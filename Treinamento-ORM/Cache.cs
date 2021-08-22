using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Treinamento_ORM
{
    public class Cache<T>
    {
        private Dictionary<int, ItemCache<object>> itens = new Dictionary<int, ItemCache<object>>();

        public Cache()
        {
        }

        public T Get<T>(int key)
        {
            lock (this)
            {
                if (itens.ContainsKey(key))
                    return (T)itens[key].value;

                // Chama o Broker para busca do objeto desejado !
                var o = Broker.Obter<T>(key);
                itens.Add(key,new ItemCache<object>(key, o));
                return (T)itens[key].value;
            }
        }

        public void Add(int key, T value)
        {
            lock (this)
            {
                if (itens.ContainsKey(key))
                    itens[key].update(value);
                else
                {
                    // Chama o Cache de 2 nível para validação do objeto desejado !
                    bool ret = true;
                    if(ret)
                        itens.Add(key, new ItemCache<object>(key, value));
                }
            }
        }
    }
}