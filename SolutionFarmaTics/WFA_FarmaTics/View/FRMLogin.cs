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
using WFA_FarmaTics.View;

namespace WFA_FarmaTics
{
    public partial class FRM_Login : Form
    {
        private FarmaTicsController _controller = new FarmaTicsController();
        Empleado us;

        public FRM_Login()
        {
            InitializeComponent();
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            us = _controller.Login(txtPassword.Text, txtUser.Text);
            if (us != null)
            {
                FrmMenu menu = new FrmMenu(us);
                menu.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error!!!!");
            }
        }
    }
}
