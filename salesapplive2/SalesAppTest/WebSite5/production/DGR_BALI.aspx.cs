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
public partial class WebSite5_production_Reports : System.Web.UI.Page
{

    static string pname;
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

        reader.Close();
        sqlcon.Close();
        return htmlstr;

    }

    protected void Page_Load(object sender, EventArgs e)
    {

         user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        string reportName = Request.Form["reportName"];
        string user = (string)Session["username"];

        string office1 = Queries.GetOffice(user);



       
        string date = Request.Form["example1"];
        string office = Request.Form["office"];
        string venue = Request.Form["venue"];
        string type = Request.Form["type"];

        string marketingProgram= Request.Form["marktProgram2"];


        if (office == "HML")
        {
            DataTable datatable = Queries.loadDGRIndia(date, office, venue);

            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
            crystalReport.Load(Server.MapPath("~/reports/DGR.rpt")); // path of report       
            crystalReport.SetDataSource(datatable);

            System.IO.FileStream fs = null;
            long FileSize = 0;
            DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
            //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
            string ExportFileName = Server.MapPath("~/reports/DGR.rpt") + "Export";
            crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crystalReport.ExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
            oDest.DiskFileName = ExportFileName;
            crystalReport.ExportOptions.DestinationOptions = oDest;
            crystalReport.Export();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Type", "application/.xls");
            string fn = "DGR.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

            fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
            FileSize = fs.Length;
            byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
            fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            fs.Close();
            Response.BinaryWrite(bBuffer);
            Response.Flush();
        


    }
        else
        {
            if (type == ".xls")
            {

                if (marketingProgram=="" || marketingProgram== null)
                {
                    DataTable datatable = Queries2.loadDGRBali(date, office, venue);

                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/DGR Bali.rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);

                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
                    string ExportFileName = Server.MapPath("~/reports/DGR Bali.rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/" + type + "");
                    string fn = "DGR_Bali" + type;
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();
                }else { 
                DataTable datatable = Queries2.loadDGRBaliVenue(date, office, venue,marketingProgram);

                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/DGR Bali.rpt")); // path of report       
                crystalReport.SetDataSource(datatable);

                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
                string ExportFileName = Server.MapPath("~/reports/DGR Bali.rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/" + type + "");
                string fn = "DGR_Bali" + type;
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }

            }
        }

       
        
    }

    public string getvenueCountry()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select Venue_Country_Name,Venue_Country_ID from VenueCountry where Venue_Country_Status='Active';";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string venuecountry = reader.GetString(0);
            string venuecountryID = reader.GetString(1);
            htmlstr += "<option value='" + venuecountryID + "'>" + venuecountry + "</option>";
        }
        sqlcon.Close();
        return htmlstr;
    }
    [WebMethod]
    public static string getVenue(string venueCountry)
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        String JSON = "{\n \"names\":[";
        string query = "select Venue_Name from venue where Venue_Country_ID in('"+ venueCountry + "') and venue.Venue_Status='Active'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string venue = reader.GetString(0);
            //  htmlstr += "<option value='"+ venue +"'>"+venue+"</option>";
            JSON += "[\"" + venue + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;
    }

    [WebMethod]
    public static string getMarketingProgram(string venue)
    {
        string[] value = venue.Split(',');
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        String JSON = "{\n \"names\":[";
        for (int i = 0; i < value.Length; i++)
        {

            string query = "select distinct mp.MProgram2_Name from venue v join venue2 v2 on v.Venue_ID = v2.Venue_ID join Marketing_Program2 mp on v2.Venue2_ID = mp.Venue2_ID where v.Venue_Name in('" + value[i] + "')";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                string marktProgram = reader.GetString(0);
                    JSON += "[\"" + marktProgram + "\"],";
            }
          
            sqlcon.Close();
        }
          JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

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


}