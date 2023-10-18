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

namespace MyApp.Reportes
{
    public partial class frmReporteUsuarios : Form
    {
        public frmReporteUsuarios()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string correo = txtCorreoElectronico.Text;

            dgvDatos.DataSource = clsNUsuario.Search(usuario, correo);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReportes frmReportes = new frmReportes(1, dgvDatos.DataSource);
            frmReportes.MdiParent = this.MdiParent;
            frmReportes.Show();
        }
    }
}
