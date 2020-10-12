using Dominio.Modelos;
using Dominio.Objetos;
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
    public partial class Clientes : Form
    {
        private bool editar = false;
        private readonly ClienteModelo Cliente = new ClienteModelo();
        private readonly ResponsabilidadModelo Responsabilidad = new ResponsabilidadModelo();
        private readonly DomicilioModelo Domicilio = new DomicilioModelo();


        public Clientes()
        {
            InitializeComponent();
            Cliente.Domicilio = Domicilio;
            
            Cliente.Responsabilidad = Responsabilidad;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }
        public void MostrarClientes(List<ClienteModelo> totalClientes)
        {
            String[,] articleGrid = new String[totalClientes.Count(), 10];

            int cont = 0;

            do
            {
                foreach (ClienteModelo item in totalClientes)
                {

                    articleGrid[cont, 0] = item.Id.ToString();
                    articleGrid[cont, 1] = item.Nombre.ToString();
                    articleGrid[cont, 2] = item.Cuit.ToString();
                    articleGrid[cont, 3] = item.Domicilio.calle.ToString();
                    articleGrid[cont, 4] = item.Domicilio.localidad.Nombre.ToString();
                    articleGrid[cont, 5] = item.Domicilio.localidad.Provincia.Nombre.ToString();
                    articleGrid[cont, 6] = item.Responsabilidad.Nombre.ToString();
                    articleGrid[cont, 7] = item.Telefono.ToString();
                    articleGrid[cont, 8] = item.Email.ToString();
                    articleGrid[cont, 9] = item.Contacto.ToString();


                    cont++;
                }
            } while (cont < totalClientes.Count());

            try
            {

                dataGridView1.ColumnCount = 10;
                int filas = articleGrid.GetLength(0);
                int columnas = articleGrid.GetLength(1);

                this.dataGridView1.ColumnCount = columnas;

                for (int i = 0; i < filas; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridView1);

                    for (int c = 0; c < columnas; c++)
                    {
                        row.Cells[c].Value = articleGrid[i, c];
                    }

                    this.dataGridView1.Rows.Add(row);
                }

                //dataGridView1.Columns[1].DefaultCellStyle.Alignment =
                //   DataGridViewContentAlignment.MiddleCenter;


                dataGridView1.Columns[1].Name = "Nombre";
                dataGridView1.Columns[2].Name = "Cuit";
                dataGridView1.Columns[3].Name = "Direccion";
                dataGridView1.Columns[4].Name = "Localidad";
                dataGridView1.Columns[5].Name = "Provincia";
                dataGridView1.Columns[6].Name = "Resp.Iva";
                dataGridView1.Columns[7].Name = "Telefono";
                dataGridView1.Columns[8].Name = "Email";
                dataGridView1.Columns[9].Name = "Contacto";




                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;//Oculto Columna Id
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AllowUserToResizeRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ListarClientes()

        {
            dataGridView1.Rows.Clear();           

            var totalClientes = Cliente.GetAll();

            MostrarClientes(totalClientes);
           

        }
        private void TextBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = cliente.FindById(textBoxBusqueda.Text);

            var clientesLista = (List<ClienteModelo>) Cliente.FindById(textBoxBusqueda.Text);

            dataGridView1.Rows.Clear();
            MostrarClientes(clientesLista);
        }
        private void Cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnNuevoArt_Click_1(object sender, EventArgs e)
        {
            editar = false;
            AddCliente frm = new AddCliente(dataGridView1, editar);

            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            ListarClientes();
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            {
                editar = true;

                AddCliente frm = new AddCliente(dataGridView1, editar); //Instanciamos el Form que abriremos

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    frm.txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    frm.txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    frm.txtCuit.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    frm.txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbLocalidad.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbProvincia.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    frm.cmbRespIva.SelectedValue = dataGridView1.CurrentRow.Cells[6].Value.ToString();                    
                    frm.txtTelefono.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    frm.txtEmail.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    frm.txtContacto.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                    frm.ShowDialog();  //Mostramos el Form que deseamos abrir.  

                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    ListarClientes();

                }
                else
                    MessageBox.Show("Seleccione una fila para editar");
            }
        }
        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seguro que desea borrar el artículo?", "Eliminar Artículo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Cliente.State = EntityState.Borrado;
                    Cliente.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string resultado = Cliente.GuardarCambios();
                    MessageBox.Show(resultado);
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    ListarClientes();
                }

            }
            else
                MessageBox.Show("Seleccione una fila para borrar");
        }
    }
}

