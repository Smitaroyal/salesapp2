<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateProfile1.aspx.cs" EnableEventValidation="false" Inherits="WebSite5_production_CreateProfile" %>

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

        #searchPro {
            padding: 8px 40px;
            border-radius: 25px;
            margin-right: 10px;
            font-size: 13px;
            text-align: center;
        }

        .item10, .item11, .item12,
        .item9b, .item9a1, .item9a2, .item9a3, .item9a4, .itemFly,.item47b,.item53b,.item6b,.item4b,.item312,.item313,
        #sub1, #subPro1, #sub2, #subPro2, #sub3, #subPro3, #sub4, #subPro4, #stay,#item577,.item4bb,.item412,.item4122,
        .item88s2, .item88p2, .item88q2, .item88s3, .item88p3, .item88q3, .item88s4, .item88p4, .item88q4, .item88s5,.itemHome412,.itemHome4122,
        .item88p5, .item88q5, .item88s6, .item88p6, .item88q6, .item88s7, .item88p7, .item88q7, .item8822qq,.item377,.itemHome312,.itemHome313 {
            display: none;
        }

        .title {
            font-size: 13px;
            font-style: oblique;
        }

        #img {
            position: fixed;
            background: #04070B;
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }


        #update, #head, #directory, #insert, #sourceCodeText, #hidden1, #Prihidden, #Sechidden, #SP1hidden, #SP2hidden, #SP3hidden, #SP4hidden {
            display: none;
        }

        #success-alert, #danger-alert, #danger-alert1, #menu_toggle, #profileDetails {
            display: none;
        }

        #TextBox5 {
            text-align: center;
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
        #TONameDropDownList,#ManagerDropDownList,#PrimaryCountryDropDownList,#pofficecodeDropDownList,#pofficenoTextBox,#sofficecodeDropDownList,#sofficenoTextBox,
        #maledesgTextBox,#femaledesgTextBox,#StateDropDownList,#comment2,#TypeDropDownList,#phomecodeDropDownList,#phomenoTextBox,#shomecodeDropDownList,#shomenoTextBox,
        #ProfileIDTextBox, #TextVPID, #TextBox1, #CreatedByTextBox, #ReceptionistDropDownList, #VenueCountryDropDownList, #VenueDropDownList, #GroupVenueDropDownList,
        #VenueDropDownList2, #MarketingPrgmDropDownList, #AgentsDropDownList, #AgentsDropDownListInd,#AgentCodeDropDownList, #sourcecodetext, #OfficeSourceTextBox, #FAgentDropDownList,
        #PreArrivalDropDownList, #VerificationDropDownList, #DropDownListFly, #MemType1DropDownList, #Memno1TextBox, #MemType2DropDownList, #Memno2TextBox,#leadOffice,
        #primarytitleDropDownList, #pfnameTextBox, #plnameTextBox, #pdobdatepicker, #TextPrimaryAge, #primarymobileDropDownList, #pmobileTextBox, #primaryalternateDropDownList,
        #palternateTextBox, #primarynationalityDropDownList, #employmentstatusDropDownList, #pemailTextBox, #pemailTextBox2, #TextBoxPrimIDType, #TextBoxPrimID, #TextBoxSecoID,
        #TextBoxSecoIDType, #SecondemploymentstatusDropDownList, #salternateTextBox, #secondaryalternateDropDownList, #smobileTextBox, #secondarymobileDropDownList, #TextSecondAge,
        #SecondaryCountryDropDownList, #semailTextBox2, #semailTextBox, #secondarynationalityDropDownList, #sdobdatepicker, #slnameTextBox, #sfnameTextBox, #secondarytitleDropDownList,
        #address1TextBox, #address2TextBox, #pincodeTextBox, #AddCountryDropDownList, #stateTextBox, #cityTextBox, #livingyrsTextBox, #MaritalStatusDropDownList, #TextBoxSP1ID,
        #TextBoxSP1IDType, #sp1alternateTextBox, #subprofile1alternateDropDownList, #sp1mobileTextBox, #subprofile1mobileDropDownList, #TextSP1Age, #SubProfile1CountryDropDownList,
        #sp1emailTextBox2, #sp1emailTextBox, #subprofile1nationalityDropDownList, #sp1dobdatepicker, #sp1lnameTextBox, #sp1fnameTextBox, #subprofile1titleDropDownList, #TextBoxSP2ID,
        #TextBoxSP2IDType, #sp2alternateTextBox, #subprofile2alternateDropDownList, #sp2mobileTextBox, #subprofile2mobileDropDownList, #TextSP2Age, #SubProfile2CountryDropDownList,
        #sp2emailTextBox2, #sp2emailTextBox, #subprofile2nationalityDropDownList, #sp2dobdatepicker, #sp2lnameTextBox, #sp2fnameTextBox, #subprofile2titleDropDownList, #TextBoxSP3ID,
        #TextBoxSP3IDType, #SubP3AMobileTextBox, #SubP3CCDropDownList2, #SubP3MobileTextBox, #SubP3CCDropDownList, #TextSP3Age, #SubP3CountryDropDownList,#subVenueIndia,
        #SubP3EmailTextBox2, #SubP3EmailTextBox, #SubP3NationalityDropDownList, #SubP3DOB, #SubP3LnameTextBox, #SubP3FnameTextBox, #SubP3TitleDropDownList,
        #TextBoxSP4ID, #TextBoxSP4IDType, #SubP4AMobileTextBox, #SubP4CCDropDownList2, #SubP4MobileTextBox, #SubP4CCDropDownList, #TextSP4Age,#TextBoxChargeBack,
        #SubP4CountryDropDownList, #SubP4EmailTextBox2, #SubP4EmailTextBox, #SubP4NationalityDropDownList, #SubP4DOB, #SubP4LnameTextBox,#tourdatedatepicker,
        #deckcheckouttimeTextBox, #deckcheckintimeTextBox, #checkoutdatedatepicker, #checkindatedatepicker, #roomnoTextBox, #hotelTextBox ,#TextBoxGPrice2, 
        #vouchernoTextBox2, #giftoptionDropDownList2, #TextBoxGPrice3, #vouchernoTextBox3, #giftoptionDropDownList3, #TextBoxGPrice4, #vouchernoTextBox4,#subGroup,
        #giftoptionDropDownList4, #TextBoxGPrice5, #vouchernoTextBox5, #giftoptionDropDownList5, #TextBoxGPrice6, #vouchernoTextBox6, #giftoptionDropDownList6,
        #TextBoxGPrice7, #vouchernoTextBox7, #giftoptionDropDownList7,#QStatusDropDownList1,#gueststatusDropDownList,#commentTextBox,#TaxiRefOutTextBox,#TaxiPriceOutTextBox,
        #SubP4FnameTextBox, #SubP4TitleDropDownList,#giftoptionDropDownList,#vouchernoTextBox,#TextBoxGPrice1,#salesrepDropDownList,#TaxiRefInTextBox,#taxipriceInTextBox {
            height: 28px;
            font-size: 12px;
           
        }
        #pfnameTextBox,#plnameTextBox,#TextBoxPrimIDType,#sfnameTextBox,#slnameTextBox,#TextBoxSecoIDType,
        #address1TextBox,#address2TextBox,#maledesgTextBox,#femaledesgTextBox,#stateTextBox,#cityTextBox,
        #sp1fnameTextBox,#sp1lnameTextBox,#TextBoxSP1IDType,#sp2fnameTextBox,#sp2lnameTextBox,#TextBoxSP2IDType,
        #SubP3FnameTextBox,#SubP3LnameTextBox,#TextBoxSP3IDType,#SubP4FnameTextBox,#SubP4LnameTextBox,#TextBoxSP4IDType,
        #hotelTextBox,#TextBoxChargeBack,#TaxiRefInTextBox,#TaxiRefOutTextBox,#commentTextBox,#comment2{
        text-transform:uppercase;
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

        var l = 1;

        function f() {
            //var p = 1;
            l++;
            //alert(l);
            var s = 'item88s' + l;
            var p = 'item88p' + l;
            var q = 'item88q' + l;
            //alert('kkk');
          //--  document.getElementById(s).style.display = "block";
          //--  document.getElementById(p).style.display = "block";
            //-- document.getElementById(q).style.display = "block";
            $("." + s).show();
            $("." + p).show();
            $("." + q).show();

            //alert('kkk');
            if (l == '7') {
                document.getElementById("bittu").style.display = "none";
                //alert('kkk');
            }

        }
        function topFunction2() {
            //alert('hi');

            window.location.href = "CreateProfile1.aspx";


        }
        function pele(kk) {
            alert(kk);
            // window.location.href("Dashboard.aspx");
            topFunction2();
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
    </script>

     <script>
        //for venue
         $(document).ready(function () {

             $(".item23").hide();
             $(".item24").hide();


             $(".item21").hide();
             $(".item22").hide();
             $(".item212").hide();

            $("#VenueCountryDropDownList").change(function () {

                var id = $("#VenueCountryDropDownList").val();
                // alert(id);
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateVenueDropDownList",
                    data: "{'id': '" + id + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        $("#VenueDropDownList").empty();
                        $("#VenueDropDownList").append("<option value=''>Select an Option</option>");

                      
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


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/PopulatePriTitleDropDownList',
                    data: "{'countryName':'" + id + "'}",
                    async: false,
                    success: function (data) {
                        //  alert(data.d);
                        $("#primarytitleDropDownList").empty();
                        $("#primarytitleDropDownList").append("<option value=''>Select an Option</option>");
                       
                        $("#secondarytitleDropDownList").empty();
                        $("#secondarytitleDropDownList").append("<option value=''>Select an Option</option>");

                        $("#subprofile1titleDropDownList").empty();
                        $("#subprofile1titleDropDownList").append("<option value=''>Select an Option</option>");

                        $("#subprofile2titleDropDownList").empty();
                        $("#subprofile2titleDropDownList").append("<option value=''>Select an Option</option>");

                        $("#SubP3TitleDropDownList").empty();
                        $("#SubP3TitleDropDownList").append("<option value=''>Select an Option</option>");

                        $("#SubP4TitleDropDownList").empty();
                        $("#SubP4TitleDropDownList").append("<option value=''>Select an Option</option>");
                        
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#primarytitleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#secondarytitleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#subprofile1titleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#subprofile2titleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#SubP3TitleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#SubP4TitleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/PopulateNationalityDropDownList',
                    data: "{'countryName':'" + id + "'}",
                    async: false,
                    success: function (data) {
                        //  alert(data.d);
                        $("#primarynationalityDropDownList").empty();
                        $("#primarynationalityDropDownList").append("<option value=''>Select an Option</option>");
                        $("#PrimaryCountryDropDownList").empty();

                        $("#secondarynationalityDropDownList").empty();
                        $("#secondarynationalityDropDownList").append("<option value=''>Select an Option</option>");
                        $("#SecondaryCountryDropDownList").empty();
                       

                        $("#subprofile1nationalityDropDownList").empty();
                        $("#subprofile1nationalityDropDownList").append("<option value=''>Select an Option</option>");
                        $("#SubProfile1CountryDropDownList").empty();


                        $("#subprofile2nationalityDropDownList").empty();
                        $("#subprofile2nationalityDropDownList").append("<option value=''>Select an Option</option>");
                        $("#SubProfile2CountryDropDownList").empty();

                        $("#SubP3NationalityDropDownList").empty();
                        $("#SubP3NationalityDropDownList").append("<option value=''>Select an Option</option>");
                        $("#SubP3CountryDropDownList").empty();

                        $("#SubP4NationalityDropDownList").empty();
                        $("#SubP4NationalityDropDownList").append("<option value=''>Select an Option</option>");
                        $("#SubP4CountryDropDownList").empty();
                       
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#primarynationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#secondarynationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#subprofile1nationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                                $("#subprofile2nationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#SubP3NationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#SubP4NationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/PopulateAddressCountryDropDownList',
                    data: "{'countryName':'" + id + "'}",
                    async: false,
                    success: function (data) {
                        //  alert(data.d);
                        $("#AddCountryDropDownList").empty();
                        $("#AddCountryDropDownList").append("<option value=''>Select an Option</option>");
                      

                    
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#AddCountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/PopulateGiftOptionDropDownList',
                    data: "{'countryName':'" + id + "'}",
                    async: false,
                    success: function (data) {
                        //  alert(data.d);
                        $("#giftoptionDropDownList").empty();
                        $("#giftoptionDropDownList").append("<option value=''>Select an Option</option>");

                        $("#giftoptionDropDownList2").empty();
                        $("#giftoptionDropDownList2").append("<option value=''>Select an Option</option>");

                        $("#giftoptionDropDownList3").empty();
                        $("#giftoptionDropDownList3").append("<option value=''>Select an Option</option>");

                        $("#giftoptionDropDownList4").empty();
                        $("#giftoptionDropDownList4").append("<option value=''>Select an Option</option>");

                        $("#giftoptionDropDownList5").empty();
                        $("#giftoptionDropDownList5").append("<option value=''>Select an Option</option>");

                        $("#giftoptionDropDownList6").empty();
                        $("#giftoptionDropDownList6").append("<option value=''>Select an Option</option>");

                        $("#giftoptionDropDownList7").empty();
                        $("#giftoptionDropDownList7").append("<option value=''>Select an Option</option>");

                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#giftoptionDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#giftoptionDropDownList2").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#giftoptionDropDownList3").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#giftoptionDropDownList4").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#giftoptionDropDownList5").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#giftoptionDropDownList6").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#giftoptionDropDownList7").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });


                return false;


            });

        });


        $(document).ready(function () {
            $("#VenueDropDownList").change(function () {
                var id = $("#VenueDropDownList").val();

                var id2 = $("#VenueCountryDropDownList").val();

                //alert(id+"   "+id2);
                //-- document.getElementById("itemFly").style.display = "none";
            //--    document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                //loadQStatus();
               //-- document.getElementById("QStatusDropDownList1").selectedIndex = "0";

                //--document.getElementById("item9a1").style.display = "none";


                //--document.getElementById("item9a2").style.display = "none";

                //--document.getElementById("item9a3").style.display = "none";

                //--document.getElementById("item9a4").style.display = "none";

                //--document.getElementById("item9b").style.display = "none";

                //--document.getElementById("item9").style.display = "grid";



                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateVenueGroupDropDownList",
                    data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        $("#GroupVenueDropDownList").empty();
                        $("#GroupVenueDropDownList").append("<option value=''>Select an Option</option>");
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



                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadManagersOnVenue',
                    data: "{'venueCountry':'" + id2 + "','venue':'" + id + "'}",
                    async: false,
                    success: function (data) {
                        //   alert(data.d);
                        $("#ManagerDropDownList").empty();
                        $("#ManagerDropDownList").append("<option value=''>Select an Option</option>")
                        subJson = JSON.parse(data.d);

                        //alert(subJson);
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
            //flychange();

        });


        $(document).ready(function () {
            $("#GroupVenueDropDownList").change(function () {
               
                // alert('hi');
                var id = $("#GroupVenueDropDownList option:selected").text();

               

                var id2 = $("#VenueCountryDropDownList").val();

                var id3 = $("#VenueDropDownList option:selected").text();


                if (id2 == "India" && id == "Coldline" || id2 == "India" && id == "COLDLINE") {

                    $(".item12").show();
                }
                else {
                    $(".item12").hide();
                }

                //alert (id+'   '+id2+'  '+id3);
                //if ((id == "Flybuy" && id3 != "Inhouse") || (id == "FLYBUY" && id3 != "Inhouse")) {
                if (id2 == "Indonesia" && id == "Flybuy" || id2 == "Indonesia" && id == "FLYBUY") {
                    // alert('hi');
                    $(".itemFly").show();
                    $(".item9a1").show();
                    $(".item9a2").show();
                    $(".item9a3").show();
                    $(".item9a4").show();

                    //--   document.getElementById("item9a1").style.display = 'block';
                    // document.getElementById("item9").style.display = "none";
                    //-- document.getElementById("item9a2").style.display = 'block';
                    //-- document.getElementById("item9a3").style.display = 'block';
                    //-- document.getElementById("item9a4").style.display = 'block';
                    // document.getElementById("item8").style.display = "none";
                 document.getElementById("gueststatusDropDownList").selectedIndex = "4";
                loadQStatus();
                 document.getElementById("QStatusDropDownList1").selectedIndex = "2";


                    $(".item9b").hide();
                    $(".item9").show();
                    //--  document.getElementById("item9b").style.display = 'none';
                    //-- document.getElementById("item9").style.display = 'block';

                    //$('#gueststatusDropDownList').val('2');
                }
                else if (id2 == "Indonesia" && id == "Coldline" || id2 == "Indonesia" && id == "COLDLINE") {
                    $(".item9b").show();
                    $(".item9").hide();
                    $(".itemFly").hide();
                    $(".item9a1").hide();
                    $(".item9a2").hide();
                    $(".item9a3").hide();
                    $(".item9a4").hide();
                    //--  document.getElementById("item9b").style.display = "block";
                    //-- document.getElementById("item9").style.display = "none";
                    //-- document.getElementById("itemFly").style.display = "none";
                  document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                 loadQStatus();
              document.getElementById("QStatusDropDownList1").selectedIndex = "0";
                    //-- document.getElementById("item9a1").style.display = "none";
                    //-- document.getElementById("item9a2").style.display = "none";
                    //-- document.getElementById("item9a3").style.display = "none";
                    //-- document.getElementById("item9a4").style.display = "none";
                    // document.getElementById("item9").style.display = "grid";
                    // document.getElementById("item8").style.display = "grid";

                }
                else {
                    if (id2 == "India" || id2 == "INDIA") {
                        $(".item9b").hide();
                        $(".item9").hide();
                    } else {
                        $(".item9b").hide();
                        $(".item9").show();

                    }
                    //--  document.getElementById("item9b").style.display = "none";
                    //--  document.getElementById("item9").style.display = "block";
                    //--  document.getElementById("itemFly").style.display = "none";
                    //   document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                     loadQStatus();
                    //   document.getElementById("QStatusDropDownList1").selectedIndex = "0";
                    //--   document.getElementById("item9a1").style.display = "none";
                    //--  document.getElementById("item9a2").style.display = "none";
                    //--  document.getElementById("item9a3").style.display = "none";
                    //-- document.getElementById("item9a4").style.display = "none";
                }
                //alert('by ');
                //for sales rep to populate according to venue

              


                // to load sub venue
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateSubVenueGroupDropDownList",
                    data: "{'venueid': '" + id + "','countid' : '" + id2 + "','venue':'"+id3+"'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        //alert(data);
                        $("#VenueDropDownList2").empty();
                        $("#VenueDropDownList2").append("<option value=''>Select an Option</option>");
                        jsdata = JSON.parse(data.d);
                        //alert(jsdata);
                        $.each(jsdata, function (key, value) {

                            $("#VenueDropDownList2").append($("<option></option>").val(value.SubVenueGroupTypeName).html(value.SubVenueGroupTypeName));

                        });
                    },
                    //called on jquery ajax call failure
                    error: function () {
                        alert('error11');
                    }
                });



                // alert('buntu');
                if(id2=="India" || id2=="INDIA"){
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "CreateProfile1.aspx/PopulateMrktProgDropDownList",
                        data: "{'venueGroupid': '" + id + "','countid' : '" + id2 + "','venueid':'" + id3 + "'}",
                        dataType: "json",
                        //called on jquery ajax call success
                        success: function (data) {
                            $("#MarketingPrgmDropDownList").empty();
                            $("#MarketingPrgmDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            // alert(jsdata);
                            $.each(jsdata, function (key, value) {

                                $("#MarketingPrgmDropDownList").append($("<option></option>").val(value.Marketing_Program_abbrv).html(value.MrktProgTypeName));
                                
                            });
                        },
                        //called on jquery ajax call failure
                        error: function () {
                            alert('error');
                        }
                    });
                }else{
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "CreateProfile1.aspx/PopulateMrktProgDropDownList",
                        data: "{'venueGroupid': '" + id + "','countid' : '" + id2 + "','venueid':'" + id3 + "'}",
                        dataType: "json",
                        //called on jquery ajax call success
                        success: function (data) {
                            $("#MarketingPrgmDropDownList").empty();
                            $("#MarketingPrgmDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            // alert(jsdata);
                            $.each(jsdata, function (key, value) {

                                $("#MarketingPrgmDropDownList").append($("<option></option>").val(value.MrktProgTypeName).html(value.MrktProgTypeName));

                            });
                        },
                        //called on jquery ajax call failure
                        error: function () {
                            alert('error');
                        }
                    });
        }
               

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadAgentsOnVenuegrp',
                    data: "{'venueCountry':'" + id2 + "','vgrp':'" + id + "','venue':'" + id3 + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#AgentsDropDownListInd").empty();
                        $("#AgentsDropDownListInd").append("<option value=''>Select an Option</option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#AgentsDropDownListInd").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }

                });

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadTOOnVenueNVGrp',
                    data: "{'venueCountry':'" + id2 + "','vgrp':'" + id + "','venue':'" + id3 + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#TONameDropDownList").empty();
                        $("#TONameDropDownList").append("<option value=''>Select an Option</option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#TONameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/SalesRepTypeList",
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
             
                return false;


            });

        });

        $(document).ready(function () {
            $("#MarketingPrgmDropDownList").change(function () {
                //alert("hi2");
                var marketingText = $("#MarketingPrgmDropDownList option:selected").text();
                $("#TextBox2").val(marketingText);

                // al();
                var id = $("#MarketingPrgmDropDownList").val();

                var id2 = $("#GroupVenueDropDownList").val();


                var id3 = $("#VenueCountryDropDownList").val();

                // alert(id );

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateAgentDropDownList",
                    data: "{'markid': '" + id + "','venueid': '" + id2 + "','countid': '" + id3 + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        $("#AgentsDropDownList").empty();
                        $("#AgentsDropDownList").append("<option value=''>Select an Option</option>");
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
                // alert("hi");
                var id = $("#AgentsDropDownList").val();

                var id2 = $("#MarketingPrgmDropDownList").val();

                var id3 = $("#GroupVenueDropDownList").val();

                // alert(id + "   " + id2+"  "+id3);

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateAgentCodeDropDownList",
                    data: "{'markid': '" + id2 + "','agentid':'" + id + "','venueid':'" + id3 + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        $("#AgentCodeDropDownList").empty();
                        $("#AgentCodeDropDownList").append("<option value=''>Select an Option</option>");
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



            $("#primarynationalityDropDownList").change(function () {

                var countryID = $("#VenueCountryDropDownList").val();
                // alert("hi");
                var id = $("#primarynationalityDropDownList option:selected").text();

                var id1 = $("#primarynationalityDropDownList option:selected").text();
                // alert(id);
                //    alert(id1);

                // alert(id + "   " + id2);

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateCountryCodeDropDownList",
                    data: "{'Countid': '" + id + "','countryID':'" + countryID + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        if(countryID=="India" || countryID=="INDIA"){
                            $("#PrimaryCountryDropDownList").empty();
                            $("#PrimaryCountryDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#PrimaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        } else {
                            $("#PrimaryCountryDropDownList").empty();
                            //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#PrimaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        }
                      
                    },
                    //called on jquery ajax call failure
                    error: function () {
                        alert('error');
                    }
                });


                var groupVenue = $("#GroupVenueDropDownList").val();
                var venue = $("#VenueDropDownList").val();
                var SubVenue = $("#VenueDropDownList2").val();
                //  alert(groupVenue);
                //  alert(venue);

                if (venue == "Jimbaran Sales Deck" && groupVenue == "Coldline" && SubVenue != "KCV1" || venue == "JIMBARAN SALES DECK" && groupVenue == "COLDLINE" && SubVenue != "KCV1") {

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "CreateProfile1.aspx/PopulateSubVenueOnNationality",
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
                    //return false;
                } else {

                }

            });


            $("#secondarynationalityDropDownList").change(function () {
                //alert("hi");

                var countryID = $("#VenueCountryDropDownList").val();
                var id = $("#secondarynationalityDropDownList").val();

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateCountryCodeDropDownList",
                    data: "{'Countid': '" + id + "','countryID': '" + countryID + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        if (countryID == "India" || countryID == "INDIA") {
                            $("#SecondaryCountryDropDownList").empty();
                            $("#SecondaryCountryDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SecondaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        } else {
                            $("#SecondaryCountryDropDownList").empty();
                            //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SecondaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        }

                    },
                    //called on jquery ajax call failure
                    error: function () {
                        alert('error');
                    }
                });
                return false;


            });

           
            $("#subprofile1nationalityDropDownList").change(function () {
                //alert("hi");

                var countryID = $("#VenueCountryDropDownList").val();
                var id = $("#subprofile1nationalityDropDownList").val();

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateCountryCodeDropDownList",
                    data: "{'Countid': '" + id + "','countryID': '" + countryID + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        if (countryID == "India" || countryID == "INDIA") {
                            $("#SubProfile1CountryDropDownList").empty();
                            $("#SubProfile1CountryDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubProfile1CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        } else {
                            $("#SubProfile1CountryDropDownList").empty();
                            //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubProfile1CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        }

                    },
                    //called on jquery ajax call failure
                    error: function () {
                        alert('error');
                    }
                });
                return false;


            });


            $("#subprofile2nationalityDropDownList").change(function () {
                //alert("hi");

                var countryID = $("#VenueCountryDropDownList").val();
                var id = $("#subprofile2nationalityDropDownList").val();

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateCountryCodeDropDownList",
                    data: "{'Countid': '" + id + "','countryID': '" + countryID + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        if (countryID == "India" || countryID == "INDIA") {
                            $("#SubProfile2CountryDropDownList").empty();
                            $("#SubProfile2CountryDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubProfile2CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        } else {
                            $("#SubProfile2CountryDropDownList").empty();
                            //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubProfile2CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        }

                    },
                    //called on jquery ajax call failure
                    error: function () {
                        alert('error');
                    }
                });
                return false;


            });


            $("#SubP3NationalityDropDownList").change(function () {
                //alert("hi");

                var countryID = $("#VenueCountryDropDownList").val();
                var id = $("#SubP3NationalityDropDownList").val();

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateCountryCodeDropDownList",
                    data: "{'Countid': '" + id + "','countryID': '" + countryID + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        if (countryID == "India" || countryID == "INDIA") {
                            $("#SubP3CountryDropDownList").empty();
                            $("#SubP3CountryDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubP3CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        } else {
                            $("#SubP3CountryDropDownList").empty();
                            //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubP3CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        }

                    },
                    //called on jquery ajax call failure
                    error: function () {
                        alert('error');
                    }
                });
                return false;


            });


            $("#SubP4NationalityDropDownList").change(function () {
                //alert("hi");

                var countryID = $("#VenueCountryDropDownList").val();
                var id = $("#SubP4NationalityDropDownList").val();

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "CreateProfile1.aspx/PopulateCountryCodeDropDownList",
                    data: "{'Countid': '" + id + "','countryID': '" + countryID + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        if (countryID == "India" || countryID == "INDIA") {
                            $("#SubP4CountryDropDownList").empty();
                            $("#SubP4CountryDropDownList").append("<option value=''>Select an Option</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubP4CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        } else {
                            $("#SubP4CountryDropDownList").empty();
                            //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $("#SubP4CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                            });
                        }

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
            $("#PrimaryCountryDropDownList").change(function () {
                var value = $("#PrimaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#primarymobileDropDownList").empty();
                        //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                        
                        $("#primaryalternateDropDownList").empty();
                        $("#primaryalternateDropDownList").append("<option value=''>Select an Option</option>");

                        $("#phomecodeDropDownList").empty();
                        $("#phomecodeDropDownList").append("<option value=''>Select an Option</option>");

                        $("#pofficecodeDropDownList").empty();
                        $("#pofficecodeDropDownList").append("<option value=''>Select an Option</option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#primaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#phomecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#pofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });



            $("#SecondaryCountryDropDownList").change(function () {
                var value = $("#SecondaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {
                      
                        $("#secondarymobileDropDownList").empty();
                        $("#secondarymobileDropDownList").append("<option value=''>select an option  </option>")

                        $("#secondaryalternateDropDownList").empty();
                        $("#secondaryalternateDropDownList").append("<option value=''>select an option  </option>")

                        $("#shomecodeDropDownList").empty();
                        $("#shomecodeDropDownList").append("<option value=''>select an option  </option>")

                        $("#sofficecodeDropDownList").empty();
                        $("#sofficecodeDropDownList").append("<option value=''>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#secondaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#shomecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#sofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }

                });
                return false;
            });



            $("#SubProfile1CountryDropDownList").change(function () {
                var value = $("#SubProfile1CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {
                       
                        $("#subprofile1mobileDropDownList").empty();
                        $("#subprofile1mobileDropDownList").append("<option value=''>select an option  </option>");

                        $("#subprofile1alternateDropDownList").empty();
                        $("#subprofile1alternateDropDownList").append("<option value=''>select an option  </option>");

                      
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#subprofile1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                               
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }

                });
                return false;
            });


            $("#SubProfile2CountryDropDownList").change(function () {
                var value = $("#SubProfile2CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile2mobileDropDownList").empty();
                        $("#subprofile2mobileDropDownList").append("<option value=''>select an option  </option>");

                        $("#subprofile2alternateDropDownList").empty();
                        $("#subprofile2alternateDropDownList").append("<option value=''>select an option  </option>");


                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#subprofile2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }

                });
                return false;
            });


           
            $("#SubP3CountryDropDownList").change(function () {
                var value = $("#SubP3CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#SubP3CCDropDownList").empty();
                        $("#SubP3CCDropDownList").append("<option value=''>select an option  </option>");

                        $("#SubP3CCDropDownList2").empty();
                        $("#SubP3CCDropDownList2").append("<option value=''>select an option  </option>");


                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#SubP3CCDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#SubP3CCDropDownList2").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }

                });
                return false;
            });



            $("#SubP4CountryDropDownList").change(function () {
                var value = $("#SubP4CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#SubP4CCDropDownList").empty();
                        $("#SubP4CCDropDownList").append("<option value=''>select an option  </option>");

                        $("#SubP4CCDropDownList2").empty();
                        $("#SubP4CCDropDownList2").append("<option value=''>select an option  </option>");


                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#SubP4CCDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                $("#SubP4CCDropDownList2").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }

                });
                return false;
            });

            $("#AddCountryDropDownList").change(function () {

                var value = $("#AddCountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadStates',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#StateDropDownList").empty();
                        $("#StateDropDownList").append("<option value=''>Select an Option</option>")
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#StateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;



            });



            $("#MarketingPrgmDropDownList").change(function () {

                var marketingValue = $("#MarketingPrgmDropDownList").val();
                //alert(marketingValue);
                if (marketingValue == "OWNER" || marketingValue == "Owner" || marketingValue == "owner") {


                    $(".item21").show();
                    $(".item22").show();
                    $(".item212").hide();
                }
                else {
                    $(".item21").show();
                    $(".item22").hide();
                    $(".item212").show();

                }


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'CreateProfile1.aspx/LoadTypes',
                    data: "{}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#TypeDropDownList").empty();
                        $("#TypeDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#TypeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong Types");
                    }



                });
                return false;


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
                                  <div class="container-fluid">
                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <label for="sel1" style="color: #73879C;">PROFILE</label></div>
                                      </div>

                                      <div class="row">
                                            <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 dummy" style="display:none;">
                                              <div class="form-group">
                                                  <label for="sel1">:</label>
                                                  <asp:TextBox ID="TextBox2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

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
                                                  <label for="sel1">Date Insert:</label>
                                                  <asp:TextBox ID="TextBox1" Enabled="True" class="form-control pull-right" runat="server" ReadOnly="true"></asp:TextBox>
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
                                                  <asp:DropDownList ID="VenueCountryDropDownList" class="form-control pull-right" runat="server">
                                                        <asp:ListItem Value="">Select an Option</asp:ListItem>
                                                  </asp:DropDownList>
                                                  
                                              </div>
                                          </div>

                                            <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item4b">
                                              <div class="form-group">
                                                  <label for="sel1">Sub Venue Group:</label>
                                                  <asp:DropDownList ID="subGroup" class="form-control pull-right" runat="server">
                                                        <asp:ListItem Value="">Select an Option</asp:ListItem>
                                                       <asp:ListItem Value="ODYSSEY">ODYSSEY</asp:ListItem>
                                                       <asp:ListItem Value="COLLECTIONS">COLLECTIONS</asp:ListItem>
                                                       <asp:ListItem Value="MC">MC</asp:ListItem>
                                                  </asp:DropDownList>
                                                  
                                              </div>
                                          </div>

                                           <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item4bb">
                                              <div class="form-group">
                                                  <label for="sel1">Lead Office:</label>
                                                  <asp:DropDownList ID="leadOffice" class="form-control pull-right" runat="server">
                                                        <asp:ListItem Value="">Select an Option</asp:ListItem>
                                                     
                                                  </asp:DropDownList>
                                                  
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

                                         <%--  <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item6b">
                                              <div class="form-group">
                                                  <label for="sel1">Sub Venue:</label>
                                                  <asp:DropDownList ID="subVenueIndia" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>--%>

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

                                          
                                           <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item10">
                                              <div class="form-group">
                                                  <label for="sel1">Agents:</label>
                                                  <asp:DropDownList ID="AgentsDropDownListInd" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item11">
                                              <div class="form-group">
                                                  <label for="sel1">To Name:</label>
                                                  <asp:DropDownList ID="TONameDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item12">
                                              <div class="form-group">
                                                  <label for="sel1">Manager:</label>
                                            <asp:DropDownList ID="ManagerDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 chs">
                                              <div class="form-group">
                                                  <input id="chs" type="checkbox" />
                                                  <label for="sel1">Are you a Member?</label>
                                              </div>
                                          </div>

                                      </div>

                                      <div class="row" id="hidden1">
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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item212">
                                              <div class="form-group">
                                                  <label for="sel1">Type:</label>
                                                  <asp:DropDownList ID="TypeDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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
                                  <div class="container-fluid">
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

                                       

                                      <div class="row">
                                           <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item311age">
                                              <div class="form-group">
                                                  <label for="sel1">Age:</label>
                                                  <asp:TextBox ID="TextPrimaryAge" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
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

                                           <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item312Emp">
                                              <div class="form-group">
                                                  <label for="sel1">Employee Status:</label>
                                                  <asp:DropDownList ID="employmentstatusDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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

                                            <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item36">
                                              <div class="form-group">
                                                  <label for="sel1">Country:</label>
                                                  <asp:DropDownList ID="PrimaryCountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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


                                      </div>
                                   
                                      <br />
                                  
                                      <div class="row">
                                             <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemHome312">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="phomecodeDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemHome313">
                                              <div class="form-group">
                                                  <label for="sel1">Home Number:</label>
                                                  <asp:TextBox ID="phomenoTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                         
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item312">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="pofficecodeDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item313">
                                              <div class="form-group">
                                                  <label for="sel1">Office Number:</label>
                                                  <asp:TextBox ID="pofficenoTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                      </div>
                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 Primchs">
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

                                  <div class="container-fluid">
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
                                              <div class="input-group date" id="sdobdatepicker1" data-provide="datepicker">
                                                  <asp:TextBox ID="sdobdatepicker" class="form-control pull-right" Style="pointer-events: none;" runat="server" onchange="getAge('sdobdatepicker', 'TextSecondAge');"></asp:TextBox>
                                                  <div class="input-group-addon">
                                                      <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                  </div>
                                              </div>
                                          </div>

                                      </div>

                                      <div class="row">
                                          
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item411age">
                                              <div class="form-group">
                                                  <label for="sel1">Age:</label>
                                                  <asp:TextBox ID="TextSecondAge" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
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

                                           <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item412Emp">
                                              <div class="form-group">
                                                  <label for="sel1">Employee Status:</label>
                                                  <asp:DropDownList ID="SecondemploymentstatusDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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

                                           <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item46">
                                              <div class="form-group">
                                                  <label for="sel1">Country:</label>
                                                  <asp:DropDownList ID="SecondaryCountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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

                                      </div>
                                      <br />

                                      <div class="row">
                                          
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemHome412">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="shomecodeDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                        
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 itemHome4122">
                                              <div class="form-group">
                                                  <label for="sel1">Home Number:</label>
                                                   <asp:TextBox ID="shomenoTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>
                                         <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item412">
                                              <div class="form-group">
                                                  <label for="sel1">CCode:</label>
                                                  <asp:DropDownList ID="sofficecodeDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>
                                        
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item4122">
                                              <div class="form-group">
                                                  <label for="sel1">Office Number:</label>
                                                   <asp:TextBox ID="sofficenoTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                      </div>
                                      <br />

                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 Secochs">
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
                                  <div class="container-fluid">

                                      <div class="panel panel-default">
                                          <div class="panel-heading">
                                              <label for="sel1" style="color: #73879C;">ADDRESS</label>
                                          </div>

                                      </div>
 
                                      <div class="row">
                                          <div class="col-md-6 col-xs-12 col-sm-8 col-lg-6 item51">
                                              <div class="form-group">
                                                  <label for="sel1">Address Line1:</label>
                                                  <asp:TextBox ID="address1TextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-6 col-xs-12 col-sm-8 col-lg-6 item52">
                                              <div class="form-group">
                                                  <label for="sel1">Address Line2:</label>
                                                  <asp:TextBox ID="address2TextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                      </div>
                                     
                                      <br />

                                      <div class="row">

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item551">
                                              <div class="form-group">
                                                  <label for="sel1">Country:</label>
                                                  <asp:DropDownList ID="AddCountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>

                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item53">
                                              <div class="form-group">
                                                  <label for="sel1">State:</label>
                                                  <asp:TextBox ID="stateTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item53b">
                                              <div class="form-group">
                                                  <label for="sel1">State:</label>
                                                  <asp:DropDownList ID="StateDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item54">
                                              <div class="form-group">
                                                  <label for="sel1">City:</label>
                                                  <asp:TextBox ID="cityTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
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
                                      <div class="row" id="item577">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item578">
                                              <div class="form-group">
                                                  <label for="sel1">Primary Desig:</label>
                                                  <asp:TextBox ID="maledesgTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>

                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item579">
                                              <div class="form-group">
                                                  <label for="sel1">Secondary Desig:</label>
                                                  <asp:TextBox ID="femaledesgTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>

                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item377">
                                              <div class="form-group">
                                                  <label for="sel1">Primary Lang:</label>
                                                  <select multiple="multiple" name="primarylang" id="primarylang" style="display: none;">
                                                      <option value="English">English</option>
                                                      <option value="Hindi">Hindi</option>
                                                      <option value="Konkani">Konkani</option>
                                                      <option value="Marathi">Marathi</option>
                                                      <option value="Kannada">Kannada</option>
                                                      <option value="Malayam">Malayam</option>
                                                      <option value="Tamil">Tamil</option>
                                                      <option value="Telegu">Telegu</option>
                                                      <option value="French">French</option>
                                                      <option value="Portuguese">Portuguese</option>
                                                  </select>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item47b">
                                              <div class="form-group">
                                                  <label for="sel1">Secondary Lang:</label>
                                                  <select multiple="multiple" name="seclang" id="seclang" style="display: none;">
                                                      <option value="English">English</option>
                                                      <option value="Hindi">Hindi</option>
                                                      <option value="Konkani">Konkani</option>
                                                      <option value="Marathi">Marathi</option>
                                                      <option value="Kannada">Kannada</option>
                                                      <option value="Malayam">Malayam</option>
                                                      <option value="Tamil">Tamil</option>
                                                      <option value="Telegu">Telegu</option>
                                                      <option value="French">French</option>
                                                      <option value="Portuguese">Portuguese</option>
                                                  </select>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item600">
                                              <div class="form-group" id="hell">
                                                  <label for="sel1">Photo Identity:</label>
                                                  <select multiple="multiple" name="pidentity" id="pidentity" style="display: none;">
                                                      <option value="Membership Card">Membership Card</option>
                                                      <option value="Driving License">Driving License</option>
                                                      <option value="Pan Card">PAN Card</option>
                                                      <option value="Passport">Passport</option>
                                                      <option value="Adhar Card">Adhar Card</option>
                                                      <option value="Others">Others</option>
                                                  </select>
                                              </div>
                                          </div>

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item601">
                                              <div class="form-group">
                                                  <label for="sel1">Kind Of Card:</label>
                                                  <select multiple="multiple" name="card" id="card" style="display: none;">
                                                      <option value="T1">Titanium</option>
                                                      <option value="Platinum">Platinum</option>
                                                      <option value="Gold">Gold</option>
                                                      <option value="Silver">Silver</option>
                                                      <option value="Visa">Visa</option>
                                                      <option value="Mastercard">Mastercard</option>
                                                      <option value="Debit Card">Debit Card</option>
                                                      <option value="Others">Others</option>
                                                  </select>
                                              </div>
                                          </div>

                                      </div>

                                  </div>
                                  <br />
                                  <br />
                                  <div class="container-fluid">

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

                                               <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item611age">
                                                  <div class="form-group">
                                                      <label for="sel1">Age:</label>
                                                      <asp:TextBox ID="TextSP1Age" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
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

                                              
                                          
                                          </div>

                                          <br />

                                          <div class="row">
                                             <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item65">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="subprofile1nationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                             
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item66">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubProfile1CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 SP1chs">
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

                                  <div class="container-fluid">
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
                                                      <asp:TextBox ID="sp2dobdatepicker" class="form-control pull-right" Style="pointer-events: none;" runat="server" onchange="getAge('sp2dobdatepicker', 'TextSP2Age');"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
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

                                          </div>
                                          <br />

                                          <div class="row">
                                            <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item75">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="subprofile2nationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                            
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item76">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubProfile2CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 SP2chs">
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

                                  <div class="container-fluid">
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

                                               <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9sage">
                                                  <div class="form-group">
                                                      <label for="sel1">Age:</label>
                                                      <asp:TextBox ID="TextSP3Age" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
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

                                             
                                          </div>
                                          <br />

                                          <div class="row">
                                             <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s35">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="SubP3NationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>
                                            
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s36">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubP3CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 SP3chs">
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

                                  <div class="container-fluid">
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
                                                      <asp:TextBox ID="SubP4DOB" class="form-control pull-right" Style="pointer-events: none;" runat="server" onchange="getAge('SubP4DOB', 'TextSP4Age');"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
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
                                          </div>
                                          <br />

                                          <div class="row">
                                             <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s5">
                                                  <div class="form-group">
                                                      <label for="sel1">Nationality:</label>
                                                      <asp:DropDownList ID="SubP4NationalityDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
                                                  </div>
                                              </div>

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item9s4s6">
                                                  <div class="form-group">
                                                      <label for="sel1">Country:</label>
                                                      <asp:DropDownList ID="SubP4CountryDropDownList" class="form-control pull-right" runat="server"></asp:DropDownList>
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
                                  <div class="container-fluid">
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
                                                      <asp:TextBox ID="checkindatedatepicker" Style="pointer-events: none;" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>
                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item84">

                                                  <label for="sel1">Departure:</label>
                                                  <div class="input-group date" id="checkoutdatedatepicker1" data-provide="datepicker">
                                                      <asp:TextBox ID="checkoutdatedatepicker" Style="pointer-events: none;" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                                      <div class="input-group-addon">
                                                          <%--  <span class="glyphicon glyphicon-th" ></span>--%>
                                                      </div>
                                                  </div>
                                              </div>
                                             

                                              <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item85">
                                                  <div class="form-group">
                                                      <div>
                                                          <label for="sel1">Check-In Time:</label>
                                                          <asp:TextBox ID="deckcheckintimeTextBox" class="form-control pull-right" runat="server"></asp:TextBox>

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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88q1">
                                              <div class="form-group">
                                                  <label for="sel1">Gift Price:</label>
                                                  <asp:TextBox ID="TextBoxGPrice1" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice1');"></asp:TextBox>
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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88q2">
                                              <div class="form-group">
                                                  <label for="sel1">Gift Price:</label>
                                                  <asp:TextBox ID="TextBoxGPrice2" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice2');"></asp:TextBox>
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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88q3">
                                              <div class="form-group">
                                                  <label for="sel1">Gift Price:</label>
                                                  <asp:TextBox ID="TextBoxGPrice3" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice3');"></asp:TextBox>
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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88q4">
                                              <div class="form-group">
                                                  <label for="sel1">Gift Price:</label>
                                                  <asp:TextBox ID="TextBoxGPrice4" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice4');"></asp:TextBox>
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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88q5">
                                              <div class="form-group">
                                                  <label for="sel1">Gift Price:</label>
                                                  <asp:TextBox ID="TextBoxGPrice5" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice5');"></asp:TextBox>
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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88q6">
                                              <div class="form-group">
                                                  <label for="sel1">Gift Price:</label>
                                                  <asp:TextBox ID="TextBoxGPrice6" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice6');"></asp:TextBox>
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

                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item88q7">
                                              <div class="form-group">
                                                  <label for="sel1">Gift Price:</label>
                                                  <asp:TextBox ID="TextBoxGPrice7" Enabled="True" class="form-control pull-right" runat="server" onchange="pp('TextBoxGPrice7');"></asp:TextBox>
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
                                        
                                      </div>
                                      <br />
                                      <div class="row">
                                          <div class="col-md-2 col-xs-12 col-sm-8 col-lg-2 item8823">
                                              <label for="sel1">Tour Date:</label>
                                              <div class="input-group date" id="tourdatedatepicker1" data-provide="datepicker">
                                                  <asp:TextBox ID="tourdatedatepicker" Style="pointer-events: none;" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
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
                                            <div class="col-md-6 col-xs-12 col-sm-8 col-lg-6 item8821">
                                              <div class="form-group">
                                                  <label for="sel1">Comment if Any:</label>
                                                  <asp:TextBox ID="commentTextBox" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
                                              </div>
                                          </div>

                                          <div class="col-md-6 col-xs-12 col-sm-8 col-lg-6 item88cbb2">
                                              <div class="form-group">
                                                  <label for="sel1">Comment 2:</label>
                                                  <asp:TextBox ID="comment2" Enabled="True" class="form-control pull-right" runat="server"></asp:TextBox>
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
                                      <br />
                                      <br />
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
                                                  <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="Button1_Click" Text="Create Profile" />
                                              </div>
                                          </div>
                                          <div class="col-md-4 col-xs-12 col-sm-8 col-lg-4">
                                              <div class="form-group">
                                                  <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Save & Generate Doccument" OnClick="Button2_Click" />
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
                orientation: "bottom auto",
                autoclose: true
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
                    autoclose:true,
                    //startDate: new Date()
                  
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
         //   $("#hidden1").hide();
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
            $("#pdobdatepicker").change(function () {
                
                var date = $("#pdobdatepicker").val();
                 dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
               
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#TextPrimaryAge').val(age);
            });

            $("#sdobdatepicker").change(function () {

                var date = $("#sdobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));

                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#TextSecondAge').val(age);
            });
            $("#sp1dobdatepicker").change(function () {

                var date = $("#sp1dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));

                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#TextSP1Age').val(age);
            });

            $("#sp2dobdatepicker").change(function () {

                var date = $("#sp2dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));

                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#TextSP2Age').val(age);
            });

            $("#SubP3DOB").change(function () {

                var date = $("#SubP3DOB").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));

                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#TextSP3Age').val(age);
            });

            $("#SubP4DOB").change(function () {

                var date = $("#SubP4DOB").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));

                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#TextSP4Age').val(age);
            });
        });



        function shows(check, fiel) {
            var checkbox1 = document.getElementById(check);
            if (checkbox1.checked) {
                document.getElementById(fiel).style.display = "block";
            }
            else {
                document.getElementById(fiel).style.display = "none";
            }
        }

        function loadQStatus() {

            var v1 = document.getElementById("gueststatusDropDownList");
            var gueststat = v1.options[v1.selectedIndex].text;

            var vcountry = document.getElementById("VenueCountryDropDownList");
            var country = vcountry.options[vcountry.selectedIndex].text;

            // alert(gueststat);

            if(country=="India" || country == "INDIA"){
    
                $(".item8822qq").hide();

            }else{

                if (gueststat == 'Qualified') {
                    //-- document.getElementById('gs2').style.display = 'block';
                    //--  document.getElementById('QStatusDropDownList1').style.display = 'block';

                    $(".item8822qq").show();

                }
                else {
                    $(".item8822qq").hide();
                    //--    document.getElementById('gs2').style.display = 'none';
                    //--  document.getElementById('QStatusDropDownList1').style.display = 'none';
                }

        }


        }
    </script>

     <script>
         $(document).ready(function () {
             $("#Button1").click(function (e) {

                 var country = $("#VenueCountryDropDownList").val();
                 if(country=="India" || country =="INDIA"){

                     var isValid = true;
                     if ($.trim($("#MarketingPrgmDropDownList option:selected").text()) == '') {
                         isValid = false;
                         alert("Select Marketing Program");
                         $("#MarketingPrgmDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#MarketingPrgmDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#VenueDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Venue  ");
                         $("#VenueDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#VenueDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#GroupVenueDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Venue Group");
                         $("#GroupVenueDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#GroupVenueDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }


                     //primary profile

                     var isValid = true;
                     if ($.trim($("#primarytitleDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Title");
                         $("#primarytitleDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#primarytitleDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#pfnameTextBox").val()) == '') {
                         isValid = false;
                         alert("Enter First Name");
                         $("#pfnameTextBox").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#pfnameTextBox").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }


                     var isValid = true;
                     if ($.trim($("#primarynationalityDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Nationality");
                         $("#primarynationalityDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#primarynationalityDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }


                     var isValid = true;
                     if ($.trim($("#PrimaryCountryDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Country");
                         $("#PrimaryCountryDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#PrimaryCountryDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }




                     ////// Stay Details/////

                     var isValid = true;
                     if ($.trim($("#hotelTextBox").val()) == '') {
                         isValid = false;
                         alert("Enter Resort Name");
                         $("#hotelTextBox").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#hotelTextBox").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }


var venueGroup= $("#GroupVenueDropDownList option:selected").text();
                     if (venueGroup == "FlyBuy" || venueGroup == "FLYBUY") {

                         var isValid = true;
                         if ($.trim($("#leadOffice").val()) == '') {
                             isValid = false;
                             alert("select Lead Office");
                             $("#leadOffice").css({

                                 "border": "1px solid red",

                                 "background": "#FFCECE"
                             });
                             if (isValid == false)
                                 e.preventDefault();


                         } else {
                             $("#leadOffice").css({

                                 "border": "",

                                 "background": ""

                             });
                             // alert('Thank you for submitting');
                             //$("#TextBox1").val("");
                         }

                         var isValid = true;
                         if ($.trim($("#VenueDropDownList2").val()) == '') {
                             isValid = false;
                             alert("select Sub Venue");
                             $("#VenueDropDownList2").css({

                                 "border": "1px solid red",

                                 "background": "#FFCECE"
                             });
                             if (isValid == false)
                                 e.preventDefault();


                         } else {
                             $("#VenueDropDownList2").css({

                                 "border": "",

                                 "background": ""

                             });
                             // alert('Thank you for submitting');
                             //$("#TextBox1").val("");
                         }

                     } else if (venueGroup == "Inhouse" || venueGroup == "INHOUSE") {

                       

                         var isValid = true;
                         if ($.trim($("#VenueDropDownList2").val()) == '') {
                             isValid = false;
                             alert("select Sub Venue");
                             $("#VenueDropDownList2").css({

                                 "border": "1px solid red",

                                 "background": "#FFCECE"
                             });
                             if (isValid == false)
                                 e.preventDefault();


                         } else {
                             $("#VenueDropDownList2").css({

                                 "border": "",

                                 "background": ""

                             });
                             // alert('Thank you for submitting');
                             //$("#TextBox1").val("");
                         }
                     }


                 } else {
                     var isValid = true;
                     if ($.trim($("#MarketingPrgmDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Marketing Program");
                         $("#MarketingPrgmDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#MarketingPrgmDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#VenueDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Venue ");
                         $("#VenueDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#VenueDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#GroupVenueDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Venue Group");
                         $("#GroupVenueDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#GroupVenueDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#VenueDropDownList2").val()) == '') {
                         isValid = false;
                         alert("Select Sub Venue");
                         $("#VenueDropDownList2").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#VenueDropDownList2").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#AgentsDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Marketing Source");
                         $("#AgentsDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#AgentsDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#AgentsDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Marketing Source");
                         $("#AgentsDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#AgentsDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                     var isValid = true;
                     if ($.trim($("#plnameTextBox").val()) == '') {
                         isValid = false;
                         alert("Enter Last Name");
                         $("#plnameTextBox").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#plnameTextBox").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }


                     var isValid = true;
                     if ($.trim($("#primarynationalityDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Nationality");
                         $("#primarynationalityDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#primarynationalityDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }
                     
                     var isValid = true;
                     if ($.trim($("#primarynationalityDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Nationality");
                         $("#primarynationalityDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#primarynationalityDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }
                    

                     var isValid = true;
                     if ($.trim($("#deckcheckintimeTextBox").val()) == '') {
                         isValid = false;
                         alert("Select check in time");
                         $("#deckcheckintimeTextBox").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#deckcheckintimeTextBox").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }


                     var isValid = true;
                     if ($.trim($("#gueststatusDropDownList").val()) == '') {
                         isValid = false;
                         alert("Select Quest Status");
                         $("#gueststatusDropDownList").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#gueststatusDropDownList").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }


                     var isValid = true;
                     if ($.trim($("#tourdatedatepicker").val()) == '') {
                         isValid = false;
                         alert("Select Tour Date");
                         $("#tourdatedatepicker").css({

                             "border": "1px solid red",

                             "background": "#FFCECE"
                         });
                         if (isValid == false)
                             e.preventDefault();


                     } else {
                         $("#tourdatedatepicker").css({

                             "border": "",

                             "background": ""

                         });
                         // alert('Thank you for submitting');
                         //$("#TextBox1").val("");
                     }

                 }


      

            });

        });
       
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

      <script>

        ! function ($) {

        "use strict"; // jshint ;_;

        if (typeof ko !== 'undefined' && ko.bindingHandlers && !ko.bindingHandlers.multiselect) {
            ko.bindingHandlers.multiselect = {
                init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {},
                update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

                    var config = ko.utils.unwrapObservable(valueAccessor());
                    var selectOptions = allBindingsAccessor().options;
                    var ms = $(element).data('multiselect');

                    if (!ms) {
                        $(element).multiselect(config);
                    } else {
                        ms.updateOriginalOptions();
                        if (selectOptions && selectOptions().length !== ms.originalOptions.length) {
                            $(element).multiselect('rebuild');
                        }
                    }
                }
            };
        }

     
        function Multiselect(select, options) {

            this.options = this.mergeOptions(options);
            this.$select = $(select);

          
            this.originalOptions = this.$select.clone()[0].options;
            this.query = '';
            this.searchTimeout = null;

            this.options.multiple = this.$select.attr('multiple') === "multiple";
            this.options.onChange = $.proxy(this.options.onChange, this);
            this.options.onDropdownShow = $.proxy(this.options.onDropdownShow, this);
            this.options.onDropdownHide = $.proxy(this.options.onDropdownHide, this);

            // Build select all if enabled.
            this.buildContainer();
            this.buildButton();
            this.buildSelectAll();
            this.buildDropdown();
            this.buildDropdownOptions();
            this.buildFilter();

            this.updateButtonText();
            this.updateSelectAll();
            this.updateOptgroups();

            this.$select.hide().after(this.$container);
        };

        Multiselect.prototype = {

            defaults: {
               
                buttonText: function (options, select) {
                    if (options.length === 0) {
                        return this.nonSelectedText + ' <b class="caret"></b>';
                    } else {
                        if (options.length > this.numberDisplayed) {
                            return options.length + ' ' + this.nSelectedText + ' <b class="caret"></b>';
                        } else {
                            var selected = '';
                            options.each(function () {
                                var label = ($(this).attr('label') !== undefined) ? $(this).attr('label') : $(this).html();

                                selected += label + ', ';
                            });
                            return selected.substr(0, selected.length - 2) + ' <b class="caret"></b>';
                        }
                    }
                },
             
                buttonTitle: function (options, select) {
                    if (options.length === 0) {
                        return this.nonSelectedText;
                    } else {
                        var selected = '';
                        options.each(function () {
                            selected += $(this).text() + ', ';
                        });
                        return selected.substr(0, selected.length - 2);
                    }
                },
                
                label: function (element) {
                    return $(element).attr('label') || $(element).html();
                },
               
                onChange: function (option, checked) {

                },
               
                onDropdownShow: function (event) {

                },
               
                onDropdownHide: function (event) {

                },
                buttonClass: 'btn btn-default',
                dropRight: false,
                selectedClass: 'active',
                groupClass: 'multiselect-optgroup-item',
                clickableGroups: false,
                buttonWidth: 'auto',
                buttonContainer: '<div class="btn-group" />',
                // Maximum height of the dropdown menu.
                // If maximum height is exceeded a scrollbar will be displayed.
                maxHeight: false,
                includeSelectAllOption: false,
                selectAllText: ' Select all',
                selectAllValue: 'multiselect-all',
                enableFiltering: false,
                enableCaseInsensitiveFiltering: false,
                filterPlaceholder: 'Search',
                // possible options: 'text', 'value', 'both'
                filterBehavior: 'text',
                preventInputChangeEvent: false,
                nonSelectedText: 'Select!',
                nSelectedText: 'selected',
                numberDisplayed: 0
            },

            templates: {
                button: '<button type="button" style="width:150px; height:28px" class="multiselect dropdown-toggle" data-toggle="dropdown"></button>',
                ul: '<ul class="multiselect-container dropdown-menu"></ul>',
                filter: '<div class="input-group"><span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span><input class="form-control multiselect-search" type="text"></div>',
                li: '<div style="padding:0px 25px;"><li><a href="javascript:void(0);"><label></label></a></li></div>',
                divider: '<li class="divider"></li>',
                liGroup: '<li><label class="multiselect-group"></label></li>'
            },

            constructor: Multiselect,

            buildContainer: function () {
                this.$container = $(this.options.buttonContainer);
                this.$container.on('show.bs.dropdown', this.options.onDropdownShow);
                this.$container.on('hide.bs.dropdown', this.options.onDropdownHide);
            },

            buildButton: function () {
                this.$button = $(this.templates.button).addClass(this.options.buttonClass);

                // Adopt active state.
                if (this.$select.prop('disabled')) {
                    this.disable();
                } else {
                    this.enable();
                }

                // Manually add button width if set.
                if (this.options.buttonWidth && this.options.buttonWidth != 'auto') {
                    this.$button.css({
                        'width': this.options.buttonWidth
                    });
                }

                // Keep the tab index from the select.
                var tabindex = this.$select.attr('tabindex');
                if (tabindex) {
                    this.$button.attr('tabindex', tabindex);
                }

                this.$container.prepend(this.$button);
            },

            /**
             * Builds the ul representing the dropdown menu.
             */
            buildDropdown: function () {

                // Build ul.
                this.$ul = $(this.templates.ul);

                if (this.options.dropRight) {
                    this.$ul.addClass('pull-right');
                }

                // Set max height of dropdown menu to activate auto scrollbar.
                if (this.options.maxHeight) {
                    // TODO: Add a class for this option to move the css declarations.
                    this.$ul.css({
                        'max-height': this.options.maxHeight + 'px',
                        'overflow-y': 'auto',
                        'overflow-x': 'hidden'
                    });
                }

                this.$container.append(this.$ul);
            },

            /**
             * Build the dropdown options and binds all nessecary events.
             * Uses createDivider and createOptionValue to create the necessary options.
             */
            buildDropdownOptions: function () {

                this.$select.children().each($.proxy(function (index, element) {

                    // Support optgroups and options without a group simultaneously.
                    var tag = $(element).prop('tagName')
                        .toLowerCase();

                    if (tag === 'optgroup') {
                        this.createOptgroup(element);
                    } else if (tag === 'option') {

                        if ($(element).data('role') === 'divider') {
                            this.createDivider();
                        } else {
                            this.createOptionValue(element);
                        }

                    }

                    // Other illegal tags will be ignored.
                }, this));

                // Bind the change event on the dropdown elements.
                $('li input', this.$ul).on('change', $.proxy(function (event) {
                    var checked = $(event.target).prop('checked') || false;
                    var isSelectAllOption = $(event.target).val() === this.options.selectAllValue && this.$select[0][0].value === this.options.selectAllValue;
                    var optgroup = $(event.target).parents('label').attr('data-for');

                    // Apply or unapply the configured selected class.
                    if (this.options.selectedClass) {
                        if (checked) {
                            $(event.target).parents('li')
                                .addClass(this.options.selectedClass);
                        } else {
                            $(event.target).parents('li')
                                .removeClass(this.options.selectedClass);
                        }
                    }

                    // Get the corresponding option.
                    var value = $(event.target).val();
                    var $option = this.getOptionByValue(value);

                    var $optionsNotThis = $('option', this.$select).not($option);
                    var $checkboxesNotThis = $('input', this.$container).not($(event.target));

                    if (isSelectAllOption || optgroup) {
                        var values = [];

                        var $parent = this.$select;
                        if (optgroup) {
                            $parent = $parent.find("optgroup[label='" + optgroup + "']")
                        }

                        var options = $('option[value!="' + this.options.selectAllValue + '"]', $parent);
                        for (var i = 0; i < options.length; i++) {
                            // Additionally check whether the option is visible within the dropcown.
                            if (options[i].value !== this.options.selectAllValue && this.getInputByValue(options[i].value).is(':visible')) {
                                values.push(options[i].value);
                            }
                        }

                        if (checked) {
                            this.select(values);
                        } else {
                            this.deselect(values);
                        }
                    }

                    if (checked) {
                        $option.prop('selected', true);

                        if (this.options.multiple) {
                            // Simply select additional option.
                            $option.prop('selected', true);
                        } else {
                            // Unselect all other options and corresponding checkboxes.
                            if (this.options.selectedClass) {
                                $($checkboxesNotThis).parents('li').removeClass(this.options.selectedClass);
                            }

                            $($checkboxesNotThis).prop('checked', false);
                            $optionsNotThis.prop('selected', false);

                            // It's a single selection, so close.
                            this.$button.click();
                        }

                        if (this.options.selectedClass === "active") {
                            $optionsNotThis.parents("a").css("outline", "");
                        }
                    } else {
                        // Unselect option.
                        $option.prop('selected', false);
                    }

                    this.$select.change();
                    this.options.onChange($option, checked);

                    this.updateButtonText();
                    this.updateSelectAll();
                    this.updateOptgroups();

                    if (this.options.preventInputChangeEvent) {
                        return false;
                    }
                }, this));

                $('li a', this.$ul).on('touchstart click', function (event) {
                    event.stopPropagation();

                    if (event.shiftKey) {
                        var checked = $(event.target).prop('checked') || false;

                        if (checked) {
                            var prev = $(event.target).parents('li:last')
                                .siblings('li[class="active"]:first');

                            var currentIdx = $(event.target).parents('li')
                                .index();
                            var prevIdx = prev.index();

                            if (currentIdx > prevIdx) {
                                $(event.target).parents("li:last").prevUntil(prev).each(

                                function () {
                                    $(this).find("input:first").prop("checked", true)
                                        .trigger("change");
                                });
                            } else {
                                $(event.target).parents("li:last").nextUntil(prev).each(

                                function () {
                                    $(this).find("input:first").prop("checked", true)
                                        .trigger("change");
                                });
                            }
                        }
                    }

                    $(event.target).blur();
                });

                // Keyboard support.
                this.$container.on('keydown', $.proxy(function (event) {
                    if ($('input[type="text"]', this.$container).is(':focus')) {
                        return;
                    }
                    if ((event.keyCode === 9 || event.keyCode === 27) && this.$container.hasClass('open')) {

                        // Close on tab or escape.
                        this.$button.click();
                    } else {
                        var $items = $(this.$container).find("li:not(.divider):visible a");

                        if (!$items.length) {
                            return;
                        }

                        var index = $items.index($items.filter(':focus'));

                        // Navigation up.
                        if (event.keyCode === 38 && index > 0) {
                            index--;
                        }
                            // Navigate down.
                        else if (event.keyCode === 40 && index < $items.length - 1) {
                            index++;
                        } else if (!~index) {
                            index = 0;
                        }

                        var $current = $items.eq(index);
                        $current.focus();

                        if (event.keyCode === 32 || event.keyCode === 13) {
                            var $checkbox = $current.find('input');

                            $checkbox.prop("checked", !$checkbox.prop("checked"));
                            $checkbox.change();
                        }

                        event.stopPropagation();
                        event.preventDefault();
                    }
                }, this));
            },

           
            createOptionValue: function (element) {
                if ($(element).is(':selected')) {
                    $(element).prop('selected', true);
                }

                // Support the label attribute on options.
                var label = this.options.label(element);
                var value = $(element).val();
                var inputType = this.options.multiple ? "checkbox" : "radio";

                var $li = $(this.templates.li);
                $('label', $li).addClass(inputType);
                $('label', $li).append('<input type="' + inputType + '"  />');

                var selected = $(element).prop('selected') || false;
                var $checkbox = $('input', $li);
                $checkbox.val(value);

                if (value === this.options.selectAllValue) {
                    $checkbox.parent().parent()
                        .addClass('multiselect-all');
                }

                $('label', $li).append(" " + label);

                this.$ul.append($li);

                if ($(element).is(':disabled')) {
                    $checkbox.attr('disabled', 'disabled')
                        .prop('disabled', true)
                        .parents('li')
                        .addClass('disabled');
                }

                $checkbox.prop('checked', selected);

                if (selected && this.options.selectedClass) {
                    $checkbox.parents('li')
                        .addClass(this.options.selectedClass);
                }

                return $li;
            },

           
            createDivider: function (element) {
                var $divider = $(this.templates.divider);
                this.$ul.append($divider);
            },

            createOptgroup: function (group) {
                var groupName = $(group).prop('label');
                var inputType = this.options.multiple ? "checkbox" : "radio";

                // Add a header for the group.
                var $li = $(this.templates.liGroup);
                $('label', $li).addClass(inputType);
                $('label', $li).text(groupName).attr('data-for', groupName);
                if (this.options.multiple && this.options.clickableGroups) {
                    $('label', $li).prepend('<input type="' + inputType + '" /> ');
                    $li.wrapInner('<a>');
                }
                this.$ul.append($li);

                // Add the options of the group.
                $('option', group).each($.proxy(function (index, element) {
                    this.createOptionValue(element).addClass(this.options.groupClass);
                }, this));
            },

           
            buildSelectAll: function () {
                var alreadyHasSelectAll = this.hasSelectAll();

                // If options.includeSelectAllOption === true, add the include all checkbox.
                if (this.options.includeSelectAllOption && this.options.multiple && !alreadyHasSelectAll) {
                    this.$select.prepend('<option value="' + this.options.selectAllValue + '">' + this.options.selectAllText + '</option>');
                }
            },

           
            buildFilter: function () {

                // Build filter if filtering OR case insensitive filtering is enabled and the number of options exceeds (or equals) enableFilterLength.
                if (this.options.enableFiltering || this.options.enableCaseInsensitiveFiltering) {
                    var enableFilterLength = Math.max(this.options.enableFiltering, this.options.enableCaseInsensitiveFiltering);

                    if (this.$select.find('option').length >= enableFilterLength) {

                        this.$filter = $(this.templates.filter);
                        $('input', this.$filter).attr('placeholder', this.options.filterPlaceholder);
                        this.$ul.prepend(this.$filter);

                        this.$filter.val(this.query).on('click', function (event) {
                            event.stopPropagation();
                        }).on('input keydown', $.proxy(function (event) {
                            // This is useful to catch "keydown" events after the browser has updated the control.
                            clearTimeout(this.searchTimeout);

                            this.searchTimeout = this.asyncFunction($.proxy(function () {

                                if (this.query !== event.target.value) {
                                    this.query = event.target.value;

                                    $.each($('li', this.$ul), $.proxy(function (index, element) {
                                        var value = $('input', element).val();
                                        var text = $('label', element).text();

                                        if (value !== this.options.selectAllValue && text) {
                                            // by default lets assume that element is not
                                            // interesting for this search
                                            var showElement = false;

                                            var filterCandidate = '';
                                            if ((this.options.filterBehavior === 'text' || this.options.filterBehavior === 'both')) {
                                                filterCandidate = text;
                                            }
                                            if ((this.options.filterBehavior === 'value' || this.options.filterBehavior === 'both')) {
                                                filterCandidate = value;
                                            }

                                            if (this.options.enableCaseInsensitiveFiltering && filterCandidate.toLowerCase().indexOf(this.query.toLowerCase()) > -1) {
                                                showElement = true;
                                            } else if (filterCandidate.indexOf(this.query) > -1) {
                                                showElement = true;
                                            }

                                            if (showElement) {
                                                $(element).show();
                                            } else {
                                                $(element).hide();
                                            }
                                        }
                                    }, this));
                                }

                                // TODO: check whether select all option needs to be updated.
                            }, this), 300, this);
                        }, this));
                    }
                }
            },

           
            destroy: function () {
                this.$container.remove();
                this.$select.show();
            },

           
            refresh: function () {
                $('option', this.$select).each($.proxy(function (index, element) {
                    var $input = $('li input', this.$ul).filter(function () {
                        return $(this).val() === $(element).val();
                    });

                    if ($(element).is(':selected')) {
                        $input.prop('checked', true);

                        if (this.options.selectedClass) {
                            $input.parents('li')
                                .addClass(this.options.selectedClass);
                        }
                    } else {
                        $input.prop('checked', false);

                        if (this.options.selectedClass) {
                            $input.parents('li')
                                .removeClass(this.options.selectedClass);
                        }
                    }

                    if ($(element).is(":disabled")) {
                        $input.attr('disabled', 'disabled')
                            .prop('disabled', true)
                            .parents('li')
                            .addClass('disabled');
                    } else {
                        $input.prop('disabled', false)
                            .parents('li')
                            .removeClass('disabled');
                    }
                }, this));

                this.updateButtonText();
                this.updateSelectAll();
                this.updateOptgroups();
            },

            
            select: function (selectValues) {
                if (!$.isArray(selectValues)) {
                    selectValues = [selectValues];
                }

                for (var i = 0; i < selectValues.length; i++) {
                    var value = selectValues[i];

                    var $option = this.getOptionByValue(value);
                    var $checkbox = this.getInputByValue(value);

                    if (this.options.selectedClass) {
                        $checkbox.parents('li')
                            .addClass(this.options.selectedClass);
                    }

                    $checkbox.prop('checked', true);
                    $option.prop('selected', true);
                }

                this.updateButtonText();
            },

        
            deselect: function (deselectValues) {
                if (!$.isArray(deselectValues)) {
                    deselectValues = [deselectValues];
                }

                for (var i = 0; i < deselectValues.length; i++) {

                    var value = deselectValues[i];

                    var $option = this.getOptionByValue(value);
                    var $checkbox = this.getInputByValue(value);

                    if (this.options.selectedClass) {
                        $checkbox.parents('li')
                            .removeClass(this.options.selectedClass);
                    }

                    $checkbox.prop('checked', false);
                    $option.prop('selected', false);
                }

                this.updateButtonText();
            },

           
            rebuild: function () {
                this.$ul.html('');

                // Remove select all option in select.
                $('option[value="' + this.options.selectAllValue + '"]', this.$select).remove();

                // Important to distinguish between radios and checkboxes.
                this.options.multiple = this.$select.attr('multiple') === "multiple";

                this.buildSelectAll();
                this.buildDropdownOptions();
                this.buildFilter();

                this.updateButtonText();
                this.updateSelectAll();
                this.updateOptgroups();
            },

           
            dataprovider: function (dataprovider) {
                var optionDOM = "";
                dataprovider.forEach(function (option) {
                    optionDOM += '<option value="' + option.value + '">' + option.label + '</option>';
                });

                this.$select.html(optionDOM);
                this.rebuild();
            },

        
            enable: function () {
                this.$select.prop('disabled', false);
                this.$button.prop('disabled', false)
                    .removeClass('disabled');
            },

          
            disable: function () {
                this.$select.prop('disabled', true);
                this.$button.prop('disabled', true)
                    .addClass('disabled');
            },

         
            setOptions: function (options) {
                this.options = this.mergeOptions(options);
            },

         
            mergeOptions: function (options) {
                return $.extend({}, this.defaults, options);
            },

           
            hasSelectAll: function () {
                return this.$select[0][0] ? this.$select[0][0].value === this.options.selectAllValue : false;
            },

            
            updateSelectAll: function () {
                if (this.hasSelectAll()) {
                    var selected = this.getSelected();

                    if (selected.length === $('option:not([data-role=divider])', this.$select).length - 1) {
                        this.select(this.options.selectAllValue);
                    } else {
                        this.deselect(this.options.selectAllValue);
                    }
                }
            },

           
            updateOptgroups: function () {
                if (this.options.multiple && this.options.clickableGroups) {
                    $('optgroup', this.$select).each($.proxy(function (key, optgroup) {
                        var state = $('option', optgroup).length == $('option:selected', optgroup).length;

                        $("label[data-for='" + $(optgroup).prop('label') + "'] > input", this.$container)
                            .prop('checked', state)
                            .parents('li').toggleClass(this.options.selectedClass, state);
                    }, this));
                }
            },

         
            updateButtonText: function () {
                var options = this.getSelected();

                // First update the displayed button text.
                $('button', this.$container).html(this.options.buttonText(options, this.$select));

                // Now update the title attribute of the button.
                $('button', this.$container).attr('title', this.options.buttonTitle(options, this.$select));

            },

           
            getSelected: function () {
                return $('option[value!="' + this.options.selectAllValue + '"]:selected', this.$select).filter(function () {
                    return $(this).prop('selected');
                });
            },

           
            getOptionByValue: function (value) {
                return $('option', this.$select).filter(function () {
                    return $(this).val() === value;
                });
            },

           
            getInputByValue: function (value) {
                return $('li input', this.$ul).filter(function () {
                    return $(this).val() === value;
                });
            },

           
            updateOriginalOptions: function () {
                this.originalOptions = this.$select.clone()[0].options;
            },

            asyncFunction: function (callback, timeout, self) {
                var args = Array.prototype.slice.call(arguments, 3);
                return setTimeout(function () {
                    callback.apply(self || window, args);
                }, timeout);
            }
        };

        $.fn.multiselect = function (option, parameter) {
            return this.each(function () {
                var data = $(this).data('multiselect');
                var options = typeof option === 'object' && option;

                // Initialize the multiselect.
                if (!data) {
                    $(this).data('multiselect', (data = new Multiselect(this, options)));
                }

                // Call multiselect method.
                if (typeof option === 'string') {
                    data[option](parameter);
                }
            });
        };

        $.fn.multiselect.Constructor = Multiselect;

        $(function () {
            $("select[data-role=multiselect]").multiselect();
        });

        }(window.jQuery);

        $('.multiselect-group').before('<input type="checkbox" />');
        $(document).on('click', '.multiselect-group', function(event) {
            var checkAll = true;
            var $opts = $(this).parent().nextUntil(':has(.multiselect-group)'); 
            var $inactive = $opts.filter(':not(.active)'); 
            var $toggleMe = $inactive;
            if ($inactive.length == 0) { 
                $toggleMe = $opts;
                checkAll = false;
            }
            $toggleMe.find('input').click();
            $(this).parent().find('input').attr('checked', checkAll);
            event.preventDefault();
        });


        
        $(document).ready(function () {
            $('#primarylang').multiselect();
            $('#seclang').multiselect();
            $('#pidentity').multiselect();
            $('#card').multiselect();
            
        });
        
     

    </script>

           <script>

        $(document).ready(function () {

            $.ajax({

                type: 'Post',
                url: 'CreateProfile1.aspx/getAdminRights',
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
                    url: 'CreateProfile1.aspx/searchProfile',
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
                    url: 'CreateProfile1.aspx/getlink',
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

            $("#VenueCountryDropDownList").change(function () {

                var id = $("#VenueCountryDropDownList").val();
              
      
                if (id == "India" || id == "INDIA") {
                    $(".item5a").hide();
                    $(".item8").hide();
                    $(".item9").hide();
                    $(".item9b").hide();
                    $(".item10").show();
                    $(".item11").show();
                    $(".item12").show();
                    $(".item3a").hide();
                    $(".item9a1").hide();
                    $(".item9a2").hide();
                    $(".item9a3").hide();
                    $(".item9a4").hide();
                    $(".itemFly").hide();
                    $(".Primchs").hide();
                    $(".Prihidden").hide();
                    $(".item313").show();
                    $(".item312").show();
                    $(".itemHome313").show();
                    $(".itemHome312").show();
                    $(".item37a").show();
                    $(".item377").show();
                    $(".item47b").show();
                    $(".item47a").show();
                    $(".Secochs").hide();
                    $(".Sechidden").hide();
                    $(".item412").show();
                    $(".item4122").show();
                    $(".itemHome412").show();
                    $(".itemHome4122").show();

                    $("#item577").show();
                    $(".item53").hide();
                    $(".item53b").show();
                    $(".SP1chs").hide();
                    $(".SP2chs").hide();
                    $(".SP3chs").hide();
                    $(".SP4chs").hide();

                    $(".chs").show();
                    $("#chs").prop("checked", false);
                    $("#hidden1").hide();
                    $(".item4b").hide();
                    $(".item4bb").hide();
                    $("#ReceptionistDropDownList").val('');
                    $("#MarketingPrgmDropDownList").empty();
                    $("#AgentsDropDownList").empty();
                    $("#AgentCodeDropDownList").empty();
                    $("#AgentsDropDownListInd").empty();
                    $("#VenueDropDownList2").empty();
                    $("#TONameDropDownList").empty();
                    $("#ManagerDropDownList").empty();
                    $("#FAgentDropDownList").val('');
                    $("#PreArrivalDropDownList").val('');
                    $("#VerificationDropDownList").val('');
                    $("#DropDownListFly").val('');
                    $("#GroupVenueDropDownList").empty();
                    $("#sourcecodetext").val("");
                    $("#OfficeSourceTextBox").val("");

                    $("#Memno1TextBox").val("");
                    $("#TypeDropDownList").empty();
                    $("#MemType1DropDownList").val('');

                    $("#primarytitleDropDownList").empty();
                    $("#pfnameTextBox").val("");
                    $("#plnameTextBox").val("");
                    $("#pdobdatepicker").val("");
                    $("#TextPrimaryAge").val("");
                    $("#employmentstatusDropDownList").val('');
                    $("#primarymobileDropDownList").val('');
                    $("#pmobileTextBox").val("");
                    $("#primaryalternateDropDownList").val('');
                    $("#palternateTextBox").val("");
                    $("#phomecodeDropDownList").val('');
                    $("#phomenoTextBox").val("");
                    $("#pofficecodeDropDownList").val('');
                    $("#pofficenoTextBox").val("");
                    $("#pemailTextBox").val("");
                    $("#pemailTextBox2").val("");
                    $("#TextBoxPrimIDType").val("");
                    $("#TextBoxPrimID").val("");


                    $("#secondarytitleDropDownList").empty();
                    $("#sfnameTextBox").val("");
                    $("#slnameTextBox").val("");
                    $("#sdobdatepicker").val("");
                    $("#TextSecondAge").val("");
                    $("#SecondemploymentstatusDropDownList").val('');
                    $("#secondarymobileDropDownList").val('');
                    $("#smobileTextBox").val("");
                    $("#secondaryalternateDropDownList").val('');
                    $("#salternateTextBox").val("");
                    $("#shomecodeDropDownList").val('');
                    $("#shomenoTextBox").val("");
                    $("#sofficecodeDropDownList").val('');
                    $("#sofficenoTextBox").val("");
                    $("#semailTextBox").val("");
                    $("#semailTextBox2").val("");
                    $("#TextBoxSecoIDType").val("");
                    $("#TextBoxSecoID").val("");


                    $("#address1TextBox").val("");
                    $("#address2TextBox").val("");
                    $("#maledesgTextBox").val("");
                    $("#femaledesgTextBox").val("");
                    $("#StateDropDownList").empty();
                    $("#stateTextBox").val("");
                    $("#cityTextBox").val("");
                    $("#pincodeTextBox").val("");
                    $("#MaritalStatusDropDownList").val('');
                    $("#livingyrsTextBox").val("");


                    $("#sp1fnameTextBox").val("");
                    $("#sp1lnameTextBox").val("");
                    $("#sp1dobdatepicker").val("");
                    $("#TextSP1Age").val("");
                    $("#subprofile1mobileDropDownList").val('');
                    $("#sp1mobileTextBox").val("");
                    $("#subprofile1alternateDropDownList").val('');
                    $("#sp1alternateTextBox").val("");
                    $("#sp1emailTextBox").val("");
                    $("#sp1emailTextBox2").val("");
                    $("#TextBoxSP1IDType").val("");
                    $("#TextBoxSP1ID").val("");

                    $("#sp2fnameTextBox").val("");
                    $("#sp2lnameTextBox").val("");
                    $("#sp2dobdatepicker").val("");
                    $("#TextSP2Age").val("");
                    $("#subprofile2mobileDropDownList").val('');
                    $("#sp2mobileTextBox").val("");
                    $("#subprofile2alternateDropDownList").val('');
                    $("#sp2alternateTextBox").val("");
                    $("#sp2emailTextBox").val("");
                    $("#sp2emailTextBox2").val("");
                    $("#TextBoxSP2IDType").val("");
                    $("#TextBoxSP2ID").val("");

                    $("#SubP3FnameTextBox").val("");
                    $("#SubP3LnameTextBox").val("");
                    $("#SubP3DOB").val("");
                    $("#TextSP3Age").val("");
                    $("#SubP3CCDropDownList").val('');
                    $("#SubP3MobileTextBox").val("");
                    $("#SubP3CCDropDownList2").val('');
                    $("#SubP3AMobileTextBox").val("");
                    $("#SubP3EmailTextBox").val("");
                    $("#SubP3EmailTextBox2").val("");
                    $("#TextBoxSP3IDType").val("");
                    $("#TextBoxSP3ID").val("");

                    $("#SubP4FnameTextBox").val("");
                    $("#SubP4LnameTextBox").val("");
                    $("#SubP4DOB").val("");
                    $("#TextSP4Age").val("");
                    $("#SubP4CCDropDownList").val('');
                    $("#SubP4MobileTextBox").val("");
                    $("#SubP4CCDropDownList2").val('');
                    $("#SubP4AMobileTextBox").val("");
                    $("#SubP4EmailTextBox").val("");
                    $("#SubP4EmailTextBox2").val("");
                    $("#TextBoxSP4IDType").val("");
                    $("#TextBoxSP4ID").val("");

                    $("#hotelTextBox").val("");
                    $("#roomnoTextBox").val("");
                    $("#checkindatedatepicker").val("");
                    $("#checkoutdatedatepicker").val("");
                    $("#deckcheckintimeTextBox").val("");
                    $("#deckcheckouttimeTextBox").val("");
                    $("#vouchernoTextBox").val("");
                    $("#TextBoxGPrice1").val("");
                    $("#TextBoxChargeBack").val("");
                    $("#vouchernoTextBox2").val("");
                    $("#TextBoxGPrice2").val("");
                    $("#vouchernoTextBox3").val("");
                    $("#TextBoxGPrice3").val("");
                    $("#vouchernoTextBox4").val("");
                    $("#TextBoxGPrice4").val("");
                    $("#vouchernoTextBox5").val("");
                    $("#TextBoxGPrice5").val("");
                    $("#vouchernoTextBox6").val("");
                    $("#TextBoxGPrice6").val("");
                    $("#vouchernoTextBox7").val("");
                    $("#TextBoxGPrice7").val("");
                    $("#gueststatusDropDownList").val('');
                    $("#QStatusDropDownList1").val('');
                    $("#salesrepDropDownList").val('');
                    $("#tourdatedatepicker").val("");
                    $("#taxipriceInTextBox").val("");
                    $("#TaxiRefInTextBox").val("");
                    $("#TaxiPriceOutTextBox").val("");
                    $("#TaxiRefOutTextBox").val("");
                    $("#commentTextBox").val("");
                    $("#comment2").val("");
                    $("#subGroup").val('');
                    $("#leadOffice").val('');
                } else {
                    $(".item5a").show();
                    $(".item8").show();
                    $(".item9").show();
                    $(".item9b").hide();
                    $(".item10").hide();
                    $(".item11").hide();
                    $(".item12").hide();
                    $(".item3a").show();
                    $(".Primchs").show();
                    $(".Prihidden").show();
                    $(".item313").hide();
                    $(".item312").hide();
                    $(".itemHome313").hide();
                    $(".itemHome312").hide();
                    $(".item37a").show();
                    $(".item377").hide();
                    $(".item47b").hide();
                    $(".item47a").show();

                    $(".Secochs").show();
                    $(".Sechidden").show();
                    $(".item412").hide();
                    $(".item4122").hide();
                    $(".itemHome412").hide();
                    $(".itemHome4122").hide();
                    $("#item577").hide();
                    $(".item53").show();
                    $(".item53b").hide();
                    $(".SP1chs").show();
                    $(".SP2chs").show();
                    $(".SP3chs").show();
                    $(".SP4chs").show();
                    $(".chs").hide();
                    $("#hidden1").hide();
                    $("#chs").prop("checked", false);
                    $(".item4b").hide();
                    $(".item4bb").hide();
                    //$(".item6b").hide();
                    // $("#ReceptionistDropDownList").val('');
                    $("#MarketingPrgmDropDownList").empty();
                    $("#AgentsDropDownList").empty();
                    $("#AgentCodeDropDownList").empty();
                    $("#AgentsDropDownListInd").empty();
                    $("#VenueDropDownList2").empty();
                    $("#TONameDropDownList").empty();
                    $("#ManagerDropDownList").empty();
                    $("#FAgentDropDownList").val('');
                    $("#PreArrivalDropDownList").val('');
                    $("#VerificationDropDownList").val('');
                    $("#DropDownListFly").val('');
                    $("#GroupVenueDropDownList").empty();
                    $("#sourcecodetext").val("");
                    $("#OfficeSourceTextBox").val("");

                    $("#Memno1TextBox").val("");
                    $("#TypeDropDownList").empty();
                    $("#MemType1DropDownList").val('');


                    $("#primarytitleDropDownList").empty();
                    $("#pfnameTextBox").val("");
                    $("#plnameTextBox").val("");
                    $("#pdobdatepicker").val("");
                    $("#TextPrimaryAge").val("");
                    $("#employmentstatusDropDownList").val('');
                    $("#primarymobileDropDownList").val('');
                    $("#pmobileTextBox").val("");
                    $("#primaryalternateDropDownList").val('');
                    $("#palternateTextBox").val("");
                    $("#phomecodeDropDownList").val('');
                    $("#phomenoTextBox").val("");
                    $("#pofficecodeDropDownList").val('');
                    $("#pofficenoTextBox").val("");
                    $("#pemailTextBox").val("");
                    $("#pemailTextBox2").val("");
                    $("#TextBoxPrimIDType").val("");
                    $("#TextBoxPrimID").val("");


                    $("#secondarytitleDropDownList").empty();
                    $("#sfnameTextBox").val("");
                    $("#slnameTextBox").val("");
                    $("#sdobdatepicker").val("");
                    $("#TextSecondAge").val("");
                    $("#SecondemploymentstatusDropDownList").val('');
                    $("#secondarymobileDropDownList").val('');
                    $("#smobileTextBox").val("");
                    $("#secondaryalternateDropDownList").val('');
                    $("#salternateTextBox").val("");
                    $("#shomecodeDropDownList").val('');
                    $("#shomenoTextBox").val("");
                    $("#sofficecodeDropDownList").val('');
                    $("#sofficenoTextBox").val("");
                    $("#semailTextBox").val("");
                    $("#semailTextBox2").val("");
                    $("#TextBoxSecoIDType").val("");
                    $("#TextBoxSecoID").val("");

                    $("#address1TextBox").val("");
                    $("#address2TextBox").val("");
                    $("#maledesgTextBox").val("");
                    $("#femaledesgTextBox").val("");
                    $("#StateDropDownList").empty();
                    $("#stateTextBox").val("");
                    $("#cityTextBox").val("");
                    $("#pincodeTextBox").val("");
                    $("#MaritalStatusDropDownList").val('');
                    $("#livingyrsTextBox").val("");

                    $("#sp1fnameTextBox").val("");
                    $("#sp1lnameTextBox").val("");
                    $("#sp1dobdatepicker").val("");
                    $("#TextSP1Age").val("");
                    $("#subprofile1mobileDropDownList").val('');
                    $("#sp1mobileTextBox").val("");
                    $("#subprofile1alternateDropDownList").val('');
                    $("#sp1alternateTextBox").val("");
                    $("#sp1emailTextBox").val("");
                    $("#sp1emailTextBox2").val("");
                    $("#TextBoxSP1IDType").val("");
                    $("#TextBoxSP1ID").val("");

                    $("#sp2fnameTextBox").val("");
                    $("#sp2lnameTextBox").val("");
                    $("#sp2dobdatepicker").val("");
                    $("#TextSP2Age").val("");
                    $("#subprofile2mobileDropDownList").val('');
                    $("#sp2mobileTextBox").val("");
                    $("#subprofile2alternateDropDownList").val('');
                    $("#sp2alternateTextBox").val("");
                    $("#sp2emailTextBox").val("");
                    $("#sp2emailTextBox2").val("");
                    $("#TextBoxSP2IDType").val("");
                    $("#TextBoxSP2ID").val("");

                    $("#SubP3FnameTextBox").val("");
                    $("#SubP3LnameTextBox").val("");
                    $("#SubP3DOB").val("");
                    $("#TextSP3Age").val("");
                    $("#SubP3CCDropDownList").val('');
                    $("#SubP3MobileTextBox").val("");
                    $("#SubP3CCDropDownList2").val('');
                    $("#SubP3AMobileTextBox").val("");
                    $("#SubP3EmailTextBox").val("");
                    $("#SubP3EmailTextBox2").val("");
                    $("#TextBoxSP3IDType").val("");
                    $("#TextBoxSP3ID").val("");

                    $("#SubP4FnameTextBox").val("");
                    $("#SubP4LnameTextBox").val("");
                    $("#SubP4DOB").val("");
                    $("#TextSP4Age").val("");
                    $("#SubP4CCDropDownList").val('');
                    $("#SubP4MobileTextBox").val("");
                    $("#SubP4CCDropDownList2").val('');
                    $("#SubP4AMobileTextBox").val("");
                    $("#SubP4EmailTextBox").val("");
                    $("#SubP4EmailTextBox2").val("");
                    $("#TextBoxSP4IDType").val("");
                    $("#TextBoxSP4ID").val("");

                    $("#hotelTextBox").val("");
                    $("#roomnoTextBox").val("");
                    $("#checkindatedatepicker").val("");
                    $("#checkoutdatedatepicker").val("");
                    $("#deckcheckintimeTextBox").val("");
                    $("#deckcheckouttimeTextBox").val("");
                    $("#vouchernoTextBox").val("");
                    $("#TextBoxGPrice1").val("");
                    $("#TextBoxChargeBack").val("");
                    $("#vouchernoTextBox2").val("");
                    $("#TextBoxGPrice2").val("");
                    $("#vouchernoTextBox3").val("");
                    $("#TextBoxGPrice3").val("");
                    $("#vouchernoTextBox4").val("");
                    $("#TextBoxGPrice4").val("");
                    $("#vouchernoTextBox5").val("");
                    $("#TextBoxGPrice5").val("");
                    $("#vouchernoTextBox6").val("");
                    $("#TextBoxGPrice6").val("");
                    $("#vouchernoTextBox7").val("");
                    $("#TextBoxGPrice7").val("");
                    $("#gueststatusDropDownList").val('');
                    $("#QStatusDropDownList1").val('');
                    $("#salesrepDropDownList").val('');
                    $("#tourdatedatepicker").val("");
                    $("#taxipriceInTextBox").val("");
                    $("#TaxiRefInTextBox").val("");
                    $("#TaxiPriceOutTextBox").val("");
                    $("#TaxiRefOutTextBox").val("");
                    $("#commentTextBox").val("");
                    $("#comment2").val("");
                    $("#subGroup").val('');
                    $("#leadOffice").val('');
                }

            });

        });

    </script>

    <script>
        $(document).ready(function () {

            $("#GroupVenueDropDownList").change(function () {
                $("#subGroup").val('');
                $("#leadOffice").val('');
                var id = $("#VenueCountryDropDownList").val();
                var venue = $("#VenueDropDownList option:selected").text();
                var venue_group = $("#GroupVenueDropDownList option:selected").text();
                //alert(venue_group);
                if (id == "India" || id == "INDIA") {
                 
                    if (venue_group == "INHOUSE" || venue_group == "Inhouse") {
                       // alert("hiee");
                        $(".item5a").show();
                        $(".item4b").show();
                        $(".item4bb").hide();
                    }
                    else if (venue_group == "FLYBUY" || venue_group == "FlyBuy") {

                        $(".item5a").show();
                        $(".item4b").hide();
                        $(".item4bb").show();
                    } else {

                        $(".item5a").hide();
                        $(".item4b").hide();
                        $(".item4bb").hide();
                    }
                }


            });


        });


    </script>


</body>
</html>
