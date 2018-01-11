using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

public partial class Contractsite_Edit_Contract : System.Web.UI.Page
{

    static string officeo, user;
    static string ProfileIDo,fracido;
    static string contFinance;
    static string purchaseservice;
    private string Values;
    static string venuecountryG, venueG, markG;
    static int i;


    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager, oreception, osubvenue;
    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID;
    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country;
    static string oSub_Profile1_ID, oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country;
    static string oSub_Profile3_ID, oSub_Profile3_Title, oSub_Profile3_Fname, oSub_Profile3_Lname, oSub_Profile3_DOB, oSub_Profile3_Nationality, oSub_Profile3_Country;
    static string oSub_Profile4_ID, oSub_Profile4_Title, oSub_Profile4_Fname, oSub_Profile4_Lname, oSub_Profile4_DOB, oSub_Profile4_Nationality, oSub_Profile4_Country;
    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate, oSubprofile3_CC, oSubprofile3_Mobile, oSubprofile3_Alt_CC, oSubprofile3_Alternate, oSubprofile4_CC, oSubprofile4_Mobile, oSubprofile4_Alt_CC, oSubprofile4_Alternate;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email, oPrimary_Email2, oSecondary_Email2, oSubprofile1_Email2, oSubprofile2_Email2, oSubprofile3_Email, oSubprofile3_Email2, oSubprofile4_Email, oSubprofile4_Email2;
    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;

    static string oBalance_Pay_Method, oDealDrawer, oCGroupvenueDropDownList, oCReasonDropDownList, oCancelDateTextBox;

    static string ogiftoptionDropDownList, ogiftoptionDropDownList2, ogiftoptionDropDownList3;
    static string ovouchernoTextBox, ovouchernoTextBox2, ovouchernoTextBox3;


    static string text11,desc,text12,amot1,text13,date,text14,curr, GenContNumbglob;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string user1 = (string)Session["username"];
        //if (user1 == null)
        //{
        //    Response.Redirect("~/WebSite5/production/login.aspx");
        //}

        TextBox1.Text = DateTime.Today.ToString("yyyy/MM/dd");

        string user1 = (string)Session["username"];
        //string user1 = "Administrator";
        // TextBox tb = new TextBox();
         user = user1;

        string contractno = Convert.ToString(Request.QueryString["ContractNo"]);
        //user = "Administrator";
       // officeo = "ivo";
        string office = Queries.GetOffice(user);


        

        string fracid= Queries2.getcontIDfromNo(contractno);

        string ProfileID = Queries2.getProfileIDfromNo(contractno);

        fracido = fracid;
        
        if (!Page.IsPostBack)
        {

            
            DataSet ds4 = Queries2.LoadProfileOnCreation(ProfileID);
            ProfileIDTextBox.Text = ds4.Tables[0].Rows[0]["Profile_ID"].ToString();
            ProfileIDo = ProfileIDTextBox.Text;
            TextBox1.Text = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]).ToString("yyyy-MM-dd");

            CreatedByTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Created_By"].ToString();

            DataSet recep = Queries2.LoadRecept();

            ReceptionistDropDownList.DataSource = recep;
            ReceptionistDropDownList.DataTextField = "name";
            ReceptionistDropDownList.DataValueField = "Recep_ID";
            ReceptionistDropDownList.AppendDataBoundItems = true;
            ReceptionistDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Reception"].ToString(), ""));
            ReceptionistDropDownList.DataBind();

            primarytitleDropDownList.DataSource = ds4;
            primarytitleDropDownList.DataTextField = "Profile_Primary_Title";
            primarytitleDropDownList.DataValueField = "Profile_Primary_Title";
            primarytitleDropDownList.DataBind();
            pfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();

            //primarynationalityDropDownList.DataSource = ds4;
            //primarynationalityDropDownList.DataTextField = "Profile_Primary_Nationality";
            //primarynationalityDropDownList.DataValueField = "Profile_Primary_Nationality";
            //primarynationalityDropDownList.DataBind();

            DataSet primanat = Queries.LoadNationality();
            primarynationalityDropDownList.DataSource = primanat;
            primarynationalityDropDownList.DataTextField = "nationality_name";
            primarynationalityDropDownList.DataValueField = "nationality_name";
            primarynationalityDropDownList.AppendDataBoundItems = true;
            primarynationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            primarynationalityDropDownList.DataBind();


            PrimaryCountryDropDownList.Items.Clear();
            DataSet ds28 = Queries2.LoadCountryName();

            PrimaryCountryDropDownList.DataSource = ds28;
            PrimaryCountryDropDownList.DataTextField = "country_name";
            PrimaryCountryDropDownList.DataValueField = "country_name";
            PrimaryCountryDropDownList.AppendDataBoundItems = true;
            PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            PrimaryCountryDropDownList.DataBind();


            string vencountry = Queries2.GetVenueCountryCode(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString());
            VenueCountryDropDownList.Items.Clear();
            DataSet ds8 = Queries2.LoadVenueCountry1(ProfileID);

            VenueCountryDropDownList.DataSource = ds8;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            //VenueDropDownList.Items.Clear();
            //DataSet ds24 = Queries.LoadVenuebasedOnCountryID(vencountry);
            //VenueDropDownList.DataSource = ds24; 
            //VenueDropDownList.DataTextField = "Venue_Name";
            //VenueDropDownList.DataValueField = "Venue_Name";
            //VenueDropDownList.AppendDataBoundItems = true;
            //VenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            //VenueDropDownList.DataBind();

            //string venuecode = Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, vencountry);
            VenueDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Venue"].ToString());



            GroupVenueDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString());
            MarketingPrgmDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
            AgentsDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString());
            AgentCodeDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());


            string VenueDropDownListval = ds4.Tables[0].Rows[0]["Profile_Venue"].ToString();

            DataSet loadven = Queries.LoadSubVenue(VenueDropDownListval);
            //VenueDropDownList.DataSource = ds24; 
            VenueDropDownList2.DataSource = loadven;
            VenueDropDownList2.DataTextField = "SVenue_Name";
            VenueDropDownList2.DataValueField = "SVenue_Name";
            VenueDropDownList2.AppendDataBoundItems = true;
            //VenueCountryDropDownList.Items.Insert(0,"", ""));
            VenueDropDownList2.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["SubVenue"].ToString(), ""));
            VenueDropDownList2.DataBind();

            //GroupVenueDropDownList.Items.Clear();
            //DataSet ds25 = Queries.LoadVenueGroup(venuecode);
            //GroupVenueDropDownList.DataSource = ds25;
            //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            //GroupVenueDropDownList.AppendDataBoundItems = true;
            //GroupVenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            //GroupVenueDropDownList.DataBind();

            //string Groupvenuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);

            //MarketingPrgmDropDownList.Items.Clear();
            //DataSet ds26 = Queries.LoadMarketingProgram(Groupvenuecode);
            //MarketingPrgmDropDownList.DataSource = ds26;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            //string MarketingPCode = Queries2.getMarketingProgram(MarketingPrgmDropDownList.SelectedItem.Text, Groupvenuecode);
            //MarketingPrgmDropDownList.Items.Clear();
            //MarketingPrgmDropDownList.DataSource = ds26;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            //AgentsDropDownList.Items.Clear();
            //DataSet ds27 = Queries2.LoadAgentsIVO(MarketingPrgmDropDownList.SelectedItem.Text);
            //AgentsDropDownList.DataSource = ds27;
            //AgentsDropDownList.DataTextField = "Agent_Name";
            //AgentsDropDownList.DataValueField = "Agent_Name";
            //AgentsDropDownList.AppendDataBoundItems = true;
            //AgentsDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            //AgentsDropDownList.DataBind();

            /*DataSet ds27 = Queries.LoadAgentsIVO(MarketingProgramDropDownList.SelectedItem.Text);
            AgentNameDropDownList.DataSource = ds27;
            AgentNameDropDownList.DataTextField = "Agent_Name";
            AgentNameDropDownList.DataValueField = "Agent_Name";
            AgentNameDropDownList.AppendDataBoundItems = true;
            AgentNameDropDownList.Items.Insert(0, new ListItem("", ""));
            AgentNameDropDownList.DataBind();*/

            Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();

            Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();





           // contsalesrepDropDownList.Items.Clear();
         

            /* secondarytitleDropDownList.DataSource = ds4;
             secondarytitleDropDownList.DataTextField = "Profile_Secondary_Title";
             secondarytitleDropDownList.DataValueField = "Profile_Secondary_Title";
             secondarytitleDropDownList.DataBind();

             Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
             Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();

             pfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
             plnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();



             sfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
             slnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();

             secondarynationalityDropDownList.DataSource = ds4;
             secondarynationalityDropDownList.DataTextField = "Profile_Secondary_Nationality";
             secondarynationalityDropDownList.DataValueField = "Profile_Secondary_Nationality";
             secondarynationalityDropDownList.DataBind();

            // SecCountryDropDownList.DataSource = ds4;
            // SecCountryDropDownList.DataTextField = "Profile_Primary_Country";
            // SecCountryDropDownList.DataValueField = "Profile_Primary_Country";
           //  SecCountryDropDownList.DataBind();

             pmobileTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Mobile"].ToString();
             pemailTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Email"].ToString();
             employmentstatusDropDownList.DataSource = ds4;
             employmentstatusDropDownList.DataTextField = "Profile_Employment_status";
             employmentstatusDropDownList.DataValueField = "Profile_Employment_status";
             employmentstatusDropDownList.DataBind();

             MaritalStatusDropDownList.DataSource = ds4;
             MaritalStatusDropDownList.DataTextField = "Profile_Marital_status";
             MaritalStatusDropDownList.DataValueField = "Profile_Marital_status";
             MaritalStatusDropDownList.DataBind();

             datepicker1.Text = ds4.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();

             hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();*/

            //string datear = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd"); ; 
            // datepicker5.Text = DateTime.datear.ToString();
            // datepicker5.Text
            //Response.Write(datear);
            //DateTime dae = DateTime.ParseExact(datear, "yyyy/MM/dd", null);
            //datepicker5.Text = datear;

            //AgentCodeDropDownList.Items.Clear();
            //DataSet ds29 = Queries.LoadProfileAgentCode(ProfileID);
            //AgentCodeDropDownList.DataSource = ds29;
            //AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
            //AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
            //AgentCodeDropDownList.AppendDataBoundItems = true;
            //AgentCodeDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //AgentCodeDropDownList.DataBind();

            MemType1DropDownList.Items.Clear();
            DataSet ds30 = Queries.LoadMemberType();
            MemType1DropDownList.DataSource = ds30;
            MemType1DropDownList.DataTextField = "Member_Type_name";
            MemType1DropDownList.DataValueField = "Member_Type_name";
            MemType1DropDownList.AppendDataBoundItems = true;
            MemType1DropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
            MemType1DropDownList.DataBind();

            MemType2DropDownList.Items.Clear();
            DataSet ds31 = Queries.LoadMemberType();
            MemType2DropDownList.DataSource = ds31;
            MemType2DropDownList.DataTextField = "Member_Type_name";
            MemType2DropDownList.DataValueField = "Member_Type_name";
            MemType2DropDownList.AppendDataBoundItems = true;
            MemType2DropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Member_Type2"].ToString(), ""));
            MemType2DropDownList.DataBind();

            Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            //   MemType2DropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
            Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();

            employmentstatusDropDownList.Items.Clear();
            employmentstatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Employment_status"].ToString());
            employmentstatusDropDownList.Items.Add("Employee");
            employmentstatusDropDownList.Items.Add("Worker");
            employmentstatusDropDownList.Items.Add("Self Employed");
            employmentstatusDropDownList.Items.Add("Director");
            employmentstatusDropDownList.Items.Add("Office Holder");
            employmentstatusDropDownList.Items.Add("Unemployed");

            MaritalStatusDropDownList.Items.Clear();
            MaritalStatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Marital_status"].ToString());
            MaritalStatusDropDownList.Items.Add("Single");
            MaritalStatusDropDownList.Items.Add("Married");
            MaritalStatusDropDownList.Items.Add("Divorced");
            MaritalStatusDropDownList.Items.Add("Just Friend");
            MaritalStatusDropDownList.Items.Add("Female Couple");
            MaritalStatusDropDownList.Items.Add("Male Couple");
            MaritalStatusDropDownList.Items.Add("Living Together as couple");

            livingyrsTextBox.Text = ds4.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            primarytitleDropDownList.Items.Clear();
            primarytitleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            primarytitleDropDownList.Items.Add("Mr");
            primarytitleDropDownList.Items.Add("Ms");
            primarytitleDropDownList.Items.Add("Mrs");
            primarytitleDropDownList.Items.Add("Adv");
            primarytitleDropDownList.Items.Add("Dr");

            DataSet ds32 = Queries.LoadCountryPrimary(ProfileID);
            PrimaryCountryDropDownList.DataSource = ds32;
            PrimaryCountryDropDownList.DataTextField = "country_name";
            PrimaryCountryDropDownList.DataValueField = "country_name";
            PrimaryCountryDropDownList.AppendDataBoundItems = true;
            PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            PrimaryCountryDropDownList.DataBind();
            DataSet ds33 = Queries.LoadCountryWithCodePrimaryMobile(ProfileID);
            primarymobileDropDownList.DataSource = ds33;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();
            DataSet ds34 = Queries.LoadCountryWithCodePrimaryAlt(ProfileID);
            primaryalternateDropDownList.DataSource = ds34;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();

            pmobileTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            palternateTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            pemailTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Email"].ToString();
            pemailTextBox2.Text = ds4.Tables[0].Rows[0]["Primary_Email2"].ToString();


            //secondary profile

            secondarytitleDropDownList.Items.Clear();
            secondarytitleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());
            secondarytitleDropDownList.Items.Add("Mr");
            secondarytitleDropDownList.Items.Add("Ms");
            secondarytitleDropDownList.Items.Add("Mrs");
            secondarytitleDropDownList.Items.Add("Adv");
            secondarytitleDropDownList.Items.Add("Dr");



            sfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            //

            string datep1 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Primary_DOB"]).ToString("yyyy-MM-dd");
            if (datep1 == " " || datep1 == "1900-01-01")
            {
                datepicker1.Text = "";
            }
            else
            {
                datepicker1.Text = datep1;
            }



            string datep2 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Secondary_DOB"]).ToString("yyyy-MM-dd");

            if (datep2 == " " || datep2 == "1900-01-01")
            {
                datepicker2.Text = "";
            }
            else
            {
                datepicker2.Text = datep2;
            }

            DataSet seconnat = Queries.LoadNationality();
            secondarynationalityDropDownList.DataSource = seconnat;
            secondarynationalityDropDownList.DataTextField = "nationality_name";
            secondarynationalityDropDownList.DataValueField = "nationality_name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();
            //secondarynationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());


            DataSet ds35 = Queries.LoadCountrySecondary(ProfileID);
            SecondaryCountryDropDownList.DataSource = ds35;
            SecondaryCountryDropDownList.DataTextField = "country_name";
            SecondaryCountryDropDownList.DataValueField = "country_name";
            SecondaryCountryDropDownList.AppendDataBoundItems = true;
            SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString(), ""));
            SecondaryCountryDropDownList.DataBind();
            DataSet ds36 = Queries.LoadCountryWithCodeSecondaryMobile(ProfileID);
            secondarymobileDropDownList.DataSource = ds36;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();
            DataSet ds37 = Queries.LoadCountryWithCodeSecondaryAlt(ProfileID);
            secondaryalternateDropDownList.DataSource = ds37;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();

            smobileTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            salternateTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            semailTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Email"].ToString();
            semailTextBox2.Text = ds4.Tables[0].Rows[0]["Secondary_Email2"].ToString();
            //subprofile 1
            subprofile1titleDropDownList.Items.Clear();
            subprofile1titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            subprofile1titleDropDownList.Items.Add("Mr");
            subprofile1titleDropDownList.Items.Add("Ms");
            subprofile1titleDropDownList.Items.Add("Mrs");
            subprofile1titleDropDownList.Items.Add("Adv");
            subprofile1titleDropDownList.Items.Add("Dr");



            //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            sp1fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            //datepicker3.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString();

            string datep3 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"]).ToString("yyyy-MM-dd");

            if (datep3 == " " || datep3 == "1900-01-01")
            {
                datepicker3.Text = "";
            }
            else
            {
                datepicker3.Text = datep3;
            }

            DataSet sp1nat = Queries.LoadNationality();
            subprofile1nationalityDropDownList.DataSource = sp1nat;
            subprofile1nationalityDropDownList.DataTextField = "nationality_name";
            subprofile1nationalityDropDownList.DataValueField = "nationality_name";
            subprofile1nationalityDropDownList.AppendDataBoundItems = true;
            subprofile1nationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            subprofile1nationalityDropDownList.DataBind();
            //subprofile1nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());

            DataSet ds38 = Queries.LoadCountrySP1(ProfileID);
            SubProfile1CountryDropDownList.DataSource = ds38;
            SubProfile1CountryDropDownList.DataTextField = "country_name";
            SubProfile1CountryDropDownList.DataValueField = "country_name";
            SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            SubProfile1CountryDropDownList.DataBind();


            DataSet ds39 = Queries.LoadCountryWithCodeSP1Mobile(ProfileID);
            subprofile1mobileDropDownList.DataSource = ds39;
            subprofile1mobileDropDownList.DataTextField = "name";
            subprofile1mobileDropDownList.DataValueField = "name";
            subprofile1mobileDropDownList.AppendDataBoundItems = true;
            subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            subprofile1mobileDropDownList.DataBind();
            DataSet ds40 = Queries.LoadCountryWithCodeSP1Alt(ProfileID);
            subprofile1alternateDropDownList.DataSource = ds40;
            subprofile1alternateDropDownList.DataTextField = "name";
            subprofile1alternateDropDownList.DataValueField = "name";
            subprofile1alternateDropDownList.AppendDataBoundItems = true;
            subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            subprofile1alternateDropDownList.DataBind();


            sp1mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            sp1alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            sp1emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            sp1emailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

            //subprofile2
            subprofile2titleDropDownList.Items.Clear();
            subprofile2titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            subprofile2titleDropDownList.Items.Add("Mr");
            subprofile2titleDropDownList.Items.Add("Ms");
            subprofile2titleDropDownList.Items.Add("Mrs");
            subprofile2titleDropDownList.Items.Add("Adv");
            subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            sp2fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            // datepicker4.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString();

            string datep4 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

            if (datep4 == " " || datep4 == "1900-01-01")
            {
                datepicker4.Text = "";
            }
            else
            {
                datepicker4.Text = datep4;
            }

            DataSet sp2nat = Queries.LoadNationality();
            subprofile2nationalityDropDownList.DataSource = sp2nat;
            subprofile2nationalityDropDownList.DataTextField = "nationality_name";
            subprofile2nationalityDropDownList.DataValueField = "nationality_name";
            subprofile2nationalityDropDownList.AppendDataBoundItems = true;
            subprofile2nationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            subprofile2nationalityDropDownList.DataBind();
            //subprofile2nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            //subprofile2nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            DataSet ds41 = Queries.LoadCountrySP2(ProfileID);
            SubProfile2CountryDropDownList.DataSource = ds41;
            SubProfile2CountryDropDownList.DataTextField = "country_name";
            SubProfile2CountryDropDownList.DataValueField = "country_name";
            SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            SubProfile2CountryDropDownList.DataBind();



            DataSet ds42 = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            subprofile2mobileDropDownList.DataSource = ds42;
            subprofile2mobileDropDownList.DataTextField = "name";
            subprofile2mobileDropDownList.DataValueField = "name";
            subprofile2mobileDropDownList.AppendDataBoundItems = true;
            subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            subprofile2mobileDropDownList.DataBind();
            DataSet ds43 = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            subprofile2alternateDropDownList.DataSource = ds43;
            subprofile2alternateDropDownList.DataTextField = "name";
            subprofile2alternateDropDownList.DataValueField = "name";
            subprofile2alternateDropDownList.AppendDataBoundItems = true;
            subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            subprofile2alternateDropDownList.DataBind();


            sp2mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            sp2alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            sp2emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            sp2emailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();

            address1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            stateTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            cityTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();


            DataSet ds64 = Queries.LoadCountryName();
            AddCountryDropDownList.DataSource = ds64;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();




            //sub profile 3

            DataSet dssp3title = Queries.LoadSalutations();
            SubP3TitleDropDownList.DataSource = dssp3title;
            SubP3TitleDropDownList.DataTextField = "Salutation";
            SubP3TitleDropDownList.DataValueField = "Salutation";
            SubP3TitleDropDownList.AppendDataBoundItems = true;
            SubP3TitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
            SubP3TitleDropDownList.DataBind();

            //DataSet dssp2title = Queries.LoadSalutations();
            //subprofile2titleDropDownList.DataSource = dssp2title;
            //subprofile2titleDropDownList.DataTextField = "Salutation";
            //subprofile2titleDropDownList.DataValueField = "Salutation";
            //subprofile2titleDropDownList.AppendDataBoundItems = true;
            //subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            //subprofile2titleDropDownList.DataBind();

            //subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            SubP3FnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            if (SubP3FnameTextBox.Text != "")
            {
                SubP3LnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

                string datesp3 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile3_DOB"]).ToString("yyyy-MM-dd");

                if (datesp3 == " " || datep4 == "1900-01-01")
                {
                    SubP3DOB.Text = "";
                }
                else
                {
                    SubP3DOB.Text = datesp3;
                }




                SubP3MobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
                SubP3AMobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
                SubP3EmailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
                SubP3EmailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();
            }

            DataSet sp3nat = Queries.LoadNationality();
            SubP3NationalityDropDownList.DataSource = sp3nat;
            SubP3NationalityDropDownList.DataTextField = "nationality_name";
            SubP3NationalityDropDownList.DataValueField = "nationality_name";
            SubP3NationalityDropDownList.AppendDataBoundItems = true;
            SubP3NationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
            SubP3NationalityDropDownList.DataBind();

            DataSet dsp311 = Queries.LoadCountrySP2(ProfileID);
            SubP3CountryDropDownList.DataSource = dsp311;
            SubP3CountryDropDownList.DataTextField = "country_name";
            SubP3CountryDropDownList.DataValueField = "country_name";
            SubP3CountryDropDownList.AppendDataBoundItems = true;
            SubP3CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            SubP3CountryDropDownList.DataBind();



            DataSet dssp3 = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            SubP3CCDropDownList.DataSource = dssp3;
            SubP3CCDropDownList.DataTextField = "name";
            SubP3CCDropDownList.DataValueField = "name";
            SubP3CCDropDownList.AppendDataBoundItems = true;
            SubP3CCDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
            SubP3CCDropDownList.DataBind();

            DataSet dsspalt3 = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            SubP3CCDropDownList2.DataSource = dsspalt3;
            SubP3CCDropDownList2.DataTextField = "name";
            SubP3CCDropDownList2.DataValueField = "name";
            SubP3CCDropDownList2.AppendDataBoundItems = true;
            SubP3CCDropDownList2.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
            SubP3CCDropDownList2.DataBind();

            //sub profile 4

            DataSet dssp4title = Queries.LoadSalutations();
            SubP4TitleDropDownList.DataSource = dssp4title;
            SubP4TitleDropDownList.DataTextField = "Salutation";
            SubP4TitleDropDownList.DataValueField = "Salutation";
            SubP4TitleDropDownList.AppendDataBoundItems = true;
            SubP4TitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
            SubP4TitleDropDownList.DataBind();

            //DataSet dssp2title = Queries.LoadSalutations();
            //subprofile2titleDropDownList.DataSource = dssp2title;
            //subprofile2titleDropDownList.DataTextField = "Salutation";
            //subprofile2titleDropDownList.DataValueField = "Salutation";
            //subprofile2titleDropDownList.AppendDataBoundItems = true;
            //subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            //subprofile2titleDropDownList.DataBind();

            //subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            SubP4FnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            if (SubP4FnameTextBox.Text != "")
            {
                SubP4LnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

                string datesp4 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile4_DOB"]).ToString("yyyy-MM-dd");

                if (datesp4 == " " || datep4 == "1900-01-01")
                {
                    SubP4DOB.Text = "";
                }
                else
                {
                    SubP4DOB.Text = datesp4;
                }




                SubP4MobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
                SubP4AMobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
                SubP4EmailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
                SubP4EmailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

            }

            DataSet sp4nat = Queries.LoadNationality();
            SubP4NationalityDropDownList.DataSource = sp4nat;
            SubP4NationalityDropDownList.DataTextField = "nationality_name";
            SubP4NationalityDropDownList.DataValueField = "nationality_name";
            SubP4NationalityDropDownList.AppendDataBoundItems = true;
            SubP4NationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
            SubP4NationalityDropDownList.DataBind();


            DataSet dsp411 = Queries.LoadCountrySP2(ProfileID);
            SubP4CountryDropDownList.DataSource = dsp411;
            SubP4CountryDropDownList.DataTextField = "country_name";
            SubP4CountryDropDownList.DataValueField = "country_name";
            SubP4CountryDropDownList.AppendDataBoundItems = true;
            SubP4CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            SubP4CountryDropDownList.DataBind();



            DataSet dssp4 = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            SubP4CCDropDownList.DataSource = dssp4;
            SubP4CCDropDownList.DataTextField = "name";
            SubP4CCDropDownList.DataValueField = "name";
            SubP4CCDropDownList.AppendDataBoundItems = true;
            SubP4CCDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
            SubP4CCDropDownList.DataBind();

            DataSet dsspalt4 = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            SubP4CCDropDownList2.DataSource = dsspalt4;
            SubP4CCDropDownList2.DataTextField = "name";
            SubP4CCDropDownList2.DataValueField = "name";
            SubP4CCDropDownList2.AppendDataBoundItems = true;
            SubP4CCDropDownList2.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
            SubP4CCDropDownList2.DataBind();






            //stay details
            hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            roomnoTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            datepicker5.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
            datepicker6.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();

            string datep5 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd");

            if (datep5 == " " || datep5 == "1900-01-01")
            {
                datepicker5.Text = "";
            }
            else
            {
                datepicker5.Text = datep5;
            }


            string datep6 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("yyyy-MM-dd");

            if (datep6 == " " || datep6 == "1900-01-01")
            {
                datepicker6.Text = "";
            }
            else
            {
                datepicker6.Text = datep6;
            }


            //guest status

            gueststatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString());
            salesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
            //contsalesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString());
            deckcheckintimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            deckcheckouttimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            //tourdatedatepicker.Text = ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString();

            string datep7 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToString("yyyy-MM-dd");

            if (datep7 == " " || datep7 == "1900-01-01")
            {
                tourdatedatepicker.Text = "";
            }
            else
            {
                tourdatedatepicker.Text = datep7;
            }



            taxipriceInTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            TaxiRefInTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            TaxiPriceOutTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            TaxiRefOutTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();

            officeo = Queries2.getoffice(ProfileID);

            string[] ar = new string[10];
            string[] br = new string[10];
            int i = 0;
            SqlDataReader reader = Queries2.getgiftoption(ProfileID);
            while (reader.Read())
            {

                ar[i] = reader.GetString(0);
                br[i] = reader.GetString(1);

                //string id = "giftoptionDropDownList";

                i++;

            }

            if (ar[0] != "")
            {
                DataSet dsgifts1 = Queries2.LoadGiftOption(officeo);
                giftoptionDropDownList.DataSource = dsgifts1;
                giftoptionDropDownList.DataTextField = "item";
                giftoptionDropDownList.DataValueField = "item";
                giftoptionDropDownList.AppendDataBoundItems = true;

                giftoptionDropDownList.DataBind();
                giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                vouchernoTextBox.Text = br[0];

                ogiftoptionDropDownList = ar[0];
                ovouchernoTextBox = br[0];

            }

            if (ar[1] != "")
            {
                DataSet dsgifts2 = Queries2.LoadGiftOption(officeo);
                giftoptionDropDownList2.DataSource = dsgifts2;
                giftoptionDropDownList2.DataTextField = "item";
                giftoptionDropDownList2.DataValueField = "item";
                giftoptionDropDownList2.AppendDataBoundItems = true;

                giftoptionDropDownList2.DataBind();
                giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                vouchernoTextBox2.Text = br[1];
                ogiftoptionDropDownList2 = ar[1];
                ovouchernoTextBox2 = br[1];
            }

            if (ar[2] != "")
            {
                DataSet dsgifts3 = Queries2.LoadGiftOption(officeo);
                giftoptionDropDownList3.DataSource = dsgifts3;
                giftoptionDropDownList3.DataTextField = "item";
                giftoptionDropDownList3.DataValueField = "item";
                giftoptionDropDownList3.AppendDataBoundItems = true;

                giftoptionDropDownList3.DataBind();
                giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList3 = ar[2];
                ovouchernoTextBox3 = br[2];
            }




            DataSet ds5 = Queries2.LoadAllContractFractionalDetails(fracid);
            // hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            DropDownList40.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Type"].ToString());
            string conttype = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Type"].ToString();
            TextICE.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Affil_ICE"].ToString();
            TextHP.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Affil_HP"].ToString();

           // contsalesrepDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString());
            DataSet ds7 = Queries2.LoadSalesReps(vencountry);
            contsalesrepDropDownList.DataSource = ds7;
            contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            contsalesrepDropDownList.AppendDataBoundItems = true;
            contsalesrepDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Sales_Rep"].ToString(), ""));
            contsalesrepDropDownList.DataBind();
            //TOManagerDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_TO_Manager"].ToString());
            //ButtonUpDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Button_UP"].ToString());


            string VenueDropDown = ds4.Tables[0].Rows[0]["Profile_Venue"].ToString();
            oDealDrawer = ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString();
            

            DataSet Cancelvenue = Queries.LoadSubVenue(VenueDropDown);
            CGroupvenueDropDownList.DataSource = Cancelvenue;
            CGroupvenueDropDownList.DataTextField = "SVenue_Name";
            CGroupvenueDropDownList.DataValueField = "SVenue_Name";
            CGroupvenueDropDownList.AppendDataBoundItems = true;
            CGroupvenueDropDownList.Items.Insert(0, new ListItem("", ""));
            CGroupvenueDropDownList.DataBind();


            

            
            DataSet CanRea = Queries2.LoadCancelReason();
            CReasonDropDownList.DataSource = CanRea;
            CReasonDropDownList.DataTextField = "CR_Reasons";
            CReasonDropDownList.DataValueField = "CR_Reasons";
            CReasonDropDownList.AppendDataBoundItems = true;
            CReasonDropDownList.Items.Insert(0, new ListItem("", ""));
            CReasonDropDownList.DataBind();

            DataSet dsec19 = Queries2.LoadTOManager(officeo);
            TOManagerDropDownList.DataSource = dsec19;
            TOManagerDropDownList.DataTextField = "TO_Manager_name";
            TOManagerDropDownList.DataValueField = "TO_Manager_name";
            TOManagerDropDownList.AppendDataBoundItems = true;
            TOManagerDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_TO_Manager"].ToString(), ""));
            TOManagerDropDownList.DataBind();

            DataSet dsec20 = Queries2.LoadButtonUp(officeo);
            ButtonUpDropDownList.DataSource = dsec20;
            ButtonUpDropDownList.DataTextField = "ButtonUp_Name";
            ButtonUpDropDownList.DataValueField = "ButtonUp_Name";
            ButtonUpDropDownList.AppendDataBoundItems = true;
            ButtonUpDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Button_UP"].ToString(), ""));
            ButtonUpDropDownList.DataBind();

            FinanceCurrencyDropDownList.Items.Clear();
            FinanceCurrencyDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Currency"].ToString());
            FinanceCurrencyDropDownList.Items.Clear();
            FinanceCurrencyDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Currency"].ToString());

            TextPurchasePrice.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Purchase_Price"].ToString();
            TextAdminFees.Text =  ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees"].ToString();
            //TextMCFees.Text = ds5.Tables[0].Rows[0]["Contract_Finance_MC_Fees"].ToString();
            TextMCFees.Text = ds5.Tables[0].Rows[0]["Contract_Finance_MC_Fees"].ToString();

           

            DataSet dsec1 = Queries2.LoadDealDrawer();
            DealDrawerDropDownList.DataSource = dsec1;
            DealDrawerDropDownList.DataTextField = "Deal_Drawer_Name";
            DealDrawerDropDownList.DataValueField = "Deal_Drawer_Name";
            DealDrawerDropDownList.AppendDataBoundItems = true;
            DealDrawerDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString(), ""));
            DealDrawerDropDownList.DataBind();

            //DealDrawerDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Deal_Drawer"].ToString());
            oBalance_Pay_Method = ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();
            DataSet dsec2 = Queries2.LoadPayMethod();
            PayMethodDropDownList.DataSource = dsec2;
            PayMethodDropDownList.DataTextField = "pay_method_name";
            PayMethodDropDownList.DataValueField = "pay_method_name";
            PayMethodDropDownList.AppendDataBoundItems = true;
            PayMethodDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString(), ""));
            PayMethodDropDownList.DataBind();

            //PayMethodDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString());

            TextPnumb.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Finance_Num"].ToString();

            //string BPaymethod = "";//BPMDropDownList.SelectedItem.Text;
            TextPan.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Pan_Card"].ToString();
            TextAdhar.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Adhar_Card"].ToString();
            TextOtherID.Text = ds5.Tables[0].Rows[0]["Contract_Finance_ID_Card"].ToString();
            //CrownFinanceCurrDropDownList.Items.Add();

            DataSet dsec66 = Queries2.CrownFinaCurr();

            CrownFinanceCurrDropDownList.DataSource = dsec66;
            CrownFinanceCurrDropDownList.DataTextField = "Finance_Curr_Name";
            CrownFinanceCurrDropDownList.DataValueField = "Finance_Curr_Name";
            CrownFinanceCurrDropDownList.AppendDataBoundItems = true;
            CrownFinanceCurrDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Finance_Crown_Curr"].ToString(), ""));
            CrownFinanceCurrDropDownList.DataBind();

            DataSet dsec10 = Queries2.LoadDepositPayMethod(officeo);
            DPMFractDropDownList.DataSource = dsec10;
            DPMFractDropDownList.DataTextField = "Deposit_pay_method_name";
            DPMFractDropDownList.DataValueField = "Deposit_pay_method_name";
            DPMFractDropDownList.AppendDataBoundItems = true;
            DPMFractDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["PS_Deposit_Pay_Method"].ToString(), ""));
            DPMFractDropDownList.DataBind();


            TextEuroRateP.Text = ds5.Tables[0].Rows[0]["PS_EURO_Rate"].ToString(); 
             TextAusRateP.Text = ds5.Tables[0].Rows[0]["PS_AUS_Rate"].ToString(); 
             TextGbpRateP.Text = ds5.Tables[0].Rows[0]["PS_GBP_Rate"].ToString(); 
             TextIdaRateP.Text = ds5.Tables[0].Rows[0]["PS_IDA_Rate"].ToString();


            DataSet dsec65 = Queries2.LoadYearOfInt();

            YearOfIntDropDownList.DataSource = dsec65;
            YearOfIntDropDownList.DataTextField = "name";
            YearOfIntDropDownList.DataValueField = "Year_Int_ID";
            YearOfIntDropDownList.AppendDataBoundItems = true;
            YearOfIntDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["PS_YOInterest"].ToString(), ""));
            YearOfIntDropDownList.DataBind();

            TextAdminFees.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees"].ToString();
            string kk = ds5.Tables[0].Rows[0]["Contract_Finance_Admin_Fees"].ToString();


            if (oDealDrawer == "Cancel")
            {
                //string pp = ds5.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();
                //string pp2 = ds5.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString();
                //CGroupvenueDropDownList.Items.Add(ds5.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString());

                // CReasonDropDownList.Items.Add(ds5.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString());

                //CancelDateTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_Fractional_Int"].ToString();
                DataSet ds6 = Queries2.LoadStatusChange(fracid, oDealDrawer);
                oCGroupvenueDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();

                oCReasonDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString();

                DataSet Cancelvenue2 = Queries.LoadSubVenue(VenueDropDown);
                CGroupvenueDropDownList.DataSource = Cancelvenue2;
                CGroupvenueDropDownList.DataTextField = "SVenue_Name";
                CGroupvenueDropDownList.DataValueField = "SVenue_Name";
                CGroupvenueDropDownList.AppendDataBoundItems = true;
                CGroupvenueDropDownList.Items.Insert(0, new ListItem(ds6.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString(), ""));
                CGroupvenueDropDownList.DataBind();

                //oCGroupvenueDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Group_Venue"].ToString();

                //oCReasonDropDownList = ds6.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString();


                DataSet CanRea2 = Queries2.LoadCancelReason();
                CReasonDropDownList.DataSource = CanRea2;
                CReasonDropDownList.DataTextField = "CR_Reasons";
                CReasonDropDownList.DataValueField = "CR_Reasons";
                CReasonDropDownList.AppendDataBoundItems = true;
                CReasonDropDownList.Items.Insert(0, new ListItem(ds6.Tables[0].Rows[0]["SC_Cancel_Reason"].ToString(), ""));
                CReasonDropDownList.DataBind();


                string datepc1 = Convert.ToDateTime(ds6.Tables[0].Rows[0]["SC_Cancel_Date"]).ToString("yyyy-MM-dd");
                if (datep1 == " " || datep1 == "1900-01-01")
                {
                    CancelDateTextBox.Text = "";
                }
                else
                {
                    CancelDateTextBox.Text = datepc1;
                }
                oCancelDateTextBox = CancelDateTextBox.Text;
               
            }




            if (conttype == "Fractional")
            {


                ResortDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Resort"].ToString());
                ResidenceNoDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_No"].ToString());
                ResidenceTypeDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_Type"].ToString());


                //FractionalIDropDownListF.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Fractional_Int"].ToString());
                DataSet dsec21 = Queries2.LoadFractionalI();
                FractionalIDropDownListF.DataSource = dsec21;
                FractionalIDropDownListF.DataTextField = "Contract_Fractional_Int_Name";
                FractionalIDropDownListF.DataValueField = "Contract_Fractional_Int_Name";
                FractionalIDropDownListF.AppendDataBoundItems = true;
                FractionalIDropDownListF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Fractional_Fractional_Int"].ToString(), ""));
                FractionalIDropDownListF.DataBind();

                //EntitlementFracDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Entitle"].ToString());
                DataSet dsEnt = Queries2.LoadEntitlement();
                EntitlementFracDropDownList.DataSource = dsEnt;
                EntitlementFracDropDownList.DataTextField = "Entitlement_Name";
                EntitlementFracDropDownList.DataValueField = "Entitlement_Name";
                EntitlementFracDropDownList.AppendDataBoundItems = true;
                EntitlementFracDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["Contract_Fractional_Entitle"].ToString(), ""));
                EntitlementFracDropDownList.DataBind();

                TextFOccuF.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_First_Occu"].ToString();
                TextFDuration.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_Duration"].ToString();
                TextFOccuL.Text = ds5.Tables[0].Rows[0]["Contract_Fractional_Last_Occu"].ToString();

                ContractNoFractTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();


                TextDepositF.Text = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();

                TextAdmissFeesF.Text = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                TextAdminFeesF.Text = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();

                TextTotalPurchasePriceF.Text = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                TextCountryTaxF.Text = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();

                TextBalanceDueF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();


                TextNoOfInstallF.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();
                string PANoOfInstallTF = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();


                // datepicker10.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker10.Text = "";
                }
                else
                {
                    datepicker10.Text = datepc1;
                }




                TextInstallAmtF.Text = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                TextFirstInstallAmtF.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                TextDueDatesPAF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                TextTotalBalanceF.Text = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();
                
                TextRemarksF.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();


                TotalPurTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QualTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmountCreditTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                AmountCreditCurrTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoMonthsTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateInterestTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthRepayTextBoxFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();



                ////System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                ////string var1, car1;
                //if (PANoOfInstallTF != "" || PANoOfInstallTF != "0")
                //{
                //    for (i = 1; i <= int.Parse(PANoOfInstallTF); i++)
                //    {
                //        text11 = "textBoxN_" + i + "1";
                //        desc = Request[text11];

                //        text12 = "textBoxN_" + i + "2";
                //        amot1 = Request[text12];
                //        //text15 = "textBoxN_" + i + "3";
                //        //amot2 = Request[text15];
                //        text13 = "textBox_" + i + "3";
                //        date = Request[text13];
                //        text14 = "textBox_" + i + "4";
                //        curr = Request[text14];


                //       // Request.Form[text11] = "hi";



                //        // if (int.Parse(amot1) != 0)
                //        //{
                //        //string finaInstI = Queries2.getFinanceInstallID(officeo);
                //        // int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                //        // }


                //    }


                //}


            }
            else if (conttype == "Points")
            {
                ContractClubPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["CT_Points_Club"].ToString());

                DataSet ds2 = Queries2.LoadEntitlement();
                EntitlementPoinDropDownList.DataSource = ds2;
                EntitlementPoinDropDownList.DataTextField = "Entitlement_Name";
                EntitlementPoinDropDownList.DataValueField = "Entitlement_Name";
                EntitlementPoinDropDownList.AppendDataBoundItems = true;
                EntitlementPoinDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["CT_Points_Entle"].ToString(), ""));
                EntitlementPoinDropDownList.DataBind();
                //EntitlementPoinDropDownList.Items.Add(ds5.Tables[0].Rows[0]["Contract_Fractional_Residence_Type"].ToString());
                //string ContClub = .SelectedItem.Text;
                TextNoPoints.Text = ds5.Tables[0].Rows[0]["CT_Points_Noof_Points"].ToString();
                TextPMemFees.Text = ds5.Tables[0].Rows[0]["CT_Points_Member_fees"].ToString();
                TextPPropFees.Text = ds5.Tables[0].Rows[0]["CT_Points_Points_Property_fees"].ToString();
                TextPFOccu.Text = ds5.Tables[0].Rows[0]["CT_Points_FYear_Occ"].ToString();
                TextPDura.Text = ds5.Tables[0].Rows[0]["CT_Points_Duration"].ToString();
                TextPLOccu.Text = ds5.Tables[0].Rows[0]["CT_Points_LYear_Occ"].ToString();

                ContractNoPointsTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();


                TextDepositP.Text = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                TextDepoPPA.Text = ds5.Tables[0].Rows[0]["PS_Deposit_PA"].ToString();
                TextAdmissFeesP.Text = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                TextAdminFeesP.Text = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                TextPpurchasePrice.Text = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                TextCountryTaxP.Text = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                TextGrandTotalP.Text = ds5.Tables[0].Rows[0]["PS_Grand_Total"].ToString();
                TextPBalaceDPA.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                TextPPANoInstall.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();



                // datepicker10.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();
                string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker8.Text = "";
                }
                else
                {
                    datepicker8.Text = datepc1;
                }


                TextPPAAmountInstall.Text = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                TextPPAFInstall.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                TextPBalanceDDates.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                TextPDepositSA.Text = ds5.Tables[0].Rows[0]["PS_Deposit_SA"].ToString();
                TextAppliFeesP.Text = ds5.Tables[0].Rows[0]["PS_SA_Application"].ToString();
                TextAdminServiceP.Text = ds5.Tables[0].Rows[0]["PS_SA_Administration"].ToString();
                TextTotalServicePriceP.Text = ds5.Tables[0].Rows[0]["PS_Total_Service"].ToString();
                TextBalanceDueSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"].ToString();
                TextBalanceDDatesSAP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();
                TextRemarkP.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();

                TextTotalBalance.Text = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();


                TotalPurTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QualTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmountCreditTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                AmountCreditCurrTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoMonthsTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateInterestTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthRepayTextBoxPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();




                //string NoofPoints = TextNoPoints.Text;
                //string PointsEntitle = .SelectedItem.Text;
                //string PointsMemFees = TextPMemFees.Text;
                //string PointsPropFees = TextPPropFees.Text;
                //string PointsFOccu = TextPFOccu.Text;
                //string PointsDura = TextPDura.Text;
                //string PointsLOccu = TextPLOccu.Text;

            }
            else if (conttype == "Trade Into Points")
            {


                ContTypeTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString());

                string subconttype = ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString();

                //TextNoPoints.Text = ds5.Tables[0].Rows[0]["CT_Points_Noof_Points"].ToString();

                if (subconttype == "From Points To Points")
                {

                    TextOldAgreeNoTP1.Text = ds5.Tables[0].Rows[0]["TP_Old_Agree_Numb"].ToString();
                    ContractClubTPDropDownList1.Items.Add(ds5.Tables[0].Rows[0]["TP_Old_Club"].ToString());
                    TextOldNoPointsTP.Text = ds5.Tables[0].Rows[0]["TP_Old_No_Points"].ToString();
                    DataSet dsec46 = Queries2.LoadEntitlement();
                    EntitlementDropDownList1.DataSource = dsec46;
                    EntitlementDropDownList1.DataTextField = "Entitlement_Name";
                    EntitlementDropDownList1.DataValueField = "Entitlement_Name";
                    EntitlementDropDownList1.AppendDataBoundItems = true;
                    EntitlementDropDownList1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString(), ""));
                    EntitlementDropDownList1.DataBind();
                    // EntitlementDropDownList1.Items.Add(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString());
                }
                else if (subconttype == "From Weeks To Points")
                {
                    TextOldAgreeNoTP2.Text = ds5.Tables[0].Rows[0]["TP_Old_Agree_Numb"].ToString();
                    DataSet dsec47 = Queries2.LoadContResort();
                    ResortTPDropDownList.DataSource = dsec47;
                    ResortTPDropDownList.DataTextField = "Contract_Resort_Name";
                    ResortTPDropDownList.DataValueField = "Contract_Resort_Name";
                    ResortTPDropDownList.AppendDataBoundItems = true;
                    ResortTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Resort"].ToString(), ""));
                    ResortTPDropDownList.DataBind();

                    //ResortTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Resort"].ToString());
                    DataSet dsec50 = Queries2.LoadApartType();
                    AppartmentTypeTPDropDownList.DataSource = dsec50;
                    AppartmentTypeTPDropDownList.DataTextField = "Apart_Type_Name";
                    AppartmentTypeTPDropDownList.DataValueField = "Apart_Type_Name";
                    AppartmentTypeTPDropDownList.AppendDataBoundItems = true;
                    AppartmentTypeTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Appartment_Type"].ToString(), ""));
                    AppartmentTypeTPDropDownList.DataBind();

                    //AppartmentTypeTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Appartment_Type"].ToString());
                    DataSet ds49 = Queries2.LoadContNumbOccu();
                    NumbOccuTPDropDownList.DataSource = ds49;
                    NumbOccuTPDropDownList.DataTextField = "Numb_Occu_Numb";
                    NumbOccuTPDropDownList.DataValueField = "Numb_Occu_Numb";
                    NumbOccuTPDropDownList.AppendDataBoundItems = true;
                    NumbOccuTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Num_Occ"].ToString(), ""));
                    NumbOccuTPDropDownList.DataBind();

                    //NumbOccuTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Num_Occ"].ToString());
                    DataSet ds48 = Queries2.LoadContPeriod();
                    PeriodTPDropDownList.DataSource = ds48;
                    PeriodTPDropDownList.DataTextField = "Period_Name";
                    PeriodTPDropDownList.DataValueField = "Period_Name";
                    PeriodTPDropDownList.AppendDataBoundItems = true;
                    PeriodTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Period"].ToString(), ""));
                    PeriodTPDropDownList.DataBind();

                    // PeriodTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Period"].ToString());
                    DataSet ds44 = Queries2.LoadSeasType();
                    SeasonTPDropDownList.DataSource = ds44;
                    SeasonTPDropDownList.DataTextField = "Season_Name";
                    SeasonTPDropDownList.DataValueField = "Season_Name";
                    SeasonTPDropDownList.AppendDataBoundItems = true;
                    SeasonTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Season"].ToString(), ""));
                    SeasonTPDropDownList.DataBind();

                    //SeasonTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Season"].ToString());
                    DataSet ds45 = Queries2.LoadEntitlement();
                    EntitleTPDropDownList.DataSource = ds45;
                    EntitleTPDropDownList.DataTextField = "Entitlement_Name";
                    EntitleTPDropDownList.DataValueField = "Entitlement_Name";
                    EntitleTPDropDownList.AppendDataBoundItems = true;
                    EntitleTPDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString(), ""));
                    EntitleTPDropDownList.DataBind();

                    // EntitleTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Old_Entitlement"].ToString());
                    TextTPPoints.Text = ds5.Tables[0].Rows[0]["TP_Old_No_Points"].ToString();
                }



                TextNewPointsTP.Text = ds5.Tables[0].Rows[0]["TP_New_No_Points"].ToString();
                TextTotalPointsTP.Text = ds5.Tables[0].Rows[0]["TP_Total_Points"].ToString();
                DataSet dsec18 = Queries2.LoadContractClub(officeo);
                ContractClubTPDropDownList2.DataSource = dsec18;
                ContractClubTPDropDownList2.DataTextField = "Contract_Club_Name";
                ContractClubTPDropDownList2.DataValueField = "Contract_Club_Name";
                ContractClubTPDropDownList2.AppendDataBoundItems = true;
                ContractClubTPDropDownList2.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_New_CLub"].ToString(), ""));
                ContractClubTPDropDownList2.DataBind();

                //ContractClubTPDropDownList2.Items.Add(ds5.Tables[0].Rows[0]["TP_New_CLub"].ToString());
                DataSet ds3 = Queries2.LoadEntitlement();
                EntitlementTPoinDropDownList.DataSource = ds3;
                EntitlementTPoinDropDownList.DataTextField = "Entitlement_Name";
                EntitlementTPoinDropDownList.DataValueField = "Entitlement_Name";
                EntitlementTPoinDropDownList.AppendDataBoundItems = true;
                EntitlementTPoinDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TP_New_Entitlement"].ToString(), ""));
                EntitlementTPoinDropDownList.DataBind();

                //EntitlementTPoinDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_New_Entitlement"].ToString());
                TextMembershipFeesTP.Text = ds5.Tables[0].Rows[0]["TP_Member_Fees"].ToString();
                TextPropertyFeesTP.Text = ds5.Tables[0].Rows[0]["TP_Property_Fees"].ToString();
                TextFYOccTP.Text = ds5.Tables[0].Rows[0]["TP_FY_Occu"].ToString();
                TextDurationTP.Text = ds5.Tables[0].Rows[0]["TP_Duration"].ToString();
                TextLYOccTP.Text = ds5.Tables[0].Rows[0]["TP_LY_Occu"].ToString();


                ContractNoTPTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();



                TextDepositTP.Text = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                TextDepositPATP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_PA"].ToString();
                TextTotalBalanceTP.Text = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();
                TextAdmissFTP.Text = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                TextAdminFeesTP.Text = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                TextPurchasePriceTP.Text = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                TextCountryTaxTP.Text = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                TextGrandTotalTP.Text = ds5.Tables[0].Rows[0]["PS_Grand_Total"].ToString();
                TextBalanceDuePATP.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                TextNoOfInstallPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();
                TextInstallAmtPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                TextFInstallAmtPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                TextDepositSATP.Text = ds5.Tables[0].Rows[0]["PS_Deposit_SA"].ToString();
                TextAppliFeesTP.Text = ds5.Tables[0].Rows[0]["PS_SA_Application"].ToString();
                TextAdminServiceTP.Text = ds5.Tables[0].Rows[0]["PS_SA_Administration"].ToString();
                TextTotalServiceTP.Text = ds5.Tables[0].Rows[0]["PS_Total_Service"].ToString();
                TextBalanceDueSATP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due"].ToString();

                TextRemarksTP.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                TextBalanceDueDatesPATP.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();
                TextBalanceDueDatesSATP.Text = ds5.Tables[0].Rows[0]["PS_SA_Balance_Due_Dates"].ToString();

                // datepicker11.Text = ds5.Tables[0].Rows[0]["CT_Points_Noof_Points"].ToString();

                string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker11.Text = "";
                }
                else
                {
                    datepicker11.Text = datepc1;
                }


                TotalPurTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QualTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmountCreditTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                AmountCreditCurrTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoMonthsTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateInterestTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthRepayTextBoxTPFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();




            }
            else if (conttype == "Trade Into Fractional")
            {


                string OldAgreeNoTF = "", OldClubTF = "", OldNoOfPointsTF = "", OldEntitleTF = "", OldResortTF = "", OldAppartTypeTF = "", OldNoOccuTF = "", OldPeriodTF = "", OldSeasonTF = "", OldResidenceNoTF = "", OldResiTypeTF = "", OldFracIntTF = "";

                //ContTypeTPDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString());

                //string subconttype = ds5.Tables[0].Rows[0]["TP_Cont_Type"].ToString();




                string conttypeTF = ds5.Tables[0].Rows[0]["TF_Contract_Type"].ToString();
                ContTypeDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Contract_Type"].ToString());

                if (conttypeTF == "From Points To Fractional")
                {
                     TextOldAgreeNoTF1.Text = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString(); 
                  // OldClubDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Club"].ToString());
                    DataSet dsec51 = Queries2.LoadContractClub(officeo);
                    OldClubDropDownListTF.DataSource = dsec51;
                    OldClubDropDownListTF.DataTextField = "Contract_Club_Name";
                    OldClubDropDownListTF.DataValueField = "Contract_Club_Name";
                    OldClubDropDownListTF.AppendDataBoundItems = true;
                    OldClubDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Club"].ToString(), ""));
                    OldClubDropDownListTF.DataBind();

                    TextOldNoOfPointsTF.Text = ds5.Tables[0].Rows[0]["TF_Old_NoOf_Points"].ToString();
                    //EntitleDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString());
                    DataSet ds52 = Queries2.LoadEntitlement();
                    EntitleDropDownListTF1.DataSource = ds52;
                    EntitleDropDownListTF1.DataTextField = "Entitlement_Name";
                    EntitleDropDownListTF1.DataValueField = "Entitlement_Name";
                    EntitleDropDownListTF1.AppendDataBoundItems = true;
                    EntitleDropDownListTF1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString(), ""));
                    EntitleDropDownListTF1.DataBind();
                    //OldResortTF = "";
                    //OldAppartTypeTF = "";
                    //OldNoOccuTF = "";
                    //OldPeriodTF = "";
                    //OldSeasonTF = "";
                    //OldResidenceNoTF = "";
                    //OldResiTypeTF = "";
                    //OldFracIntTF = "";
                }
                else if (conttypeTF == "From Weeks To Fractional")
                {
                    TextOldAgreeNoTF2.Text = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString();
                    //OldClubTF = "";
                    //OldNoOfPointsTF = "";
                    //EntitleDropDownListTF2.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString());
                    DataSet dsec53 = Queries2.LoadEntitlement();
                    EntitleDropDownListTF2.DataSource = dsec53;
                    EntitleDropDownListTF2.DataTextField = "Entitlement_Name";
                    EntitleDropDownListTF2.DataValueField = "Entitlement_Name";
                    EntitleDropDownListTF2.AppendDataBoundItems = true;
                    EntitleDropDownListTF2.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString(), ""));
                    EntitleDropDownListTF2.DataBind();

                    //ResortDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString());
                    DataSet dsec55 = Queries2.LoadContResort();
                    ResortDropDownListTF1.DataSource = dsec55;
                    ResortDropDownListTF1.DataTextField = "Contract_Resort_Name";
                    ResortDropDownListTF1.DataValueField = "Contract_Resort_Name";
                    ResortDropDownListTF1.AppendDataBoundItems = true;
                    ResortDropDownListTF1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString(), ""));
                    ResortDropDownListTF1.DataBind();

                   // AppartTypeDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Apmnt_Type"].ToString());
                    DataSet dsec58 = Queries2.LoadApartType();
                    AppartTypeDropDownListTF.DataSource = dsec58;
                    AppartTypeDropDownListTF.DataTextField = "Apart_Type_Name";
                    AppartTypeDropDownListTF.DataValueField = "Apart_Type_Name";
                    AppartTypeDropDownListTF.AppendDataBoundItems = true;
                    AppartTypeDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Apmnt_Type"].ToString(), ""));
                    AppartTypeDropDownListTF.DataBind();

                   // NoOccuDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_No_Occu"].ToString());
                    DataSet dsec57 = Queries2.LoadContNumbOccu();
                    NoOccuDropDownListTF.DataSource = dsec57;
                    NoOccuDropDownListTF.DataTextField = "Numb_Occu_Numb";
                    NoOccuDropDownListTF.DataValueField = "Numb_Occu_Numb";
                    NoOccuDropDownListTF.AppendDataBoundItems = true;
                    NoOccuDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_No_Occu"].ToString(), ""));
                    NoOccuDropDownListTF.DataBind();

                    //PeriodDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Period"].ToString());
                    DataSet dsec56 = Queries2.LoadContPeriod();
                    PeriodDropDownListTF.DataSource = dsec56;
                    PeriodDropDownListTF.DataTextField = "Period_Name";
                    PeriodDropDownListTF.DataValueField = "Period_Name";
                    PeriodDropDownListTF.AppendDataBoundItems = true;
                    PeriodDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Period"].ToString(), ""));
                    PeriodDropDownListTF.DataBind();


                   // SeasonDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Season"].ToString());

                    DataSet dsec59 = Queries2.LoadSeasType();
                    SeasonDropDownListTF.DataSource = dsec59;
                    SeasonDropDownListTF.DataTextField = "Season_Name";
                    SeasonDropDownListTF.DataValueField = "Season_Name";
                    SeasonDropDownListTF.AppendDataBoundItems = true;
                    SeasonDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Season"].ToString(), ""));
                    SeasonDropDownListTF.DataBind();
                    //OldResidenceNoTF = "";
                    //OldResiTypeTF = "";
                    //OldFracIntTF = "";
                }
                else if (conttypeTF == "From Fractional To Fractional")
                {
                    OldAgreeNoTF = ds5.Tables[0].Rows[0]["TF_Old_Cont_Numb"].ToString();
                    //OldClubTF = "";
                    //OldNoOfPointsTF = "";
                    //EntitleDropDownListTF3.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString());
                    DataSet dsec54 = Queries2.LoadEntitlement();
                    EntitleDropDownListTF3.DataSource = dsec54;
                    EntitleDropDownListTF3.DataTextField = "Entitlement_Name";
                    EntitleDropDownListTF3.DataValueField = "Entitlement_Name";
                    EntitleDropDownListTF3.AppendDataBoundItems = true;
                    EntitleDropDownListTF3.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Entitle"].ToString(), ""));
                    EntitleDropDownListTF3.DataBind();

                    //ResortDropDownListTF3.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString());
                    DataSet dsec62 = Queries2.LoadContResort();
                    ResortDropDownListTF3.DataSource = dsec62;
                    ResortDropDownListTF3.DataTextField = "Contract_Resort_Name";
                    ResortDropDownListTF3.DataValueField = "Contract_Resort_Name";
                    ResortDropDownListTF3.AppendDataBoundItems = true;
                    ResortDropDownListTF3.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Resort"].ToString(), ""));
                    ResortDropDownListTF3.DataBind();

                    //OldAppartTypeTF = "";
                    //OldNoOccuTF = "";
                    //OldPeriodTF = "";
                    //OldSeasonTF = "";
                    ResidenceNoDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resi_No"].ToString());
                    ResiTypeDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Resi_Type"].ToString());
                    //FracIntDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Old_Frac_Int"].ToString());
                    DataSet dsec61 = Queries2.LoadFractionalI();
                    FracIntDropDownListTF.DataSource = dsec61;
                    FracIntDropDownListTF.DataTextField = "Contract_Fractional_Int_Name";
                    FracIntDropDownListTF.DataValueField = "Contract_Fractional_Int_Name";
                    FracIntDropDownListTF.AppendDataBoundItems = true;
                    FracIntDropDownListTF.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Old_Frac_Int"].ToString(), ""));
                    FracIntDropDownListTF.DataBind();

                }


                ResortDropDownListTF.Items.Add(ds5.Tables[0].Rows[0]["TF_Resort"].ToString());
                ResidenceNoDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Resi_No"].ToString());
                ResiTypeDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Resi_Type"].ToString());

                
               //FracIntDropDownListTF1.Items.Add(ds5.Tables[0].Rows[0]["TF_Frac_Int"].ToString());
                DataSet dsec63 = Queries2.LoadFractionalI();
                FracIntDropDownListTF1.DataSource = dsec63;
                FracIntDropDownListTF1.DataTextField = "Contract_Fractional_Int_Name";
                FracIntDropDownListTF1.DataValueField = "Contract_Fractional_Int_Name";
                FracIntDropDownListTF1.AppendDataBoundItems = true;
                FracIntDropDownListTF1.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Frac_Int"].ToString(), ""));
                FracIntDropDownListTF1.DataBind();

                DataSet dsec5 = Queries2.LoadEntitlement();
                EntitlementTFracDropDownList.DataSource = dsec5;
                EntitlementTFracDropDownList.DataTextField = "Entitlement_Name";
                EntitlementTFracDropDownList.DataValueField = "Entitlement_Name";
                EntitlementTFracDropDownList.AppendDataBoundItems = true;
                EntitlementTFracDropDownList.Items.Insert(0, new ListItem(ds5.Tables[0].Rows[0]["TF_Entitle"].ToString(), ""));
                EntitlementTFracDropDownList.DataBind();

                //EntitlementTFracDropDownList.Items.Add(ds5.Tables[0].Rows[0]["TF_Entitle"].ToString());
                 TextFYOccuTF.Text = ds5.Tables[0].Rows[0]["TF_First_Occ"].ToString();
               TextDurationTF.Text = ds5.Tables[0].Rows[0]["TF_Duration"].ToString();
                TextLYOccuTF.Text = ds5.Tables[0].Rows[0]["TF_Last_Occ"].ToString();
                ContractNoTFTextBox.Text = ds5.Tables[0].Rows[0]["Contract_Finance_Cont_Numb"].ToString();

                TextDepositTF.Text = ds5.Tables[0].Rows[0]["PS_Deposit"].ToString();
                // string DepoPPA = TextDepoPPA.Text;
                 TextAdmissFeeTF.Text = ds5.Tables[0].Rows[0]["PS_PA_Admission"].ToString();
                TextAdminFeeTF.Text = ds5.Tables[0].Rows[0]["PS_PA_Administration"].ToString();
                 TextPurchasePriceTF.Text = ds5.Tables[0].Rows[0]["PS_Total_Purchase"].ToString();
                TextCountryTaxTF.Text = ds5.Tables[0].Rows[0]["PS_Country_Tax"].ToString();
                //string GrandTotalP = TextGrandTotalP.Text;
                 TextBalanceDuePATF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due"].ToString();
                TextNoOfInstallTF.Text = ds5.Tables[0].Rows[0]["PS_PA_No_Install"].ToString();

               // datepicker13.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"].ToString();

                string datepc1 = Convert.ToDateTime(ds5.Tables[0].Rows[0]["PS_PA_FInstall_Date"]).ToString("yyyy-MM-dd");
                if (datep1 == " " || datep1 == "1900-01-01")
                {
                    datepicker13.Text = "";
                }
                else
                {
                    datepicker13.Text = datepc1;
                }


                TextInstallAmtTF.Text = ds5.Tables[0].Rows[0]["PS_PA_Install_Amt"].ToString();
                TextFInstallAmtTF.Text = ds5.Tables[0].Rows[0]["PS_PA_FInstall_Amt"].ToString();
                 TextBalanceDueDatesPATF.Text = ds5.Tables[0].Rows[0]["PS_PA_Balance_Due_Dates"].ToString();

                TextRemarksTF.Text = ds5.Tables[0].Rows[0]["PS_Remarks"].ToString();
                 TextTotalBalanceTF.Text = ds5.Tables[0].Rows[0]["Total_Balance"].ToString();

                TotalPurTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Total_Pur"].ToString();
                QualTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Qual_Depo"].ToString();
                AmountCreditTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Credit_Amount"].ToString();
                AmountCreditCurrTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Amount_Curr"].ToString();
                NoMonthsTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_No_Of_Month"].ToString();
                RateInterestTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Int_Rate"].ToString();
                MonthRepayTextBoxTFFC.Text = ds5.Tables[0].Rows[0]["Finance_Details_Monthly_Repay"].ToString();

            }


        }
        
      }

    public void Button5_Click(object sender, EventArgs e)
    {

        string conttype = DropDownList40.SelectedItem.Text;
        string Deposit_PM = DPMFractDropDownList.SelectedItem.Text;

        string GenContNumb = Queries2.getcontnumbfromid(fracido);//ContractNoFractTextBox.Text;
        GenContNumbglob = GenContNumb;
        // string ContType = DropDownList40.SelectedItem.Text;
        string affilice = TextICE.Text;
        string affilhp = TextHP.Text;
        string salesrep = contsalesrepDropDownList.SelectedItem.Text;
        string tomanager = TOManagerDropDownList.SelectedItem.Text;
        string buttonup = ButtonUpDropDownList.SelectedItem.Text;
        string FinaCurrency = FinanceCurrencyDropDownList.SelectedItem.Text;
        string PurchasePrice = TextPurchasePrice.Text;
        string AdminFees = TextAdminFees.Text;
        string MCFees = TextMCFees.Text;
        string DealDrawer = DealDrawerDropDownList.SelectedItem.Text;
        string PaymentMethod = PayMethodDropDownList.SelectedItem.Text;
        string FinanceNumb = TextPnumb.Text;
        string BPaymethod = "";//BPMDropDownList.SelectedItem.Text;
        string Pan = TextPan.Text;
        string Adhar = TextAdhar.Text;
        string ID_Card = TextOtherID.Text;
        string CrownCurr = CrownFinanceCurrDropDownList.SelectedItem.Text;

        string EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF;
        string YearOfInterestP;
        string tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1;
        string TYearOfInterestP = YearOfIntDropDownList.SelectedItem.Text;

        string SC_Cancel_Group_Venue, SC_Cancel_Reason, SC_Cancel_Date;

        if (DealDrawer == "Cancel")
        {
            SC_Cancel_Group_Venue = CGroupvenueDropDownList.SelectedItem.Text;

            SC_Cancel_Reason = CReasonDropDownList.SelectedItem.Text;

            SC_Cancel_Date = CancelDateTextBox.Text;
        }
        else
        {
            SC_Cancel_Group_Venue = "";

            SC_Cancel_Reason = "";

            SC_Cancel_Date = "";
        }



            if (String.Compare(oDealDrawer, DealDrawer) != 0)
        {
            string scid = Queries2.GetStatusChangeID();

            int statchange = Queries2.InsertStatusChange(scid, oDealDrawer, DealDrawer, SC_Cancel_Group_Venue, SC_Cancel_Reason, SC_Cancel_Date, user, ProfileIDo, fracido, DateTime.Now.ToString());
        }
            else
        {
            if(oDealDrawer=="Cancel")
            {
                //oCGroupvenueDropDownList,oCReasonDropDownList,oCancelDateTextBox
                     if (String.Compare(oCGroupvenueDropDownList, SC_Cancel_Group_Venue) != 0 || String.Compare(oCReasonDropDownList, SC_Cancel_Reason) != 0 || String.Compare(oCancelDateTextBox, SC_Cancel_Date) != 0)
                {
                    //SC_Cancel_Group_Venue,SC_Cancel_Reason,SC_Cancel_Date

                      int updstatuschange = Queries2.Update_Status_change(SC_Cancel_Group_Venue, SC_Cancel_Reason, SC_Cancel_Date,DateTime.Now.ToString(), oDealDrawer, fracido);
                }
                    

                
            }

        }

            if (PaymentMethod != "Crown Finance")
        {
            EuroRatesF = "";
            AusRatesF = "";
            GbpRatesF = "";
            IdaRatesF = "";
            YearOfInterestP = "";

            tPurchase1 = "";
            QDepo1 = "";
            AmtCre1 = "";
            CreCurr1 = "";
            NoOfMonth1 = "";
            RateOfInt1 = "";
            MonthlyRepay1 = "";
        }
        else
        {
            EuroRatesF = TextEuroRateP.Text;
            AusRatesF = TextAusRateP.Text;
            GbpRatesF = TextGbpRateP.Text;
            IdaRatesF = TextIdaRateP.Text;


            tPurchase1 = tPurchase.Text;
            QDepo1 = QDepo.Text;
            AmtCre1 = AmtCre.Text;
            CreCurr1 = CreCurr.Text;
            NoOfMonth1 = NoOfMonth.Text;
            RateOfInt1 = RateOfInt.Text;
            MonthlyRepay1 = MonthlyRepay.Text;


            if (TYearOfInterestP == "")
            {
                YearOfInterestP = "";
            }
            else
            {

                YearOfInterestP = Queries2.LoadYearOfIntValue(TYearOfInterestP);
            }

        }


        //oBalance_Pay_Method=
             if (String.Compare(oBalance_Pay_Method, PaymentMethod) != 0)
        {
            int finadetails = Queries2.Update_Finance_Details(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, fracido);
        }
        //else { }


        if (conttype == "Fractional")
        {



            string ResortF = Request.Form[ResortDropDownListF.UniqueID];
            string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
            string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];

            
            string FractionalInt = FractionalIDropDownListF.SelectedItem.Text;
            string FractEntitle = EntitlementFracDropDownList.SelectedItem.Text;
            string FractFOccu = TextFOccuF.Text;
            string FractDura = TextFDuration.Text;
            string FractLOccu = TextFOccuL.Text;
            string FractLease = "";


            string DepositF = TextDepositF.Text;
            
            string AdmissFeesF = TextAdmissFeesF.Text;
            string AdminFeesF = TextAdminFeesF.Text;
            string PurchasePriceF = TextTotalPurchasePriceF.Text;
            string CoutryTaxF = TextCountryTaxF.Text;
            
            string BalanceDuePAF = TextBalanceDueF.Text;

            string PAFirstPayDateF = datepicker10.Text;
            string PAAmountInstallF = TextInstallAmtF.Text;
            string PAFirstInstallF = TextFirstInstallAmtF.Text;
            string BalanceDueDatesPAF = TextDueDatesPAF.Text;
            
            string RemarksF = TextRemarksF.Text;
             //EuroRatesF = TextEuroRateP.Text;
            // AusRatesF = TextAusRateP.Text;
            // GbpRatesF = TextGbpRateP.Text;
            // IdaRatesF = TextIdaRateP.Text;
            string UsePayProtectF = "";
            string PANoOfInstallF = TextNoOfInstallF.Text;
           

            


           
            string TotalBalanceF = TextTotalBalanceF.Text;

            int icnt = Queries2.checkforexistinginvoice(fracido);
            if (icnt == 0)
            {

                string desc, amot1, date, curr, text11, text12, text13, text14;
                string PA = "PA";
                // string PANoOfInstallF = TextNoOfInstallF.Text;
                //string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                //string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallF); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12];
                    //text15 = "textBoxN_" + i + "3";
                    //amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                    // if (int.Parse(amot1) != 0)
                    //{
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                    // }

                }


            }
                int contFracPS = Queries2.UpdateContract_Fractional(ResortF, ResidenceNoF, ResidenceTypeF, FractionalInt, FractEntitle, FractFOccu, FractDura, FractLOccu,fracido);

            int contup = Queries2.UpdateFracPS(Deposit_PM,  DepositF,  AdmissFeesF,  AdminFeesF,  PurchasePriceF,  BalanceDuePAF, PANoOfInstallF,  PAFirstPayDateF,  PAAmountInstallF,  PAFirstInstallF,  BalanceDueDatesPAF, RemarksF,  EuroRatesF,  AusRatesF,  GbpRatesF,  IdaRatesF, YearOfInterestP, TotalBalanceF, DateTime.Now.ToString(), fracido);

            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, fracido);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1,  QDepo1,  AmtCre1,  CreCurr1,  NoOfMonth1,  RateOfInt1,  MonthlyRepay1, DateTime.Now.ToString(), fracido);


        }

        else if(conttype=="Points")
        {
            //string ContClub = ContractClubPDropDownList.SelectedItem.Text;
            string NoofPoints = TextNoPoints.Text;
            string PointsEntitle = EntitlementPoinDropDownList.SelectedItem.Text;
            string PointsMemFees = TextPMemFees.Text;
            string PointsPropFees = TextPPropFees.Text;
            string PointsFOccu = TextPFOccu.Text;
            string PointsDura = TextPDura.Text;
            string PointsLOccu = TextPLOccu.Text;

            string DepositP = TextDepositP.Text;
            string DepoPPA = TextDepoPPA.Text;
            string AdmissFeesP = TextAdmissFeesP.Text;
            string AdminFeesP = TextAdminFeesP.Text;
            string PurchasePriceP = TextPpurchasePrice.Text;
            string CoutryTaxP = TextCountryTaxP.Text;
            string GrandTotalP = TextGrandTotalP.Text;
            string BalanceDuePAP = TextPBalaceDPA.Text;
            string PANoOfInstallP = TextPPANoInstall.Text;
            string PAFirstPayDateP = datepicker8.Text;
            string PAAmountInstallP = TextPPAAmountInstall.Text;
            string PAFirstInstallP = TextPPAFInstall.Text;
            string BalanceDueDatesPAP = TextPBalanceDDates.Text;
            string DepositSAP = TextPDepositSA.Text;
            string ApplicationFeesP = TextAppliFeesP.Text;
            string AdminServiceP = TextAdminServiceP.Text;
            string TotalServicePriceP = TextTotalServicePriceP.Text;
            string BalanceDueSAP = TextBalanceDueSAP.Text;
           
            string BalanceDueDatesSAP = TextBalanceDDatesSAP.Text;
            string RemarksP = TextRemarkP.Text;
            
            string UsePayProtectP = "";

            string TotalBalance = TextTotalBalance.Text;


            int icnt = Queries2.checkforexistinginvoice(fracido);
            if (icnt == 0)
            {
                string desc, amot1, amot2, date, curr, text11, text12, text13, text14, text15;
                string PA = "PA";
                string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallP); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12];
                    text15 = "textBoxN_" + i + "3";
                    amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                    if (int.Parse(amot1) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                    }

                    if (int.Parse(amot2) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, ProfileIDo, SA, officeo);
                    }

                }



            }

            int contFracPS = Queries2.UpdateCT_Points( NoofPoints,  PointsEntitle,  PointsMemFees,  PointsPropFees,  PointsFOccu,  PointsDura,  PointsLOccu,  fracido);
            int contup = Queries2.UpdatePointPS( Deposit_PM,  DepositP,  DepoPPA,  DepositSAP,  AdmissFeesP,  ApplicationFeesP,  AdminFeesP,  AdminServiceP,  PurchasePriceP,  TotalServicePriceP,  CoutryTaxP,  GrandTotalP,  BalanceDuePAP,  BalanceDueSAP,  PANoOfInstallP,  PAFirstPayDateP,  PAAmountInstallP,  PAFirstInstallP,  BalanceDueDatesPAP,  BalanceDueDatesSAP,  RemarksP,  TotalBalance, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, YearOfInterestP, DateTime.Now.ToString(), fracido);
            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, fracido);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, DateTime.Now.ToString(), fracido);


        }
        else if(conttype == "Trade Into Points")
        {



            string OldAgreeNo = "";
            string OldClub = "", OldNoPoints = "", OldEntitle = "", ContResort = "", AppartmentType = "", NumbOccuTP = "", ContPeriod = "", ContSeason = "";


            string ContTPType = hiddentconttype.Text;

            if (ContTPType == "From Points To Points")
            {
                OldAgreeNo = TextOldAgreeNoTP1.Text;
                //OldAgreeNo = OldAgreeNo1;
                if (ContractClubTPDropDownList1.SelectedItem.Text == "")
                { OldClub = ""; }
                else
                { OldClub = ContractClubTPDropDownList1.SelectedItem.Text; }


                OldNoPoints = TextOldNoPointsTP.Text;

                if (EntitlementDropDownList1.SelectedItem.Text == "")
                { OldEntitle = ""; }
                else
                { OldEntitle = EntitlementDropDownList1.SelectedItem.Text; }


                ContResort = "";
                AppartmentType = "";
                NumbOccuTP = "";
                ContPeriod = "";
                ContSeason = "";
            }
            else if (ContTPType == "From Weeks To Points")
            {
                OldAgreeNo = TextOldAgreeNoTP2.Text;
                ContResort = ResortTPDropDownList.SelectedItem.Text;
                if (AppartmentTypeTPDropDownList.SelectedItem.Text == "")
                {
                    AppartmentType = "";
                }
                else
                {
                    AppartmentType = AppartmentTypeTPDropDownList.SelectedItem.Text;
                }

                if (NumbOccuTPDropDownList.SelectedItem.Text == "")
                {
                    NumbOccuTP = "";
                }
                else
                {
                    NumbOccuTP = NumbOccuTPDropDownList.SelectedItem.Text;
                }

                if (PeriodTPDropDownList.SelectedItem.Text == "")
                {
                    ContPeriod = "";
                }
                else
                {
                    ContPeriod = PeriodTPDropDownList.SelectedItem.Text;
                }

                if (SeasonTPDropDownList.SelectedItem.Text == "")
                {
                    ContSeason = "";
                }
                else
                {
                    ContSeason = SeasonTPDropDownList.SelectedItem.Text;
                }

                if (EntitleTPDropDownList.SelectedItem.Text == "")
                {
                    OldEntitle = "";
                }
                else
                {
                    OldEntitle = EntitleTPDropDownList.SelectedItem.Text;
                }

                OldNoPoints = TextTPPoints.Text;
                OldClub = "";
            }

                string NewPoints = TextNewPointsTP.Text;
            string TotalPoints = TextTotalPointsTP.Text;
            //string ContNewClub = ContractClubTPDropDownList2.Text;
            string ContNewEntitle = EntitlementTPoinDropDownList.SelectedItem.Text;
            string Memberfees = TextMembershipFeesTP.Text;
            string PropertyFees = TextPropertyFeesTP.Text;
            string FYOcc = TextFYOccTP.Text;
            string DurationTP = TextDurationTP.Text;
            string LYOcc = TextLYOccTP.Text;


            string DepositP = TextDepositTP.Text;
            string DepoPPA = TextDepositPATP.Text;
            string AdmissFeesP = TextAdmissFTP.Text;
            string AdminFeesP = TextAdminFeesTP.Text;
            string PurchasePriceP = TextPurchasePriceTP.Text;
            string CoutryTaxP = TextCountryTaxTP.Text;
            string GrandTotalP = TextGrandTotalTP.Text;
            string BalanceDuePAP = TextBalanceDuePATP.Text;
            string PANoOfInstallP = TextNoOfInstallPATP.Text;
            string PAFirstPayDateP = datepicker11.Text;
            string PAAmountInstallP = TextInstallAmtPATP.Text;
            string PAFirstInstallP = TextFInstallAmtPATP.Text;
            string BalanceDueDatesPAP = TextBalanceDueDatesPATP.Text;
            string DepositSAP = TextDepositSATP.Text;
            string ApplicationFeesP = TextAppliFeesTP.Text;
            string AdminServiceP = TextAdminServiceTP.Text;
            string TotalServicePriceP = TextTotalServiceTP.Text;
            string BalanceDueSAP = TextBalanceDueSATP.Text;

            string BalanceDueDatesSAP = TextBalanceDueDatesSATP.Text;
            string RemarksP = TextRemarksTP.Text;

            string UsePayProtectP = ""; ;

            string TotalBalance = TextTotalBalanceTP.Text;



            int icnt = Queries2.checkforexistinginvoice(fracido);
            if (icnt == 0)
            {
                string desc, amot1, amot2, date, curr, text11, text12, text13, text14, text15;
                string PA = "PA";
                string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallP); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12];
                    text15 = "textBoxN_" + i + "3";
                    amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                    if (int.Parse(amot1) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                    }

                    if (int.Parse(amot2) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, ProfileIDo, SA, officeo);
                    }

                }
            }



                int contract_TP = Queries2.Update_Contract_TP(ContResort, AppartmentType, NumbOccuTP, ContPeriod, ContSeason, OldEntitle, OldNoPoints, NewPoints, TotalPoints, ContNewEntitle, Memberfees, PropertyFees, FYOcc, DurationTP, LYOcc, fracido, OldAgreeNo);

            int contup = Queries2.UpdatePointPS(Deposit_PM, DepositP, DepoPPA, DepositSAP, AdmissFeesP, ApplicationFeesP, AdminFeesP, AdminServiceP, PurchasePriceP, TotalServicePriceP, CoutryTaxP, GrandTotalP, BalanceDuePAP, BalanceDueSAP, PANoOfInstallP, PAFirstPayDateP, PAAmountInstallP, PAFirstInstallP, BalanceDueDatesPAP, BalanceDueDatesSAP, RemarksP, TotalBalance, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, YearOfInterestP, DateTime.Now.ToString(), fracido);
            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, fracido);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, DateTime.Now.ToString(), fracido);

        }

        else if (conttype == "Trade Into Fractional")
        {
            string OldAgreeNoTF = "", OldClubTF = "", OldNoOfPointsTF = "", OldEntitleTF = "", OldResortTF = "", OldAppartTypeTF = "", OldNoOccuTF = "", OldPeriodTF = "", OldSeasonTF = "", OldResidenceNoTF = "", OldResiTypeTF = "", OldFracIntTF = "";


            string conttypeTF = Request.Form[ContTypeDropDownListTF.UniqueID];

            if (conttypeTF == "From Points To Fractional")
            {
                OldAgreeNoTF = TextOldAgreeNoTF1.Text;
                OldClubTF = OldClubDropDownListTF.Text;
                OldNoOfPointsTF = TextOldNoOfPointsTF.Text;
                OldEntitleTF = EntitleDropDownListTF1.SelectedItem.Text;
                OldResortTF = "";
                OldAppartTypeTF = "";
                OldNoOccuTF = "";
                OldPeriodTF = "";
                OldSeasonTF = "";
                OldResidenceNoTF = "";
                OldResiTypeTF = "";
                OldFracIntTF = "";
            }
            else if (conttypeTF == "From Weeks To Fractional")
            {
                OldAgreeNoTF = TextOldAgreeNoTF2.Text;
                OldClubTF = "";
                OldNoOfPointsTF = "";
                OldEntitleTF = EntitleDropDownListTF2.SelectedItem.Text;
                OldResortTF = ResortDropDownListTF1.SelectedItem.Text;
                OldAppartTypeTF = AppartTypeDropDownListTF.SelectedItem.Text;
                OldNoOccuTF = NoOccuDropDownListTF.SelectedItem.Text;
                OldPeriodTF = PeriodDropDownListTF.SelectedItem.Text;
                OldSeasonTF = SeasonDropDownListTF.SelectedItem.Text;
                OldResidenceNoTF = "";
                OldResiTypeTF = "";
                OldFracIntTF = "";
            }
            else if (conttypeTF == "From Fractional To Fractional")
            {
                OldAgreeNoTF = TextOldAgreeNoTF3.Text;
                OldClubTF = "";
                OldNoOfPointsTF = "";
                OldEntitleTF = EntitleDropDownListTF3.SelectedItem.Text;
                OldResortTF = ResortDropDownListTF3.SelectedItem.Text;
                OldAppartTypeTF = "";
                OldNoOccuTF = "";
                OldPeriodTF = "";
                OldSeasonTF = "";
                OldResidenceNoTF = Request.Form[ResidenceNoDropDownListTF.UniqueID];
                OldResiTypeTF = Request.Form[ResiTypeDropDownListTF.UniqueID];
                OldFracIntTF = Request.Form[FracIntDropDownListTF.UniqueID];
            }


            string ResortTF = Request.Form[ResortDropDownListTF.UniqueID];
            string ResidenceNoTF = Request.Form[ResidenceNoDropDownListTF1.UniqueID];
            string ResidenceTypeTF = Request.Form[ResiTypeDropDownListTF1.UniqueID];

            //string ResortF = Request.Form[ResortDropDownListF.UniqueID];
            // string ResidenceNoF = ResidenceNoDropDownListF.SelectedItem.Text;
            // string ResidenceTypeF = ResidenceTypeDropDownListF.SelectedItem.Text;
            // string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
            // string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];
            string TFractionalInt = FracIntDropDownListTF1.SelectedItem.Text;
            string TFractEntitle = EntitlementTFracDropDownList.SelectedItem.Text;
            string TFractFOccu = TextFYOccuTF.Text;
            string TFractDura = TextDurationTF.Text;
            string TFractLOccu = TextLYOccuTF.Text;
            string TFractLease = "";


            string DepositF  =   TextDepositTF.Text;

            string AdmissFeesF=   TextAdmissFeeTF.Text;
            string AdminFeesF  =  TextAdminFeeTF.Text;
            string PurchasePriceF  =  TextPurchasePriceTF.Text;
            string CoutryTaxF =   TextCountryTaxTF.Text;

            string BalanceDuePAF   =  TextBalanceDuePATF.Text;

            string PAFirstPayDateF =  datepicker13.Text;
            string PAAmountInstallF  =    TextInstallAmtTF.Text;
            string PAFirstInstallF =  TextFInstallAmtTF.Text;
            string BalanceDueDatesPAF =   TextBalanceDueDatesPATF.Text;

            string RemarksF   =   TextRemarksTF.Text;
            string TotalBalanceF   =  TextTotalBalanceTF.Text;
            string PANoOfInstallF  =  TextNoOfInstallTF.Text;


            int icnt = Queries2.checkforexistinginvoice(fracido);
            if (icnt == 0)
            {

                string desc, amot1, date, curr, text11, text12, text13, text14;
                string PA = "PA";
                // string PANoOfInstallF = TextNoOfInstallF.Text;
                //string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                //string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallF); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12];
                    //text15 = "textBoxN_" + i + "3";
                    //amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                    // if (int.Parse(amot1) != 0)
                    //{
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                    // }

                }


            }

            int contract_TF = Queries2.Update_Contract_TF(OldAgreeNoTF, OldClubTF, OldNoOfPointsTF, OldEntitleTF, OldResortTF, OldAppartTypeTF, OldNoOccuTF, OldPeriodTF, OldSeasonTF, OldResidenceNoTF, OldResiTypeTF, OldFracIntTF, ResortTF, ResidenceNoTF, ResidenceTypeTF, TFractionalInt, TFractEntitle, TFractFOccu, TFractDura, TFractLOccu, fracido);
            int contup = Queries2.UpdateFracPS(Deposit_PM, DepositF, AdmissFeesF, AdminFeesF, PurchasePriceF, BalanceDuePAF, PANoOfInstallF, PAFirstPayDateF, PAAmountInstallF, PAFirstInstallF, BalanceDueDatesPAF, RemarksF, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, YearOfInterestP, TotalBalanceF, DateTime.Now.ToString(), fracido);

            int contFina = Queries2.UpdateContFrac(affilice, affilhp, salesrep, tomanager, buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, ID_Card, CrownCurr, fracido);

            int contFinadetails = Queries2.UpdateFinanceDetails(tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, DateTime.Now.ToString(), fracido);


        }

        PrintPdfDropDownList.Items.Clear();
        string ContType1 = DropDownList40.SelectedItem.Text;
        DataSet ds21 = Queries2.LoadPrintFiles(ContType1, officeo);
        PrintPdfDropDownList.DataSource = ds21;
        PrintPdfDropDownList.DataTextField = "Printpdf_name";
        PrintPdfDropDownList.DataValueField = "Printpdf_name";
        PrintPdfDropDownList.AppendDataBoundItems = true;
        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
        PrintPdfDropDownList.DataBind();



        //string PmentDetailsId = Queries2.getPaymentDetailsID(officeo);
        //string PCard_Type = CardPrimaryDropDownList.SelectedItem.Text;
        //string PIssuing_Bank = TextIssuingP.Text;
        //string PCredit_Card_No = TextCardNumbP.Text;
        //string PCard_Holders_Name = TextCardHNameP.Text;
        //string PExpiry = TextExpMonthP.Text;
        //string PSecurity_No = TextSecurityP.Text;
        //string PFor_Depo = TextFDepo1.Text;
        //string PFor_Bala = TextFBala1.Text;
        //string SCard_Type = CardSecondaryDropDownList.SelectedItem.Text;
        //string SIssuing_Bank = TextIssuingS.Text;
        //string SCredit_Card = TextCardNumbS.Text;
        //string SCard_Holders_Name = TextCardHNameS.Text;
        //string SExpiry = TextExpiryS.Text;
        //string SSecurity_No = TextSecurityS.Text;
        //string SFor_Depo = TextFDepo2.Text;
        //string SFor_Bala = TextFBala2.Text;
        //DateTime entrydate = DateTime.Now;
        //string Pcomments = TextPrimaryCCard.Text;
        //string Scomments = TextSecondaryCCard.Text;



        //int PmentDetails = Queries2.InserPaymentDetails(PmentDetailsId, PCard_Type, PIssuing_Bank, PCredit_Card_No, PCard_Holders_Name, PExpiry, PSecurity_No,
        //    PFor_Depo, PFor_Bala, SCard_Type, SIssuing_Bank, SCredit_Card, SCard_Holders_Name, SExpiry, SSecurity_No, SFor_Depo, SFor_Bala, ProfileIDo, contFinance, entrydate, officeo, Pcomments, Scomments);

        string script = "<script> $(function() { $('#tabs').tabs({ disabled: [] }); $( '#tabs' ).tabs({ active: 4 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

    }


    protected void Button4_Click(object sender, EventArgs e)
    {

        var printr = PrintPdfDropDownList.SelectedItem.Text;
        DataTable datatable = Queries2.loadreport(GenContNumbglob, printr, officeo);

        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
        crystalReport.SetDataSource(datatable);

        System.IO.FileStream fs = null;
        long FileSize = 0;
        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
        //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        oDest.DiskFileName = ExportFileName;
        crystalReport.ExportOptions.DestinationOptions = oDest;
        crystalReport.Export();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Type", "application/pdf");
        string fn = printr + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

        fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        Response.BinaryWrite(bBuffer);
        Response.Flush();
        // Response.Close();







        //  string ContType = PrintPdfDropDownList.SelectedItem.Text;
        // string text2 = "reports"+ ContType + ".rpt";
        // ReportDocument cryRpt = new ReportDocument();
        // cryRpt.Load(Server.MapPath("~/reports/NEW POINTS CPA.rpt"));
        //  cryRpt.FileName = Server.MapPath("~/reports/NEW POINTS CPA.rpt");
        // CrystalReportViewer1.ReportSource = cryRpt;
    }


    public class resort
    {
        public string ResortID { get; set; }
        public string ResortName { get; set; }
    }

    [WebMethod]
    public static string PopulateDropDownList()
    {
        DataTable dt = new DataTable();
        List<resort> listRes = new List<resort>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Resort_ID,Contract_Resort_Name from Contract_Resort where Contract_Resort_Status='Active' order by 1", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        resort objst = new resort();

                        objst.ResortID = Convert.ToString(dt.Rows[i]["Contract_Resort_ID"]);

                        objst.ResortName = Convert.ToString(dt.Rows[i]["Contract_Resort_Name"]);

                        listRes.Insert(i, objst);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class resortno
    {
        public string ResortNoID { get; set; }
        public string ResortNoName { get; set; }
    }


    [WebMethod]
    public static string PopulateResortNoDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<resortno> listRes = new List<resortno>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Residence_ID,Contract_Residence_Name from Contract_Residence_No where Contract_Resort_ID in (select Contract_Resort_ID from Contract_Resort where Contract_Resort_Name ='" + id + "') ", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        resortno objst2 = new resortno();

                        objst2.ResortNoID = Convert.ToString(dt.Rows[i]["Contract_Residence_ID"]);

                        objst2.ResortNoName = Convert.ToString(dt.Rows[i]["Contract_Residence_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class ResidenceType
    {
        public string ResidenceTypeID { get; set; }
        public string ResidenceTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateResidenceTypeDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<ResidenceType> listRes = new List<ResidenceType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Resi_Type_ID,Contract_Resi_Type_Name from Contract_Residence_Type where Contract_Residence_ID in (select Contract_Residence_ID from Contract_Residence_No where Contract_Residence_Name='" + id + "')", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        ResidenceType objst2 = new ResidenceType();

                        objst2.ResidenceTypeID = Convert.ToString(dt.Rows[i]["Contract_Resi_Type_ID"]);

                        objst2.ResidenceTypeName = Convert.ToString(dt.Rows[i]["Contract_Resi_Type_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //for contract type


    public class Contracttype
    {
        public string ContracttypeID { get; set; }
        public string ContracttypeName { get; set; }
    }


    [WebMethod]
    public static string ContracttypeDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<Contracttype> listRes = new List<Contracttype>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Type_Name from contract_type where contract_type_contract_type = '" + id + "'and Contract_Type_Status = 'Active' order by 1 ", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        Contracttype objst2 = new Contracttype();

                        // objst2.ResortNoID = Convert.ToString(dt.Rows[i]["Contract_Residence_ID"]);

                        objst2.ContracttypeName = Convert.ToString(dt.Rows[i]["Contract_Type_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //for venue dropdownlist
    public class VenueType
    {
        public string VenueTypeID { get; set; }
        public string VenueTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<VenueType> listRes = new List<VenueType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select v.Venue_Name,v.Venue_ID  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID   where vc.Venue_Country_Name = '" + id + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        VenueType objst2 = new VenueType();

                        objst2.VenueTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueTypeName = Convert.ToString(dt.Rows[i]["Venue_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class VenueGroupType
    {
        public string VenueGroupTypeID { get; set; }
        public string VenueGroupTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueGroupDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<VenueGroupType> listRes = new List<VenueGroupType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select Venue2_Name from venue2 where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "')", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        VenueGroupType objst2 = new VenueGroupType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueGroupTypeName = Convert.ToString(dt.Rows[i]["Venue2_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //load sub venue

    public class SubVenueGroupType
    {
        public string SubVenueGroupTypeID { get; set; }
        public string SubVenueGroupTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateSubVenueGroupDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<SubVenueGroupType> listRes = new List<SubVenueGroupType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue_ID in (select Venue_ID from venue where Venue_Name='" + venueid + "')", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        SubVenueGroupType objst2 = new SubVenueGroupType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.SubVenueGroupTypeName = Convert.ToString(dt.Rows[i]["SVenue_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    public class MrktProgType
    {
        public string MrktProgTypeID { get; set; }
        public string MrktProgTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateMrktProgDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<MrktProgType> listRes = new List<MrktProgType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
            using (SqlCommand cmd = new SqlCommand("select MProgram2_Name from Marketing_Program2 where Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueid + "')", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        MrktProgType objst2 = new MrktProgType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["MProgram2_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class AgentType
    {
        public string AgentTypeID { get; set; }
        public string AgentTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentDropDownList(string markid, string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<AgentType> listRes = new List<AgentType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            // using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            using (SqlCommand cmd = new SqlCommand("select MSource_Name from Marketing_Source where MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name='" + markid + "' and Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name='" + venueid + "'))", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        AgentType objst2 = new AgentType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentTypeName = Convert.ToString(dt.Rows[i]["MSource_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    public class AgentCodeType
    {
        public string AgentCodeTypeID { get; set; }
        public string AgentCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentCodeDropDownList(string markid, string agentid, string venueid)
    {
        DataTable dt = new DataTable();
        List<AgentCodeType> listRes = new List<AgentCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '" + agentid + "' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select SCode_Name from Source_code where MSource_ID in (select MSource_ID from Marketing_Source where MSource_Name = '" + agentid + "' and MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name = '" + markid + "' and  Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueid + "')) )", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        AgentCodeType objst2 = new AgentCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentCodeTypeName = Convert.ToString(dt.Rows[i]["SCode_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class CountryCodeType
    {
        public string CountryCodeTypeID { get; set; }
        public string CountryCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateCountryCodeDropDownList(string Countid)
    {
        DataTable dt = new DataTable();
        List<CountryCodeType> listRes = new List<CountryCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Country_Code from Country where Country_Name='" + Countid + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        CountryCodeType objst2 = new CountryCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Country_Code"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }





    /* public class contnumbgen
     {
         public string contnumbgenno { get; set; }
         //public string ResidenceTypeName { get; set; }
     }*/

    [WebMethod]

    public static string loadpointcont1(string venuecountry)
    {
        //contnumbgen c1 = new contnumbgen();

        // DataSet dt = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            /*SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
            SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            // da = new SqlDataAdapter(SqlCmd);
            //dt = new DataSet();
            //da.Fill(dt);*/

            SqlCommand SqlCmd = new SqlCommand("select Venue_Country_ID from VenueCountry where Venue_Country_Name = @venuecountry", con);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //cs1.Open();
            //SqlDataReader rd = SqlCmd.ExecuteReader();
            DataTable data = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            //dt = new DataSet();
            da.Fill(data);

            if (data.Rows.Count > 0)
            {
                return data.Rows[0].ItemArray[0].ToString();//rd["Venue_Country_ID"].ToString();

            }
            //cs1.Close();
        }
        return "hi";

    }



    [System.Web.Services.WebMethod]
    public static string helo1(string name, string venue, string club, string mark, string conttype)
    {
        //return "Hello "+name;
        string finaInstI = "";

        if (conttype == "Points" || conttype == "Trade Into Points")
        {
            finaInstI = Queries2.LoadPointCont(officeo, club, name, venue, mark);
        }
        else if (conttype == "Fractional" || conttype == "Trade Into Fractional")
        {
            finaInstI = Queries2.LoadFracCont(officeo, club, name, venue, mark);
        }
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        //{
        //    /*SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", cs1);
        //    SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
        //    SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
        //    SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
        //    SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        //    // da = new SqlDataAdapter(SqlCmd);
        //    //dt = new DataSet();
        //    //da.Fill(dt);*/

        //    // SqlCommand SqlCmd = new SqlCommand("select Venue_Country_ID from VenueCountry where Venue_Country_Name = @venuecountry", con);
        //    SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", con);
        //    SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
        //    SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club;
        //    SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = name;
        //    SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;


        //    //SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = name;
        //    //cs1.Open();
        //    //SqlDataReader rd = SqlCmd.ExecuteReader();
        //    DataTable data = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
        //    //dt = new DataSet();
        //    da.Fill(data);

        //    if (data.Rows.Count > 0)
        //    {
        //        return data.Rows[0].ItemArray[0].ToString();//rd["Venue_Country_ID"].ToString();

        //    }
        //    //cs1.Close();
        //}
        return finaInstI;


    }

    [System.Web.Services.WebMethod]
    public static string[] LoadPropfess(string NoPoints)
    {
        // string[] finaInstI = new string[3];
        //return "Hello "+name;
        string[] s = new string[2];
        string finaInstI = Queries2.LoadPropfess(NoPoints);
        //return finaInstI;

        //var k = finaInstI.Split('-');



        //string str = null;
        string[] strArr = new string[10];
        //int count = 0;
        //str = "CSharp split test";
        char[] splitchar = { '-' };
        strArr = finaInstI.Split(splitchar);

        return strArr;
        // return NoPoints;
    }


    //gift option
    [System.Web.Services.WebMethod]
    public static int totalgift()
    {
        //return "Hello "+name;
        int finaInstI;

        finaInstI = Queries2.countgift(ProfileIDo);
        return finaInstI;

        //  return "hi";


    }

    [System.Web.Services.WebMethod]
    public static string pnumberCount(string id)
    {
        //return "Hello "+name;
        string Pnumb;

        Pnumb = Queries2.PnumbCount(id);
        return Pnumb;

        // return "hi";


    }


    [System.Web.Services.WebMethod]
    public static string Erates(string id)
    {
        //return "Hello "+name;
        string ER;

        ER = Queries2.getExchangeRate(id);
        return ER;

        // return "hi";


    }

    [System.Web.Services.WebMethod]
    public static string gmcharge(string id, string id2)
    {
        //return "Hello "+name;
        string mcval;

        mcval = Queries2.loadmcharge(id, id2);
        return mcval;

        // return "hi";


    }


    [System.Web.Services.WebMethod]
    public static string DeleteInvoiceOnEdit()
    {
        //return "Hello "+name;
        string p1,p2;
        p1 = ProfileIDo;
        p2 = fracido;
        int delete = Queries2.DeleteInvoiceOnEdit(p1,p2);
        //mcval = Queries2.loadmcharge(id, id2);
        // return mcval;

        return p1;


    }
}