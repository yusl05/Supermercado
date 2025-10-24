using ImageMagick;
using ImageMagick.Drawing;
using Supermercado.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            mostrarClientes();
            mostrarProductos();
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
                tBAntiguEmp.Text + "','" + dTPFechaIngEmp.Value.ToString("yyyy-MM-dd") + "','" +
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
            mostrarEmpleados();
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

        //private void btnAgregarProd_Click(object sender, EventArgs e)
        //{

        //}

        //private void tBBuscar_TextChanged(object sender, EventArgs e)
        //{
            
        //}

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
            //MessageBox.Show("ID seleccionado = "+id);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool resultado;
            String id = dGVEmpleados[0, dGVEmpleados.CurrentCell.RowIndex].Value.ToString();
            string query = "Update empleados SET nombre='" + tBNombreEmp.Text +
                    "',apellido='" + tBApellEmp.Text + "',edad='" + tBEdadEmp.Text +
                    "',fecha_nac='" + dTPFechaNacEmp.Value.ToString("yyyy-MM-dd") +
                    "',tipo_doc='" + tBTipoDocEmp.Text + "',nro_doc='" + tBNumDocEmp.Text +
                    "',cuil='" + tBCuilEmp.Text + "',direccion='" + tBDireEmp.Text +
                    "',nro_tel_princ='" + tBTel1Emp.Text + "',nro_tel_sec='" + tBTel2Emp.Text +
                    "',email='" + tBEmailEmp.Text + "',cargo='" + tBAntiguEmp.Text +
                    "',antiguedad='" + tBAntiguEmp.Text + "',fecha_ingreso='" + 
                    dTPFechaIngEmp.Value.ToString("yyyy-MM-dd") + "',salario_anual='" + tBSalaAnuEmp.Text +
                    "'WHERE id = " + id;
            resultado = datos.ExecuteQuery(query);
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
            mostrarEmpleados();
        }

        private void btnEliminarEmp_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            String w = dGVEmpleados[0, dGVEmpleados.CurrentCell.RowIndex].Value.ToString();
            String query = "DELETE FROM empleados WHERE id =" + w;
            bool flag = data.ExecuteQuery(query);
            if (flag)
            {
                MessageBox.Show("Dato eliminado");
            }
            else
            {
                MessageBox.Show("Dato no eliminado");
            }
            mostrarEmpleados(); 
        }

        private void mostrarClientes()
        {
            DataSet ds = datos.getAllData("SELECT * FROM clientes Order By id");
            if (ds != null)
            {
                dGVClientes.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dGVClientes_MouseClick(object sender, MouseEventArgs e)
        {
            btnEditClie.Enabled = true;
            btnElimclie.Enabled = true;
            String id = dGVClientes[0, dGVClientes.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT * FROM clientes WHERE id=" + id);
            tBNombreClie.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            tBApellClie.Text = ds.Tables[0].Rows[0]["apellido"].ToString();
            tBTipoDocClie.Text = ds.Tables[0].Rows[0]["tipo_doc"].ToString();
            tBNumDocClie.Text = ds.Tables[0].Rows[0]["nro_doc"].ToString();
            tBTel1Clie.Text = ds.Tables[0].Rows[0]["nro_tel_princ"].ToString();
            tBTel2Clie.Text = ds.Tables[0].Rows[0]["nro_tel_sec"].ToString();
            tBEmailClie.Text = ds.Tables[0].Rows[0]["email"].ToString();
            //MessageBox.Show("ID seleccionado = "+id);
        }

        private void tBBuscarEmp_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAllData(
            "SELECT * " +
            "FROM empleados " + "WHERE nombre ILIKE '" + tBBuscarEmp.Text + "%' " +
            "   OR apellido ILIKE '" + tBBuscarEmp.Text + "%' " +
            "   OR (nombre || ' ' || apellido) ILIKE '" + tBBuscarEmp.Text + "%' " +
            "   OR tipo_doc ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR nro_doc ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR cuil ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR direccion ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR nro_tel_princ ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR nro_tel_sec ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR email ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR cargo ILIKE '%" + tBBuscarEmp.Text + "%' " +
            "   OR antiguedad ILIKE '%" + tBBuscarEmp.Text + "%' "
            );
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

        private void btnEditClie_Click(object sender, EventArgs e)
        {
            bool resultado;
            String id = dGVClientes[0, dGVClientes.CurrentCell.RowIndex].Value.ToString();
            string query = "Update clientes SET nombre='" + tBNombreClie.Text +
                    "',apellido='" + tBApellClie.Text + "',tipo_doc='" + tBTipoDocClie.Text + 
                    "',nro_doc='" + tBNumDocClie.Text +
                    "',nro_tel_princ='" + tBTel1Clie.Text + "',nro_tel_sec='" + tBTel2Clie.Text +
                    "',email='" + tBEmailEmp.Text + "'WHERE id = " + id;
            resultado = datos.ExecuteQuery(query);
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
            mostrarClientes();
        }

        private void btnElimclie_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            String w = dGVClientes[0, dGVClientes.CurrentCell.RowIndex].Value.ToString();
            String query = "DELETE FROM clientes WHERE id =" + w;
            bool flag = data.ExecuteQuery(query);
            if (flag)
            {
                MessageBox.Show("Dato eliminado");
            }
            else
            {
                MessageBox.Show("Dato no eliminado");
            }
            mostrarClientes();
        }

        private void tBBuscarClie_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAllData(
            "SELECT * " +
            "FROM clientes " + "WHERE nombre ILIKE '" + tBBuscarClie.Text + "%' " +
            "   OR apellido ILIKE '" + tBBuscarClie.Text + "%' " +
            "   OR (nombre || ' ' || apellido) ILIKE '" + tBBuscarClie.Text + "%' " +
            "   OR tipo_doc ILIKE '%" + tBBuscarClie.Text + "%' " +
            "   OR nro_doc ILIKE '%" + tBBuscarClie.Text + "%' " +
            "   OR nro_tel_princ ILIKE '%" + tBBuscarClie.Text + "%' " +
            "   OR nro_tel_sec ILIKE '%" + tBBuscarClie.Text + "%' " +
            "   OR email ILIKE '%" + tBBuscarClie.Text + "%' "
            );
            if (ds != null)
            {
                dGVClientes.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarProductos()
        {
            DataSet ds = datos.getAllData("SELECT * FROM productos Order By id");
            if (ds != null)
            {
                dGVProductos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dGVProductos_MouseClick(object sender, MouseEventArgs e)
        {
            btnEditClie.Enabled = true;
            btnElimclie.Enabled = true;
            String id = dGVProductos[0, dGVProductos.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT * FROM productos WHERE id=" + id);
            tBIdProvProd.Text = ds.Tables[0].Rows[0]["id_proveedor"].ToString();
            tBCodProd.Text = ds.Tables[0].Rows[0]["codigo"].ToString();
            tBImagProd.Text = ds.Tables[0].Rows[0]["imagen"].ToString();
            MostrarImagenDesdeURL(tBImagProd.Text);
            tBNombreProd.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            tBMarcaProd.Text = ds.Tables[0].Rows[0]["marca"].ToString();
            tBTipoProd.Text = ds.Tables[0].Rows[0]["tipo"].ToString();
            tBGrupoProd.Text = ds.Tables[0].Rows[0]["grupo"].ToString();
            tBPesoProd.Text = ds.Tables[0].Rows[0]["peso"].ToString();
            tBPrecioUProd.Text = ds.Tables[0].Rows[0]["precio_unidad"].ToString();
            tBStockProd.Text = ds.Tables[0].Rows[0]["stock"].ToString();

            //MessageBox.Show("ID seleccionado = "+id);
        }

        private void MostrarImagenDesdeURL(string imageUrl)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] imageBytes = client.DownloadData(imageUrl);

                    using (MagickImage magickImage = new MagickImage(imageBytes))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            magickImage.Write(ms, MagickFormat.Png);
                            ms.Position = 0;
                            pBProd.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen "+ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditarProd_Click(object sender, EventArgs e)
        {
            bool resultado;
            String id = dGVProductos[0, dGVProductos.CurrentCell.RowIndex].Value.ToString();
            string query = "Update productos SET id_proveedor='" + tBIdProvProd.Text +
                    "',codigo='" + tBCodProd.Text + "',imagen='" + tBImagProd.Text +
                    "',nombre='" + tBNombreProd.Text + "',marca='" + tBMarcaProd.Text +
                    "',tipo='" + tBTipoProd.Text + "',grupo='" + tBGrupoProd.Text +
                    "',peso='" + tBPesoProd.Text + "',precio_unidad='" + tBPrecioUProd.Text +
                    "',stock='" + tBStockProd.Text + "'WHERE id = " + id;
            resultado = datos.ExecuteQuery(query);
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
            mostrarProductos();
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            String w = dGVProductos[0, dGVProductos.CurrentCell.RowIndex].Value.ToString();
            String query = "DELETE FROM productos WHERE id =" + w;
            bool flag = data.ExecuteQuery(query);
            if (flag)
            {
                MessageBox.Show("Dato eliminado");
            }
            else
            {
                MessageBox.Show("Dato no eliminado");
            }
            mostrarProductos();
        }

        private void tBBuscarProd_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAllData(
            "SELECT * " +
            "FROM productos " + "WHERE codigo ILIKE '" + tBBuscarProd.Text + "%' " +
            "   OR nombre ILIKE '" + tBBuscarProd.Text + "%' " +
            "   OR (nombre || ' ' || marca) ILIKE '" + tBBuscarProd.Text + "%' " +
            "   OR tipo ILIKE '%" + tBBuscarProd.Text + "%' " +
            "   OR grupo ILIKE '%" + tBBuscarProd.Text + "%' " 
            );
            if (ds != null)
            {
                dGVProductos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
