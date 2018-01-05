using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace eComerce
{
    public partial class Mantencion : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();
        SqlDataReader reader;
        string query = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            verProductos();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string crearNombre = Request.Form["txtCrearNombre"];
            string crearPrecio = Request.Form["txtCrearPrecio"];
            string crearDescripcion = Request.Form["txtCrearDescripcion"];
            string crearImagen = "";
            float precio = 0f;
            if (crearNombre.Trim().Equals("") || crearPrecio.Trim().Equals("") || crearDescripcion.Trim().Equals(""))
                Response.Write("Complete todos los campos");
            else
            {
                precio = Convert.ToSingle(crearPrecio);

                conexion.abreConexion();
                comando.Connection = conexion.usaConexion();
                query = "insert into producto (nombre, descripcion, precio, imagen) values ('" + crearNombre + "', '" + crearDescripcion + "', " + precio + ", '" + crearImagen + "')";
                comando.CommandText = query;
                if (comando.ExecuteNonQuery() > 0)
                    Response.Write("Exito al registrar");
                else
                    Response.Write("Error al registrar");
                conexion.cierraConexion();
                verProductos();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string modId = Request.Form["txtmodId"];
            string modNombreNuevo = Request.Form["txtmodNombreNuevo"];
            string modPrecio = Request.Form["txtmodPrecio"];
            string modDescripcion = Request.Form["txtModDescripcion"];
            string modImagen = "";
            double precio = 0;
            if (modId.Trim().Equals("") || modNombreNuevo.Trim().Equals("") || modPrecio.Trim().Equals("") || modDescripcion.Trim().Equals(""))
                Response.Write("Complete todos los campos");
            else
            {
                precio = Convert.ToDouble(modPrecio);

                conexion.abreConexion();
                comando.Connection = conexion.usaConexion();
                query = "update producto set nombre='" + modNombreNuevo + "', precio=" + modPrecio + ", descripcion = '" + modDescripcion + "', imagen='" + modImagen + "' where id = '" + modId + "'";
                comando.CommandText = query;
                if (comando.ExecuteNonQuery() > 0)
                    Response.Write("Exito al modificar");
                else
                    Response.Write("Error al modificar");
                conexion.cierraConexion();
                verProductos();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string delId = Request.Form["txtDelId"];
            if (delId.Trim().Equals(""))
                Response.Write("Complete los campos");
            else
            {
                conexion.abreConexion();
                comando.Connection = conexion.usaConexion();
                query = "delete producto where id = '" + delId + "'";
                comando.CommandText = query;
                if (comando.ExecuteNonQuery() > 0)
                    Response.Write("Exito al eliminar");
                else
                    Response.Write("Error al eliminar");
                conexion.cierraConexion();
                verProductos();
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            string verNombre = Request.Form["txtVerNombre"];
            List<Producto> lista = new List<Producto>();
            double pre = 0;
            if (verNombre.Trim().Equals(""))
                Response.Write("Complete los campos");
            else
            {
                conexion.abreConexion();
                comando.Connection = conexion.usaConexion();
                query = "select * from producto where nombre = '"+verNombre+"'";
                comando.CommandText = query;
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Producto p = new Producto();
                    p.Id = (int)reader["id"];
                    p.Nombre = (string)reader["nombre"];
                    p.Descripcion = (string)reader["descripcion"];
                    pre = (double)reader["precio"];
                    p.Precio = Convert.ToSingle(pre);
                    lista.Add(p);
                }
                else
                    Response.Write("No existe producto");
                dgvProducto.DataSource = lista;
                dgvProducto.DataBind();
                conexion.cierraConexion();
            }
        }
        private void verProductos()
        {
            List<Producto> lista = new List<Producto>();
            double pre = 0;
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            query = "select * from producto";
            comando.CommandText = query;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Producto p = new Producto();
                p.Id = (int)reader["id"];
                p.Nombre = (string)reader["nombre"];
                p.Descripcion = (string)reader["descripcion"];
                pre = (double)reader["precio"];
                p.Precio = Convert.ToSingle(pre);
                lista.Add(p);
            }
            dgvTodosProductos.DataSource = lista;
            dgvTodosProductos.DataBind();
            conexion.cierraConexion();
        }

        protected void crearBuscarImagen_Click(object sender, EventArgs e)
        {
            
        }

        protected void modBuscarImagen_Click(object sender, EventArgs e)
        {

        }
    }
}