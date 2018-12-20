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
          #sidebar-menu{
         position: fixed;
         width: 230px;
         margin-top:70px;
        }
   .main {
   
    margin: 13px auto;
}

/* Bootstrap 3 text input with search icon */

.has-search .form-control-feedback {
    right: initial;
    left: 0;
    color: #ccc;
}

.has-search .form-control {
    padding-right: 12px;
    padding-left: 34px;
}

        #searchPro{
            padding:8px 40px;
            border-radius: 25px;
            margin-right:10px;
            font-size:13px;
                text-align:center;
        }
 #foot{

       margin-left:auto;
   }

        #xtitle1,#xtitle,#xtitle2{

            padding: 0px 0px 0px;
            margin-bottom:3px;
        }
        #topProfiles,#topProfiles1,#topProfiles2{

            height:auto;
        }
   
        .title{
           font-size:13px;
      font-style:oblique;
        }

        #img {
               position: fixed;
            background: #04070B;
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

        #h1, #h2, #h3, #h4, #h5, #h6, #h7, #h8, #h9,#h10,#h11,#h12,#topPro,#topPro1,#topPro11 {
            text-align: center;

        }

        #topPro,#topPro1,#topPro11{
            float:none;
                color:#BAB8B8;
                font-size: 18px
        }

        #count1, #count2, #count3, #count4, #count5, #count6,#count7,#count8 {
            text-align: center;
            font-size :25px;
        }


        
        #head,#directory,#menu_toggle,#profileDetails{
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


            #h3,#h6,#h12,#h9{

                color:#BAB8B8;
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
     .modal .modal-title1 {
        display: inline-block;
    }
       .modal .modal-title2 {
        display: inline-block;
    }
          .modal .modal-title3 {
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
                    <div class="navbar nav_title" style="border-bottom: 2px; height:auto; color: #172D44;" id="img">

                          <img src="../production/images/KSC1.png" class="img-square" alt="" style="margin-top:3px; margin-bottom:5px;"  width="200" height="53" /><br />
                      
                     <!-- <span style="opacity: 0.5; font-size:16px; margin-bottom:150px; font-style:oblique; font-family:'Bookman Old Style'; color:#FCDE97">Karma Group</span>-->
                    </div>

                    <div class="clearfix"></div>

                    <!-- menu profile quick info -->
                  <%--  <div class="profile clearfix">

                        <div class="profile_pic">
                            <img src="images/img.jpg" alt="..." class="img-circle profile_img">
                        </div>
                        <div class="profile_info">
                            <span>Welcome,</span>
                            <h2>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2>
                        </div>
                    </div>--%>
                    <!-- /menu profile quick info -->

                    <br />
                    <br />
                    <!-- sidebar menu -->
                    <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
                        <div class="menu_section">

                            <h3>MENU</h3>
                            <ul class="nav side-menu">
                                <% Response.Write(getdata()); %>
                            </ul>
                        </div>


                    </div>
                    <!-- /sidebar menu -->

                    <!-- /menu footer buttons -->

                    <div class="sidebar-footer hidden-small">
                        <a data-toggle="tooltip" data-placement="top" title="" href="Dashboard.aspx">
                            <span class="glyphicon glyphicon-home" aria-hidden="true"></span>
                        </a>
                        <a data-toggle="" data-placement="top" title="Settings">
                            <span class="glyphicon glyphicon" aria-hidden="true"></span>
                        </a>


                        <a data-toggle="tooltip" data-placement="top" title="">
                            <span class="glyphicon glyphicon" aria-hidden="true"></span>
                        </a>


                        <a data-toggle="tooltip" data-placement="top" title="" href="logout.aspx">
                            <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
                        </a>
              </div>
              <!-- /menu footer buttons -->
          </div>
        </div>

          <!-- top navigation -->
            <div class="top_nav">
                <div class="nav_menu">
                     <form id="form2" runat="server">
                    <nav>
                        <div class="nav toggle">
                            <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                        </div>

                        <ul class="nav navbar-nav navbar-right">
                            <li class="">
                                <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    <!--<img src="images/img.jpg" alt=""/>-->
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    <span class=" fa fa-angle-down"></span>
                                </a>
                                <ul class="dropdown-menu dropdown-usermenu pull-right">
                                    <li><a href="Profile_Page.aspx">Change Password</a></li>

                                    <li><a href="#addEmployeeModal" data-toggle="modal">Setting</a></li>
                                    <li><a href="logout.aspx"><i class="fa fa-sign-out pull-right"></i>Log Out</a></li>
                                </ul>
                            </li>

                            <li class="">

                                <div class="main">


                                    <div class="form-group has-feedback has-search">
                                        <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                        <asp:TextBox ID="searchPro" runat="server" class="form-control" placeholder="Search for Profile.."></asp:TextBox>
                                    </div>

                                </div>

                            </li>
                                
                        </ul>
                    </nav>
                         </form>
                </div>
            </div>
            <!-- /top navigation -->

            <!-- page content -->
          <div class="right_col" role="main">
              <div class="">
                  <div class="row top_tiles" id="toprow">
                      <div class="animated flipInY col-lg-4 col-md-4 col-sm-6 col-xs-12">
                          <div class="tile-stats">

                              <div class="row">
                                  <div class="col-md-6 col-sm-6 col-xs-6">
                                      <h5 id="h1">INDIA</h5>
                                      <div class="count counter-count" id="count1"><%Response.Write(getSignUps()); %></div>
                                  </div>
                                  <div class="col-md-6 col-sm-6 col-xs-6">
                                      <h5 id="h2">BALI</h5>
                                      <div class="count counter-count" id="count2"><%Response.Write(getSignUpsIVO()); %></div>

                                  </div>

                              </div>

                    <br />
                    <h4 id="h3">NEW SIGN UPS</h4>
                    <p></p>
                </div>
              </div>


              <%--  <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="tile-stats">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h5 id="h10">INDIA</h5>
                                <div class="count" id="count7"><%Response.Write(getTopSalesRep()); %></div>

                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h5 id="h11">BALI</h5>
                                <div class="count" id="count8"><%Response.Write(getTopSalesRepIVO()); %></div>

                            </div>
                        </div>

                        <h4 id="h12">Top Sales Rep</h4>
                        <p></p>
                    </div>
                   </div>--%>




                <div class="animated flipInY col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <div class="tile-stats">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h5 id="h4">INDIA</h5>
                                <div class="count counter-count" id="count3"><%Response.Write(getDealsRegistered()); %></div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h5 id="h5">BALI</h5>
                                <div class="count counter-count" id="count4"><%Response.Write(getDealsRegisteredIVO()); %></div>

                            </div>

                        </div>

                        <br />
                        <h4 id="h6">DEALS REGISTERED</h4>
                        <p></p>
                    </div>
                </div>


                <div class="animated flipInY col-lg-4 col-md-4 col-sm-6 col-xs-12">
                    <div class="tile-stats">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h5 id="h7">INDIA</h5>
                                <div class="count counter-count" id="count5"><%Response.Write(getCancelledDeals()); %></div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <h5 id="h8">BALI</h5>
                                <div class="count counter-count" id="count6"><%Response.Write(getCancelledDealsIVO()); %></div>

                            </div>

                        </div>

                        <br />
                        <h4 id="h9">DEALS CANCELLED</h4>
                        <p></p>
                    </div>
                </div>
            </div>

                  <div class="row">
                      <div class="col-md-12 col-sm-12 col-xs-12">
                          <div class="x_panel">
                                <div class="table-responsive" id="profileDetails">
                         
                              <table class="table table-striped table-hover" id="task-table2">
                                  <thead>
                                      <tr>
                                         <th>PROFILE ID</th>
                                          <th>TITLE</th>
                                          <th>NAME</th>
                                          <th>EMAIL</th>
                                            <th>MOBILE</th>
                                          <th>TOUR DATE</th>
                                          <th>GUEST CARD</th>
                                      </tr>
                                  </thead>
                                  <tbody>
                                  </tbody>

                              </table>
                          
                      </div>
                              <div class="x_content" id="x_content">
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

                                   <div id="salesRep" class="modal fade">
                                      <div class="modal-dialog">
                                          <div class="modal-content">

                                              <div class="modal-header">
                                                  <h4 class="modal-title1"></h4>
                                                  <!-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>-->
                                              </div>
                                              <div class="modal-body">
                                                
                                                  <div class="container-fluid">

                                                      <div class="table-responsive">
                                                          <div style="overflow: scroll; height: 180px; width: 100%; overflow: auto">
                                                              <table class="table table-striped table-hover" id="task-table3">
                                                                  <thead>
                                                                  </thead>
                                                                  <tbody>
                                                                      



                                                                  </tbody>

                                                              </table>
                                                          </div>
                                                      </div>


                                                  </div>

                                              </div>
                                              <div class="modal-footer">
                                                  <input type="button" class="btn btn-default" id="cancel1" data-dismiss="modal" value="Cancel" />

                                              </div>

                                          </div>
                                      </div>
                                   </div>


                                  <div id="salesRepIVO" class="modal fade">
                                      <div class="modal-dialog">
                                          <div class="modal-content">

                                              <div class="modal-header">
                                                  <h4 class="modal-title2"></h4>
                                                  <!-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>-->
                                              </div>
                                              <div class="modal-body">
                                                
                                                  <div class="container-fluid">

                                                      <div class="table-responsive">
                                                          <div style="overflow: scroll; height: 180px; width: 100%; overflow: auto">
                                                              <table class="table table-striped table-hover" id="task-table4">
                                                                  <thead>
                                                                  </thead>
                                                                  <tbody>
                                                                      



                                                                  </tbody>

                                                              </table>
                                                          </div>
                                                      </div>


                                                  </div>

                                              </div>
                                              <div class="modal-footer">
                                                  <input type="button" class="btn btn-default" id="cancel2" data-dismiss="modal" value="Cancel" />

                                              </div>

                                          </div>
                                      </div>
                                   </div>


                                   <div id="topProfile" class="modal fade">
                                      <div class="modal-dialog">
                                          <div class="modal-content">

                                              <div class="modal-header">
                                                  <h4 class="modal-title3"></h4>
                                                  <!-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>-->
                                              </div>
                                              <div class="modal-body">
                                                
                                                  <div class="container-fluid">

                                                      <div class="table-responsive">
                                                          <div style="overflow: scroll; height: 180px; width: 100%; overflow: auto">
                                                              <table class="table table-striped table-hover" id="task-table5">
                                                                  <thead>
                                                                  </thead>
                                                                  <tbody>
                                                                      



                                                                  </tbody>

                                                              </table>
                                                          </div>
                                                      </div>


                                                  </div>

                                              </div>
                                              <div class="modal-footer">
                                                  <input type="button" class="btn btn-default" id="cancel3" data-dismiss="modal" value="Cancel" />

                                              </div>

                                          </div>
                                      </div>
                                   </div>
                                  <div class="col-md-8 col-sm-12 col-xs-12">
                                      <div class="x_title" id="xtitle2">
                                          <h4 id="topPro1">WEEK <%Response.Write(GetWkNumber()); %> STATS</h4>
                                          <div class="clearfix"></div>
                                      </div>
                                      <div class="row">
                                          <div class="col-md-12 col-sm-12 col-xs-12">
                                              <div style="overflow: scroll; height: 350px; width: 100%; overflow: auto">
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
                                      <div class="x_title" id="xtitle">
                                          <h4 id="topPro">TOP DEALS</h4>
                                          <div class="clearfix"></div>
                                      </div>

                                      <div class="row">

                                          <div class="col-md-12 col-sm-12 col-xs-12">

                                              <!--   <div style="text-align:center; font-size: 17px;">INDIA</div>-->
                                              <ul class="list-unstyled top_profiles" id="topProfiles">
                                                  <%--  <marquee behavior='scroll' direction='left'>--%>


                                                  <%Response.Write(getTopProfiles()); %>
                                                  <%--  </marquee>--%>
                                              </ul>


                                          </div>
  </div>

                                          <div class="x_title" id="xtitle1">
                                              <h4 id="topPro11">TOP SALES REP</h4>
                                              <div class="clearfix"></div>
                                          </div>

                                          <div class="row">

                                              <div class="col-md-12 col-sm-12 col-xs-12">
                                             
                                                  <!--   <div style="text-align:center; font-size: 17px;">INDIA</div>-->
                                                  <ul class="list-unstyled top_profiles" id="topProfiles1">
                                                      <%--             <marquee behavior='scroll' direction='left'>--%>

                                                      <%Response.Write(getTopSalesRep()); %>

                                                      <%--      </marquee>--%>
                                                  </ul>
                                                  <ul class="list-unstyled top_profiles "  id="topProfiles2">
                                                      <%Response.Write(getTopSalesRepIVO()); %>
                                                  </ul>

                                              
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
        <footer id="foot">
          <div class="pull-right">
           
          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
      </div>
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

            $('#form2').bind('keydown', function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                }
            });
        </script>
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
                                        'SATURDAY',
                                        'SUNDAY',
                                        'MONDAY',
                                        'TUESDAY',
                                        'WENESDAY',
                                        'THURSDAY',
                                        'FRIDAY'
                                        
                                     
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
                                        'SATURDAY',
                                        'SUNDAY',
                                        'MONDAY',
                                        'TUESDAY',
                                        'WENESDAY',
                                        'THURSDAY',
                                        'FRIDAY'
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

    <script>

        $('.counter-count').each(function () {
            $(this).prop('Counter', 0).animate({
                Counter: $(this).text()
            }, {
                duration:2000,
                easing: 'swing',
                step: function (now) {
                    $(this).text(Math.ceil(now));
                }
            });
        });
    </script>


          <script>

        $(document).ready(function () {
            $(document).on('click', '#salesclick', function () {


                $.ajax({

                    type: 'Post',
                    url: 'Dashboard.aspx/getTopSalesDetails',
                    contentType: "application/json; charset=utf-8",
                    data: "{}",
                    async: false,
                    success: function (data) {

                        $("#task-table3 tbody").empty();
                        $(".modal-title1").empty();
                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                $(".modal-title1").text(value1[1]);
                                $("#task-table3 tbody").append("<tr><td>Country:</td><td>India</td></tr><tr><td>Venue:</td><td>"+value1[3]+"</td></tr><tr><td>Total Deals:</td><td>" + value1[0] + "</td></tr><tr><td>Total Volume:</td><td>INR " + value1[2] + "</td></tr>");

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
           


           

        });

    </script>



          <script>

        $(document).ready(function () {
            $(document).on('click', '#salesclickIVO', function () {


                $.ajax({

                    type: 'Post',
                    url: 'Dashboard.aspx/getTopSalesDetailsIVO',
                    contentType: "application/json; charset=utf-8",
                    data: "{}",
                    async: false,
                    success: function (data) {

                        $("#task-table4 tbody").empty();
                        $(".modal-title2").empty();
                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                $(".modal-title2").text(value1[1]);
                                $("#task-table4 tbody").append("<tr><td>Country:</td><td>Indonesia</td></tr><tr><td>Venue:</td><td>"+value1[3]+"</td></tr><tr><td>Total Deals:</td><td>" + value1[0] + "</td></tr><tr><td>Total Volume:</td><td>USD " + value1[2] + "</td></tr>");

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
           


           

        });

    </script>


            <script>

                $(document).ready(function () {
                   
                    $(document).on("click", "#topProfileclick0", function () {
                           
                        var profileID = $("#profileID0").val();
                          //  alert(profileID);
                            $.ajax({
                                type: 'Post',
                                url: 'Dashboard.aspx/getTopProfileInfo',
                                contentType: "application/json; charset=utf-8",
                                data: "{'profileID':'" + profileID + "'}",
                                async: false,
                                success: function (data) {

                                    $("#task-table5 tbody").empty();
                                    $(".modal-title3").empty();
                                    subJson = JSON.parse(data.d);

                                    $.each(subJson, function (key, value) {

                                        $.each(value, function (index1, value1) {

                                            $(".modal-title3").text(value1[1]);
                                            $("#task-table5 tbody").append("<tr><td>Profile ID:</td><td>" + value1[5] + "</td></tr><tr><td>Contract No:</td><td>" + value1[6] + "</td></tr><tr><td>Contract Type:</td><td>" + value1[3] + "</td></tr><tr><td>Volume:</td><td>" + value1[4] + " " + value1[0] + "</td></tr>");

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


        });

    </script>


         <script>

                $(document).ready(function () {
                   
                    $(document).on("click", "#topProfileclick1", function () {
                           
                        var profileID = $("#profileID1").val();
                           // alert(profileID);
                            $.ajax({
                                type: 'Post',
                                url: 'Dashboard.aspx/getTopProfileInfo',
                                contentType: "application/json; charset=utf-8",
                                data: "{'profileID':'" + profileID + "'}",
                                async: false,
                                success: function (data) {

                                    $("#task-table5 tbody").empty();
                                    $(".modal-title3").empty();
                                    subJson = JSON.parse(data.d);

                                    $.each(subJson, function (key, value) {

                                        $.each(value, function (index1, value1) {

                                            $(".modal-title3").text(value1[1]);
                                            $("#task-table5 tbody").append("<tr><td>Profile ID:</td><td>" + value1[5] + "</td></tr><tr><td>Contract No:</td><td>" + value1[6] + "</td></tr><tr><td>Contract Type:</td><td>" + value1[3] + "</td></tr><tr><td>Volume:</td><td>" + value1[4] + " " + value1[0] + "</td></tr>");

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


        });

    </script>

        
         <script>

                $(document).ready(function () {
                   
                    $(document).on("click", "#topProfileclick2", function () {
                           
                        var profileID = $("#profileID2").val();
                            //alert(profileID);
                            $.ajax({
                                type: 'Post',
                                url: 'Dashboard.aspx/getTopProfileInfo',
                                contentType: "application/json; charset=utf-8",
                                data: "{'profileID':'" + profileID + "'}",
                                async: false,
                                success: function (data) {

                                    $("#task-table5 tbody").empty();
                                    $(".modal-title3").empty();
                                    subJson = JSON.parse(data.d);

                                    $.each(subJson, function (key, value) {

                                        $.each(value, function (index1, value1) {

                                            $(".modal-title3").text(value1[1]);
                                            $("#task-table5 tbody").append("<tr><td>Profile ID:</td><td>" + value1[5] + "</td></tr><tr><td>Contract No:</td><td>" + value1[6] + "</td></tr><tr><td>Contract Type:</td><td>" + value1[3] + "</td></tr><tr><td>Volume:</td><td>" + value1[4] + " " + value1[0] + "</td></tr>");

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


        });

    </script>


        
         <script>

                $(document).ready(function () {
                   
                    $(document).on("click", "#topProfileclick3", function () {
                           
                        var profileID = $("#profileID3").val();
                          //  alert(profileID);
                            $.ajax({
                                type: 'Post',
                                url: 'Dashboard.aspx/getTopProfileInfo',
                                contentType: "application/json; charset=utf-8",
                                data: "{'profileID':'" + profileID + "'}",
                                async: false,
                                success: function (data) {

                                    $("#task-table5 tbody").empty();
                                    $(".modal-title3").empty();
                                    subJson = JSON.parse(data.d);

                                    $.each(subJson, function (key, value) {

                                        $.each(value, function (index1, value1) {

                                            $(".modal-title3").text(value1[1]);
                                            $("#task-table5 tbody").append("<tr><td>Profile ID:</td><td>" + value1[5] + "</td></tr><tr><td>Contract No:</td><td>" + value1[6] + "</td></tr><tr><td>Contract Type:</td><td>" + value1[3] + "</td></tr><tr><td>Volume:</td><td>" + value1[4] + " " + value1[0] + "</td></tr>");

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


        });

    </script>



     <script>

        $(document).ready(function () {

            $("#searchPro").keyup(function () {
                
                var profileID = $("#searchPro").val();

                $.ajax({

                    type: 'Post',
                    url: 'Dashboard.aspx/searchProfile',
                    contentType: "application/json; charset=utf-8",
                    data: "{'profileID':'" + profileID + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#task-table2 tbody").empty();
                        $("#x_content").hide();
                        $("#toprow").hide();
                        $("#task-table2").show();
                        $("#profileDetails").show();
                        

                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {
                                
                                if (value1[0] == "") {
                                    $("#task-table2").hide();
                                    $("#x_content").show();
                                    $("#toprow").show();
                                    //  window.location.reload();
                                    $(window).scrollTop(0);
                                } else {

                                    //$("#task-table2 tbody").append("<tr><td><a href='" + value1[1] + "'>" + value1[0] + "</a></td></tr>");
                                    $("#task-table2 tbody").append("<tr><td><a href='" + value1[0] + "' id='profileclick'>" + value1[0] + "</a></td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td>" + value1[4] + "</td><td>" + value1[5] + "</td><td><a href=GuestCard.aspx?name=" + value1[0] + ">Guest Card</a></td></tr>");
                                }
                            });

                        });
                    },
                    error: function (xhr, status, error) {
                        var err = JSON.parse(xhr.responseText);
                        alert(err.Message);
                    }

                });
                return false;


            });


          



        });

    </script>


         <script>

        $(document).ready(function () {

            $(document).on('click','#profileclick',function() {

                var row = $(this).closest("tr");
                var profileID = row.find("td:eq(0)").text();
                //alert(profileID);
              //  var profileID = $("#profileclick").text();

                $.ajax({

                    type: 'Post',
                    url: 'Dashboard.aspx/getlink',
                    contentType: "application/json; charset=utf-8",
                    data: "{'profileID':'" + profileID + "'}",
                    async: false,
                    success: function (data) {

                     //   alert(data.d);

                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                window.location.href =value1[0];

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


          



        });

    </script>

  </body>
</html>
