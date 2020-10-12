using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaComun.Cache;
using Dominio.Modelos;
using Dominio.Objetos;

namespace Presentacion.Forms
{
    public partial class Compras : Form
    {
        private readonly ProveedorModelo Proveedor = new ProveedorModelo();
        private readonly DomicilioModelo Domicilio = new DomicilioModelo();
        private readonly FormaDePagoModelo FormaPago = new FormaDePagoModelo();
        private readonly TipoFacturaModelo TipoFactura = new TipoFacturaModelo();
        private readonly ComprasModelo Compra = new ComprasModelo();
        private readonly UsuarioModelo Usuario = new UsuarioModelo();
        private readonly ArticuloModelo Articulo = new ArticuloModelo();
        private readonly CompraDetalleModelo CompraDetalle = new CompraDetalleModelo();
        private readonly List<CompraDetalleModelo> DetallesList = new List<CompraDetalleModelo>();
        public bool changed = false;
        double subtotal = 0;
        double subtotalIva = 0;
        double total = 0;
        readonly DataGridView data;
        private readonly bool editar;


        public Compras()
        {
            InitializeComponent();
            Usuario.Id = UserLoginCache.IdUser;
            Proveedor.Domicilio = Domicilio;
            Compra.Proveedor = Proveedor;
            Compra.FormaDePago = FormaPago;
            Compra.TipoFactura = TipoFactura;
            Compra.Usuario = Usuario;
            CompraDetalle.Compra = Compra;
            CompraDetalle.Articulo = Articulo;
        }

     

        private void FormCompras_Load(object sender, EventArgs e)
        {
            var ListaArticulos = Articulo.GetAll();
            var ListaProveedores = Proveedor.GetAll();
            var ListaCompras = Compra.GetAll();
            ListarFormaDePago();
            ListarTipoFactura();


            LimpiarForm();
            changed = false;
        }

        public void LimpiarForm()
        {
            //SetArticulo(txtCodigo.Text);
            //SetProveedor(txtRazonSocial.Text);

            dataGridView1.Rows.Clear();
            txtRazonSocial.Text = "Seleccione PROVEEDOR";
            txtDireccion.Text = "";
            txtCuit.Text = " ";
            txtRespIva.Text = "";
            txtCantidad.Text = "0";
            txtPrecioTotal.Text ="0";
            txtCodigo.Text = "";
            txtDescripcion.Text = CompraDetalle.Articulo.Descripcion;
            //  txtPreciounitario.Text = CompraDetalle.Articulo.Precio.ToString();
            txtPuntoDeVenta.Text = "";
            txtNumFactura.Text = "";
            
            labelSubtotal.Text = "0.00";
            labIva.Text = "0.00";
            labTotal.Text = "0.00";



            //labelSubtotal.Text = Convert.ToString(FacturaDetalle.Articulo.Precio);
        }
        public void LimpiarArt()
        {
           
            txtCantidad.Text = "1";
            txtPreciounitario.Text = "0";
            txtPrecioTotal.Text = "0";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            

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

        private void ListarTipoFactura()
        {
            cbxTipoFactura.DataSource = TipoFactura.GetAll();
            cbxTipoFactura.DisplayMember = "tipo";
            cbxTipoFactura.ValueMember = "id";

            if (editar == true)
            {
                string formaCombo = data.CurrentRow.Cells[4].Value.ToString();

                cbxFormaDePago.SelectedValue = GetComboValue(cbxTipoFactura, formaCombo);
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


        private void BtnAddArticulo_Click_1(object sender, EventArgs e)
        {

            try
            {

                CompraDetalleModelo det = new CompraDetalleModelo();

                det.Compra = CompraDetalle.Compra;
                det.PrecioVenta = Convert.ToDouble(txtPreciounitario.Text);
                det.Cantidad = Convert.ToDouble(txtCantidad.Text);
                det.SubTotal = det.Cantidad * det.PrecioVenta;
                det.Articulo = CompraDetalle.Articulo;
                    
                DetallesList.Add(det);
                MostrarDetalles(det);
                //txtCantidad.Text = "1";
                //txtCodigo.Text = "1";
                //txtPrecioTotal.Text = "0.00";
                LimpiarArt();


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar por: " + ex);
            }
        }

     
        private double SubtotalCalculo()
        {
            subtotal = 0;

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {

                if (this.dataGridView1.Rows[i].Cells[5].Value != null)
                    subtotal += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[6].Value.ToString());
            }

            labelSubtotal.Text = subtotal.ToString();
            return subtotal;
        }
        private double TotalCalculo()
        {
            total = 0;

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {

                if (this.dataGridView1.Rows[i].Cells[7].Value != null)
                    total += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[7].Value.ToString());
            }

            labTotal.Text = total.ToString();
            return total;
        }
        private double SubtotalIVA()
        {
            subtotalIva = 0;

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {

                if (this.dataGridView1.Rows[i].Cells[5].Value != null)
                    subtotalIva += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[5].Value.ToString());
            }

            labIva.Text = subtotalIva.ToString();
            return subtotalIva;
        }

        private void MostrarDetalles(CompraDetalleModelo detalle)
        {

            String[] articleGrid = new String[7];


            articleGrid[0] = detalle.Articulo.Codigo;
            articleGrid[1] = detalle.Articulo.Descripcion;
            articleGrid[2] = detalle.PrecioVenta.ToString();
            articleGrid[3] = detalle.Cantidad.ToString();
            articleGrid[4] = (detalle.Cantidad * ((detalle.PrecioVenta * (1 + (detalle.Articulo.IvaEntity.Valor / 100))) - detalle.PrecioVenta)).ToString();
            articleGrid[5] = (detalle.Cantidad * detalle.PrecioVenta).ToString();
            articleGrid[6] = (detalle.Cantidad * (detalle.PrecioVenta * (1 + (detalle.Articulo.IvaEntity.Valor / 100)))).ToString();
            


            try
            {

                int columnas = articleGrid.Length;

                this.dataGridView1.ColumnCount = columnas + 1;

                int rowIndex = this.dataGridView1.Rows.Add();


                var row = this.dataGridView1.Rows[rowIndex];


                for (int c = 0; c < columnas; c++)
                {
                    row.Cells[c + 1].Value = articleGrid[c];
                }

                SubtotalCalculo();
                SubtotalIVA();
                TotalCalculo();

                dataGridView1.Columns[1].Name = "Código artículo";
                dataGridView1.Columns[2].Name = "Descripción artículo";
                dataGridView1.Columns[3].Name = "Precio Compra";
                dataGridView1.Columns[4].Name = "Cantidad";
                dataGridView1.Columns[5].Name = "Iva";
                dataGridView1.Columns[6].Name = "Subtotal Neto";
                dataGridView1.Columns[7].Name = "Subtotal";


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
   
        private void TxtCantidad_Leave(object sender, EventArgs e)

        {

            txtPrecioTotal.Text = (Convert.ToDouble(txtPreciounitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {

            if (changed)
            {
                bool flag = SetArticulo(txtDescripcion.Text);
                if (flag)
                {
                    //txtDescripcion.Text = FacturaDetalle.Articulo.Descripcion;
                    txtCantidad.Text = "1";
                    txtCodigo.Text = CompraDetalle.Articulo.Codigo;
                    //txtPreciounitario.Text = CompraDetalle.Articulo.Precio.ToString();
                    //var total = CompraDetalle.Articulo.Precio * Convert.ToDouble(txtCantidad.Text);
                    //txtPrecioTotal.Text = total.ToString();
                   
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
                txtDescripcion.Text = CompraDetalle.Articulo.Descripcion;
                //var total = Convert.ToInt32(txtPreciounitario.Text) * Convert.ToInt32(txtCantidad.Text);
                //txtPrecioTotal.Text = total.ToString();
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

        private void btnListaArt_Click_1(object sender, EventArgs e)
        {
            ArticulosFacturacion artFact = new ArticulosFacturacion();

            artFact.ShowDialog();  //Mostramos el Form que deseamos abrir            

            Articulo.GetAll();

            bool flag = SetArticulo(artFact.id);
            if (flag)
            {
                txtCantidad.Text = "1";
                txtCodigo.Text = CompraDetalle.Articulo.Codigo;
                txtDescripcion.Text = CompraDetalle.Articulo.Descripcion;
                //var total = Convert.ToDouble(txtPreciounitario.Text) * Convert.ToDouble(txtCantidad.Text);
                //txtPrecioTotal.Text = total.ToString();

            }
        }

        private bool SetArticulo(string codArt)

        {

            var Art = Articulo.FindArticulo(codArt);
            if (Art != null)
            {
                CompraDetalle.Articulo = Art;
                return true;
            }
            else
            {
                MessageBox.Show("No se encontró el artículo");
                return false;
            }

        }

        private void btnEliminarArt_Click_1(object sender, EventArgs e)
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



        // ********************************** Proveedor ***************************
        private void btnListaClientes_Click_1(object sender, EventArgs e)
        {
            ProveedoresCompras proveFact = new ProveedoresCompras();

            proveFact.ShowDialog();
            Proveedor.GetAll();

            bool flag = SetProveedor(proveFact.id);
            if (flag)
            {
                txtRazonSocial.Text = Compra.Proveedor.RazonSocial;
                txtDireccion.Text = Compra.Proveedor.Domicilio.calle;
                txtRespIva.Text = Compra.Proveedor.Responsabilidad.Nombre.ToString();
                txtCuit.Text = Compra.Proveedor.Cuit;

            }

        }
        private bool SetProveedor(string codCli)

        {

            var Prov = Proveedor.FindProveedor(codCli);
            if (Prov != null)
            {
                Compra.Proveedor = Prov;
                return true;

            }
            else
            {
                MessageBox.Show("No se encontró el Proveedor");
                return false;
            }
        }

        private void TxtRazonSocial_Leave(object sender, EventArgs e)
        {

                bool flag = SetProveedor(txtRazonSocial.Text);

                if (flag)
                {
                    txtRazonSocial.Text = Compra.Proveedor.RazonSocial;
                    txtCuit.Text = Compra.Proveedor.Cuit;
                    txtDireccion.Text = Compra.Proveedor.Domicilio.calle;
                    txtRespIva.Text = Compra.Proveedor.Responsabilidad.Nombre;
              
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
                totalIva += (item.Articulo.IvaEntity.Valor / 100) * neto;
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

            var fac = new ComprasModelo();
            var lista = fac.GetAll();

            fac = Compra.LastCompra(lista);

            Compra.Id = ++fac.Id;
            if(txtPuntoDeVenta.Text == null)
            {
                MessageBox.Show("Debe ingresar Punto de Venta");
            }
            else
            {
                Compra.PuntoDeVenta = Convert.ToInt32(txtPuntoDeVenta.Text);
            }
            if(txtNumFactura.Text == null)
            {
                MessageBox.Show("Debe ingresar Numero de factura");
            }
            else
            {
                Compra.Numero = Convert.ToInt32(txtNumFactura.Text);
            }

            

            Compra.Fecha = txtFecha.Value;

            Compra.Iva = SubtotalIVA();
            Compra.Neto = SubtotalCalculo();
            Compra.Total = TotalCalculo();
            Compra.Descuento = 0;
            Compra.TipoFactura.Id = Convert.ToInt32(cbxTipoFactura.SelectedValue);
            Compra.FormaDePago.Id = Convert.ToInt32(cbxFormaDePago.SelectedValue);
            Compra.Usuario.Id = Usuario.Id;
            Compra.Cancelada = false;


        }

        private bool AddFactura()
        {
            bool flag = false;

            SetFactura();

            try
            {
                bool valid = new Helps.ValidacionDeDatos(Compra).Validar();
                if (valid == true)
                {

                    Compra.State = EntityState.Agregado;
                    string resultado = Compra.GuardarCambios();

                    // MessageBox.Show(resultado);

                   
                    flag = true;
                    LimpiarForm();
                    LimpiarArt();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear la factura por: " + ex);
                flag = false;
            }
            return flag;
        }

        private void btnFacturar_Click_1(object sender, EventArgs e)
        {

            if (DetallesList.Count != 0)
            {
                bool newFactura = AddFactura();

                try
                {
                    if (newFactura)
                    {


                        string resultado = "";
                        foreach (var item in DetallesList)
                        {
                            item.Compra = Compra;
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
                MessageBox.Show("No se puede ingresar Compra con precio 0.00");
            }
        }

        
    }

}
