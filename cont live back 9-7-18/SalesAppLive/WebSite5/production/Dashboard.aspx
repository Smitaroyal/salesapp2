<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="WebSite5_production_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <style>
        #img {
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

        #h1, #h2, #h3, #h4, #h5, #h6, #h7, #h8, #h9,#h10,#h11,#h12,#topPro,#topPro1 {
            text-align: center;
        }

        #topPro,#topPro1{
            float:none;
        }

        #count1, #count2, #count3, #count4, #count5, #count6,#count7,#count8 {
            text-align: center;
        }


        #head,#directory{
             display:none;
         }

           #success-alert,#danger-alert,#danger-alert1{
            display:none;
        }
         

            body {
        color: #566787;
		background: #f5f5f5;
		font-family: 'Varela Round', sans-serif;
		font-size: 13px;
	}
	
  

	
   
    .hint-text {
        float: left;
        margin-top: 10px;
        font-size: 13px;
    }    
	/* Custom checkbox */
	
	/* Modal styles */
	.modal .modal-dialog {
		max-width: 400px;
	}
	.modal .modal-header, .modal .modal-body, .modal .modal-footer {
		padding: 20px 30px;
	}
	.modal .modal-content {
		border-radius: 3px;
	}
	.modal .modal-footer {
		background: #ecf0f1;
		border-radius: 0 0 3px 3px;
	}
    .modal .modal-title {
        display: inline-block;
    }
	.modal .form-control {
		border-radius: 2px;
		box-shadow: none;
		border-color: #dddddd;
	}
	.modal textarea.form-control {
		resize: vertical;
	}
	.modal .btn {
		border-radius: 2px;
		min-width: 100px;
	}	
	.modal form label {
		font-weight: normal;
	}	
        
    </style>
    <title>Contract App </title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
   
    <!-- iCheck -->
     
	
    <!-- bootstrap-progressbar -->
   
    <!-- JQVMap -->
    <link href="../vendors/jqvmap/dist/jqvmap.min.css" rel="stylesheet" />
    <!-- bootstrap-daterangepicker -->


    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
</head>
<body class="nav-md">
    <div class="container body">
        <div class="main_container">
            <div class="col-md-3 left_col">
                <div class="left_col scroll-view">
                    <div class="navbar nav_title" style="border-bottom: 2px; height: auto; color: #172D44;" id="img">

                        <img src="../production/images/k.png" class="img-square" alt="" width="40" height="40" />
                        <br />
                        <a href="" class="site_title"><span style="opacity: 0.5;">Karma Group</span></a>
                    </div>

                    <div class="clearfix"></div>

                    <!-- menu profile quick info -->
                    <div class="profile clearfix">

                        <div class="profile_pic">
                            <img src="images/img.jpg" alt="..." class="img-circle profile_img">
                        </div>
                        <div class="profile_info">
                            <span>Welcome,</span>
                            <h2>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2>
                        </div>
                    </div>
                    <!-- /menu profile quick info -->

                    <br />

                    <!-- sidebar menu -->
                    <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
                        <div class="menu_section">

                            <h3>General</h3>
                            <ul class="nav side-menu">
                                <% Response.Write(getdata()); %>
                            </ul>
                        </div>


                    </div>
                    <!-- /sidebar menu -->

                    <!-- /menu footer buttons -->
                    <div class="sidebar-footer hidden-small">
                  <a data-toggle="tooltip" data-placement="top" title="Settings">
                      <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
                  </a>
                  <a data-toggle="tooltip" data-placement="top" title="FullScreen">
                      <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
                  </a>
                  <a data-toggle="tooltip" data-placement="top" title="Home" href="Dashboard.aspx">
                      <span class="glyphicon glyphicon-home" aria-hidden="true"></span>
                  </a>

                  <a data-toggle="tooltip" data-placement="top" title="Logout" href="logout.aspx">
                      <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
                  </a>
              </div>
              <!-- /menu footer buttons -->
          </div>
        </div>

          <!-- top navigation -->
          <div class="top_nav">
              <div class="nav_menu">
                  <nav>
                      <div class="nav toggle">
                          <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                      </div>

                      <ul class="nav navbar-nav navbar-right">
                          <li class="">
                              <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                  <img src="images/img.jpg" alt=""/><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                  <span class=" fa fa-angle-down"></span>
                              </a>
                              <ul class="dropdown-menu dropdown-usermenu pull-right">
                                  <li><a href="Profile_Page.aspx">Change Password</a></li>

                                  <li><a href="#addEmployeeModal" data-toggle="modal">Setting</a></li>
                                  <li><a href="logout.aspx"><i class="fa fa-sign-out pull-right"></i>Log Out</a></li>
                              </ul>
                          </li>


                      </ul>
                  </nav>
              </div>
        </div>
          <!-- /top navigation -->

          <!-- page content -->
          <div class="right_col" role="main">
              <div class="">
                  <div class="row top_tiles">
                      <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
                          <div class="tile-stats">

                              <div class="row">
                                  <div class="col-md-6 col-sm-6 col-xs-6">
                                      <h4 id="h1">INDIA</h4>
                                      <div class="count" id="count1"><%Response.Write(getSignUps()); %></div>
                                  </div>
                                  <div class="col-md-6 col-sm-6 col-xs-6">
                                      <h4 id="h2">BALI</h4>
                                      <div class="count" id="count2"><%Response.Write(getSignUpsIVO()); %></div>

                                  </div>

                              </div>

                    <br />
                    <h3 id="h3">New Sign ups</h3>
                    <p></p>
                </div>
              </div>


                <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="tile-stats">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h4 id="h10">INDIA</h4>
                                <div class="count" id="count7"><%Response.Write(getTopSalesRep()); %></div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h4 id="h11">BALI</h4>
                                <div class="count" id="count8"><%Response.Write(getTopSalesRepIVO()); %></div>

                            </div>
                        </div>

                        <h3 id="h12">Top Sales Rep</h3>
                        <p></p>
                    </div>
                   </div>




                <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="tile-stats">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h4 id="h4">INDIA</h4>
                                <div class="count" id="count3"><%Response.Write(getDealsRegistered()); %></div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h4 id="h5">BALI</h4>
                                <div class="count" id="count4"><%Response.Write(getDealsRegisteredIVO()); %></div>

                            </div>

                        </div>

                        <br />
                        <h3 id="h6">Deals Registered</h3>
                        <p></p>
                    </div>
                </div>


                <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="tile-stats">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h4 id="h7">INDIA</h4>
                                <div class="count" id="count5"><%Response.Write(getCancelledDeals()); %></div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h4 id="h8">BALI</h4>
                                <div class="count" id="count6"><%Response.Write(getCancelledDealsIVO()); %></div>

                            </div>

                        </div>

                        <br />
                        <h3 id="h9">Deals Cancelled</h3>
                        <p></p>
                    </div>
                </div>
            </div>

                  <div class="row">
                      <div class="col-md-12 col-sm-12 col-xs-12">
                          <div class="x_panel">
                              <div class="x_content">
                                  <div id="addEmployeeModal" class="modal fade">
                                      <div class="modal-dialog">
                                          <div class="modal-content">

                                              <div class="modal-header">
                                                  <h4 class="modal-title">Admin</h4>
                                                  <!-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>-->
                                              </div>
                                              <div class="modal-body">
                                                  <div class="container-fluid">

                                                      <div class="table-responsive">
                                                           <div style="overflow:scroll;height:200px;width:100%;overflow:auto">
                                                          <table class="table table-striped table-hover" id="task-table">
                                                              <thead>
                                                                  <tr>
                                                                      <th>Name</th>
                                                                  </tr>
                                                              </thead>
                                                              <tbody>


                                                              </tbody>

                                                          </table>
                                                               </div>
                                                      </div>


                                                  </div>

                                              </div>
                                              <div class="modal-footer">
                                                  <input type="button" class="btn btn-default" id="cancel" data-dismiss="modal" value="Cancel" />
                                           
                                              </div>

                                          </div>
                                      </div>
                                  </div>


                                  <div class="col-md-8 col-sm-12 col-xs-12">
                                      <div class="x_title">
                                      <h4 id="topPro1">WEEKLY STATS</h4>
                                      <div class="clearfix"></div>
                                          </div>
                                          <div class="row">
                                              <div class="col-md-12 col-sm-12 col-xs-12">
                                                  <div style="overflow: scroll; height: 300px; width: 100%; overflow: auto">
                                                  <ul class="nav nav-tabs">
                                                      <li class="active"><a data-toggle="tab" href="#home">INDIA</a></li>
                                                      <li><a data-toggle="tab" href="#menu1">BALI</a></li>
                                                  </ul>

                                                  <div class="tab-content">
                                                      <div id="home" class="tab-pane fade in active">

                                                          <div id="container" style="min-width: 400px; height: 280px; margin: 0 auto"></div>
                                                      </div>
                                                      <div id="menu1" class="tab-pane fade">

                                                          <div id="container1" style="min-width: 400px; height: 280px; margin: 0 auto"></div>
                                                      </div>

                                                  </div>
                                                
                                                      </div>
                                              </div>
                                          </div>
                                  </div>
                                  <div class="col-md-4 col-sm-12 col-xs-12">
                                      <div class="x_title">
                                          <h4 id="topPro">TOP PROFILES</h4>
                                          <div class="clearfix"></div>
                                      </div>

                                      <div class="row">

                                      <div class="col-md-12 col-sm-12 col-xs-12">
                                             <div style="overflow: scroll; height: 300px; width: 100%; overflow: auto">
                                       <!--   <div style="text-align:center; font-size: 17px;">INDIA</div>-->
                                          <ul class="list-unstyled top_profiles scroll-view">

                                              <%Response.Write(getTopProfiles()); %>
                                          </ul>
                                                 </div>
                                      </div>

                                  </div>


                              </div>



                          </div>
                      </div>
                  </div>
            </div>
          </div>
        </div>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right">
           
          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
      </div>
    </div>

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- Chart.js -->
    <script src="../vendors/Chart.js/dist/Chart.min.js"></script>
    <!-- jQuery Sparklines -->
    <script src="../vendors/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
    <!-- Flot -->
    <script src="../vendors/Flot/jquery.flot.js"></script>
    <script src="../vendors/Flot/jquery.flot.pie.js"></script>
    <script src="../vendors/Flot/jquery.flot.time.js"></script>
    <script src="../vendors/Flot/jquery.flot.stack.js"></script>
    <script src="../vendors/Flot/jquery.flot.resize.js"></script>
    <!-- Flot plugins -->
    <script src="../vendors/flot.orderbars/js/jquery.flot.orderBars.js"></script>
    <script src="../vendors/flot-spline/js/jquery.flot.spline.min.js"></script>
    <script src="../vendors/flot.curvedlines/curvedLines.js"></script>
    <!-- DateJS -->
    <script src="../vendors/DateJS/build/date.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="../vendors/moment/min/moment.min.js"></script>
    <script src="../vendors/bootstrap-daterangepicker/daterangepicker.js"></script>
    
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
       <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script src="https://code.highcharts.com/modules/export-data.js"></script>
      <script>

            $(document).ready(function () {

                            Highcharts.chart('container', {
                                chart: {
                                    type: 'column'
                                },
                                title: {
                                    text: ''
                                },
                                subtitle: {
                                    text: ''
                                },
                                xAxis: {
                                    categories: [
                                        'MONDAY',
                                        'TUESDAY',
                                        'WENESDAY',
                                        'THURSDAY',
                                        'FRIDAY',
                                        'SATURDAY',
                                        'SUNDAY'
                                    ],
                                    crosshair: true
                                },
                                yAxis: {
                                    min: 5,
                                    max: 70,
                                    title: {
                                        text: ''
                                    }
                                },
                                tooltip: {
                                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                        '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
                                    footerFormat: '</table>',
                                    shared: true,
                                    useHTML: true
                                },
                                plotOptions: {
                                    column: {
                                        pointPadding: 0.2,
                                        borderWidth: 0
                                    }
                                },
                                series: [{
                                    name: 'Sign ups',
                                    data: [<% Response.Write(getDailySignUpsHML());%>]

                                }, {
                                    name: 'Deals Registered',
                                    data: [<% Response.Write(getDailyDealsHML());%>]

                                }]
                            });
                        });
    </script>


     <script>

            $(document).ready(function () {

                            Highcharts.chart('container1', {
                                chart: {
                                    type: 'column'
                                },
                                title: {
                                    text: ''
                                },
                                subtitle: {
                                    text: ''
                                },
                                xAxis: {
                                    categories: [
                                        'MONDAY',
                                        'TUESDAY',
                                        'WENESDAY',
                                        'THURSDAY',
                                        'FRIDAY',
                                        'SATURDAY',
                                        'SUNDAY'
                                    ],
                                    crosshair: true
                                },
                                yAxis: {
                                    min: 5,
                                    max: 70,
                                    title: {
                                        text: ''
                                    }
                                },
                                tooltip: {
                                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                        '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
                                    footerFormat: '</table>',
                                    shared: true,
                                    useHTML: true
                                },
                                plotOptions: {
                                    column: {
                                        pointPadding: 0.2,
                                        borderWidth: 0
                                    }
                                },
                                series: [{
                                    name: 'Sign ups',
                                    data: [<% Response.Write(getDailySignUpsIVO());%>]

                                }, {
                                    name: 'Deals Registered',
                                    data: [<% Response.Write(getDailyDealsIVO());%>]

                                }]
                            });
                        });
    </script>

    <script>

        $(document).ready(function () {

            $.ajax({

                type: 'Post',
                url: 'Dashboard.aspx/getAdminRights',
                contentType: "application/json; charset=utf-8",
                data: "{}",
                async: false,
                success: function (data) {

                    $("#task-table tbody").empty();

                    subJson = JSON.parse(data.d);

                    $.each(subJson, function (key, value) {

                        $.each(value, function (index1, value1) {
                          

                                $("#task-table tbody").append("<tr><td><a href='"+value1[1]+"'>"+value1[0]+"</a></td></tr>");
                           
                        });

                    });
                },
                error: function () {
                    $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                        $("#danger-alert").slideUp(500);
                    });
                }

            });
            return false;



        });

    </script>
  </body>
</html>
