using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Administracion_web
{
    public partial class Promo : System.Web.UI.Page
    {
    ///    public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

         ///   ArticuloNegocio negocio = new ArticuloNegocio();
       ///     ListaArticulos = negocio.listar();
        ///    Session.Add("listadoProductos", ListaArticulos);

        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string voucherCode = txtVoucherCode.Text.Trim();

         
            if (IsVoucherValid(voucherCode))
            {
              
          //      Response.Redirect("Default.aspx"); 
                Response.Redirect("Default.aspx?voucherId=" + voucherCode);
            }
            else
            {

                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "El código del voucher es incorrecto o ya fue utilizado.";
            }
        }


        private bool IsVoucherValid(string voucherCode)
        {
            VoucherNegocio negocio = new VoucherNegocio();
            Voucher voucher = negocio.ObtenerVoucherPorCodigo(voucherCode);

            {


                // Si no existe el voucher
                if (voucher == null)
            {
                return false;
            }

  
            if (voucher.FechaCanje != null)
           {

                return false;
            }

            
            return true;
        }
    }


}
}