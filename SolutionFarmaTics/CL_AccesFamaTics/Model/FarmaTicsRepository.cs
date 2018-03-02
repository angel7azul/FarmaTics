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

        public void Delete(Producto p)
        {
            db.Productos.Remove(p);
            Save();
        }
        #endregion

        #region Venta
        public IQueryable<Venta> GetAllVentas()
        {
            return db.Ventas;
        }

        public Venta GetVentaById(int id)
        {
            return db.Ventas.Find(id);
        }

        public void Add(Venta nv)
        {
            db.Ventas.Add(nv);
            Save();
        }

        public void Delete (Venta ov)
        {
            db.Ventas.Remove(ov);
            Save();
        }
        #endregion

        #region Detalle Venta
        public IQueryable<DetalleVenta> GetAllDetalleVenta()
        {
            return db.DetalleVentas;
        }

        public DetalleVenta GetVentaDetailById(int id)
        {
            return db.DetalleVentas.Find(id);
        }
        public void Add(DetalleVenta np)
        {
            db.DetalleVentas.Add(np);
            Save();
        }
        public void Delete(DetalleVenta np)
        {
            db.DetalleVentas.Remove(np);
            Save();
        }
        #endregion

        #region Empleado
        public IQueryable<Empleado> GetallEmployee()
        {
            return db.Empleados;
        }

        public Empleado GetEmployeeById(int id)
        {
            return db.Empleados.Find(id);
        }
        public void Add(Empleado np)
        {
            db.Empleados.Add(np);
            Save();
        }
        public void Delete(Empleado np)
        {
            db.Empleados.Remove(np);
            Save();
        }
        #endregion

        #region Categoria
        public IQueryable<Categoria> GetallCategory()
        {
            return db.Categorias;
        }

        public Categoria GetCategoryById(int id)
        {
            return db.Categorias.Find(id);
        }
        public void add(Categoria np)
        {
            db.Categorias.Add(np);
            Save();
        }
        public void Remove(Categoria np)
        {
            db.Categorias.Remove(np);
            Save();
        }
        #endregion

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
