using CL_AccesFamaTics.Controller;
using CL_AccesFamaTics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_FarmaTics.View
{
    public partial class FrmVenta : Form
    {
        private readonly FarmaTicsController _controller = new FarmaTicsController();
        Empleado us;
        Cliente cliente;
        Venta venta;

        //Objetos para la transaccion
        public FarmaTicsController controllerTransac;

        public FrmVenta()
        {
            InitializeComponent();
        }

        public FrmVenta(Empleado us)
        {
            InitializeComponent();
            this.us = us;
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            lblNombreEmp.Text = $"Empleado: {us.Nombre}";
            cliente = _controller.ObtenerClientePorID(8);
            lblCliente.Text = cliente.Nombre;

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dgvBusqueda.DataSource = _controller.ObtenerPorductoPorNombre(txtBusqueda.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var filaCell = dgvBusqueda.CurrentRow;
            int cantidad = int.Parse(nvCant.Text);
            decimal precioU = (decimal)(filaCell.Cells[2].Value);
            decimal subtotal = cantidad * precioU;



            dgvVenta.Rows.Add(filaCell.Cells[0].Value, filaCell.Cells[1].Value.ToString(), filaCell.Cells[2].Value, nvCant.Text, subtotal.ToString());

            //Calcular el total,recorrer el grid de venta sacar el valor de subtotal y sumarlo, 
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvVenta.Rows)
            {
                total += Convert.ToDecimal(fila.Cells[4].Value);
            }
            lblTotal.Text = total.ToString();

        }
        DataGridViewRow filaSeleccionada;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quitar laventa", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filaSeleccionada = dgvVenta.CurrentRow;
                if (filaSeleccionada != null && dgvVenta.Rows.Count > 0)
                {
                    decimal totalSeleccionado = decimal.Parse(filaSeleccionada.Cells[4].Value.ToString());
                    decimal total = decimal.Parse(lblTotal.Text);
                    lblTotal.Text = (total - totalSeleccionado).ToString();
                    dgvVenta.Rows.Remove(filaSeleccionada);
                }
                else
                {
                    MessageBox.Show("No hay ningun dato para borrar");
                }
            }
            else
            {

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar Venta", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                filaSeleccionada = dgvVenta.CurrentRow;
                if (filaSeleccionada != null && dgvVenta.Rows.Count > 0)
                {
                    //Guardar en venta
                    if (venta == null)
                    {
                        //Transacion 
                        using (var db = new FARMATICSEntities1())
                        {
                            //Iniciar Transaccion
                            using (var Context = db.Database.BeginTransaction())
                            {
                                try
                                {
                                    //Crear objetos y pasar el contexto
                                    controllerTransac = new FarmaTicsController(db);
                                    //Escribiendo venta
                                    venta = new Venta
                                    {
                                        EmpleadoId = us.Id,
                                        ClienteId = cliente.Id,
                                        TotalDeVenta = decimal.Parse(lblTotal.Text),
                                        FechaDeVenta = DateTime.Now,
                                    };
                                    controllerTransac.Agregar(venta);
                                    venta.NumeroDeVenta = venta.Id.ToString();
                                    MessageBox.Show("Venta Guardada");

                                    //Escrinbir detalle Venta

                                    foreach (DataGridViewRow item in dgvVenta.Rows)
                                    {
                                        DetalleVenta detalleVenta = new DetalleVenta
                                        {
                                            VentaId = venta.Id,
                                            ProductoId = int.Parse(item.Cells[0].Value.ToString()),
                                            Cantidad = int.Parse(item.Cells[3].Value.ToString())
                                        };
                                        controllerTransac.Agregar(detalleVenta);
                                        MessageBox.Show("Detalle Venta Guardado");

                                        //Actualizar Stock
                                        var p = _controller.ObtenerProductoPorID(detalleVenta.ProductoId);
                                        p.Stock -= detalleVenta.Cantidad;
                                        //throw new Exception();
                                        controllerTransac.Guardar();
                                        MessageBox.Show($"Stock actualizado a: {p.Stock}");
                                    }
                                    Context.Commit();
                                    MessageBox.Show("Transaccion Terminada");
                                }

                                catch (Exception ex)
                                {
                                    Context.Rollback();
                                    MessageBox.Show($"Transaccion Cancelada!!! {ex}");
                                }

                            }
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("No hay ningun dato para Guardar");
                }
            }
            else
            {
                MessageBox.Show("Venta Cancelada", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
   
