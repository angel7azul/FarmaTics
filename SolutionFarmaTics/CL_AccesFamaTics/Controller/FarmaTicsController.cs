using CL_AccesFamaTics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_AccesFamaTics.Controller
{
    public class FarmaTicsController
    {
        private readonly FarmaTicsRepository repository = new FarmaTicsRepository();

        //todos los metodos publicos,cualquiere interface o iqueryable seran listas, si lo son se respeta el tipo de dato
        
            //Cliente Terminado
        #region Cliente
        public List<Cliente> ObtenerTodosLosClientes()
        {
            return repository.GetAllClientes().ToList();
        }

        public Cliente ObtenerClientePorID(int id)
        {
            return repository.GetClienteById(id);
        }

        public void Agregar(Cliente nc)
        {
            repository.Add(nc);
        }
        public void Eliminar(Cliente oc)
        {
            repository.Delete(oc);
        }

        //Personas que se registraron el mismo dia
        public List<Cliente> ClientePorFechaRegistroMismoDia(DateTime fc)
        {
            return repository.GetCustomersByRegisterDate(fc).ToList();
        }

        //Nombre y telefono por fecha de registro
        public List<dynamic> ClientePorFechaRegistro(DateTime f)
        {
            return repository.GetCustomerByHireDate(f).ToList();
        }

        //Todos los datos del cliente por fecha de registro
        public List<Cliente> TodosLosClientesFechaRegistro(DateTime f)
        {
            return repository.GetAllCustomersByHireDate(f).ToList();
        }

        //Historial de compras de un cliente
        public List<Venta> ClientesPorCompras(int id)
        {
            return repository.GetCustomerBySale(id).ToList();
        }

        #endregion

        #region Producto
        public List<Producto> ObtenerTodosLosProductos()
        {
            return repository.GetAllProducts().ToList();
        }

        public Producto ObtenerProductoPorID(int id)
        {
            return repository.GetProductById(id);
        }

        public void Agregar(Producto p)
        {
            repository.Add(p);
        }

        public void Eliminar(Producto p)
        {
            repository.Delete(p);
        }

        //Listar todos los productos que pertenecen a una categoria
        public List<Producto> ObtenerProductosPorCategoria(string cat)
        {
            return repository.GetProductsByCategoryName(cat).ToList();
        }

        //Lista de los nombres de productos que caducan este mes
        public List<dynamic> ObtenerProductosCaducados()
        {
            return repository.GetProductsCaducados();
        }

        //Productos con su nombre mediante su presentacion
        public List<dynamic> ObtenerProductosPorPresentacion(string nomP)
        {
            return repository.GetProductByPresentation(nomP).ToList();
        }

        //Cuantos Productos con menos de 10 existencias y su nombre
        public List<dynamic> ProductosDisponibles()
        {
            return repository.ProductsByAvaliable().ToList();
        }

        //Busqueda de producto por codigo de barra
        public Producto ProductoPorCodigoDeBarra (string cod)
        {
            return repository.ProductByCodigoBarra(cod);
        }

        //Lista de productos por laboratorio
        public List<Producto> ObtenerProductoPorLab(string nomLab)
        {
            return repository.GetProductsByLaboratory(nomLab).ToList();
        }
        #endregion

        #region Venta
        public List<Venta> ObtenerTodasLasVentas()
        {
            return repository.GetAllVentas().ToList();
        }

        public Venta ObtenerVentaPorID(int id)
        {
            return repository.GetVentaById(id);
        }

        public void Agregar(Venta v)
        {
            repository.Add(v);
        }

        public void Eliminar(Venta v)
        {
            repository.Delete(v);
        }
        #endregion

        #region DetalleVenta

        public List<DetalleVenta> ObtenerTodasLosDetalleVenta()
        {
            return repository.GetAllDetalleVenta().ToList();
        }

        public DetalleVenta ObtenerDetalleVentaPorID(int id)
        {
            return repository.GetVentaDetailById(id);
        }

        public void Agregar(DetalleVenta dv)
        {
            repository.Add(dv);
        }
        public void Eliminar(DetalleVenta dv)
        {
            repository.Delete(dv);
        }
        #endregion

        #region Empleado
        public List<Empleado> BuscarTodosLosEmpleados()
        {
            return repository.GetallEmployee().ToList();
        }

        public Empleado ObtenerEmpleadoPorID(int id)
        {
            return repository.GetEmployeeById(id);
        }

        public void Agregar(Empleado emp)
        {
            repository.Add(emp);
        }

        public void Eliminar(Empleado emp)
        {
            repository.Delete(emp);
        }

        //LOGIN
        public Empleado Login(string pass, string user)
        {
            return repository.Login(user, pass);
        }

        //Dar regalo a los que cumplan años este mes nombre y telefono
        public List<dynamic> EmpleadosBirthDayEsteMes()
        {
            return repository.GetCustomersBirthDayThisMonth();
        }

        //Empleado por fecha de contratacion
        public List<Empleado> EmpleadoPorFechaContratacion(DateTime f)
        {
            return repository.GetEmployeeByHireDate(f).ToList();
        }

        //Empleados por cumpleannos nombre y fecha de nac
        public List<dynamic> EmpleadosPorFechaDeCumple()
        {
            return repository.GetEmployeeByBirthDay();
        }


        #endregion

        #region Categoria

        public List<Categoria> TodasLasCategorias()
        {
            return repository.GetallCategory().ToList();
        }

        public Categoria CategoriaPorID(int id)
        {
            return repository.GetCategoryById(id);
        }

        public void Agregar(Categoria cat)
        {
            repository.Add(cat);
        }

        public void Eliminar(Categoria cat)
        {
            repository.Delete(cat);
        }

        #endregion

        public void Guardar()
        {
            repository.Save();
        }

    }
}
