﻿using System;
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
public partial class WebSite5_production_BudgetMonthly: System.Web.UI.Page
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




    private void show_report(string country)
    {

        ReportViewer2.Reset();


        DataTable dt = Queries2.Monthbudget(TextBox4.Text, country);
        // DataTable dt2 = Queries2.inhousedate(TextBox4.Text);
        ReportDataSource rds = new ReportDataSource("DataSetM", dt);
        //ReportDataSource rds2 = new ReportDataSource("DataSet2", dt2);




        ReportViewer2.LocalReport.DataSources.Add(rds);
        // ReportViewer2.LocalReport.DataSources.Add(rds2);

        ReportViewer2.LocalReport.ReportPath = "reports/MonthBudget.rdlc";

        ReportParameter[] rptParam = new ReportParameter[]
        {
              new ReportParameter("input",TextBox4.Text),
               new ReportParameter("country",country),


         };


        ReportViewer2.LocalReport.SetParameters(rptParam);
        // ReportViewer1.LocalReport.SetParameters(rptPara1);
        // ReportViewer1.LocalReport.SetParameters(rptPara2);
        ReportViewer2.LocalReport.Refresh();
        // ReportViewer2.LocalReport.Refresh();



        //DataTable dt2 = Queries2.erate();
        //ReportDataSource rds2 = new ReportDataSource("DataSet2", dt2);









    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         
        string country = Request.Form["country"];
    

        show_report(country);

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
            htmlstr += "<option value='"+name+"'>"+name+"</option>";

        }

        sqlcon.Close();
        return htmlstr;



    }
    
    
}