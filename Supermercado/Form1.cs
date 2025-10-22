using ImageMagick.Drawing;
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
        Datos datos = new Datos();
        public Form1()
        {
            InitializeComponent();
            mostrarEmpleados();
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

        private void btnAltaDF_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();
            string query = "INSERT INTO facturas_detalles(id_factura,tipo," +
                "descr_factura,costo_asoc,iva,medio_de_pago,descr_pago)Values('"
                + tBIdFactDF + "','" + tBTipoDF + "','" +
                tBDescFactDF.Text + "','" + tBCostAsocDF.Text + "','"
                + tBIVADF.Text + "','" + cBMedioPagDF.SelectedItem.ToString() + "','" 
                + tBDescPagoDF + "')";
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

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {

        }

        private void tBBuscar_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAllData(
            "SELECT id as \"Id\", nombre as \"Nombre\", " +
            "apaterno as \"A. Paterno\", amaterno as \"A. Materno\", " +
            "direccion as \"Direccion\", telefono as \"Telefono\" " +
            "FROM \"Agenda\" " + "WHERE nombre ILIKE '" + tBBuscar.Text + "%' " +
            "   OR apaterno ILIKE '" + tBBuscar.Text + "%' " +
            "   OR amaterno ILIKE '" + tBBuscar.Text + "%' " +
            "   OR (nombre || ' ' || apaterno || ' ' || amaterno) ILIKE '" + tBBuscar.Text + "%' " +
            "   OR direccion ILIKE '%" + tBBuscar.Text + "%' " +
            "   OR telefono ILIKE '%" + tBBuscar.Text + "%'"
            );
            if (ds != null)
            {
                //dGVPersona.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarEmpleados()
        {
            DataSet ds = datos.getAllData("SELECT * FROM empleados Order By id");
            if (ds != null)
            {
                dGVEmpleados.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dGVEmpleados_MouseClick(object sender, MouseEventArgs e)
        {
            btnEditarEmp.Enabled = true;
            btnEditarEmp.Enabled = true;
            String id = dGVEmpleados[0, dGVEmpleados.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT * FROM empleados WHERE id=" + id);
            tBNombreEmp.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            tBApellEmp.Text = ds.Tables[0].Rows[0]["apellido"].ToString();
            tBEdadEmp.Text = ds.Tables[0].Rows[0]["edad"].ToString();
            tBTipoDocEmp.Text = ds.Tables[0].Rows[0]["tipo_doc"].ToString();
            tBNumDocEmp.Text = ds.Tables[0].Rows[0]["nro_doc"].ToString();
            tBCuilEmp.Text = ds.Tables[0].Rows[0]["cuil"].ToString();
            tBDireEmp.Text = ds.Tables[0].Rows[0]["direccion"].ToString();
            tBTel1Emp.Text = ds.Tables[0].Rows[0]["nro_tel_princ"].ToString();
            tBTel2Emp.Text = ds.Tables[0].Rows[0]["nro_tel_sec"].ToString();
            tBEmailEmp.Text = ds.Tables[0].Rows[0]["email"].ToString();
            tBCargoEmp.Text = ds.Tables[0].Rows[0]["cargo"].ToString();
            tBAntiguEmp.Text = ds.Tables[0].Rows[0]["antiguedad"].ToString();
            tBSalaAnuEmp.Text = ds.Tables[0].Rows[0]["salario_anual"].ToString();
            MessageBox.Show("ID seleccionado = "+id);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarEmp_Click(object sender, EventArgs e)
        {

        }
    }
}
