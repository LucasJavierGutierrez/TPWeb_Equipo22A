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

        public class ClienteNegocio
        {
            private string connectionString = "server=.\\SQLEXPRESS; database=PROMOS_DB; integrated security = true";

            public Cliente BuscarPorDocumento(string documento)
            {
                Cliente cliente = null;
                SqlConnection conexion = new SqlConnection(connectionString);
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;

                try
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "SELECT * FROM Clientes WHERE Documento = @Documento";
                    comando.Parameters.AddWithValue("@Documento", documento);
                    comando.Connection = conexion;

                    conexion.Open();
                    lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        cliente = new Cliente
                        {
                            Id = (int)lector["Id"],                        
                            Nombre = (string)lector["Nombre"],
                            Apellido = (string)lector["Apellido"],
                            Email = (string)lector["Email"],
                            Direccion = (string)lector["Direccion"],
                            Ciudad = (string)lector["Ciudad"],
                            CP = (int)lector["CP"]
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // Manejo de excepciones (puedes agregar logging aquí)
                }
                finally
                {
                    conexion.Close();
                }

                return cliente;
            }

            public int GuardarCliente(Cliente nuevoCliente)
            {
            //   SqlConnection conexion = new SqlConnection(connectionString);
            //   SqlCommand comando = new SqlCommand();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                                     "OUTPUT INSERTED.Id VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @cp)");
                datos.setearParametro("@documento", nuevoCliente.Documento);
                datos.setearParametro("@nombre", nuevoCliente.Nombre);
                datos.setearParametro("@apellido", nuevoCliente.Apellido);
                datos.setearParametro("@email", nuevoCliente.Email);
                datos.setearParametro("@direccion", nuevoCliente.Direccion);
                datos.setearParametro("@ciudad", nuevoCliente.Ciudad);
                datos.setearParametro("@cp", nuevoCliente.CP);


                return datos.ejecutarScalar(); 
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