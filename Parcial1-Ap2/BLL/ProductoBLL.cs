using Microsoft.EntityFrameworkCore;
using Parcial1_Ap2.DAL;
using Parcial1_Ap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Parcial1_Ap2.BLL
{
    public class ProductoBLL
    {
        public static bool Guardar(Producto producto)
        {
            if (!Existe(producto.productoId))

                return Insertar(producto);
            else
                return Modificar(producto);

        }
        private static bool Insertar(Producto producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Productos.Add(producto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Producto producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(producto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var auxProducto = contexto.Productos.Find(id);
                if (auxProducto != null)
                {
                    contexto.Productos.Remove(auxProducto);
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Producto Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Producto producto;

            try
            {
                producto = contexto.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return producto;

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Productos.Any(p=>p.productoId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }

        public static List<Producto> GetList(Expression<Func<Producto, bool>> expression)
        {
            List<Producto> lista = new List<Producto>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Productos.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
