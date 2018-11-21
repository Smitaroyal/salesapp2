using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Sql;
using System.Net;
using System.IO;
using System.Web.UI.WebControls.Adapters;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Globalization; 
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using System.Collections.Generic;
 






public partial class _Default : System.Web.UI.Page
{
    static string office;
    
    
    public string getdata()
    {
        string htmlstr = "";
        SqlDataReader dr = Queries.LoadAffiliationType(office); //,currencyDropDownList.SelectedItem.Text);
        while (dr.Read())
        {

            int id = dr.GetInt32(0);
            string name = dr.GetString(1);
            double amt = dr.GetDouble(2);
            string addvalue = "dispplayvalue";
            string ca = "ca";

            htmlstr += " <input id=" + ca + "" + id + " type='checkbox' class='hello' name='aamt' onClick="  + addvalue + "() value='" + amt + "'>" + name + "";


        }

        return htmlstr;
    }
    
 
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        if (!IsPostBack)
        {


            Session["oProfile_Venue_Country"] = ""; Session["oProfile_Venue"] = ""; Session["oProfile_Group_Venue"] = ""; Session["oProfile_Marketing_Program"] = "";
            Session["oProfile_Agent"] = ""; Session["oProfile_Agent_Code"] = ""; Session["oProfile_Member_Type1"] = ""; Session["oProfile_Member_Number1"] = "";
            Session["oProfile_Member_Type2"] = ""; Session["oProfile_Member_Number2"] = ""; Session["oProfile_Employment_status"] = ""; Session["oProfile_Marital_status"] = "";
            Session["oProfile_NOY_Living_as_couple"] = ""; Session["oOffice"] = ""; Session["oComments"] = ""; Session["oManager"] = "";
            Session["ophid"] = ""; Session["ocard"] = "";

            Session["oProfile_Primary_Title"] = ""; Session["oProfile_Primary_Fname"] = ""; Session["oProfile_Primary_Lname"] = "";
            Session["oProfile_Primary_DOB"] = ""; Session["oProfile_Primary_Nationality"] = ""; Session["oProfile_Primary_Country"] = "";
            Session["opage"] = ""; Session["opdesignation"] = ""; Session["oplang"] = "";

            Session["oProfile_Secondary_Title"] = ""; Session["oProfile_Secondary_Fname"] = ""; Session["oProfile_Secondary_Lname"] = "";
            Session["oProfile_Secondary_DOB"] = ""; Session["oProfile_Secondary_Nationality"] = ""; Session["oProfile_Secondary_Country"] = "";
            Session["osage"] = ""; Session["osdesignation"] = ""; Session["oslang"] = "";

            Session["oSub_Profile1_Title"] = ""; Session["oSub_Profile1_Fname"] = ""; Session["oSub_Profile1_Lname"] = "";
            Session["oSub_Profile1_DOB"] = ""; Session["  oSub_Profile1_Nationality"] = ""; Session["oSub_Profile1_Country"] = "";
            Session["osp1age"] = "";

            Session["oSub_Profile2_Title"] = ""; Session["oSub_Profile2_Fname"] = ""; Session["oSub_Profile2_Lname"] = "";
            Session["oSub_Profile2_DOB"] = ""; Session["  oSub_Profile2_Nationality"] = ""; Session["oSub_Profile2_Country"] = "";
            Session["osp2age"] = "";

            Session["oSub_Profile3_Title"] = ""; Session["oSub_Profile3_Fname"] = ""; Session["oSub_Profile3_Lname"] = "";
            Session["oSub_Profile3_DOB"] = ""; Session["  oSub_Profile3_Nationality"] = ""; Session["oSub_Profile3_Country"] = "";
            Session["osp3age"] = "";

            Session["oSub_Profile4_Title"] = ""; Session["oSub_Profile4_Fname"] = ""; Session["oSub_Profile4_Lname"] = "";
            Session["oSub_Profile4_DOB"] = ""; Session["  oSub_Profile4_Nationality"] = ""; Session["oSub_Profile4_Country"] = "";
            Session["osp4age"] = "";

            Session["oProfile_Address_Line1"] = ""; Session["oProfile_Address_Line2"] = ""; Session["oProfile_Address_State"] = "";
            Session["oProfile_Address_city"] = ""; Session["oProfile_Address_Postcode"] = ""; Session["oProfile_Address_Created_Date"] = "";
            Session["oProfile_Address_Expiry_Date"] = ""; Session["oProfile_Address_Country"] = "";


            Session["oPrimary_CC"] = ""; Session["oPrimary_Mobile"] = ""; Session["oPrimary_Alt_CC"] = "";
            Session["oPrimary_Alternate"] = ""; Session["opriOfficecc"] = ""; Session["opriOfficeno"] = "";

            Session["osecOfficecc"] = ""; Session["osecofficeno"] = ""; Session["oSecondary_CC"] = "";
            Session["oSecondary_Mobile"] = ""; Session["oSecondary_Alt_CC"] = ""; Session["oSecondary_Alternate"] = "";

            Session["oSubprofile1_CC"] = ""; Session["oSubprofile1_Mobile"] = ""; Session["oSubprofile1_Alt_CC"] = ""; Session["oSubprofile1_Alternate"] = "";
            Session["oSubprofile2_CC"] = ""; Session["oSubprofile2_Mobile"] = ""; Session["oSubprofile2_Alt_CC"] = ""; Session["oSubprofile2_Alternate"] = "";

            Session["oSubprofile3_CC"] = ""; Session["oSubprofile3_Mobile"] = ""; Session["oSubprofile3_Alt_CC"] = ""; Session["oSubprofile3_Alternate"] = "";
            Session["oSubprofile4_CC"] = ""; Session["oSubprofile4_Mobile"] = ""; Session["oSubprofile4_Alt_CC"] = ""; Session["oSubprofile4_Alternate"] = "";

            Session["oPrimary_Email"] = ""; Session["oSecondary_Email"] = ""; Session["oSubprofile1_Email"] = "";
            Session["oSubprofile2_Email"] = ""; Session["oSubprofile3_Email"] = ""; Session["oSubprofile4_Email"] = "";

            Session["oProfile_Stay_ID"] = ""; Session["oProfile_Stay_Resort_Name"] = ""; Session["oProfile_Stay_Resort_Room_Number"] = "";
            Session["oProfile_Stay_Arrival_Date"] = ""; Session["oProfile_Stay_Departure_Date"] = "";

            Session["oTour_Details_Guest_Status"] = ""; Session["oTour_Details_Guest_Sales_Rep"] = ""; Session["oTour_Details_Tour_Date"] = "";
            Session["tourweekno"] = ""; Session["oTour_Details_Sales_Deck_Check_In"] = ""; Session["oTour_Details_Sales_Deck_Check_Out"] = "";
            Session["oTour_Details_Taxi_In_Price"] = ""; Session["oTour_Details_Taxi_In_Ref"] = ""; Session["oTour_Details_Taxi_Out_Price"] = "";
            Session["oTour_Details_Taxi_Out_Ref"] = ""; Session["oComments"] = ""; Session["oregTerms"] = ""; Session["ocomment2"] = "";

            Session["ProfileID"] = "";


            Session["ProfileID"] = Convert.ToString(Request.QueryString["Profile_ID"]);

            DataSet ds = Queries.LoadProfielDetailsFull(Session["ProfileID"].ToString());
            profileidTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();
            indateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"].ToString();
            createdbyTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString();
            office = ds.Tables[0].Rows[0]["Office"].ToString();
            officeTextBox.Text = ds.Tables[0].Rows[0]["Office"].ToString();
            Session["ophid"]  = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
            Session["ocard"]   = ds.Tables[0].Rows[0]["Card_Holder"].ToString();
            companynameTextBox.Text = ds.Tables[0].Rows[0]["Company_Name"].ToString().ToUpper();


            //loading venuecountry on load
            DataSet ds1 = Queries.LoadProfileVenueCountry(Session["ProfileID"].ToString());
            VenueCountryDropDownList.DataSource = ds1;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            //loading venue on load
            DataSet ds2 = Queries.LoadProfileVenue(Session["ProfileID"].ToString(), VenueCountryDropDownList.SelectedItem.Text);
            VenueDropDownList.DataSource = ds2;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            // loading venuegroup on load
            DataSet ds3 = Queries.LoadProfileVenueGroup(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
            GroupVenueDropDownList.DataSource = ds3;
            GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            GroupVenueDropDownList.AppendDataBoundItems = true;
            GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            GroupVenueDropDownList.DataBind();

            //loading marketing program on load
            DataSet ds4 = Queries.LoadProfileMktg(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
            MarketingProgramDropDownList.DataSource = ds4;
            MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
            MarketingProgramDropDownList.DataValueField = "Marketing_Program_Name";
            MarketingProgramDropDownList.AppendDataBoundItems = true;
            MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            MarketingProgramDropDownList.DataBind();

            // loading agents on load as per venue group
            if (GroupVenueDropDownList.SelectedItem.Text == "Coldline")
            {
                //     DataSet ds5 = Queries.LoadProfileAgent1(ProfileID);
                DataSet ds5 = Queries.LoadProfileAgent1(Session["ProfileID"].ToString(), office);
                AgentDropDownList.DataSource = ds5;
                AgentDropDownList.DataTextField = "Agent_Name";
                AgentDropDownList.DataValueField = "Agent_Name";
                AgentDropDownList.AppendDataBoundItems = true;
                AgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                AgentDropDownList.DataBind();


            }
            else
            {
                DataSet ds5 = Queries.LoadProfileAgentNotColdline(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
                AgentDropDownList.DataSource = ds5;
                AgentDropDownList.DataTextField = "Sales_Rep_Name";
                AgentDropDownList.DataValueField = "Sales_Rep_Name";
                AgentDropDownList.AppendDataBoundItems = true;
                AgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                AgentDropDownList.DataBind();



            }

            // loading To name on load as per venue group
            if (GroupVenueDropDownList.SelectedItem.Text == "Coldline" || GroupVenueDropDownList.SelectedItem.Text == "COLDLINE")
            {
                // load to11
                DataSet ds5aa = Queries.LoadTOOPCOnVenue11(Session["ProfileID"].ToString(), office);
                TONameDropDownList.DataSource = ds5aa;
                TONameDropDownList.DataTextField = "to_name";
                TONameDropDownList.DataValueField = "to_name";
                TONameDropDownList.AppendDataBoundItems = true;
                TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
                TONameDropDownList.DataBind();


            }
            else
            {
                // load to12
                DataSet ds5aa = Queries.LoadTOOPCOnVenue12(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
                TONameDropDownList.DataSource = ds5aa;
                TONameDropDownList.DataTextField = "TO_Manager_Name";
                TONameDropDownList.DataValueField = "TO_Manager_Name";
                TONameDropDownList.AppendDataBoundItems = true;
                TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
                TONameDropDownList.DataBind();



            }

            //DataSet ds6 = Queries.LoadProfileTOName(ProfileID, VenueDropDownList.SelectedItem.Text);
            //TONameDropDownList.DataSource = ds6;
            //TONameDropDownList.DataTextField = "TO_Manager_Name";
            //TONameDropDownList.DataValueField = "TO_Manager_Name";
            //TONameDropDownList.AppendDataBoundItems = true;
            //TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //TONameDropDownList.DataBind();




            DataSet dsmg = Queries.LoadProfileManager(Session["ProfileID"].ToString(), office);
            ManagerDropDownList.DataSource = dsmg;
            ManagerDropDownList.DataTextField = "Manager_Name";
            ManagerDropDownList.DataValueField = "Manager_Name";
            ManagerDropDownList.AppendDataBoundItems = true;
            ManagerDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["manager"].ToString(), ""));
            ManagerDropDownList.DataBind();



            if (MarketingProgramDropDownList.SelectedItem.Text == "Owner" || MarketingProgramDropDownList.SelectedItem.Text == "OWNER")
            {
                // loadprofilememebertype
                DataSet dsmgs = Queries.LoadProfileMemberType(Session["ProfileID"].ToString());
                MemType1DropDownList.DataSource = dsmgs;
                MemType1DropDownList.DataTextField = "Member_Type_Name";
                MemType1DropDownList.DataValueField = "Member_Type_Name";
                MemType1DropDownList.AppendDataBoundItems = true;
                MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
                MemType1DropDownList.DataBind();


                Memno1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();

                // load profiletype
                DataSet dsmgss = Queries.LoadProfileType(Session["ProfileID"].ToString());
                TypeDropDownList.DataSource = dsmgss;
                TypeDropDownList.DataTextField = "Type_Name";
                TypeDropDownList.DataValueField = "Type_Name";
                TypeDropDownList.AppendDataBoundItems = true;
                TypeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString(), ""));
                TypeDropDownList.DataBind();
            }
            else
            {


                // profilemembertype
                DataSet dsmgs = Queries.LoadProfileMemberType(Session["ProfileID"].ToString());
                MemType1DropDownList.DataSource = dsmgs;
                MemType1DropDownList.DataTextField = "Member_Type_Name";
                MemType1DropDownList.DataValueField = "Member_Type_Name";
                MemType1DropDownList.AppendDataBoundItems = true;
                MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
                MemType1DropDownList.DataBind();
                // load profiletype
                DataSet dsmgss = Queries.LoadProfileType(Session["ProfileID"].ToString());
                TypeDropDownList.DataSource = dsmgss;
                TypeDropDownList.DataTextField = "Type_Name";
                TypeDropDownList.DataValueField = "Type_Name";
                TypeDropDownList.AppendDataBoundItems = true;
                TypeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString(), ""));
                TypeDropDownList.DataBind();


            }

            DataSet dsptitle = Queries.LoadPrimarySalutation(Session["ProfileID"].ToString(), office);
            PrimaryTitleDropDownList.DataSource = dsptitle;
            PrimaryTitleDropDownList.DataTextField = "Salutation";
            PrimaryTitleDropDownList.DataValueField = "Salutation";
            PrimaryTitleDropDownList.AppendDataBoundItems = true;
            PrimaryTitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            PrimaryTitleDropDownList.DataBind();

            pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            primarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            primaryAge.Text = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            pdesginationTextBox.Text = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();


            DataSet dspnationality = Queries.LoadPrimaryNationality(Session["ProfileID"].ToString());
            PrimarynationalityDropDownList.DataSource = dspnationality;
            PrimarynationalityDropDownList.DataTextField = "Nationality_Name";
            PrimarynationalityDropDownList.DataValueField = "Nationality_Name";
            PrimarynationalityDropDownList.AppendDataBoundItems = true;
            PrimarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            PrimarynationalityDropDownList.DataBind();

            DataSet dspcountry = Queries.LoadCountryPrimary(Session["ProfileID"].ToString());
            primarycountryDropDownList.DataSource = dspcountry;
            primarycountryDropDownList.DataTextField = "country_name";
            primarycountryDropDownList.DataValueField = "country_name";
            primarycountryDropDownList.AppendDataBoundItems = true;
            primarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            primarycountryDropDownList.DataBind();



            pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();

            DataSet dspm = Queries.LoadCountryWithCodePrimaryMobile(Session["ProfileID"].ToString());
            primarymobileDropDownList.DataSource = dspm;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();

            pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();

            DataSet dspalt = Queries.LoadCountryWithCodePrimaryAlt(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString());//( ProfileID);
            primaryalternateDropDownList.DataSource = dspalt;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();
            palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();

            DataSet dspoff = Queries.LoadCountryWithCodePrimaryOffice(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString());//(ProfileID);
            pofficecodeDropDownList.DataSource = dspoff;
            pofficecodeDropDownList.DataTextField = "name";
            pofficecodeDropDownList.DataValueField = "name";
            pofficecodeDropDownList.AppendDataBoundItems = true;
            pofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_office_cc"].ToString(), ""));
            pofficecodeDropDownList.DataBind();
            pofficenoTextBox.Text = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();



            //secondary details
            DataSet dsstitle = Queries.LoadSecondarySalutation(Session["ProfileID"].ToString(), office);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();

            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Lname"].ToString();
            secondarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_secondary_DOB"]);
            secondaryAge.Text = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            sdesignationTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();

            DataSet dssnationality = Queries.LoadSecondaryNationality(Session["ProfileID"].ToString());
            secondarynationalityDropDownList.DataSource = dssnationality;
            secondarynationalityDropDownList.DataTextField = "Nationality_Name";
            secondarynationalityDropDownList.DataValueField = "Nationality_Name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();

            DataSet dsscountry = Queries.LoadCountrySecondary(Session["ProfileID"].ToString());
            secondarycountryDropDownList.DataSource = dsscountry;
            secondarycountryDropDownList.DataTextField = "country_name";
            secondarycountryDropDownList.DataValueField = "country_name";
            secondarycountryDropDownList.AppendDataBoundItems = true;
            secondarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString(), ""));
            secondarycountryDropDownList.DataBind();



            semailTextBox.Text = ds.Tables[0].Rows[0]["secondary_Email"].ToString();

            DataSet dssm = Queries.LoadCountryWithCodeSecondaryMobile(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString());//(ProfileID);
            secondarymobileDropDownList.DataSource = dssm;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();

            smobileTextBox.Text = ds.Tables[0].Rows[0]["secondary_Mobile"].ToString();

            DataSet dssalt = Queries.LoadCountryWithCodeSecondaryAlt(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString());//(ProfileID);
            secondaryalternateDropDownList.DataSource = dssalt;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();
            salternateTextBox.Text = ds.Tables[0].Rows[0]["secondary_Alternate"].ToString();


            DataSet dssoff = Queries.LoadCountryWithCodeSecondaryAlt(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString());//(ProfileID);
            sofficecodeDropDownList.DataSource = dssoff;
            sofficecodeDropDownList.DataTextField = "name";
            sofficecodeDropDownList.DataValueField = "name";
            sofficecodeDropDownList.AppendDataBoundItems = true;
            sofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString(), ""));
            sofficecodeDropDownList.DataBind();
            sofficenoTextBox.Text = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();


            //address
            address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            //stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            livingyrsTextBox.Text = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            DataSet ds12 = Queries.LoadCountryName();
            AddCountryDropDownList.DataSource = ds12;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();

            //state Name
            DataSet ds1222 = Queries.LoadStateName(Session["ProfileID"].ToString(), AddCountryDropDownList.SelectedItem.Text);
            StateDropDownList.DataSource = ds1222;
            StateDropDownList.DataTextField = "State_Name";
            StateDropDownList.DataValueField = "State_Name";
            StateDropDownList.AppendDataBoundItems = true;
            StateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_State"].ToString(), ""));
            StateDropDownList.DataBind();

            DataSet dsemploy = Queries.LoadEmploymentStatusNotInProfile(Session["ProfileID"].ToString());
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();


            DataSet dsmart = Queries.LoadMaritalStatusNotInProfile(Session["ProfileID"].ToString());
            maritalstatusDropDownList.DataSource = dsmart;
            maritalstatusDropDownList.DataTextField = "MaritalStatus";
            maritalstatusDropDownList.DataValueField = "MaritalStatus";
            maritalstatusDropDownList.AppendDataBoundItems = true;
            maritalstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            maritalstatusDropDownList.DataBind();



            DataSet dssp1title = Queries.LoadSub_Profile1Salutation(Session["ProfileID"].ToString(), office);
            sp1titleDropDownList.DataSource = dssp1title;
            sp1titleDropDownList.DataTextField = "Salutation";
            sp1titleDropDownList.DataValueField = "Salutation";
            sp1titleDropDownList.AppendDataBoundItems = true;
            sp1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            sp1titleDropDownList.DataBind();

            sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();

            //secondarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_secondary_DOB"]);

            sp1dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);// Convert.ToDateTime( ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            subProfile1Age.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

            DataSet dssp1nationality = Queries.LoadSub_Profile1Nationality(Session["ProfileID"].ToString());
            sp1nationalityDropDownList.DataSource = dssp1nationality;
            sp1nationalityDropDownList.DataTextField = "Nationality_Name";
            sp1nationalityDropDownList.DataValueField = "Nationality_Name";
            sp1nationalityDropDownList.AppendDataBoundItems = true;
            sp1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            sp1nationalityDropDownList.DataBind();

            DataSet dssp1country = Queries.LoadCountrySP1(Session["ProfileID"].ToString());
            sp1countryDropDownList.DataSource = dssp1country;
            sp1countryDropDownList.DataTextField = "country_name";
            sp1countryDropDownList.DataValueField = "country_name";
            sp1countryDropDownList.AppendDataBoundItems = true;
            sp1countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            sp1countryDropDownList.DataBind();



            sp1pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();

            DataSet dssp1m = Queries.LoadCountryWithCodeSP1Mobile(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());//(ProfileID);
            sp1mobileDropDownList.DataSource = dssp1m;
            sp1mobileDropDownList.DataTextField = "name";
            sp1mobileDropDownList.DataValueField = "name";
            sp1mobileDropDownList.AppendDataBoundItems = true;
            sp1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            sp1mobileDropDownList.DataBind();

            sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();

            DataSet dssp1alt = Queries.LoadCountryWithCodeSP1Alt(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());//(ProfileID);
            sp1alternateDropDownList.DataSource = dssp1alt;
            sp1alternateDropDownList.DataTextField = "name";
            sp1alternateDropDownList.DataValueField = "name";
            sp1alternateDropDownList.AppendDataBoundItems = true;
            sp1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            sp1alternateDropDownList.DataBind();
            sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();



            DataSet dssp2title = Queries.LoadSub_Profile2Salutation(Session["ProfileID"].ToString(), office);
            sp2titleDropDownList.DataSource = dssp2title;
            sp2titleDropDownList.DataTextField = "Salutation";
            sp2titleDropDownList.DataValueField = "Salutation";
            sp2titleDropDownList.AppendDataBoundItems = true;
            sp2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            sp2titleDropDownList.DataBind();

            sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            sp2dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            subProfile2Age.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

            DataSet dssp2nationality = Queries.LoadSub_Profile2Nationality(Session["ProfileID"].ToString());
            sp2nationalityDropDownList.DataSource = dssp2nationality;
            sp2nationalityDropDownList.DataTextField = "Nationality_Name";
            sp2nationalityDropDownList.DataValueField = "Nationality_Name";
            sp2nationalityDropDownList.AppendDataBoundItems = true;
            sp2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            sp2nationalityDropDownList.DataBind();

            DataSet dssp2country = Queries.LoadCountrySP2(Session["ProfileID"].ToString());
            sp2countryDropDownList.DataSource = dssp2country;
            sp2countryDropDownList.DataTextField = "country_name";
            sp2countryDropDownList.DataValueField = "country_name";
            sp2countryDropDownList.AppendDataBoundItems = true;
            sp2countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            sp2countryDropDownList.DataBind();
            sp2pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

            DataSet dssp2m = Queries.LoadCountryWithCodeSP2Mobile(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());//(ProfileID);
            sp2mobileDropDownList.DataSource = dssp2m;
            sp2mobileDropDownList.DataTextField = "name";
            sp2mobileDropDownList.DataValueField = "name";
            sp2mobileDropDownList.AppendDataBoundItems = true;
            sp2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            sp2mobileDropDownList.DataBind();

            sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();

            DataSet dssp2alt = Queries.LoadCountryWithCodeSP2Alt(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());//(ProfileID);
            sp2alternateDropDownList.DataSource = dssp2alt;
            sp2alternateDropDownList.DataTextField = "name";
            sp2alternateDropDownList.DataValueField = "name";
            sp2alternateDropDownList.AppendDataBoundItems = true;
            sp2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            sp2alternateDropDownList.DataBind();
            sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();



            //sub profile 3///
            DataSet dssp3title = Queries.LoadSub_Profile3Salutation(Session["ProfileID"].ToString(), office);
            sp3titleDropDownList.DataSource = dssp3title;
            sp3titleDropDownList.DataTextField = "Salutation";
            sp3titleDropDownList.DataValueField = "Salutation";
            sp3titleDropDownList.AppendDataBoundItems = true;
            sp3titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
            sp3titleDropDownList.DataBind();

            sp3fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            sp3lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();

            sp3dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");

            subProfile3Age.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

            DataSet dssp3nationality = Queries.LoadSub_Profile3Nationality(Session["ProfileID"].ToString());
            sp3nationalityDropDownList.DataSource = dssp3nationality;
            sp3nationalityDropDownList.DataTextField = "Nationality_Name";
            sp3nationalityDropDownList.DataValueField = "Nationality_Name";
            sp3nationalityDropDownList.AppendDataBoundItems = true;
            sp3nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
            sp3nationalityDropDownList.DataBind();

            DataSet dssp3country = Queries.LoadCountrySP3(Session["ProfileID"].ToString());
            sp3countryDropDownList.DataSource = dssp3country;
            sp3countryDropDownList.DataTextField = "country_name";
            sp3countryDropDownList.DataValueField = "country_name";
            sp3countryDropDownList.AppendDataBoundItems = true;
            sp3countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            sp3countryDropDownList.DataBind();
            sp3pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();

            DataSet dssp3m = Queries.LoadCountryWithCodeSP3Mobile(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());//(ProfileID);
            sp3mobileDropDownList.DataSource = dssp3m;
            sp3mobileDropDownList.DataTextField = "name";
            sp3mobileDropDownList.DataValueField = "name";
            sp3mobileDropDownList.AppendDataBoundItems = true;
            sp3mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
            sp3mobileDropDownList.DataBind();

            sp3mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();

            DataSet dssp3alt = Queries.LoadCountryWithCodeSP3Alt(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());//(ProfileID);
            sp3alternateDropDownList.DataSource = dssp3alt;
            sp3alternateDropDownList.DataTextField = "name";
            sp3alternateDropDownList.DataValueField = "name";
            sp3alternateDropDownList.AppendDataBoundItems = true;
            sp3alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
            sp3alternateDropDownList.DataBind();
            sp3alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
            // end//


            //// sub profile 4//
            DataSet dssp4title = Queries.LoadSub_Profile4Salutation(Session["ProfileID"].ToString(), office);
            sp4titleDropDownList.DataSource = dssp4title;
            sp4titleDropDownList.DataTextField = "Salutation";
            sp4titleDropDownList.DataValueField = "Salutation";
            sp4titleDropDownList.AppendDataBoundItems = true;
            sp4titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
            sp4titleDropDownList.DataBind();

            sp4fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            sp4lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();

            sp4dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");

            subProfile4Age.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

            DataSet dssp4nationality = Queries.LoadSub_Profile4Nationality(Session["ProfileID"].ToString());
            sp4nationalityDropDownList.DataSource = dssp4nationality;
            sp4nationalityDropDownList.DataTextField = "Nationality_Name";
            sp4nationalityDropDownList.DataValueField = "Nationality_Name";
            sp4nationalityDropDownList.AppendDataBoundItems = true;
            sp4nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
            sp4nationalityDropDownList.DataBind();

            DataSet dssp4country = Queries.LoadCountrySP4(Session["ProfileID"].ToString());
            sp4countryDropDownList.DataSource = dssp4country;
            sp4countryDropDownList.DataTextField = "country_name";
            sp4countryDropDownList.DataValueField = "country_name";
            sp4countryDropDownList.AppendDataBoundItems = true;
            sp4countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            sp4countryDropDownList.DataBind();
            sp4pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

            DataSet dssp4m = Queries.LoadCountryWithCodeSP4Mobile(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());//(ProfileID);
            sp4mobileDropDownList.DataSource = dssp4m;
            sp4mobileDropDownList.DataTextField = "name";
            sp4mobileDropDownList.DataValueField = "name";
            sp4mobileDropDownList.AppendDataBoundItems = true;
            sp4mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
            sp4mobileDropDownList.DataBind();

            sp4mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();


            DataSet dssp4alt = Queries.LoadCountryWithCodeSP4Alt(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());//(ProfileID);
            sp4alternateDropDownList.DataSource = dssp4alt;
            sp4alternateDropDownList.DataTextField = "name";
            sp4alternateDropDownList.DataValueField = "name";
            sp4alternateDropDownList.AppendDataBoundItems = true;
            sp4alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
            sp4alternateDropDownList.DataBind();
            sp4alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
            ////end//

            DataSet dsss = Queries.LoadGift(Session["ProfileID"].ToString());


            if (dsss.Tables[0].Rows.Count == 0)
            {

            }
            else
            {
                TextBox13.Text = dsss.Tables[0].Rows[0]["Gift_Voucher_numb"].ToString();
                TextBox22.Text = dsss.Tables[0].Rows[0]["Gift_Comment"].ToString();
            }


            resortTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();

            roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            arrivaldatedatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToShortDateString();
            departuredatedatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToShortDateString();

            tourdatedatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToShortDateString();
            Session["oTour_Details_Tour_Date"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");

            timeinTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            timeoutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            inpriceTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            inrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            outpriceTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            outrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
            commentsTextBox.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            comment2.Text = ds.Tables[0].Rows[0]["comment2"].ToString();

         

            Session["oProfile_Venue_Country"]   = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
            Session["oProfile_Venue"]    = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
            Session["oProfile_Group_Venue"]   = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            Session["oProfile_Marketing_Program"]   = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
            Session["oProfile_Agent"]   = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
            Session["oProfile_Agent_Code"]    = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
            Session["oProfile_Member_Type1"]    = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
            Session["oProfile_Member_Number1"]    = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            Session["oProfile_Member_Type2"]    = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
            Session["oProfile_Member_Number2"]    = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
            Session["oProfile_Employment_status"]    = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            Session["oProfile_Marital_status"]    = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            Session["oProfile_NOY_Living_as_couple"]     = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
            Session["oOffice"]    = ds.Tables[0].Rows[0]["Office"].ToString();
            Session["oComments"]   = ds.Tables[0].Rows[0]["Comments"].ToString();
            Session["ocomment2"]  = ds.Tables[0].Rows[0]["comment2"].ToString();
            Session["oManager"]    = ds.Tables[0].Rows[0]["Manager"].ToString();

            Session["oProfile_Primary_Title"]     = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            Session["oProfile_Primary_Fname"]    = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            Session["oProfile_Primary_Lname"]    = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            Session["oProfile_Primary_DOB"]    = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oProfile_Primary_Nationality"]   = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            Session["oProfile_Primary_Country"]   = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
            Session["opage"]   = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            Session["opdesignation"]    = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
            Session["oplang"]    = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

            Session["oProfile_Secondary_Title"]    = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            Session["oProfile_Secondary_Fname"]    = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            Session["oProfile_Secondary_Lname"]    = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            Session["oProfile_Secondary_DOB"]   = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oProfile_Secondary_Nationality"]    = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            Session["oProfile_Secondary_Country"]    = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
            Session["osage"]    = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            Session["osdesignation"]    = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
            Session["oslang"]   = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();


            Session["oSub_Profile1_Title"]    = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            Session["oSub_Profile1_Fname"]    = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            Session["oSub_Profile1_Lname"]    = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            Session["oSub_Profile1_DOB"]     = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile1_Nationality"]    = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            Session["oSub_Profile1_Country"]     = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
            Session["osp1age"]   = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();


            Session["oSub_Profile2_Title"]   = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            Session["oSub_Profile2_Fname"]    = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            Session["oSub_Profile2_Lname"]   = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            Session["oSub_Profile2_DOB"]   = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile2_Nationality"]    = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            Session["oSub_Profile2_Country"]   = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
            Session["osp2age"]     = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

            Session["oProfile_Address_Line1"]    = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            Session["oProfile_Address_Line2"]   = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            Session["oProfile_Address_State"]   = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            Session["oProfile_Address_city"]  = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            Session["oProfile_Address_Postcode"]   = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            Session["oProfile_Address_Created_Date"]    = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
            Session["oProfile_Address_Expiry_Date"]    = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();
            Session["oProfile_Address_Country"]   = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();

            Session["oPrimary_CC"]    = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
            Session["oPrimary_Mobile"]    = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            Session["oPrimary_Alt_CC"]   = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
            Session["oPrimary_Alternate"]   = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();

            Session["oSecondary_CC"]   = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
            Session["oSecondary_Mobile"]   = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            Session["oSecondary_Alt_CC"]   = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
            Session["oSecondary_Alternate"]     = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();

            Session["oSubprofile1_CC"]     = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
            Session["oSubprofile1_Mobile"]      = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            Session["oSubprofile1_Alt_CC"]    = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
            Session["oSubprofile1_Alternate"]   = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();

            Session["oSubprofile2_CC"]   = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
            Session["oSubprofile2_Mobile"]    = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            Session["oSubprofile2_Alt_CC"]   = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
            Session["oSubprofile2_Alternate"]   = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

            Session["oPrimary_Email"]  = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            Session["oSecondary_Email"]  = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            Session["oSubprofile1_Email"]   = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            Session["oSubprofile2_Email"]  = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            Session["oProfile_Stay_ID"]   = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
            Session["oProfile_Stay_Resort_Name"]  = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            Session["oProfile_Stay_Resort_Room_Number"]  = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            Session["oProfile_Stay_Arrival_Date"]  = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
            Session["oProfile_Stay_Departure_Date"]  = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

            Session["oTour_Details_Guest_Status"]  = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
            Session["oTour_Details_Guest_Sales_Rep"]   = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();

            Session["oTour_Details_Sales_Deck_Check_In"]  = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            Session["oTour_Details_Sales_Deck_Check_Out"]  = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            Session["oTour_Details_Taxi_In_Price"]  = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            Session["oTour_Details_Taxi_In_Ref"]  = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            Session["oTour_Details_Taxi_Out_Price"]  = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            Session["oTour_Details_Taxi_Out_Ref"]  = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();



            DataSet dsqual = Queries.LoadGuestStatusInProfile(Session["ProfileID"].ToString());
            guestatusDropDownList.DataSource = dsqual;
            guestatusDropDownList.DataTextField = "Guest_Status_name";
            guestatusDropDownList.DataValueField = "Guest_Status_name";
            guestatusDropDownList.AppendDataBoundItems = true;
            guestatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            guestatusDropDownList.DataBind();

            DataSet dstour = Queries.LoadSalesRepsInProfile1(office, Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
            toursalesrepDropDownList.DataSource = dstour;
            toursalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            toursalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            toursalesrepDropDownList.AppendDataBoundItems = true;
            toursalesrepDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            toursalesrepDropDownList.DataBind();






        }


        //   Response.Write(ContractdetailsIDTextBox.Text);
    }


 
   
  




       

    [WebMethod]
    public static string getVenueOnCountry(string countryName)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = " select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_Name = '" + countryName + "')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;
    }

    [WebMethod]
    public static string getVenueGroupOnVenue(string venue)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select vg.Venue_Group_ID,vg.Venue_Group_Name from Venue_Group vg where vg.Venue_ID in(select venue.Venue_ID from venue where venue.Venue_Name ='" + venue + "')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(1);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }

    [WebMethod]
    public static string LoadManagersOnVenue(string venue)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadManagersOnVenue1(venue,office);
        while (reader.Read())
        {
            string mn = reader.GetString(0);

            JSON += "[\"" + mn + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }
    

    protected void Button6_Click(object sender, EventArgs e)
    {
        Session["oProfile_Venue_Country"] = ""; Session["oProfile_Venue"] = ""; Session["oProfile_Group_Venue"] = ""; Session["oProfile_Marketing_Program"] = "";
        Session["oProfile_Agent"] = ""; Session["oProfile_Agent_Code"] = ""; Session["oProfile_Member_Type1"] = ""; Session["oProfile_Member_Number1"] = "";
        Session["oProfile_Member_Type2"] = ""; Session["oProfile_Member_Number2"] = ""; Session["oProfile_Employment_status"] = ""; Session["oProfile_Marital_status"] = "";
        Session["oProfile_NOY_Living_as_couple"] = ""; Session["oOffice"] = ""; Session["oComments"] = ""; Session["oManager"] = "";
        Session["ophid"] = ""; Session["ocard"] = "";

        Session["oProfile_Primary_Title"] = ""; Session["oProfile_Primary_Fname"] = ""; Session["oProfile_Primary_Lname"] = "";
        Session["oProfile_Primary_DOB"] = ""; Session["oProfile_Primary_Nationality"] = ""; Session["oProfile_Primary_Country"] = "";
        Session["opage"] = ""; Session["opdesignation"] = ""; Session["oplang"] = "";

        Session["oProfile_Secondary_Title"] = ""; Session["oProfile_Secondary_Fname"] = ""; Session["oProfile_Secondary_Lname"] = "";
        Session["oProfile_Secondary_DOB"] = ""; Session["oProfile_Secondary_Nationality"] = ""; Session["oProfile_Secondary_Country"] = "";
        Session["osage"] = ""; Session["osdesignation"] = ""; Session["oslang"] = "";

        Session["oSub_Profile1_Title"] = ""; Session["oSub_Profile1_Fname"] = ""; Session["oSub_Profile1_Lname"] = "";
        Session["oSub_Profile1_DOB"] = ""; Session["  oSub_Profile1_Nationality"] = ""; Session["oSub_Profile1_Country"] = "";
        Session["osp1age"] = "";

        Session["oSub_Profile2_Title"] = ""; Session["oSub_Profile2_Fname"] = ""; Session["oSub_Profile2_Lname"] = "";
        Session["oSub_Profile2_DOB"] = ""; Session["  oSub_Profile2_Nationality"] = ""; Session["oSub_Profile2_Country"] = "";
        Session["osp2age"] = "";

        Session["oSub_Profile3_Title"] = ""; Session["oSub_Profile3_Fname"] = ""; Session["oSub_Profile3_Lname"] = "";
        Session["oSub_Profile3_DOB"] = ""; Session["  oSub_Profile3_Nationality"] = ""; Session["oSub_Profile3_Country"] = "";
        Session["osp3age"] = "";

        Session["oSub_Profile4_Title"] = ""; Session["oSub_Profile4_Fname"] = ""; Session["oSub_Profile4_Lname"] = "";
        Session["oSub_Profile4_DOB"] = ""; Session["  oSub_Profile4_Nationality"] = ""; Session["oSub_Profile4_Country"] = "";
        Session["osp4age"] = "";

        Session["oProfile_Address_Line1"] = ""; Session["oProfile_Address_Line2"] = ""; Session["oProfile_Address_State"] = "";
        Session["oProfile_Address_city"] = ""; Session["oProfile_Address_Postcode"] = ""; Session["oProfile_Address_Created_Date"] = "";
        Session["oProfile_Address_Expiry_Date"] = ""; Session["oProfile_Address_Country"] = "";

        Session["oPrimary_CC"] = ""; Session["oPrimary_Mobile"] = ""; Session["oPrimary_Alt_CC"] = "";
        Session["oPrimary_Alternate"] = ""; Session["opriOfficecc"] = ""; Session["opriOfficeno"] = "";
     
        Session["osecOfficecc"] = ""; Session["osecofficeno"] = ""; Session["oSecondary_CC"] = "";
        Session["oSecondary_Mobile"] = ""; Session["oSecondary_Alt_CC"] = ""; Session["oSecondary_Alternate"] = "";
      
        Session["oSubprofile1_CC"] = ""; Session["oSubprofile1_Mobile"] = ""; Session["oSubprofile1_Alt_CC"] = ""; Session["oSubprofile1_Alternate"] = "";
        Session["oSubprofile2_CC"] = ""; Session["oSubprofile2_Mobile"] = ""; Session["oSubprofile2_Alt_CC"] = ""; Session["oSubprofile2_Alternate"] = "";

        Session["oSubprofile3_CC"] = ""; Session["oSubprofile3_Mobile"] = ""; Session["oSubprofile3_Alt_CC"] = ""; Session["oSubprofile3_Alternate"] = "";
        Session["oSubprofile4_CC"] = ""; Session["oSubprofile4_Mobile"] = ""; Session["oSubprofile4_Alt_CC"] = ""; Session["oSubprofile4_Alternate"] = "";

        Session["oPrimary_Email"] = ""; Session["oSecondary_Email"] = ""; Session["oSubprofile1_Email"] = "";
        Session["oSubprofile2_Email"] = ""; Session["oSubprofile3_Email"] = ""; Session["oSubprofile4_Email"] = "";
        
        Session["oProfile_Stay_ID"] = ""; Session["oProfile_Stay_Resort_Name"] = ""; Session["oProfile_Stay_Resort_Room_Number"] = "";
        Session["oProfile_Stay_Arrival_Date"] = ""; Session["oProfile_Stay_Departure_Date"] = "";
        
        Session["oTour_Details_Guest_Status"] = ""; Session["oTour_Details_Guest_Sales_Rep"] = ""; Session["oTour_Details_Tour_Date"] = "";
        Session["tourweekno"] = ""; Session["oTour_Details_Sales_Deck_Check_In"] = ""; Session["oTour_Details_Sales_Deck_Check_Out"] = "";
        Session["oTour_Details_Taxi_In_Price"] = ""; Session["oTour_Details_Taxi_In_Ref"] = ""; Session["oTour_Details_Taxi_Out_Price"] = "";
        Session["oTour_Details_Taxi_Out_Ref"] = ""; Session["oComments"] = ""; Session["oregTerms"] = ""; Session["ocomment2"] = "";

        Session["pmobile"] = ""; Session["palternate"] = ""; Session["smobile"] = ""; Session["salternate"] = ""; Session["priOfficeno"] = "";
        Session["sp1mobile"] = ""; Session["sp1alternate"] = ""; Session["sp2mobile"] = ""; Session["sp2alternate"] = ""; Session["secOfficeno"] = "";
        Session["sp3mobile"] = ""; Session["sp3alternate"] = ""; Session["sp4mobile"] = ""; Session["sp4alternate"] = "";

        Session["pmobilec"] = ""; Session["palternatec"] = ""; Session["smobilec"] = ""; Session["salternatec"] = ""; Session["sp1mobilec"] = ""; Session["sp1alternatec"] = "";
        Session["sp2mobilec"] = ""; Session["sp2alternatec"] = ""; Session["sp3mobilec"] = ""; Session["sp3alternatec"] = ""; Session["sp4mobilec"] = ""; Session["sp4alternatec"] = "";

        Session["pcc"] = ""; Session["paltrcc"] = ""; Session["scc"] = ""; Session["saltcc"] = ""; Session["sp1cc"] = ""; Session["sp1altcc"] = ""; Session["priOfficecc"] = "";
        Session["sp2cc"] = ""; Session["sp2altccc"] = ""; Session["sp3cc"] = ""; Session["sp3altccc"] = ""; Session["sp4cc"] = ""; Session["sp4altccc"] = ""; Session["secOfficecc"] = "";

        Session["ocompanyname"] = ""; Session["pemail"] = ""; Session["semail"] = ""; Session["sp1email"] = ""; Session["sp2email"] = ""; Session["sp3email"] = ""; Session["sp4email"] = "";

        Session["regTerms"] = ""; Session["tourweekno"] = "";
    

        DataSet ds = Queries.LoadProfielDetailsFull(profileidTextBox.Text);
        Session["oProfile_Venue_Country"]  = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
        Session["oProfile_Venue"]  = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
        Session["oProfile_Group_Venue"]  = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
        Session["oProfile_Marketing_Program"]  = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
        Session["oProfile_Agent"]   = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
        Session["oProfile_Agent_Code"]  = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
        Session["oProfile_Member_Type1"]  = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
        Session["oProfile_Member_Number1"]  = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
        Session["oProfile_Member_Type2"]  = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
        Session["oProfile_Member_Number2"]  = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
        Session["oProfile_Employment_status"]   = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
        Session["oProfile_Marital_status"]   = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
        Session["oProfile_NOY_Living_as_couple"]   = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
        Session["oOffice"]  = ds.Tables[0].Rows[0]["Office"].ToString();
        Session["oComments"]   = ds.Tables[0].Rows[0]["Comments"].ToString();
        Session["oManager"]  = ds.Tables[0].Rows[0]["Manager"].ToString();
        Session["ophid"]   = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
        Session["ocard"]  = ds.Tables[0].Rows[0]["Card_Holder"].ToString();
        Session["ocomment2"] = ds.Tables[0].Rows[0]["comment2"].ToString();


        Session["oProfile_Primary_Title"]   = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
        Session["oProfile_Primary_Fname"]  = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
        Session["oProfile_Primary_Lname"]  = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
        Session["oProfile_Primary_DOB"]   = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oProfile_Primary_Nationality"]  = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
        Session["oProfile_Primary_Country"]   = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
        Session["opage"]   = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
        Session["opdesignation"]   = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
        Session["oplang"]  = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

        Session["oProfile_Secondary_Title"]  = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
        Session["oProfile_Secondary_Fname"]   = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
        Session["oProfile_Secondary_Lname"] = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
        Session["oProfile_Secondary_DOB"]  = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oProfile_Secondary_Nationality"]   = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
        Session["oProfile_Secondary_Country"] = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
        Session["osage"] = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
        Session["osdesignation"]  = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
        Session["oslang"]   = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

        Session["oSub_Profile1_Title"]   = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
        Session["oSub_Profile1_Fname"]   = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
        Session["oSub_Profile1_Lname"]  = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
        Session["oSub_Profile1_DOB"]  = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);//Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile1_Nationality"]  = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
        Session["oSub_Profile1_Country"]  = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
        Session["osp1age"]   = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

        Session["oSub_Profile2_Title"]   = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
        Session["oSub_Profile2_Fname"]   = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
        Session["oSub_Profile2_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
        Session["oSub_Profile2_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile2_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
        Session["oSub_Profile2_Country"]   = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
        Session["osp2age"]  = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

        Session["oSub_Profile3_Title"]   = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
        Session["oSub_Profile3_Fname"]   = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
        Session["oSub_Profile3_Lname"]  = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
        Session["oSub_Profile3_DOB"]  = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile3_Nationality"]  = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
        Session["oSub_Profile3_Country"]  = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
        Session["osp3age"]  = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

        Session["oSub_Profile4_Title"]  = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
        Session["oSub_Profile4_Fname"]  = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
        Session["oSub_Profile4_Lname"]  = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
        Session["oSub_Profile4_DOB"]   = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile4_Nationality"]   = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
        Session["oSub_Profile4_Country"]  = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
        Session["osp4age"]  = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

        Session["oProfile_Address_Line1"]  = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
        Session["oProfile_Address_Line2"]  = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
        Session["oProfile_Address_State"]   = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
        Session["oProfile_Address_city"]  = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
        Session["oProfile_Address_Postcode"]  = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
        Session["oProfile_Address_Created_Date"]   = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
        Session["oProfile_Address_Expiry_Date"]  = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();
        Session["oProfile_Address_Country"]   = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();

        Session["oPrimary_CC"]    = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
        Session["oPrimary_Mobile"]   = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
        Session["oPrimary_Alt_CC"]  = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
        Session["oPrimary_Alternate"]  = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
        Session["opriOfficecc"]  = ds.Tables[0].Rows[0]["Primary_office_cc"].ToString();
        Session["opriOfficeno"]    = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();

        Session["osecOfficecc"]    = ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString();
        Session["osecofficeno"]    = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();
        Session["oSecondary_CC"]    = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
        Session["oSecondary_Mobile"]  = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
        Session["oSecondary_Alt_CC"]    = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
        Session["oSecondary_Alternate"]   = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();

        Session["oSubprofile1_CC"]   = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
        Session["oSubprofile1_Mobile"]   = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
        Session["oSubprofile1_Alt_CC"]   = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
        Session["oSubprofile1_Alternate"]   = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();

        Session["oSubprofile2_CC"]    = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
        Session["oSubprofile2_Mobile"]      = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
        Session["oSubprofile2_Alt_CC"]     = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
        Session["oSubprofile2_Alternate"]    = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

        Session["oSubprofile3_CC"]    = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
        Session["oSubprofile3_Mobile"]   = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
        Session["oSubprofile3_Alt_CC"]   = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
        Session["oSubprofile3_Alternate"]   = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

        Session["oSubprofile4_CC"]   = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
        Session["oSubprofile4_Mobile"]   = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
        Session["oSubprofile4_Alt_CC"]   = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
        Session["oSubprofile4_Alternate"]   = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();

        Session["oPrimary_Email"]    = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
        Session["oSecondary_Email"]  = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
        Session["oSubprofile1_Email"]  = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
        Session["oSubprofile2_Email"]  = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
        Session["oSubprofile3_Email"]   = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
        Session["oSubprofile4_Email"]  = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

        Session["oProfile_Stay_ID"]   = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
        Session["oProfile_Stay_Resort_Name"]   = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        Session["oProfile_Stay_Resort_Room_Number"]  = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
        Session["oProfile_Stay_Arrival_Date"]   = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
        Session["oProfile_Stay_Departure_Date"]   = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

        Session["oTour_Details_Guest_Status"]  = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
        Session["oTour_Details_Guest_Sales_Rep"]  = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
        Session["oTour_Details_Tour_Date"]    = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
        Session["tourweekno"]   = ds.Tables[0].Rows[0]["Week_number"].ToString();
        Session["oTour_Details_Sales_Deck_Check_In"]    = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
        Session["oTour_Details_Sales_Deck_Check_Out"]   = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
        Session["oTour_Details_Taxi_In_Price"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
        Session["oTour_Details_Taxi_In_Ref"]  = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
        Session["oTour_Details_Taxi_Out_Price"]  = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
        Session["oTour_Details_Taxi_Out_Ref"]  = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
        Session["oComments"]  = ds.Tables[0].Rows[0]["Comments"].ToString();
        Session["oregTerms"]   = ds.Tables[0].Rows[0]["RegTerms"].ToString();
        //update profile

        string user =(string)Session["username"]; 
        createdbyTextBox.Text = user;
        //get office of user
        string office = Queries.GetOffice(user);

        string profile = profileidTextBox.Text;
        string createdby = createdbyTextBox.Text;
        string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
        string venue = VenueDropDownList.SelectedItem.Text;
        string venuegroup = GroupVenueDropDownList.SelectedItem.Text;
        string mktg = Request.Form["MarketingProgramDropDownList"];//MarketingProgramDropDownList.SelectedItem.Text;
        if (mktg=="")
        {
            mktg= MarketingProgramDropDownList.Items[0].Text;

        }
        else
        {
            mktg= Request.Form["MarketingProgramDropDownList"];
        }
        string agents= Request.Form["AgentDropDownList"];// .SelectedItem.Text;
        //string agents1;
        if (agents == "")
        {
            agents = AgentDropDownList.Items[0].Text;
        }
        else
        {
            agents = Request.Form["AgentDropDownList"];
        }
        string agentcode = Request.Form["TONameDropDownList"];// .SelectedItem.Text;
        if (agentcode == "")
        {
            agentcode = TONameDropDownList.Items[0].Text;

        }else
        {
            agentcode = Request.Form["TONameDropDownList"];
        }

        string mgr;

        if (venuegroup=="Coldline" || venuegroup=="COLDLINE")
        {
           mgr = Request.Form["ManagerDropDownList"];// SelectedItem.Text;
            if (mgr == "")
            {
                mgr = ManagerDropDownList.Items[0].Text;

            }
            else
            {
                mgr = Request.Form["ManagerDropDownList"];
            }

        }
        else
        {

             mgr = agentcode;
        }

      



        string photoidentity;
        if (Request.Form["pidentity"] == null)
        {
            photoidentity = "";
        }
        else
        {
            photoidentity = Request.Form["pidentity"];
        }
        string card;
        if (Request.Form["card"] == null)
        {
            card = "";
        }
        else
        {
            card = Request.Form["card"];
        }

        //member details
        string membertype1 = MemType1DropDownList.SelectedItem.Text;// .SelectedItem.Text;
        string memno1 = Memno1TextBox.Text;
        if (mktg == "Owner" || mktg == "OWNER")
        {
            membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno = Memno1TextBox.Text;
            if (memno == null || memno=="")
            {
                memno1 = "";
            }
            else
            {
                memno1 = Memno1TextBox.Text;
            }

        }
        else
        {
            membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno =TypeDropDownList.SelectedItem.Text;
            if (memno == null || memno=="")
            {

                memno1 = "";
            }
            else
            {

                memno1 = TypeDropDownList.SelectedItem.Text;
            }


        }



        string membertype2 = Request.Form[MemType2DropDownList.UniqueID];// .SelectedItem.Text;
        string memno2 = Memno2TextBox.Text;




        //primary profile
        string primarytitle = PrimaryTitleDropDownList.SelectedItem.Text;
        string primaryfname = pfnameTextBox.Text.ToUpper();
        string primaylname = plnameTextBox.Text.ToUpper();
        string primarydob = primarydobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd");
        string primarynationality = PrimarynationalityDropDownList.SelectedItem.Text;
        string primarycountry = primarycountryDropDownList.SelectedItem.Text;
        string npage = primaryAge.Text;
        string npdesg = pdesginationTextBox.Text.ToUpper();
        string primarylanguage;


        if (Request.Form["primarylang"] == null)
        {
            primarylanguage = "";
        }
        else
        {
            primarylanguage = Request.Form["primarylang"];

        }

        //if (primarymobileDropDownList.SelectedIndex == 0)
        //{
        //    pcc = "";

        //}
        //else
        //{

          Session["pcc"] = Request.Form["primarymobileDropDownList"];//primarymobileDropDownList.SelectedItem.Text;

            if (Session["pcc"].ToString() == "")
            {
            Session["pcc"] = primarymobileDropDownList.Items[0].Text;
            }
            else {
            Session["pcc"] = Request.Form["primarymobileDropDownList"];

            }

        //}
        //if (primaryalternateDropDownList.SelectedIndex == 0)
        //{
        //    paltrcc = "";
        //}
        //else
        //{

        Session["paltrcc"]  = Request.Form["primaryalternateDropDownList"]; //primaryalternateDropDownList.SelectedItem.Text;
            if (Session["paltrcc"].ToString() == "")
            {
            Session["paltrcc"] = primaryalternateDropDownList.Items[0].Text;
            }
            else {
            Session["paltrcc"] = Request.Form["primaryalternateDropDownList"];
            }
        //}
        if (pmobileTextBox.Text == "" || pmobileTextBox.Text == null)
        {
          Session["pmobile"] = "";
        }
        else
        {
            Session["pmobile"] = pmobileTextBox.Text;
        }

        if (palternateTextBox.Text == "" || palternateTextBox.Text == null)
        {
            Session["palternate"] = "";
        }
        else
        {
            Session["palternate"] = palternateTextBox.Text;
        }

        if (pemailTextBox.Text == "" || pemailTextBox.Text == null)
        {
            Session["pemail"]  = "";
        }
        else
        {
            Session["pemail"]  = pemailTextBox.Text.ToUpper();
        }

        //secondary profile

        string secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
        string secondaryfname = sfnameTextBox.Text.ToUpper();
        string secondarylname = slnameTextBox.Text.ToUpper();
        string secondarydob = secondarydobdatepicker.Text;//Convert.ToDateTime(sdobdatepicker.Text).ToString("yyyy-MM-dd"); 
        string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
        string secondarycountry = secondarycountryDropDownList.SelectedItem.Text;
        string nsage = secondaryAge.Text;
        string nsdesg = sdesignationTextBox.Text.ToUpper();

        string secondarylanguage;
        if (Request.Form["seclang"] == null)
        {
            secondarylanguage = "";
        }
        else
        {
            secondarylanguage = Request.Form["seclang"];

        }
        //if (secondarymobileDropDownList.SelectedIndex == 0)
        //{
        //    scc = "";
        //}
        //else
        //{

        Session["scc"] = Request.Form["secondarymobileDropDownList"];//secondarymobileDropDownList.SelectedItem.Text;
            if (Session["scc"].ToString() == "")
            {
            Session["scc"] = secondarymobileDropDownList.Items[0].Text;
            }else
            {
            Session["scc"] = Request.Form["secondarymobileDropDownList"];
            }
        //}

        //if (secondaryalternateDropDownList.SelectedIndex == 0)
        //{
        //    saltcc = "";
        //}
        //else
        //{

        Session["saltcc"]  = Request.Form["secondaryalternateDropDownList"];//secondaryalternateDropDownList.SelectedItem.Text;
            if (Session["saltcc"].ToString() == "")
            {
            Session["saltcc"] = secondaryalternateDropDownList.Items[0].Text;
            }
            else
            {

            Session["saltcc"] = Request.Form["secondaryalternateDropDownList"];


            }

        Session["priOfficecc"]   = Request.Form["pofficecodeDropDownList"];
        if (Session["priOfficecc"].ToString() == "")
        {
            Session["priOfficecc"] = pofficecodeDropDownList.Items[0].Text;
        }
        else
        {
            Session["priOfficecc"] = Request.Form["pofficecodeDropDownList"];
        }


        Session["secOfficecc"]  = Request.Form["sofficecodeDropDownList"];
        if (Session["secOfficecc"].ToString() == "")
        {
            Session["secOfficecc"] = sofficecodeDropDownList.Items[0].Text;
        }
        else
        {
            Session["secOfficecc"] = Request.Form["sofficecodeDropDownList"];
        }

        //}

        if (smobileTextBox.Text == "" || smobileTextBox.Text == null)
        {
            Session["smobile"]   = "";
        }
        else
        {
            Session["smobile"]   = smobileTextBox.Text;
        }
        if (salternateTextBox.Text == "" || salternateTextBox.Text == null)
        {
            Session["salternate"]  = "";
        }
        else
        {
            Session["salternate"] = salternateTextBox.Text;
        }

        if (pofficenoTextBox.Text == "" || pofficenoTextBox.Text == null)
        {
            Session["priOfficeno"]  = "";
        }
        else
        {
            Session["priOfficeno"] = pofficenoTextBox.Text;
        }

        if (sofficenoTextBox.Text == "" || sofficenoTextBox.Text == null)
        {
            Session["secOfficeno"]  = "";
        }
        else
        {
            Session["secOfficeno"] = sofficenoTextBox.Text;
        }


        if (semailTextBox.Text == "" || semailTextBox.Text == null)
        {
            Session["semail"]   = "";
        }
        else
        {
            Session["semail"]  = semailTextBox.Text.ToUpper();
        }
        //sub profile1


        string sp1title = sp1titleDropDownList.SelectedItem.Text;
        string sp1fname = sp1fnameTextBox.Text.ToUpper();
        string sp1lname = sp1lnameTextBox.Text.ToUpper();
        string sp1dob = sp1dobdatepicker.Text;//Convert.ToDateTime(sp1dobdatepicker.Text).ToString("yyyy-MM-dd"); 


        string sp1nationality = sp1nationalityDropDownList.SelectedItem.Text;
        string sp1country = sp1countryDropDownList.SelectedItem.Text;
        string nsp1age = subProfile1Age.Text;
        //if (sp1mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp1cc = "";
        //}
        //else
        //{

        Session["sp1cc"]   = Request.Form["sp1mobileDropDownList"];//sp1mobileDropDownList.SelectedItem.Text;
            if (Session["sp1cc"].ToString() == "")
            {
            Session["sp1cc"] = sp1mobileDropDownList.Items[0].Text;
            }
            else
            {

            Session["sp1cc"] = Request.Form["sp1mobileDropDownList"];

            }
        //}

        //if (sp1alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp1altcc = "";
        //}
        //else
        //{

           Session["sp1altcc"]  = Request.Form["sp1alternateDropDownList"];// sp1alternateDropDownList.SelectedItem.Text;
           
            if (Session["sp1altcc"].ToString() == "")
            {
            Session["sp1altcc"] = sp1alternateDropDownList.Items[0].Text;
            }
            else
            {
            Session["sp1altcc"] = Request.Form["sp1alternateDropDownList"]; ;
            }
        //}


        if (sp1mobileTextBox.Text == "" || sp1mobileTextBox.Text == null)
        {
            Session["sp1mobile"]   = "";
        }
        else
        {
            Session["sp1mobile"]  = sp1mobileTextBox.Text;
        }
        if (sp1alternateTextBox.Text == "" || sp1alternateTextBox.Text == null)
        {
            Session["sp1alternate"]  = "";
        }
        else
        {
            Session["sp1alternate"] = sp1alternateTextBox.Text;
        }
        if (sp1pemailTextBox.Text == "" || sp1pemailTextBox.Text == null)
        {
            Session["sp1email"]   = "";
        }
        else
        {
            Session["sp1email"] = sp1pemailTextBox.Text.ToUpper();
        }



        //sub profile 2
        string sp2title = sp2titleDropDownList.SelectedItem.Text;
        string sp2fname = sp2fnameTextBox.Text.ToUpper();
        string sp2lname = sp2lnameTextBox.Text.ToUpper();
        string sp2dob = sp2dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp2nationality = sp2nationalityDropDownList.SelectedItem.Text;
        string sp2country = sp2countryDropDownList.SelectedItem.Text;
        string nsp2age = subProfile2Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        Session["sp2cc"]  = Request.Form["sp2mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
            if (Session["sp2cc"].ToString() == "")
            {
            Session["sp2cc"] = sp2mobileDropDownList.Items[0].Text;
            }else
            {

            Session["sp2cc"] = Request.Form["sp2mobileDropDownList"];

            }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        Session["sp2altccc"]  = Request.Form["sp2alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
            if (Session["sp2altccc"].ToString() == "")
            {
            Session["sp2altccc"] = sp2alternateDropDownList.Items[0].Text;
            }
            else
            {
            Session["sp2altccc"] = Request.Form["sp2alternateDropDownList"];

            }
        //}


        if (sp2mobileTextBox.Text == "" || sp2mobileTextBox.Text == null)
        {
            Session["sp2mobile"]  = "";
        }
        else
        {
            Session["sp2mobile"] = sp2mobileTextBox.Text;

        }
        if (sp2alternateTextBox.Text == "" || sp2alternateTextBox.Text == null)
        {
            Session["sp2alternate"]  = "";

        }
        else
        {
            Session["sp2alternate"] = sp2alternateTextBox.Text;

        }
        if (sp2pemailTextBox.Text == "" || sp2pemailTextBox.Text == null)
        {
            Session["sp2email"]  = "";
        }
        else
        {
            Session["sp2email"] = sp2pemailTextBox.Text.ToUpper();
        }

        // sub profile 3//
        string sp3title = sp3titleDropDownList.SelectedItem.Text;
        string sp3fname = sp3fnameTextBox.Text.ToUpper();
        string sp3lname = sp3lnameTextBox.Text.ToUpper();
        string sp3dob = sp3dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp3nationality = sp3nationalityDropDownList.SelectedItem.Text;
        string sp3country = sp3countryDropDownList.SelectedItem.Text;
        string nsp3age = subProfile3Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        Session["sp3cc"]  = Request.Form["sp3mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (Session["sp3cc"].ToString() == "")
        {
            Session["sp3cc"] = sp3mobileDropDownList.Items[0].Text;
        }
        else
        {

            Session["sp3cc"] = Request.Form["sp3mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        Session["sp3altccc"]  = Request.Form["sp3alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (Session["sp3altccc"].ToString() == "")
        {
            Session["sp3altccc"] = sp3alternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["sp3altccc"] = Request.Form["sp3alternateDropDownList"];

        }
        //}


        if (sp3mobileTextBox.Text == "" || sp3mobileTextBox.Text == null)
        {
            Session["sp3mobile"]    = "";
        }
        else
        {
            Session["sp3mobile"] = sp3mobileTextBox.Text;

        }
        if (sp3alternateTextBox.Text == "" || sp3alternateTextBox.Text == null)
        {
            Session["sp3alternate"]  = "";

        }
        else
        {
            Session["sp3alternate"] = sp3alternateTextBox.Text;

        }
        if (sp3pemailTextBox.Text == "" || sp3pemailTextBox.Text == null)
        {
            Session["sp3email"]    = "";
        }
        else
        {
            Session["sp3email"] = sp3pemailTextBox.Text.ToUpper();
        }
        //end//

        // sub profile 4//
        string sp4title = sp4titleDropDownList.SelectedItem.Text;
        string sp4fname = sp4fnameTextBox.Text.ToUpper();
        string sp4lname = sp4lnameTextBox.Text.ToUpper();
        string sp4dob = sp4dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp4nationality = sp4nationalityDropDownList.SelectedItem.Text;
        string sp4country = sp4countryDropDownList.SelectedItem.Text;
        string nsp4age = subProfile4Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        Session["sp4cc"]   = Request.Form["sp4mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (Session["sp4cc"].ToString() == "")
        {
            Session["sp4cc"] = sp4mobileDropDownList.Items[0].Text;
        }
        else
        {

            Session["sp4cc"] = Request.Form["sp4mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        Session["sp4altccc"]  = Request.Form["sp4alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (Session["sp4altccc"].ToString() == "")
        {
            Session["sp4altccc"] = sp4alternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["sp4altccc"] = Request.Form["sp4alternateDropDownList"];

        }
        //}


        if (sp4mobileTextBox.Text == "" || sp4mobileTextBox.Text == null)
        {
            Session["sp4mobile"]  = "";
        }
        else
        {
            Session["sp4mobile"] = sp4mobileTextBox.Text;

        }
        if (sp4alternateTextBox.Text == "" || sp4alternateTextBox.Text == null)
        {
            Session["sp4alternate"]    = "";

        }
        else
        {
            Session["sp4alternate"] = sp4alternateTextBox.Text;

        }
        if (sp4pemailTextBox.Text == "" || sp4pemailTextBox.Text == null)
        {
            Session["sp4email"]   = "";
        }
        else
        {
            Session["sp4email"] = sp4pemailTextBox.Text.ToUpper();
        }
        // end//


        //address

        string address1 = address1TextBox.Text.ToUpper();
        string address2 = address2TextBox.Text.ToUpper();
        string state = Request.Form["StateDropDownList"];// StateDropDownList.SelectedItem.Text;
        if (state=="")
        {
            state = StateDropDownList.Items[0].Text;
        }else
        {
            state = Request.Form["StateDropDownList"];


        }
        string city = cityTextBox.Text.ToUpper();
        string pincode = pincodeTextBox.Text;
        string acountry = AddCountryDropDownList.SelectedItem.Text;

        //other details

        string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
        string maritalstatus = maritalstatusDropDownList.SelectedItem.Text;
        string livingyrs = livingyrsTextBox.Text;

        //stay details
        string resort = resortTextBox.Text.ToUpper();
        string roomno = roomnoTextBox.Text.ToUpper();
        string arrivaldate = arrivaldatedatepicker.Text;
        string departuredate = departuredatedatepicker.Text;

        //guest status

        string gueststatus = guestatusDropDownList.SelectedItem.Text;
        string salesrep = toursalesrepDropDownList.SelectedItem.Text;
        string timeIn = timeinTextBox.Text;
        string timeOut = timeoutTextBox.Text;
        // string tourdate = tourdatedatepicker.Text;
        string tourdate;
        int wkno;
        if (tourdatedatepicker.Text == "" || tourdatedatepicker.Text == null || tourdatedatepicker.Text == "NaN" || tourdatedatepicker.Text == "1-1-1990")
        {
            tourdate = "";
            wkno = 0;
        }
        else
        {
            tourdate = tourdatedatepicker.Text;
            wkno = Queries.GetWkNumber(Convert.ToDateTime(tourdate));
            tourdate = Convert.ToDateTime(tourdatedatepicker.Text).ToString("dd-MM-yyyy");
        }
        string taxin = inpriceTextBox.Text.ToUpper();
        string taxirefin = inrefTextBox.Text.ToUpper();
        string taxiout = outpriceTextBox.Text.ToUpper();
        string taxirefout = outrefTextBox.Text.ToUpper();
        string ProComments = commentsTextBox.Text.ToUpper();
        string ProComment2 = comment2.Text.ToUpper();
        if (CheckBox1.Checked)
        {


           Session["regTerms"] = "Y";
        }
        else
        {
            Session["regTerms"]  = "N";

        }

                //update
                if (String.Compare(Session["ocompanyname"].ToString()  , companynameTextBox.Text) != 0)
                {
                    int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
                    string log3 = "Company Name changed from:" + Session["ocompanyname"].ToString() + " " + "to" + companynameTextBox.Text;
                    int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

                }
                else
                {
                }
             	
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon4 = new SqlConnection(conn);

        string query4 = "select Gift_ID_Option+'-'+GiftItem from gift where Profile_ID='" + Session["ProfileID"].ToString() + "'";
        sqlcon4.Open();
        SqlCommand cmd4 = new SqlCommand(query4, sqlcon4);
        SqlDataReader reader4 = cmd4.ExecuteReader();
        while (reader4.Read())
        {
            string name = reader4.GetString(0);
            string act1 = "Deleted:" + name;
            int insertlog2 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act1, user, DateTime.Now.ToString());
        }

        reader4.Close();
        sqlcon4.Close();

        SqlConnection sqlcon2 = new SqlConnection(conn);
        string query2 = "delete from gift where Profile_ID='" + Session["ProfileID"].ToString() + "'";
        sqlcon2.Open();
        SqlCommand cmd2 = new SqlCommand(query2, sqlcon2);
        cmd2.ExecuteNonQuery();
        sqlcon2.Close();


           string val = Request.Form["giftoptionDropDownList"];
        if (val=="" || val==null)
        {

        }else
        {


        string[] value = val.Split(new Char[] { ',', '-' },
                                  StringSplitOptions.RemoveEmptyEntries);




        for (int i = 0; i < value.Length; i = i + 2)
        {
            conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select Gift_Option_Name,Item from Gift_Option where Gift_Option_Name='" + value[i] + "' and Item='" + value[i + 1] + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string giftname = reader.GetString(0);
                string item = reader.GetString(1);


                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select distinct Profile_ID from Gift where Profile_ID='" + Session["ProfileID"].ToString() + "'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {



                        int year = DateTime.Now.Year;
                        string giftid = Queries.GetProfileGift(office);
                        int insert = Queries.InsertGiftOption(giftid, giftname.Trim(), TextBox13.Text, TextBox22.Text,profileidTextBox.Text, item.Trim(), "");
                        int updategift = Queries.UpdateGiftValue(office, year);
                        string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftname + "," + "Voucherno:" + TextBox13.Text + "," + "Comments:" + TextBox22.Text + "," + "Profile id:" + Session["ProfileID"].ToString() + "," + "Item:" + item;
                        int insertlog11 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log11, user, DateTime.Now.ToString());



                    }
                }
                else
                {


                    int year = DateTime.Now.Year;
                    string giftid = Queries.GetProfileGift(office);
                    int insert = Queries.InsertGiftOption(giftid, giftname.Trim(), TextBox13.Text, TextBox22.Text, Session["ProfileID"].ToString(), item.Trim(), "");
                    int updategift = Queries.UpdateGiftValue(office, year);
                    string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftname + "," + "Voucherno:" + TextBox13.Text + "," + "Comments:" + TextBox22.Text + "," + "Profile id:" + Session["ProfileID"].ToString() + "," + "Item:" + item;
                    int insertlog11 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log11, user, DateTime.Now.ToString());

                }

                reader1.Close();
                sqlcon1.Close();


            }
            reader.Close();
            sqlcon.Close();

        }
}

        if (String.Compare(Session["oProfile_Venue_Country"].ToString() , venuecountry) != 0)
        {
            string act = "venue country changed from:" + Session["oProfile_Venue_Country"].ToString() + "To:" + venuecountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Venue"].ToString(), venue) != 0)
        {
            string act = "venue changed from:" + Session["oProfile_Venue"].ToString() + "To:" + venue;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Group_Venue"].ToString() , venuegroup) != 0)
        {
            string act = "venue group changed from:" + Session["oProfile_Group_Venue"].ToString() + "To:" + venuegroup;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Marketing_Program"].ToString() , mktg) != 0)
        {
            string act = "marketing prgm changed from:" + Session["oProfile_Marketing_Program"].ToString() + "To:" + mktg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Agent"].ToString(), agents) != 0)
        {
            string act = "agent name changed from:" + Session["oProfile_Agent"].ToString() + "To:" + agents;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Agent_Code"].ToString(), agentcode) != 0)
        {
            string act = "To Name changed from:" + Session["oProfile_Agent_Code"].ToString() + "To:" + agentcode;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oManager"].ToString() , mgr) != 0)
        {
            string act = "manager changed from:" + Session["oManager"].ToString()   + "To:" + mgr;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Type1"].ToString() , membertype1) != 0)
        {
            string act = "membertype1 changed from:" + Session["oProfile_Member_Type1"].ToString() + "To:" + membertype1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ophid"].ToString(), photoidentity) != 0)
        {
            string act = "Photo Identity changed from:" + Session["ophid"].ToString() + "To:" + photoidentity;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocard"].ToString(), card) != 0)
        {
            string act = "Card Holder value changed from:" + Session["ocard"].ToString()+ "To:" + card;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Number1"].ToString() , memno1) != 0)
        {
            string act = "memno1 changed from:" + Session["oProfile_Member_Number1"].ToString() + "To:" + memno1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Type2"].ToString() , membertype2) != 0)
        {
            string act = "membertype2 changed from:" + Session["oProfile_Member_Type2"].ToString() + "To:" + membertype2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Number2"].ToString(), memno2) != 0)
        {
            string act = "memno2 changed from:" + Session["oProfile_Member_Number2"].ToString() + "To:" + memno2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Title"].ToString(), primarytitle) != 0)
        {
            string act = "primary title changed from:" + Session["oProfile_Primary_Title"].ToString() + "To:" + primarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Fname"].ToString(), primaryfname) != 0)
        {
            string act = "primary fname changed from:" + Session["oProfile_Primary_Fname"].ToString() + "To:" + primaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Lname"].ToString(), primaylname) != 0)
        {
            string act = "primay lname changed from:" + Session["oProfile_Primary_Lname"].ToString() + "To:" + primaylname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_DOB"].ToString(), primarydob) != 0)
        {
            string act = "primary dob changed from:" + Session["oProfile_Primary_DOB"].ToString() + "To:" + primarydob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Nationality"].ToString(), primarynationality) != 0)
        {
            string act = "primary nationality changed from:" + Session["oProfile_Primary_Nationality"].ToString() + "To:" + primarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Country"].ToString(), primarycountry) != 0)
        {
            string act = "primary country changed from:" + Session["oProfile_Primary_Country"].ToString() + "To:" + primarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["opage"].ToString(), npage) != 0)
        {
            string act = "primary age changed from:" + Session["opage"].ToString() + "To:" + npage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["opdesignation"].ToString(), npdesg) != 0)
        {
            string act = "primary designation changed from:" + Session["opdesignation"].ToString() + "To:" + npdesg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oplang"].ToString(), primarylanguage) != 0)
        {
            string act = "primary Language changed from:" + Session["oplang"].ToString() + "To:" + primarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_CC"].ToString(), Session["pcc"].ToString()  ) != 0)
        {
            string act = "primary mobile code changed from:" + Session["oPrimary_CC"].ToString() + "To:" + Session["pcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_Mobile"].ToString(), Session["pmobile"].ToString()) != 0)
        {
            string act = "primary mobile no changed from:" + Session["oPrimary_Mobile"].ToString() + "To:" + Session["pmobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_Alt_CC"].ToString(), Session["paltrcc"].ToString()  ) != 0)
        {
            string act = "primary mobile changed from:" + Session["oPrimary_Alt_CC"].ToString() + "To:" + Session["paltrcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_Alternate"].ToString(), Session["palternate"].ToString() ) != 0)
        {
            string act = "primary alternate no changed from:" + Session["oPrimary_Alternate"].ToString() + "To:" + Session["palternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["opriOfficecc"].ToString(), Session["priOfficecc"].ToString()  ) != 0)
        {
            string act = "primary office cc changed from:" + Session["opriOfficecc"].ToString() + "To:" + Session["priOfficecc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["opriOfficeno"].ToString(), Session["priOfficeno"].ToString() ) != 0)
        {
            string act = "primary office no changed from:" + Session["opriOfficeno"].ToString() + "To:" + Session["priOfficeno"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["oPrimary_Email"].ToString(), Session["pemail"].ToString()  ) != 0)
        {
            string act = "primary email changed from:" + Session["oPrimary_Email"].ToString() + "To:" + Session["pemail"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Title"].ToString(), secondarytitle) != 0)
        {
            string act = "secondary title changed from:" + Session["oProfile_Secondary_Title"].ToString() + "To:" + secondarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Fname"].ToString(), secondaryfname) != 0)
        {
            string act = "secondary fname changed from:" + Session["oProfile_Secondary_Fname"].ToString() + "To:" + secondaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Lname"].ToString(), secondarylname) != 0)
        {
            string act = "secondary lname changed from:" + Session["oProfile_Secondary_Lname"].ToString() + "To:" + secondarylname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_DOB"].ToString(), secondarydob) != 0)
        {
            string act = "secondary dob changed from:" + Session["oProfile_Secondary_DOB"].ToString() + "To:" + secondarydob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oProfile_Secondary_Nationality"].ToString(), secondarynationality) != 0)
        {
            string act = "secondary nationality changed from:" + Session["oProfile_Secondary_Nationality"].ToString() + "To:" + secondarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osage"].ToString(), nsage) != 0)
        {
            string act = "secondary age changed from:" + Session["osage"].ToString() + "To:" + nsage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osdesignation"].ToString(), nsdesg) != 0)
        {
            string act = "secondary designation changed from:" + Session["osdesignation"].ToString() + "To:" + nsdesg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oslang"].ToString(), secondarylanguage) != 0)
        {
            string act = "secondary Language changed from:" + Session["oslang"].ToString() + "To:" + secondarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Country"].ToString(), secondarycountry) != 0)
        {
            string act = "secondary country changed from:" + Session["oProfile_Secondary_Country"].ToString() + "To:" + secondarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSecondary_CC"].ToString(), Session["scc"].ToString() ) != 0)
        {
            string act = "secondary mobile code changed from:" + Session["oSecondary_CC"].ToString() + "To:" + Session["scc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSecondary_Mobile"].ToString(), Session["smobile"].ToString()  ) != 0)
        {
            string act = "secondary mobile no changed from:" + Session["oSecondary_Mobile"].ToString() + "To:" + Session["smobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());

        }
        else { }
        if (String.Compare(Session["oSecondary_Alt_CC"].ToString(), Session["saltcc"].ToString() ) != 0)
        {
            string act = "secondary alternaet num code changed from:" + Session["oSecondary_Alt_CC"].ToString() + "To:" + Session["saltcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSecondary_Alternate"].ToString(), Session["salternate"].ToString() ) != 0)
        {
            string act = "secondary alternate no changed from:" + Session["oSecondary_Alternate"].ToString() + "To:" + Session["salternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["osecOfficecc"].ToString(), Session["secOfficecc"].ToString() ) != 0)
        {
            string act = "secondary office cc changed from:" + Session["osecOfficecc"].ToString() + "To:" + Session["secOfficecc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["osecofficeno"].ToString(), Session["secOfficeno"].ToString()) != 0)
        {
            string act = "secondary office no changed from:" + Session["osecofficeno"].ToString() + "To:" + Session["secOfficeno"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oSecondary_Email"].ToString(), Session["semail"].ToString()  ) != 0)
        {
            string act = "secondary email changed from:" + Session["oSecondary_Email"].ToString() + "To:" + Session["semail"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Title"].ToString(), sp1title) != 0)
        {
            string act = "subprofile1 title changed from:" + Session["oSub_Profile1_Title"].ToString() + "To:" + sp1title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Fname"].ToString(), sp1fname) != 0)
        {
            string act = "subprofile1 fname changed from:" + Session["oSub_Profile1_Fname"].ToString() + "To:" + sp1fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Lname"].ToString(), sp1lname) != 0)
        {
            string act = "subprofile1 lname changed from:" + Session["oSub_Profile1_Lname"].ToString() + "To:" + sp1lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_DOB"].ToString(), sp1dob) != 0)
        {
            string act = "subprofile1 dob changed from:" + Session["oSub_Profile1_DOB"].ToString() + "To:" + sp1dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Nationality"].ToString(), sp1nationality) != 0)
        {
            string act = "subprofile1 nationality changed from:" + Session["oSub_Profile1_Nationality"].ToString() + "To:" + sp1nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp1age"].ToString(), nsp1age) != 0)
        {
            string act = "subprofile1 age changed from:" + Session["osp1age"].ToString() + "To:" + nsp1age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Country"].ToString(), sp1country) != 0)
        {
            string act = "subprofile1 country changed from:" + Session["oSub_Profile1_Country"].ToString() + "To:" + sp1country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_CC"].ToString(), Session["sp1cc"].ToString()  ) != 0)
        {
            string act = "subprofile1 mobile code changed from:" + Session["oSubprofile1_CC"].ToString() + "To:" + Session["sp1cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_Mobile"].ToString(), Session["sp1mobile"].ToString() ) != 0)
        {
            string act = "subprofile1 mobile no changed from:" + Session["oSubprofile1_Mobile"].ToString() + "To:" + Session["sp1mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_Alt_CC"].ToString(), Session["sp1altcc"].ToString()  ) != 0)
        {
            string act = "subprofile1 alternate no code changed from:" + Session["oSubprofile1_Alt_CC"].ToString() + "To:" + Session["sp1altcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_Alternate"].ToString(), Session["sp1alternate"].ToString()) != 0)
        {
            string act = "subprofile1 alternate changed from:" + Session["oSubprofile1_Alternate"].ToString() + "To:" + Session["sp1alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["oSubprofile1_Email"].ToString(), Session["sp1email"].ToString()  ) != 0)
        {
            string act = "subprofile1 email changed from:" + Session["oSubprofile1_Email"].ToString() + "To:" + Session["sp1email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Title"].ToString(), sp2title) != 0)
        {
            string act = "subprofile2 title changed from:" + Session["oSub_Profile2_Title"].ToString() + "To:" + sp2title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Fname"].ToString(), sp2fname) != 0)
        {
            string act = "subprofile2 fname changed from:" + Session["oSub_Profile2_Fname"].ToString() + "To:" + sp2fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Lname"].ToString(), sp2lname) != 0)
        {
            string act = "subprofile2 lname changed from:" + Session["oSub_Profile2_Lname"].ToString() + "To:" + sp2lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_DOB"].ToString(), sp2dob) != 0)
        {
            string act = "subprofile2 dob changed from:" + Session["oSub_Profile2_DOB"].ToString() + "To:" + sp2dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Nationality"].ToString(), sp2nationality) != 0)
        {
            string act = "subprofile2 nationality changed from:" + Session["oSub_Profile2_Nationality"].ToString() + "To:" + sp2nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp2age"].ToString(), nsp2age) != 0)
        {
            string act = "subprofile2 age changed from:" + Session["osp2age"].ToString() + "To:" + nsp2age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Country"].ToString(), sp2country) != 0)

        {
            string act = "subprofile2 country changed from:" + Session["oSub_Profile2_Country"].ToString() + "To:" + sp2country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_CC"].ToString(), Session["sp2cc"].ToString() ) != 0)
        {
            string act = "subprofile2 mobile code changed from:" + Session["oSubprofile2_CC"].ToString() + "To:" + Session["sp2cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Mobile"].ToString(), Session["sp2mobile"].ToString() ) != 0)
        {
            string act = "subprofile2 mobile no changed from:" + Session["oSubprofile2_Mobile"].ToString() + "To:" + Session["sp2mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Alt_CC"].ToString(), Session["sp2altccc"].ToString() ) != 0)
        {
            string act = "subprofile2 alternate no code changed from:" + Session["oSubprofile2_Alt_CC"].ToString() + "To:" + Session["sp2altccc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Alternate"].ToString(), Session["sp2alternate"].ToString() ) != 0)
        {
            string act = "subprofile2 alternate no changed from:" + Session["oSubprofile2_Alternate"].ToString() + "To:" + Session["sp2alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Email"].ToString(), Session["sp2email"].ToString()  ) != 0)
        {
            string act = "subprofile2 email changed from:" + Session["oSubprofile2_Email"].ToString() + "To:" + Session["sp2email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        // sub profile 3//
        if (String.Compare(Session["oSub_Profile3_Title"].ToString(), sp3title) != 0)
        {
            string act = "subprofile3 title changed from:" + Session["oSub_Profile3_Title"].ToString() + "To:" + sp3title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Fname"].ToString(), sp3fname) != 0)
        {
            string act = "subprofile3 fname changed from:" + Session["oSub_Profile3_Fname"].ToString() + "To:" + sp3fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Lname"].ToString(), sp3lname) != 0)
        {
            string act = "subprofile3 lname changed from:" + Session["oSub_Profile3_Lname"].ToString() + "To:" + sp3lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_DOB"].ToString(), sp3dob) != 0)
        {
            string act = "subprofile3 dob changed from:" + Session["oSub_Profile3_DOB"].ToString() + "To:" + sp3dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Nationality"].ToString(), sp3nationality) != 0)
        {
            string act = "subprofile3 nationality changed from:" + Session["oSub_Profile3_Nationality"].ToString() + "To:" + sp3nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp3age"].ToString(), nsp3age) != 0)
        {
            string act = "subprofile3 age changed from:" + Session["osp3age"].ToString() + "To:" + nsp3age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Country"].ToString(), sp3country) != 0)

        {
            string act = "subprofile3 country changed from:" + Session["oSub_Profile3_Country"].ToString() + "To:" + sp3country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_CC"].ToString(), Session["sp3cc"].ToString() ) != 0)
        {
            string act = "subprofile3 mobile code changed from:" + Session["oSubprofile3_CC"].ToString() + "To:" + Session["sp3cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Mobile"].ToString(), Session["sp3mobile"].ToString() ) != 0)
        {
            string act = "subprofile3 mobile no changed from:" + Session["oSubprofile3_Mobile"].ToString() + "To:" + Session["sp3mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Alt_CC"].ToString(), Session["sp3altccc"].ToString() ) != 0)
        {
            string act = "subprofile3 alternate no code changed from:" + Session["oSubprofile3_Alt_CC"].ToString() + "To:" + Session["sp3altccc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Alternate"].ToString(), Session["sp3alternate"].ToString() ) != 0)
        {
            string act = "subprofile3 alternate no changed from:" + Session["oSubprofile3_Alternate"].ToString() + "To:" + Session["sp3alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Email"].ToString(), Session["sp3email"].ToString() ) != 0)
        {
            string act = "subprofile3 email changed from:" + Session["oSubprofile3_Email"].ToString() + "To:" + Session["sp3email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        // end//



        // sub profile 4//
        if (String.Compare(Session["oSub_Profile4_Title"].ToString(), sp4title) != 0)
        {
            string act = "subprofile4 title changed from:" + Session["oSub_Profile4_Title"].ToString() + "To:" + sp4title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Fname"].ToString(), sp4fname) != 0)
        {
            string act = "subprofile4 fname changed from:" + Session["oSub_Profile4_Fname"].ToString() + "To:" + sp4fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Lname"].ToString(), sp4lname) != 0)
        {
            string act = "subprofile4 lname changed from:" + Session["oSub_Profile4_Lname"].ToString() + "To:" + sp4lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_DOB"].ToString(), sp4dob) != 0)
        {
            string act = "subprofile4 dob changed from:" + Session["oSub_Profile4_DOB"].ToString() + "To:" + sp4dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Nationality"].ToString(), sp4nationality) != 0)
        {
            string act = "subprofile4 nationality changed from:" + Session["oSub_Profile4_Nationality"].ToString() + "To:" + sp4nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp4age"].ToString(), nsp4age) != 0)
        {
            string act = "subprofile4 age changed from:" + Session["osp4age"].ToString() + "To:" + nsp4age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Country"].ToString(), sp4country) != 0)

        {
            string act = "subprofile4 country changed from:" + Session["oSub_Profile4_Country"].ToString() + "To:" + sp4country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_CC"].ToString(), Session["sp4cc"].ToString() ) != 0)
        {
            string act = "subprofile4 mobile code changed from:" + Session["oSubprofile4_CC"].ToString() + "To:" + Session["sp4cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Mobile"].ToString(), Session["sp4mobile"].ToString() ) != 0)
        {
            string act = "subprofile4 mobile no changed from:" + Session["oSubprofile4_Mobile"].ToString() + "To:" + Session["sp4mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Alt_CC"].ToString(), Session["sp4altccc"].ToString() ) != 0)
        {
            string act = "subprofile4 alternate no code changed from:" + Session["oSubprofile4_Alt_CC"].ToString() + "To:" + Session["sp4altccc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Alternate"].ToString(), Session["sp4alternate"].ToString() ) != 0)
        {
            string act = "subprofile4 alternate no changed from:" + Session["oSubprofile4_Alternate"].ToString() + "To:" + Session["sp4alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Email"].ToString(), Session["sp4email"].ToString() ) != 0)
        {
            string act = "subprofile4 email changed from:" + Session["oSubprofile4_Email"].ToString() + "To:" + Session["sp4email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        // end//


        if (String.Compare(Session["oProfile_Address_Line1"].ToString(), address1) != 0)

        {
            string act = "address1 changed from:" + Session["oProfile_Address_Line1"].ToString() + "To:" + address1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_Line2"].ToString(), address2) != 0)
        {
            string act = "address2 changed from:" + Session["oProfile_Address_Line2"].ToString() + "To:" + address2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_State"].ToString(), state) != 0)
        {
            string act = "state changed from:" + Session["oProfile_Address_State"].ToString() + "To:" + state;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_city"].ToString(), city) != 0)
        {
            string act = "city changed from:" + Session["oProfile_Address_city"].ToString() + "To:" + city;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_Postcode"].ToString(), pincode) != 0)
        {
            string act = "pincode changed from:" + Session["oProfile_Address_Postcode"].ToString() + "To:" + pincode;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_Country"].ToString(), acountry) != 0)
        {
            string act = "Address Country changed from:" + Session["oProfile_Address_Country"].ToString() + "To:" + acountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Employment_status"].ToString(), employmentstatus) != 0)
        {
            string act = "employment status changed from:" + Session["oProfile_Employment_status"].ToString() + "To:" + employmentstatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Marital_status"].ToString(), maritalstatus) != 0)
        {
            string act = "marital status changed from:" + Session["oProfile_Marital_status"].ToString() + "To:" + maritalstatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_NOY_Living_as_couple"].ToString(), livingyrs) != 0)
        {
            string act = "livingyrs changed from:" + Session["oProfile_NOY_Living_as_couple"].ToString() + "To:" + livingyrs;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Resort_Name"].ToString(), resort) != 0)
        {
            string act = "resort changed from:" + Session["oProfile_Stay_Resort_Name"].ToString() + "To:" + resort;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Resort_Room_Number"].ToString(), roomno) != 0)
        {
            string act = "roomno changed from:" + Session["oProfile_Stay_Resort_Room_Number"].ToString() + "To:" + roomno;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Arrival_Date"].ToString(), arrivaldate) != 0)
        {
            string act = "arrival date changed from:" + Session["oProfile_Stay_Arrival_Date"].ToString() + "To:" + arrivaldate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Departure_Date"].ToString(), departuredate) != 0)
        {
            string act = "departure date changed from:" + Session["oProfile_Stay_Departure_Date"].ToString() + "To:" + departuredate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Guest_Status"].ToString(), gueststatus) != 0)
        {
            string act = "guest status changed from:" + Session["oTour_Details_Guest_Status"].ToString() + "To:" + gueststatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Guest_Sales_Rep"].ToString(), salesrep) != 0)

        {
            string act = "salesrep changed from:" + Session["oTour_Details_Guest_Sales_Rep"].ToString() + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Sales_Deck_Check_In"].ToString(), timeIn) != 0)
        {
            string act = "time In changed from:" + Session["oTour_Details_Sales_Deck_Check_In"].ToString() + "To:" + timeIn;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oTour_Details_Sales_Deck_Check_Out"].ToString(), timeOut) != 0)
        {
            string act = "time Out changed from:" + Session["oTour_Details_Sales_Deck_Check_Out"].ToString() + "To:" + timeOut;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Tour_Date"].ToString(), tourdate) != 0)
        {
            string act = "tour date changed from:" + Session["oTour_Details_Tour_Date"].ToString() + "To:" + tourdate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["tourweekno"].ToString(), wkno.ToString()) != 0)
        {
            string act = "week num changed from:" + Session["tourweekno"].ToString() + "To:" + wkno.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Taxi_In_Price"].ToString(), taxin) != 0)
        {
            string act = "taxi in price changed from:" + Session["oTour_Details_Taxi_In_Price"].ToString() + "To:" + taxin;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Taxi_In_Ref"].ToString(), taxirefin) != 0)
        {
            string act = "taxi reference in changed from:" + Session["oTour_Details_Taxi_In_Ref"].ToString() + "To:" + taxirefin;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Taxi_Out_Price"].ToString(), taxiout) != 0)
        {
            string act = "taxi outprice changed from:" + Session["oTour_Details_Taxi_Out_Price"].ToString() + "To:" + taxiout;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oTour_Details_Taxi_Out_Ref"].ToString(), taxirefout) != 0)
        {
            string act = "taxi reference out changed from:" + Session["oTour_Details_Taxi_Out_Ref"].ToString() + "To:" + taxirefout;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oComments"].ToString(), ProComments) != 0)
        {
            string act = "Profile Comments changed from:" + Session["oComments"].ToString() + "To:" + ProComments;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["ocomment2"].ToString(), ProComment2) != 0)
        {
            string act = "Profile Comment2 changed from:" + Session["ocomment2"].ToString() + "To:" + ProComment2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oregTerms"].ToString(), Session["regTerms"].ToString()) != 0)
        {
            string act = "Registration Terms changed from:" + Session["oregTerms"].ToString() + "To:" + Session["regTerms"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        //update profile
        int updateprofile = Queries.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, mgr, photoidentity, card,ProComments,"","", Session["regTerms"].ToString(), "",ProComment2,"","");
        int primary = Queries.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry, npage, npdesg, primarylanguage);
        if (secondarytitle == "")
        {
          
        }
        else
        {
            //string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            //SqlConnection sqlcon = new SqlConnection(connn);

            //string query = "select * from Profile_Secondary where Profile_ID = '"+ Session["ProfileID"].ToString() + "'";
            //sqlcon.Open();
            //SqlCommand cmd = new SqlCommand(query, sqlcon);
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, nsage, nsdesg, secondarylanguage);
            //}
            //else
            //{
            //    int year = DateTime.Now.Year;
            //    string secondaryprofileid = Queries.GetSecondaryProfileID(office);
            //    int secondary = Queries.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, profileidTextBox.Text, nsage, nsdesg, secondarylanguage);
            //    int updates = Queries.UpdateSecondaryValue(office, year);

            //    string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + profileidTextBox.Text + "Age:" + nsage + "," + "Designation:" + nsdesg + "," + "Languages spoken:" + secondarylanguage;
            //    int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

            //}
            //reader.Close();
            //sqlcon.Close();
            int secexists = Queries.SecondaryprofileExists(Session["ProfileID"].ToString());
            if (secexists == 1)
            {
                int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, nsage, nsdesg, secondarylanguage);
            }
            else
            {
                int year = DateTime.Now.Year;
                string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                int secondary = Queries.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, profileidTextBox.Text, nsage, nsdesg, secondarylanguage);
                int updates = Queries.UpdateSecondaryValue(office, year);

                string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + profileidTextBox.Text + "Age:" + nsage + "," + "Designation:" + nsdesg + "," + "Languages spoken:" + secondarylanguage;
                int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

            }

        }

       
        if (sp1title == "")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile1 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, nsp1age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile1id = Queries.GetSubProfile1ID(office);
                int subprofielid = Queries.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, Session["ProfileID"].ToString(), nsp1age);
                int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


                string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log5, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();

            //int sp1exists = Queries.Sub_Profile1Exists(Session["ProfileID"].ToString());
            //if (sp1exists == 1)
            //{
            //    int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, nsp1age);

            //}
            //else
            //{
            //    int year = DateTime.Now.Year;
            //    string subprofile1id = Queries.GetSubProfile1ID(office);
            //    int subprofielid = Queries.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, Session["ProfileID"].ToString(), nsp1age);
            //    int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


            //    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
            //    int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log5, user, DateTime.Now.ToString());


            //}

        }


        if (sp2title=="")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile2 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp2 = Queries.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, nsp2age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile2id = Queries.GetSubProfile2ID(office);
                int subprofielid2 = Queries.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, Session["ProfileID"].ToString(), nsp2age);
                int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

                string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog6 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log6, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
            //int sp2exists = Queries.Sub_Profile1Exists(Session["ProfileID"].ToString());
            //if (sp2exists == 1)
            //{
            //    int sp2 = Queries.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, nsp2age);

            //}
            //else
            //{
            //    int year = DateTime.Now.Year;
            //    string subprofile2id = Queries.GetSubProfile2ID(office);
            //    int subprofielid2 = Queries.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, Session["ProfileID"].ToString(), nsp2age);
            //    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

            //    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
            //    int insertlog6 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log6, user, DateTime.Now.ToString());


            //}
        }

        if (sp3title == "")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile3 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp3 = Queries.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, nsp3age);

            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile3id = Queries.GetSubProfile3ID(office);
                int subprofielid3 = Queries.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, Session["ProfileID"].ToString(), nsp3age);
                int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

                string log12 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog12 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log12, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
            //int sp3exists = Queries.Sub_Profile1Exists(Session["ProfileID"].ToString());
            //if (sp3exists == 1)
            //{
            //    int sp3 = Queries.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, nsp3age);

            //}
            //else
            //{
            //    int year = DateTime.Now.Year;
            //    string subprofile3id = Queries.GetSubProfile3ID(office);
            //    int subprofielid3 = Queries.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, Session["ProfileID"].ToString(), nsp3age);
            //    int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

            //    string log12 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
            //    int insertlog12 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log12, user, DateTime.Now.ToString());


            //}

        }

        if (sp4title == "")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile4 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp4 = Queries.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, nsp4age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile4id = Queries.GetSubProfile4ID(office);
                int subprofielid4 = Queries.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, Session["ProfileID"].ToString(), nsp4age);
                int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


                string log13 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog13 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log13, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
        
            //int sp4exists = Queries.Sub_Profile1Exists(Session["ProfileID"].ToString());
            //if (sp4exists == 1)
            //{
            //    int sp4 = Queries.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, nsp4age);

            //}
            //else
            //{
            //    int year = DateTime.Now.Year;
            //    string subprofile4id = Queries.GetSubProfile4ID(office);
            //    int subprofielid4 = Queries.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, Session["ProfileID"].ToString(), nsp4age);
            //    int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


            //    string log13 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
            //    int insertlog13 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log13, user, DateTime.Now.ToString());


            //}
        }
       
       
        int address = Queries.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);
        int phone = Queries.UpdatePhone(profile, Session["pcc"].ToString() , Session["pmobile"].ToString(), Session["paltrcc"].ToString() , Session["palternate"].ToString(), Session["scc"].ToString() , Session["smobile"].ToString(), Session["saltcc"].ToString() , Session["salternate"].ToString(), Session["sp1cc"].ToString() , Session["sp1mobile"].ToString(), Session["sp1altcc"].ToString() , Session["sp1alternate"].ToString(), Session["sp2cc"].ToString() , Session["sp2mobile"].ToString(), Session["sp2altccc"].ToString() , Session["sp2alternate"].ToString(), Session["sp3cc"].ToString(), Session["sp3mobile"].ToString(), Session["sp4cc"].ToString() , Session["sp4mobile"].ToString(), Session["sp3altccc"].ToString() , Session["sp3alternate"].ToString(), Session["sp4altccc"].ToString() , Session["sp4alternate"].ToString(), Session["priOfficecc"].ToString(), Session["priOfficeno"].ToString(), Session["secOfficecc"].ToString(), Session["secOfficeno"].ToString(),"","","","" );
        int email = Queries.UpdateEmail(profile, Session["pemail"].ToString() , Session["semail"].ToString() , Session["sp1email"].ToString() , Session["sp2email"].ToString() ,"","","","", Session["sp3email"].ToString() , "", Session["sp4email"].ToString() , "");
        int stay = Queries.UpdateProfileStay(profile, resort, roomno, arrivaldate, departuredate);
        int tour = Queries.UpdateTourDetails(profile, gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout,"",wkno);


        Response.Redirect(Request.RawUrl);
        //   string msg = "Details updated for Profile :" + " " + profile;
        //   Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
        //  Response.Write("<script>alert(' successfully')</script>");
        //Response.Write(@"<script alert('Record successful.'); window.location = '" + Request.RawUrl + @"'; </script>");
    }
    
    [WebMethod]
    public static string primaryl(string prid)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        //string query = "SELECT Primary_Language FROM Profile_Primary WHERE Profile_ID ='"+ '""
        //   SqlCommand sql = new SqlCommand(query, sqlcon);

        //SqlDataReader reader = sql.ExecuteReader();
        SqlDataReader reader = Queries.LoadPrimaryLang(prid);
        if (reader.HasRows)
        {
            
        while (reader.Read())
        {
            string name = reader.GetString(0);

            string[] arr = name.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {

                JSON += "[\"" + arr[i] + "\"],";
            }
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }

        return JSON;
    }

    [WebMethod]
    public static string Secondarylang(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadSecLang(prid);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        return JSON;
    }


    [WebMethod]
    public static string PhotoIdentity(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadPhotoID(prid);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       

        return JSON;
    }
    [WebMethod]
    public static string CardType(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadCardType(prid);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        return JSON;
    }



    [WebMethod]
    public static string getMarketingProgram(string venue, string venueGroup, string profileID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select distinct Marketing_Program_Name from Marketing_Program join Venue_Group vg on vg.Venue_group_ID=Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID= vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='" + profileID + "' ) and vg.Venue_Group_Name='" + venueGroup + "' and v.Venue_Name= '" + venue + "'";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);
                JSON += "[\"" + name + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;
    }



    [WebMethod]
    public static string LoadAgentsOnVenuegrp(string venue, string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue,office);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetSalesRepOnlyVenue(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        return JSON;
    }


    [WebMethod]
    public static string LoadTOOnVenueNVGrp(string venue, string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenue1(venue,office);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;
        }
        else
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenueNGrp(venue);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;

        }
    }
    [WebMethod]
    public static string LoadCountryCode(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }
    [WebMethod]
    public static string LoadAllCountryCode(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadStates(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select s.State_Name from state s join Country c on s.State_Country=c.Country_Name where c.Country_Name='" + country + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string stateName = reader.GetString(0);



                JSON += "[\"" + stateName + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;





    }


    [WebMethod]
    public static string loadRegTerms()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select RegTerms from profile p where Profile_ID='" +HttpContext.Current.Session["ProfileID"].ToString() + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string RegTerms = reader.GetString(0);
                JSON += "[\"" + RegTerms + "\"],";


            }
        
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }

  


    

    public string loadGifts()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select * from Gift_Option  where Gift_Option_Status='Active' and office='hml'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string giftname = reader.GetString(1);
            string giftItem = reader.GetString(5);
            htmlstr += "<option value='" + giftname + "-" + giftItem + "'>" + giftname + "-" + giftItem + "</option>";
        }
        sqlcon.Close();
        return htmlstr;

    }

    [WebMethod]
    public static string loadgiftdata()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Gift_ID_Option+'-'+GiftItem from Gift where Profile_ID='" + HttpContext.Current.Session["ProfileID"].ToString() + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string gift = reader.GetString(0);



                JSON += "[\"" + gift + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        sqlcon.Close();
        return JSON;



    }
}



