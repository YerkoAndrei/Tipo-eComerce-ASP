using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eComerce
{
    public class Producto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private float precio;

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}