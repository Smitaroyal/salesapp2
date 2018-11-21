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
using System.Diagnostics;
public partial class WebSite5_production_CreateProfile : System.Web.UI.Page
{



    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct parentnode,ReportOrder from user_group_access ug where username ='"+user+"' order by ReportOrder asc";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            if (name == "")
            {

            }
            else
            {
                if (name == "Reports")
                {
                    htmlstr += "<li><a href='reportSlider.aspx'><i class='fa fa-home'></i>" + name + " <span class='fa fa-chevron - down'></span> </a><ul class='nav child_menu'>";
                    htmlstr += "</ul></li>";
                    name = "";
                }
                if (name == "")
                {

                }
                else
                {
                    htmlstr += "<li><a><i class='fa fa-home'></i>" + name + " <span class='fa fa-chevron - down'></span> </a><ul class='nav child_menu'>";
                    SqlConnection sqlcon1 = new SqlConnection(conn);
                    sqlcon1.Open();
                    string query1 = "select * from user_group_access ug where ug.ParentNode='" + name + "' and username ='" + user + "' order By page_order asc";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);


                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        string pagename = reader1.GetString(1);
                        string pageurl = reader1.GetString(3);
                        string AccessName = reader1.GetString(6);

                        htmlstr += "<li><a href=" + pageurl + "?name=" + AccessName + ">" + pagename + " </a></li>";
                        Session["pagename"] = pagename;
                        string office = Queries.GetOffice(user);
                        Session["office"] = office;
                        Session["username"] = user;
                    }

                    htmlstr += "</ul></li>";



                    reader1.Close();
                    sqlcon1.Close();

                }

            }
        }
        reader.Close();
        sqlcon.Close();
        return htmlstr;

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        string user = (string)Session["username"];
         // office = (string)Session["office"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
       // Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();

            //string user = (string)Session["username"];// "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user
         // ---  string office = Queries.GetOffice(user);
           //--- officeo = office;

            ProfileIDTextBox.ReadOnly = true;


        /* ProfileIDTextBox.Text = Queries.GetProfileID(office);// VenueCountryDropDownList.SelectedItem.Text);
         string PID = Queries.GetProfileID(office);
         int PCount = Queries2.CheckProfileID(PID);

         while(PCount != 0)
         {
              PID = Queries.GetProfileID(office);
              PCount = Queries2.CheckProfileID(PID);
         }*/
        // ProfileIDTextBox.Text = Queries.GetProfileID(office);

        //load values in respective dropdown listbox

        Regterms1.Checked = true;
       Regterms2.Checked = true;

            DataSet ds = Queries2.LoadVenueCountry1();
            VenueCountryDropDownList.DataSource = ds;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.DataBind();

            DataSet dsLead = Queries.LoadLeadOffice();
            leadOffice.DataSource = dsLead;
            leadOffice.DataTextField = "Office";
            leadOffice.DataValueField = "Office";
            leadOffice.AppendDataBoundItems = true;
            leadOffice.DataBind();

        //load venues
        /*  DataSet ds1 = Queries.LoadVenue();
          VenueDropDownList.DataSource = ds1;
          VenueDropDownList.DataTextField = "Venue_Name";
          VenueDropDownList.DataValueField = "Venue_Name";
          VenueDropDownList.AppendDataBoundItems = true;
          VenueDropDownList.Items.Insert(0, new ListItem("", ""));
          VenueDropDownList.DataBind();*/


        //load venue group
        /*  DataSet ds2 = Queries.LoadVenueGroup();
          GroupVenueDropDownList.DataSource = ds2;
          GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
          GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
          GroupVenueDropDownList.AppendDataBoundItems = true;
          GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
          GroupVenueDropDownList.DataBind();*/

        //load venue group
        /* DataSet ds3 = Queries.LoadMarketingProgram();
         MarketingPrgmDropDownList.DataSource = ds3;
         MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
         MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
         MarketingPrgmDropDownList.AppendDataBoundItems = true;
         MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
         MarketingPrgmDropDownList.DataBind();*/

        //load agents
        /*  DataSet ds4 = Queries.LoadAgents();
          AgentsDropDownList.DataSource = ds4;
          AgentsDropDownList.DataTextField = "Agent_Name";
          AgentsDropDownList.DataValueField = "Agent_Name";
          AgentsDropDownList.AppendDataBoundItems = true;
          AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
          AgentsDropDownList.DataBind();*/



        //load agent code
        DataSet ds5 = Queries.LoadAgentCode();
            AgentCodeDropDownList.DataSource = ds5;
            AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
            AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
            AgentCodeDropDownList.AppendDataBoundItems = true;
            AgentCodeDropDownList.Items.Insert(0, new ListItem("", ""));
            AgentCodeDropDownList.DataBind();

            //load membertype
            DataSet ds6 = Queries.LoadMemberType();
            MemType1DropDownList.DataSource = ds6;
            MemType1DropDownList.DataTextField = "Member_Type_name";
            MemType1DropDownList.DataValueField = "Member_Type_name";
            MemType1DropDownList.AppendDataBoundItems = true;
            MemType1DropDownList.Items.Insert(0, new ListItem("", ""));
            MemType1DropDownList.DataBind();

            DataSet ds7 = Queries.LoadMemberType();
            MemType2DropDownList.DataSource = ds7;
            MemType2DropDownList.DataTextField = "Member_Type_name";
            MemType2DropDownList.DataValueField = "Member_Type_name";
            MemType2DropDownList.AppendDataBoundItems = true;
            MemType2DropDownList.Items.Insert(0, new ListItem("", ""));
            MemType2DropDownList.DataBind();


            //load country names in respective country dropdowns
            /* DataSet ds8 = Queries.LoadCountryName();
             PrimaryCountryDropDownList.DataSource = ds8;
             PrimaryCountryDropDownList.DataTextField = "country_name";
             PrimaryCountryDropDownList.DataValueField = "country_name";
             PrimaryCountryDropDownList.AppendDataBoundItems = true;
             PrimaryCountryDropDownList.Items.Insert(0, new ListItem("", ""));
             PrimaryCountryDropDownList.DataBind();

             DataSet ds9 = Queries.LoadCountryName();
             SecondaryCountryDropDownList.DataSource = ds9;
             SecondaryCountryDropDownList.DataTextField = "country_name";
             SecondaryCountryDropDownList.DataValueField = "country_name";
             SecondaryCountryDropDownList.AppendDataBoundItems = true;
             SecondaryCountryDropDownList.Items.Insert(0, new ListItem("", ""));
             SecondaryCountryDropDownList.DataBind();

             DataSet ds10 = Queries.LoadCountryName();
             SubProfile1CountryDropDownList.DataSource = ds10;
             SubProfile1CountryDropDownList.DataTextField = "country_name";
             SubProfile1CountryDropDownList.DataValueField = "country_name";
             SubProfile1CountryDropDownList.AppendDataBoundItems = true;
             SubProfile1CountryDropDownList.Items.Insert(0, new ListItem("", ""));
             SubProfile1CountryDropDownList.DataBind();

             DataSet ds11 = Queries.LoadCountryName();
             SubProfile2CountryDropDownList.DataSource = ds11;
             SubProfile2CountryDropDownList.DataTextField = "country_name";
             SubProfile2CountryDropDownList.DataValueField = "country_name";
             SubProfile2CountryDropDownList.AppendDataBoundItems = true;
             SubProfile2CountryDropDownList.Items.Insert(0, new ListItem("", ""));
             SubProfile2CountryDropDownList.DataBind();

             DataSet sp3country = Queries.LoadCountryName();
                 SubP3CountryDropDownList.DataSource = sp3country;
                 SubP3CountryDropDownList.DataTextField = "country_name";
                 SubP3CountryDropDownList.DataValueField = "country_name";
                 SubP3CountryDropDownList.AppendDataBoundItems = true;
                 SubP3CountryDropDownList.Items.Insert(0, new ListItem("", ""));
                 SubP3CountryDropDownList.DataBind();

                 DataSet sp4country = Queries.LoadCountryName();
                 SubP4CountryDropDownList.DataSource = sp4country;
                 SubP4CountryDropDownList.DataTextField = "country_name";
                 SubP4CountryDropDownList.DataValueField = "country_name";
                 SubP4CountryDropDownList.AppendDataBoundItems = true;
                 SubP4CountryDropDownList.Items.Insert(0, new ListItem("", ""));
                 SubP4CountryDropDownList.DataBind();*/


            //load country with code for mobile nos n alternate nos
          DataSet ds12 = Queries2.LoadCountryWithCode();
            primarymobileDropDownList.DataSource = ds12;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
            primarymobileDropDownList.DataBind();

                DataSet ds12a = Queries2.LoadCountryWithCode();
                primaryalternateDropDownList.DataSource = ds12a;
                primaryalternateDropDownList.DataTextField = "name";
                primaryalternateDropDownList.DataValueField = "name";
                primaryalternateDropDownList.AppendDataBoundItems = true;
                primaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
                primaryalternateDropDownList.DataBind();

                   DataSet ds13 = Queries2.LoadCountryWithCode();
                   secondarymobileDropDownList.DataSource = ds13;
                   secondarymobileDropDownList.DataTextField = "name";
                   secondarymobileDropDownList.DataValueField = "name";
                   secondarymobileDropDownList.AppendDataBoundItems = true;
                   secondarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
                   secondarymobileDropDownList.DataBind();


              DataSet ds13a = Queries2.LoadCountryWithCode();
               secondaryalternateDropDownList.DataSource = ds13a;
               secondaryalternateDropDownList.DataTextField = "name";
               secondaryalternateDropDownList.DataValueField = "name";
               secondaryalternateDropDownList.AppendDataBoundItems = true;
               secondaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
               secondaryalternateDropDownList.DataBind();

                 DataSet ds14 = Queries2.LoadCountryWithCode();
               subprofile1mobileDropDownList.DataSource = ds14;
               subprofile1mobileDropDownList.DataTextField = "name";
               subprofile1mobileDropDownList.DataValueField = "name";
               subprofile1mobileDropDownList.AppendDataBoundItems = true;
               subprofile1mobileDropDownList.Items.Insert(0, new ListItem("", ""));
               subprofile1mobileDropDownList.DataBind();

               DataSet ds14a = Queries2.LoadCountryWithCode();
               subprofile1alternateDropDownList.DataSource = ds14a;
               subprofile1alternateDropDownList.DataTextField = "name";
               subprofile1alternateDropDownList.DataValueField = "name";
               subprofile1alternateDropDownList.AppendDataBoundItems = true;
               subprofile1alternateDropDownList.Items.Insert(0, new ListItem("", ""));
               subprofile1alternateDropDownList.DataBind();

           DataSet ds15 = Queries2.LoadCountryWithCode();
               subprofile2mobileDropDownList.DataSource = ds15;
               subprofile2mobileDropDownList.DataTextField = "name";
               subprofile2mobileDropDownList.DataValueField = "name";
               subprofile2mobileDropDownList.AppendDataBoundItems = true;
               subprofile2mobileDropDownList.Items.Insert(0, new ListItem("", ""));
               subprofile2mobileDropDownList.DataBind();

               DataSet ds15a = Queries2.LoadCountryWithCode();
               subprofile2alternateDropDownList.DataSource = ds15a;
               subprofile2alternateDropDownList.DataTextField = "name";
               subprofile2alternateDropDownList.DataValueField = "name";
               subprofile2alternateDropDownList.AppendDataBoundItems = true;
               subprofile2alternateDropDownList.Items.Insert(0, new ListItem("", ""));
               subprofile2alternateDropDownList.DataBind();



               DataSet sp3altcc1 = Queries2.LoadCountryWithCode();
               SubP3CCDropDownList.DataSource = sp3altcc1;
               SubP3CCDropDownList.DataTextField = "name";
               SubP3CCDropDownList.DataValueField = "name";
               SubP3CCDropDownList.AppendDataBoundItems = true;
               SubP3CCDropDownList.Items.Insert(0, new ListItem("", ""));
               SubP3CCDropDownList.DataBind();

               DataSet sp4altcc1 = Queries2.LoadCountryWithCode();
               SubP4CCDropDownList.DataSource = sp4altcc1;
               SubP4CCDropDownList.DataTextField = "name";
               SubP4CCDropDownList.DataValueField = "name";
               SubP4CCDropDownList.AppendDataBoundItems = true;
               SubP4CCDropDownList.Items.Insert(0, new ListItem("", ""));
               SubP4CCDropDownList.DataBind();





               DataSet sp3altcc = Queries2.LoadCountryWithCode();
               SubP3CCDropDownList2.DataSource = sp3altcc;
               SubP3CCDropDownList2.DataTextField = "name";
               SubP3CCDropDownList2.DataValueField = "name";
               SubP3CCDropDownList2.AppendDataBoundItems = true;
               SubP3CCDropDownList2.Items.Insert(0, new ListItem("", ""));
               SubP3CCDropDownList2.DataBind();

               DataSet sp4altcc = Queries2.LoadCountryWithCode();
               SubP4CCDropDownList2.DataSource = sp4altcc;
               SubP4CCDropDownList2.DataTextField = "name";
               SubP4CCDropDownList2.DataValueField = "name";
               SubP4CCDropDownList2.AppendDataBoundItems = true;
               SubP4CCDropDownList2.Items.Insert(0, new ListItem("", ""));
               SubP4CCDropDownList2.DataBind();

        //load nationality

        /*--      DataSet ds16 = Queries2.LoadNationality();
         primarynationalityDropDownList.DataSource = ds16;
         primarynationalityDropDownList.DataTextField = "nationality_name";
         primarynationalityDropDownList.DataValueField = "nationality_name";
         primarynationalityDropDownList.AppendDataBoundItems = true;
         primarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
         primarynationalityDropDownList.DataBind();

         DataSet ds17 = Queries2.LoadNationality();
         secondarynationalityDropDownList.DataSource = ds17;
         secondarynationalityDropDownList.DataTextField = "nationality_name";
         secondarynationalityDropDownList.DataValueField = "nationality_name";
         secondarynationalityDropDownList.AppendDataBoundItems = true;
         secondarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
         secondarynationalityDropDownList.DataBind();

         DataSet ds18 = Queries2.LoadNationality();
         subprofile1nationalityDropDownList.DataSource = ds18;
         subprofile1nationalityDropDownList.DataTextField = "nationality_name";
         subprofile1nationalityDropDownList.DataValueField = "nationality_name";
         subprofile1nationalityDropDownList.AppendDataBoundItems = true;
         subprofile1nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
         subprofile1nationalityDropDownList.DataBind();

         DataSet ds19 = Queries2.LoadNationality();
         subprofile2nationalityDropDownList.DataSource = ds19;
         subprofile2nationalityDropDownList.DataTextField = "nationality_name";
         subprofile2nationalityDropDownList.DataValueField = "nationality_name";
         subprofile2nationalityDropDownList.AppendDataBoundItems = true;
         subprofile2nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
         subprofile2nationalityDropDownList.DataBind();

         DataSet sp3nat = Queries2.LoadNationality();
         SubP3NationalityDropDownList.DataSource = sp3nat;
         SubP3NationalityDropDownList.DataTextField = "nationality_name";
         SubP3NationalityDropDownList.DataValueField = "nationality_name";
         SubP3NationalityDropDownList.AppendDataBoundItems = true;
         SubP3NationalityDropDownList.Items.Insert(0, new ListItem("", ""));
         SubP3NationalityDropDownList.DataBind();

         DataSet sp4nat = Queries2.LoadNationality();
         SubP4NationalityDropDownList.DataSource = sp4nat;
         SubP4NationalityDropDownList.DataTextField = "nationality_name";
         SubP4NationalityDropDownList.DataValueField = "nationality_name";
         SubP4NationalityDropDownList.AppendDataBoundItems = true;
         SubP4NationalityDropDownList.Items.Insert(0, new ListItem("", ""));
         SubP4NationalityDropDownList.DataBind(); --*/


         //load guest status
         DataSet ds20 = Queries.LoadGuestStatus();
         gueststatusDropDownList.DataSource = ds20;
         gueststatusDropDownList.DataTextField = "Guest_Status_name";
         gueststatusDropDownList.DataValueField = "Guest_Status_name";
         gueststatusDropDownList.AppendDataBoundItems = true;
         gueststatusDropDownList.Items.Insert(0, new ListItem("", ""));
         gueststatusDropDownList.DataBind();

         DataSet ds24 = Queries2.LoadQStatus();
         QStatusDropDownList1.DataSource = ds24;
         QStatusDropDownList1.DataTextField = "Qstatus_Name";
         QStatusDropDownList1.DataValueField = "Qstatus_Name";
         QStatusDropDownList1.AppendDataBoundItems = true;
         QStatusDropDownList1.Items.Insert(0, new ListItem("", ""));
         QStatusDropDownList1.DataBind();


       /*--  DataSet ds21 = Queries2.LoadCountryName();
         AddCountryDropDownList.DataSource = ds21;
         AddCountryDropDownList.DataTextField = "country_name";
         AddCountryDropDownList.DataValueField = "country_name";
         AddCountryDropDownList.AppendDataBoundItems = true;
         AddCountryDropDownList.Items.Insert(0, new ListItem("", ""));
         AddCountryDropDownList.DataBind(); --*/

        //load guest status
        //DataSet ds21 = Queries.LoadSalesReps();
        // DataSet ds21 = Queries2.LoadSalesReps(Queries2.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text));
        //salesrepDropDownList.DataSource = ds21;
        //salesrepDropDownList.DataTextField = "sales_rep_name";
        //salesrepDropDownList.DataValueField = "sales_rep_name";
        //salesrepDropDownList.AppendDataBoundItems = true;
        //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
        //salesrepDropDownList.DataBind();


        //load Employment status
        DataSet dsemploy = Queries.LoadEmploymentStatus();
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem("", ""));
            employmentstatusDropDownList.DataBind();

               DataSet Secondemploy = Queries.LoadEmploymentStatus();
             SecondemploymentstatusDropDownList.DataSource = Secondemploy;
             SecondemploymentstatusDropDownList.DataTextField = "Name";
             SecondemploymentstatusDropDownList.DataValueField = "Name";
             SecondemploymentstatusDropDownList.AppendDataBoundItems = true;
             SecondemploymentstatusDropDownList.Items.Insert(0, new ListItem("", ""));
             SecondemploymentstatusDropDownList.DataBind(); 

            /*      employmentstatusDropDownList.Items.Add("");
              employmentstatusDropDownList.Items.Add("Employee");
              employmentstatusDropDownList.Items.Add("Worker");
              employmentstatusDropDownList.Items.Add("Self Employed");
              employmentstatusDropDownList.Items.Add("Director");
              employmentstatusDropDownList.Items.Add("Office Holder");
              employmentstatusDropDownList.Items.Add("Unemployed");*/


            //load marital status
              DataSet dsmart = Queries.LoadMaritalStatus();
                MaritalStatusDropDownList.DataSource = dsmart;
                MaritalStatusDropDownList.DataTextField = "MaritalStatus";
                MaritalStatusDropDownList.DataValueField = "MaritalStatus";
                MaritalStatusDropDownList.AppendDataBoundItems = true;
                MaritalStatusDropDownList.Items.Insert(0, new ListItem("", ""));
                MaritalStatusDropDownList.DataBind(); 

            /*     MaritalStatusDropDownList.Items.Add("");
             MaritalStatusDropDownList.Items.Add("Single");
             MaritalStatusDropDownList.Items.Add("Married");
             MaritalStatusDropDownList.Items.Add("Divorced");
             MaritalStatusDropDownList.Items.Add("Just Friend");
             MaritalStatusDropDownList.Items.Add("Female Couple");
             MaritalStatusDropDownList.Items.Add("Male Couple");
             MaritalStatusDropDownList.Items.Add("Living Together as couple");*/

            //load title dropdown

            TextBox1.Text = DateTime.Today.ToString("yyyy/MM/dd");
            //tourdatedatepicker.Text = DateTime.Today.ToString("yyyy/MM/dd");

            /*--    DataSet dsptitle = Queries2.LoadSalutations(office);
              primarytitleDropDownList.DataSource = dsptitle;
              primarytitleDropDownList.DataTextField = "Salutation";
              primarytitleDropDownList.DataValueField = "Salutation";
              primarytitleDropDownList.AppendDataBoundItems = true;
              primarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
              primarytitleDropDownList.DataBind();

                 DataSet dsstitle = Queries2.LoadSalutations(office);
                 secondarytitleDropDownList.DataSource = dsstitle;
                 secondarytitleDropDownList.DataTextField = "Salutation";
                 secondarytitleDropDownList.DataValueField = "Salutation";
                 secondarytitleDropDownList.AppendDataBoundItems = true;
                 secondarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
                 secondarytitleDropDownList.DataBind();


                 DataSet dssp1title = Queries2.LoadSalutations(office);
                 subprofile1titleDropDownList.DataSource = dssp1title;
                 subprofile1titleDropDownList.DataTextField = "Salutation";
                 subprofile1titleDropDownList.DataValueField = "Salutation";
                 subprofile1titleDropDownList.AppendDataBoundItems = true;
                 subprofile1titleDropDownList.Items.Insert(0, new ListItem("", ""));
                 subprofile1titleDropDownList.DataBind();


                 DataSet dssp2title = Queries2.LoadSalutations(office);
                 subprofile2titleDropDownList.DataSource = dssp2title;
                 subprofile2titleDropDownList.DataTextField = "Salutation";
                 subprofile2titleDropDownList.DataValueField = "Salutation";
                 subprofile2titleDropDownList.AppendDataBoundItems = true;
                 subprofile2titleDropDownList.Items.Insert(0, new ListItem("", ""));
                 subprofile2titleDropDownList.DataBind();

                 DataSet dssp3title = Queries2.LoadSalutations(office);
                 SubP3TitleDropDownList.DataSource = dssp3title;
                 SubP3TitleDropDownList.DataTextField = "Salutation";
                 SubP3TitleDropDownList.DataValueField = "Salutation";
                 SubP3TitleDropDownList.AppendDataBoundItems = true;
                 SubP3TitleDropDownList.Items.Insert(0, new ListItem("", ""));
                 SubP3TitleDropDownList.DataBind();

                 DataSet dssp4title = Queries2.LoadSalutations(office);
                 SubP4TitleDropDownList.DataSource = dssp4title;
                 SubP4TitleDropDownList.DataTextField = "Salutation";
                 SubP4TitleDropDownList.DataValueField = "Salutation";
                 SubP4TitleDropDownList.AppendDataBoundItems = true;
                 SubP4TitleDropDownList.Items.Insert(0, new ListItem("", ""));
                 SubP4TitleDropDownList.DataBind();


                 //load gift

                 DataSet dsgift1 = Queries2.LoadGiftOption(office);
                 giftoptionDropDownList.DataSource = dsgift1;
                 giftoptionDropDownList.DataTextField = "item";
                 giftoptionDropDownList.DataValueField = "item";
                 giftoptionDropDownList.AppendDataBoundItems = true;
                 giftoptionDropDownList.Items.Insert(0, new ListItem("", ""));
                 giftoptionDropDownList.DataBind();

                 DataSet dsgift2 = Queries2.LoadGiftOption(office);
                 giftoptionDropDownList2.DataSource = dsgift2;
                 giftoptionDropDownList2.DataTextField = "item";
                 giftoptionDropDownList2.DataValueField = "item";
                 giftoptionDropDownList2.AppendDataBoundItems = true;
                 giftoptionDropDownList2.Items.Insert(0, new ListItem("", ""));
                 giftoptionDropDownList2.DataBind();


                 DataSet dsgift3 = Queries2.LoadGiftOption(office);
                 giftoptionDropDownList3.DataSource = dsgift3;
                 giftoptionDropDownList3.DataTextField = "item";
                 giftoptionDropDownList3.DataValueField = "item";
                 giftoptionDropDownList3.AppendDataBoundItems = true;
                 giftoptionDropDownList3.Items.Insert(0, new ListItem("", ""));
                 giftoptionDropDownList3.DataBind();

                 DataSet dsgift4 = Queries2.LoadGiftOption(office);
                 giftoptionDropDownList4.DataSource = dsgift4;
                 giftoptionDropDownList4.DataTextField = "item";
                 giftoptionDropDownList4.DataValueField = "item";
                 giftoptionDropDownList4.AppendDataBoundItems = true;
                 giftoptionDropDownList4.Items.Insert(0, new ListItem("", ""));
                 giftoptionDropDownList4.DataBind();

                 DataSet dsgift5 = Queries2.LoadGiftOption(office);
                 giftoptionDropDownList5.DataSource = dsgift5;
                 giftoptionDropDownList5.DataTextField = "item";
                 giftoptionDropDownList5.DataValueField = "item";
                 giftoptionDropDownList5.AppendDataBoundItems = true;
                 giftoptionDropDownList5.Items.Insert(0, new ListItem("", ""));
                 giftoptionDropDownList5.DataBind();

                 DataSet dsgift6 = Queries2.LoadGiftOption(office);
                 giftoptionDropDownList6.DataSource = dsgift6;
                 giftoptionDropDownList6.DataTextField = "item";
                 giftoptionDropDownList6.DataValueField = "item";
                 giftoptionDropDownList6.AppendDataBoundItems = true;
                 giftoptionDropDownList6.Items.Insert(0, new ListItem("", ""));
                 giftoptionDropDownList6.DataBind();

                 DataSet dsgift7 = Queries2.LoadGiftOption(office);
                 giftoptionDropDownList7.DataSource = dsgift7;
                 giftoptionDropDownList7.DataTextField = "item";
                 giftoptionDropDownList7.DataValueField = "item";
                 giftoptionDropDownList7.AppendDataBoundItems = true;
                 giftoptionDropDownList7.Items.Insert(0, new ListItem("", ""));
                 giftoptionDropDownList7.DataBind(); --*/



            DataSet recep = Queries2.LoadRecept();

            ReceptionistDropDownList.DataSource = recep;
            ReceptionistDropDownList.DataTextField = "name";
            ReceptionistDropDownList.DataValueField = "Recep_ID";
            ReceptionistDropDownList.AppendDataBoundItems = true;
            ReceptionistDropDownList.Items.Insert(0, new ListItem("", ""));
            ReceptionistDropDownList.DataBind();



            /*DataSet OfficeSou = Queries2.LoadOfficeSource();

            OfficeSourceDropDownList.DataSource = OfficeSou;
            OfficeSourceDropDownList.DataTextField = "Office_Source_Name";
            OfficeSourceDropDownList.DataValueField = "Office_Source_Name";
            OfficeSourceDropDownList.AppendDataBoundItems = true;
            OfficeSourceDropDownList.Items.Insert(0, new ListItem("", ""));
            OfficeSourceDropDownList.DataBind();*/



            DataSet Flyage = Queries2.LoadFlybuyAgent();

            FAgentDropDownList.DataSource = Flyage;
            FAgentDropDownList.DataTextField = "FAgent_Name";
            FAgentDropDownList.DataValueField = "FAgent_Name";
            FAgentDropDownList.AppendDataBoundItems = true;
            FAgentDropDownList.Items.Insert(0, new ListItem("", ""));
            FAgentDropDownList.DataBind();



            DataSet LeaSou = Queries2.LoadLeadSource();

            DropDownListFly.DataSource = LeaSou;
            DropDownListFly.DataTextField = "Lead_Source_Name";
            DropDownListFly.DataValueField = "Lead_Source_Name";
            DropDownListFly.AppendDataBoundItems = true;
            DropDownListFly.Items.Insert(0, new ListItem("", ""));
            DropDownListFly.DataBind();


            DataSet PreArr = Queries2.LoadPreArrival();

            PreArrivalDropDownList.DataSource = PreArr;
            PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
            PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
            PreArrivalDropDownList.AppendDataBoundItems = true;
            PreArrivalDropDownList.Items.Insert(0, new ListItem("", ""));
            PreArrivalDropDownList.DataBind();

            DataSet Veri = Queries2.LoadVerification();

            VerificationDropDownList.DataSource = Veri;
            VerificationDropDownList.DataTextField = "Verification_Name";
            VerificationDropDownList.DataValueField = "Verification_Name";
            VerificationDropDownList.AppendDataBoundItems = true;
            VerificationDropDownList.Items.Insert(0, new ListItem("", ""));
            VerificationDropDownList.DataBind();


            //DataSet ds22 = Queries.LoadSalesReps(office);
            //salesrepDropDownList.DataSource = ds22;
            //salesrepDropDownList.DataTextField = "sales_rep_name";
            //salesrepDropDownList.DataValueField = "sales_rep_name";
            //salesrepDropDownList.AppendDataBoundItems = true;
            //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
            //salesrepDropDownList.DataBind();



            /*    primarytitleDropDownList.Items.Add("");
            primarytitleDropDownList.Items.Add("Mr");
            primarytitleDropDownList.Items.Add("Ms");
            primarytitleDropDownList.Items.Add("Mrs");
            primarytitleDropDownList.Items.Add("Adv");
            primarytitleDropDownList.Items.Add("Dr");


            secondarytitleDropDownList.Items.Add("");
            secondarytitleDropDownList.Items.Add("Mr");
            secondarytitleDropDownList.Items.Add("Ms");
            secondarytitleDropDownList.Items.Add("Mrs");
            secondarytitleDropDownList.Items.Add("Adv");
            secondarytitleDropDownList.Items.Add("Dr");


            subprofile1titleDropDownList.Items.Add("");
            subprofile1titleDropDownList.Items.Add("Mr");
            subprofile1titleDropDownList.Items.Add("Ms");
            subprofile1titleDropDownList.Items.Add("Mrs");
            subprofile1titleDropDownList.Items.Add("Adv");
            subprofile1titleDropDownList.Items.Add("Dr");

            subprofile2titleDropDownList.Items.Add("");
            subprofile2titleDropDownList.Items.Add("Mr");
            subprofile2titleDropDownList.Items.Add("Ms");
            subprofile2titleDropDownList.Items.Add("Mrs");
            subprofile2titleDropDownList.Items.Add("Adv");
            subprofile2titleDropDownList.Items.Add("Dr");*/
        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ProfileID"] = "";
            string viewPointID = TextVPID.Text;
            if (viewPointID == "")
            {
                viewPointID = "";
            }
            else
            {
                viewPointID = TextVPID.Text;
            }

            string profileCreatedBy = CreatedByTextBox.Text;

            string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            venuecountry = textInfo.ToTitleCase(venuecountry.ToLower());

            string office = Queries.GetOfficeOnVenueCountry(venuecountry);
            int year = DateTime.Now.Year;
            Session["ProfileID"] = Queries.GetProfileID(office);
            string reception = ReceptionistDropDownList.SelectedItem.Text;

            //Request.Form[AgentCodeDropDownList.UniqueID];
            string venue = Request.Form[VenueDropDownList.UniqueID];
            TextInfo textInfo1 = new CultureInfo("en-US", false).TextInfo;
            venue = textInfo1.ToTitleCase(venue.ToLower());

             string venueGroup = Request.Form[GroupVenueDropDownList.UniqueID];
            if (venuecountry=="India" || venuecountry == "INDIA")
            {
                if(venueGroup=="Flybuy" || venueGroup == "FLYBUY")
                {
                    venueGroup = "FlyBuy";
                }
                else
                {
                    venueGroup = Request.Form[GroupVenueDropDownList.UniqueID];
                    TextInfo textInfo2 = new CultureInfo("en-US", false).TextInfo;
                    venueGroup = textInfo2.ToTitleCase(venueGroup.ToLower());
                }

            }else
            {
                venueGroup = Request.Form[GroupVenueDropDownList.UniqueID];
                TextInfo textInfo2 = new CultureInfo("en-US", false).TextInfo;
                venueGroup = textInfo2.ToTitleCase(venueGroup.ToLower());
            }

            string subVenue = Request.Form[VenueDropDownList2.UniqueID];

            if (subVenue == "" || subVenue == null)
            {
                subVenue = "";
            }
            else
            {
                subVenue = Request.Form[VenueDropDownList2.UniqueID];
            }

            string marketingProgram;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                if (venueGroup=="Coldline" || venueGroup=="COLDLINE")
                {
                    marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];// MarketingPrgmDropDownList.Items[MarketingPrgmDropDownList.SelectedIndex].Text;

            }
                else {

                    marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];
                }

            }
            else
            {
                marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];// MarketingPrgmDropDownList.Items[MarketingPrgmDropDownList.SelectedIndex].Text;

            }

            

            string agent_marketingSource;

            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                agent_marketingSource = Request.Form[AgentsDropDownListInd.UniqueID];
            }
            else
            {
                agent_marketingSource = Request.Form[AgentsDropDownList.UniqueID];

            }

            string toName_sourceCode;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                toName_sourceCode = Request.Form[TONameDropDownList.UniqueID];
            }
            else
            {
                if (venueGroup == "Coldline" || venueGroup == "COLDLINE")
                {
                    toName_sourceCode = sourcecodetext.Text;
                }
                else
                {
                    toName_sourceCode = Request.Form[AgentCodeDropDownList.UniqueID];
                }
            }

            string toManager;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                if (venueGroup == "Coldline" || venueGroup == "COLDLINE")
                {
                    toManager = Request.Form[ManagerDropDownList.UniqueID];
                }
                else
                {
                    toManager = toName_sourceCode;
                }
            }
            else
            {

                toManager = "";
            }

            string promoSource = OfficeSourceTextBox.Text;
            string teleMarketingAgent = FAgentDropDownList.SelectedItem.Text;
            string preArrival = PreArrivalDropDownList.SelectedItem.Text;
            string verification = VerificationDropDownList.SelectedItem.Text;
            string guestRelations = DropDownListFly.SelectedItem.Text;


            string membertype1, memno1;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                if (marketingProgram == "Owner" || marketingProgram == "OWNER")
                {
                    membertype1 = MemType1DropDownList.SelectedItem.Text;
                    string memno = Memno1TextBox.Text.ToUpper();
                    if (memno == null || memno == "")
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
                    string memno = Request.Form[TypeDropDownList.UniqueID];//TypeDropDownList.SelectedItem.Text;
                    if (memno == null || memno == "")
                    {

                        memno1 = "";
                    }
                    else
                    {

                        memno1 = Request.Form[TypeDropDownList.UniqueID];
                    }


                }
            }
            else
            {
                membertype1 = "";
                memno1 = "";
            }

            string subVenueGroup = subGroup.SelectedItem.Value;
            string leadOffices = leadOffice.SelectedItem.Value;

            // Primary Profile Details //
            string primaryTitle = Request.Form[primarytitleDropDownList.UniqueID];
            string primaryFirstName = pfnameTextBox.Text;
            string primaryLastName = plnameTextBox.Text;
            string primaryDateOfBirth = pdobdatepicker.Text;
            string primaryAge = TextPrimaryAge.Text;
            string primaryEmploymentStatus = employmentstatusDropDownList.SelectedItem.Text;
            string primaryNationality = Request.Form[primarynationalityDropDownList.UniqueID];
            string primaryCountry = Request.Form[PrimaryCountryDropDownList.UniqueID];
            if (primaryCountry == "" || primaryCountry == null)
            { primaryCountry = ""; }
            else { primaryCountry = Request.Form[PrimaryCountryDropDownList.UniqueID]; }

            //string primaryMobileCode = Request.Form[primarymobileDropDownList.UniqueID];
            //string primaryMobileNumber = pmobileTextBox.Text;

            //string primaryAlternateCode = Request.Form[primaryalternateDropDownList.UniqueID];
            //string PrimaryAlternateNumber = palternateTextBox.Text;

            //string primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID];
            //if (primaryHomeCode == "" || primaryHomeCode == null)
            //{
            //    primaryHomeCode = "";
            //}
            //else { primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID]; }
            //string primaryHomeNumber = phomenoTextBox.Text;

            //string primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID];
            //if (primaryOfficeCode == "" || primaryOfficeCode == null)
            //{
            //    primaryOfficeCode = "";
            //}
            //else { primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID]; }

            //string primaryOfficeNumber = pofficenoTextBox.Text;


            string primaryMobileCode = ""; string primaryMobileNumber = ""; string primaryAlternateCode = ""; string PrimaryAlternateNumber = "";
            string primaryHomeCode = ""; string primaryHomeNumber = ""; string primaryOfficeCode = ""; string primaryOfficeNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                primaryMobileCode = Request.Form[primarymobileDropDownList.UniqueID];
                primaryMobileNumber = pmobileTextBox.Text;

                primaryAlternateCode = Request.Form[primaryalternateDropDownList.UniqueID];
                PrimaryAlternateNumber = palternateTextBox.Text;

                primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID];
                if (primaryHomeCode == "" || primaryHomeCode == null)
                {
                    primaryHomeCode = "";
                }
                else { primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID]; }
                primaryHomeNumber = phomenoTextBox.Text;

                primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID];
                if (primaryOfficeCode == "" || primaryOfficeCode == null)
                {
                    primaryOfficeCode = "";
                }
                else { primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID]; }

                primaryOfficeNumber = pofficenoTextBox.Text;
            }
            else
            {
                primaryMobileCode = Request.Form[primarymobileDropDownList.UniqueID];
                string pcc1;
                pcc1 = Queries2.getcountrycodefromstring(primaryMobileCode);
                if (pcc1 == "" || pcc1 == null)
                {
                    pcc1 = "";
                }
                else
                {
                    pcc1 = Queries2.getcountrycodefromstring(primaryMobileCode);
                }
                primaryMobileCode = pcc1;
                primaryMobileNumber = pmobileTextBox.Text;

                primaryAlternateCode = Request.Form[primaryalternateDropDownList.UniqueID];
                string paltrcc1;
                paltrcc1 = Queries2.getcountrycodefromstring(primaryAlternateCode);
                if (paltrcc1 == "" || paltrcc1 == null)
                {
                    paltrcc1 = "";
                }
                else
                {
                    paltrcc1 = Queries2.getcountrycodefromstring(primaryAlternateCode);
                }
                primaryAlternateCode = paltrcc1;
                PrimaryAlternateNumber = palternateTextBox.Text;

                primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID];
                if (primaryHomeCode == "" || primaryHomeCode == null)
                {
                    primaryHomeCode = "";
                }
                else { primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID]; }
                primaryHomeNumber = phomenoTextBox.Text;

                primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID];
                if (primaryOfficeCode == "" || primaryOfficeCode == null)
                {
                    primaryOfficeCode = "";
                }
                else { primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID]; }
                primaryOfficeNumber = pofficenoTextBox.Text;
            }

            string primaryEmail1 = pemailTextBox.Text;
            string primaryEmail2 = pemailTextBox2.Text;



            string primaryLanguage;

            if (Request.Form["primarylang"] == null)
            {
                primaryLanguage = "";
            }
            else
            {
                primaryLanguage = Request.Form["primarylang"];

            }

            string primaryIDCardType = TextBoxPrimIDType.Text;
            string primaryIDCardNumber = TextBoxPrimID.Text;
            //--------------------------------------------//

            // Secondary Profile Details //
            string secondaryTitle = Request.Form[secondarytitleDropDownList.UniqueID];
            string secondaryFirstName = sfnameTextBox.Text;
            string secondaryLastName = slnameTextBox.Text;
            string secondaryDateOfBirth = sdobdatepicker.Text;
            string secondaryAge = TextSecondAge.Text;
            string secondaryEmploymentStatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            string secondaryNationality = Request.Form[secondarynationalityDropDownList.UniqueID];
            string secondaryCountry = Request.Form[SecondaryCountryDropDownList.UniqueID];
            if (secondaryCountry == "" || secondaryCountry == null)
            { secondaryCountry = ""; }
            else { secondaryCountry = Request.Form[SecondaryCountryDropDownList.UniqueID]; }

            //string secondaryMobileCode = Request.Form[secondarymobileDropDownList.UniqueID];
            //string secondaryMobileNumber = smobileTextBox.Text;

            //string secondaryAlternateCode = Request.Form[secondaryalternateDropDownList.UniqueID];
            //string secondaryAlternateNumber = salternateTextBox.Text;

            //string secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID];
            //if (secondaryHomeCode == "" || secondaryHomeCode == null)
            //{
            //    secondaryHomeCode = "";
            //}
            //else { secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID]; }
            //string secondaryHomeNumber = shomenoTextBox.Text;

            //string secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID];
            //if (secondaryOfficeCode == "" || secondaryOfficeCode == null)
            //{
            //    secondaryOfficeCode = "";
            //}
            //else { secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID]; }
            //string secondaryOfficeNumber = sofficenoTextBox.Text;


            string secondaryMobileCode = ""; string secondaryMobileNumber = ""; string secondaryAlternateCode = ""; string secondaryAlternateNumber = "";
            string secondaryHomeCode = ""; string secondaryHomeNumber = ""; string secondaryOfficeCode = ""; string secondaryOfficeNumber = "";

            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                secondaryMobileCode = Request.Form[secondarymobileDropDownList.UniqueID];
                secondaryMobileNumber = smobileTextBox.Text;

                secondaryAlternateCode = Request.Form[secondaryalternateDropDownList.UniqueID];
                secondaryAlternateNumber = salternateTextBox.Text;

                secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID];
                if (secondaryHomeCode == "" || secondaryHomeCode == null)
                {
                    secondaryHomeCode = "";
                }
                else { secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID]; }
                secondaryHomeNumber = shomenoTextBox.Text;

                secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID];
                if (secondaryOfficeCode == "" || secondaryOfficeCode == null)
                {
                    secondaryOfficeCode = "";
                }
                else { secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID]; }
                secondaryOfficeNumber = sofficenoTextBox.Text;


            }
            else
            {
                secondaryMobileCode = Request.Form[secondarymobileDropDownList.UniqueID];
                string scc1;
                scc1 = Queries2.getcountrycodefromstring(secondaryMobileCode);
                if (scc1=="" || scc1==null)
                {
                    scc1 = "";
                }else
                {
                    scc1= Queries2.getcountrycodefromstring(secondaryMobileCode);
                }
                secondaryMobileCode = scc1;
                secondaryMobileNumber = smobileTextBox.Text;

                secondaryAlternateCode = Request.Form[secondaryalternateDropDownList.UniqueID];
                string saltcc1;
                saltcc1 = Queries2.getcountrycodefromstring(secondaryAlternateCode);
                if (saltcc1 == "" || saltcc1 == null)
                {
                    saltcc1 = "";
                }
                else
                {
                    saltcc1 = Queries2.getcountrycodefromstring(secondaryAlternateCode);
                }
                secondaryAlternateCode = saltcc1;
                secondaryAlternateNumber = salternateTextBox.Text;

                secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID];
                if (secondaryHomeCode == "" || secondaryHomeCode == null)
                {
                    secondaryHomeCode = "";
                }
                else { secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID]; }
                secondaryHomeNumber = shomenoTextBox.Text;

                secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID];
                if (secondaryOfficeCode == "" || secondaryOfficeCode == null)
                {
                    secondaryOfficeCode = "";
                }
                else { secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID]; }
                secondaryOfficeNumber = sofficenoTextBox.Text;


            }

            string secondaryEmail1 = semailTextBox.Text;
            string secondaryEmail2 = semailTextBox2.Text;


            string secondaryLanguage;
            if (Request.Form["seclang"] == null)
            {
                secondaryLanguage = "";
            }

            else
            {
                secondaryLanguage = Request.Form["seclang"];

            }

            string secondaryIDCardType = TextBoxSecoIDType.Text;
            string secondaryIDCardNumber = TextBoxSecoID.Text;

            //--------------------------------------------//

            // Address Details//
            string addressLine1 = address1TextBox.Text;
            string addressLine2 = address2TextBox.Text;
            string primaryDesignation = maledesgTextBox.Text;
            string secondaryDesignation = femaledesgTextBox.Text;
            string photoIdentity;
            if (Request.Form["pidentity"] == null)
            {
                photoIdentity = "";
            }
            else
            {
                photoIdentity = Request.Form["pidentity"];
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

            string addressCountry = Request.Form[AddCountryDropDownList.UniqueID];
            string addressState;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                addressState = Request.Form[StateDropDownList.UniqueID];
                if (addressState == "" || addressState == null) { addressState = ""; } else { addressState = Request.Form[StateDropDownList.UniqueID]; }
            }
            else
            {
                addressState = stateTextBox.Text;
            }

            string addressCity = cityTextBox.Text;
            string addressPincode = pincodeTextBox.Text;
            string martialStatus = MaritalStatusDropDownList.SelectedItem.Text;
            string livingYears = livingyrsTextBox.Text;

            //--------------------------------------------//

            // Sub Profile 1 Profile Details //
            string subProfileTitle = Request.Form[subprofile1titleDropDownList.UniqueID];
            string subProfileFirstName = sp1fnameTextBox.Text;
            string subProfileLastName = sp1lnameTextBox.Text;
            string subProfileDateOfBirth = sp1dobdatepicker.Text;
            string subProfileAge = TextSP1Age.Text;

            string subProfileNationality = Request.Form[subprofile1nationalityDropDownList.UniqueID];
            string subProfileCountry = Request.Form[SubProfile1CountryDropDownList.UniqueID];
            if (subProfileCountry == "" || subProfileCountry == null)
            { subProfileCountry = ""; }
            else { subProfileCountry = Request.Form[SubProfile1CountryDropDownList.UniqueID]; }

            //string subProfileMobileCode = Request.Form[subprofile1mobileDropDownList.UniqueID];
            //string subProfileMobileNumber = sp1mobileTextBox.Text;

            //string subProfileAlternateCode = Request.Form[subprofile1alternateDropDownList.UniqueID];
            //string subProfileAlternateNumber = sp1alternateTextBox.Text;



            string subProfileMobileCode = ""; string subProfileMobileNumber = ""; string subProfileAlternateCode = ""; string subProfileAlternateNumber = "";

            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfileMobileCode = Request.Form[subprofile1mobileDropDownList.UniqueID];
                subProfileMobileNumber = sp1mobileTextBox.Text;

                subProfileAlternateCode = Request.Form[subprofile1alternateDropDownList.UniqueID];
                subProfileAlternateNumber = sp1alternateTextBox.Text;
            }
            else
            {
                subProfileMobileCode = Request.Form[subprofile1mobileDropDownList.UniqueID];
                string sp1cc1;
                sp1cc1 = Queries2.getcountrycodefromstring(subProfileMobileCode);
                if (sp1cc1 == "" || sp1cc1 == null)
                {
                    sp1cc1 = "";
                }
                else
                {
                    sp1cc1 = Queries2.getcountrycodefromstring(subProfileMobileCode);
                }
                subProfileMobileCode = sp1cc1;
                subProfileMobileNumber = sp1mobileTextBox.Text;

                subProfileAlternateCode = Request.Form[subprofile1alternateDropDownList.UniqueID];
                string sp1altcc1;
                sp1altcc1 = Queries2.getcountrycodefromstring(subProfileAlternateCode);
                if (sp1altcc1 == "" || sp1altcc1 == null)
                {
                    sp1altcc1 = "";
                }
                else
                {
                    sp1altcc1 = Queries2.getcountrycodefromstring(subProfileAlternateCode);
                }
                subProfileAlternateCode = sp1altcc1;
                subProfileAlternateNumber = sp1alternateTextBox.Text;

            }

            string subProfileEmail1 = sp1emailTextBox.Text;
            string subProfileEmail2 = sp1emailTextBox2.Text;

            string subProfileIDCardType = TextBoxSP1IDType.Text;
            string subProfileIDCardNumber = TextBoxSP1ID.Text;

            //--------------------------------------------//


            // Sub Profile 2 Profile Details //

            string subProfile2Title = Request.Form[subprofile2titleDropDownList.UniqueID];
            string subProfile2FirstName = sp2fnameTextBox.Text;
            string subProfile2LastName = sp2lnameTextBox.Text;
            string subProfile2DateOfBirth = sp2dobdatepicker.Text;
            string subProfile2Age = TextSP2Age.Text;

            string subProfile2Nationality = Request.Form[subprofile2nationalityDropDownList.UniqueID];
            string subProfile2Country = Request.Form[SubProfile2CountryDropDownList.UniqueID];
            if (subProfile2Country == "" || subProfile2Country == null)
            { subProfile2Country = ""; }
            else { subProfile2Country = Request.Form[SubProfile2CountryDropDownList.UniqueID]; }

            //string subProfile2MobileCode = Request.Form[subprofile2mobileDropDownList.UniqueID];
            //string subProfile2MobileNumber = sp2mobileTextBox.Text;

            //string subProfile2AlternateCode = Request.Form[subprofile2alternateDropDownList.UniqueID];
            //string subProfile2AlternateNumber = sp2alternateTextBox.Text;

            string subProfile2MobileCode = ""; string subProfile2MobileNumber = ""; string subProfile2AlternateCode = ""; string subProfile2AlternateNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfile2MobileCode = Request.Form[subprofile2mobileDropDownList.UniqueID];
                subProfile2MobileNumber = sp2mobileTextBox.Text;

                subProfile2AlternateCode = Request.Form[subprofile2alternateDropDownList.UniqueID];
                subProfile2AlternateNumber = sp2alternateTextBox.Text;
            }
            else
            {
                subProfile2MobileCode = Request.Form[subprofile2mobileDropDownList.UniqueID];
                string sp2cc1;
                sp2cc1 = Queries2.getcountrycodefromstring(subProfile2MobileCode);
                if (sp2cc1 == "" || sp2cc1 == null)
                {
                    sp2cc1 = "";
                }
                else
                {
                    sp2cc1 = Queries2.getcountrycodefromstring(subProfile2MobileCode);
                }
                subProfile2MobileCode = sp2cc1;
                subProfile2MobileNumber = sp2mobileTextBox.Text;

                subProfile2AlternateCode = Request.Form[subprofile2alternateDropDownList.UniqueID];
                string sp2altccc1;
                sp2altccc1 = Queries2.getcountrycodefromstring(subProfile2AlternateCode);
                if (sp2altccc1 == "" || sp2altccc1 == null)
                {
                    sp2altccc1 = "";
                }
                else
                {
                    sp2altccc1 = Queries2.getcountrycodefromstring(subProfile2AlternateCode);
                }
                subProfile2AlternateCode = sp2altccc1;
                subProfile2AlternateNumber = sp2alternateTextBox.Text;

            }

            string subProfile2Email1 = sp2emailTextBox.Text;
            string subProfile2Email2 = sp2emailTextBox2.Text;

            string subProfile2IDCardType = TextBoxSP2IDType.Text;
            string subProfile2IDCardNumber = TextBoxSP2ID.Text;

            //--------------------------------------------//

            // Sub Profile 3 Profile Details //

            string subProfile3Title = Request.Form[SubP3TitleDropDownList.UniqueID];
            string subProfile3FirstName = SubP3FnameTextBox.Text;
            string subProfile3LastName = SubP3LnameTextBox.Text;
            string subProfile3DateOfBirth = SubP3DOB.Text;
            string subProfile3Age = TextSP3Age.Text;

            string subProfile3Nationality = Request.Form[SubP3NationalityDropDownList.UniqueID];
            string subProfile3Country = Request.Form[SubP3CountryDropDownList.UniqueID];
            if (subProfile3Country == "" || subProfile3Country == null)
            { subProfile3Country = ""; }
            else { subProfile3Country = Request.Form[SubP3CountryDropDownList.UniqueID]; }

            //string subProfile3MobileCode = Request.Form[SubP3CCDropDownList.UniqueID];
            //string subProfile3MobileNumber = SubP3MobileTextBox.Text;

            //string subProfile3AlternateCode = Request.Form[SubP3CCDropDownList2.UniqueID];
            //string subProfile3AlternateNumber = SubP3AMobileTextBox.Text;

            string subProfile3MobileCode = ""; string subProfile3MobileNumber = ""; string subProfile3AlternateCode = "";
            string subProfile3AlternateNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfile3MobileCode = Request.Form[SubP3CCDropDownList.UniqueID];
                subProfile3MobileNumber = SubP3MobileTextBox.Text;

                subProfile3AlternateCode = Request.Form[SubP3CCDropDownList2.UniqueID];
                subProfile3AlternateNumber = SubP3AMobileTextBox.Text;

            }
            else
            {
                subProfile3MobileCode = Request.Form[SubP3CCDropDownList.UniqueID];
                string sp3cc1;
                sp3cc1 = Queries2.getcountrycodefromstring(subProfile3MobileCode);
                if (sp3cc1 == "" || sp3cc1 == null)
                {
                    sp3cc1 = "";
                }
                else
                {
                    sp3cc1 = Queries2.getcountrycodefromstring(subProfile3MobileCode);
                }
                subProfile3MobileCode = sp3cc1;
                subProfile3MobileNumber = SubP3MobileTextBox.Text;


                subProfile3AlternateCode = Request.Form[SubP3CCDropDownList2.UniqueID];
                string sp3altcc1;
                sp3altcc1 = Queries2.getcountrycodefromstring(subProfile3AlternateCode);
                if (sp3altcc1 == "" || sp3altcc1 == null)
                {
                    sp3altcc1 = "";
                }
                else
                {
                    sp3altcc1 = Queries2.getcountrycodefromstring(subProfile3AlternateCode);
                }
                subProfile3AlternateCode = sp3altcc1;
                subProfile3AlternateNumber = SubP3AMobileTextBox.Text;

            }


            string subProfile3Email1 = SubP3EmailTextBox.Text;
            string subProfile3Email2 = SubP3EmailTextBox2.Text;

            string subProfile3IDCardType = TextBoxSP3IDType.Text;
            string subProfile3IDCardNumber = TextBoxSP3ID.Text;

            //--------------------------------------------//

            // Sub Profile 4 Profile Details //

            string subProfile4Title = Request.Form[SubP4TitleDropDownList.UniqueID];
            string subProfile4FirstName = SubP4FnameTextBox.Text;
            string subProfile4LastName = SubP4LnameTextBox.Text;
            string subProfile4DateOfBirth = SubP4DOB.Text;
            string subProfile4Age = TextSP4Age.Text;

            string subProfile4Nationality = Request.Form[SubP4NationalityDropDownList.UniqueID];
            string subProfile4Country = Request.Form[SubP4CountryDropDownList.UniqueID];
            if (subProfile4Country == "" || subProfile4Country == null)
            { subProfile4Country = ""; }
            else { subProfile4Country = Request.Form[SubP4CountryDropDownList.UniqueID]; }

            //string subProfile4MobileCode = Request.Form[SubP4CCDropDownList.UniqueID];
            //string subProfile4MobileNumber = SubP4MobileTextBox.Text;

            //string subProfile4AlternateCode = Request.Form[SubP4CCDropDownList2.UniqueID];
            //string subProfile4AlternateNumber = SubP4AMobileTextBox.Text;

            string subProfile4MobileCode = ""; string subProfile4MobileNumber = ""; string subProfile4AlternateCode = "";
            string subProfile4AlternateNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfile4MobileCode = Request.Form[SubP4CCDropDownList.UniqueID];
                subProfile4MobileNumber = SubP4MobileTextBox.Text;

                subProfile4AlternateCode = Request.Form[SubP4CCDropDownList2.UniqueID];
                subProfile4AlternateNumber = SubP4AMobileTextBox.Text;
            }
            else
            {
                subProfile4MobileCode = Request.Form[SubP4CCDropDownList.UniqueID];
                string sp4cc1;
                sp4cc1 = Queries2.getcountrycodefromstring(subProfile4MobileCode);
                if (sp4cc1 == "" || sp4cc1 == null)
                {
                    sp4cc1 = "";
                }
                else
                {
                    sp4cc1 = Queries2.getcountrycodefromstring(subProfile4MobileCode);
                }
                subProfile4MobileCode = sp4cc1;
                subProfile4MobileNumber = SubP4MobileTextBox.Text;

                subProfile4AlternateCode = Request.Form[SubP4CCDropDownList2.UniqueID];
                string sp4altcc1;
                sp4altcc1 = Queries2.getcountrycodefromstring(subProfile4AlternateCode);
                if (sp4altcc1 == "" || sp4altcc1 == null)
                {
                    sp4altcc1 = "";
                }
                else
                {
                    sp4altcc1 = Queries2.getcountrycodefromstring(subProfile4AlternateCode);
                }
                subProfile4AlternateCode = sp4altcc1;
                subProfile4AlternateNumber = SubP4AMobileTextBox.Text;

            }

            string subProfile4Email1 = SubP4EmailTextBox.Text;
            string subProfile4Email2 = SubP4EmailTextBox2.Text;

            string subProfile4IDCardType = TextBoxSP4IDType.Text;
            string subProfile4IDCardNumber = TextBoxSP4ID.Text;

            //--------------------------------------------//


            // Profile Stay Details //

            string arrivalDate;
            string resortName = hotelTextBox.Text;
            string resortRoomNumber = roomnoTextBox.Text;

            string arrivalDate1 = checkindatedatepicker.Text;
            if (arrivalDate1=="" || arrivalDate1==null)
            {
                 arrivalDate = "";
            }
            else
            {
                DateTime dtt = DateTime.ParseExact(arrivalDate1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                arrivalDate = dtt.ToString("yyyy-MM-dd");
            }

            string departureDate;
            string departureDate1 = checkoutdatedatepicker.Text;
            if (departureDate1 == "" || departureDate1 == null)
            {
                departureDate = "";
            }
            else
            {
                DateTime dtt1 = DateTime.ParseExact(departureDate1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                 departureDate = dtt1.ToString("yyyy-MM-dd");
            }


        
            //---------------------------------//

            // Profile Tour Details //

            string questStatus = gueststatusDropDownList.SelectedItem.Text;
            string qStatus = QStatusDropDownList1.SelectedItem.Text;
            string checkInTime = deckcheckintimeTextBox.Text;
            string checkOutTime = deckcheckouttimeTextBox.Text;
            string salesRepresentative = Request.Form[salesrepDropDownList.UniqueID];
            if (salesRepresentative == "" || salesRepresentative == null) { salesRepresentative = ""; } else { salesRepresentative = Request.Form[salesrepDropDownList.UniqueID]; }

            string tourDate;
            int weekNo;
            if (tourdatedatepicker.Text == "" || tourdatedatepicker.Text == null || tourdatedatepicker.Text == "NaN")
            {
                tourDate = "";
                weekNo = 0;
            }
            else
            {
                DateTime dtt4 = DateTime.ParseExact(tourdatedatepicker.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                 tourDate = dtt4.ToString("yyyy-MM-dd");

                weekNo = Queries.GetWkNumber(Convert.ToDateTime(tourDate));

            }

           

            string taxiInPrice = taxipriceInTextBox.Text;
            if (taxiInPrice == "" || taxiInPrice == null)
            {
                taxiInPrice = "0";
            }
            else
            {
                taxiInPrice = taxipriceInTextBox.Text;
            }
            string taxiInRef = TaxiRefInTextBox.Text;

            string taxiOutPrice = TaxiPriceOutTextBox.Text;
            if (taxiOutPrice == "" || taxiOutPrice == null)
            {
                taxiOutPrice = "0";
            }
            else
            {
                taxiOutPrice = TaxiPriceOutTextBox.Text;
            }
            string taxiOutRef = TaxiRefOutTextBox.Text;

            //---------------------------------//



            string regTerm1;
            if (Regterms1.Checked)
            {

                regTerm1 = "Y";
            }
            else
            {
                regTerm1 = "N";

            }

            string regTerm2;
            if (Regterms2.Checked)
            {

                regTerm2 = "Y";
            }
            else
            {
                regTerm2 = "N";

            }


            if (venuecountry == "")
            { }
            else
            {
                // Insertion of Profile //
                int profile = Queries.InsertProfile(Session["ProfileID"].ToString(), DateTime.Now, profileCreatedBy, venuecountry, venue, venueGroup, marketingProgram, agent_marketingSource, toName_sourceCode, membertype1, memno1, "", "", primaryEmploymentStatus, martialStatus, livingYears, office, commentTextBox.Text.ToUpper(), toManager, photoIdentity, card, reception, subVenue, regTerm1, viewPointID, "", regTerm2, secondaryEmploymentStatus, guestRelations, preArrival, comment2.Text.ToUpper(), verification, promoSource, teleMarketingAgent,subVenueGroup,leadOffices);
                string log1 = "Profile Details:" + " " + "Profile ID:" + Session["ProfileID"].ToString() + "," + "Created date:" + TextBox1.Text + "," + CreatedByTextBox.Text + "," + "venue country:" + venuecountry + "," + "venue: " + venue + "," + "Venue Group: " + venueGroup + "," + "Marketing Program :" + marketingProgram + "," + "Agent_MarketingSource :" + agent_marketingSource + "," + "TOName_SourceCode:" + toName_sourceCode + "," + "Primary_Employment_status :" + primaryEmploymentStatus + "," + "Martial_Status :" + martialStatus + "," + "Living Years :" + livingYears + "," + "Office :" + office + "," + "comments :" + commentTextBox.Text.ToUpper() + "," + "Manager:" + toManager + "," + "membertype1:" + "" + "," + "memno1:" + "" + "," + "membertype2:" + "" + "," + "memno2:" + "" + "," + "Photo Identity:" + photoIdentity + "," + "Card Holder:" + card + "," + "Registration Terms:" + regTerm1 + "," + "View Point ID:" + viewPointID + "," + "Registration Terms 2:" + regTerm2 + "," + "Secondary_Employemnt_status:" + secondaryEmploymentStatus + "," + "Guest Relations :" + guestRelations + "," + "Pre Arrival:" + preArrival + "," + "comment2:" + comment2.Text.ToUpper() + "," + "verification:" + verification + "," + "Promo Source:" + promoSource + "," + "Tele Marketing Agent:" + teleMarketingAgent + ","+" Sub Venue Group :"+subVenueGroup+","+" lead office: "+leadOffices;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log1, profileCreatedBy, DateTime.Now.ToString());
                int update = Queries.UpdateProfileValue(office, year);
                // ------------------- //

                // Insertion of Primary Profile //
                string primaryProfileID = Queries.GetPrimaryProfileID(office);
                int primary = Queries.InsertPrimaryProfile(primaryProfileID, primaryTitle, primaryFirstName.ToUpper(), primaryLastName.ToUpper(), primaryDateOfBirth, primaryNationality, primaryCountry, Session["ProfileID"].ToString(), primaryAge, primaryDesignation.ToUpper(), primaryLanguage);
                int updatep = Queries.UpdatePrimaryValue(office, year);

                string log2 = "Primary details:" + " " + "primary ID:" + primaryProfileID + "," + "title:" + primaryTitle + "," + "Fname:" + primaryFirstName.ToUpper() + "," + "Lname:" + primaryLastName.ToUpper() + "," + "DOB:" + primaryDateOfBirth + "," + "nationality:" + primaryNationality + "," + "Country:" + primaryCountry + "," + "Profile ID:" + Session["ProfileID"].ToString() + "Age:" + primaryAge + "," + "Designation:" + primaryDesignation.ToUpper() + "," + "Languages spoken:" + primaryLanguage;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log2, profileCreatedBy, DateTime.Now.ToString());
                // ------------------- //

                // Insertion of Secondary Profile //
                if (secondaryTitle == "")
                {

                }
                else
                {
                    string secondaryProfileID = Queries.GetSecondaryProfileID(office);
                    int secondary = Queries.InsertSecondaryProfile(secondaryProfileID, secondaryTitle, secondaryFirstName.ToUpper(), secondaryLastName.ToUpper(), secondaryDateOfBirth, secondaryNationality, secondaryCountry, Session["ProfileID"].ToString(), secondaryAge, secondaryDesignation.ToUpper(), secondaryLanguage);
                    int updates = Queries.UpdateSecondaryValue(office, year);

                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryProfileID + "," + "title:" + secondaryTitle + "," + "Fname:" + secondaryFirstName.ToUpper() + "," + "Lname:" + secondaryLastName.ToUpper() + "," + "DOB:" + secondaryDateOfBirth + "," + "nationality:" + secondaryNationality + "," + "Country:" + secondaryCountry + "," + "Profiel ID:" + Session["ProfileID"].ToString() + "Age:" + secondaryAge + "," + "Designation:" + secondaryDesignation.ToUpper() + "," + "Languages spoken:" + secondaryLanguage;
                    int insertlog3 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log3, profileCreatedBy, DateTime.Now.ToString());
                }
                // ------------------- //

                // Insertion of Profile Address //
                string addressID = Queries.GetAddressProfileID(office);
                int address = Queries.InsertProfileAddress(addressID, addressLine1.ToUpper(), addressLine2.ToUpper(), addressState.ToUpper(), addressCity.ToUpper(), addressPincode.ToUpper(), DateTime.Now, "", Session["ProfileID"].ToString(), addressCountry);
                int updateadd = Queries.UpdateAddressValue(office, year);

                string log4 = "Address details:" + " " + "address  id:" + addressID + "," + "address1:" + addressLine1.ToUpper() + "," + "address2:" + addressLine2.ToUpper() + "," + "state:" + addressState.ToUpper() + "," + "city:" + addressCity.ToUpper() + "," + "pincode:" + addressPincode.ToUpper() + "," + "Country: " + addressCountry + "," + "Created Date:" + DateTime.Now + "," + "Profile ID:" + Session["ProfileID"].ToString();
                int insertlog4 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log4, profileCreatedBy, DateTime.Now.ToString());
                // ------------------- //


                // Insertion of Sub Profile 1 //
                if (subProfileTitle == "")
                { }
                else
                {

                    string subProfileID = Queries.GetSubProfile1ID(office);
                    int subprofielid = Queries.InsertSub_Profile1(subProfileID, subProfileTitle, subProfileFirstName.ToUpper(), subProfileLastName.ToUpper(), subProfileDateOfBirth, subProfileNationality, subProfileCountry, Session["ProfileID"].ToString(), subProfileAge);
                    int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


                    string log5 = "sub profile 1 details:" + " " + "sp1 id:" + subProfileID + "," + "title:" + subProfileTitle + "," + "Fname:" + subProfileFirstName.ToUpper() + "," + "Lname:" + subProfileLastName.ToUpper() + "," + "DOB:" + subProfileDateOfBirth + "," + "nationality:" + subProfileNationality + "," + "Country:" + subProfileCountry + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub1 age: " + subProfileAge;
                    int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log5, profileCreatedBy, DateTime.Now.ToString());
                }
                // ------------------- //

                // Insertion of Sub Profile 2 //
                if (subProfile2Title == "")
                {

                }
                else
                {
                    string subProfile2ID = Queries.GetSubProfile2ID(office);
                    int subprofielid2 = Queries.InsertSub_Profile2(subProfile2ID, subProfile2Title, subProfile2FirstName.ToUpper(), subProfile2LastName.ToUpper(), subProfile2DateOfBirth, subProfile2Nationality, subProfile2Country, Session["ProfileID"].ToString(), subProfile2Age);
                    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

                    string log6 = "sub profile 2 details:" + " " + "sp2 id:" + subProfile2ID + "," + "title:" + subProfile2Title + "," + "Fname:" + subProfile2FirstName.ToUpper() + "," + "Lname:" + subProfile2LastName.ToUpper() + "," + "DOB:" + subProfile2DateOfBirth + "," + "nationality:" + subProfile2Nationality + "," + "Country:" + subProfile2Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub2 age: " + subProfile2Age;
                    int insertlog6 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log6, profileCreatedBy, DateTime.Now.ToString());

                }

                // ------------------- //

                // Insertion of Sub Profile 3 //
                if (subProfile3Title == "")
                {

                }
                else
                {
                    string subProfile3ID = Queries.GetSubProfile3ID(office);
                    int subprofielid3 = Queries.InsertSub_Profile3(subProfile3ID, subProfile3Title, subProfile3FirstName.ToUpper(), subProfile3LastName.ToUpper(), subProfile3DateOfBirth, subProfile3Nationality, subProfile3Country, Session["ProfileID"].ToString(), subProfile3Age);
                    int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

                    string log12 = "sub profile 3 details:" + " " + "sp3 id:" + subProfile3ID + "," + "title:" + subProfile3Title + "," + "Fname:" + subProfile3FirstName.ToUpper() + "," + "Lname:" + subProfile3LastName.ToUpper() + "," + "DOB:" + subProfile3DateOfBirth + "," + "nationality:" + subProfile3Nationality + "," + "Country:" + subProfile3Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub3 age: " + subProfile3Age;
                    int insertlog12 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log12, profileCreatedBy, DateTime.Now.ToString());

                }

                // ------------------- //

                // Insertion of Sub Profile 4 //

                if (subProfile4Title == "")
                { }
                else
                {
                    string subProfile4ID = Queries.GetSubProfile4ID(office);
                    int subprofielid4 = Queries.InsertSub_Profile4(subProfile4ID, subProfile4Title, subProfile4FirstName.ToUpper(), subProfile4LastName.ToUpper(), subProfile4DateOfBirth, subProfile4Nationality, subProfile4Country, Session["ProfileID"].ToString(), subProfile4Age);
                    int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


                    string log13 = "sub profile4 details:" + " " + "sp4 id:" + subProfile4ID + "," + "title:" + subProfile4Title + "," + "Fname:" + subProfile4FirstName.ToUpper() + "," + "Lname:" + subProfile4LastName.ToUpper() + "," + "DOB:" + subProfile4DateOfBirth + "," + "nationality:" + subProfile4Nationality + "," + "Country:" + subProfile4Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub4 age: " + subProfile4Age;
                    int insertlog13 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log13, profileCreatedBy, DateTime.Now.ToString());
                }

                // ------------------- //

                // Insertion of Profile Phone Details //
                string phoneID = Queries.GetPhoneID(office);
                int phone = Queries.InsertPhone(phoneID, Session["ProfileID"].ToString(), primaryMobileCode, primaryMobileNumber, primaryAlternateCode, PrimaryAlternateNumber, secondaryMobileCode, secondaryMobileNumber, secondaryAlternateCode, secondaryAlternateNumber, subProfileMobileCode, subProfileMobileNumber, subProfileAlternateCode, subProfileAlternateNumber, subProfile2MobileCode, subProfile2MobileNumber, subProfile2AlternateCode, subProfile2AlternateNumber, subProfile3MobileCode, subProfile3MobileNumber, subProfile4MobileCode, subProfile4MobileNumber, subProfile3AlternateCode, subProfile3AlternateNumber, subProfile4AlternateCode, subProfile4AlternateNumber, primaryOfficeCode, primaryOfficeNumber, secondaryOfficeCode, secondaryOfficeNumber, primaryHomeCode, primaryHomeNumber, secondaryHomeCode, secondaryHomeNumber);
                int updatephone = Queries.UpdatePhoneValue(office, year);

                string log7 = "Phone Details:" + " " + "Phone id:" + phoneID + "," + "Profile id:" + Session["ProfileID"].ToString() + "," + "Primary mobile:" + primaryMobileCode + "" + primaryMobileNumber + "," + "primary alternate:" + primaryAlternateCode + "" + PrimaryAlternateNumber + "," + "Secondary mobile:" + secondaryMobileCode + "" + secondaryMobileNumber + "," + "Secondary alternate:" + secondaryAlternateCode + "" + secondaryAlternateNumber + "," + "Subprofile1 mobile:" + subProfileMobileCode + " " + subProfileMobileNumber + "," + "Subprofile1 alternate:" + subProfileAlternateCode + "" + subProfileAlternateNumber + "," + "Subprofile2 mobile:" + subProfile2MobileCode + "" + subProfile2MobileNumber + "," + "subprofile2 alternate:" + subProfile2AlternateCode + "" + subProfile2AlternateNumber + "," + "Subprofile3 mobile:" + subProfile3MobileCode + "" + subProfile3MobileNumber + "," + "subprofile3 alternate:" + subProfile3AlternateCode + "" + subProfile3AlternateNumber + "," + "Subprofile4 mobile:" + subProfile4MobileCode + "" + subProfile4MobileNumber + "," + "subprofile4 alternate:" + subProfile4AlternateCode + "" + subProfile4AlternateNumber + "," + "Primary office code:" + primaryOfficeCode + "," + "Primary Office No:" + primaryOfficeNumber + "," + "Sec office code:" + secondaryOfficeCode + "," + "Sec office num:" + secondaryOfficeNumber;
                int insertlog7 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log7, profileCreatedBy, DateTime.Now.ToString());

                // ------------------- //

                // Insertion of Profile Email Details //
                string emailID = Queries.GetEmailID(office);
                int email = Queries.InsertEmail(emailID, Session["ProfileID"].ToString(), primaryEmail1, secondaryEmail1, subProfileEmail1, subProfile2Email1, primaryEmail2, secondaryEmail2, subProfileEmail2, subProfile2Email2, subProfile3Email1, subProfile3Email2, subProfile4Email1, subProfile4Email2);
                int updateemail = Queries.UpdateEmailValue(office, year);
                string log8 = "Email Details:" + " " + "Email id:" + emailID + "," + "profile id:" + Session["ProfileID"].ToString() + "," + "Primary email:" + primaryEmail1 + "," + "Primary email 2:" + primaryEmail2 + "," + "Secondary email:" + secondaryEmail1 + "," + "Secondary email 2:" + secondaryEmail2 + "," + "Subprofile1 email:" + subProfileEmail1 + "," + "Subprofile1 email 2 :" + subProfileEmail2 + "," + "subprofile2 email:" + subProfile2Email1 + "," + "subprofile2 email 2:" + subProfile2Email2 + "," + "subprofile3 email:" + subProfile3Email1 + "," + "subprofile3 email 2 :" + subProfile3Email2 + "," + "subprofile4 email:" + subProfile4Email1 + "," + "subprofile4 email 2:" + subProfile4Email2;
                int insertlog8 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log8, profileCreatedBy, DateTime.Now.ToString());

                // ------------------- //


                // Insertion of Profile Stay Details //
                string stayID = Queries.GetStayDetailsID(office);
                int staydetails = Queries.InsertProfileStay(stayID, resortName.ToUpper(), resortRoomNumber, arrivalDate, departureDate, Session["ProfileID"].ToString());
                string log9 = "Stay details:" + " " + "Stay ID:" + stayID + "," + "Resort:" + resortName.ToUpper() + "," + "room#:" + resortRoomNumber + "," + "Arrival date:" + arrivalDate + "," + "Departure date:" + departureDate + "," + "Profile id:" + Session["ProfileID"].ToString();
                int updatestay = Queries.UpdateStayValue(office, year);

                int insertlog9 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log9, profileCreatedBy, DateTime.Now.ToString());

                // ------------------- //

                // Insertion of Profile Tour Details //
                string tourID = Queries.GetTourDetailsID(office);
                int tourdetails = Queries.InsertTourDetails(tourID, questStatus, salesRepresentative, tourDate, checkInTime, checkOutTime, taxiInPrice, taxiInRef.ToUpper(), taxiOutPrice, taxiOutRef.ToUpper(), Session["ProfileID"].ToString(), qStatus, weekNo);
                int updatetour = Queries.UpdateTourValue(office, year);
                string log10 = "Tour Details:" + "Tour ID:" + tourID + "," + "Guest status:" + questStatus + "," + "," + "Guest Q status: " + qStatus + "," + " Sales rep:" + salesRepresentative + "," + "tour date:" + tourDate + "," + "Time in:" + checkInTime + "," + "Time out:" + checkOutTime + "," + "Taxi In:" + taxiInPrice + "," + "Taxi Ref In:" + taxiInRef.ToUpper() + "," + "taxi out:" + taxiOutPrice + "," + "taxi Ref out:" + taxiOutRef.ToUpper() + "," + "Profile id:" + Session["ProfileID"].ToString();
                int insertlog10 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log10, profileCreatedBy, DateTime.Now.ToString());
                // ---------------------------------- //

                // Insertion of Profile ID Number Details //
                if (venuecountry=="India" || venuecountry == "INDIA")
                { }else
                {
                    int insert_id_numb = Queries2.InsertID_Numb(Session["ProfileID"].ToString(), primaryIDCardType.ToUpper(), primaryIDCardNumber, secondaryIDCardType.ToUpper(), secondaryIDCardNumber, subProfileIDCardType.ToUpper(), subProfileIDCardNumber, subProfile2IDCardType.ToUpper(), subProfile2IDCardNumber, subProfile3IDCardType.ToUpper(), subProfile3IDCardNumber, subProfile4IDCardType.ToUpper(), subProfile4IDCardNumber, DateTime.Now.ToString());

                }
                
                // ---------------------------------- //


                //   Insertion of Profile Gift Details  //
                if (Request.Form[giftoptionDropDownList.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg1 = TextBoxGPrice1.Text;
                    if (tg1 == "")
                    {
                        tg1 = "0";

                    }
                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList.UniqueID], vouchernoTextBox.Text, TextBoxChargeBack.Text.ToUpper(), Session["ProfileID"].ToString(), "", tg1);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList2.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg2 = TextBoxGPrice2.Text;
                    if (tg2 == "")
                    {
                        tg2 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList2.UniqueID], vouchernoTextBox2.Text, "", Session["ProfileID"].ToString(), "", tg2);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList3.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg3 = TextBoxGPrice3.Text;
                    if (tg3 == "")
                    {
                        tg3 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList3.UniqueID], vouchernoTextBox3.Text, "", Session["ProfileID"].ToString(), "", tg3);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList4.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg4 = TextBoxGPrice4.Text;
                    if (tg4 == "")
                    {
                        tg4 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList4.UniqueID], vouchernoTextBox4.Text, "", Session["ProfileID"].ToString(), "", tg4);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList5.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg5 = TextBoxGPrice5.Text;
                    if (tg5 == "")
                    {
                        tg5 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList5.SelectedItem.Text, vouchernoTextBox5.Text, "", Session["ProfileID"].ToString(), "", tg5);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (Request.Form[giftoptionDropDownList6.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg6 = TextBoxGPrice6.Text;
                    if (tg6 == "")
                    {
                        tg6 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList6.UniqueID], vouchernoTextBox6.Text, "", Session["ProfileID"].ToString(), "", tg6);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (Request.Form[giftoptionDropDownList7.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg7 = TextBoxGPrice7.Text;
                    if (tg7 == "")
                    {
                        tg7 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList7.UniqueID], vouchernoTextBox7.Text, "", Session["ProfileID"].ToString(), "", tg7);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                // ------------------------------------------------------------------------- //


            }
            string msg = "Profile Created with ID = " + Session["ProfileID"].ToString();
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('" + msg + "')", true);

       }
        catch (Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame
           var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();

           string msg = "Error while creating profile " + ex.Message + "  " + line;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

            int delete = Queries2.Deleteprofileonerror(Session["ProfileID"].ToString());

            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

       }
 
        
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ProfileID"] = "";
            string viewPointID = TextVPID.Text;
            if (viewPointID == "")
            {
                viewPointID = "";
            }
            else
            {
                viewPointID = TextVPID.Text;
            }

            string profileCreatedBy = CreatedByTextBox.Text;

            string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            venuecountry = textInfo.ToTitleCase(venuecountry.ToLower());

            string office = Queries.GetOfficeOnVenueCountry(venuecountry);
            int year = DateTime.Now.Year;
            Session["ProfileID"] = Queries.GetProfileID(office);
            string reception = ReceptionistDropDownList.SelectedItem.Text;

            //Request.Form[AgentCodeDropDownList.UniqueID];
            string venue = Request.Form[VenueDropDownList.UniqueID];
            TextInfo textInfo1 = new CultureInfo("en-US", false).TextInfo;
            venue = textInfo1.ToTitleCase(venue.ToLower());

            string venueGroup = Request.Form[GroupVenueDropDownList.UniqueID];
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                if (venueGroup == "Flybuy" || venueGroup == "FLYBUY")
                {
                    venueGroup = "FlyBuy";
                }
                else
                {
                    venueGroup = Request.Form[GroupVenueDropDownList.UniqueID];
                    TextInfo textInfo2 = new CultureInfo("en-US", false).TextInfo;
                    venueGroup = textInfo2.ToTitleCase(venueGroup.ToLower());
                }

            }
            else
            {
                venueGroup = Request.Form[GroupVenueDropDownList.UniqueID];
                TextInfo textInfo2 = new CultureInfo("en-US", false).TextInfo;
                venueGroup = textInfo2.ToTitleCase(venueGroup.ToLower());
            }

            string subVenue = Request.Form[VenueDropDownList2.UniqueID];

            if (subVenue == "" || subVenue == null)
            {
                subVenue = "";
            }
            else
            {
                subVenue = Request.Form[VenueDropDownList2.UniqueID];
            }

            string marketingProgram;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                if (venueGroup == "Coldline" || venueGroup == "COLDLINE")
                {
                    marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];// MarketingPrgmDropDownList.Items[MarketingPrgmDropDownList.SelectedIndex].Text;

                }
                else
                {

                    marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];
                }

            }
            else
            {
                marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];// MarketingPrgmDropDownList.Items[MarketingPrgmDropDownList.SelectedIndex].Text;

            }



            string agent_marketingSource;

            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                agent_marketingSource = Request.Form[AgentsDropDownListInd.UniqueID];
            }
            else
            {
                agent_marketingSource = Request.Form[AgentsDropDownList.UniqueID];

            }

            string toName_sourceCode;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                toName_sourceCode = Request.Form[TONameDropDownList.UniqueID];
            }
            else
            {
                if (venueGroup == "Coldline" || venueGroup == "COLDLINE")
                {
                    toName_sourceCode = sourcecodetext.Text;
                }
                else
                {
                    toName_sourceCode = Request.Form[AgentCodeDropDownList.UniqueID];
                }
            }

            string toManager;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                if (venueGroup == "Coldline" || venueGroup == "COLDLINE")
                {
                    toManager = Request.Form[ManagerDropDownList.UniqueID];
                }
                else
                {
                    toManager = toName_sourceCode;
                }
            }
            else
            {

                toManager = "";
            }

            string promoSource = OfficeSourceTextBox.Text;
            string teleMarketingAgent = FAgentDropDownList.SelectedItem.Text;
            string preArrival = PreArrivalDropDownList.SelectedItem.Text;
            string verification = VerificationDropDownList.SelectedItem.Text;
            string guestRelations = DropDownListFly.SelectedItem.Text;


            string membertype1, memno1;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                if (marketingProgram == "Owner" || marketingProgram == "OWNER")
                {
                    membertype1 = MemType1DropDownList.SelectedItem.Text;
                    string memno = Memno1TextBox.Text.ToUpper();
                    if (memno == null || memno == "")
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
                    string memno = Request.Form[TypeDropDownList.UniqueID];//TypeDropDownList.SelectedItem.Text;
                    if (memno == null || memno == "")
                    {

                        memno1 = "";
                    }
                    else
                    {

                        memno1 = Request.Form[TypeDropDownList.UniqueID];
                    }


                }
            }
            else
            {
                membertype1 = "";
                memno1 = "";
            }

            string subVenueGroup = subGroup.SelectedItem.Value;
            string leadOffices = leadOffice.SelectedItem.Value;

            // Primary Profile Details //
            string primaryTitle = Request.Form[primarytitleDropDownList.UniqueID];
            string primaryFirstName = pfnameTextBox.Text;
            string primaryLastName = plnameTextBox.Text;
            string primaryDateOfBirth = pdobdatepicker.Text;
            string primaryAge = TextPrimaryAge.Text;
            string primaryEmploymentStatus = employmentstatusDropDownList.SelectedItem.Text;
            string primaryNationality = Request.Form[primarynationalityDropDownList.UniqueID];
            string primaryCountry = Request.Form[PrimaryCountryDropDownList.UniqueID];
            if (primaryCountry == "" || primaryCountry == null)
            { primaryCountry = ""; }
            else { primaryCountry = Request.Form[PrimaryCountryDropDownList.UniqueID]; }

            //string primaryMobileCode = Request.Form[primarymobileDropDownList.UniqueID];
            //string primaryMobileNumber = pmobileTextBox.Text;

            //string primaryAlternateCode = Request.Form[primaryalternateDropDownList.UniqueID];
            //string PrimaryAlternateNumber = palternateTextBox.Text;

            //string primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID];
            //if (primaryHomeCode == "" || primaryHomeCode == null)
            //{
            //    primaryHomeCode = "";
            //}
            //else { primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID]; }
            //string primaryHomeNumber = phomenoTextBox.Text;

            //string primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID];
            //if (primaryOfficeCode == "" || primaryOfficeCode == null)
            //{
            //    primaryOfficeCode = "";
            //}
            //else { primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID]; }

            //string primaryOfficeNumber = pofficenoTextBox.Text;


            string primaryMobileCode = ""; string primaryMobileNumber = ""; string primaryAlternateCode = ""; string PrimaryAlternateNumber = "";
            string primaryHomeCode = ""; string primaryHomeNumber = ""; string primaryOfficeCode = ""; string primaryOfficeNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                primaryMobileCode = Request.Form[primarymobileDropDownList.UniqueID];
                primaryMobileNumber = pmobileTextBox.Text;

                primaryAlternateCode = Request.Form[primaryalternateDropDownList.UniqueID];
                PrimaryAlternateNumber = palternateTextBox.Text;

                primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID];
                if (primaryHomeCode == "" || primaryHomeCode == null)
                {
                    primaryHomeCode = "";
                }
                else { primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID]; }
                primaryHomeNumber = phomenoTextBox.Text;

                primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID];
                if (primaryOfficeCode == "" || primaryOfficeCode == null)
                {
                    primaryOfficeCode = "";
                }
                else { primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID]; }

                primaryOfficeNumber = pofficenoTextBox.Text;
            }
            else
            {
                primaryMobileCode = Request.Form[primarymobileDropDownList.UniqueID];
                string pcc1;
                pcc1 = Queries2.getcountrycodefromstring(primaryMobileCode);
                if (pcc1 == "" || pcc1 == null)
                {
                    pcc1 = "";
                }
                else
                {
                    pcc1 = Queries2.getcountrycodefromstring(primaryMobileCode);
                }
                primaryMobileCode = pcc1;
                primaryMobileNumber = pmobileTextBox.Text;

                primaryAlternateCode = Request.Form[primaryalternateDropDownList.UniqueID];
                string paltrcc1;
                paltrcc1 = Queries2.getcountrycodefromstring(primaryAlternateCode);
                if (paltrcc1 == "" || paltrcc1 == null)
                {
                    paltrcc1 = "";
                }
                else
                {
                    paltrcc1 = Queries2.getcountrycodefromstring(primaryAlternateCode);
                }
                primaryAlternateCode = paltrcc1;
                PrimaryAlternateNumber = palternateTextBox.Text;

                primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID];
                if (primaryHomeCode == "" || primaryHomeCode == null)
                {
                    primaryHomeCode = "";
                }
                else { primaryHomeCode = Request.Form[phomecodeDropDownList.UniqueID]; }
                primaryHomeNumber = phomenoTextBox.Text;

                primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID];
                if (primaryOfficeCode == "" || primaryOfficeCode == null)
                {
                    primaryOfficeCode = "";
                }
                else { primaryOfficeCode = Request.Form[pofficecodeDropDownList.UniqueID]; }
                primaryOfficeNumber = pofficenoTextBox.Text;
            }

            string primaryEmail1 = pemailTextBox.Text;
            string primaryEmail2 = pemailTextBox2.Text;



            string primaryLanguage;

            if (Request.Form["primarylang"] == null)
            {
                primaryLanguage = "";
            }
            else
            {
                primaryLanguage = Request.Form["primarylang"];

            }

            string primaryIDCardType = TextBoxPrimIDType.Text;
            string primaryIDCardNumber = TextBoxPrimID.Text;
            //--------------------------------------------//

            // Secondary Profile Details //
            string secondaryTitle = Request.Form[secondarytitleDropDownList.UniqueID];
            string secondaryFirstName = sfnameTextBox.Text;
            string secondaryLastName = slnameTextBox.Text;
            string secondaryDateOfBirth = sdobdatepicker.Text;
            string secondaryAge = TextSecondAge.Text;
            string secondaryEmploymentStatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            string secondaryNationality = Request.Form[secondarynationalityDropDownList.UniqueID];
            string secondaryCountry = Request.Form[SecondaryCountryDropDownList.UniqueID];
            if (secondaryCountry == "" || secondaryCountry == null)
            { secondaryCountry = ""; }
            else { secondaryCountry = Request.Form[SecondaryCountryDropDownList.UniqueID]; }

            //string secondaryMobileCode = Request.Form[secondarymobileDropDownList.UniqueID];
            //string secondaryMobileNumber = smobileTextBox.Text;

            //string secondaryAlternateCode = Request.Form[secondaryalternateDropDownList.UniqueID];
            //string secondaryAlternateNumber = salternateTextBox.Text;

            //string secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID];
            //if (secondaryHomeCode == "" || secondaryHomeCode == null)
            //{
            //    secondaryHomeCode = "";
            //}
            //else { secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID]; }
            //string secondaryHomeNumber = shomenoTextBox.Text;

            //string secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID];
            //if (secondaryOfficeCode == "" || secondaryOfficeCode == null)
            //{
            //    secondaryOfficeCode = "";
            //}
            //else { secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID]; }
            //string secondaryOfficeNumber = sofficenoTextBox.Text;


            string secondaryMobileCode = ""; string secondaryMobileNumber = ""; string secondaryAlternateCode = ""; string secondaryAlternateNumber = "";
            string secondaryHomeCode = ""; string secondaryHomeNumber = ""; string secondaryOfficeCode = ""; string secondaryOfficeNumber = "";

            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                secondaryMobileCode = Request.Form[secondarymobileDropDownList.UniqueID];
                secondaryMobileNumber = smobileTextBox.Text;

                secondaryAlternateCode = Request.Form[secondaryalternateDropDownList.UniqueID];
                secondaryAlternateNumber = salternateTextBox.Text;

                secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID];
                if (secondaryHomeCode == "" || secondaryHomeCode == null)
                {
                    secondaryHomeCode = "";
                }
                else { secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID]; }
                secondaryHomeNumber = shomenoTextBox.Text;

                secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID];
                if (secondaryOfficeCode == "" || secondaryOfficeCode == null)
                {
                    secondaryOfficeCode = "";
                }
                else { secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID]; }
                secondaryOfficeNumber = sofficenoTextBox.Text;


            }
            else
            {
                secondaryMobileCode = Request.Form[secondarymobileDropDownList.UniqueID];
                string scc1;
                scc1 = Queries2.getcountrycodefromstring(secondaryMobileCode);
                if (scc1 == "" || scc1 == null)
                {
                    scc1 = "";
                }
                else
                {
                    scc1 = Queries2.getcountrycodefromstring(secondaryMobileCode);
                }
                secondaryMobileCode = scc1;
                secondaryMobileNumber = smobileTextBox.Text;

                secondaryAlternateCode = Request.Form[secondaryalternateDropDownList.UniqueID];
                string saltcc1;
                saltcc1 = Queries2.getcountrycodefromstring(secondaryAlternateCode);
                if (saltcc1 == "" || saltcc1 == null)
                {
                    saltcc1 = "";
                }
                else
                {
                    saltcc1 = Queries2.getcountrycodefromstring(secondaryAlternateCode);
                }
                secondaryAlternateCode = saltcc1;
                secondaryAlternateNumber = salternateTextBox.Text;

                secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID];
                if (secondaryHomeCode == "" || secondaryHomeCode == null)
                {
                    secondaryHomeCode = "";
                }
                else { secondaryHomeCode = Request.Form[shomecodeDropDownList.UniqueID]; }
                secondaryHomeNumber = shomenoTextBox.Text;

                secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID];
                if (secondaryOfficeCode == "" || secondaryOfficeCode == null)
                {
                    secondaryOfficeCode = "";
                }
                else { secondaryOfficeCode = Request.Form[sofficecodeDropDownList.UniqueID]; }
                secondaryOfficeNumber = sofficenoTextBox.Text;


            }

            string secondaryEmail1 = semailTextBox.Text;
            string secondaryEmail2 = semailTextBox2.Text;


            string secondaryLanguage;
            if (Request.Form["seclang"] == null)
            {
                secondaryLanguage = "";
            }

            else
            {
                secondaryLanguage = Request.Form["seclang"];

            }

            string secondaryIDCardType = TextBoxSecoIDType.Text;
            string secondaryIDCardNumber = TextBoxSecoID.Text;

            //--------------------------------------------//

            // Address Details//
            string addressLine1 = address1TextBox.Text;
            string addressLine2 = address2TextBox.Text;
            string primaryDesignation = maledesgTextBox.Text;
            string secondaryDesignation = femaledesgTextBox.Text;
            string photoIdentity;
            if (Request.Form["pidentity"] == null)
            {
                photoIdentity = "";
            }
            else
            {
                photoIdentity = Request.Form["pidentity"];
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

            string addressCountry = Request.Form[AddCountryDropDownList.UniqueID];
            string addressState;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                addressState = Request.Form[StateDropDownList.UniqueID];
                if (addressState == "" || addressState == null) { addressState = ""; } else { addressState = Request.Form[StateDropDownList.UniqueID]; }
            }
            else
            {
                addressState = stateTextBox.Text;
            }

            string addressCity = cityTextBox.Text;
            string addressPincode = pincodeTextBox.Text;
            string martialStatus = MaritalStatusDropDownList.SelectedItem.Text;
            string livingYears = livingyrsTextBox.Text;

            //--------------------------------------------//

            // Sub Profile 1 Profile Details //
            string subProfileTitle = Request.Form[subprofile1titleDropDownList.UniqueID];
            string subProfileFirstName = sp1fnameTextBox.Text;
            string subProfileLastName = sp1lnameTextBox.Text;
            string subProfileDateOfBirth = sp1dobdatepicker.Text;
            string subProfileAge = TextSP1Age.Text;

            string subProfileNationality = Request.Form[subprofile1nationalityDropDownList.UniqueID];
            string subProfileCountry = Request.Form[SubProfile1CountryDropDownList.UniqueID];
            if (subProfileCountry == "" || subProfileCountry == null)
            { subProfileCountry = ""; }
            else { subProfileCountry = Request.Form[SubProfile1CountryDropDownList.UniqueID]; }

            //string subProfileMobileCode = Request.Form[subprofile1mobileDropDownList.UniqueID];
            //string subProfileMobileNumber = sp1mobileTextBox.Text;

            //string subProfileAlternateCode = Request.Form[subprofile1alternateDropDownList.UniqueID];
            //string subProfileAlternateNumber = sp1alternateTextBox.Text;



            string subProfileMobileCode = ""; string subProfileMobileNumber = ""; string subProfileAlternateCode = ""; string subProfileAlternateNumber = "";

            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfileMobileCode = Request.Form[subprofile1mobileDropDownList.UniqueID];
                subProfileMobileNumber = sp1mobileTextBox.Text;

                subProfileAlternateCode = Request.Form[subprofile1alternateDropDownList.UniqueID];
                subProfileAlternateNumber = sp1alternateTextBox.Text;
            }
            else
            {
                subProfileMobileCode = Request.Form[subprofile1mobileDropDownList.UniqueID];
                string sp1cc1;
                sp1cc1 = Queries2.getcountrycodefromstring(subProfileMobileCode);
                if (sp1cc1 == "" || sp1cc1 == null)
                {
                    sp1cc1 = "";
                }
                else
                {
                    sp1cc1 = Queries2.getcountrycodefromstring(subProfileMobileCode);
                }
                subProfileMobileCode = sp1cc1;
                subProfileMobileNumber = sp1mobileTextBox.Text;

                subProfileAlternateCode = Request.Form[subprofile1alternateDropDownList.UniqueID];
                string sp1altcc1;
                sp1altcc1 = Queries2.getcountrycodefromstring(subProfileAlternateCode);
                if (sp1altcc1 == "" || sp1altcc1 == null)
                {
                    sp1altcc1 = "";
                }
                else
                {
                    sp1altcc1 = Queries2.getcountrycodefromstring(subProfileAlternateCode);
                }
                subProfileAlternateCode = sp1altcc1;
                subProfileAlternateNumber = sp1alternateTextBox.Text;

            }

            string subProfileEmail1 = sp1emailTextBox.Text;
            string subProfileEmail2 = sp1emailTextBox2.Text;

            string subProfileIDCardType = TextBoxSP1IDType.Text;
            string subProfileIDCardNumber = TextBoxSP1ID.Text;

            //--------------------------------------------//


            // Sub Profile 2 Profile Details //

            string subProfile2Title = Request.Form[subprofile2titleDropDownList.UniqueID];
            string subProfile2FirstName = sp2fnameTextBox.Text;
            string subProfile2LastName = sp2lnameTextBox.Text;
            string subProfile2DateOfBirth = sp2dobdatepicker.Text;
            string subProfile2Age = TextSP2Age.Text;

            string subProfile2Nationality = Request.Form[subprofile2nationalityDropDownList.UniqueID];
            string subProfile2Country = Request.Form[SubProfile2CountryDropDownList.UniqueID];
            if (subProfile2Country == "" || subProfile2Country == null)
            { subProfile2Country = ""; }
            else { subProfile2Country = Request.Form[SubProfile2CountryDropDownList.UniqueID]; }

            //string subProfile2MobileCode = Request.Form[subprofile2mobileDropDownList.UniqueID];
            //string subProfile2MobileNumber = sp2mobileTextBox.Text;

            //string subProfile2AlternateCode = Request.Form[subprofile2alternateDropDownList.UniqueID];
            //string subProfile2AlternateNumber = sp2alternateTextBox.Text;

            string subProfile2MobileCode = ""; string subProfile2MobileNumber = ""; string subProfile2AlternateCode = ""; string subProfile2AlternateNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfile2MobileCode = Request.Form[subprofile2mobileDropDownList.UniqueID];
                subProfile2MobileNumber = sp2mobileTextBox.Text;

                subProfile2AlternateCode = Request.Form[subprofile2alternateDropDownList.UniqueID];
                subProfile2AlternateNumber = sp2alternateTextBox.Text;
            }
            else
            {
                subProfile2MobileCode = Request.Form[subprofile2mobileDropDownList.UniqueID];
                string sp2cc1;
                sp2cc1 = Queries2.getcountrycodefromstring(subProfile2MobileCode);
                if (sp2cc1 == "" || sp2cc1 == null)
                {
                    sp2cc1 = "";
                }
                else
                {
                    sp2cc1 = Queries2.getcountrycodefromstring(subProfile2MobileCode);
                }
                subProfile2MobileCode = sp2cc1;
                subProfile2MobileNumber = sp2mobileTextBox.Text;

                subProfile2AlternateCode = Request.Form[subprofile2alternateDropDownList.UniqueID];
                string sp2altccc1;
                sp2altccc1 = Queries2.getcountrycodefromstring(subProfile2AlternateCode);
                if (sp2altccc1 == "" || sp2altccc1 == null)
                {
                    sp2altccc1 = "";
                }
                else
                {
                    sp2altccc1 = Queries2.getcountrycodefromstring(subProfile2AlternateCode);
                }
                subProfile2AlternateCode = sp2altccc1;
                subProfile2AlternateNumber = sp2alternateTextBox.Text;

            }

            string subProfile2Email1 = sp2emailTextBox.Text;
            string subProfile2Email2 = sp2emailTextBox2.Text;

            string subProfile2IDCardType = TextBoxSP2IDType.Text;
            string subProfile2IDCardNumber = TextBoxSP2ID.Text;

            //--------------------------------------------//

            // Sub Profile 3 Profile Details //

            string subProfile3Title = Request.Form[SubP3TitleDropDownList.UniqueID];
            string subProfile3FirstName = SubP3FnameTextBox.Text;
            string subProfile3LastName = SubP3LnameTextBox.Text;
            string subProfile3DateOfBirth = SubP3DOB.Text;
            string subProfile3Age = TextSP3Age.Text;

            string subProfile3Nationality = Request.Form[SubP3NationalityDropDownList.UniqueID];
            string subProfile3Country = Request.Form[SubP3CountryDropDownList.UniqueID];
            if (subProfile3Country == "" || subProfile3Country == null)
            { subProfile3Country = ""; }
            else { subProfile3Country = Request.Form[SubP3CountryDropDownList.UniqueID]; }

            //string subProfile3MobileCode = Request.Form[SubP3CCDropDownList.UniqueID];
            //string subProfile3MobileNumber = SubP3MobileTextBox.Text;

            //string subProfile3AlternateCode = Request.Form[SubP3CCDropDownList2.UniqueID];
            //string subProfile3AlternateNumber = SubP3AMobileTextBox.Text;

            string subProfile3MobileCode = ""; string subProfile3MobileNumber = ""; string subProfile3AlternateCode = "";
            string subProfile3AlternateNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfile3MobileCode = Request.Form[SubP3CCDropDownList.UniqueID];
                subProfile3MobileNumber = SubP3MobileTextBox.Text;

                subProfile3AlternateCode = Request.Form[SubP3CCDropDownList2.UniqueID];
                subProfile3AlternateNumber = SubP3AMobileTextBox.Text;

            }
            else
            {
                subProfile3MobileCode = Request.Form[SubP3CCDropDownList.UniqueID];
                string sp3cc1;
                sp3cc1 = Queries2.getcountrycodefromstring(subProfile3MobileCode);
                if (sp3cc1 == "" || sp3cc1 == null)
                {
                    sp3cc1 = "";
                }
                else
                {
                    sp3cc1 = Queries2.getcountrycodefromstring(subProfile3MobileCode);
                }
                subProfile3MobileCode = sp3cc1;
                subProfile3MobileNumber = SubP3MobileTextBox.Text;


                subProfile3AlternateCode = Request.Form[SubP3CCDropDownList2.UniqueID];
                string sp3altcc1;
                sp3altcc1 = Queries2.getcountrycodefromstring(subProfile3AlternateCode);
                if (sp3altcc1 == "" || sp3altcc1 == null)
                {
                    sp3altcc1 = "";
                }
                else
                {
                    sp3altcc1 = Queries2.getcountrycodefromstring(subProfile3AlternateCode);
                }
                subProfile3AlternateCode = sp3altcc1;
                subProfile3AlternateNumber = SubP3AMobileTextBox.Text;

            }


            string subProfile3Email1 = SubP3EmailTextBox.Text;
            string subProfile3Email2 = SubP3EmailTextBox2.Text;

            string subProfile3IDCardType = TextBoxSP3IDType.Text;
            string subProfile3IDCardNumber = TextBoxSP3ID.Text;

            //--------------------------------------------//

            // Sub Profile 4 Profile Details //

            string subProfile4Title = Request.Form[SubP4TitleDropDownList.UniqueID];
            string subProfile4FirstName = SubP4FnameTextBox.Text;
            string subProfile4LastName = SubP4LnameTextBox.Text;
            string subProfile4DateOfBirth = SubP4DOB.Text;
            string subProfile4Age = TextSP4Age.Text;

            string subProfile4Nationality = Request.Form[SubP4NationalityDropDownList.UniqueID];
            string subProfile4Country = Request.Form[SubP4CountryDropDownList.UniqueID];
            if (subProfile4Country == "" || subProfile4Country == null)
            { subProfile4Country = ""; }
            else { subProfile4Country = Request.Form[SubP4CountryDropDownList.UniqueID]; }

            //string subProfile4MobileCode = Request.Form[SubP4CCDropDownList.UniqueID];
            //string subProfile4MobileNumber = SubP4MobileTextBox.Text;

            //string subProfile4AlternateCode = Request.Form[SubP4CCDropDownList2.UniqueID];
            //string subProfile4AlternateNumber = SubP4AMobileTextBox.Text;

            string subProfile4MobileCode = ""; string subProfile4MobileNumber = ""; string subProfile4AlternateCode = "";
            string subProfile4AlternateNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                subProfile4MobileCode = Request.Form[SubP4CCDropDownList.UniqueID];
                subProfile4MobileNumber = SubP4MobileTextBox.Text;

                subProfile4AlternateCode = Request.Form[SubP4CCDropDownList2.UniqueID];
                subProfile4AlternateNumber = SubP4AMobileTextBox.Text;
            }
            else
            {
                subProfile4MobileCode = Request.Form[SubP4CCDropDownList.UniqueID];
                string sp4cc1;
                sp4cc1 = Queries2.getcountrycodefromstring(subProfile4MobileCode);
                if (sp4cc1 == "" || sp4cc1 == null)
                {
                    sp4cc1 = "";
                }
                else
                {
                    sp4cc1 = Queries2.getcountrycodefromstring(subProfile4MobileCode);
                }
                subProfile4MobileCode = sp4cc1;
                subProfile4MobileNumber = SubP4MobileTextBox.Text;

                subProfile4AlternateCode = Request.Form[SubP4CCDropDownList2.UniqueID];
                string sp4altcc1;
                sp4altcc1 = Queries2.getcountrycodefromstring(subProfile4AlternateCode);
                if (sp4altcc1 == "" || sp4altcc1 == null)
                {
                    sp4altcc1 = "";
                }
                else
                {
                    sp4altcc1 = Queries2.getcountrycodefromstring(subProfile4AlternateCode);
                }
                subProfile4AlternateCode = sp4altcc1;
                subProfile4AlternateNumber = SubP4AMobileTextBox.Text;

            }

            string subProfile4Email1 = SubP4EmailTextBox.Text;
            string subProfile4Email2 = SubP4EmailTextBox2.Text;

            string subProfile4IDCardType = TextBoxSP4IDType.Text;
            string subProfile4IDCardNumber = TextBoxSP4ID.Text;

            //--------------------------------------------//


            // Profile Stay Details //

            string arrivalDate;
            string resortName = hotelTextBox.Text;
            string resortRoomNumber = roomnoTextBox.Text;

            string arrivalDate1 = checkindatedatepicker.Text;
            if (arrivalDate1 == "" || arrivalDate1 == null)
            {
                arrivalDate = "";
            }
            else
            {
                DateTime dtt = DateTime.ParseExact(arrivalDate1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                arrivalDate = dtt.ToString("yyyy-MM-dd");
            }

            string departureDate;
            string departureDate1 = checkoutdatedatepicker.Text;
            if (departureDate1 == "" || departureDate1 == null)
            {
                departureDate = "";
            }
            else
            {
                DateTime dtt1 = DateTime.ParseExact(departureDate1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                departureDate = dtt1.ToString("yyyy-MM-dd");
            }



            //---------------------------------//

            // Profile Tour Details //

            string questStatus = gueststatusDropDownList.SelectedItem.Text;
            string qStatus = QStatusDropDownList1.SelectedItem.Text;
            string checkInTime = deckcheckintimeTextBox.Text;
            string checkOutTime = deckcheckouttimeTextBox.Text;
            string salesRepresentative = Request.Form[salesrepDropDownList.UniqueID];
            if (salesRepresentative == "" || salesRepresentative == null) { salesRepresentative = ""; } else { salesRepresentative = Request.Form[salesrepDropDownList.UniqueID]; }

            string tourDate;
            int weekNo;
            if (tourdatedatepicker.Text == "" || tourdatedatepicker.Text == null || tourdatedatepicker.Text == "NaN")
            {
                tourDate = "";
                weekNo = 0;
            }
            else
            {
                DateTime dtt4 = DateTime.ParseExact(tourdatedatepicker.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                tourDate = dtt4.ToString("yyyy-MM-dd");

                weekNo = Queries.GetWkNumber(Convert.ToDateTime(tourDate));

            }



            string taxiInPrice = taxipriceInTextBox.Text;
            if (taxiInPrice == "" || taxiInPrice == null)
            {
                taxiInPrice = "0";
            }
            else
            {
                taxiInPrice = taxipriceInTextBox.Text;
            }
            string taxiInRef = TaxiRefInTextBox.Text;

            string taxiOutPrice = TaxiPriceOutTextBox.Text;
            if (taxiOutPrice == "" || taxiOutPrice == null)
            {
                taxiOutPrice = "0";
            }
            else
            {
                taxiOutPrice = TaxiPriceOutTextBox.Text;
            }
            string taxiOutRef = TaxiRefOutTextBox.Text;

            //---------------------------------//



            string regTerm1;
            if (Regterms1.Checked)
            {

                regTerm1 = "Y";
            }
            else
            {
                regTerm1 = "N";

            }

            string regTerm2;
            if (Regterms2.Checked)
            {

                regTerm2 = "Y";
            }
            else
            {
                regTerm2 = "N";

            }


            if (venuecountry == "")
            { }
            else
            {
                // Insertion of Profile //
                int profile = Queries.InsertProfile(Session["ProfileID"].ToString(), DateTime.Now, profileCreatedBy, venuecountry, venue, venueGroup, marketingProgram, agent_marketingSource, toName_sourceCode, membertype1, memno1, "", "", primaryEmploymentStatus, martialStatus, livingYears, office, commentTextBox.Text.ToUpper(), toManager, photoIdentity, card, reception, subVenue, regTerm1, viewPointID, "", regTerm2, secondaryEmploymentStatus, guestRelations, preArrival, comment2.Text.ToUpper(), verification, promoSource, teleMarketingAgent, subVenueGroup, leadOffices);
                string log1 = "Profile Details:" + " " + "Profile ID:" + Session["ProfileID"].ToString() + "," + "Created date:" + TextBox1.Text + "," + CreatedByTextBox.Text + "," + "venue country:" + venuecountry + "," + "venue: " + venue + "," + "Venue Group: " + venueGroup + "," + "Marketing Program :" + marketingProgram + "," + "Agent_MarketingSource :" + agent_marketingSource + "," + "TOName_SourceCode:" + toName_sourceCode + "," + "Primary_Employment_status :" + primaryEmploymentStatus + "," + "Martial_Status :" + martialStatus + "," + "Living Years :" + livingYears + "," + "Office :" + office + "," + "comments :" + commentTextBox.Text.ToUpper() + "," + "Manager:" + toManager + "," + "membertype1:" + "" + "," + "memno1:" + "" + "," + "membertype2:" + "" + "," + "memno2:" + "" + "," + "Photo Identity:" + photoIdentity + "," + "Card Holder:" + card + "," + "Registration Terms:" + regTerm1 + "," + "View Point ID:" + viewPointID + "," + "Registration Terms 2:" + regTerm2 + "," + "Secondary_Employemnt_status:" + secondaryEmploymentStatus + "," + "Guest Relations :" + guestRelations + "," + "Pre Arrival:" + preArrival + "," + "comment2:" + comment2.Text.ToUpper() + "," + "verification:" + verification + "," + "Promo Source:" + promoSource + "," + "Tele Marketing Agent:" + teleMarketingAgent + "," + " Sub Venue Group :" + subVenueGroup + "," + " lead office: " + leadOffices;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log1, profileCreatedBy, DateTime.Now.ToString());
                int update = Queries.UpdateProfileValue(office, year);
                // ------------------- //

                // Insertion of Primary Profile //
                string primaryProfileID = Queries.GetPrimaryProfileID(office);
                int primary = Queries.InsertPrimaryProfile(primaryProfileID, primaryTitle, primaryFirstName.ToUpper(), primaryLastName.ToUpper(), primaryDateOfBirth, primaryNationality, primaryCountry, Session["ProfileID"].ToString(), primaryAge, primaryDesignation.ToUpper(), primaryLanguage);
                int updatep = Queries.UpdatePrimaryValue(office, year);

                string log2 = "Primary details:" + " " + "primary ID:" + primaryProfileID + "," + "title:" + primaryTitle + "," + "Fname:" + primaryFirstName.ToUpper() + "," + "Lname:" + primaryLastName.ToUpper() + "," + "DOB:" + primaryDateOfBirth + "," + "nationality:" + primaryNationality + "," + "Country:" + primaryCountry + "," + "Profile ID:" + Session["ProfileID"].ToString() + "Age:" + primaryAge + "," + "Designation:" + primaryDesignation.ToUpper() + "," + "Languages spoken:" + primaryLanguage;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log2, profileCreatedBy, DateTime.Now.ToString());
                // ------------------- //

                // Insertion of Secondary Profile //
                if (secondaryTitle == "")
                {

                }
                else
                {
                    string secondaryProfileID = Queries.GetSecondaryProfileID(office);
                    int secondary = Queries.InsertSecondaryProfile(secondaryProfileID, secondaryTitle, secondaryFirstName.ToUpper(), secondaryLastName.ToUpper(), secondaryDateOfBirth, secondaryNationality, secondaryCountry, Session["ProfileID"].ToString(), secondaryAge, secondaryDesignation.ToUpper(), secondaryLanguage);
                    int updates = Queries.UpdateSecondaryValue(office, year);

                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryProfileID + "," + "title:" + secondaryTitle + "," + "Fname:" + secondaryFirstName.ToUpper() + "," + "Lname:" + secondaryLastName.ToUpper() + "," + "DOB:" + secondaryDateOfBirth + "," + "nationality:" + secondaryNationality + "," + "Country:" + secondaryCountry + "," + "Profiel ID:" + Session["ProfileID"].ToString() + "Age:" + secondaryAge + "," + "Designation:" + secondaryDesignation.ToUpper() + "," + "Languages spoken:" + secondaryLanguage;
                    int insertlog3 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log3, profileCreatedBy, DateTime.Now.ToString());
                }
                // ------------------- //

                // Insertion of Profile Address //
                string addressID = Queries.GetAddressProfileID(office);
                int address = Queries.InsertProfileAddress(addressID, addressLine1.ToUpper(), addressLine2.ToUpper(), addressState.ToUpper(), addressCity.ToUpper(), addressPincode.ToUpper(), DateTime.Now, "", Session["ProfileID"].ToString(), addressCountry);
                int updateadd = Queries.UpdateAddressValue(office, year);

                string log4 = "Address details:" + " " + "address  id:" + addressID + "," + "address1:" + addressLine1.ToUpper() + "," + "address2:" + addressLine2.ToUpper() + "," + "state:" + addressState.ToUpper() + "," + "city:" + addressCity.ToUpper() + "," + "pincode:" + addressPincode.ToUpper() + "," + "Country: " + addressCountry + "," + "Created Date:" + DateTime.Now + "," + "Profile ID:" + Session["ProfileID"].ToString();
                int insertlog4 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log4, profileCreatedBy, DateTime.Now.ToString());
                // ------------------- //


                // Insertion of Sub Profile 1 //
                if (subProfileTitle == "")
                { }
                else
                {

                    string subProfileID = Queries.GetSubProfile1ID(office);
                    int subprofielid = Queries.InsertSub_Profile1(subProfileID, subProfileTitle, subProfileFirstName.ToUpper(), subProfileLastName.ToUpper(), subProfileDateOfBirth, subProfileNationality, subProfileCountry, Session["ProfileID"].ToString(), subProfileAge);
                    int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


                    string log5 = "sub profile 1 details:" + " " + "sp1 id:" + subProfileID + "," + "title:" + subProfileTitle + "," + "Fname:" + subProfileFirstName.ToUpper() + "," + "Lname:" + subProfileLastName.ToUpper() + "," + "DOB:" + subProfileDateOfBirth + "," + "nationality:" + subProfileNationality + "," + "Country:" + subProfileCountry + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub1 age: " + subProfileAge;
                    int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log5, profileCreatedBy, DateTime.Now.ToString());
                }
                // ------------------- //

                // Insertion of Sub Profile 2 //
                if (subProfile2Title == "")
                {

                }
                else
                {
                    string subProfile2ID = Queries.GetSubProfile2ID(office);
                    int subprofielid2 = Queries.InsertSub_Profile2(subProfile2ID, subProfile2Title, subProfile2FirstName.ToUpper(), subProfile2LastName.ToUpper(), subProfile2DateOfBirth, subProfile2Nationality, subProfile2Country, Session["ProfileID"].ToString(), subProfile2Age);
                    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

                    string log6 = "sub profile 2 details:" + " " + "sp2 id:" + subProfile2ID + "," + "title:" + subProfile2Title + "," + "Fname:" + subProfile2FirstName.ToUpper() + "," + "Lname:" + subProfile2LastName.ToUpper() + "," + "DOB:" + subProfile2DateOfBirth + "," + "nationality:" + subProfile2Nationality + "," + "Country:" + subProfile2Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub2 age: " + subProfile2Age;
                    int insertlog6 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log6, profileCreatedBy, DateTime.Now.ToString());

                }

                // ------------------- //

                // Insertion of Sub Profile 3 //
                if (subProfile3Title == "")
                {

                }
                else
                {
                    string subProfile3ID = Queries.GetSubProfile3ID(office);
                    int subprofielid3 = Queries.InsertSub_Profile3(subProfile3ID, subProfile3Title, subProfile3FirstName.ToUpper(), subProfile3LastName.ToUpper(), subProfile3DateOfBirth, subProfile3Nationality, subProfile3Country, Session["ProfileID"].ToString(), subProfile3Age);
                    int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

                    string log12 = "sub profile 3 details:" + " " + "sp3 id:" + subProfile3ID + "," + "title:" + subProfile3Title + "," + "Fname:" + subProfile3FirstName.ToUpper() + "," + "Lname:" + subProfile3LastName.ToUpper() + "," + "DOB:" + subProfile3DateOfBirth + "," + "nationality:" + subProfile3Nationality + "," + "Country:" + subProfile3Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub3 age: " + subProfile3Age;
                    int insertlog12 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log12, profileCreatedBy, DateTime.Now.ToString());

                }

                // ------------------- //

                // Insertion of Sub Profile 4 //

                if (subProfile4Title == "")
                { }
                else
                {
                    string subProfile4ID = Queries.GetSubProfile4ID(office);
                    int subprofielid4 = Queries.InsertSub_Profile4(subProfile4ID, subProfile4Title, subProfile4FirstName.ToUpper(), subProfile4LastName.ToUpper(), subProfile4DateOfBirth, subProfile4Nationality, subProfile4Country, Session["ProfileID"].ToString(), subProfile4Age);
                    int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


                    string log13 = "sub profile4 details:" + " " + "sp4 id:" + subProfile4ID + "," + "title:" + subProfile4Title + "," + "Fname:" + subProfile4FirstName.ToUpper() + "," + "Lname:" + subProfile4LastName.ToUpper() + "," + "DOB:" + subProfile4DateOfBirth + "," + "nationality:" + subProfile4Nationality + "," + "Country:" + subProfile4Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + " sub4 age: " + subProfile4Age;
                    int insertlog13 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log13, profileCreatedBy, DateTime.Now.ToString());
                }

                // ------------------- //

                // Insertion of Profile Phone Details //
                string phoneID = Queries.GetPhoneID(office);
                int phone = Queries.InsertPhone(phoneID, Session["ProfileID"].ToString(), primaryMobileCode, primaryMobileNumber, primaryAlternateCode, PrimaryAlternateNumber, secondaryMobileCode, secondaryMobileNumber, secondaryAlternateCode, secondaryAlternateNumber, subProfileMobileCode, subProfileMobileNumber, subProfileAlternateCode, subProfileAlternateNumber, subProfile2MobileCode, subProfile2MobileNumber, subProfile2AlternateCode, subProfile2AlternateNumber, subProfile3MobileCode, subProfile3MobileNumber, subProfile4MobileCode, subProfile4MobileNumber, subProfile3AlternateCode, subProfile3AlternateNumber, subProfile4AlternateCode, subProfile4AlternateNumber, primaryOfficeCode, primaryOfficeNumber, secondaryOfficeCode, secondaryOfficeNumber, primaryHomeCode, primaryHomeNumber, secondaryHomeCode, secondaryHomeNumber);
                int updatephone = Queries.UpdatePhoneValue(office, year);

                string log7 = "Phone Details:" + " " + "Phone id:" + phoneID + "," + "Profile id:" + Session["ProfileID"].ToString() + "," + "Primary mobile:" + primaryMobileCode + "" + primaryMobileNumber + "," + "primary alternate:" + primaryAlternateCode + "" + PrimaryAlternateNumber + "," + "Secondary mobile:" + secondaryMobileCode + "" + secondaryMobileNumber + "," + "Secondary alternate:" + secondaryAlternateCode + "" + secondaryAlternateNumber + "," + "Subprofile1 mobile:" + subProfileMobileCode + " " + subProfileMobileNumber + "," + "Subprofile1 alternate:" + subProfileAlternateCode + "" + subProfileAlternateNumber + "," + "Subprofile2 mobile:" + subProfile2MobileCode + "" + subProfile2MobileNumber + "," + "subprofile2 alternate:" + subProfile2AlternateCode + "" + subProfile2AlternateNumber + "," + "Subprofile3 mobile:" + subProfile3MobileCode + "" + subProfile3MobileNumber + "," + "subprofile3 alternate:" + subProfile3AlternateCode + "" + subProfile3AlternateNumber + "," + "Subprofile4 mobile:" + subProfile4MobileCode + "" + subProfile4MobileNumber + "," + "subprofile4 alternate:" + subProfile4AlternateCode + "" + subProfile4AlternateNumber + "," + "Primary office code:" + primaryOfficeCode + "," + "Primary Office No:" + primaryOfficeNumber + "," + "Sec office code:" + secondaryOfficeCode + "," + "Sec office num:" + secondaryOfficeNumber;
                int insertlog7 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log7, profileCreatedBy, DateTime.Now.ToString());

                // ------------------- //

                // Insertion of Profile Email Details //
                string emailID = Queries.GetEmailID(office);
                int email = Queries.InsertEmail(emailID, Session["ProfileID"].ToString(), primaryEmail1, secondaryEmail1, subProfileEmail1, subProfile2Email1, primaryEmail2, secondaryEmail2, subProfileEmail2, subProfile2Email2, subProfile3Email1, subProfile3Email2, subProfile4Email1, subProfile4Email2);
                int updateemail = Queries.UpdateEmailValue(office, year);
                string log8 = "Email Details:" + " " + "Email id:" + emailID + "," + "profile id:" + Session["ProfileID"].ToString() + "," + "Primary email:" + primaryEmail1 + "," + "Primary email 2:" + primaryEmail2 + "," + "Secondary email:" + secondaryEmail1 + "," + "Secondary email 2:" + secondaryEmail2 + "," + "Subprofile1 email:" + subProfileEmail1 + "," + "Subprofile1 email 2 :" + subProfileEmail2 + "," + "subprofile2 email:" + subProfile2Email1 + "," + "subprofile2 email 2:" + subProfile2Email2 + "," + "subprofile3 email:" + subProfile3Email1 + "," + "subprofile3 email 2 :" + subProfile3Email2 + "," + "subprofile4 email:" + subProfile4Email1 + "," + "subprofile4 email 2:" + subProfile4Email2;
                int insertlog8 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log8, profileCreatedBy, DateTime.Now.ToString());

                // ------------------- //


                // Insertion of Profile Stay Details //
                string stayID = Queries.GetStayDetailsID(office);
                int staydetails = Queries.InsertProfileStay(stayID, resortName.ToUpper(), resortRoomNumber, arrivalDate, departureDate, Session["ProfileID"].ToString());
                string log9 = "Stay details:" + " " + "Stay ID:" + stayID + "," + "Resort:" + resortName.ToUpper() + "," + "room#:" + resortRoomNumber + "," + "Arrival date:" + arrivalDate + "," + "Departure date:" + departureDate + "," + "Profile id:" + Session["ProfileID"].ToString();
                int updatestay = Queries.UpdateStayValue(office, year);

                int insertlog9 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log9, profileCreatedBy, DateTime.Now.ToString());

                // ------------------- //

                // Insertion of Profile Tour Details //
                string tourID = Queries.GetTourDetailsID(office);
                int tourdetails = Queries.InsertTourDetails(tourID, questStatus, salesRepresentative, tourDate, checkInTime, checkOutTime, taxiInPrice, taxiInRef.ToUpper(), taxiOutPrice, taxiOutRef.ToUpper(), Session["ProfileID"].ToString(), qStatus, weekNo);
                int updatetour = Queries.UpdateTourValue(office, year);
                string log10 = "Tour Details:" + "Tour ID:" + tourID + "," + "Guest status:" + questStatus + "," + "," + "Guest Q status: " + qStatus + "," + " Sales rep:" + salesRepresentative + "," + "tour date:" + tourDate + "," + "Time in:" + checkInTime + "," + "Time out:" + checkOutTime + "," + "Taxi In:" + taxiInPrice + "," + "Taxi Ref In:" + taxiInRef.ToUpper() + "," + "taxi out:" + taxiOutPrice + "," + "taxi Ref out:" + taxiOutRef.ToUpper() + "," + "Profile id:" + Session["ProfileID"].ToString();
                int insertlog10 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log10, profileCreatedBy, DateTime.Now.ToString());
                // ---------------------------------- //

                // Insertion of Profile ID Number Details //
                if (venuecountry == "India" || venuecountry == "INDIA")
                { }
                else
                {
                    int insert_id_numb = Queries2.InsertID_Numb(Session["ProfileID"].ToString(), primaryIDCardType.ToUpper(), primaryIDCardNumber, secondaryIDCardType.ToUpper(), secondaryIDCardNumber, subProfileIDCardType.ToUpper(), subProfileIDCardNumber, subProfile2IDCardType.ToUpper(), subProfile2IDCardNumber, subProfile3IDCardType.ToUpper(), subProfile3IDCardNumber, subProfile4IDCardType.ToUpper(), subProfile4IDCardNumber, DateTime.Now.ToString());

                }

                // ---------------------------------- //


                //   Insertion of Profile Gift Details  //
                if (Request.Form[giftoptionDropDownList.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg1 = TextBoxGPrice1.Text;
                    if (tg1 == "")
                    {
                        tg1 = "0";

                    }
                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList.UniqueID], vouchernoTextBox.Text, TextBoxChargeBack.Text.ToUpper(), Session["ProfileID"].ToString(), "", tg1);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList2.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg2 = TextBoxGPrice2.Text;
                    if (tg2 == "")
                    {
                        tg2 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList2.UniqueID], vouchernoTextBox2.Text, "", Session["ProfileID"].ToString(), "", tg2);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList3.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg3 = TextBoxGPrice3.Text;
                    if (tg3 == "")
                    {
                        tg3 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList3.UniqueID], vouchernoTextBox3.Text, "", Session["ProfileID"].ToString(), "", tg3);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList4.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg4 = TextBoxGPrice4.Text;
                    if (tg4 == "")
                    {
                        tg4 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList4.UniqueID], vouchernoTextBox4.Text, "", Session["ProfileID"].ToString(), "", tg4);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (Request.Form[giftoptionDropDownList5.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg5 = TextBoxGPrice5.Text;
                    if (tg5 == "")
                    {
                        tg5 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList5.SelectedItem.Text, vouchernoTextBox5.Text, "", Session["ProfileID"].ToString(), "", tg5);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (Request.Form[giftoptionDropDownList6.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg6 = TextBoxGPrice6.Text;
                    if (tg6 == "")
                    {
                        tg6 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList6.UniqueID], vouchernoTextBox6.Text, "", Session["ProfileID"].ToString(), "", tg6);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (Request.Form[giftoptionDropDownList7.UniqueID] != "")
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg7 = TextBoxGPrice7.Text;
                    if (tg7 == "")
                    {
                        tg7 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, Request.Form[giftoptionDropDownList7.UniqueID], vouchernoTextBox7.Text, "", Session["ProfileID"].ToString(), "", tg7);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                // ------------------------------------------------------------------------- //


            }
            string msg = "Profile Created with ID = " + Session["ProfileID"].ToString();
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('" + msg + "')", true);

        }
        catch (Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();

            string msg = "Error while creating profile " + ex.Message + "  " + line;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

            int delete = Queries2.Deleteprofileonerror(Session["ProfileID"].ToString());

            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }



    }


    protected void VenueCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecountry =Queries.GetVenueCountryCode( VenueCountryDropDownList.SelectedItem.Text);
        //ProfileIDTextBox.ReadOnly = true;
        //ProfileIDTextBox.Text = Queries.GetProfileID(VenueCountryDropDownList.SelectedItem.Text);

        DataSet ds1 = Queries.LoadVenuebasedOnCountryID(venuecountry);
        VenueDropDownList.DataSource = ds1;
        VenueDropDownList.DataTextField = "Venue_Name";
        VenueDropDownList.DataValueField = "Venue_Name";
        VenueDropDownList.AppendDataBoundItems = true;
        VenueDropDownList.Items.Insert(0, new ListItem("", ""));
        VenueDropDownList.DataBind();

        

    }
    protected void VenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        //get code
        string venuecode= Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));

        
        DataSet ds1 = Queries.LoadVenueGroup(venuecode);
        GroupVenueDropDownList.DataSource = ds1;
        GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        GroupVenueDropDownList.AppendDataBoundItems = true;
        GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        GroupVenueDropDownList.DataBind();
    }

    protected void GroupVenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        //get code
        string venuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);


        DataSet ds1 = Queries.LoadMarketingProgram(venuecode);
        MarketingPrgmDropDownList.DataSource = ds1;
        MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.AppendDataBoundItems = true;
        MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        MarketingPrgmDropDownList.DataBind();
        
    }
  
    //protected void PrimaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    primarymobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(PrimaryCountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    primarymobileDropDownList.DataSource = ds12;
    //    primarymobileDropDownList.DataTextField = "name";
    //    primarymobileDropDownList.DataValueField = "name";
    //    primarymobileDropDownList.AppendDataBoundItems = true;
    //    primarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    primarymobileDropDownList.DataBind();

    //}

    //protected void SecondaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    secondarymobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(SecondaryCountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    secondarymobileDropDownList.DataSource = ds12;
    //    secondarymobileDropDownList.DataTextField = "name";
    //    secondarymobileDropDownList.DataValueField = "name";
    //    secondarymobileDropDownList.AppendDataBoundItems = true;
    //    secondarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    secondarymobileDropDownList.DataBind();
    //}

    //protected void SubProfile1CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    subprofile1mobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(SubProfile1CountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    subprofile1mobileDropDownList.DataSource = ds12;
    //    subprofile1mobileDropDownList.DataTextField = "name";
    //    subprofile1mobileDropDownList.DataValueField = "name";
    //    subprofile1mobileDropDownList.AppendDataBoundItems = true;
    //    subprofile1mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    subprofile1mobileDropDownList.DataBind();
    //}
    //protected void SubProfile2CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    subprofile2mobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(SubProfile2CountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    subprofile2mobileDropDownList.DataSource = ds12;
    //    subprofile2mobileDropDownList.DataTextField = "name";
    //    subprofile2mobileDropDownList.DataValueField = "name";
    //    subprofile2mobileDropDownList.AppendDataBoundItems = true;
    //    subprofile2mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    subprofile2mobileDropDownList.DataBind();
    //}

    protected void MarketingPrgmDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
         
        //DataSet ds4 = Queries.LoadAgentsIVO(MarketingPrgmDropDownList.SelectedItem.Text);
        //AgentsDropDownList.DataSource = ds4;
        //AgentsDropDownList.DataTextField = "Agent_Name";
        //AgentsDropDownList.DataValueField = "Agent_Name";
        //AgentsDropDownList.AppendDataBoundItems = true;
        //AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
        //AgentsDropDownList.DataBind();
    }


  

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
            using (SqlCommand cmd = new SqlCommand("select upper(v.Venue_Name) as Venue_Name,v.Venue_ID  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID   where vc.Venue_Country_Name = '" + id + "' and v.Venue_Status='Active'", con))
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
        if (countid=="Indonesia"  || countid=="INDONESIA")
        {
            DataTable dt = new DataTable();
            List<VenueGroupType> listRes = new List<VenueGroupType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
                using (SqlCommand cmd = new SqlCommand("select upper(Venue2_Name) as Venue2_Name from venue2 where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "') and venue2_status='Active'", con))
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
        else
        {
            DataTable dt = new DataTable();
            List<VenueGroupType> listRes = new List<VenueGroupType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
                using (SqlCommand cmd = new SqlCommand("select upper(Venue_Group_Name) as Venue_Group_Name  from Venue_Group vg join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venueid + "' and Venue_Group_Status = 'Active' order by 1", con))
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

                            objst2.VenueGroupTypeName = Convert.ToString(dt.Rows[i]["Venue_Group_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }
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
    public static string PopulateSubVenueGroupDropDownList(string venueid, string countid,string venue)
    {
        if (countid=="India" || countid=="INDIA")
        {
            DataTable dt = new DataTable();
            List<SubVenueGroupType> listRes = new List<SubVenueGroupType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
                using (SqlCommand cmd = new SqlCommand("select svi.SVenue_India_Name as SVenue_India_Name from sub_venue_india svi join Venue_Group vg on vg.Venue_Group_ID = svi.GroupVenue_ID join venue v on v.Venue_ID = vg.Venue_ID where vg.Venue_Group_Name = '" + venueid + "' and v.Venue_Name = '" + venue + "' and svi.SVenue_India_Status = 'Active' order by 1", con))
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

                            objst2.SubVenueGroupTypeName = Convert.ToString(dt.Rows[i]["SVenue_India_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }
            }
        }
        else{
            DataTable dt = new DataTable();
            List<SubVenueGroupType> listRes = new List<SubVenueGroupType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
                using (SqlCommand cmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue2_ID in (select Venue2_ID from Venue2 where Venue2_Name='" + venueid + "') and SVenue_Status='Active'", con))
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
       
    }



    public class MrktProgType
    {
        public string MrktProgTypeID { get; set; }
        public string MrktProgTypeName { get; set; }

        public string Marketing_Program_abbrv { get; set; }
    }


    [WebMethod]
    public static string PopulateMrktProgDropDownList(string venueGroupid, string countid,string venueid)
    {
        if (countid=="Indonesia" || countid=="INDONESIA")
        {
            DataTable dt = new DataTable();
            List<MrktProgType> listRes = new List<MrktProgType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                // using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
                using (SqlCommand cmd = new SqlCommand("select MProgram2_Name from Marketing_Program2 where Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueGroupid + "') and MProgram2_Status='Active'", con))
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


        }else
        {
            if (venueGroupid=="Coldline" || venueGroupid=="COLDLINE")
            {
                DataTable dt = new DataTable();
                List<MrktProgType> listRes = new List<MrktProgType>();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
                {
                    // using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
                    using (SqlCommand cmd = new SqlCommand("select m.Marketing_Program_Name,m.Marketing_Program_abbrv  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venueid + "' and vg.Venue_Group_Name ='" + venueGroupid + "' and m.Marketing_Program_Status = 'Active' order by 1", con))
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
                                // MrktProgType objst3 = new MrktProgType();


                                objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["Marketing_Program_Name"]);

                                objst2.Marketing_Program_abbrv = Convert.ToString(dt.Rows[i]["Marketing_Program_Name"]);

                                listRes.Insert(i, objst2);


                            }
                        }
                        JavaScriptSerializer jscript = new JavaScriptSerializer();

                        return jscript.Serialize(listRes);
                    }
                }
            }
            else
            {
                DataTable dt = new DataTable();
                List<MrktProgType> listRes = new List<MrktProgType>();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
                {
                    // using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
                    using (SqlCommand cmd = new SqlCommand("select m.Marketing_Program_Name,m.Marketing_Program_abbrv  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venueid + "' and vg.Venue_Group_Name ='" + venueGroupid + "' and m.Marketing_Program_Status = 'Active' order by 1", con))
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
                                // MrktProgType objst3 = new MrktProgType();


                                objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["Marketing_Program_Name"]);

                                objst2.Marketing_Program_abbrv = Convert.ToString(dt.Rows[i]["Marketing_Program_abbrv"]);

                                listRes.Insert(i, objst2);


                            }
                        }
                        JavaScriptSerializer jscript = new JavaScriptSerializer();

                        return jscript.Serialize(listRes);
                    }
                }
            }


           

        }
      
    }




    public class AgentType
    {
        public string AgentTypeID { get; set; }
        public string AgentTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentDropDownList(string markid,string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<AgentType> listRes = new List<AgentType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            using (SqlCommand cmd = new SqlCommand("select MSource_Name from Marketing_Source where MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name='" + markid + "' and Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name='" + venueid + "')) and MSource_Status='Active'", con))
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
    public static string PopulateAgentCodeDropDownList(string markid,string agentid,string venueid)
    {
        DataTable dt = new DataTable();
        List<AgentCodeType> listRes = new List<AgentCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            // using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '"+ agentid +"' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='"+ markid +"'))", con))

            using (SqlCommand cmd = new SqlCommand("select SCode_Name from Source_code where MSource_ID in (select MSource_ID from Marketing_Source where MSource_Name = '" + agentid + "' and MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name = '" + markid + "' and  Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueid + "')) ) and SCode_Status='Active'", con))
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

                        objst2.AgentCodeTypeName = Convert.ToString(dt.Rows[i]["SCode_Name"]) ;

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //public class CountryCodeType
    //{
    //    public string CountryCodeTypeID { get; set; }
    //    public string CountryCodeTypeName { get; set; }
    //}


    //[WebMethod]
    //public static string PopulateCountryCodeDropDownList(string Countid)
    //{
    //    DataTable dt = new DataTable();
    //    List<CountryCodeType> listRes = new List<CountryCodeType>();

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("select Country_Code from Country where Country_Name='"+ Countid + "'", con))
    //        {
    //            con.Open();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            da.Fill(dt);
    //            if (dt.Rows.Count > 0)
    //            {
    //                for (int i = 0; i < dt.Rows.Count; i++)
    //                {
    //                    /*objRes.Add(new resort
    //                    {
    //                        //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
    //                        ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
    //                    });*/

    //                    CountryCodeType objst2 = new CountryCodeType();

    //                    //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

    //                    objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Country_Code"]);

    //                    listRes.Insert(i, objst2);


    //                }
    //            }
    //            JavaScriptSerializer jscript = new JavaScriptSerializer();

    //            return jscript.Serialize(listRes);
    //        }
    //    }
    //}


        //nationality with Country

    public class CountryCodeType
    {
        public string CountryCodeTypeID { get; set; }
        public string CountryCodeTypeName { get; set; }
        public string SVenue_Name { get; set; }
    }


    [WebMethod]
    public static string PopulateCountryCodeDropDownList(string Countid,string countryID)
    {
        if (countryID=="India" || countryID=="INDIA")
        {
            DataTable dt = new DataTable();
            List<CountryCodeType> listRes = new List<CountryCodeType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select distinct country_name from country order by 1", con))
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

                            objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["country_name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }
            }
        }
        else
        {
            DataTable dt = new DataTable();
            List<CountryCodeType> listRes = new List<CountryCodeType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select Nationality_Country_Name from Nationality where Nationality_Name='" + Countid.Trim() + "'", con))
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

                            objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Nationality_Country_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }
            }

        }
       
    }


    [WebMethod]
    public static string PopulateSubVenueOnNationality(string id1)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select SubVenueID from Nationality where Nationality_Name='" + id1.Trim() + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string SubVenueID = reader.GetString(0);

            if (SubVenueID == "" || SubVenueID == null)
            {
                SqlConnection sqlcon1 = new SqlConnection(conn);
                sqlcon1.Open();
                string query1 = "select '' as SVenue_Name union select SVenue_Name from Sub_Venue where SVenue_ID in('SV79','SV82')";
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    string subvenue = reader1.GetString(0);
                    JSON += "[\"" + subvenue + "\"],";
                }
            }
            else
            {
                SqlConnection sqlcon1 = new SqlConnection(conn);
                sqlcon1.Open();
                string query1 = "select SVenue_Name from Sub_Venue where SVenue_ID='" + SubVenueID + "'";
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    string subvenue = reader1.GetString(0);
                    JSON += "[\"" + subvenue + "\"],";
                }

            }

        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;


    }


    //load sales rep with 

    public class SalesRepType
    {
        public string SalesRepTypeID { get; set; }
        public string SalesRepTypeName { get; set; }
    }


    [WebMethod]
    public static string SalesRepTypeList(string venueid, string countid,string venue)
    {
      
        if (countid=="India" || countid=="INDIA")
        {
            string vencountry = Queries2.GetVenueCountryCode(countid);
            DataTable dt = new DataTable();
            List<SalesRepType> listRes = new List<SalesRepType>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select sales_rep_name from Sales_Rep sr    join VenueCountry vc on vc.Venue_Country_ID = sr.Venue_country_ID    where sales_rep_status = 'Active'   and sr.venue = '"+venue+"' and vc.Venue_Country_Name = '"+countid+"' order by 1", con))
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

                            SalesRepType objst2 = new SalesRepType();

                            //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                            objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }
            }

        } else {
           

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                string vencountry = Queries2.GetVenueCountryCode(countid);
                DataTable dt = new DataTable();
                List<SalesRepType> listRes = new List<SalesRepType>();
                if (/*venue != "Inhouse" */venue != "INHOUSE")
                {
                    if ((venueid != "Flybuy") && (venueid != "FLYBUY"))
                    {
                        using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "' and venue= '" + venue + "' and Group_Venue= '" + venueid + "'and Sales_Rep_Status='Active' order by Sales_Rep_Name", con))
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

                                    SalesRepType objst2 = new SalesRepType();

                                    //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                                    objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                                    listRes.Insert(i, objst2);


                                }
                            }
                            JavaScriptSerializer jscript = new JavaScriptSerializer();
                            return jscript.Serialize(listRes);

                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "'and Sales_Rep_Status='Active' order by Sales_Rep_Name ", con))
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

                                    SalesRepType objst2 = new SalesRepType();

                                    //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                                    objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                                    listRes.Insert(i, objst2);


                                }
                            }
                            JavaScriptSerializer jscript = new JavaScriptSerializer();
                            return jscript.Serialize(listRes);

                        }


                    }
                }
                else
                {

                    using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "' and venue= '" + venue + "'and Sales_Rep_Status='Active' order by Sales_Rep_Name", con))
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

                                SalesRepType objst2 = new SalesRepType();

                                //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                                objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                                listRes.Insert(i, objst2);


                            }
                        }
                        JavaScriptSerializer jscript = new JavaScriptSerializer();
                        return jscript.Serialize(listRes);

                    }

                }
            }

        }

       
    }
    

    //    //protected void dostuff()
    //    //{


    //    //    string radalertscript = "<script> $( function() {alert('hi')});</script>";
    //    //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", radalertscript);
    //    //    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "radalert", radalertscript, true);

    //    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", radalertscript, false);
    //    //}


    //    //protected void dostuff2 (string profileID)
    //    //{

    //    //    DataTable datatable = Queries2.loadregcard(profileID);
    //    //    var printr = "Guest Reg Form";


    //    //    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
    //    //    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
    //    //    crystalReport.SetDataSource(datatable);

    //    //    System.IO.FileStream fs = null;
    //    //    long FileSize = 0;
    //    //    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
    //    //    //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
    //    //    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
    //    //    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
    //    //    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
    //    //    oDest.DiskFileName = ExportFileName;
    //    //    crystalReport.ExportOptions.DestinationOptions = oDest;
    //    //    crystalReport.Export();
    //    //    Response.Clear();
    //    //    Response.Buffer = true;
    //    //    Response.AddHeader("Content-Type", "application/pdf");
    //    //    string fn = "Guest Reg Form" + ".pdf";
    //    //    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

    //    //    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
    //    //    FileSize = fs.Length;
    //    //    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
    //    //    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
    //    //    fs.Close();
    //    //    // Response.Write("<script>$(function() {alert('hi'); });</script>");

    //    //    Response.BinaryWrite(bBuffer);
    //    //    Response.Flush();
    //    //    Response.Clear();
    //    //}


    [WebMethod]
    public static string LoadAgentsOnVenuegrp(string venueCountry, string vgrp, string venue)//string venue,string vgrp)
    {
        string office = Queries.GetOfficeOnVenueCountry(venueCountry);
        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline" || vgrp=="COLDLINE")
        {
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue, office);// venue);
            if (reader.HasRows) {
                while (reader.Read())
                {
                    string ag = reader.GetString(0);

                    JSON += "[\"" + ag + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            } else {

                JSON += "[\"" + "" + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";

            }
           
        }
        else
        {
            SqlDataReader reader = Queries.GetSalesRepOnlyVenue(venue);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string ag = reader.GetString(0);

                    JSON += "[\"" + ag + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }
            else {

                JSON += "[\"" + "" + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";

            }
         
        }

        return JSON;
    }


    [WebMethod]
    public static string LoadTOOnVenueNVGrp(string venueCountry, string vgrp, string venue)//string venue,string vgrp)
    {
        string office = Queries.GetOfficeOnVenueCountry(venueCountry);
        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline" || vgrp== "COLDLINE")
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenue1(venue, office);// venue);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string tom = reader.GetString(0);

                    JSON += "[\"" + tom + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }
            else {

                JSON += "[\"" + "" + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }
           

            return JSON;
        }
        else
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenueNGrp(venue);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string tom = reader.GetString(0);

                    JSON += "[\"" + tom + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }
            else {

                JSON += "[\"" + "" + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";

            }
            
            return JSON;

        }
    }


    [WebMethod]
    public static string LoadManagersOnVenue(string venueCountry, string venue)//string venue)
    {
        string office = Queries.GetOfficeOnVenueCountry(venueCountry);
        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadManagersOnVenue1(venue, office);// venue);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string mn = reader.GetString(0);

                JSON += "[\"" + mn + "\"],";
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
    public static string getAdminRights()
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string JSON = "{\n \"names\":[";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        string query = "select name,PageName from user_group_access  where Username='" + user + "' and PageType='Admin'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string name = reader.GetString(0);
                string PageName = reader.GetString(1);

                JSON += "[\"" + name + "\" , \"" + PageName + "\"],";


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

        reader.Close();
        sqlcon.Close();



        return JSON;



    }

    [WebMethod]
    public static string searchProfile(string profileID)
    {
        string office = HttpContext.Current.Session["office"].ToString();
        string JSON = "{\n \"names\":[";

        if (profileID == "" || profileID == null)
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {

            SqlDataReader reader = production.searchProfiles(profileID, office);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string profile = reader.GetString(0);
                    string title = reader.GetString(1);
                    string name = reader.GetString(2);
                    string email = reader.GetString(3);
                    string mobile = reader.GetString(4);
                    string tourdate = reader.GetString(5);
                 

                    string profile1 = profile.Trim();
                    string title1 = title.Trim();
                    string name1 = name.Trim();
                    string email1 = email.Trim();
                    string mobile1 = mobile.Trim();
                    string tourdate1 = tourdate.Trim();
                 
                    JSON += "[\"" + profile1 + "\" , \"" + title1 + "\",\"" + name1 + "\" , \"" + email1 + "\", \"" + mobile1 + "\", \"" + tourdate1 + "\"],";


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

            reader.Close();


        }

        return JSON;



    }



    [WebMethod]
    public static string getlink(string profileID)
    {
        string office = HttpContext.Current.Session["office"].ToString();
        string JSON = "{\n \"names\":[";

        if (office == "HML")
        {


            string val = "../../Contractsite/IndiaEdit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        else if (office == "IVO")
        {


            string val = "Edit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }



        return JSON;
        
    }



    [WebMethod]
    public static string PopulatePriTitleDropDownList(string countryName)
    {
        string office = Queries.GetOfficeOnVenueCountry(countryName);
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Salutation from Salutations where status='active' and office='" + office + "' order by 1";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {


            while (reader.Read())
            {

                string Salutation = reader.GetString(0);



                JSON += "[\"" + Salutation + "\"],";


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
        reader.Close();
        sqlcon.Close();
        return JSON;
        

    }


    [WebMethod]
    public static string PopulateNationalityDropDownList(string countryName)
    {
        string office = Queries.GetOfficeOnVenueCountry(countryName);
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        String JSON = "{\n \"names\":[";
        if (countryName=="India" || countryName=="INDIA")
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select distinct nationality_name from nationality order by 1";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {


                while (reader.Read())
                {

                    string nationality_name = reader.GetString(0);



                    JSON += "[\"" + nationality_name + "\"],";


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
            reader.Close();
            sqlcon.Close();
        }
        else {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select Nationality_Name from Nationality order by orders desc,Nationality_Name asc";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {


                while (reader.Read())
                {

                    string Nationality_Name = reader.GetString(0);



                    JSON += "[\"" + Nationality_Name + "\"],";


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
            reader.Close();
            sqlcon.Close();
        }


        return JSON;

    }



    [WebMethod]
    public static string PopulateAddressCountryDropDownList(string countryName)
    {
        string office = Queries.GetOfficeOnVenueCountry(countryName);
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        String JSON = "{\n \"names\":[";
        if (countryName == "India" || countryName == "INDIA")
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select distinct country_name from country order by 1";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {


                while (reader.Read())
                {

                    string nationality_name = reader.GetString(0);



                    JSON += "[\"" + nationality_name + "\"],";


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
            reader.Close();
            sqlcon.Close();
        }
        else
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select Country_Name from Country order by COrder desc,Country_Name";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {


                while (reader.Read())
                {

                    string Nationality_Name = reader.GetString(0);



                    JSON += "[\"" + Nationality_Name + "\"],";


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
            reader.Close();
            sqlcon.Close();
        }


        return JSON;

    }


    [WebMethod]
    public static string LoadCountryCode(string country)
    {
        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadCodeOnCountry(country);
        if (reader.HasRows) {
            while (reader.Read())
            {
                string mn = reader.GetString(0);

                JSON += "[\"" + mn + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        } else {

            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        
        return JSON;
    }


    [WebMethod]
    public static string LoadStates(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select s.State_Name from state s join Country c on s.State_Country=c.Country_Name where c.Country_Name='" + country + "' order by 1";
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
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        reader.Close();
        sqlcon.Close();
        return JSON;
        
    }


    [WebMethod]
    public static string LoadTypes()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Type_Name from Type order by 1";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string Type = reader.GetString(0);



                JSON += "[\"" + Type + "\"],";


            }

            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }

        reader.Close();
        sqlcon.Close();
        return JSON;





    }




    [WebMethod]
    public static string PopulateGiftOptionDropDownList(string countryName)
    {
        string office = Queries.GetOfficeOnVenueCountry(countryName);
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string JSON = "{\n \"names\":[";
        if (countryName=="India" || countryName=="INDIA")
        {
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select Gift_Option_Name + ' -' + ' ' + item as item from Gift_Option where Gift_Option_Status = 'Active' and office='"+office+"'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {


                while (reader.Read())
                {

                    string item = reader.GetString(0);



                    JSON += "[\"" + item + "\"],";


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

            reader.Close();
            sqlcon.Close();

        }
        else
        {
            SqlConnection sqlcon = new SqlConnection(conn);
           
            string query = "select item from Gift_Option where Gift_Option_Status = 'Active' and office='" + office + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {


                while (reader.Read())
                {

                    string item = reader.GetString(0);



                    JSON += "[\"" + item + "\"],";


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

            reader.Close();
            sqlcon.Close();

        }
       
        return JSON;

    }

    

    //[WebMethod]
    //public static string loadSubVenueIndia(string venue ,string venue_group)
    //{

    //    String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
    //    SqlConnection sqlcon = new SqlConnection(conn);
    //    String JSON = "{\n \"names\":[";
    //    string query = "select svi.SVenue_India_Name from sub_venue_india svi join Venue_Group vg on vg.Venue_Group_ID = svi.GroupVenue_ID join venue v on v.Venue_ID = vg.Venue_ID where vg.Venue_Group_Name = '"+venue_group+"' and v.Venue_Name = '"+venue+"' and svi.SVenue_India_Status = 'Active' order by 1";
    //    sqlcon.Open();
    //    SqlCommand cmd = new SqlCommand(query, sqlcon);
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    if (reader.HasRows)
    //    {
    //        while (reader.Read())
    //        {

    //            string SVenue_India_Name = reader.GetString(0);



    //            JSON += "[\"" + SVenue_India_Name + "\"],";


    //        }

    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";
    //    }
    //    else
    //    {
    //        JSON += "[\"" + "" + "\"],";
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";

    //    }

    //    reader.Close();
    //    sqlcon.Close();
    //    return JSON;
        
    //}
}