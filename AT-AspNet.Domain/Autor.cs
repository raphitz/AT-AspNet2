using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_AspNet.Domain
{
    public class Autor
    {
        public int AutorId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }

    }
}
