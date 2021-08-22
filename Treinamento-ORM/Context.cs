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
            if (!instance.IsValueCreated || instance.Value == null)
                throw new Exception("Uma transação não pode ser iniciada sem título.");
            return instance.Value;
        }

        internal static Context Get(string titulo)
        {
            if (instance.IsValueCreated && instance.Value != null)
                throw new Exception("Uma transação só pode ter um título.");
            return instance.Value = new Context();
        }

        public Context()
        {
        }

        public void Save()
        {
            UsuarioSet.Save();
        }
        public void Dispose()
        {
            instance.Value = null;
        }
    }
}