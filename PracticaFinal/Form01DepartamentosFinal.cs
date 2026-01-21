using NetAppAdoNet.Models;
using PracticaFinal.Models;
using PracticaFinal.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFinal
{
    public partial class Form01DepartamentosFinal : Form
    {
        RepositoryDepartamentos repo;
        public Form01DepartamentosFinal()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            LoadDepartamentos();
        }

        private async Task LoadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetDepartamentosAsync();
            this.cmbDepartamentos.Items.Clear();
            foreach (string nombre in departamentos)
            {
                this.cmbDepartamentos.Items.Add(nombre);
            }

        }

        private async void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            Departamentos model = await this.repo.GetEmpleadosDepartamentoAsync(nombre);
            this.lstEmpleados.Items.Clear();
            foreach (string ape in model.Apellidos)
            {
                this.lstEmpleados.Items.Add(ape);
            }
            this.txtId.Text = model.IdDepartamento.ToString();
            this.txtNombre.Text = model.Nombre.ToString();
            this.txtLocalidad.Text = model.Localidad.ToString();
        }

        private async void btnInsertarDepartamento_ClickAsync(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;
            await this.repo.CreateDepartamentoAsync(id, nombre, localidad);
            await this.LoadDepartamentos();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string apellido =this.txtApellido.Text;
            string oficio = this.txtOficio.Text;
            int salario = int.Parse(this.txtSalario.Text);
            await this.repo.UpdateEmpleadoAsync(apellido, oficio, salario);
          

        }

        private async void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string apellido = this.lstEmpleados.SelectedItem.ToString();
            Empleado model = await this.repo.GetDatosEmpleadosAsync(apellido);
            this.txtApellido.Text = model.Apellido.ToString();
            this.txtOficio.Text = model.Oficio.ToString();
            this.txtSalario.Text = model.Salario.ToString();

        }
    }
}
