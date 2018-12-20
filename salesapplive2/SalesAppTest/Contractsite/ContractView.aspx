<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ContractView.aspx.cs" Inherits="Contractsite_ContractView" %>


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
          $("#tabs").tabs();//{ disabled: [1, 2, 3, 4] }
          //$("#Btn1").on('click', function () {
          //    $("#tabs").tabs({ disabled: [2, 3, 4] });
          //    $("#tabs").tabs("option", "active", 1);
          //});
          //$("#Btn2").on('click', function () {
          //    $("#tabs").tabs({ disabled: [3, 4] });
          //    $("#tabs").tabs("option", "active", 2);
          //});

      });

 
      /*$("#btn").on('click', function () {
          $("#tabs").tabs("option", "active", 2);
      });*/

  </script>
    <script type="text/javascript">

             function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

             }


        $(document).ready(function () {

            $("#PrintPdfDropDownList").change(function () {
                //PrintPdfTextBox2
               // alert('hi');
                // $("#PrintPdfTextBox2").val() = $("#PrintPdfDropDownList").val();
                var v1 = document.getElementById("PrintPdfDropDownList");
                var pri = v1.options[v1.selectedIndex].text;

                var id2 = document.getElementById("PrintPdfTextBox2").value = pri;


                // var id2 = $("#PrintPdfTextBox2").val();
               // alert(id2);
                //alert(id);




            });

     









        $("#LanguageDropDown").change(function () {
            $("#PrintPdfDropDownList").empty();
            var id = $("#LanguageDropDown").val();

            var id2;

            if (id == 'ENG') {
                id2 = "";
            }
            else {
                id2 = id;
            }

            //var id2 = $("#FracIntDropDownListTF1").val();
            //alert(id);

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url is the path of our web method (Page name/function name)
                url: "ContractView.aspx/PrintPdfTypeDropDownList",
                data: "{'Lang': '" + id2 + "'}",
                dataType: "json",
                //called on jquery ajax call success
                success: function (data) {


                    // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                    jsdata = JSON.parse(data.d);
                    $("#PrintPdfDropDownList").append("<option disabled selected value></option>");
                    $.each(jsdata, function (key, value) {

                        $("#PrintPdfDropDownList").append($("<option></option>").val(value.PrintPdfType).html(value.PrintPdfTypeName));

                    });


                    // $("#TextMCFees").val(data.d);


                },
                //called on jquery ajax call failure
                error: function () {
                    alert('error');
                }
            });
            return false;


        });

        });

  </script>
 

        <style type="text/css">
            #tabs {
                padding: 10px;
                border: 1px solid #4c4c4c;
                /* max-width:1000px;*/
            }

           

            #panel, #chs2, #chs3, #panel2 {
                display: none;
            }

          
             

            

         

            .space {
                margin-right: 10px;
            }

            body {
            }
            /*#incrTextBox,*/
            #ffractional1, #tfractional, #pointsamtTextBox, #pointstaxTextBox, #testTextBox, #AffiliationamtTextBox,#findocfeeTextBox,#igstamtTextBox,#lastfingennoTextBox,#AffiliationvalueTextBox,#lblMCFees,#MCFeesTextBox,#testresTextBox,#testresnoTextBox, #lblfptsResidenceno1,#fptsResidenceno1TextBox,#lblfptsresidencetype1,#fptsresidencetype1TextBox,#lblfwresidenceno1,#fwresidenceno1TextBox,#lblfwresidencetype1,#fwresidencetype1TextBox,#oldcontracttypeTextBox,#lblinitaldepamt,#initaldepamtTextBox,#lblbaladepamt,#baldepamtTextBox,#firstdepamtTextBox,#lblfirstdepamt,#PrintPdfTextBox2

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

.Tab4cont{
    display: grid;
    grid-template-columns: 1fr 1fr;
    /* background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  width:30%;
  padding: 10px;
  grid-template-areas:
    'TLang TDoccu'
      'Tbutt .';
}

.Tab4cont>div {
 /*background-color:aqua;*/
  padding:5px 2.5px;
  
}

.TLang {
   grid-area: TLang;
}
.TDoccu {
   grid-area: TDoccu;
}
.Tbutt {
   grid-area: Tbutt;
}



        </style>

</head>
<body>
 
<div id="tabs">
     <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
  <form id="form1" runat="server"> 
        
  <ul>
    <%--<li><a href="#tabs-1">Profile</a></li>
    <li><a href="#tabs-2">Contract</a></li>
    <li><a href="#tabs-3">Finance Details</a></li>--%>
    <li><a href="#tabs-4">Print</a></li>
  </ul>
        <a href="#tabs-4">
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
      </a>
      <div id="tabs-4" style="background-color:#e9e9e9;">
          <div class="Tab4cont">
              <div class="TLang">
              <p>Language</p><asp:DropDownList ID="LanguageDropDown" runat="server" Width="100px">
                  <asp:ListItem Text="" Value=""></asp:ListItem>
                  <asp:ListItem Text="ENG" Value="ENG"></asp:ListItem>
                  <asp:ListItem Text="INA" Value="INA"></asp:ListItem>
                  <asp:ListItem Text="JAP" Value="JAP"></asp:ListItem>
                  </asp:DropDownList>
               </div>
              <div class="TDoccu">
                <p>File Name</p>
                              <asp:DropDownList ID="PrintPdfDropDownList" runat="server" Width="400px"></asp:DropDownList>  
                </div>
              <div class="Tbutt">
                  <asp:Button ID="Button5" runat="server" Text="Print" OnClick="Button5_Click" /><asp:TextBox ID="PrintPdfTextBox2" runat="server" Enabled="True" Width="110px"></asp:TextBox>
                  </div>
          </div>
      </div>
  
   
      

    </form>
   </div>
      
    
 
 

    

</body>

</html>
