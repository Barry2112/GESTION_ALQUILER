using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Boleta : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

      string n = (string)Session["Diego"];
      Label1.Text = n;
      Response.Redirect(n);

      string m = (string)Session["Barry"];
      Label2.Text = m;
      Response.Redirect(m);
    }
  }
}
