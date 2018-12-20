<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rights.aspx.cs" Inherits="WebSite5_production_Rights" %>

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

        #searchPro,#TextBox11{
            padding:8px 40px;
            border-radius: 25px;
            margin-right:10px;
            font-size:13px;
                text-align:center;
        }

       

        #CheckBox1{
            background-color: greenyellow;
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
         #head,#directory{
             display:none;
         }

           #success-alert,#danger-alert,#danger-alert1,#menu_toggle,#profileDetails,#task-table{
            display:none;
        }
         

            body {
        color: #566787;
		background: #f5f5f5;
		font-family: 'Varela Round', sans-serif;
		font-size: 13px;
	}
	.table-wrapper {
        background: #fff;
        padding: 20px 25px;
        margin: 30px 0;
		border-radius: 3px;
       
    }
	.table-title {        
		padding-bottom: 15px;
		background: #435d7d;
		color: #fff;
		padding: 16px 30px;
		margin: -20px -25px 10px;
		border-radius: 3px 3px 0 0;
    }
    .table-title h2 {
		margin: 5px 0 0;
		font-size: 24px;
	}
	.table-title .btn-group {
		float: right;
	}
	.table-title .btn {
		color: #fff;
		float: right;
		font-size: 13px;
		border: none;
		min-width: 50px;
		border-radius: 2px;
		border: none;
		outline: none !important;
		margin-left: 10px;
	}
	.table-title .btn i {
		float: left;
		font-size: 21px;
		margin-right: 5px;
            height: 21px;
        }
	.table-title .btn span {
		float: left;
		margin-top: 2px;
	}
    table.table tr th, table.table tr td {
        border-color: #e9e9e9;
		padding: 12px 15px;
		vertical-align: middle;
    }
	table.table tr th:first-child {
		width: 60px;
	}
	table.table tr th:last-child {
		width: 100px;
	}
    table.table-striped tbody tr:nth-of-type(odd) {
    	background-color: #fcfcfc;
	}
	table.table-striped.table-hover tbody tr:hover {
		background: #f5f5f5;
	}
    table.table th i {
        font-size: 13px;
        margin: 0 5px;
        cursor: pointer;
    }	
    table.table td:last-child i {
		opacity: 0.9;
		font-size: 22px;
        margin: 0 5px;
    }
	table.table td a {
		/*/font-weight: bold;
		color: #566787;*/
		display: inline-block;
		text-decoration: none;
		outline: none !important;
	}

  
	table.table td a:hover {
		color: #2196F3;
	}
	table.table td a.edit {
        color: #73879C;
    }
    table.table td a.delete {
        color: #F44336;
    }
    table.table td i {
        font-size: 19px;
    }
	table.table .avatar {
		border-radius: 50%;
		vertical-align: middle;
		margin-right: 10px;
	}
    .pagination {
        float: right;
        margin: 0 0 5px;
    }
    .pagination li a {
        border: none;
        font-size: 13px;
        min-width: 30px;
        min-height: 30px;
        color: #999;
        margin: 0 2px;
        line-height: 30px;
        border-radius: 2px !important;
        text-align: center;
        padding: 0 6px;
    }
    .pagination li a:hover {
        color: #666;
    }	
    .pagination li.active a, .pagination li.active a.page-link {
        background: #03A9F4;
    }
    .pagination li.active a:hover {        
        background: #0397d6;
    }
	.pagination li.disabled i {
        color: #ccc;
    }
    .pagination li i {
        font-size: 16px;
        padding-top: 6px
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
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="../build/css/custom.min.css" rel="stylesheet">
    <script src="jquery-3.2.1.min.js"></script>

</head>

    <script type="text/javascript">
$(document).ready(function(){
	// Activate tooltip
	$('[data-toggle="tooltip"]').tooltip();
	
	// Select/Deselect checkboxes
	
});
</script>
<body class="nav-md">
   
    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3 left_col">
          <div class="left_col scroll-view">
                    <div class="navbar nav_title" style="border-bottom: 2px; height:auto; color: #172D44;" id="img">

                          <img src="../production/images/KSC1.png" class="img-square" alt="" style="margin-top:3px; margin-bottom:5px;" width="200" height="53" /><br />
                      
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

                            <li><a href="#addEmployeeModal1" data-toggle="modal">Setting</a></li>
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
                             <div id="addEmployeeModal1" class="modal fade">
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
                                                          <table class="table table-striped table-hover" id="task-table6">
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

                          <div class="container">
                              <div class="table-wrapper">
                                  <div class="table-title">
                                      <div class="row">
                                          <div class="col-sm-12 col-xs-12 col-md-6 col-lg-6">
                                              <h4>Manage <b>Users</b></h4>
                                          </div>
                                          <div class="col-sm-12 col-xs-12 col-md-1 col-lg-1">
                                             
                                          </div>
                                          <div class="col-sm-11 col-xs-11 col-md-3 col-lg-3">
                                              <div class="form-group has-feedback has-search">
                                                  <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                                  <asp:TextBox ID="TextBox11" runat="server" class="form-control" placeholder="Search for Users"></asp:TextBox>
                                              </div>

                                          </div>
                                          <div class="col-sm-10 col-xs-10 col-md-2 col-lg-2">
                                              <a href="#addEmployeeModal" class="btn btn-success" id="addusers" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Add Users</span></a>
                                              <%-- <a href="#deleteEmployeeModal" class="btn btn-danger" data-toggle="modal"><i class="material-icons">&#xE15C;</i> <span>Delete</span></a>--%>
                                          </div>
                                      </div>
                                  </div>

                                  <ul class="nav nav-tabs md-tabs nav-justified indigo" role="tablist">
                                      <li class="nav-item">
                                          <a class="nav-link" data-toggle="tab" id="active1" href="#panel5" role="tab"><span class="glyphicon glyphicon-ok-circle"></span> ACTIVE</a>
                                      </li>
                                      <li class="nav-item">
                                          <a class="nav-link" data-toggle="tab" href="#panel6" id="inactive1" role="tab"><span class="glyphicon glyphicon-remove-circle"></span> IN ACTIVE</a>
                                      </li>
                                     
                                  </ul>
                                  <br />
                                 
                                  <div class="table-responsive">
                                      <table class="table table-striped table-hover" id="task-table">
                                          <thead>
                                              <tr>

                                                  <th>User Name</th>
                                                  <th>Password</th>
                                                  <th>Full Name</th>
                                                  <th>Office</th>
                                                  <th>Email</th>
                                                  <th>Title</th>
                                                  <th>Group</th>
                                                  <th>Status</th>
                                              </tr>
                                          </thead>
                                          <tbody id="myTable">

    
                                                 <!-- <a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>-->
                                            
                                          
                                         
                                      </tbody>
                                  </table>
                                         </div>
                                  <div class="col-md-12 col-xs-12 col-sm-12">
                                      <ul class="pagination pagination-lg pager" id="myPager"></ul>
                                  </div>
                                 <%-- <div class="clearfix">
                                      <div class="hint-text">Showing <b>5</b> out of <b>25</b> entries</div>
                                      <ul class="pagination">
                                          <li class="page-item disabled"><a href="#">Previous</a></li>
                                          <li class="page-item"><a href="#" class="page-link">1</a></li>
                                          <li class="page-item"><a href="#" class="page-link">2</a></li>
                                          <li class="page-item active"><a href="#" class="page-link">3</a></li>
                                          <li class="page-item"><a href="#" class="page-link">4</a></li>
                                          <li class="page-item"><a href="#" class="page-link">5</a></li>
                                          <li class="page-item"><a href="#" class="page-link">Next</a></li>
                                      </ul>
                                  </div>--%>
                              </div>
                          </div>
	<!-- Edit Modal HTML -->
                    <div id="addEmployeeModal" class="modal fade">
                        <div class="modal-dialog">
                            <div class="modal-content">

                                <div class="modal-header">
                                    <h4 class="modal-title">Add Users</h4>
                                   <!-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>-->
                                </div>
                                <div class="modal-body">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                                <div class="alert alert-success" id="success-alert">
                                                    <button type="button" class="close" data-dismiss="alert">x</button>
                                                    <strong>Success! </strong>

                                                </div>

                                                <div class="alert alert-danger" id="danger-alert">
                                                    <button type="button" class="close" data-dismiss="alert">x</button>
                                                    <strong>Something went wrong! </strong>

                                                </div>

                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">
                                                <div class="form-group">
                                                    <label>User Name</label>
                                                    <asp:TextBox ID="TextBox1" class="form-control pull-right" placeholder="Enter Username" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                <div class="form-group">
                                                    <label>Password</label>
                                                    <asp:TextBox ID="TextBox2" class="form-control pull-right" placeholder="Enter Password" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                      

                                        <div class="row">
                                            <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">
                                                <div class="form-group">
                                                    <label>Full Name</label>
                                                    <asp:TextBox ID="TextBox3" class="form-control pull-right" placeholder="Enter Name" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                <div class="form-group">
                                                    <label>Title</label>
                                                    <asp:TextBox ID="TextBox6" class="form-control pull-right" placeholder="Enter Title" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <br />

                                    </div>
                               


                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">
                                            <div class="form-group">
                                                <label>Office</label>
                                                <select class="form-control" id="office">
                                                    <option disabled selected value>Select an Option</option>
                                                    <option value="IVO">IVO</option>
                                                    <option value="HML">HML</option>
                                                    <option value="ATH">ATH</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">
                                            <div class="form-group">
                                                <label>Group</label>
                                                <select class="form-control" id="group">
                                                    <option disabled selected value>Select an Option</option>
                                                    <%Response.Write(getAllGroups()); %>
                                                </select>
                                            </div>
                                        </div>
                                    </div>

                                      <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                                <div class="form-group">
                                                    <label>Email</label>
                                                    <asp:TextBox ID="TextBox4" class="form-control pull-right" placeholder="Enter Email" runat="server"></asp:TextBox>
                                                </div>

                                            </div>

                                        </div>
                                       
                                </div>
                            </div>
                            <div class="modal-footer">
                                <input type="button" class="btn btn-default" id="cancel" data-dismiss="modal" value="Cancel" />
                                <input type="button" class="btn btn-success" id="insert" value="Add" />
                            </div>

                        </div>
                        </div>
                    </div>
                          <!-- Edit Modal HTML -->
                          <div id="editEmployeeModal" class="modal fade">
                        <div class="modal-dialog">
                            <div class="modal-content">

                                <div class="modal-header">
                                    <h4 class="modal-title">Edit Users</h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                </div>
                                <div class="modal-body">
                                    <div role="tabpanel">
                                        <!-- Nav tabs -->
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li role="presentation" class="active"><a href="#uploadTab" aria-controls="uploadTab" role="tab" data-toggle="tab">Modify</a>

                                            </li>
                                            <li role="presentation"><a href="#browseTab" aria-controls="browseTab" role="tab" data-toggle="tab">Rights</a>

                                            </li>
                                              <li role="presentation"><a href="#Admin" aria-controls="Admin" role="tab" data-toggle="tab">Admin</a>

                                            </li>
                                             <li role="presentation"><a href="#Reports" aria-controls="Reports" role="tab" data-toggle="tab">Reports</a>

                                            </li>
                                        </ul>
                                        <!-- Tab panes -->
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane active" id="uploadTab">

                                                <div class="container-fluid">
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                            <div class="form-group">
                                                                <label>User Name:</label>
                                                            <asp:TextBox ID="TextBox5" class="form-control pull-right" placeholder="Enter Username" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                          <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                            <div class="form-group">
                                                                <label>Password:</label>
                                                                <asp:TextBox ID="TextBox7" class="form-control pull-right" placeholder="Enter Password" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>

                                                   <br />
                                                      <div class="row">
                                                        <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                            <div class="form-group">
                                                                <label>Full Name:</label>
                                                                  <asp:TextBox ID="TextBox8" class="form-control pull-right" placeholder="Enter Name" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                           <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                            <div class="form-group">
                                                                <label>Title:</label>
                                                               <asp:TextBox ID="TextBox9" class="form-control pull-right" placeholder="Enter Title" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                     <br />


                                                    <div class="row">
                                                        <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                            <div class="form-group">
                                                                <label>Office:</label>
                                                                <select class="form-control" id="office1">
                                                                    <option disabled selected value>Select an Option</option>
                                                                    <option value="IVO">IVO</option>
                                                                    <option value="HML">HML</option>
                                                                    <option value="ATH">ATH</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 col-sm-12 col-xs-12 col-lg-6">

                                                            <div class="form-group">
                                                                <label>Group</label>
                                                                <select class="form-control" id="group1">
                                                                    <option disabled selected value>Select an Option</option>
                                                                    <%Response.Write(getAllGroups()); %>
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                     <br />
                                                    <div class="row">
                                                       
                                                         <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">

                                                            <div class="form-group">
                                                                <label>Email:</label>
                                                              <asp:TextBox ID="TextBox10" class="form-control pull-right" placeholder="Enter Email" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <br />
                                                     <div class="row">
                                                       
                                                         <div class="col-md-5 col-sm-5 col-xs-5 col-lg-5">

                                                         </div>
                                                         <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">

                                                            <div class="form-group">
                                                              <asp:CheckBox ID="CheckBox1"  runat="server"  /> 
                                                              
                                                            </div>
                                                        </div>
                                                           <div class="col-md-4 col-sm-4 col-xs-4 col-lg-4">

                                                         </div>
                                                    </div>

                                                </div>

                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="browseTab">
                                                     
                                                <div class="container-fluid">
                                                    <br />
                                                    <div class="row">
                                                         <div class="table-responsive">
                                                             <div style="overflow:scroll;height:250px;width:100%;overflow:auto">
                                                       <table class="table table-striped table-hover" id="table2" >
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
                                          



                                            </div>

                                            <div role="tabpanel" class="tab-pane" id="Admin">
                                                     
                                                <div class="container-fluid">
                                                    <br />
                                                    <div class="row">
                                                         <div class="table-responsive">
                                                            <div style="overflow:scroll;height:250px;width:100%;overflow:auto">
                                                             <table class="table table-striped table-hover" id="table3">
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
                                          



                                            </div>


                                              <div role="tabpanel" class="tab-pane" id="Reports">
                                                     
                                                <div class="container-fluid">
                                                    <br />
                                                    <div class="row">
                                                        <div class="table-responsive">
                                                            <div style="overflow: scroll; height: 250px; width: 100%; overflow: auto">
                                                                <table class="table table-striped table-hover" id="table4">
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




                                              </div>

                                        </div>
                                    </div>
                                   
                                </div>
                                <div class="modal-footer">
                                    <input type="button" class="btn btn-default" data-dismiss="modal" id="cancel1" value="Cancel" />
                                    <input type="button" class="btn btn-info" data-dismiss="modal" id="update" value="Save" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- Delete Modal HTML -->
                    <div id="deleteEmployeeModal" class="modal fade">
                        <div class="modal-dialog">
                            <div class="modal-content">

                                <div class="modal-header">
                                    <h4 class="modal-title">Delete Employee</h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                </div>
                                <div class="modal-body">
                                    <p>Are you sure you want to delete these Records?</p>
                                    <p class="text-warning"><small>This action cannot be undone.</small></p>
                                </div>
                                <div class="modal-footer">
                                    <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel" />
                                    <input type="submit" class="btn btn-danger" value="Delete" />
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

            $('#form1').bind('keydown', function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                }
            });
        </script>

        <script>
            $(document).ready(function () {
                $("#addusers").click(function () {

                    $("#TextBox1").val("");
                    $("#TextBox2").val("");
                    $("#TextBox3").val("");
                    $("#TextBox4").val("");
                    $("#TextBox6").val("");
                    $("#TextBox11").val("");
                    $("#status").val('');
                    $("#office").val('');
                    $("#group").val('');

                });

            });

        </script>
        
    <script>

        $(document).ready(function () {
     
            $("#insert").click(function () {
                var username = $("#TextBox1").val();
                if (username == "" || username == null) {
                    username = "";
                } else {
                    username = $("#TextBox1").val();
                }
                var password = $("#TextBox2").val();
                if (password == "" || password == null) {
                    password = "";
                } else {
                    password = $("#TextBox2").val();
                }
                var name = $("#TextBox3").val();
                if (name == "" || name == null) {
                    name = "";
                } else {
                    name = $("#TextBox3").val();
                }
                var email = $("#TextBox4").val();
                if (email == "" || email == null) {
                    email = "";
                } else {
                    email = $("#TextBox4").val();
                }
                var title = $("#TextBox6").val();
                if (title == "" || title == null) {
                    title = "";
                } else {
                    title = $("#TextBox6").val();
                }
                var office = $("#office").val();
                if (office=="" || office==null) {
                    office = "";
                }else{
                    office = $("#office").val();
                }
            
                var group = $("#group").val();
                if (group == "" || group == null) {
                    group = "";
                } else {
                    group = $("#group").val();
                }


                $.ajax({

                    type:'Post',
                    url: 'Rights.aspx/insertUsers',
                    contentType:"application/json; charset=utf-8",
                    data: "{'username':'" + username + "','password':'" + password + "','name':'" + name + "','email':'" + email + "','office':'" + office + "','group':'" + group + "','title':'" + title + "'}",
                    async: false,
                    success: function (data) {
                        $("#TextBox1").val("");
                        $("#TextBox2").val("");
                        $("#TextBox3").val("");
                        $("#TextBox4").val("");
                        $("#TextBox6").val("");
                        $("#TextBox11").val("");
                        $("#status").val('');
                        $("#office").val('');
                        $("#task-table tbody").empty();
                        $("#group").val('');
                        $("#success-alert").fadeTo(1500, 500).slideUp(500, function () {
                            $("#success-alert").slideUp(500);
                        });
                     
                           
                    },
                    error: function () {
                        $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                            $("#danger-alert").slideUp(500);
                        });

                        $("#TextBox1").val("");
                        $("#TextBox2").val("");
                        $("#TextBox3").val("");
                        $("#TextBox4").val("");
                        $("#TextBox6").val("");
                        $("#TextBox11").val("");
                        $("#status").val('');
                        $("#office").val('');
                        $("#task-table tbody").empty();
                        $("#group").val('');
                    }

                });
                return false;


            });
        });
    </script>

        <script>

            $(document).ready(function () {

                $("#active1").click(function () {
               
                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getAllActiveUsers',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
 			    $("#myPager").show();
                            $("#task-table").show();
                            $("#task-table tbody").empty();
                            $("#myPager").empty();
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {
                                    if (value1[0] == "") {

                                    } else {

                                        $("#task-table tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td style='display:none;'>" + value1[4] + "</td><td>" + value1[5] + "</td><td>" + value1[6] + "</td><td>" + value1[7] + "</td><td>" + value1[8] + "</td><td><a href='#editEmployeeModal' class='edit' data-toggle='modal'><i class='material-icon' data-toggle='tooltip' title='Edit'> <span class='glyphicon glyphicon-edit'></span></i></a></td></tr>");
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

                                $('#myTable').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 10 });

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

                $("#inactive1").click(function () {
               
                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getAllINactiveUsers',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
 			    $("#myPager").show();
                            $("#task-table").show();
                            $("#task-table tbody").empty();
                            $("#myPager").empty();
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {
                                    if (value1[0] == "") {

                                    } else {

                                        $("#task-table tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td style='display:none;'>" + value1[4] + "</td><td>" + value1[5] + "</td><td>" + value1[6] + "</td><td>" + value1[7] + "</td><td>" + value1[8] + "</td><td><a href='#editEmployeeModal' class='edit' data-toggle='modal'><i class='material-icon' data-toggle='tooltip' title='Edit'> <span class='glyphicon glyphicon-edit'></span></i></a></td></tr>");
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

                                $('#myTable').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 10 });

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
              
                $("#TextBox11").keyup(function () {

                    var search = $("#TextBox11").val();
                $.ajax({

                    type: 'Post',
                    url: 'Rights.aspx/getAllUsers',
                    contentType: "application/json; charset=utf-8",
                    data: "{'search':'" + search + "'}",
                    async: false,
                    success: function (data) {
                        $("#task-table").show();
                        $("#task-table tbody").empty();
                     
                        subJson = JSON.parse(data.d);
                            
                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {
                                if (value1[0] == "") {
                                    $("#task-table").hide();
                                   
                                    $("#myPager").empty();
                                } else {

                                    $("#task-table tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td style='display:none;'>" + value1[4] + "</td><td>" + value1[5] + "</td><td>" + value1[6] + "</td><td>" + value1[7] + "</td><td>" + value1[8] + "</td><td><a href='#editEmployeeModal' class='edit' data-toggle='modal'><i class='material-icon' data-toggle='tooltip' title='Edit'> <span class='glyphicon glyphicon-edit'></span></i></a></td></tr>");
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
                var val = "";
                $(document).on('click', '.edit', function () {

                    var row = $(this).closest("tr");
                    var username = row.find("td:eq(0)").text();
                    var password = row.find("td:eq(1)").text();
                    var name = row.find("td:eq(2)").text();
                    var office = row.find("td:eq(3)").text();
                    var email = row.find("td:eq(5)").text();
                    var title = row.find("td:eq(6)").text();
                    var group = row.find("td:eq(4)").text();
                    var status = row.find("td:eq(8)").text();

                    $("#TextBox5").val(username);
                    $("#TextBox7").val(password);
                    $("#TextBox8").val(name);
                    $("#TextBox9").val(title);
                    $("#TextBox10").val(email);
                    $("#office1 option[value='" + office + "']").prop('selected', true);
                    $("#group1 option[value='" + group + "']").prop('selected', true);

                    if (status == "Active") {
                        $('#CheckBox1').prop('checked', false);
                        val = "Active";
                    } else {
                        $('#CheckBox1').prop('checked', true);
                        val = "Inactive";
                    }

                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getRights',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {

                            $("#table2 tbody").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $("#table2 tbody").append("<tr><td>" + value1[1] + "</td><td><input type='checkbox' name='tick[]' id='tick' value='" + value1[1] + "'></td></tr>");


                                });

                            });
                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });


                



                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getActiveRights',
                        contentType: "application/json; charset=utf-8",
                        data: "{'group':'" + group + "','username':'" + username + "'}",
                        async: false,
                        success: function (data) {
                            // alert(data.d);
                            $("#tick").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $('input[name="tick[]"][value="' + value1[0] + '"]').prop("checked", true);


                                });

                            });
                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });




                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getAdmin',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {

                            $("#table3 tbody").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $("#table3 tbody").append("<tr><td>" + value1[1] + "</td><td><input type='checkbox' name='tick1[]' id='tick1' value='" + value1[1] + "'></td></tr>");


                                });

                            });
                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });


                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getActiveAdmin',
                        contentType: "application/json; charset=utf-8",
                        data: "{'group':'" + group + "','username':'" + username + "'}",
                        async: false,
                        success: function (data) {
                            // alert(data.d);
                            $("#tick1").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $('input[name="tick1[]"][value="' + value1[0] + '"]').prop("checked", true);


                                });

                            });
                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });




                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getReports',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {

                            $("#table4 tbody").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $("#table4 tbody").append("<tr><td>" + value1[1] + "</td><td><input type='checkbox' name='tick2[]' id='tick2' value='" + value1[1] + "'></td></tr>");


                                });

                            });
                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });


                    $.ajax({

                        type: 'Post',
                        url: 'Rights.aspx/getActiveReports',
                        contentType: "application/json; charset=utf-8",
                        data: "{'group':'" + group + "','username':'" + username + "'}",
                        async: false,
                        success: function (data) {
                           // alert(data.d);
                            $("#tick2").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $('input[name="tick2[]"][value="' + value1[0] + '"]').prop("checked", true);


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

                $("#CheckBox1").click(function () {
                    if ($("#CheckBox1").is(':checked')) {
                        val = "Inactive";
                    } else {
                        val = "Active";
                    }
                });


                $("#update").click(function () {
                    var vals = "";
                    var vals1 = "";

                    var aVal = "";
                    var aVal1 = "";

                    var rVal = "";
                    var rVal1 = "";

                    $("input[name='tick[]']").each(function () {
                        if ($(this).is(":checked")) {
                            var val = $(this).val();

                            vals += val + ",";

                        } else {
                            var val1 = $(this).val();
                            vals1 += val1 + ",";
                        }

                    });

                    //alert(vals);
                    // alert(vals1);


                    $("input[name='tick1[]']").each(function () {
                        if ($(this).is(":checked")) {
                            var aval = $(this).val();

                            aVal += aval + ",";

                        } else {
                            var aval1 = $(this).val();
                            aVal1 += aval1 + ",";
                        }

                    });

                    //alert(aVal);
                    //alert(aVal1);


                    $("input[name='tick2[]']").each(function () {
                        if ($(this).is(":checked")) {
                            var rval = $(this).val();

                            rVal += rval + ",";

                        } else {
                            var rval1 = $(this).val();
                            rVal1 += rval1 + ",";
                        }

                    });

                    //alert(rVal);
                    // alert(rVal1);





                    var username = $("#TextBox5").val();
                    if (username == "" || username == null) {
                        username = "";
                    } else {
                        username = $("#TextBox5").val();
                    }
                    var password = $("#TextBox7").val();
                    if (password == "" || password == null) {
                        password = "";
                    } else {
                        password = $("#TextBox7").val();
                    }
                    var name = $("#TextBox8").val();
                    if (name == "" || name == null) {
                        name = "";
                    } else {
                        name = $("#TextBox8").val();
                    }
                    var email = $("#TextBox10").val();
                    if (email == "" || email == null) {
                        email = "";
                    } else {
                        email = $("#TextBox10").val();
                    }
                    var title = $("#TextBox9").val();
                    if (title == "" || title == null) {
                        title = "";
                    } else {
                        title = $("#TextBox9").val();
                    }
                    var office = $("#office1").val();
                    if (office == "" || office == null) {
                        office = "";
                    } else {
                        office = $("#office1").val();
                    }

                    var group = $("#group1").val();
                    if (group == "" || group == null) {
                        group = "";
                    } else {
                        group = $("#group1").val();
                    }




                    $.ajax({
                        type: 'POST',
                        url: 'Rights.aspx/updateUsers',
                        contentType: "application/json; charset=utf-8",
                        data: "{'username':'" + username + "','password':'" + password + "','name':'" + name + "','email':'" + email + "','val':'" + val + "','office':'" + office + "','group':'" + group + "','title':'" + title + "','vals':'" + vals + "','vals1':'" + vals1 + "','rVal':'" + rVal + "','rVal1':'" + rVal1 + "','aVal':'" + aVal + "','aVal1':'" + aVal1 + "'}",
                        async: false,
                        success: function (data) {
                            $("#TextBox1").val("");
                            $("#TextBox2").val("");
                            $("#TextBox3").val("");
                            $("#TextBox4").val("");
                            $("#TextBox6").val("");
                            $("#task-table tbody").empty();
    		            $("#task-table").hide();
                            $("#myPager").empty();
                            $("#myPager").hide();
                            $("#office").val('');
                            $("#department").val('');
                            $("#group").val('');

                            $("#TextBox11").val("");
                            $("#success-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#success-alert").slideUp(500);
                            });
                            $("#editEmployeeModal").modal('hide');


                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });

                    


                });



                //$("#cancel").click(function () {

                //    $("#TextBox11").val("");
                //    $("#task-table tbody").empty();

                //});


                //$("#cancel1").click(function () {

                //    $("#TextBox11").val("");
                //    $("#task-table tbody").empty();

                //});


            });

        </script>


     


        <%--         <script>
             $(document).ready(function () {
                 //var val = "";
                 //if ($('#CheckBox1').prop('checked', false)) {
                 //    alert("hiee");
                 //    val = "Inactive";
                 //} else {
                 //    alert("hello");
                 //    val = "Active";
                 //}
               
              
                
           
               

            })
        </script>--%>


        <script>

        $(document).ready(function () {

            $.ajax({

                type: 'Post',
                url: 'Rights.aspx/getAdminRights',
                contentType: "application/json; charset=utf-8",
                data: "{}",
                async: false,
                success: function (data) {

                    $("#task-table6 tbody").empty();

                    subJson = JSON.parse(data.d);

                    $.each(subJson, function (key, value) {

                        $.each(value, function (index1, value1) {
                          

                                $("#task-table6 tbody").append("<tr><td><a href='"+value1[1]+"'>"+value1[0]+"</a></td></tr>");
                           
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
                    url: 'Rights.aspx/searchProfile',
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
                    url: 'Rights.aspx/getlink',
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


