<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Asignar_Equipo_Trabajador.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Asignar_Equipo_Trabajador" %>

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


    .btn_Cancelar {
      font-size: 16px;
      font-weight: lighter;
      width: 240px;
      height: 60px
    }

    .btn_Asignar_Quitar_Equipo {
      font-size: 16px;
      font-weight: lighter;
      width: 340px;
      height: 60px
    }

    h1 {
      font-size: 40px;
      font-weight: bold;
      text-align: center;
    }

    .p {
      font-size: 22px;
    }
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-12 p-3">
      <div id="DIV_Lista_Trabajador" runat="server">
        <h1>LISTA DE TRABAJADORES</h1>
        <br />
        <div align="center" class="p">
          <p>Debe de seleccionar un trabajador</p>
        </div>
        <br />
        <asp:GridView ID="GV_Lista_Trabajadores" runat="server" HorizontalAlign="Center" EmptyDataText="No hay Trabajadores actualmente." DataKeyNames="ID_Trabajador" HeaderStyle-BackColor="#6cacdc" CssClass="gridview" AlternatingRowStyle-CssClass="even" AutoGenerateColumns="false" OnRowCommand="GV_LT_RowCommand">
          <Columns>
            <asp:BoundField DataField="ID_Trabajador" HeaderText="ID TRABAJADOR" Visible="false" />
            <asp:BoundField DataField="ID_Usuario" Visible="false" />
            <asp:BoundField DataField="Nombre_Apellidos" HeaderText="NOMBRE Y APELLIDOS" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="DNI" HeaderText="DNI" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Celular" HeaderText="CELULAR" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Correo" HeaderText="CORREO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Tipo_Equipo" HeaderText="TIPO DE EQUIPOS ASIGNADOS" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Button ID="btn_Revisar_Equipos_Asignados" runat="server" Text="REVISAR EQUIPOS" class="btn btn-primary" CommandName="REVISAR_EQUIPOS_ASIGNADOS" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Button ID="btn_Asignar_Equipo" runat="server" Text="GESTIONAR ASIGNACION" class="btn btn-primary" CommandName="AGREGAR_QUITAR_ASIGNACION" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
        <asp:Label ID="Label_id_List_Trabajadores" runat="server" Text="Label"></asp:Label>
      </div>

      <div id="DIV_Equipos_Asignados_Trabajador" runat="server">
        <h1>EQUIPOS ASIGNADOS</h1>
        <br /> 
        <br />

        <asp:DataList ID="DL_T_X_E_A" runat="server" DataKeyField="ID_ASIGNACION" RepeatColumns="2" RepeatDirection="Horizontal" HorizontalAlign="Center" Width="70%" CellPadding="4" CellSpacing="4" BackColor="White">
          <ItemTemplate>
            <div style="width: 400px;">
              <h3>
                <asp:Label ID="Label2" runat="server" Style="font-weight: bold" Text='<%# Eval("Descripcion_Tipo_Equipo") %>' /></h3>
              <h4>Codigo del equipo : 
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Codigo_Equipo") %>' /></h4>
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

      <div id="DIV_Asignar" runat="server">
        <div align="center">
          <h2>Seleccione si quiere agregar o quitar asignacion de equipo al trabajador.</h2>
          <br />
          <asp:Button ID="btn_Asignar_Tipo_Equipo" runat="server" Text="AGREGAR ASIGNACION DE EQUIPO" class="btn btn-primary btn_Asignar_Quitar_Equipo" OnClick="btn_Agregar_Asignacion_Equipo_Click" />
          <asp:Button ID="btn_Equipo_Tipo_Equipo" runat="server" Text="ELIMINAR ASIGNACION DE EQUIPO" class="btn btn-primary btn_Asignar_Quitar_Equipo" OnClick="btn_Quitar_Asignacion_Equipo_Click" />
        </div>
      </div>

      <div id="DIV_Agregar_Asignacion" runat="server">
        <div align="center">
          <br />
          <h3>Seleccione un tipo de equipo a agregar al trabajador:</h3>
          <asp:DropDownList ID="DDL_TEAT" runat="server" AutoPostBack="true" Class="form-control" Style="width: 200px;" OnSelectedIndexChanged="DDL_TEAT_SelectedIndexChanged"></asp:DropDownList>
        </div>
      </div>

      <div id="DIV_Quitar_Asignacion" runat="server">
        <div align="center">
          <br />
          <h3>Seleccione un tipo de equipo a eliminar al trabajador:</h3>
          <asp:DropDownList ID="DDL_TEQT" runat="server" AutoPostBack="true" Class="form-control" Style="width: 200px;" OnSelectedIndexChanged="DDL_TEQT_SelectedIndexChanged"></asp:DropDownList>
        </div>
      </div>

      <div id="DIV_Codigo_Equipo" runat="server">
        <div align="center">
          <br />
          <h3>Seleccione un codigo de equipo:</h3>
          <asp:DropDownList ID="DDL_Equipo_X_Codigo" runat="server" Class="form-control" Style="width: 200px;" AutoPostBack="true" OnSelectedIndexChanged="DDL_Equipo_X_Codigo_SelectedIndexChanged"></asp:DropDownList>
        </div>
      </div>

      <div id="DIV_Producto" runat="server">
        <br />
        <div align="center">
          <h3>Detalles del equipo seleccionado</h3>
        </div>
        <br />
        <div class="row">
          <div class="col-md-3"></div>
          <div class="col-md-3">
            <div align="left">
              <div class="form-group">
                Nombre Equipo :
              </div>
              <div class="form-group" id="cod_equipo" runat="server">
                Codigo del Equipo :
              </div>
              <div class="form-group">
                Marca del Equipo :
              </div>
              <div class="form-group">
                Precio del Equipo :
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div align="left">
              <div class="form-group">
                <asp:Label ID="txtNombre" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtCodigo" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtMarca" runat="server" />
              </div>
              <div class="form-group">
                <asp:Label ID="txtPrecio" runat="server" />
              </div>
            </div>
          </div>
          <div class="col-md-1"></div>
        </div>
        <br />
        <br />
        <div align="center">
          <asp:Image ID="Imagen" runat="server" Height="300px" Width="300px" />
        </div>
      </div>

      <div id="DIV_Agregar_Quitar_Asignacion_Equipo" runat="server">
        <br />
        <div align="center">
          <asp:Button ID="btnAtras" runat="server" Text="RETROCEDER" OnClick="btnAtras_Click" class="btn btn-secondary btn_Cancelar" Width="300px" />
          <asp:Button ID="btn_A_Asignacion" runat="server" Text="AGREGAR ASIGNACION DE EQUIPO" class="btn btn-primary btn_Asignar_Quitar_Equipo" Width="300px" OnClick="btn_A_Asignacion_Click" />
          <asp:Button ID="btn_Q_Asignacion" runat="server" Text="ELIMINAR ASIGNACION DE EQUIPO" class="btn btn-primary btn_Asignar_Quitar_Equipo" Width="300px" OnClick="btn_Q_Asignacion_Click" />
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

  <div class="modal fade" id="ModalAgregarTipoequipo">
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
          <h5>SE AGREGO LA ASIGNACION DE EQUIPO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade" id="ModalQuitarTipoequipo">
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
          <h5>SE QUITO ASIGNACION DE TIPO DE EQUIPO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade" id="Modal_Advertencia_Quitar_Asignacion_Tipo_Equipo" role="dialog" data-backdrop="static" data-keyboard="false">
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
          <h5>ELIGE UNA OPCION </h5>
          <asp:Button ID="Button2" runat="server" Text="CANCELAR" class="btn btn-secondary" ForeColor="Black" UseSubmitBehavior="false" />
          <asp:Button ID="Button3" runat="server" Text="ELIMINAR TIPO DE EQUIPO" class="btn btn-danger" ForeColor="Black" OnClick="Eliminar_Tipo_Equipo" UseSubmitBehavior="false" />
        </div>
      </div>
    </div>
  </div>
</asp:Content>
