﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_AspNet.Domain
{
    public class Livro
    {
        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public string Isbn { get; set; }

        public int Ano { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }
    }
}
