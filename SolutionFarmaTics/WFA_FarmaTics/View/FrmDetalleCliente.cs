using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CL_AccesFamaTics.Model;

namespace WFA_FarmaTics.View
{
    public partial class FrmDetalleCliente : Form
    {
        private Cliente cl;

        public FrmDetalleCliente()
        {
            InitializeComponent();
        }

        public FrmDetalleCliente(Cliente cl)
        {
            InitializeComponent();
            this.cl = cl;
        }

        private void FrmDetalleCliente_Load(object sender, EventArgs e)
        {
            txt_correo.Text = cl.Email;
            txt_Nombre.Text = cl.Nombre;
            txt_telefono.Text = cl.Telefono;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
