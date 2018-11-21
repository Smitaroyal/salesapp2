<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget1.aspx.cs" Inherits="WebSite5_production_Budget1" %>

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

         #update,#head{
             display:none;
         }

           #success-alert,#danger-alert,#danger-alert1,#directory,#profileDetails,#menu_toggle,#Year11,#Group,#Group11,#Odyssey,#MembMarkt,
           #Country11,#Venue11,#VenueGroup11,#Group11,#Source11,#update,#directory2,#insertButton,#enable,#update,#Odyssey11,#MembMarkt11,#warning-alert{
            display:none;
        }
           #TextBox5{
               text-align:center;
           }

            #directory2{
             pointer-events:none;

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

                          <div class="alert alert-warning" id="warning-alert">
                                            <button type="button" class="close" data-dismiss="alert">x</button>
                                            <strong>Data Already Exists! </strong>

                                        </div>
                          <div class="container-fluid">
                                  <button type="button" id="insertButton" class="btn btn-primary pull-right btn-block">Insert</button>
                              <button type="button" id="view" class="btn btn-primary pull-right btn-block">View</button>
                              <div class="row">
                                  <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " id="head">
                                      <br />
                                      <h5 class="text-center">ADD BUDGET</h5>
                                  </div>
                              </div>
                          </div>
                          <br />
                          <br />
                          <div class="container-fluid">
                              <div class="row" id="row1">
                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Year">
                                      <div class="form-group">
                                          <label for="sel1">Year:</label>
                                          <select class="form-control" id="year">
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
                                          <select class="form-control" id="country1">
                                              <option disabled selected value>Select an Option</option>
                                              <%Response.Write(getAllCountries()); %>
                                          </select>
                                      </div>
                                  </div>

                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Venue">
                                      <div class="form-group">
                                          <label for="sel1">venue:</label>
                                          <select class="form-control" id="venue1">
                                          </select>
                                      </div>
                                  </div>


                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Year11">
                                      <div class="form-group">
                                          <label for="sel1">Year:</label>
                                          <select class="form-control" id="year11">
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
                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Country11">
                                      <div class="form-group">
                                          <label for="sel1">Country:</label>
                                          <select class="form-control" id="country11">
                                              <option disabled selected value>Select an Option</option>
                                              <%Response.Write(getAllCountries()); %>
                                          </select>
                                      </div>
                                  </div>

                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Venue11">
                                      <div class="form-group">
                                          <label for="sel1">venue:</label>
                                          <select class="form-control" id="venue11">
                                          </select>
                                      </div>
                                  </div>

                              </div>
                              <div class="row" id="row2">
                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="VenueGroup">
                                      <div class="form-group">
                                          <label for="sel1">venue Group:</label>
                                          <select class="form-control" id="venue1Group">
                                          </select>
                                      </div>
                                  </div>

                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Group">
                                      <div class="form-group">
                                          <label for="sel1">Group:</label>
                                          <select class="form-control" id="group">
                                              <option disabled selected value>Select an Option</option>
                                              <%Response.Write(getGroup()); %>
                                          </select>
                                      </div>
                                  </div>


                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Source">
                                      <div class="form-group">
                                          <label for="sel1">source:</label>
                                          <select class="form-control" id="source">
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

                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="VenueGroup11">
                                      <div class="form-group">
                                          <label for="sel1">venue Group:</label>
                                          <select class="form-control" id="venue1Group11">
                                          </select>
                                      </div>
                                  </div>

                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Group11">
                                      <div class="form-group">
                                          <label for="sel1">Group:</label>
                                          <select class="form-control" id="group11">
                                              <option disabled selected value>Select an Option</option>
                                              <%Response.Write(getGroup()); %>
                                          </select>
                                      </div>
                                  </div>


                                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Source11">
                                      <div class="form-group">
                                          <label for="sel1">source:</label>
                                          <select class="form-control" id="source11">
                                          </select>
                                      </div>
                                  </div>

                                     <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Odyssey11">
                                      <div class="form-group">
                                          <label for="sel1">Group:</label>
                                          <select class="form-control" id="odyssey11">
                                              <option disabled selected value>Select an Option</option>
                                              <option value="Odyssey Timeshare">Odyssey Timeshare</option>
                                              <option value="Odyssey Fractional">Odyssey Fractional</option>
                                          </select>
                                      </div>
                                  </div>

                                   <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="MembMarkt11">
                                      <div class="form-group">
                                          <label for="sel1">Group:</label>
                                          <select class="form-control" id="membMarkt11">
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
                <br />   <div class="row">

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
                                                  <th>NET</th>
                                                  <th></th>
                                              </tr>
                                          </thead>
                                          <tbody id="myTable">
                                          </tbody>
                                      </table>

                                  </div>
                             <div class="col-md-12 text-center">
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
                                                  <th>DAYS</th>
                                                  <th>QT</th>
                                                  <th>CLOSE</th>
                                                  <th>SALES</th>
                                                  <th>AVG PRICE</th>
                                                  <th>NET</th>
                                                  <th></th>
                                              </tr>
                                          </thead>
                                          <tbody id="myTable1">
                                          </tbody>
                                      </table>

                                  </div>

                             <div class="col-md-12 text-center">
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
                                <p style="font-size: 17px">Huge</p>
                            </a>
                        </li>
                        <li>
                            <a data-edit="fontSize 3">
                                <p style="font-size: 14px">Normal</p>
                            </a>
                        </li>
                        <li>
                            <a data-edit="fontSize 1">
                                <p style="font-size: 11px">Small</p>
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

                $("#country1").change(function () {
                    var venueCountryID = $("#country1").val();
                    $.ajax({

                        type: 'Post',
                        url: 'Budget1.aspx/getVenueOnCountry',
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


                $("#country11").change(function () {
                    var venueCountryID = $("#country11").val();
                    $.ajax({

                        type: 'Post',
                        url: 'Budget1.aspx/getVenueOnCountry',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venueCountryID':'" + venueCountryID + "'}",
                        async: false,
                        success: function (data) {

                    
                            $("#venue11").empty();
                            $("#venue11").append("<option disabled selected value>Select an Option</option>");
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                
                                    $("#venue11").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");

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
                   // alert(venue)
                    if (venue == "V1") {

                        $("#VenueGroup").hide();

                        $.ajax({

                            type: 'Post',
                            url: 'Budget1.aspx/getsourceOnVenue',
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

                    } else {
                        $("#VenueGroup").show();
                        $("#Odyssey").hide();
                        $("#MembMarkt").hide();
                        $.ajax({

                            type: 'Post',
                            url: 'Budget1.aspx/getVenueGroupOnVenue',
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

                $("#venue11").change(function () {
                    var venue = $("#venue11").val();
                    if(venue=="V1"){
                        $("#VenueGroup11").hide();

                        $.ajax({

                            type: 'Post',
                            url: 'Budget1.aspx/getsourceOnVenue',
                            contentType: "application/json; charset=utf-8",
                            data: "{'venue':'" + venue + "'}",
                            async: false,
                            success: function (data) {

                                $("#source11").empty();
                                $("#source11").append("<option disabled selected value>Select an Option</option>");

                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {

                                        $("#source11").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
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

                    } else {
                        $("#VenueGroup11").show();
                        $("#Odyssey11").hide();
                        $("#MembMarkt11").hide();
                        $.ajax({

                            type: 'Post',
                            url: 'Budget1.aspx/getVenueGroupOnVenue',
                            contentType: "application/json; charset=utf-8",
                            data: "{'venue':'" + venue + "'}",
                            async: false,
                            success: function (data) {


                                $("#venue1Group11").empty();
                                $("#venue1Group11").append("<option disabled selected value>Select an Option</option>");
                                $("#source11").empty();
                                $("#source11").append("<option disabled selected value>Select an Option</option>");

                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {


                                        $("#venue1Group11").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");

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
                        url: 'Budget1.aspx/getSourceOnVenueGroup',
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

                $("#venue1Group11").change(function () {
                    var venueGroup = $("#venue1Group11").val();

                    $.ajax({

                        type: 'Post',
                        url: 'Budget1.aspx/getSourceOnVenueGroup',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venueGroup':'" + venueGroup + "'}",
                        async: false,
                        success: function (data) {

                            
                            $("#source11").empty();
                            $("#source11").append("<option disabled selected value>Select an Option</option>");
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                           
                                    $("#source11").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
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


            $("#source11").change(function () {

                var source11 = $("#source11 option:selected").text();
                if (source11 == "Odyssey" || source11 == "ODYSSEY") {
                    $("#Odyssey11").show();
                    $("#MembMarkt11").hide();
                } else if (source11 == "Member Marketing" || source11 == "MEMBER MARKETING") {
                    $("#Odyssey11").hide();
                    $("#MembMarkt11").show();
                } else {
                    $("#Odyssey11").hide();
                    $("#MembMarkt11").hide();
                }

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
                    var current = 0;
                    $.ajax({

                        type: 'Post',
                        url: 'Budget1.aspx/getdetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                        async: false,
                        success: function (data) {
                          // alert(data.d);

                            $("#directory").show();
                            $("#task-table tbody").empty();
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {
                                    if (value1[0] == "2") {
                                        $("#warning-alert").fadeTo(1500, 500).slideUp(500, function () {
                                            $("#warning-alert").slideUp(500);

                                        });
                                        $("#directory").hide();
                                        $("#year").val('');
                                        $("#country1").val('');
                                        $("#venue1").val('');
                                        $("#venue1Group").val('');
                                        $("#source").val('');
                                        $("#odyssey").val('');
                                        $("#membMarkt").val('');
                                    }else if (value1[0] == "1") {
                                       
                                    } else {
                                        $("#task-table tbody").append("<tr><td style='display:none'><input type='hidden' style='width:80px' id='month" + current + "' value='" + value1[0] + "'></td><td>" + value1[1] + "</td><td><input type='text' style='width:65px' id='DAYS" + current + "'><td><input type='text' style='width:80px' id='QT" + current + "'></td> <td><input type='text' style='width:80px' id='Close" + current + "'></td> <td><input type='text' style='width:80px' id='sales" + current + "' readonly></td> <td><input type='text' style='width:80px' id='Avg" + current + "'></td> <td><input type='text' style='width:80px' id='Net" + current + "'></td></tr>");

                                        current++;
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


                }

            });


            $("#odyssey").change(function () {

                var year = $("#year").val();
                if (year == "" || year == null || year == "Select an Option") {
                    year == "";
                } else {
                    var year = $("#year").val();
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

                var current = 0;
                $.ajax({

                    type: 'Post',
                    url: 'Budget1.aspx/getdetails',
                    contentType: "application/json; charset=utf-8",
                    data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                    async: false,
                    success: function (data) {
                        $("#directory").show();
                        $("#task-table tbody").empty();
                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {
                                if (value1[0] == "2") {
                                    $("#warning-alert").fadeTo(1500, 500).slideUp(500, function () {
                                        $("#warning-alert").slideUp(500);

                                    });
                                    $("#directory").hide();
                                    $("#year").val('');
                                    $("#country1").val('');
                                    $("#venue1").val('');
                                    $("#venue1Group").val('');
                                    $("#source").val('');
                                    $("#odyssey").val('');
                                    $("#membMarkt").val('');
                                } else if (value1[0] == "1") {

                                } else {
                                    $("#task-table tbody").append("<tr><td style='display:none'><input type='hidden' style='width:80px' id='month" + current + "' value='" + value1[0] + "'></td><td>" + value1[1] + "</td><td><input type='text' style='width:65px' id='DAYS" + current + "'><td><input type='text' style='width:80px' id='QT" + current + "'></td> <td><input type='text' style='width:80px' id='Close" + current + "'></td> <td><input type='text' style='width:80px' id='sales" + current + "' readonly></td> <td><input type='text' style='width:80px' id='Avg" + current + "'></td> <td><input type='text' style='width:80px' id='Net" + current + "'></td></tr>");

                                    current++;
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


            $("#membMarkt").change(function () {

                var year = $("#year").val();
                if (year == "" || year == null || year == "Select an Option") {
                    year == "";
                } else {
                    var year = $("#year").val();
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

                var current = 0;
                $.ajax({

                    type: 'Post',
                    url: 'Budget1.aspx/getdetails',
                    contentType: "application/json; charset=utf-8",
                    data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                    async: false,
                    success: function (data) {
                        $("#directory").show();
                        $("#task-table tbody").empty();

                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {
                                if (value1[0] == "2") {
                                    $("#warning-alert").fadeTo(1500, 500).slideUp(500, function () {
                                        $("#warning-alert").slideUp(500);

                                    });
                                    $("#directory").hide();
                                    $("#year").val('');
                                    $("#country1").val('');
                                    $("#venue1").val('');
                                    $("#venue1Group").val('');
                                    $("#source").val('');
                                    $("#odyssey").val('');
                                    $("#membMarkt").val('');
                                } else if (value1[0] == "1") {

                                } else {
                                    $("#task-table tbody").append("<tr><td style='display:none'><input type='hidden' style='width:80px' id='month" + current + "' value='" + value1[0] + "'></td><td>" + value1[1] + "</td><td><input type='text' style='width:65px' id='DAYS" + current + "'><td><input type='text' style='width:80px' id='QT" + current + "'></td> <td><input type='text' style='width:80px' id='Close" + current + "'></td> <td><input type='text' style='width:80px' id='sales" + current + "' readonly></td> <td><input type='text' style='width:80px' id='Avg" + current + "'></td> <td><input type='text' style='width:80px' id='Net" + current + "'></td></tr>");

                                    current++;
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


       <%-- <script>
            $(document).ready(function () {

                $("#year").change(function () {

                    var current = 0;
                    $.ajax({

                        type: 'Post',
                        url: 'Budget1.aspx/getdetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                            $("#directory").show();
                            $("#task-table tbody").empty();
                         
                            subJson = JSON.parse(data.d);
                         
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                   
                                    $("#task-table tbody").append("<tr><td style='display:none'><input type='hidden' style='width:80px' id='month" + current + "' value='" + value1[0] + "'></td><td>" + value1[0] + "</td><td><input type='text' style='width:65px' id='DAYS" + current + "'><td><input type='text' style='width:80px' id='QT" + current + "'></td> <td><input type='text' style='width:80px' id='Close" + current + "'></td> <td><input type='text' style='width:80px' id='sales" + current + "' readonly></td> <td><input type='text' style='width:80px' id='Avg" + current + "'></td> <td><input type='text' style='width:80px' id='Net" + current + "' readonly></td></tr>");

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

        </script>--%>

        
       <!-- jan-->
        <script>

            $(document).ready(function () {


            
                var total="";
                $(document).on('focusout', '#Close0', function () {

                    var qt = $("#QT0").val();
                    var close = $("#Close0").val();
                    total = qt * close / 100;

                   // var salesRound = Math.round(total);

                    $("#sales0").val(total.toFixed(2));



                });

                //$(document).on('focusout', '#Avg0', function () {

                //    var sales = total;

                //    var Avg = $("#Avg0").val();
                //    var total1 = sales * Avg;
                //    $("#Net0").val(total1.toFixed(2));

                //});

            });


        </script>
       <!-- end-->

          <!-- Feb-->
        <script>

            $(document).ready(function () {

               
                var total = "";
                $(document).on('focusout', '#Close1', function () {

                    var qt = $("#QT1").val();
                    var close = $("#Close1").val();

                     total = qt * close / 100;
                   //  var salesRound = Math.round(total);
                     $("#sales1").val(total.toFixed(2));
                 


                });

            //    $(document).on('focusout', '#Avg1', function () {

            //        var sales = total;
            //        var Avg = $("#Avg1").val();
            //        var total1 = sales * Avg;
            //        $("#Net1").val(total1.toFixed(2));


                   


            //});
            });

        </script>
       <!-- end-->

          <!-- Mar-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close2', function () {

                    var qt = $("#QT2").val();
                    var close = $("#Close2").val();
                    total = qt * close / 100;
                   // var salesRound = Math.round(total);
                    $("#sales2").val(total.toFixed(2));
                 


                });

            //    $(document).on('focusout', '#Avg2', function () {

            //        var sales = total;
            //        var Avg = $("#Avg2").val();
            //        var total1 = sales * Avg;
            //        $("#Net2").val(total1.toFixed(2));

                  

            //});

            });
        </script>
       <!-- end-->


           <!-- Apr-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close3', function () {

                    var qt = $("#QT3").val();
                    var close = $("#Close3").val();
                    total = qt * close / 100;
                  //  var salesRound = Math.round(total);
                    $("#sales3").val(total.toFixed(2));

                });

                //$(document).on('focusout', '#Avg3', function () {

                //    var sales = total;
                //    var Avg = $("#Avg3").val();
                //    var total1 = sales * Avg;
                //    $("#Net3").val(total1.toFixed(2));

                

                //});
            });

        </script>
       <!-- end-->

           <!-- May-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close4', function () {

                    var qt = $("#QT4").val();
                    var close = $("#Close4").val();
                     total = qt * close / 100;
                  //   var salesRound = Math.round(total);
                     $("#sales4").val(total.toFixed(2));
                });

            //    $(document).on('focusout', '#Avg4', function () {

            //        var sales = total;
            //        var Avg = $("#Avg4").val();
            //        var total1 = sales * Avg;
            //        $("#Net4").val(total1.toFixed(2));

            //});
            });

        </script>
       <!-- end-->
        
         <!-- Jun-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close5', function () {

                    var qt = $("#QT5").val();
                    var close = $("#Close5").val();
                     total = qt * close / 100;
                   //  var salesRound = Math.round(total);
                     $("#sales5").val(total.toFixed(2));
                 
                });

            //    $(document).on('focusout', '#Avg5', function () {

            //        var sales = total;
            //        var Avg = $("#Avg5").val();
            //        var total1 = sales * Avg;
            //        $("#Net5").val(total1.toFixed(2));


            //});

            });
        </script>
       <!-- end-->


          <!-- Jul-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close6', function () {

                    var qt = $("#QT6").val();
                    var close = $("#Close6").val();

                     total = qt * close / 100;
                    // var salesRound = Math.round(total);
                     $("#sales6").val(total.toFixed(2));
                 
                });

                //$(document).on('focusout', '#Avg6', function () {

                //    var sales = total;
                //    var Avg = $("#Avg6").val();
                //    var total1 = sales * Avg;
                //    $("#Net6").val(total1.toFixed(2));

                
                //});

            });


        </script>
       <!-- end-->


          <!-- Aug-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close7', function () {

                    var qt = $("#QT7").val();
                    var close = $("#Close7").val();
                     total = qt * close / 100;
                   //  var salesRound = Math.round(total);
                     $("#sales7").val(total.toFixed(2));
                 
                });

                //$(document).on('focusout', '#Avg7', function () {

                //    var sales = total;
                //    var Avg = $("#Avg7").val();
                //    var total1 = sales * Avg;
                //    $("#Net7").val(total1.toFixed(2));

                   

                //});

            });


        </script>
       <!-- end-->


             <!-- sep-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close8', function () {

                    var qt = $("#QT8").val();
                    var close = $("#Close8").val();
                     total = qt * close / 100;
                    // var salesRound = Math.round(total);
                     $("#sales8").val(total.toFixed(2));
                 
                });

                //$(document).on('focusout', '#Avg8', function () {

                //    var sales = total;
                //    var Avg = $("#Avg8").val();
                //    var total1 = sales * Avg;
                //    $("#Net8").val(total1.toFixed(2));

                

                //});

            });


        </script>
       <!-- end-->


              <!-- oct-->
        <script>

            $(document).ready(function () {


                var total = "";
                $(document).on('focusout', '#Close9', function () {

                    var qt = $("#QT9").val();
                    var close = $("#Close9").val();

                     total = qt * close / 100;
                   //  var salesRound = Math.round(total);
                     $("#sales9").val(total.toFixed(2));
                 
                });

                //$(document).on('focusout', '#Avg9', function () {

                //    var sales = total;
                //    var Avg = $("#Avg9").val();
                //    var total1 = sales * Avg;
                //    $("#Net9").val(total1.toFixed(2));
              

                //});

            });


        </script>
       <!-- end-->


               <!-- nov-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close10', function () {

                    var qt = $("#QT10").val();
                    var close = $("#Close10").val();
                     total = qt * close / 100;
                   //  var salesRound = Math.round(total);
                     $("#sales10").val(total.toFixed(2));
                 
                });

                //$(document).on('focusout', '#Avg10', function () {

                //    var sales = total;
                //    var Avg = $("#Avg10").val();
                //    var total1 = sales * Avg;
                //    $("#Net10").val(total1.toFixed(2));
                
                //});

            });


        </script>
       <!-- end-->


               <!-- Dec-->
        <script>

            $(document).ready(function () {

                var total = "";
                $(document).on('focusout', '#Close11', function () {

                    var qt = $("#QT11").val();
                    var close = $("#Close11").val();
                     total = qt * close / 100;
                  //  var salesRound = Math.round(total);
                     $("#sales11").val(total.toFixed(2));
                 
                });

                //$(document).on('focusout', '#Avg11', function () {

                //    var sales = total;
                //    var Avg = $("#Avg11").val();
                //    var total1 = sales * Avg;

                //    $("#Net11").val(total1.toFixed(2));

                   
                //});

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
                if (country == "" || country == "Select an Option" || country==null) {
                    country == "";
                } else {
                    country = $("#country1 option:selected").text();
                }

                var venue = $("#venue1 option:selected").text();
                if (venue == "" || venue == "Select an Option" || venue == null) {
                    venue == "";
                } else {
                    venue = $("#venue1 option:selected").text();
                }
                var venueGroup = "";
                if (venue == "Inhouse") {
                    venueGroup = "";
                } else {
                    venueGroup = $("#venue1Group option:selected").text();
                    if (venueGroup == "" || venueGroup == "Select an Option" || venueGroup == null) {
                        venueGroup == "";
                    } else {
                        venueGroup = $("#venue1Group option:selected").text();
                    }

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

               ///-- var GROSS0 = $("#Gross0").val(); var GROSS2 = $("#Gross2").val(); var GROSS4 = $("#Gross4").val(); var GROSS6 = $("#Gross6").val(); var GROSS8 = $("#Gross8").val(); var GROSS10 = $("#Gross10").val();
               //-- var GROSS1 = $("#Gross1").val(); var GROSS3 = $("#Gross3").val(); var GROSS5 = $("#Gross5").val(); var GROSS7 = $("#Gross7").val(); var GROSS9 = $("#Gross9").val(); var GROSS11 = $("#Gross11").val();
               //-- var GROSS = GROSS0 + ',' + GROSS1 + ',' + GROSS2 + ',' + GROSS3 + ',' + GROSS4 + ',' + GROSS5 + ',' + GROSS6 + ',' + GROSS7 + ',' + GROSS8 + ',' + GROSS9 + ',' + GROSS10 + ',' + GROSS11;
                //alert(GROSS);

               //-- var PPN0 = Math.round($("#PPN0").val()); var PPN2 = Math.round($("#PPN2").val()); var PPN4 = Math.round($("#PPN4").val()); var PPN6 = Math.round($("#PPN6").val()); var PPN8 = Math.round($("#PPN8").val()); var PPN10 = Math.round($("#PPN10").val());
              //--  var PPN1 = Math.round($("#PPN1").val()); var PPN3 = Math.round($("#PPN3").val()); var PPN5 = Math.round($("#PPN5").val()); var PPN7 = Math.round($("#PPN7").val()); var PPN9 = Math.round($("#PPN9").val()); var PPN11 = Math.round($("#PPN11").val());
               //-- var PPN = PPN0 + ',' + PPN1 + ',' + PPN2 + ',' + PPN3 + ',' + PPN4 + ',' + PPN5 + ',' + PPN6 + ',' + PPN7 + ',' + PPN8 + ',' + PPN9 + ',' + PPN10 + ',' + PPN11;
              //  alert(PPN);

           //--     var ADMIN0 = $("#Admin0").val(); var ADMIN2 = $("#Admin2").val(); var ADMIN4 = $("#Admin4").val(); var ADMIN6 = $("#Admin6").val(); var ADMIN8 = $("#Admin8").val(); var ADMIN10 = $("#Admin10").val();
       //--    var ADMIN1 = $("#Admin1").val(); var ADMIN3 = $("#Admin3").val(); var ADMIN5 = $("#Admin5").val(); var ADMIN7 = $("#Admin7").val(); var ADMIN9 = $("#Admin9").val(); var ADMIN11 = $("#Admin11").val();
            //--    var ADMIN = ADMIN0 + ',' + ADMIN1 + ',' + ADMIN2 + ',' + ADMIN3 + ',' + ADMIN4 + ',' + ADMIN5 + ',' + ADMIN6 + ',' + ADMIN7 + ',' + ADMIN8 + ',' + ADMIN9 + ',' + ADMIN10 + ',' + ADMIN11;
              //  alert(ADMIN);

                var NET0 = $("#Net0").val(); var NET2 = $("#Net2").val(); var NET4 = $("#Net4").val(); var NET6 = $("#Net6").val(); var NET8 = $("#Net8").val(); var NET10 = $("#Net10").val();
                var NET1 = $("#Net1").val(); var NET3 = $("#Net3").val(); var NET5 = $("#Net5").val(); var NET7 = $("#Net7").val(); var NET9 = $("#Net9").val(); var NET11= $("#Net11").val();
                var NET = NET0 + ',' + NET1 + ',' + NET2 + ',' + NET3 + ',' + NET4 + ',' + NET5 + ',' + NET6 + ',' + NET7 + ',' + NET8 + ',' + NET9 + ',' + NET10 + ',' + NET11;
              //  alert(NET);

                $.ajax({

                    type:'Post',
                    url: 'Budget1.aspx/insertBudget',
                    contentType:"application/json; charset=utf-8",
                    data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','QT':'" + QT + "','CLOSE':'" + CLOSE + "','SALES':'" + SALES + "','AVG':'" + AVG + "','NET':'" + NET + "','group':'" + group + "','source':'" + source + "','MONTH':'" + MONTH + "','DAYS':'" + DAYS + "','sourceGroup':'" + sourceGroup + "'}",
                    async: false,
                    success: function (data) {
                      
                        $("#year").val('');
                        $("#country1").val('');
                        $("#venue1").val('');
                        $("#venue1Group").val('');
                        $("#source").val('');
                        $("#group").val('');
                        $("#odyssey").val('');
                        $("#membMarkt").val('');
                        $("#QT0").val(''); $("#QT1").val(''); $("#QT2").val(''); $("#QT3").val(''); $("#QT4").val(''); $("#QT5").val(''); $("#QT6").val(''); $("#QT7").val(''); $("#QT8").val(''); $("#QT9").val(''); $("#QT10").val(''); $("#QT11").val('');
                        $("#Close0").val(''); $("#Close1").val(''); $("#Close2").val(''); $("#Close3").val(''); $("#Close4").val(''); $("#Close5").val(''); $("#Close6").val(''); $("#Close7").val(''); $("#Close8").val(''); $("#Close9").val(''); $("#Close10").val(''); $("#Close11").val('');
                        $("#sales0").val(''); $("#sales1").val(''); $("#sales2").val(''); $("#sales3").val(''); $("#sales4").val(''); $("#sales5").val(''); $("#sales6").val(''); $("#sales7").val(''); $("#sales8").val(''); $("#sales9").val(''); $("#sales10").val(''); $("#sales11").val('');
                        $("#Avg0").val(''); $("#Avg1").val(''); $("#Avg2").val(''); $("#Avg3").val(''); $("#Avg4").val(''); $("#Avg5").val(''); $("#Avg6").val(''); $("#Avg7").val(''); $("#Avg8").val(''); $("#Avg9").val(''); $("#Avg10").val(''); $("#Avg11").val('');
                    //--    $("#Gross0").val(''); $("#Gross1").val(''); $("#Gross2").val(''); $("#Gross3").val(''); $("#Gross4").val(''); $("#Gross5").val(''); $("#Gross6").val(''); $("#Gross7").val(''); $("#Gross8").val(''); $("#Gross9").val(''); $("#Gross10").val(''); $("#Gross11").val('');
                      //--  $("#PPN0").val(''); $("#PPN1").val(''); $("#PPN2").val(''); $("#PPN3").val(''); $("#PPN4").val(''); $("#PPN5").val(''); $("#PPN6").val(''); $("#PPN7").val(''); $("#PPN8").val(''); $("#PPN9").val(''); $("#PPN10").val(''); $("#PPN11").val('');
                      //--  $("#Admin0").val(''); $("#Admin1").val(''); $("#Admin2").val(''); $("#Admin3").val(''); $("#Admin4").val(''); $("#Admin5").val(''); $("#Admin6").val(''); $("#Admin7").val(''); $("#Admin8").val(''); $("#Admin9").val(''); $("#Admin10").val(''); $("#Admin11").val('');
                        $("#Net0").val(''); $("#Net1").val(''); $("#Net2").val(''); $("#Net3").val(''); $("#Net4").val(''); $("#Net5").val(''); $("#Net6").val(''); $("#Net7").val(''); $("#Net8").val(''); $("#Net9").val(''); $("#Net10").val(''); $("#Net11").val('');
                        $("#DAYS0").val(''); $("#DAYS1").val(''); $("#DAYS2").val(''); $("#DAYS3").val(''); $("#DAYS4").val(''); $("#DAYS5").val(''); $("#DAYS6").val(''); $("#DAYS7").val(''); $("#DAYS8").val(''); $("#DAYS9").val(''); $("#DAYS10").val(''); $("#DAYS11").val('');
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
            $("#view").click(function () {
                $("#Year").hide();
                $("#Country").hide();
                $("#Venue").hide();
                $("#VenueGroup").hide();
                $("#Group").hide();
                $("#Source").hide();
                $("#insert").hide();
                $("#directory").hide();
                $("#view").hide();
                $("#Year11").show();
                $("#Country11").show();
                $("#Venue11").show();
                $("#VenueGroup11").show();
                $("#Odyssey").hide();
                $("#MembMarkt").hide();
                $("#Source11").show();
                $("#update").hide();
                $("#enable").hide();
                $("#insertButton").show();
                $("#year11").val('');
                $("#country11").val('');
                $("#venue11").empty();
                $("#venue1Group11").empty();
                $("#source11").empty();
                $("#group11").val('');
                $("#qt0").val(''); $("#qt1").val(''); $("#qt2").val(''); $("#qt3").val(''); $("#qt4").val(''); $("#qt5").val(''); $("#qt6").val(''); $("#qt7").val(''); $("#qt8").val(''); $("#qt9").val(''); $("#qt10").val(''); $("#qt11").val('');
                $("#close0").val(''); $("#close1").val(''); $("#close2").val(''); $("#close3").val(''); $("#close4").val(''); $("#close5").val(''); $("#close6").val(''); $("#close7").val(''); $("#close8").val(''); $("#close9").val(''); $("#close10").val(''); $("#close11").val('');
                $("#saless0").val(''); $("#saless1").val(''); $("#saless2").val(''); $("#saless3").val(''); $("#saless4").val(''); $("#saless5").val(''); $("#saless6").val(''); $("#saless7").val(''); $("#saless8").val(''); $("#saless9").val(''); $("#saless10").val(''); $("#saless11").val('');
                $("#average0").val(''); $("#average1").val(''); $("#average2").val(''); $("#average3").val(''); $("#average4").val(''); $("#average5").val(''); $("#average6").val(''); $("#average7").val(''); $("#average8").val(''); $("#average9").val(''); $("#average10").val(''); $("#average11").val('');
                $("#netvolume0").val(''); $("#netvolume1").val(''); $("#netvolume2").val(''); $("#netvolume3").val(''); $("#netvolume4").val(''); $("#netvolume5").val(''); $("#netvolume6").val(''); $("#netvolume7").val(''); $("#netvolume8").val(''); $("#netvolume9").val(''); $("#netvolume10").val(''); $("#netvolume11").val('');
                $("#days0").val(''); $("#days1").val(''); $("#days2").val(''); $("#days3").val(''); $("#days4").val(''); $("#days5").val(''); $("#days6").val(''); $("#days7").val(''); $("#days8").val(''); $("#days9").val(''); $("#days10").val(''); $("#days11").val('');
                $("#Net0").val(''); $("#Net1").val(''); $("#Net2").val(''); $("#Net3").val(''); $("#Net4").val(''); $("#Net5").val(''); $("#Net6").val(''); $("#Net7").val(''); $("#Net8").val(''); $("#Net9").val(''); $("#Net10").val(''); $("#Net11").val('');
                $("#DAYS0").val(''); $("#DAYS1").val(''); $("#DAYS2").val(''); $("#DAYS3").val(''); $("#DAYS4").val(''); $("#DAYS5").val(''); $("#DAYS6").val(''); $("#DAYS7").val(''); $("#DAYS8").val(''); $("#DAYS9").val(''); $("#DAYS10").val(''); $("#DAYS11").val('');
            });
        });

    </script>

     <script>

        $(document).ready(function () {
            $("#insertButton").click(function () {
                $("#Year").show();
                $("#Country").show();
                $("#Venue").show();
                $("#VenueGroup").show();
                $("#Group").hide();
                $("#Source").show();
                $("#insert").show();
                $("#Odyssey11").hide();
                $("#MembMarkt11").hide();
                $("#directory").hide();
                $("#directory2").hide();
                $("#Year11").hide();
                $("#Country11").hide();
                $("#Venue11").hide();
                $("#VenueGroup11").hide();
                $("#Source11").hide();
                $("#update").hide();
                $("#enable").hide();
                $("#insertButton").hide();
                $("#view").show();
                $('#directory2').css('pointer-events', 'none');
                $("#year").val('');
                $("#country1").val('');
                $("#venue1").empty();
                $("#venue1Group").empty();
                $("#source").empty();
                $("#group").val('');
                $("#QT0").val(''); $("#QT1").val(''); $("#QT2").val(''); $("#QT3").val(''); $("#QT4").val(''); $("#QT5").val(''); $("#QT6").val(''); $("#QT7").val(''); $("#QT8").val(''); $("#QT9").val(''); $("#QT10").val(''); $("#QT11").val('');
                $("#Close0").val(''); $("#Close1").val(''); $("#Close2").val(''); $("#Close3").val(''); $("#Close4").val(''); $("#Close5").val(''); $("#Close6").val(''); $("#Close7").val(''); $("#Close8").val(''); $("#Close9").val(''); $("#Close10").val(''); $("#Close11").val('');
                $("#sales0").val(''); $("#sales1").val(''); $("#sales2").val(''); $("#sales3").val(''); $("#sales4").val(''); $("#sales5").val(''); $("#sales6").val(''); $("#sales7").val(''); $("#sales8").val(''); $("#sales9").val(''); $("#sales10").val(''); $("#sales11").val('');
                $("#Avg0").val(''); $("#Avg1").val(''); $("#Avg2").val(''); $("#Avg3").val(''); $("#Avg4").val(''); $("#Avg5").val(''); $("#Avg6").val(''); $("#Avg7").val(''); $("#Avg8").val(''); $("#Avg9").val(''); $("#Avg10").val(''); $("#Avg11").val('');
            });
        });

    </script>

    <script>

        $(document).ready(function () {
           
            $("#source11").change(function () {

                var year = $("#year11").val();
                if (year == "" || year == null) {
                    year == "";
                } else {
                    var year = $("#year11").val();
                }


                var country = $("#country11 option:selected").text();
                if (country == "" || country == null || country == "Select an Option") {
                    country == "";
                } else {
                    var country = $("#country11 option:selected").text();
                }
                var venue = $("#venue11 option:selected").text();
                if (venue == "" || venue == null || venue == "Select an Option") {
                    venue == "";
                } else {
                    var venue = $("#venue11 option:selected").text();
                }
                var venueGroup = $("#venue1Group11 option:selected").text();
                if (venueGroup == "" || venueGroup == null || venueGroup == "Select an Option") {
                    venueGroup == "";
                } else {
                    var venueGroup = $("#venue1Group11 option:selected").text();
                }

                var source = $("#source11 option:selected").text();
                if (source == "" || source == null || source == "Select an Option") {
                    source == "";
                } else {
                    var source = $("#source11 option:selected").text();

                }

                if (source == "Odyssey" || source == "ODYSSEY") {

                    var sourceGroup1 = $("#odyssey11 option:selected").text();
                    if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                        sourceGroup1 == "";
                    } else {

                        sourceGroup1 = $("#odyssey11 option:selected").text();
                    }

                } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                    var sourceGroup1 = $("#membMarkt11 option:selected").text();
                    if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                        sourceGroup1 == "";
                    } else {

                        sourceGroup1 = $("#membMarkt11 option:selected").text();
                    }
                } else {
                    var sourceGroup1 = "";

                }


                $("#odyssey11").val('');
                $("#membMarkt11").val('');

                if (source == "Odyssey" || source == "Member Marketing" || source == "ODYSSEY" || source == "MEMBER MARKETING") {
                    
                } else {
                    $.ajax({

                        type: 'Post',
                        url: 'Budget1.aspx/getBudgetDetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                        async: false,
                        success: function (data) {

                            var current = 0;
                            $("#enable").show();
                            $("#directory2").show();
                            $('#directory2').css('pointer-events', 'none');
                            $("#task-table3 tbody").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {
                                    if (value1[0] == "") {
                                        $("#directory2").hide();
                                    } else {

                                        $("#task-table3 tbody").append("<tr><td style='display:none;'><input type='text' style='width:65px' id='id" + current + "' value='" + value1[0] + "'/></td><td><input type='text' style='width:65px; pointer-events:none;' id='month" + current + "' value='" + value1[1] + "'/></td><td><input type='text' style='width:65px' id='days" + current + "' value='" + value1[2] + "'/></td><td><input type='text' style='width:65px' id='qt" + current + "' value='" + value1[3] + "'/></td><td><input type='text' style='width:65px' id='close" + current + "' value='" + value1[4] + "'/></td><td><input type='text' style='width:65px' id='saless" + current + "' value='" + value1[5] + "'/></td><td><input type='text' style='width:65px' id='average" + current + "' value='" + value1[6] + "'/></td><td><input type='text' style='width:65px' id='netvolume" + current + "' value='" + value1[7] + "'/></td></tr>");
                                        current++;

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


                }

            });


            $("#odyssey11").change(function () {

                var year = $("#year11").val();
                if (year == "" || year == null || year == "Select an Option") {
                    year == "";
                } else {
                    var year = $("#year11").val();
                }


                var country = $("#country11 option:selected").text();
                if (country == "" || country == null || country == "Select an Option") {
                    country == "";
                } else {
                    var country = $("#country11 option:selected").text();
                }
                var venue = $("#venue11 option:selected").text();
                if (venue == "" || venue == null || venue == "Select an Option") {
                    venue == "";
                } else {
                    var venue = $("#venue11 option:selected").text();
                }
                var venueGroup = "";
                if (venueGroup == "" || venueGroup == null || venueGroup == "Select an Option") {
                    venueGroup == "";
                } else {
                    var venueGroup = "";
                }

                var source = $("#source11 option:selected").text();
                if (source == "" || source == null || source == "Select an Option") {
                    source == "";
                } else {
                    var source = $("#source11 option:selected").text();

                }

                if (source == "Odyssey" || source == "ODYSSEY") {

                    var sourceGroup1 = $("#odyssey11 option:selected").text();
                    if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                        sourceGroup1 == "";
                    } else {

                        sourceGroup1 = $("#odyssey11 option:selected").text();
                    }

                } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                    var sourceGroup1 = $("#membMarkt11 option:selected").text();
                    if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                        sourceGroup1 == "";
                    } else {

                        sourceGroup1 = $("#membMarkt11 option:selected").text();
                    }
                } else {
                    var sourceGroup1 = "";

                }

               
                    $.ajax({

                        type: 'Post',
                        url: 'Budget1.aspx/getBudgetDetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                        async: false,
                        success: function (data) {
                            var current = 0;
                            $("#enable").show();
                            $("#directory2").show();
                            $('#directory2').css('pointer-events', 'none');
                            $("#task-table3 tbody").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {
                                    if (value1[0] == "") {

                                    } else {

                                        $("#task-table3 tbody").append("<tr><td style='display:none;'><input type='text' style='width:65px' id='id" + current + "' value='" + value1[0] + "'/></td><td><input type='text' style='width:65px; pointer-events:none;' id='month" + current + "' value='" + value1[1] + "'/></td><td><input type='text' style='width:65px' id='days" + current + "' value='" + value1[2] + "'/></td><td><input type='text' style='width:65px' id='qt" + current + "' value='" + value1[3] + "'/></td><td><input type='text' style='width:65px' id='close" + current + "' value='" + value1[4] + "'/></td><td><input type='text' style='width:65px' id='saless" + current + "' value='" + value1[5] + "'/></td><td><input type='text' style='width:65px' id='average" + current + "' value='" + value1[6] + "'/></td><td><input type='text' style='width:65px' id='netvolume" + current + "' value='" + value1[7] + "'/></td></tr>");
                                        current++;

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


            $("#membMarkt11").change(function () {

                var year = $("#year11").val();
                if (year == "" || year == null || year == "Select an Option") {
                    year == "";
                } else {
                    var year = $("#year11").val();
                }


                var country = $("#country11 option:selected").text();
                if (country == "" || country == null || country == "Select an Option") {
                    country == "";
                } else {
                    var country = $("#country11 option:selected").text();
                }
                var venue = $("#venue11 option:selected").text();
                if (venue == "" || venue == null || venue == "Select an Option") {
                    venue == "";
                } else {
                    var venue = $("#venue11 option:selected").text();
                }
                var venueGroup = "";
                if (venueGroup == "" || venueGroup == null || venueGroup == "Select an Option") {
                    venueGroup == "";
                } else {
                    var venueGroup = "";
                }

                var source = $("#source11 option:selected").text();
                if (source == "" || source == null || source == "Select an Option") {
                    source == "";
                } else {
                    var source = $("#source11 option:selected").text();

                }

                if (source == "Odyssey" || source == "ODYSSEY") {

                    var sourceGroup1 = $("#odyssey11 option:selected").text();
                    if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                        sourceGroup1 == "";
                    } else {

                        sourceGroup1 = $("#odyssey11 option:selected").text();
                    }

                } else if (source == "Member Marketing" || source == "MEMBER MARKETING") {
                    var sourceGroup1 = $("#membMarkt11 option:selected").text();
                    if (sourceGroup1 == "" || sourceGroup1 == null || sourceGroup1 == "Select an Option") {
                        sourceGroup1 == "";
                    } else {

                        sourceGroup1 = $("#membMarkt11 option:selected").text();
                    }
                } else {
                    var sourceGroup1 = "";

                }


                $.ajax({

                    type: 'Post',
                    url: 'Budget1.aspx/getBudgetDetails',
                    contentType: "application/json; charset=utf-8",
                    data: "{'year':'" + year + "','country':'" + country + "','venue':'" + venue + "','venueGroup':'" + venueGroup + "','source':'" + source + "','sourceGroup1':'" + sourceGroup1 + "'}",
                    async: false,
                    success: function (data) {
                        var current = 0;
                        $("#enable").show();
                        $("#directory2").show();
                        $('#directory2').css('pointer-events', 'none');
                        $("#task-table3 tbody").empty();

                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {
                                if (value1[0] == "") {

                                } else {

                                    $("#task-table3 tbody").append("<tr><td style='display:none;'><input type='text' style='width:65px' id='id" + current + "' value='" + value1[0] + "'/></td><td><input type='text' style='width:65px; pointer-events:none;' id='month" + current + "' value='" + value1[1] + "'/></td><td><input type='text' style='width:65px' id='days" + current + "' value='" + value1[2] + "'/></td><td><input type='text' style='width:65px' id='qt" + current + "' value='" + value1[3] + "'/></td><td><input type='text' style='width:65px' id='close" + current + "' value='" + value1[4] + "'/></td><td><input type='text' style='width:65px' id='saless" + current + "' value='" + value1[5] + "'/></td><td><input type='text' style='width:65px' id='average" + current + "' value='" + value1[6] + "'/></td><td><input type='text' style='width:65px' id='netvolume" + current + "' value='" + value1[7] + "'/></td></tr>");
                                    current++;

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


      <!-- jan-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close0', function () {

                    var qt1 = $("#qt0").val();
                    var close1 = $("#close0").val();
                    total1 = qt1 * close1 / 100;
                  //  var salesRound1 = Math.round(total1);

                    $("#saless0").val(total1.toFixed(2));



                });

                //$(document).on('focusout', '#average0', function () {

                //    var sales1 = total1;

                //    var Avg1 = $("#average0").val();
                //    var total11 = sales1 * Avg1;
                //    $("#netvolume0").val(total11.toFixed(2));

                //});

            });


        </script>
       <!-- end-->

          <!-- Feb-->
        <script>

            $(document).ready(function () {
                var total1="";
                $(document).on('focusout', '#close1', function () {

                    var qt1 = $("#qt1").val();
                    var close1 = $("#close1").val();

                     total1 = qt1 * close1 / 100;
                   //  var salesRound1 = Math.round(total1);
                     $("#saless1").val(total1.toFixed(2));
                });

            //    $(document).on('focusout', '#average1', function () {

            //        var sales1 = total1;
            //        var Avg1 = $("#average1").val();
            //        var total11 = sales1 * Avg1;
            //        $("#netvolume1").val(total11.toFixed(2));

            //});
            });

        </script>
       <!-- end-->

          <!-- Mar-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close2', function () {

                    var qt1 = $("#qt2").val();
                    var close1 = $("#close2").val();

                    total1 = qt1 * close1 / 100;
                 //   var salesRound1 = Math.round(total1);
                    $("#saless2").val(total1.toFixed(2));
                 


                });

            //    $(document).on('focusout', '#average2', function () {

            //        var sales1 = total1;
            //        var Avg1 = $("#average2").val();
            //        var total11 = sales1 * Avg1;
            //        $("#netvolume2").val(total11.toFixed(2));
            //});

            });
        </script>
       <!-- end-->


           <!-- Apr-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close3', function () {

                    var qt1 = $("#qt3").val();
                    var close1 = $("#close3").val();
                    total1 = qt1 * close1 / 100;
                   // var salesRound1 = Math.round(total1);
                    $("#saless3").val(total1.toFixed(2));

                });

                //$(document).on('focusout', '#average3', function () {

                //    var sales1 = total1;
                //    var Avg1 = $("#average3").val();
                //    var total11 = sales1 * Avg1;
                //    $("#netvolume3").val(total11.toFixed(2));

                

                //});
            });

        </script>
       <!-- end-->

           <!-- May-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close4', function () {

                    var qt1 = $("#qt4").val();
                    var close1 = $("#close4").val();
                     total1 = qt1 * close1 / 100;
                   //  var salesRound1 = Math.round(total1);
                     $("#saless4").val(total1.toFixed(2));
                });

            //    $(document).on('focusout', '#average4', function () {

            //        var sales1 = total1;
            //        var Avg1 = $("#average4").val();
            //        var total11 = sales1 * Avg1;
            //        $("#netvolume4").val(total11.toFixed(2));

            //});
            });

        </script>
       <!-- end-->
        
         <!-- Jun-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close5', function () {

                    var qt1 = $("#qt5").val();
                    var close1 = $("#close5").val();
                     total1 = qt1 * close1 / 100;
                   //  var salesRound1 = Math.round(total1);
                     $("#saless5").val(total1.toFixed(2));
                 
                });

            //    $(document).on('focusout', '#average5', function () {

            //        var sales1 = total1;
            //        var Avg1 = $("#average5").val();
            //        var total11 = sales1 * Avg1;
            //        $("#netvolume5").val(total11.toFixed(2));


            //});

            });
        </script>
       <!-- end-->


          <!-- Jul-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close6', function () {

                    var qt1 = $("#qt6").val();
                    var close1 = $("#close6").val();

                     total1 = qt1 * close1 / 100;
                  //   var salesRound1 = Math.round(total1);
                     $("#saless6").val(total1.toFixed(2));
                 
                });

                //$(document).on('focusout', '#average6', function () {

                //    var sales1 = total1;
                //    var Avg1 = $("#average6").val();
                //    var total11 = sales1 * Avg1;
                //    $("#netvolume6").val(total11.toFixed(2));

                
                //});

            });


        </script>
       <!-- end-->


          <!-- Aug-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close7', function () {

                    var qt1 = $("#qt7").val();
                    var close1 = $("#close7").val();
                     total1 = qt1 * close1 / 100;
                   //  var salesRound1 = Math.round(total1);
                     $("#saless7").val(total1.toFixed(2));
                 
                });

                //$(document).on('focusout', '#average7', function () {

                //    var sales1 = total1;
                //    var Avg1 = $("#average7").val();
                //    var total11 = sales1 * Avg1;
                //    $("#netvolume7").val(total11.toFixed(2));

                //});

            });

        </script>
       <!-- end-->
             <!-- sep-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close8', function () {

                    var qt1 = $("#qt8").val();
                    var close1 = $("#close8").val();
                     total1 = qt1 * close1 / 100;
                  //   var salesRound1 = Math.round(total1);
                     $("#saless8").val(total1.toFixed(2));
                 
                });

                //$(document).on('focusout', '#average8', function () {

                //    var sales1 = total1;
                //    var Avg1 = $("#average8").val();
                //    var total11 = sales1 * Avg1;
                //    $("#netvolume8").val(total11.toFixed(2));

                

                //});

            });


        </script>
       <!-- end-->


              <!-- oct-->
        <script>

            $(document).ready(function () {


                var total1="";
                $(document).on('focusout', '#close9', function () {

                    var qt1 = $("#qt9").val();
                    var close1 = $("#close9").val();
                     total1 = qt1 * close1 / 100;
                  //   var salesRound1 = Math.round(total1);
                     $("#saless9").val(total1.toFixed(2));
                 
                });

                //$(document).on('focusout', '#average9', function () {

                //    var sales1 = total1;
                //    var Avg1 = $("#average9").val();
                //    var total11 = sales1 * Avg1;
                //    $("#netvolume9").val(total11.toFixed(2));
              

                //});

            });


        </script>
       <!-- end-->


               <!-- nov-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close10', function () {

                    var qt1 = $("#qt10").val();
                    var close1 = $("#close10").val();
                     total1 = qt1 * close1 / 100;
                   //  var salesRound1 = Math.round(total1);
                     $("#saless10").val(total1.toFixed(2));
                 
                });

                //$(document).on('focusout', '#average10', function () {

                //    var sales1 = total1;
                //    var Avg1 = $("#average10").val();
                //    var total11 = sales1 * Avg1;
                //    $("#netvolume10").val(total11.toFixed(2));
                
                //});

            });


        </script>
       <!-- end-->


               <!-- Dec-->
        <script>

            $(document).ready(function () {

                var total1="";
                $(document).on('focusout', '#close11', function () {

                    var qt1 = $("#qt11").val();
                    var close1 = $("#close11").val();
                     total1 = qt1 * close1 / 100;
                  //  var salesRound1 = Math.round(total1);
                     $("#saless11").val(total1);
                 
                });

                //$(document).on('focusout', '#average11', function () {

                //    var sales1 = total1;
                //    var Avg1 = $("#average11").val();
                //    var total11 = sales1 * Avg1;

                //    $("#netvolume11").val(total11);

                   
                //});

            });


        </script>
       <!-- end-->

    
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

               
                var id0 = $("#id0").val(); var id2 = $("#id2").val(); var id4 = $("#id4").val(); var id6 = $("#id6").val(); var id8 = $("#id8").val(); var id10 = $("#id10").val();
                var id1 = $("#id1").val(); var id3 = $("#id3").val(); var id5 = $("#id5").val(); var id7 = $("#id7").val(); var id9 = $("#id9").val(); var id11 = $("#id11").val();
                var id = id0 + ',' + id1 + ',' + id2 + ',' + id3 + ',' + id4 + ',' + id5 + ',' + id6 + ',' + id7 + ',' + id8 + ',' + id9 + ',' + id10 + ',' + id11;

                var days0 = $("#days0").val(); var days2 = $("#days2").val(); var days4 = $("#days4").val(); var days6 = $("#days6").val(); var days8 = $("#days8").val(); var days10 = $("#days10").val();
                var days1 = $("#days1").val(); var days3 = $("#days3").val(); var days5 = $("#days5").val(); var days7 = $("#days7").val(); var days9 = $("#days9").val(); var days11 = $("#days11").val();
                var days = days0 + ',' + days1 + ',' + days2 + ',' + days3 + ',' + days4 + ',' + days5 + ',' + days6 + ',' + days7 + ',' + days8 + ',' + days9 + ',' + days10 + ',' + days11;
             //   alert(DAYS);

            //--    var month0 = $("#month0").val(); var month2 = $("#month2").val(); var month4 = $("#month4").val(); var month6 = $("#month6").val(); var month8 = $("#month8").val(); var month10 = $("#month10").val();
             //--   var month1 = $("#month1").val(); var month3 = $("#month3").val(); var month5 = $("#month5").val(); var month7 = $("#month7").val(); var month9 = $("#month9").val(); var month11 = $("#month11").val();
             //--   var month = month0 + ',' + month1 + ',' + month2 + ',' + month3 + ',' + month4 + ',' + month5 + ',' + month6 + ',' + month7 + ',' + month8 + ',' + month9 + ',' + month10 + ',' + month11;

               // alert(MONTH);
                var qt0 = $("#qt0").val(); var qt2 = $("#qt2").val(); var qt4 = $("#qt4").val(); var qt6 = $("#qt6").val(); var qt8 = $("#qt8").val(); var qt10 = $("#qt10").val();
                var qt1 = $("#qt1").val(); var qt3 = $("#qt3").val(); var qt5 = $("#qt5").val(); var qt7 = $("#qt7").val(); var qt9 = $("#qt9").val(); var qt11 = $("#qt11").val();
                var qt = qt0 + ',' + qt1 + ',' + qt2 + ',' + qt3 + ',' + qt4 + ',' + qt5 + ',' + qt6 + ',' + qt7 + ',' + qt8 + ',' + qt9 + ',' + qt10 + ',' + qt11;
              //  alert(QT);

                var close0 = $("#close0").val(); var close2 = $("#close2").val(); var close4 = $("#close4").val(); var close6 = $("#close6").val(); var close8 = $("#close8").val(); var close10 = $("#close10").val();
                var close1 = $("#close1").val(); var close3 = $("#close3").val(); var close5 = $("#close5").val(); var close7 = $("#close7").val(); var close9 = $("#close9").val(); var close11 = $("#close11").val();
                var close = close0 + ',' + close1 + ',' + close2 + ',' + close3 + ',' + close4 + ',' + close5 + ',' + close6 + ',' + close7 + ',' + close8 + ',' + close9 + ',' + close10 + ',' + close11;
              //  alert(CLOSE);

                var saless0 = $("#saless0").val(); var saless2 = $("#saless2").val(); var saless4 = $("#saless4").val(); var saless6 = $("#saless6").val(); var saless8 = $("#saless8").val(); var saless10 = $("#saless10").val();
                var saless1 = $("#saless1").val(); var saless3 = $("#saless3").val(); var saless5 = $("#saless5").val(); var saless7 = $("#saless7").val(); var saless9 = $("#saless9").val(); var saless11 = $("#saless11").val();
                var saless = saless0 + ',' + saless1 + ',' + saless2 + ',' + saless3 + ',' + saless4 + ',' + saless5 + ',' + saless6 + ',' + saless7 + ',' + saless8 + ',' + saless9 + ',' + saless10 + ',' + saless11;
             //   alert(SALES);

                var average0 = $("#average0").val(); var average2 = $("#average2").val(); var average4 = $("#average4").val(); var average6 = $("#average6").val(); var average8 = $("#average8").val(); var average10 = $("#average10").val();
                var average1 = $("#average1").val(); var average3 = $("#average3").val(); var average5 = $("#average5").val(); var average7 = $("#average7").val(); var average9 = $("#average9").val(); var average11 = $("#average11").val();
                var average = average0 + ',' + average1 + ',' + average2 + ',' + average3 + ',' + average4 + ',' + average5 + ',' + average6 + ',' + average7 + ',' + average8 + ',' + average9 + ',' + average10 + ',' + average11;
               // alert(AVG);

               ///-- var GROSS0 = $("#Gross0").val(); var GROSS2 = $("#Gross2").val(); var GROSS4 = $("#Gross4").val(); var GROSS6 = $("#Gross6").val(); var GROSS8 = $("#Gross8").val(); var GROSS10 = $("#Gross10").val();
               //-- var GROSS1 = $("#Gross1").val(); var GROSS3 = $("#Gross3").val(); var GROSS5 = $("#Gross5").val(); var GROSS7 = $("#Gross7").val(); var GROSS9 = $("#Gross9").val(); var GROSS11 = $("#Gross11").val();
               //-- var GROSS = GROSS0 + ',' + GROSS1 + ',' + GROSS2 + ',' + GROSS3 + ',' + GROSS4 + ',' + GROSS5 + ',' + GROSS6 + ',' + GROSS7 + ',' + GROSS8 + ',' + GROSS9 + ',' + GROSS10 + ',' + GROSS11;
                //alert(GROSS);

               //-- var PPN0 = Math.round($("#PPN0").val()); var PPN2 = Math.round($("#PPN2").val()); var PPN4 = Math.round($("#PPN4").val()); var PPN6 = Math.round($("#PPN6").val()); var PPN8 = Math.round($("#PPN8").val()); var PPN10 = Math.round($("#PPN10").val());
              //--  var PPN1 = Math.round($("#PPN1").val()); var PPN3 = Math.round($("#PPN3").val()); var PPN5 = Math.round($("#PPN5").val()); var PPN7 = Math.round($("#PPN7").val()); var PPN9 = Math.round($("#PPN9").val()); var PPN11 = Math.round($("#PPN11").val());
               //-- var PPN = PPN0 + ',' + PPN1 + ',' + PPN2 + ',' + PPN3 + ',' + PPN4 + ',' + PPN5 + ',' + PPN6 + ',' + PPN7 + ',' + PPN8 + ',' + PPN9 + ',' + PPN10 + ',' + PPN11;
              //  alert(PPN);

           //--     var ADMIN0 = $("#Admin0").val(); var ADMIN2 = $("#Admin2").val(); var ADMIN4 = $("#Admin4").val(); var ADMIN6 = $("#Admin6").val(); var ADMIN8 = $("#Admin8").val(); var ADMIN10 = $("#Admin10").val();
       //--    var ADMIN1 = $("#Admin1").val(); var ADMIN3 = $("#Admin3").val(); var ADMIN5 = $("#Admin5").val(); var ADMIN7 = $("#Admin7").val(); var ADMIN9 = $("#Admin9").val(); var ADMIN11 = $("#Admin11").val();
            //--    var ADMIN = ADMIN0 + ',' + ADMIN1 + ',' + ADMIN2 + ',' + ADMIN3 + ',' + ADMIN4 + ',' + ADMIN5 + ',' + ADMIN6 + ',' + ADMIN7 + ',' + ADMIN8 + ',' + ADMIN9 + ',' + ADMIN10 + ',' + ADMIN11;
              //  alert(ADMIN);

                var netvolume0 = $("#netvolume0").val(); var netvolume2 = $("#netvolume2").val(); var netvolume4 = $("#netvolume4").val(); var netvolume6 = $("#netvolume6").val(); var netvolume8 = $("#netvolume8").val(); var netvolume10 = $("#netvolume10").val();
                var netvolume1 = $("#netvolume1").val(); var netvolume3 = $("#netvolume3").val(); var netvolume5 = $("#netvolume5").val(); var netvolume7 = $("#netvolume7").val(); var netvolume9 = $("#netvolume9").val(); var netvolume11= $("#netvolume11").val();
                var netvolume = netvolume0 + ',' + netvolume1 + ',' + netvolume2 + ',' + netvolume3 + ',' + netvolume4 + ',' + netvolume5 + ',' + netvolume6 + ',' + netvolume7 + ',' + netvolume8 + ',' + netvolume9 + ',' + netvolume10 + ',' + netvolume11;
              //  alert(NET);

                $.ajax({

                    type:'Post',
                    url: 'Budget1.aspx/updateBudget',
                    contentType:"application/json; charset=utf-8",
                    data: "{'id':'" + id + "','days':'" + days + "','qt':'" + qt + "','close':'" + close + "','saless':'" + saless + "','average':'" + average + "','netvolume':'" + netvolume + "'}",
                    async: false,
                    success: function (data) {
                        $("#Odyssey11").hide();
                        $("#MembMarkt11").hide();
                        $("#year11").val('');
                        $("#country11").val('');
                        $("#venue11").empty();
                        $("#venue1Group11").empty();
                        $("#source11").empty();
                        $("#group11").val('');
                        $("#qt0").val(''); $("#qt1").val(''); $("#qt2").val(''); $("#qt3").val(''); $("#qt4").val(''); $("#qt5").val(''); $("#qt6").val(''); $("#qt7").val(''); $("#qt8").val(''); $("#qt9").val(''); $("#qt10").val(''); $("#qt11").val('');
                        $("#close0").val(''); $("#close1").val(''); $("#close2").val(''); $("#close3").val(''); $("#close4").val(''); $("#close5").val(''); $("#close6").val(''); $("#close7").val(''); $("#close8").val(''); $("#close9").val(''); $("#close10").val(''); $("#close11").val('');
                        $("#saless0").val(''); $("#saless1").val(''); $("#saless2").val(''); $("#saless3").val(''); $("#saless4").val(''); $("#saless5").val(''); $("#saless6").val(''); $("#saless7").val(''); $("#saless8").val(''); $("#saless9").val(''); $("#saless10").val(''); $("#saless11").val('');
                        $("#average0").val(''); $("#average1").val(''); $("#average2").val(''); $("#average3").val(''); $("#average4").val(''); $("#average5").val(''); $("#average6").val(''); $("#average7").val(''); $("#average8").val(''); $("#average9").val(''); $("#average10").val(''); $("#average11").val('');
                    //--    $("#Gross0").val(''); $("#Gross1").val(''); $("#Gross2").val(''); $("#Gross3").val(''); $("#Gross4").val(''); $("#Gross5").val(''); $("#Gross6").val(''); $("#Gross7").val(''); $("#Gross8").val(''); $("#Gross9").val(''); $("#Gross10").val(''); $("#Gross11").val('');
                      //--  $("#PPN0").val(''); $("#PPN1").val(''); $("#PPN2").val(''); $("#PPN3").val(''); $("#PPN4").val(''); $("#PPN5").val(''); $("#PPN6").val(''); $("#PPN7").val(''); $("#PPN8").val(''); $("#PPN9").val(''); $("#PPN10").val(''); $("#PPN11").val('');
                      //--  $("#Admin0").val(''); $("#Admin1").val(''); $("#Admin2").val(''); $("#Admin3").val(''); $("#Admin4").val(''); $("#Admin5").val(''); $("#Admin6").val(''); $("#Admin7").val(''); $("#Admin8").val(''); $("#Admin9").val(''); $("#Admin10").val(''); $("#Admin11").val('');
                        $("#netvolume0").val(''); $("#netvolume1").val(''); $("#netvolume2").val(''); $("#netvolume3").val(''); $("#netvolume4").val(''); $("#netvolume5").val(''); $("#netvolume6").val(''); $("#netvolume7").val(''); $("#netvolume8").val(''); $("#netvolume9").val(''); $("#netvolume10").val(''); $("#netvolume11").val('');
                        $("#days0").val(''); $("#days1").val(''); $("#days2").val(''); $("#days3").val(''); $("#days4").val(''); $("#days5").val(''); $("#days6").val(''); $("#days7").val(''); $("#days8").val(''); $("#days9").val(''); $("#days10").val(''); $("#days11").val('');
                        $("#directory2").hide();
                        $("#directory1").hide();
                        $("#update").hide();
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
                url: 'Budget1.aspx/getAdminRights',
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
                    url: 'Budget1.aspx/searchProfile',
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
                    url: 'Budget1.aspx/getlink',
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
