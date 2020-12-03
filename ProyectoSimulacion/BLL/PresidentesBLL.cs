using Microsoft.EntityFrameworkCore;
using ProyectoSimulacion.DAL;
using ProyectoSimulacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoSimulacion.BLL
{
    public class PresidentesBLL
    {

        public static bool Guardar(Presidentes presidentes)
        {
            if (!Existe(presidentes.Id))
            {
                return Insertar(presidentes);
            }
            else
            {
                return Modificar(presidentes);
            }

        }

        public static bool Insertar(Presidentes presidentes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Presidente.Add(presidentes) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Presidentes presidentes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(presidentes).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        private static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Presidente.Any(d => d.Id == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Presidente.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Presidentes Buscar(int id)
        {
            Presidentes presidentes = new Presidentes();
            Contexto db = new Contexto();

            try
            {
                presidentes = db.Presidente.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return presidentes;
        }

        public static List<Presidentes> GetList(Expression<Func<Presidentes, bool>> presidente)
        {
            List<Presidentes> Lista = new List<Presidentes>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Presidente.Where(presidente).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

    }
}
