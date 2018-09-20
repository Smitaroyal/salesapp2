<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit Profile.aspx.cs" EnableEventValidation="false" Inherits="WebSite5_production_CreateProfile" %>

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

        #con1,#con2,#con3,#con4,#con5,#con6,#con7,#con8,#con9{

            pointer-events: none;
        }

        #trans{
    opacity:0;
    filter: alpha(opacity = 0);
      width:100%;
      /*height:350%;*/
      background:transparent;
      position:absolute;
       z-index:2;
       display:block;
       border:3px solid red;
}

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
        .item9b, .item9a1, .item9a2, .item9a3, .item9a4, .itemFly, .item36, .item46, .item66, .item76, .item9s36,#Button1,
        #sub1, #subPro1, .item9s4s6, #sub2, #subPro2, #sub3, #subPro3, #sub4, #subPro4,#stay,
        .item88s2, .item88p2, .item88q2, .item88s3, .item88p3, .item88q3, .item88s4, .item88p4, .item88q4, .item88s5,
        .item88p5, .item88q5, .item88s6, .item88p6, .item88q6, .item88s7, .item88p7, .item88q7,.item8822qq,.item88d7,.item88d6,.item88d5,.item88d4,.item88d3,
        .item88d2
         {
            display: none;
        }

        .title {
            font-size: 13px;
            font-style: oblique;
        }

        #img {
            position:fixed;
            background: #04070B;
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }


         #update,#head,#directory,#insert,#sourceCodeText,#hidden,#Prihidden,#Sechidden,#SP1hidden,#SP2hidden,#SP3hidden,#SP4hidden{
             display:none;
         }

           #success-alert,#danger-alert,#danger-alert1,#menu_toggle,#profileDetails{
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

        #ProfileIDTextBox, #TextVPID, #createddateTextBox, #CreatedByTextBox, #ReceptionistDropDownList, #VenueCountryDropDownList, #VenueDropDownList, #GroupVenueDropDownList,
        #VenueDropDownList2, #MarketingPrgmDropDownList, #AgentsDropDownList, #AgentCodeDropDownList, #sourcecodetext, #OfficeSourceTextBox, #FAgentDropDownList,
        #PreArrivalDropDownList, #VerificationDropDownList, #DropDownListFly, #MemType1DropDownList, #Memno1TextBox, #MemType2DropDownList, #Memno2TextBox,
        #primarytitleDropDownList, #pfnameTextBox, #plnameTextBox, #pdobdatepicker, #TextPrimaryAge, #primarymobileDropDownList, #pmobileTextBox, #primaryalternateDropDownList,
        #palternateTextBox, #primarynationalityDropDownList, #employmentstatusDropDownList, #pemailTextBox, #pemailTextBox2, #TextBoxPrimIDType, #TextBoxPrimID, #TextBoxSecoID,
        #TextBoxSecoIDType, #SecondemploymentstatusDropDownList, #salternateTextBox, #secondaryalternateDropDownList, #smobileTextBox, #secondarymobileDropDownList, #TextSecondAge,
        #SecondaryCountryDropDownList, #semailTextBox2, #semailTextBox, #secondarynationalityDropDownList, #sdobdatepicker, #slnameTextBox, #sfnameTextBox, #secondarytitleDropDownList,
        #address1TextBox, #address2TextBox, #pincodeTextBox, #AddCountryDropDownList, #stateTextBox, #cityTextBox, #livingyrsTextBox, #MaritalStatusDropDownList, #TextBoxSP1ID,
        #TextBoxSP1IDType, #sp1alternateTextBox, #subprofile1alternateDropDownList, #sp1mobileTextBox, #subprofile1mobileDropDownList, #TextSP1Age, #SubProfile1CountryDropDownList,
        #sp1emailTextBox2, #sp1emailTextBox, #subprofile1nationalityDropDownList, #sp1dobdatepicker, #sp1lnameTextBox, #sp1fnameTextBox, #subprofile1titleDropDownList, #TextBoxSP2ID,
        #TextBoxSP2IDType, #sp2alternateTextBox, #subprofile2alternateDropDownList, #sp2mobileTextBox, #subprofile2mobileDropDownList, #TextSP2Age, #SubProfile2CountryDropDownList,
        #sp2emailTextBox2, #sp2emailTextBox, #subprofile2nationalityDropDownList, #sp2dobdatepicker, #sp2lnameTextBox, #sp2fnameTextBox, #subprofile2titleDropDownList, #TextBoxSP3ID,
        #TextBoxSP3IDType, #SubP3AMobileTextBox, #SubP3CCDropDownList2, #SubP3MobileTextBox, #SubP3CCDropDownList, #TextSP3Age, #SubP3CountryDropDownList,
        #SubP3EmailTextBox2, #SubP3EmailTextBox, #SubP3NationalityDropDownList, #SubP3DOB, #SubP3LnameTextBox, #SubP3FnameTextBox, #SubP3TitleDropDownList,
        #TextBoxSP4ID, #TextBoxSP4IDType, #SubP4AMobileTextBox, #SubP4CCDropDownList2, #SubP4MobileTextBox, #SubP4CCDropDownList, #TextSP4Age,#TextBoxChargeBack,
        #SubP4CountryDropDownList, #SubP4EmailTextBox2, #SubP4EmailTextBox, #SubP4NationalityDropDownList, #SubP4DOB, #SubP4LnameTextBox,#tourdatedatepicker,
        #deckcheckouttimeTextBox, #deckcheckintimeTextBox, #checkoutdatedatepicker, #checkindatedatepicker, #roomnoTextBox, #hotelTextBox ,#TextBoxGPrice2, 
        #vouchernoTextBox2, #giftoptionDropDownList2, #TextBoxGPrice3, #vouchernoTextBox3, #giftoptionDropDownList3, #TextBoxGPrice4, #vouchernoTextBox4,
        #giftoptionDropDownList4, #TextBoxGPrice5, #vouchernoTextBox5, #giftoptionDropDownList5, #TextBoxGPrice6, #vouchernoTextBox6, #giftoptionDropDownList6,
        #TextBoxGPrice7, #vouchernoTextBox7, #giftoptionDropDownList7,#QStatusDropDownList1,#gueststatusDropDownList,#commentTextBox,#TaxiRefOutTextBox,#TaxiPriceOutTextBox,
        #SubP4FnameTextBox, #SubP4TitleDropDownList,#giftoptionDropDownList,#vouchernoTextBox,#TextBoxGPrice1,#salesrepDropDownList,#TaxiRefInTextBox,#taxipriceInTextBox {
          height: 28px;
            font-size: 12px;
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

           <script type="text/javascript">

           /* function shows() {
               var checkbox1 = document.getElementById('chs');
              if (checkbox1.checked) {
                document.getElementById("hidden").style.display = "block";
                }
                else {
                    document.getElementById("hidden").style.display = "none";
                     }
 
            }*/


           function shows(check, fiel) {
               var checkbox1 = document.getElementById(check);
               if (checkbox1.checked) {
                   document.getElementById(fiel).style.display = "block";
               }
               else {
                   document.getElementById(fiel).style.display = "none";
               }

           }

           function uncheck() {
               //var checkbox1 = document.getElementById();
               //alert('1');

               if (document.getElementById('TextBoxPrimIDType').value != "") {

                   //alert('12');
                   document.getElementById('Primchs').checked = true;
                   document.getElementById('Prihidden').style.display = "block";

               }

               if (document.getElementById('TextBoxSecoIDType').value != '') {
                   document.getElementById('Secochs').checked = true;
                   document.getElementById('Sechidden').style.display = "block";

               }

               if (document.getElementById('TextBoxSP1IDType').value != '') {
                   document.getElementById('SP1chs').checked = true;
                   document.getElementById('SP1hidden').style.display = "block";

               }

               if (document.getElementById('TextBoxSP2IDType').value != '') {
                   document.getElementById('SP2chs').checked = true;
                   document.getElementById('SP2hidden').style.display = "block";

               }

               if (document.getElementById('TextBoxSP3IDType').value != '') {
                   document.getElementById('SP3chs').checked = true;
                   document.getElementById('SP3hidden').style.display = "block";

               }

               if (document.getElementById('TextBoxSP2IDType').value != '') {
                   document.getElementById('SP3chs').checked = true;
                   document.getElementById('SP3hidden').style.display = "block";

               }



               //if (checkbox1.checked) {

               //}
               //else {
               //document.getElementById(fiel).style.display = "none";
               // }

           }



           function topFunction() {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location = '<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

           }


           function pele(kk) {
               alert(kk);
               // window.location.href("Dashboard.aspx");
               topFunction();
               return false;
           }

           function pp(giftprice) {
               //alert('lpo');
               var x = document.getElementById(giftprice).value;
               document.getElementById(giftprice).value = addCommas(x);


           }


           function addCommas(x) {
               var parts = x.toString().split(".");
               parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
               return parts.join(".");
           }


           function hi3() {
               document.getElementById('<%= pfnameTextBox.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= VenueCountryDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= VenueDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= GroupVenueDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= MarketingPrgmDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= AgentsDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= AgentCodeDropDownList.ClientID %>').style.backgroundColor = '#ffffff';

          document.getElementById('<%= plnameTextBox.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= primarynationalityDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= PrimaryCountryDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          //document.getElementById('<%= pemailTextBox.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= gueststatusDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= employmentstatusDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= MaritalStatusDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= deckcheckintimeTextBox.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= salesrepDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= sourcecodetext.ClientID %>').style.backgroundColor = '#ffffff';



          var rem = true;
          var v1 = document.getElementById("VenueCountryDropDownList");
          var id = v1.options[v1.selectedIndex].text;
          var v2 = document.getElementById("VenueDropDownList");
          var id2 = v2.options[v2.selectedIndex].text;
          var v3 = document.getElementById("GroupVenueDropDownList");
          var id3 = v3.options[v3.selectedIndex].text;
          var v4 = document.getElementById("MarketingPrgmDropDownList");
          var id4 = v4.options[v4.selectedIndex].text;
          var v5 = document.getElementById("AgentsDropDownList");
          var id5 = v5.options[v5.selectedIndex].text;
          var v6 = document.getElementById("AgentCodeDropDownList");
          var id6 = v6.options[v6.selectedIndex].text;
          var v7 = document.getElementById("primarynationalityDropDownList");
          var id7 = v7.options[v7.selectedIndex].text;
          var v8 = document.getElementById("PrimaryCountryDropDownList");
          var id8 = v8.options[v8.selectedIndex].text;
          var v9 = document.getElementById("gueststatusDropDownList");
          var id9 = v9.options[v9.selectedIndex].text;
          var v10 = document.getElementById("employmentstatusDropDownList");
          var id10 = v10.options[v10.selectedIndex].text;
          var v11 = document.getElementById("MaritalStatusDropDownList");
          var id11 = v11.options[v11.selectedIndex].text;
          var v12 = document.getElementById("salesrepDropDownList");
          var id12 = v12.options[v12.selectedIndex].text;
          var v13 = document.getElementById("QStatusDropDownList1");
          var id13 = v13.options[v13.selectedIndex].text;


          //document.getElementById('<%= QStatusDropDownList1.ClientID %>').value == ''


          //alert(id);
        <%--if (document.getElementById('<%= pfnameTextBox.ClientID %>').value == '')
        {
            //alert('pfnameTextBox');
            document.getElementById('<%= pfnameTextBox.ClientID %>').style.backgroundColor = '#fcccd2';
            //alert(document.getElementById('<%= pfnameTextBox.ClientID %>').value);
            rem = false;
            //alert(rem);
        }--%>
          //alert('venuec1' + rem);
          //alert(id);
          if (id == '') {
              //alert('12');
              document.getElementById('<%= VenueCountryDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
            // alert(rem);
        }
          //alert('venuec'+rem);
        if (id2 == '') {
            // alert('venuec');
            document.getElementById('<%= VenueDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
             // alert(rem);
         }
          //alert('venue'+rem);
         if (id3 == '') {
             //alert('groupv');
             document.getElementById('<%= GroupVenueDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
             // alert(rem);
         }
          // alert('groupv' + rem);
         if (id4 == '') {
             //alert('MarketingPrgmDropDownList');
             document.getElementById('<%= MarketingPrgmDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
             // alert(rem);
         }
          // alert('mark' + rem);
         if (id5 == '') {
             //alert('AgentsDropDownList');
             if (id3 != "Flybuy") {

                 document.getElementById('<%= AgentsDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                 rem = false;
             }
             // alert(rem);
         }
          //alert('agent' + rem);
         if (id6 == '') {
             //alert('AgentCodeDropDownList');
             if (id3 != "Flybuy" && id3 != "Coldline") {


                 document.getElementById('<%= AgentCodeDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                 rem = false;
             }
             // alert(rem);
         }


         if (document.getElementById('<%= sourcecodetext.ClientID %>').value == '') {
              //alert('hi');
              var v2 = document.getElementById("GroupVenueDropDownList").value;

              //alert('hi');
              if (v2 == "Coldline") {
                  document.getElementById('<%= sourcecodetext.ClientID %>').style.backgroundColor = '#fcccd2';
                 rem = false;
             }
               // alert(rem);
         }



         if (id7 == '') {
             //alert('AgentCodeDropDownList');
             document.getElementById('<%= primarynationalityDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
               rem = false;
               // alert(rem);
           }

           if (id8 == '') {
               //alert('primary country');
               document.getElementById('<%= PrimaryCountryDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
               rem = false;
               // alert(rem);
           }

           if (id9 == '') {
               //alert('AgentCodeDropDownList');
               document.getElementById('<%= gueststatusDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
               rem = false;
               // alert(rem);
           }
          <%-- if (id10 == '')
        {
             //alert('AgentCodeDropDownList');
            document.getElementById('<%= employmentstatusDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
           // alert(rem);
           }

           if (id11 == '')
        {
             //alert('AgentCodeDropDownList');
            document.getElementById('<%= MaritalStatusDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
           // alert(rem);
           }--%>
          if (id12 == '') {
              //alert('AgentCodeDropDownList');

              if (id9 == 'Qualified' || id9 == 'Courtesy Tour') {

                  document.getElementById('<%= salesrepDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                   rem = false;
               }
               // alert(rem);
           }

           if (id13 == '') {
               //alert('hi');
               //var v9 = document.getElementById("gueststatusDropDownList").value;
               //var id9 = v9.options[v9.selectedIndex].text;

               if (id9 == 'Qualified') {
                   document.getElementById('<%= QStatusDropDownList1.ClientID %>').style.backgroundColor = '#fcccd2';
                  rem = false;
              }
               //alert(rem);
          }



          if (document.getElementById('<%= plnameTextBox.ClientID %>').value == '') {
              //alert('hi');
              document.getElementById('<%= plnameTextBox.ClientID %>').style.backgroundColor = '#fcccd2';
              rem = false;
              //alert(rem);
          }

          <%-- if (document.getElementById('<%= pemailTextBox.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= pemailTextBox.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
            //alert(rem);
           }--%>

          if (document.getElementById('<%= deckcheckintimeTextBox.ClientID %>').value == '') {
              //alert('hi');
              if (id2 != 'Inhouse') {
                  document.getElementById('<%= deckcheckintimeTextBox.ClientID %>').style.backgroundColor = '#fcccd2';
                  rem = false;
              }
              //alert(rem);
          }

          // alert('ERROR');

          if (rem == false) {
              alert('Please Enter Data in Required Field!!');

          }
          //alert('ERROR');
          return rem;
      }


       </script>


        <script>



        $(document).ready(function () {

            $("#sub1").click(function () {

                if ($(this).is(":checked")) {
                    $("#subPro1").show();
                } else {

                    $("#subPro1").hide();
                }

            });

            $("#sub2").click(function () {

                if ($(this).is(":checked")) {
                    $("#subPro2").show();
                } else {

                    $("#subPro2").hide();
                }

            });


            $("#sub3").click(function () {

                if ($(this).is(":checked")) {
                    $("#subPro3").show();
                } else {

                    $("#subPro3").hide();
                }

            });


            $("#sub4").click(function () {

                if ($(this).is(":checked")) {
                    $("#subPro4").show();
                } else {

                    $("#subPro4").hide();
                }

            });



        });

    </script>

       <script type="text/javascript">


           var l = 1;

           function f() {
               //var p = 1;

               //$.ajax({
               //    type: "POST",
               //    contentType: "application/json; charset=utf-8",
               //    //url is the path of our web method (Page name/function name)
               //    url: "Edit Profile.aspx/totalgift",
               //    data: "{}",
               //    dataType: "json",
               //    //called on jquery ajax call success
               //    success: function (data) {
               //        k = (data.d);
               //        //$("#vouchernoTextBox").val(data.d);

               //        l = k;

               //    },
               //    //called on jquery ajax call failure
               //    error: function () {
               //        //alert('error');
               //    }
               //});
               ////return false;
               //alert(l);

               l++;
               //alert(l);
               var s = 'item88s' + l;
               var p = 'item88p' + l;
               var q = 'item88q' + l;
               var d = 'item88d' + l;

               $("." + s).show();
               $("." + p).show();
               $("." + q).show();
               $("." + d).show();
               //alert('kkk');
             //--  document.getElementById(s).style.display = "block";
           //--    document.getElementById(p).style.display = "block";
            //--   document.getElementById(q).style.display = "block";
               //alert('kkk');
               if (l == '7') {
                   document.getElementById("bittu").style.display = "none";
                   //alert('kkk');
               }

           }


        

           function topFunction() {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location = '<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

     }





     function getAge(date, ageid) {
         // alert('hi');


         var today = new Date();
         //alert('hi2');
         //  alert(today);
         var dateString = document.getElementById(date).value;
         var birthDate = new Date(dateString.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));

         // dob = new Date(value.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
         // age = today.getFullYear() - dob.getFullYear(); //This is the update

         // alert(birthDate);

         // var teage = today.getFullYear();
         // var tbage = birthDate.getFullYear();

         // alert(teage + '  ' + tbage);

         var age = today.getFullYear() - birthDate.getFullYear();

         // alert(age);
         var m = today.getMonth() - birthDate.getMonth();
         if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
             age--;
         }

         document.getElementById(ageid).value = age;
         //return age;
     }




     function loadQStatus() {

         var v1 = document.getElementById("gueststatusDropDownList");
         var gueststat = v1.options[v1.selectedIndex].text;

         if (gueststat == 'Qualified') {
             
             $(".item8822qq").show();

         }
         else {
             $(".item8822qq").hide();
         }



     }


     function showflybuys() {
         //var id = $("#GroupVenueDropDownList").val();

         //var v1 = document.getElementById("VenueDropDownList");
         //var id = v1.options[v1.selectedIndex].text;

         var v1 = document.getElementById("GroupVenueDropDownList");
         var id = v1.options[v1.selectedIndex].text;

         var v2 = document.getElementById("VenueCountryDropDownList");
         var id2 = v2.options[v2.selectedIndex].text;

         if (id == "Flybuy") {
             // alert('hi');
             $(".itemFly").show();
             $(".item9a1").show();
             $(".item9a2").show();
             $(".item9a3").show();
             $(".item9a4").show();
             $(".item9b").hide();
             $(".item9").show();
           //--  document.getElementById("itemFly").style.display = "grid";
            //-- document.getElementById("item9a1").style.display = "grid";
             // document.getElementById("item9").style.display = "none";
          //--   document.getElementById("item9a2").style.display = "grid";
          //--   document.getElementById("item9a3").style.display = "grid";
          //--   document.getElementById("item9a4").style.display = "grid";
             //document.getElementById("item8").style.display = "none";
           //--  document.getElementById("item9b").style.display = "none";
            //-- document.getElementById("item9").style.display = "grid";
         }
         else if (id == "Coldline") {
             $(".item9b").show();
             $(".item9").hide();
             $(".itemFly").hide();
             $(".item9a1").hide();
             $(".item9a2").hide();
             $(".item9a3").hide();
             $(".item9a4").hide();
             //--  document.getElementById("item9b").style.display = "grid";
             //--  document.getElementById("item9").style.display = "none";
             //--  document.getElementById("itemFly").style.display = "none";
             //--    document.getElementById("item9a1").style.display = "none";
             //--  document.getElementById("item9a2").style.display = "none";
             //--  document.getElementById("item9a3").style.display = "none";
             //-- document.getElementById("item9a4").style.display = "none";
             // document.getElementById("item9").style.display = "grid";
             //document.getElementById("item8").style.display = "grid";
         }
         else {
             $(".item9b").hide();
             $(".item9").show();
             $(".itemFly").hide();
             $(".item9a1").hide();
             $(".item9a2").hide();
             $(".item9a3").hide();
             $(".item9a4").hide();
            //-- document.getElementById("item9b").style.display = "none";
            //-- document.getElementById("item9").style.display = "grid";
           //--  document.getElementById("itemFly").style.display = "none";
           //--  document.getElementById("item9a1").style.display = "none";
           //--  document.getElementById("item9a2").style.display = "none";
           //--  document.getElementById("item9a3").style.display = "none";
           //--  document.getElementById("item9a4").style.display = "none";
             // document.getElementById("item9").style.display = "grid";
             //document.getElementById("item8").style.display = "grid";
         }
     }


       </script>

       <script type="text/javascript">

           //for venue
           $(document).ready(function () {
               $("#VenueCountryDropDownList").change(function () {

                   //var id = $("#VenueCountryDropDownList").val();
                   var v1 = document.getElementById("VenueCountryDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   // alert(id);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit Profile.aspx/PopulateVenueDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#VenueDropDownList").empty();
                           $("#VenueDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#VenueDropDownList").append($("<option></option>").val(value.VenueTypeName).html(value.VenueTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });


           $(document).ready(function () {
               $("#VenueDropDownList").change(function () {

                   // var id = $("#VenueDropDownList").val();

                   //var id2 = $("#VenueCountryDropDownList").val();

                   var v1 = document.getElementById("VenueDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   var v2 = document.getElementById("VenueCountryDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;

                //--   document.getElementById("itemFly").style.display = "none";

                   $(".itemFly").hide();
                   document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                   //loadQStatus();
                   document.getElementById("QStatusDropDownList1").selectedIndex = "0";

                   $(".item9a1").hide();
                 //--  document.getElementById("item9a1").style.display = "none";

                   $(".item9a2").hide();
                 //--  document.getElementById("item9a2").style.display = "none";
                   $(".item9a3").hide();
                   //--document.getElementById("item9a3").style.display = "none";
                   $(".item9a4").hide();
                   //--document.getElementById("item9a4").style.display = "none";

                   //if (id == "Flybuys" || id =="FLYBUYS") {
                   //    // alert('hi');
                   //    document.getElementById("itemFly").style.display = "grid";
                   //    document.getElementById("item9a1").style.display = "grid";

                   //    document.getElementById("item9").style.display = "none";


                   //    document.getElementById("item9a2").style.display = "grid";

                   //    document.getElementById("item9a3").style.display = "grid";

                   //    document.getElementById("item9a4").style.display = "grid";

                   //    document.getElementById("item8").style.display = "none";

                   //    document.getElementById("gueststatusDropDownList").selectedIndex = "4";
                   //    loadQStatus();
                   //    document.getElementById("QStatusDropDownList1").selectedIndex = "1";
                   //}
                   //else {
                   //    document.getElementById("itemFly").style.display = "none";


                   //    document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                   //    loadQStatus();
                   //    document.getElementById("QStatusDropDownList1").selectedIndex = "0";


                   //    document.getElementById("item9a1").style.display = "none";


                   //    document.getElementById("item9a2").style.display = "none";

                   //    document.getElementById("item9a3").style.display = "none";

                   //    document.getElementById("item9a4").style.display = "none";

                   //    document.getElementById("item9").style.display = "grid";


                   //    document.getElementById("item8").style.display = "grid";

                   //}

                   //alert(id+"   "+id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit Profile.aspx/PopulateVenueGroupDropDownList",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#GroupVenueDropDownList").empty();
                           $("#GroupVenueDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#GroupVenueDropDownList").append($("<option></option>").val(value.VenueGroupTypeName).html(value.VenueGroupTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });

                   //for sales rep to populate according to venue

                   //$.ajax({
                   //    type: "POST",
                   //    contentType: "application/json; charset=utf-8",
                   //    //url is the path of our web method (Page name/function name)
                   //    url: "Edit Profile.aspx/SalesRepTypeList",
                   //    data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                   //    dataType: "json",
                   //    //called on jquery ajax call success
                   //    success: function (data) {
                   //        $("#salesrepDropDownList").empty();
                   //        $("#salesrepDropDownList").append("<option></option>");
                   //        jsdata = JSON.parse(data.d);
                   //        $.each(jsdata, function (key, value) {

                   //            $("#salesrepDropDownList").append($("<option></option>").val(value.SalesRepTypeName).html(value.SalesRepTypeName));

                   //        });
                   //    },
                   //    //called on jquery ajax call failure
                   //    error: function () {
                   //        alert('error');
                   //    }
                   //});


                   return false;


               });

           });


           $(document).ready(function () {
               $("#GroupVenueDropDownList").change(function () {

                   //var id = $("#VenueDropDownList").val();

                   // var id2 = $("#VenueCountryDropDownList").val();


                   //var v1 = document.getElementById("VenueDropDownList");
                   //var id = v1.options[v1.selectedIndex].text;

                   var v1 = document.getElementById("GroupVenueDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   var v2 = document.getElementById("VenueCountryDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;


                   var v3 = document.getElementById("VenueDropDownList");
                   var id3 = v3.options[v3.selectedIndex].text;

                   if (id == "Flybuy" || id == "FLYBUY") {
                       // alert('hi');

                       $(".itemFly").show();
                       $(".item9a1").show();
                       $(".item9a2").show();
                       $(".item9a3").show();
                       $(".item9a4").show();
                    
                       //-- document.getElementById("itemFly").style.display = "grid";
                       //--     document.getElementById("item9a1").style.display = "grid";
                       //document.getElementById("item9").style.display = "none";
                       //--  document.getElementById("item9a2").style.display = "grid";
                       //-- document.getElementById("item9a3").style.display = "grid";
                       //-- document.getElementById("item9a4").style.display = "grid";
                       //document.getElementById("item8").style.display = "none";

                       document.getElementById("gueststatusDropDownList").selectedIndex = "4";
                       loadQStatus();
                       document.getElementById("QStatusDropDownList1").selectedIndex = "2";

                       $(".item9b").hide();
                       $(".item9").show();
                     //--  document.getElementById("item9b").style.display = "none";
                     //--  document.getElementById("item9").style.display = "grid";
                   }
                   else if (id == "Coldline") {
                       $(".item9b").show();
                       $(".item9").hide();
                       $(".itemFly").hide();
                       //--   document.getElementById("item9b").style.display = "grid";
                       //-- document.getElementById("item9").style.display = "none";
                       //-- document.getElementById("itemFly").style.display = "none";


                       document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                       loadQStatus();
                       document.getElementById("QStatusDropDownList1").selectedIndex = "0";

                       $(".item9a1").hide();
                       $(".item9a2").hide();
                       $(".item9a3").hide();
                       $(".item9a4").hide();
                      
                       //--   document.getElementById("item9a1").style.display = "none";
                       //-- document.getElementById("item9a2").style.display = "none";
                       //-- document.getElementById("item9a3").style.display = "none";
                       //-- document.getElementById("item9a4").style.display = "none";

                       //document.getElementById("item9").style.display = "grid";


                       //document.getElementById("item8").style.display = "grid";

                   }

                   else {
                       $(".item9b").hide();
                       $(".item9").show();
                       $(".itemFly").hide();

                       //--   document.getElementById("item9b").style.display = "none";
                       //-- document.getElementById("item9").style.display = "grid";
                       //-- document.getElementById("itemFly").style.display = "none";


                       document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                       loadQStatus();
                       document.getElementById("QStatusDropDownList1").selectedIndex = "0";

                       $(".item9a1").hide();
                       $(".item9a2").hide();
                       $(".item9a3").hide();
                       $(".item9a4").hide();


                       //--document.getElementById("item9a1").style.display = "none";
                       //--document.getElementById("item9a2").style.display = "none";
                       //--document.getElementById("item9a3").style.display = "none";
                       //--document.getElementById("item9a4").style.display = "none";

                       //document.getElementById("item9").style.display = "grid";


                       //document.getElementById("item8").style.display = "grid";

                   }

                   // alert(id + "   " + id2);


                   //for sales rep to populate according to venue

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit Profile.aspx/SalesRepTypeList",
                       //data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "','venue' : '" + id3 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#salesrepDropDownList").empty();
                           $("#salesrepDropDownList").append("<option></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#salesrepDropDownList").append($("<option></option>").val(value.SalesRepTypeName).html(value.SalesRepTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });

                   // to load sub venue
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit Profile.aspx/PopulateSubVenueGroupDropDownList",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           // alert('f2');
                           $("#VenueDropDownList2").empty();
                           $("#VenueDropDownList2").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#VenueDropDownList2").append($("<option></option>").val(value.SubVenueGroupTypeName).html(value.SubVenueGroupTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });



                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit Profile.aspx/PopulateMrktProgDropDownList",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#MarketingPrgmDropDownList").empty();
                           $("#MarketingPrgmDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#MarketingPrgmDropDownList").append($("<option></option>").val(value.MrktProgTypeName).html(value.MrktProgTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });



           $(document).ready(function () {
               $("#MarketingPrgmDropDownList").change(function () {
                   // alert("hi");
                   // var id = $("#MarketingPrgmDropDownList").val();

                   //var id2 = $("#VenueDropDownList").val();

                   // var id3 = $("#VenueCountryDropDownList").val();


                   var v1 = document.getElementById("MarketingPrgmDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   //var v2 = document.getElementById("VenueDropDownList");
                   //var id2 = v2.options[v2.selectedIndex].text;

                   var v2 = document.getElementById("GroupVenueDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;

                   var v3 = document.getElementById("VenueCountryDropDownList");
                   var id3 = v3.options[v3.selectedIndex].text;

                   // alert(id );

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit Profile.aspx/PopulateAgentDropDownList",
                       data: "{'markid': '" + id + "','venueid': '" + id2 + "','countid': '" + id3 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#AgentsDropDownList").empty();
                           $("#AgentsDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#AgentsDropDownList").append($("<option></option>").val(value.AgentTypeName).html(value.AgentTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });


           $(document).ready(function () {
               $("#AgentsDropDownList").change(function () {
                   //alert("hi");
                   // var id = $("#AgentsDropDownList").val();

                   //var id2 = $("#MarketingPrgmDropDownList").val();

                   var v1 = document.getElementById("AgentsDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   var v2 = document.getElementById("MarketingPrgmDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;

                   var v3 = document.getElementById("GroupVenueDropDownList");
                   var id3 = v3.options[v3.selectedIndex].text;

                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit Profile.aspx/PopulateAgentCodeDropDownList",
                       data: "{'markid': '" + id2 + "','agentid':'" + id + "','venueid':'" + id3 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#AgentCodeDropDownList").empty();
                           $("#AgentCodeDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#AgentCodeDropDownList").append($("<option></option>").val(value.AgentCodeTypeName).html(value.AgentCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });



           $(document).ready(function () {
               //for primary
               //for primary
               //$("#PrimaryCountryDropDownList").change(function () {
               //   // alert("hi");
               //    var id = $("#PrimaryCountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#primarymobileDropDownList").empty();
               //            //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#primarymobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               //nationality with country primary
               $("#primarynationalityDropDownList").change(function () {
                   // alert("hi");
                   var id = $("#primarynationalityDropDownList option:selected").text();
                   var id1 = $("#primarynationalityDropDownList option:selected").text();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#PrimaryCountryDropDownList").empty();
                           //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#PrimaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });


                   var groupVenue = $("#GroupVenueDropDownList").val();
                   var v1 = document.getElementById("VenueDropDownList");
                   var venue = v1.options[v1.selectedIndex].text;
                   var SubVenue = $("#VenueDropDownList2").val();
                   // alert(groupVenue);
                   // alert(venue);
                   // alert(groupVenue);
                   //  alert(venue);

                   if (venue == "Jimbaran Sales Deck" && groupVenue == "Coldline" && SubVenue != "KCV1") {

                       $.ajax({
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           //url is the path of our web method (Page name/function name)
                           url: "Edit Profile.aspx/PopulateSubVenueOnNationality",
                           data: "{'id1': '" + id1 + "'}",
                           dataType: "json",
                           //called on jquery ajax call success
                           success: function (data) {
                               $("#VenueDropDownList2").empty();
                               //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                               subJson = JSON.parse(data.d);
                               $.each(subJson, function (key, value) {
                                   $.each(value, function (index1, value1) {
                                       $("#VenueDropDownList2").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                   });
                               });
                           },
                           //called on jquery ajax call failure
                           error: function () {
                               alert('error');
                           }
                       });
                       return false;
                   } else {

                   }
               


               });




               //for secondary
               //$("#SecondaryCountryDropDownList").change(function () {
               //    //alert("hi");
               //    var id = $("#SecondaryCountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#secondarymobileDropDownList").empty();
               //           // $("#secondarymobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#secondarymobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               $("#secondarynationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#secondarynationalityDropDownList").val();


                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SecondaryCountryDropDownList").empty();
                           // $("#secondarymobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SecondaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

               //for Subprofile1
               //$("#SubProfile1CountryDropDownList").change(function () {
               //    //alert("hi");
               //    var id = $("#SubProfile1CountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#subprofile1mobileDropDownList").empty();
               //            //$("#subprofile1mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#subprofile1mobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               $("#subprofile1nationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#subprofile1nationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubProfile1CountryDropDownList").empty();
                           //$("#subprofile1mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubProfile1CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });


               //for Subprofile2
               //$("#SubProfile2CountryDropDownList").change(function () {
               //    //alert("hi");
               //    var id = $("#SubProfile2CountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#subprofile2mobileDropDownList").empty();
               //           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#subprofile2mobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               $("#subprofile2nationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#subprofile2nationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubProfile2CountryDropDownList").empty();
                           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubProfile2CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

               //for Subprofile3
               //$("#SubP3CountryDropDownList").change(function () {
               //    //alert("hi");
               //    var id = $("#SubP3CountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#SubP3CCDropDownList").empty();
               //            // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#SubP3CCDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               $("#SubP3NationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#SubP3NationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubP3CountryDropDownList").empty();
                           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubP3CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });


               //for Subprofile4
               //$("#SubP4CountryDropDownList").change(function () {
               //    //alert("hi");
               //    var id = $("#SubP4CountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#SubP4CCDropDownList").empty();
               //            // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#SubP4CCDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});



               $("#SubP4NationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#SubP4NationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubP4CountryDropDownList").empty();
                           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubP4CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });



           });



           /*to load gift option values*/

           //$(document).ready(function () {
           //    $("#pro1").mouseover(function () {
           //        //alert("hi");
           //        // var id = $("#AgentsDropDownList").val();

           //        //var id2 = $("#MarketingPrgmDropDownList").val();

           //        //var v1 = document.getElementById("AgentsDropDownList");
           //        //var id = v1.options[v1.selectedIndex].text;

           //        //var v2 = document.getElementById("MarketingPrgmDropDownList");
           //        //var id2 = v2.options[v2.selectedIndex].text;

           //        // alert(id + "   " + id2);
           //        var k,i,s,p;
           //        //alert('hhhh');

           //        $.ajax({
           //            type: "POST",
           //            contentType: "application/json; charset=utf-8",
           //            //url is the path of our web method (Page name/function name)
           //            url: "Edit Profile.aspx/totalgift",
           //            data: "{}",
           //            dataType: "json",
           //            //called on jquery ajax call success
           //            success: function (data) {
           //                k = (data.d);
           //                alert('pp');
           //                if (k == '3')
           //                {
           //                    document.getElementById(bittu).style.display = "none";
           //                }
           //                alert('pp2');
           //                //$("#vouchernoTextBox").val(data.d);

           //                for (i = 1; i <= k; i++) {

           //                     s = 'item88s' + i;
           //                     p = 'item88p' + i;
           //                    //alert('kkk');
           //                    document.getElementById(s).style.display = "block";
           //                    document.getElementById(p).style.display = "block";
           //                }

           //                //alert(k);

           //            },
           //            //called on jquery ajax call failure
           //            error: function () {
           //                alert('error');
           //            }
           //        });
           //        return false;


           //    });

           //});



       </script>


       <script>
           /*on load Jquery*/
           $(window).on("load", function () {

               showflybuys();
               loadQStatus();

               var k, i, s, p, d;
               // alert('hhhh');

               $.ajax({
                   type: "POST",
                   contentType: "application/json; charset=utf-8",
                   //url is the path of our web method (Page name/function name)
                   url: "Edit Profile.aspx/totalgift",
                   data: "{}",
                   dataType: "json",
                   //called on jquery ajax call success
                   success: function (data) {
                       k = (data.d);
                       //alert('pp');
                       if (k == '7') {
                           // alert('zz');
                           document.getElementById('bittu').style.display = "none";
                        //--  document.getElementById('trans').style.height = "350%";
                       }
                       else if (k == '3') {
                           // alert('hi3');
                           //--   document.getElementById('trans').style.height = "320%";
                           //document.getElementById('trans').style.height = "auto";
                       }
                       else if (k == '4') {
                           //alert('hi');
                           //--  document.getElementById('trans').style.height = "330%";
                       }
                       else if (k == '5') {
                           //alert('hi');
                           //--     document.getElementById('trans').style.height = "330%";
                       }
                       else if (k == '6') {
                           //alert('hi');
                           //--   document.getElementById('trans').style.height = "340%";
                       }

                       else if (k <= '2') {
                           //--   document.getElementById('trans').style.height = "310%";
                       }
                       // alert('pp2');
                       //$("#vouchernoTextBox").val(data.d);

                       for (i = 1; i <= k; i++) {

                           s = 'item88s' + i;
                           p = 'item88p' + i;
                           q = 'item88q' + i;
                           d = 'item88d' + i;
                           //alert('kkk');

                           $("." + s).show();
                           $("." + p).show();
                           $("." + q).show();
                           $("." + d).show();
                          //-- document.getElementById(s).style.display = "block";
                          //-- document.getElementById(p).style.display = "block";
                           //--document.getElementById(q).style.display = "block";
                       }

                       //alert(k);

                   },
                   //called on jquery ajax call failure
                   error: function () {
                       alert('error');
                   }
               });
               // return false;

               //var v1 = document.getElementById("VenueDropDownList");
               // var id = v1.options[v1.selectedIndex].text;

               var v1 = document.getElementById("GroupVenueDropDownList");
               var id = v1.options[v1.selectedIndex].text;

               var v2 = document.getElementById("VenueCountryDropDownList");
               var id2 = v2.options[v2.selectedIndex].text;


               var v3 = document.getElementById("VenueDropDownList");
               var id3 = v3.options[v3.selectedIndex].text;

               $.ajax({
                   type: "POST",
                   contentType: "application/json; charset=utf-8",
                   //url is the path of our web method (Page name/function name)
                   url: "Edit Profile.aspx/SalesRepTypeList",
                   //data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                   data: "{'venueid': '" + id + "','countid' : '" + id2 + "','venue' : '" + id3 + "'}",
                   dataType: "json",
                   //called on jquery ajax call success
                   success: function (data) {
                       //$("#salesrepDropDownList").empty();
                       //$("#salesrepDropDownList").append("<option></option>");
                       jsdata = JSON.parse(data.d);
                       $.each(jsdata, function (key, value) {

                           $("#salesrepDropDownList").append($("<option></option>").val(value.SalesRepTypeName).html(value.SalesRepTypeName));

                       });
                   },
                   //called on jquery ajax call failure
                   error: function () {
                       alert('error');
                   }
               });




           });

       </script>

</head>
<body class="nav-md">
   
    <div class="container body">
         <form id="form1" runat="server">
      <div class="main_container">
        <div class="col-md-3 col-sm-3 col-xs-12 col-lg-3 left_col">
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
                     
                              <div class="x_content" id="x_content" >
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

                                      <div class="row">
                                          <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " id="head">
                                              <br />
                                              <h3 class="text-center"></h3>
                                          </div>
                                      </div>
                                  </div>
                                  <br />
                                  <br />
                                    
                                
                                  <div class="container-fluid" id="con1">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <label for="sel1" style="color: #73879C;">PROFILE</label></div>
                                      </div>

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item1">
                                              <div class="form-group">
                                                  <label for="sel1">Profile ID:</label>
                                                  <asp:TextBox ID="ProfileIDTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemVPID">
                                              <div class="form-group">
                                                  <label for="sel1">View Point ID:</label>
                                                  <asp:TextBox ID="TextVPID" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item2">
                                              <div class="form-group">
                                                  <label for="sel1">Created Date:</label>
                                                  <asp:TextBox ID="createddateTextBox" Enabled="True" class="form-control pull-right" runat="server" ReadOnly="true"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item3">
                                              <div class="form-group">
                                                  <label for="sel1">Created By:</label>
                                                  <asp:TextBox ID="CreatedByTextBox" Enabled="True" class="form-control pull-right" runat="server" ReadOnly="true"></asp:TextBox>
                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item3a">
                                              <div class="form-group">
                                                  <label for="sel1">Receptionist:</label>
                                                  <asp:DropDownList ID="ReceptionistDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item4">
                                              <div class="form-group">
                                                  <label for="sel1">Venue Country:</label>
                                                  <asp:DropDownList ID="VenueCountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                      </div>
                                      <br />

                                      <div class="row">


                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item5">
                                              <div class="form-group">
                                                  <label for="sel1">Venue:</label>
                                                  <asp:DropDownList ID="VenueDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item6">
                                              <div class="form-group">
                                                  <label for="sel1">Sales Venue Group:</label>
                                                  <asp:DropDownList ID="GroupVenueDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item5a">
                                              <div class="form-group">
                                                  <label for="sel1">Sub Venue:</label>
                                                  <asp:DropDownList ID="VenueDropDownList2" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item7">
                                              <div class="form-group">
                                                  <label for="sel1">Marketing Program:</label>
                                                  <asp:DropDownList ID="MarketingPrgmDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8">
                                              <div class="form-group">
                                                  <label for="sel1">Marketing Source:</label>
                                                  <asp:DropDownList ID="AgentsDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9">
                                              <div class="form-group">
                                                  <label for="sel1">Source Code:</label>
                                                  <asp:DropDownList ID="AgentCodeDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9b">
                                              <div class="form-group">
                                                  <label for="sel1">Source Code:</label>
                                                  <asp:TextBox ID="sourcecodetext" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                      </div>

                                      <br />
                                      <div class="row">

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9a1">
                                              <div class="form-group">
                                                  <label for="sel1">Promotion Source:</label>
                                                  <asp:TextBox ID="OfficeSourceTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9a2">
                                              <div class="form-group">
                                                  <label for="sel1">Telemarketing Agent:</label>
                                                  <asp:DropDownList ID="FAgentDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9a3">
                                              <div class="form-group">
                                                  <label for="sel1">Pre Arrival:</label>
                                                  <asp:DropDownList ID="PreArrivalDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>


                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9a4">
                                              <div class="form-group">
                                                  <label for="sel1">Verification:</label>
                                                  <asp:DropDownList ID="VerificationDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemFly">
                                              <div class="form-group">
                                                  <label for="sel1">Guest Relations:</label>
                                                  <asp:DropDownList ID="DropDownListFly" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                      </div>
                                      <br />
                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                              <div class="form-group">
                                                  <input id="chs" type="checkbox" onclick="shows('chs', 'hidden');" />
                                                  <label for="sel1">Are you a Member?</label>
                                              </div>
                                          </div>

                                      </div>

                                      <div class="row" id="hidden">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item21">
                                              <div class="form-group">
                                                  <label for="sel1">Choose Member Type:</label>
                                                  <asp:DropDownList ID="MemType1DropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item22">
                                              <div class="form-group">
                                                  <label for="sel1">Member Number:</label>
                                                  <asp:TextBox ID="Memno1TextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item23">
                                              <div class="form-group">
                                                  <label for="sel1">Choose Member Type:</label>
                                                  <asp:DropDownList ID="MemType2DropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item24">
                                              <div class="form-group">
                                                  <label for="sel1">Member Number:</label>
                                                  <asp:TextBox ID="Memno2TextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>
                                      </div>
                                  </div>
                                  <br />

                                  <div class="container-fluid" id="con2">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <label for="sel1" style="color: #73879C;">PRIMARY PROFILE</label>
                                          </div>
                                      </div>

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item31">
                                              <div class="form-group">
                                                  <label for="sel1">Title:</label>
                                                  <asp:DropDownList ID="primarytitleDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item32">
                                              <div class="form-group">
                                                  <label for="sel1">First Name:</label>
                                                  <asp:TextBox ID="pfnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item33">
                                              <div class="form-group">
                                                  <label for="sel1">Last Name:</label>
                                                  <asp:TextBox ID="plnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item34">
                                            <label for="sel1">Date Of Birth:</label>
                                              <div class="input-group date" id="pdobdatepicker1"  data-provide="datepicker">
                                                  <asp:TextBox ID="pdobdatepicker" class="form-control pull-right" style="pointer-events:none;" runat="server" onchange="getAge('pdobdatepicker', 'TextPrimaryAge');"></asp:TextBox>
                                                  <div class="input-group-addon">
                                                    <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                  </div>
                                              </div>
                                          </div>


                                      </div>

                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item35">
                                              <div class="form-group">
                                                  <label for="sel1">Nationality:</label>
                                                  <asp:DropDownList ID="primarynationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>


                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item37">
                                              <div class="form-group">
                                                  <label for="sel1">Email1:</label>
                                                  <asp:TextBox ID="pemailTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item37a">
                                              <div class="form-group">
                                                  <label for="sel1">Email2:</label>
                                                  <asp:TextBox ID="pemailTextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                            <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item36">
                                              <div class="form-group">
                                                  <label for="sel1">Country:</label>
                                                  <asp:DropDownList ID="PrimaryCountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                      </div>
                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item311age">
                                              <div class="form-group">
                                                  <label for="sel1">Age:</label>
                                                  <asp:TextBox ID="TextPrimaryAge" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item38">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="primarymobileDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item39">
                                              <div class="form-group">
                                                  <label for="sel1">Mobile Number:</label>
                                                  <asp:TextBox ID="pmobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item310">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="primaryalternateDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item311">
                                              <div class="form-group">
                                                  <label for="sel1">Alternate Number:</label>
                                                  <asp:TextBox ID="palternateTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item312">
                                              <div class="form-group">
                                                  <label for="sel1">Employee Status:</label>
                                                  <asp:DropDownList ID="employmentstatusDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                      </div>
                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                              <div class="form-group">
                                                  <input id="Primchs" type="checkbox" onclick="shows('Primchs', 'Prihidden');" />
                                                  <label for="sel1">ID Card?</label>
                                              </div>
                                          </div>

                                      </div>



                                      <div class="row" id="Prihidden">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemPr1">
                                              <div class="form-group">
                                                  <label for="sel1">ID Type:</label>
                                                  <asp:TextBox ID="TextBoxPrimIDType" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemPr2">
                                              <div class="form-group">
                                                  <label for="sel1">ID Number:</label>
                                                  <asp:TextBox ID="TextBoxPrimID" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>


                                      </div>

                                  </div>
                                  <br />
                                  <div class="container-fluid" id="con3">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <label for="sel1" style="color: #73879C;">SECONDARY PROFILE</label>
                                          </div>
                                      </div>


                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item41">
                                              <div class="form-group">
                                                  <label for="sel1">Title:</label>
                                                  <asp:DropDownList ID="secondarytitleDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item42">
                                              <div class="form-group">
                                                  <label for="sel1">First Name:</label>
                                                  <asp:TextBox ID="sfnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item43">
                                              <div class="form-group">
                                                  <label for="sel1">Last Name:</label>
                                                  <asp:TextBox ID="slnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item44">
                                               <label for="sel1">Date Of Birth:</label>
                                              <div class="input-group date" id="sdobdatepicker1"  data-provide="datepicker">
                                                  <asp:TextBox ID="sdobdatepicker" class="form-control pull-right" style="pointer-events:none;" runat="server" onchange="getAge('sdobdatepicker', 'TextSecondAge');"></asp:TextBox>
                                                  <div class="input-group-addon">
                                                    <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                  </div>
                                              </div>
                                          </div>

                                      </div>

                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item45">
                                              <div class="form-group">
                                                  <label for="sel1">Nationality:</label>
                                                  <asp:DropDownList ID="secondarynationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>


                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item47">
                                              <div class="form-group">
                                                  <label for="sel1">Email1:</label>
                                                  <asp:TextBox ID="semailTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item47a">
                                              <div class="form-group">
                                                  <label for="sel1">Email2:</label>
                                                  <asp:TextBox ID="semailTextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item46">
                                              <div class="form-group">
                                                  <label for="sel1">Country:</label>
                                                  <asp:DropDownList ID="SecondaryCountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                      </div>
                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item411age">
                                              <div class="form-group">
                                                  <label for="sel1">Age:</label>
                                                  <asp:TextBox ID="TextSecondAge" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item48">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="secondarymobileDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item49">
                                              <div class="form-group">
                                                  <label for="sel1">Mobile Number:</label>
                                                  <asp:TextBox ID="smobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item410">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="secondaryalternateDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item411">
                                              <div class="form-group">
                                                  <label for="sel1">Alternate Number:</label>
                                                  <asp:TextBox ID="salternateTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item412">
                                              <div class="form-group">
                                                  <label for="sel1">Employee Status:</label>
                                                  <asp:DropDownList ID="SecondemploymentstatusDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                      </div>
                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                              <div class="form-group">
                                                  <input id="Secochs" type="checkbox" onclick="shows('Secochs', 'Sechidden');" />
                                                  <label for="sel1">ID Card?</label>
                                              </div>
                                          </div>

                                      </div>
                                      <div class="row" id="Sechidden">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSec1">
                                              <div class="form-group">
                                                  <label for="sel1">ID Type:</label>
                                                  <asp:TextBox ID="TextBoxSecoIDType" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSec2">
                                              <div class="form-group">
                                                  <label for="sel1">ID Number:</label>
                                                  <asp:TextBox ID="TextBoxSecoID" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>
                                      </div>
                                  </div>
                                  <br />

                                  <div class="container-fluid" id="con4">

                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <label for="sel1" style="color: #73879C;">ADDRESS</label>
                                          </div>

                                      </div>

                                      <div class="row">
                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item51">
                                              <div class="form-group">
                                                  <label for="sel1">Address Line1:</label>
                                                  <asp:TextBox ID="address1TextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item52">
                                              <div class="form-group">
                                                  <label for="sel1">Address Line2:</label>
                                                  <asp:TextBox ID="address2TextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                      </div>
                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item54">
                                              <div class="form-group">
                                                  <label for="sel1">City:</label>
                                                  <asp:TextBox ID="cityTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item53">
                                              <div class="form-group">
                                                  <label for="sel1">State:</label>
                                                  <asp:TextBox ID="stateTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item551">
                                              <div class="form-group">
                                                  <label for="sel1">Country:</label>
                                                  <asp:DropDownList ID="AddCountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>

                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item55">
                                              <div class="form-group">
                                                  <label for="sel1">Postcode:</label>
                                                  <asp:TextBox ID="pincodeTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>

                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item57">
                                              <div class="form-group">
                                                  <label for="sel1">Marital Status:</label>
                                                  <asp:DropDownList ID="MaritalStatusDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>

                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item58">
                                              <div class="form-group">
                                                  <label for="sel1">No of Years (couple):</label>
                                                  <asp:TextBox ID="livingyrsTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>
                                      </div>
                                      <br />

                                  </div>
                                  <br />
                                  <div class="container-fluid" id="con5">

                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <input type="checkbox" id="sub1" />
                                              <label for="sub1" style="color: #73879C;">SUB PROFILE 1</label>
                                          </div>

                                      </div>
                                      <div id="subPro1">
                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item61">
                                                  <div class="form-group">
                                                      <label for="sel1">Title:</label>
                                                      <asp:DropDownList ID="subprofile1titleDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item62">
                                                  <div class="form-group">
                                                      <label for="sel1">First Name:</label>
                                                      <asp:TextBox ID="sp1fnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item63">
                                                  <div class="form-group">
                                                      <label for="sel1">Last Name:</label>
                                                      <asp:TextBox ID="sp1lnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item64">
                                                  <label for="sel1">Date Of Birth:</label>
                                                  <div class="input-group date" id="sp1dobdatepicker1" data-provide="datepicker">
                                                      <asp:TextBox ID="sp1dobdatepicker" class="form-control pull-right" style="pointer-events:none;" runat="server" onchange="getAge('sp1dobdatepicker', 'TextSP1Age');"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>

                                          </div>

                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item65">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="subprofile1nationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>


                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item67">
                                                  <div class="form-group">
                                                      <label for="sel1">Email1:</label>
                                                      <asp:TextBox ID="sp1emailTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item67a">
                                                  <div class="form-group">
                                                      <label for="sel1">Email2:</label>
                                                      <asp:TextBox ID="sp1emailTextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item66">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubProfile1CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item611age">
                                                  <div class="form-group">
                                                      <label for="sel1">Age:</label>
                                                      <asp:TextBox ID="TextSP1Age" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item68">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="subprofile1mobileDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item69">
                                                  <div class="form-group">
                                                      <label for="sel1">Mobile Number:</label>
                                                      <asp:TextBox ID="sp1mobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item610">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="subprofile1alternateDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item611">
                                                  <div class="form-group">
                                                      <label for="sel1">Alternate Number:</label>
                                                      <asp:TextBox ID="sp1alternateTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>



                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                                  <div class="form-group">
                                                      <input id="SP1chs" type="checkbox" onclick="shows('SP1chs', 'SP1hidden');" />
                                                      <label for="sel1">ID Card?</label>
                                                  </div>
                                              </div>

                                          </div>
                                          <div class="row" id="SP1hidden">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP11">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Type:</label>
                                                      <asp:TextBox ID="TextBoxSP1IDType" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP12">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Number:</label>
                                                      <asp:TextBox ID="TextBoxSP1ID" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>
                                          </div>

                                      </div>

                                  </div>

                                  <br />

                                  <div class="container-fluid" id="con6">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <input type="checkbox" id="sub2" />
                                              <label for="sub2" style="color: #73879C;">SUB PROFILE 2</label>
                                          </div>
                                      </div>
                                      <div id="subPro2">
                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item71">
                                                  <div class="form-group">
                                                      <label for="sel1">Title:</label>
                                                      <asp:DropDownList ID="subprofile2titleDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item72">
                                                  <div class="form-group">
                                                      <label for="sel1">First Name:</label>
                                                      <asp:TextBox ID="sp2fnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item73">
                                                  <div class="form-group">
                                                      <label for="sel1">Last Name:</label>
                                                      <asp:TextBox ID="sp2lnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item74">
                                                  <label for="sel1">Date Of Birth:</label>
                                                  <div class="input-group date" id="sp2dobdatepicker1" data-provide="datepicker">
                                                      <asp:TextBox ID="sp2dobdatepicker" class="form-control pull-right" style="pointer-events:none;" runat="server" onchange="getAge('sp2dobdatepicker', 'TextSP2Age');"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>

                                          </div>

                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item75">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="subprofile2nationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>


                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item77">
                                                  <div class="form-group">
                                                      <label for="sel1">Email1:</label>
                                                      <asp:TextBox ID="sp2emailTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item77a">
                                                  <div class="form-group">
                                                      <label for="sel1">Email2:</label>
                                                      <asp:TextBox ID="sp2emailTextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item76">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubProfile2CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item711age">
                                                  <div class="form-group">
                                                      <label for="sel1">Age:</label>
                                                      <asp:TextBox ID="TextSP2Age" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item78">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="subprofile2mobileDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item79">
                                                  <div class="form-group">
                                                      <label for="sel1">Mobile Number:</label>
                                                      <asp:TextBox ID="sp2mobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item710">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="subprofile2alternateDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item711">
                                                  <div class="form-group">
                                                      <label for="sel1">Alternate Number:</label>
                                                      <asp:TextBox ID="sp2alternateTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>



                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                                  <div class="form-group">
                                                      <input id="SP2chs" type="checkbox" onclick="shows('SP2chs', 'SP2hidden');" />
                                                      <label for="sel1">ID Card?</label>
                                                  </div>
                                              </div>

                                          </div>
                                          <div class="row" id="SP2hidden">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP21">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Type:</label>
                                                      <asp:TextBox ID="TextBoxSP2IDType" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP22">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Number:</label>
                                                      <asp:TextBox ID="TextBoxSP2ID" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>
                                          </div>
                                      </div>


                                  </div>
                                  <br />

                                  <div class="container-fluid" id="con7">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <input type="checkbox" id="sub3" />
                                              <label for="sub3" style="color: #73879C;">SUB PROFILE 3</label>
                                          </div>
                                      </div>
                                      <div id="subPro3">
                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s31">
                                                  <div class="form-group">
                                                      <label for="sel1">Title:</label>
                                                      <asp:DropDownList ID="SubP3TitleDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s32">
                                                  <div class="form-group">
                                                      <label for="sel1">First Name:</label>
                                                      <asp:TextBox ID="SubP3FnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s33">
                                                  <div class="form-group">
                                                      <label for="sel1">Last Name:</label>
                                                      <asp:TextBox ID="SubP3LnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s34">
                                                  <label for="sel1">Date Of Birth:</label>
                                                  <div class="input-group date" id="SubP3DOB1" data-provide="datepicker">
                                                      <asp:TextBox ID="SubP3DOB" class="form-control pull-right" style="pointer-events:none;" runat="server" onchange="getAge('SubP3DOB', 'TextSP3Age');"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>

                                          </div>

                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s35">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="SubP3NationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>


                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s37">
                                                  <div class="form-group">
                                                      <label for="sel1">Email1:</label>
                                                      <asp:TextBox ID="SubP3EmailTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s38">
                                                  <div class="form-group">
                                                      <label for="sel1">Email2:</label>
                                                      <asp:TextBox ID="SubP3EmailTextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s36">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubP3CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9sage">
                                                  <div class="form-group">
                                                      <label for="sel1">Age:</label>
                                                      <asp:TextBox ID="TextSP3Age" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s39">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="SubP3CCDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s40">
                                                  <div class="form-group">
                                                      <label for="sel1">Mobile Number:</label>
                                                      <asp:TextBox ID="SubP3MobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s41">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="SubP3CCDropDownList2" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s42">
                                                  <div class="form-group">
                                                      <label for="sel1">Alternate Number:</label>
                                                      <asp:TextBox ID="SubP3AMobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>



                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                                  <div class="form-group">
                                                      <input id="SP3chs" type="checkbox" onclick="shows('SP3chs', 'SP3hidden');" />
                                                      <label for="sel1">ID Card?</label>
                                                  </div>
                                              </div>

                                          </div>
                                          <div class="row" id="SP3hidden">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP31">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Type:</label>
                                                      <asp:TextBox ID="TextBoxSP3IDType" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP32">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Number:</label>
                                                      <asp:TextBox ID="TextBoxSP3ID" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>
                                          </div>

                                      </div>


                                  </div>
                                  <br />

                                  <div class="container-fluid" id="con8">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <input type="checkbox" id="sub4" />
                                              <label for="sub4" style="color: #73879C;">SUB PROFILE 4</label>
                                          </div>
                                      </div>
                                      <div id="subPro4">
                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s1">
                                                  <div class="form-group">
                                                      <label for="sel1">Title:</label>
                                                      <asp:DropDownList ID="SubP4TitleDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s4s2">
                                                  <div class="form-group">
                                                      <label for="sel1">First Name:</label>
                                                      <asp:TextBox ID="SubP4FnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s4s3">
                                                  <div class="form-group">
                                                      <label for="sel1">Last Name:</label>
                                                      <asp:TextBox ID="SubP4LnameTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s4">
                                                  <label for="sel1">Date Of Birth:</label>
                                                  <div class="input-group date" id="SubP4DOB1" data-provide="datepicker">
                                                      <asp:TextBox ID="SubP4DOB" class="form-control pull-right" style="pointer-events:none;" runat="server" onchange="getAge('SubP4DOB', 'TextSP4Age');"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>

                                          </div>

                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s5">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="SubP4NationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s4s7">
                                                  <div class="form-group">
                                                      <label for="sel1">Email1:</label>
                                                      <asp:TextBox ID="SubP4EmailTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4 item9s4s8">
                                                  <div class="form-group">
                                                      <label for="sel1">Email2:</label>
                                                      <asp:TextBox ID="SubP4EmailTextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s6">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubP4CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4age">
                                                  <div class="form-group">
                                                      <label for="sel1">Age:</label>
                                                      <asp:TextBox ID="TextSP4Age" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s9">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="SubP4CCDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s10">
                                                  <div class="form-group">
                                                      <label for="sel1">Mobile Number:</label>
                                                      <asp:TextBox ID="SubP4MobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s11">
                                                  <div class="form-group">
                                                      <label for="sel1">CCode:</label>
                                                      <asp:DropDownList ID="SubP4CCDropDownList2" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s12">
                                                  <div class="form-group">
                                                      <label for="sel1">Alternate Number:</label>
                                                      <asp:TextBox ID="SubP4AMobileTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>



                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                                  <div class="form-group">
                                                      <input id="SP4chs" type="checkbox" onclick="shows('SP4chs', 'SP4hidden');" />
                                                      <label for="sel1">ID Card?</label>
                                                  </div>
                                              </div>

                                          </div>
                                          <div class="row" id="SP4hidden">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP41">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Type:</label>
                                                      <asp:TextBox ID="TextBoxSP4IDType" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemSP42">
                                                  <div class="form-group">
                                                      <label for="sel1">ID Number:</label>
                                                      <asp:TextBox ID="TextBoxSP4ID" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>

                                              </div>
                                          </div>

                                      </div>
                                  </div>

                                  <br />
                                  <div class="container-fluid" id="con9">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <input type="checkbox" id="stay" />
                                              <label for="stay" style="color: #73879C;">STAY DETAILS</label>
                                          </div>
                                      </div>

                                      <div id="staydetails">
                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item81">
                                                  <div class="form-group">
                                                      <label for="sel1">Resort Name:</label>
                                                      <asp:TextBox ID="hotelTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item82">
                                                  <div class="form-group">
                                                      <label for="sel1">Resort Room No:</label>
                                                      <asp:TextBox ID="roomnoTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item83">
                                                  <label for="sel1">Arrival:</label>
                                                  <div class="input-group date" id="checkindatedatepicker1" data-provide="datepicker">
                                                      <asp:TextBox ID="checkindatedatepicker" style="pointer-events:none;" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>
                                             <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item84">
                                                  <label for="sel1">Departure:</label>
                                                  <div class="input-group date" id="checkoutdatedatepicker1" data-provide="datepicker">
                                                      <asp:TextBox ID="checkoutdatedatepicker" style="pointer-events:none;" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item85">
                                                  <div class="form-group">
                                                      <div >
                                                          <label for="sel1">Check-In Time:</label>
                                                      <asp:TextBox ID="deckcheckintimeTextBox"  class="form-control pull-right" runat="server"></asp:TextBox>
                                                          
                                                      </div>
                                                     
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item86">
                                                  <div class="form-group">
                                                      <div>
                                                         <label for="sel1">Check-Out Time:</label>
                                                        <asp:TextBox ID="deckcheckouttimeTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox> 
                                                      </div>
                                                  </div>
                                              </div>
                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88s1">
                                                  <div class="form-group">
                                                      <label for="sel1">Choose Gift Option:</label>
                                                      <asp:DropDownList ID="giftoptionDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                            
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88p1">
                                                  <div class="form-group">
                                                      <label for="sel1">Voucher No:</label>
                                                      <asp:TextBox ID="vouchernoTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88q1">
                                                  <div class="form-group">
                                                      <label for="sel1">Gift Price:</label>
                                                      <asp:TextBox ID="TextBoxGPrice1" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice1');"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88d1">
                                                  <div class="form-group">
                                                      <label for="sel1">Delete:</label>
                                                      <div></div>&nbsp;&nbsp;
                                                     <asp:CheckBox ID="DeleGiftCheckBox1" runat="server" />
                                                  </div>
                                              </div>

                                               <div class="col-md-6 col-xs-12 col-sm-8 col-lg-6 item88cb">
                                                  <div class="form-group">
                                                      <label for="sel1">Charge Back:</label>
                                                      <asp:TextBox ID="TextBoxChargeBack" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>


                                          </div>
                                          <br />
                                          <div class="row">

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88s2">
                                                  <div class="form-group">
                                                      <label for="sel1">Choose Gift Option:</label>
                                                      <asp:DropDownList ID="giftoptionDropDownList2" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88p2">
                                                  <div class="form-group">
                                                      <label for="sel1">Voucher No:</label>
                                                      <asp:TextBox ID="vouchernoTextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88q2">
                                                  <div class="form-group">
                                                      <label for="sel1">Gift Price:</label>
                                                      <asp:TextBox ID="TextBoxGPrice2" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice2');"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88d2">
                                                  <div class="form-group">
                                                      <label for="sel1">Delete:</label>
                                                      <div></div>
                                                      &nbsp;&nbsp;
                                                     <asp:CheckBox ID="DeleGiftCheckBox2" runat="server" />
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88s3">
                                                  <div class="form-group">
                                                      <label for="sel1">Choose Gift Option:</label>
                                                      <asp:DropDownList ID="giftoptionDropDownList3" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88p3">
                                                  <div class="form-group">
                                                      <label for="sel1">Voucher No:</label>
                                                      <asp:TextBox ID="vouchernoTextBox3" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88q3">
                                                  <div class="form-group">
                                                      <label for="sel1">Gift Price:</label>
                                                      <asp:TextBox ID="TextBoxGPrice3" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice3');"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88d3">
                                                  <div class="form-group">
                                                      <label for="sel1">Delete:</label>
                                                      <div></div>
                                                      &nbsp;&nbsp;
                                                     <asp:CheckBox ID="DeleGiftCheckBox3" runat="server" />
                                                  </div>
                                              </div>
                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88s4">
                                                  <div class="form-group">
                                                      <label for="sel1">Choose Gift Option:</label>
                                                      <asp:DropDownList ID="giftoptionDropDownList4" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88p4">
                                                  <div class="form-group">
                                                      <label for="sel1">Voucher No:</label>
                                                      <asp:TextBox ID="vouchernoTextBox4" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88q4">
                                                  <div class="form-group">
                                                      <label for="sel1">Gift Price:</label>
                                                      <asp:TextBox ID="TextBoxGPrice4" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice4');"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88d4">
                                                  <div class="form-group">
                                                      <label for="sel1">Delete:</label>
                                                      <div></div>
                                                      &nbsp;&nbsp;
                                                     <asp:CheckBox ID="DeleGiftCheckBox4" runat="server" />
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88s5">
                                                  <div class="form-group">
                                                      <label for="sel1">Choose Gift Option:</label>
                                                      <asp:DropDownList ID="giftoptionDropDownList5" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88p5">
                                                  <div class="form-group">
                                                      <label for="sel1">Voucher No:</label>
                                                      <asp:TextBox ID="vouchernoTextBox5" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88q5">
                                                  <div class="form-group">
                                                      <label for="sel1">Gift Price:</label>
                                                      <asp:TextBox ID="TextBoxGPrice5" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice5');"></asp:TextBox>
                                                  </div>
                                              </div>
                                               <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88d5">
                                                  <div class="form-group">
                                                      <label for="sel1">Delete:</label>
                                                      <div></div>
                                                      &nbsp;&nbsp;
                                                     <asp:CheckBox ID="DeleGiftCheckBox5" runat="server" />
                                                  </div>
                                              </div>
                                          </div>
                                          <br />
                                          <div class="row">

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88s6">
                                                  <div class="form-group">
                                                      <label for="sel1">Choose Gift Option:</label>
                                                      <asp:DropDownList ID="giftoptionDropDownList6" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88p6">
                                                  <div class="form-group">
                                                      <label for="sel1">Voucher No:</label>
                                                      <asp:TextBox ID="vouchernoTextBox6" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88q6">
                                                  <div class="form-group">
                                                      <label for="sel1">Gift Price:</label>
                                                      <asp:TextBox ID="TextBoxGPrice6" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice6');"></asp:TextBox>
                                                  </div>
                                              </div>
                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88d6">
                                                  <div class="form-group">
                                                      <label for="sel1">Delete:</label>
                                                      <div></div>
                                                      &nbsp;&nbsp;
                                                     <asp:CheckBox ID="DeleGiftCheckBox6" runat="server" />
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88s7">
                                                  <div class="form-group">
                                                      <label for="sel1">Choose Gift Option:</label>
                                                      <asp:DropDownList ID="giftoptionDropDownList7" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88p7">
                                                  <div class="form-group">
                                                      <label for="sel1">Voucher No:</label>
                                                      <asp:TextBox ID="vouchernoTextBox7" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>

                                              <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88q7">
                                                  <div class="form-group">
                                                      <label for="sel1">Gift Price:</label>
                                                      <asp:TextBox ID="TextBoxGPrice7" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice7');"></asp:TextBox>
                                                  </div>
                                              </div>
                                               <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1 item88d7">
                                                  <div class="form-group">
                                                      <label for="sel1">Delete:</label>
                                                      <div></div>
                                                      &nbsp;&nbsp;
                                                     <asp:CheckBox ID="DeleGiftCheckBox7" runat="server" />
                                                  </div>
                                              </div>

                                          </div>
                                          <br />
                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                                  <div id='kk2'>
                                                      <button type="button" id="bittu" class="btn" onclick="f();">More Gifts</button>

                                                  </div>
                                              </div>
                                          </div>
                                          <br />

                                          <div class="row">
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8822">
                                                  <div class="form-group">
                                                      <label for="sel1">Guest Status:</label>
                                                      <asp:DropDownList ID="gueststatusDropDownList" class="form-control pull-right" runat="server" onchange="loadQStatus();"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8822qq">
                                                  <div class="form-group">
                                                      <label for="sel1">Q Status:</label>
                                                      <asp:DropDownList ID="QStatusDropDownList1" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8824">
                                                  <div class="form-group">
                                                      <label for="sel1">Sales Represntative:</label>
                                                      <asp:DropDownList ID="salesrepDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                              <div class="col-md-6 col-xs-12 col-sm-8 col-lg-6 item8821">
                                                  <div class="form-group">
                                                      <label for="sel1">Comment if Any:</label>
                                                      <asp:TextBox ID="commentTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>
                                          </div>
                                          <br />
                                          <div class="row">
                                               <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8823">
                                                   <label for="sel1">Tour Date:</label>
                                                   <div class="input-group date" id="tourdatedatepicker1" data-provide="datepicker">
                                                       <asp:TextBox ID="tourdatedatepicker" style="pointer-events:none;" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                        <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                   </div>
                                               </div>

                                                <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8826">
                                                  <div class="form-group">
                                                      <label for="sel1">Taxi in Price:</label>
                                                      <asp:TextBox ID="taxipriceInTextBox" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('taxipriceInTextBox');"></asp:TextBox>
                                                  </div>
                                              </div>

                                               <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8827">
                                                  <div class="form-group">
                                                      <label for="sel1">Taxi in Reference:</label>
                                                      <asp:TextBox ID="TaxiRefInTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>


                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8828">
                                                  <div class="form-group">
                                                      <label for="sel1">Taxi out Price:</label>
                                                      <asp:TextBox ID="TaxiPriceOutTextBox" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TaxiPriceOutTextBox');"></asp:TextBox>
                                                  </div>
                                              </div>


                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8829">
                                                  <div class="form-group">
                                                      <label for="sel1">Taxi out Reference:</label>
                                                      <asp:TextBox ID="TaxiRefOutTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                  </div>
                                              </div>



                                          </div>
                                          <br />
                                          <div class="row">
                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4">
                                                  <div class="form-group">
                                                      <asp:CheckBox ID="Regterms1" runat="server" Text="" />
                                                      <label for="sel1">Registration Card Terms 1</label>
                                                  </div>
                                              </div>

                                              <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4">
                                                  <div class="form-group">
                                                      <asp:CheckBox ID="Regterms2" runat="server" Text="" />
                                                      <label for="sel1">Registration Card Terms 2</label>
                                                  </div>
                                              </div>
                                          </div>

                                      </div>

                                  </div>

                                  <br />
                                  <br />
                                  <div class="container-fluid">

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                              <div class="form-group">
                                              </div>
                                          </div>
                                          <div class="col-md-1 col-xs-12 col-sm-8 col-lg-1">
                                              <div class="form-group">
                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                              <div class="form-group">
                                               

                                              </div>
                                          </div>
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2">
                                              <div class="form-group">
                                                     <button type="button" class="btn btn-success" id="Ed">Edit</button>
                                                  <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClientClick="if (!hi3()) return false;" OnClick="Button1_Click" Text="Update Profile" />

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

    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.css" rel="stylesheet" />

    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#deckcheckintimeTextBox,#deckcheckouttimeTextBox').datetimepicker({
                format: 'HH:mm'
            });
        });
    </script>


    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"></script>



    <script type="text/javascript">

        $(function () {

            $('#pdobdatepicker1,#SubP4DOB1,#SubP3DOB1,#sp2dobdatepicker1,#sp1dobdatepicker1,#sdobdatepicker1').datepicker({
                maxDate: "31-12-2000",
                format: 'dd-mm-yyyy',
                startView: 2,
                autoclose: true,
                orientation: "bottom auto"
            });


        });

        $(function () {

            $('#checkindatedatepicker1,#checkoutdatedatepicker1').datepicker({
                format: 'dd-mm-yyyy',
                orientation: "bottom auto",
                autoclose: true
            });
        });

        $(function () {

            $('#tourdatedatepicker1').datepicker({
                format: 'dd-mm-yyyy',
                autoclose: true,
                startDate: new Date()

            });


        });

        function getAge(date, ageid) {
            // alert('hi');

            var today = new Date();
            //alert('hi2');
            //  alert(today);
            var dateString = document.getElementById(date).value;
            var birthDate = new Date(dateString.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));

            // dob = new Date(value.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
            // age = today.getFullYear() - dob.getFullYear(); //This is the update

            // alert(birthDate);

            // var teage = today.getFullYear();
            // var tbage = birthDate.getFullYear();

            // alert(teage + '  ' + tbage);

            var age = today.getFullYear() - birthDate.getFullYear();

            // alert(age);
            var m = today.getMonth() - birthDate.getMonth();
            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }

            document.getElementById(ageid).value = age;
            //return age;
            //alert(age);



        }

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

            $.ajax({

                type: 'Post',
                url: 'Edit Profile.aspx/getAdminRights',
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
                    url: 'Edit Profile.aspx/searchProfile',
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
                    url: 'Edit Profile.aspx/getlink',
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

            $("#Ed").click(function () {
                $("#Ed").hide();
                $("#Button1").show();
                $('#con1').css('pointer-events', 'auto');
                $('#con2').css('pointer-events', 'auto');
                $('#con3').css('pointer-events', 'auto');
                $('#con4').css('pointer-events', 'auto');
                $('#con5').css('pointer-events', 'auto');
                $('#con6').css('pointer-events', 'auto');
                $('#con7').css('pointer-events', 'auto');
                $('#con8').css('pointer-events', 'auto');
                $('#con9').css('pointer-events', 'auto');

            });

        });

    </script>

</body>
</html>
