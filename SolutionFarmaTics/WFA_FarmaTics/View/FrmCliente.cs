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
    public partial class FrmCliente : Form
    {
        private FarmaTicsController _controller = new FarmaTicsController();
        Cliente c;  
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            c = new Cliente
            {
                Nombre = txt_Nombre.Text,
                Direccion = txt_Direccion.Text,
                Telefono = txt_Telefono.Text,
                Email = txt_Email.Text,
                FechaDeRegistro = dtp_FechaRegistro.Value
            };

            _controller.Agregar(c);
            _controller.Guardar();
            MessageBox.Show("Cliente Agregado!!");
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            var clientes = _controller.ObtenerTodosLosClientes();
            foreach (var c in clientes)
            {
                dgv_Clientes.Rows.Add(c.Id, c.Nombre, c.Direccion, c.Telefono, c.Email, c.FechaDeRegistro.Value.ToShortDateString());
            }
        }
    }
}
