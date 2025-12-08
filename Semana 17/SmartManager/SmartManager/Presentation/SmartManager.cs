using Datos;
using SmartManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SmartManager
{
    public partial class SmartManager : Form
    {
        private readonly D_VentaDetalle _dataVentaDetalle;
        private D_Cliente dCliente;



        public SmartManager()
        {
            InitializeComponent();
            _dataVentaDetalle = new D_VentaDetalle();
            dgwVentasDetalle.AutoGenerateColumns = true;
            dgwVentasDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwVentasDetalle.MultiSelect = false;
            dgwVentasDetalle.ReadOnly = true;

        }

        private void CargarClientePorEmail(string email)
        {
            try
            {
                D_Cliente datos = new D_Cliente();

                DataTable cliente = datos.MostrarClientePorEmail(email);

                if (cliente.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún cliente con ese correo.");
                    return;
                }

                // Llenar varios ComboBox
                LlenarComboCliente(cboCliente1, cliente);
                LlenarComboCliente(cboCliente2, cliente);
                LlenarComboCliente(cboCliente3, cliente);
                // ... agrega todos los que necesites

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cliente: " + ex.Message);
            }
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CargarVentasDetalle(string busqueda = null)
        {
            try
            {
                // Llamada al método de la capa de datos
                DataTable dt = _dataVentaDetalle.BuscarVentaDetalle(string.IsNullOrWhiteSpace(busqueda) ? null : busqueda);

                // Asignar DataTable al DataGridView
                dgwVentasDetalle.DataSource = dt;

                // Opcional: ajustar ancho de columnas y formato
                if (dgwVentasDetalle.Columns.Count > 0)
                {
                    dgwVentasDetalle.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    // Ejemplo: si existe columna precio_unitario formatearla
                    if (dgwVentasDetalle.Columns.Contains("precio_unitario"))
                    {
                        dgwVentasDetalle.Columns["precio_unitario"].DefaultCellStyle.Format = "N2";
                        dgwVentasDetalle.Columns["precio_unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles de venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SmartManager_Load(object sender, EventArgs e)
        {
            try
            {
                D_Categorias dcat = new D_Categorias();
                


                CargarVentasDetalle();
                dcat.CargarCombo(cmbCategoriaProducto);
                dcat.CargarCombo(cmbActualizarCategoriaProducto);
                dcat.CargarCombo(cmbVentaDetalleCategoria);
                dcat.CargarCombo(cmbEliminarCategoria);
                dcat.CargarCombo(cmbEliminarCategoriaProducto);
                dcat.CargarCombo(cmbActualizarCategoria);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);

            }
        }

        //Caja de texto del Nombre del cliente
        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();
            string apellido = txtApellidoCliente.Text.Trim();
            string email = txtEmailCliente.Text.Trim();

            // Validaciones básicas
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCliente.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Ingrese el apellido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidoCliente.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Ingrese el email.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailCliente.Focus();
                return;
            }

            // Opcional: validación simple de formato de email
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                {
                    MessageBox.Show("Email inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailCliente.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Email inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailCliente.Focus();
                return;
            }

            // Llamar al método de datos
            D_Cliente datos = new D_Cliente();
            string respuesta = datos.InsertarCliente(nombre, apellido, email);

            if (respuesta == "OK")
            {
                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Limpiar campos
                txtNombreCliente.Clear();
                txtApellidoCliente.Clear();
                txtEmailCliente.Clear();
                txtNombreCliente.Focus();

                // Si tienes un DataGridView para mostrar clientes, recárgalo aquí
                // Ejemplo: CargarClientes();
            }
            else
            {
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtApellidoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmailCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreCliente_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategoriaProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudProductoPrecio_ValueChanged(object sender, EventArgs e)
        {
            nudProductoPrecio.DecimalPlaces = 2; // ahora acepta hasta 2 decimales
            nudProductoPrecio.Maximum = 1000000; // valor máximo permitido

        }

        private void nudUnidadesProducto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                return;
            }

            if (cmbCategoriaProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoriaProducto.Focus();
                return;
            }

            try
            {
                string nombre = txtNombreProducto.Text.Trim();
                int idCategoria = Convert.ToInt32(cmbCategoriaProducto.SelectedValue);
                decimal precio = nudProductoPrecio.Value;
                int existencias = Convert.ToInt32(nudUnidadesProducto.Value);


                if (existencias < 0)
                {
                    MessageBox.Show("Las existencias no pueden ser negativas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudUnidadesProducto.Focus();
                    return;
                }

                if (precio < 0)
                {
                    MessageBox.Show("El precio no puede ser negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudProductoPrecio.Focus();
                    return;
                }

                D_Productos datos = new D_Productos();
                string resultado = datos.InsertarProducto(nombre, idCategoria, precio, existencias);

                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: limpiar controles después de insertar
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {
            txtNombreProducto.Clear();
            cmbCategoriaProducto.SelectedIndex = -1;
            nudProductoPrecio.Value = 0;
            nudUnidadesProducto.Value = 0;
            txtNombreProducto.Focus();
        }


        //Guardar categoría

        private void CargarCategoriasEnCombos(params ComboBox[] combos)
        {
            D_Categorias dcat = new D_Categorias();
            foreach (var cb in combos)
            {
                // Evita pasar nulls si algún combo no existe en este formulario
                if (cb == null) continue;
                dcat.CargarCombo(cb);
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Validación básica
            string nombre = txtAgregarNombreCategoria.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese el nombre de la categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgregarNombreCategoria.Focus();
                return;
            }

            try
            {
                D_Categorias dcat = new D_Categorias();
                string resultado = dcat.InsertarCategoria(nombre);

                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar textbox
                txtAgregarNombreCategoria.Clear();
                txtAgregarNombreCategoria.Focus();

                //Actualizar todos los ComboBox
                CargarCategoriasEnCombos(
                    cmbCategoriaProducto,
                    cmbActualizarCategoriaProducto,
                    cmbVentaDetalleCategoria,
                    cmbEliminarCategoria,
                    cmbEliminarCategoriaProducto,
                    cmbActualizarCategoria);





            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void txtAgregarNombreCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void nudPrecioUnitarioDetalleVenta_ValueChanged(object sender, EventArgs e)
        {
            nudPrecioUnitarioDetalleVenta.DecimalPlaces = 2; // ahora acepta hasta 2 decimales
            nudPrecioUnitarioDetalleVenta.Maximum = 1000000; // valor máximo permitido
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void dgwVentasDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarVentaDetalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarVentaDetalle_Click(object sender, EventArgs e)
        {
            string termino = txtBuscarVentaDetalle.Text.Trim();
            CargarVentasDetalle(termino);


        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            // Validar selección de vendedor
            if (cmbVendedor.SelectedValue == null || !int.TryParse(cmbVendedor.SelectedValue.ToString(), out int idVendedor))
            {
                MessageBox.Show("Seleccione un vendedor válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVendedor.Focus();
                return;
            }

            // Validar selección de cliente
            if (cmbCorreoCliente.SelectedValue == null || !int.TryParse(cmbCorreoCliente.SelectedValue.ToString(), out int idCliente))
            {
                MessageBox.Show("Seleccione un cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCorreoCliente.Focus();
                return;
            }

            try
            {
                btnCrearVenta.Enabled = false; // evitar doble clic
                int idVenta;
                string mensaje = InsertarVenta(idVendedor, idCliente, out idVenta);

                if (idVenta > 0)
                {
                    MessageBox.Show($"{mensaje}\nID venta: {idVenta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aquí puedes limpiar controles o actualizar la UI según convenga
                }
                else
                {
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al crear la venta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCrearVenta.Enabled = true;
            }

        }
        public string InsertarVenta(int id_vendedor, int id_cliente, out int id_venta)
        {
            id_venta = 0;
            try
            {
                using (SqlConnection SqlCon = Conexion.crearInstancia().CrearConexion())
                using (SqlCommand comando = new SqlCommand("sp_InsertarVenta", SqlCon))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@id_vendedor", SqlDbType.Int).Value = id_vendedor;
                    comando.Parameters.Add("@id_cliente", SqlDbType.Int).Value = id_cliente;

                    SqlParameter parIdVenta = new SqlParameter("@id_venta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    comando.Parameters.Add(parIdVenta);

                    SqlCon.Open();
                    int filas = comando.ExecuteNonQuery();

                    if (comando.Parameters["@id_venta"].Value != DBNull.Value)
                    {
                        id_venta = Convert.ToInt32(comando.Parameters["@id_venta"].Value);
                    }

                    return filas > 0 ? "Inserción exitosa." : "No se insertó ningún registro.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}

