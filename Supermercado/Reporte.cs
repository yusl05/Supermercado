using CristalApp.Clases;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            GenerarReporte reporte = new GenerarReporte();
            ReportDocument imprime;
            imprime = reporte.CrearReporte();

            crystalReportViewer1.ReportSource = imprime;
            crystalReportViewer1.RefreshReport();
        }

    }
}
