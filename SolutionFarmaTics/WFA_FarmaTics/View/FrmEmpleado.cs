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
    public partial class FrmEmpleado : Form
    {
        Empleado emp;
        private FarmaTicsController _controller = new FarmaTicsController();
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            emp = new Empleado
            {
                Nombre = txt_Nombre.Text,
                Telefono = txt_Telefono.Text,
                Direccion = txt_Direccion.Text,
                Email = txt_Email.Text,
                Usuario = txt_Usuario.Text,
                Contraseña = txt_Contra.Text,
                FechaNacimiento = dtp_FechaNac.Value,
                FechaContratacion = dtp_FechaContratacion.Value
            };
            _controller.Agregar(emp);
            _controller.Guardar();
            MessageBox.Show("Empleado Agregado con Exito!");
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            var empleados = _controller.BuscarTodosLosEmpleados();

            foreach(var emp in empleados)
            {
                dgv_TodosEmpleados.Rows.Add(emp.Id, emp.Nombre, emp.Direccion,emp.Email,emp.Telefono,emp.FechaContratacion.ToShortDateString(),emp.FechaNacimiento.Value.ToShortDateString(),emp.Usuario,emp.Contraseña);
            }

            dgv_TodosEmpleados.AllowUserToAddRows = false;
        }
    }
}
