<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InhouseStatsIndia.aspx.cs" Inherits="WebSite5_production_InhouseStatsIndia" %>

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


         #update,#venueID,#head,#GroupVenueID,#date,#directory,#insert,#tours,#deals,#occupied,
         #inhouseStatID,#date1,#GroupVenueID1,#task-table8,#SubVenue,#GroupVenueID2,#enable,#Venue,#Venue1{
             display:none;
         }

         #directory{
             pointer-events:none;

         }

           #success-alert,#danger-alert,#danger-alert1,#menu_toggle,#profileDetails,#warning-alert{
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
                    </div>
                </div>
                <!-- /top navigation -->

                <!-- page content -->

                <div class="right_col" role="main">
                    <div class="">



                        <div class="clearfix"></div>

                        <div class="row">
                            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
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
                                       
                                        <div class="container-fluid">
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
                                              <div class="alert alert-warning" id="warning-alert">
                                            <button type="button" class="close" data-dismiss="alert">x</button>
                                            <strong>Data Already Exists! </strong>

                                        </div>
                                            <button type="button" id="insertButton" class="btn btn-primary pull-right btn-block">Insert</button>
                                            <button type="button" id="view" class="btn btn-primary pull-right btn-block">View</button>
                                            <div class="row">
                                                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " id="head">
                                                    <br />
                                                    <h4 class="text-center">ADD INHOUSE STATS</h4>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3 " id="inhouseStatID">
                                                    <div class="form-group">
                                                        <label for="sel1">:</label>
                                                        <asp:TextBox ID="TextBox1" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="date">
                                                    <label for="sel1">Date:</label>
                                                    <div class="input-group date" id="datepicker1" data-provide="datepicker">
                                                        <asp:TextBox ID="TextBox2" class="form-control pull-right" Style="pointer-events: none;" runat="server"></asp:TextBox>
                                                        <div class="input-group-addon">
                                                            <span class="glyphicon glyphicon-th"></span>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="date1">
                                                    <label for="sel1">Date:</label>
                                                    <div class="input-group date" id="datepicker2" data-provide="datepicker">
                                                        <asp:TextBox ID="TextBox6" class="form-control pull-right" Style="pointer-events: none;" runat="server"></asp:TextBox>
                                                        <div class="input-group-addon">
                                                            <span class="glyphicon glyphicon-th"></span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-3 col-sm-12 col-xs-12 col-lg-3" id="Venue">
                                                    <div class="form-group">
                                                        <label for="sel1">Venue:</label>
                                                        <select class="form-control" name="venue" id="venue">
                                                            <option disabled selected value>--Select an Option--</option>
                                                            <% Response.Write(getVenueOnCountry()); %>
                                                        </select>
                                                    </div>
                                                </div>

                                                 <div class="col-md-3 col-sm-12 col-xs-12 col-lg-3" id="Venue1">
                                                    <div class="form-group">
                                                        <label for="sel1">Venue:</label>
                                                        <select class="form-control" name="venue1" id="venue1">
                                                            <option disabled selected value>--Select an Option--</option>
                                                            <% Response.Write(getVenueOnCountry()); %>
                                                        </select>
                                                    </div>
                                                </div>

                                                <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="GroupVenueID">
                                                    <div class="form-group">
                                                        <label for="sel1">Group Venue:</label>
                                                        <select class="form-control" id="groupVenue">
                                                        </select>

                                                    </div>
                                                </div>

                                                 <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="GroupVenueID1">
                                                    <div class="form-group">
                                                        <label for="sel1">Group Venue:</label>
                                                        <select class="form-control" id="groupVenue1">
                                                            <option disabled selected value>Select an Option</option>
                                                         
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
                                          
                                        
                                            <div class="row">

                                                <div class="table-responsive">
                                                    <table class="table table-hover" id="task-table8">
                                                        <thead>
                                                            <tr>

                                                                <th>SUB VENUE</th>
                                                                <th>OCCUPIED</th>
                                                                 <th>UNIQUE</th>
                                                             
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <h6 id="ody">ODYSSEY</h6>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox8" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox3" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                               

                                                            </tr>

                                                            <tr>
                                                                <td>
                                                                    <h6 id="exc">EXCHANGE</h6>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox11" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox4" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                               


                                                            </tr>

                                                         
                                                          
                                                            <tr>
                                                                <td>
                                                                    <h6 id="markt">MEMBER MARKETING</h6>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox20" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox33" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                               


                                                            </tr>
                                                          
                                                            <tr>
                                                                <td>
                                                                    <h6 id="other">OTHER</h6>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox26" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox35" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                               


                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <h6 id="kcv1">KCV1</h6>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox29" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox36" class="form-control pull-right" Style="height: 26px;" runat="server"></asp:TextBox></td>
                                                             
                                                            </tr>

                                                           
                                                        </tbody>
                                                    </table>
                                                </div>

                                                <div class="col-md-12 text-center">
                                                    <ul class="pagination pagination-lg pager" id="myPager1"></ul>
                                                </div>
                                            </div>
                                            
                                        </div>
                                        </div>

                                  <div class="container-fluid" id="directory">
          <div class="row">
              
                   <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " "><br />
                        <h5 class="text-center"> INHOUSE STATS DIRECTORY</h5>
                               </div>
              
              </div>
                      <div class="row">
                   <div class="col-md-4 col-md-offset-4 col-sm-4 col-sm-offset-4 col-xs-6 col-xs-offset-3 col-lg-4 col-lg-offset-4" >
                    <div class="form-group">
                       <label for="sel1"></label>
                      <asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server" placeholder="Search"  data-table="table table-hover" ></asp:TextBox>
                  </div>
              </div>
          </div>
          
                <br /> 
      
           <div class="row">
               
                         <div class="table-responsive">
               <table class="table table-hover" id="task-table">
            <thead>
                <tr>
                    <th>ID</th>
                     <th>VENUE</th>
                    <th>GROUP VENUE</th>
                    <th>SUB VENUE</th>
                     <th>DATE</th>
                     <th>OCCUPIED</th>
                      <th>UNIQUE</th>
                
             
                   
                </tr>
            </thead>
            <tbody id="myTable" >
                
              
               

                </tbody>
            </table>
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
  
         <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet">  
   
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"></script> 
               <script type="text/javascript">
           
            $(document).ready(function () {
                
                $('#datepicker1,#datepicker2').datepicker({
                    format: "dd-mm-yyyy",
                    orientation: "bottom auto",
                    autoclose: true
                });  
            

            });
        </script>
         <script>

            $('#form1').bind('keydown', function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                }
            });
        </script>


        <script>

        $(document).ready(function () {
            $("#venue").change(function () {
                var venue = $("#venue").val();
              //  alert(office);
                $.ajax({

                    type: 'Post',
                    url: 'InhouseStatsIndia.aspx/getGroupVenueOnVenue',
                    contentType: "application/json; charset=utf-8",
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                   //     alert(data.d);
                        $("#groupVenue").empty();
                        $("#groupVenue").append(" <option value=''>--Select an Option--</option>");
                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                $("#groupVenue").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");
                            });


                        });



                    },
                    error: function () {

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
              //  alert(office);
                $.ajax({

                    type: 'Post',
                    url: 'InhouseStatsIndia.aspx/getGroupVenueOnVenue',
                    contentType: "application/json; charset=utf-8",
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                   //     alert(data.d);
                        $("#groupVenue1").empty();
                        $("#groupVenue1").append(" <option value=''>--Select an Option--</option>");
                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                $("#groupVenue1").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");
                            });


                        });



                    },
                    error: function () {

                    }

                });
                return false;


            });



        });

    </script>



    <script>
        $(document).ready(function () {
            $("#groupVenue").change(function () {

                var venue = $("#venue option:selected").text();
                if (venue == "" || venue == "") {
                    venue = "";

                } else {
                    var venue = $("#venue option:selected").text();
                    //alert(groupvenue);
                }

                var groupVenue = $("#groupVenue option:selected").text();
                if (groupVenue == "" || groupVenue == "") {
                    groupVenue = "";

                } else {
                    var groupVenue = $("#groupVenue option:selected").text();
                    //alert(groupvenue);
                }

               
                var isValid = true;
                var date = $("#TextBox2").val();
                if (date == "" || date == "") {
                    date = "";
          
                    isValid = false;
                    $("#venue").val('');
                    $("#groupVenue").val('');
                  

                    $("#TextBox8").val("");
                    $("#TextBox3").val("");
                  


                    $("#TextBox11").val("");
                    $("#TextBox4").val("");
                  


                    $("#TextBox20").val("");
                    $("#TextBox33").val("");
                  


                    $("#TextBox26").val("");
                    $("#TextBox35").val("");
                   

                    $("#TextBox29").val("");
                    $("#TextBox36").val("");
                  

             


                    $("#task-table8").hide();

                    $("#TextBox2").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();
                }
                else {
                    var date = $("#TextBox2").val();
                    $("#TextBox2").css({

                        "border": "",

                        "background": ""

                    });
                }


                $.ajax({

                    type: 'Post',
                    url: 'InhouseStatsIndia.aspx/checkDuplicate',
                    contentType: "application/json; charset=utf-8",
                    data: "{'venue':'" + venue + "','groupVenue':'" + groupVenue + "','date':'" + date + "'}",
                    async: false,
                    success: function (data) {
                     //   alert(data.d);
                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                if (value1[0] == "1") {
                                    $('#datepicker1').datepicker('setDate', null);
                                       $("#venue").val('');
                                       $("#groupVenue").val('');
                                      

                                        $("#TextBox8").val("");
                                        $("#TextBox3").val("");
                                      

                                        $("#TextBox11").val("");
                                        $("#TextBox4").val("");
                                       
                                   
                                        $("#TextBox20").val("");
                                        $("#TextBox33").val("");
                                       

                                        $("#TextBox26").val("");
                                        $("#TextBox35").val("");
                                       

                                        $("#TextBox29").val("");
                                        $("#TextBox36").val("");
                                      
                                        $("#TextBox2").val("");

                                  
                                        $("#task-table8").hide();

                                        $("#warning-alert").fadeTo(1500, 500).slideUp(500, function () {
                                            $("#warning-alert").slideUp(500);
                                    });
                                } else if(value1[0]=="2"){

                                    $("#task-table8").show();

                                }
                            

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
         
            $("#insert").click(function () {

                var venue = $("#venue option:selected").text();
                if (venue == "" || venue == "") {
                    venue = "";

                } else {
                    var venue = $("#venue option:selected").text();
                    //alert(groupvenue);
                }
               
                var groupvenue = $("#groupVenue option:selected").text();
                if (groupvenue == "" || groupvenue == "") {
                    groupvenue = "";
                   
                } else {
                    var groupvenue = $("#groupVenue option:selected").text();
                    //alert(groupvenue);
                }
               
                var isValid = true;
                var date = $("#TextBox2").val();
                if (date == "" || date == "") {
                    date = "";
          
                    isValid = false;
                    $("#groupVenue").val('');
                    $("#venue").val('');
                    $("#TextBox8").val("");
                    $("#TextBox3").val("");
                   

                    $("#TextBox11").val("");
                    $("#TextBox4").val("");
                   


                    $("#TextBox20").val("");
                    $("#TextBox33").val("");
                   



                    $("#TextBox26").val("");
                    $("#TextBox35").val("");
                   

                    $("#TextBox29").val("");
                    $("#TextBox36").val("");
                  
                    $("#task-table8").hide();
                    $("#TextBox2").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();
                }
                else {
                    var date = $("#TextBox2").val();
                    $("#TextBox2").css({

                        "border": "",

                        "background": ""

                    });
                }

                var ody = $("#ody").text();
                var odyOccu = $("#TextBox8").val();
                var odyUniq = $("#TextBox3").val();
             

                

                var exc = $("#exc").text();
                var excOccu = $("#TextBox11").val();
                var excUniq = $("#TextBox4").val();
            
               

                var markt = $("#markt").text();
                var marktOccu = $("#TextBox20").val();
                var marktUniq = $("#TextBox33").val();
              
              


                var other = $("#other").text();
                var otherOccu = $("#TextBox26").val();
                var otherUniq = $("#TextBox35").val();
             

                



                var kcv1 = $("#kcv1").text();
                var kcv1Occu = $("#TextBox29").val();
                var kcv1Uniq = $("#TextBox36").val();
            



                var val = ody + "," + exc + "," + markt + "," + other + "," + kcv1;
                var val1 = odyOccu + "," + excOccu + "," + marktOccu + "," + otherOccu + "," + kcv1Occu;
                var val4 = odyUniq + "," + excUniq + "," + marktUniq + "," + otherUniq + "," + kcv1Uniq;
              

          
                //alert(val);
                //alert(val1);
                //alert(val2);
                //alert(val3);

                $.ajax({

                    type:'Post',
                    url: 'InhouseStatsIndia.aspx/insertInhouseStats',
                    contentType:"application/json; charset=utf-8",
                    data: "{'venue':'" + venue + "','groupvenue':'" + groupvenue + "','date':'" + date + "','val':'" + val + "','val1':'" + val1 + "','val4':'" + val4 + "'}",
                    async: false,
                    success: function (data) {
                       // alert(data.d);
                        $("#venue").val('');
                        $("#groupVenue").val('');
                        $("#TextBox2").val("");
                     
                        $("#TextBox4").val("");
                        $("#TextBox7").val("");

                        $("#TextBox8").val("");
                        $("#TextBox3").val("");
                      

                        $("#TextBox11").val("");
                        $("#TextBox4").val("");
                      
                     
                        $("#TextBox20").val("");
                        $("#TextBox33").val("");
                     


                        $("#TextBox26").val("");
                        $("#TextBox35").val("");
                      

                        $("#TextBox29").val("");
                        $("#TextBox36").val("");
                     

                        $("#task-table8").hide();

                        $('#datepicker1').datepicker('setDate', null);

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
                    $("#venueID").hide();
                    $("#GroupVenueID").show();
                    $("#date").show();
                    $("#occupied").hide();
                    $("#tours").hide();
                    $("#deals").hide();
                    $("#task-table8").hide();
                    $("#insert").show();
                    $("#insertButton").hide();
                    $("#view").show();
                    $("#directory").hide();
                    $("#update").hide();
                    $("#GroupVenueID1").hide();
                    $("#date1").hide();
                    $("#venue").val('');
                    $("#groupVenue").val('');
                    $("#TextBox2").val("");
                    $("#TextBox3").val("");
                    $("#TextBox4").val("");
                    $("#TextBox7").val("");
                    $("#SubVenue").show();
                    $("#GroupVenueID2").hide();
                    $("#enable").hide();
                    $("#Venue").show();
                    $("#Venue1").hide();
                });
                $("#view").click(function () {
                    $("#head").hide();
                    $("#task-table8").hide();
                    $("#venueID").hide();
                    $("#GroupVenueID").hide();
                    $("#date").hide();
                    $("#occupied").hide();
                    $("#tours").hide();
                    $("#deals").hide();
                    $("#insert").hide();
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#directory").hide();
                    $("#inhouseStatID").hide();
                    $("#update").hide();
                    $("#GroupVenueID1").show();
                    $("#date1").show();
                    $("#subVenue").hide();
                    $("#GroupVenueID2").hide();
                    $("#enable").hide();
                    $('#directory').css('pointer-events', 'none');
                    $("#Venue1").show();
                    $("#Venue").hide();
                });


                //$(document).on('click','.edit-btn', function () {
                //    $("#insertButton").show();
                //    $("#view").hide();
                //    $("#date1").hide();
                //    $("#date").hide();
                //    $("#GroupVenueID1").hide();
                //    $("#venueID").show();
                //    $("#GroupVenueID").hide();
                //    $("#subVenue").show();
                //    $("#occupied").show();
                //    $("#tours").show();
                //    $("#deals").show();
                //    $("#update").show();
                //    $("#GroupVenueID2").show();
                //    $("#directory").hide();
                   

                //    var row = $(this).closest("tr");
                //    var ID = row.find("td:eq(0)").text();
                //    var group = row.find("td:eq(1)").text();
                //    var subvenue = row.find("td:eq(2)").text();
                //    var occupied = row.find("td:eq(4)").text();
                //    var tours = row.find("td:eq(5)").text();
                //    var deals = row.find("td:eq(6)").text();

               
                //    $("#groupVenue2 option[value='" + group + "']").prop('selected', true);
                //    $("#TextBox1").val(ID);
                //    $("#TextBox3").val(occupied);
                //    $("#TextBox4").val(tours);
                //    $("#TextBox7").val(deals);

                //});
                

            });
        </script>
       



        <script>
            $(document).ready(function () {

             
                $("#groupVenue1").change(function () {
                    $("#update").hide();
                    $("#enable").show();

                    var isValid = true;
                    var date = $("#TextBox6").val();
                    if (date == "" || date == "") {
                        date = "";
                        $("#groupVenue1").val('');
                        isValid = false;
                      
                        $("#TextBox6").css({

                            "border": "1px solid red",

                            "background": "#FFCECE"
                        });
                        if (isValid == false)
                            e.preventDefault();
                    }
                    else {
                        var date = $("#TextBox6").val();
                        $("#TextBox6").css({

                            "border": "",

                            "background": ""

                        });
                    }
                    var venue = $("#venue1 option:selected").text();
                    if (venue == "" || venue == "") {
                        venue = "";
                    } else {

                        venue = $("#venue1 option:selected").text();
                    }

                    var groupVenue = $("#groupVenue1 option:selected").text();
                    if (groupVenue == "" || groupVenue == "") {
                        groupVenue = "";
                    } else {

                        groupVenue = $("#groupVenue1 option:selected").text();
                    }
                    $.ajax({

                        type: 'Post',
                        url: 'InhouseStatsIndia.aspx/getAllInhouseStats',
                        contentType: "application/json; charset=utf-8",
                        data: "{'date':'" + date + "','groupVenue':'" + groupVenue + "','venue':'" + venue + "'}",
                        async: false,
                        success: function (data) {
                            $('#datepicker2').datepicker('setDate', null);
                            $("#TextBox6").val("");
                            $("#groupVenue1").val('');
                            $("#venue1").val('');
                            $("#directory").show();
                            $("#task-table tbody").empty();
                            $("#myPager").empty();
                            $('#directory').css('pointer-events', 'none');
                            subJson = JSON.parse(data.d);
                            var i=0;
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                    if(value1[0]==""){
                                        $("#directory").hide();
                                      
                                    } else {
                                        $("#task-table tbody").append("<tr><td style='display:none;'><input type='text' id='id" + i + "' style='width:50px;' value='" + value1[0] + "'/></td><td>" + value1[0] + "</td><td>" + value1[7] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td><input type='text' id='occup" + i + "' style='width:50px;' value='" + value1[4] + "'/></td><td><input type='text' id='uniq" + i + "' style='width:50px;' value='" + value1[6] + "'/></td></tr>");
                                        i++;
                                    }

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

            $("#enable").click(function () {
                $("#enable").hide();
                $("#update").show();
                $('#directory').css('pointer-events', 'auto');

            });

        });

    </script>


     <script>
            $(document).ready(function () {
                $("#update").click(function () {
                    $("#insertButton").hide();
                    $("#view").show();

                    var vall0 = $("#id0").val();
                    var vall1 = $("#id1").val();
                    var vall2 = $("#id2").val();
                    var vall3 = $("#id3").val();
                    var vall4 = $("#id4").val();
                   
                  

                    var valID = vall0 + "," + vall1 + "," + vall2 + "," + vall3 + "," + vall4;

                    var vallOcc0 = $("#occup0").val();
                    var vallOcc1 = $("#occup1").val();
                    var vallOcc2 = $("#occup2").val();
                    var vallOcc3 = $("#occup3").val();
                    var vallOcc4 = $("#occup4").val();
            

                    var valOccupied = vallOcc0 + "," + vallOcc1 + "," + vallOcc2 + "," + vallOcc3 + "," + vallOcc4;


                    var vallUniq0 = $("#uniq0").val();
                    var vallUniq1 = $("#uniq1").val();
                    var vallUniq2 = $("#uniq2").val();
                    var vallUniq3 = $("#uniq3").val();
                    var vallUniq4 = $("#uniq4").val();
            
                    var valUnique = vallUniq0 + "," + vallUniq1 + "," + vallUniq2 + "," + vallUniq3 + "," + vallUniq4;

                  


                    $.ajax({
                        type: 'POST',
                        url: 'InhouseStatsIndia.aspx/updateInnhouseStats',
                        contentType: "application/json; charset=utf-8",
                        data: "{'valID':'" + valID + "','valOccupied':'" + valOccupied + "','valUnique':'" + valUnique + "'}",
                        async: false,
                        success: function (data) {
                            $("#TextBox1").val("");
                            $('#datepicker2').datepicker('setDate', null);
                            $('#directory').css('pointer-events', 'none');
                         //   $("#venue1").val('');
                  //        $("#groupVenue1").val('');
                          
                            $("#success-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#success-alert").slideUp(500);
                            });

                        },
                        error: function (xhr, status, error) {
                        var err = JSON.parse(xhr.responseText);
                        alert(err.Message);
                    }

                    });

                    return false;


                });

            })
     </script>

    <script>

        $(document).ready(function () {
            $("#update").click(function () {
                $("#GroupVenueID2").hide();
                $("#subVenue").hide();
                $("#occupied").hide();
                $("#tours").hide();
                $("#deals").hide();
                $("#update").hide();
                $("#insertButton").show();
                $("#view").hide();
                $("#directory").hide();
                $("#enable").hide();
            });
        });
    </script>
           <script>

        $(document).ready(function () {

            $.ajax({

                type: 'Post',
                url: 'InhouseStatsIndia.aspx/getAdminRights',
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
                    url: 'InhouseStatsIndia.aspx/searchProfile',
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
                    url: 'InhouseStatsIndia.aspx/getlink',
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
