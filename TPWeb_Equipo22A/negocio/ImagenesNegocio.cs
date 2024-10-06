using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ImagenesNegocio
    {
        public List<Imagenes> listar()
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, IDARTICULO, IMAGENURL FROM IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagenes ima = new Imagenes();
                    ima.Id = (int)datos.Lector["ID"];
                    ima.IdArticulo = (int)datos.Lector["IDARTICULO"];
                    ima.ImagenUrl = (string)datos.Lector["IMAGENURL"];
                    lista.Add(ima);
                }
                return lista;
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
