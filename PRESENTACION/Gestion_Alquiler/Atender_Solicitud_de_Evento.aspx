<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Atender_Solicitud_de_Evento.aspx.cs" Inherits="PRESENTACION.Gestion_de_Alquiler.Atender_Solicitud_de_Evento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../dist/css/gridview.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .btnopcion {
      font-size: 16px;
      font-weight: lighter;
    }

    .btn_Atras {
      font-size: 16px;
      font-weight: lighter;
      width: 240px;
      height: 60px
    }

    .btn_Filtrar_Tipo_Evento {
      font-size: 16px;
      font-weight: lighter;
      width: 340px;
      height: 60px
    }

    .btn_Revisar_Solicitud_Evento {
      font-size: 16px;
      font-weight: lighter;
      width: 280px;
      height: 60px
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
        <div class="mb-3">
          <h1>ATENDER SOLICITUD DE EVENTO</h1>
        </div>
        <br />

        <div align="center" style="display:flex;">
          <asp:TextBox ID="txt_fecha" runat="server" TextMode="Date" Width="200px"></asp:TextBox>          
          <asp:DropDownList ID="DDL_Filtrar_X_Tipo_Evento" runat="server" AutoPostBack="true" Width="200px" class="form-control" style="margin-left: 50px;"></asp:DropDownList>
          <asp:Button ID="btn_Buscar_Evento_X_FechaYTipo" runat="server" Text="BUSCAR" Width="200px" OnClick="btn_Buscar_Evento_X_FechaYTipo_Click" class="btn btn-secondary" style="margin-left: 50px;"/>
        </div>

        <div id="div_GV_Cargar_Solicitud_Eventos" runat="server">
          <br />
          <br />
          <asp:GridView ID="GV_Gestionar_Solicitud_Evento" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay solicitudes de evento actualmente." DataKeyNames="ID_Evento" HorizontalAlign="Center" HeaderStyle-BackColor="#6cacdc" class="gridview" AlternatingRowStyle-CssClass="even" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChangingRevisarSolicitud" OnRowCommand="GV_Gestionar_Solicitud_Evento_RowCommand">
            <Columns>
              <asp:BoundField DataField="ID_Evento" HeaderText="ID SOLICITUD DE EVENTO" Visible="false" />
              <asp:BoundField DataField="Cliente" HeaderText="CLIENTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Descripcion_Tipo_Evento" HeaderText="TIPO DE EVENTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Correo" HeaderText="CORREO" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Celular" HeaderText="CELULAR" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="DNI" HeaderText="DNI" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              <asp:BoundField DataField="Fecha" HeaderText="FECHA" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />

              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Button ID="btn_Revisar_Solicitud" runat="server" Text="REVISAR" class="btn btn-primary" CommandName="REVISAR_SOLICITUD" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>

              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Button ID="btn_Atender_Solicitud" runat="server" Text="ATENDER" class="btn btn-primary" CommandName="ATENDER_SOLICITUD" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>

        <asp:Label ID="Label_ID_Evento" runat="server" Text="Label"></asp:Label>
      </div>

      <div id="DIV_REVISAR_SOLICITUD_EVENTO" runat="server">
        <div class="mb-3" style="text-align: center">
          <h1>REVISAR SOLICITUD DE EVENTO</h1>
          <br />
          <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-4">
              <div class="form-group">
                <label>Nombre del cliente:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtNombre" ErrorMessage="Este campo no admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>DNI del cliente:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtDNI" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtDNI" ErrorMessage="Este campo solo admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="[0-9]*">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Celular del cliente:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtCelular" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtCelular" ErrorMessage="Este campo solo admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="[0-9]*">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Tipo de evento del cliente</label>
              </div>
              <div class="form-group">
                <asp:DropDownList ID="DDL_Tipo_Evento_Atender" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Tipo_Evento_Atender_SelectedIndexChanged" class="form-control"></asp:DropDownList>
              </div>
              <div id="pruebax" runat="server">
                <div class="form-group">
                  <label id="label_otro_evento" runat="server">Tipo de evento</label>
                </div>
                <div class="form-group">
                  <asp:TextBox ID="txt_otro_evento" runat="server" class="form-control"></asp:TextBox>
                </div>
              </div>
            </div>
            <div class="col-md-2"></div>
            <div class="col-md-4">
              <div class="form-group">
                <label>Apellido del cliente:</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtApellido" ErrorMessage="Este campo no admite n&#250meros"
                  ForeColor="Red"
                  ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Correo del cliente</label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                  ValidationGroup="VG_form" ControlToValidate="txtCorreo" ErrorMessage="Formato ejemplo: nombre@direcci&#243n.com"
                  ForeColor="Red"
                  ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">
                </asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label>Fecha del Evento</label>
              </div>
              <div class="form-group">
                <input id="txtFechayHora" type="datetime-local" class="form-control" runat="server" />
              </div>
              <br />
              <div class="form-group">
                <label id="label_direccion" runat="server">Direcci&#243n del cliente: </label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtdireccion" runat="server" Class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label id="label1" runat="server">Direcci&#243n del evento: </label>
              </div>
              <div class="form-group">
                <asp:TextBox ID="txtdireccion_evento" runat="server" Class="form-control"></asp:TextBox>
              </div>
            </div>
          </div>
          <br />
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
          <div align="center">
            <asp:Button ID="btnAtras1" runat="server" Text="RETROCEDER" OnClick="btnAtras1_Click" class="btn btn-secondary btn_Atras" />
            <asp:Button ID="btn_Aceptar_Solicitud" runat="server" class="btn btn-primary btn_Revisar_Solicitud_Evento" Text="EDITAR SOLICITUD DE EVENTO" ValidationGroup="VG_form" OnClick="btnAceptarSolicitud_Click" />
          </div>
        </div>
      </div>

      <div id="DIV_ATENDER_SOLICITUD_EVENTO" runat="server">
        <div class="mb-3" style="text-align: center">
          <h1>ATENDER SOLICITUD DE EVENTO</h1>
        </div>
        <br />
        <br />
        <div class="row">
          <div class="col-md-2">
          </div>
          <div class="col-md-4">
            <label>Elegir cantidad de camara filmadora a contratar:</label>
          </div>
          <div class="col-md-1">
          </div>
          <div class="col-md-2">
            <asp:TextBox ID="txtcantcamarafilmadora" runat="server" min="1" max="2" Text="0" Class="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
              ControlToValidate="txtcantcamarafilmadora" runat="server"
              ValidationGroup="VG_form2" ForeColor="Red"
              ErrorMessage="Este campo solo admite n&#250meros"
              ValidationExpression="[0-9]*">
            </asp:RegularExpressionValidator>
          </div>
          <div class="col-md-3">
          </div>

          <div class="col-md-2">
          </div>
          <div class="col-md-4">
            <label>Elegir cantidad de camara fotografica a contratar:</label>
          </div>
          <div class="col-md-1">
          </div>
          <div class="col-md-2">
            <asp:TextBox ID="txtcantcamarafotografica" runat="server" min="0" max="2" Text="0" Class="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
              ControlToValidate="txtcantcamarafotografica" runat="server"
              ValidationGroup="VG_form2" ForeColor="Red"
              ErrorMessage="Este campo solo admite n&#250meros"
              ValidationExpression="[0-9]*">
            </asp:RegularExpressionValidator>
          </div>
          <div class="col-md-3">
          </div>

          <div class="col-md-2">
          </div>
          <div class="col-md-4">
            <label>Elegir cantidad de consola de sonido a contratar:</label>
          </div>
          <div class="col-md-1">
          </div>
          <div class="col-md-2">
            <asp:TextBox ID="txtcantconsolasonido" runat="server" min="0" max="1" Text="0" Class="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
              ControlToValidate="txtcantconsolasonido" runat="server"
              ValidationGroup="VG_form2" ForeColor="Red"
              ErrorMessage="Este campo solo admite n&#250meros"
              ValidationExpression="[0-9]*">
            </asp:RegularExpressionValidator>
          </div>
          <div class="col-md-3">
          </div>

          <div class="col-md-2">
          </div>
          <div class="col-md-4">
            <label>Elegir cantidad de parlantes a contratar:</label>
          </div>
          <div class="col-md-1">
          </div>
          <div class="col-md-2">
            <asp:TextBox ID="txtcantparlantes" runat="server" min="0" max="4" Text="0" Class="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
              ControlToValidate="txtcantparlantes" runat="server"
              ValidationGroup="VG_form2" ForeColor="Red"
              ErrorMessage="Este campo solo admite n&#250meros"
              ValidationExpression="[0-9]*">
            </asp:RegularExpressionValidator>
          </div>
          <div class="col-md-3">
          </div>

          <div class="col-md-2">
          </div>
          <div class="col-md-4">
            <label>Eliga cantidad de cabeza moviles a contratar:</label>
          </div>
          <div class="col-md-1">
          </div>
          <div class="col-md-2">
            <asp:TextBox ID="txtcantcabezamoviles" runat="server" min="0" max="4" Text="0" Class="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
              ControlToValidate="txtcantcabezamoviles" runat="server"
              ValidationGroup="VG_form2" ForeColor="Red"
              ErrorMessage="Este campo solo admite n&#250meros"
              ValidationExpression="[0-9]*">
            </asp:RegularExpressionValidator>
          </div>
          <div class="col-md-3">
          </div>

          <div class="col-md-2">
          </div>
          <div class="col-md-4">
            <label>Eliga cantidad de proyectores a contratar:</label>
          </div>
          <div class="col-md-1">
          </div>
          <div class="col-md-2">
            <asp:TextBox ID="txtcantproyectores" runat="server" Text="0" Class="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6"
              ControlToValidate="txtcantproyectores" runat="server"
              ValidationGroup="VG_form2" ForeColor="Red"
              ErrorMessage="Este campo solo admite n&#250meros"
              ValidationExpression="[0-9]*">
            </asp:RegularExpressionValidator>
          </div>
          <div class="col-md-3">
          </div>

          <div class="col-md-2">
          </div>
          <div class="col-md-4">
            <label>Eliga cantidad iluminacion LED a contratar:</label>
          </div>
          <div class="col-md-1">
          </div>
          <div class="col-md-2">
            <asp:TextBox ID="txtcantiluminacionled" runat="server" min="0" max="2" Class="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
              ControlToValidate="txtcantiluminacionled" runat="server"
              ValidationGroup="VG_form2" ForeColor="Red"
              ErrorMessage="Este campo solo admite n&#250meros"
              ValidationExpression="[0-9]*">
            </asp:RegularExpressionValidator>
          </div>
          <div class="col-md-3">
          </div>
        </div>

        <br />
        <br />
        <div align="center">
          <asp:Button ID="btnAtras2" runat="server" Text="RETROCEDER" OnClick="btnAtras2_Click" class="btn btn-secondary btn_Atender_Solicitud_Evento" />
          <asp:Button ID="btnAtender" runat="server" class="btn btn-primary btn_Filtrar_Tipo_Evento" Text="ATENDER SOLICITUD DE EVENTO" ValidationGroup="VG_form2" OnClick="btnAtenderSolicitud_Click" />
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

  <div class="modal fade" id="ModalEventoRevisado">
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
          <h5>EVENTO EDITADO</h5>
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade" id="ModalEventoAtendido">
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
          <h5>EVENTO ATENDIDO</h5>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
