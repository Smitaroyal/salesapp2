<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LastYearData.aspx.cs" Inherits="WebSite5_production_LastYearData" %>

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


        #sidebar-menu {
            position: fixed;
            width: 230px;
            margin-top: 70px;
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

        #searchPro {
            padding: 8px 40px;
            border-radius: 25px;
            margin-right: 10px;
            font-size: 13px;
            text-align: center;
        }

        .title {
            font-size: 13px;
            font-style: oblique;
        }

        #img {
            position: fixed;
            background: #04070B;
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

         #update,#head,#Group,#directory,#Odyssey,#MembMarkt,#insertButton,#Month11,#directory2,#update,#enable{
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
                    <div class="navbar nav_title" style="border-bottom: 2px; height: auto; color: #172D44;" id="img">

                        <img src="../production/images/KSC1.png" class="img-square" alt="" style="margin-top: 3px; margin-bottom: 5px;" width="200" height="53" /><br />

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
            <nav>
              <div class="nav toggle">
           <%--     <a id="menu_toggle"><i class="fa fa-bars"></i></a>--%>
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
              <button type="button" id="insertButton" class="btn btn-primary pull-right btn-block">Insert</button>
              <button type="button" id="view" class="btn btn-primary pull-right btn-block">View</button>      
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

               <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Month">
                  <div class="form-group">
                      <label for="sel1">Month:</label>
                      <select class="form-control"  id="month">
                          <option disabled selected value>Select an Option</option>
                          <option value="01">Jan</option>
                          <option value="02">Feb</option>
                           <option value="3">Mar</option>
                           <option value="4">Apr</option>
                           <option value="5">May</option>
                           <option value="6">June</option>
                           <option value="7">July</option>
                           <option value="8">Aug</option>
                           <option value="9">Sept</option>
                           <option value="10">Oct</option>
                           <option value="11">Nov</option>
                           <option value="12">Dec</option>
                      </select>
                  </div>
              </div>

              <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Month11">
                  <div class="form-group">
                      <label for="sel1">Month:</label>
                      <select class="form-control"  id="month11">
                          <option disabled selected value>Select an Option</option>
                          <option value="01">Jan</option>
                          <option value="02">Feb</option>
                           <option value="3">Mar</option>
                           <option value="4">Apr</option>
                           <option value="5">May</option>
                           <option value="6">June</option>
                           <option value="7">July</option>
                           <option value="8">Aug</option>
                           <option value="9">Sept</option>
                           <option value="10">Oct</option>
                           <option value="11">Nov</option>
                           <option value="12">Dec</option>
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
         
              </div>
            <div class="row">
                
               <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Venue">
                  <div class="form-group">
                      <label for="sel1">venue:</label>
                      <select class="form-control"  id="venue1">
                         
                          
                      </select>
                  </div>
              </div>
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

                <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Odyssey">
                    <div class="form-group">
                        <label for="sel1">Group:</label>
                        <select class="form-control" id="odyssey">
                            <option disabled selected value>Select an Option</option>
                            <option value="Odyssey Timeshare">Odyssey Timeshare</option>
                            <option value="Odyssey Fractional">Odyssey Fractional</option>
                        </select>
                    </div>
                </div>

                <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="MembMarkt">
                    <div class="form-group">
                        <label for="sel1">Group:</label>
                        <select class="form-control" id="membMarkt">
                            <option disabled selected value>Select an Option</option>
                            <option value="Member Marketing Timeshare">Member Marketing Timeshare</option>
                            <option value="Member Marketing Fractional">Member Marketing Fractional</option>
                        </select>
                    </div>
                </div>

                <div class="col-md-2 col-xs-9 col-sm-2 col-lg-2">
                    <label for="sel1">&nbsp;</label>
                    <button type="button" runat="server" id="insert" class="btn btn-primary pull-right btn-block">Insert</button>
                     <label for="sel1">&nbsp;</label>
                    <button type="button" runat="server" id="update" class="btn btn-primary pull-right btn-block">Update</button>
                     <label for="sel1">&nbsp;</label>
                     <button type="button" runat="server" id="enable" class="btn btn-primary pull-right btn-block">Edit</button>

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
                           <th>QT</th>
                           <th>SALES</th>
                           <th>VOL+ADMIN+TAX</th>
                       </tr>
                   </thead>
                   <tbody id="myTable">
                   </tbody>
               </table>
                           
                         </div>
               <div class="col-md-12 col-xs-12 col-sm-12 text-center">
                   <ul class="pagination pagination-lg pager" id="myPager"></ul>
               </div>
           </div>

                     </div>


                     <div class="container-fluid" id="directory2">
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
               <table class="table table-hover" id="task-table3">
                   <thead>
                       <tr>
                           <th>MONTH</th>
                           <th>QT</th>
                           <th>SALES</th>
                           <th>VOL+ADMIN+TAX</th>
                       </tr>
                   </thead>
                   <tbody id="myTable1">
                   </tbody>
               </table>
                           
                         </div>
               <div class="col-md-12 col-xs-12 col-sm-12 text-center">
                   <ul class="pagination pagination-lg pager" id="myPager1"></ul>
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
                        url: 'LastYearData.aspx/getVenueOnCountry',
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

                    if (venue=="V1") {
                        $("#VenueGroup").hide();

                        $.ajax({

                            type: 'Post',
                            url: 'LastYearData.aspx/getsourceOnVenue',
                            contentType: "application/json; charset=utf-8",
                            data: "{'venue':'" + venue + "'}",
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

                    } else{
                        $("#VenueGroup").show();
                        $("#Odyssey").hide();
                        $("#MembMarkt").hide();

                        $.ajax({

                            type: 'Post',
                            url: 'LastYearData.aspx/getVenueGroupOnVenue',
                            contentType: "application/json; charset=utf-8",
                            data: "{'venue':'" + venue + "'}",
                            async: false,
                            success: function (data) {

                                $("#venue1Group").empty();
                                $("#venue1Group").append("<option disabled selected value>Select an Option</option>");
                                $("#source").empty();
                                $("#source").append("<option disabled selected value>Select an Option</option>");
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
            }

                   


                });
            });

        </script>
    


          <script>
            $(document).ready(function () {

                $("#venue1Group").change(function () {
                    var venueGroup = $("#venue1Group").val();

                    $.ajax({

                        type: 'Post',
                        url: 'LastYearData.aspx/getSourceOnVenueGroup',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venueGroup':'" + venueGroup + "'}",
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

                $("#month").change(function () {
               
                    var year = $("#year").val();
                    var isValid = true;
                    if ($.trim($("#year").val()) == '') {
                        isValid = false;
                        alert("Select Year");
                        $("#year").css({

                            "border": "1px solid red",

                            "background": "#FFCECE"
                        });
                        if (isValid == false)
                            e.preventDefault();


                    } else {
                        $("#year").css({

                            "border": "",

                            "background": ""

                        });
                        // alert('Thank you for submitting');
                        //$("#TextBox1").val("");
                    }

                    var month = $("#month").val()

                    var current = 0;
                    $.ajax({

                        type: 'Post',
                        url: 'LastYearData.aspx/getdetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'"+year+"','month':'"+month+"'}",
                        async: false,
                        success: function (data) {
                          
                            $("#task-table tbody").empty();
                            $("#myPager").empty();
                            $("#directory").show();
                            subJson = JSON.parse(data.d);
                         
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                   
                                    $("#task-table tbody").append("<tr><td style='display:none'><input type='hidden' style='width:80px' name='month[]' id='month" + current + "' value='" + value1[0] + "'></td><td>" + value1[0] + "</td><td><input type='text' style='width:100px' name='QT[]' id='QT" + current + "'><td><input type='text' style='width:100px' name='SALES[]' id='SALES" + current + "'></td> <td><input type='text' style='width:100px' name='VAT[]' id='VAT" + current + "'></td></tr>");

                                    current++;
                                  
                                });
                            });

                            $.fn.pageMe = function (opts) {
                                var $this = this,
                                    defaults = {
                                        perPage: 7,
                                        showPrevNext: false,
                                        hidePageNumbers: false
                                    },
                                    settings = $.extend(defaults, opts);

                                var listElement = $this;
                                var perPage = settings.perPage;
                                var children = listElement.children();
                                var pager = $('.pager');

                                if (typeof settings.childSelector != "undefined") {
                                    children = listElement.find(settings.childSelector);
                                }

                                if (typeof settings.pagerSelector != "undefined") {
                                    pager = $(settings.pagerSelector);
                                }

                                var numItems = children.size();
                                var numPages = Math.ceil(numItems / perPage);

                                pager.data("curr", 0);

                                if (settings.showPrevNext) {
                                    $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
                                }

                                var curr = 0;
                                while (numPages > curr && (settings.hidePageNumbers == false)) {
                                    $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
                                    curr++;
                                }

                                if (settings.showPrevNext) {
                                    $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
                                }

                                pager.find('.page_link:first').addClass('active');
                                pager.find('.prev_link').hide();
                                if (numPages <= 1) {
                                    pager.find('.next_link').hide();
                                }
                                pager.children().eq(1).addClass("active");

                                children.hide();
                                children.slice(0, perPage).show();

                                pager.find('li .page_link').click(function () {
                                    var clickedPage = $(this).html().valueOf() - 1;
                                    goTo(clickedPage, perPage);
                                    return false;
                                });
                                pager.find('li .prev_link').click(function () {
                                    previous();
                                    return false;
                                });
                                pager.find('li .next_link').click(function () {
                                    next();
                                    return false;
                                });

                                function previous() {
                                    var goToPage = parseInt(pager.data("curr")) - 1;
                                    goTo(goToPage);
                                }

                                function next() {
                                    goToPage = parseInt(pager.data("curr")) + 1;
                                    goTo(goToPage);
                                }

                                function goTo(page) {
                                    var startAt = page * perPage,
                                        endOn = startAt + perPage;

                                    children.css('display', 'none').slice(startAt, endOn).show();

                                    if (page >= 1) {
                                        pager.find('.prev_link').show();
                                    }
                                    else {
                                        pager.find('.prev_link').hide();
                                    }

                                    if (page < (numPages - 1)) {
                                        pager.find('.next_link').show();
                                    }
                                    else {
                                        pager.find('.next_link').hide();
                                    }

                                    pager.data("curr", page);
                                    pager.children().removeClass("active");
                                    pager.children().eq(page + 1).addClass("active");

                                }
                            };

                            $(document).ready(function () {

                                $('#myTable').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 8 });

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

         <script>

        $(document).ready(function () {

            $("#source").change(function () {

                var source = $("#source option:selected").text();
                if (source == "Odyssey" || source == "ODYSSEY") {
                    $("#Odyssey").show();
                    $("#MembMarkt").hide();
                } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                    $("#Odyssey").hide();
                    $("#MembMarkt").show();
                } else {
                    $("#Odyssey").hide();
                    $("#MembMarkt").hide();
                }

            });

        });

    </script>

        


           
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
                if (country == "" || country == null || country == "Select an Option") {
                    country == "";
                } else {
                    country = $("#country1 option:selected").text();
                }

                var venue = $("#venue1 option:selected").text();
                if (venue == "" || venue == null || venue == "Select an Option") {
                    venue == "";
                } else {
                    venue = $("#venue1 option:selected").text();
                }

                var venueGroup = $("#venue1Group option:selected").text();
                if (venueGroup == "" || venueGroup == null || venueGroup == "Select an Option") {
                    venueGroup == "";
                } else {
                    venueGroup = $("#venue1Group option:selected").text();
                }

                var group = $("#group option:selected").text();
                if (group == "" || group == null || group == "Select an Option") {
                    group == "";
                } else {
                    group = $("#group option:selected").text();
                }

                var source = $("#source option:selected").text();
                if (source == "" || source == null || source == "Select an Option") {
                    source == "";
                } else {
                    source = $("#source option:selected").text();
                }

                if (source == "Odyssey" || source == "ODYSSEY") {

                    var sourceGroup = $("#odyssey option:selected").text();
                    if (sourceGroup == "" || sourceGroup == null || sourceGroup == "Select an Option") {
                        sourceGroup == "";
                    } else {

                        sourceGroup = $("#odyssey option:selected").text();
                    }

                } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                    var sourceGroup = $("#membMarkt option:selected").text();
                    if (sourceGroup == "" || sourceGroup == null || sourceGroup == "Select an Option") {
                        sourceGroup == "";
                    } else {

                        sourceGroup = $("#membMarkt option:selected").text();
                    }
                } else {
                    var sourceGroup = "";

                }


                var monthVals = "";
                var qtVals = "";
                var salesVals = "";
                var vatVals = "";

                $("input[name='month[]']").each(function () {

                    var monthVal = $(this).val();

                    monthVals += monthVal + ",";


                });

                $("input[name='QT[]']").each(function () {

                    var qtVal = $(this).val();

                    qtVals += qtVal + ",";


                });

                $("input[name='SALES[]']").each(function () {

                    var salesVal = $(this).val();

                    salesVals += salesVal + ",";


                });

                $("input[name='VAT[]']").each(function () {

                    var vatVal = $(this).val();

                    vatVals += vatVal + ",";


                });

                $.ajax({

                    type:'Post',
                    url: 'LastYearData.aspx/insertLastYearData',
                    contentType:"application/json; charset=utf-8",
                    data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','monthVals':'" + monthVals + "','qtVals':'" + qtVals + "','salesVals':'" + salesVals + "','vatVals':'" + vatVals + "','sourceGroup':'" + sourceGroup + "'}",
                    async: false,
                    success: function (data) {
                      
                        $("#year").val('');
                        $("#country1").val('');
                        $("#month").val('');
                        $("#venue1").val('');
                        $("#venue1Group").val('');
                        $("#source").val('');
                        $("#odyssey").val('');
                        $("#membMarkt").val('');
                        $("#directory").hide();
                        $(window).scrollTop(0);
                   
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

                $("#insertButton").click(function () {
                    $("#insertButton").hide();
                    $("#Month").show();
                    $("#Month11").hide();
                    $("#view").show();
                    $("#year").val('');
                    $("#month").val('');
                    $("#country1").val('');
                    $("#venue1").empty();
                    $("#venue1Group").empty();
                    $("#source").empty();
                    $("#odyssey").val('');
                    $("#month11").val('');
                    $("#membMarkt").val('');
                    $("#directory").hide();
                    $("#directory2").hide();
                    $("#insert").hide();
                    $("#update").hide();
                    $("#Odyssey").hide();
                    $("#MembMarkt").hide();
                    $("#enable").hide();
                    $("#insert").show();
                });
               
                $("#view").click(function () {
                    $("#insertButton").show();
                    $("#Month").hide();
                    $("#Month11").show();
                    $("#view").hide();
                    $("#year").val('');
                    $("#month").val('');
                    $("#month11").val('');
                    $("#country1").val('');
                    $("#venue1").empty();
                    $("#venue1Group").empty();
                    $("#source").empty();
                    $("#odyssey").val('');
                    $("#membMarkt").val('');
                    $("#directory").hide();
                    $("#insert").hide();
                    $("#update").hide();
                    $("#Odyssey").hide();
                    $("#MembMarkt").hide();
                });
            });


        </script>

        <script>

            $(document).ready(function () {
                $("#source").change(function () {

                    var year = $("#year").val();
                    if (year == "" || year == null) {
                        year == "";
                    } else {
                        var year = $("#year").val();
                    }

                    var month = $("#month11").val();
                    if (month == "" || month == null) {
                        month == "";
                    } else {
                        var month = $("#month11").val();
                    }

                    var country = $("#country1 option:selected").text();
                    if (country == "" || country == null || country == "Select an Option") {
                        country == ""; 
                    } else {
                        var country = $("#country1 option:selected").text();
                    }
                    var venue = $("#venue1 option:selected").text();
                    if (venue == "" || venue == null || venue == "Select an Option") {
                        venue == "";
                    } else {
                        var venue = $("#venue1 option:selected").text();
                    }
                    var venueGroup = $("#venue1Group option:selected").text();
                    if (venueGroup == "" || venueGroup == null || venueGroup == "Select an Option") {
                        venueGroup == "";
                    } else {
                        var venueGroup = $("#venue1Group option:selected").text();
                    }

                    var source = $("#source option:selected").text();
                    if (source == "" || source == null || source == "Select an Option") {
                        source == "";
                    } else {
                        var source = $("#source option:selected").text();

                    }

                    if (source == "Odyssey" || source == "ODYSSEY") {

                        var sourceGroup1 = $("#odyssey option:selected").text();
                        if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                            sourceGroup1 == "";
                        } else {

                            sourceGroup1 = $("#odyssey option:selected").text();
                        }

                    } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                        var sourceGroup1 = $("#membMarkt option:selected").text();
                        if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                            sourceGroup1 == "";
                        } else {

                            sourceGroup1 = $("#membMarkt option:selected").text();
                        }
                    } else {
                        var sourceGroup1 = "";

                    }


                    $("#odyssey").val('');
                    $("#membMarkt").val('');

                    if (source == "Odyssey" || source == "Member Marketing" || source == "ODYSSEY" || source == "MEMBER MARKETING") {

                    } else {
                        $.ajax({

                            type: 'Post',
                            url: 'LastYearData.aspx/getLastYearData',
                            contentType: "application/json; charset=utf-8",
                            data: "{'year':'" + year + "','month':'" + month + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                            async: false,
                            success: function (data) {
                              //  alert(data.d);
                                var current = 0;
                                $("#enable").show();
                                $("#directory2").show();
                                $('#directory2').css('pointer-events', 'none');
                                $("#task-table3 tbody").empty();
                                $("#myPager1").empty();
                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {
                                        if (value1[0]=="") {

                                        }else if (value1[0] == "0") {
                                            $("#directory2").hide();
                                            $("#enable").hide();
                                        } else {

                                            $("#task-table3 tbody").append("<tr><td style='display:none;'><input type='text' style='width:65px' name='id[]' id='id" + current + "' value='" + value1[0] + "'/></td><td><input type='text' style='width:110px; pointer-events:none;' name='month[]' id='month" + current + "' value='" + value1[1] + "'/></td><td><input type='text' style='width:110px' name='qt[]' id='qt" + current + "' value='" + value1[2] + "'/></td><td><input type='text' style='width:110px' name='saless[]' id='saless" + current + "' value='" + value1[3] + "'/></td><td><input type='text' style='width:110px' name='netvolume[]' id='netvolume" + current + "' value='" + value1[4] + "'/></td></tr>");
                                            current++;

                                        }
                                    });

                                });


                                $.fn.pageMe = function (opts) {
                                    var $this = this,
                                        defaults = {
                                            perPage: 7,
                                            showPrevNext: false,
                                            hidePageNumbers: false
                                        },
                                        settings = $.extend(defaults, opts);

                                    var listElement = $this;
                                    var perPage = settings.perPage;
                                    var children = listElement.children();
                                    var pager = $('.pager');

                                    if (typeof settings.childSelector != "undefined") {
                                        children = listElement.find(settings.childSelector);
                                    }

                                    if (typeof settings.pagerSelector != "undefined") {
                                        pager = $(settings.pagerSelector);
                                    }

                                    var numItems = children.size();
                                    var numPages = Math.ceil(numItems / perPage);

                                    pager.data("curr", 0);

                                    if (settings.showPrevNext) {
                                        $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
                                    }

                                    var curr = 0;
                                    while (numPages > curr && (settings.hidePageNumbers == false)) {
                                        $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
                                        curr++;
                                    }

                                    if (settings.showPrevNext) {
                                        $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
                                    }

                                    pager.find('.page_link:first').addClass('active');
                                    pager.find('.prev_link').hide();
                                    if (numPages <= 1) {
                                        pager.find('.next_link').hide();
                                    }
                                    pager.children().eq(1).addClass("active");

                                    children.hide();
                                    children.slice(0, perPage).show();

                                    pager.find('li .page_link').click(function () {
                                        var clickedPage = $(this).html().valueOf() - 1;
                                        goTo(clickedPage, perPage);
                                        return false;
                                    });
                                    pager.find('li .prev_link').click(function () {
                                        previous();
                                        return false;
                                    });
                                    pager.find('li .next_link').click(function () {
                                        next();
                                        return false;
                                    });

                                    function previous() {
                                        var goToPage = parseInt(pager.data("curr")) - 1;
                                        goTo(goToPage);
                                    }

                                    function next() {
                                        goToPage = parseInt(pager.data("curr")) + 1;
                                        goTo(goToPage);
                                    }

                                    function goTo(page) {
                                        var startAt = page * perPage,
                                            endOn = startAt + perPage;

                                        children.css('display', 'none').slice(startAt, endOn).show();

                                        if (page >= 1) {
                                            pager.find('.prev_link').show();
                                        }
                                        else {
                                            pager.find('.prev_link').hide();
                                        }

                                        if (page < (numPages - 1)) {
                                            pager.find('.next_link').show();
                                        }
                                        else {
                                            pager.find('.next_link').hide();
                                        }

                                        pager.data("curr", page);
                                        pager.children().removeClass("active");
                                        pager.children().eq(page + 1).addClass("active");

                                    }
                                };

                                $(document).ready(function () {

                                    $('#myTable1').pageMe({ pagerSelector: '#myPager1', showPrevNext: true, hidePageNumbers: false, perPage: 8 });

                                });
                            },
                            error: function (xhr, status, error) {
                                var err = JSON.parse(xhr.responseText);
                                alert(err.Message);
                            }

                        });
                        return false;
                    }

                });

                $("#odyssey").change(function () {

                    var year = $("#year").val();
                    if (year == "" || year == null) {
                        year == "";
                    } else {
                        var year = $("#year").val();
                    }

                    var month = $("#month11").val();
                    if (month == "" || month == null) {
                        month == "";
                    } else {
                        var month = $("#month11").val();
                    }


                    var country = $("#country1 option:selected").text();
                    if (country == "" || country == null || country == "Select an Option") {
                        country == "";
                    } else {
                        var country = $("#country1 option:selected").text();
                    }
                    var venue = $("#venue1 option:selected").text();
                    if (venue == "" || venue == null || venue == "Select an Option") {
                        venue == "";
                    } else {
                        var venue = $("#venue1 option:selected").text();
                    }
                    var venueGroup = "";
                    if (venueGroup == "" || venueGroup == null || venueGroup == "Select an Option") {
                        venueGroup == "";
                    } else {
                        var venueGroup = "";
                    }

                    var source = $("#source option:selected").text();
                    if (source == "" || source == null || source == "Select an Option") {
                        source == "";
                    } else {
                        var source = $("#source option:selected").text();

                    }

                    if (source == "Odyssey" || source == "ODYSSEY") {

                        var sourceGroup1 = $("#odyssey option:selected").text();
                        if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                            sourceGroup1 == "";
                        } else {

                            sourceGroup1 = $("#odyssey option:selected").text();
                        }

                    } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                        var sourceGroup1 = $("#membMarkt option:selected").text();
                        if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                            sourceGroup1 == "";
                        } else {

                            sourceGroup1 = $("#membMarkt option:selected").text();
                        }
                    } else {
                        var sourceGroup1 = "";

                    }

                    $.ajax({

                        type: 'Post',
                        url: 'LastYearData.aspx/getLastYearData',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                        async: false,
                        success: function (data) {
                            var current = 0;
                            $("#enable").show();
                            $("#directory2").show();
                            $('#directory2').css('pointer-events', 'none');
                            $("#task-table3 tbody").empty();
                            $("#myPager1").empty();
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {
                                    if (value1[0]=="") {

                                    }else if(value1[0] == "0") {
                                        $("#directory2").hide();
                                        $("#enable").hide();
                                    } else {

                                        $("#task-table3 tbody").append("<tr><td style='display:none;'><input type='text' style='width:65px' name='id[]' id='id" + current + "' value='" + value1[0] + "'/></td><td><input type='text' style='width:110px; pointer-events:none;' name='month[]' id='month" + current + "' value='" + value1[1] + "'/></td><td><input type='text' style='width:110px' name='qt[]' id='qt" + current + "' value='" + value1[2] + "'/></td><td><input type='text' style='width:110px' name='saless[]' id='saless" + current + "' value='" + value1[3] + "'/></td><td><input type='text' style='width:110px' name='netvolume[]' id='netvolume" + current + "' value='" + value1[4] + "'/></td></tr>");
                                        current++;

                                    }
                                });

                            });

                            $.fn.pageMe = function (opts) {
                                var $this = this,
                                    defaults = {
                                        perPage: 7,
                                        showPrevNext: false,
                                        hidePageNumbers: false
                                    },
                                    settings = $.extend(defaults, opts);

                                var listElement = $this;
                                var perPage = settings.perPage;
                                var children = listElement.children();
                                var pager = $('.pager');

                                if (typeof settings.childSelector != "undefined") {
                                    children = listElement.find(settings.childSelector);
                                }

                                if (typeof settings.pagerSelector != "undefined") {
                                    pager = $(settings.pagerSelector);
                                }

                                var numItems = children.size();
                                var numPages = Math.ceil(numItems / perPage);

                                pager.data("curr", 0);

                                if (settings.showPrevNext) {
                                    $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
                                }

                                var curr = 0;
                                while (numPages > curr && (settings.hidePageNumbers == false)) {
                                    $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
                                    curr++;
                                }

                                if (settings.showPrevNext) {
                                    $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
                                }

                                pager.find('.page_link:first').addClass('active');
                                pager.find('.prev_link').hide();
                                if (numPages <= 1) {
                                    pager.find('.next_link').hide();
                                }
                                pager.children().eq(1).addClass("active");

                                children.hide();
                                children.slice(0, perPage).show();

                                pager.find('li .page_link').click(function () {
                                    var clickedPage = $(this).html().valueOf() - 1;
                                    goTo(clickedPage, perPage);
                                    return false;
                                });
                                pager.find('li .prev_link').click(function () {
                                    previous();
                                    return false;
                                });
                                pager.find('li .next_link').click(function () {
                                    next();
                                    return false;
                                });

                                function previous() {
                                    var goToPage = parseInt(pager.data("curr")) - 1;
                                    goTo(goToPage);
                                }

                                function next() {
                                    goToPage = parseInt(pager.data("curr")) + 1;
                                    goTo(goToPage);
                                }

                                function goTo(page) {
                                    var startAt = page * perPage,
                                        endOn = startAt + perPage;

                                    children.css('display', 'none').slice(startAt, endOn).show();

                                    if (page >= 1) {
                                        pager.find('.prev_link').show();
                                    }
                                    else {
                                        pager.find('.prev_link').hide();
                                    }

                                    if (page < (numPages - 1)) {
                                        pager.find('.next_link').show();
                                    }
                                    else {
                                        pager.find('.next_link').hide();
                                    }

                                    pager.data("curr", page);
                                    pager.children().removeClass("active");
                                    pager.children().eq(page + 1).addClass("active");

                                }
                            };

                            $(document).ready(function () {

                                $('#myTable1').pageMe({ pagerSelector: '#myPager1', showPrevNext: true, hidePageNumbers: false, perPage: 8 });

                            });
                        },
                        error: function (xhr, status, error) {
                            var err = JSON.parse(xhr.responseText);
                            alert(err.Message);
                        }

                    });
                    return false;




                });


                $("#membMarkt").change(function () {

                    var year = $("#year").val();
                    if (year == "" || year == null) {
                        year == "";
                    } else {
                        var year = $("#year").val();
                    }

                    var month = $("#month11").val();
                    if (month == "" || month == null) {
                        month == "";
                    } else {
                        var month = $("#month11").val();
                    }
                   
                    var country = $("#country1 option:selected").text();
                    if (country == "" || country == null || country == "Select an Option") {
                        country == "";
                    } else {
                        var country = $("#country1 option:selected").text();
                    }
                    var venue = $("#venue1 option:selected").text();
                    if (venue == "" || venue == null || venue == "Select an Option") {
                        venue == "";
                    } else {
                        var venue = $("#venue1 option:selected").text();
                    }
                    var venueGroup = "";
                    if (venueGroup == "" || venueGroup == null || venueGroup == "Select an Option") {
                        venueGroup == "";
                    } else {
                        var venueGroup = "";
                    }

                    var source = $("#source option:selected").text();
                    if (source == "" || source == null || source == "Select an Option") {
                        source == "";
                    } else {
                        var source = $("#source option:selected").text();

                    }

                    if (source == "Odyssey" || source == "ODYSSEY") {

                        var sourceGroup1 = $("#odyssey option:selected").text();
                        if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                            sourceGroup1 == "";
                        } else {

                            sourceGroup1 = $("#odyssey option:selected").text();
                        }

                    } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                        var sourceGroup1 = $("#membMarkt option:selected").text();
                        if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                            sourceGroup1 == "";
                        } else {

                            sourceGroup1 = $("#membMarkt option:selected").text();
                        }
                    } else {
                        var sourceGroup1 = "";

                    }


                    $.ajax({

                        type: 'Post',
                        url: 'LastYearData.aspx/getLastYearData',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','month':'" + month + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                        async: false,
                        success: function (data) {
                            var current = 0;
                            $("#enable").show();
                            $("#update").hide();
                            $("#directory2").show();
                            $("#enable").show();
                            $('#directory2').css('pointer-events', 'none');
                            $("#task-table3 tbody").empty();
                            $("#myPager1").empty();
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {
                                    if (value1[0] == "") {

                                    } else if (value1[0] == "0") {
                                        $("#directory2").hide();
                                        $("#enable").hide();
                                    } else {

                                        $("#task-table3 tbody").append("<tr><td style='display:none;'><input type='text' style='width:65px' name='id[]' id='id" + current + "' value='" + value1[0] + "'/></td><td><input type='text' style='width:110px; pointer-events:none;' name='month[]' id='month" + current + "' value='" + value1[1] + "'/></td><td><input type='text' style='width:110px' name='qt[]' id='qt" + current + "' value='" + value1[2] + "'/></td><td><input type='text' style='width:110px' name='saless[]' id='saless" + current + "' value='" + value1[3] + "'/></td><td><input type='text' style='width:110px' name='netvolume[]' id='netvolume" + current + "' value='" + value1[4] + "'/></td></tr>");
                                        current++;

                                    }
                                });

                            });


                            $.fn.pageMe = function (opts) {
                                var $this = this,
                                    defaults = {
                                        perPage: 7,
                                        showPrevNext: false,
                                        hidePageNumbers: false
                                    },
                                    settings = $.extend(defaults, opts);

                                var listElement = $this;
                                var perPage = settings.perPage;
                                var children = listElement.children();
                                var pager = $('.pager');

                                if (typeof settings.childSelector != "undefined") {
                                    children = listElement.find(settings.childSelector);
                                }

                                if (typeof settings.pagerSelector != "undefined") {
                                    pager = $(settings.pagerSelector);
                                }

                                var numItems = children.size();
                                var numPages = Math.ceil(numItems / perPage);

                                pager.data("curr", 0);

                                if (settings.showPrevNext) {
                                    $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
                                }

                                var curr = 0;
                                while (numPages > curr && (settings.hidePageNumbers == false)) {
                                    $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
                                    curr++;
                                }

                                if (settings.showPrevNext) {
                                    $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
                                }

                                pager.find('.page_link:first').addClass('active');
                                pager.find('.prev_link').hide();
                                if (numPages <= 1) {
                                    pager.find('.next_link').hide();
                                }
                                pager.children().eq(1).addClass("active");

                                children.hide();
                                children.slice(0, perPage).show();

                                pager.find('li .page_link').click(function () {
                                    var clickedPage = $(this).html().valueOf() - 1;
                                    goTo(clickedPage, perPage);
                                    return false;
                                });
                                pager.find('li .prev_link').click(function () {
                                    previous();
                                    return false;
                                });
                                pager.find('li .next_link').click(function () {
                                    next();
                                    return false;
                                });

                                function previous() {
                                    var goToPage = parseInt(pager.data("curr")) - 1;
                                    goTo(goToPage);
                                }

                                function next() {
                                    goToPage = parseInt(pager.data("curr")) + 1;
                                    goTo(goToPage);
                                }

                                function goTo(page) {
                                    var startAt = page * perPage,
                                        endOn = startAt + perPage;

                                    children.css('display', 'none').slice(startAt, endOn).show();

                                    if (page >= 1) {
                                        pager.find('.prev_link').show();
                                    }
                                    else {
                                        pager.find('.prev_link').hide();
                                    }

                                    if (page < (numPages - 1)) {
                                        pager.find('.next_link').show();
                                    }
                                    else {
                                        pager.find('.next_link').hide();
                                    }

                                    pager.data("curr", page);
                                    pager.children().removeClass("active");
                                    pager.children().eq(page + 1).addClass("active");

                                }
                            };

                            $(document).ready(function () {

                                $('#myTable1').pageMe({ pagerSelector: '#myPager1', showPrevNext: true, hidePageNumbers: false, perPage: 8 });

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
                $("#enable").click(function () {
                    $("#enable").hide();
                    $("#update").show();
                    $('#directory2').css('pointer-events', 'auto');

                });
            });
        </script>


        <script>
            $(document).ready(function () {
                $("#update").click(function () {
                    var idVals1 = "";
                    var qtVals1 = "";
                    var salesVals1 = "";
                    var vatVals1 = "";

                    $("input[name='id[]']").each(function () {

                        var idVal1 = $(this).val();

                        idVals1 += idVal1 + ",";


                    });


                    $("input[name='qt[]']").each(function () {

                        var qtVal1 = $(this).val();

                        qtVals1 += qtVal1 + ",";


                    });

                    $("input[name='saless[]']").each(function () {

                        var salesVal1 = $(this).val();

                        salesVals1 += salesVal1 + ",";


                    });

                    $("input[name='netvolume[]']").each(function () {

                        var vatVal1 = $(this).val();

                        vatVals1 += vatVal1 + ",";


                    });

                    $.ajax({

                        type: 'Post',
                        url: 'LastYearData.aspx/updateLastYearData',
                        contentType: "application/json; charset=utf-8",
                        data: "{'idVals1':'" + idVals1 + "','qtVals1':'" + qtVals1 + "','salesVals1':'" + salesVals1 + "','vatVals1':'" + vatVals1 + "'}",
                        async: false,
                        success: function (data) {
                            $("input[name='qt[]']").each(function () {
                                $(this).empty();
                            });
                            $("input[name='saless[]']").each(function () {
                                $(this).empty();
                            });
                            $("input[name='netvolume[]']").each(function () {
                                $(this).empty();
                            });

                            $("#update").hide();
                            $("#Odyssey").hide();
                            $("#MembMarkt").hide();
                            $("#year").val('');
                            $("#country1").val('');
                            $("#month11").val('');
                            $("#venue1").empty();
                            $("#venue1Group").empty();
                            $("#source").empty();
                            $("#odyssey").val('');
                            $("#membMarkt").val('');
                            $("#directory2").hide();
                            $('#directory2').css('pointer-events', 'none');
                            $(window).scrollTop(0);

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
                url: 'LastYearData.aspx/getAdminRights',
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
    
        <script>

        $(document).ready(function () {

            $("#searchPro").keyup(function () {
                
                var profileID = $("#searchPro").val();

                $.ajax({

                    type: 'Post',
                    url: 'LastYearData.aspx/searchProfile',
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
                    url: 'LastYearData.aspx/getlink',
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
