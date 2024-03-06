using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DOMINIO;
using NEGOCIO;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Coti : System.Web.UI.Page
  {
    N_Evento NEvento = new N_Evento();
    N_Equipo NEquipo = new N_Equipo();
    N_Tipo_Equipo NTipoEquipo = new N_Tipo_Equipo();
    N_Conexion_BD NConexionBD = new N_Conexion_BD();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        string ID_Usuario = (string)Session["ID_Usuario"];
        string ID_Tipo_Usuario = (string)Session["ID_Tipo_Usuario"];

        if (string.IsNullOrEmpty(ID_Usuario))
        {
          Inicie_Sesion();
          Response.Redirect("~/Gestion_Alquiler/Iniciar_Sesion.aspx");
        }
        /*
        else if (ID_Tipo_Usuario == "3")
        {
          Permisos_Insuficientes();
          Response.Redirect("~/Gestion_Alquiler/Pagina_Principal.aspx");
        }*/
        else
        {
          if (!IsPostBack)
          {
            CargarPagina();

            LabelSUBTOTAL.Text = "0,00";
            LabelIGV.Text = "0,00";
            LabelTOTAL.Text = "0,00";
          }
        }
      }
    }

    public void Inicie_Sesion()
    {
      labelerror.Text = "ADVERTENCIA: Debe de iniciar sesion";
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
    }

    public void Permisos_Insuficientes()
    {
      labelerror.Text = "ADVERTENCIA: Tipo de usuario no adminitido";
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
    }

    public void CargarPagina()
    {
      DataTable dt1 = new DataTable();
      DataColumn d1 = dt1.Columns.Add("n1", typeof(Int32));
      dt1.Rows.Add(1);
      GV_Cotizacion.DataSource = dt1;
      GV_Cotizacion.DataBind();
      CargarLista();

      Session["CACHEDATA1"] = null;
      Session["CACHEDATA2"] = null;
    }

    public void CargarLista()
    {
      for (int i = 0; i < Int32.Parse(GV_Cotizacion.Rows.Count.ToString()); i++)
      {
        DropDownList DDL_Tipo_Equipo = GV_Cotizacion.Rows[i].Cells[1].FindControl("DDL_Tipo_Equipo") as DropDownList;
        DDL_Tipo_Equipo.DataSource = NTipoEquipo.Listar_Tipo_Equipo();
        DDL_Tipo_Equipo.DataTextField = "DESCRIPCION";
        DDL_Tipo_Equipo.DataValueField = "ID";
        DDL_Tipo_Equipo.DataBind();
        DDL_Tipo_Equipo.Items.Insert(0, "SELECCIONE");

        DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
        DDL_Codigo_Equipo.SelectedIndex = -1;
        DDL_Codigo_Equipo.Items.Insert(0, "Eliga un tipo de equipo");
      }
    }

    public void CargarCodigoEquipo(int ID_Tipo_Equipo)
    {
      for (int i = 0; i < Int32.Parse(GV_Cotizacion.Rows.Count.ToString()); i++)
      {
        DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
        DDL_Codigo_Equipo.DataSource = NEquipo.Listar_Codigo_Equipo_X_ID_Tipo_Equipo(ID_Tipo_Equipo);
        DDL_Codigo_Equipo.DataTextField = "Codigo_Equipo";
        DDL_Codigo_Equipo.DataValueField = "ID_Equipo";
        DDL_Codigo_Equipo.DataBind();
        DDL_Codigo_Equipo.Items.Insert(0, "SELECCIONE");
      }
    }

    protected void DDL_Tipo_Equipo_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.Parent.Parent;
        int idx = row.RowIndex;

        if (ddl.SelectedItem.Text.Equals("SELECCIONE"))
        {
          DropDownList DDL_Codigo_Equipo = (DropDownList)row.Cells[2].FindControl("DDL_Codigo_Equipo");
          DDL_Codigo_Equipo.SelectedIndex = -1;
          DDL_Codigo_Equipo.Items.Insert(0, "Eliga un tipo de equipo");

          TextBox txt_Nombre_Equipo = (TextBox)row.Cells[3].FindControl("txt_Nombre_Equipo");
          txt_Nombre_Equipo.Text = "";
          TextBox txt_Marca_Equipo = (TextBox)row.Cells[4].FindControl("txt_Marca_Equipo");
          txt_Marca_Equipo.Text = "";
          TextBox txt_Precio = (TextBox)row.Cells[6].FindControl("txt_Precio");
          txt_Precio.Text = "";
          TextBox txt_Cantidad = (TextBox)row.Cells[7].FindControl("txt_Cantidad");
          txt_Cantidad.Text = "";
          TextBox txt_Subtotal = (TextBox)row.Cells[8].FindControl("txt_Subtotal");
          txt_Subtotal.Text = "";
        }
        else
        {
          int ID_Tipo_Equipo = Int32.Parse(ddl.SelectedValue);

          for (int i = Int32.Parse(GV_Cotizacion.Rows.Count.ToString()) - 1; i < Int32.Parse(GV_Cotizacion.Rows.Count.ToString()); i++)
          {
            DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
            DDL_Codigo_Equipo.DataSource = NEquipo.Listar_Codigo_Equipo_X_ID_Tipo_Equipo(ID_Tipo_Equipo);
            DDL_Codigo_Equipo.DataTextField = "Codigo_Equipo";
            DDL_Codigo_Equipo.DataValueField = "ID_Equipo";
            DDL_Codigo_Equipo.DataBind();
            DDL_Codigo_Equipo.Items.Insert(0, "SELECCIONE");
          }
        }
      }
      catch
      {
      }
    }

    protected void DDL_Codigo_Equipo_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.Parent.Parent;
        int idx = row.RowIndex;

        if (ddl.SelectedItem.Text.Equals("SELECCIONE"))
        {
          TextBox txt_Nombre_Equipo = (TextBox)row.Cells[3].FindControl("txt_Nombre_Equipo");
          txt_Nombre_Equipo.Text = "";
          TextBox txt_Marca_Equipo = (TextBox)row.Cells[4].FindControl("txt_Marca_Equipo");
          txt_Marca_Equipo.Text = "";
          TextBox txt_Precio = (TextBox)row.Cells[6].FindControl("txt_Precio");
          txt_Precio.Text = "";
          TextBox txt_Cantidad = (TextBox)row.Cells[7].FindControl("txt_Cantidad");
          txt_Cantidad.Text = "";
          TextBox txt_Subtotal = (TextBox)row.Cells[8].FindControl("txt_Subtotal");
          txt_Subtotal.Text = "";

          CalcularTotal();
        }
        else
        {
          string Codigo_Equipo = ddl.SelectedItem.ToString();

          DataTable dtParametrosP = NEquipo.ObtenerDetallesxCodigoEquipo(Codigo_Equipo);

          if (dtParametrosP.Rows.Count > 0)
          {
            DataRow filaA = dtParametrosP.Rows[0];

            TextBox txt_Nombre_Equipo = (TextBox)row.Cells[3].FindControl("txt_Nombre_Equipo");
            txt_Nombre_Equipo.Text = Convert.ToString(filaA[0]);
            TextBox txt_Marca_Equipo = (TextBox)row.Cells[4].FindControl("txt_Marca_Equipo");
            txt_Marca_Equipo.Text = Convert.ToString(filaA[1]);
            TextBox txt_Precio = (TextBox)row.Cells[6].FindControl("txt_Precio");
            txt_Precio.Text = Convert.ToString(filaA[3]);

            TextBox txt_Cantidad = (TextBox)row.Cells[7].FindControl("txt_Cantidad");
            txt_Cantidad.Text = "1";
            TextBox txt_Subtotal = (TextBox)row.Cells[8].FindControl("txt_Subtotal");
            txt_Subtotal.Text = Convert.ToString(filaA[3]);
          }

          CalcularTotal();
        }
      }
      catch
      {
      }
    }

    protected void txt_Cantidad_TextChanged(object sender, EventArgs e)
    {
      try
      {
        TextBox textBoxCantidad = (TextBox)sender;
        GridViewRow row = (GridViewRow)textBoxCantidad.Parent.Parent;

        TextBox txt_Precio = (TextBox)row.Cells[6].FindControl("txt_Precio");
        TextBox txt_Cantidad = (TextBox)row.Cells[7].FindControl("txt_Cantidad");
        TextBox txt_Subtotal = (TextBox)row.Cells[8].FindControl("txt_Subtotal");

        var precio = Double.Parse(txt_Precio.Text);
        var cantidad = Double.Parse(txt_Cantidad.Text);
        var subtotal = precio * cantidad;

        txt_Subtotal.Text = subtotal.ToString();

        CalcularTotal();
      }
      catch
      {
      }
    }

    protected void GV_Cotizaccion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int validar = 0;
      int rowIndex = int.Parse(e.CommandArgument.ToString());

      switch (e.CommandName)
      {
        case "Eliminar":
          if (GV_Cotizacion.Rows.Count == 1)
          {
            DataTable dt = new DataTable();
            DataColumn dc = dt.Columns.Add("n1", typeof(Int32));
            dt.Rows.Add(1);
            GV_Cotizacion.DataSource = dt;
            GV_Cotizacion.DataBind();
            CargarLista();
            CalcularTotal();
            //calcularcotizacion --calcularTotal();
          }
          else
          {
            DO_Cotizacion DOC = new DO_Cotizacion();

            DataTable dt = (DataTable)Session["CACHEDATA2"];
            Session["CACHEDATA2"] = null;

            for (int i = 0; i < (Int32.Parse(GV_Cotizacion.Rows.Count.ToString())); i++)
            {
              TextBox txt_Nombre_Equipo = GV_Cotizacion.Rows[i].Cells[3].FindControl("txt_Nombre_Equipo") as TextBox;
              //int.TryParse(txtIngresarMonto.Text,out valor)
              if (rowIndex == i)
              {
                //nothing
              }
              else if (txt_Nombre_Equipo.Text.Equals(""))
              {
                validar = 1;
              }

              else if (!txt_Nombre_Equipo.Text.Equals(""))
              {
                DropDownList DDL_Tipo_Equipo = GV_Cotizacion.Rows[i].Cells[1].FindControl("DDL_Tipo_Equipo") as DropDownList;
                DOC.ID_Tipo_Equipo = DDL_Tipo_Equipo.SelectedItem.Text;
                DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
                DOC.ID_Codigo_Equipo = DDL_Codigo_Equipo.SelectedItem.Text;
                DOC.Nombre_Equipo = txt_Nombre_Equipo.Text;
                TextBox txt_Marca_Equipo = GV_Cotizacion.Rows[i].Cells[4].FindControl("txt_Marca_Equipo") as TextBox;
                DOC.Marca_Equipo = txt_Marca_Equipo.Text;
                TextBox txt_Precio = GV_Cotizacion.Rows[i].Cells[6].FindControl("txt_Precio") as TextBox;
                DOC.Precio_Equipo = txt_Precio.Text;

                TextBox txt_Cantidad = GV_Cotizacion.Rows[i].Cells[7].FindControl("txt_Cantidad") as TextBox;
                DOC.Cantidad = txt_Cantidad.Text;
                TextBox txt_Subtotal = GV_Cotizacion.Rows[i].Cells[6].FindControl("txt_Subtotal") as TextBox;
                DOC.Subtotal = txt_Subtotal.Text;

                if (dt == null)
                {
                  dt = new DataTable("Tabla");
                  dt.Columns.Add("1");
                  dt.Columns.Add("2");
                  dt.Columns.Add("3");
                  dt.Columns.Add("4");
                  dt.Columns.Add("5");
                  dt.Columns.Add("6");
                  dt.Columns.Add("7");
                  dt.Columns.Add("8");
                }
                dt.LoadDataRow(new object[] { DOC.ID_Tipo_Equipo, DOC.ID_Codigo_Equipo, DOC.Nombre_Equipo, DOC.Marca_Equipo, DOC.Trabajador_Equipo, DOC.Precio_Equipo, DOC.Cantidad, DOC.Subtotal }, true);
              }
            }
            Session["CACHEDATA2"] = dt;

            int n = GV_Cotizacion.Rows.Count;

            DataTable dt1 = new DataTable();
            DataColumn d1 = dt1.Columns.Add("n1", typeof(Int32));

            for (int i = 0; i <= n; i++)
            {
              dt1.Rows.Add(i);
            }

            GV_Cotizacion.DataSource = dt;
            GV_Cotizacion.DataBind();

            CargarLista();

            for (int i = 0; i < GV_Cotizacion.Rows.Count - validar; i++)
            {
              DropDownList DDL_Tipo_Equipo = GV_Cotizacion.Rows[i].Cells[1].FindControl("DDL_Tipo_Equipo") as DropDownList;
              DDL_Tipo_Equipo.SelectedIndex = -1;
              DDL_Tipo_Equipo.Items.FindByText(dt.Rows[i].Field<String>(0)).Selected = true;
              int id_tipoequipo = DDL_Tipo_Equipo.SelectedIndex;

              DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
              DDL_Codigo_Equipo.DataSource = NEquipo.Listar_Codigo_Equipo_X_ID_Tipo_Equipo(id_tipoequipo);
              DDL_Codigo_Equipo.DataTextField = "Codigo_Equipo";
              DDL_Codigo_Equipo.DataValueField = "ID_Equipo";
              DDL_Codigo_Equipo.DataBind();
              DDL_Codigo_Equipo.Items.Insert(0, "SELECCIONE");
              DDL_Codigo_Equipo.Items.FindByText(dt.Rows[i].Field<String>(1)).Selected = true;

              TextBox txt_Nombre_Equipo = GV_Cotizacion.Rows[i].Cells[3].FindControl("txt_Nombre_Equipo") as TextBox;
              txt_Nombre_Equipo.Text = dt.Rows[i].Field<String>(2);
              TextBox txt_Marca_Equipo = GV_Cotizacion.Rows[i].Cells[4].FindControl("txt_Marca_Equipo") as TextBox;
              txt_Marca_Equipo.Text = dt.Rows[i].Field<String>(3);
              TextBox txt_Precio = GV_Cotizacion.Rows[i].Cells[6].FindControl("txt_Precio") as TextBox;
              txt_Precio.Text = dt.Rows[i].Field<String>(5);

              TextBox txt_Cantidad = GV_Cotizacion.Rows[i].Cells[7].FindControl("txt_Cantidad") as TextBox;
              txt_Cantidad.Text = dt.Rows[i].Field<String>(6);
              TextBox txt_Subtotal = GV_Cotizacion.Rows[i].Cells[8].FindControl("txt_Subtotal") as TextBox;
              txt_Subtotal.Text = dt.Rows[i].Field<String>(7);
            }
            Session["CACHEDATA2"] = null;
            DataTable dteliminar = (DataTable)Session["CACHEDATA2"];

            CalcularTotal();
          }
          break;
      }
    }

    protected void btnAgregarRow_Click(object sender, EventArgs e)
    {
      int cant = 0;
      int row = 0;

      for (int i = 0; i <= GV_Cotizacion.Rows.Count - 1; i++)
      {
        TextBox txt_Nombre = GV_Cotizacion.Rows[i].Cells[3].FindControl("txt_Nombre_Equipo") as TextBox;

        if (txt_Nombre.Text.Equals(""))
        {
          cant = 1;
          row = i + 1;
        }
      }

      if (cant == 1)
      {
        labelerror.Text = "ADVERTENCIA: No puede generar cotizacion si la fila " + row + " no esta llena.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        DO_Cotizacion DOC = new DO_Cotizacion();
        DataTable dt = (DataTable)Session["CACHEDATA1"]; // cache data to session
        Session["CACHEDATA1"] = null;
        for (int i = 0; i < (Int32.Parse(GV_Cotizacion.Rows.Count.ToString())); i++)
        {
          DropDownList DDL_Tipo_Equipo = GV_Cotizacion.Rows[i].Cells[1].FindControl("DDL_Tipo_Equipo") as DropDownList;
          DOC.ID_Tipo_Equipo = DDL_Tipo_Equipo.SelectedItem.Text;
          DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
          DOC.ID_Codigo_Equipo = DDL_Codigo_Equipo.SelectedItem.Text;
          TextBox txt_Nombre_Equipo = GV_Cotizacion.Rows[i].Cells[3].FindControl("txt_Nombre_Equipo") as TextBox;
          DOC.Nombre_Equipo = txt_Nombre_Equipo.Text;
          TextBox txt_Marca_Equipo = GV_Cotizacion.Rows[i].Cells[4].FindControl("txt_Marca_Equipo") as TextBox;
          DOC.Marca_Equipo = txt_Marca_Equipo.Text;
          TextBox txt_Precio = GV_Cotizacion.Rows[i].Cells[6].FindControl("txt_Precio") as TextBox;
          DOC.Precio_Equipo = txt_Precio.Text;

          TextBox txt_Cantidad = GV_Cotizacion.Rows[i].Cells[7].FindControl("txt_Cantidad") as TextBox;
          DOC.Cantidad = txt_Cantidad.Text;
          TextBox txt_Subtotal = GV_Cotizacion.Rows[i].Cells[8].FindControl("txt_Subtotal") as TextBox;
          DOC.Subtotal = txt_Subtotal.Text;

          if (dt == null)
          {
            dt = new DataTable("Tabla");
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4");
            dt.Columns.Add("5");
            dt.Columns.Add("6");
            dt.Columns.Add("7");
            dt.Columns.Add("8");
          }
          dt.LoadDataRow(new object[] { DOC.ID_Tipo_Equipo, DOC.ID_Codigo_Equipo, DOC.Nombre_Equipo, DOC.Marca_Equipo, DOC.Trabajador_Equipo, DOC.Precio_Equipo, DOC.Cantidad, DOC.Subtotal }, true);
        }

        Session["CACHEDATA1"] = dt;
        int n = Int32.Parse(GV_Cotizacion.Rows.Count.ToString());
        DataTable dt1 = new DataTable();
        DataColumn d1 = dt1.Columns.Add("n1", typeof(Int32));

        for (int i = 0; i <= n; i++)
        {
          dt1.Rows.Add(i + 1);
        }

        GV_Cotizacion.DataSource = dt1;
        GV_Cotizacion.DataBind();

        CargarLista();

        for (int i = 0; i < (Int32.Parse(GV_Cotizacion.Rows.Count.ToString()) - 1); i++)
        {
          DropDownList DDL_Tipo_Equipo = GV_Cotizacion.Rows[i].Cells[1].FindControl("DDL_Tipo_Equipo") as DropDownList;
          DDL_Tipo_Equipo.SelectedIndex = -1;
          DDL_Tipo_Equipo.Items.FindByText(dt.Rows[i].Field<String>(0)).Selected = true;

          int id_tipoequipo = DDL_Tipo_Equipo.SelectedIndex;

          DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
          DDL_Codigo_Equipo.DataSource = NEquipo.Listar_Codigo_Equipo_X_ID_Tipo_Equipo(id_tipoequipo);
          DDL_Codigo_Equipo.DataTextField = "Codigo_Equipo";
          DDL_Codigo_Equipo.DataValueField = "ID_Equipo";
          DDL_Codigo_Equipo.DataBind();
          DDL_Codigo_Equipo.Items.Insert(0, "SELECCIONE");
          DDL_Codigo_Equipo.Items.FindByText(dt.Rows[i].Field<String>(1)).Selected = true;

          TextBox txt_Nombre_Equipo = GV_Cotizacion.Rows[i].Cells[3].FindControl("txt_Nombre_Equipo") as TextBox;
          txt_Nombre_Equipo.Text = dt.Rows[i].Field<String>(2);
          TextBox txt_Marca_Equipo = GV_Cotizacion.Rows[i].Cells[4].FindControl("txt_Marca_Equipo") as TextBox;
          txt_Marca_Equipo.Text = dt.Rows[i].Field<String>(3);
          TextBox txt_Precio = GV_Cotizacion.Rows[i].Cells[6].FindControl("txt_Precio") as TextBox;
          txt_Precio.Text = dt.Rows[i].Field<String>(5);

          TextBox txt_Cantidad = GV_Cotizacion.Rows[i].Cells[7].FindControl("txt_Cantidad") as TextBox;
          txt_Cantidad.Text = dt.Rows[i].Field<String>(6);
          TextBox txt_Subtotal = GV_Cotizacion.Rows[i].Cells[8].FindControl("txt_Subtotal") as TextBox;
          txt_Subtotal.Text = dt.Rows[i].Field<String>(7);
        }
        Session["CACHEDATA1"] = null;
      }
    }

    public void CalcularTotal()
    {
      double TOTALFINAL = 0;
      double sub = 0;

      foreach (GridViewRow row in GV_Cotizacion.Rows)
      {

        //TextBox txt_Precio = row.Cells[6].FindControl("txt_Precio") as TextBox
        TextBox txt_Subtotal = row.Cells[8].FindControl("txt_Subtotal") as TextBox;

        if (!txt_Subtotal.Text.Equals(""))
        {
          sub = Convert.ToDouble(txt_Subtotal.Text);
          TOTALFINAL = TOTALFINAL + sub;
        }
        TOTALFINAL = TOTALFINAL + (TOTALFINAL * (18 / 100));
        LabelSUBTOTAL.Text = Convert.ToString(TOTALFINAL);
        LabelIGV.Text = Convert.ToString(TOTALFINAL * 0.18);

        double SUBT = Convert.ToDouble(LabelSUBTOTAL.Text);
        double IGV = Convert.ToDouble(LabelIGV.Text);

        LabelTOTAL.Text = Convert.ToString(SUBT + IGV);
      }
    }


    protected void btnGenerarCotizacion_Click(object sender, EventArgs e)
    {
      int cant = 0;
      int row = 0;

      for (int i = 0; i <= GV_Cotizacion.Rows.Count - 1; i++)
      {
        TextBox txt_Nombre = GV_Cotizacion.Rows[i].Cells[3].FindControl("txt_Nombre_Equipo") as TextBox;

        if (txt_Nombre.Text.Equals(""))
        {
          cant = 1;
          row = i + 1;
        }
      }

      if (cant == 1)
      {
        labelerror.Text = "ADVERTENCIA: No puede generar cotizacion si la fila " + row + " no esta llena.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        int ID_Cotizacion = 0;

        DataTable dtParametrosC = NEvento.Obtener_ID_Cotizacion();

        if (dtParametrosC.Rows.Count > 0)
        {
          DataRow filaA = dtParametrosC.Rows[0];
          string Cotizacion_key = filaA[0].ToString();
          ID_Cotizacion = Convert.ToInt32(Cotizacion_key);
        }

        //GUARDA DETALLES DE LA COTIZACION
        for (int i = 0; i < Int32.Parse(GV_Cotizacion.Rows.Count.ToString()); i++)
        {
          DropDownList DDL_Tipo_Equipo = GV_Cotizacion.Rows[i].Cells[1].FindControl("DDL_Tipo_Equipo") as DropDownList;
          DropDownList DDL_Codigo_Equipo = GV_Cotizacion.Rows[i].Cells[2].FindControl("DDL_Codigo_Equipo") as DropDownList;
          TextBox txt_Precio = GV_Cotizacion.Rows[i].Cells[6].FindControl("txt_Precio") as TextBox;
          TextBox txt_Cantidad = GV_Cotizacion.Rows[i].Cells[7].FindControl("txt_Cantidad") as TextBox;
          TextBox txt_Subtotal = GV_Cotizacion.Rows[i].Cells[8].FindControl("txt_Subtotal") as TextBox;

          int ID_Tipo_Equipo = Convert.ToInt32(DDL_Tipo_Equipo.SelectedValue);
          int ID_Equipo = Convert.ToInt32(DDL_Codigo_Equipo.SelectedValue);
          int cantidad = Convert.ToInt32(txt_Cantidad.Text);
          double precio_unitario = Convert.ToDouble(txt_Precio.Text);
          double sub_total = Convert.ToDouble(txt_Subtotal.Text);

          NEvento.Registrar_Cotizacion(ID_Cotizacion, ID_Tipo_Equipo, ID_Equipo, cantidad, precio_unitario, sub_total);
        }

        //GUARDA DATOS PRINCIPALES DE LA COTIZACION
        double numero_IGV = 18;
        double sub_total_x = Convert.ToDouble(LabelSUBTOTAL.Text);
        double total_IGV = Convert.ToDouble(LabelIGV.Text);
        double total = Convert.ToDouble(LabelTOTAL.Text);

        NEvento.Registrar_Datos_Cotizacion(ID_Cotizacion, numero_IGV, sub_total_x, total_IGV, total);

        //GUARDA LA COTIZACION
        ReportDocument RepDoc = new ReportDocument();
        RepDoc.Load(Server.MapPath(@"~/Reportes/Cotizacion.rpt"));
        RepDoc.SetParameterValue("@ID_COTIZACION", ID_Cotizacion);
        RepDoc.DataSourceConnections[0].SetConnection(NConexionBD.getServidor(), "GESTION_ALQUILER", true);
        RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Cotizacion/Cotizacion_" + ID_Cotizacion + ".pdf"));
        FileStream fstream = new FileStream(Server.MapPath(@"~/Cotizacion/Cotizacion_" + ID_Cotizacion + ".pdf"), FileMode.Open);
        BinaryReader binaryReader = new BinaryReader(fstream);
        byte[] bytes = binaryReader.ReadBytes((int)fstream.Length);

        DO_Reporte_Cotizacion DORC = new DO_Reporte_Cotizacion();
        DORC.Cotizacion = bytes;
        fstream.Close();
        
        NEvento.Guardar_Reporte_Cotizacion(ID_Cotizacion, DORC);

        Session["Diego"] = "~/Cotizacion/Cotizacion_" + ID_Cotizacion + ".pdf";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalGenerarCotizacionExitosa').modal('show');", true);
         string _open = "window.open('Reporte.aspx', '_blank');";
           ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        /*
          ReportDocument RepDoc = new ReportDocument();
            RepDoc.Load(Server.MapPath(@"~/Reportes/Boleta.rpt"));
            RepDoc.SetParameterValue("@id", ID_Evento);
            RepDoc.DataSourceConnections[0].SetConnection(NConexionBD.getServidor(), "GESTION_ALQUILER", true);
            RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Boleta/Boleta_" + ID_Evento + ".pdf"));
            FileStream fstream = new FileStream(Server.MapPath(@"~/Boleta/Boleta_" + ID_Evento + ".pdf"), FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fstream);
            byte[] bytes = binaryReader.ReadBytes((int)fstream.Length);

            DO_Boleta DOB = new DO_Boleta();
            DOB.Boleta = bytes;
            fstream.Close();
            NEvento.Guardar_Boleta(ID_Evento, DOB);
            Session["Diego"] = "~/Boleta/Boleta_" + ID_Evento + ".pdf";
            string _open = "window.open('Reporte.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            ReportDocument RepDoc2 = new ReportDocument();
            RepDoc2.Load(Server.MapPath(@"~/Reportes/Contrato.rpt"));
            RepDoc2.SetParameterValue("@ID_EVENTO", ID_Evento);
            RepDoc2.DataSourceConnections[0].SetConnection(NConexionBD.getServidor(), "GESTION_ALQUILER", true);
            RepDoc2.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Contrato/Contrato_" + ID_Evento + ".pdf"));
            FileStream fstream2 = new FileStream(Server.MapPath(@"~/Contrato/Contrato_" + ID_Evento + ".pdf"), FileMode.Open);
            BinaryReader binaryReader2 = new BinaryReader(fstream2);
            byte[] bytes2 = binaryReader2.ReadBytes((int)fstream2.Length);
         
         */

      }
    }

    
  }
}
