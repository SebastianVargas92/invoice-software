using Dominio.Modelos;
using Dominio.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FormArticulo : Form
    {
        private string idProducto = null;
        private bool editar = false;
        private ArticuloModelo articulo = new ArticuloModelo();
        private GrupoModelo grupo = new GrupoModelo();
        public FormArticulo(bool editar)
        {
            InitializeComponent();
            this.editar = editar;
            //this.idProducto = id;
        }

        private void FormArticulo_Load(object sender, EventArgs e)
        {
            ListaGrupos();
        }

        private void ListaGrupos()
        {
            try
            {
                List<GrupoModelo> groupList = grupo.GetAll();

                foreach (GrupoModelo item in groupList)
                {
                    comboGrupos.Items.Add(item.Id + " - " + item.Nombre);
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (editar == false)
            {
                try
                {
                    articulo.State = EntityState.Agregado;

                   
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Marc = Convert.ToInt32(txtMarca.Text);
                    //articulo.Grup = Convert.ToInt32(txtGrupo.Text);
                    articulo.Prov = Convert.ToInt32(txtProveedor.Text);
                    articulo.Costo = Convert.ToDouble(txtCosto.Text);
                    articulo.Precio = Convert.ToDouble(txtPrecio.Text);
                    articulo.Lista2 = Convert.ToDouble(txtL2.Text);
                    articulo.Lista3 = Convert.ToDouble(txtL3.Text);
                    articulo.Iva = Convert.ToInt32(txtIva.Text);
                    articulo.PuntoDePedido = Convert.ToInt32(txtPunto.Text);
                    articulo.Stock = Convert.ToInt32(txtStock.Text);

                    bool valid = new Helps.ValidacionDeDatos(articulo).Validar();
                    if (valid == true)
                    {
                        string resultado = articulo.GuardarCambios();
                        MessageBox.Show(resultado);

                        limpiarForm();
                        
                        this.Close();

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
                    articulo.State = EntityState.Modificado;

                    articulo.Id = Convert.ToInt32(txtId.Text);
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Marc = Convert.ToInt32(txtMarca.Text);
                    //articulo.Grup = Convert.ToInt32(txtGrupo.Text);
                    articulo.Prov = Convert.ToInt32(txtProveedor.Text);
                    articulo.Costo = Convert.ToDouble(txtCosto.Text);
                    articulo.Precio = Convert.ToDouble(txtPrecio.Text);
                    articulo.Lista2 = Convert.ToDouble(txtL2.Text);
                    articulo.Lista3 = Convert.ToDouble(txtL3.Text);
                    articulo.Iva = Convert.ToInt32(txtIva.Text);
                    articulo.PuntoDePedido = Convert.ToInt32(txtPunto.Text);
                    articulo.Stock = Convert.ToInt32(txtStock.Text);

                    bool valid = new Helps.ValidacionDeDatos(articulo).Validar();
                    if (valid == true)
                    {
                        string resultado = articulo.GuardarCambios();
                        MessageBox.Show(resultado);

                        limpiarForm();

                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar por: " + ex);
                }

            }


            }
        private void limpiarForm()
        {
            
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtCosto.Clear();
            txtPrecio.Clear();
            txtL2.Clear();
            txtL3.Clear();
            txtIva.Clear();
            txtPunto.Clear();
            txtStock.Clear();
            comboGrupos.SelectedIndex=0;
            txtMarca.Clear();
            txtProveedor.Clear();
            

        }
    }
}
