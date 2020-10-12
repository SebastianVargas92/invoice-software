using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;
using Dominio.Modelos;

namespace Presentacion.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int xParam, int lParam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "USUARIO") { 
             if(txtPass.Text != "CONTRASEÑA")
                {
                    UsuarioModelo user = new UsuarioModelo();
                    bool valido = user.LoginUser(txtUser.Text, txtPass.Text);
                    if(valido == true)
                    {
                        FormPrincipal principal = new FormPrincipal();
                        principal.Show();
                        principal.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario o Contraseña incorrectos");
                    }
                }
                else msgError("Ingrese su Contraseña");
            }
            else msgError("Ingrese su Usuario");
        }
        private void msgError(string msg)
        {
            labelError.Text = msg;
            labelError.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUser.Text = "USUARIO";
            txtPass.UseSystemPasswordChar = false;
            txtPass.Text = "CONTRASEÑA";
            labelError.Visible = false;
            this.Show();
        }
    }
}
