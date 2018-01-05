using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eComerce
{
    public partial class compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void verProductos()
        {
            busqueda bs = new busqueda();
            bs.todos();
        }
    }
}