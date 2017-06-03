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

        public bool Selecionado { get; set; }

        
    }
}