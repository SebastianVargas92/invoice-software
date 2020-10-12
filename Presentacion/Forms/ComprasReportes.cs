using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class ComprasReportes : Form
    {
        public ComprasReportes()
        {
            InitializeComponent();
        }

        private void cOMPRASBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cOMPRASBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.baseUltimaDataSet);

        }

        private void ComprasReportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'baseUltimaDataSet.COMPRA_DETALLE' Puede moverla o quitarla según sea necesario.
            //this.cOMPRA_DETALLETableAdapter.Fill(this.baseUltimaDataSet.COMPRA_DETALLE);
            // TODO: esta línea de código carga datos en la tabla 'baseUltimaDataSet.COMPRAS' Puede moverla o quitarla según sea necesario.
           // this.cOMPRASTableAdapter.Fill(this.baseUltimaDataSet.COMPRAS);

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
