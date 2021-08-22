using System.Collections.Generic;
using System.Linq;

namespace Treinamento_ORM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var cache = new CacheT<Usuario>())
            {
                /* DESAFIO 01 Concluído */
                Usuario u1    = cache.Get<Usuario>(1);
                Usuario u2    = cache.Get<Usuario>(1);
                Usuario u3    = cache.Get<Usuario>(3);
                Usuario u4    = cache.Get<Usuario>(4);
            }
        }
        
    }
}