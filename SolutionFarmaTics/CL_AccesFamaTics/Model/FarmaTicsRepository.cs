using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_AccesFamaTics.Model
{
    public class FarmaTicsRepository
    {
        private readonly FARMATICSEntities db = new FARMATICSEntities();

        #region Cliente
        public IQueryable<Cliente> GetAllClientes()
        {
            return db.Clientes;
        }

        public Cliente GetClienteById(int id)
        {
            return db.Clientes.Find(id);
        }

        public void Add(Cliente nc)
        {
            db.Clientes.Add(nc);
            Save();
        }

        public void Delete(Cliente oc)
        {
            db.Clientes.Remove(oc);
        }
        #endregion

        #region Producto
        public IQueryable<Producto> GetAllProducts()
        {
           return db.Productos;
        }

        public Producto GetProductById(int id)
        {
            return db.Productos.Find(id);
        }

        public void Add(Producto p)
        {
            db.Productos.Add(p);
            Save();
        }

        public void Remove(Producto p)
        {
            db.Productos.Remove(p);
            Save();
        }
        #endregion

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
