using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eComerce
{
    public partial class busqueda : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();
        SqlDataReader reader;
        string query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string opcion = Request.QueryString["opcion"];
            if (opcion.Equals("ok"))
                Response.Write(todos());
            else
            {
                string search = Request.QueryString["search"];
                conexion.abreConexion();
                comando.Connection = conexion.usaConexion();
                query = "select * from producto where nombre like '%" + search + "%'";
                comando.CommandText = query;
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Response.Write("<a href='mostrar.aspx?idProducto=" + (int)reader["id"] +"'><div class=producto>" +
                                    "<b>" + (string)reader["nombre"] + "</b><br>" +
                                    (string)reader["descripcion"] + "<br>" +
                                    "$ " + (double)reader["precio"] + "</div></a>");
                }
                conexion.cierraConexion();
            }
        }
        public string todos()
        {
            string res = "";
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            query = "select * from producto";
            comando.CommandText = query;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                res += "<a href='mostrar.aspx?idProducto=" + (int)reader["id"] + "'><div class=producto>" +
                       "<b>" + (string)reader["nombre"] + "</b><br>" +
                       (string)reader["descripcion"] + "<br>" +
                       "$ " + (double)reader["precio"] + "</div></a>";
            }
            conexion.cierraConexion();
            return res;
        }

        public string mostrarPorId(int id)
        {
            string res = "";
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            query = "select * from producto where id = " + id;
            comando.CommandText = query;
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                res += "<div class=productoMostrar>" +
                        "<div class=imagenProducto><img src='img/" + (string)reader["imagen"] + "' heigh='150' width='150'></div>" +
                        "<b>Id: </b>" + (int)reader["id"] + "<br>" +
                        "<b>Nombre: </b>" + (string)reader["nombre"] + "<br>" +
                        "<b>Precio: $</b>" + (double)reader["precio"] + "<br>"+
                        "<b>Descripción: </b>" + (string)reader["descripcion"] + "</div>";
            }
            conexion.cierraConexion();
            return res;
        }
    }
}