<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="IndiaEdit Profile.aspx.cs" Inherits="_Default" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">

       <style>

           #check{
    display: none;
}
     
    #myBtn {
  display: block;
  position: fixed;
  bottom: 20px;
  right: 30px;
  z-index: 99;
  border: none;
  outline: none;
  background-color: #555;
  color: white;
  cursor: pointer;
  padding: 15px;
  border-radius: 10px;
}

#myBtn:hover {
  background-color: #555;
}  

#hidden1, #Label205,#ManagerDropDownList{
    display:none;
}
</style>
<script src="jquery-3.2.1.min.js"></script>

<meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Contracts</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <link rel="stylesheet" href="/resources/demos/style.css">

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#tabs").tabs({ disabled: [1, 2, 3, 4] });
          $("#Btn1").on('click', function () {
              $("#tabs").tabs({ disabled: [2, 3, 4] });
              $("#tabs").tabs("option", "active", 1);
             
            
          });
          $("#Btn2").on('click', function () {
              $("#tabs").tabs({ disabled: [4] });
              $("#tabs").tabs("option", "active", 2);
              $("#tabs").tabs("option", "active", 3);
              
          });

      });

      $(function () {
          $("#primarydobdatepicker,#secondarydobdatepicker,#sp1dobdatepicker,#sp2dobdatepicker,#sp3dobdatepicker,#sp4dobdatepicker,#arrivaldatedatepicker,#departuredatedatepicker,#baladepamtdateTextBox").datepicker({
              changeMonth: true,
              changeYear: true,
              yearRange: "-100:+0",
              dateFormat: 'dd-mm-yy'

          });

         

           $("#tourdatedatepicker").datepicker({
              changeMonth: true,
              changeYear: true,
              yearRange: "-100:+0",
              dateFormat: 'yy-mm-dd'

          });

 $("#dealdateTextBox").datepicker({
              changeMonth: true,
              changeYear: true,
              yearRange: "-100:+0",
              dateFormat: 'mm/dd/yy'

          });
      });
 
      
             function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

             }


      function shows2() {
          //alert("shows2");
          var checkbox2 = document.getElementById('chs2');

          if (checkbox2.checked) {

              document.getElementById("panel").style.display = "block";

          }
          else {
              document.getElementById("panel").style.display = "none";

          }

      }

      function shows3() {
          //alert("shows2");
          var checkbox2 = document.getElementById('chs3');

          if (checkbox2.checked) {

              document.getElementById("panel2").style.display = "block";

          }
          else {
              document.getElementById("panel2").style.display = "none";

          }

      }

      function shows3a() {
          //alert("shows2");
          var checkbox2 = document.getElementById('chs3a');

          if (checkbox2.checked) {

              document.getElementById("panel3").style.display = "block";

          }
          else {
              document.getElementById("panel3").style.display = "none";

          }

      }

      function shows4a() {
          //alert("shows2");
          var checkbox2 = document.getElementById('chs4a');

          if (checkbox2.checked) {

              document.getElementById("panel4").style.display = "block";

          }
          else {
              document.getElementById("panel4").style.display = "none";

          }

      }

 
 </script>







        <style type="text/css">
            #tabs {
                padding: 10px;
                border: 1px solid #4c4c4c;
                /* max-width:1000px;*/
            }

           

            #panel, #chs2, #chs3,#chs3a,#chs4a,#panel2,#panel3,#panel4 {
                display: none;
            }

            #TextBox22 {
                vertical-align: top;
            }

            #cleft {
                float: left;
            }

            #cright {
                float: right;
                display: none;
            }

            #financetitle {
                float: right;
                display: none;
                width: 600px;
            }

            #cdiv1, #cdiv2, #cdiv3, #cdiv4, #cdivtradeinweeks, #cdivtradeinpoints,#fractionalweeks,#fractionalpoints,#fractionaltofractionals  {
                display: none;
            }
            /*#pan,#adhar,*/
            #identitytable, #yes, #yes1, #yess1, #yes2, #yess2, #ptyes1,#pyess1, #remarks, #Points, #pnumb, #initaldepamtTextBox, #lblinitaldepamt, #lblbaladepamt, #baldepamtTextBox, #lblfirstdepamt, #firstdepamtTextBox, #lblbalamtpayable, #balamtpayableTextBox, #lblnoinstallment, #NoinstallmentTextBox, #lblinstallmentamt, #installmentamtTextBox, #lblfinancemethod, #financemethodDropDownList, #lblfinanceno, #FinancenoTextBox, #lblbalinitialdep, #balinitialdepamtTextBox {
                display: none;
            }
            #lblchk2,
            #ca2,
            #lblfinanceno,
            #FinancenoTextBox,
            #lblnoemi,
            #noemiTextBox,
            #lblemiamt,
            #emiamtTextBox,#lbladminamtfees,#adminamtfeesTextBox  #lblforeigncurrency ,
                    #foreigncurrencyTextBox {
                display: none;
            }

            .space {
                margin-right: 10px;
            }

            body {
            }
            /*#incrTextBox,*/
            #ffractional1, #tfractional, #pointsamtTextBox, #pointstaxTextBox, #testTextBox, #AffiliationamtTextBox,#findocfeeTextBox,#igstamtTextBox,#lastfingennoTextBox,#AffiliationvalueTextBox,#lblMCFees,#MCFeesTextBox,#testresTextBox,#testresnoTextBox, #lblfptsResidenceno1,#fptsResidenceno1TextBox,#lblfptsresidencetype1,#fptsresidencetype1TextBox,#lblfwresidenceno1,#fwresidenceno1TextBox,#lblfwresidencetype1,#fwresidencetype1TextBox,#oldcontracttypeTextBox,#lblinitaldepamt,#initaldepamtTextBox,#lblbaladepamt,#baldepamtTextBox,#firstdepamtTextBox,#lblfirstdepamt,#lblregcoll,#regcollectiontermTextBox,#lblregcollamt,#regcollamtTextBox,#lblbaladepamtdate,#baladepamtdateTextBox

              {
                /*float:left;*/
                display: none;
            }

            p {
                margin: 0px;
                padding: 0px;
            }

            .auto-style1 {
                width: 157px;
            }
            .auto-style2 {
                height: 30px;
            }
        </style>

</head>
<body>
 
<div id="tabs">
     <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
  <form id="form1" runat="server"> 
        
  <ul>
    <li><a href="#tabs-1">Profile</a></li>
  
  </ul>
        <a href="#tabs-5">
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
      </a>

  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
      
        
       <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PROFILE</h3>
        <hr />
        <br />
          
         <table style="width:100%; ">

             <tbody>
               <tr>
                   <td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="Profile ID" Font-Size="Medium"></asp:Label> </td>
                   <td class="auto-style2"><asp:TextBox ID="profileidTextBox" runat="server" style="width:170px; height:20px" Enabled="True" ReadOnly="True" Font-Size="Small"></asp:TextBox> </td>
                   <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Date Insert" Font-Size="Medium"></asp:Label></td>
                   <td class="auto-style2"><asp:TextBox ID="indateTextBox" runat="server" Enabled="False" style="width:170px; height:20px" ReadOnly="True" Font-Size="Small"></asp:TextBox></td>
                   <td class="auto-style2"><asp:Label ID="Label3" runat="server" Text="Created By" Font-Size="Medium"></asp:Label></td>
                   <td class="auto-style2"><asp:TextBox ID="createdbyTextBox" runat="server" Enabled="True" style="width:170px; height:20px" ReadOnly="True" Font-Size="Small"></asp:TextBox></td>
                    <td class="auto-style2"><asp:Label ID="Label7" runat="server" Font-Size="Medium" Text="Label">Marketing Program</asp:Label></td>
                   <td class="auto-style2"><asp:DropDownList ID="MarketingProgramDropDownList" style="width:170px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                   <%--   <td>   &nbsp;</td>
                   <td>   &nbsp;</td>--%>
               </tr>
           
               <tr>
                   <td>   <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Label">Venue Country</asp:Label></td>
                   <td>  <asp:DropDownList ID="VenueCountryDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server" ></asp:DropDownList></td>
                   <td>  <asp:Label ID="Label5" runat="server" Font-Size="Medium"  Text="Label">Venue</asp:Label></td>
                   <td>  <asp:DropDownList ID="VenueDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td>  <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Label">Group Venue</asp:Label></td>
                   <td>  <asp:DropDownList ID="GroupVenueDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                  
               </tr>
               <tr>
                   <td><asp:Label ID="Label8" runat="server" Font-Size="Medium" Text="Label">Agents</asp:Label></td>
                   <td><asp:DropDownList ID="AgentDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                   <td><asp:Label ID="Label9" runat="server" Text="TO Name" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="TONameDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                   <td><asp:Label ID="Label205" runat="server" Text="Manager" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="ManagerDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                   <td><asp:TextBox ID="officeTextBox" runat="server" Font-Size="Small" ReadOnly="True" Visible="False" Width="47px"></asp:TextBox></td>
                   <td>&nbsp;</td>
               </tr>
                 <tr>
                    
                     <td>
                         <input id="chs" type="checkbox" onclick="shows();" />
                         <asp:Label ID="Label10" runat="server" Text="Label">Are you a Member?</asp:Label></td>
                 </tr>

             </tbody>
         </table>
           <br />
           <table style="width: 57%;">

               <tbody id="hidden1">
                   <tr>
                       <td><asp:Label ID="Label11" runat="server" Font-Size="Medium"  Text="Label">Choose Source</asp:Label></td>
                       <td><asp:DropDownList ID="MemType1DropDownList" Font-Size="Small" Style="width:150px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label15" runat="server" Font-Size="Medium"  Text="Label">Member Number</asp:Label></td>
                       <td><asp:TextBox ID="Memno1TextBox" runat="server" Font-Size="Small" Style="width: 150px; height: 20px" Enabled="True"></asp:TextBox></td>
                       <td><asp:Label ID="Label114" runat="server" Font-Size="Medium" Text="Label">Type</asp:Label></td>
                       <td><asp:DropDownList ID="TypeDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label12" runat="server"  Font-Size="Medium"  Text="Label">Choose Member Type</asp:Label></td>
                       <td><asp:DropDownList ID="MemType2DropDownList" Font-Size="Small" Style="width: 150px; height: 25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label16" runat="server" Font-Size="Medium"  Text="Label">Member Number</asp:Label></td>
                       <td><asp:TextBox ID="Memno2TextBox" Font-Size="Small" Style="width:150px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                   </tr>
                  
               </tbody>

           </table>
           <br />
        <br />
        </div>
       
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PRIMARY PROFILE</h3>
        <hr />
        <br />
          <table style="width:100%;">
              <tr>

                  <td><asp:Label ID="Label86" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                  <td><asp:DropDownList ID="PrimaryTitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label13" runat="server"  Text="Label">First Name</asp:Label></td>
                   <td> <asp:TextBox ID="pfnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td> <asp:Label ID="Label14" runat="server" Text="Label">Last Name</asp:Label></td>
                   <td> <asp:TextBox ID="plnameTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                   <td>  <asp:Label ID="Label17" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                   <td> <asp:TextBox ID="primarydobdatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
              </tr>

              <tr>
                  <td></td>
                  <td></td>
                   <td> <asp:Label ID="Label18" runat="server" Text="Label">Nationality</asp:Label></td>
                   <td> <asp:DropDownList ID="PrimarynationalityDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server">
                         <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList></td>
                   <td> <asp:Label ID="Label19" runat="server" Text="Label">Country</asp:Label></td>
                   <td> <asp:DropDownList ID="primarycountryDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server">
                         <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList></td>
                  <td> <asp:Label ID="Label107" runat="server" Text="Label">Age</asp:Label></td>
                  <td>  <asp:TextBox ID="primaryAge" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
              </tr>

              <tr>
                  <td></td>
                  <td></td>
                   <td> <asp:Label ID="Label21" runat="server" Text="Label">Mobile #</asp:Label></td>
                   <td> <asp:DropDownList ID="primarymobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                         <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="pmobileTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td> <asp:Label ID="Label22" runat="server" Text="Label">Home #</asp:Label></td>
                   <td> <asp:DropDownList ID="primaryalternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                         <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="palternateTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label121" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                    <td><asp:DropDownList ID="pofficecodeDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px">
                          <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="pofficenoTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   
              </tr>

              <tr>
                  <td></td>
                   <td></td>
                   <td> <asp:Label ID="Label20" runat="server" Text="Label">Email</asp:Label></td>
                  <td>  <asp:TextBox ID="pemailTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
              </tr>
             
               <tr>
                  <td></td>
                   <td></td>
                  <td><asp:Label ID="Label80" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                  <td><select multiple="multiple"  style="width:175px; height:70px" id="primlg" name="primarylang" >
                             <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>


          </table>
          <br />
        <br />
         </div>
     
         
        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label81" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td> <asp:DropDownList ID="secondarytitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td> <asp:Label ID="Label23" runat="server" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sfnameTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label24" runat="server" Text="Label">Last Name</asp:Label></td>
                        <td> <asp:TextBox ID="slnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px"  Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label25" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                        <td> <asp:TextBox ID="secondarydobdatepicker" Font-Size="Small" style="width:170px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td>  <asp:Label ID="Label26" runat="server" Text="Label">Nationality</asp:Label></td>
                        <td>  <asp:DropDownList ID="secondarynationalityDropDownList" style="width:175px; height:25px"  Font-Size="Small"  runat="server"></asp:DropDownList></td>
                        <td> <asp:Label ID="Label27" runat="server" Text="Label">Country</asp:Label></td>
                        <td>  <asp:DropDownList ID="secondarycountryDropDownList" Font-Size="Small" style="width:175px; height:25px"  runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label108" runat="server" Text="Label">Age</asp:Label></td>
                        <td> <asp:TextBox ID="secondaryAge" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td></td>
                        <td></td>
                        <td> <asp:Label ID="Label29" runat="server" Text="Label">Mobile #</asp:Label></td>
                        <td> <asp:DropDownList ID="secondarymobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                            <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="smobileTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    
                        <td> <asp:Label ID="Label30" runat="server" Text="Label">Home #</asp:Label></td>
                        <td><asp:DropDownList ID="secondaryalternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                            <asp:ListItem Value=" "></asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:TextBox ID="salternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>


                        <td>
                            <asp:Label ID="Label122" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="sofficecodeDropDownList" runat="server" Font-Size="Small" Style="width: 70px; height: 25px">
                                <asp:ListItem Value=" "></asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:TextBox ID="sofficenoTextBox" runat="server" Font-Size="Small" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label28" runat="server" Text="Label">Email</asp:Label></td>
                        <td> <asp:TextBox ID="semailTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>

                     <tr>
                  <td></td>
                   <td></td>
                  <td><asp:Label ID="Label87" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" id="seclang" name="seclang">
                             <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>
                </tbody>
            </table>
         <br />
        <br />
        </div>
 
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>ADDRESS</h3>
        <hr />
        <br />

          <table style="width:100%;">
              <tbody>
                  <tr>

                      <td ><asp:Label ID="Label31" runat="server" Font-Size="Medium" Style="width:200px;" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address1TextBox" Font-Size="Small" runat="server" Enabled="True" Width="250px" Height="62px"></asp:TextBox></td>
                      <td ><asp:Label ID="Label32" Font-Size="Medium" runat="server"  Text="Label">Address Line2</asp:Label></td>
                      <td><asp:TextBox ID="address2TextBox" Font-Size="Small" runat="server"  Enabled="True" Width="250px" Height="62px"></asp:TextBox></td>
                       <td ><asp:Label ID="Label112" Font-Size="Medium" runat="server"  Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="AddCountryDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                  </tr>
                  <tr>

                      <%-- <td><asp:Label ID="Label33" runat="server" Text="Label">State</asp:Label></td>
                      <td><asp:TextBox ID="stateTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>--%>
                      <td><asp:Label ID="Label333" runat="server" Text="Label">State</asp:Label></td>
                      <td><asp:DropDownList ID="StateDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label34" runat="server" Text="Label">City</asp:Label></td>
                      <td><asp:TextBox ID="cityTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label39" runat="server" Text="Label">Pincode</asp:Label></td>
                      <td><asp:TextBox ID="pincodeTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small"  Enabled="True"></asp:TextBox></td>
                  </tr>
                 
              </tbody>
          </table>
       <br />
       <br />
    </div>


        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>OTHER DETAILS</h3>
        <hr />
        <br />
            <table style="width:100%;">
              <tbody>
                   <tr>
                      <td><asp:Label ID="Label40" runat="server" Text="Label">Employee Status</asp:Label></td>
                       <td><asp:DropDownList ID="employmentstatusDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label35" runat="server" Text="Label">Marital Status</asp:Label></td>
                       <td><asp:DropDownList ID="maritalstatusDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label41" runat="server" Text="Label">No of Year living together as a couple</asp:Label></td>
                       <td><asp:TextBox ID="livingyrsTextBox" Font-Size="Small" style="width:150px; height:20px"  runat="server"></asp:TextBox></td>
                  </tr>

                   <tr>
                      <td><asp:Label ID="Label90" runat="server" Font-Size="Medium" Text="Label">Professional/Designation</asp:Label></td>
                      <td></td>
                      <td><asp:Label ID="Label103" runat="server" Font-Size="Medium" Text="Label">Male</asp:Label></td>
                      <td><asp:TextBox ID="pdesginationTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label104" runat="server" Font-Size="Medium" Text="Label">Female</asp:Label></td>
                      <td><asp:TextBox ID="sdesignationTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>

                   <tr>
                      <td><asp:Label ID="Label334" runat="server" Font-Size="Medium" Text="Company Name" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="companynameTextBox" Font-Size="Small" runat="server" Height="30px" TextMode="MultiLine" Width="251px"></asp:TextBox></td>
                      
                  </tr>
                  <tr>
                    <td><asp:Label ID="Label105" runat="server" Font-Size="Medium" Text="Label">Photo Identity</asp:Label></td>
                    <td><select multiple="multiple" style="width:155px; height:70px" id="phid" name="pidentity">
                        <option value="Membership Card">Membership Card(if member with any club)</option>
                          <option value="Driving License">Driving License</option>
                          <option value="Pan Card">PAN Card</option>                         
                          <option value="Passport">Passport</option>
                         <option value="Adhar Card">Adhar Card</option>
                          <option value="Others">Others</option>

                        </select></td>
                    <td><asp:Label ID="Label106" runat="server" Font-Size="Medium" Text="Label">Kind Of Card</asp:Label></td>
                     <td><select multiple="multiple" style="width:155px; height:70px"id="card" name="card">
                        <option value="Titanium">Titanium</option>
                        <option value="Platinum">Platinum</option>
                        <option value="Gold">Gold</option>
                        <option value="Silver">Silver</option>
                        <option value="Visa">Visa</option>
                        <option value="Mastercard">Mastercard</option>
                        <option value="Debit Card">Debit Card</option>
                        <option value="Others">Others</option>
                        </select></td>

                    </tr>
                     </tbody>
                     </table>
                     <br />
                 <br />
              </div>
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs2" type="checkbox" onclick="shows2();"/>
       
 <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
           <tbody>

               <tr>
                   <td><asp:Label ID="Label200" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                   <td><asp:DropDownList ID="sp1titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                    <td><asp:Label ID="Label36" runat="server"  Text="Label">First Name</asp:Label></td>
                    <td><asp:TextBox ID="sp1fnameTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label37" runat="server" Text="Label">Last Name</asp:Label></td>
                    <td><asp:TextBox ID="sp1lnameTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label38" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                    <td><asp:TextBox ID="sp1dobdatepicker" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    
               </tr>

               <tr>
                   <td></td>
                   <td></td>
                   <td><asp:Label ID="Label42" runat="server" Text="Label">Nationality</asp:Label></td>
                   <td><asp:DropDownList ID="sp1nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label43" runat="server" Text="Label">Country</asp:Label></td>
                   <td><asp:DropDownList ID="sp1countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label109" runat="server" Text="Label">Age</asp:Label></td>
                   <td><asp:TextBox ID="subProfile1Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                  
               </tr>
               <tr>
                   <td></td>
                   <td></td>
                    <td><asp:Label ID="Label45" runat="server" Text="Label">Mobile Number</asp:Label></td>
                    <td> <asp:DropDownList ID="sp1mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                         <asp:ListItem Value=" "></asp:ListItem>
                         </asp:DropDownList>&nbsp;<asp:TextBox ID="sp1mobileTextBox" style="width:95px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                    <td> <asp:Label ID="Label46" runat="server" Text="Label">Alternate Number</asp:Label></td>
                    <td><asp:DropDownList ID="sp1alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                         <asp:ListItem Value=" "></asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="sp1alternateTextBox" runat="server" style="width:95px;  height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                     <td><asp:Label ID="Label44" runat="server" Text="Label">Email</asp:Label></td>
                   <td><asp:TextBox ID="sp1pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
               </tr>
           </tbody>
       </table>
          <br />
          <br /> 
    </div>
       <br />
     <br />
   </div>
     
     <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs3" type="checkbox" onclick="shows3();"/>
 <label for="chs3">SUB PROFILE 2</label>      
        <div id="panel2" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label78" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp2titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label47" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp2fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label48" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp2lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label49" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp2dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                   
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label50" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp2nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label51" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp2countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label110" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile2Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   
                    </tr>

                    <tr> 
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label53" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp2mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                              <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp2mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label54" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp2alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                              <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp2alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label52" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp2pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
                
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>

             <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs3a" type="checkbox" onclick="shows3a();"/>
 <label for="chs3a">SUB PROFILE 3</label>      
        <div id="panel3" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label129" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp3titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label130" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp3fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label131" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp3lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label132" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp3dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                  
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label133" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp3nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label134" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp3countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label135" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile3Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                    </tr>
                          
                    <tr> 
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label136" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp3mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                              <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp3mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label137" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp3alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                              <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp3alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label138" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp3pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    
                </tbody>
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>


        
             <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs4a" type="checkbox" onclick="shows4a();"/>
 <label for="chs4a">SUB PROFILE 4</label>      
        <div id="panel4" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label139" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp4titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label140" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp4fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label141" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp4lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label142" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp4dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label143" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp4nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label144" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp4countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label145" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile4Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                          

                    </tr>     
                    <tr>     
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label155" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp4mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                              <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp4mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label156" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp4alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server">
                              <asp:ListItem Value=" "></asp:ListItem>
                             </asp:DropDownList>&nbsp;<asp:TextBox ID="sp4alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label157" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp4pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>



 
        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>STAY DETAILS</h3>
        <hr />
        <br />
           
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td> <asp:Label ID="Label55" runat="server" Text="Label">Resort Name</asp:Label></td>
                         <td>   <asp:TextBox ID="resortTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label56" runat="server" Text="Label">Resort Room No</asp:Label></td>
                         <td> <asp:TextBox ID="roomnoTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label57" runat="server" Text="Label">Arrival</asp:Label></td>
                         <td> <asp:TextBox ID="arrivaldatedatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label58" runat="server" Text="Label">Departure</asp:Label></td>
                        <td><asp:TextBox ID="departuredatedatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label59" runat="server" Text="Label">Choose Gift Option</asp:Label></td>
                        <td>
                            <select multiple="multiple" style="width: 165px; height: 70px" id="giftoptionDropDownList" name="giftoptionDropDownList">
                                <%Response.Write(loadGifts()); %>
                            </select>

                        </td>
                        <td> <asp:Label ID="Label60" runat="server" Text="Label">Voucher No.</asp:Label></td>
                        <td><asp:TextBox ID="TextBox13" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td> <asp:Label ID="Label61" runat="server" Text="Label">Comment if Any</asp:Label></td>
                        <td> <asp:TextBox ID="TextBox22" runat="server" style="width:170px; height:30px" Font-Size="Small" Enabled="True" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                        <td> <asp:Label ID="Label62" runat="server" Text="Label">Guest Status</asp:Label></td>
                        <td><asp:DropDownList ID="guestatusDropDownList" style="width:175px; height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                    </tr>
                  
                    <tr>
                        <td><asp:Label ID="Label202" runat="server" Text="Tour Date"></asp:Label></td>
                         <td><asp:TextBox ID="tourdatedatepicker" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label63" runat="server" Text="Label">Sales Represntative</asp:Label></td>
                         <td><asp:DropDownList ID="toursalesrepDropDownList"  Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label64" runat="server" Text="Label">Sales Deck Check-In Time</asp:Label></td>
                         <td><asp:TextBox ID="timeinTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label65" runat="server" Text="Label">Sales Deck Check-Out Time</asp:Label></td>
                         <td><asp:TextBox ID="timeoutTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label66" runat="server" Text="Label">Taxi in Price</asp:Label></td>
                         <td><asp:TextBox ID="inpriceTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label67" runat="server" Text="Label">Taxi in Reference</asp:Label></td>
                         <td><asp:TextBox ID="inrefTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label68" runat="server" Text="Label">Taxi out Price</asp:Label></td>
                         <td><asp:TextBox ID="outpriceTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label69" runat="server" Text="Label">Taxi out Reference</asp:Label></td>
                         <td> <asp:TextBox ID="outrefTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>

            <table style="width: 56.5%;">

                <tr>
                    <td>
                        <asp:Label ID="Label33" runat="server" Font-Size="Medium" Text="Comment1" BorderStyle="None"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="commentsTextBox" runat="server" Style="width: 300px; height: 120px" TextMode="MultiLine"></asp:TextBox></td>

                </tr>

<tr>

 <td>
                        <asp:Label ID="Label339" runat="server" Font-Size="Medium" Text="Comment2" BorderStyle="None"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="comment2" runat="server" Style="width: 300px; height: 120px" TextMode="MultiLine"></asp:TextBox></td>
</tr>

            </table>
            <br />
            <br />
            <table style="width: 59%;">
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Registration Card Terms" /></td>


                </tr>
            </table>
        <br />
        <br />
        </div>
        <%-- <input type="button" />&nbsp;&nbsp;
          <asp:Button ID="btn" runat="server" Text="Button" OnClientClick="return false;" Visible="False"/>
    --%>
       
</div>
      <br />
        <center>
              <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Update Profile" Width="200px" />
        </center>
    
  </div>

        </form>
   </div>
    
      
    
 



 

    <script>

        $(document).ready(function () {
            var marketprogram = $("#MarketingProgramDropDownList :selected").text();
           /* var ctype = $("#contracttypeDropDownList :selected").text();
            alert(ctype);
            if (ctype == "Fractional" || ctype == "Trade-In-Fractionals")
            {
                if (marketprogram == "OWNER") {
                    $('#check').css('display', 'none');
                    //alert("hiee");
                } else {
                    $('#check').css('display', 'none');
                    //alert("else");
                }
            }
            else

            {
                if (marketprogram == "OWNER") {
                    $('#check').css('display', 'block');
                    //alert("hiee");
                } else {
                    $('#check').css('display', 'none');
                    //alert("else");
                }

            }*/
           
        });

    </script>
   
 
    <script>

        $(document).ready(function () {
           // $("#hidden1").hide();
            $("#chs").click(function () {
                if ($("#chs").is(':checked')) {

                    $("#hidden1").show();
                } else {
                    $("#hidden1").hide();
                }
            });
        });


    </script>

   
    


           <script>
        $(document).ready(function () {
            $("#primarydobdatepicker").change(function () {
                
                var date = $("#primarydobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#primaryAge').val(age);
            });
        });

    </script>

    <script>
        $(document).ready(function () {
            $("#secondarydobdatepicker").change(function () {
                var date = $("#secondarydobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#secondaryAge').val(age);
            });



        });
    </script>

     <script>
        $(document).ready(function () {
            $("#sp1dobdatepicker").change(function () {
                var date = $("#sp1dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile1Age').val(age);
            });



        });
    </script>

    <script>
        $(document).ready(function () {
            $("#sp2dobdatepicker").change(function () {
                var date = $("#sp2dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile2Age').val(age);
            });



        });
    </script>
    
    <script>
        $(document).ready(function () {
            $("#sp3dobdatepicker").change(function () {
                var date = $("#sp3dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile3Age').val(age);
            });



        });
    </script>
    
    <script>
        $(document).ready(function () {
            $("#sp4dobdatepicker").change(function () {
                var date = $("#sp4dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile4Age').val(age);
            });



        });
    </script>


    <script>
        $(document).ready(function () {
            $("#VenueCountryDropDownList").change(function () {
                var v = document.getElementById("VenueCountryDropDownList");
                var countryName = v.options[v.selectedIndex].text;
               // alert(countryName)
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/getVenueOnCountry',
                    data: "{'countryName':'" + countryName + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#VenueDropDownList").empty();
                        $("#VenueDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#VenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;

            });



            $("#VenueDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                // alert(countryName)
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/getVenueGroupOnVenue',
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#GroupVenueDropDownList").empty();
                        $("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")

                        $("#MarketingProgramDropDownList").empty();
                        $("#MarketingProgramDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#GroupVenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadManagersOnVenue',
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#ManagerDropDownList").empty();
                        $("#ManagerDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#ManagerDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;



            });



            $("#GroupVenueDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;


                var profileID = $("#profileidTextBox").val();

                if (venueGroup == "Coldline" || venueGroup == "COLDLINE") {
                    //alert("hello");

                    $("#Label205").show();
                    $("#ManagerDropDownList").show();
                }
                else {
                    $("#Label205").hide();
                    $("#ManagerDropDownList").hide();
                }
           

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/getMarketingProgram',
                    data: "{'venue':'" + venue + "','venueGroup':'" + venueGroup + "','profileID':'" + profileID + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#MarketingProgramDropDownList").empty();
                        $("#MarketingProgramDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#MarketingProgramDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAgentsOnVenuegrp',
                    data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
                    async: false,
                    success: function (data) {
                       // alert(data.d);
                        $("#AgentDropDownList").empty();
                        $("#AgentDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#AgentDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong LoadAgentsOnVenuegrp");
                    }



                });
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadTOOnVenueNVGrp',
                    data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
                    async: false,
                    success: function (data) {
                    //    alert(data.d);
                        $("#TONameDropDownList").empty();
                        $("#TONameDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#TONameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong LoadTOOnVenueNVGrp");
                    }



                });
                return false;

            });

        });
    </script>
 
  
     <script>
        $(document).ready(function () {
          //  alert("hiee");
            var prid = $("#profileidTextBox").val();
           // alert(prid);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/primaryl',
                data: "{'prid':'"+prid+"'}",
                async: false,
                success: function (data) {
                     //alert(data.d);
                  
                    subJson = JSON.parse(data.d);

                   
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                          

                            var valArr = [value1[0]],
                                
                            i = 0, size = valArr.length,
                            $options = $('#primlg option');
                           // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong p");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/Secondarylang',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#seclang option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong s");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/PhotoIdentity',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#phid option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong pi");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/CardType',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#card option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrongct");
                }



            });
            return false;



        });



    </script>


    <script>
        $(document).ready(function () {
            // hide show manager based on venue group
            
            
            var value = $("#GroupVenueDropDownList option:selected").text();
            // alert(value);
            if (value == "Coldline") {

               // $("#Label205").show();
               //$("#ManagerDropDownList").show();

                $("#Label205").css("display", "block");
                $("#ManagerDropDownList").css("display", "block");
            }
            else {
             //   $("#Label205").hide();
              //  $("#ManagerDropDownList").hide();
                $("#Label205").css("display", "none");
                $("#ManagerDropDownList").css("display", "none");
            }
            //end//
           
            $("#Label11").hide();
            $("#MemType1DropDownList").hide();
            $("#Label15").hide();
            $("#Memno1TextBox").hide();
            $("#Label114").hide();
            $("#TypeDropDownList").hide();
            
            $("#Label12").hide();
            $("#MemType2DropDownList").hide();

            $("#Label16").hide();
            $("#Memno2TextBox").hide();



            //  MarketingPrgmDropDownList
            var marketingValue = $("#MarketingProgramDropDownList option:selected").text();
           // alert(marketingValue);
            //alert(marketingValue);
            if (marketingValue == "OWNER" || marketingValue == "Owner" || marketingValue == "owner") {

                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").show();
                $("#Memno1TextBox").show();
                $("#Label114").hide();
                $("#TypeDropDownList").hide();
              
                
                
            } else {
                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").hide();
                $("#Memno1TextBox").hide();
                $("#Label114").show();
                $("#TypeDropDownList").show();

            }

        });

    </script>
   
    

    <script>
        $(document).ready(function () {

            // loading country code primary for primary as per country//
            $("#primarycountryDropDownList").change(function () {
                var country = $("#primarycountryDropDownList option:selected").text();
               
                 //alert(country);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#primarymobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading country code primary for primary as per country");
                    }





                });

                // end//


                // loding all country code alternative for primary as per country//


                var country = $("#primarycountryDropDownList option:selected").text();

                //alert(country);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#primaryalternateDropDownList").empty();
                        $("#primaryalternateDropDownList").append("<option value=''>select an option</option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for primary as per country");
                    }



                });
                //end//


                // loding all country code office for primary as per country//


                var country = $("#primarycountryDropDownList option:selected").text();
                //alert(country);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#pofficecodeDropDownList").empty();
                        $("#pofficecodeDropDownList").append("<option value=''>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#pofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code office for primary as per country");
                    }



                });
              

          
                return false;

                //end//


            });

        });
    </script>

 <script>
        $(document).ready(function () {

            // loading country code primary for secondary as per country//
            $("#secondarycountryDropDownList").change(function () {
                var country = $("#secondarycountryDropDownList option:selected").text();
               // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#secondarymobileDropDownList").empty();
                        $("#secondarymobileDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading country code primary for secondary as per country");
                    }




                });

                // end//


                // loding all country code alternative for secondary as per country//


                var country = $("#secondarycountryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#secondaryalternateDropDownList").empty();
                        $("#secondaryalternateDropDownList").append("<option value=''>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for secondary as per country");
                    }



                });
              

                //end//


                // loding all country code office for secondary as per country//


                var country = $("#secondarycountryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sofficecodeDropDownList").empty();
                        $("#sofficecodeDropDownList").append("<option value=''>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code office for secondary as per country");
                    }



                });
                return false;

                //end//

            });



        });


    </script>

    <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 1 as per country//
            $("#sp1countryDropDownList").change(function () {
                var country = $("#sp1countryDropDownList option:selected").text();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp1mobileDropDownList").empty();
                        $("#sp1mobileDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 1 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 1 as per country//

                
                
                var country = $("#sp1countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp1alternateDropDownList").empty();
                        $("#sp1alternateDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 1 as per country");
                    }



                });
                return false;

                //end//


            });



        });


    </script>

     <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 2 as per country//
            $("#sp2countryDropDownList").change(function () {
                var country = $("#sp2countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp2mobileDropDownList").empty();
                        $("#sp2mobileDropDownList").append("<option  value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 1 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 2 as per country//

                
                
                var country = $("#sp2countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp2alternateDropDownList").empty();
                        $("#sp2alternateDropDownList").append("<option  value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 2 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>

    <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 3 as per country//
            $("#sp3countryDropDownList").change(function () {
                var country = $("#sp3countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp3mobileDropDownList").empty();
                        $("#sp3mobileDropDownList").append("<option  value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 3 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 3 as per country//

                
                
                var country = $("#sp3countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp3alternateDropDownList").empty();
                        $("#sp3alternateDropDownList").append("<option  value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 3 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>

    <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 4 as per country//
            $("#sp4countryDropDownList").change(function () {
                var country = $("#sp4countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp4mobileDropDownList").empty();
                        $("#sp4mobileDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 4 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 4 as per country//

                
                
                var country = $("#sp4countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp4alternateDropDownList").empty();
                        $("#sp4alternateDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 4 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>



    <script>

        $(document).ready(function () {
            // loading states on country////
            $("#AddCountryDropDownList").change(function () {
                var country = $("#AddCountryDropDownList option:selected").text();
                //   alert(country);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadStates',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#StateDropDownList").empty();
                        $("#StateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#StateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong load states");
                    }

                });
                return false;

            });
            //end///
        });
    </script>
     <script>
    $(document).ready(function(){
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaEdit Profile.aspx/loadRegTerms',
            data: "{}",
            async: false,
            success: function (data) {

                //alert("hello"+data.d);

                subJson = JSON.parse(data.d);


                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {
                        if (value1[0] == "Y") {
                            $('#CheckBox1').prop('checked', true);
                        } else {
                            $('#CheckBox1').prop('checked', false);
                        }
                      
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });


   });
   </script>

    <script>
        $(document).ready(function () {
            $("#MarketingProgramDropDownList").change(function () {
                var marketingValue1 = $("#MarketingProgramDropDownList option:selected").val();
    
              // alert(marketingValue1);
                if (marketingValue1 == "OWNER" || marketingValue1 == "Owner" || marketingValue1 == "owner") {
                   // alert("hiee");
                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").show();
                    $("#Memno1TextBox").show();
                    $("#Label114").hide();
                    $("#TypeDropDownList").hide();



                } else {
                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").hide();
                    $("#Memno1TextBox").hide();
                    $("#Label114").show();
                    $("#TypeDropDownList").show();

                }



            });



        });

    </script>
     <script>
        $(document).ready(function () {
            $("#pmobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#pmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');

                    $("#pmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;

                }

            });

            $("#palternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#palternateTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');
                    $("#palternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#pofficenoTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#pofficenoTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');
                    $("#pofficenoTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });

            $("#smobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#smobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#smobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#salternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#salternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#salternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });

            $("#sofficenoTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#sofficenoTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');
                    $("#sofficenoTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });







            $("#sp1mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp1mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp1mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });









            $("#sp1alternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;// /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#sp1alternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp1alternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });



            $("#sp2mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp2mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp2mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp2alternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;// /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp2alternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp2alternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp3mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp3mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp3mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp3altmobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;// /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp3altmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp3altmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp4mobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 100) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp4mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp4mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp4altmobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;// /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {

                    if (mobNum.length <= 100) {
                        //  alert("valid");


                    } else {
                        alert('Enter valid number');


                        return false;
                    }
                    $("#sp4altmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');

                    $("#sp4altmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });

        });


    </script>

    <script>

        $(document).ready(function () {
            // $("#hidden1").hide();
            $('#lblregcoll').css('display', 'none');
            $('#regcollectiontermTextBox').css('display', 'none');
            $('#lblregcollamt').css('display', 'none');
            $('#regcollamtTextBox').css('display', 'none');
            $("#ca3").click(function () {
                if ($("#ca3").is(':checked')) {

                    $('#lblregcoll').css('display', 'block');
                    $('#regcollectiontermTextBox').css('display', 'block');
                    $('#lblregcollamt').css('display', 'block');
                    $('#regcollamtTextBox').css('display', 'block');
                } else {
                    $('#lblregcoll').css('display', 'none');
                    $('#regcollectiontermTextBox').css('display', 'none');
                    $('#lblregcollamt').css('display', 'none');
                    $('#regcollamtTextBox').css('display', 'none');
                }
            });
        });


    </script>

      <script>

        $(document).ready(function () {
          
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/loadgiftdata',
                data: "{}",
                async: false,
                success: function (data) {
                   // alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                           
                            i = 0, size = valArr.length,
                            $options = $('#giftoptionDropDownList option');
                         //   alert(size);
                         

                            for (i; i < size; i++) {
                                //alert(valArr[i]);

                                $("#giftoptionDropDownList option[value='" + valArr[i] + "']").attr('selected', true);
                               // $("#giftoptionDropDownList option:contains('"+valArr[i]+"')").attr("selected", true);

                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong");
                }



            });
        });
    </script>



      <script>
        $(document).ready(function () {

            $("#inrefTextBox").blur(function () {
              
                var value = $("#inrefTextBox").val();
                alert

                $("#outrefTextBox").val(value);

            });

            
            

        });


    </script>

</body>

</html>
