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
    public partial class Form_Tipo_Asiento : Form
    {
        #region PROPIEDADES
        public EstadosDeForma Estado { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Form_Tipo_Asiento()
        {
            InitializeComponent();
            CargaDatos();
            this.Estado = EstadosDeForma.Inicial;
        }
        #endregion

        #region METODOS
        private void CargaDatos()
        {
            List<Asiento_Tipo> tipos = clsNAsientoTipo.ObtenerLista();
            dgvDatos.DataSource = tipos;

            #region FORMATEAR GRID
            if (dgvDatos.Columns.Contains("ID"))
            {
                dgvDatos.Columns["ID"].Visible = false;
            }
            if (dgvDatos.Columns.Contains("Tipo"))
            {
                dgvDatos.Columns["Tipo"].HeaderText = "Tipo de Asiento";
            }
            #endregion
        }
        private void LimpiarFormulario()
        {
            txtUsuario.Text = "";
        }
        #endregion

        #region EVENTOS
             
              
              
            
        private void panelDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTituloPanelDatos_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();

            lblTituloPanelDatos.Text = "Nuevo tipo de asiento";
            panelDatos.BringToFront();
            panelDatos.Visible = true;
            panelGrid.SendToBack();
            this.Estado = EstadosDeForma.Nuevo;
        }
        #endregion

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

                Asiento_Tipo tipo = clsNAsientoTipo.GetOne(ID);

                txtUsuario.Text = tipo.Tipo;

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

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

                if (clsNAsientoTipo.Eliminar(ID))
                    CargaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.Estado == EstadosDeForma.Nuevo)
                {
                    if (clsNAsientoTipo.CrearCuenta(txtUsuario.Text)
                    )
                    {
                        CargaDatos();
                        btnCancelar_Click_1(null, null);
                    }
                }
                else if (this.Estado == EstadosDeForma.Actualizando)
                {
                    int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;
                    Asiento_Tipo tipo = new Asiento_Tipo();
                    tipo.ID = ID;
                    tipo.Tipo = txtUsuario.Text;

                    if (clsNAsientoTipo.Actualizar(tipo))
                    {
                        CargaDatos();
                        btnCancelar_Click_1(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            panelGrid.BringToFront();
            panelDatos.Visible = false;
            panelDatos.SendToBack();
            this.Estado = EstadosDeForma.Inicial;
        }
    }
}
