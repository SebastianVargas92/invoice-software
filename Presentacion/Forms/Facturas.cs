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
    public partial class Facturas : Form
    {

        ClienteModelo Cliente = new ClienteModelo();
        UsuarioModelo Usuario = new UsuarioModelo();
        TipoFacturaModelo TipoFactura = new TipoFacturaModelo();
        FormaDePagoModelo FormaPago = new FormaDePagoModelo();
        FacturaDetalleModelo Detalle = new FacturaDetalleModelo();

        FacturaModelo Factura = new FacturaModelo();
        List<FacturaModelo> FacturasList;
        int id = 1;


        public Facturas()
        {
            InitializeComponent();
            Factura.Cliente = Cliente;
            Factura.Usuario = Usuario;
            Factura.TipoFactura = TipoFactura;
            Factura.FormaDePago = FormaPago;
            Detalle.Factura = Factura;
        }

        private void fACTURASBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

        }

        private void Facturas_Load(object sender, EventArgs e)
        {

            Carga();

        }

        private void Carga()
        {
            id = 1;
            FacturasList = Factura.GetAll();
            ListarFacturas();
            FacturasDataGridView.Rows[0].Selected = true;
            MostrarDetalles(id);
        }

        private void ListarFacturas()
        {
            FacturasList = FacturasList.OrderByDescending(x => x.Id).ToList();

            MostrarFacturas(FacturasList);
        }

        private void MostrarFacturas(List<FacturaModelo> totalFacturas)
        {
            String[,] facturaGrid = new String[totalFacturas.Count(), 12];

            int cont = 0;

            do
            {
                foreach (FacturaModelo item in totalFacturas)
                {

                    facturaGrid[cont, 0] = item.Id.ToString();
                    facturaGrid[cont, 1] = item.Numero.ToString();
                    facturaGrid[cont, 2] = item.TipoFactura.Tipo.ToString();
                    facturaGrid[cont, 3] = item.Fecha.ToString();
                    facturaGrid[cont, 4] = item.Cliente.Nombre.ToString();
                    facturaGrid[cont, 5] = item.Usuario.Nombre.ToString();
                    facturaGrid[cont, 6] = item.Neto.ToString();
                    facturaGrid[cont, 7] = item.Iva.ToString();
                    facturaGrid[cont, 8] = item.Total.ToString();
                    facturaGrid[cont, 9] = item.Descuento.ToString();
                    facturaGrid[cont, 10] = item.FormaDePago.Tipo.ToString();
                    if (item.Cancelada)
                    {
                        facturaGrid[cont, 11] = "Sí";
                    }
                    else
                    {
                        facturaGrid[cont, 11] = "No";
                    }

                    cont++;
                }

            } while (cont < totalFacturas.Count());

            try
            {
                //FacturasDataGridView.ColumnCount = 13;
                int filas = facturaGrid.GetLength(0);
                int columnas = facturaGrid.GetLength(1);

                this.FacturasDataGridView.ColumnCount = columnas;

                for (int i = 0; i < filas; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.FacturasDataGridView);

                    for (int c = 0; c < columnas; c++)
                    {
                        row.Cells[c].Value = facturaGrid[i, c];
                    }

                    this.FacturasDataGridView.Rows.Add(row);
                }


                FacturasDataGridView.Columns[0].HeaderText = "Fac. Id";
                FacturasDataGridView.Columns[0].Visible = false;
                FacturasDataGridView.Columns[1].HeaderText = "Número";
                FacturasDataGridView.Columns[2].HeaderText = "Tipo Factura";
                FacturasDataGridView.Columns[3].HeaderText = "Fecha";
                FacturasDataGridView.Columns[4].HeaderText = "Cliente";
                FacturasDataGridView.Columns[5].HeaderText = "Usuario";
                FacturasDataGridView.Columns[6].HeaderText = "Neto";
                FacturasDataGridView.Columns[7].HeaderText = "Iva";
                FacturasDataGridView.Columns[8].HeaderText = "Total";
                FacturasDataGridView.Columns[9].HeaderText = "Descuento";
                FacturasDataGridView.Columns[10].HeaderText = "Forma de Pago";
                FacturasDataGridView.Columns[11].HeaderText = "Cancelada";




                FacturasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



                FacturasDataGridView.AllowUserToResizeColumns = true;
                FacturasDataGridView.AllowUserToResizeRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        /*
        private void ListarDetalles()
        {
            //var ListaDetalles = Detalle.GetAll();

           
            MostrarDetalles(id);
            

        }
        */
        private void MostrarDetalles(int id)
        {


            var Fact = Factura.GetFacturaById(FacturasList, id);



            //this.DetalleDataGridView = new DataGridView();

            String[,] detalleGrid = new String[Fact.DetallesFactura.Count(), 6];



            int cont = 0;

            do
            {
                foreach (FacturaDetalleModelo item in Fact.DetallesFactura)
                {

                    detalleGrid[cont, 0] = item.Id.ToString();
                    detalleGrid[cont, 1] = item.Factura.Numero.ToString();
                    detalleGrid[cont, 2] = item.Articulo.Descripcion;
                    detalleGrid[cont, 3] = item.PrecioVenta.ToString();
                    detalleGrid[cont, 4] = item.Cantidad.ToString();
                    detalleGrid[cont, 5] = item.SubTotal.ToString();

                    cont++;
                }

            } while (cont < Fact.DetallesFactura.Count());




            try
            {

                int filas = detalleGrid.GetLength(0);
                int columnas = detalleGrid.GetLength(1);

                this.DetalleDataGridView.ColumnCount = columnas;

                for (int i = 0; i < filas; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DetalleDataGridView);

                    for (int c = 0; c < columnas; c++)
                    {
                        row.Cells[c].Value = detalleGrid[i, c];
                    }

                    this.DetalleDataGridView.Rows.Add(row);
                }

                DetalleDataGridView.Columns[0].HeaderText = "Id";
                DetalleDataGridView.Columns[1].HeaderText = "Número Factura";
                DetalleDataGridView.Columns[2].HeaderText = "Artículo";
                DetalleDataGridView.Columns[3].HeaderText = "Precio Venta";
                DetalleDataGridView.Columns[4].HeaderText = "Cantidad";
                DetalleDataGridView.Columns[5].HeaderText = "Subtotal";
                DetalleDataGridView.Columns[0].Visible = false;


                DetalleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



                DetalleDataGridView.AllowUserToResizeColumns = true;
                DetalleDataGridView.AllowUserToResizeRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }



        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacturasDataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
            DetalleDataGridView.Rows.Clear();

            if (FacturasDataGridView.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(FacturasDataGridView.CurrentRow.Cells[0].Value.ToString());
                MostrarDetalles(id);
            }
        }


        private void Filtros()
        {
            var list = FacturasList;

            if (!textBoxBusqueda.Text.Trim().Equals(""))
            {
                list = FacturasList.Where(x => x.Numero.ToString().Contains(textBoxBusqueda.Text)
                                                    || x.Cliente.Nombre.ToUpper().Contains(textBoxBusqueda.Text.ToUpper())).ToList();
            }

            if (comboTipoFact.SelectedIndex > 0)
            {
                list = list.Where(x => x.TipoFactura.Tipo.ToString().Equals(comboTipoFact.SelectedItem)).ToList();
            }

            if (comboFormaPago.SelectedIndex > 0)
            {
                list = list.Where(x => x.FormaDePago.Tipo.ToString().ToUpper().Equals(comboFormaPago.SelectedItem.ToString().ToUpper())).ToList();
            }

            DateTime inicio = DateTime.Parse(dateDesde.Text);
            DateTime fin = DateTime.Parse(dateHasta.Text);
            //DateTime today = DateTime.Now;

            if (inicio != fin)
            {                
                    list = list.Where(a => a.Fecha >= inicio && a.Fecha <= fin).ToList();                                    
            }
            

            if (textBoxBusqueda.Text.Trim().Equals("")
                && comboTipoFact.SelectedIndex == 0 && comboFormaPago.SelectedIndex == 0
                && inicio == fin)
            {
                list = FacturasList;
            }



            list = list.OrderByDescending(x => x.Id).ToList();

            FacturasDataGridView.Rows.Clear();
            MostrarFacturas(list);

            DetalleDataGridView.Rows.Clear();

            if (FacturasDataGridView.SelectedRows.Count > 0)
            {

                id = Convert.ToInt32(FacturasDataGridView.CurrentRow.Cells[0].Value.ToString());
                MostrarDetalles(id);
            }


        }
        private void TextBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            //FacturasList = (List<FacturaModelo>) Factura.FindById(textBoxBusqueda.Text);            

            Filtros();


        }

        private void ComboTipoFact_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtros();
        }

        private void ComboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtros();
        }

        private void DateDesde_ValueChanged(object sender, EventArgs e)
        {
            Filtros();
        }

        private void DateHasta_ValueChanged(object sender, EventArgs e)
        {
            Filtros();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxBusqueda.Text = "";
            comboTipoFact.SelectedIndex = 0;
            comboFormaPago.SelectedIndex = 0;
            dateDesde.Value = DateTime.Today;
            dateHasta.Value = DateTime.Today;
            FacturasDataGridView.Rows.Clear();
            DetalleDataGridView.Rows.Clear();
            Carga();
        }
    }
}
