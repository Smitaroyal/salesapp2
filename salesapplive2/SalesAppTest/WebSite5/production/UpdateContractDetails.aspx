<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateContractDetails.aspx.cs" Inherits="WebSite5_production_UpdateContractDetails" %>

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


         #update,#countryID,#head,#countryName,#countryCode,#directory,#insert,#contractID,#contractType,#oldContractNo,
         #salesMarketingSource,#profileID,#ReferralBy,#Comment,#contractNo,#dealDate,#dealStatus1,#SubVenue,#LeadOffice,#MarketingPro,
          #oldDeposit,#oldTotalTax,#oldAdminFee,#oldVolume{
             display:none;
         }

           #success-alert,#danger-alert,#danger-alert1,#menu_toggle,#profileDetails{
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

                          <img src="../production/images/KSC1.png" class="img-square" alt="" style="margin-top:3px; margin-bottom:5px;"  width="150" height="50" /><br />
                      
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
                <div class="container-fluid">
                
          <div class="row">
          <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " id="head"><br />
        <h3 class="text-center"></h3>
              </div>
              </div>
            </div>
              <br /><br />
        <div class="container-fluid">
            <div class="row">
                  <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="Group">
                      <div class="form-group">
                          <label for="sel1">Group:</label>
                          <select class="form-control" id="group">
                              <option disabled selected value>Select an Option</option>
                              <option>Update Deal Status</option>
                              <option>Update Marketing Source SPI</option>
                              <option>Update Referral Name</option>
                              <option>Update Upgrade Details</option>
                          </select>
                      </div>
                  </div>
            </div>
            <br />

          <div class="row"> 
              
              <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="contractID">
                  <div class="form-group">
                      <label for="sel1">Contract ID:</label>
                      <asp:TextBox ID="TextBox1" class="form-control pull-right" runat="server" ReadOnly></asp:TextBox>
                     
                  </div>
              </div>

              <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="profileID">
                  <div class="form-group">
                      <label for="sel1">Profile ID:</label>
                      <asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server" ReadOnly></asp:TextBox>
                     
                  </div>
              </div>

              <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="contractNo">
                  <div class="form-group">
                      <label for="sel1">Contract No:</label>
                      <asp:TextBox ID="TextBox2" class="form-control pull-right" placeholder="Enter Contract No" runat="server"></asp:TextBox>
                  </div>
              </div>
            

              <div class="col-md-3 col-xs-12 col-sm-3 col-md-3" id="dealDate">
                  <label for="sel1">Date:</label>
                  <div class="input-group date" id="datepicker1" data-provide="datepicker">
                      <asp:TextBox ID="TextBox3" class="form-control pull-right" runat="server" Style="pointer-events: none;"></asp:TextBox>
                      <div class="input-group-addon">
                          <span class="glyphicon glyphicon-th"></span>
                      </div>
                  </div>

              </div>

                 <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3" id="dealStatus1">
                  <div class="form-group">
                      <label for="sel1">Deal Status:</label>
                      <select class="form-control"  id="dealStatus">
                          <option disabled selected value>Select an Option</option>
      
                      </select>
                  </div>
              </div>

               <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="MarketingPro">
                  <div class="form-group">
                      <label for="sel1">Marketing Program:</label>
                      <select class="form-control"  id="marketingProgram">
                        
      
                      </select>
                  </div>
              </div>

                <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="salesMarketingSource">
                  <div class="form-group">
                      <label for="sel1">Marketing Source:</label>
                      <asp:TextBox ID="TextBox4" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>

                <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="ReferralBy">
                  <div class="form-group">
                      <label for="sel1">Referral By:</label>
                      <asp:TextBox ID="TextBox6" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>

                <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="Comment">
                  <div class="form-group">
                      <label for="sel1">Comment:</label>
                      <asp:TextBox ID="TextBox7" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>

                   <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="contractType">
                  <div class="form-group">
                      <label for="sel1">Contract Type:</label>
                      <asp:TextBox ID="TextBox8" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>

               <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="oldContractNo">
                  <div class="form-group">
                      <label for="sel1">Old Contract No:</label>
                      <asp:TextBox ID="TextBox9" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>


               <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="oldVolume">
                  <div class="form-group">
                      <label for="sel1">Old Volume:</label>
                      <asp:TextBox ID="TextBox10" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>

               <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="oldAdminFee">
                  <div class="form-group">
                      <label for="sel1">Old Admin Fee:</label>
                      <asp:TextBox ID="TextBox11" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>

               <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="oldTotalTax">
                  <div class="form-group">
                      <label for="sel1">Old Total Tax:</label>
                      <asp:TextBox ID="TextBox12" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>
             
               <div class="col-md-3 col-xs-12 col-sm-3 col-lg-3" id="oldDeposit">
                  <div class="form-group">
                      <label for="sel1">Old Deposit:</label>
                      <asp:TextBox ID="TextBox13" class="form-control pull-right" placeholder="" runat="server"></asp:TextBox>
                  </div>
              </div>

                <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="SubVenue">
                  <div class="form-group">
                      <label for="sel1">Sub Venue:</label>
                      <select class="form-control"  id="subVenue">
                        
      
                      </select>
                  </div>
              </div>

                <div class="col-md-2 col-sm-2 col-xs-12 col-lg-2" id="LeadOffice">
                  <div class="form-group">
                      <label for="sel1">Lead Office:</label>
                      <select class="form-control"  id="leadOffice">
                        
      
                      </select>
                  </div>
              </div>


              <div class="col-md-2 col-xs-9 col-sm-2 col-lg-2">
             
                  <label for="sel1">&nbsp;</label>
                 <button type="button"  runat="server" id="update" class="btn btn-primary pull-right btn-block">Update</button>
                
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
  
        <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet">  
   
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"></script> 
               <script type="text/javascript">
           
            $(document).ready(function () {
                
                $('#datepicker1').datepicker({
                    format: "dd-mm-yyyy",
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

                $("#update").click(function () {

                    var isValid = true;
                    if ($.trim($("#TextBox2").val()) == '') {
                        isValid = false;
                        alert("Enter Contract Number");
                        $("#TextBox2").css({

                            "border": "1px solid red",

                            "background": "#FFCECE"
                        });
                        if (isValid == false)
                            e.preventDefault();


                    } else {
                        $("#TextBox2").css({

                            "border": "",

                            "background": ""

                        });
                        // alert('Thank you for submitting');
                        //$("#TextBox1").val("");
                    }
                });

            });

            

        </script>
    
    <script>

        
            $(document).ready(function () {
                $("#update").click(function () {
                    $("#insertButton").hide();
                    $("#view").show();

                    var group = $("#group option:selected").text();
                    var contractID = $("#TextBox1").val();
                    var profileID = $("#TextBox5").val();

                    var contractNo = $("#TextBox2").val();
                    if (contractNo == "" || contractNo == null) {
                        contractNo = "";
                    } else {
                        var contractNo = $("#TextBox2").val();
                    }

                    var dealDate = $("#TextBox3").val();
                    if (dealDate == "" || dealDate == null) {
                        dealDate = "";
                    } else {
                        var dealDate = $("#TextBox3").val();
                    }


                    var dealStatus = $("#dealStatus option:selected").text();
                    if (dealStatus == "" || dealStatus == null || dealStatus == "Select an Option") {
                        dealStatus = "";
                    } else {
                        var dealStatus = $("#dealStatus option:selected").text();
                    }

                    var marketingSource = $("#TextBox4").val();
                    if (marketingSource == "" || marketingSource == null ) {
                        marketingSource = "";
                    } else {
                        var marketingSource = $("#TextBox4").val();
                    }

                    var referralBy = $("#TextBox6").val();
                    if (referralBy == "" || referralBy == null) {
                        referralBy = "";
                    } else {
                        var referralBy = $("#TextBox6").val();
                    }
                    var Comment = $("#TextBox7").val();
                    if (Comment == "" || Comment == null) {
                        Comment = "";
                    } else {
                        var Comment = $("#TextBox7").val();
                    }

                    var contractType = $("#TextBox8").val();
                    if (contractType == "" || contractType == null) {
                        contractType = "";
                    } else {
                        var contractType = $("#TextBox8").val();
                    }

                    var oldVolume = $("#TextBox10").val();
                    if (oldVolume == "" || oldVolume == null) {
                        oldVolume = "";
                    } else {
                        var oldVolume = $("#TextBox10").val();
                    }

                    var oldAdminFee = $("#TextBox11").val();
                    if (oldAdminFee == "" || oldAdminFee == null) {
                        oldAdminFee = "";
                    } else {
                        var oldAdminFee = $("#TextBox11").val();
                    }

                    var oldTotalTax = $("#TextBox12").val();
                    if (oldTotalTax == "" || oldTotalTax == null) {
                        oldTotalTax = "";
                    } else {
                        var oldTotalTax = $("#TextBox12").val();
                    }

                    var oldDeposit = $("#TextBox13").val();
                    if (oldDeposit == "" || oldDeposit == null) {
                        oldDeposit = "";
                    } else {
                        var oldDeposit = $("#TextBox13").val();
                    }

                    var oldContractNo = $("#TextBox9").val();
                    if (oldContractNo == "" || oldContractNo == null) {
                        oldContractNo = "";
                    } else {
                        var oldContractNo = $("#TextBox9").val();
                    }

                    var subVenue = $("#subVenue").val();
                    if (subVenue == "" || subVenue == null) {
                        subVenue = "";
                    } else {
                        var subVenue = $("#subVenue").val();
                    }

                    var leadOffice = $("#leadOffice").val();
                    if (leadOffice == "" || leadOffice == null) {
                        leadOffice = "";
                    } else {
                        var leadOffice = $("#leadOffice").val();
                    }

                    var marketingProgram = $("#marketingProgram").val();
                    if (marketingProgram == "" || marketingProgram == null) {
                        marketingProgram = "";
                    } else {
                        var marketingProgram = $("#marketingProgram").val();
                    }
            
                    $.ajax({
                        type: 'POST',
                        url: 'UpdateContractDetails.aspx/updatedetails',
                        contentType: "application/json; charset=utf-8",
                        data: "{'group':'" + group + "','contractID':'" + contractID + "','profileID':'" + profileID + "','contractNo':'" + contractNo + "','dealStatus':'" + dealStatus + "','marketingSource':'" + marketingSource + "','referralBy':'" + referralBy + "','Comment':'" + Comment + "','contractType':'" + contractType + "','oldVolume':'" + oldVolume + "','oldAdminFee':'" + oldAdminFee + "','oldTotalTax':'" + oldTotalTax + "','oldDeposit':'" + oldDeposit + "','oldContractNo':'" + oldContractNo + "','subVenue':'" + subVenue + "','leadOffice':'" + leadOffice + "','dealDate':'" + dealDate + "','marketingProgram':'" + marketingProgram + "'}",
                        async: false,
                        success: function (data) {

                            $("#contractNo").hide();
                            $("#dealStatus1").hide();
                            $("#salesMarketingSource").hide();
                            $("#dealDate").hide();
                            $("#ReferralBy").hide();
                            $("#Comment").hide();
                            $("#update").hide();
                            $("#oldDeposit").hide();
                            $("#oldTotalTax").hide();
                            $("#oldAdminFee").hide();
                            $("#oldVolume").hide();
                            $("#contractType").hide();
                            $("#oldContractNo").hide();
                            $("#SubVenue").hide();
                            $("#MarketingPro").hide();
                            $("#LeadOffice").hide();
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
                            $("#TextBox11").val("");
                            $("#TextBox12").val("");
                            $("#TextBox13").val("");

                            $("#dealStatus").val('');
                            $("#group").val('');
                            $("#subVenue").empty();
                            $("#leadOffice").empty();
                            $("#marketingProgram").empty();
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

                $("#TextBox2").blur(function () {

                    var contractNo = $("#TextBox2").val();
                    var group = $("#group option:selected").text();

                    if (contractNo == "" || contractNo == null) {
                        $("#TextBox3").val("");
                        $("#dealStatus").val('');

                    } else

                    {

                        $.ajax({

                            type: 'Post',
                            url: 'UpdateContractDetails.aspx/getMarketingProgramOnContractNo',
                            contentType: "application/json; charset=utf-8",
                            data: "{'contractNo':'" + contractNo + "'}",
                            async: false,
                            success: function (data) {

                                $("#marketingProgram").empty();

                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {

                                        $("#marketingProgram").append("<option value='" + value1[0] + "'>" + value1[1] + "</option>");

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
                            url: 'UpdateContractDetails.aspx/getSubvenueOnContractNo',
                            contentType: "application/json; charset=utf-8",
                            data: "{'contractNo':'" + contractNo + "'}",
                            async: false,
                            success: function (data) {

                                $("#subVenue").empty();

                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {

                                        $("#subVenue").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");

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
                            url: 'UpdateContractDetails.aspx/getLeadOfficeOnContractNo',
                            contentType: "application/json; charset=utf-8",
                            data: "{'contractNo':'" + contractNo + "'}",
                            async: false,
                            success: function (data) {

                                $("#leadOffice").empty();

                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {

                                        $("#leadOffice").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");

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
                            url: 'UpdateContractDetails.aspx/getContractDetailsOnContractNo',
                            contentType: "application/json; charset=utf-8",
                            data: "{'contractNo':'" + contractNo + "','group':'" + group + "'}",
                            async: false,
                            success: function (data) {

                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {

                                        $("#TextBox1").val(value1[0]);
                                        $("#TextBox3").val(value1[1]);
                                        $("#TextBox5").val(value1[2]);
                                        $("#TextBox8").val(value1[3]);
                                        $("#TextBox4").val(value1[3]);
                                        $("#TextBox6").val(value1[3]);
                                        $("#TextBox7").val(value1[4]);
                                        
                                        $("#TextBox10").val(value1[4]);
                                        $("#TextBox11").val(value1[5]);
                                        $("#TextBox12").val(value1[6]);
                                        $("#TextBox13").val(value1[7]);
                                        $("#TextBox9").val(value1[8]);

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
                            url: 'UpdateContractDetails.aspx/getdealStatusOnContractNo',
                            contentType: "application/json; charset=utf-8",
                            data: "{'contractNo':'" + contractNo + "','group':'" + group + "'}",
                            async: false,
                            success: function (data) {

                                $("#dealStatus").empty();

                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {


                                        $("#dealStatus").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");

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

            $.ajax({

                type: 'Post',
                url: 'UpdateContractDetails.aspx/getAdminRights',
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
                    url: 'UpdateContractDetails.aspx/searchProfile',
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
                    url: 'UpdateContractDetails.aspx/getlink',
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

        <script>
            $(document).ready(function () {

                $("#group").change(function () {

                    var group = $("#group option:selected").text();

                    if (group == "Update Deal Status") {

                        $("#contractNo").show();
                        $("#dealStatus1").show();
                        $("#dealDate").show();
                        $("#salesMarketingSource").hide();

                        $("#ReferralBy").hide();
                        $("#Comment").hide();
                        $("#update").show();

                        $("#contractType").hide();
                        $("#oldContractNo").hide();

                        $("#oldDeposit").hide();
                        $("#oldTotalTax").hide();
                        $("#oldAdminFee").hide();
                        $("#oldVolume").hide();
                        $("#SubVenue").hide();
                        $("#MarketingPro").hide();
                        $("#LeadOffice").hide();


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
                        $("#TextBox11").val("");
                        $("#TextBox12").val("");
                        $("#TextBox13").val("");
                        $("#dealStatus").val('');
                       


                    } else if (group == "Update Marketing Source SPI") {

                        $("#contractNo").show();
                        $("#dealStatus1").hide();
                        $("#dealDate").hide();
                        $("#salesMarketingSource").show();

                        $("#ReferralBy").hide();
                        $("#Comment").hide();
                        $("#update").show();

                        $("#oldDeposit").hide();
                        $("#oldTotalTax").hide();
                        $("#oldAdminFee").hide();
                        $("#oldVolume").hide();

                        $("#contractType").hide();
                        $("#oldContractNo").hide();

                        $("#SubVenue").show();
                        $("#MarketingPro").show();
                        $("#LeadOffice").show();

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
                        $("#TextBox11").val("");
                        $("#TextBox12").val("");
                        $("#TextBox13").val("");
                        $("#dealStatus").val('');
                    }
                    else if (group == "Update Referral Name") {

                        $("#contractNo").show();
                        $("#dealStatus1").hide();
                        $("#salesMarketingSource").hide();
                        $("#dealDate").hide();

                        $("#ReferralBy").show();
                        $("#Comment").show();
                        $("#update").show();

                        $("#oldDeposit").hide();
                        $("#oldTotalTax").hide();
                        $("#oldAdminFee").hide();
                        $("#oldVolume").hide();

                        $("#contractType").hide();
                        $("#oldContractNo").hide();

                        $("#SubVenue").hide();
                        $("#MarketingPro").hide();
                        $("#LeadOffice").hide();


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
                        $("#TextBox11").val("");
                        $("#TextBox12").val("");
                        $("#TextBox13").val("");
                        $("#dealStatus").val('');



                    } else if (group == "Update Upgrade Details") {
                        $("#contractNo").show();
                        $("#dealStatus1").hide();
                        $("#salesMarketingSource").hide();
                        $("#dealDate").hide();

                        $("#ReferralBy").hide();
                        $("#Comment").hide();
                        $("#update").show();

                        $("#contractType").show();
                        $("#oldContractNo").show();

                        $("#oldDeposit").show();
                        $("#oldTotalTax").show();
                        $("#oldAdminFee").show();
                        $("#oldVolume").show();

                        $("#SubVenue").hide();
                        $("#MarketingPro").hide();
                        $("#LeadOffice").hide();


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
                        $("#TextBox11").val("");
                        $("#TextBox12").val("");
                        $("#TextBox13").val("");
                        $("#dealStatus").val('');
                    }



                });


            });

        </script>

</body>
</html>
