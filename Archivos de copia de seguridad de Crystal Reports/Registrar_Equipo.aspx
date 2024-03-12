<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrar_Equipo.aspx.cs" Inherits="PRESENTACION.Gestion_de_Alquiler.Gestionar_Equipo" %>

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
    }

    label {
      padding-top: 20px;
      padding-bottom: 5px;
    }

    .btn_Registrar_Equipo {
      font-size: 20px;
      font-weight: lighter;
      width: 240px;
      height: 60px
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
    <div class="card col-sm-10 p-3">
      <div id="DIV_GestionarEquipo">
        <div class="mb-3" style="text-align: center">
          <h1>REGISTRAR EQUIPO</h1>
        </div>
        <div class="mb-2" style="margin: 25px">
          <div class="mb-2">
            <label>Seleccione un tipo de equipo:</label>
            <asp:DropDownList ID="ddl_tipo_equipo_reg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_tipo_equipo_reg_SelectedIndexChanged" class="form-control"></asp:DropDownList>
          </div>
          <div class="mb-2">
            <label>Ingrese codigo del equipo</label>
            <asp:TextBox ID="cod_equipo_reg" runat="server" class="form-control"></asp:TextBox>
          </div>
          <div class="mb-2">
            <label>Ingrese nombre del equipo</label>
            <asp:TextBox ID="nombe_equipo_reg" runat="server" class="form-control"></asp:TextBox>
          </div>
          <div class="mb-2">
            <label>Seleccione la marca del equipo</label>
            <asp:DropDownList ID="ddl_marca_reg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_marca_reg_SelectedIndexChanged" class="form-control"></asp:DropDownList>
          </div>
          <div class="mb-2" id="otro_marca_equipo" runat="server">
            <label for="nombre">Ingrese marca del equipo</label>
            <asp:TextBox ID="otro_marca_equipo_reg" runat="server" class="form-control"></asp:TextBox>
          </div>
          <div class="mb-2">
            <label for="nombre">Ingrese el precio del alquiler del equipo</label>
            <asp:TextBox ID="precio_reg" runat="server" class="form-control"></asp:TextBox>
          </div>
          <div class="mb-2">
            <label for="nombre">Seleccione imagen del equipo</label>
            <asp:FileUpload ID="FU_Equipo_Agregar" runat="server" onchange="filePreview(this)" />
          </div>
          <br />
          <div style="text-align: center">
            <div id="uploadForm">
              <asp:Image ID="image_equipo_agregar" runat="server" alt="" Style="width: 300px" />
            </div>
          </div>
          <br />
          <br />
          <div align="center">
            <asp:Button ID="btn_Equipo_Agregar" runat="server" Text="REGISTRAR EQUIPO" class="btn btn-primary btn_Registrar_Equipo" OnClick="btn_Equipo_Agregar_Click" />
          </div>
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

  <div class="modal fade" id="ModalEquipoRegistrado">
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
          <h5>EQUIPO REGISTRADO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
