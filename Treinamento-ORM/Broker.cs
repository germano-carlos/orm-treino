using System;

namespace Treinamento_ORM
{
    public class Broker
    {
        public static T Obter<T>(int id)
        {
            if (typeof(T) == typeof(Usuario))
                return (T)Usuario.Get(id);
            return default;
        }
        
        public static T Listar<T>(int id)
        {
            if (typeof(T) == typeof(Usuario))
                return (T)Usuario.Listar();
            return default;
        }

        public static T Add<T>(string type, T Value)
        {
            return Factory.CreateFactory<T>(type, Value);;
        }
    }
}