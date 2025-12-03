using Datos;
using SmartManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartManager
{
    public partial class SmartManager : Form
    {
        public SmartManager()
        {
            InitializeComponent();
        }



        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void SmartManager_Load(object sender, EventArgs e)
        {
            try
            {
                D_Categorias dcat = new D_Categorias();
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
    }
}

