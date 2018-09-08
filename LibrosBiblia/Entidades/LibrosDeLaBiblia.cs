using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBiblia.Entidades
{
    public class LibrosDeLaBiblia
    {
        [Key]
        public int LibroId { get; set; }
        public string Descripcion { get; set; }
        public string Siglas { get; set; }
        public string TipoId { get; set; }

        public LibrosDeLaBiblia()
        {
            LibroId = 0;
            Descripcion = string.Empty;
            Siglas = string.Empty;
            TipoId = string.Empty;
        }
    }
}
