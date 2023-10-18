using Datos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp.Reportes
{
    public partial class frmReportes : Form
    {
        public int NoReporte { get; set; }
        public object DataSource { get; set; }

        public frmReportes(int noReporte, object dataSource)
        {
            this.NoReporte = noReporte;
            this.DataSource = dataSource;
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                switch (this.NoReporte)
                {
                    case 1: // Reporte de Usuarios
                            // load the report
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyApp.Formatos.rptUsuarios.rdlc";
                        this.reportViewer1.LocalReport.EnableExternalImages = true;

                        ReportParameter parCantidadDeRegistros = new ReportParameter("parCantidadDeRegistros", ((List<Usuario>)this.DataSource).Count.ToString());
                        reportViewer1.LocalReport.SetParameters(parCantidadDeRegistros);

                        ReportDataSource dsDatos = new ReportDataSource("dsDatos", (List<Usuario>)this.DataSource);
                        this.reportViewer1.LocalReport.DataSources.Add(dsDatos);

                        this.reportViewer1.RefreshReport();

                        break;
                    case 2:
                        // Reporte de Tipos de Asientos
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
