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
    public partial class frmCiudades : Form
    {
        #region PROPIEDADES
        public EstadosDeForma Estado { get; set; }
        #endregion

        #region CONSTRUCTORES
        public frmCiudades()
        {
            InitializeComponent();
            CargaDatos();
            this.Estado = EstadosDeForma.Inicial;
        }
        #endregion

        #region METODOS
        private void CargaDatos()
        {
            List<Ciudad> ciudades = clsNCiudad.ObtenerLista();
            dgvDatos.DataSource = ciudades;

            #region FORMATEAR GRID
            if (dgvDatos.Columns.Contains("ID"))
            {
                dgvDatos.Columns["ID"].Visible = false;
            }
            if (dgvDatos.Columns.Contains("Ciudad1"))
            {
                dgvDatos.Columns["Ciudad1"].HeaderText = "Nombre de la ciudad";
            }

            #endregion
        }
        private void LimpiarFormulario()
        {
            txtCiudad.Text = "";

        }
        #endregion

        #region EVENTOS CLICKs BOTONES
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            lblTituloPanelDatos.Text = "Nueva Ciudad";
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

                Ciudad usuario = clsNCiudad.GetOne(ID);

                txtCiudad.Text = usuario.Ciudad1;


                lblTituloPanelDatos.Text = "Actualizar Ciudad";
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

                if (clsNCiudad.Eliminar(ID))
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
                    if (clsNCiudad.CrearCiudad(txtCiudad.Text)
                    )
                    {
                        CargaDatos();
                        btnCancelar_Click(null, null);
                    }
                }
                else if (this.Estado == EstadosDeForma.Actualizando)
                {
                    int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;
                    Ciudad ciudad = new Ciudad();
                    ciudad.ID = ID;
                    ciudad.Ciudad1 = txtCiudad.Text;


                    if (clsNCiudad.Actualizar(ciudad))
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

        private void panelDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Ciudades_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

                if (clsNCiudad.Eliminar(ID))
                    CargaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

                if (clsNCiudad.Eliminar(ID))
                    CargaDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iconButton1_Click_2(object sender, EventArgs e)
        {

            try
            {
                int ID = (int)dgvDatos.SelectedRows[0].Cells["ID"].Value;

                Ciudad usuario = clsNCiudad.GetOne(ID);

                txtCiudad.Text = usuario.Ciudad1;


                lblTituloPanelDatos.Text = "Actualizar Ciudad";
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
    }
}