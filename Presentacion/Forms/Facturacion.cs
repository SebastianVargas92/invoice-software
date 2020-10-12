using CapaComun.Cache;
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
    public partial class Facturacion : Form
    {
        private readonly ClienteModelo Cliente = new ClienteModelo();
        private readonly DomicilioModelo Domicilio = new DomicilioModelo();
        private readonly FormaDePagoModelo FormaPago = new FormaDePagoModelo();
        private readonly TipoFacturaModelo TipoFactura = new TipoFacturaModelo();
        private readonly FacturaModelo Factura = new FacturaModelo();
        private readonly UsuarioModelo Usuario = new UsuarioModelo();
        private readonly ArticuloModelo Articulo = new ArticuloModelo();
        private readonly FacturaDetalleModelo FacturaDetalle = new FacturaDetalleModelo();
        private readonly List<FacturaDetalleModelo> DetallesList = new List<FacturaDetalleModelo>();
        public bool changed = false;
        double subtotal = 0;
        readonly DataGridView data;
        private readonly bool editar;

        //
        public Facturacion()
        {
            InitializeComponent();
            Usuario.Id = UserLoginCache.IdUser;
            Cliente.Domicilio = Domicilio;
            Factura.Cliente = Cliente;
            Factura.FormaDePago = FormaPago;
            Factura.TipoFactura = TipoFactura;
            Factura.Usuario = Usuario;
            FacturaDetalle.Factura = Factura;                        
            FacturaDetalle.Articulo = Articulo;
            
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {

            
            var ListaArticulos = Articulo.GetAll();
            var ListaClientes = Cliente.GetAll();
            var ListaFacturas = Factura.GetAll();
            ListarFormaDePago();
           

            LimpiarForm();
            changed = false;


        }
        public void LimpiarForm()
        {
           // SetArticulo(txtCodigo.Text);
            SetCliente(txtRazonSocial.Text);

            dataGridView1.Rows.Clear();
            txtRazonSocial.Text = "Consumidor Final";
            txtDireccion.Text = "Sin Dirección";
            txtCuit.Text = " ";
            txtRespIva.Text = "Consumidor Final";
            txtCantidad.Text = "1";
          // txtPrecioTotal.Text = (Convert.ToInt32(txtCantidad.Text) * FacturaDetalle.Articulo.Precio).ToString();
            txtCodigo.Text = "";
           // txtDescripcion.Text = FacturaDetalle.Articulo.Descripcion;
           // txtPreciounitario.Text = FacturaDetalle.Articulo.Precio.ToString();
            labelSubtotal.Text = "0.00";
            label11.Text = "B";
           
           
            //labelSubtotal.Text = Convert.ToString(FacturaDetalle.Articulo.Precio);
        }
        public void LimpiarArt()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPreciounitario.Text = "";
            txtPrecioTotal.Text = "0.00";
            txtCantidad.Text = "1";
        }

        private void ListarFormaDePago()
        {
            cbxFormaDePago.DataSource = FormaPago.GetAll();
            cbxFormaDePago.DisplayMember = "tipo";
            cbxFormaDePago.ValueMember = "id";

            if (editar == true)
            {
                string formaCombo = data.CurrentRow.Cells[4].Value.ToString();

                cbxFormaDePago.SelectedValue = GetComboValue(cbxFormaDePago, formaCombo);
            }
        }

        private int GetComboValue(ComboBox combo, String valor)
        {
            int index = 0;

            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.GetItemText(combo.Items[i]).Equals(valor))
                {
                    index = ++i;
                    break;
                }
            }
            return index;
        }


        // ********************************** Artículo - Detalle **********************
       
        
        private void BtnAddArticulo_Click(object sender, EventArgs e)
        {
           
            try
            {
                    
                FacturaDetalleModelo det = new FacturaDetalleModelo();

                det.Factura = FacturaDetalle.Factura;
                det.PrecioVenta = Convert.ToDouble(txtPreciounitario.Text);
                det.Cantidad = Convert.ToDouble(txtCantidad.Text);
                det.SubTotal = det.Cantidad * det.PrecioVenta;
                det.Articulo = FacturaDetalle.Articulo;

                    DetallesList.Add(det);                
                    MostrarDetalles(det);
                     LimpiarArt();
                   


            }
            catch (Exception ex)
            {
               MessageBox.Show("No se pudo agregar por: " + ex);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // dataGridView1.DataSource = FacturaDetalle.Ge
        }
        
        private void SubtotalCalculo()
        {
            subtotal = 0;

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {

                if (this.dataGridView1.Rows[i].Cells[3].Value != null)
                    subtotal += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[5].Value.ToString());
            }

            labelSubtotal.Text = subtotal.ToString();
        }

        private void MostrarDetalles(FacturaDetalleModelo detalle)
        {

            String[] articleGrid = new String[5];
                       

                    articleGrid[0] = detalle.Articulo.Codigo;
                    articleGrid[1] = detalle.Articulo.Descripcion;
                    articleGrid[2] = detalle.PrecioVenta.ToString();
                    articleGrid[3] = detalle.Cantidad.ToString();
                    articleGrid[4] = (detalle.Cantidad * detalle.PrecioVenta).ToString();
            

            try
            {
                                
                int columnas = articleGrid.Length;

                this.dataGridView1.ColumnCount = columnas+1;

                int rowIndex = this.dataGridView1.Rows.Add();

                
                var row = this.dataGridView1.Rows[rowIndex];


                    for (int c = 0; c < columnas; c++)
                    {
                        row.Cells[c+1].Value = articleGrid[c];                    
                    }

                SubtotalCalculo();


                dataGridView1.Columns[1].Name = "Código artículo";
                dataGridView1.Columns[2].Name = "Descripción artículo";
                dataGridView1.Columns[3].Name = "Precio";
                dataGridView1.Columns[4].Name = "Cantidad";
                dataGridView1.Columns[5].Name = "Subtotal";


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
                //dataGridView1.Columns[1].Visible = false;//Oculto Columna Fac.id
                //dataGridView1.Columns[2].Visible = false;//Oculto Columna Fac.Num
                //dataGridView1.Columns[3].Visible = false;//Oculto Columna Art.id


                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AllowUserToResizeRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /*
        private void leaveMethod()
        {
            var codArt = txtCodigo.Text;
            var Art = Articulo.FindArticulo(codArt);

            txtDescripcion.Text = Art.Descripcion;
            txtPreciounitario.Text = Art.Precio.ToString();
            var total = Art.Precio * Convert.ToInt32(txtCantidad.Text);
            txtPrecioTotal.Text = total.ToString();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {

            //MessageBox.Show("tab ");

            leaveMethod();

        }
*/
        private void TxtCantidad_Leave(object sender, EventArgs e)

        {

            if(txtPreciounitario.Text != "")
            {
                txtPrecioTotal.Text = (Convert.ToDouble(txtPreciounitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
            }
            
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {            

            if (changed) { 
            bool flag = SetArticulo(txtDescripcion.Text);
            if (flag)
            {
                //txtDescripcion.Text = FacturaDetalle.Articulo.Descripcion;
                txtCodigo.Text = FacturaDetalle.Articulo.Codigo;
                txtPreciounitario.Text = FacturaDetalle.Articulo.Precio.ToString();
                var total = FacturaDetalle.Articulo.Precio * Convert.ToDouble(txtCantidad.Text);
                txtPrecioTotal.Text = total.ToString();                    
            }
            else
            {
                txtCodigo.Text = "1";
                LimpiarForm();
            }
        }
            changed = false;
        }
      
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            bool flag = SetArticulo(txtCodigo.Text);
            if (flag)
            {
                txtDescripcion.Text = FacturaDetalle.Articulo.Descripcion;
                txtPreciounitario.Text = FacturaDetalle.Articulo.Precio.ToString();
                var total = FacturaDetalle.Articulo.Precio * Convert.ToInt32(txtCantidad.Text);
                txtPrecioTotal.Text = total.ToString();
            }
            else
            {
                txtCodigo.Text = "1";
                LimpiarForm();
            }
            changed = false;

        }
        private void TxtPreciounitario_Leave(object sender, EventArgs e)
        {

            txtPrecioTotal.Text = (Convert.ToDouble(txtPreciounitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
        }

        private void BtnListaArt_Click(object sender, EventArgs e)
        {
            ArticulosFacturacion artFact = new ArticulosFacturacion();

            artFact.ShowDialog();  //Mostramos el Form que deseamos abrir            

            Articulo.GetAll();

            bool flag = SetArticulo(artFact.id);
            if (flag)
            {
                txtCodigo.Text = FacturaDetalle.Articulo.Codigo;
                txtDescripcion.Text = FacturaDetalle.Articulo.Descripcion;
                txtPreciounitario.Text = FacturaDetalle.Articulo.Precio.ToString();
                var total = FacturaDetalle.Articulo.Precio * Convert.ToDouble(txtCantidad.Text);
                txtPrecioTotal.Text = total.ToString();
            }
        }

        private bool SetArticulo(string codArt)

        {
           
                var Art = Articulo.FindArticulo(codArt);
            if (Art != null)
            {
                FacturaDetalle.Articulo = Art;
                return true;
            }
            else
            {
                MessageBox.Show("No se encontró el artículo");
                return false;
            }
           
        }

        private void BtnEliminarArt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int number = dataGridView1.Rows.Count;
                var row = dataGridView1.CurrentCell.RowIndex;
                var celdaCod = dataGridView1.Rows[row].Cells[1].Value.ToString();
                var celdaPrecio = dataGridView1.Rows[row].Cells[3].Value.ToString();
                var celdaCantidad = dataGridView1.Rows[row].Cells[4].Value.ToString();

                foreach (var item in DetallesList)
                {
                    if (item.Articulo.Codigo.Equals(celdaCod) &&
                        (item.PrecioVenta).ToString().Equals(celdaPrecio) &&
                        (item.Cantidad).ToString().Equals(celdaCantidad))
                    {
                        DetallesList.Remove(item);
                        break;
                    }
                }

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    //if (this.dataGridView1.CurrentCell.Value != null) 
                    dataGridView1.Rows.RemoveAt(item.Index);
                }

                SubtotalCalculo();


            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }

        }



        // ********************************** Cliente ***************************
        private void BtnListaClientes_Click(object sender, EventArgs e)
        {
            ClientesFacturacion cliFact = new ClientesFacturacion();

            cliFact.ShowDialog();
            Cliente.GetAll();

            bool flag = SetCliente(cliFact.id);
            if (flag)
            {
                txtRazonSocial.Text = Factura.Cliente.Nombre;
                txtDireccion.Text = Factura.Cliente.Domicilio.calle;
                txtRespIva.Text = Factura.Cliente.Responsabilidad.Nombre.ToString();
                txtCuit.Text = Factura.Cliente.Cuit;
                if (Factura.Cliente.Responsabilidad.Id == 1)
                {
                    label11.Text ="B";
                }
                if (Factura.Cliente.Responsabilidad.Id == 2)
                {
                    label11.Text = "A";
                }

            }

        }
        private bool SetCliente(string codCli)

        {

            var Cli = Cliente.FindCliente(codCli);
            if (Cli != null)
            {
                Factura.Cliente = Cli;
                return true;
               
            }
            else
            {
                MessageBox.Show("No se encontró el cliente");
                return false;
            }
        }

        private void TxtRazonSocial_Leave(object sender, EventArgs e)
        {

            if (!txtRazonSocial.Text.Equals("Consumidor Final")) {
                bool flag = SetCliente(txtRazonSocial.Text);            
            
            if (flag)
            {
                txtRazonSocial.Text = Factura.Cliente.Nombre;
                txtCuit.Text = Factura.Cliente.Cuit;
                txtDireccion.Text = Factura.Cliente.Domicilio.calle;
                txtRespIva.Text = Factura.Cliente.Responsabilidad.Nombre;
                
            }
            else
            {
                
                txtRazonSocial.Text = "Consumidor Final";
                
            }
            }
        }


        //************************ Factura - Botón Facturación *************************

        private double CalculoIva()
        {
            double neto = 0;
            double totalIva = 0;
            foreach (var item in DetallesList)
            {
                neto = (item.PrecioVenta * item.Cantidad) / (1 + (item.Articulo.IvaEntity.Valor / 100));
                totalIva += (item.Articulo.IvaEntity.Valor/100) * neto;
            }

            return totalIva;
        }
        private double CalculoNeto()
        {
            double totalNeto = 0;
            double neto = 0;
            
            foreach (var item in DetallesList)
            {                       
                    neto = (item.PrecioVenta * item.Cantidad) / (1 + (item.Articulo.IvaEntity.Valor / 100));
                    totalNeto += neto;                
            }

            return totalNeto;
        }
        private double CalculoTotalFact()
        {
            double totalFac = 0;
           

            foreach (var item in DetallesList)
            {
                 
                totalFac += item.PrecioVenta * item.Cantidad;
            }

            return totalFac;
        }

        private void SetFactura()
        {

            var fac = new FacturaModelo();
            var lista = fac.GetAll();

            fac = Factura.lastFactura(lista);

            Factura.Id = ++fac.Id;
            Factura.Numero = ++fac.Numero;
            
            Factura.Fecha = DateTime.Now;

            Factura.Iva = CalculoIva();
            Factura.Neto = CalculoNeto();
            Factura.Total = CalculoTotalFact();
            Factura.Descuento = 0;
            Factura.TipoFactura.Id = 1;
            Factura.FormaDePago.Id = Convert.ToInt32(cbxFormaDePago.SelectedValue); ;
            Factura.Usuario.Id = Usuario.Id;
            Factura.Cancelada = false;
           

        }

        private bool AddFactura()
        {
            bool flag = false;

            SetFactura();

            try
            {
                bool valid = new Helps.ValidacionDeDatos(Factura).Validar();
            if (valid == true)
            {

                Factura.State = EntityState.Agregado;
                string resultado = Factura.GuardarCambios();

               // MessageBox.Show(resultado);
               
                    labelNumeroFactura.Text = "0000-" + (++Factura.Numero).ToString();
                    flag = true;
                LimpiarForm();

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear la factura por: " + ex);
                flag = false;
            }
            return flag;
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {

            if(DetallesList.Count != 0)
            {
                bool newFactura = AddFactura();

                try
                {
                    if (newFactura)
                    {


                        string resultado = "";
                        foreach (var item in DetallesList)
                        {
                            item.Factura = Factura;
                            item.State = EntityState.Agregado;
                            
                            resultado = item.GuardarCambios();
                        }
                       // MessageBox.Show(resultado);
                        LimpiarForm();
                        DetallesList.Clear();
                        this.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar por: " + ex);

                }
            }
            else
            {
                MessageBox.Show("No se pueden facturar con precio 0.00");
            }
        }

        
    }

}

    

    

