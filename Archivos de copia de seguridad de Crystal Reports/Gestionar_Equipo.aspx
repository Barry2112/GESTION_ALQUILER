<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Gestionar_Equipo.aspx.cs" Inherits="PRESENTACION.Gestion_de_Alquiler.Gestionar_Equipo1" %>

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

    .btn_Gestionar_Equipo {
      font-size: 20px;
      font-weight: lighter;
      width: 240px;
      height: 60px
    }

    .p {
      font-size: 22px;
    }
  </style>

  <script>
    function filePreview(input) {
      if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
          $('#uploadForm + image_equipo_agregar').remove();
          $('#uploadForm').after('<img src="' + e.target.result + '" width="450" height="300"/>');
        }
        reader.readAsDataURL(input.files[0]);
      }
    }
  </script>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-12 p-3">
      <div id="DIV_Gestionar_Equipo" runat="server">
        <h1 style="text-align: center">EDITAR EQUIPO</h1>
        <div align="center" class="p">
          <p>Debe de seleccionar un tipo de equipo para poder editarlo</p>
          <asp:DropDownList ID="DDL_Listar_Tipo_Equipos" runat="server" OnSelectedIndexChanged="DDL_Listar_Tipo_Equipos_SelectedIndexChanged" AutoPostBack="true" class="form-control" Style="width: 190px"></asp:DropDownList>
        </div>
      </div>

      <asp:Label ID="labelNameEquipo" runat="server" Text="LabelIDEquipo"></asp:Label>
      <asp:Label ID="labelIDEquipo" runat="server" Text="LabelIDEquipo"></asp:Label>
      <asp:Label ID="labelRutaImagenEquipo" runat="server" Text="LabelIDEquipo"></asp:Label>
      <div id="DIV_Detalles_Equipo" runat="server">
        <br />
        <br />
        <asp:GridView ID="GV_Mostrar_Equipos_X_Tipo" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay Equipos de este Tipo Actualmente." DataKeyNames="ID_Equipo" HeaderStyle-BackColor="#6cacdc" OnRowCommand="GV_Mostrar_Equipos_X_Tipo_RowCommand" CssClass="gridview" AlternatingRowStyle-CssClass="even">
          <Columns>
            <asp:BoundField DataField="ID_Equipo" HeaderText="ID Equipo" Visible="false" />
            <asp:BoundField DataField="Codigo_Equipo" HeaderText="CODIGO DEL EQUIPO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Nombre_Equipo" HeaderText="NOMBRE DEL EQUIPO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Precio_Equipo" HeaderText="PRECIO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:BoundField DataField="Descripcion_Marca_Equipo" HeaderText="MARCA" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <asp:Button ID="btn_Editar_Equipo_GV" runat="server" Text="EDITAR EQUIPO" class="btn btn-primary" CommandName="EDITAR_EQUIPO" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
              </ItemTemplate>
            </asp:TemplateField> 
          </Columns>
        </asp:GridView>
      </div>

      <div id="DIV_Editar_Equipo" runat="server">
        <h1 style="text-align: center">EDITAR EQUIPO</h1>
        <br />
        <div class="row">
          <div class="col-md-3"></div>
          <div class="col-md-3">
            <div align="left">
              <div class="form-group">
                <label style="margin: 7px; padding-top: 2px">Tipo de equipo:</label>
              </div>
              <div class="form-group">
                <label style="margin: 7px; padding-top: 2px">Codigo del equipo:</label>
              </div>
              <div class="form-group">
                <label style="margin: 7px;">Nombre del equipo:</label>
              </div>
              <div class="form-group">
                <label style="margin: 7px;">Marca del equipo:</label>
              </div>
              <div id="DIV_marca_equipo_editar" runat="server">
                <div class="form-group">
                  <label style="margin: 7px;">Ingrese marca del equipo:</label>
                </div>
              </div>
              <div class="form-group">
                <label style="margin: 7px; padding-top: 20px">Precio del equipo:</label>
              </div>
            </div>
          </div>

          <div class="col-md-3">
            <div class="form-group">
              <asp:DropDownList ID="DDL_Tipo_Equipo_Editar" runat="server" Style="margin-top: 5px" AutoPostBack="true" OnSelectedIndexChanged="DDL_Tipo_Equipo_Editar_SelectedIndexChanged" class="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
              <asp:TextBox ID="txtCodigo_Equipo_Editar" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
              <asp:TextBox ID="txtNombre_Editar" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
              <asp:DropDownList ID="DDL_Marca_Editar" runat="server" Style="margin-top: 5px" AutoPostBack="true" OnSelectedIndexChanged="DDL_Marca_Editar_SelectedIndexChanged" class="form-control"></asp:DropDownList><br />
            </div>
            <div class="form-group" runat="server" id="DIV_txt_marca_equipo_editar">
              <asp:TextBox ID="txtmarca_editar" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
              <asp:TextBox ID="txtPrecio_Editar" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
            </div>
          </div>
        </div>
        <div style="text-align: center">
          <br />
          <label for="nombre">Seleccione imagen del equipo</label>
          <asp:FileUpload ID="FU_Equipo_Editar" runat="server" onchange="filePreview(this)" />
        </div>
        <br />
        <br />
        <div style="text-align: center">
          <div id="uploadForm">
            <asp:Image ID="Image_Equipo_Editar" runat="server" alt="" Style="width: 300px" />
          </div>
          <br />
          <br />
        </div>
        <div align="center">
          <asp:Button ID="btnAtras" runat="server" Text="RETROCEDER" OnClick="btnAtras_Click" class="btn btn-secondary btn_Gestionar_Equipo" Width="300px" />
          <asp:Button ID="btn_Editar_Equipo" runat="server" Text="EDITAR EQUIPO" class="btn btn-primary btn_Gestionar_Equipo" Width="300px" OnClick="btn_Editar_Equipo_Click" />
          <br />
          <br />
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
          <h5>EQUIPO EDITADO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade" id="Modal_Advertencia_Eliminar_Equipo" role="dialog" data-backdrop="static" data-keyboard="false">
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
          <asp:Button ID="Button2" runat="server" Text="CANCELAR" class="btn btn-secondarybtn_Gestionar_Equipo" ForeColor="Black" UseSubmitBehavior="false" />
          <asp:Button ID="Button3" runat="server" Text="ELIMINAR EQUIPO" class="btn btn-danger btn_Gestionar_Equipo" ForeColor="Black" OnClick="Eliminar_Equipo" UseSubmitBehavior="false" />
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade" id="Modal_Equipo_Elimindado">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header" style="width: 500px; height: 300px; background-color: green">
          <h4 class="modal-title"></h4>
          <div class="icon-box">
            <img src="../Imagenes/check.png" style="width: 200px; height: 200px" />
            <br />
            <h4 style="color: white; font-size: xx-large">&nbsp;EXITO!</h4>
          </div>
          <br>
        </div>
        <div class="modal-body align-content-center">
          <h5>
            <asp:Label ID="label_tipo_equipo_eliminar" runat="server" Text="Label"></asp:Label>
            ELIMINADO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
