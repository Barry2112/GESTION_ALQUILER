<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cancelar_Evento.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Cancelar_Evento" %>

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

    .btn_Atender_Solicitud_Evento {
      font-size: 16px;
      font-weight: lighter;
      width: 240px;
      height: 60px
    }
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-11 p-3">
      <div id="DIV_Atender_Solicitud_de_Evento" runat="server">
        <div class="mb-3" style="text-align: center">
          <h1>CANCELAR EVENTO ORGANIZADO</h1>
        </div>
        <br />
        <div id="div_Filtros_Atender_Solicitud_Evento" style="text-align: center">
          <asp:Button ID="btn_Filtrar_Fecha" runat="server" Text="FILTRAR POR FECHA" OnClick="btn_Filtrar_Fecha_Click" class="btn btn-secondary btn_Atender_Solicitud_Evento" />
          <asp:Button ID="btn_Filtrar_Tipo_Evento" runat="server" Text="FILTRAR POR TIPO DE EVENTO" OnClick="btn_Filtrar_Tipo_Evento_Click" class="btn btn-secondary btn_Atender_Solicitud_Evento" />
        </div>
        <br />

        <div id="div_Filtrar_X_Fecha" runat="server">
          <div align="center">
            <label>Eliga una fecha para filtrar</label>
            <br />
            <asp:TextBox ID="txt_fecha" runat="server" TextMode="Date" Height="30px" Width="200px"></asp:TextBox>
            <asp:Button ID="btn_Buscar_Evento_X_Fecha" runat="server" Text="BUSCAR FECHA" Width="200px" OnClick="btn_Buscar_Evento_X_Fecha_Click" class="btn btn-secondary" Style="margin-left: 50px;" />
          </div>
        </div>

        <div id="div_Filtrar_X_Tipo_Evento" runat="server">
          <div align="center">
            <label>Seleccione un tipo de evento para filtrar</label>
            <asp:DropDownList ID="DDL_Filtrar_X_Tipo_Evento" runat="server" AutoPostBack="true" Width="200px" class="form-control" OnSelectedIndexChanged="DDL_Filtrar_X_Tipo_Evento_Changed"></asp:DropDownList>
          </div>
        </div>

        <div id="div_GV_Cargar_Solicitud_Eventos" runat="server">
          <br />
          <br />
          <asp:GridView ID="GV_Gestionar_Solicitud_Evento" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay solicitudes de evento actualmente." DataKeyNames="ID_Evento" HorizontalAlign="Center" HeaderStyle-BackColor="#6cacdc" class="gridview" AlternatingRowStyle-CssClass="even" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChangingRevisarSolicitud" OnRowCommand="GV_Gestionar_Solicitud_Evento_RowCommand">
            <Columns>
              <asp:BoundField DataField="ID_Evento" HeaderText="ID SOLICITUD DE EVENTO" Visible="false" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="Cliente" HeaderText="CLIENTE" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="Descripcion_Tipo_Evento" HeaderText="TIPO DE EVENTO" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="Correo" HeaderText="CORREO" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="Celular" HeaderText="CELULAR" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="DNI" HeaderText="DNI" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="Fecha" HeaderText="FECHA" ItemStyle-HorizontalAlign="Center" />

              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Button ID="btn_Cancelar_Evento" runat="server" Text="CANCELAR EVENTO" class="btn btn-danger" CommandName="CANCELAR_EVENTO" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>

        <asp:Label ID="Label_ID_Evento" runat="server" Text="Label"></asp:Label>
      </div>
    </div>
  </section>

  <div class="modal fade" id="Modal_Advertencia_Eliminar_Evento_Organizado" role="dialog" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header" style="width: 500px; height: 300px; background-color: yellow">
          <!--<asp:Button ID="Button1" runat="server" Text="x" class="close" />
          -->
          <h4 class="modal-title"></h4>
          <div class="icon-box">
            <img src="../Imagenes/questions.png" style="width: 200px; height: 200px" />
            <br />
            <h4 style="color: black; font-size: xx-large">&nbsp;ADVERTENCIA!</h4>
          </div>
          <br>
        </div>
        <div class="modal-body align-content-center">
          <h5>ELIGE UNA OPCION</h5>
          <asp:Button ID="Button2" runat="server" Text="CANCELAR" class="btn btn-secondary" ForeColor="Black" UseSubmitBehavior="false" />
          <asp:Button ID="Button3" runat="server" Text="CANCELAR EVENTO" class="btn btn-danger" ForeColor="Black" OnClick="Eliminar_Evento_Organizado" UseSubmitBehavior="false" />
        </div>
      </div>
    </div>
  </div>

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
