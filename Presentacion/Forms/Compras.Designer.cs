namespace Presentacion.Forms
{
    partial class Compras
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
            this.btnEliminarArt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTipoFactura = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.txtPuntoDeVenta = new System.Windows.Forms.TextBox();
            this.Fecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.btnListaClientes = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRespIva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnListaArt = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.BtnAddArticulo = new System.Windows.Forms.Button();
            this.cbxFormaDePago = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txtPreciounitario = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTotal = new System.Windows.Forms.Label();
            this.labIva = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminarArt
            // 
            this.btnEliminarArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminarArt.Location = new System.Drawing.Point(12, 481);
            this.btnEliminarArt.Name = "btnEliminarArt";
            this.btnEliminarArt.Size = new System.Drawing.Size(75, 37);
            this.btnEliminarArt.TabIndex = 29;
            this.btnEliminarArt.Text = "ELIMINAR ARTICULO";
            this.btnEliminarArt.UseVisualStyleBackColor = true;
            this.btnEliminarArt.Click += new System.EventHandler(this.btnEliminarArt_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxTipoFactura);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtNumFactura);
            this.panel1.Controls.Add(this.txtPuntoDeVenta);
            this.panel1.Controls.Add(this.Fecha);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.btnListaClientes);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtRespIva);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDireccion);
            this.panel1.Controls.Add(this.txtCuit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 175);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tipo";
            // 
            // cbxTipoFactura
            // 
            this.cbxTipoFactura.FormattingEnabled = true;
            this.cbxTipoFactura.Location = new System.Drawing.Point(125, 146);
            this.cbxTipoFactura.Name = "cbxTipoFactura";
            this.cbxTipoFactura.Size = new System.Drawing.Size(56, 21);
            this.cbxTipoFactura.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(255, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Número";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "PV";
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(258, 146);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(128, 20);
            this.txtNumFactura.TabIndex = 17;
            // 
            // txtPuntoDeVenta
            // 
            this.txtPuntoDeVenta.Location = new System.Drawing.Point(189, 146);
            this.txtPuntoDeVenta.Name = "txtPuntoDeVenta";
            this.txtPuntoDeVenta.Size = new System.Drawing.Size(57, 20);
            this.txtPuntoDeVenta.TabIndex = 16;
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Location = new System.Drawing.Point(17, 130);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(37, 13);
            this.Fecha.TabIndex = 15;
            this.Fecha.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(16, 146);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(103, 20);
            this.txtFecha.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "PROVEEDOR";
            // 
            // btnListaClientes
            // 
            this.btnListaClientes.Location = new System.Drawing.Point(16, 33);
            this.btnListaClientes.Name = "btnListaClientes";
            this.btnListaClientes.Size = new System.Drawing.Size(48, 20);
            this.btnListaClientes.TabIndex = 10;
            this.btnListaClientes.Text = "Buscar";
            this.btnListaClientes.UseVisualStyleBackColor = true;
            this.btnListaClientes.Click += new System.EventHandler(this.btnListaClientes_Click_1);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(70, 33);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(276, 20);
            this.txtRazonSocial.TabIndex = 0;
            this.txtRazonSocial.Leave += new System.EventHandler(this.TxtRazonSocial_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Resp. Iva";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Razón Social";
            // 
            // txtRespIva
            // 
            this.txtRespIva.Location = new System.Drawing.Point(370, 76);
            this.txtRespIva.Name = "txtRespIva";
            this.txtRespIva.ReadOnly = true;
            this.txtRespIva.Size = new System.Drawing.Size(118, 20);
            this.txtRespIva.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(19, 76);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(329, 20);
            this.txtDireccion.TabIndex = 6;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(370, 33);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.ReadOnly = true;
            this.txtCuit.Size = new System.Drawing.Size(118, 20);
            this.txtCuit.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cuit/Cuil";
            // 
            // btnListaArt
            // 
            this.btnListaArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnListaArt.Location = new System.Drawing.Point(60, 212);
            this.btnListaArt.Name = "btnListaArt";
            this.btnListaArt.Size = new System.Drawing.Size(34, 20);
            this.btnListaArt.TabIndex = 28;
            this.btnListaArt.Text = "Art.";
            this.btnListaArt.UseVisualStyleBackColor = true;
            this.btnListaArt.Click += new System.EventHandler(this.btnListaArt_Click_1);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(492, 569);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Forma de Pago";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Detalle Factura";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(698, 190);
            this.dataGridView1.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(500, 467);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 25);
            this.label15.TabIndex = 24;
            this.label15.Text = "Subtotal $";
            // 
            // BtnAddArticulo
            // 
            this.BtnAddArticulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAddArticulo.Location = new System.Drawing.Point(658, 211);
            this.BtnAddArticulo.Name = "BtnAddArticulo";
            this.BtnAddArticulo.Size = new System.Drawing.Size(48, 20);
            this.BtnAddArticulo.TabIndex = 11;
            this.BtnAddArticulo.Text = "OK";
            this.BtnAddArticulo.UseVisualStyleBackColor = true;
            this.BtnAddArticulo.Click += new System.EventHandler(this.BtnAddArticulo_Click_1);
            // 
            // cbxFormaDePago
            // 
            this.cbxFormaDePago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxFormaDePago.FormattingEnabled = true;
            this.cbxFormaDePago.Location = new System.Drawing.Point(492, 588);
            this.cbxFormaDePago.Name = "cbxFormaDePago";
            this.cbxFormaDePago.Size = new System.Drawing.Size(121, 21);
            this.cbxFormaDePago.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(605, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Total Neto";
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSubtotal.AutoSize = true;
            this.labelSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtotal.Location = new System.Drawing.Point(635, 463);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Size = new System.Drawing.Size(45, 29);
            this.labelSubtotal.TabIndex = 25;
            this.labelSubtotal.Text = "0.0";
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrecioTotal.Location = new System.Drawing.Point(606, 212);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(46, 20);
            this.txtPrecioTotal.TabIndex = 19;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFacturar.Location = new System.Drawing.Point(619, 588);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 26;
            this.btnFacturar.Text = "PAGAR";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click_1);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(548, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 26);
            this.label9.TabIndex = 18;
            this.label9.Text = "Precio U.\r\nNeto";
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(12, 536);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "CANCELAR";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtPreciounitario
            // 
            this.txtPreciounitario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPreciounitario.Location = new System.Drawing.Point(551, 212);
            this.txtPreciounitario.Name = "txtPreciounitario";
            this.txtPreciounitario.Size = new System.Drawing.Size(46, 20);
            this.txtPreciounitario.TabIndex = 17;
            this.txtPreciounitario.Leave += new System.EventHandler(this.TxtPreciounitario_Leave);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(240, 212);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(305, 20);
            this.txtDescripcion.TabIndex = 15;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            this.txtDescripcion.Leave += new System.EventHandler(this.TxtDescripcion_Leave);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Descripción";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCantidad.Location = new System.Drawing.Point(13, 212);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(41, 20);
            this.txtCantidad.TabIndex = 11;
            this.txtCantidad.Leave += new System.EventHandler(this.TxtCantidad_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cant.";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodigo.Location = new System.Drawing.Point(100, 212);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(134, 20);
            this.txtCodigo.TabIndex = 13;
            this.txtCodigo.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labTotal);
            this.panel2.Controls.Add(this.labIva);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnEliminarArt);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnListaArt);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.BtnAddArticulo);
            this.panel2.Controls.Add(this.cbxFormaDePago);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.labelSubtotal);
            this.panel2.Controls.Add(this.txtPrecioTotal);
            this.panel2.Controls.Add(this.btnFacturar);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.txtPreciounitario);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtCantidad);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Location = new System.Drawing.Point(54, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 649);
            this.panel2.TabIndex = 33;
            // 
            // labTotal
            // 
            this.labTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labTotal.AutoSize = true;
            this.labTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTotal.Location = new System.Drawing.Point(635, 518);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(45, 29);
            this.labTotal.TabIndex = 35;
            this.labTotal.Text = "0.0";
            // 
            // labIva
            // 
            this.labIva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labIva.AutoSize = true;
            this.labIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIva.Location = new System.Drawing.Point(635, 493);
            this.labIva.Name = "labIva";
            this.labIva.Size = new System.Drawing.Size(45, 29);
            this.labIva.TabIndex = 34;
            this.labIva.Text = "0.0";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(528, 518);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 25);
            this.label18.TabIndex = 33;
            this.label18.Text = "Total $";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(546, 493);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 25);
            this.label13.TabIndex = 32;
            this.label13.Text = "Iva $";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "COMPROBANTE";
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 710);
            this.Controls.Add(this.panel2);
            this.Name = "Compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCompras";
            this.Load += new System.EventHandler(this.FormCompras_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarArt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnListaClientes;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRespIva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnListaArt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button BtnAddArticulo;
        private System.Windows.Forms.ComboBox cbxFormaDePago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtPreciounitario;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.TextBox txtPuntoDeVenta;
        private System.Windows.Forms.Label Fecha;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTipoFactura;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Label labIva;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
    }
}