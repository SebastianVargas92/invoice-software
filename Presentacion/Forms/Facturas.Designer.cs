namespace Presentacion.Forms
{
    partial class Facturas
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
            this.components = new System.ComponentModel.Container();
            this.baseUltimaDataSet = new Presentacion.BaseUltimaDataSet();
            this.fACTURASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fACTURASTableAdapter = new Presentacion.BaseUltimaDataSetTableAdapters.FACTURASTableAdapter();
            this.tableAdapterManager = new Presentacion.BaseUltimaDataSetTableAdapters.TableAdapterManager();
            this.fACTURA_DETALLETableAdapter = new Presentacion.BaseUltimaDataSetTableAdapters.FACTURA_DETALLETableAdapter();
            this.FacturasDataGridView = new System.Windows.Forms.DataGridView();
            this.fACTURA_DETALLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DetalleDataGridView = new System.Windows.Forms.DataGridView();
            this.Buscar = new System.Windows.Forms.Label();
            this.Cerrar = new System.Windows.Forms.Button();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTipoFact = new System.Windows.Forms.ComboBox();
            this.comboFormaPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.baseUltimaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURA_DETALLEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // baseUltimaDataSet
            // 
            this.baseUltimaDataSet.DataSetName = "BaseUltimaDataSet";
            this.baseUltimaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fACTURASTableAdapter
            // 
            this.fACTURASTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.FACTURA_DETALLETableAdapter = this.fACTURA_DETALLETableAdapter;
            this.tableAdapterManager.FACTURASTableAdapter = this.fACTURASTableAdapter;
            this.tableAdapterManager.UpdateOrder = Presentacion.BaseUltimaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fACTURA_DETALLETableAdapter
            // 
            this.fACTURA_DETALLETableAdapter.ClearBeforeFill = true;
            // 
            // FacturasDataGridView
            // 
            this.FacturasDataGridView.AllowUserToAddRows = false;
            this.FacturasDataGridView.AllowUserToDeleteRows = false;
            this.FacturasDataGridView.AllowUserToOrderColumns = true;
            this.FacturasDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FacturasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FacturasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FacturasDataGridView.Location = new System.Drawing.Point(12, 92);
            this.FacturasDataGridView.Name = "FacturasDataGridView";
            this.FacturasDataGridView.Size = new System.Drawing.Size(856, 202);
            this.FacturasDataGridView.TabIndex = 1;
            this.FacturasDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FacturasDataGridView_Click);
            // 
            // fACTURA_DETALLEBindingSource
            // 
            this.fACTURA_DETALLEBindingSource.DataSource = this.fACTURASBindingSource;
            // 
            // DetalleDataGridView
            // 
            this.DetalleDataGridView.AllowUserToAddRows = false;
            this.DetalleDataGridView.AllowUserToDeleteRows = false;
            this.DetalleDataGridView.AllowUserToOrderColumns = true;
            this.DetalleDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DetalleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DetalleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetalleDataGridView.Location = new System.Drawing.Point(12, 329);
            this.DetalleDataGridView.Name = "DetalleDataGridView";
            this.DetalleDataGridView.Size = new System.Drawing.Size(648, 163);
            this.DetalleDataGridView.TabIndex = 2;
            // 
            // Buscar
            // 
            this.Buscar.AutoSize = true;
            this.Buscar.Location = new System.Drawing.Point(10, 41);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(139, 13);
            this.Buscar.TabIndex = 21;
            this.Buscar.Text = "Buscar por número o cliente";
            // 
            // Cerrar
            // 
            this.Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cerrar.Location = new System.Drawing.Point(793, 12);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 20;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.Location = new System.Drawing.Point(10, 60);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(239, 20);
            this.textBoxBusqueda.TabIndex = 19;
            this.textBoxBusqueda.TextChanged += new System.EventHandler(this.TextBoxBusqueda_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(370, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Facturas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboTipoFact
            // 
            this.comboTipoFact.FormattingEnabled = true;
            this.comboTipoFact.Items.AddRange(new object[] {
            "Seleccione un ítem",
            "A",
            "B",
            "C"});
            this.comboTipoFact.Location = new System.Drawing.Point(285, 60);
            this.comboTipoFact.Name = "comboTipoFact";
            this.comboTipoFact.Size = new System.Drawing.Size(121, 21);
            this.comboTipoFact.TabIndex = 22;
            this.comboTipoFact.SelectedIndexChanged += new System.EventHandler(this.ComboTipoFact_SelectedIndexChanged);
            // 
            // comboFormaPago
            // 
            this.comboFormaPago.FormattingEnabled = true;
            this.comboFormaPago.Items.AddRange(new object[] {
            "Seleccione un ítem",
            "Efectivo",
            "Tarjeta"});
            this.comboFormaPago.Location = new System.Drawing.Point(443, 60);
            this.comboFormaPago.Name = "comboFormaPago";
            this.comboFormaPago.Size = new System.Drawing.Size(121, 21);
            this.comboFormaPago.TabIndex = 23;
            this.comboFormaPago.SelectedIndexChanged += new System.EventHandler(this.ComboFormaPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tipo de factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Forma de pago";
            // 
            // dateDesde
            // 
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDesde.Location = new System.Drawing.Point(633, 36);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(199, 20);
            this.dateDesde.TabIndex = 26;
            this.dateDesde.ValueChanged += new System.EventHandler(this.DateDesde_ValueChanged);
            // 
            // dateHasta
            // 
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHasta.Location = new System.Drawing.Point(633, 62);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(199, 20);
            this.dateHasta.TabIndex = 27;
            this.dateHasta.ValueChanged += new System.EventHandler(this.DateHasta_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(589, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Desde";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(804, 57);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(55, 23);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 517);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboFormaPago);
            this.Controls.Add(this.comboTipoFact);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.textBoxBusqueda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DetalleDataGridView);
            this.Controls.Add(this.FacturasDataGridView);
            this.Name = "Facturas";
            this.Text = "Facturas";
            this.Load += new System.EventHandler(this.Facturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseUltimaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURA_DETALLEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalleDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseUltimaDataSet baseUltimaDataSet;
        private System.Windows.Forms.BindingSource fACTURASBindingSource;
        private BaseUltimaDataSetTableAdapters.FACTURASTableAdapter fACTURASTableAdapter;
        private BaseUltimaDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView FacturasDataGridView;
        private BaseUltimaDataSetTableAdapters.FACTURA_DETALLETableAdapter fACTURA_DETALLETableAdapter;
        private System.Windows.Forms.BindingSource fACTURA_DETALLEBindingSource;
        private System.Windows.Forms.DataGridView DetalleDataGridView;
        private System.Windows.Forms.Label Buscar;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTipoFact;
        private System.Windows.Forms.ComboBox comboFormaPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpiar;
    }
}