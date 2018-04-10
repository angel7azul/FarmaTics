using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CL_AccesFamaTics.Controller;
using CL_AccesFamaTics.Model;

namespace WFA_FarmaTics.View
{
    public partial class FrmMenuContextual : Form
    {
        private readonly FarmaTicsController _controller = new FarmaTicsController();
        Cliente cl;
        public FrmMenuContextual()
        {
            InitializeComponent();
        }

        private void FrmMenuContextual_Load(object sender, EventArgs e)
        {
            var clientes = _controller.ObtenerTodosLosClientes();
            dgv_Clientes.DataSource = clientes;
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cl = _controller.ObtenerClientePorID(int.Parse(dgv_Clientes.CurrentRow.Cells[0].Value.ToString()));

            FrmDetalleCliente dc = new FrmDetalleCliente(cl);
            dc.ShowDialog();
        }
    }
}
