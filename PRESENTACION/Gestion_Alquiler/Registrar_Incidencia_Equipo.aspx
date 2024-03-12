<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrar_Incidencia_Equipo.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Registrar_Incidencia_Equipo" EnableSessionState="True"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link href="../dist/css/gridview.css" rel="stylesheet">
  <style>
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
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-10 p-3">
        <h1>
          <asp:Label ID="LabelTitulo" runat="server"></asp:Label>
        </h1>

        <div id="datosEventoDIV" runat="server">
          <h3>Datos del Evento</h3>
          <div class="row" style="margin-top: 20px">
            <div class="col-md-3">
              <p>Descripcion Evento: 
                <asp:Label ID="lvlDescripcionEvento" runat="server"></asp:Label>
              </p>
            </div>
            <div class="col-md-3">
              <p>Cliente del evento: 
                <asp:Label ID="lvlCliente" runat="server"></asp:Label>
              </p>
            </div>
            <div class="col-md-3">
              <p>DNI: 
                <asp:Label ID="lvlDNI" runat="server"></asp:Label>
              </p>
            </div>
            <div class="col-md-3">
              <p>Correo: 
                <asp:Label ID="lvlCorreo" runat="server"></asp:Label>
              </p>
            </div>
            <div class="col-md-3">
              <p>Celular: 
                <asp:Label ID="lvlCelular" runat="server"></asp:Label>
              </p>
            </div>
            <div class="col-md-3">
              <p>Fecha del evento: 
                <asp:Label ID="lvlFecha" runat="server"></asp:Label>
              </p>              
            </div>
            <div class="col-md-3">
              <p>Estado del evento:
                <asp:Label ID="lvlEstadoEvento" runat="server"></asp:Label>
              </p>
            </div>
          </div>

        </div>

        <h3 style="margin-top: 20px">Datos de Incidencia</h3>
        <div class="row" style="margin-top: 20px">
          <div class="col-md-3">
            <p>Tipo de equipo:</p>
            <asp:DropDownList ID="DDL_Listar_Tipo_Equipos_Registro" runat="server" AutoPostBack="true" class="form-control" Style="width: 190px" OnSelectedIndexChanged="DDL_Listar_Tipo_Equipos_Registro_SelectedIndexChanged"></asp:DropDownList>
          </div>

          <div class="col-md-3">
            <p>Equipo:</p>
            <asp:DropDownList ID="DDL_Equipos_Incidencias_Registro" runat="server" AutoPostBack="true" Class="form-control" Style="width: 200px;"></asp:DropDownList>
          </div>

          <div class="col-md-3">
            <p>Estado de la incidencia:</p>
            <asp:DropDownList ID="DDL_Estados_Incidencias_Equipo_Registro" runat="server" AutoPostBack="true" Class="form-control" Style="width: 200px;"></asp:DropDownList>
          </div>
        </div>

        <div id="divFechas" class="row" style="margin-top: 20px" runat="server">
          <div class="col-md-3">
            <p>Fecha creacion: 
              <asp:Label ID="txtFechaCreacion" runat="server"></asp:Label>
            </p>
          </div>

          <div class="col-md-3">
            <p>Fecha resolucion:
              <asp:Label ID="txtFechaResolucion" runat="server"></asp:Label>
            </p>
          </div>
        </div>

        <div class="row" style="margin-top: 20px">
          <div class="col-md-6">
            <p>Descripcion:</p>
            <textarea ID="txtAreaDescripcion" cols="75" maxlength="200" runat="server"></textarea>
          </div>

          <div class="col-md-6">
            <p>Comentario:</p>
            <textarea ID="txtAreaComentario" cols="75" maxlength="200" runat="server"></textarea>
          </div>
        </div>
        
        <div class="row" style="margin-top: 20px">
          <div class="col-md-8"></div>
          <div class="col-md-4">
            <asp:Button ID="btn_Registrar_Editar" runat="server" Text="Registrar Nueva Incidencia" class="btn btn-primary" OnClick="btn_Registrar_Editar_Click" Style="margin-top: 40px;"/>
          </div>
        </div>



      <div id="divLogsIncidencias" runat="server">
        <h3>Historial de la incidencia</h3>

        <div id="divLogs" class="row" style="margin-top: 20px">
          <div class="col-md-1"></div>
          <div class="col-md-10">
            <asp:GridView ID="GV_Logs_Incidencias" runat="server" HorizontalAlign="Center" EmptyDataText="No hay registros de la incidencia." DataKeyNames="ID_Log_Equipo_Incidencia" HeaderStyle-BackColor="#6cacdc" CssClass="gridview" AlternatingRowStyle-CssClass="even" AutoGenerateColumns="false">
              <Columns>
                <asp:BoundField DataField="ID_Log_Equipo_Incidencia" HeaderText="ID_Log_Equipo_Incidencia" Visible="false" />
                <asp:BoundField DataField="Cambio" HeaderText="Cambio" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de modificacion" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Comentario" HeaderText="Comentario" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Estado" HeaderText="Estado registrado" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
              </Columns>
            </asp:GridView>
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


  <div class="modal fade" id="ModalIncidenciaModificada">
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
          <h5>INCIDENCIA DE EQUIPO REGISTRADA CORRECTAMENTE</h5>
        </div>
      </div>
    </div>
  </div>

</asp:Content>

