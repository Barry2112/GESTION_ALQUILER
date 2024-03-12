<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reportar_Incidencia_Equipo.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Reportar_Incidencia_Equipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../dist/css/gridview.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .btn_Reportar_Incidencia_Equipo {
      font-size: 20px;
      font-weight: lighter;
      width: 340px;
      height: 60px
    }

    #center {
      text-align: center;
    }
  </style>
    
  <section class="d-flex justify-content-center">
    <div class="card col-sm-10 p-3">
      <div id="DIV_Reportar_Incidencia_Equipo" runat="server">
        <h1 style="text-align: center">REPORTAR INCIDENCIA EQUIPO</h1>
        <br />
        <br />
        <div class="row" style="margin-top: 20px">
          <div class="col-md-3">
          </div>
          <div class="col-md-2">
            <p>Seleccione el tipo de equipo:</p>
            <asp:DropDownList ID="DDL_Listar_Tipo_Equipos_Registro" runat="server" AutoPostBack="true" class="form-control" Style="width: 190px" OnSelectedIndexChanged="DDL_Listar_Tipo_Equipos_Registro_SelectedIndexChanged"></asp:DropDownList>
          </div>
          <div class="col-md-2">
          </div>
          <div class="col-md-3">
            <p>Seleccione el codigo de equipo:</p>
            <asp:DropDownList ID="DDL_Codigo_Equipos_Incidencia" runat="server" AutoPostBack="true" class="form-control" Style="width: 200px;" OnSelectedIndexChanged="DDL_Codigo_Equipos_Incidencia_SelectedIndexChanged"></asp:DropDownList>
          </div>
          <div class="col-md-2">
          </div>
        </div>
        <br />
        <br />

        <div id="DIV_DETALLES_EQUIPO" runat="server">
          <div class="row">
            <div class="col-md-4"></div> 
            <div class="col-md-4">
              <div align="center">
                <div class="form-group">
                  Codigo del equipo : 
            <asp:TextBox ID="txtCodigo_Equipo_Editar" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                  Nombre del equipo :  
              <asp:TextBox ID="txtNombre" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group" runat="server" id="DIV_txt_marca_equipo_editar">
                  Marca del equipo :  
              <asp:TextBox ID="txtmarca" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                  Precio del equipo :  
              <asp:TextBox ID="txtPrecio" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                  Trabajador asignado :
            <asp:TextBox ID="txtTrabajador" runat="server" Style="margin-top: 5px" class="form-control"></asp:TextBox>
                </div> 
              </div>
            </div>
          </div>
        </div>

        
      <asp:Label ID="label_ID_Trabajador" runat="server" Text="LabelIDEquipo"></asp:Label>
      </div>
      <br />
      <br />
      <div id="DIV_IMAGEN_EQUIPO" runat="server" style="text-align: center">
        <asp:Image ID="Image_Equipo_Editar" runat="server" alt="" Style="width: 300px" />
      </div>

      <br />
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
      <br />
      <div align="center">
        <asp:Button ID="btnRegistrarIncidencia" runat="server" class="btn btn-primary btn_Reportar_Incidencia_Equipo" Text="REGISTRAR INCIDENCIA DE EQUIPO" OnClick="btn_Registrar_Incidencia_Equipo_Click" />
      </div>
      <br />
      <br />
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

  <div class="modal fade" id="ModalIncidenciaRegistrado">
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
