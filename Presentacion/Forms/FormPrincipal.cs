using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaComun.Cache;

namespace Presentacion.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            CargarUsuario();
        }

        private void FromPrincipal_Load(object sender, EventArgs e)
        {
           
        }
        #region Funcionalidades del formulario
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro quiere cerrar la aplicación?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
     

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
     

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int xParam, int lParam);


        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            
            AbrirFormulario<Facturacion>();
            if (Application.OpenForms["Articulos"] != null)
            {
                Application.OpenForms["Articulos"].Close();
            }
            if (Application.OpenForms["Clientes"] != null)
            {
                Application.OpenForms["Clientes"].Close();
            }
            if (Application.OpenForms["Proveedores"] != null)
            {
                Application.OpenForms["Proveedores"].Close();
            }
            if (Application.OpenForms["Facturas"] != null)
            {
                Application.OpenForms["Facturas"].Close();
            }
            if (Application.OpenForms["Compras"] != null)
            {
                Application.OpenForms["Compras"].Close();
            }
            if (Application.OpenForms["ComprasReportes"] != null)
            {
                Application.OpenForms["ComprasReportes"].Close();
            }


            btnFacturar.BackColor = Color.FromArgb(138, 149, 151);
        }
        private void BtnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Facturas>();
            btnReportes.BackColor = Color.FromArgb(138, 149, 151);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Compras>();
            btnCompras.BackColor = Color.FromArgb(138, 149, 151);
        }

        private void btnRepostesCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ComprasReportes>();
            btnRepostesCompras.BackColor = Color.FromArgb(138, 149, 151);
        }
        private void BtnMenuProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Articulos>();
            btnMenuProductos.BackColor = Color.FromArgb(138,149,151);
        }

        private void BtnMenuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Proveedores>();
            btnMenuProveedores.BackColor = Color.FromArgb(138, 149, 151);
        }
     

        private void BtnMenuClientes_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<Clientes>();
            btnMenuClientes.BackColor = Color.FromArgb(138, 149, 151);
        }

        private void PanelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro quiere cerrar la sesion?", "Warning",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            this.Close();

        }

        #endregion

        //METODO PARA ABRIR FORMULARIO DENTRO DEL PANEL
        private void AbrirFormulario<MiForm>()where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca el la coleccion el formulario
            //si el formulario/instancia no existe
            if(formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        




        //METODO PARA VOLVER LOS COLORES DE LOS BOTONES AL DEFAULT
        private void CloseForms(object sender, FormClosedEventArgs e)

        {
            if (Application.OpenForms["Facturar"] == null)
                btnFacturar.BackColor = Color.FromArgb(227, 228, 229);
            if (Application.OpenForms["Reportes"] == null)
                btnReportes.BackColor = Color.FromArgb(227, 228, 229);
            if (Application.OpenForms["Compras"] == null)
                btnCompras.BackColor = Color.FromArgb(227, 228, 229);
            if (Application.OpenForms["ComprasReportes"] == null)
                btnRepostesCompras.BackColor = Color.FromArgb(227, 228, 229);
            if (Application.OpenForms["Proveedores"] == null)
                btnMenuProveedores.BackColor = Color.FromArgb(227, 228, 229);
            if (Application.OpenForms["Clientes"] == null)
                btnMenuClientes.BackColor = Color.FromArgb(227, 228, 229);
            if (Application.OpenForms["Articulos"] == null)
                btnMenuProductos.BackColor = Color.FromArgb(227, 228, 229);

        }
        private void CargarUsuario() 
        {
            labUsuario.Text = UserLoginCache.Nombre;
        }
    }
}