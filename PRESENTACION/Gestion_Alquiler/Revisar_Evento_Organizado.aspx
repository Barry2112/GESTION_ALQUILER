<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Revisar_Evento_Organizado.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Revisar_Evento_Organizado" %>

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

    .p {
      font-size: 22px;
    }

    .btn_Anexar_Acta {
      font-size: 20px;
      font-weight: lighter;
      width: 240px;
      height: 60px
    }
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-12 p-3">
      <div id="DIV_Principal" runat="server">
        <h1>EVENTOS ORGANIZADOS</h1>
        <br />
        <div align="center" class="p">
          <p>Debe de seleccionar un evento para revisar o anexar la acta de satisfacci&#243n</p>
        </div>
        <br />
        <asp:Label ID="Label_ID_Evento" runat="server" Text="Label"></asp:Label>
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
                  <asp:Button ID="btn_Revisar_Equipos_Asignados" runat="server" Text="REVISAR EQUIPOS ASIGNADOS" class="btn btn-primary" CommandName="REVISAR_EQUIPOS_ASIGNADOS" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Button ID="btn_Anexar" runat="server" Text="ANEXAR ACTA DE SATISFACCION" class="btn btn-primary" CommandName="ADJUNTAR_ACTA_EVENTO" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </div>


      <div id="DIV_Equipos_Asignados_Trabajador" runat="server">
        <h1>TRABAJADORES ASIGNADOS</h1>
        <br />
        <br />

        <asp:DataList ID="DL_T_X_E_A" runat="server" DataKeyField="ID_ASIGNACION" RepeatColumns="2" RepeatDirection="Horizontal" HorizontalAlign="Center" Width="70%" CellPadding="4" CellSpacing="4" BackColor="White">
          <ItemTemplate>
            <div style="width: 460px;">
              <h3>
                <asp:Label ID="Label2" runat="server" Style="font-weight: bold" Text='<%# Eval("Descripcion_Tipo_Equipo") %>' /></h3>
              <h4>Trabajador : 
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Trabajador") %>' /></h4>
              <h4>Codigo del equipo : 
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Codigo_Equipo") %>' /></h4>
              <h5>Nombre del equipo :
                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("Nombre_Equipo") %>' /></h5>
              <h5>Marca :
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Descripcion_Marca_Equipo") %>' /></h5>
              <h5>Precio de alquiler S/.
               
                <asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Eval("Precio_Equipo") %>' /></h5>
              <asp:ImageButton ID="ImageButton1" runat="server" Height="250px" Width="250px" ImageUrl='<%# Eval("Ruta") %>' />
              <br />
              <br />
            </div>
          </ItemTemplate>
          <FooterTemplate>
            <asp:Label Visible='<%#bool.Parse((DL_T_X_E_A.Items.Count==0).ToString())%>' runat="server" ID="lblNoRecord" Text="No hay equipos asignados a este trabajador."></asp:Label>
          </FooterTemplate>
          <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:DataList>
        <br />
        <br />
        <div align="center">
          <asp:Button ID="btn_Atras" runat="server" Text="VOLVER ATRAS" Class="btn btn-secondary" OnClick="btn_Atras_Click" />
        </div>
      </div>

      <div runat="server" id="DIV_ANEXAR">
        <h1>ANEXAR ACTA DE CONFORMIDAD</h1>
        <br />
        <br />
        <div align="center" class="p">
          <p>Generar acta de conformidad</p>
          <br />
          <br />
          <asp:Button ID="btn_Anexar_Acta" runat="server" Text="GENERAR ACTA DE CONFORMIDAD" class="btn btn-primary btn_Anexar_Acta" Width="300px" OnClick="btn_Anexar_Acta_Click" />
        </div>

        <br />
        <br />
        <div align="center" class="p">
          <p>Adjuntar acta de conformidad</p>
        </div>
        <br />
        <div style="text-align: center">
          <br /> 
          <asp:FileUpload ID="FU_Adjuntar_Acta" runat="server" />
           <br /><br />
           <asp:Button ID="btn_Adjuntar_Acta" runat="server" Text="ADJUNTAR ACTA DE CONFORMIDAD"
             class="btn btn-primary btn_Anexar_Acta" Width="300px" OnClick="btn_Adjuntar_Acta_Click" />
        </div>
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
