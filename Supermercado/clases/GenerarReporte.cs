using CrystalDecisions.CrystalReports.Engine;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CristalApp.Clases
{
    public class GenerarReporte
    {
        string connectionString = "Host=localhost;Port=5432;Database=Topicos;Username=admin;Password=12345";
        public ReportDocument CrearReporte()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    string Query = @"SELECT
    c.id AS ""ID"",
    c.nombre AS ""Nombre"",
    c.apellido AS ""Apellido"",
    
    p.nombre AS ""Nombre del Producto"",
    p.precio_unidad AS ""Precio Unitario"",
    
    vp.cantidad,
    
    (vp.cantidad * p.precio_unidad) AS ""Precio Total""
FROM
    ventas_productos AS vp
JOIN
    productos AS p ON vp.id_producto = p.id
JOIN
    compras_clientes AS cc ON vp.id_venta = cc.id_venta
JOIN
    clientes AS c ON cc.id_cliente = c.id;"; 

                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(Query, connection);

                    DataSetApp ds = new DataSetApp();
                    dataAdapter.Fill(ds, "VentasClientes");

                    ReportDocument reporte = new ReportDocument();

                    reporte.Load(@"C:\Users\Yushab\source\repos\Supermercado\Supermercado\PrimerInforme.rpt");
                    reporte.SetDataSource(ds.Tables["VentasClientes"]);
                    return reporte;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al generar el reporte: " + ex.Message);
                }
            }

        }
    }
}