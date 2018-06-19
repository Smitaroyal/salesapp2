<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Fee.aspx.cs" Inherits="WebSite5_production_Admin_Fee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title></title>
    <style>
        #img1 {
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

        #update, #Year, #head, #Country, #directory, #insert, #directory1,#Status,#Month,#AdminFee,#ID{
            display: none;
        }

        #success-alert, #danger-alert, #danger-alert1 {
            display: none;
        }

        #TextBox5 {
            text-align: center;
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
                    <div class="navbar nav_title" style="border-bottom: 2px; height: auto; color: #172D44;" id="img1">
                        <img src="../production/images/k.png" class="img-square" alt="" width="40" height="40" />
                        <br />
                        <a href="#" class="site_title"><span style="opacity: 0.5;">Karma Group</span></a>
                    </div>
                    <div class="clearfix"></div>

                    <!-- menu profile quick info -->
                    <div class="profile clearfix">
                        <div class="profile_pic">
                            <img src="images/img.jpg" alt="..." class="img-circle profile_img">
                        </div>
                        <div class="profile_info">
                            <span>Welcome,</span><br />

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
                                    <img src="images/img.jpg" alt="" /><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    <span class=" fa fa-angle-down"></span>
                                </a>
                                <ul class="dropdown-menu dropdown-usermenu pull-right">
                                    <li><a href="Profile_Page.aspx">Change Password</a></li>

                                    <li><a href="javascript:;">Help</a></li>
                                    <li><a href="logout.aspx"><i class="fa fa-sign-out pull-right"></i>Log Out</a></li>
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
                              <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " id="head">
                                  <br />
                                  <h4 class="text-center">ADD ADMIN FEE</h4>
                              </div>
                          </div>
                      </div>
                      <br />
                      <br />
                      <div class="container-fluid">
                          <div class="row">

                                <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="ID">
                                  <div class="form-group">
                                      <label for="sel1">ID:</label>
                                    <asp:TextBox ID="TextBox3" class="form-control pull-right" placeholder="" runat="server"  ></asp:TextBox>
                                  </div>
                              </div>
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
                               <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="Month">
                                  <div class="form-group">
                                      <label for="sel1">Month:</label>
                                    <asp:TextBox ID="TextBox2" class="form-control pull-right" placeholder="" runat="server" readonly="true" ></asp:TextBox>
                                  </div>
                              </div>

                               <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="AdminFee">
                                  <div class="form-group">
                                      <label for="sel1">Admin Fee:</label>
                                    <asp:TextBox ID="TextBox1" class="form-control pull-right" placeholder="" runat="server"  ></asp:TextBox>
                                  </div>
                              </div>
                                 <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Status">
                                  <div class="form-group">
                                      <label for="sel1">Status:</label>
                                      <select class="form-control" id="status">
                                          <option disabled selected value>Select an Option</option>
                                          <option value="Active">Active</option>
                                         <option value="Inactive">Inactive</option>
                                      </select>
                                  </div>
                              </div>
                                <div class="col-md-2 col-xs-9 col-sm-2 col-lg-2">
                                    <label for="sel1">&nbsp;</label>
                                       <button type="button" runat="server" id="update" class="btn btn-primary pull-right btn-block">Update</button>

                                  </div>

                               
                          </div>
                      </div>


                      <div class="container-fluid" id="directory">


                        <br />

                        <div class="row">

                            <div class="table-responsive">
                                <table class="table table-hover" id="task-table">
                                    <thead>
                                        <tr>
                                            <th>MONTH</th>
                                            <th>ADMIN FEE</th>
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

                    <div class="container-fluid" id="directory1">
                        <div class="row">
              
                   <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " "><br />
                        <h5 class="text-center">ADMIN FEE DIRECTORY</h5>
                   </div>

                       </div>
                          <div class="row">
                              <div class="col-md-4 col-md-offset-4 col-sm-4 col-sm-offset-4 col-xs-6 col-xs-offset-3 col-lg-4 col-lg-offset-4">
                                  <div class="form-group">
                                      <label for="sel1"></label>
                                      <asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server" placeholder="Search"  data-table="table table-hover" ></asp:TextBox>
                                  </div>
                              </div>
                          </div>
                          <div class="row">

                              <div class="table-responsive">
                                  <table class="table table-hover" id="task-table1">
                                      <thead>
                                          <tr>
                                              <th>ID</th>
                                              <th>YEAR</th>
                                              <th>MONTH</th>
                                              <th>COUNTRY</th>
                                              <th>ADMIN FEE</th>
                                              <th>STATUS</th>
                                              <th>EDIT</th>
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


                var year = $("#year").val();
                if (year == "" || year == null) {
                    year == "";
                } else {
                    year = $("#year").val();
                }
                var country = $("#country1 option:selected").text();
                if (country == "" || country == null) {
                    country == "";
                } else {
                    country = $("#country1 option:selected").text();
                }

                var MONTH0 = $("#month0").val(); var MONTH2 = $("#month2").val(); var MONTH4 = $("#month4").val(); var MONTH6 = $("#month6").val(); var MONTH8 = $("#month8").val(); var MONTH10 = $("#month10").val();
                var MONTH1 = $("#month1").val(); var MONTH3 = $("#month3").val(); var MONTH5 = $("#month5").val(); var MONTH7 = $("#month7").val(); var MONTH9 = $("#month9").val(); var MONTH11 = $("#month11").val();
                var MONTH = MONTH0 + ',' + MONTH1 + ',' + MONTH2 + ',' + MONTH3 + ',' + MONTH4 + ',' + MONTH5 + ',' + MONTH6 + ',' + MONTH7 + ',' + MONTH8 + ',' + MONTH9 + ',' + MONTH10 + ',' + MONTH11;

                var FEE0 = $("#FEE0").val(); var FEE2 = $("#FEE2").val(); var FEE4 = $("#FEE4").val(); var FEE6 = $("#FEE6").val(); var FEE8 = $("#FEE8").val(); var FEE10 = $("#FEE10").val();
                var FEE1 = $("#FEE1").val(); var FEE3 = $("#FEE3").val(); var FEE5 = $("#FEE5").val(); var FEE7 = $("#FEE7").val(); var FEE9 = $("#FEE9").val(); var FEE11 = $("#FEE11").val();
                var FEE = FEE0 + ',' + FEE1 + ',' + FEE2 + ',' + FEE3 + ',' + FEE4 + ',' + FEE5 + ',' + FEE6 + ',' + FEE7 + ',' + FEE8 + ',' + FEE9 + ',' + FEE10 + ',' + FEE11;
               
                $.ajax({

                    type:'Post',
                    url: 'Admin_Fee.aspx/insertAdmin_Fee',
                    contentType:"application/json; charset=utf-8",
                    data: "{'year':'" + year + "','country':'" + country + "','MONTH':'" + MONTH + "','FEE':'" + FEE + "'}",
                    async: false,
                    success: function (data) {
                        $("#TextBox5").val("");
                        $("#year").val('');
                        $("#country1").val('');

                        $("#FEE0").val(''); $("#FEE1").val(''); $("#FEE2").val(''); $("#FEE3").val(''); $("#FEE4").val(''); $("#FEE5").val(''); $("#FEE6").val(''); $("#FEE7").val(''); $("#FEE8").val(''); $("#FEE9").val(''); $("#FEE10").val(''); $("#FEE11").val('');
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
               

                $("#insertButton").click(function () {
                    $("#head").show();
                    $("#Year").show();
                    $("#Country").show();
                    $("#directory").show();
                    $("#insert").show();
                    $("#insertButton").hide();
                    $("#view").show();
                    $("#task-table1 tbody").empty();
                    $("#update").hide();
                    $("#AdminFee").hide();
                    $("#Status").hide();
                    $("#Month").hide();
                    $("#year").val('');
                    $("#TextBox5").val("");
                    $("#country1").val('');
                    $("#directory1").hide();
                    $('#year').attr("disabled", false);
                });
                $("#view").click(function () {
                    $("#head").hide();
                    $("#Year").hide();
                    $("#Country").hide();
                    $("#insert").hide();
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#directory").hide();
                    $("#directory1").show();
                    $("#update").hide();
                    $("#Status").hide();
                    $("#Month").hide();
                    $("#AdminFee").hide();
                    $("#TextBox5").val("");
                    $("#task-table1 tbody").empty();

                });
               

            });
        </script>
       



         <script>
            $(document).ready(function () {

                $("#year").change(function () {
                    var current = 0;
                    $.ajax({

                        type: 'Post',
                        url: 'Admin_Fee.aspx/getdetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                            $("#task-table tbody").empty();
                         
                            subJson = JSON.parse(data.d);
                         
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                   
                                    $("#task-table tbody").append("<tr><td style='display:none'><input type='hidden' style='width:80px' id='month" + current + "' value='" + value1[0] + "'></td><td>" + value1[0] + "</td><td><input type='text' style='width:100px' id='FEE" + current + "'></td></tr>");

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


        
         <script>
            $(document).ready(function () {

                $("#TextBox5").keyup(function () {
                    var value = $("#TextBox5").val();
                    $.ajax({

                        type: 'Post',
                        url: 'Admin_Fee.aspx/getAdminFeeOnYear',
                        contentType: "application/json; charset=utf-8",
                        data: "{'year':'"+value+"'}",
                        async: false,
                        success: function (data) {
                            $("#task-table1 tbody").empty();
                         
                            subJson = JSON.parse(data.d);
                         
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                    if (value1[0] == "") {

                                    } else {

                                        $("#task-table1 tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td>" + value1[4] + "</td><td>" + value1[5] + "</td><td><button type='button'  class='edit-btn btn btn-primary col-md-12' >Edit</button></td></tr>");
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
                   
                 
                

                });
            });

        </script>

        <script>

            $(document).ready(function () {
                $(document).on('click', '.edit-btn', function () {
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#AdminFee").show();
                    $("#Year").show();
                    $("#Year").show();
                    $("#Status").show();
                    $("#update").show();
                    $("#Month").show();
                    $("#directory").hide();
                    $("#directory1").hide();
                    $('#year').attr("disabled", true);

                    var row = $(this).closest("tr");
                    var ID = row.find("td:eq(0)").text();
                    var year = row.find("td:eq(1)").text();
                    var month = row.find("td:eq(2)").text();
                    var fee = row.find("td:eq(4)").text();
                    var status = row.find("td:eq(5)").text();

                    $("#year option[value='" + year + "']").prop('selected', true);
                    $("#TextBox1").val(fee);
                    $("#TextBox2").val(month);
                    $("#TextBox3").val(ID);
                    $("#status option[value='" + status + "']").prop('selected', true);
                });

            });
           

        </script>
      
        <script>
            $(document).ready(function () {
                $("#update").click(function () {
                    $("#insertButton").hide();
                    $("#view").show();

                    var ID = $("#TextBox3").val();
                    var adminFee = $("#TextBox1").val();
                    var status = $("#status").val();

                    if (adminFee == "" || adminFee == null) {
                        adminFee = "";
                    } else {
                        var adminFee = $("#TextBox1").val();
                    }

                    if (status == "" || status == null) {
                        status = "";
                    }else{
                        var status = $("#status").val();
            }
                    $.ajax({
                        type: 'POST',
                        url: 'Admin_Fee.aspx/updateAdminFee',
                        contentType: "application/json; charset=utf-8",
                        data: "{'ID':'" + ID + "','adminFee':'" + adminFee + "','status':'" + status + "'}",
                        async: false,
                        success: function (data) {
                            $("#TextBox1").val("");
                            $("#TextBox2").val("");
                            $("#TextBox3").val("");
                            $("#year").val("");
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
                    $("#Year").hide();
                    $("#Country").hide();
                    $("#Month").hide();
                    $("#AdminFee").hide();
                    $("#Status").hide();
                    $("#update").hide();
                    $("#insertButton").show();
                    $("#TextBox5").val("");

                });
            });
        </script>

    

       
    
</body>
</html>
