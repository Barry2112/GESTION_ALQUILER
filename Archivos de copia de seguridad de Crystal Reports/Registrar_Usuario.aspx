<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrar_Usuario.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Registrar_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .content {
      background: #ecf0f5;
    }

    .modal-content {
      text-align: center;
    }

    .Sesion {
      position: absolute;
      top: 60%;
      left: 50%;
      transform: translateX(-50%) translateY(-92%);
      border-width: 4px;
      width: 1070px;
      border: 3px solid black;
      border-radius: 22px;
      margin: 15px;
      padding: 69px;
    }

    h1 {
      position: center;
      font-weight: lighter;
      font-size: 68px;
      margin-left: 200px;
      margin-top: -44px;
    }

    .textbox {
      display: block;
      outline: none;
      border: 1px solid rgba(0,0,0,0.5);
      font-family: Source Sans Pro;
      font-weight: lighter;
      font-size: 21px;
      padding-left: 12px;
      border-radius: 8px;
      width: 260px;
      height: 45px;
      margin-bottom: 10px;
      margin-top: 10px;
    }

    .btnRegistrarUsuario {
      position: absolute;
      width: 200px;
      height: 56px;
      font-size: 20px;
      font-weight: lighter;
      margin-left: 352px;
      margin-top: 28px;
    }
  </style>

  <div class="Sesion" runat="server" id="Sesion">
    <div>
      <h1>REGISTRAR USUARIO</h1>
      <br />
      <br />
      <div class="row">
        <div class="col-md-4">
          REGISTRE SU NOMBRE:
                    <asp:TextBox ID="txt_nombre" runat="server" class="textbox"></asp:TextBox>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ValidationGroup="VG_form" ControlToValidate="txt_nombre" ErrorMessage="Este campo no admite numeros"
            ForeColor="Red"
            ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
          </asp:RegularExpressionValidator>
        </div>
        <div class="col-md-4">
          REGISTRE SU APELLIDO:
                    <asp:TextBox ID="txt_apellido" runat="server" class="textbox"></asp:TextBox>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ValidationGroup="VG_form" ControlToValidate="txt_apellido" ErrorMessage="Este campo no admite numeros"
            ForeColor="Red"
            ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
          </asp:RegularExpressionValidator>
        </div>
        <div class="col-md-4">
          REGISTRE SU DNI:
                    <asp:TextBox ID="txt_dni" runat="server" class="textbox"></asp:TextBox>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
            ValidationGroup="VG_form" ControlToValidate="txt_dni" ErrorMessage="Este campo solo admite numeros"
            ForeColor="Red"
            ValidationExpression="[0-9]*">
          </asp:RegularExpressionValidator>
        </div>
        <div class="col-md-4">
          REGISTRE SU CELULAR:
                    <asp:TextBox ID="txt_celular" runat="server" class="textbox"></asp:TextBox>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
            ValidationGroup="VG_form" ControlToValidate="txt_celular" ErrorMessage="Este campo solo admite numeros"
            ForeColor="Red"
            ValidationExpression="[0-9]*">
          </asp:RegularExpressionValidator>
        </div>
        <div class="col-md-4">
          REGISTRE UNA DIRECCION:
          <asp:TextBox ID="txt_direccion" runat="server" class="textbox"></asp:TextBox>
        </div>
        <div class="col-md-4">
          REGISTRE SU CORREO:
                    <asp:TextBox ID="txt_correo" runat="server" class="textbox"></asp:TextBox>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
            ValidationGroup="VG_form" ControlToValidate="txt_correo" ErrorMessage="Debe cumplir este formato: correo@enlace"
            ForeColor="Red"
            ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">
          </asp:RegularExpressionValidator>
        </div>
        <div class="col-md-4">
          REGISTRE SU PASSWORD:
                    <asp:TextBox ID="txt_contra" runat="server" class="textbox" TextMode="Password"></asp:TextBox>
        </div>
        <div class="col-md-4">
          VUELVA INGRESAR SU PASSWORD:
                    <asp:TextBox ID="txt_contrase_validar" runat="server" class="textbox" TextMode="Password"></asp:TextBox>
        </div>
        <div class="col-md-4">
          REGISTRE SU IMAGEN DE USUARIO:
           <asp:FileUpload ID="FU_Imagen_Usuario" runat="server" Style="margin-top: 20px" />
        </div>
      </div>
    </div>

    <asp:Button ID="btn_Registrar_Usuario" runat="server" Text="REGISTRAR USUARIO" class="btnRegistrarUsuario" OnClick="btn_Registrar_Usuario_Click" ValidationGroup="VG_form" />
    <br />
    <br />

    <asp:Button ID="btn_Volver_Login" runat="server" Text="VOLVER A INICIAR SESION" OnClick="btn_Volver_Login_Click"/>
  </div>

  <br />

  <div class="modal fade" id="ModalError" role="dialog" style="margin-top: 46px; margin-left:98px">
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

  <div class="modal fade" id="ModalUsuarioRegistrado">
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
          <h5>USUARIO REGISTRADO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
