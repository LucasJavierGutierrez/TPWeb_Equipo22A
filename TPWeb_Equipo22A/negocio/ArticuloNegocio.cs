using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=PROMOS_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                //  comando.CommandText = "SELECT A.Id,A.CODIGO, A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,A.ImagenUrl, A.Precio, A.IdCategoria, A.IdMarca FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria";
                comando.CommandText = "SELECT A.Id,A.CODIGO, A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,I.ImagenUrl, A.Precio, A.IdCategoria, A.IdMarca FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    int articuloId = (int)lector["Id"];

                   
                    Articulo art = lista.FirstOrDefault(x => x.Id == articuloId);

                    if (art == null)
                    {
                    
                        art = new Articulo();
                        art.Imagenes = new List<Imagenes>();

                        art.Id = articuloId;
                        if (!(lector["CODIGO"] is DBNull))
                            art.Codigo = (string)lector["CODIGO"];
                        if (!(lector["NOMBRE"] is DBNull))
                            art.Nombre = (string)lector["NOMBRE"];
                        if (!(lector["Descripcion"] is DBNull))
                            art.Descripcion = (string)lector["Descripcion"];
                        if (!(lector["Precio"] is DBNull))
                            art.Precio = (decimal)lector["Precio"];

                        art.Marca = new Marca
                        {
                            Id = (int)lector["IdMarca"],
                            NombreMarca = (string)lector["Marca"]
                        };

                        art.Categoria = new Categoria
                        {
                            Id = (int)lector["IdCategoria"]
                        };
                        if (!(lector["TIPO"] is DBNull))
                            art.Categoria.Tipo = (string)lector["TIPO"];

                       
                        lista.Add(art);
                    }

                    if (!(lector["ImagenUrl"] is DBNull))
                    {
                        Imagenes imagen = new Imagenes
                        {
                            Id = articuloId, 
                            ImagenUrl = (string)lector["ImagenUrl"],
                            IdArticulo = art.Id
                        };
                        art.Imagenes.Add(imagen);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

    



    /* public List<Articulo> filtrar(string campo, string criterio, string filtro)
     {
         List<Articulo> lista = new List<Articulo>();
         AccesoDatos datos = new AccesoDatos();
         try
         {
             string consulta = "SELECT A.Id,A.CODIGO,A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,I.ImagenUrl,A.Precio,A.IdCategoria,A.IdMarca FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id WHERE ";
             switch (campo)
             {
                 case "Nombre":
                     switch (criterio)
                     {
                         case "Comienza con":
                             consulta += "A.NOMBRE LIKE '" + filtro + "%'  ";
                             break;
                         case "Termina con":
                             consulta += "A.NOMBRE LIKE '%" + filtro + "'  ";
                             break;
                         case "Contiene":
                             consulta += "A.NOMBRE LIKE '%" + filtro + "%'  ";
                             break;
                     }
                     break;
                 case "Marca":
                     switch (criterio)
                     {
                         case "Comienza con":
                             consulta += "M.Descripcion LIKE '" + filtro + "%'  ";
                             break;
                         case "Termina con":
                             consulta += "M.Descripcion LIKE '%" + filtro + "'  ";
                             break;
                         case "Contiene":
                             consulta += "M.Descripcion LIKE '%" + filtro + "%'  ";
                             break;
                     }
                     break;
                 case "Categoria":
                     switch (criterio)
                     {
                         case "Comienza con":
                             consulta += "C.Descripcion LIKE '" + filtro + "%'  ";
                             break;
                         case "Termina con":
                             consulta += "C.Descripcion LIKE '%" + filtro + "'  ";
                             break;
                         case "Contiene":
                             consulta += "C.Descripcion LIKE '%" + filtro + "%'  ";
                             break;
                     }
                     break;
                 case "Precio":
                     switch (criterio)
                     {
                         case "Mayor a":
                             consulta += "A.Precio > " + filtro;
                             break;
                         case "Menor a":
                             consulta += "A.Precio < " + filtro;
                             break;
                         case "Igual a":
                             consulta += "A.Precio = " + filtro;
                             break;
                         default:
                             break;
                     }
                     break;
             }
             datos.setearConsulta(consulta);
             datos.ejecutarLectura();

             while (datos.Lector.Read())
             {
                 Articulo art = new Articulo();
                 art.Id = (int)datos.Lector["Id"];
                 if (!(datos.Lector["CODIGO"] is DBNull))
                     art.Codigo = (string)datos.Lector["CODIGO"];
                 if (!(datos.Lector["NOMBRE"] is DBNull))
                     art.Nombre = (string)datos.Lector["NOMBRE"];
                 if (!(datos.Lector["Descripcion"] is DBNull))
                     art.Descripcion = (string)datos.Lector["Descripcion"];

                 if (!(datos.Lector["Precio"] is DBNull))
                     art.Precio = (decimal)datos.Lector["Precio"];


                 art.Imagenes = new Imagenes();
                 art.Imagenes.Id = (int)datos.Lector["IdImagenes"];
                 art.Imagenes.IdArticulo = (int)datos.Lector["IdArticulo"];
                 art.Imagenes.ImagenUrl = (string)datos.Lector["ImagenUrl"];



                 art.Marca = new Marca();
                 art.Marca.Id = (int)datos.Lector["IdMarca"];
                 art.Marca.NombreMarca = (string)datos.Lector["Marca"];


                 art.Categoria = new Categoria();
                 art.Categoria.Id = (int)datos.Lector["IdCategoria"];


                 if (!(datos.Lector["TIPO"] is DBNull))
                     art.Categoria.Tipo = (string)datos.Lector["TIPO"];



                 lista.Add(art);
             }

             return lista;

         }
         catch (Exception ex)
         {

             throw ex;
         }

     }
    */
}
    }
