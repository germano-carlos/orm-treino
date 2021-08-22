using System.Collections.Generic;
using System.Linq;

namespace Treinamento_ORM
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }


        public Usuario()
        {
            
        }

        public Usuario(string nome)
        {
            var lista = (List<Usuario>) Usuario.Listar();
            id = lista.OrderByDescending(s => s.id).Take(1).ToList()[0].id + 1;
            this.nome = nome;

            // Adicionar no context !
            Context.Get().UsuarioSet.Add(this);
        }

        public static object Get(int id)
        {
            if (id != 1)
                return null;

            return new Usuario() { id = id, nome = "Carlos Germano Avelar Carvalho"};
        }
        
        public static object Listar()
        {
            var list = new List<Usuario>()
            {
                new Usuario {id = 1, nome = "Carlos Germano Avelar Carvalho"},
                new Usuario {id = 2, nome = "Amanda Lima Carvalho"},
                new Usuario {id = 3, nome = "Alef Richard Ferreira"},
                new Usuario {id = 4, nome = "Gabriel Augusto"},
                new Usuario {id = 5, nome = "Rediner Vinhal"},
                new Usuario {id = 6, nome = "Isabela Malachias"},
                new Usuario {id = 7, nome = "Lucas Bonfioli"},
                new Usuario {id = 8, nome = "Jonathan Pimenta"},
                new Usuario {id = 9, nome = "Thales Gregory"},
                new Usuario {id = 10, nome = "Joaquim Alberto"},
                new Usuario {id = 11, nome = "Vinicius Moraes"}
            };

            return list;
        }
    }
}