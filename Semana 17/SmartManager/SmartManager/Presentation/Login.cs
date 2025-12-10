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

namespace SmartManager.Presentation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '*';
            txtContraseña.MaxLength = 8;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.MaxLength = 8;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            D_Vendedores dVendedores = new D_Vendedores();
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (dVendedores.Login(usuario, contraseña))
            {
                this.DialogResult = DialogResult.OK; 
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
