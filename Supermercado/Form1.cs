using Supermercado.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermercado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();
            string query = "INSERT INTO clientes(nombre,apellido," +
                "tipo_doc,nro_doc,nro_tel_princ,nro_tel_sec,email)Values('" 
                + tBNombreClie.Text + "','" + tBApellClie.Text + "','" +
                tBTipoDocClie.Text + "','" + tBNumDocClie.Text + "','" 
                + tBTel1Clie.Text + "','" + tBTel2Clie.Text + "','" + 
                tBEmailClie.Text + "')";
            resultado = data.ExecuteQuery(query);
            if (resultado)
            {
                MessageBox.Show("Registro agregado", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar el registro", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAltaEmp_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();
            string query = "INSERT INTO empleados(nombre,apellido,edad," +
                "fecha_nac,tipo_doc,nro_doc,cuil,direccion,nro_tel_princ," +
                "nro_tel_sec,email,cargo,antiguedad,fecha_ingreso,salario_anual" +
                ")Values('" +
                tBNombreEmp.Text + "','" + tBApellEmp.Text + "','" +
                tBEdadEmp.Text + "','" + dTPFechaNacEmp.Value.ToString("yyyy-MM-dd") + "','" +
                tBTipoDocEmp.Text + "','" + tBNumDocEmp.Text + "','" +
                tBCuilEmp.Text + "','" + tBDireEmp.Text + "','" +
                tBTel1Emp.Text + "','" + tBTel2Emp.Text + "','" +
                tBEmailEmp.Text + "','" + tBCargoEmp.Text + "','" +
                tBAntiguEmp.Text + "','" + dTPFechaNacEmp.Value.ToString("yyyy-MM-dd") + "','" +
                tBSalaAnuEmp.Text + "')";
            resultado = data.ExecuteQuery(query);
            if (resultado)
            {
                MessageBox.Show("Registro agregado", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar el registro", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAltaProd_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();
            string query = "INSERT INTO productos(id_proveedor,codigo," +
                "imagen,nombre,marca,tipo,grupo,peso,precio_unidad,stock)" +
                "Values('" + tBIdProvProd.Text + "','" + tBCodProd.Text + "','" +
                tBImagProd.Text + "','" + tBNombreProd.Text + "','" +
                tBMarcaProd.Text + "','" + tBTipoProd.Text + "','" +
                tBGrupoProd.Text + "','" + tBPesoProd.Text + "','" +
                tBPrecioUProd.Text + "','" + tBStockProd.Text + "')";
            resultado = data.ExecuteQuery(query);
            if (resultado)
            {
                MessageBox.Show("Registro agregado", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar el registro", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAltaFact_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();
            string query = "INSERT INTO facturas(numero,codigo,fecha," +
                "hora,importe_total)" +
                "Values('" + tBNroFact.Text + "','" + tBCodFact.Text + "','" +
                dTPFechaFact.Value.ToString("yyyy-MM-dd") + "','" + tBHraFact.Text + "','" +
                tBImpoTotFact.Text + "')";
            resultado = data.ExecuteQuery(query);
            if (resultado)
            {
                MessageBox.Show("Registro agregado", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar el registro", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAltaProv_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();
            string query = "INSERT INTO proveedores(empresa,tipo_producto," +
                "direccion,nro_tel_princ,nro_tel_sec,email)Values('"
                + tBEmpProv.Text + "','" + tBTipoProdProv.Text + "','" +
                tBDireProv.Text + "','" + tBTel1Prov.Text + "','"
                + tBTel2Prov.Text + "','" + tBEmailProv.Text + "')";
            resultado = data.ExecuteQuery(query);
            if (resultado)
            {
                MessageBox.Show("Registro agregado", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar el registro", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
