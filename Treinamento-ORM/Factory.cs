using System;
using System.Collections.Generic;
using System.Reflection;

namespace Treinamento_ORM
{
    public class Factory
    {
        private static readonly Dictionary<string, Type> tables;

        static Factory()
        {
            tables = new Dictionary<string, Type>();
            Registry<Usuario>("Treinamento_ORM.Usuario");
        }
        
        public static void Registry<T>(string table)
        {
            if (!tables.ContainsKey(table))
                tables.Add(table, typeof(T));
        }
        
        // Para este caso em especifico o parametro será o nome da nossa tabela Usuario
        public static T CreateFactory<T>(string table, T Value)
        {
            if (!tables.ContainsKey(table))
                throw new Exception("É necessario inserir uma tabela para conseguir invocar a construtura");

            // Simula a criação de uma instância de objeto
            var objectType = Type.GetType(Value.ToString());
            var instance = Activator.CreateInstance(objectType);

            return (T)instance;
        }
    }
}