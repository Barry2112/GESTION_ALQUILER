<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Generar_Cotizacion.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Coti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
    .modal-content {
      text-align: center;
    }

    .btnopcion {
      font-size: 16px;
      font-weight: lighter;
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
  </style>

  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <script language="javascript" type="text/javascript">
    function show() {
      document.write("<head id="Head" runat='server'></head>");
    }
  </script>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-11 p-4">
      <h1 style="text-align: center">GENERAR COTIZACION</h1>

      <br />
      <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12">
          <asp:GridView ID="GV_Cotizacion" runat="server" AutoGenerateColumns="False" GridLines="None" class="gridview" HeaderStyle-BackColor="#6cacdc" AlternatingRowStyle-CssClass="even"
            OnRowCommand="GV_Cotizaccion_RowCommand">
            <Columns>
              <asp:BoundField DataField="n1" HeaderText="Item" Visible="false" />
              <asp:TemplateField HeaderText="Tipo_Equipo">
                <ItemTemplate>
                  <asp:DropDownList ID="DDL_Tipo_Equipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Tipo_Equipo_SelectedIndexChanged" Width="200px">
                  </asp:DropDownList>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                  <asp:DropDownList ID="DDL_Codigo_Equipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Codigo_Equipo_SelectedIndexChanged" Width="200px">
                  </asp:DropDownList>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Equipo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                <ItemTemplate>
                  <asp:TextBox ID="txt_Nombre_Equipo" runat="server" ReadOnly="true" Class="form-control"></asp:TextBox>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Marca">
                <ItemTemplate>
                  <asp:TextBox ID="txt_Marca_Equipo" runat="server" ReadOnly="true" Class="form-control" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center"></asp:TextBox>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                  <asp:TextBox ID="txt_Precio" runat="server" ReadOnly="true" Class="form-control" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center"></asp:TextBox>
                </ItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="Cantidad">
              <ItemTemplate>
                <asp:TextBox ID="txt_Cantidad" runat="server" Class="form-control" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" TextMode="Number" min="1" OnTextChanged="txt_Cantidad_TextChanged" AutoPostBack="true"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Sub-Total">
                <ItemTemplate>
                  <asp:TextBox ID="txt_Subtotal" runat="server" ReadOnly="true" Class="form-control" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center"></asp:TextBox>
                </ItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField>
                <ItemTemplate>
                  <asp:Button ID="btn_Borrar" runat="server" Text="Borrar" CommandName="Eliminar" class="btn btn-danger" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </div>

      <br />
      <br />

      <div id="posSUBTOTAL" class="row">
          <div class="col-sm-9"></div>
          <div class="col-sm-3">
            <div class="row">
            <div class="col-sm-6 text-right">SUBTOTAL (S/.):</div>
            <div class="col-sm-6 text-right">
              <asp:Label ID="LabelSUBTOTAL" runat="server" Text="LabelSUBTOTAL"></asp:Label>
            </div>
            </div>
          </div> 
      </div>

      <div id="posIGV" class="row">
        <div class="col-sm-9"></div>
        <div class="col-sm-3">
            <div class="row">
            <div class="col-sm-6 text-right">IGV 18% (S/.):</div>
            <div class="col-sm-6 text-right">
              <asp:Label ID="LabelIGV" runat="server" Text="LabelIGV"></asp:Label>
            </div>
            </div>
        </div>
      </div>

      <div id="posTOTAL" class="row">
        <div class="col-sm-9"></div>
        <div class="col-sm-3">
            <div class="row">
              <div class="col-sm-6 text-right">TOTAL (S/.):</div>
              <div class="col-sm-6 text-right">
                <asp:Label ID="LabelTOTAL" runat="server" Text="LabelTOTAL"></asp:Label>
              </div>
            </div>
        </div>          
      </div>

      <br />
      <br />
      <br />

      <div>
        <div class="row">
          <div class="col-md-1"></div>
          <div class="col-md-4">
            <asp:Button ID="btnAgregarRow" runat="server" Text="AGREGAR FILA" OnClick="btnAgregarRow_Click" CssClass="btn btn-secondary" />
          </div>
          <div class="col-md-3"></div>
          <div class="col-md-4">
            <asp:Button ID="btn_Generar_Cotizacion" runat="server" Text="GENERAR COTIZACION" OnClick="btnGenerarCotizacion_Click" CssClass="btn btn-primary" />
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


    <div class="modal fade" id="ModalGenerarCotizacionExitosa">
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
          <h5>GENERACION DE COTIZACION EXITOSA</h5>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
