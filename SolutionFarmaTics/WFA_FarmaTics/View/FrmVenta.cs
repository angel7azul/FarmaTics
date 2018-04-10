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
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {

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

            dgvVenta.Rows.Add(filaCell.Cells[0].Value, filaCell.Cells[1].Value.ToString(), filaCell.Cells[2].Value,nvCant.Text,subtotal.ToString());
            //MessageBox.Show(filaCell.Cells[20].Value.ToString());
        }
    }
}
