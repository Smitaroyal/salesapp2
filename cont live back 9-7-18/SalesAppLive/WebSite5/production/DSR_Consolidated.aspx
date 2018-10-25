﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSR_Consolidated.aspx.cs" Inherits="WebSite5_production_Reports" %>

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

        #success-alert,#danger-alert,#hell1{
            display:none;
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
 


</head>
<body class="nav-md">
   
    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 col-sm-3 col-xs-9 col-lg-3 left_col">
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
                    <img src="images/img.jpg" alt=""><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
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
              <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
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
                <div class="container-fluid">
                   
          <div class="row">
          <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12 " id="head" ><br />
        <h3 class="text-center">DSR CONSOLIDATED</h3>
              </div>
              </div>
            </div>
              <br /><br />
                    <div class="container-fluid">

                        
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="">
                               <div class="form-group">
                                    <label for="sel1">Report Name:</label>

                                   <asp:TextBox ID="TextBox1" placeholder="" class="form-control" runat="server" value="DSR CONSOLIDATED" ReadOnly="true"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div id="hell">
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="date">
                                     <label for="sel1">Date:</label>
                              <div class="input-group date" id="datepicker1" data-provide="datepicker">
                                    <asp:TextBox ID="example1" placeholder="Select Date" class="form-control" runat="server" ></asp:TextBox>
      				<div class="input-group-addon">
                                      <span class="glyphicon glyphicon-th"></span>
                                  </div>
                              </div>

                          </div>
                      </div>
                              <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="">
                               <div class="form-group">
                                    <label for="sel1">Type:</label>
                                    <select class="form-control" name="reportName" id="reportName">
                                        <option disabled selected value>--Select an Option--</option>
                                        <option value=".xls">EXCEL</option>
				                    	<option value="dataonly">EXCEL(Data Only)</option>
                                      

                                    </select>
                                </div>
                            </div>
                        </div>
                      
                             </div>

                       
                  

                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-xs-9 col-lg-2">
                                <label for="sel1">&nbsp;</label>
                                <asp:Button ID="Button1" runat="server" class="btn btn-primary pull-right btn-block" Text="Generate" OnClick="Button1_Click" />
                                <%-- <button type="button" runat="server" id="insert" class="btn btn-primary pull-right btn-block">Generate</button>--%>
                            </div>
                        </div>


                    </div>

                  
        
                     <div class="container-fluid" id="directory">
                    <div class="row">
              
                   <div class="col-md-12 col-sm-12 col-xs-12  col-lg-12" "><br />
                        <h3 class="text-center"></h3>
                               </div>
              
              </div>
                      <div class="row">
                  <%-- <div class="col-md-4 col-md-offset-4" >
                    <div class="form-group">
                       <label for="sel1"></label>
                      <asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server"  data-table="table table-hover" ></asp:TextBox>
                  </div>
              </div>--%>
          </div>
          
                 
      
           
                    <table class="table table-hover" id="task-table">
            <thead>
                
            </thead>
            <tbody>
                
              
               

                </tbody>
            </table>
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
        New Message<button type="button" class="close compose-close">
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

  
       
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet">  
   
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"></script> 
               <script type="text/javascript">
           
            $(document).ready(function () {
                
                $('#datepicker1').datepicker({
                    format: "yyyy-mm-dd"
                });  
            
               

            });
        </script>

   
    
    <script>

        $(document).ready(function () {

            $.ajax({

                type: 'Post',
                url: 'DSR_Consolidated.aspx/getAdminRights',
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