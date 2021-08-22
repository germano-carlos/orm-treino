using System;
using System.Collections.Generic;
using System.Linq;

namespace Treinamento_ORM
{
    public class DBSet<T>
    {
        private Dictionary<int, ItemCache<object>> itens = new Dictionary<int, ItemCache<object>>();
        private static Cache<T> cache2nivel = new Cache<T>(3600);

        public DBSet()
        {
            
        }
        
        public T Get (int key)
        {
            lock (this)
            {
                if (itens.ContainsKey(key))
                    return (T)itens[key].value;

                // Chama o Cache de 2 nível para validação do objeto desejado !
                var value2nivel = cache2nivel.Get<T>(key);
                if (value2nivel == null)
                    return default;
                itens.Add(key, new ItemCache<object>(key, value2nivel));
                return (T)itens[key].value;
            }
        }
        
        public void Add(T Value)
        {
            lock (this)
            {
                int id = 2;//new Random().Next();
                itens.Add(id, new ItemCache<object>(id, Value, TypeItem.NEW_OBJECT));
            }
        }
        
        public void Save()
        {
            lock (this)
            {
                var registers = itens.Values.Where(s => s.type == TypeItem.NEW_OBJECT).ToList();
                // Preciso de ir no cache 2 nivel, ou posso ir ao broker direto ?
                // cache2nivel.Add();
                foreach (var o in registers)
                {
                    var element = (T)o.value;
                    Broker.Add(element.GetType().ToString(), element);
                }
                
            }
        }
    }
}