using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eComerce
{
    public partial class mostrar : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();
        SqlDataReader reader;
        string query = "";
        //--------------------------------------------------
        SqlCommand comando2 = new SqlCommand();
        SqlDataReader reader2;
        //---------------------------------------------------
        public static int idActual = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string idRes = Request.QueryString["idProducto"];
            idActual = Convert.ToInt32(idRes);
        }

        public void mostrarProducto()
        {
            busqueda bs = new busqueda();
            Response.Write(bs.mostrarPorId(idActual));
        }

        //sql desde aqui -------------------------------------
        public void mostrarComentarios()
        {
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            query = "select * from comentarios where id_producto = "+idActual;
            comando.CommandText = query;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                comando2.Connection = conexion.usaConexion();
                query = "select * from usuario where rut = '" + (string)reader["rut_usuario"]+"'";
                comando2.CommandText = query;
                reader2 = comando2.ExecuteReader();
                if (reader2.HasRows)
                {
                    reader2.Read();
                    Response.Write("<div class=comentarioMostrar><b>" + (string)reader2["nombre"] + " " +(string)reader2["apellido"] + ": </b>" + (string)reader["texto"] + "</div>");
                    reader2.Close();
                }
            }
            conexion.cierraConexion();
        }

        protected void btnComentar_Click(object sender, EventArgs e)
        {
            string rut = (string)Session["rutActual"];
            string texto = Request.Form["txtComentar"];
            if (!texto.Trim().Equals(""))
            {
                conexion.abreConexion();
                comando.Connection = conexion.usaConexion();
                string query = "insert into comentarios (id_producto, texto, rut_usuario) values (" + idActual + ", '" + texto + "', '" + rut + "')";
                comando.CommandText = query;
                if (comando.ExecuteNonQuery() > 0)
                    Response.Write("Exito al comentar");
                else
                    Response.Write("Error al comentar");
                conexion.cierraConexion();
            }
            else
                Response.Write("Escriba un comentario");
        }

        protected void btnAgregarCarro_Click(object sender, EventArgs e)
        {

        }

        /*public void ImprimirMancoGG ()
        {
            //llama a la lista a este metodo primero
            List lista = lista venida desde el espacio con un "select * from universo";
            //imprime la forma que tendrá el table galactico
            Response.Write("<table>");
            Response.Write("<tr>");

            Response.Write("<td>Dato Interplanetario</td>");
            Response.Write("<td>Dato Galactico</td>");
            Response.Write("<td>Dato Universal</td>");

            Response.Write("/<tr>");

            Response.Write("<tr>");

            //imprime los datos de la galaxia
            foreach(dato in lista)
            {
                Response.Write("<td>");
                Response.Write(dato.interplanetario);
                Response.Write(dato.galactico);
                Response.Write(dato.universal);
                Response.Write("/<td>");
            }
            Response.Write("</tr>");
            Response.Write("</table>");

            //llora
        }*/
    }
}
