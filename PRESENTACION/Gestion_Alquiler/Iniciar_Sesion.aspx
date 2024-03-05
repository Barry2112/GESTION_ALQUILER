<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Iniciar_Sesion.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Iniciar_Sesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

  <style>
    .content {
      background: #ecf0f5;
    }

    .modal-content {
      text-align: center;
    }

    .Sesion {
      position: absolute;
      top: 40%;
      left: 50%;
      transform: translateX(-50%) translateY(-50%);

      border-width: 4px;
      width: 660px;
      height: 546px;
      border: 3px solid black;
      border-radius: 22px;
      margin: 15px;
      padding: 69px;
    }

    h1 {
      font-weight: lighter;
      font-size: 75px;
    }

    .textbox {
      display: inline;
      width: 320px;
      height: 60px;
      outline: none;
      border: 1px solid rgba(0,0,0,0.5);
      font-family: Source Sans Pro;
      font-weight: lighter;
      font-size: 16px;
      margin-bottom: 12px;
      padding-left: 12px;
      border-radius: 5px;
      margin-left: 100px;
    }

    button {
      position: absolute;
      left: 340px;
      top: 242px;
    }

    .btnIniciarSesion {
      width: 120px;
      height: 50px;
      font-size: 16px;
      font-weight: lighter;
      margin-left: 108px;
    }

    .btnRegistrarUsuario {
      width: 180px;
      height: 50px;
      font-size: 16px;
      font-weight: lighter;
    }

    .btn_Ver_Contrasenia {
      width: 180px;
      height: 50px;
    }
  </style>


  <div class="Sesion" runat="server" id="Sesion">
    <div>
      <h1>INICIAR SESION</h1>
      <br />
      <br />
      <asp:TextBox ID="txt_email" runat="server" TextMode="Email" placeholder="Ingrese su correo" class="textbox"></asp:TextBox>
      <br />
      <div>
        <asp:TextBox ID="txt_password" runat="server" placeholder="Ingrese su password" class="textbox"></asp:TextBox>
        <asp:ImageButton ID="ImageButton_ShowPass" runat="server" OnClick="ImageButton_ShowPass_Click" ImageUrl="~/dist/img/eye.png" Height="30px" Width="30px" ImageAlign="AbsMiddle"/>
        <asp:ImageButton ID="ImageButton_HidePass" runat="server" OnClick="ImageButton_HidePass_Click" ImageUrl="~/dist/img/eye-hidden.png" Height="30px" Width="30px" ImageAlign="AbsMiddle"/>
      </div>

      <br />

      <asp:Button ID="btn_Iniciar_Sesion" runat="server" Text="INICIAR SESION" OnClick="btn_Iniciar_Sesion_Click" class="btnIniciarSesion" />
      <asp:Button ID="btn_Registrar_Usuario_Nuevo" runat="server" Text="REGISTRAR USUARIO" OnClick="btn_Registrar_Usuario_Nuevo_Click" class="btnRegistrarUsuario" />
    </div>
  </div>

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
</asp:Content>
