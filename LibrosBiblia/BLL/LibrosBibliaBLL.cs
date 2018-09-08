using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LibrosBiblia.DAL;
using LibrosBiblia.Entidades;

namespace LibrosBiblia.BLL
{
    public class LibrosBibliaBLL
    {
        /// <summary>
        /// Permite Guardar una entidad en la base datos
        /// </summary>
        /// <param name="Libro"></param>
        /// <returns></returns>
        public static bool Guardar(LibrosDeLaBiblia Libro)
        {
            bool paso = false;
            contexto contexto = new contexto();
            try
            {
                if (contexto.LibrosDeLaBiblia.Add(Libro) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        /// <summary>
        /// permite Modificar una entidad en la base de datos
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public static bool Modificar(LibrosDeLaBiblia Libro)
        {
            bool paso = false;
            contexto contexto = new contexto();
            try
            {
                contexto.Entry(Libro).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Eliminar una entidad de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            contexto contexto = new contexto();
            try
            {
                LibrosDeLaBiblia Libro = contexto.LibrosDeLaBiblia.Find(id);

                contexto.LibrosDeLaBiblia.Remove(Libro);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Buscar una entidad en la base de datos 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static LibrosDeLaBiblia Buscar(int id)
        {
            contexto contexto = new contexto();
            LibrosDeLaBiblia Libro = new LibrosDeLaBiblia();

            try
            {
                Libro = contexto.LibrosDeLaBiblia.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libro;
        }

        public static List<LibrosDeLaBiblia> GetList(Expression<Func<LibrosDeLaBiblia, bool >> expression)
        {
            List<LibrosDeLaBiblia> Libros = new List<LibrosDeLaBiblia>();
            contexto contexto = new contexto();
            try
            {
                Libros = contexto.LibrosDeLaBiblia.Where(expression).ToList();
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return Libros;
        }
    }
}
