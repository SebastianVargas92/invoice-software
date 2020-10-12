using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Modelos;
using Dominio.Objetos;

namespace Presentacion.Forms
{
    public partial class AddIva : Form

    {
        private IvaModelo iva = new IvaModelo();
        public AddIva()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                iva.State = EntityState.Agregado;

                iva.Valor = Convert.ToDouble(txtTexto.Text);

                bool valid = new Helps.ValidacionDeDatos(iva).Validar();
                if (valid == true)
                {
                    string resultado = iva.GuardarCambios();
                    MessageBox.Show(resultado);

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar por: " + ex);
            }
        }
    }
}
