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
    public partial class AddGrupo : Form
    {
        private GrupoModelo grupo = new GrupoModelo();
        public AddGrupo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                grupo.State = EntityState.Agregado;

                grupo.Nombre = txtTexto.Text;

                bool valid = new Helps.ValidacionDeDatos(grupo).Validar();
                if (valid == true)
                {
                    string resultado = grupo.GuardarCambios();
                    MessageBox.Show(resultado);

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar por: " + ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
