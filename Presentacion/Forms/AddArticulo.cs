using Dominio.Modelos;
using Dominio.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class AddArticulo : Form
    {

        private bool editar = false;
        private readonly ArticuloModelo Articulo = new ArticuloModelo();
        private readonly IvaModelo Iva = new IvaModelo();
        private readonly MarcaModelo Marca = new MarcaModelo();
        private readonly GrupoModelo Grupo = new GrupoModelo();
        private readonly ProveedorModelo Prove = new ProveedorModelo();
        readonly DataGridView Data;




        public AddArticulo(DataGridView dataView, bool editar)
        {
            InitializeComponent();
            this.editar = editar;
            //this.idProducto = id;
            this.Data = dataView;

            Articulo.Marca = Marca;
            Articulo.Grupo = Grupo;
            Articulo.IvaEntity = Iva;
            Articulo.Proveedor = Prove;

        }

        private void FormArticulo_Load(object sender, EventArgs e)
        {

            ListarGrupos();
            ListarMarcas();
            ListarIvas();
            ListarProveedoress();
            
            if(editar == false)
            {
                txtCosto.Text = "0";
                txtRentabilidad.Text = "0";
                txtPrecio.Text = "0";
                txtL2.Text = "0";
                txtL3.Text = "0";
                txtImpInterno.Text = "0";
                txtPunto.Text = "0";
                txtCantidadM.Text = "0";
                txtStock.Text = "0";
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

        //LISTAR COMBOBOX
        private void ListarGrupos()
        {
            //GrupoModelo objGrupo = new GrupoModelo();
            cbxGrupos.DataSource = Grupo.GetAll();
            cbxGrupos.DisplayMember = "nombre";
            cbxGrupos.ValueMember = "id";

            if (editar == true)
            {
                string grupCombo = Data.CurrentRow.Cells[12].Value.ToString();

                cbxGrupos.SelectedValue = GetComboValue(cbxGrupos, grupCombo);
            }
        }
        private void ListarMarcas()
        {
            //MarcaModelo objMarca = new MarcaModelo();

            cbxMarca.DataSource = Marca.GetAll();
            cbxMarca.DisplayMember = "nombre";
            cbxMarca.ValueMember = "id";

            if (editar == true)
            {
                string marcaCombo = Data.CurrentRow.Cells[13].Value.ToString();

                cbxMarca.SelectedValue = GetComboValue(cbxMarca, marcaCombo);
            }
        }
        private void ListarIvas()
        {
            //IvaModelo objIva = new IvaModelo();

            cbxIva.DataSource = Iva.GetAll();
            cbxIva.DisplayMember = "valor";
            cbxIva.ValueMember = "id";

            if (editar == true)
            {
                string ivaCombo = Data.CurrentRow.Cells[8].Value.ToString();

                cbxIva.SelectedValue = GetComboValue(cbxIva, ivaCombo);
            }
        }
        private void ListarProveedoress()
        {
            

            cbxProveedor.DataSource = Prove.GetAll();
            cbxProveedor.DisplayMember = "razonSocial";
            cbxProveedor.ValueMember = "id";

            if (editar == true)
            {
                string proveCombo = Data.CurrentRow.Cells[14].Value.ToString();


                cbxProveedor.SelectedValue = GetComboValue(cbxProveedor, proveCombo);
            }
        }
        private void CalcularRentabilidad()
        {
            try 
            {
                var costo = Convert.ToDouble(txtCosto.Text);
                var rentabilidad = Convert.ToDouble(txtRentabilidad.Text);
                var precio = (costo * rentabilidad / 100) + costo;
                txtPrecio.Text = precio.ToString();

            }catch(Exception ex)
            {
                MessageBox.Show("Error en " + ex);
            }

        }
        private void CalcularRentabilidadXPrecio()
        {
            try
            {

                var costo = Convert.ToDouble(txtCosto.Text);
                var precio = Convert.ToDouble(txtPrecio.Text);
                var rentabilidad = ((precio - costo) * 100)/costo;
                txtRentabilidad.Text = rentabilidad.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en " + ex);
            }

        }
       
        //BOTONES PRINCIPALES
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (editar == false)
            {
                try
                {
                    Articulo.State = EntityState.Agregado;

                    Articulo.Codigo = txtCodigo.Text;
                    Articulo.Descripcion = txtDescripcion.Text;
                    Articulo.Costo = Convert.ToDouble(txtCosto.Text);
                    Articulo.Rentabilidad = Convert.ToDouble(txtRentabilidad.Text);
                    Articulo.Precio = Convert.ToDouble(txtPrecio.Text);
                    Articulo.Lista2 = Convert.ToDouble(txtL2.Text);
                    Articulo.Lista3 = Convert.ToDouble(txtL3.Text);
                    Articulo.IvaEntity.Id = Convert.ToInt32(cbxIva.SelectedValue);
                    Articulo.PuntoDePedido = Convert.ToInt32(txtPunto.Text);
                    Articulo.CantMax = Convert.ToDouble(txtCantidadM.Text);
                    Articulo.Stock = Convert.ToInt32(txtStock.Text);
                    Articulo.Marca.Id = Convert.ToInt32(cbxMarca.SelectedValue);
                    Articulo.Grupo.Id = Convert.ToInt32(cbxGrupos.SelectedValue);
                    Articulo.Proveedor.Id = Convert.ToInt32(cbxProveedor.SelectedValue);
                    Articulo.UltimaModificacion = Convert.ToDateTime(System.DateTime.UtcNow);
                    Articulo.ImpInterno = Convert.ToDouble(txtImpInterno.Text);

                    bool valid = new Helps.ValidacionDeDatos(Articulo).Validar();
                    if (valid == true)
                    {
                        string resultado = Articulo.GuardarCambios();
                        MessageBox.Show(resultado);

                        
                        LimpiarForm();
                        

                        //this.Close();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar por: " + ex);
                }
            }
            //EDITAR
            if (editar == true)
            {

                try
                {

                    Articulo.State = EntityState.Modificado;

                    Articulo.Id = Convert.ToInt32(txtId.Text);
                    Articulo.Codigo = txtCodigo.Text;
                    Articulo.Descripcion = txtDescripcion.Text;
                    Articulo.Costo = Convert.ToDouble(txtCosto.Text);
                    Articulo.Rentabilidad = Convert.ToDouble(txtRentabilidad.Text);
                    Articulo.Precio = Convert.ToDouble(txtPrecio.Text);
                    Articulo.Lista2 = Convert.ToDouble(txtL2.Text);
                    Articulo.Lista3 = Convert.ToDouble(txtL3.Text);
                    Articulo.IvaEntity.Id = Convert.ToInt32(cbxIva.SelectedValue);
                    Articulo.PuntoDePedido = Convert.ToInt32(txtPunto.Text);
                    Articulo.CantMax = Convert.ToDouble(txtCantidadM.Text);
                    Articulo.Stock = Convert.ToInt32(txtStock.Text);
                    Articulo.Marca.Id = Convert.ToInt32(cbxMarca.SelectedValue);
                    Articulo.Grupo.Id = Convert.ToInt32(cbxGrupos.SelectedValue);
                    Articulo.Proveedor.Id = Convert.ToInt32(cbxProveedor.SelectedValue);
                    Articulo.UltimaModificacion = Convert.ToDateTime(System.DateTime.UtcNow);
                    Articulo.ImpInterno = Convert.ToDouble(txtImpInterno.Text);

                    bool valid = new Helps.ValidacionDeDatos(Articulo).Validar();
                    if (valid == true)
                    {
                        string resultado = Articulo.GuardarCambios();
                        MessageBox.Show(resultado);

                        LimpiarForm();

                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar por: " + ex);
                }

            }


        }


        //BOTONOES AGREGAR MARCA; GRUPO; IVA Y PROVEEDORES
        private void BtnMarca_Click(object sender, EventArgs e)
        {

            AddMarca frm = new AddMarca();

            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.
            ListarMarcas();

        }

        private void BtnAgGrupo_Click(object sender, EventArgs e)
        {
            AddGrupo frm = new AddGrupo();

            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.
            ListarGrupos();
        }

        private void AgregarIva_Click(object sender, EventArgs e)
        {
            AddIva frm = new AddIva();

            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.
            ListarIvas();
        }

        private void BtnAddProveedor_Click(object sender, EventArgs e)
        {
            editar = false;

            AddProveedor frm = new AddProveedor(Data , editar) ;
            frm.ShowDialog();  //Mostramos el Form que deseamos abrir.
            ListarProveedoress();
        }

        private void AutoNum_Button_Click(object sender, EventArgs e)
        {
            var articulosLista = Articulo.GetAll();
            var codigosLista = new List<int>();

            foreach (ArticuloModelo item in articulosLista)
            {

                if (item.Codigo.All(char.IsDigit))
                {
                    codigosLista.Add(Convert.ToInt32(item.Codigo));
                }


            }
            int maximumNumber = codigosLista.Max();

            int i = 1;

            bool flag = true;

            do
            {

                for (int j = 0; j < codigosLista.Count(); j++)
                {
                    {
                        if (i != codigosLista[j])
                        {
                            txtCodigo.Text = i.ToString();
                            flag = false;
                            break;
                        }
                        else if (i == maximumNumber)
                        {
                            var num = ++maximumNumber;
                            txtCodigo.Text = num.ToString();
                            flag = false;
                            break;

                        }
                    }
                    i++;
                }
            } while (flag);

        }

        private void LimpiarForm()
        {
            txtId.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            //txtCosto.Clear();
            //txtRentabilidad.Clear();
            //txtPrecio.Clear();
            txtL2.Clear();
            txtL3.Clear();
            txtPunto.Clear();
            txtCantidadM.Clear();
            txtStock.Clear();
            txtImpInterno.Clear();

            txtCosto.Text = "0";
            txtRentabilidad.Text = "0";
            txtPrecio.Text = "0";
            txtL2.Text = "0";
            txtL3.Text = "0";
            txtPunto.Text = "0";
            txtCantidadM.Text = "0";
            txtStock.Text = "0";
            txtImpInterno.Text = "0";

        }

       
        private void TxtRentabilidad_Leave(object sender, EventArgs e)
        {
            CalcularRentabilidad();
        }

       
        private void TxtCosto_Leave(object sender, EventArgs e)
        {
            CalcularRentabilidad();
        }

        private void TxtPrecio_Leave(object sender, EventArgs e)
        {
            CalcularRentabilidadXPrecio();
        }
    }
}
