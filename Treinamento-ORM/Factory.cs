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
            Registry<Usuario>("usuario");
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

            ConstructorInfo ci = tables[table].GetConstructor(new Type[] { } );
            return (T)ci.Invoke(new object[] { null } );
        }
    }
}