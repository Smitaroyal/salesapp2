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
public partial class WebSite5_production_EditProfile1 : System.Web.UI.Page
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
        
        Label2.Text = user;
        string val = getdata();
        // CreatedByTextBox.Text = user;

        if (!Page.IsPostBack)
        {
            string ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);
            ProfileIDTextBox.ReadOnly = true;

            //-------------------------- Profile Details -----------------------------//
            DataSet ds = Queries3.LoadProfielDetailsFull(ProfileID);
            DataSet dsT = Queries3.LoadTaxiprice(ProfileID);
            CreatedByTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString(); ;
            ProfileIDTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();
            Session["ProfileIDo"] = ""; Session["office"] = ""; Session["venueCountry"] = "";
            Session["priCountry"] = ""; Session["secCountry"] = ""; Session["sp1Country"] = "";
            Session["sp2Country"] = ""; Session["sp3Country"] = ""; Session["sp4Country"] = "";
            Session["ProfileIDo"] = ds.Tables[0].Rows[0]["Profile_ID"].ToString();
            Session["office"] = ds.Tables[0].Rows[0]["Office"].ToString();
            Session["venueCountry"] = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
            Session["priCountry"] = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
            Session["groupVenue"] = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            Session["secCountry"] = ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString();
            Session["sp1Country"] = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
            Session["sp2Country"] = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
            Session["sp3Country"] = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
            Session["sp4Country"] = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
            DataSet recep = Queries3.LoadRecept();

            ReceptionistDropDownList.DataSource = recep;
            ReceptionistDropDownList.DataTextField = "name";
            ReceptionistDropDownList.DataValueField = "Recep_ID";
            ReceptionistDropDownList.AppendDataBoundItems = true;
            ReceptionistDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Reception"].ToString(), ""));
            ReceptionistDropDownList.DataBind();



            DataSet ds1 = Queries3.LoadVenueCountryOnProfileID(Session["ProfileIDo"].ToString());
            VenueCountryDropDownList.DataSource = ds1;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            DataSet ds2 = Queries3.LoadVenue(Session["venueCountry"].ToString(), ds.Tables[0].Rows[0]["Profile_Venue"].ToString());
            VenueDropDownList.DataSource = ds2;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            GroupVenueDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString());

            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                if (Session["groupVenue"].ToString()=="Coldline" || Session["groupVenue"].ToString()=="COLDLINE")
                {
                    MarketingPrgmDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());

                }
                else
                {
                    if (ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString() == "" || ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString() == null)
                    {
                        MarketingPrgmDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString()== "MBRMKT" && ds.Tables[0].Rows[0]["Lead_Source"].ToString()=="")
                        {
                            MarketingPrgmDropDownList.Items.Add("CANCELLED MEMBER");
                        }
                        else if (ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString() == "MBRMKT" && ds.Tables[0].Rows[0]["Lead_Source"].ToString() == "MRG")
                        {
                            MarketingPrgmDropDownList.Items.Add("REVOKED MEMBER");
                        }
                        else
                        {
                            string marketingProgram = Queries3.getMarketingProgramOnMarketingAbb(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), Session["groupVenue"].ToString(), ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
                            MarketingPrgmDropDownList.Items.Add(marketingProgram);

                        }

                           
                    }

                }
              
               
            }
            else
            {
                MarketingPrgmDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
            }




            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                AgentsDropDownListInd.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent"].ToString());
            }
            else
            {
                AgentsDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent"].ToString());
            }

            string GroupVenueDropDownListval = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                TONameDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());

            }
            else
            {
                if (GroupVenueDropDownListval == "Coldline")
                {
                    sourcecodetext.Text = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();

                }
                else
                {
                    AgentCodeDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());
                }
            }

            ManagerDropDownList.Items.Add(ds.Tables[0].Rows[0]["Manager"].ToString());


            string subvenue1 = "";
            if (Session["venueCountry"].ToString()=="India" || Session["venueCountry"].ToString()=="INDIA")
            {
                VenueDropDownList2.Items.Add(ds.Tables[0].Rows[0]["SubVenue"].ToString());
            }
            else
            {
                subvenue1 = ds.Tables[0].Rows[0]["SubVenue"].ToString();
                DataSet loadven = Queries3.LoadSubVenue(GroupVenueDropDownListval, subvenue1);
                //VenueDropDownList.DataSource = ds24; 
                VenueDropDownList2.DataSource = loadven;
                VenueDropDownList2.DataTextField = "SVenue_Name";
                VenueDropDownList2.DataValueField = "SVenue_Name";
                VenueDropDownList2.AppendDataBoundItems = true;
                //VenueCountryDropDownList.Items.Insert(0,"", ""));
                VenueDropDownList2.Items.Insert(0, new ListItem(subvenue1, ""));
                VenueDropDownList2.DataBind();
            }

          
          

            if (Session["groupVenue"].ToString() == "Flybuy" || Session["groupVenue"].ToString() == "FLYBUY")
            {
                OfficeSourceTextBox.Text = ds.Tables[0].Rows[0]["Promo_Source"].ToString();
                DataSet Flyage = Queries3.LoadFlybuyAgent();

                FAgentDropDownList.DataSource = Flyage;
                FAgentDropDownList.DataTextField = "FAgent_Name";
                FAgentDropDownList.DataValueField = "FAgent_Name";
                FAgentDropDownList.AppendDataBoundItems = true;
                FAgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tele_Agent"].ToString(), ""));
                FAgentDropDownList.DataBind();



                DataSet LeaSou = Queries3.LoadLeadSource();
                DropDownListFly.DataSource = LeaSou;
                DropDownListFly.DataTextField = "Lead_Source_Name";
                DropDownListFly.DataValueField = "Lead_Source_Name";
                DropDownListFly.AppendDataBoundItems = true;
                DropDownListFly.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Lead_Source"].ToString(), ""));
                DropDownListFly.DataBind();

                DataSet PreArr = Queries3.LoadPreArrival();

                PreArrivalDropDownList.DataSource = PreArr;
                PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
                PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
                PreArrivalDropDownList.AppendDataBoundItems = true;
                PreArrivalDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Pre_Arrival"].ToString(), ""));
                PreArrivalDropDownList.DataBind();

                DataSet Veri = Queries3.LoadVerification();

                VerificationDropDownList.DataSource = Veri;
                VerificationDropDownList.DataTextField = "Verification_Name";
                VerificationDropDownList.DataValueField = "Verification_Name";
                VerificationDropDownList.AppendDataBoundItems = true;
                VerificationDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Verification"].ToString(), ""));
                VerificationDropDownList.DataBind();
            }
            else
            {
                OfficeSourceTextBox.Text = ds.Tables[0].Rows[0]["Promo_Source"].ToString();
                DataSet Flyage = Queries3.LoadFlybuyAgent();

                FAgentDropDownList.DataSource = Flyage;
                FAgentDropDownList.DataTextField = "FAgent_Name";
                FAgentDropDownList.DataValueField = "FAgent_Name";
                FAgentDropDownList.AppendDataBoundItems = true;
                FAgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tele_Agent"].ToString(), ""));
                FAgentDropDownList.DataBind();



                DataSet LeaSou = Queries3.LoadLeadSource();

                DropDownListFly.DataSource = LeaSou;
                DropDownListFly.DataTextField = "Lead_Source_Name";
                DropDownListFly.DataValueField = "Lead_Source_Name";
                DropDownListFly.AppendDataBoundItems = true;
                DropDownListFly.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Lead_Source"].ToString(), ""));
                DropDownListFly.DataBind();

                DataSet PreArr = Queries3.LoadPreArrival();

                PreArrivalDropDownList.DataSource = PreArr;
                PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
                PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
                PreArrivalDropDownList.AppendDataBoundItems = true;
                PreArrivalDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Pre_Arrival"].ToString(), ""));
                PreArrivalDropDownList.DataBind();

                DataSet Veri = Queries3.LoadVerification();

                VerificationDropDownList.DataSource = Veri;
                VerificationDropDownList.DataTextField = "Verification_Name";
                VerificationDropDownList.DataValueField = "Verification_Name";
                VerificationDropDownList.AppendDataBoundItems = true;
                VerificationDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Verification"].ToString(), ""));
                VerificationDropDownList.DataBind();
            }


            DataSet dsLead = Queries3.onLoadLeadOffice(Session["ProfileIDo"].ToString());
            leadOffice.DataSource = dsLead;
            leadOffice.DataTextField = "Office";
            leadOffice.DataValueField = "Office";
            leadOffice.AppendDataBoundItems = true;
            leadOffice.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["leadOffice"].ToString(), ""));
            leadOffice.DataBind();



            //--------------------------------------- end of profile details-----------------------------//

            // ------------------------------------Primary profile details-------------------------------//
            DataSet dsptitle = Queries3.LoadSalutations(Session["office"].ToString());
            primarytitleDropDownList.DataSource = dsptitle;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            primarytitleDropDownList.DataBind();

            pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();

            string datePrimary = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]);
            if (datePrimary == "" || datePrimary == "01-01-1900")
            {
                pdobdatepicker.Text = "";
            }
            else
            {
                pdobdatepicker.Text = datePrimary;
            }
            TextPrimaryAge.Text = ds.Tables[0].Rows[0]["Primary_Age"].ToString();

            DataSet dsemploy = Queries.LoadEmploymentStatusNotInProfile(Session["ProfileIDo"].ToString());
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();

            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dspnationality = Queries.LoadPrimaryNationality(Session["ProfileIDo"].ToString());
                primarynationalityDropDownList.DataSource = dspnationality;
                primarynationalityDropDownList.DataTextField = "Nationality_Name";
                primarynationalityDropDownList.DataValueField = "Nationality_Name";
                primarynationalityDropDownList.AppendDataBoundItems = true;
                primarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
                primarynationalityDropDownList.DataBind();
            }
            else
            {
                DataSet primanat = Queries3.LoadNationalityWithoutPrevValPrimary(Session["ProfileIDo"].ToString());
                primarynationalityDropDownList.DataSource = primanat;
                primarynationalityDropDownList.DataTextField = "nationality_name";
                primarynationalityDropDownList.DataValueField = "nationality_name";
                primarynationalityDropDownList.AppendDataBoundItems = true;
                primarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
                primarynationalityDropDownList.DataBind();
            }


            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dspcountry = Queries.LoadCountryPrimary(Session["ProfileIDo"].ToString());
                PrimaryCountryDropDownList.DataSource = dspcountry;
                PrimaryCountryDropDownList.DataTextField = "country_name";
                PrimaryCountryDropDownList.DataValueField = "country_name";
                PrimaryCountryDropDownList.AppendDataBoundItems = true;
                PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
                PrimaryCountryDropDownList.DataBind();

            }
            else
            {
                PrimaryCountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString());
            }


            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dspm = Queries.LoadCountryWithCodePrimaryMobile(Session["ProfileIDo"].ToString());
                primarymobileDropDownList.DataSource = dspm;
                primarymobileDropDownList.DataTextField = "name";
                primarymobileDropDownList.DataValueField = "name";
                primarymobileDropDownList.AppendDataBoundItems = true;
                primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
                primarymobileDropDownList.DataBind();

                pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();


                DataSet dspalt = Queries.LoadCountryWithCodePrimaryAlt(Session["priCountry"].ToString());//( ProfileID);
                primaryalternateDropDownList.DataSource = dspalt;
                primaryalternateDropDownList.DataTextField = "name";
                primaryalternateDropDownList.DataValueField = "name";
                primaryalternateDropDownList.AppendDataBoundItems = true;
                primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
                primaryalternateDropDownList.DataBind();
                palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();


                DataSet dspoff = Queries.LoadCountryWithCodePrimaryOffice(Session["priCountry"].ToString());//(ProfileID);
                pofficecodeDropDownList.DataSource = dspoff;
                pofficecodeDropDownList.DataTextField = "name";
                pofficecodeDropDownList.DataValueField = "name";
                pofficecodeDropDownList.AppendDataBoundItems = true;
                pofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_office_cc"].ToString(), ""));
                pofficecodeDropDownList.DataBind();
                pofficenoTextBox.Text = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();

                DataSet dsphome = Queries.LoadCountryWithCodePrimaryOffice(Session["priCountry"].ToString());//(ProfileID);
                phomecodeDropDownList.DataSource = dsphome;
                phomecodeDropDownList.DataTextField = "name";
                phomecodeDropDownList.DataValueField = "name";
                phomecodeDropDownList.AppendDataBoundItems = true;
                phomecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_home_cc"].ToString(), ""));
                phomecodeDropDownList.DataBind();

                phomenoTextBox.Text = ds.Tables[0].Rows[0]["Primary_home_num"].ToString();




            }
            else
            {
                DataSet ds14p = Queries3.LoadCountryWithCodePrimaryMobile(Session["ProfileIDo"].ToString());
                primarymobileDropDownList.DataSource = ds14p;
                primarymobileDropDownList.DataTextField = "name";
                primarymobileDropDownList.DataValueField = "name";
                primarymobileDropDownList.AppendDataBoundItems = true;
                primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
                primarymobileDropDownList.DataBind();
                pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();

                DataSet ds14al = Queries3.LoadCountryWithCodePrimaryAlt(Session["ProfileIDo"].ToString());
                primaryalternateDropDownList.DataSource = ds14al;
                primaryalternateDropDownList.DataTextField = "name";
                primaryalternateDropDownList.DataValueField = "name";
                primaryalternateDropDownList.AppendDataBoundItems = true;
                primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
                primaryalternateDropDownList.DataBind();

                palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();

                // pofficecodeDropDownList.Items.Add(ds.Tables[0].Rows[0]["Primary_office_cc"].ToString());
                // pofficenoTextBox.Text = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();

            }

            pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            pemailTextBox2.Text = ds.Tables[0].Rows[0]["Primary_Email2"].ToString();

            TextBoxPrimIDType.Text = ds.Tables[0].Rows[0]["Primary_ID_Type"].ToString();
            TextBoxPrimID.Text = ds.Tables[0].Rows[0]["Primary_ID_Num"].ToString();

            //---------------------------------- end of primary profile details ----------------------------------//

            //---------------------------------- secondary profile details ----------------------------------------//
            DataSet dsstitle = Queries3.LoadSalutations(Session["office"].ToString());
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();

            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();

            string dateSecondary = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);

            if (dateSecondary == "" || dateSecondary == "01-01-1900")
            {
                sdobdatepicker.Text = "";
            }
            else
            {
                sdobdatepicker.Text = dateSecondary;
            }
            TextSecondAge.Text = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();

            DataSet Secondemploy = Queries.LoadEmploymentStatus();
            SecondemploymentstatusDropDownList.DataSource = Secondemploy;
            SecondemploymentstatusDropDownList.DataTextField = "Name";
            SecondemploymentstatusDropDownList.DataValueField = "Name";
            SecondemploymentstatusDropDownList.AppendDataBoundItems = true;
            SecondemploymentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_Employment_Status"].ToString(), ""));
            SecondemploymentstatusDropDownList.DataBind();


            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dssnationality = Queries.LoadSecondaryNationality(Session["ProfileIDo"].ToString());
                secondarynationalityDropDownList.DataSource = dssnationality;
                secondarynationalityDropDownList.DataTextField = "Nationality_Name";
                secondarynationalityDropDownList.DataValueField = "Nationality_Name";
                secondarynationalityDropDownList.AppendDataBoundItems = true;
                secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Nationality"].ToString(), ""));
                secondarynationalityDropDownList.DataBind();
            }
            else
            {
                DataSet seconnat = Queries3.LoadNationalityWithoutPrevValSecondary(Session["ProfileIDo"].ToString());
                secondarynationalityDropDownList.DataSource = seconnat;
                secondarynationalityDropDownList.DataTextField = "nationality_name";
                secondarynationalityDropDownList.DataValueField = "nationality_name";
                secondarynationalityDropDownList.AppendDataBoundItems = true;
                secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString(), ""));
                secondarynationalityDropDownList.DataBind();
            }


            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dsscountry = Queries.LoadCountrySecondary(Session["ProfileIDo"].ToString());
                SecondaryCountryDropDownList.DataSource = dsscountry;
                SecondaryCountryDropDownList.DataTextField = "country_name";
                SecondaryCountryDropDownList.DataValueField = "country_name";
                SecondaryCountryDropDownList.AppendDataBoundItems = true;
                SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString(), ""));
                SecondaryCountryDropDownList.DataBind();

            }
            else
            {
                SecondaryCountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString());
            }

            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dssm = Queries.LoadCountryWithCodeSecondaryMobile(Session["secCountry"].ToString());
                secondarymobileDropDownList.DataSource = dssm;
                secondarymobileDropDownList.DataTextField = "name";
                secondarymobileDropDownList.DataValueField = "name";
                secondarymobileDropDownList.AppendDataBoundItems = true;
                secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_CC"].ToString(), ""));
                secondarymobileDropDownList.DataBind();

                smobileTextBox.Text = ds.Tables[0].Rows[0]["secondary_Mobile"].ToString();


                DataSet dssalt = Queries.LoadCountryWithCodeSecondaryAlt(Session["secCountry"].ToString());//(ProfileID);
                secondaryalternateDropDownList.DataSource = dssalt;
                secondaryalternateDropDownList.DataTextField = "name";
                secondaryalternateDropDownList.DataValueField = "name";
                secondaryalternateDropDownList.AppendDataBoundItems = true;
                secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_Alt_CC"].ToString(), ""));
                secondaryalternateDropDownList.DataBind();
                salternateTextBox.Text = ds.Tables[0].Rows[0]["secondary_Alternate"].ToString();


                DataSet dssoff = Queries.LoadCountryWithCodeSecondaryAlt(Session["secCountry"].ToString());//(ProfileID);
                sofficecodeDropDownList.DataSource = dssoff;
                sofficecodeDropDownList.DataTextField = "name";
                sofficecodeDropDownList.DataValueField = "name";
                sofficecodeDropDownList.AppendDataBoundItems = true;
                sofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString(), ""));
                sofficecodeDropDownList.DataBind();
                sofficenoTextBox.Text = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();

                DataSet dsshome = Queries.LoadCountryWithCodePrimaryOffice(Session["priCountry"].ToString());//(ProfileID);
                shomecodeDropDownList.DataSource = dsshome;
                shomecodeDropDownList.DataTextField = "name";
                shomecodeDropDownList.DataValueField = "name";
                shomecodeDropDownList.AppendDataBoundItems = true;
                shomecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_home_cc"].ToString(), ""));
                shomecodeDropDownList.DataBind();

                shomenoTextBox.Text = ds.Tables[0].Rows[0]["Secondary_home_num"].ToString();





            }
            else
            {
                DataSet ds144 = Queries3.LoadCountryWithCodeSecondaryMobile(Session["ProfileIDo"].ToString());
                secondarymobileDropDownList.DataSource = ds144;
                secondarymobileDropDownList.DataTextField = "name";
                secondarymobileDropDownList.DataValueField = "name";
                secondarymobileDropDownList.AppendDataBoundItems = true;
                secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
                secondarymobileDropDownList.DataBind();

                smobileTextBox.Text = ds.Tables[0].Rows[0]["secondary_Mobile"].ToString();

                DataSet ds14aa = Queries3.LoadCountryWithCodeSecondaryAlt(Session["ProfileIDo"].ToString());
                secondaryalternateDropDownList.DataSource = ds14aa;
                secondaryalternateDropDownList.DataTextField = "name";
                secondaryalternateDropDownList.DataValueField = "name";
                secondaryalternateDropDownList.AppendDataBoundItems = true;
                secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
                secondaryalternateDropDownList.DataBind();

                salternateTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();


            }
            semailTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            semailTextBox2.Text = ds.Tables[0].Rows[0]["Secondary_Email2"].ToString();

            TextBoxSecoIDType.Text = ds.Tables[0].Rows[0]["Secondary_ID_Type"].ToString();
            TextBoxSecoID.Text = ds.Tables[0].Rows[0]["Secondary_ID_Num"].ToString();


            //--------------------------------- end of secondary profile details ---------------------------------//

            //---------------------------------- profile address and other details --------------------------------//

            address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();

            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet ds12 = Queries.LoadCountryName();
                AddCountryDropDownList.DataSource = ds12;
                AddCountryDropDownList.DataTextField = "country_name";
                AddCountryDropDownList.DataValueField = "country_name";
                AddCountryDropDownList.AppendDataBoundItems = true;
                AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
                AddCountryDropDownList.DataBind();

                DataSet ds1222 = Queries.LoadStateName(Session["ProfileIDo"].ToString(), AddCountryDropDownList.SelectedItem.Text);
                StateDropDownList.DataSource = ds1222;
                StateDropDownList.DataTextField = "State_Name";
                StateDropDownList.DataValueField = "State_Name";
                StateDropDownList.AppendDataBoundItems = true;
                StateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_State"].ToString(), ""));
                StateDropDownList.DataBind();

                maledesgTextBox.Text = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
                femaledesgTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();

            }
            else
            {
                DataSet ds12 = Queries3.LoadCountryName();
                AddCountryDropDownList.DataSource = ds12;
                AddCountryDropDownList.DataTextField = "country_name";
                AddCountryDropDownList.DataValueField = "country_name";
                AddCountryDropDownList.AppendDataBoundItems = true;
                AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
                AddCountryDropDownList.DataBind();
                stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            }


            cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            DataSet dsmart = Queries.LoadMaritalStatus();
            MaritalStatusDropDownList.DataSource = dsmart;
            MaritalStatusDropDownList.DataTextField = "MaritalStatus";
            MaritalStatusDropDownList.DataValueField = "MaritalStatus";
            MaritalStatusDropDownList.AppendDataBoundItems = true;
            MaritalStatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            MaritalStatusDropDownList.DataBind();
            livingyrsTextBox.Text = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();


            //------------------------------------ end profile address / other details ------------------------------//

            // ------------------------------------ sub profile 1 details -------------------------------------------//
            DataSet dssp1title = Queries3.LoadSalutations(Session["office"].ToString());
            subprofile1titleDropDownList.DataSource = dssp1title;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            subprofile1titleDropDownList.DataBind();

            sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();

            string dateSp1 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);
            if (dateSp1 == " " || dateSp1 == "01-01-1900")
            {
                sp1dobdatepicker.Text = "";
            }
            else
            {
                sp1dobdatepicker.Text = dateSp1;
            }

            TextSP1Age.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dssp1nationality = Queries.LoadSub_Profile1Nationality(Session["ProfileIDo"].ToString());
                subprofile1nationalityDropDownList.DataSource = dssp1nationality;
                subprofile1nationalityDropDownList.DataTextField = "Nationality_Name";
                subprofile1nationalityDropDownList.DataValueField = "Nationality_Name";
                subprofile1nationalityDropDownList.AppendDataBoundItems = true;
                subprofile1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
                subprofile1nationalityDropDownList.DataBind();

                DataSet dssp1country = Queries.LoadCountrySP1(Session["ProfileIDo"].ToString());
                SubProfile1CountryDropDownList.DataSource = dssp1country;
                SubProfile1CountryDropDownList.DataTextField = "country_name";
                SubProfile1CountryDropDownList.DataValueField = "country_name";
                SubProfile1CountryDropDownList.AppendDataBoundItems = true;
                SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
                SubProfile1CountryDropDownList.DataBind();

                DataSet dssp1m = Queries.LoadCountryWithCodeSP1Mobile(Session["sp1Country"].ToString());
                subprofile1mobileDropDownList.DataSource = dssp1m;
                subprofile1mobileDropDownList.DataTextField = "name";
                subprofile1mobileDropDownList.DataValueField = "name";
                subprofile1mobileDropDownList.AppendDataBoundItems = true;
                subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
                subprofile1mobileDropDownList.DataBind();

                sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();

                DataSet dssp1alt = Queries.LoadCountryWithCodeSP1Alt(Session["sp1Country"].ToString());
                subprofile1alternateDropDownList.DataSource = dssp1alt;
                subprofile1alternateDropDownList.DataTextField = "name";
                subprofile1alternateDropDownList.DataValueField = "name";
                subprofile1alternateDropDownList.AppendDataBoundItems = true;
                subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
                subprofile1alternateDropDownList.DataBind();

                sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();

            }
            else
            {
                DataSet sp1nat = Queries3.LoadNationalityWithoutPrevValSP1(Session["ProfileIDo"].ToString());
                subprofile1nationalityDropDownList.DataSource = sp1nat;
                subprofile1nationalityDropDownList.DataTextField = "nationality_name";
                subprofile1nationalityDropDownList.DataValueField = "nationality_name";
                subprofile1nationalityDropDownList.AppendDataBoundItems = true;
                subprofile1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
                subprofile1nationalityDropDownList.DataBind();

                SubProfile1CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());


                DataSet dssp1 = Queries3.LoadCountryWithCodeSP1Mobile(Session["ProfileIDo"].ToString());
                subprofile1mobileDropDownList.DataSource = dssp1;
                subprofile1mobileDropDownList.DataTextField = "name";
                subprofile1mobileDropDownList.DataValueField = "name";
                subprofile1mobileDropDownList.AppendDataBoundItems = true;
                subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
                subprofile1mobileDropDownList.DataBind();

                sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();


                DataSet dsspalt = Queries3.LoadCountryWithCodeSP1Alt(Session["ProfileIDo"].ToString());
                subprofile1alternateDropDownList.DataSource = dsspalt;
                subprofile1alternateDropDownList.DataTextField = "name";
                subprofile1alternateDropDownList.DataValueField = "name";
                subprofile1alternateDropDownList.AppendDataBoundItems = true;
                subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
                subprofile1alternateDropDownList.DataBind();

                sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();


            }

            sp1emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            sp1emailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

            TextBoxSP1IDType.Text = ds.Tables[0].Rows[0]["SP1_ID_Type"].ToString();
            TextBoxSP1ID.Text = ds.Tables[0].Rows[0]["SP1_ID_Num"].ToString();
            //------------------------------------ end of sub profile 1 details ---------------------------------//

            //------------------------------------- sub profile 2 details ---------------------------------------//

            DataSet dssp2title = Queries3.LoadSalutations(Session["office"].ToString());
            subprofile2titleDropDownList.DataSource = dssp2title;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            subprofile2titleDropDownList.DataBind();

            sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();

            string dateSp2 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);
            if (dateSp2 == " " || dateSp2 == "01-01-1900")
            {
                sp2dobdatepicker.Text = "";
            }
            else
            {
                sp2dobdatepicker.Text = dateSp2;
            }
            TextSP2Age.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dssp2nationality = Queries.LoadSub_Profile2Nationality(Session["ProfileIDo"].ToString());
                subprofile2nationalityDropDownList.DataSource = dssp2nationality;
                subprofile2nationalityDropDownList.DataTextField = "Nationality_Name";
                subprofile2nationalityDropDownList.DataValueField = "Nationality_Name";
                subprofile2nationalityDropDownList.AppendDataBoundItems = true;
                subprofile2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
                subprofile2nationalityDropDownList.DataBind();

                DataSet dssp2country = Queries.LoadCountrySP2(Session["ProfileIDo"].ToString());
                SubProfile2CountryDropDownList.DataSource = dssp2country;
                SubProfile2CountryDropDownList.DataTextField = "country_name";
                SubProfile2CountryDropDownList.DataValueField = "country_name";
                SubProfile2CountryDropDownList.AppendDataBoundItems = true;
                SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
                SubProfile2CountryDropDownList.DataBind();

                DataSet dssp2m = Queries.LoadCountryWithCodeSP2Mobile(Session["sp2Country"].ToString());
                subprofile2mobileDropDownList.DataSource = dssp2m;
                subprofile2mobileDropDownList.DataTextField = "name";
                subprofile2mobileDropDownList.DataValueField = "name";
                subprofile2mobileDropDownList.AppendDataBoundItems = true;
                subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
                subprofile2mobileDropDownList.DataBind();

                sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();

                DataSet dssp2alt = Queries.LoadCountryWithCodeSP2Alt(Session["sp2Country"].ToString());//(ProfileID);
                subprofile2alternateDropDownList.DataSource = dssp2alt;
                subprofile2alternateDropDownList.DataTextField = "name";
                subprofile2alternateDropDownList.DataValueField = "name";
                subprofile2alternateDropDownList.AppendDataBoundItems = true;
                subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
                subprofile2alternateDropDownList.DataBind();

                sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            }
            else
            {
                DataSet sp2nat = Queries3.LoadNationalityWithoutPrevValSP2(Session["ProfileIDo"].ToString());
                subprofile2nationalityDropDownList.DataSource = sp2nat;
                subprofile2nationalityDropDownList.DataTextField = "nationality_name";
                subprofile2nationalityDropDownList.DataValueField = "nationality_name";
                subprofile2nationalityDropDownList.AppendDataBoundItems = true;
                subprofile2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
                subprofile2nationalityDropDownList.DataBind();

                SubProfile2CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());


                DataSet dssp2 = Queries3.LoadCountryWithCodeSP2Mobile(Session["ProfileIDo"].ToString());
                subprofile2mobileDropDownList.DataSource = dssp2;
                subprofile2mobileDropDownList.DataTextField = "name";
                subprofile2mobileDropDownList.DataValueField = "name";
                subprofile2mobileDropDownList.AppendDataBoundItems = true;
                subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
                subprofile2mobileDropDownList.DataBind();

                sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();

                DataSet dsspalt2 = Queries3.LoadCountryWithCodeSP2Alt(Session["ProfileIDo"].ToString());
                subprofile2alternateDropDownList.DataSource = dsspalt2;
                subprofile2alternateDropDownList.DataTextField = "name";
                subprofile2alternateDropDownList.DataValueField = "name";
                subprofile2alternateDropDownList.AppendDataBoundItems = true;
                subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
                subprofile2alternateDropDownList.DataBind();

                sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            }
            sp2emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            sp2emailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();

            TextBoxSP2IDType.Text = ds.Tables[0].Rows[0]["SP2_ID_Type"].ToString();
            TextBoxSP2ID.Text = ds.Tables[0].Rows[0]["SP2_ID_Num"].ToString();
            //--------------------------------------- end of sub profile 2 details ---------------------//


            //------------------------------------- sub profile 3 details ---------------------------------------//
            DataSet dssp3title = Queries3.LoadSalutations(Session["office"].ToString());
            SubP3TitleDropDownList.DataSource = dssp3title;
            SubP3TitleDropDownList.DataTextField = "Salutation";
            SubP3TitleDropDownList.DataValueField = "Salutation";
            SubP3TitleDropDownList.AppendDataBoundItems = true;
            SubP3TitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
            SubP3TitleDropDownList.DataBind();

            SubP3FnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            SubP3LnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();

            string dateSp3 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);
            if (dateSp3 == " " || dateSp3 == "01-01-1900")
            {
                SubP3DOB.Text = "";
            }
            else
            {
                SubP3DOB.Text = dateSp3;
            }

            TextSP3Age.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();


            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dssp3nationality = Queries.LoadSub_Profile3Nationality(Session["ProfileIDo"].ToString());
                SubP3NationalityDropDownList.DataSource = dssp3nationality;
                SubP3NationalityDropDownList.DataTextField = "Nationality_Name";
                SubP3NationalityDropDownList.DataValueField = "Nationality_Name";
                SubP3NationalityDropDownList.AppendDataBoundItems = true;
                SubP3NationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
                SubP3NationalityDropDownList.DataBind();


                DataSet dssp3country = Queries.LoadCountrySP3(Session["ProfileIDo"].ToString());
                SubP3CountryDropDownList.DataSource = dssp3country;
                SubP3CountryDropDownList.DataTextField = "country_name";
                SubP3CountryDropDownList.DataValueField = "country_name";
                SubP3CountryDropDownList.AppendDataBoundItems = true;
                SubP3CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
                SubP3CountryDropDownList.DataBind();

                DataSet dssp3m = Queries.LoadCountryWithCodeSP3Mobile(Session["sp3Country"].ToString());
                SubP3CCDropDownList.DataSource = dssp3m;
                SubP3CCDropDownList.DataTextField = "name";
                SubP3CCDropDownList.DataValueField = "name";
                SubP3CCDropDownList.AppendDataBoundItems = true;
                SubP3CCDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
                SubP3CCDropDownList.DataBind();

                SubP3MobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();

                DataSet dssp3alt = Queries.LoadCountryWithCodeSP3Alt(Session["sp3Country"].ToString());//(ProfileID);
                SubP3CCDropDownList2.DataSource = dssp3alt;
                SubP3CCDropDownList2.DataTextField = "name";
                SubP3CCDropDownList2.DataValueField = "name";
                SubP3CCDropDownList2.AppendDataBoundItems = true;
                SubP3CCDropDownList2.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
                SubP3CCDropDownList2.DataBind();

                SubP3AMobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
            }
            else
            {
                DataSet sp3nat = Queries3.LoadNationalityWithoutPrevValSP3(Session["ProfileIDo"].ToString());
                SubP3NationalityDropDownList.DataSource = sp3nat;
                SubP3NationalityDropDownList.DataTextField = "nationality_name";
                SubP3NationalityDropDownList.DataValueField = "nationality_name";
                SubP3NationalityDropDownList.AppendDataBoundItems = true;
                SubP3NationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
                SubP3NationalityDropDownList.DataBind();

                SubP3CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());

                DataSet dssp3 = Queries3.LoadCountryWithCodeSP3Mobile(Session["ProfileIDo"].ToString());
                SubP3CCDropDownList.DataSource = dssp3;
                SubP3CCDropDownList.DataTextField = "name";
                SubP3CCDropDownList.DataValueField = "name";
                SubP3CCDropDownList.AppendDataBoundItems = true;
                SubP3CCDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
                SubP3CCDropDownList.DataBind();

                SubP3MobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();

                DataSet dsspalt3 = Queries3.LoadCountryWithCodeSP3Alt(Session["ProfileIDo"].ToString());
                SubP3CCDropDownList2.DataSource = dsspalt3;
                SubP3CCDropDownList2.DataTextField = "name";
                SubP3CCDropDownList2.DataValueField = "name";
                SubP3CCDropDownList2.AppendDataBoundItems = true;
                SubP3CCDropDownList2.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
                SubP3CCDropDownList2.DataBind();

                SubP3AMobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

            }

            SubP3EmailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
            SubP3EmailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();

            TextBoxSP3IDType.Text = ds.Tables[0].Rows[0]["SP3_ID_Type"].ToString();
            TextBoxSP3ID.Text = ds.Tables[0].Rows[0]["SP3_ID_Num"].ToString();

            //--------------------------------------- end of sub profile 3 details ---------------------//


            //---------------------------------------  sub profile 4 details ---------------------//

            DataSet dssp4title = Queries3.LoadSalutations(Session["office"].ToString());
            SubP4TitleDropDownList.DataSource = dssp4title;
            SubP4TitleDropDownList.DataTextField = "Salutation";
            SubP4TitleDropDownList.DataValueField = "Salutation";
            SubP4TitleDropDownList.AppendDataBoundItems = true;
            SubP4TitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
            SubP4TitleDropDownList.DataBind();

            SubP4FnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            SubP4LnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();

            string dateSp4 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]);
            if (dateSp4 == " " || dateSp4 == "01-01-1900")
            {
                SubP4DOB.Text = "";
            }
            else
            {
                SubP4DOB.Text = dateSp4;
            }
            TextSP4Age.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

            if (Session["venueCountry"].ToString() == "India" || Session["venueCountry"].ToString() == "INDIA")
            {
                DataSet dssp4nationality = Queries.LoadSub_Profile4Nationality(Session["ProfileIDo"].ToString());
                SubP4NationalityDropDownList.DataSource = dssp4nationality;
                SubP4NationalityDropDownList.DataTextField = "Nationality_Name";
                SubP4NationalityDropDownList.DataValueField = "Nationality_Name";
                SubP4NationalityDropDownList.AppendDataBoundItems = true;
                SubP4NationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
                SubP4NationalityDropDownList.DataBind();

                DataSet dssp4country = Queries.LoadCountrySP4(Session["ProfileIDo"].ToString());
                SubP4CountryDropDownList.DataSource = dssp4country;
                SubP4CountryDropDownList.DataTextField = "country_name";
                SubP4CountryDropDownList.DataValueField = "country_name";
                SubP4CountryDropDownList.AppendDataBoundItems = true;
                SubP4CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
                SubP4CountryDropDownList.DataBind();

                DataSet dssp4m = Queries.LoadCountryWithCodeSP4Mobile(Session["sp4Country"].ToString());
                SubP4CCDropDownList.DataSource = dssp4m;
                SubP4CCDropDownList.DataTextField = "name";
                SubP4CCDropDownList.DataValueField = "name";
                SubP4CCDropDownList.AppendDataBoundItems = true;
                SubP4CCDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
                SubP4CCDropDownList.DataBind();

                SubP4MobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();

                DataSet dssp4alt = Queries.LoadCountryWithCodeSP4Alt(Session["sp4Country"].ToString());
                SubP4CCDropDownList2.DataSource = dssp4alt;
                SubP4CCDropDownList2.DataTextField = "name";
                SubP4CCDropDownList2.DataValueField = "name";
                SubP4CCDropDownList2.AppendDataBoundItems = true;
                SubP4CCDropDownList2.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
                SubP4CCDropDownList2.DataBind();

                SubP4AMobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();

            }
            else
            {
                DataSet sp4nat = Queries3.LoadNationalityWithoutPrevValSP4(Session["ProfileIDo"].ToString());
                SubP4NationalityDropDownList.DataSource = sp4nat;
                SubP4NationalityDropDownList.DataTextField = "nationality_name";
                SubP4NationalityDropDownList.DataValueField = "nationality_name";
                SubP4NationalityDropDownList.AppendDataBoundItems = true;
                SubP4NationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
                SubP4NationalityDropDownList.DataBind();

                SubP4CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());

                DataSet dssp4 = Queries3.LoadCountryWithCodeSP4Mobile(Session["ProfileIDo"].ToString());
                SubP4CCDropDownList.DataSource = dssp4;
                SubP4CCDropDownList.DataTextField = "name";
                SubP4CCDropDownList.DataValueField = "name";
                SubP4CCDropDownList.AppendDataBoundItems = true;
                SubP4CCDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
                SubP4CCDropDownList.DataBind();

                SubP4MobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();

                DataSet dsspalt4 = Queries3.LoadCountryWithCodeSP4Alt(Session["ProfileIDo"].ToString());
                SubP4CCDropDownList2.DataSource = dsspalt4;
                SubP4CCDropDownList2.DataTextField = "name";
                SubP4CCDropDownList2.DataValueField = "name";
                SubP4CCDropDownList2.AppendDataBoundItems = true;
                SubP4CCDropDownList2.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
                SubP4CCDropDownList2.DataBind();

                SubP4AMobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
            }

            SubP4EmailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
            SubP4EmailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

            TextBoxSP4IDType.Text = ds.Tables[0].Rows[0]["SP4_ID_Type"].ToString();
            TextBoxSP4ID.Text = ds.Tables[0].Rows[0]["SP4_ID_Num"].ToString();
            //--------------------------------------- end of sub profile 4 details ---------------------//


            // -------------------------------------- stay details -------------------------------------//
            hotelTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();

            string dateArrival = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]);
            if (dateArrival == " " || dateArrival == "01-01-1900")
            {
                checkindatedatepicker.Text = "";
            }
            else
            {
                checkindatedatepicker.Text = dateArrival;
            }


            string dateDepature = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);
            if (dateDepature == " " || dateDepature == "01-01-1900")
            {
                checkoutdatedatepicker.Text = "";
            }
            else
            {
                checkoutdatedatepicker.Text = dateDepature;
            }

            DataSet ds20 = Queries.LoadGuestStatus();
            gueststatusDropDownList.DataSource = ds20;
            gueststatusDropDownList.DataTextField = "Guest_Status_name";
            gueststatusDropDownList.DataValueField = "Guest_Status_name";
            gueststatusDropDownList.AppendDataBoundItems = true;
            gueststatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            gueststatusDropDownList.DataBind();

            salesrepDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());

            deckcheckintimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            deckcheckouttimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();

            string dateTour = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);

            if (dateTour == " " || dateTour == "01-01-1900")
            {
                tourdatedatepicker.Text = "";
            }
            else
            {
                tourdatedatepicker.Text = dateTour;
            }

            taxipriceInTextBox.Text = dsT.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            TaxiPriceOutTextBox.Text = dsT.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            TaxiRefInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            TaxiRefOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
            commentTextBox.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            comment2.Text = ds.Tables[0].Rows[0]["comment2"].ToString();

            DataSet dsepr = Queries3.LoadQStatus();
            QStatusDropDownList1.DataSource = dsepr;
            QStatusDropDownList1.DataTextField = "Qstatus_Name";
            QStatusDropDownList1.DataValueField = "Qstatus_Name";
            QStatusDropDownList1.AppendDataBoundItems = true;
            QStatusDropDownList1.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Qualified_Status"].ToString(), ""));
            QStatusDropDownList1.DataBind();

            string check = ds.Tables[0].Rows[0]["RegTerms"].ToString();

            if (check == "Y")
            {
                Regterms1.Checked = true;
            }
            else
            {
                Regterms1.Checked = false;
            }


            string check2 = ds.Tables[0].Rows[0]["RegTerms2"].ToString();

            if (check2 == "Y")
            {
                Regterms2.Checked = true;
            }
            else
            {
                Regterms2.Checked = false;
            }

            DataSet tdsgift1 = Queries3.LoadGiftOption(Session["office"].ToString());
            giftoptionDropDownList.DataSource = tdsgift1;
            giftoptionDropDownList.DataTextField = "item";
            giftoptionDropDownList.DataValueField = "item";
            giftoptionDropDownList.AppendDataBoundItems = true;
            giftoptionDropDownList.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList.DataBind();

            DataSet tdsgift2 = Queries3.LoadGiftOption(Session["office"].ToString());
            giftoptionDropDownList2.DataSource = tdsgift2;
            giftoptionDropDownList2.DataTextField = "item";
            giftoptionDropDownList2.DataValueField = "item";
            giftoptionDropDownList2.AppendDataBoundItems = true;
            giftoptionDropDownList2.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList2.DataBind();


            DataSet tdsgift3 = Queries3.LoadGiftOption(Session["office"].ToString());
            giftoptionDropDownList3.DataSource = tdsgift3;
            giftoptionDropDownList3.DataTextField = "item";
            giftoptionDropDownList3.DataValueField = "item";
            giftoptionDropDownList3.AppendDataBoundItems = true;
            giftoptionDropDownList3.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList3.DataBind();

            DataSet tdsgift4 = Queries3.LoadGiftOption(Session["office"].ToString());
            giftoptionDropDownList4.DataSource = tdsgift4;
            giftoptionDropDownList4.DataTextField = "item";
            giftoptionDropDownList4.DataValueField = "item";
            giftoptionDropDownList4.AppendDataBoundItems = true;
            giftoptionDropDownList4.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList4.DataBind();

            DataSet tdsgift5 = Queries3.LoadGiftOption(Session["office"].ToString());
            giftoptionDropDownList5.DataSource = tdsgift5;
            giftoptionDropDownList5.DataTextField = "item";
            giftoptionDropDownList5.DataValueField = "item";
            giftoptionDropDownList5.AppendDataBoundItems = true;
            giftoptionDropDownList5.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList5.DataBind();

            DataSet tdsgift6 = Queries3.LoadGiftOption(Session["office"].ToString());
            giftoptionDropDownList6.DataSource = tdsgift6;
            giftoptionDropDownList6.DataTextField = "item";
            giftoptionDropDownList6.DataValueField = "item";
            giftoptionDropDownList6.AppendDataBoundItems = true;
            giftoptionDropDownList6.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList6.DataBind();

            DataSet tdsgift7 = Queries3.LoadGiftOption(Session["office"].ToString());
            giftoptionDropDownList7.DataSource = tdsgift7;
            giftoptionDropDownList7.DataTextField = "item";
            giftoptionDropDownList7.DataValueField = "item";
            giftoptionDropDownList7.AppendDataBoundItems = true;
            giftoptionDropDownList7.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList7.DataBind();


            string[] ar = new string[10];
            string[] br = new string[10];
            string[] cr = new string[10];
            string[] dr = new string[10];
            string[] er = new string[10];

            Array.Clear(ar, 0, ar.Length);
            Array.Clear(br, 0, br.Length);
            Array.Clear(cr, 0, cr.Length);
            Array.Clear(dr, 0, dr.Length);
            Array.Clear(er, 0, er.Length);

            int i = 0;

            Session["ogiftprice1"] = ""; Session["ogiftprice2"] = ""; Session["ogiftprice3"] = ""; Session["ogiftprice4"] = ""; Session["ogiftprice5"] = ""; Session["ogiftprice6"] = ""; Session["ogiftprice7"] = "";
            Session["ovouchernoTextBox"] = ""; Session["ovouchernoTextBox2"] = ""; Session["ovouchernoTextBox3"] = ""; Session["ovouchernoTextBox4"] = ""; Session["ovouchernoTextBox5"] = ""; Session["ovouchernoTextBox6"] = ""; Session["ovouchernoTextBox7"] = "";
            Session["ogiftoptionDropDownList"] = ""; Session["ogiftoptionDropDownList2"] = ""; Session["ogiftoptionDropDownList3"] = ""; Session["ogiftoptionDropDownList4"] = ""; Session["ogiftoptionDropDownList5"] = ""; Session["ogiftoptionDropDownList6"] = ""; Session["ogiftoptionDropDownList7"] = "";

            SqlDataReader reader = Queries3.getgiftoption(ProfileID);
            while (reader.Read())
            {
                er[i] = reader.GetString(4);

                if (er[i] == (string)Session["ProfileIDo"])
                {

                    ar[i] = reader.GetString(0);
                    br[i] = reader.GetString(1);
                    cr[i] = reader.GetString(2);
                    dr[i] = reader.GetString(3);

                    //string id = "giftoptionDropDownList";
                }
                i++;

            }


            if (string.IsNullOrEmpty(ar[0]) == false)

            // if (ar[0] != "" || ar[0] != "null")
            {
                giftoptionDropDownList.Items.Clear();
                DataSet dsgift1 = Queries3.LoadGiftOption(Session["office"].ToString());
                giftoptionDropDownList.DataSource = dsgift1;
                giftoptionDropDownList.DataTextField = "item";
                giftoptionDropDownList.DataValueField = "item";
                giftoptionDropDownList.AppendDataBoundItems = true;

                giftoptionDropDownList.DataBind();
                giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                vouchernoTextBox.Text = br[0];
                string gift_p = dr[0];

                if (gift_p != "0")
                {
                    TextBoxGPrice1.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[0]));//string.Format("{0:n0}", dr[0]);//dr[0];
                }
                else
                {
                    TextBoxGPrice1.Text = "0";
                }

                Session["ogiftoptionDropDownList"] = ar[0];
                //ogiftoptionDropDownList = ar[0];
                Session["ovouchernoTextBox"] = br[0];
                // ovouchernoTextBox = br[0];
                TextBoxChargeBack.Text = cr[0];
                Session["ogiftprice1"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[0]));

            }

            if (string.IsNullOrEmpty(ar[1]) == false)
            //if (ar[1] != "" || ar[1] != null)
            {
                giftoptionDropDownList2.Items.Clear();
                DataSet dsgift2 = Queries3.LoadGiftOption(Session["office"].ToString());
                giftoptionDropDownList2.DataSource = dsgift2;
                giftoptionDropDownList2.DataTextField = "item";
                giftoptionDropDownList2.DataValueField = "item";
                giftoptionDropDownList2.AppendDataBoundItems = true;

                giftoptionDropDownList2.DataBind();
                giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                vouchernoTextBox2.Text = br[1];

                string gift_p = dr[1];

                if (gift_p != "0")
                {

                    TextBoxGPrice2.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1])); //dr[1];
                }
                else
                {
                    TextBoxGPrice2.Text = "0";
                }
                Session["ogiftoptionDropDownList2"] = ar[1];
                Session["ovouchernoTextBox2"] = br[1];
                Session["ogiftprice2"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];

            }


            if (string.IsNullOrEmpty(ar[2]) == false)
            //if (ar[2] != "" || ar[2] != null)
            {
                giftoptionDropDownList3.Items.Clear();
                DataSet dsgift3 = Queries3.LoadGiftOption(Session["office"].ToString());
                giftoptionDropDownList3.DataSource = dsgift3;
                giftoptionDropDownList3.DataTextField = "item";
                giftoptionDropDownList3.DataValueField = "item";
                giftoptionDropDownList3.AppendDataBoundItems = true;

                giftoptionDropDownList3.DataBind();
                giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                vouchernoTextBox3.Text = br[2];

                string gift_p = dr[2];

                if (gift_p != "0")
                {


                    TextBoxGPrice3.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[2]));//dr[2];
                }
                else
                {

                    TextBoxGPrice3.Text = "0";
                }
                Session["ogiftoptionDropDownList3"] = ar[2];
                Session["ovouchernoTextBox3"] = br[2];
                Session["ogiftprice3"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[2]));//dr[1];


            }


            if (string.IsNullOrEmpty(ar[3]) == false)
            //if (ar[3] != "" || ar[3] != null)
            {
                giftoptionDropDownList4.Items.Clear();
                DataSet dsgift4 = Queries3.LoadGiftOption(Session["office"].ToString());
                giftoptionDropDownList4.DataSource = dsgift4;
                giftoptionDropDownList4.DataTextField = "item";
                giftoptionDropDownList4.DataValueField = "item";
                giftoptionDropDownList4.AppendDataBoundItems = true;

                giftoptionDropDownList4.DataBind();
                giftoptionDropDownList4.Items.Insert(0, new ListItem(ar[3]));

                vouchernoTextBox4.Text = br[3];

                string gift_p = dr[3];

                if (gift_p != "0")
                {

                    TextBoxGPrice4.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[3])); //dr[3];
                }
                else
                {
                    TextBoxGPrice4.Text = "0";
                }

                Session["ogiftoptionDropDownList4"] = ar[3];
                Session["ovouchernoTextBox4"] = br[3];
                Session["ogiftprice4"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[3]));//dr[1];

            }

            if (string.IsNullOrEmpty(ar[4]) == false)
            // if (ar[4] != "" || ar[4] != null)
            {
                giftoptionDropDownList5.Items.Clear();
                DataSet dsgift5 = Queries3.LoadGiftOption(Session["office"].ToString());
                giftoptionDropDownList5.DataSource = dsgift5;
                giftoptionDropDownList5.DataTextField = "item";
                giftoptionDropDownList5.DataValueField = "item";
                giftoptionDropDownList5.AppendDataBoundItems = true;

                giftoptionDropDownList5.DataBind();
                giftoptionDropDownList5.Items.Insert(0, new ListItem(ar[4]));

                vouchernoTextBox5.Text = br[4];
                string gift_p = dr[4];

                if (gift_p != "0")
                {
                    TextBoxGPrice5.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[4]));//dr[4];
                }
                else
                {

                    TextBoxGPrice5.Text = "0";
                }

                Session["ogiftoptionDropDownList5"] = ar[4];
                Session["ovouchernoTextBox5"] = br[4];
                Session["ogiftprice5"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[4]));//dr[1];

            }

            if (string.IsNullOrEmpty(ar[5]) == false)
            //if (ar[5] != "" || ar[5] != null)
            {
                giftoptionDropDownList6.Items.Clear();
                DataSet dsgift6 = Queries3.LoadGiftOption(Session["office"].ToString());
                giftoptionDropDownList6.DataSource = dsgift6;
                giftoptionDropDownList6.DataTextField = "item";
                giftoptionDropDownList6.DataValueField = "item";
                giftoptionDropDownList6.AppendDataBoundItems = true;

                giftoptionDropDownList6.DataBind();
                giftoptionDropDownList6.Items.Insert(0, new ListItem(ar[5]));

                vouchernoTextBox6.Text = br[5];

                string gift_p = dr[5];

                if (gift_p != "0")
                {
                    TextBoxGPrice6.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[5])); //dr[5];
                }
                else
                {
                    TextBoxGPrice6.Text = "0";
                }

                Session["ogiftoptionDropDownList6"] = ar[5];
                Session["ovouchernoTextBox6"] = br[5];
                Session["ogiftprice6"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[5]));//dr[1];

            }

            if (string.IsNullOrEmpty(ar[6]) == false)
            //if (ar[6] != "" || ar[6] != null)
            {
                giftoptionDropDownList7.Items.Clear();
                DataSet dsgift7 = Queries3.LoadGiftOption(Session["office"].ToString());
                giftoptionDropDownList7.DataSource = dsgift7;
                giftoptionDropDownList7.DataTextField = "item";
                giftoptionDropDownList7.DataValueField = "item";
                giftoptionDropDownList7.AppendDataBoundItems = true;

                giftoptionDropDownList7.DataBind();
                giftoptionDropDownList7.Items.Insert(0, new ListItem(ar[6]));

                vouchernoTextBox7.Text = br[6];


                string gift_p = dr[6];

                if (gift_p != "0")
                {

                    TextBoxGPrice7.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[6]));//dr[6];
                }
                else
                {
                    TextBoxGPrice7.Text = "0";
                }

                Session["ogiftoptionDropDownList7"] = ar[6];
                Session["ovouchernoTextBox7"] = br[6];
                Session["ogiftprice7"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[6]));//dr[1];

            }
            //-------------------------------------------end of stay details ------------------------------//
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
       // try
      //  {
            //-------- session variables for profilem details ------------//
            Session["office"] = "";
            Session["oProfile_Venue_Country"] = ""; Session["oProfile_Venue"] = ""; Session["oProfile_Group_Venue"] = "";
            Session["oProfile_Marketing_Program"] = ""; Session["oAgent_marketingSource"] = ""; Session["oToName_sourceCode"] = "";
            Session["oToManager"] = ""; Session["oPromoSource"] = ""; Session["oTeleMarktAgent"] = ""; Session["oPreArrival"] = "";
            Session["oVerification"] = ""; Session["oGuestRelations"] = ""; Session["oProfile_Sub_Venue"] = "";
            Session["oProfile_Reception"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for primary  profile details ------------//
            Session["oProfile_Primary_Title"] = ""; Session["oProfile_Primary_Fname"] = ""; Session["oProfile_Primary_Lname"] = "";
            Session["oProfile_Primary_DOB"] = ""; Session["oProfile_Primary_Nationality"] = ""; Session["oProfile_Primary_Country"] = "";
            Session["oPrimary_Designation"] = ""; Session["oPrimary_Language"] = ""; Session["oPrimary_Age"] = "";

            Session["oPrimary_CC"] = ""; Session["oPrimary_Mobile"] = ""; Session["oPrimary_Alt_CC"] = ""; Session["oPrimary_Alternate"] = "";
            Session["oPrimary_Home_CC"] = ""; Session["oPrimary_Home"] = ""; Session["oPrimary_Office_CC"] = ""; Session["oPrimary_Office"] = "";
            Session["oPrimary_Email"] = ""; Session["oPrimary_Email2"] = ""; Session["oPrimary_ID_Type"] = ""; Session["oPrimary_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Secondary profile details ------------//
            Session["oProfile_Secondary_Title"] = ""; Session["oProfile_Secondary_Fname"] = ""; Session["oProfile_Secondary_Lname"] = "";
            Session["oProfile_Secondary_DOB"] = ""; Session["oProfile_Secondary_Nationality"] = ""; Session["oProfile_Secondary_Country"] = "";
            Session["oSecondary_Age"] = ""; Session["oSecondary_Designation"] = ""; Session["oSecondary_Language"] = "";

            Session["oSecondary_CC"] = ""; Session["oSecondary_Mobile"] = ""; Session["oSecondary_Alt_CC"] = ""; Session["oSecondary_Alternate"] = "";
            Session["oSecondary_Home_CC"] = ""; Session["oSecondary_Home"] = ""; Session["oSecondary_Office_CC"] = ""; Session["oSecondary_Office"] = "";
            Session["oSecondary_Email"] = ""; Session["oSecondary_Email2"] = ""; Session["oSecondary_ID_Type"] = ""; Session["oSecondary_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Sub profile 1 profile details ------------//
            Session["oSub_Profile1_Title"] = ""; Session["oSub_Profile1_Fname"] = ""; Session["oSub_Profile1_Lname"] = "";
            Session["oSub_Profile1_DOB"] = ""; Session["oSub_Profile1_Nationality"] = ""; Session["oSub_Profile1_Country"] = "";
            Session["oSub_Profile1_Age"] = ""; 

            Session["oSubprofile1_CC"] = ""; Session["oSubprofile1_Mobile"] = ""; Session["oSubprofile1_Alt_CC"] = ""; Session["oSubprofile1_Alternate"] = "";
            Session["oSubprofile1_Email"] = ""; Session["oSubprofile1_Email2"] = ""; Session["oSubprofile1_ID_Type"] = ""; Session["oSubprofile1_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Sub profile 2 profile details ------------//
            Session["oSub_Profile2_Title"] = ""; Session["oSub_Profile2_Fname"] = ""; Session["oSub_Profile2_Lname"] = "";
            Session["oSub_Profile2_DOB"] = ""; Session["oSub_Profile2_Nationality"] = ""; Session["oSub_Profile2_Country"] = "";
            Session["oSub_Profile2_Age"] = ""; 

            Session["oSubprofile2_CC"] = ""; Session["oSubprofile2_Mobile"] = ""; Session["oSubprofile2_Alt_CC"] = ""; Session["oSubprofile2_Alternate"] = "";
            Session["oSubprofile2_Email"] = ""; Session["oSubprofile2_Email2"] = ""; Session["oSubprofile2_ID_Type"] = ""; Session["oSubprofile2_ID_Num"] = "";
            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for Sub profile 3 profile details ------------//
            Session["oSub_Profile3_Title"] = ""; Session["oSub_Profile3_Fname"] = ""; Session["oSub_Profile3_Lname"] = "";
            Session["oSub_Profile3_DOB"] = ""; Session["oSub_Profile3_Nationality"] = ""; Session["oSub_Profile3_Country"] = "";
            Session["oSub_Profile3_Age"] = "";

            Session["oSubprofile3_CC"] = ""; Session["oSubprofile3_Mobile"] = ""; Session["oSubprofile3_Alt_CC"] = "";
            Session["oSubprofile3_Alternate"] = "";
            Session["oSubprofile3_Email"] = ""; Session["oSubprofile3_Email2"] = ""; Session["oSubprofile3_ID_Type"] = ""; Session["oSubprofile3_ID_Num"] = "";
            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for Sub profile 4 profile details ------------//
            Session["oSub_Profile4_Title"] = ""; Session["oSub_Profile4_Fname"] = ""; Session["oSub_Profile4_Lname"] = "";
            Session["oSub_Profile4_DOB"] = ""; Session["oSub_Profile4_Nationality"] = ""; Session["oSub_Profile4_Country"] = "";
            Session["oSub_Profile4_Age"] = ""; 
            Session["oSubprofile4_CC"] = ""; Session["oSubprofile4_Mobile"] = ""; Session["oSubprofile4_Alt_CC"] = "";
            Session["oSubprofile4_Alternate"] = "";
            Session["oSubprofile4_Email"] = ""; Session["oSubprofile4_Email2"] = ""; Session["oSubprofile4_ID_Type"] = ""; Session["oSubprofile4_ID_Num"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//

            //-------- session variables for Address details ------------//

            Session["oProfile_Address_Line1"] = ""; Session["oProfile_Address_Line2"] = ""; Session["oSecond_Employment_status"] = "";
            Session["oProfile_Address_State"] = ""; Session["oProfile_Address_city"] = ""; Session["oProfile_Address_Postcode"] = "";
            Session["oProfile_Employment_status"] = ""; Session["oProfile_Marital_status"] = ""; Session["oProfile_NOY_Living_as_couple"] = "";

            Session["oProfile_Photo_Identity"] = ""; Session["oProfile_Card"] = "";

            //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


            //-------- session variables for Stay details ------------//
            Session["oResort_Name"] = ""; Session["oResort_RoomNo"] = ""; Session["oArrival_Date"] = ""; Session["oDepature_Date"] = "";

            Session["oGuest_Status"] = ""; Session["oSales_Rep"] = ""; Session["oTour_Date"] = ""; Session["oCheck_In_Time"] = "";
            Session["oCheck_Out_Time"] = ""; Session["oTaxi_In_Price"] = ""; Session["oTaxi_Out_Price"] = ""; Session["oTaxi_In_Ref"] = "";
            Session["oTaxi_Out_Ref"] = ""; Session["oQstatus"] = ""; Session["oWeekNo"] = ""; Session["oComments"] = ""; Session["oComments2"] = "";
        Session["oRegTerms"] = ""; Session["oRegTerms2"] = "";

        //--------------------------XXXXXXXXXXXXXXXXXXX---------------------------------------//


        // --------------------------- profile details --------------------------------//
        DataSet ds = Queries3.LoadProfielDetailsFull(ProfileIDTextBox.Text);
            Session["office"] = ds.Tables[0].Rows[0]["Office"].ToString();
            Session["oProfile_Venue_Country"] = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
            Session["oProfile_Venue"] = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
            Session["oProfile_Group_Venue"] = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            Session["oProfile_Sub_Venue"] = ds.Tables[0].Rows[0]["SubVenue"].ToString();
            Session["oProfile_Marketing_Program"] = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
            Session["oAgent_marketingSource"] = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
            Session["oToName_sourceCode"] = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
            Session["oToManager"] = ds.Tables[0].Rows[0]["Manager"].ToString();

            Session["oPromoSource"] = ds.Tables[0].Rows[0]["Promo_Source"].ToString();
            Session["oTeleMarktAgent"] = ds.Tables[0].Rows[0]["Tele_Agent"].ToString();
            Session["oPreArrival"] = ds.Tables[0].Rows[0]["Pre_Arrival"].ToString();
            Session["oVerification"] = ds.Tables[0].Rows[0]["Verification"].ToString();
            Session["oGuestRelations"] = ds.Tables[0].Rows[0]["Lead_Source"].ToString();
            Session["oProfile_Reception"] = ds.Tables[0].Rows[0]["Reception"].ToString();
            //-----------------------------------XXXXXXXXX-------------------------------------//


            //--------------------------------------profile primary -----------------------------//
            Session["oProfile_Primary_Title"] = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            Session["oProfile_Primary_Fname"] = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            Session["oProfile_Primary_Lname"] = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            Session["oProfile_Primary_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oPrimary_Age"] = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            Session["oProfile_Primary_Nationality"] = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            Session["oProfile_Primary_Country"] = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();

            Session["oPrimary_Designation"] = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
            Session["oPrimary_Language"] = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

            Session["oPrimary_CC"] = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
            Session["oPrimary_Mobile"] = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            Session["oPrimary_Alt_CC"] = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
            Session["oPrimary_Alternate"] = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();

            Session["oPrimary_Home_CC"] = ds.Tables[0].Rows[0]["Primary_home_CC"].ToString();
            Session["oPrimary_Home"] = ds.Tables[0].Rows[0]["Primary_home_num"].ToString();

            Session["oPrimary_Office_CC"] = ds.Tables[0].Rows[0]["Primary_office_CC"].ToString();
            Session["oPrimary_Office"] = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();
            
            Session["oPrimary_Email"] = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            Session["oPrimary_Email2"] = ds.Tables[0].Rows[0]["Primary_Email2"].ToString();

            Session["oPrimary_ID_Type"] = ds.Tables[0].Rows[0]["Primary_ID_Type"].ToString();
            Session["oPrimary_ID_Num"] = ds.Tables[0].Rows[0]["Primary_ID_Num"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Secondary -----------------------------//
            Session["oProfile_Secondary_Title"] = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            Session["oProfile_Secondary_Fname"] = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            Session["oProfile_Secondary_Lname"] = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            Session["oProfile_Secondary_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSecondary_Age"] = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            Session["oProfile_Secondary_Nationality"] = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            Session["oProfile_Secondary_Country"] = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();

            Session["oSecondary_Designation"] = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
            Session["oSecondary_Language"] = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

            Session["oSecondary_CC"] = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
            Session["oSecondary_Mobile"] = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            Session["oSecondary_Alt_CC"] = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
            Session["oSecondary_Alternate"] = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();

            Session["oSecondary_Home_CC"] = ds.Tables[0].Rows[0]["Secondary_home_CC"].ToString();
            Session["oSecondary_Home"] = ds.Tables[0].Rows[0]["Secondary_home_num"].ToString();

            Session["oSecondary_Office_CC"] = ds.Tables[0].Rows[0]["Secondary_office_CC"].ToString();
            Session["oSecondary_Office"] = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();

            Session["oSecondary_Email"] = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            Session["oSecondary_Email2"] = ds.Tables[0].Rows[0]["Secondary_Email2"].ToString();

            Session["oSecondary_ID_Type"] = ds.Tables[0].Rows[0]["Secondary_ID_Type"].ToString();
            Session["oSecondary_ID_Num"] = ds.Tables[0].Rows[0]["Secondary_ID_Num"].ToString();
            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Sub 1 -----------------------------//

            Session["oSub_Profile1_Title"] = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            Session["oSub_Profile1_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            Session["oSub_Profile1_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            Session["oSub_Profile1_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);//Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile1_Age"]= ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

            Session["oSub_Profile1_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            Session["oSub_Profile1_Country"] = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();



            Session["oSubprofile1_CC"] = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
            Session["oSubprofile1_Mobile"] = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            Session["oSubprofile1_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
            Session["oSubprofile1_Alternate"] = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();

            Session["oSubprofile1_Email"] = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            Session["oSubprofile1_Email2"] = ds.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

            Session["oSubprofile1_ID_Type"] = ds.Tables[0].Rows[0]["SP1_ID_Type"].ToString();
            Session["oSubprofile1_ID_Num"] = ds.Tables[0].Rows[0]["SP1_ID_Num"].ToString();
            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Sub 2 -----------------------------//
            Session["oSub_Profile2_Title"] = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            Session["oSub_Profile2_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            Session["oSub_Profile2_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            Session["oSub_Profile2_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile2_Age"] = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            Session["oSub_Profile2_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            Session["oSub_Profile2_Country"] = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();

            Session["oSubprofile2_CC"] = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
            Session["oSubprofile2_Mobile"] = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            Session["oSubprofile2_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
            Session["oSubprofile2_Alternate"] = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

            Session["oSubprofile2_Email"] = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            Session["oSubprofile2_Email2"] = ds.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();


            Session["oSubprofile2_ID_Type"] = ds.Tables[0].Rows[0]["SP2_ID_Type"].ToString();
            Session["oSubprofile2_ID_Num"] = ds.Tables[0].Rows[0]["SP2_ID_Num"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile Sub 3 -----------------------------//

            Session["oSub_Profile3_Title"] = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
            Session["oSub_Profile3_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();

            Session["oSub_Profile3_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
            Session["oSub_Profile3_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);  //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile3_Age"] = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();
            Session["oSub_Profile3_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
            Session["oSub_Profile3_Country"] = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();

            Session["oSubprofile3_CC"] = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
            Session["oSubprofile3_Mobile"] = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
            Session["oSubprofile3_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
            Session["oSubprofile3_Alternate"] = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

            Session["oSubprofile3_Email"] = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
            Session["oSubprofile3_Email2"] = ds.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();

            Session["oSubprofile2_ID_Type"] = ds.Tables[0].Rows[0]["SP2_ID_Type"].ToString();
            Session["oSubprofile2_ID_Num"] = ds.Tables[0].Rows[0]["SP2_ID_Num"].ToString();
            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//



            //--------------------------------------profile Sub 4 -----------------------------//
            Session["oSub_Profile4_Title"] = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
            Session["oSub_Profile4_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();

            Session["oSub_Profile4_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
            Session["oSub_Profile4_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
            Session["oSub_Profile4_Age"]= ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();
            Session["oSub_Profile4_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
            Session["oSub_Profile4_Country"] = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();

            Session["oSubprofile4_CC"] = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
            Session["oSubprofile4_Mobile"] = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
            Session["oSubprofile4_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
            Session["oSubprofile4_Alternate"] = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();

            Session["oSubprofile4_Email"] = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
            Session["oSubprofile4_Email2"] = ds.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//


            //--------------------------------------profile Address details-----------------------------//
            Session["oProfile_Address_Line1"] = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            Session["oProfile_Address_Line2"] = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            Session["oProfile_Address_Country"] = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();
            Session["oProfile_Address_State"] = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            Session["oProfile_Address_city"] = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            Session["oProfile_Address_Postcode"] = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            Session["oProfile_Employment_status"] = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            Session["oSecond_Employment_status"] = ds.Tables[0].Rows[0]["Secondary_Employment_Status"].ToString(); 
            Session["oProfile_Marital_status"] = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            Session["oProfile_NOY_Living_as_couple"] = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            Session["oProfile_Photo_Identity"] = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
            Session["oProfile_Card"] = ds.Tables[0].Rows[0]["Card_Holder"].ToString();

            //--------------------------------------XXXXXXXXXXXXXXX--------------------------//

            //--------------------------------------profile stay details-----------------------------//

            Session["oResort_Name"] = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            Session["oResort_RoomNo"] = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            Session["oArrival_Date"] = ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
            Session["oDepature_Date"] = ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();

            Session["oGuest_Status"] = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
            Session["oSales_Rep"] = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
            Session["oTour_Date"] = ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString();
            Session["oCheck_In_Time"] = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            Session["oCheck_Out_Time"] = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            Session["oTaxi_In_Price"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            Session["oTaxi_Out_Price"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            Session["oTaxi_In_Ref"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            Session["oTaxi_Out_Ref"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
            Session["oQstatus"] = ds.Tables[0].Rows[0]["Tour_Details_Qualified_Status"].ToString();
            Session["oWeekNo"] = ds.Tables[0].Rows[0]["Week_number"].ToString();
            Session["oComments"] = ds.Tables[0].Rows[0]["Comments"].ToString();
            Session["oComments2"] = ds.Tables[0].Rows[0]["comment2"].ToString();
            Session["oRegTerms"]= ds.Tables[0].Rows[0]["RegTerms"].ToString();
            Session["oRegTerms2"] = ds.Tables[0].Rows[0]["RegTerms2"].ToString();
        // --------------------------------------XXXXXXXXXXXXXXX--------------------------//

        string user = (string)Session["username"];
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
           

            string office = Queries.GetOfficeOnVenueCountry(venuecountry);
           // int year = DateTime.Now.Year;
            Session["ProfileID"] = ProfileIDTextBox.Text;
            string reception = ReceptionistDropDownList.SelectedItem.Text;
           
            string venue = VenueDropDownList.SelectedItem.Text; //Request.Form[VenueDropDownList.UniqueID];
            string venueGroup = Request.Form[GroupVenueDropDownList.UniqueID];
             string subVenue;// Request.Form[VenueDropDownList2.UniqueID];// VenueDropDownList2.SelectedItem.Text;// 
            if (venuecountry == "India" || venuecountry == "INDIA")
             {
                  subVenue = Request.Form[VenueDropDownList2.UniqueID];
                   if (subVenue == "" || subVenue == null)
                     {
                        subVenue = VenueDropDownList2.Items[0].Text;
                      }
                    else
                      {
                         subVenue = Request.Form[VenueDropDownList2.UniqueID];
                       }

             }
             else
             {
                       subVenue = VenueDropDownList2.SelectedItem.Text;
                      if (subVenue == "" || subVenue == null)
                      {
                          subVenue = "";
                      }
                      else
                      {
                           subVenue = VenueDropDownList2.SelectedItem.Text;
                      }
              }


           

         string marketingProgram= Request.Form[MarketingPrgmDropDownList.UniqueID];

          if (venuecountry == "India" || venuecountry == "INDIA")
        {
            if (venueGroup == "Coldline" || venueGroup == "COLDLINE")
            {
                if (marketingProgram == "")
                {
                    marketingProgram = MarketingPrgmDropDownList.Items[0].Text;

                    // mktg = Queries.getMarketingAbbOnMarketingProgram(venue, venuegroup, mktg);

                }
                else
                {
                    marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];
                }
            }
            else
            {
                if (marketingProgram == "")
                {
                    marketingProgram = MarketingPrgmDropDownList.Items[0].Text;
                    marketingProgram = Queries3.getMarketingAbbOnMarketingProgram(venue, venueGroup, marketingProgram);

                }
                else
                {
                    marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];
                    marketingProgram = Queries3.getMarketingAbbOnMarketingProgram(venue, venueGroup, marketingProgram);
                }
            }
        }
        else
        {
            marketingProgram = Request.Form[MarketingPrgmDropDownList.UniqueID];

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

          //  string guestRelations = DropDownListFly.SelectedItem.Text;

          string guestRelations="";

          if (venuecountry == "India" || venuecountry == "INDIA")
        {
            if ((venueGroup == "Inhouse" || venueGroup == "INHOUSE") && (TextBox2.Text == "CANCELLED MEMBER" || TextBox2.Text == "Cancelled Member"))
            {
                guestRelations = "";
            }
            else if ((venueGroup == "Inhouse" || venueGroup == "INHOUSE") && (TextBox2.Text == "REVOKED MEMBER" || TextBox2.Text == "Revoked Member"))
            {
                guestRelations = "MRG";

            }
            else
            {
                guestRelations = "";
            }

        }
        else
        {

            guestRelations = DropDownListFly.SelectedItem.Text;
        }


        string subVenueGroup = Request.Form["subGroup"];
            if (subVenueGroup == "" || subVenueGroup == null)
            {
            subVenueGroup = subGroup.Items[0].Value;
            }
            else
            {
            subVenueGroup = Request.Form["subGroup"];
            }


            string leadOffices = "";
            if (venueGroup == "Inhouse" || venueGroup == "INHOUSE")
            {
            leadOffices = "";
            }
            else if (venueGroup == "FlyBuy" || venueGroup == "FLYBUY" || venueGroup == "CallCenter")
            {
            leadOffices = Request.Form["leadOffice"];
            if (leadOffices == "" || leadOffices == null)
            {
                leadOffices = leadOffice.Items[0].Text;
            }
            else
            {
                leadOffices = Request.Form["leadOffice"];
            }
            }

        //string membertype1, memno1;
        //if (venuecountry == "India" || venuecountry == "INDIA")
        //{
        //    if (marketingProgram == "Owner" || marketingProgram == "OWNER")
        //    {
        //        membertype1 = MemType1DropDownList.SelectedItem.Text;
        //        string memno = Memno1TextBox.Text.ToUpper();
        //        if (memno == null || memno == "")
        //        {
        //            memno1 = "";
        //        }
        //        else
        //        {
        //            memno1 = Memno1TextBox.Text;
        //        }

        //    }
        //    else
        //    {
        //        membertype1 = MemType1DropDownList.SelectedItem.Text;
        //        string memno = Request.Form[TypeDropDownList.UniqueID];//TypeDropDownList.SelectedItem.Text;
        //        if (memno == null || memno == "")
        //        {

        //            memno1 = "";
        //        }
        //        else
        //        {

        //            memno1 = Request.Form[TypeDropDownList.UniqueID];
        //        }


        //    }
        //}
        //else
        //{
        //    membertype1 = "";
        //    memno1 = "";
        //}


        // Primary Profile Details //
        string primaryTitle = primarytitleDropDownList.SelectedItem.Text; // Request.Form[primarytitleDropDownList.UniqueID]; // // 
           

            string primaryLastName = plnameTextBox.Text;
            string primaryFirstName = pfnameTextBox.Text;
            string primaryDateOfBirth = pdobdatepicker.Text;
            string primaryAge = TextPrimaryAge.Text;
            string primaryEmploymentStatus = employmentstatusDropDownList.SelectedItem.Text;
            string primaryNationality = primarynationalityDropDownList.SelectedItem.Text;    // Request.Form[primarynationalityDropDownList.UniqueID];//
           
            string primaryCountry = Request.Form[PrimaryCountryDropDownList.UniqueID]; //PrimaryCountryDropDownList.SelectedItem.Text; // 

            if (primaryCountry == "" || primaryCountry == null)
            {
                primaryCountry = PrimaryCountryDropDownList.SelectedItem.Text;
            }
            else
            {
                primaryCountry = Request.Form[PrimaryCountryDropDownList.UniqueID];
            }

            string primaryMobileCode="", primaryMobileNumber="", primaryAlternateCode="", PrimaryAlternateNumber="", primaryHomeCode="",
                primaryHomeNumber="", primaryOfficeCode="", primaryOfficeNumber="";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                 primaryMobileCode = primarymobileDropDownList.SelectedItem.Text; // Request.Form[primarymobileDropDownList.UniqueID];
                 primaryMobileNumber = pmobileTextBox.Text;

                 primaryAlternateCode = primaryalternateDropDownList.SelectedItem.Text;// Request.Form[primaryalternateDropDownList.UniqueID];
                 PrimaryAlternateNumber = palternateTextBox.Text;

                 primaryHomeCode = phomecodeDropDownList.SelectedItem.Text;// Request.Form[phomecodeDropDownList.UniqueID];
                 primaryHomeNumber = phomenoTextBox.Text;

                 primaryOfficeCode = pofficecodeDropDownList.SelectedItem.Text;// Request.Form[pofficecodeDropDownList.UniqueID];
                 primaryOfficeNumber = pofficenoTextBox.Text;
            }
            else
            {
                 primaryMobileCode = primarymobileDropDownList.SelectedItem.Text; // Request.Form[primarymobileDropDownList.UniqueID];

                 if (String.Compare((string)Session["oPrimary_CC"], primaryMobileCode) != 0)
                 {
                 string  pcc1 = Queries3.getcountrycodefromstring(primaryMobileCode);
                  primaryMobileCode = pcc1;
                 }

                 primaryMobileNumber = pmobileTextBox.Text;

                  primaryAlternateCode = primaryalternateDropDownList.SelectedItem.Text;// Request.Form[primaryalternateDropDownList.UniqueID];
                  if (String.Compare((string)Session["oPrimary_Alt_CC"], primaryAlternateCode) != 0)
                  {
                   string  paltrcc1 = Queries3.getcountrycodefromstring(primaryAlternateCode);
                   primaryAlternateCode = paltrcc1;
                  }
                  PrimaryAlternateNumber = palternateTextBox.Text;

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
            ////--------------------------------------------//

            //// Secondary Profile Details //
            string secondaryTitle = secondarytitleDropDownList.SelectedItem.Text; // Request.Form[secondarytitleDropDownList.UniqueID];
            string secondaryFirstName = sfnameTextBox.Text;
            string secondaryLastName = slnameTextBox.Text;
            string secondaryDateOfBirth = sdobdatepicker.Text;
            string secondaryAge = TextSecondAge.Text;
            string secondaryEmploymentStatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            string secondaryNationality = secondarynationalityDropDownList.SelectedItem.Text;// Request.Form[secondarynationalityDropDownList.UniqueID];
            string secondaryCountry = Request.Form[SecondaryCountryDropDownList.UniqueID];// SecondaryCountryDropDownList.SelectedItem.Text;// 
            if (secondaryCountry == "" || secondaryCountry == null)
            {
                secondaryCountry = SecondaryCountryDropDownList.SelectedItem.Text;
            }
            else
            {
                secondaryCountry = Request.Form[SecondaryCountryDropDownList.UniqueID];
            }

            string secondaryMobileCode = "", secondaryMobileNumber = "", secondaryAlternateCode = "", secondaryAlternateNumber = "", secondaryHomeCode = "",
                secondaryHomeNumber = "", secondaryOfficeCode = "", secondaryOfficeNumber = "";
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                 secondaryMobileCode = secondarymobileDropDownList.SelectedItem.Text; // Request.Form[secondarymobileDropDownList.UniqueID];
                 secondaryMobileNumber = smobileTextBox.Text;

                 secondaryAlternateCode = secondaryalternateDropDownList.SelectedItem.Text; // Request.Form[secondaryalternateDropDownList.UniqueID];
                 secondaryAlternateNumber = salternateTextBox.Text;

                 secondaryHomeCode = shomecodeDropDownList.SelectedItem.Text; //Request.Form[shomecodeDropDownList.UniqueID];
                 secondaryHomeNumber = shomenoTextBox.Text;

                 secondaryOfficeCode = sofficecodeDropDownList.SelectedItem.Text;  // Request.Form[sofficecodeDropDownList.UniqueID];
                 secondaryOfficeNumber = sofficenoTextBox.Text;
            }
            else
            {
                 secondaryMobileCode = secondarymobileDropDownList.SelectedItem.Text; // Request.Form[secondarymobileDropDownList.UniqueID];

                 if (String.Compare((string)Session["oSecondary_CC"], secondaryMobileCode) != 0)
                 {
                    string  scc1 = Queries3.getcountrycodefromstring(secondaryMobileCode);
                    secondaryMobileCode = scc1;
                 }
                    secondaryMobileNumber = smobileTextBox.Text;

                 secondaryAlternateCode = secondaryalternateDropDownList.SelectedItem.Text; // Request.Form[secondaryalternateDropDownList.UniqueID];
                 if (String.Compare((string)Session["oSecondary_Alt_CC"], secondaryAlternateCode) != 0)
                 {
                  string  saltcc1 = Queries3.getcountrycodefromstring(secondaryAlternateCode);
                   secondaryAlternateCode = saltcc1;
                 }
                 secondaryAlternateNumber = salternateTextBox.Text;

             
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

            //------------------------- Address Details ---------------------------//

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

            string addressCountry = AddCountryDropDownList.SelectedItem.Text; //Request.Form[AddCountryDropDownList.UniqueID];
            string addressState;
            if (venuecountry == "India" || venuecountry == "INDIA")
            {
                addressState = StateDropDownList.SelectedItem.Text;// Request.Form[StateDropDownList.UniqueID];
              //  if (addressState == "" || addressState == null) { addressState = ""; } else { addressState = Request.Form[StateDropDownList.UniqueID]; }
            }
            else
            {
                addressState = stateTextBox.Text;
            }

            string addressCity = cityTextBox.Text;
            string addressPincode = pincodeTextBox.Text;
            string martialStatus = MaritalStatusDropDownList.SelectedItem.Text;
            string livingYears = livingyrsTextBox.Text;

            ////--------------------------------------------//

            //// Sub Profile 1 Profile Details //

            string subProfileTitle = subprofile1titleDropDownList.SelectedItem.Text;// Request.Form[subprofile1titleDropDownList.UniqueID];
            string subProfileFirstName = sp1fnameTextBox.Text;
            string subProfileLastName = sp1lnameTextBox.Text;
            string subProfileDateOfBirth = sp1dobdatepicker.Text;
            string subProfileAge = TextSP1Age.Text;

            string subProfileNationality = subprofile1nationalityDropDownList.SelectedItem.Text;// Request.Form[subprofile1nationalityDropDownList.UniqueID];
            string subProfileCountry = Request.Form[SubProfile1CountryDropDownList.UniqueID];// SubProfile1CountryDropDownList.SelectedItem.Text;// 
            if (subProfileCountry == "" || subProfileCountry == null)
            {
                subProfileCountry = SubProfile1CountryDropDownList.SelectedItem.Text;
            }
            else {
                subProfileCountry = Request.Form[SubProfile1CountryDropDownList.UniqueID];
            }
            string subProfileMobileCode = subprofile1mobileDropDownList.SelectedItem.Text;// Request.Form[subprofile1mobileDropDownList.UniqueID];
            if (String.Compare((string)Session["oSubprofile1_CC"], subProfileMobileCode) != 0)
            {
            string sp1cc1 = Queries3.getcountrycodefromstring(subProfileMobileCode);
            subProfileMobileCode = sp1cc1;
            }
            string subProfileMobileNumber = sp1mobileTextBox.Text;


            string subProfileAlternateCode = subprofile1alternateDropDownList.SelectedItem.Text;// Request.Form[subprofile1alternateDropDownList.UniqueID];
            if (String.Compare((string)Session["oSubprofile1_Alt_CC"], subProfileAlternateCode) != 0)
            {
            string sp1altcc1 = Queries3.getcountrycodefromstring(subProfileAlternateCode);
            subProfileAlternateCode = sp1altcc1;
            }
            string subProfileAlternateNumber = sp1alternateTextBox.Text;

            string subProfileEmail1 = sp1emailTextBox.Text;
            string subProfileEmail2 = sp1emailTextBox2.Text;

            string subProfileIDCardType = TextBoxSP1IDType.Text;
            string subProfileIDCardNumber = TextBoxSP1ID.Text;

            ////--------------------------------------------//


            //// Sub Profile 2 Profile Details //

            string subProfile2Title = subprofile2titleDropDownList.SelectedItem.Text;// Request.Form[subprofile2titleDropDownList.UniqueID];
            string subProfile2FirstName = sp2fnameTextBox.Text;
            string subProfile2LastName = sp2lnameTextBox.Text;
            string subProfile2DateOfBirth = sp2dobdatepicker.Text;
            string subProfile2Age = TextSP2Age.Text;

            string subProfile2Nationality = subprofile2nationalityDropDownList.SelectedItem.Text;// Request.Form[subprofile2nationalityDropDownList.UniqueID];
            string subProfile2Country = Request.Form[SubProfile2CountryDropDownList.UniqueID];// SubProfile2CountryDropDownList.SelectedItem.Text;// 
            if (subProfile2Country == "" || subProfile2Country == null)
            {
                subProfile2Country = SubProfile2CountryDropDownList.SelectedItem.Text;
            }
            else {
                subProfile2Country = Request.Form[SubProfile2CountryDropDownList.UniqueID];
            }
            string subProfile2MobileCode = subprofile2mobileDropDownList.SelectedItem.Text;// Request.Form[subprofile2mobileDropDownList.UniqueID];
            if (String.Compare((string)Session["oSubprofile2_CC"], subProfile2MobileCode) != 0)
            {
            string sp2cc1 = Queries3.getcountrycodefromstring(subProfile2MobileCode);
            subProfile2MobileCode = sp2cc1;
            }
            string subProfile2MobileNumber = sp2mobileTextBox.Text;

            string subProfile2AlternateCode = subprofile2alternateDropDownList.SelectedItem.Text;// Request.Form[subprofile2alternateDropDownList.UniqueID];
            if (String.Compare((string)Session["oSubprofile2_Alt_CC"], subProfile2AlternateCode) != 0)
            {
            string sp2altccc1 = Queries3.getcountrycodefromstring(subProfile2AlternateCode);
            subProfile2AlternateCode = sp2altccc1;
            }
            string subProfile2AlternateNumber = sp2alternateTextBox.Text;

            string subProfile2Email1 = sp2emailTextBox.Text;
            string subProfile2Email2 = sp2emailTextBox2.Text;

            string subProfile2IDCardType = TextBoxSP2IDType.Text;
            string subProfile2IDCardNumber = TextBoxSP2ID.Text;

            ////--------------------------------------------//

            //// Sub Profile 3 Profile Details //

            string subProfile3Title = SubP3TitleDropDownList.SelectedItem.Text;// Request.Form[SubP3TitleDropDownList.UniqueID];
            string subProfile3FirstName = SubP3FnameTextBox.Text;
            string subProfile3LastName = SubP3LnameTextBox.Text;
            string subProfile3DateOfBirth = SubP3DOB.Text;
            string subProfile3Age = TextSP3Age.Text;

            string subProfile3Nationality = SubP3NationalityDropDownList.SelectedItem.Text;// Request.Form[SubP3NationalityDropDownList.UniqueID];
            string subProfile3Country = Request.Form[SubP3CountryDropDownList.UniqueID];// SubP3CountryDropDownList.SelectedItem.Text;// 
            if (subProfile3Country == "" || subProfile3Country == null)
            {
                subProfile3Country = SubP3CountryDropDownList.SelectedItem.Text;
            }
            else
            {
                subProfile3Country = Request.Form[SubP3CountryDropDownList.UniqueID];
            }
            string subProfile3MobileCode = SubP3CCDropDownList.SelectedItem.Text;// Request.Form[SubP3CCDropDownList.UniqueID];
            if (String.Compare((string)Session["oSubprofile3_CC"], subProfile3MobileCode) != 0)
            {
            string sp3cc1 = Queries3.getcountrycodefromstring(subProfile3MobileCode);
            subProfile3MobileCode = sp3cc1;
            }
            string subProfile3MobileNumber = SubP3MobileTextBox.Text;

            string subProfile3AlternateCode = SubP3CCDropDownList2.SelectedItem.Text;// Request.Form[SubP3CCDropDownList2.UniqueID];
            if (String.Compare((string)Session["oSubprofile3_Alt_CC"], subProfile3AlternateCode) != 0)
            {
            string sp3altcc1 = Queries3.getcountrycodefromstring(subProfile3AlternateCode);
            subProfile3AlternateCode = sp3altcc1;
            }
            string subProfile3AlternateNumber = SubP3AMobileTextBox.Text;

            string subProfile3Email1 = SubP3EmailTextBox.Text;
            string subProfile3Email2 = SubP3EmailTextBox2.Text;

            string subProfile3IDCardType = TextBoxSP3IDType.Text;
            string subProfile3IDCardNumber = TextBoxSP3ID.Text;

            ////--------------------------------------------//

            //// Sub Profile 4 Profile Details //

            string subProfile4Title = SubP4TitleDropDownList.SelectedItem.Text; //Request.Form[SubP4TitleDropDownList.UniqueID];
            string subProfile4FirstName = SubP4FnameTextBox.Text;
            string subProfile4LastName = SubP4LnameTextBox.Text;
            string subProfile4DateOfBirth = SubP4DOB.Text;
            string subProfile4Age = TextSP4Age.Text;

            string subProfile4Nationality = SubP4NationalityDropDownList.SelectedItem.Text;// Request.Form[SubP4NationalityDropDownList.UniqueID];
            string subProfile4Country = Request.Form[SubP4CountryDropDownList.UniqueID]; //SubP4CountryDropDownList.SelectedItem.Text;// 
            if (subProfile4Country == "" || subProfile4Country == null)
            {
                subProfile4Country = SubP4CountryDropDownList.SelectedItem.Text;
            }
            else
            {
                subProfile4Country = Request.Form[SubP4CountryDropDownList.UniqueID];
            }
            string subProfile4MobileCode = SubP4CCDropDownList.SelectedItem.Text; //Request.Form[SubP4CCDropDownList.UniqueID];
            if (String.Compare((string)Session["oSubprofile4_CC"], subProfile4MobileCode) != 0)
            {
            string sp4cc1 = Queries3.getcountrycodefromstring(subProfile4MobileCode);
            subProfile4MobileCode = sp4cc1;
            }

            string subProfile4MobileNumber = SubP4MobileTextBox.Text;

            string subProfile4AlternateCode = SubP4CCDropDownList2.SelectedItem.Text;// Request.Form[SubP4CCDropDownList2.UniqueID];
            if (String.Compare((string)Session["oSubprofile4_Alt_CC"], subProfile4AlternateCode) != 0)
            {
            string sp4altcc1 = Queries3.getcountrycodefromstring(subProfile4AlternateCode);
            subProfile4AlternateCode = sp4altcc1;
            }
            string subProfile4AlternateNumber = SubP4AMobileTextBox.Text;

            string subProfile4Email1 = SubP4EmailTextBox.Text;
            string subProfile4Email2 = SubP4EmailTextBox2.Text;

            string subProfile4IDCardType = TextBoxSP4IDType.Text;
            string subProfile4IDCardNumber = TextBoxSP4ID.Text;

            ////--------------------------------------------//


            //// Profile Stay Details //

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
              
                arrivalDate = checkindatedatepicker.Text;
        }

            string departureDate;
            string departureDate1 = checkoutdatedatepicker.Text;
            if (departureDate1 == "" || departureDate1 == null)
            {
                departureDate = "";
            }
            else
            {
               // DateTime dtt1 = DateTime.ParseExact(departureDate1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                departureDate = checkoutdatedatepicker.Text;
        }



            ////---------------------------------//

            //// Profile Tour Details //

            string guestStatus = gueststatusDropDownList.SelectedItem.Text;
            string qStatus = QStatusDropDownList1.SelectedItem.Text;
            string checkInTime = deckcheckintimeTextBox.Text;
            string checkOutTime = deckcheckouttimeTextBox.Text;
            string salesRepresentative = Request.Form[salesrepDropDownList.UniqueID];// salesrepDropDownList.SelectedItem.Text;// 
            if (salesRepresentative == "" || salesRepresentative == null)
           { salesRepresentative = salesrepDropDownList.SelectedItem.Text;
               } else { salesRepresentative = Request.Form[salesrepDropDownList.UniqueID]; }
            string tourDate;
            int weekNo;
            if (tourdatedatepicker.Text == "" || tourdatedatepicker.Text == null || tourdatedatepicker.Text == "NaN")
            {
                tourDate = "";
                weekNo = 0;
            }
            else
            {
            //  DateTime dtt4 = DateTime.ParseExact(tourdatedatepicker.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                tourDate = tourdatedatepicker.Text;
                weekNo = Queries3.GetWkNumber(tourDate);

        }
            
            string taxiInPrice = taxipriceInTextBox.Text;
            string taxiInRef = TaxiRefInTextBox.Text;
            string taxiOutPrice = TaxiPriceOutTextBox.Text;
            string taxiOutRef = TaxiRefOutTextBox.Text;

            string comments = commentTextBox.Text;
            string comments2 = comment2.Text;
            ////---------------------------------//


            string gifto1, gifto2, gifto3, gifto4, gifto5, gifto6, gifto7;
            if (giftoptionDropDownList.SelectedItem.Text == "")
            {
                gifto1 = "";
            }
            else
            {
                gifto1 = giftoptionDropDownList.SelectedItem.Text;
            }

            if (giftoptionDropDownList2.SelectedItem.Text == "")
            {
                gifto2 = "";
            }
            else
            {
                gifto2 = giftoptionDropDownList2.SelectedItem.Text;
            }

            if (giftoptionDropDownList3.SelectedItem.Text == "")
            {
                gifto3 = "";
            }
            else
            {
                gifto3 = giftoptionDropDownList3.SelectedItem.Text;
            }
            if (giftoptionDropDownList4.SelectedItem.Text == "")
            {
                gifto4 = "";
            }
            else
            {
                gifto4 = giftoptionDropDownList4.SelectedItem.Text;
            }
            if (giftoptionDropDownList5.SelectedItem.Text == "")
            {
                gifto5 = "";
            }
            else
            {
                gifto5 = giftoptionDropDownList5.SelectedItem.Text;
            }
            if (giftoptionDropDownList6.SelectedItem.Text == "")
            {
                gifto6 = "";
            }
            else
            {
                gifto6 = giftoptionDropDownList6.SelectedItem.Text;
            }
            if (giftoptionDropDownList7.SelectedItem.Text == "")
            {
                gifto7 = "";
            }
            else
            {
                gifto7 = giftoptionDropDownList7.SelectedItem.Text;
            }

            string voucher1 = vouchernoTextBox.Text;
            string voucher2 = vouchernoTextBox2.Text;
            string voucher3 = vouchernoTextBox3.Text;
            string voucher4 = vouchernoTextBox4.Text;
            string voucher5 = vouchernoTextBox5.Text;
            string voucher6 = vouchernoTextBox6.Text;
            string voucher7 = vouchernoTextBox7.Text;



            string giftprice1 = TextBoxGPrice1.Text;

            string giftprice2 = TextBoxGPrice2.Text;
            string giftprice3 = TextBoxGPrice3.Text;
            string giftprice4 = TextBoxGPrice4.Text;
            string giftprice5 = TextBoxGPrice5.Text;
            string giftprice6 = TextBoxGPrice6.Text;
            string giftprice7 = TextBoxGPrice7.Text;

            if (giftprice1 == "")
            {
                giftprice1 = "0";
            }

            if (giftprice2 == "")
            {
                giftprice2 = "0";
            }

            if (giftprice3 == "")
            {
                giftprice3 = "0";
            }

            if (giftprice4 == "")
            {
                giftprice4 = "0";
            }

            if (giftprice5 == "")
            {
                giftprice5 = "0";
            }

            if (giftprice6 == "")
            {
                giftprice6 = "0";
            }

            if (giftprice7 == "")
            {
                giftprice7 = "0";
            }



            string chargeback = TextBoxChargeBack.Text;


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

            
            //----------------------------------- updation of profile details--------------------------//
            int updateprofile = Queries3.UpdateProfile(Session["ProfileID"].ToString(), venuecountry, venue, venueGroup, marketingProgram, agent_marketingSource, toName_sourceCode, primaryEmploymentStatus, martialStatus, livingYears, toManager, photoIdentity, card, comments.ToUpper(), reception, subVenue,regTerm1, viewPointID, regTerm2, secondaryEmploymentStatus, guestRelations, preArrival, verification, promoSource, teleMarketingAgent,comments2.ToUpper(),subVenueGroup,leadOffices);
            if (String.Compare((string)Session["oProfile_Venue_Country"], venuecountry) != 0)
            {
                string act = "venue country changed from:" + Session["oProfile_Venue_Country"] + "To:" + venuecountry;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                //int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Venue"], venue) != 0)
            {
                string act = "venue changed from:" + Session["oProfile_Venue"] + "To:" + venue;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            
            if (String.Compare((string)Session["oProfile_Group_Venue"], venueGroup) != 0)
            {
                string act = "venue group changed from:" + Session["oProfile_Group_Venue"] + "To:" + venueGroup;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Sub_Venue"], subVenue) != 0)
            {
                string act = "Sub venue changed from:" + Session["oProfile_Sub_Venue"] + "To:" + subVenue;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Marketing_Program"], marketingProgram) != 0)
            {
                string act = "marketing prgm changed from:" + Session["oProfile_Marketing_Program"] + "To:" + marketingProgram;
                int insertlog2 = Queries3.InsertContractLogs(Session["ProfileID"].ToString(), "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oAgent_marketingSource"], agent_marketingSource) != 0)
            {
                string act = "agent name changed from:" + Session["oAgent_marketingSource"] + "To:" + agent_marketingSource;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oToName_sourceCode"], toName_sourceCode) != 0)
            {
                string act = "To Name changed from:" + Session["oToName_sourceCode"] + "To:" + toName_sourceCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oToManager"], toManager) != 0)
            {
                string act = "To Manager changed from:" + Session["oToManager"] + "To:" + toManager;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oPromoSource"], promoSource) != 0)
            {
                string act = "Promo Source changed from:" + Session["oPromoSource"] + "To:" + promoSource;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oTeleMarktAgent"], teleMarketingAgent) != 0)
            {
                string act = "Tele Marketing Agent changed from:" + Session["oTeleMarktAgent"] + "To:" + teleMarketingAgent;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oPreArrival"], preArrival) != 0)
            {
                string act = "Pre Arrival changed from:" + Session["oPreArrival"] + "To:" + preArrival;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oVerification"], verification) != 0)
            {
                string act = "Verification changed from:" + Session["oVerification"] + "To:" + verification;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oGuestRelations"], guestRelations) != 0)
            {
                string act = "guest Relations changed from:" + Session["oGuestRelations"] + "To:" + guestRelations;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Reception"], reception) != 0)
            {
                string act = "Reception changed from:" + Session["oProfile_Reception"] + "To:" + reception;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            
            //--------------------------------------------XXXXXXXXXXXXXX------------------------------------------//

            //----------------------------------- updation of Primary Profile details--------------------------//
            int primary = Queries3.UpdateProfilePrimary(Session["ProfileID"].ToString(), primaryTitle, primaryFirstName.ToUpper(), primaryLastName.ToUpper(), primaryDateOfBirth, primaryNationality, primaryCountry, primaryAge, primaryDesignation.ToUpper(),primaryLanguage);

            if (String.Compare((string)Session["oProfile_Primary_Title"], primaryTitle) != 0)
            {
                string act = "primary title changed from:" + Session["oProfile_Primary_Title"] + "To:" + primaryTitle;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_Fname"], primaryFirstName.ToUpper()) != 0)
            {
                string act = "primary fname changed from:" + Session["oProfile_Primary_Fname"] + "To:" + primaryFirstName.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_Lname"], primaryLastName.ToUpper()) != 0)
            {
                string act = "primay lname changed from:" + Session["oProfile_Primary_Lname"] + "To:" + primaryLastName.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_DOB"], primaryDateOfBirth) != 0)
            {
                string act = "primary dob changed from:" + Session["oProfile_Primary_DOB"] + "To:" + primaryDateOfBirth;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oPrimary_Age"], primaryAge) != 0)
            {
                string act = "primary Age changed from:" + Session["oPrimary_Age"] + "To:" + primaryAge;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
           

            if (String.Compare((string)Session["oProfile_Primary_Nationality"], primaryNationality) != 0)
            {
                string act = "primary nationality changed from:" + Session["oProfile_Primary_Nationality"] + "To:" + primaryNationality;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oProfile_Primary_Country"], primaryCountry) != 0)
            {
                string act = "primary country changed from:" + Session["oProfile_Primary_Country"] + "To:" + primaryCountry;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oPrimary_Designation"], primaryDesignation.ToUpper()) != 0)
            {
                string act = "primary Designation changed from:" + Session["oPrimary_Designation"] + "To:" + primaryDesignation.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oPrimary_Language"], primaryLanguage) != 0)
            {
                string act = "primary Language changed from:" + Session["oPrimary_Language"] + "To:" + primaryLanguage;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            

          
            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//

            //----------------------------------- updation of Secondary Profile details--------------------------//
            int secondary1 = Queries3.checksubprofile("secondary", Session["ProfileID"].ToString());

            if (secondaryFirstName != "")
            {
                if (secondary1 == 0)
                {
                    int year = DateTime.Now.Year;
                    string secondaryprofileid = Queries.GetSecondaryProfileID(Session["office"].ToString());
                    int secondary = Queries3.InsertSecondaryProfile(secondaryprofileid, secondaryTitle, secondaryFirstName.ToUpper(), secondaryLastName.ToUpper(), secondaryDateOfBirth, secondaryNationality, secondaryCountry, Session["ProfileID"].ToString(), secondaryAge, secondaryDesignation.ToUpper(), secondaryLanguage);
                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondaryTitle + "," + "Fname:" + secondaryFirstName.ToUpper() + "," + "Lname:" + secondaryLastName.ToUpper() + "," + "DOB:" + secondaryDateOfBirth + "," + "nationality:" + secondaryNationality + "," + "Country:" + secondaryCountry + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + "Profile Secondary Age:" + secondaryAge+","+"Secondary Designation: "+secondaryDesignation.ToUpper()+","+"secondary language:"+secondaryLanguage;
                    int insertlog3 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log3, user, DateTime.Now.ToString());
                    int updates = Queries.UpdateSecondaryValue(Session["office"].ToString(), year);



                }

                else
                {
                    int secondary = Queries3.UpdateProfileSecondary(Session["ProfileID"].ToString(), secondaryTitle, secondaryFirstName.ToUpper(), secondaryLastName.ToUpper(), secondaryDateOfBirth, secondaryNationality, secondaryCountry, secondaryAge, secondaryDesignation.ToUpper(), secondaryLanguage);
                    if (String.Compare((string)Session["oProfile_Secondary_Title"], secondaryTitle) != 0)
                    {
                        string act = "secondary title changed from:" + Session["oProfile_Secondary_Title"] + "To:" + secondaryTitle;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oProfile_Secondary_Fname"], secondaryFirstName.ToUpper()) != 0)
                    {
                        string act = "secondary fname changed from:" + Session["oProfile_Secondary_Fname"] + "To:" + secondaryFirstName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oProfile_Secondary_Lname"], secondaryLastName.ToUpper()) != 0)
                    {
                        string act = "secondary lname changed from:" + Session["oProfile_Secondary_Lname"] + "To:" + secondaryLastName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oProfile_Secondary_DOB"], secondaryDateOfBirth) != 0)
                    {
                        string act = "secondary dob changed from:" + Session["oProfile_Secondary_DOB"] + "To:" + secondaryDateOfBirth;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSecondary_Age"], secondaryAge) != 0)
                    {
                        string act = "secondaryage changed from:" + Session["oSecondary_Age"] + "To:" + secondaryAge;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oProfile_Secondary_Nationality"], secondaryNationality) != 0)
                    {
                        string act = "secondary nationality changed from:" + Session["oProfile_Secondary_Nationality"] + "To:" + secondaryNationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oProfile_Secondary_Country"], secondaryCountry) != 0)
                    {
                        string act = "secondary country changed from:" + Session["oProfile_Secondary_Country"] + "To:" + secondaryCountry;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSecondary_Designation"], secondaryDesignation.ToUpper()) != 0)
                    {
                        string act = "secondary Designation changed from:" + Session["oSecondary_Designation"] + "To:" + secondaryDesignation.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSecondary_Language"], secondaryLanguage) != 0)
                    {
                        string act = "secondary Language changed from:" + Session["oSecondary_Language"] + "To:" + secondaryLanguage;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }


                  
                }

            }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//

            //----------------------------------- updation of Sub Profile 1 details------------------------------------------------//

            int subprofilecheck1 = Queries3.checksubprofile("SP1", Session["ProfileID"].ToString());
           

            if (subProfileTitle != "")
            {
                if (subprofilecheck1 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile1id = Queries.GetSubProfile1ID(Session["office"].ToString());
                    int subprofielid = Queries3.InsertSub_Profile1(subprofile1id, subProfileTitle, subProfileFirstName.ToUpper(), subProfileLastName.ToUpper(), subProfileDateOfBirth, subProfileNationality, subProfileCountry, Session["ProfileID"].ToString(), subProfileAge);
                    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + subProfileTitle + "," + "Fname:" + subProfileFirstName.ToUpper() + "," + "Lname:" + subProfileLastName.ToUpper() + "," + "DOB:" + subProfileDateOfBirth + "," + "nationality:" + subProfileNationality + "," + "Country:" + subProfileCountry + "," + "Profiel ID:" + Session["ProfileID"].ToString() + "," + "Sub Profile 1 Age:" + subProfileAge;
                    int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log5, user, DateTime.Now.ToString());
                    int updatesp2 = Queries.UpdateSubprofile1Value(Session["office"].ToString(), year);

                    
                }
                else
                {
                    int sp1 = Queries3.UpdateSubProfile1(Session["ProfileID"].ToString(), subProfileTitle, subProfileFirstName.ToUpper(), subProfileLastName.ToUpper(), subProfileDateOfBirth, subProfileNationality, subProfileCountry, subProfileAge);

                    if (String.Compare((string)Session["oSub_Profile1_Title"], subProfileTitle) != 0)
                    {
                        string act = "subprofile1 title changed from:" + Session["oSub_Profile1_Title"] + "To:" + subProfileTitle;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_Fname"], subProfileFirstName.ToUpper()) != 0)
                    {
                        string act = "subprofile1 fname changed from:" + Session["oSub_Profile1_Fname"] + "To:" + subProfileFirstName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_Lname"], subProfileLastName.ToUpper()) != 0)
                    {
                        string act = "subprofile1 lname changed from:" + Session["oSub_Profile1_Lname"] + "To:" + subProfileLastName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_DOB"], subProfileDateOfBirth) != 0)
                    {
                        string act = "subprofile1 dob changed from:" + Session["oSub_Profile1_DOB"] + "To:" + subProfileDateOfBirth;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile1_Age"], subProfileAge) != 0)
                    {
                        string act = "SubProfile1age changed from:" + Session["oSub_Profile1_Age"] + "To:" + subProfileAge;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile1_Nationality"], subProfileNationality) != 0)
                    {
                        string act = "subprofile1 nationality changed from:" + Session["oSub_Profile1_Nationality"] + "To:" + subProfileNationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile1_Country"], subProfileCountry) != 0)
                    {
                        string act = "subprofile1 country changed from:" + Session["oSub_Profile1_Country"] + "To:" + subProfileCountry;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    
                }

            }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//

            //----------------------------------- updation of Sub Profile 2 details------------------------------------------------//
            int subprofilecheck2 = Queries3.checksubprofile("SP2", Session["ProfileID"].ToString());

            if (subProfile2FirstName != "")
            {
                if (subprofilecheck2 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile2id = Queries.GetSubProfile2ID(Session["office"].ToString());
                    int subprofielid2 = Queries3.InsertSub_Profile2(subprofile2id, subProfile2Title, subProfile2FirstName.ToUpper(), subProfile2LastName.ToUpper(), subProfile2DateOfBirth, subProfile2Nationality, subProfile2Country, Session["ProfileID"].ToString(), subProfile2Age);
                    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + subProfile2Title + "," + "Fname:" + subProfile2FirstName.ToUpper() + "," + "Lname:" + subProfile2LastName.ToUpper() + "," + "DOB:" + subProfile2DateOfBirth + "," + "nationality:" + subProfile2Nationality + "," + "Country:" + subProfile2Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + "Sub Profile 2 Age:" + subProfile2Age;
                    int insertlog6 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log6, user, DateTime.Now.ToString());
                    int updatesp2 = Queries.UpdateSubprofile2Value(Session["office"].ToString(), year);

                  
                }
                else
                {
                    int sp2 = Queries3.UpdateSubProfile2(Session["ProfileID"].ToString(), subProfile2Title, subProfile2FirstName.ToUpper(), subProfile2LastName.ToUpper(), subProfile2DateOfBirth, subProfile2Nationality, subProfile2Country, subProfile2Age);
                    if (String.Compare((string)Session["oSub_Profile2_Title"], subProfile2Title) != 0)
                    {
                        string act = "subprofile2 title changed from:" + Session["oSub_Profile2_Title"] + "To:" + subProfile2Title;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile2_Fname"], subProfile2FirstName.ToUpper()) != 0)
                    {
                        string act = "subprofile2 fname changed from:" + Session["oSub_Profile2_Fname"] + "To:" + subProfile2FirstName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile2_Lname"], subProfile2LastName.ToUpper()) != 0)
                    {
                        string act = "subprofile2 lname changed from:" + Session["oSub_Profile2_Lname"] + "To:" + subProfile2LastName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile2_DOB"], subProfile2DateOfBirth) != 0)
                    {
                        string act = "subprofile2 dob changed from:" + Session["oSub_Profile2_DOB"] + "To:" + subProfile2DateOfBirth;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile2_Age"], subProfile2Age) != 0)
                    {
                        string act = "SubProfile2 age changed from:" + Session["oSub_Profile2_Age"] + "To:" + subProfile2Age;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile2_Nationality"], subProfile2Nationality) != 0)
                    {
                        string act = "subprofile2 nationality changed from:" + Session["oSub_Profile2_Nationality"] + "To:" + subProfile2Nationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile2_Country"], subProfile2Country) != 0)

                    {
                        string act = "subprofile2 country changed from:" + Session["oSub_Profile2_Country"] + "To:" + subProfile2Country;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    
                  
                }

            }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//

            //----------------------------------- updation of Sub Profile 3 details------------------------------------------------//
            int subprofilecheck3 = Queries3.checksubprofile("SP3", Session["ProfileID"].ToString());

            if (subProfile3FirstName != "")
            {
                if (subprofilecheck3 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile3id = Queries.GetSubProfile3ID(Session["office"].ToString());
                    int subprofielid3 = Queries3.InsertSub_Profile3(subprofile3id, subProfile3Title, subProfile3FirstName.ToUpper(), subProfile3LastName.ToUpper(), subProfile3DateOfBirth, subProfile3Nationality, subProfile3Country, Session["ProfileID"].ToString(), subProfile3Age);
                    string log11 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + subProfile3Title + "," + "Fname:" + subProfile3FirstName.ToUpper() + "," + "Lname:" + subProfile3LastName.ToUpper() + "," + "DOB:" + subProfile3DateOfBirth + "," + "nationality:" + subProfile3Nationality + "," + "Country:" + subProfile3Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + "Age:" + subProfile3Age;
                    int insertlog11 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log11, user, DateTime.Now.ToString());
                    int updatesp3 = Queries3.UpdateSubprofile3Value(Session["office"].ToString(), year);


                  
                }
                else
                {
                    int sp3 = Queries3.UpdateSubProfile3(Session["ProfileID"].ToString(),subProfile3Title,subProfile3FirstName.ToUpper() , subProfile3LastName.ToUpper(), subProfile3DateOfBirth, subProfile3Nationality, subProfile3Country, subProfile3Age);

                    if (String.Compare((string)Session["oSub_Profile3_Title"], subProfile3Title) != 0)
                    {
                        string act = "subprofile3 title changed from:" + Session["oSub_Profile3_Title"] + "To:" + subProfile3Title;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_Fname"], subProfile3FirstName.ToUpper()) != 0)
                    {
                        string act = "subprofile3 fname changed from:" + Session["oSub_Profile3_Fname"] + "To:" + subProfile3FirstName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_Lname"], subProfile3LastName.ToUpper()) != 0)
                    {
                        string act = "subprofile3 lname changed from:" + Session["oSub_Profile3_Lname"] + "To:" + subProfile3LastName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_DOB"], subProfile3DateOfBirth) != 0)
                    {
                        string act = "subprofile3 dob changed from:" + Session["oSub_Profile3_DOB"] + "To:" + subProfile3DateOfBirth;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile3_Age"], String.IsNullOrEmpty(subProfile3Age) ? "" : subProfile3Age) != 0)
                    {
                        string act = "Subprofile3age changed from:" + Session["oSub_Profile3_Age"] + "To:" + subProfile3Age;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile3_Nationality"], subProfile3Nationality) != 0)
                    {
                        string act = "subprofile3 nationality changed from:" + Session["oSub_Profile3_Nationality"] + "To:" + subProfile3Nationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile3_Country"], subProfile3Country) != 0)

                    {
                        string act = "subprofile3 country changed from:" + Session["oSub_Profile3_Country"] + "To:" + subProfile3Country;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                   
                }


            }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//

            //----------------------------------- updation of Sub Profile 4 details------------------------------------------------//
            int subprofilecheck4 = Queries3.checksubprofile("SP4", Session["ProfileID"].ToString());
            if (subProfile4FirstName != "")
            {
                if (subprofilecheck4 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile4id = Queries.GetSubProfile4ID(Session["office"].ToString());
                    int subprofielid4 = Queries3.InsertSub_Profile4(subprofile4id, subProfile4Title, subProfile4FirstName.ToUpper(), subProfile4LastName.ToUpper(),subProfile4DateOfBirth,subProfile4Nationality, subProfile4Country, Session["ProfileID"].ToString(), subProfile4Age);
                    string log12 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + subProfile4Title + "," + "Fname:" + subProfile4FirstName.ToUpper() + "," + "Lname:" + subProfile4LastName.ToUpper() + "," + "DOB:" + subProfile4DateOfBirth + "," + "nationality:" + subProfile4Nationality + "," + "Country:" + subProfile4Country + "," + "Profile ID:" + Session["ProfileID"].ToString() + "," + "Age:" + subProfile4Age;
                    int insertlog12 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log12, user, DateTime.Now.ToString());
                    int updatesp4 = Queries3.UpdateSubprofile4Value(Session["office"].ToString(), year);



                }
                else
                {
                    int sp4 = Queries3.UpdateSubProfile4(Session["ProfileID"].ToString(), subProfile4Title, subProfile4FirstName.ToUpper(), subProfile4LastName.ToUpper(), subProfile4DateOfBirth, subProfile4Nationality, subProfile4Country, subProfile4Age);

                    if (String.Compare((string)Session["oSub_Profile4_Title"], subProfile4Title) != 0)
                    {
                        string act = "subprofile4 title changed from:" + Session["oSub_Profile4_Title"] + "To:" + subProfile4Title;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_Fname"], subProfile4FirstName.ToUpper()) != 0)
                    {
                        string act = "subprofile4 fname changed from:" + Session["oSub_Profile4_Fname"] + "To:" + subProfile4FirstName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_Lname"], subProfile4LastName.ToUpper()) != 0)
                    {
                        string act = "subprofile4 lname changed from:" + Session["oSub_Profile4_Lname"] + "To:" + subProfile4LastName.ToUpper();
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_DOB"], subProfile4DateOfBirth) != 0)
                    {
                        string act = "subprofile4 dob changed from:" + Session["oSub_Profile4_DOB"] + "To:" + subProfile4DateOfBirth;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile4_Age"], String.IsNullOrEmpty(subProfile4Age) ? "" : subProfile4Age) != 0)
                    {
                        string act = "Subprofile4age changed from:" + Session["oSub_Profile4_Age"] + "To:" + subProfile4Age;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    if (String.Compare((string)Session["oSub_Profile4_Nationality"], subProfile4Nationality) != 0)
                    {
                        string act = "subprofile4 nationality changed from:" + Session["oSub_Profile4_Nationality"] + "To:" + subProfile4Nationality;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }

                    if (String.Compare((string)Session["oSub_Profile4_Country"],subProfile4Country) != 0)

                    {
                        string act = "subprofile4 country changed from:" + Session["oSub_Profile4_Country"] + "To:" + subProfile4Country;
                        int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
                    }
                    else { }
                    
                }

            }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//

            //----------------------------------- updation of Address details------------------------------------------------//

            int address = Queries3.UpdateProfileAddress(Session["ProfileID"].ToString(), addressLine1.ToUpper(), addressLine2.ToUpper(),addressState.ToUpper() , addressCity.ToUpper(), addressPincode.ToUpper(), addressCountry);
           
                if (String.Compare((string)Session["oProfile_Address_Line1"], addressLine1.ToUpper()) != 0)
            {
                string act = "Address line 1 changed from:" + Session["oProfile_Address_Line1"] + "To:" + addressLine1.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oProfile_Address_Line2"], addressLine2.ToUpper()) != 0)
            {
                string act = "Address line 2 changed from:" + Session["oProfile_Address_Line2"] + "To:" + addressLine2.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Address_Country"], addressCountry) != 0)
            {
                string act = "Address Country changed from:" + Session["oProfile_Address_Country"] + "To:" + addressCountry;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Address_State"], addressState.ToUpper()) != 0)
            {
            string act = "Address State changed from:" + Session["oProfile_Address_State"] + "To:" + addressState.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oProfile_Address_city"], addressCity.ToUpper()) != 0)
            {
                string act = "Address City changed from:" + Session["oProfile_Address_city"] + "To:" + addressCity.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Address_Postcode"], addressPincode.ToUpper()) != 0)
            {
                string act = "Address Postal code changed from:" + Session["oProfile_Address_Postcode"] + "To:" + addressPincode.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_Employment_status"], primaryEmploymentStatus) != 0)
            {
                string act = "Primary Employment status changed from:" + Session["oProfile_Employment_status"] + "To:" + primaryEmploymentStatus;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecond_Employment_status"], secondaryEmploymentStatus) != 0)
            {
                string act = "Secondary Employment status changed from:" + Session["oSecond_Employment_status"] + "To:" + secondaryEmploymentStatus;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oProfile_Marital_status"], martialStatus) != 0)
            {
                string act = "Marital status changed from:" + Session["oProfile_Marital_status"] + "To:" + martialStatus;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oProfile_NOY_Living_as_couple"], livingYears) != 0)
            {
                string act = "No of years living changed from:" + Session["oProfile_NOY_Living_as_couple"] + "To:" + livingYears;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oProfile_Photo_Identity"], photoIdentity) != 0)
            {
                string act = "Photo Identity changed from:" + Session["oProfile_Photo_Identity"] + "To:" + photoIdentity;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oProfile_Card"], card) != 0)
            {
                string act = "Card Holder details changed from:" + Session["oProfile_Card"] + "To:" + card;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//


            //----------------------------------- updation of Phone details------------------------------------------------//

            int phone = Queries3.UpdatePhone(Session["ProfileID"].ToString(), primaryMobileCode, primaryMobileNumber, primaryAlternateCode, PrimaryAlternateNumber,secondaryMobileCode , secondaryMobileNumber,secondaryAlternateCode,secondaryAlternateNumber,subProfileMobileCode, subProfileMobileNumber, subProfileAlternateCode, subProfileAlternateNumber,subProfile2MobileCode, subProfile2MobileNumber, subProfile2AlternateCode, subProfile2AlternateNumber, subProfile3MobileCode,subProfile3MobileNumber, subProfile4MobileCode, subProfile4MobileNumber,subProfile3AlternateCode, subProfile3AlternateNumber,subProfile4AlternateCode,subProfile4AlternateNumber, primaryOfficeCode, primaryOfficeNumber,secondaryOfficeCode, secondaryOfficeNumber,primaryHomeCode,primaryHomeNumber,secondaryHomeCode,secondaryHomeNumber);

            if (String.Compare((string)Session["oPrimary_CC"], primaryMobileCode) != 0)
            {
                string act = "primary mobile code changed from:" + Session["oPrimary_CC"] + "To:" + primaryMobileCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Mobile"], primaryMobileNumber) != 0)
            {
                string act = "primary mobile no changed from:" + Session["oPrimary_Mobile"] + "To:" + primaryMobileNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Alt_CC"], primaryAlternateCode) != 0)
            {
                string act = "primary mobile changed from:" + Session["oPrimary_Alt_CC"] + "To:" + primaryAlternateCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Alternate"], PrimaryAlternateNumber) != 0)
            {
                string act = "primary alternate no changed from:" + Session["oPrimary_Alternate"] + "To:" + PrimaryAlternateNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oPrimary_Home_CC"], primaryHomeCode) != 0)
            {
                string act = "primary Home code changed from:" + Session["oPrimary_Home_CC"] + "To:" + primaryHomeCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Home"], primaryHomeNumber) != 0)
            {
                string act = "primary Home no changed from:" + Session["oPrimary_Home"] + "To:" + primaryHomeNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oPrimary_Office_CC"], primaryOfficeCode) != 0)
            {
                string act = "primary Office code changed from:" + Session["oPrimary_Office_CC"] + "To:" + primaryOfficeCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare((string)Session["oPrimary_Office"], primaryOfficeNumber) != 0)
            {
                string act = "primary Office no changed from:" + Session["oPrimary_Office"] + "To:" + primaryOfficeNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }



            if (String.Compare((string)Session["oSecondary_CC"], secondaryMobileCode) != 0)
            {
                string act = "Secondary mobile code changed from:" + Session["oSecondary_CC"] + "To:" + secondaryMobileCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSecondary_Mobile"], secondaryMobileNumber) != 0)
            {
                string act = "Secondary mobile No changed from:" + Session["oSecondary_Mobile"] + "To:" + secondaryMobileNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Alt_CC"], secondaryAlternateCode) != 0)
            {
                string act = "Secondary alternate code changed from:" + Session["oSecondary_Alt_CC"] + "To:" + secondaryAlternateCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSecondary_Alternate"], secondaryAlternateNumber) != 0)
            {
                string act = "Secondary alternate No changed from:" + Session["oSecondary_Alternate"] + "To:" + secondaryAlternateNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Home_CC"], secondaryHomeCode) != 0)
            {
                string act = "Secondary Home code changed from:" + Session["oSecondary_Home_CC"] + "To:" + secondaryHomeCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Home"], secondaryHomeNumber) != 0)
            {
                string act = "Secondary Home No changed from:" + Session["oSecondary_Home"] + "To:" + secondaryHomeNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Office_CC"], secondaryOfficeCode) != 0)
            {
                string act = "Secondary Office code changed from:" + Session["oSecondary_Office_CC"] + "To:" + secondaryOfficeCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Office"], secondaryOfficeNumber) != 0)
            {
                string act = "Secondary Office No changed from:" + Session["oSecondary_Office"] + "To:" + secondaryOfficeNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile1_CC"], subProfileMobileCode) != 0)
            {
                string act = "Sub Profile 1 Mobile code changed from:" + Session["oSubprofile1_CC"] + "To:" + subProfileMobileCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile1_Mobile"], subProfileMobileNumber) != 0)
            {
                string act = "Sub profile 1 Mobile  No changed from:" + Session["oSubprofile1_Mobile"] + "To:" + subProfileMobileNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Alt_CC"], subProfileAlternateCode) != 0)
            {
                string act = "Sub Profile 1 alternate code changed from:" + Session["oSubprofile1_Alt_CC"] + "To:" + subProfileAlternateCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Alternate"], subProfileAlternateNumber) != 0)
            {
                string act = "Sub profile 1 alternate No changed from:" + Session["oSubprofile1_Alternate"] + "To:" + subProfileAlternateNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_CC"], subProfile2MobileCode) != 0)
            {
                string act = "Sub Profile 2 Mobile code changed from:" + Session["oSubprofile2_CC"] + "To:" + subProfile2MobileCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Mobile"], subProfile2MobileNumber) != 0)
            {
                string act = "Sub profile 2 Mobile No changed from:" + Session["oSubprofile2_Mobile"] + "To:" + subProfile2MobileNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Alt_CC"], subProfile2AlternateCode) != 0)
            {
                string act = "Sub Profile 2 Alternate code changed from:" + Session["oSubprofile2_Alt_CC"] + "To:" + subProfile2AlternateCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Alternate"], subProfile2AlternateNumber) != 0)
            {
                string act = "Sub profile 2 alternate No changed from:" + Session["oSubprofile2_Alternate"] + "To:" + subProfile2AlternateNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile3_CC"], subProfile3MobileCode) != 0)
            {
                string act = "Sub Profile 3 Mobile code changed from:" + Session["oSubprofile3_CC"] + "To:" + subProfile3MobileCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile3_Mobile"], subProfile3MobileNumber) != 0)
            {
                string act = "Sub profile 3 Mobile No changed from:" + Session["oSubprofile3_Mobile"] + "To:" + subProfile3MobileNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }



            if (String.Compare((string)Session["oSubprofile3_Alt_CC"], subProfile3AlternateCode) != 0)
            {
                string act = "Sub Profile 3 Alternate code changed from:" + Session["oSubprofile3_Alt_CC"] + "To:" + subProfile3AlternateCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_Alternate"], subProfile3AlternateNumber) != 0)
            {
                string act = "Sub profile 3 Alternate No changed from:" + Session["oSubprofile3_Alternate"] + "To:" + subProfile3AlternateNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_CC"], subProfile4MobileCode) != 0)
            {
                string act = "Sub Profile 4 Mobile code changed from:" + Session["oSubprofile4_CC"] + "To:" + subProfile4MobileCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_Mobile"], subProfile4MobileNumber) != 0)
            {
                string act = "Sub profile 4 Mobile No changed from:" + Session["oSubprofile4_Mobile"] + "To:" + subProfile4MobileNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_Alt_CC"], subProfile4AlternateCode) != 0)
            {
                string act = "Sub Profile 4 Alternate code changed from:" + Session["oSubprofile4_Alt_CC"] + "To:" + subProfile4AlternateCode;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile4_Alternate"], subProfile4AlternateNumber) != 0)
            {
                string act = "Sub profile 4 Alternate No changed from:" + Session["oSubprofile4_Alternate"] + "To:" + subProfile4AlternateNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//


            //----------------------------------- updation of Email details------------------------------------------------//

            int email = Queries3.UpdateEmail(Session["ProfileID"].ToString(), primaryEmail1, secondaryEmail1, subProfileEmail1, subProfile2Email1,primaryEmail2,secondaryEmail2,subProfileEmail2, subProfile2Email2, subProfile3Email1, subProfile3Email2, subProfile4Email1, subProfile4Email2);

            if (String.Compare((string)Session["oPrimary_Email"], primaryEmail1) != 0)
            {
                string act = "Primary email 1 changed from:" + Session["oPrimary_Email"] + "To:" + primaryEmail1;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oPrimary_Email2"], primaryEmail2) != 0)
            {
                string act = "Primary email 2 changed from:" + Session["oPrimary_Email2"] + "To:" + primaryEmail2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }



            if (String.Compare((string)Session["oSecondary_Email"], secondaryEmail1) != 0)
            {
                string act = "Secondary email 1 changed from:" + Session["oSecondary_Email"] + "To:" + secondaryEmail1;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_Email2"], secondaryEmail2) != 0)
            {
                string act = "Secondary email 2 changed from:" + Session["oSecondary_Email2"] + "To:" + secondaryEmail2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Email"], subProfileEmail1) != 0)
            {
                string act = "Sub profile 1 email 1 changed from:" + Session["oSubprofile1_Email"] + "To:" + subProfileEmail1;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile1_Email2"], subProfileEmail2) != 0)
            {
                string act = "Sub profile 1 email 2 changed from:" + Session["oSubprofile1_Email2"] + "To:" + subProfileEmail2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile2_Email"], subProfile2Email1) != 0)
            {
                string act = "Sub profile 2 email 1 changed from:" + Session["oSubprofile2_Email"] + "To:" + subProfile2Email1;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_Email2"], subProfile2Email2) != 0)
            {
                string act = "Sub profile 2 email 2 changed from:" + Session["oSubprofile2_Email2"] + "To:" + subProfile2Email2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile3_Email"], subProfile3Email1) != 0)
            {
                string act = "Sub profile 3 email 1 changed from:" + Session["oSubprofile3_Email"] + "To:" + subProfile3Email1;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_Email2"], subProfile3Email2) != 0)
            {
                string act = "Sub profile 3 email 2 changed from:" + Session["oSubprofile3_Email2"] + "To:" + subProfile3Email2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile4_Email"], subProfile4Email1) != 0)
            {
                string act = "Sub profile 4 email 1 changed from:" + Session["oSubprofile4_Email"] + "To:" + subProfile4Email1;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oSubprofile4_Email2"], subProfile4Email2) != 0)
            {
                string act = "Sub profile 4 email 2 changed from:" + Session["oSubprofile4_Email2"] + "To:" + subProfile4Email2;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//

            //----------------------------------- updation of ID details------------------------------------------------//

            int updateID_Card = Queries3.UpdateIDCard(Session["ProfileID"].ToString(),primaryIDCardType.ToUpper() , primaryIDCardNumber,secondaryIDCardType.ToUpper(), secondaryIDCardNumber, subProfileIDCardType.ToUpper(), subProfileIDCardNumber, subProfile2IDCardType.ToUpper(), subProfile2IDCardNumber, subProfile3IDCardType.ToUpper(), subProfile3IDCardNumber, subProfile4IDCardType.ToUpper(),subProfile4IDCardNumber);

            if (String.Compare((string)Session["oPrimary_ID_Type"], primaryIDCardType.ToUpper()) != 0)
            {
                string act = "Primary ID Type changed from:" + Session["oPrimary_ID_Type"] + "To:" + primaryIDCardType.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oPrimary_ID_Num"], primaryIDCardNumber) != 0)
            {
                string act = "Primary ID Num changed from:" + Session["oPrimary_ID_Num"] + "To:" + primaryIDCardNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_ID_Type"], secondaryIDCardType.ToUpper()) != 0)
            {
                string act = "Secondary ID Type changed from:" + Session["oSecondary_ID_Type"] + "To:" + secondaryIDCardType.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSecondary_ID_Num"], secondaryIDCardNumber) != 0)
            {
                string act = "Secondary ID Num changed from:" + Session["oSecondary_ID_Num"] + "To:" + secondaryIDCardNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile1_ID_Type"], subProfileIDCardType.ToUpper()) != 0)
            {
                string act = "Sub Profile 1 ID Type changed from:" + Session["oSubprofile1_ID_Type"] + "To:" + subProfileIDCardType.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile1_ID_Num"], subProfileIDCardNumber) != 0)
            {
                string act = "Sub Profile 1 ID Num changed from:" + Session["oSubprofile1_ID_Num"] + "To:" + subProfileIDCardNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_ID_Type"], subProfile2IDCardType.ToUpper()) != 0)
            {
                string act = "Sub Profile 2 ID Type changed from:" + Session["oSubprofile2_ID_Type"] + "To:" + subProfile2IDCardType.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile2_ID_Num"], subProfile2IDCardNumber) != 0)
            {
                string act = "Sub Profile 2 ID Num changed from:" + Session["oSubprofile2_ID_Num"] + "To:" + subProfile2IDCardNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_ID_Type"], subProfile3IDCardType.ToUpper()) != 0)
            {
                string act = "Sub Profile 3 ID Type changed from:" + Session["oSubprofile3_ID_Type"] + "To:" + subProfile3IDCardType.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile3_ID_Num"], subProfile3IDCardNumber) != 0)
            {
                string act = "Sub Profile 3 ID Num changed from:" + Session["oSubprofile3_ID_Num"] + "To:" + subProfile3IDCardNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_ID_Type"], subProfile4IDCardType.ToUpper()) != 0)
            {
                string act = "Sub Profile 4 ID Type changed from:" + Session["oSubprofile4_ID_Type"] + "To:" + subProfile4IDCardType.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSubprofile4_ID_Num"], subProfile4IDCardNumber) != 0)
            {
                string act = "Sub Profile 4 ID Num changed from:" + Session["oSubprofile4_ID_Num"] + "To:" + subProfile4IDCardNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//


            //----------------------------------- updation of profile  Stay  details------------------------------------------------//

            int stay = Queries3.UpdateProfileStay(Session["ProfileID"].ToString(), resortName.ToUpper(), resortRoomNumber,arrivalDate,departureDate);

            if (String.Compare((string)Session["oResort_Name"], resortName.ToUpper()) != 0)
            {
                string act = "Resort Name changed from:" + Session["oResort_Name"] + "To:" + resortName.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oResort_RoomNo"], resortRoomNumber) != 0)
            {
                string act = "Resort Room No changed from:" + Session["oResort_RoomNo"] + "To:" + resortRoomNumber;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oArrival_Date"], arrivalDate) != 0)
            {
                string act = "Arrival Date changed from:" + Session["oArrival_Date"] + "To:" + arrivalDate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oDepature_Date"], departureDate) != 0)
            {
                string act = "Depature Date changed from:" + Session["oDepature_Date"] + "To:" + departureDate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//


            //----------------------------------- updation of profile Tour details------------------------------------------------//
            int tour = Queries3.UpdateTourDetails(Session["ProfileID"].ToString(),guestStatus, salesRepresentative, tourDate, checkInTime, checkOutTime, taxiInPrice, taxiInRef.ToUpper(), taxiOutPrice, taxiOutRef.ToUpper(), qStatus, weekNo);

            if (String.Compare((string)Session["oGuest_Status"], guestStatus) != 0)
            {
                string act = "Guest Status changed from:" + Session["oGuest_Status"] + "To:" + guestStatus;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oSales_Rep"], salesRepresentative) != 0)
            {
                string act = "Sales Representative changed from:" + Session["oSales_Rep"] + "To:" + salesRepresentative;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oTour_Date"], tourDate) != 0)
            {
                string act = "Tour Date changed from:" + Session["oTour_Date"] + "To:" + tourDate;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oCheck_In_Time"], checkInTime) != 0)
            {
                string act = "Check In Time changed from:" + Session["oCheck_In_Time"] + "To:" + checkInTime;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oCheck_Out_Time"], checkOutTime) != 0)
            {
                string act = "Check Out Time changed from:" + Session["oCheck_Out_Time"] + "To:" + checkOutTime;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oTaxi_In_Price"], taxiInPrice) != 0)
            {
                string act = "Taxi In Price changed from:" + Session["oTaxi_In_Price"] + "To:" + taxiInPrice;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oTaxi_Out_Price"], taxiOutPrice) != 0)
            {
                string act = "Taxi Out Price changed from:" + Session["oTaxi_Out_Price"] + "To:" + taxiOutPrice;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare((string)Session["oTaxi_In_Ref"], taxiInRef.ToUpper()) != 0)
            {
                string act = "Taxi In Ref changed from:" + Session["oTaxi_In_Ref"] + "To:" + taxiInRef.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oTaxi_Out_Ref"], taxiOutRef.ToUpper()) != 0)
            {
                string act = "Taxi Out Ref changed from:" + Session["oTaxi_Out_Ref"] + "To:" + taxiOutRef.ToUpper();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oQstatus"], qStatus) != 0)
            {
                string act = "Qstatus changed from:" + Session["oQstatus"] + "To:" + qStatus;
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare((string)Session["oWeekNo"], weekNo.ToString()) != 0)
            {
                string act = "Week No changed from:" + Session["oWeekNo"] + "To:" + weekNo.ToString();
                int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
            }
            else { }


        if (String.Compare((string)Session["oComments"], comments.ToUpper()) != 0)
        {
            string act = "Comments changed from:" + Session["oComments"] + "To:" + comments.ToUpper();
            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare((string)Session["oComments2"], comments2.ToUpper()) != 0)
        {
            string act = "Comments 2 changed from:" + Session["oComments2"] + "To:" + comments2.ToUpper();
            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare((string)Session["oRegTerms"], regTerm1) != 0)
        {
            string act = "Reg Terms changed from:" + Session["oRegTerms"] + "To:" + regTerm1;
            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare((string)Session["oRegTerms2"], regTerm2) != 0)
        {
            string act = "Reg Terms 2 changed from:" + Session["oRegTerms2"] + "To:" + regTerm2;
            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }



        if (DeleGiftCheckBox1.Checked == true)
        {

            // Session["ogiftoptionDropDownList2"] = ar[1];
            // Session["ovouchernoTextBox2"] = br[1];
            // Session["ogiftprice2"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];
            int deletegift = Queries3.DeleteGift(Session["ogiftoptionDropDownList"].ToString(), Session["ovouchernoTextBox"].ToString(), ProfileIDTextBox.Text);
            string act = "Deleted gift :" + Session["ogiftoptionDropDownList"].ToString() + "  " + Session["ovouchernoTextBox"].ToString();
            int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

        }
        else
        {
            
            if (giftoptionDropDownList.SelectedItem.Text != "")
            {
                if (Session["ogiftoptionDropDownList"].ToString() == "" || Session["ogiftoptionDropDownList"].ToString() == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string item = Queries.GetItemOnGift(gifto1);
                    if (item == "" || item == null)
                    {
                        item = "";
                    }
                    else
                    {
                        item = Queries.GetItemOnGift(gifto1);
                    }

                    int insert = Queries3.InsertGiftOption(giftid, gifto1, voucher1, chargeback.ToUpper(), (string)Session["ProfileIDo"], item, giftprice1);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {
                    int gift = Queries3.UpdateGiftValue(Session["ogiftoptionDropDownList"].ToString(), gifto1, voucher1, (string)Session["ProfileIDo"], chargeback.ToUpper(), giftprice1);
                }
            }
        }


        if (DeleGiftCheckBox2.Checked == true)
        {

            // Session["ogiftoptionDropDownList2"] = ar[1];
            // Session["ovouchernoTextBox2"] = br[1];
            // Session["ogiftprice2"] = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];
            int deletegift = Queries3.DeleteGift(Session["ogiftoptionDropDownList2"].ToString(), Session["ovouchernoTextBox2"].ToString(), ProfileIDTextBox.Text);
            string act = "Deleted gift :" + Session["ogiftoptionDropDownList2"].ToString() + "  " + Session["ovouchernoTextBox2"].ToString();
            int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

        }
        else
        {

            if (giftoptionDropDownList2.SelectedItem.Text != "")
            {
                if (Session["ogiftoptionDropDownList2"].ToString() == "" || Session["ogiftoptionDropDownList2"].ToString() == null)
                {
                    string giftid = Queries.GetProfileGift(office);
                    string item = Queries.GetItemOnGift(gifto2);
                    if (item == "" || item == null)
                    {
                        item = "";
                    }
                    else
                    {
                        item = Queries.GetItemOnGift(gifto2);
                    }

                    int insert = Queries3.InsertGiftOption(giftid, gifto2, voucher2, "", (string)Session["ProfileIDo"], item, giftprice2);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {
                    int gift = Queries3.UpdateGiftValue(Session["ogiftoptionDropDownList2"].ToString(), gifto2, voucher2, (string)Session["ProfileIDo"], "", giftprice2);
                }
            }
        }



        if (DeleGiftCheckBox3.Checked == true)
        {


            int deletegift = Queries3.DeleteGift(Session["ogiftoptionDropDownList3"].ToString(), Session["ovouchernoTextBox3"].ToString(), ProfileIDTextBox.Text);
            string act = "Deleted gift :" + Session["ogiftoptionDropDownList3"].ToString() + "  " + Session["ovouchernoTextBox3"].ToString();
            int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

        }
        else
        {

            if (giftoptionDropDownList3.SelectedItem.Text != "")
            {
                if (Session["ogiftoptionDropDownList3"].ToString() == "" || Session["ogiftoptionDropDownList3"].ToString() == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string item = Queries.GetItemOnGift(gifto3);
                    if (item == "" || item == null)
                    {
                        item = "";
                    }
                    else
                    {
                        item = Queries.GetItemOnGift(gifto3);
                    }

                    int insert = Queries3.InsertGiftOption(giftid, gifto3, voucher3, "", (string)Session["ProfileIDo"], item, giftprice3);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries3.UpdateGiftValue(Session["ogiftoptionDropDownList3"].ToString(), gifto3, voucher3, (string)Session["ProfileIDo"], "", giftprice3);
                }
            }
        }


        if (DeleGiftCheckBox4.Checked == true)
        {


            int deletegift = Queries3.DeleteGift(Session["ogiftoptionDropDownList4"].ToString(), Session["ovouchernoTextBox4"].ToString(), ProfileIDTextBox.Text);
            string act = "Deleted gift :" + Session["ogiftoptionDropDownList4"].ToString() + "  " + Session["ovouchernoTextBox4"].ToString();
            int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

        }
        else
        {
            if (giftoptionDropDownList4.SelectedItem.Text != "")
            {
                if (Session["ogiftoptionDropDownList4"].ToString() == "" || Session["ogiftoptionDropDownList4"].ToString() == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string item = Queries.GetItemOnGift(gifto4);
                    if (item == "" || item == null)
                    {
                        item = "";
                    }
                    else
                    {
                        item = Queries.GetItemOnGift(gifto4);
                    }

                    int insert = Queries3.InsertGiftOption(giftid, gifto4, voucher4, "", (string)Session["ProfileIDo"], item, giftprice4);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries3.UpdateGiftValue(Session["ogiftoptionDropDownList4"].ToString(), gifto4, voucher4, (string)Session["ProfileIDo"], "", giftprice4);
                }
            }
        }


        if (DeleGiftCheckBox5.Checked == true)
        {


            int deletegift = Queries3.DeleteGift(Session["ogiftoptionDropDownList5"].ToString(), Session["ovouchernoTextBox5"].ToString(), ProfileIDTextBox.Text);
            string act = "Deleted gift :" + Session["ogiftoptionDropDownList5"].ToString() + "  " + Session["ovouchernoTextBox5"].ToString();
            int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

        }
        else
        {
            if (giftoptionDropDownList5.SelectedItem.Text != "")
            {
                if (Session["ogiftoptionDropDownList5"].ToString() == "" || Session["ogiftoptionDropDownList5"].ToString() == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string item = Queries.GetItemOnGift(gifto5);
                    if (item == "" || item == null)
                    {
                        item = "";
                    }
                    else
                    {
                        item = Queries.GetItemOnGift(gifto5);
                    }

                    int insert = Queries3.InsertGiftOption(giftid, gifto5, voucher5, "", (string)Session["ProfileIDo"], item, giftprice5);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries3.UpdateGiftValue(Session["ogiftoptionDropDownList5"].ToString(), gifto5, voucher5, (string)Session["ProfileIDo"], "", giftprice5);
                }
            }
        }


        if (DeleGiftCheckBox6.Checked == true)
        {


            int deletegift = Queries3.DeleteGift(Session["ogiftoptionDropDownList6"].ToString(), Session["ovouchernoTextBox6"].ToString(), ProfileIDTextBox.Text);
            string act = "Deleted gift :" + Session["ogiftoptionDropDownList6"].ToString() + "  " + Session["ovouchernoTextBox6"].ToString();
            int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

        }
        else
        {
            if (giftoptionDropDownList6.SelectedItem.Text != "")
            {
                if (Session["ogiftoptionDropDownList6"].ToString() == "" || Session["ogiftoptionDropDownList6"].ToString() == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string item = Queries.GetItemOnGift(gifto6);
                    if (item == "" || item == null)
                    {
                        item = "";
                    }
                    else
                    {
                        item = Queries.GetItemOnGift(gifto6);
                    }


                    int insert = Queries3.InsertGiftOption(giftid, gifto6, voucher6, "", (string)Session["ProfileIDo"], item, giftprice6);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries3.UpdateGiftValue(Session["ogiftoptionDropDownList6"].ToString(), gifto6, voucher6, (string)Session["ProfileIDo"], "", giftprice6);
                }
            }
        }

        if (DeleGiftCheckBox7.Checked == true)
        {


            int deletegift = Queries3.DeleteGift(Session["ogiftoptionDropDownList7"].ToString(), Session["ovouchernoTextBox7"].ToString(), ProfileIDTextBox.Text);
            string act = "Deleted gift :" + Session["ogiftoptionDropDownList7"].ToString() + "  " + Session["ovouchernoTextBox7"].ToString();
            int insertlog2 = Queries3.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

        }
        else
        {

            if (giftoptionDropDownList7.SelectedItem.Text != "")
            {
                if (Session["ogiftoptionDropDownList7"].ToString() == "" || Session["ogiftoptionDropDownList7"].ToString() == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string item = Queries.GetItemOnGift(gifto7);
                    if (item == "" || item == null)
                    {
                        item = "";
                    }
                    else
                    {
                        item = Queries.GetItemOnGift(gifto7);
                    }

                    int insert = Queries3.InsertGiftOption(giftid, gifto7, voucher7, "", (string)Session["ProfileIDo"], item, giftprice7);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries3.UpdateGiftValue(Session["ogiftoptionDropDownList7"].ToString(), gifto7, voucher7, (string)Session["ProfileIDo"], "", giftprice7);
                }
            }
        }
        //----------------------------------------------------XXXXXXXXXXXXXX---------------------------------------------------------//


        string msg = "Details updated for Profile :" + " " + Session["ProfileID"].ToString();
            // Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('" + msg + "')", true);

      //  }
        //catch (Exception ex)
        //{

        //    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
        //}
 
        
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
                using (SqlCommand cmd = new SqlCommand("select Venue2_Name as Venue2_Name from venue2 where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "') and venue2_status='Active'", con))
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
                using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name as Venue_Group_Name  from Venue_Group vg join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venueid + "' and Venue_Group_Status = 'Active' order by 1", con))
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


    //[WebMethod]
    //public static string PopulateSubVenueGroupDropDownList(string venueid, string countid, string venue)
    //{
    //    DataTable dt = new DataTable();
    //    List<SubVenueGroupType> listRes = new List<SubVenueGroupType>();

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
    //    {
    //        //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
    //        using (SqlCommand cmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue2_ID in (select Venue2_ID from Venue2 where Venue2_Name='" + venueid + "') and SVenue_Status='Active'", con))
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

    //                    SubVenueGroupType objst2 = new SubVenueGroupType();

    //                    //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

    //                    objst2.SubVenueGroupTypeName = Convert.ToString(dt.Rows[i]["SVenue_Name"]);

    //                    listRes.Insert(i, objst2);


    //                }
    //            }
    //            JavaScriptSerializer jscript = new JavaScriptSerializer();

    //            return jscript.Serialize(listRes);
    //        }
    //    }
    //}


    [WebMethod]
    public static string PopulateSubVenueGroupDropDownList(string venueid, string countid, string venue)
    {
        if (countid == "India" || countid == "INDIA")
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
        else
        {
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

            DataTable dt = new DataTable();
            List<MrktProgType> listRes = new List<MrktProgType>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
            {
                // using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
                using (SqlCommand cmd = new SqlCommand("select m.Marketing_Program_Name  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='"+venueid+"' and vg.Venue_Group_Name ='"+venueGroupid+"' and m.Marketing_Program_Status = 'Active' order by 1", con))
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

                            objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["Marketing_Program_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
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
            string vencountry = Queries3.GetVenueCountryCode(countid);
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
                string vencountry = Queries3.GetVenueCountryCode(countid);
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

            string val = "EditProfile1.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        
  
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
        }
        else
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
        }
        else
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
        }
        else
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
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        return JSON;
    }


    [System.Web.Services.WebMethod]
    public static int totalgift()
    {
        //return "Hello "+name;
        int finaInstI;

        finaInstI = Queries3.countgift((string)HttpContext.Current.Session["ProfileIDo"].ToString());
        return finaInstI;

        //  return "hi";


    }


    [WebMethod]
    public static string loadsubVenueGroup(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries3.LoadSubVenueGroup(prid);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                JSON += "[\"" + name + "\"],";

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

        return JSON;
    }
}