using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        #region CATALOGOS
        private void miCatalogos_Usuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios frmUsuarios = new frmUsuarios();
            frmUsuarios.MdiParent = this;
            frmUsuarios.Show();
        }

        private void miCatalogos_TiposDeAsientos_Click(object sender, EventArgs e)
        {
            frmTiposDeAsientos frmTiposDeAsientos = new frmTiposDeAsientos();
            frmTiposDeAsientos.MdiParent = this;
            frmTiposDeAsientos.Show();
        }

        private void miCatalogos_Ciudades_Click(object sender, EventArgs e)
        {
            frmCiudades frmCiudades = new frmCiudades();
            frmCiudades.MdiParent = this;
            frmCiudades.Show();
        }
        #endregion

        #region REPORTES
        #endregion

    }
}
