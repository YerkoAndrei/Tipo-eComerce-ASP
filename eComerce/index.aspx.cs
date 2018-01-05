using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eComerce
{
    public partial class index : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion.cierraConexion();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string rut = Request.Form["txtRut"];
            string nombre = Request.Form["txtNombre"];
            string apellido = Request.Form["txtApellido"];
            string correo = Request.Form["txtCorreo"];
            string direccion = Request.Form["txtDireccion"];
            string pass = Request.Form["txtPass"];
            string pass2 = Request.Form["txtPass2"];

            if (rut.Trim().Equals("") || nombre.Trim().Equals("") || apellido.Trim().Equals("") || correo.Trim().Equals("") || direccion.Trim().Equals("") || pass.Trim().Equals("") || pass2.Trim().Equals(""))
                Response.Write("Complete todos los campos");
            else
                if (pass.Equals(pass2))
                {
                    conexion.abreConexion();
                    comando.Connection = conexion.usaConexion();
                    string query = "insert into usuario values ('" + rut + "', '" + nombre + "', '" + apellido + "', '" + correo + "', '" + direccion + "', '" + pass + "', 0)";
                    comando.CommandText = query;
                    if(comando.ExecuteNonQuery() > 0)
                        Response.Write("Exito al registrar");
                    else
                        Response.Write("Error al registrar");
                    conexion.cierraConexion();
                }
                else
                    Response.Write("Contraseñas distintas");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string login = Request.Form["txtLogin"];
            string loginPass = Request.Form["txtLoginPass"];
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from usuario where rut='" + login + "' and pass='" + loginPass + "'";
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int opcion = (int)reader["perfil"];
                conexion.cierraConexion();
                switch (opcion)
                {
                    case 0:
                        this.Session["actual"] = "cliente";
                        this.Session["rutActual"] = login;
                        Response.Redirect("compras.aspx");
                        break;
                    case 1:
                        this.Session["actual"] = "admin";
                        Response.Redirect("mantencion.aspx");
                        break;
                }
            }
            else
                Response.Write("Usuario invalido");
        }

    }
}