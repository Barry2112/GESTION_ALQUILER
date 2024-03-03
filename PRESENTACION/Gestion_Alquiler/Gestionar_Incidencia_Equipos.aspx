<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gestionar_Incidencia_Equipos.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Gestionar_Incidencia_Equipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .modal-content {
      text-align: center;
    }

    .gridview {
      font-family: "arial";
      background-color: #FFFFFF;
      width: 100%;
      font-size: small;
    }

      .gridview th {
        background: #7AC142;
        padding: 5px;
        font-size: small;
      }

        .gridview th a {
          color: #003300;
          text-decoration: none;
        }

          .gridview th a:hover {
            color: #003300;
            text-decoration: underline;
          }

      .gridview td {
        background: #D9EDC9;
        color: #333333;
        font: small "arial";
        padding: 4px;
      }

      .gridview tr.even td {
        background: #FFFFFF;
      }

      .gridview td a {
        color: #003300;
        font: bold small "arial";
      }

    h1 {
      font-size: 40px;
      font-weight: bold;
      text-align: center;
    }

    .btn_Reportar_Incidencia_Equipo {
      font-size: 20px;
      font-weight: lighter;
      width: 340px;
      height: 60px
    }

    .p {
      font-size: 22px;
    }

    #center {
      text-align: center;
    }
  </style>


  <section class="d-flex justify-content-center">
    <div class="card col-sm-10 p-3">
      <div id="DIV_GESTIONAR_Incidencia_Equipo" runat="server">
        <h1 style="text-align: center">GESTIONAR INCIDENCIA EQUIPO</h1>
      </div>
      <br />
      <div id="DIV_Detalles_Equipo" runat="server">
        <br />
        <div align="center" class="p">
          <p>Debe de seleccionar una incidencia</p>
        </div>
        <br />
        <asp:GridView ID="GV_Mostrar_Equipos_Incidencia" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay Equipos de este Tipo Actualmente." DataKeyNames="ID_Equipo" HeaderStyle-BackColor="#6cacdc" OnRowCommand="GV_Mostrar_Equipos_Incidencia_RowCommand" CssClass="gridview" AlternatingRowStyle-CssClass="even">
          <Columns>
            <asp:BoundField DataField="ID_Equipo" HeaderText="ID Equipo" Visible="false" />
            <asp:BoundField DataField="ID_Incidencia" HeaderText="ID INCIDENCIA" Visible="false" />
            <asp:BoundField DataField="Nombre_Equipo" HeaderText="NOMBRE DEL EQUIPO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Descripcion_Marca_Equipo" HeaderText="CODIGO DEL EQUIPO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Fecha_Creacion" HeaderText="FECHA DE CREACION DE INCIDENCIA" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Fecha_Cerrado" HeaderText="FECHA DE CIERRE DE INCIDENCIA" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Button ID="btn_REVISAR_INCIDENCIA" runat="server" Text="REVISAR INCIDENCIA DE EQUIPO" class="btn btn-primary" CommandName="REVISAR_INCIDENCIA_EQUIPO" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>

      <asp:Label ID="label_ID_Equipo" runat="server" Text="LabelIDEquipo"></asp:Label>

      <div id="DIV_DETALLES_EQUIPO_incidencia" runat="server">
        <br />
        <br />
        <div class="row">
          <div class="col-md-4"></div>
          <div class="col-md-4">
            <div align="center">
              <div class="form-group">
                Codigo del equipo : 
            <asp:TextBox ID="txtCodigo_Equipo_Editar" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                Nombre del equipo :  
              <asp:TextBox ID="txtNombre" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group" runat="server" id="DIV_txt_marca_equipo_editar">
                Marca del equipo :  
              <asp:TextBox ID="txtmarca" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                Precio del equipo :  
              <asp:TextBox ID="txtPrecio" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                Trabajador asignado :
            <asp:TextBox ID="txtTrabajador" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
              </div>
            </div>
          </div>
        </div>
      </div>


      <asp:Label ID="label_ID_Trabajador" runat="server" Text="LabelIDEquipo"></asp:Label>

      <br />
      <br />
      <div id="DIV_IMAGEN_EQUIPO" runat="server" style="text-align: center">
        <asp:Image ID="Image_Equipo_Editar" runat="server" alt="" Style="width: 300px" />
      </div>
      <div id="detalles" runat="server">

        <br />
        <br />
        <br />
        <div class="row">
          <div class="col-md-1"></div>
          <div class="col-md-10">
            <div style="text-align: left">
              <label>Especifique alg&#250n detalle</label>
            </div>
            <div>
              <textarea id="txtdetalle" runat="server" class="form-control" style="height: 105px"></textarea>
            </div>
          </div>
          <div class="col-md-1"></div>
        </div>
        <br />
        <br />

        <div class="row">
          <div class="col-md-1"></div>
          <div class="col-md-10">
            <div style="text-align: left">
              <label>Especifique la solucion aplicada</label>
            </div>
            <div>
              <textarea id="txtsolucion" runat="server" class="form-control" style="height: 105px"></textarea>
            </div>
          </div>
          <div class="col-md-1"></div>
        </div>
        <br />
        <br />

        <div align="center">
          <asp:Button ID="btnRegistrarIncidencia" runat="server" class="btn btn-primary btn_Reportar_Incidencia_Equipo" Text="REGISTRAR SOLUCION DE INCIDENCIA DE EQUIPO" OnClick="btn_Registrar_Incidencia_Equipo_Click" />
        </div>
        <br />
        <br />

      </div>
    </div>
  </section>


  <div class="modal fade" id="ModalError" role="dialog">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header" style="width: 500px; height: 300px; background-color: red">
          <h4 class="modal-title"></h4>
          <div class="icon-box" style="text-align: center">
            <img src="../Imagenes/aspa.png" style="width: 200px; height: 200px" />
            <br />
            <h3 style="color: white; font-size: xx-large">&nbsp;ERROR!</h3>
          </div>
          <br>
        </div>
        <div id="error" class="modal-body">
          <asp:Label ID="labelerror" runat="server" Text="Label"></asp:Label>
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade" id="ModalSolicitudRegistrado">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header" style="width: 500px; height: 300px; background-color: green">
          <h4 class="modal-title"></h4>
          <div class="icon-box" style="text-align: center">
            <img src="../Imagenes/check.png" style="width: 200px; height: 200px" />
            <br />
            <h4 style="color: white; font-size: xx-large">&nbsp;EXITO!</h4>
          </div>
          <br>
        </div>
        <div class="modal-body align-content-center">
          <h5>INCIDENCIA RESUELTA</h5>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
