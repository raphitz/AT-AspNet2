using AT_AspNet.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AT_AspNet.Presentation.Models
{
    public class AutorViewModel
    {
        public int AutorId { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Required]
        [StringLength(150)]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}