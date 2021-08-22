using System.Collections.Generic;
using System.Linq;

namespace Treinamento_ORM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = Context.Get("Treinamento-ORM"))
            {
                // Desafio 01 - Get Usuário
                Usuario u1 = context.UsuarioSet.Get(2);
                
                // Desafio 02 - Criando novo Usuário
                Usuario u2 = new Usuario("Carlos Germano A Carvalho");
                u1 = context.UsuarioSet.Get(2);
                context.Save();
                
                // Desafio 03 - Realizando testes de multithreading
                
            }
        }
        
    }
}