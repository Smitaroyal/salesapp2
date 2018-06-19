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
public partial class WebSite5_production_Top_Drawer : System.Web.UI.Page
{

    static string pname;
    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct parentnode from user_group_access ug join users u on u.[Group Id] = ug.[Group Id]where u.username ='" + user + "' ";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            htmlstr += "<li><a><i class='fa fa-home'></i>" + name + " <span class='fa fa-chevron - down'></span> </a><ul class='nav child_menu'>";
            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();
            string query1 = "select * from user_group_access ug join users u on u.[Group Id] =ug.[Group Id]where ug.ParentNode='" + name + "' and  u.username ='" + user + "'";
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);

            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string pagename = reader1.GetString(1);
                string pageurl = reader1.GetString(3);
                string AccessName = reader1.GetString(11);
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
        reader.Close();
        sqlcon.Close();
     
        return htmlstr;

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }




    private void show_report(string country,string venue,string venueGroup)
    {
        ReportViewer1.Reset();

        DataTable dt1 = Queries2.topdrawer1_1(TextBox4.Text, TextBox1.Text, country, venue, venueGroup);
        DataTable dt1_2 = Queries2.topdrawer1_2(TextBox4.Text, TextBox1.Text, country, venue, venueGroup);
        DataTable dt2 = Queries2.topdrawer2(TextBox4.Text, TextBox1.Text, country, venue, venueGroup);
        //DataTable dt3 = Queries2.topdrawer3(TextBox1.Text, TextBox3.Text, TextBox2.Text, TextBox4.Text);
        //DataTable dt4 = Queries2.topdrawer4(TextBox1.Text, TextBox3.Text, TextBox2.Text, TextBox4.Text);

        ReportDataSource rds1 = new ReportDataSource("DataSet1", dt1);
        ReportDataSource rds1_2 = new ReportDataSource("DataSet2", dt1_2);
        ReportDataSource rds2 = new ReportDataSource("DataSet3", dt2);
        //ReportDataSource rds3 = new ReportDataSource("DataSet4", dt3);
        //ReportDataSource rds4 = new ReportDataSource("DataSet5", dt4);


        ReportViewer1.LocalReport.DataSources.Add(rds1);
        ReportViewer1.LocalReport.DataSources.Add(rds1_2);
        ReportViewer1.LocalReport.DataSources.Add(rds2);
        //ReportViewer1.LocalReport.DataSources.Add(rds3);
        //ReportViewer1.LocalReport.DataSources.Add(rds4);

        ReportViewer1.LocalReport.ReportPath = "reports/Top_Drawer.rdlc";
        ReportParameter[] rptParam = new ReportParameter[]
        {
            new ReportParameter("SDATE",TextBox4.Text),
            new ReportParameter("EDATE",TextBox1.Text),
            new ReportParameter("VENUE",venue),
            new ReportParameter("COUNTRY",country),
            new ReportParameter("GVENUE",venueGroup)
        };
        ReportViewer1.LocalReport.SetParameters(rptParam);
        ReportViewer1.LocalReport.Refresh();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string country = Request.Form["country"];
        string venue = Request.Form["venue"];

        string venueGroup= Request.Form["venueGroup"];
        string subVenue= Request.Form["subVenue"];

        show_report(country,venue, venueGroup);

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
    public static string getVenueGroup(string venue)
    {
        
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select v2.Venue2_Name from venue2 v2 join venue v on v2.Venue_ID=v.Venue_ID where v.Venue_Name='"+venue+"' and v2.Venue2_Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var Venue_Group_Name = reader.GetString(0);

                JSON += "[\"" + Venue_Group_Name + "\"],";

            }
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
        }
       
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }



  
}