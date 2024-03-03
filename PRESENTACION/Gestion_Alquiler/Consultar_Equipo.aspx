<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Consultar_Equipo.aspx.cs" Inherits="PRESENTACION.Gestion_de_Alquiler.Consultar_Equipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .modal-content {
      text-align: center;
    }

    h1 {
      font-size: 40px;
      font-weight: bold;
      text-align: center;
    }

    .btn_Consultar_Equipo {
      font-size: 20px;
      font-weight: lighter;
      width: 240px;
      height: 60px
    }

    .p {
      font-size: 22px;
    }
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-10 p-3">
      <div id="DIV_Consultar_Equipo" runat="server">

        <h1>CONSULTAR EQUIPO</h1>

        <div align="center">
          <div class="p">
            <p>Debe de seleccionar un tipo de equipo para poder visualizar y haga click en la imagen para ver mas detalles</p>
          </div>
          <asp:DropDownList ID="DDL_Listar_Tipo_Equipos" runat="server" OnSelectedIndexChanged="DDL_Listar_Tipo_Equipos_SelectedIndexChanged" AutoPostBack="true" Class="form-control" Height="38px" Width="200px"></asp:DropDownList>
          <br />
          <br />
        </div>
        <div>
          <asp:DataList ID="DataListEquipos" runat="server" DataKeyField="ID_Equipo" RepeatColumns="2" RepeatDirection="Horizontal" HorizontalAlign="Center" Width="70%"
            CellPadding="5" CellSpacing="5" BackColor="White" OnItemCommand="DataListEquipos_ItemCommand">
            <ItemTemplate>
              <div style="width: 460px;">
                <h3>
                  <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("Nombre_Equipo") %>' /></h3>

                <h4>Precio: S/.
                <asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Eval("Precio_Equipo") %>' /></h4>

                <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("Ruta") %>' />
              </div>
            </ItemTemplate>
            <FooterTemplate>
              <asp:Label Visible='<%#bool.Parse((DataListEquipos.Items.Count==0).ToString())%>' runat="server" ID="lblNoRecord" Text="No hay resultados que mostrar."></asp:Label>
            </FooterTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
          </asp:DataList>
        </div>
      </div>

      <div runat="server" id="DIV_Detalle_Equipo">
        <div style="text-align: center">
          <h1>EQUIPO SELECCIONADO</h1>
          <br />
          <h2>Detalles del equipo seleccionado</h2>
          <br />
          <br />
        </div>

        <div align="center">
          <asp:Image ID="Imagen" runat="server" Height="300px" Width="300px" />
        </div>
        <br />
        <br />
        <div class="row">
          <div class="col-md-4"></div>
          <div class="col-md-2">
            <div align="left">
              <div class="form-group">
                Codigo del Equipo :
              </div>
              <div class="form-group">
                Nombre Equipo :
              </div>
              <div class="form-group">
                Marca del Equipo :
              </div>
              <div class="form-group">
                Estado del Equipo :
              </div>
              <div class="form-group">
                Tipo del Equipo :
              </div>
              <div class="form-group">
                Precio del Equipo :
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div align="left">
              <div class="form-group">
                <asp:Label ID="txtCodigoEquipo" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtNombre" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtMarca" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtEstadoEquipo" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtTipoEquipo" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtPrecio" runat="server" />
              </div>
            </div>
          </div>
          <div class="col-md-1"></div>
        </div>
        <div align="center">
          <br />
          <asp:Button ID="btnAtras" runat="server" Text="RETROCEDER" OnClick="btnAtras_Click" CssClass="btn btn-secondary btn_Consultar_Equipo" />
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
