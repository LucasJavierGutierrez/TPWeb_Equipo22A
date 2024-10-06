using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        public Articulo seleccionado;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["Id"]);

                List<Articulo> listado = (List<Articulo>)Session["listadoProductos"];
                seleccionado = listado.Find(x => x.Id == id);


            }
        }
        protected void txtDocumento_TextChanged(object sender, EventArgs e)
            {
           
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = clienteNegocio.BuscarPorDocumento(txtDocumento.Text.Trim());

                if (cliente != null)
                {
                 
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text = cliente.Direccion;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text = cliente.CP.ToString();
                }
                else
                {
           
                    LimpiarCampos();
                }
            }

            private void LimpiarCampos()
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtCP.Text = "";
            }

            protected void btnGuardar_Click(object sender, EventArgs e)
            {


            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                VoucherNegocio voucherNegocio = new VoucherNegocio();


                string idArticulo = Request.QueryString["id"];
                string voucherId = Request.QueryString["voucherId"];           
                string documento = txtDocumento.Text;

                Cliente clienteExistente = clienteNegocio.BuscarPorDocumento(documento);

                int clienteId;

              
                if (clienteExistente == null)
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        Documento = documento,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Email = txtEmail.Text,
                        Direccion = txtDireccion.Text,
                        Ciudad = txtCiudad.Text,
                        CP = int.Parse(txtCP.Text)
                    };

             //     clienteNegocio.GuardarCliente(nuevoCliente);
                   
                 //   clienteId = nuevoCliente.Id;
                    clienteId = clienteNegocio.GuardarCliente(nuevoCliente);
                   Session["clienteId"] = clienteId;

                }
                else
                {
                    clienteId = clienteExistente.Id; 
                }

                if (Session["clienteId"] != null)
                {
                    clienteId = (int)Session["clienteId"];
                }


                voucherNegocio.ActualizarVoucher(voucherId, clienteId, DateTime.Now, int.Parse(idArticulo));

                Response.Redirect("Exito.aspx");
            }
           
    }
 }

}


