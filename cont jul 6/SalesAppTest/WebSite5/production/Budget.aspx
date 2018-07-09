<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget.aspx.cs" Inherits="WebSite5_production_Budget" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title> </title>
    <style>


        #img1 {
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

         #update,#head{
             display:none;
         }

           #success-alert,#danger-alert,#danger-alert1{
            display:none;
        }
           #TextBox5{
               text-align:center;
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
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
  
   
    <link href="../vendors/google-code-prettify/bin/prettify.min.css" rel="stylesheet">

    <!-- Custom styling plus plugins -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
    <script src="jquery-3.2.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.2.1.min.js"></script>
</head>
<body class="nav-md">
   
    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3 left_col">
          <div class="left_col scroll-view">
             <div class="navbar nav_title" style="border-bottom:2px;   height:auto; color:#172D44;  " id="img1">
                 <img src="../production/images/k.png"  class="img-square"  alt="" width="40" height="40"/> <br />
                <a href="#" class="site_title"> <span style="opacity: 0.5;">Karma Group</span></a>
            </div>
            <div class="clearfix"></div>

            <!-- menu profile quick info -->
            <div class="profile clearfix">
              <div class="profile_pic">
                <img src="images/img.jpg" alt="..." class="img-circle profile_img">
              </div>
              <div class="profile_info">
                <span>Welcome,</span><br />
                  
                <h2><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2>
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
                    <li><a href="logout.aspx"><i class="fa fa-sign-out pull-right"></i> Log Out</a></li>
                  </ul>
                </li>
              </ul>
            </nav>
          </div>
        </div>
        <!-- /top navigation -->

        <!-- page content -->
           <form id="form1" runat="server">
        <div class="right_col" role="main">
          <div class="">

           

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <div class="x_panel">
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
                                                          <table class="table table-striped table-hover" id="task-table1">
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

                     <div class="alert alert-success" id="success-alert">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Success! </strong>
                        
                    </div>
                     <div class="alert alert-danger" id="danger-alert">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Something went wrong! </strong>
                        
                    </div>
                     <div class="alert alert-danger" id="danger-alert1">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Enter Details! </strong>
                        
                    </div>
                <div class="container-fluid">
                   
          <div class="row">
          <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " id="head" ><br />
        <h5 class="text-center">ADD BUDGET</h5>
              </div>
              </div>
            </div>
              <br /><br />
        <div class="container-fluid">
          <div class="row"> 
               <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Year">
                  <div class="form-group">
                      <label for="sel1">Year:</label>
                      <select class="form-control"  id="year">
                          <option disabled selected value>Select an Option</option>
                          <option value="2016">2016</option>
                          <option value="2017">2017</option>
                           <option value="2018">2018</option>
                           <option value="2019">2019</option>
                           <option value="2020">2020</option>
                           <option value="2021">2021</option>
                           <option value="2022">2022</option>
                           <option value="2023">2023</option>
                           <option value="2024">2024</option>
                           <option value="2025">2025</option>
                      </select>
                  </div>
              </div>
                <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Country">
                  <div class="form-group">
                      <label for="sel1">Country:</label>
                      <select class="form-control"  id="country1">
                          <option disabled selected value>Select an Option</option>
                          <%Response.Write(getAllCountries()); %>
                      </select>
                  </div>
              </div>
         
               <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Venue">
                  <div class="form-group">
                      <label for="sel1">venue:</label>
                      <select class="form-control"  id="venue1">
                         
                          
                      </select>
                  </div>
              </div>
              </div>
            <div class="row">
           <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="VenueGroup">
                  <div class="form-group">
                      <label for="sel1">venue Group:</label>
                      <select class="form-control"  id="venue1Group">
                         
                          
                      </select>
                  </div>
              </div>
            
                <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Group">
                  <div class="form-group">
                      <label for="sel1">Group:</label>
                      <select class="form-control"  id="group">
                          <option disabled selected value>Select an Option</option>
                         <%Response.Write(getGroup()); %>
                          
                      </select>
                  </div>
              </div>
        

                 <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Source">
                  <div class="form-group">
                      <label for="sel1">source:</label>
                      <select class="form-control"  id="source">
                         
                          
                      </select>
                  </div>
              </div>

              </div>
              </div>
                 
        
                     <div class="container-fluid" id="directory">
          <div class="row">
              
                   <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " "><br />
                      <%--  <h5 class="text-center"> COUNTRY DIRECTORY</h5>--%>
                               </div>
              
              </div>
                      <div class="row">
                   <div class="col-md-4 col-md-offset-4 col-sm-4 col-sm-offset-4 col-xs-6 col-xs-offset-3 col-lg-4 col-lg-offset-4" >
                    <div class="form-group">
                       <label for="sel1"></label>
                      <%--<asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server" placeholder="Search"  data-table="table table-hover" ></asp:TextBox>--%>
                  </div>
              </div>
          </div>
          
                <br /> 
      
           <div class="row">
               
                         <div class="table-responsive">
               <table class="table table-hover" id="task-table">
            <thead>
                <tr>
                    <th>MONTH</th>
                    <th>DAYS</th>
                    <th>QT</th>
                    <th>CLOSE</th>
                    <th>SALES</th>
                    <th>AVG PRICE</th>
                    <th>GROSS</th>
                    <th>PPN</th>
                    <th>ADMIN</th>
                    <th>NET</th>
                    <th></th>
                </tr>
            </thead>
                   <tbody id="myTable">
                   </tbody>
               </table>
                             <div class="col-md-2 col-xs-9 col-sm-2 col-lg-2">
                                 <label for="sel1">&nbsp;</label>
                                 <button type="button" runat="server" id="insert" class="btn btn-primary pull-right btn-block">Insert</button>


                             </div>
                         </div>
               <div class="col-md-12 text-center">
                   <ul class="pagination pagination-lg pager" id="myPager"></ul>
               </div>
           </div>

                     </div>
                </div>
              </div>
            </div>
          </div>
        </div>

               </form>
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

    <!-- compose -->
    <div class="compose col-md-6 col-xs-12">
      <div class="compose-header">
        New Message
        <button type="button" class="close compose-close">
          <span>×</span>
        </button>
      </div>

      <div class="compose-body">
        <div id="alerts"></div>

        <div class="btn-toolbar editor" data-role="editor-toolbar" data-target="#editor">
          <div class="btn-group">
            <a class="btn dropdown-toggle" data-toggle="dropdown" title="Font"><i class="fa fa-font"></i><b class="caret"></b></a>
            <ul class="dropdown-menu">
            </ul>
          </div>

          <div class="btn-group">
            <a class="btn dropdown-toggle" data-toggle="dropdown" title="Font Size"><i class="fa fa-text-height"></i>&nbsp;<b class="caret"></b></a>
            <ul class="dropdown-menu">
              <li>
                <a data-edit="fontSize 5">
                  <p style="font-size:17px">Huge</p>
                </a>
              </li>
              <li>
                <a data-edit="fontSize 3">
                  <p style="font-size:14px">Normal</p>
                </a>
              </li>
              <li>
                <a data-edit="fontSize 1">
                  <p style="font-size:11px">Small</p>
                </a>
              </li>
            </ul>
          </div>

        

          

         

        <div id="editor" class="editor-wrapper"></div>
      </div>

      <div class="compose-footer">
        <button id="send" class="btn btn-sm btn-success" type="button">Send</button>
      </div>
    </div>
    <!-- /compose -->

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- bootstrap-wysiwyg -->
    <script src="../vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js"></script>
    <script src="../vendors/jquery.hotkeys/jquery.hotkeys.js"></script>
    <script src="../vendors/google-code-prettify/src/prettify.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
  
       
        
        
        <script>
            $(document).ready(function () {

                $("#country1").change(function () {
                    var venueCountryID = $("#country1").val();
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getVenueOnCountry',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venueCountryID':'" + venueCountryID + "'}",
                        async: false,
                        success: function (data) {
                     
                            $("#venue1").empty();
                            $("#venue1").append("<option disabled selected value>Select an Option</option>");
                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {

                                    $("#venue1").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");
                                  
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

                $("#venue1").change(function () {
                    var venue = $("#venue1").val();

                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getVenueGroupOnVenue',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venue':'" + venue + "'}",
                        async: false,
                        success: function (data) {
                     
                            $("#venue1Group").empty();
                            $("#venue1Group").append("<option disabled selected value>Select an Option</option>");
                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {

                                    $("#venue1Group").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");
                                  
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

                $("#group").change(function () {
                    var group = $("#group").val();

                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getSourceOnGroup',
                        contentType: "application/json; charset=utf-8",
                        data: "{'group':'" + group + "'}",
                        async: false,
                        success: function (data) {
                     
                            $("#source").empty();
                            $("#source").append("<option disabled selected value>Select an Option</option>");
                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {

                                    $("#source").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
                                  
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

                $("#year").change(function () {
                    var current = 0;
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getdetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                            $("#task-table tbody").empty();
                         
                            subJson = JSON.parse(data.d);
                         
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                   
                                    $("#task-table tbody").append("<tr><td style='display:none'><input type='hidden' style='width:80px' id='month" + current + "' value='" + value1[0] + "'></td><td>" + value1[0] + "</td><td><input type='text' style='width:50px' id='DAYS" + current + "'><td><input type='text' style='width:80px' id='QT" + current + "'></td> <td><input type='text' style='width:80px' id='Close" + current + "'></td> <td><input type='text' style='width:80px' id='sales" + current + "' readonly></td> <td><input type='text' style='width:80px' id='Avg" + current + "'></td> <td><input type='text' style='width:80px' id='Gross" + current + "' readonly></td> <td><input type='text' style='width:80px' id='PPN" + current + "'></td> <td><input type='text' style='width:80px' id='Admin" + current + "' readonly></td> <td><input type='text' style='width:80px' id='Net" + current + "' readonly></td></tr>");

                                    current++;
                                  
                                });
                             

                            });
                          
                           

                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                      
                    });
                   
                 
                

                });
            });

        </script>

        
       <!-- jan-->
        <script>

            $(document).ready(function () {


                var adminfee;
                var total;
                $(document).on('focusout', '#Close0', function () {

                    var qt = $("#QT0").val();
                    var close = $("#Close0").val();
                     total = qt * close / 100;
                     var salesRound = Math.round(total);

                     $("#sales0").val(salesRound);
                 


                });

                $(document).on('focusout', '#Avg0', function () {

                    var sales = total;
                   
                    var Avg = $("#Avg0").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross0").val(total1);



                    var year = $("#year").val();
                    var month = $("#month0").val();
                   
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                     adminFeeWR = value1[0] * sales;
                                     $("#Admin0").val(adminFeeR);
                                 
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


                $(document).on('focusout', '#PPN0', function () {
                    var Gross = $("#Gross0").val();
                    var ppn = $("#PPN0").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net0").val(netVolume);


                });

            });


        </script>
       <!-- end-->

          <!-- Feb-->
        <script>

            $(document).ready(function () {

               
                var total;
                $(document).on('focusout', '#Close1', function () {

                    var qt = $("#QT1").val();
                    var close = $("#Close1").val();

                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales1").val(salesRound);
                 


                });

                $(document).on('focusout', '#Avg1', function () {

                    var sales = total;
                    var Avg = $("#Avg1").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross1").val(total1);


                    var year = $("#year").val();
                    var month = $("#month1").val();
                   // alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin1").val(adminFeeR);

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


                $(document).on('focusout', '#PPN1', function () {
                    var Gross = $("#Gross1").val();
                    var ppn = $("#PPN1").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net1").val(netVolume);


                });

            });


        </script>
       <!-- end-->

          <!-- Mar-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close2', function () {

                    var qt = $("#QT2").val();
                    var close = $("#Close2").val();

                   

                    total = qt * close / 100;
                    var salesRound = Math.round(total);
                    $("#sales2").val(salesRound);
                 


                });

                $(document).on('focusout', '#Avg2', function () {

                    var sales = total;
                    var Avg = $("#Avg2").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross2").val(total1);

                    var year = $("#year").val();
                    var month = $("#month2").val();
                  //  alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin2").val(adminFeeR);

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

                $(document).on('focusout', '#PPN2', function () {
                    var Gross = $("#Gross2").val();
                    var ppn = $("#PPN2").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net2").val(netVolume);


                });

            });


        </script>
       <!-- end-->


           <!-- Apr-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close3', function () {

                    var qt = $("#QT3").val();
                    var close = $("#Close3").val();
                    total = qt * close / 100;
                    var salesRound = Math.round(total);
                    $("#sales3").val(salesRound);

                });

                $(document).on('focusout', '#Avg3', function () {

                    var sales = total;
                    var Avg = $("#Avg3").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross3").val(total1);

                    var year = $("#year").val();
                    var month = $("#month3").val();
                  //  alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin3").val(adminFeeR);

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


                $(document).on('focusout', '#PPN3', function () {
                    var Gross = $("#Gross3").val();
                    var ppn = $("#PPN3").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net3").val(netVolume);


                });

            });


        </script>
       <!-- end-->

           <!-- May-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close4', function () {

                    var qt = $("#QT4").val();
                    var close = $("#Close4").val();
                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales4").val(salesRound);
                });

                $(document).on('focusout', '#Avg4', function () {

                    var sales = total;
                    var Avg = $("#Avg4").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross4").val(total1);

                    var year = $("#year").val();
                    var month = $("#month4").val();
                  //  alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin4").val(adminFeeR);

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

                $(document).on('focusout', '#PPN4', function () {
                    var Gross = $("#Gross4").val();
                    var ppn = $("#PPN4").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net4").val(netVolume);


                });

            });


        </script>
       <!-- end-->
        
         <!-- Jun-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close5', function () {

                    var qt = $("#QT5").val();
                    var close = $("#Close5").val();
                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales5").val(salesRound);
                 
                });

                $(document).on('focusout', '#Avg5', function () {

                    var sales = total;
                    var Avg = $("#Avg5").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross5").val(total1);

                    var year = $("#year").val();
                    var month = $("#month5").val();
                  //  alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin5").val(adminFeeR);

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

                $(document).on('focusout', '#PPN5', function () {
                    var Gross = $("#Gross5").val();
                    var ppn = $("#PPN5").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net5").val(netVolume);


                });

            });


        </script>
       <!-- end-->


          <!-- Jul-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close6', function () {

                    var qt = $("#QT6").val();
                    var close = $("#Close6").val();

                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales6").val(salesRound);
                 
                });

                $(document).on('focusout', '#Avg6', function () {

                    var sales = total;
                    var Avg = $("#Avg6").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross6").val(total1);

                    var year = $("#year").val();
                    var month = $("#month6").val();
                //    alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin6").val(adminFeeR);

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

                $(document).on('focusout', '#PPN6', function () {
                    var Gross = $("#Gross6").val();
                    var ppn = $("#PPN6").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net6").val(netVolume);


                });

            });


        </script>
       <!-- end-->


          <!-- Aug-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close7', function () {

                    var qt = $("#QT7").val();
                    var close = $("#Close7").val();
                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales7").val(salesRound);
                 
                });

                $(document).on('focusout', '#Avg7', function () {

                    var sales = total;
                    var Avg = $("#Avg7").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross7").val(total1);

                    var year = $("#year").val();
                    var month = $("#month7").val();
                  //  alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin7").val(adminFeeR);

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

                $(document).on('focusout', '#PPN7', function () {
                    var Gross = $("#Gross7").val();
                    var ppn = $("#PPN7").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net7").val(netVolume);


                });

            });


        </script>
       <!-- end-->


             <!-- sep-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close8', function () {

                    var qt = $("#QT8").val();
                    var close = $("#Close8").val();
                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales8").val(salesRound);
                 
                });

                $(document).on('focusout', '#Avg8', function () {

                    var sales = total;
                    var Avg = $("#Avg8").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross8").val(total1);

                    var year = $("#year").val();
                    var month = $("#month8").val();
                  //  alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin8").val(adminFeeR);

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

                $(document).on('focusout', '#PPN8', function () {
                    var Gross = $("#Gross8").val();
                    var ppn = $("#PPN8").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net8").val(netVolume);


                });

            });


        </script>
       <!-- end-->


              <!-- oct-->
        <script>

            $(document).ready(function () {


                var total;
                $(document).on('focusout', '#Close9', function () {

                    var qt = $("#QT9").val();
                    var close = $("#Close9").val();

                   

                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales9").val(salesRound);
                 
                });

                $(document).on('focusout', '#Avg9', function () {

                    var sales = total;
                    var Avg = $("#Avg9").val();
                    var total1 = Math.round(sales * Avg);
                    $("#Gross9").val(total1);
                    var year = $("#year").val();
                    var month = $("#month9").val();
                 //   alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin9").val(adminFeeR);

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

                $(document).on('focusout', '#PPN9', function () {
                    var Gross = $("#Gross9").val();
                    var ppn = $("#PPN9").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net9").val(netVolume);


                });

            });


        </script>
       <!-- end-->


               <!-- nov-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close10', function () {

                    var qt = $("#QT10").val();
                    var close = $("#Close10").val();
                     total = qt * close / 100;
                     var salesRound = Math.round(total);
                    $("#sales10").val(salesRound);
                 
                });

                $(document).on('focusout', '#Avg10', function () {

                    var sales = total;
                    var Avg = $("#Avg10").val();
                    var total1 =Math.round(sales*Avg);
                    $("#Gross10").val(total1);
                    var year = $("#year").val();
                    var month = $("#month10").val();
                   // alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin10").val(adminFeeR);

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

                $(document).on('focusout', '#PPN10', function () {
                    var Gross = $("#Gross10").val();
                    var ppn = $("#PPN10").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net10").val(netVolume);


                });

            });


        </script>
       <!-- end-->


               <!-- Dec-->
        <script>

            $(document).ready(function () {

                var total;
                $(document).on('focusout', '#Close11', function () {

                    var qt = $("#QT11").val();
                    var close = $("#Close11").val();
                     total = qt * close / 100;
                    var salesRound = Math.round(total);
                    $("#sales11").val(salesRound);
                 
                });

                $(document).on('focusout', '#Avg11', function () {

                    var sales = total;
                    var Avg = $("#Avg11").val();
                    var total1 = Math.round(sales * Avg);

                    $("#Gross11").val(total1);

                    var year = $("#year").val();
                    var month = $("#month11").val();
                    //alert(month);
                    $.ajax({

                        type: 'Post',
                        url: 'Budget.aspx/getAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "'}",
                        async: false,
                        success: function (data) {

                            // $("#venue1Group").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    var adminFeeR = Math.round(value1[0] * sales);
                                    adminFeeWR = value1[0] * sales;
                                    $("#Admin11").val(adminFeeR);

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

                $(document).on('focusout', '#PPN11', function () {
                    var Gross = $("#Gross11").val();
                    var ppn = $("#PPN11").val();
                    var adminfee = adminFeeWR;

                    var netVolume = Math.round(Gross - ppn - adminfee);
                    $("#Net11").val(netVolume);


                });

            });


        </script>
       <!-- end-->

        <script>

        $(document).ready(function () {
         
            $("#insert").click(function () {

                var year = $("#year").val();
                if(year=="" || year== null){
                    year == "";
                }else{
                    year = $("#year").val();
                }
                var country = $("#country1 option:selected").text();
                if (country == "" || country == null) {
                    country == "";
                } else {
                    country = $("#country1 option:selected").text();
                }

                var venue = $("#venue1 option:selected").text();
                if (venue == "" || venue == null) {
                    venue == "";
                } else {
                    venue = $("#venue1 option:selected").text();
                }

                var venueGroup = $("#venue1Group option:selected").text();
                if (venueGroup == "" || venueGroup == null) {
                    venueGroup == "";
                } else {
                    venueGroup = $("#venue1Group option:selected").text();
                }

                var group = $("#group option:selected").text();
                if (group == "" || group == null) {
                    group == "";
                } else {
                    group = $("#group option:selected").text();
                }

                var source = $("#source option:selected").text();
                if (source == "" || source == null) {
                    source == "";
                } else {
                    source = $("#source option:selected").text();
                }


                var DAYS0 = $("#DAYS0").val(); var DAYS2 = $("#DAYS2").val(); var DAYS4 = $("#DAYS4").val(); var DAYS6 = $("#DAYS6").val(); var DAYS8 = $("#DAYS8").val(); var DAYS10 = $("#DAYS10").val();
                var DAYS1 = $("#DAYS1").val(); var DAYS3 = $("#DAYS3").val(); var DAYS5 = $("#DAYS5").val(); var DAYS7 = $("#DAYS7").val(); var DAYS9 = $("#DAYS9").val(); var DAYS11 = $("#DAYS11").val();
                var DAYS = DAYS0 + ',' + DAYS1 + ',' + DAYS2 + ',' + DAYS3 + ',' + DAYS4 + ',' + DAYS5 + ',' + DAYS6 + ',' + DAYS7 + ',' + DAYS8 + ',' + DAYS9 + ',' + DAYS10 + ',' + DAYS11;
             //   alert(DAYS);

                var MONTH0 = $("#month0").val(); var MONTH2 = $("#month2").val(); var MONTH4 = $("#month4").val(); var MONTH6 = $("#month6").val(); var MONTH8 = $("#month8").val(); var MONTH10 = $("#month10").val();
                var MONTH1 = $("#month1").val(); var MONTH3 = $("#month3").val(); var MONTH5 = $("#month5").val(); var MONTH7 = $("#month7").val(); var MONTH9 = $("#month9").val(); var MONTH11 = $("#month11").val();
                var MONTH = MONTH0 + ',' + MONTH1 + ',' + MONTH2 + ',' + MONTH3 + ',' + MONTH4 + ',' + MONTH5 + ',' + MONTH6 + ',' + MONTH7 + ',' + MONTH8 + ',' + MONTH9 + ',' + MONTH10 + ',' + MONTH11;

               // alert(MONTH);
                var QT0 = $("#QT0").val(); var QT2 = $("#QT2").val(); var QT4 = $("#QT4").val(); var QT6 = $("#QT6").val(); var QT8 = $("#QT8").val(); var QT10 = $("#QT10").val();
                var QT1 = $("#QT1").val(); var QT3 = $("#QT3").val(); var QT5 = $("#QT5").val(); var QT7 = $("#QT7").val(); var QT9 = $("#QT9").val(); var QT11 = $("#QT11").val();
                var QT = QT0 + ',' + QT1 + ',' + QT2 + ',' + QT3 + ',' + QT4 + ',' + QT5 + ',' + QT6 + ',' + QT7 + ',' + QT8 + ',' + QT9 + ',' + QT10+','+QT11;
              //  alert(QT);

                var CLOSE0 = $("#Close0").val(); var CLOSE2 = $("#Close2").val(); var CLOSE4 = $("#Close4").val(); var CLOSE6 = $("#Close6").val(); var CLOSE8 = $("#Close8").val(); var CLOSE10 = $("#Close10").val();
                var CLOSE1 = $("#Close1").val(); var CLOSE3 = $("#Close3").val(); var CLOSE5 = $("#Close5").val(); var CLOSE7 = $("#Close7").val(); var CLOSE9 = $("#Close9").val(); var CLOSE11 = $("#Close11").val();
                var CLOSE = CLOSE0 + ',' + CLOSE1 + ',' + CLOSE2 + ',' + CLOSE3 + ',' + CLOSE4 + ',' + CLOSE5 + ',' + CLOSE6 + ',' + CLOSE7 + ',' + CLOSE8 + ',' + CLOSE9 + ',' + CLOSE10+','+CLOSE11;
              //  alert(CLOSE);

                var SALES0 = $("#sales0").val(); var SALES2 = $("#sales2").val(); var SALES4 = $("#sales4").val(); var SALES6 = $("#sales6").val(); var SALES8 = $("#sales8").val(); var SALES10 = $("#sales10").val();
                var SALES1 = $("#sales1").val(); var SALES3 = $("#sales3").val(); var SALES5 = $("#sales5").val(); var SALES7 = $("#sales7").val(); var SALES9 = $("#sales9").val(); var SALES11 = $("#sales11").val();
                var SALES = SALES0 + ',' + SALES1 + ',' + SALES2 + ',' + SALES3 + ',' + SALES4 + ',' + SALES5 + ',' + SALES6 + ',' + SALES7 + ',' + SALES8 + ',' + SALES9 + ',' + SALES10+','+SALES11;
             //   alert(SALES);

                var AVG0 = $("#Avg0").val(); var AVG2 = $("#Avg2").val(); var AVG4 = $("#Avg4").val(); var AVG6 = $("#Avg6").val(); var AVG8 = $("#Avg8").val(); var AVG10 = $("#Avg10").val();
                var AVG1 = $("#Avg1").val(); var AVG3 = $("#Avg3").val(); var AVG5 = $("#Avg5").val(); var AVG7 = $("#Avg7").val(); var AVG9 = $("#Avg9").val(); var AVG11 = $("#Avg11").val();
                var AVG = AVG0 + ',' + AVG1 + ',' + AVG2 + ',' + AVG3 + ',' + AVG4 + ',' + AVG5 + ',' + AVG6 + ',' + AVG7 + ',' + AVG8 + ',' + AVG9 + ',' + AVG10+','+AVG11;
               // alert(AVG);

                var GROSS0 = $("#Gross0").val(); var GROSS2 = $("#Gross2").val(); var GROSS4 = $("#Gross4").val(); var GROSS6 = $("#Gross6").val(); var GROSS8 = $("#Gross8").val(); var GROSS10 = $("#Gross10").val();
                var GROSS1 = $("#Gross1").val(); var GROSS3 = $("#Gross3").val(); var GROSS5 = $("#Gross5").val(); var GROSS7 = $("#Gross7").val(); var GROSS9 = $("#Gross9").val(); var GROSS11 = $("#Gross11").val();
                var GROSS = GROSS0 + ',' + GROSS1 + ',' + GROSS2 + ',' + GROSS3 + ',' + GROSS4 + ',' + GROSS5 + ',' + GROSS6 + ',' + GROSS7 + ',' + GROSS8 + ',' + GROSS9 + ',' + GROSS10 + ',' + GROSS11;
                //alert(GROSS);

                var PPN0 = Math.round($("#PPN0").val()); var PPN2 = Math.round($("#PPN2").val()); var PPN4 = Math.round($("#PPN4").val()); var PPN6 = Math.round($("#PPN6").val()); var PPN8 = Math.round($("#PPN8").val()); var PPN10 = Math.round($("#PPN10").val());
                var PPN1 = Math.round($("#PPN1").val()); var PPN3 = Math.round($("#PPN3").val()); var PPN5 = Math.round($("#PPN5").val()); var PPN7 = Math.round($("#PPN7").val()); var PPN9 = Math.round($("#PPN9").val()); var PPN11 = Math.round($("#PPN11").val());
                var PPN = PPN0 + ',' + PPN1 + ',' + PPN2 + ',' + PPN3 + ',' + PPN4 + ',' + PPN5 + ',' + PPN6 + ',' + PPN7 + ',' + PPN8 + ',' + PPN9 + ',' + PPN10 + ',' + PPN11;
              //  alert(PPN);

                var ADMIN0 = $("#Admin0").val(); var ADMIN2 = $("#Admin2").val(); var ADMIN4 = $("#Admin4").val(); var ADMIN6 = $("#Admin6").val(); var ADMIN8 = $("#Admin8").val(); var ADMIN10 = $("#Admin10").val();
                var ADMIN1 = $("#Admin1").val(); var ADMIN3 = $("#Admin3").val(); var ADMIN5 = $("#Admin5").val(); var ADMIN7 = $("#Admin7").val(); var ADMIN9 = $("#Admin9").val(); var ADMIN11 = $("#Admin11").val();
                var ADMIN = ADMIN0 + ',' + ADMIN1 + ',' + ADMIN2 + ',' + ADMIN3 + ',' + ADMIN4 + ',' + ADMIN5 + ',' + ADMIN6 + ',' + ADMIN7 + ',' + ADMIN8 + ',' + ADMIN9 + ',' + ADMIN10 + ',' + ADMIN11;
              //  alert(ADMIN);

                var NET0 = $("#Net0").val(); var NET2 = $("#Net2").val(); var NET4 = $("#Net4").val(); var NET6 = $("#Net6").val(); var NET8 = $("#Net8").val(); var NET10 = $("#Net10").val();
                var NET1 = $("#Net1").val(); var NET3 = $("#Net3").val(); var NET5 = $("#Net5").val(); var NET7 = $("#Net7").val(); var NET9 = $("#Net9").val(); var NET11= $("#Net11").val();
                var NET = NET0 + ',' + NET1 + ',' + NET2 + ',' + NET3 + ',' + NET4 + ',' + NET5 + ',' + NET6 + ',' + NET7 + ',' + NET8 + ',' + NET9 + ',' + NET10 + ',' + NET11;
              //  alert(NET);

                $.ajax({

                    type:'Post',
                    url: 'Budget.aspx/insertBudget',
                    contentType:"application/json; charset=utf-8",
                    data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','QT':'" + QT + "','CLOSE':'" + CLOSE + "','SALES':'" + SALES + "','AVG':'" + AVG + "','GROSS':'" + GROSS + "','PPN':'" + PPN + "','ADMIN':'" + ADMIN + "','NET':'" + NET + "','group':'" + group + "','source':'" + source + "','MONTH':'" + MONTH + "','DAYS':'"+DAYS+"'}",
                    async: false,
                    success: function (data) {
                      
                        $("#year").val('');
                        $("#country1").val('');
                        $("#venue1").val('');
                        $("#venue1Group").val('');

                        $("#QT0").val(''); $("#QT1").val(''); $("#QT2").val(''); $("#QT3").val(''); $("#QT4").val(''); $("#QT5").val(''); $("#QT6").val(''); $("#QT7").val(''); $("#QT8").val(''); $("#QT9").val(''); $("#QT10").val(''); $("#QT11").val('');
                        $("#Close0").val(''); $("#Close1").val(''); $("#Close2").val(''); $("#Close3").val(''); $("#Close4").val(''); $("#Close5").val(''); $("#Close6").val(''); $("#Close7").val(''); $("#Close8").val(''); $("#Close9").val(''); $("#Close10").val(''); $("#Close11").val('');
                        $("#sales0").val(''); $("#sales1").val(''); $("#sales2").val(''); $("#sales3").val(''); $("#sales4").val(''); $("#sales5").val(''); $("#sales6").val(''); $("#sales7").val(''); $("#sales8").val(''); $("#sales9").val(''); $("#sales10").val(''); $("#sales11").val('');
                        $("#Avg0").val(''); $("#Avg1").val(''); $("#Avg2").val(''); $("#Avg3").val(''); $("#Avg4").val(''); $("#Avg5").val(''); $("#Avg6").val(''); $("#Avg7").val(''); $("#Avg8").val(''); $("#Avg9").val(''); $("#Avg10").val(''); $("#Avg11").val('');
                        $("#Gross0").val(''); $("#Gross1").val(''); $("#Gross2").val(''); $("#Gross3").val(''); $("#Gross4").val(''); $("#Gross5").val(''); $("#Gross6").val(''); $("#Gross7").val(''); $("#Gross8").val(''); $("#Gross9").val(''); $("#Gross10").val(''); $("#Gross11").val('');
                        $("#PPN0").val(''); $("#PPN1").val(''); $("#PPN2").val(''); $("#PPN3").val(''); $("#PPN4").val(''); $("#PPN5").val(''); $("#PPN6").val(''); $("#PPN7").val(''); $("#PPN8").val(''); $("#PPN9").val(''); $("#PPN10").val(''); $("#PPN11").val('');
                        $("#Admin0").val(''); $("#Admin1").val(''); $("#Admin2").val(''); $("#Admin3").val(''); $("#Admin4").val(''); $("#Admin5").val(''); $("#Admin6").val(''); $("#Admin7").val(''); $("#Admin8").val(''); $("#Admin9").val(''); $("#Admin10").val(''); $("#Admin11").val('');
                        $("#Net0").val(''); $("#Net1").val(''); $("#Net2").val(''); $("#Net3").val(''); $("#Net4").val(''); $("#Net5").val(''); $("#Net6").val(''); $("#Net7").val(''); $("#Net8").val(''); $("#Net9").val(''); $("#Net10").val(''); $("#Net11").val('');
                        $("#DAYS0").val(''); $("#DAYS1").val(''); $("#DAYS2").val(''); $("#DAYS3").val(''); $("#DAYS4").val(''); $("#DAYS5").val(''); $("#DAYS6").val(''); $("#DAYS7").val(''); $("#DAYS8").val(''); $("#DAYS9").val(''); $("#DAYS10").val(''); $("#DAYS11").val('');
                        window.location.reload();
                        $("#success-alert").fadeTo(1500, 500).slideUp(500, function () {
                            $("#success-alert").slideUp(500);
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

            $.ajax({

                type: 'Post',
                url: 'Budget.aspx/getAdminRights',
                contentType: "application/json; charset=utf-8",
                data: "{}",
                async: false,
                success: function (data) {

                    $("#task-table1 tbody").empty();

                    subJson = JSON.parse(data.d);

                    $.each(subJson, function (key, value) {

                        $.each(value, function (index1, value1) {
                          

                                $("#task-table1 tbody").append("<tr><td><a href='"+value1[1]+"'>"+value1[0]+"</a></td></tr>");
                           
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
