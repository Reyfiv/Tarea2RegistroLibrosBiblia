using LibrosBiblia.Entidades;
using System.Data.Entity;

namespace LibrosBiblia.DAL
{
    public class contexto : DbContext
    { 
        public DbSet<LibrosDeLaBiblia> LibrosDeLaBiblia { get; set; }

        public contexto() : base("ConStr")
        {   }
    }
}
