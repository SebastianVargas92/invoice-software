namespace Presentacion.Forms
{
    partial class AddArticulo
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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtRentabilidad = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtL2 = new System.Windows.Forms.TextBox();
            this.txtL3 = new System.Windows.Forms.TextBox();
            this.txtPunto = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.labelRenta = new System.Windows.Forms.Label();
            this.cbxGrupos = new System.Windows.Forms.ComboBox();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.cbxIva = new System.Windows.Forms.ComboBox();
            this.btnMarca = new System.Windows.Forms.Button();
            this.btnAgGrupo = new System.Windows.Forms.Button();
            this.AgregarIva = new System.Windows.Forms.Button();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.btnAddProveedor = new System.Windows.Forms.Button();
            this.autoNum_Button = new System.Windows.Forms.Button();
            this.txtImpInterno = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCantidadM = new System.Windows.Forms.TextBox();
            this.checkBoxStock = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(15, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(90, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(187, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(442, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(15, 84);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 3;
           // this.txtCosto.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            this.txtCosto.Leave += new System.EventHandler(this.TxtCosto_Leave);
            // 
            // txtRentabilidad
            // 
            this.txtRentabilidad.Location = new System.Drawing.Point(141, 84);
            this.txtRentabilidad.Name = "txtRentabilidad";
            this.txtRentabilidad.Size = new System.Drawing.Size(100, 20);
            this.txtRentabilidad.TabIndex = 4;
           // this.txtRentabilidad.TextChanged += new System.EventHandler(this.TxtRentabilidad_TextChanged);
            this.txtRentabilidad.Leave += new System.EventHandler(this.TxtRentabilidad_Leave);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(285, 84);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 5;
         //   this.txtPrecio.TextChanged += new System.EventHandler(this.TxtPrecio_TextChanged);
            this.txtPrecio.Leave += new System.EventHandler(this.TxtPrecio_Leave);
            // 
            // txtL2
            // 
            this.txtL2.Location = new System.Drawing.Point(409, 84);
            this.txtL2.Name = "txtL2";
            this.txtL2.Size = new System.Drawing.Size(100, 20);
            this.txtL2.TabIndex = 6;
            // 
            // txtL3
            // 
            this.txtL3.Location = new System.Drawing.Point(529, 84);
            this.txtL3.Name = "txtL3";
            this.txtL3.Size = new System.Drawing.Size(100, 20);
            this.txtL3.TabIndex = 7;
            // 
            // txtPunto
            // 
            this.txtPunto.Location = new System.Drawing.Point(154, 229);
            this.txtPunto.Name = "txtPunto";
            this.txtPunto.Size = new System.Drawing.Size(100, 20);
            this.txtPunto.TabIndex = 13;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(386, 229);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Codigo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Marca";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Punto de pedido";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(506, 211);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(123, 38);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(406, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Precio L2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(526, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Precio L3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Iva";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Costo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Grupo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(432, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Proveedor";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(606, 5);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(22, 20);
            this.txtId.TabIndex = 28;
            this.txtId.Visible = false;
            // 
            // labelRenta
            // 
            this.labelRenta.AutoSize = true;
            this.labelRenta.Location = new System.Drawing.Point(140, 68);
            this.labelRenta.Name = "labelRenta";
            this.labelRenta.Size = new System.Drawing.Size(77, 13);
            this.labelRenta.TabIndex = 30;
            this.labelRenta.Text = "Rentabilidad %";
            // 
            // cbxGrupos
            // 
            this.cbxGrupos.FormattingEnabled = true;
            this.cbxGrupos.Location = new System.Drawing.Point(225, 134);
            this.cbxGrupos.Name = "cbxGrupos";
            this.cbxGrupos.Size = new System.Drawing.Size(165, 21);
            this.cbxGrupos.TabIndex = 9;
            // 
            // cbxMarca
            // 
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(16, 135);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(165, 21);
            this.cbxMarca.TabIndex = 8;
            // 
            // cbxIva
            // 
            this.cbxIva.FormattingEnabled = true;
            this.cbxIva.Location = new System.Drawing.Point(15, 184);
            this.cbxIva.Name = "cbxIva";
            this.cbxIva.Size = new System.Drawing.Size(55, 21);
            this.cbxIva.TabIndex = 11;
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(187, 135);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(23, 23);
            this.btnMarca.TabIndex = 34;
            this.btnMarca.Text = "+";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.BtnMarca_Click);
            // 
            // btnAgGrupo
            // 
            this.btnAgGrupo.Location = new System.Drawing.Point(396, 133);
            this.btnAgGrupo.Name = "btnAgGrupo";
            this.btnAgGrupo.Size = new System.Drawing.Size(23, 23);
            this.btnAgGrupo.TabIndex = 35;
            this.btnAgGrupo.Text = "+";
            this.btnAgGrupo.UseVisualStyleBackColor = true;
            this.btnAgGrupo.Click += new System.EventHandler(this.BtnAgGrupo_Click);
            // 
            // AgregarIva
            // 
            this.AgregarIva.Location = new System.Drawing.Point(76, 184);
            this.AgregarIva.Name = "AgregarIva";
            this.AgregarIva.Size = new System.Drawing.Size(23, 23);
            this.AgregarIva.TabIndex = 36;
            this.AgregarIva.Text = "+";
            this.AgregarIva.UseVisualStyleBackColor = true;
            this.AgregarIva.Click += new System.EventHandler(this.AgregarIva_Click);
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.Location = new System.Drawing.Point(435, 133);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(165, 21);
            this.cbxProveedor.TabIndex = 10;
            // 
            // btnAddProveedor
            // 
            this.btnAddProveedor.Location = new System.Drawing.Point(606, 131);
            this.btnAddProveedor.Name = "btnAddProveedor";
            this.btnAddProveedor.Size = new System.Drawing.Size(23, 23);
            this.btnAddProveedor.TabIndex = 38;
            this.btnAddProveedor.Text = "+";
            this.btnAddProveedor.UseVisualStyleBackColor = true;
            this.btnAddProveedor.Click += new System.EventHandler(this.BtnAddProveedor_Click);
            // 
            // autoNum_Button
            // 
            this.autoNum_Button.Location = new System.Drawing.Point(111, 31);
            this.autoNum_Button.Name = "autoNum_Button";
            this.autoNum_Button.Size = new System.Drawing.Size(44, 20);
            this.autoNum_Button.TabIndex = 39;
            this.autoNum_Button.Text = "Auto";
            this.autoNum_Button.UseVisualStyleBackColor = true;
            this.autoNum_Button.Click += new System.EventHandler(this.AutoNum_Button_Click);
            // 
            // txtImpInterno
            // 
            this.txtImpInterno.Location = new System.Drawing.Point(15, 229);
            this.txtImpInterno.Name = "txtImpInterno";
            this.txtImpInterno.Size = new System.Drawing.Size(84, 20);
            this.txtImpInterno.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Imp.Interno %";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(282, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Cantidad Max.";
            // 
            // txtCantidadM
            // 
            this.txtCantidadM.Location = new System.Drawing.Point(272, 229);
            this.txtCantidadM.Name = "txtCantidadM";
            this.txtCantidadM.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadM.TabIndex = 15;
            // 
            // checkBoxStock
            // 
            this.checkBoxStock.AutoSize = true;
            this.checkBoxStock.Location = new System.Drawing.Point(272, 184);
            this.checkBoxStock.Name = "checkBoxStock";
            this.checkBoxStock.Size = new System.Drawing.Size(96, 17);
            this.checkBoxStock.TabIndex = 13;
            this.checkBoxStock.Text = "Controla Stock";
            this.checkBoxStock.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Stock";
            // 
            // AddArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 273);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBoxStock);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCantidadM);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtImpInterno);
            this.Controls.Add(this.autoNum_Button);
            this.Controls.Add(this.btnAddProveedor);
            this.Controls.Add(this.cbxProveedor);
            this.Controls.Add(this.AgregarIva);
            this.Controls.Add(this.btnAgGrupo);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.cbxIva);
            this.Controls.Add(this.cbxMarca);
            this.Controls.Add(this.cbxGrupos);
            this.Controls.Add(this.labelRenta);
            this.Controls.Add(this.txtRentabilidad);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtL3);
            this.Controls.Add(this.txtL2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPunto);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Name = "AddArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormArticulo";
            this.Load += new System.EventHandler(this.FormArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.TextBox txtCosto;
        public System.Windows.Forms.TextBox txtRentabilidad;
        public System.Windows.Forms.TextBox txtPrecio;
        public System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.TextBox txtPunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox txtL2;
        public System.Windows.Forms.TextBox txtL3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label labelRenta;
        public System.Windows.Forms.ComboBox cbxGrupos;
        public System.Windows.Forms.ComboBox cbxMarca;
        public System.Windows.Forms.ComboBox cbxIva;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button btnAgGrupo;
        private System.Windows.Forms.Button AgregarIva;
        public System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.Button btnAddProveedor;
        private System.Windows.Forms.Button autoNum_Button;
        public System.Windows.Forms.TextBox txtImpInterno;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtCantidadM;
        private System.Windows.Forms.CheckBox checkBoxStock;
        private System.Windows.Forms.Label label7;
    }
}