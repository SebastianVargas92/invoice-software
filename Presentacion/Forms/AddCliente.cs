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
    public partial class AddCliente : Form
    {
        private readonly bool editar;
        private readonly ResponsabilidadModelo responsabilidad = new ResponsabilidadModelo();
        private readonly DomicilioModelo Domicilio = new DomicilioModelo();
        private readonly LocalidadModelo localidad = new LocalidadModelo();
        private readonly ProvinciaModelo provincia = new ProvinciaModelo();
        private readonly ClienteModelo cliente = new ClienteModelo();
        readonly DataGridView data;

        public AddCliente(DataGridView dataView, bool editar)
        {
            InitializeComponent();
            this.data = dataView;
            this.editar = editar;

            cliente.Responsabilidad = responsabilidad;
            
        }
        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtCuit.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
            txtEmail.Clear();

        }
        private void AddCliente_Load(object sender, EventArgs e)
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

        private int GetDomicilioId()
        {
            List<DomicilioModelo> listaDomicilios = Domicilio.GetAll();
            var domi = 0;
            var clientes = cliente.GetAll();
            

            if (editar == false)
            {
                domi = listaDomicilios.Last().id + 1;
            } else
            {
                var idClienteDomi = Convert.ToInt32(txtId.Text);
                foreach (var item in clientes)
                {
                    if (item.Id == idClienteDomi)
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
                    Domicilio.State = EntityState.Agregado;

                }
                else if (editar == true)
                {
                    Domicilio.State = EntityState.Modificado;
                }                

            localidad.Id = Convert.ToInt32(cmbLocalidad.SelectedValue);

            Domicilio.id = GetDomicilioId();
            Domicilio.calle = txtDireccion.Text;
            Domicilio.idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
            Domicilio.localidad = localidad;
                

                bool valid = new Helps.ValidacionDeDatos(Domicilio).Validar();
            if (valid == true)
            {
                string resultado = Domicilio.GuardarCambios();
                MessageBox.Show(resultado);
                    flag = true;

                this.Close();
            }

        } catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo agregar Domicilio por: " + ex);
                        flag = false;
                    }
            

            return flag;
}
        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
           
                bool flag = true;

                //INSERTAR
                
                        try
                    {
                if (editar == false)
                {
                    cliente.State = EntityState.Agregado;
                }
                else
                {
                    cliente.State = EntityState.Modificado;
                    cliente.Id = Convert.ToInt32(txtId.Text);
                }

                    
                        
                        cliente.Nombre = txtNombre.Text;
                        cliente.Cuit = txtCuit.Text;
                        cliente.Telefono = txtTelefono.Text;
                        cliente.Email = txtEmail.Text;
                        cliente.Contacto = txtContacto.Text;

                        Domicilio.id = GetDomicilioId();
                        Domicilio.calle = txtDireccion.Text;                        
                        Domicilio.idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
                        localidad.IdProv = Convert.ToInt32(cmbProvincia.SelectedValue);
                        responsabilidad.Id = Convert.ToInt32(cmbRespIva.SelectedValue);

                        Domicilio.localidad = localidad;
                        cliente.Domicilio = Domicilio;
                        cliente.Responsabilidad = responsabilidad;    


                        bool valid = new Helps.ValidacionDeDatos(cliente).Validar();
                        bool cuitValido = cliente.CuitValidator(cliente.Cuit);
                        if (valid == true && cuitValido == true)
                        {
                            flag = AddDomicilio();
                            if (flag)
                            {
                                string resultado = cliente.GuardarCambios();
                            MessageBox.Show(resultado);

                            this.Close();
                            //limpiarForm();

                        }
                        }                       
                    }
                        catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo agregar por: " + ex);
                    }
                }
        
        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
