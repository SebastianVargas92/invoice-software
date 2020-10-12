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
    public partial class AddMarca : Form
    {
        private MarcaModelo marca = new MarcaModelo();
        public AddMarca()
        {
            InitializeComponent();
        }

        private void FormMarca_Load(object sender, EventArgs e)
        {
            ListarMarcas();
        }

        public void ListarMarcas()
        {
            dataGridView1.DataSource = marca.GetAll();
            dataGridView1.Columns[0].Visible = false;//Oculto Columna Id

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                marca.State = EntityState.Agregado;

                marca.Nombre = txtTexto.Text;

                bool valid = new Helps.ValidacionDeDatos(marca).Validar();
                if (valid == true)
                {
                    string resultado = marca.GuardarCambios();
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

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
    }

