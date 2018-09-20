<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Venue2.aspx.cs" Inherits="WebSite5_production_Venue2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="jquery-3.2.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.2.1.min.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title> </title>
    
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
   
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

    .title{
           font-size:13px;
      font-style:oblique;
        }

        #img {
            position:fixed;
            background: #04070B;
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

    #success-alert,#danger-alert,#danger-alert1,#menu_toggle,#profileDetails{
            display:none;
        }
               
                
      #update,#head,#venue2ID,#venueCountry,#venue2Name,#venue2Status,#Venue,#directory,#insert,#Type1,#cgsCode,#cglCode,#fgsCode,#fglCode,#fiVal,#suffixCode,#contPVal{
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
   
    <!-- bootstrap-wysiwyg -->
    <link href="../vendors/google-code-prettify/bin/prettify.min.css" rel="stylesheet">

    <!-- Custom styling plus plugins -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
</head>
<body class="nav-md">

    <div class="container body">
        <div class="main_container">
            <div class="col-md-3 col-sm-3 col-xs-9 col-lg-3 left_col">
                  <div class="left_col scroll-view">
                    <div class="navbar nav_title" style="border-bottom: 2px; height:auto; color: #172D44;" id="img">

                          <img src="../production/images/Gold.png" class="img-square" alt="" style="margin-top:3px; margin-bottom:5px;"  width="150" height="50" /><br />
                      
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
  <form id="form1" runat="server">
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
                    <!--<img src="images/img.jpg" alt=""/>-->
<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <span class=" fa fa-angle-down"></span>
                  </a>
                  <ul class="dropdown-menu dropdown-usermenu pull-right">
                    <li><a href="Profile_Page.aspx">Change Password</a></li>
                   
                     <li><a href="#addEmployeeModal" data-toggle="modal">Setting</a></li>
                    <li><a href="logout.aspx"><i class="fa fa-sign-out pull-right"></i> Log Out</a></li>
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
          </div>
        </div>
        <!-- /top navigation -->

        <!-- page content -->
         
        <div class="right_col" role="main">
          <div class="">

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
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
                                            <div style="overflow: scroll; height: 200px; width: 100%; overflow: auto">
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
          <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12 " id="head" ><br />
        <h3 class="text-center">ADD VENUE 2</h3>
              </div>
              </div>
            </div>
              <br /><br />
        <div class="container-fluid">
          <div class="row"> 
              

              <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="venue2ID">
                  <div class="form-group">
                      <label for="sel1">Venue 2 ID:</label>
                      <asp:TextBox ID="TextBox1" class="form-control pull-right"  runat="server" ReadOnly></asp:TextBox>
                     
                  </div>
              </div>

              <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="venue2Name">
                  <div class="form-group">
                      <label for="sel1">Venue 2 Name:</label>
                      <asp:TextBox ID="TextBox2" class="form-control pull-right" placeholder="Enter Venue 2" runat="server"></asp:TextBox>
                  </div>
              </div>
               
               <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="venue2Status">
                  <div class="form-group">
                      <label for="sel1">Status:</label>
                      <select class="form-control"  id="status">
                          <option disabled selected value>Select an Option</option>
                          <option value="Active">Active</option>
                          <option value="Inactive">Inactive</option>
                      </select>
                  </div>
              </div>
              
              <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="venueCountry">
                  <div class="form-group">
                      <label for="sel1">Venue Country:</label>
                      <select class="form-control"  id="venuecountry">
                          <option disabled selected value>Select an Option</option>
                     <%Response.Write(getAllVenueCountry()); %>
                      </select>
                  </div>
              </div>

              <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="Venue">
                  <div class="form-group">
                      <label for="sel1">Venue:</label>
                      <select class="form-control" id="venue">
                      </select>
                  </div>
              </div>
               <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="cgsCode">
                  <div class="form-group">
                      <label for="sel1">Cont Gen Start Code:</label>
                      <asp:TextBox ID="TextBox3" class="form-control pull-right" placeholder="Enter Start Code" runat="server"></asp:TextBox>
                  </div>
              </div>   

              
                   <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="cglCode">
                  <div class="form-group">
                      <label for="sel1">Cont Gen Last Code:</label>
                      <asp:TextBox ID="TextBox4" class="form-control pull-right" placeholder="Enter Last Code" runat="server"></asp:TextBox>
                  </div>
              </div>
             

          </div>

            <div class="row">
               

                   <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="fgsCode">
                  <div class="form-group">
                      <label for="sel1">Frac Gen Start Code:</label>
                      <asp:TextBox ID="TextBox6" class="form-control pull-right" placeholder="Enter Start Code" runat="server"></asp:TextBox>
                  </div>
              </div>

                   <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="fglCode">
                  <div class="form-group">
                      <label for="sel1">Frac Gen Last Code:</label>
                      <asp:TextBox ID="TextBox7" class="form-control pull-right" placeholder="Enter Last Code" runat="server"></asp:TextBox>
                  </div>
              </div>

                   <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="fiVal">
                  <div class="form-group">
                      <label for="sel1">Frac Inc Val:</label>
                      <asp:TextBox ID="TextBox8" class="form-control pull-right" placeholder="Enter Inc Val" runat="server"></asp:TextBox>
                  </div>
              </div>
                 <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="suffixCode">
                  <div class="form-group">
                      <label for="sel1">Suffix Code:</label>
                      <asp:TextBox ID="TextBox9" class="form-control pull-right" placeholder="Enter Code" runat="server"></asp:TextBox>
                  </div>
              </div>
                    <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="contPVal">
                  <div class="form-group">
                      <label for="sel1">Points Inc Val:</label>
                      <asp:TextBox ID="TextBox10" class="form-control pull-right" placeholder="Enter Inc Val" runat="server"></asp:TextBox>
                  </div>
              </div>

                 <div class="col-md-2 col-sm-2 col-xs-9 col-lg-2">
                  <label for="sel1">&nbsp;</label>

                  <button type="button" runat="server" id="insert" class="btn btn-primary pull-right btn-block">Insert</button>
                  <label for="sel1">&nbsp;</label>
                  <button type="button" runat="server" id="update" class="btn btn-primary pull-right btn-block">Update</button>

              </div>
            </div>
        </div>

                    <div class="container-fluid" id="directory">
                        <div class="row">

          <div class="col-md-12 col-sm-12 col-xs-12  col-lg-12 " ">
              <h3 class="text-center">VENUE 2 DIRECTORY</h3>
          </div>
                        </div>
                        <div class="row">

                            <div class="col-md-4 col-md-offset-4 col-sm-4 col-sm-offset-4 col-xs-6 col-xs-offset-3 col-lg-4 col-lg-offset-4">
                                <div class="form-group">
                                    <label for="sel1"></label>
                                    <asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server" placeholder="Search" data-table="table table-hover"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="table-responsive">
                            <table class="table table-hover" id="task-table">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>VENUE 2</th>
                                        <th>STATUS</th>
                                        <th>COUNTRY</th>
                                        <th>VENUE</th>
                                        <th>CGS CODE</th>
                                        <th>CGL CODE</th>
                                        <th>FGS CODE</th>
                                        <th>FGL CODE</th>
                                        <th>FINC VAL</th>
                                        <th>SUFFIX CODE</th>
                                        <th>PINC VAL</th>
                                        <th>EDIT</th>
                                        <th>DELETE</th>
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

            $('#form1').bind('keydown', function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                }
            });
        </script>
    
    <script>

        $(document).ready(function () {
           
            $("#insert").click(function () {
                var venue2Name = $("#TextBox2").val();
                if (venue2Name == "" || venue2Name == null) {
                    venue2Name = "";
                } else {
                    venue2Name = $("#TextBox2").val();
                }
                
                var venueCountry = $("#venuecountry").val();
                if (venueCountry == "" || venueCountry == null) {
                    venueCountry = "";
                } else {
                    venueCountry = $("#venuecountry").val();
                }
                var venue = $("#venue").val();
                if (venue == "" || venue == null) {
                    venue = "";
                } else {
                    venue = $("#venue").val();
                }
                var cgsCode = $("#TextBox3").val();
                if (cgsCode == "" || cgsCode == null) {
                    cgsCode = "";
                } else {
                    cgsCode = $("#TextBox3").val();
                }
                var cglCode = $("#TextBox4").val();
                if (cglCode == "" || cglCode == null) {
                    cglCode = "";
                } else {
                    cglCode = $("#TextBox4").val();
                }
                var fgsCode = $("#TextBox6").val();
                if (fgsCode == "" || fgsCode == null) {
                    fgsCode = "";
                } else {
                    fgsCode = $("#TextBox6").val();
                }

                var fglCode = $("#TextBox7").val();
                if (fglCode == "" || fglCode == null) {
                    fglCode = "";
                } else {
                    fglCode = $("#TextBox7").val();
                }

                var fiVal = $("#TextBox8").val();
                if (fiVal == "" || fiVal == null) {
                    fiVal = "";
                } else {
                    fiVal = $("#TextBox8").val();
                }

                var suffCode = $("#TextBox9").val();
                if (suffCode == "" || suffCode == null) {
                    suffCode = "";
                } else {
                    suffCode = $("#TextBox9").val();
                }

                var contPVal = $("#TextBox10").val();
                if (contPVal == "" || contPVal == null) {
                    contPVal = "";
                } else {
                    contPVal = $("#TextBox10").val();
                }

               // alert(suffCode);
                $.ajax({

                    type:'Post',
                    url: 'Venue2.aspx/insertVenue2',
                    contentType:"application/json; charset=utf-8",
                    data: "{'venue2Name':'" + venue2Name + "','venueCountry':'" + venueCountry + "','venue':'" + venue + "','cgsCode':'" + cgsCode + "','cglCode':'" + cglCode + "','fgsCode':'" + fgsCode + "','fglCode':'" + fglCode + "','fiVal':'" + fiVal + "','suffCode':'" + suffCode + "','contPVal':'" + contPVal + "'}",
                    async: false,
                    success: function (data) {
                        $("#TextBox2").val("");
                        $("#TextBox3").val("");
                        $("#TextBox4").val("");
                        $("#TextBox6").val("");
                        $("#TextBox7").val("");
                        $("#TextBox8").val("");
                        $("#TextBox9").val("");
                        $("#TextBox10").val("");
                        $("#venue").empty();
                        $("#status").val('');
                      
                        $("#venuecountry").val('');
                      
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
                    $("#head").show();
                    $("#contPVal").show();
                    $("#Type1").show();
                    $("#venue2Name").show();
                    $("#venue2Status").hide();
                    $("#venueCountry").show();
                    $("#cgsCode").show();
                    $("#cglCode").show();
                    $("#fgsCode").show();
                    $("#fglCode").show();
                    $("#fiVal").show();
                    $("#suffixCode").show();
                    $("#Venue").show();
                    $("#insert").show();
                    $("#insertButton").hide();
                    $("#view").show();
                    $("#directory").hide();
                    $("#update").hide();
                    $("#venue2ID").hide();
                    $("#TextBox1").val("");
                    $("#TextBox2").val("");
                    $("#TextBox3").val("");
                    $("#TextBox5").val("");
                    $("#TextBox4").val("");
                    $("#TextBox6").val("");
                    $("#TextBox7").val("");
                    $("#TextBox8").val("");
                    $("#TextBox9").val("");
                    $("#TextBox10").val("");
                    $("#status").val('');
                    $("#venuecountry").val('');
                    $("#type").val('');
                    $("#venue").empty();

                });
                $("#view").click(function () {
                    $("#contPVal").hide();
                    $("#head").hide();
                    $("#venue2Name").hide();
                    $("#Type1").hide();
                    $("#venue2Status").hide();
                    $("#insert").hide();
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#directory").show();
                    $("#venue2ID").hide();
                    $("#update").hide();
                    $("#venueCountry").hide();
                    $("#suffixCode").hide();
                    $("#Venue").hide();
                    $("#TextBox5").val("");
                    $("#cgsCode").hide();
                    $("#cglCode").hide();
                    $("#fgsCode").hide();
                    $("#fglCode").hide();
                    $("#fiVal").hide();

                });
                $(document).on('click','.edit-btn', function () {
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#suffixCode").show();
                    $("#venue2ID").hide();
                    $("#venue2Name").show();
                    $("#venueCountry").show();
                    $("#venue2Status").show();
                    $("#description").show();
                    $("#Type1").hide();
                    $("#cgsCode").show();
                    $("#cglCode").show();
                    $("#fgsCode").show();
                    $("#fglCode").show();
                    $("#fiVal").show();
                    $("#contPVal").show();
                    $("#Venue").show();
                    $("#update").show();
                
                    $("#directory").hide();
                   

                    var row = $(this).closest("tr");
                    var venue2ID = row.find("td:eq(0)").text();
                    var venue2Name = row.find("td:eq(1)").text();
                    var status = row.find("td:eq(2)").text();
                    var venueCountryID = row.find("td:eq(3)").text();
                  //  var venueID = row.find("td:eq(5)").text();
                    var cgsCode = row.find("td:eq(7)").text();
                    var cglCode = row.find("td:eq(8)").text();
                    var fgsCode = row.find("td:eq(9)").text();
                    var fglCode = row.find("td:eq(10)").text();
                    var fiVal = row.find("td:eq(11)").text();
                    var suffixCode = row.find("td:eq(12)").text();
                    var contPointsVal = row.find("td:eq(13)").text();
                   // alert(venue);
               


                    $("#TextBox1").val(venue2ID);
                    $("#TextBox2").val(venue2Name);
                    $("#status option[value='" + status + "']").prop('selected', true);
                    $("#venuecountry option[value='" + venueCountryID + "']").prop('selected', true);
                    $("#TextBox3").val(cgsCode);
                    $("#TextBox4").val(cglCode);
                    $("#TextBox6").val(fgsCode);
                    $("#TextBox7").val(fglCode);
                    $("#TextBox8").val(fiVal);
                    $("#TextBox9").val(suffixCode);
                    $("#TextBox10").val(contPointsVal);
                   // $("#venue option[value='" + venueID + "']").prop('selected', true);


                    var venuecountryID = $("#venuecountry").val();
                    $.ajax({

                        type: 'Post',
                        url: 'Venue2.aspx/getAllVenue1',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venuecountryID':'" + venuecountryID + "'}",
                        async: false,
                        success: function (data) {
                            $("#venue").empty();
                            $("#venue").append("<option disabled selected value>Select an Option</option>");
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $("#venue").append("<option value='" + value1[1] + "'>" + value1[0] + "</option>");

                                });





                            });


                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });
                    var row = $(this).closest("tr");
                    var venue = row.find("td:eq(5)").text();
                   
                    $("#venue option[value='" + venue + "']").prop('selected', true);
                });
                

            });
        </script>
        



        <script>
            $(document).ready(function () {

                $("#view").click(function () {

                    $.ajax({

                        type: 'Post',
                        url: 'Venue2.aspx/getAllVenue2',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                           // alert(data.d);
                            $("#task-table tbody").empty();
                            $("#myPager").empty();
                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {

                                    $("#task-table tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td style='display:none;'>" + value1[3] + "</td><td>" + value1[4] + "</td><td style='display:none;'>" + value1[5] + "</td><td>" + value1[6] + "</td><td>" + value1[7] + "</td><td>" + value1[8] + "</td><td>" + value1[9] + "</td><td>" + value1[10] + "</td><td>" + value1[11] + "</td><td>" + value1[12] + "</td><td>" + value1[13] + "</td><td><button type='button'  class='edit-btn btn btn-primary col-md-12' >Edit</button></td><td><button type='button'  class='delete-btn btn btn-primary col-md-12' >Delete</button></td></tr>");

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

                                $('#myTable').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 7 });

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
                $(document).on('click', '.delete-btn', function () {
                    var row = $(this).closest("tr");
                    var venue2ID = row.find("td:eq(0)").text();
                    var venue2Name = row.find("td:eq(1)").text();
                
                    var confirmation = confirm("are you sure you want to delete " + venue2Name + " ?");

                    if (confirmation) {

                        $.ajax({
                            type: 'POST',
                            url: 'Venue2.aspx/deleteVenue2',
                            contentType: "application/json; charset=utf-8",
                            data: "{'venue2ID':'" + venue2ID + "','venue2Name':'" + venue2Name + "'}",
                            async: false,
                            success: function (data) {
                                $("#TextBox5").val("");
                                $("#directory").hide();
                                $("#view").show();
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
                        $(this).parents("tr").remove();
                    }
                    return false;
                   

                });


             

                });
         
        </script>

        <script>
            $(document).ready(function () {
                $("#update").click(function () {
                    $("#insertButton").hide();
                    $("#view").show();

                    var venue2ID = $("#TextBox1").val();
                    if (venue2ID == "" || venue2ID == null) {
                        venue2ID == "";
                    } else {
                        var venue2ID = $("#TextBox1").val();
                    }
                    var venue2Name = $("#TextBox2").val();
                    if (venue2Name == "" || venue2Name == null) {
                        venue2Name = "";
                    } else {
                        venue2Name = $("#TextBox2").val();
                    }

                    var status = $("#status").val();
                    if (status == "" || status == null) {
                        status = "";
                    } else {
                        status = $("#status").val();
                    }

                    var venueCountry = $("#venuecountry").val();
                    if (venueCountry == "" || venueCountry == null) {
                        venueCountry = "";
                    } else {
                        venueCountry = $("#venuecountry").val();
                    }
                    var venue = $("#venue").val();
                    if (venue == "" || venue == null) {
                        venue = "";
                    } else {
                        venue = $("#venue").val();
                    }
                    var cgsCode = $("#TextBox3").val();
                    if (cgsCode == "" || cgsCode == null) {
                        cgsCode = "";
                    } else {
                        cgsCode = $("#TextBox3").val();
                    }
                    var cglCode = $("#TextBox4").val();
                    if (cglCode == "" || cglCode == null) {
                        cglCode = "";
                    } else {
                        cglCode = $("#TextBox4").val();
                    }
                    var fgsCode = $("#TextBox6").val();
                    if (fgsCode == "" || fgsCode == null) {
                        fgsCode = "";
                    } else {
                        fgsCode = $("#TextBox6").val();
                    }

                    var fglCode = $("#TextBox7").val();
                    if (fglCode == "" || fglCode == null) {
                        fglCode = "";
                    } else {
                        fglCode = $("#TextBox7").val();
                    }

                    var fiVal = $("#TextBox8").val();
                    if (fiVal == "" || fiVal == null) {
                        fiVal = "";
                    } else {
                        fiVal = $("#TextBox8").val();
                    }

                    var suffixCode = $("#TextBox9").val();
                    if (suffixCode == "" || suffixCode == null) {
                        suffixCode = "";
                    } else {
                        suffixCode = $("#TextBox9").val();
                    }


                    var contPVal = $("#TextBox10").val();
                    if (contPVal == "" || contPVal == null) {
                        contPVal = "";
                    } else {
                        contPVal = $("#TextBox10").val();
                    }

                    $.ajax({
                        type: 'POST',
                        url: 'Venue2.aspx/updateVenue2',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venue2ID':'" + venue2ID + "','venue2Name':'" + venue2Name + "','status':'" + status + "','venueCountry':'" + venueCountry + "','venue':'" + venue + "','cgsCode':'" + cgsCode + "','cglCode':'" + cglCode + "','fgsCode':'" + fgsCode + "','fglCode':'" + fglCode + "','fiVal':'" + fiVal + "','suffixCode':'" + suffixCode + "','contPVal':'" + contPVal + "'}",
                        async: false,
                        success: function (data) {
                            $("#TextBox1").val("");
                            $("#TextBox2").val("");
                            $("#TextBox3").val("");
                            $("#TextBox4").val("");
                            $("#TextBox5").val("");
                            $("#TextBox6").val("");
                            $("#TextBox7").val("");
                            $("#TextBox8").val("");
                            $("#TextBox9").val("");
                            $("#TextBox10").val("");
                            $("#status").val('');
                          
                            $("#venuecountry").val('');
                            $("#venue").empty();
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

            })
        </script>


        <script>

            $(document).ready(function () {
                $("#update").click(function () {
                    $("#venue2ID").hide();
                    $("#venue2Name").hide();
                    $("#venue2Status").hide();
                    $("#Venue").hide();
                    $("#venueCountry").hide();
                    $("#update").hide();
                    $("#insertButton").show();
                    $("#cgsCode").hide();
                    $("#cglCode").hide();
                    $("#fgsCode").hide();
                    $("#fglCode").hide();
                    $("#fiVal").hide();
                    $("#suffixCode").hide();
                    $("#contPVal").hide();
                });
            });
        </script>
    
        <script>
            $(document).ready(function () {
                $("#venuecountry").change(function () {
                    var venueCountryID = $("#venuecountry").val();
                  

                    $.ajax({
                        type: 'POST',
                        url: 'Venue2.aspx/getAllVenue',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venueCountryID':'" + venueCountryID + "'}",
                        async: false,
                        success: function (data) {
                         
                           $("#venue").empty();
                            $("#venue").append("<option disabled selected value>Select an Option</option>");

                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                    $("#venue").append("<option value='" + value1[1] + "'>" + value1[0] + "</option>");
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
                                
    (function (document) {
                                
        'use strict';

                                
        var LightTableFilter = (function (Arr) {

                                
            var _input;

                                
            function _onInputEvent(e) {
                                
                _input = e.target;
                                
                var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
                                
                Arr.forEach.call(tables, function (table) {
                                
                    Arr.forEach.call(table.tBodies, function (tbody) {
                                
                        Arr.forEach.call(tbody.rows, _filter);
                                
                    });
                                
                });
                                
            }

                                
            function _filter(row) {
                                
                var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
                                
                row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
                                
            }

                                
            return {
                                
                init: function () {
                                
                    var inputs = document.getElementsByClassName('form-control pull-right');
                                
                    Arr.forEach.call(inputs, function (input) {
                                
                        input.oninput = _onInputEvent;
                                
                    });
                                
                }
                                
            };
                                
        })(Array.prototype);

                                
        document.addEventListener('readystatechange', function () {
                                
            if (document.readyState === 'complete') {
                                
                LightTableFilter.init();
                                
            }
                                
        });

                                
    })(document);
        </script>


        <script>

        $(document).ready(function () {

            $.ajax({

                type: 'Post',
                url: 'Venue2.aspx/getAdminRights',
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
                    url: 'Venue2.aspx/searchProfile',
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
                    url: 'Venue2.aspx/getlink',
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
