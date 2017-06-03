using AT_AspNet.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AT_AspNet.Presentation.Models
{
    public class LivroViewModel
    {
        public int LivroId { get; set; }
        [Required]
        [StringLength(250)]
        public string Titulo { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int Ano { get; set; }

        public int AutorId { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }
    }
}