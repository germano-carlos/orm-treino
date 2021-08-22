using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Treinamento_ORM
{
    public class Cache<T>
    {
        private Dictionary<int, ItemCache<object>> itens = new Dictionary<int, ItemCache<object>>();
        private Thread Thread;
        private int validadeSegundos;
        public Cache()
        {
        }

        public Cache(int segundos)
        {
            validadeSegundos = segundos;
            Thread = new Thread(Limpar);
            Thread.Start();
        }

        public T Get<T>(int key)
        {
            lock (this)
            {
                if (itens.ContainsKey(key))
                    return (T)itens[key].value;

                // Chama o Broker para busca do objeto desejado !
                var o = Broker.Obter<T>(key);
                if (o == null)
                    return default;
                    
                itens.Add(key,new ItemCache<object>(key, o));
                return (T)itens[key].value;
            }
        }

        private void Limpar()
        {
            while (true)
            {
                lock (this)
                {
                    List<int> keys = itens.Keys.ToList();
                    foreach (int k in keys)
                        if (!itens[k].IsValid(validadeSegundos))
                            itens.Remove(k);
                }
                Thread.Sleep(1000);
            }
        }
    }
}