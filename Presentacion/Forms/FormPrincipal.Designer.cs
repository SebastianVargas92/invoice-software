namespace Presentacion.Forms
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.btnRepostesCompras = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMenuClientes = new System.Windows.Forms.Button();
            this.btnMenuProveedores = new System.Windows.Forms.Button();
            this.btnMenuProductos = new System.Windows.Forms.Button();
            this.panelBarraTitulo = new System.Windows.Forms.Panel();
            this.labUsuario = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panelContenedor.SuspendLayout();
            this.panelmenu.SuspendLayout();
            this.panelBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelContenedor.Controls.Add(this.panelFormularios);
            this.panelContenedor.Controls.Add(this.panelmenu);
            this.panelContenedor.Controls.Add(this.panelBarraTitulo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1200, 650);
            this.panelContenedor.TabIndex = 0;
            // 
            // panelFormularios
            // 
            this.panelFormularios.BackColor = System.Drawing.SystemColors.Control;
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.Location = new System.Drawing.Point(190, 40);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(1010, 610);
            this.panelFormularios.TabIndex = 2;
            this.panelFormularios.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelFormularios_Paint);
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.Silver;
            this.panelmenu.Controls.Add(this.btnRepostesCompras);
            this.panelmenu.Controls.Add(this.btnCompras);
            this.panelmenu.Controls.Add(this.btnReportes);
            this.panelmenu.Controls.Add(this.btnFacturar);
            this.panelmenu.Controls.Add(this.button1);
            this.panelmenu.Controls.Add(this.btnMenuClientes);
            this.panelmenu.Controls.Add(this.btnMenuProveedores);
            this.panelmenu.Controls.Add(this.btnMenuProductos);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmenu.Location = new System.Drawing.Point(0, 40);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(190, 610);
            this.panelmenu.TabIndex = 1;
            // 
            // btnRepostesCompras
            // 
            this.btnRepostesCompras.BackColor = System.Drawing.Color.Silver;
            this.btnRepostesCompras.FlatAppearance.BorderSize = 0;
            this.btnRepostesCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRepostesCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRepostesCompras.Location = new System.Drawing.Point(0, 187);
            this.btnRepostesCompras.Name = "btnRepostesCompras";
            this.btnRepostesCompras.Size = new System.Drawing.Size(190, 51);
            this.btnRepostesCompras.TabIndex = 7;
            this.btnRepostesCompras.Text = "Reportes Compras";
            this.btnRepostesCompras.UseVisualStyleBackColor = false;
            this.btnRepostesCompras.Click += new System.EventHandler(this.btnRepostesCompras_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.Silver;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCompras.Location = new System.Drawing.Point(0, 130);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(190, 51);
            this.btnCompras.TabIndex = 6;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.Silver;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReportes.Location = new System.Drawing.Point(0, 73);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(190, 51);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "Reportes Ventas";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.BtnReportes_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.Color.Silver;
            this.btnFacturar.FlatAppearance.BorderSize = 0;
            this.btnFacturar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnFacturar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnFacturar.Location = new System.Drawing.Point(0, 16);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(190, 51);
            this.btnFacturar.TabIndex = 4;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.BtnFacturar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.Location = new System.Drawing.Point(0, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cerrar Sesion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnMenuClientes
            // 
            this.btnMenuClientes.BackColor = System.Drawing.Color.Silver;
            this.btnMenuClientes.FlatAppearance.BorderSize = 0;
            this.btnMenuClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnMenuClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuClientes.Location = new System.Drawing.Point(0, 399);
            this.btnMenuClientes.Name = "btnMenuClientes";
            this.btnMenuClientes.Size = new System.Drawing.Size(190, 51);
            this.btnMenuClientes.TabIndex = 2;
            this.btnMenuClientes.Text = "Clientes";
            this.btnMenuClientes.UseVisualStyleBackColor = false;
            this.btnMenuClientes.Click += new System.EventHandler(this.BtnMenuClientes_Click_1);
            // 
            // btnMenuProveedores
            // 
            this.btnMenuProveedores.BackColor = System.Drawing.Color.Silver;
            this.btnMenuProveedores.FlatAppearance.BorderSize = 0;
            this.btnMenuProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnMenuProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuProveedores.Location = new System.Drawing.Point(0, 342);
            this.btnMenuProveedores.Name = "btnMenuProveedores";
            this.btnMenuProveedores.Size = new System.Drawing.Size(190, 51);
            this.btnMenuProveedores.TabIndex = 1;
            this.btnMenuProveedores.Text = "Proveedores";
            this.btnMenuProveedores.UseVisualStyleBackColor = false;
            this.btnMenuProveedores.Click += new System.EventHandler(this.BtnMenuProveedores_Click);
            // 
            // btnMenuProductos
            // 
            this.btnMenuProductos.BackColor = System.Drawing.Color.Silver;
            this.btnMenuProductos.FlatAppearance.BorderSize = 0;
            this.btnMenuProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnMenuProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMenuProductos.Location = new System.Drawing.Point(0, 285);
            this.btnMenuProductos.Name = "btnMenuProductos";
            this.btnMenuProductos.Size = new System.Drawing.Size(190, 51);
            this.btnMenuProductos.TabIndex = 0;
            this.btnMenuProductos.Text = "Articulos";
            this.btnMenuProductos.UseVisualStyleBackColor = false;
            this.btnMenuProductos.Click += new System.EventHandler(this.BtnMenuProductos_Click);
            // 
            // panelBarraTitulo
            // 
            this.panelBarraTitulo.BackColor = System.Drawing.Color.SlateGray;
            this.panelBarraTitulo.Controls.Add(this.labUsuario);
            this.panelBarraTitulo.Controls.Add(this.btnRestaurar);
            this.panelBarraTitulo.Controls.Add(this.btnMaximizar);
            this.panelBarraTitulo.Controls.Add(this.btnMinimizar);
            this.panelBarraTitulo.Controls.Add(this.btnCerrar);
            this.panelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelBarraTitulo.Name = "panelBarraTitulo";
            this.panelBarraTitulo.Size = new System.Drawing.Size(1200, 40);
            this.panelBarraTitulo.TabIndex = 0;
            this.panelBarraTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBarraTitulo_MouseMove);
            // 
            // labUsuario
            // 
            this.labUsuario.AutoSize = true;
            this.labUsuario.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUsuario.Location = new System.Drawing.Point(13, 13);
            this.labUsuario.Name = "labUsuario";
            this.labUsuario.Size = new System.Drawing.Size(60, 19);
            this.labUsuario.TabIndex = 3;
            this.labUsuario.Text = "Usuario";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = global::Presentacion.Properties.Resources.Normal;
            this.btnRestaurar.Location = new System.Drawing.Point(1148, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(16, 16);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 2;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = global::Presentacion.Properties.Resources.maximize3;
            this.btnMaximizar.Location = new System.Drawing.Point(1148, 12);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(16, 16);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 0;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = global::Presentacion.Properties.Resources.Minimize;
            this.btnMinimizar.Location = new System.Drawing.Point(1126, 12);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(16, 16);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::Presentacion.Properties.Resources.Close;
            this.btnCerrar.Location = new System.Drawing.Point(1170, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(16, 16);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelContenedor.ResumeLayout(false);
            this.panelmenu.ResumeLayout(false);
            this.panelBarraTitulo.ResumeLayout(false);
            this.panelBarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.Panel panelBarraTitulo;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button btnMenuProveedores;
        private System.Windows.Forms.Button btnMenuProductos;
        private System.Windows.Forms.Button btnMenuClientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labUsuario;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnRepostesCompras;
        private System.Windows.Forms.Button btnCompras;
    }
}