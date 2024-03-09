<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Gestionar_Incidencias_Equipo.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Gestionar_Incidencias_Equipo" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server"> </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    h1 {
      font-size: 40px;
      font-weight: bold;
      text-align: center;
    }

    .p {
      font-size: 22px;
    }
  </style>

  <section class="d-flex justify-content-center">
    <div class="card col-sm-11 p-3">

      <div id="DIV_Principal" runat="server">
        <h1>GESTIONAR INCIDENCIAS DE EQUIPOS</h1>
        <br />

        <div align="center" style="display:flex;">
          <label>Seleccione un tipo de equipo:</label>
          <asp:DropDownList ID="DDL_Listar_Tipo_Equipos" runat="server" AutoPostBack="true" class="form-control" Style="width: 190px; margin-left: 20px" OnSelectedIndexChanged="DDL_Listar_Tipo_Equipos_SelectedIndexChanged"></asp:DropDownList>

          <label style="margin-left:50px">Seleccione un equipo con incidencias:</label>
          <asp:DropDownList ID="DDL_Equipos_Incidencias" runat="server" AutoPostBack="true" Class="form-control" Style="width: 200px; margin-left: 20px;"></asp:DropDownList>

          <label style="margin-left:50px">Seleccione estado de la incidencia:</label>
          <asp:DropDownList ID="DDL_Estados_Incidencias_Equipo" runat="server" AutoPostBack="true" Class="form-control" Style="width: 200px; margin-left: 20px;"></asp:DropDownList>

          <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" class="btn btn-secondary" OnClick="btn_Buscar_Click" style="margin-left: 50px;"/>
          <asp:Button ID="btn_Registrar_GO" runat="server" Text="Registrar" class="btn btn-secondary" OnClick="btn_Registrar_GO_Click" style="margin-left: 50px;"/>
          <asp:Button ID="TEST" runat="server" Text="TEST" class="btn btn-secondary" OnClick="TEST_Click" Visible="false"/>
        </div>

        <div>
            <br />
            <br />
            <asp:GridView ID="GV_Incidencias_Equipos" runat="server" HorizontalAlign="Center" EmptyDataText="No hay incidencias con esos parametros." DataKeyNames="ID_Equipo_Incidencia" HeaderStyle-BackColor="#6cacdc" CssClass="gridview" AlternatingRowStyle-CssClass="even" AutoGenerateColumns="false" OnRowCommand="GV_Incidencias_Equipos_RowCommand">
              <Columns>
                <asp:BoundField DataField="ID_Equipo_Incidencia" HeaderText="ID_Equipo_Incidencia" Visible="false" />
                <asp:BoundField DataField="Codigo_Equipo" HeaderText="Codigo Equipo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Nombre_Equipo" HeaderText="Equipo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Fecha_creacion" HeaderText="Fecha de creacion" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="Fecha_resolucion" HeaderText="Fecha de resolucion" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />

                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                    <asp:Button ID="btn_Editar_GO" runat="server" Text="Editar" CommandName="EDITAR_INCIDENCIA" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" class="btn btn-primary"/>
                  </ItemTemplate>
                </asp:TemplateField>

              </Columns>
            </asp:GridView>
          </div>

      </div>

    </div>

  </section>

</asp:Content>
