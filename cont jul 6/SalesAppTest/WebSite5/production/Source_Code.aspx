﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Source_Code.aspx.cs" Inherits="WebSite5_production_Source_Code" %>

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

    #img1 {
            text-align: center;

           -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
-moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

    #success-alert,#danger-alert,#danger-alert1{
            display:none;
        }
    
      #update,#head,#sourceCodeID,#sourceCodeName,#sourceCodeStatus,#MarktSource,#directory,#insert,#Type1,#sourceCodeAgentName{
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
                    <div class="navbar nav_title" style="border-bottom: 2px; height: auto; color: #172D44;" id="img1">
                        <img src="../production/images/k.png" class="img-square" alt="" width="40" height="40" />
                        <br />
                        <a href="#" class="site_title"><span style="opacity: 0.5;">Karma Group</span></a>
                    </div>

                    <div class="clearfix"></div>

                    <!-- menu profile quick info -->
                    <div class="profile clearfix">
                        <div class="profile_pic">
                            <img src="images/img.jpg" alt="..." class="img-circle profile_img"/>
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
                    <div class="alert alert-danger" id="danger-alert1">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Enter Details! </strong>

                    </div>
                <div class="container-fluid">
                    <button type="button" id="insertButton" class="btn btn-primary pull-right btn-block">Insert</button>
                    <button type="button" id="view" class="btn btn-primary pull-right btn-block">View</button>
          <div class="row">
          <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12 " id="head" ><br />
        <h3 class="text-center">ADD SOURCE CODE</h3>
              </div>
              </div>
            </div>
              <br /><br />
        <div class="container-fluid">
          <div class="row"> 
              <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="sourceCodeID">
                  <div class="form-group">
                      <label for="sel1">Source Code ID:</label>
                      <asp:TextBox ID="TextBox1" class="form-control pull-right"  runat="server" ReadOnly></asp:TextBox>
                     
                  </div>
              </div>
            
              <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="sourceCodeName">
                  <div class="form-group">
                      <label for="sel1">Source Code Name:</label>
                      <asp:TextBox ID="TextBox2" class="form-control pull-right" placeholder="Enter Source Code" runat="server"></asp:TextBox>
                  </div>
              </div>
           
               <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="sourceCodeStatus">
                  <div class="form-group">
                      <label for="sel1">Status:</label>
                      <select class="form-control"  id="status">
                          <option disabled selected value>Select an Option</option>
                          <option value="Active">Active</option>
                          <option value="Inactive">Inactive</option>
                      </select>
                  </div>
              </div>
              

            

              <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="MarktSource">
                  <div class="form-group">
                      <label for="sel1">Marketing Source:</label>
                      <select class="form-control" id="marktSource">
                      </select>
                  </div>
              </div>
                 <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="sourceCodeAgentName">
                  <div class="form-group">
                      <label for="sel1">Agent Name:</label>
                      <asp:TextBox ID="TextBox3" class="form-control pull-right" placeholder="Enter Source Code" runat="server"></asp:TextBox>
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
              <h3 class="text-center">SOURCE CODE DIRECTORY</h3>
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
                                        <th>SOURCE CODE</th>
                                        <th>STATUS</th>
                                        <th>MARKT SOURCE</th>
 <th>AGENT NAME</th>
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
            
            
            
            $("#insert").click(function () {
                var sourceCodeName = $("#TextBox2").val();
                if (sourceCodeName == "" || sourceCodeName == null) {
                    sourceCodeName = "";
                } else {
                    sourceCodeName = $("#TextBox2").val();
                  // alert(sourceCodeName);
                }

                var marktSource = $("#marktSource").val();
                if (marktSource == "" || marktSource == null) {
                    marktSource = "";
                } else {
                    marktSource = $("#marktSource").val();
                   // alert(marktSource);

               
                }
                
                var agentName = $("#TextBox3").val();
                if (agentName == "" || agentName == null) {
                    agentName = "";
                } else {
                    agentName = $("#TextBox3").val();
                    //alert(marktSource);


                }
                $.ajax({

                    type:'Post',
                    url: 'Source_Code.aspx/insertSourceCode',
                    contentType:"application/json; charset=utf-8",
                    data: "{'sourceCodeName':'" + sourceCodeName + "','marktSource':'" + marktSource + "','agentName':'" + agentName + "'}",
                    async: false,
                    success: function (data) {
                        $("#TextBox2").val("");
                        $("#TextBox3").val("");
                        $("#marktSource").val('');
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
                    
                    $("#Type1").show();
                    $("#sourceCodeName").show();
                    $("#sourceCodeAgentName").show();
                    $("SourceCodeStatus").hide();
                    $("#MarktSource").show();
                    $("#insert").show();
                    $("#insertButton").hide();
                    $("#view").show();
                    $("#directory").hide();
                    $("#update").hide();
                    $("#sourceCodeID").hide();
                    $("#TextBox1").val("");
                    $("#TextBox2").val("");
                    
                    $("#TextBox5").val("");
                    $("#status").val('');
                    $("#marktSource").val('');
               
                    $("#type").val('');
                  

                });
                $("#view").click(function () {
                    $("#head").hide();
                    $("#sourceCodeName").hide();
                    $("#sourceCodeAgentName").hide();
                    $("#Type1").hide();
                    $("#sourceCodeStatus").hide();
                    $("#insert").hide();
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#directory").show();
                    $("#sourceCodeID").hide();
                    $("#update").hide();
                    $("#MarktSource").hide();
                    $("#TextBox5").val("");

                });
                $(document).on('click', '.edit-btn', function () {
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#sourceCodeID").show();
                    $("#sourceCodeName").show();
                    $("#sourceCodeAgentName").show();
                    $("#sourceCodeStatus").show();
                    $("#Type1").hide();
                    $("#MarktSource").show();
                    $("#update").show();
                    $("#directory").hide();


                    var row = $(this).closest("tr");
                    var sourceCodeID = row.find("td:eq(0)").text();
                    var sourceCodeName = row.find("td:eq(1)").text();
                    var status = row.find("td:eq(2)").text();
                    var marktSource_ID = row.find("td:eq(3)").text();
                    var agentName = row.find("td:eq(5)").text();
                    $("#TextBox1").val(sourceCodeID);
                    $("#TextBox2").val(sourceCodeName);
                    $("#status option[value='" + status + "']").prop('selected', true);
                    $("#marktSource option[value='" + marktSource_ID + "']").prop('selected', true);
                    $("#TextBox3").val(agentName);
                });
            });
        </script>
        



        <script>
            $(document).ready(function () {

                $("#view").click(function () {

                    $.ajax({

                        type: 'Post',
                        url: 'Source_Code.aspx/getAllSourceCode',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                            $("#task-table tbody").empty();
                            $("#myPager").empty();
                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {

                                    $("#task-table tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td style='display:none;'>" + value1[3] + "</td><td>" + value1[4] + "</td><td>" + value1[5] + "</td><td><button type='button'  class='edit-btn btn btn-primary col-md-12' >Edit</button></td><td><button type='button'  class='delete-btn btn btn-primary col-md-12' >Delete</button></td></tr>");

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

                                $('#myTable').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 20 });

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
                    var SourceCodeID = row.find("td:eq(0)").text();
                    var SourceCodeName = row.find("td:eq(1)").text();
                
                    var confirmation = confirm("are you sure you want to delete " + SourceCodeName + " ?");

                    if (confirmation) {

                        $.ajax({
                            type: 'POST',
                            url: 'Source_Code.aspx/deleteSourceCode',
                            contentType: "application/json; charset=utf-8",
                            data: "{'SourceCodeID':'" + SourceCodeID + "'}",
                            async: false,
                            success: function (data) {

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
                    var sourceCodeID = $("#TextBox1").val();

                    var sourceCodeName = $("#TextBox2").val();
                    if (sourceCodeName = "" || sourceCodeName == null) {
                        sourceCodeName = "";
                    } else {
                        sourceCodeName = $("#TextBox2").val();
                    }
                    var status = $("#status").val();
                    var marktSource = $("#marktSource").val();
                    if (marktSource = "" || marktSource == null) {
                        marktSource = "";
                    } else {
                        marktSource = $("#marktSource").val();
                    }
                    var agentName = $("#TextBox2").val();
                    if (agentName == "" || agentName==null) {
                        agentName = "";
                    }else{
                        agentName = $("#TextBox2").val();
                       // alert(agentName);
                   }

                    $.ajax({
                        type: 'POST',
                        url: 'Source_Code.aspx/updateSourceCode',
                        contentType: "application/json; charset=utf-8",
                        data: "{'sourceCodeID':'" + sourceCodeID + "','sourceCodeName':'" + sourceCodeName + "','status':'" + status + "','marktSource':'" + marktSource + "','agentName':'" + agentName + "'}",
                        async: false,
                        success: function (data) {
                            $("#TextBox1").val("");
                            $("#TextBox2").val("");
                            $("#TextBox3").val("");
                            $("#TextBox5").val("");
                            $("#status").val('');
                           
                            $("#marktSource").val('');
                        
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
                    $("#sourceCodeID").hide();
                    $("#sourceCodeName").hide();
                    $("#sourceCodeAgentName").hide();
                    $("#sourceCodeStatus").hide();
                    $("#MarktSource").hide();
                    $("#update").hide();
                    $("#insertButton").show();

                });
            });
        </script>
    
        <script>
            $(document).ready(function () {
             
                    $.ajax({
                        type: 'POST',
                        url: 'Source_Code.aspx/getAllMarketingSource',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                         
                           $("#marktSource").empty();
                           $("#marktSource").append("<option disabled selected value>Select an Option</option>");

                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                    $("#marktSource").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");
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
                url: 'Source_Code.aspx/getAdminRights',
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
