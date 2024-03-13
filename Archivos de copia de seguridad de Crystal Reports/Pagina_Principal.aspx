<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pagina_Principal.aspx.cs" Inherits="PRESENTACION.Gestion_Alquiler.Pagina_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../dist/sb-admin-2/sb-admin-2.min.css" rel="stylesheet">
  <script type="text/javascript" src="../dist/sb-admin-2/jquery/jquery.js"></script>
  <!--script type="text/javascript" src="../dist/sb-admin-2/sb-admin-2.min.js"></!--script-->
  <script type="text/javascript" src="../dist/sb-admin-2/sb-admin-2.js"></script>
  <script type="text/javascript" src="../dist/sb-admin-2/chartjs/Chart.js"></script>

  <script type="text/javascript" language="javascript">
    /*function changeText1() {
        document.getElementById("lbl_header").innerText = 'Add New Teacher';
        document.getElementById("btn_Add").value = 'Add';
    }*/
    function cargarDatosEventos( tamaño ) {
      var ctx = document.getElementById("chartEventosPorTipo");
      var chartEventosPorTipo = new Chart(ctx, {
        type: 'doughnut',
        data: {
          labels: listaEventosTipo,
          datasets: [{
            data: listaEventosTipoCantidad,
            backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', '#a584ce', '#1e2f97', '#f1f5a8','#c5ebaa' ],
            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf', '#cea5f7', '#1aa7ec', '#e5e483','#a5dd9b' ],
            hoverBorderColor: "rgba(234, 236, 244, 1)"
          }],
        },
        options: {
          maintainAspectRatio: false,
          tooltips: {
            backgroundColor: "rgb(255,255,255)", bodyFontColor: "#858796", borderColor: '#dddfeb', borderWidth: 1, xPadding: 15, yPadding: 15, displayColors: true, caretPadding: 10
          },
          legend: {  display: true },
          cutoutPercentage: 80
        }
      });

      var ctx2 = document.getElementById("chartEventosPorEstado");
      var chartEventosPorEstado = new Chart(ctx2, {
        type: 'doughnut',
        data: {
          labels: listaEventosEstado,
          datasets: [{
            data: listaEventosEstadoCantidad,
            backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', '#a584ce', '#1e2f97', '#f1f5a8', '#c5ebaa'],
            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf', '#cea5f7', '#1aa7ec', '#e5e483', '#a5dd9b'],
            hoverBorderColor: "rgba(234, 236, 244, 1)"
          }],
        },
        options: {
          maintainAspectRatio: false,
          tooltips: {
            backgroundColor: "rgb(255,255,255)", bodyFontColor: "#858796", borderColor: '#dddfeb', borderWidth: 1, xPadding: 15, yPadding: 15, displayColors: true, caretPadding: 10
          },
          legend: { display: true },
          cutoutPercentage: 80,
        }
      });

      var ctx3 = document.getElementById("chartBarrasEventosPorAnio");
      var chartBarrasEventosPorAnio = new Chart(ctx3, {
        type: 'bar',
        data: {
          labels: listaEventosAnio,
          datasets: [{
            data: listaEventosAnioCantidad,
            label: "Año", backgroundColor: "#4e73df", hoverBackgroundColor: "#2e59d9", borderColor: "#4e73df"
          }]
        },
        options: {
          maintainAspectRatio: false,
          layout: {
            padding: { left: 10, right: 25, top: 25, bottom: 0 }
          },
          scales: {
            xAxes: [{
              gridLines: { display: true, drawBorder: true },
              maxBarThickness: 25,
            }],
            yAxes: [{
              ticks: {
                min: 0, max: tamaño, maxTicksLimit: 5, padding: 10
              },
              gridLines: {
                color: "rgb(234, 236, 244)", zeroLineColor: "rgb(234, 236, 244)", drawBorder: false, borderDash: [2], zeroLineBorderDash: [2]
              }
            }],
          },
          legend: { display: true },
          tooltips: {
            titleMarginBottom: 10, titleFontColor: '#6e707e', titleFontSize: 14, backgroundColor: "rgb(255,255,255)", bodyFontColor: "#858796",
            borderColor: '#dddfeb', borderWidth: 1, xPadding: 15, yPadding: 15, displayColors: false, caretPadding: 10,
          }
        }
      });
    }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <h2>Cotizaciones</h2>

  <div class="row mb-4">
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Cotizaciones creadas</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtCotizacionesCreadas" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Cotizaciones creadas (este mes)</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtCotizacionesCreadasMes" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Cotizaciones creadas (este año)</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtCotizacionesCreadasAnio" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <h2>Incidencias</h2>

  <div class="row mb-4">
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Incidencias registradas</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtIncidenciasCreadas" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Incidencias registradas (este mes)</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtIncidenciasCreadasMes" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Incidencias registradas (este año)</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtIncidenciasCreadasAnio" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <h2>Equipos</h2>

  <div class="row mb-4">
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Equipos registrados</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtEquiposRegistradosAnio" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <h2>Eventos</h2>

  <div class="row mb-4">
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Eventos registrados</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtEventosRegistrados" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Eventos registrados (este mes)</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtEventosRegistradosMes" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Eventos registrados (este año)</div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                <label id="txtEventosRegistradosAnio" runat="server"></label>
              </div>
            </div>
            <div class="col-auto">
              <i class="fas fa-calendar"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="row mb-4">
    <div class="col-md-3">
      <div class="card shadow mb-4">
        <div class="card-header py-3">
          <h6 class="m-0 font-weight-bold text-primary">Eventos por tipo</h6>
        </div>
        <div class="card-body">
          <div class="chart-pie pt-4">
            <canvas id="chartEventosPorTipo"></canvas>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3">
      <div class="card shadow mb-4">
        <div class="card-header py-3">
          <h6 class="m-0 font-weight-bold text-primary">Eventos por estado</h6>
        </div>
        <div class="card-body">
          <div class="chart-pie pt-4">
            <canvas id="chartEventosPorEstado"></canvas>
          </div>
        </div>
      </div>
    </div>

    <div class="col-md-3">
      <div class="card shadow mb-4">
        <div class="card-header py-3">
          <h6 class="m-0 font-weight-bold text-primary">Eventos por año</h6>
        </div>
        <div class="card-body">
          <div class="chart-pie pt-4">
            <canvas id="chartBarrasEventosPorAnio"></canvas>
          </div>
        </div>
      </div>
    </div>

  </div>



</asp:Content>
