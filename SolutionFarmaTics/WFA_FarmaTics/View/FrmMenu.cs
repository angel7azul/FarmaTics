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
    public partial class FrmMenu : Form
    {
        private Empleado us;

        public FrmMenu()
        {
            InitializeComponent();
        }

        public FrmMenu(Empleado us)
        {
            InitializeComponent();
            this.us = us;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            lbltool_Estado.Text = $"Bienvenido: {us.Nombre}";
        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            FrmEmpleado emp = new FrmEmpleado();
            emp.ShowDialog();
        }

        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            FrmCliente c = new FrmCliente();
            c.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenuContextual cl = new FrmMenuContextual();
            cl.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto p = new FrmProducto();
            p.ShowDialog();
        }
    }
}
