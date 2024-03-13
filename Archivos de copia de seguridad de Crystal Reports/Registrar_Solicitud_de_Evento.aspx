<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Registrar_Solicitud_de_Evento.aspx.cs" Inherits="PRESENTACION.Gestion_de_Alquiler.Registrar_Solicitud_de_Evento" %>

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

    .btn_Registrar_Solicitud_Evento {
      font-size: 20px;
      font-weight: lighter;
      width: 330px;
      height: 60px
    }
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-10 p-3">
      <div id="DIV_GestionarEquipo">
        <div class="mb-3">
          <h1>REGISTRAR SOLICITUD DE EVENTO</h1>
          <br />
          <br />

          <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-4">
              <div class="form-group">
                <label>Ingrese nombre del cliente:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtNombre" ErrorMessage="Este campo no admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Ingrese DNI del cliente:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtDNI" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtDNI" ErrorMessage="Este campo solo admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="[0-9]*">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Ingrese celular del cliente:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtCelular" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtCelular" ErrorMessage="Este campo solo admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="[0-9]*">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label id="label_direccion" runat="server">Ingrese direcci&#243n del cliente: </label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtdireccion" runat="server" class="form-control"></asp:TextBox>
              </div>  
              <div class="form-group">
                <label id="label_direccion_evento" runat="server">Ingrese direcci&#243n del evento: </label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtdireccion_evento" runat="server" class="form-control"></asp:TextBox>
              </div> 
            </div> 
            <div class="col-md-2"></div>
            <div class="col-md-4">
              <div class="form-group">
                <label>Ingrese su apellido:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtApellido" ErrorMessage="Este campo no admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Ingrese su correo</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtCorreo" ErrorMessage="Formato ejemplo: nombre@direcci&#243n.com"
                  ForeColor="Red"
                  ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Seleccione la fecha del Evento</label>
              </div>
              <div class="form-group">
                <input id="txtFechayHora" type="datetime-local" class="form-control" runat="server" />
              </div>
              <div class="form-group">
                <label>Seleccione el tipo del evento</label>
              </div>
              <div class="form-group">
                <asp:DropDownList ID="DDL_Tipo_Evento" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Tipo_Evento_SelectedIndexChanged" class="form-control"></asp:DropDownList>
              </div>
              <div id="pruebax" runat="server">
                <div class="form-group">
                  <label id="label_otro_evento" runat="server">Especifique el tipo de evento</label>
                </div>
                <div class="form-group">
                  <asp:TextBox ID="txt_otro_evento" runat="server" class="form-control"></asp:TextBox>
                </div>
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
              <div style="text-align: left">
                <label>Especifique alg&#250n detalle</label>
              </div>
              <div>
                <textarea id="txtdetalle" runat="server" class="form-control" style="height: 105px"></textarea>
              </div>
            </div>
            <div class="col-md-1"></div>
          </div>
          <br />
          <br />
          <div align="center">
            <asp:Button ID="btnEnviarSolicitud" runat="server" class="btn btn-primary btn_Registrar_Solicitud_Evento" Text="ENVIAR SOLICITUD DE EVENTO" ValidationGroup="VG_form" OnClick="btnEnviarSolicitud_Click" />
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
          <h5>SOLICITUD DE EVENTO REGISTRADO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
