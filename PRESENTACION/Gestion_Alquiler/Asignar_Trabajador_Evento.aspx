<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Asignar_Trabajador_Evento.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Asignar_Trabajador_Evento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../dist/css/gridview.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-12 p-3">
      <div id="DIV_Principal" runat="server">
        <h1>LISTA DE EVENTOS</h1>
        <br />
        <div align="center" class="p">
          <p>Debe de seleccionar un evento para asignar trabajador</p>
        </div>
        <br />
        <div>
          <asp:GridView ID="GV_Eventos" runat="server" HorizontalAlign="Center" EmptyDataText="No hay Eventos actualmente." DataKeyNames="ID_Evento" CssClass="gridview" HeaderStyle-BackColor="#6cacdc" AlternatingRowStyle-CssClass="even" AutoGenerateColumns="false" OnRowCommand="GV_Evento_RowCommand" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChangingGV_Eventos">
            <Columns>
              <asp:BoundField DataField="ID_Evento" HeaderText="ID EVENTO" Visible="false" />
              <asp:BoundField DataField="Descripcion_Tipo_Evento" HeaderText="TIPO DE EVENTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Cliente" HeaderText="NOMBRE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="DNI" HeaderText="DNI DEL CLIENTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Correo" HeaderText="CORREO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Celular" HeaderText="CELULAR" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Fecha" HeaderText="FECHA" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />

              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Button ID="btn_Asignar_Trabajador" runat="server" Text="ASIGNAR TRABAJADOR AL EVENTO" class="btn btn-primary" CommandName="ASIGNAR_TRABAJADOR_EVENTO" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
          <asp:Label ID="Label_ID_Evento" runat="server" Text="Label"></asp:Label>
          <asp:Label ID="Label_Fecha" runat="server" Text="Label"></asp:Label>
        </div>
      </div>

      <div runat="server" id="DIV_Tipo_Equipo">
        <h1 style="text-align: center">TIPO DE EQUIPOS SOLICITADOS PARA ESTE EVENTO</h1>
        <br />
        <div align="center">
          <asp:GridView ID="GV_TEAE" runat="server" HorizontalAlign="Center" EmptyDataText="Ya no hay mas servicios para asignados a este Evento." AutoGenerateColumns="false" HeaderStyle-BackColor="#6cacdc" DataKeyNames="ID_Tipo_Equipo" OnRowCommand="GV_TEAE_RowCommand">
            <Columns>
              <asp:BoundField DataField="ID_Tipo_Equipo" HeaderText="ID TIPO EQUIPO" Visible="false" />
              <asp:BoundField DataField="Descripcion_Tipo_Equipo" HeaderText="Tipo de Equipo Solicitado" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" />
              <asp:TemplateField>
                <ItemTemplate>
                  <asp:Button ID="btn_Mostrar_Trabajador" runat="server" Text="MOSTRAR TRABAJADOR" class="btn btn-primary" CommandName="MOSTRAR_TRABAJADOR" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
        <asp:Label ID="Label_ID_Tipo_Equipo" runat="server" Text="Label"></asp:Label>
      </div>
      <br />
      <div runat="server" id="DIV_Asignar_Trabajador_Evento">
        <h3 style="text-align: center">TRABAJADORES DISPONIBLES PARA EL EVENTO</h3>
        <br />
        <asp:GridView ID="GV_Trabajadores_Disponibles" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" EmptyDataText="No hay Trabajadores Disponibles para asignar a este Evento." HeaderStyle-BackColor="#6cacdc" DataKeyNames="ID_Trabajador, ID_Equipo" OnRowCommand="GV_Trabajadores_Disponibles_RowCommand">
          <Columns>
            <asp:BoundField DataField="ID_Trabajador" HeaderText="ID TRABAJADOR" Visible="false" />
            <asp:BoundField DataField="ID_Equipo" HeaderText="ID EQUIPO" Visible="false" />
            <asp:BoundField DataField="Trabajador" HeaderText="TRABAJADOR" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Codigo_Equipo" HeaderText="CODIGO DEL EQUIPO" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Precio_Equipo" HeaderText="PRECIO DE ALQUILER" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField>
              <ItemTemplate>
                <asp:Button ID="btn_Asignar_Trabajador_Evento" runat="server" Text="ASIGNAR TRABAJADOR" class="btn btn-primary" CommandName="ASIGNAR_TRABAJADOR_X_EVENTO" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
        <asp:Label ID="Label_ID_Trabajador" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label_ID_Equipo" runat="server" Text="Label"></asp:Label>
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
