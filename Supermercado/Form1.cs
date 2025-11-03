using ImageMagick;
using ImageMagick.Drawing;
using PuntoVenta;
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
            tBTotalVta.Text = "0";
            mostrarEmpleados();
            mostrarVentas();
            mostrarClientes();
            mostrarProductos();
            mostrarFacturas();
            mostrarProveedores();
            mostrarFacturasDetalles();
            iniciarComboBoxs();
            mostrarVtasProductos();
            mostrarComprasClie();
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
            mostrarClientes();
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
            mostrarProductos();
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
            mostrarFacturas();  
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
            mostrarProveedores();
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
            mostrarFacturasDetalles();
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
                    "',email='" + tBEmailEmp.Text + "',cargo='" + tBCargoEmp.Text +
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
            MostrarImagenDesdeURL(tBImagProd.Text, pBProd);
            tBNombreProd.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            tBMarcaProd.Text = ds.Tables[0].Rows[0]["marca"].ToString();
            tBTipoProd.Text = ds.Tables[0].Rows[0]["tipo"].ToString();
            tBGrupoProd.Text = ds.Tables[0].Rows[0]["grupo"].ToString();
            tBPesoProd.Text = ds.Tables[0].Rows[0]["peso"].ToString();
            tBPrecioUProd.Text = ds.Tables[0].Rows[0]["precio_unidad"].ToString();
            tBStockProd.Text = ds.Tables[0].Rows[0]["stock"].ToString();
        }

        private void MostrarImagenDesdeURL(string imageUrl, PictureBox pB)
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
                            pB.Image = System.Drawing.Image.FromStream(ms);
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

        private void mostrarFacturas()
        {
            DataSet ds = datos.getAllData("SELECT * FROM facturas Order By id");
            if (ds != null)
            {
                dGVFacturas.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarFact_Click(object sender, EventArgs e)
        {
            bool resultado;
            String id = dGVProductos[0, dGVProductos.CurrentCell.RowIndex].Value.ToString();
            string query = "Update facturas SET numero='" + tBNroFact.Text +
                    "',codigo='" + tBCodFact.Text + "',hora='" + tBHraFact.Text +
                    "',importe_total='" + tBImpoTotFact.Text + "'WHERE id = " + id;
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
            mostrarFacturas();
        }

        private void btnElimFact_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            String w = dGVProductos[0, dGVProductos.CurrentCell.RowIndex].Value.ToString();
            String query = "DELETE FROM facturas WHERE id =" + w;
            bool flag = data.ExecuteQuery(query);
            if (flag)
            {
                MessageBox.Show("Dato eliminado");
            }
            else
            {
                MessageBox.Show("Dato no eliminado");
            }
            mostrarFacturas();
        }

        private void tBBuscarFact_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAllData(
            "SELECT * " +
            "FROM facturas " + "WHERE numero ILIKE '%" + tBBuscarFact.Text + "%' " +
            "   OR codigo ILIKE '%" + tBBuscarFact.Text + "%' "
            );
            if (ds != null)
            {
                dGVFacturas.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dGVFacturas_MouseClick(object sender, MouseEventArgs e)
        {
            String id = dGVFacturas[0, dGVFacturas.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT * FROM facturas WHERE id=" + id);
            tBNroFact.Text = ds.Tables[0].Rows[0]["numero"].ToString();
            tBCodFact.Text = ds.Tables[0].Rows[0]["codigo"].ToString();
            tBHraFact.Text = ds.Tables[0].Rows[0]["hora"].ToString();
            tBImpoTotFact.Text = ds.Tables[0].Rows[0]["importe_total"].ToString();
        }

        private void mostrarProveedores()
        {
            DataSet ds = datos.getAllData("SELECT * FROM proveedores Order By id");
            if (ds != null)
            {
                dGVProveedores.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dGVProveedores_MouseClick(object sender, MouseEventArgs e)
        {
            String id = dGVProveedores[0, dGVProveedores.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT * FROM proveedores WHERE id=" + id);
            tBEmpProv.Text = ds.Tables[0].Rows[0]["empresa"].ToString();
            tBTipoProdProv.Text = ds.Tables[0].Rows[0]["tipo_producto"].ToString();
            tBDireProv.Text = ds.Tables[0].Rows[0]["direccion"].ToString();
            tBTel1Prov.Text = ds.Tables[0].Rows[0]["nro_tel_princ"].ToString();
            tBTel2Prov.Text = ds.Tables[0].Rows[0]["nro_tel_sec"].ToString();
            tBEmailProv.Text = ds.Tables[0].Rows[0]["email"].ToString();
        }

        private void btnEditProv_Click(object sender, EventArgs e)
        {
            bool resultado;
            String id = dGVProveedores[0, dGVProveedores.CurrentCell.RowIndex].Value.ToString();
            string query = "Update proveedores SET empresa='" + tBEmpProv.Text +
                    "',tipo_producto='" + tBTipoProdProv.Text + "',direccion='" + tBDireProv.Text +
                    "',nro_tel_princ='" + tBTel1Prov.Text + "',nro_tel_sec='" + tBTel2Prov.Text +
                    "',email='" + tBEmailProv.Text + "'WHERE id = " + id;
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
            mostrarProveedores();
        }

        private void btnElimProv_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            String w = dGVProveedores[0, dGVProveedores.CurrentCell.RowIndex].Value.ToString();
            String query = "DELETE FROM proveedores WHERE id =" + w;
            bool flag = data.ExecuteQuery(query);
            if (flag)
            {
                MessageBox.Show("Dato eliminado");
            }
            else
            {
                MessageBox.Show("Dato no eliminado");
            }
            mostrarProveedores();
        }

        private void tBBuscarProv_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAllData(
            "SELECT * " +
            "FROM proveedores " + "WHERE empresa ILIKE '" + tBBuscarProv.Text + "%' " +
            "   OR tipo_producto ILIKE '" + tBBuscarProv.Text + "%' " +
            "   OR direccion ILIKE '%" + tBBuscarProv.Text + "%' " +
            "   OR nro_tel_princ ILIKE '%" + tBBuscarProv.Text + "%' " + 
            "   OR nro_tel_sec ILIKE '%" + tBBuscarProv.Text + "%' " +
            "   OR email ILIKE '%" + tBBuscarProv.Text + "%' "
            );
            if (ds != null)
            {
                dGVProveedores.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dGVDetallesFact_MouseClick(object sender, MouseEventArgs e)
        {
            String id = dGVDetallesFact[0, dGVDetallesFact.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT * FROM facturas_detalles WHERE id=" + id);
            tBIdFactDF.Text = ds.Tables[0].Rows[0]["id_factura"].ToString();
            tBTipoDF.Text = ds.Tables[0].Rows[0]["tipo"].ToString();
            tBDescFactDF.Text = ds.Tables[0].Rows[0]["descr_factura"].ToString();
            tBCostAsocDF.Text = ds.Tables[0].Rows[0]["costo_asoc"].ToString();
            tBIVADF.Text = ds.Tables[0].Rows[0]["iva"].ToString();
            cBMedioPagDF.Text = ds.Tables[0].Rows[0]["medio_de_pago"].ToString();
            tBDescPagoDF.Text = ds.Tables[0].Rows[0]["descr_pago"].ToString();
        }

        private void mostrarFacturasDetalles()
        {
            DataSet ds = datos.getAllData("SELECT * FROM facturas_detalles Order By id");
            if (ds != null)
            {
                dGVDetallesFact.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditDetallFact_Click(object sender, EventArgs e)
        {
            bool resultado;
            String id = dGVDetallesFact[0, dGVDetallesFact.CurrentCell.RowIndex].Value.ToString();
            string query = "Update facturas_detalles SET id_factura='" + tBIdFactDF.Text +
                    "',tipo='" + tBTipoDF.Text + "',descr_factura='" + tBDescFactDF.Text +
                    "',costo_asoc='" + tBCostAsocDF.Text + "',iva='" + tBIVADF.Text +
                    "',medio_de_pago='" + cBMedioPagDF.Text + "',descr_pago='" + tBDescPagoDF.Text + 
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
            mostrarFacturasDetalles();
        }

        private void btnElimDetallFact_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            String w = dGVProductos[0, dGVProductos.CurrentCell.RowIndex].Value.ToString();
            String query = "DELETE FROM facturas_detalles WHERE id =" + w;
            bool flag = data.ExecuteQuery(query);
            if (flag)
            {
                MessageBox.Show("Dato eliminado");
            }
            else
            {
                MessageBox.Show("Dato no eliminado");
            }
            mostrarFacturasDetalles();
        }

        private void tBBuscarDetallFcat_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAllData(
            "SELECT * " +
            "FROM facturas_detalles " + "WHERE descr_factura " +
            "ILIKE '%" + tBBuscarDetallFcat.Text + "%' " +
            "   OR descr_pago ILIKE '%" + tBBuscarDetallFcat.Text + "%' "
            );
            if (ds != null)
            {
                dGVDetallesFact.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarVenta_Click(object sender, EventArgs e)
        {
                string n;
                if (dGVFacturas.Rows[dGVFacturas.RowCount - 2].Cells[0] != null)
                {
                    n = int.Parse(dGVFacturas.Rows[dGVFacturas.RowCount - 2].Cells[0].Value.ToString()).ToString();
                } else
                {
                    n = "1";
                }

                    bool resultadoFactura;
                Datos data = new Datos();
                string queryFactura = "INSERT INTO facturas(numero,codigo,fecha," +
                    "hora,importe_total)" +
                    //"Values('" + tBNumFactVta.Text + "','" + tBCodFcatVta.Text + "','" +
                    "Values('" + n+n+n + "','" + "A"+n+"B"+n+"LL"+n + "','" +
                    DateTime.Today.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" +
                    tBTotalVta.Text + "')";
                resultadoFactura = data.ExecuteQuery(queryFactura);
                if (resultadoFactura)
                {
                    MessageBox.Show("Factura agregada", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al agregar factura", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mostrarFacturas();

                bool resultadoVenta;
                string queryVenta = "INSERT INTO ventas(id_empleado, id_factura)" +
                    "Values('" + int.Parse(cBVendedor.SelectedItem.ToString()) + "','" + 
                    int.Parse(dGVFacturas.Rows[dGVFacturas.RowCount - 2].Cells[0].Value.ToString()) +"')";
                resultadoVenta = data.ExecuteQuery(queryVenta);
                if (resultadoVenta)
                {
                    MessageBox.Show("Venta agregada", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al agregar el venta", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mostrarVentas();

                for (int i = 0; i < dGVCesta.Rows.Count-1; i++)
                {
                    bool resultadoVtaProd;
                    string queryVtaProd = "INSERT INTO ventas_productos(id_venta, id_producto, cantidad)" +
                        "Values('" + int.Parse(dGVVentas.Rows[dGVVentas.RowCount - 2].Cells[0].Value.ToString()) + "','" +
                        int.Parse(dGVCesta.Rows[i].Cells[0].Value.ToString()) + "','" 
                        + int.Parse(dGVCesta.Rows[i].Cells[4].Value.ToString()) + "')";
                    resultadoVtaProd = data.ExecuteQuery(queryVtaProd);
                    if (resultadoVtaProd)
                    {
                        MessageBox.Show("Vta_prod agregada", "Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar vta_prod", "Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                mostrarVtasProductos();

                bool resultadoVtaClie;
                string queryVtaClie = "INSERT INTO compras_clientes(id_venta, id_cliente)" +
                    "Values('" + int.Parse(dGVVentas.Rows[dGVVentas.RowCount - 2].Cells[0].Value.ToString()) 
                    + "','" + int.Parse(cBClientes.SelectedItem.ToString()) + "')";
                resultadoVtaClie = data.ExecuteQuery(queryVtaClie);
                if (resultadoVtaClie)
                {
                    MessageBox.Show("Compra_clie agregada", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al agregar compra_clie", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mostrarComprasClie();

            for (int i = 0; i < dGVCesta.Rows.Count-1; i++)
            {
                if (!dGVCesta.Rows[i].IsNewRow)
                {
                    int stockActual = int.Parse(dGVCesta[6, i].Value.ToString());
                    int cantidadVendida = int.Parse(dGVCesta[4, i].Value.ToString());
                    int nuevoStock = stockActual - cantidadVendida;
                    bool resultado;
                    String idProd = dGVCesta[0, i].Value.ToString();
                    string query = "UPDATE productos SET stock =" + nuevoStock + " WHERE id =" + idProd;
                    resultado = datos.ExecuteQuery(query);
                    if (resultado)
                    {
                        MessageBox.Show("Stock actualizado", "Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al actulizar stock", "Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            mostrarProductos();

            dGVCesta.Rows.Clear();  
            tBTotalVta.Text = "0.00";  


        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(tBCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad no válida.");
                return;
            }
            string id = dGVMostrarProdVtas[0, dGVMostrarProdVtas.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT id, nombre, marca, codigo, precio_unidad, stock FROM productos WHERE id=" + id);

            if (int.Parse(tBCantidad.Text) <= int.Parse(dGVMostrarProdVtas[10, dGVMostrarProdVtas.CurrentCell.RowIndex].Value.ToString()))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow fila = ds.Tables[0].Rows[0];

                    // Calcular subtotal
                    decimal precio = Convert.ToDecimal(fila["precio_unidad"]);
                    decimal subtotal = precio * cantidad;

                    // Agregar al carrito
                    dGVCesta.Rows.Add(fila["id"], fila["nombre"].ToString(), fila["marca"].ToString(),
                    fila["codigo"].ToString(), cantidad, precio.ToString("0.00"), fila["stock"]);

                    tBTotalVta.Text = (Convert.ToDecimal(tBTotalVta.Text) + subtotal).ToString("0.00");
                }

            } else
            {
                MessageBox.Show("La cantidad solicitada excede el stock disponible.");  
            }
        }

        private void tBBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tBBuscar.Text.Equals(""))
            {
                dGVMostrarProdVtas.DataSource = null;
            } else
            {
                DataSet ds = datos.getAllData(
                "SELECT * " +
                "FROM productos " + "WHERE codigo ILIKE '" + tBBuscar.Text + "%' " +
                "   OR nombre ILIKE '" + tBBuscar.Text + "%' " +
                "   OR marca ILIKE '%" + tBBuscar.Text + "%' " +
                "   OR (nombre || ' ' || marca) ILIKE '" + tBBuscar.Text + "%' " +
                "   OR tipo ILIKE '%" + tBBuscar.Text + "%' " +
                "   OR grupo ILIKE '%" + tBBuscar.Text + "%' "
                );
                if (ds != null)
                {
                    dGVMostrarProdVtas.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Error al cargar los datos.", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void iniciarComboBoxs()
        {
            for (int i = 0; i < dGVEmpleados.Rows.Count-1; i++)
            {
                if (dGVEmpleados.Rows[i].Cells[12].Value.ToString().Equals("Vendedor"))
                {
                    cBVendedor.Items.Add(dGVEmpleados.Rows[i].Cells[0].Value.ToString());
                }
            }
            if (cBVendedor.Items.Count > 0)
            {
                cBVendedor.SelectedIndex = 0;
            }

            for (int i = 0; i < dGVClientes.Rows.Count - 1; i++)
            {
                cBClientes.Items.Add(dGVClientes.Rows[i].Cells[0].Value.ToString());
            }
            if (cBVendedor != null)
            {
                cBClientes.SelectedIndex = 0;
            }
        }

        private void dGVMostrarProdVtas_MouseClick(object sender, MouseEventArgs e)
        {
            String id = dGVMostrarProdVtas[0, dGVMostrarProdVtas.CurrentCell.RowIndex].Value.ToString();
            DataSet ds = datos.getAllData("SELECT * FROM facturas_detalles WHERE id=" + id);

            MostrarImagenDesdeURL(dGVMostrarProdVtas.Rows[dGVMostrarProdVtas.CurrentCell.RowIndex].Cells[3].Value.ToString(), pBMostrarProdVta);
            pBMostrarProdVta.SizeMode = PictureBoxSizeMode.StretchImage;    

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];

                int i = dGVCesta.Rows.Add();
                
            }
        }


        private void mostrarVentas()
        {
            DataSet ds = datos.getAllData("SELECT * FROM ventas Order By id");
            if (ds != null)
            {
                dGVVentas.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarComprasClie()
        {
            DataSet ds = datos.getAllData("SELECT * FROM compras_clientes Order By id");
            if (ds != null)
            {
                dGVComprasClie.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarVtasProductos()
        {
            DataSet ds = datos.getAllData("SELECT * FROM ventas_productos Order By id");
            if (ds != null)
            {
                dGVVentasProd.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenRep_Click(object sender, EventArgs e)
        {
            Reporte Rep = new Reporte();
            Rep.Show();
        }
    }
}
