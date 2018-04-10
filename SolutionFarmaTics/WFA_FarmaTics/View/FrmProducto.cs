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
    public partial class FrmProducto : Form
    {
        Producto P;
        FarmaTicsController _controller = new FarmaTicsController();
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCat.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Error, Debes Ingresar Datos");
            }
            else
            {
                bool IsGeneric = Convert.ToBoolean(cbxGeneric.Text);
                P = new Producto()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDesc.Text,
                    Precio = Convert.ToInt32(txtPrecio.Text),
                    Caducidad = dtpCaducidad.Value.Date,
                    CodigoBarras = txtCodBarras.Text,
                    Categoria = txtCat.Text,
                    Stock = Convert.ToInt32(txtStock.Text),
                    Laboratorio = txtLaboratorio.Text,
                    Presentacion = txtPresentacion.Text,
                    IsGeneric = IsGeneric
                };
                _controller.Agregar(P);
                MessageBox.Show("Dato Agregado");
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            var pro = _controller.ObtenerTodosLosProductos();
            dgvProducts.DataSource = pro;
        }
    }
}
