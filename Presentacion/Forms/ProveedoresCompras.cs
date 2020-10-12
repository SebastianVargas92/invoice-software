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

namespace Presentacion.Forms
{
    public partial class ProveedoresCompras : Form
    {

        private readonly ProveedorModelo Proveedor = new ProveedorModelo();
        public string id = "";
        private bool editar = false;
        public ProveedoresCompras()
        {
            InitializeComponent();
            ListarProveedores();
        }

        public void ListarProveedores()
        {
            var totalProveedoress = Proveedor.GetAll();

            MostrarProveedores(totalProveedoress);

        }

        public void MostrarProveedores(List<ProveedorModelo> totalProveedores)
        {

            String[,] articleGrid = new String[totalProveedores.Count(), 10];

            int cont = 0;

            do
            {
                foreach (ProveedorModelo item in totalProveedores)
                {

                    articleGrid[cont, 0] = item.Id.ToString();
                    articleGrid[cont, 1] = item.RazonSocial.ToString();
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
            } while (cont < totalProveedores.Count());

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


                dataGridView1.Columns[1].Name = "Razón Social";
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            {
                editar = true;

                AddProveedor frm = new AddProveedor(dataGridView1, editar); //Instanciamos el Form que abriremos

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

                    ListarProveedores();

                }
                else
                    MessageBox.Show("Seleccione una fila para editar");
            }
        }
    

        private void btnNuevoArt_Click(object sender, EventArgs e)
        {
            AddProveedor frm = new AddProveedor(dataGridView1, editar);
            frm.ShowDialog();
            dataGridView1.Rows.Clear();
            ListarProveedores();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {
                id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una celda");
            }
        }

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            var proveedoresLista = (List<ProveedorModelo>)Proveedor.FindById(textBoxBusqueda.Text);

            dataGridView1.Rows.Clear();
            MostrarProveedores(proveedoresLista);
        }
    }
}
