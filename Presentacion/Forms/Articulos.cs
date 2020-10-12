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
    public partial class Articulos : Form
    {
        private readonly ArticuloModelo Articulo = new ArticuloModelo();

        private readonly IvaModelo Iva = new IvaModelo();
        private readonly MarcaModelo Marca = new MarcaModelo();
        private readonly GrupoModelo Grupo = new GrupoModelo();
        private readonly ProveedorModelo Prove = new ProveedorModelo();

        private bool editar = false;
       

        public Articulos()
        {
            InitializeComponent();
            Articulo.Marca = Marca;
            Articulo.Grupo = Grupo;
            Articulo.IvaEntity = Iva;
            Articulo.Proveedor = Prove;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
             ListaArticulos();
           

        }


       
        public void ListaArticulos()
        {
            var totalArticulos = Articulo.GetAll();

            MostrarArts(totalArticulos);

        }

        public void MostrarArts(List<ArticuloModelo> totalArticulos)
        {

            String[,] articleGrid = new String[totalArticulos.Count(), 17];

            int cont = 0;

            do
            {
                foreach (ArticuloModelo item in totalArticulos)
                {

                    articleGrid[cont, 0] = item.Id.ToString();
                    articleGrid[cont, 1] = item.Codigo.ToString();
                    articleGrid[cont, 2] = item.Descripcion.ToString();
                    articleGrid[cont, 3] = item.Costo.ToString();
                    articleGrid[cont, 4] = item.Rentabilidad.ToString();
                    articleGrid[cont, 5] = item.Precio.ToString();
                    articleGrid[cont, 6] = item.Lista2.ToString();
                    articleGrid[cont, 7] = item.Lista3.ToString();
                    articleGrid[cont, 8] = item.IvaEntity.Valor.ToString();
                    articleGrid[cont, 9] = item.PuntoDePedido.ToString();
                    articleGrid[cont, 10] = item.CantMax.ToString();
                    articleGrid[cont, 11] = item.Stock.ToString();
                    articleGrid[cont, 12] = item.Grupo.Nombre.ToString();
                    articleGrid[cont, 13] = item.Marca.Nombre.ToString();
                    articleGrid[cont, 14] = item.Proveedor.RazonSocial.ToString();
                    articleGrid[cont, 15] = item.ImpInterno.ToString();
                    articleGrid[cont, 16] = item.UltimaModificacion.ToString();

                    cont++;
                }
            } while (cont < totalArticulos.Count());

            try
            {

                dataGridView1.ColumnCount = 17;
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


                //dataGridView1.Rows[0].Cells[0].Value = articleGrid[0, 0].ToString();


                dataGridView1.Columns[1].Name = "Código";
                dataGridView1.Columns[2].Name = "Descripcion";
                dataGridView1.Columns[3].Name = "Costo";
                dataGridView1.Columns[4].Name = "Rentabilidad";
                dataGridView1.Columns[5].Name = "Precio";
                dataGridView1.Columns[6].Name = "Lista 2";
                dataGridView1.Columns[7].Name = "Lista 3";
                dataGridView1.Columns[8].Name = "Iva";
                dataGridView1.Columns[9].Name = "Punto pedido";
                dataGridView1.Columns[10].Name = "Cant. max";
                dataGridView1.Columns[11].Name = "Stock";
                dataGridView1.Columns[12].Name = "Grupo";
                dataGridView1.Columns[13].Name = "Marca";
                dataGridView1.Columns[14].Name = "Proveedor";
                dataGridView1.Columns[15].Name = "Imp Interno";
                dataGridView1.Columns[16].Name = "Última Modificación";



                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;//Oculto Columna Id
                dataGridView1.Columns[3].Visible = false;//Oculto Columna Costo
                dataGridView1.Columns[4].Visible = false;//Oculto Columna Rentabilidad
                dataGridView1.Columns[6].Visible = false;//Oculto Columna Lista 2
                dataGridView1.Columns[7].Visible = false;//Oculto Columna Lista 3
                dataGridView1.Columns[9].Visible = false;//Oculto Columna punto Pedido
                dataGridView1.Columns[10].Visible = false;//Oculto Columna cantidad Maxima
                dataGridView1.Columns[15].Visible = false;// Oculto Columna Imp Interno

                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AllowUserToResizeRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //BUSQUEDA
        private void TextBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = articulo.FindById(textBoxBusqueda.Text);
            var articulosLista = (List<ArticuloModelo>)Articulo.FindById(textBoxBusqueda.Text);

            dataGridView1.Rows.Clear();
            MostrarArts(articulosLista);



        }


        /*
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editar = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                

                AddArticulo frm = new AddArticulo(dataGridView1, editar); //Instanciamos el Form que abriremos


                frm.txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.txtCosto.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frm.txtRentabilidad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm.txtPrecio.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                frm.txtL2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                frm.txtL3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                frm.cbxIva.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                frm.txtPunto.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                frm.txtStock.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                frm.cbxGrupos.SelectedValue = 2;
                frm.cbxMarca.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                frm.cbxProveedor.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();


                frm.ShowDialog();  //Mostramos el Form que deseamos abrir.  

                
                //ListaArticulos();
            }
            else
                MessageBox.Show("Seleccione una fila para editar");
        }
    */

        private void BtnNuevoArt_Click(object sender, EventArgs e)
        {
            editar = false;
            AddArticulo frm = new AddArticulo(dataGridView1, editar);
            
            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.
            
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            ListaArticulos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            
            editar = true;

            AddArticulo frm = new AddArticulo(dataGridView1, editar); //Instanciamos el Form que abriremos

            if (dataGridView1.SelectedRows.Count > 0)
            {
            frm.txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtCosto.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.txtRentabilidad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.txtPrecio.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm.txtL2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm.txtL3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frm.cbxIva.SelectedValue = Articulo.IvaEntity.Id;
            frm.txtPunto.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            frm.txtCantidadM.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            frm.txtStock.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            frm.cbxGrupos.SelectedValue = Articulo.Grupo.Id;
            frm.cbxMarca.SelectedValue = Articulo.Marca.Id;
            frm.cbxProveedor.SelectedValue = Articulo.Proveedor.Id;
            frm.txtImpInterno.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();



            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.  

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                 ListaArticulos();

            } else
                MessageBox.Show("Seleccione una fila para editar");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seguro que desea borrar el artículo?", "Eliminar Artículo", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Articulo.State = EntityState.Borrado;
                    Articulo.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string resultado = Articulo.GuardarCambios();
                    MessageBox.Show(resultado);
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    ListaArticulos();
                }
                
            }
            else
                MessageBox.Show("Seleccione una fila para borrar");
        }

        private void BtnMarcas_Click(object sender, EventArgs e)
        {
            AddMarca frm = new AddMarca();

            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.
            
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            //ExportarAExcel(dataGridView1);
        }
        //public void ExportarAExcel(DataGridView tabla)
        //{
        //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        //   // Workbook workbook = excelApplicationObject.Workbooks.Open(path, CorruptLoad: true);
        //    excel.Application.Workbooks.Add(true);

        //    int IndiceColumna = 0;

        //    foreach(DataGridViewColumn col in tabla.Columns)
        //    {
        //        IndiceColumna++;
        //        excel.Cells[1, IndiceColumna] = col.Name;
        //    }
        //    int IndiceFila = 0;
        //    foreach(DataGridViewRow row in tabla.Rows)
        //    {
        //        IndiceFila++;
        //        IndiceColumna = 0;
        //        foreach(DataGridViewColumn col in tabla.Columns)
        //        {
        //            IndiceColumna++;
        //            excel.Cells[IndiceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
        //        }
        //    }
        //    excel.Visible = true;
        //}
    }
}

