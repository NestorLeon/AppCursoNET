using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Datos;

namespace MyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargaDatos();
        }

        private void CargaDatos()
        {
            List<Usuario> usuarios = clsNUsuario.ObtenerLista();
            dgvDatos.DataSource = usuarios;

            #region FORMATEAR GRID
            if (dgvDatos.Columns.Contains("ID"))
            {
                dgvDatos.Columns["ID"].Visible = false;
            }
            if (dgvDatos.Columns.Contains("Usuario1"))
            {
                dgvDatos.Columns["Usuario1"].HeaderText = "Nombre de Usuario";
            }
            if (dgvDatos.Columns.Contains("CorreoElectronico"))
            {
                dgvDatos.Columns["CorreoElectronico"].HeaderText = "Correo Electrónico";
            }
            #endregion
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            clsNUsuario.CrearCuenta(
                txtUsuario.Text, 
                txtPassword.Text, 
                txtCorreoElectronico.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelDatos.BringToFront();
            panelDatos.Visible = true;
            panelGrid.SendToBack();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

            clsNUsuario.EliminarCuenta(ID);

            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelGrid.BringToFront();
            panelDatos.Visible = false;
            panelDatos.SendToBack();
        }
    }
}
