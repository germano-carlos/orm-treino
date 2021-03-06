using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Treinamento_ORM
{
    public class CacheT<T> : IDisposable
    {
        private Dictionary<int, ItemCache<object>> itens = new Dictionary<int, ItemCache<object>>();
        private static Cache<Usuario> cache2nivel = new Cache<Usuario>(3600);
        public CacheT()
        {
        }

        public T Get<T>(int key)
        {
            lock (this)
            {
                if (itens.ContainsKey(key))
                    return (T)itens[key].value;

                // Chama o Cache de 2 nível para validação do objeto desejado !
                var value2nivel = cache2nivel.Get<T>(key);
                itens.Add(key, new ItemCache<object>(key, value2nivel));
                return (T)itens[key].value;
            }
        }

        public static void Add(T Value)
        {
            
        }
        
        public void Dispose()
        {
            // Reseta os caches, qnd fechado a conexão
            itens = new Dictionary<int, ItemCache<object>>();
            cache2nivel = new Cache<Usuario>();
        }
    }
}