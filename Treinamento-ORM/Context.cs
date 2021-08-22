using System;
using System.Threading;

namespace Treinamento_ORM
{
    public class Context : IDisposable
    {
        private static ThreadLocal<Context> instance = new ThreadLocal<Context>();
        public DBSet<Usuario> UsuarioSet { get; set; } = new DBSet<Usuario>();

        internal static Context Get()
        {
            return instance.Value = new Context();
        }
        public Context()
        {
        }
        public void Dispose()
        {
            instance.Value = null;
        }
    }
}