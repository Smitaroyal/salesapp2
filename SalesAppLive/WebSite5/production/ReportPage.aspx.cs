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
using Microsoft.Reporting.WebForms;
public partial class WebSite5_production_ReportPage : System.Web.UI.Page
{

    static string pname,office;
    static string user;
    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct parentnode from user_group_access ug where username ='" + user + "'";
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
    public string getreportdetails()
    {

        int i = 0;
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct ug.groups from user_group_access ug where username ='" + user + "' and PageType='Reports' order by ug.groups desc";
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

                htmlstr += "<li data-toggle='collapse' data-target='#products" + i + "' class='collapsed'><a href='#'><i class='fa fa-gift fa-lg'></i>" + name + "<span class='arrow'></span></a></li><ul class='sub-menu collapse' id='products" + i + "'>";
                SqlConnection sqlcon1 = new SqlConnection(conn);
                sqlcon1.Open();
                string query1 = "select * from user_group_access ug where ug.Groups='" + name + "' and username ='" + user + "' order By page_order asc";

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

                htmlstr += "</ul>";
                i++;


                reader1.Close();
                sqlcon1.Close();
            }
        }

        reader.Close();
        sqlcon.Close();
        return htmlstr;

    }
    protected void Page_Load(object sender, EventArgs e)
    {

         user = (string)Session["username"];
        office = (string)Session["office"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
     //   Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }




    private void show_report(string country,string venue)
    {
        DateTime dtt = DateTime.ParseExact(TextBox1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        string date = dtt.ToString("yyyy-MM-dd");
        ReportViewer1.Reset();

        DataTable dt1 = Queries2.loadDSR1(date, country,venue);
        DataTable dt1_2 = Queries2.loadDSR1_2(date, country, venue);
        DataTable dt2 = Queries2.loadDSR2(date, country, venue);
        DataTable dt3 = Queries2.loadDSR3(date, country, venue);
        DataTable dt4 = Queries2.loadDSR4(date, country, venue);

        ReportDataSource rds1 = new ReportDataSource("DataSet1", dt1);
        ReportDataSource rds1_2 = new ReportDataSource("DataSet2", dt1_2);
        ReportDataSource rds2 = new ReportDataSource("DataSet3", dt2);
        ReportDataSource rds3 = new ReportDataSource("DataSet4", dt3);
        ReportDataSource rds4 = new ReportDataSource("DataSet5", dt4);


        ReportViewer1.LocalReport.DataSources.Add(rds1);
        ReportViewer1.LocalReport.DataSources.Add(rds1_2);
        ReportViewer1.LocalReport.DataSources.Add(rds2);
        ReportViewer1.LocalReport.DataSources.Add(rds3);
        ReportViewer1.LocalReport.DataSources.Add(rds4);

        ReportViewer1.LocalReport.ReportPath = "reports/Daily_sales.rdlc";
        ReportParameter[] rptParam = new ReportParameter[]
        {
            new ReportParameter("Date",date),
           new ReportParameter("VENUE",venue),
            new ReportParameter("COUNTRY",country)
        };
        ReportViewer1.LocalReport.SetParameters(rptParam);
        ReportViewer1.LocalReport.Refresh();



    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string country = Request.Form["country"];
        string venue = Request.Form["venue"];
        show_report(country,venue);

    }



    public string getcountries()
    {
        string htmlstr = "";

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select Venue_Country_Office,Venue_Country_Name from VenueCountry where Venue_Country_Status='Active';";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string office = reader.GetString(0);
            string name = reader.GetString(1);
            htmlstr += "<option value='" + name + "'>" + name + "</option>";

        }

        sqlcon.Close();
        return htmlstr;



    }
    [WebMethod]
    public static string getVenue(string country)
    {
        string Venue_Country_ID;

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Name = '" + country + "' and Venue_Country_Status='Active';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            Venue_Country_ID = reader.GetString(0);
            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select Venue_Name,Venue_ID from venue where Venue_Country_ID='" + Venue_Country_ID + "' and Venue_Status='Active';";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                var venueName = reader1.GetString(0);

                JSON += "[\"" + venueName + "\"],";
                // // htmlstr += "<option value='" + venueID + "'>" + venueName + "</option>" // //;
            }

            reader1.Close();
            sqlcon1.Close();
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string getAdminRights()
    {
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


            string val = "../../Contractsite/Edit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }



        return JSON;



    }
}