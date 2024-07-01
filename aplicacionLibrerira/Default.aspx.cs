using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace aplicacionLibrerira
{
    public partial class _Default : Page
    {
        protected void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = FACUNDO; Initial Catalog=libreria;Integrated Security=true";
            string query = "";
            string searchString = txtData.Value;
            string objetoSeleccionado = slcAutor.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    if (objetoSeleccionado == "Autor")
                    {
                        query = "SELECT Libros.Titulo, Libros.Descripcion, Libros.Anio FROM Libros INNER JOIN Autor1 ON Libros.IDAutor = Autor1.ID WHERE Autor1.Nombre LIKE @NombreAutor";
                        cmd.Parameters.AddWithValue("@NombreAutor", "%" + searchString + "%");
                    }
                    else if (objetoSeleccionado == "Titulo")
                    {
                        query = "SELECT * FROM Libros WHERE Titulo like @Titulo";
                        cmd.Parameters.AddWithValue("@Titulo", "%" + searchString + "%");
                    }
                    else if (objetoSeleccionado == "Anio")
                    {
                            query = "SELECT * FROM Libros WHERE Anio = @Anio";
                            cmd.Parameters.AddWithValue("@Anio", searchString);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    DataTable dt = new DataTable();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    dt.Load(sqlDataReader);
                    gvLibros.DataSource = dt;
                    gvLibros.DataBind();
                }

                catch (Exception ex) 
                {

                    Console.WriteLine("Error" + ex.Message);

                }

                finally
                {
                    conn.Close();
                }
            }

        }

        protected void buttonEliminar_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = FACUNDO; Initial Catalog=libreria; Integrated Security=true";
            string query = "";
            string searchString = txtData.Value;

            if (int.TryParse(searchString, out int libroID))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand delete = new SqlCommand();
                        query = "DELETE FROM Libros WHERE ID = @ID";
                        delete.Parameters.AddWithValue("@ID", libroID);
                        delete.Connection = conn;
                        delete.CommandText = query;

                        int filasModificadas = delete.ExecuteNonQuery();

                        button1_Click(sender, e);
                        Console.WriteLine($"Se eliminaron {filasModificadas} filas.");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al eliminar libro: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al eliminar el libro: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("ID del libro no válido.");
            }
        }
    }
}