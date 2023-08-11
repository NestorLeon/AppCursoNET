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
using Utilerias;

namespace MyApp
{
    public partial class FormSalaTipo : Form
    {
        #region PROPIEDADES
        public EstadosDeForma Estado { get; set; }
        #endregion

        #region CONSTRUCTORES
        public FormSalaTipo()
        {
            InitializeComponent();
            CargaDatos();
            this.Estado = EstadosDeForma.Inicial;
        }
        #endregion

        #region METODOS
        private void CargaDatos()
        {
            List<Sala_Tipo> sala_tipo = clsNSalaTipo.ObtenerLista();
            dgvSalaTipo.DataSource = sala_tipo;

            #region FORMATEAR GRID
            if (dgvSalaTipo.Columns.Contains("ID"))
            {
                dgvSalaTipo.Columns["ID"].Visible = false;
            }
            if (dgvSalaTipo.Columns.Contains("Descripcion"))
            {
                dgvSalaTipo.Columns["Descripcion"].HeaderText = "Descripción";
            }
            if (dgvSalaTipo.Columns.Contains("Formato_Pantalla"))
            {
                dgvSalaTipo.Columns["Formato_Pantalla"].HeaderText = "Formato de Pantalla";
            }
            if (dgvSalaTipo.Columns.Contains("Sonido"))
            {
                dgvSalaTipo.Columns["Sonido"].HeaderText = "Formato de Sonido";
            }
            #endregion
        }
        private void LimpiarFormulario()
        {
            textNombre.Text = "";
            textDescripcion.Text = "";
            textCapacidad.Text = "";
            textPantalla.Text = "";
            textSonido.Text = "";
        }
        #endregion

        #region EVENTOS CLICKs BOTONES
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            lblTitulo.Text = "Nuevo Tipo de Sala";
            panelDatos.BringToFront();
            panelDatos.Visible = true;
            panelGrid.SendToBack();
            this.Estado = EstadosDeForma.Nuevo;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvSalaTipo.SelectedRows[0].Cells["ID"].Value;

                Sala_Tipo sala_tipo = clsNSalaTipo.GetOne(ID);

                textNombre.Text = sala_tipo.Nombre;
                textDescripcion.Text = sala_tipo.Descripcion;
                textCapacidad.Text = sala_tipo.Capacidad.ToString();
                textPantalla.Text = sala_tipo.Formato_Pantalla;
                textSonido.Text = sala_tipo.Sonido;

                lblTitulo.Text = "Actualizar Tipo de Sala";
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
                int ID = (int)dgvSalaTipo.SelectedRows[0].Cells["ID"].Value;

                if (clsNSalaTipo.Eliminar(ID))
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
                    if (clsNSalaTipo.AgregarSala(textNombre.Text,
                                    textDescripcion.Text, int.Parse(textCapacidad.Text), 
                                        textPantalla.Text, textSonido.Text)
                    )
                    {
                        CargaDatos();
                        btnCancelar_Click(null, null);
                    }
                }
                else if (this.Estado == EstadosDeForma.Actualizando)
                {
                    int ID = (int)dgvSalaTipo.SelectedRows[0].Cells["ID"].Value;
                    Sala_Tipo sala_Tipo = new Sala_Tipo();
                    sala_Tipo.ID = ID;
                    sala_Tipo.Nombre = textNombre.Text;
                    sala_Tipo.Descripcion = textDescripcion.Text;
                    sala_Tipo.Capacidad = int.Parse(textCapacidad.Text);
                    sala_Tipo.Formato_Pantalla = textPantalla.Text;
                    sala_Tipo.Sonido = textSonido.Text;

                    if (clsNSalaTipo.Actualizar(sala_Tipo))
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
            panelDatos.BringToFront();
            panelDatos.Visible = false;
            panelGrid.SendToBack();
            this.Estado = EstadosDeForma.Inicial;
        }
        #endregion
    }
}
