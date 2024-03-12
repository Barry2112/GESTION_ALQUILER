<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Reprogramar_Evento.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Reprogramar_Evento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../dist/css/gridview.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .btnopcion {
      font-size: 16px;
      font-weight: lighter;
    }
    .btn_Atender_Solicitud_Evento {
      font-size: 16px;
      font-weight: lighter;
      width: 240px;
      height: 60px
    }
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-11 p-3">
      <div id="DIV_Atender_Solicitud_de_Evento" runat="server">
        <div class="mb-3" style="text-align: center">
          <h1>REPROGRAMAR EVENTO</h1>
        </div>
        <br />

        <div align="center" style="display:flex;">
          <asp:TextBox ID="txt_fecha" runat="server" TextMode="Date" Width="200px"></asp:TextBox>
          <asp:DropDownList ID="DDL_Filtrar_X_Tipo_Evento" runat="server" AutoPostBack="true" Width="200px" class="form-control" style="margin-left: 50px;"></asp:DropDownList>
          <asp:Button ID="btnBuscarEventoProgramadoXTipoYFecha" runat="server" Text="BUSCAR" Width="200px" OnClick="btnBuscarEventoProgramadoXTipoYFecha_Click" class="btn btn-secondary" style="margin-left: 50px;" />
        </div>

        <div id="div_GV_Cargar_Solicitud_Eventos" runat="server">
          <br />
          <br />
          <asp:GridView ID="GV_Gestionar_Solicitud_Evento" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay solicitudes de evento actualmente." DataKeyNames="ID_Evento" HorizontalAlign="Center" HeaderStyle-BackColor="#6cacdc" class="gridview" AlternatingRowStyle-CssClass="even" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChangingRevisarSolicitud" OnRowCommand="GV_Gestionar_Solicitud_Evento_RowCommand">
            <Columns>
              <asp:BoundField DataField="ID_Evento" HeaderText="IDEVENTO" Visible="false" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="Cliente" HeaderText="CLIENTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Descripcion_Tipo_Evento" HeaderText="TIPO DE EVENTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="DNI" HeaderText="DNI" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Correo" HeaderText="CORREO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Celular" HeaderText="CELULAR" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Fecha" HeaderText="FECHA" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />

              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Button ID="btn_Revisar_Solicitud" runat="server" Text="REPROGRAMAR EVENTO" class="btn btn-primary" CommandName="REVISAR_SOLICITUD" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>

        <asp:Label ID="Label_ID_Evento" runat="server" Text="Label"></asp:Label>
      </div>

      <div id="DIV_REVISAR_SOLICITUD_EVENTO" runat="server">
        <div class="mb-3" style="text-align: center">
          <h2>REPROGRAMAR EVENTO</h2>
          <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-4">
              <div class="form-group">
                <label>Ingrese su nombre:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtNombre" ErrorMessage="Este campo no admite numeros"
                  ForeColor="Red"
                  ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Ingrese su DNI:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtDNI" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtDNI" ErrorMessage="Este campo solo admite numeros"
                  ForeColor="Red"
                  ValidationExpression="[0-9]*">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Ingrese su celular:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtCelular" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtCelular" ErrorMessage="Este campo solo admite numeros"
                  ForeColor="Red"
                  ValidationExpression="[0-9]*">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Seleccione su tipo de evento</label>
              </div>
              <div class="form-group">
                <asp:DropDownList ID="DDL_Tipo_Evento_Atender" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Tipo_Evento_Atender_SelectedIndexChanged" class="form-control"></asp:DropDownList>
              </div>
              <div id="pruebax" runat="server">
                <div class="form-group">
                  <label id="label_otro_evento" runat="server">Especifique su tipo de evento</label>
                </div>
                <div class="form-group">
                  <asp:TextBox ID="txt_otro_evento" runat="server" class="form-control"></asp:TextBox>
                </div>
              </div>
            </div>
            <div class="col-md-2"></div>
            <div class="col-md-4">
              <div class="form-group">
                <label>Ingrese su apellido:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtApellido" ErrorMessage="Este campo no admite numeros"
                  ForeColor="Red"
                  ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Ingrese su correo</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtCorreo" ErrorMessage="Formato ejemplo: nombre@direccion.com"
                  ForeColor="Red"
                  ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Seleccione la fecha de su Evento</label>
              </div>
              <div class="form-group">
                <input id="txtFechayHora" type="datetime-local" class="form-control" runat="server" />
              </div>
              <div class="form-group">
                <label id="label_direccion" runat="server">Ingrese direccion: </label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtdireccion" runat="server" Class="form-control"></asp:TextBox>
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
              <div style="text-align: left">
                <label>Especifique algun detalle</label>
              </div>
              <div>
                <textarea id="txtdetalle" runat="server" class="form-control"></textarea>
              </div>
            </div>
            <div class="col-md-1"></div>
          </div>
          <br />
          <div align="center">
            <asp:Button ID="btnAtras1" runat="server" Text="RETROCEDER" OnClick="btnAtras1_Click" class="btn btn-secondary" Width="300px" />

            <asp:Button ID="btn_Aceptar_Solicitud" runat="server" class="btn btn-primary" Width="300px" Text="REPROGRAMAR EVENTO" ValidationGroup="VG_form" OnClick="btnAceptarSolicitud_Click" />
          </div>
        </div>
      </div>
    </div>
  </section>

  <div class="modal fade" id="Modal_Advertencia_Reprogramar_Evento" role="dialog" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header" style="width: 500px; height: 300px; background-color: yellow">
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
          <asp:Button ID="Button2" runat="server" Text="CANCELAR" class="btn btn-secondary" ForeColor="Black" UseSubmitBehavior="false" />
          <asp:Button ID="Button3" runat="server" Text="REPROGRAMAR EVENTO" class="btn btn-danger" ForeColor="Black" OnClick="btn_Reprogramar_Evento" UseSubmitBehavior="false" />
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade" id="Modal_Evento_Reprogramado">
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
          <h5>EVENTO REPROGRAMADO CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>

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
