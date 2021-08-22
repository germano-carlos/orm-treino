using System.Collections.Generic;
using System.Linq;

namespace Treinamento_ORM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*using (var cache = new CacheT<Usuario>())
            {
                
                Usuario u1    = cache.Get<Usuario>(1);
                Usuario u2    = cache.Get<Usuario>(1);
                Usuario u3    = cache.Get<Usuario>(3);
                Usuario u4    = cache.Get<Usuario>(4);
            }
            
            using (var cache = new CacheT<Usuario>())
            {
                
                Usuario u1     = new Usuario("Carlos Germano A Carvalho");
            }*/

            using (var context = new Context())
            {
                Usuario u1 = context.UsuarioSet.Get(2);
                Usuario u2 = new Usuario("Carlos Germano A Carvalho");
            }
        }
        
    }
}