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
    public partial class Proveedores : Form
    {
        private bool editar = false;
        private readonly ProveedorModelo proveedor = new ProveedorModelo();
        private readonly ResponsabilidadModelo responsabilidad = new ResponsabilidadModelo();
        private readonly DomicilioModelo domicilio = new DomicilioModelo();


        public Proveedores()
        {
            InitializeComponent();
            proveedor.Domicilio = domicilio;
            
            proveedor.Responsabilidad = responsabilidad;
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            ListarProveedores();
        }
        public void MostrarProve(List<ProveedorModelo> totalProveedoress)
        {

            String[,] articleGrid = new String[totalProveedoress.Count(), 10];

            int cont = 0;

            do
            {
                foreach (ProveedorModelo item in totalProveedoress)
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
            } while (cont < totalProveedoress.Count());

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
        public void ListarProveedores()

        {
            dataGridView1.Rows.Clear();
           // dataGridView1.DataSource = proveedor.GetAll();

            var totalProveedoress = proveedor.GetAll();

            MostrarProve(totalProveedoress);



        }
        private void BtnNuevoArt_Click(object sender, EventArgs e)
        {
            editar = false;
            AddProveedor frm = new AddProveedor(dataGridView1, editar);

            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            ListarProveedores();
        }
        private void TextBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = proveedor.FindById(textBoxBusqueda.Text);

            var proveedoresLista = (List<ProveedorModelo>)proveedor.FindById(textBoxBusqueda.Text);

            dataGridView1.Rows.Clear();
            MostrarProve(proveedoresLista);

        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seguro que desea borrar el artículo?", "Eliminar Artículo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    proveedor.State = EntityState.Borrado;
                    proveedor.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string resultado = proveedor.GuardarCambios();
                    MessageBox.Show(resultado);
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    ListarProveedores();
                }

            }
            else
                MessageBox.Show("Seleccione una fila para borrar");
        }
        private void BtnEditar_Click_1(object sender, EventArgs e)
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
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void Buscar_Click(object sender, EventArgs e)
        {

        }
    }
}

