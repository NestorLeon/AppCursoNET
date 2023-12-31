﻿using System;
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
using Utilerias;

namespace MyApp
{
    public partial class frmUsuarios : Form
    {
        #region PROPIEDADES
        public EstadosDeForma Estado { get; set; }
        #endregion

        #region CONSTRUCTORES
        public frmUsuarios()
        {
            InitializeComponent();
            CargaDatos();
            this.Estado = EstadosDeForma.Inicial;
        }
        #endregion

        #region METODOS
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
        private void LimpiarFormulario()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtCorreoElectronico.Text = "";
        }
        #endregion

        #region EVENTOS CLICKs BOTONES
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            lblTituloPanelDatos.Text = "Nuevo Usuario";
            panelDatos.BringToFront();
            panelDatos.Visible = true;
            panelGrid.SendToBack();
            this.Estado = EstadosDeForma.Nuevo;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

                Usuario usuario = clsNUsuario.GetOne(ID);

                txtUsuario.Text = usuario.Usuario1;
                txtPassword.Text = usuario.Password;
                txtCorreoElectronico.Text = usuario.CorreoElectronico;

                lblTituloPanelDatos.Text = "Actualizar Usuario";
                panelDatos.BringToFront();
                panelDatos.Visible = true;
                panelGrid.SendToBack();
                this.Estado = EstadosDeForma.Actualizando;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

                if(clsNUsuario.Eliminar(ID))
                    CargaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Estado == EstadosDeForma.Nuevo)
                {
                    if (clsNUsuario.CrearCuenta(txtUsuario.Text,
                                    txtPassword.Text, txtCorreoElectronico.Text)
                    )
                    {
                        CargaDatos();
                        btnCancelar_Click(null, null);
                    }
                }
                else if (this.Estado == EstadosDeForma.Actualizando)
                {
                    int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;
                    Usuario usuario = new Usuario();
                    usuario.ID = ID;
                    usuario.Usuario1 = txtUsuario.Text;
                    usuario.Password = txtPassword.Text;
                    usuario.CorreoElectronico = txtCorreoElectronico.Text;

                    if (clsNUsuario.Actualizar(usuario))
                    {
                        CargaDatos();
                        btnCancelar_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelGrid.BringToFront();
            panelDatos.Visible = false;
            panelDatos.SendToBack();
            this.Estado = EstadosDeForma.Inicial;
        }

        #endregion
    }
}
