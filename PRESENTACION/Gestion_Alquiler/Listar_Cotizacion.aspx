<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listar_Cotizacion.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Listar_Cotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .modal-content {
      text-align: center;
    }

    .btnopcion {
      font-size: 16px;
      font-weight: lighter;
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
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-10 p-3">
      <div id="DIV_Gestionar_Equipo" runat="server">
        <h1 style="text-align: center">LISTAR COTIZACION</h1>
        <div align="center">
          <h5>Revisar cotizacion por fecha
          </h5>
          <asp:Button ID="btn_Filtrar_Fecha" runat="server" Text="FILTRAR COTIZACION POR FECHA" class="btnopcion" />
        </div>
      </div>

      <div id="div_GV_Cargar_Solicitud_Eventos" runat="server">
        <br />
        <br />
        <asp:GridView ID="GV_Listar_Cotizacion" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay solicitudes de evento actualmente." DataKeyNames="ID_COTIZACION" HorizontalAlign="Center" HeaderStyle-BackColor="#6cacdc" class="gridview" AlternatingRowStyle-CssClass="even" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChangingRevisarSolicitud" OnRowCommand="GV_Gestionar_Solicitud_Evento_RowCommand">
          <Columns>
            <asp:BoundField DataField="ID_COTIZACION" HeaderText="ID SOLICITUD DE EVENTO" Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="NOMBRE" HeaderText="COTIZACION" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="FECHA" HeaderText="FECHA" ItemStyle-HorizontalAlign="Center" />

            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Button ID="btn_Revisar_Solicitud" runat="server" Text="REVISAR" class="btn btn-secondary" CommandName="REVISAR_SOLICITUD" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
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
</asp:Content>
