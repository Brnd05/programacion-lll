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

        private void LlenarComboCliente(ComboBox combo, DataTable tabla)
        {
            combo.DataSource = null;
            combo.DisplayMember = "email_cliente";   // Cambia si tu columna tiene otro nombre
            combo.ValueMember = "id_cliente";
            combo.DataSource = tabla;
            combo.SelectedIndex = -1;  // Opcional: deja sin seleccionar nada
        }
        private void llenarComboVendedor(ComboBox combo, DataTable tabla)
        {
            combo.DataSource = null;
            combo.DisplayMember = "usuario_vendedor";
            combo.ValueMember = "id_vendedor";
            combo.DataSource = tabla;
            combo.SelectedIndex = -1;  // Opcional: deja sin seleccionar nada
        }

        private void LlenarComboProducto(ComboBox combo, DataTable tabla)
        {
            combo.DataSource = null;
            combo.DisplayMember = "nombre_producto";   // Cambia si tu columna tiene otro nombre

            combo.ValueMember = "id_producto";
            combo.DataSource = tabla;
            combo.SelectedIndex = -1;  // Opcional: deja sin seleccionar nada
        }

    

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo == null || combo.SelectedValue == null)
                return;

            int idCategoria;
            object selected = combo.SelectedValue;

            // Si ValueMember no está configurado, SelectedValue puede ser DataRowView
            if (selected is DataRowView drv)
            {
                idCategoria = Convert.ToInt32(drv["id_categoria"]);
            }
            else if (selected is DataRow row)
            {
                idCategoria = Convert.ToInt32(row["id_categoria"]);
            }
            else if (selected is int)
            {
                idCategoria = (int)selected;
            }
            else
            {
                if (!int.TryParse(selected.ToString(), out idCategoria))
                {
                    MessageBox.Show("No se pudo obtener el id de la categoría seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            CargarProductosPorCategoria(idCategoria);
        }



        //private void CargarClientePorEmail(string email)
        //{
        //    try
        //    {
        //        D_Cliente datos = new D_Cliente();

        //        DataTable cliente = datos.MostrarClientePorEmail(email);

        //        if (cliente.Rows.Count == 0)
        //        {
        //            MessageBox.Show("No se encontró ningún cliente con ese correo.");
        //            return;
        //        }

        //        // Llenar varios ComboBox
        //        LlenarComboCliente(cmbCorreoCliente, cliente);
        //        LlenarComboCliente(cmbClienteActualizar, cliente);
        //        LlenarComboCliente(cmbEliminarCliente, cliente);


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar cliente: " + ex.Message);
        //    }
        //}

        private void CargarClientesEnComboBox()
        {
            try
            {
                D_Cliente datos = new D_Cliente();
                DataTable clientes = datos.MostrarClientes();

                LlenarComboCliente(cmbCorreoCliente, clientes);
                LlenarComboCliente(cmbEliminarCliente, clientes);
                LlenarComboCliente(cmbClienteActualizar, clientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }


        }
        private void CargarVendedoreEnCombobox()
        {
            try
            {
                D_Vendedores datos = new D_Vendedores();
                DataTable vendedor = datos.MostrarVendedores();

                llenarComboVendedor(cmbVendedor, vendedor);
                if (vendedor.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún vendedor.");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedor: " + ex.Message);
            }
        }

        //private void CargarProductosEnComboBox()
        //{
        //    try
        //    {
        //        D_Productos datos = new D_Productos();
        //        DataTable productos = datos.MostrarProductos();
        //        LlenarComboProducto(cmbEliminarProducto, productos);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar productos: " + ex.Message);
        //    }
        //}

        private void CargarProductosPorCategoria(int idCategoria)
        {
            try
            {
                D_Productos datos = new D_Productos();
                DataTable productos = datos.MostrarProductosPorCategoria(idCategoria);



                LlenarComboProducto(cmbVentaDetalleProducto, productos);
                LlenarComboProducto(cmbEliminarProducto, productos);
                LlenarComboProducto(cmbProductoActualizarProducto, productos);






            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
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
            CargarClientesEnComboBox();
            CargarVentasDetalle();
            CargarVendedoreEnCombobox();
            //CargarProductosEnComboBox();

            // Llenar todos los combos de categorías
            //CargarCombo(cmbVentaDetalleCategoria);
            //CargarCombo(cmbCategoriaProducto);
            //CargarCombo(cmbActualizarCategoriaProducto);
            //CargarCombo(cmbActualizarCategoria);
            //CargarCombo(cmbEliminarCategoriaProducto);
            //CargarCombo(cmbEliminarCategoria);




            try
            {
                D_Categorias dcat = new D_Categorias();


                dcat.CargarCombo(cmbCategoriaProducto);
                dcat.CargarCombo(cmbVentaDetalleCategoria);
                dcat.CargarCombo(cmbEliminarCategoria);
                dcat.CargarCombo(cmbEliminarCategoriaProducto);
                dcat.CargarCombo(cmbActualizarCategoria);
                dcat.CargarCombo(cmbActualizarCategoriaProducto);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);

            }


            cmbVentaDetalleCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

            cmbEliminarCategoriaProducto.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

            cmbActualizarCategoriaProducto.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

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

                // Refrescar ComboBox de clientes
                CargarClientesEnComboBox();

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
                LimpiarControlesProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesProducto()
        {
            txtNombreProducto.Clear();
            cmbCategoriaProducto.SelectedIndex = -1;
            nudProductoPrecio.Value = 0;
            nudUnidadesProducto.Value = 0;
            txtNombreProducto.Focus();
        }
        private void LimpiarControlesActualizarCliente()
        {
            txtActualizarNombreCliente.Clear();
            txtActualizarApellidoCliente.Clear();
            txtActualizarCorreoCliente.Clear();
            cmbClienteActualizar.SelectedIndex = -1;    
            txtNombreCliente.Focus();
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
            try
            {
                // Validar que se haya seleccionado una categoría
                if (cmbEliminarCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el id de la categoría seleccionada
                int id_categoria = Convert.ToInt32(cmbEliminarCategoria.SelectedValue);

                // Confirmar la acción con el usuario
                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro que desea eliminar esta categoría?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    // Instanciar la clase de datos
                    D_Categorias datos = new D_Categorias();

                    // Llamar al método de eliminación
                    string resultado = datos.EliminarCategoria(id_categoria);

                    // Mostrar resultado
                    MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refrescar ComboBox de categorías (opcional)
                    CargarCategoriasEnCombos(
                   cmbCategoriaProducto,
                   cmbActualizarCategoriaProducto,
                   cmbVentaDetalleCategoria,
                   cmbEliminarCategoria,
                   cmbEliminarCategoriaProducto,
                   cmbActualizarCategoria);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

        private void cmbActualizarCategoriaProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbActualizarCategoriaProducto.SelectedValue == null)
            //    return;

            //int idCategoria;

            //object selected = cmbActualizarCategoriaProducto.SelectedValue;

            //// Si por alguna razón el SelectedValue es un DataRowView (ocurre al bindear tablas),
            //// extraemos el campo correcto.
            //if (selected is DataRowView drv)
            //{
            //    // Cambia "id_categoria" si tu columna tiene otro nombre
            //    idCategoria = Convert.ToInt32(drv["id_categoria"]);
            //}
            //else if (selected is int) // ya es int
            //{
            //    idCategoria = (int)selected;
            //}
            //else
            //{
            //    // Intentamos convertir a int desde string u otros
            //    if (!int.TryParse(selected.ToString(), out idCategoria))
            //    {
            //        MessageBox.Show("No se pudo obtener el id de la categoría seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}



            //CargarProductosPorCategoria(idCategoria);
        }

        private void cmbEliminarCategoriaProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbEliminarCategoriaProducto.SelectedValue == null)
            //    return;

            //int idCategoria;

            //object selected = cmbEliminarCategoriaProducto.SelectedValue;

            //// Si por alguna razón el SelectedValue es un DataRowView (ocurre al bindear tablas),
            //// extraemos el campo correcto.
            //if (selected is DataRowView drv)
            //{
            //    // Cambia "id_categoria" si tu columna tiene otro nombre
            //    idCategoria = Convert.ToInt32(drv["id_categoria"]);
            //}
            //else if (selected is int) // ya es int
            //{
            //    idCategoria = (int)selected;
            //}
            //else
            //{
            //    // Intentamos convertir a int desde string u otros
            //    if (!int.TryParse(selected.ToString(), out idCategoria))
            //    {
            //        MessageBox.Show("No se pudo obtener el id de la categoría seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}



            //CargarProductosPorCategoria(idCategoria);
        }

        private void cmbVentaDetalleCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbVentaDetalleCategoria.SelectedValue == null)
            //    return;

            //int idCategoria;

            //object selected = cmbVentaDetalleCategoria.SelectedValue;

            //// Si por alguna razón el SelectedValue es un DataRowView (ocurre al bindear tablas),
            //// extraemos el campo correcto.
            //if (selected is DataRowView drv)
            //{
            //    // Cambia "id_categoria" si tu columna tiene otro nombre
            //    idCategoria = Convert.ToInt32(drv["id_categoria"]);
            //}
            //else if (selected is int) // ya es int
            //{
            //    idCategoria = (int)selected;
            //}
            //else
            //{
            //    // Intentamos convertir a int desde string u otros
            //    if (!int.TryParse(selected.ToString(), out idCategoria))
            //    {
            //        MessageBox.Show("No se pudo obtener el id de la categoría seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            //CargarProductosPorCategoria(idCategoria);

        }

        private void cmbEliminarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbVentaDetalleProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbActualizarCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEliminarCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProductoActualizarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado una categoría
                if (cmbEliminarCategoriaProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se haya seleccionado un producto
                if (cmbEliminarProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el id del producto seleccionado
                int id_producto = Convert.ToInt32(cmbEliminarProducto.SelectedValue);
                DialogResult confirmacion = MessageBox.Show(
                   "¿Está seguro que desea eliminar este producto?",
                   "Confirmar eliminación",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

                if (confirmacion == DialogResult.Yes)
                {
                    // Instanciar la clase de datos
                    D_Productos datos = new D_Productos();

                    // Llamar al método de eliminación
                    string resultado = datos.EliminarProducto(id_producto);

                    // Mostrar resultado
                    MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                // Refrescar ComboBox de productos (opcional)
                CargarProductosPorCategoria(Convert.ToInt32(cmbEliminarCategoriaProducto.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado una categoría
                if (cmbActualizarCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se haya ingresado un nuevo nombre
                if (string.IsNullOrWhiteSpace(txtActualizarCategoria.Text))
                {
                    MessageBox.Show("Debe ingresar un nuevo nombre para la categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el id de la categoría seleccionada
                int id_categoria = Convert.ToInt32(cmbActualizarCategoria.SelectedValue);

                // Obtener el nuevo nombre desde el TextBox
                string nuevoNombre = txtActualizarCategoria.Text.Trim();

                // Instanciar la clase de datos
                D_Categorias datos = new D_Categorias();

                // Llamar al método de actualización
                string resultado = datos.ActualizarCategoria(id_categoria, nuevoNombre);

                // Mostrar resultado
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar ComboBox de categorías
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
                MessageBox.Show("Error al actualizar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbEliminarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado una categoría
                if (cmbEliminarCliente.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un cliente para eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el id del producto seleccionado
                int id_cliente = Convert.ToInt32(cmbEliminarCliente.SelectedValue);
                DialogResult confirmacion = MessageBox.Show(
                   "¿Está seguro que desea eliminar este cliente?",
                   "Confirmar eliminación",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

                if (confirmacion == DialogResult.Yes)
                {
                    // Instanciar la clase de datos
                    D_Cliente datos = new D_Cliente();

                    // Llamar al método de eliminación
                    string resultado = datos.EliminarCliente(id_cliente);

                    // Mostrar resultado
                    MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientesEnComboBox();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cmbClienteActualizar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtActualizarNombreProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e) //btnActualizarCliente
        {

            try
            {
                // 1. Obtener el ID del cliente seleccionado en el ComboBox
                if (cmbClienteActualizar.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCliente = Convert.ToInt32(cmbClienteActualizar.SelectedValue);

                // 2. Obtener los nuevos valores de los TextBox
                string nombre = txtActualizarNombreCliente.Text.Trim();
                string apellido = txtActualizarApellidoCliente.Text.Trim();
                string email = txtActualizarCorreoCliente.Text.Trim();

                // Validación básica
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Debe completar todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Llamar al método ActualizarCliente
                D_Cliente datos = new D_Cliente();

                string respuesta = datos.ActualizarCliente(idCliente, nombre, apellido, email);

                // 4. Mostrar resultado
                if (respuesta == "OK")
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refrescar ComboBox de clientes
                    CargarClientesEnComboBox();
                    LimpiarControlesActualizarCliente();
                }
                else
                {
                    MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            //cmbActualizarCategoriaProducto = combobox de categorías
            //cmbProductoActualizarProducto = combobox de productos
            //txtActualizarNombreProducto = textbox del nombre del producto
            //nudActualizarProductoPrecio = numericupdown del precio
            //nudActualizarProductoExistencias = numericupdown de existencias
            //btnActualizarProducto = botón para actualizar el producto
            try
            {
                // 1. Validar selección de categoría
                if (cmbActualizarCategoriaProducto.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCategoria = Convert.ToInt32(cmbActualizarCategoriaProducto.SelectedValue);

                // 2. Validar selección de producto
                if (cmbProductoActualizarProducto.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProducto = Convert.ToInt32(cmbProductoActualizarProducto.SelectedValue);

                // 3. Obtener nuevos valores
                string nombreProducto = txtActualizarNombreProducto.Text.Trim();
                decimal precioProducto = nudActualizarProductoPrecio.Value; // ya definido para decimales
                int existenciasProducto = (int)nudActualizarUnidadesProducto.Value;

                if (string.IsNullOrEmpty(nombreProducto))
                {
                    MessageBox.Show("Debe ingresar el nombre del producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Llamar al método ActualizarProducto
                D_Productos datos = new D_Productos();
                string respuesta = datos.ActualizarProducto(idProducto, nombreProducto, idCategoria, precioProducto, existenciasProducto);

                // 5. Mostrar resultado
                if (respuesta == "Actualización exitosa.")
                {
                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refrescar ComboBox de productos
                    CargarProductosPorCategoria(idCategoria);
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void nudActualizarProductoPrecio_ValueChanged(object sender, EventArgs e)
        {
            nudActualizarProductoPrecio.DecimalPlaces = 2; // ahora acepta hasta 2 decimales
            nudActualizarProductoPrecio.Maximum = 1000000; // valor máximo permitido


        

        }
    }
}

