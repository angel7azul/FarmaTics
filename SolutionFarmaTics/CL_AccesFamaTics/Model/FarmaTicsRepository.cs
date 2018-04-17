using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_AccesFamaTics.Model
{
    public class FarmaTicsRepository:IDisposable
    {
        //Aplicacion pro GitHub
        public FARMATICSEntities1 db;

        public FarmaTicsRepository()
        {
            db = new FARMATICSEntities1();
        }
        //Constructor para la transaccion :D
        public FarmaTicsRepository(FARMATICSEntities1 context)
        {
            db = context;
        }

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

        //Personas que se registraron el mismo dia
        public IQueryable<Cliente> GetCustomersByRegisterDate(DateTime FR)
        {
            var query = from c in db.Clientes
                        where c.FechaDeRegistro.Value.Date == FR.Date
                        select c;
            return query;
        }      
        
        //Nombre y telefono por fecha de registro
        public List<dynamic> GetCustomerByHireDate(DateTime f)
        {
            var q = from emp in db.Clientes
                    where emp.FechaDeRegistro.Value.Date == f.Date
                    select new { Nombre = emp.Nombre, Telefono = emp.Telefono };
            return q.ToList<dynamic>();
        }
        //Todos los datos del cleinte por fecha de registro
        public IQueryable<Cliente> GetAllCustomersByHireDate(DateTime f)
        {
            var q = from c in db.Clientes
                    where c.FechaDeRegistro.Value.Date == f.Date
                    select c;
            return q;
        }
        //Historial de compras de un cliente
        public ICollection<Venta> GetCustomerBySale(int id)
        {
            return db.Clientes.Find(id).Ventas;
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
        //Listar todos los productos que pertenecen a una categoria
        //public IQueryable<Producto> GetProductsByCategoryName(string nomCat)
        //{
        //    var query = from p in db.Productos
        //                where p.Categoria.Nombre == nomCat
        //                select p;
        //    return query;
        //}
        //Lista de los nombres de productos que caducan este mes
        public List<dynamic>  GetProductsCaducados()
        {
            var query = from p in db.Productos
                        where p.Caducidad.Date.Month == DateTime.Today.Month
                        select new { Nombre = p.Nombre, FechaDeCaducidad = p.Caducidad };
            return query.ToList<dynamic>();
        }
        //Productos con su nombre mediante su presentacion
        //public IQueryable<dynamic> GetProductByPresentation(string nom)
        //{
        //    return db.Productos.Where(p => p.Nombre.Equals(nom)&&p.Stock>10).Select(p => new { Nombre = p.Nombre,Presentacion = p.Categoria.Presentacion });
        //}
        //Cuantos Productos con menos de 10 existencias y su nombre
        public IQueryable<dynamic> ProductsByAvaliable()
        {
            return db.Productos.Where(p => p.Stock < 10).Select(p => new { Nombre = p.Nombre,Cantidad = p.Stock });
        }
        //Busqueda de producto por codigo de barra
        public Producto ProductByCodigoBarra(string cod)
        {
            return db.Productos.FirstOrDefault(p => p.CodigoBarras.Equals(cod));
        }
        //Lista de productos por laboratorio
        public IQueryable<Producto> GetProductsByLaboratory(string lab)
        {
            return db.Productos.Where(p => p.Laboratorio.Equals(lab));
        }
        //Todos los productos por el nombre
        public IQueryable<Producto> GetProductsByName(string nombre)
        {
            return db.Productos.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower()));
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
        //LOGIN
        public Empleado Login(string password,string user)
        {
            return db.Empleados.FirstOrDefault(e => e.Usuario.Equals(user) && e.Contraseña.Equals(password));
        }
        //Dar regalo a los que cumplan años este mes nombre y telefono
        public List<dynamic> GetCustomersBirthDayThisMonth()
        {
            var query = from e in db.Empleados
                        where e.FechaNacimiento.Value.Month == DateTime.Today.Month
                        select new { Nom = e.Nombre, Tel = e.Telefono };
            return query.ToList<dynamic>();
        }
        //Empleado por fecha de contratacion
        public IQueryable<Empleado> GetEmployeeByHireDate(DateTime f)
        {
            var q = from emp in db.Empleados
                    where emp.FechaContratacion.Date == f.Date
                    select emp;
            return q;
        }
        //Empleados por cumpleannos nombre y fecha de nac
        public List<dynamic> GetEmployeeByBirthDay()
        {
            var q = from emp in db.Empleados
                    where emp.FechaNacimiento.Value.Month == DateTime.Today.Month
                    select new { Nombre = emp.Nombre, Fecha = emp.FechaNacimiento };
            return q.ToList<dynamic>();
        }
        #endregion

        //#region Categoria
        //public IQueryable<Categoria> GetallCategory()
        //{
        //    return db.Categorias;
        //}

        //public Categoria GetCategoryById(int id)
        //{
        //    return db.Categorias.Find(id);
        //}
        //public void Add(Categoria np)
        //{
        //    db.Categorias.Add(np);
        //    Save();
        //}
        //public void Delete(Categoria np)
        //{
        //    db.Categorias.Remove(np);
        //    Save();
        //}
        //#endregion

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
