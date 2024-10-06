using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
    {

        public Voucher ObtenerVoucherPorCodigo(string codigoVoucher)
        {
            Voucher voucher = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigoVoucher");
                datos.setearParametro("@codigoVoucher", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    voucher = new Voucher
                    {
                        CodigoVoucher = (string)datos.Lector["CodigoVoucher"],
                        IdCliente = datos.Lector["IdCliente"] != DBNull.Value ? (int)datos.Lector["IdCliente"] : (int?)null,
                        FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? ((DateTime)datos.Lector["FechaCanje"]).Date : (DateTime?)null,
                        IdArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? (int)datos.Lector["IdArticulo"] : (int?)null
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return voucher;
        }

        
        public void ActualizarVoucher(string codigoVoucher, int idCliente, DateTime fechaCanje, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Vouchers SET IdCliente = @idCliente, FechaCanje = @fechaCanje, IdArticulo = @idArticulo WHERE CodigoVoucher = @codigoVoucher");
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@fechaCanje", fechaCanje);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.setearParametro("@codigoVoucher", codigoVoucher);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}