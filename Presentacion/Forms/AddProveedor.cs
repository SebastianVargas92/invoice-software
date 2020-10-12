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
    public partial class AddProveedor : Form
    {
        private readonly bool editar;
        private readonly ResponsabilidadModelo responsabilidad = new ResponsabilidadModelo();
        private readonly DomicilioModelo domicilio = new DomicilioModelo();
        private readonly LocalidadModelo localidad = new LocalidadModelo();
        private readonly ProvinciaModelo provincia = new ProvinciaModelo();
        private readonly ProveedorModelo proveedor = new ProveedorModelo();
        readonly DataGridView data;

        public AddProveedor(DataGridView dataView, bool editar)
        {
            InitializeComponent();
            this.data = dataView;
            this.editar = editar;

            proveedor.Responsabilidad = responsabilidad;
            
        }

        private int GetDomicilioId()
        {
            List<DomicilioModelo> listaDomicilios = domicilio.GetAll();
            var domi = 0;
            var proveedores = proveedor.GetAll();
            

            if (editar == false)
            {
                domi = listaDomicilios.Last().id + 1;
            }
            else
            {
                var idProvDomi = Convert.ToInt32(txtId.Text);
                foreach (var item in proveedores)
                {
                    if (item.Id == idProvDomi)
                        domi = item.Domicilio.id;
                }
            }



            return domi;
        }

        private bool AddDomicilio()
        {
            bool flag = false;


            try
            {

                if (editar == false)
                {
                    domicilio.State = EntityState.Agregado;

                }
                else if (editar == true)
                {
                    domicilio.State = EntityState.Modificado;
                }

                localidad.Id = Convert.ToInt32(cmbLocalidad.SelectedValue);

                domicilio.id = GetDomicilioId();
                domicilio.calle = txtDireccion.Text;
                domicilio.idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
                domicilio.localidad = localidad;


                bool valid = new Helps.ValidacionDeDatos(domicilio).Validar();
                if (valid == true)
                {
                    string resultado = domicilio.GuardarCambios();
                    MessageBox.Show(resultado);
                    flag = true;

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar Domicilio por: " + ex);
                flag = false;
            }


            return flag;

        }

            private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //INSERTAR

            bool flag = true;

            try
                {

                if (editar == false)
                {
                    proveedor.State = EntityState.Agregado;

                }
                else
                {
                    proveedor.State = EntityState.Modificado;
                    proveedor.Id = Convert.ToInt32(txtId.Text);

                }


                    proveedor.RazonSocial = txtNombre.Text;                    
                    proveedor.Cuit = txtCuit.Text;                                                            
                    proveedor.Telefono = txtTelefono.Text;
                    proveedor.Email = txtEmail.Text;
                    proveedor.Contacto = txtContacto.Text;

                domicilio.id = GetDomicilioId();
                domicilio.calle = txtDireccion.Text;
                domicilio.idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
                localidad.IdProv = Convert.ToInt32(cmbProvincia.SelectedValue);
                responsabilidad.Id = Convert.ToInt32(cmbRespIva.SelectedValue);

                domicilio.localidad = localidad;
                proveedor.Domicilio = domicilio;
                proveedor.Responsabilidad = responsabilidad;



                bool valid = new Helps.ValidacionDeDatos(proveedor).Validar();
                bool cuitValido = proveedor.CuitValidator(proveedor.Cuit);
                if (valid == true && cuitValido == true)
                    {
                    flag = AddDomicilio();
                    if (flag)
                    {
                        string resultado = proveedor.GuardarCambios();
                        MessageBox.Show(resultado);

                        this.Close();
                    }

                }
            }

            catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar por: " + ex);
                }
            }
            //EDITAR
            /*
            if (editar == true)
            {

                try
                {

                    proveedor.State = EntityState.Modificado;

                    proveedor.Id = Convert.ToInt32(txtId.Text);
                    proveedor.RazonSocial = txtNombre.Text;
                    proveedor.Domicilio.calle = txtDireccion.Text;
                    proveedor.Cuit = txtCuit.Text;
                    proveedor.Domicilio.idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
                    proveedor.Domicilio.localidad.IdProv = Convert.ToInt32(cmbProvincia.SelectedValue);
                    proveedor.Responsabilidad.Id = Convert.ToInt32(cmbRespIva.SelectedValue);
                    proveedor.Telefono = txtTelefono.Text;
                    proveedor.Email = txtEmail.Text;
                    proveedor.Contacto = txtContacto.Text;

                    bool valid = new Helps.ValidacionDeDatos(proveedor).Validar();
                    if (valid == true)
                    {
                        string resultado = proveedor.GuardarCambios();
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
        */
        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtCuit.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
            txtEmail.Clear();
            
        }

        private void AddProveedor_Load(object sender, EventArgs e)
        {
            ListarLocalidades();
            ListarProvincias();
            ListarResponsabilidad();
        }
        private void ListarResponsabilidad()
        {
            

            cmbRespIva.DataSource = responsabilidad.GetAll();
            cmbRespIva.DisplayMember = "nombre";
            cmbRespIva.ValueMember = "id";

            if (editar == true)
            {
                string respCombo = data.CurrentRow.Cells[6].Value.ToString();

                cmbRespIva.SelectedValue = GetComboValue(cmbRespIva, respCombo);
            }
        }
        private void ListarProvincias()
        {
            //MarcaModelo objMarca = new MarcaModelo();

            cmbProvincia.DataSource = provincia.GetAll();
            cmbProvincia.DisplayMember = "nombre";
            cmbProvincia.ValueMember = "id";

            if (editar == true)
            {
                string provinciaCombo = data.CurrentRow.Cells[5].Value.ToString();

                cmbProvincia.SelectedValue = GetComboValue(cmbProvincia, provinciaCombo);
            }
        }
        private void ListarLocalidades()
        {
            //MarcaModelo objMarca = new MarcaModelo();

            cmbLocalidad.DataSource = localidad.GetAll();
            cmbLocalidad.DisplayMember = "nombre";
            cmbLocalidad.ValueMember = "id";

            if (editar == true)
            {
                string localidadCombo = data.CurrentRow.Cells[4].Value.ToString();

                cmbLocalidad.SelectedValue = GetComboValue(cmbLocalidad, localidadCombo);
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

        private void TxtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
