<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listar_Cotizacion.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Listar_Cotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../dist/css/gridview.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .btnopcion {
      font-size: 16px;
      font-weight: lighter;
    }
  </style>

  <div class="container">
      <div class="modal fade" id="popupVerDetallesCotizacion" role="dialog">
        <div class="modal-dialog modal-dialog-centered" style="max-width: 30%;">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Detalles de la cotizacion</h4>
              <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
              <div class="row" style="margin-bottom:20px">
                <div class="col-md-6">
                  <label style="display:flex;">Nombre:</label>
                  <asp:TextBox runat="server" id="txtCotizacionSeleccionada" CssClass="form-control" Enabled="false"/>
                </div>
                <div class="col-md-6">
                  <label style="display:flex;">Fecha de la cotizacion:</label>
                  <asp:TextBox runat="server" id="txtCotizacionSeleccionadaFecha" CssClass="form-control" Enabled="false"/>
                </div>
              </div>
              <div class="row" style="margin-bottom:20px">
                <div class="col-md-4">
                  <label style="display:flex; margin-top:0.5rem;">Sub-Total:</label>
                  <asp:TextBox runat="server" id="txtCotizacionSeleccionadaSubtotal" CssClass="form-control" Enabled="false"/>
                </div>
                <div class="col-md-4">
                  <label style="display:flex; margin-top:0.5rem;">Sub-Total con IGV:</label>
                  <asp:TextBox runat="server" id="txtCotizacionSeleccionadaTotalIGV" CssClass="form-control" Enabled="false"/>
                </div>
                <div class="col-md-4">
                  <label style="display:flex; margin-top:0.5rem;">Total:</label>
                  <asp:TextBox runat="server" id="txtCotizacionSeleccionadaTotal" CssClass="form-control" Enabled="false"/>
                </div>
              </div>

              <asp:GridView ID="GV_Detalles_Cotizacion" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay items de la cotizacion seleccionada" HorizontalAlign="Center" HeaderStyle-BackColor="#6cacdc" class="gridview" AlternatingRowStyle-CssClass="even" AllowPaging="true" PageSize="100">
                <Columns>
                  <asp:BoundField DataField="Nombre_Equipo" HeaderText="Equipo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                  <asp:BoundField DataField="Descripcion_Tipo_Equipo" HeaderText="Tipo de equipo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center"/>
                  <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                  <asp:BoundField DataField="precio_unitario" HeaderText="Precio-unitario" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                  <asp:BoundField DataField="sub_total" HeaderText="Sub-total" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                </Columns>
              </asp:GridView>
            </div>
          </div>
        </div>
      </div>
    </div>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-10 p-3">
      <div id="DIV_Gestionar_Equipo" runat="server">
        <h1 style="text-align: center">LISTAR COTIZACIONES</h1>
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
            <asp:BoundField DataField="ID_COTIZACION" HeaderText="ID COTIZACION" Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="NOMBRE" HeaderText="COTIZACION" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="FECHA" HeaderText="FECHA" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center"/>
            <asp:BoundField DataField="sub_total" HeaderText="Sub-Total" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="total_IGV" HeaderText="Total-IGV" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />

            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Button ID="btn_Revisar_Solicitud" runat="server" Text="REVISAR" class="btn btn-secondary" CommandName="REVISAR_SOLICITUD" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                <asp:Button ID="btn_Ver_Detalles" runat="server" Text="DETALLES" class="btn btn-secondary" CommandName="VER_DETALLES" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
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



