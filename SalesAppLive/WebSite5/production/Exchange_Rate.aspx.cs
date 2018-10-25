using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Exchange_Rate : System.Web.UI.Page
{

    static string pname,office;
    static string exchangeRate;
    static string user;

    static double ERates_IDR;
    static double ERates_INR;
    static double ERates_AUD;
    static double ERates_EUR;
    static double ERates_GBP;
    static string ERates_Status;
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

    protected void Page_Load(object sender, EventArgs e)
    {

         user = (string)Session["username"];
        office = (string)Session["office"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
      //  Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();

        TextBox9.Text= DateTime.Today.ToString("dd/MM/yyyy");
    }

    [WebMethod]
    public static void insertExchangeRate(string eRatesIDR, string eRatesINR, string eRatesAUD, string eRatesEUR, string eRatesGBP)
    {
       
       
        int id = 0;
        int check;
        string value = "ER";
        string exchangeRateID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;              
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select Exchange_Rate_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        exchangeRateID = value + id;

        string query1 = "select ERates_ID from Exchange_Rate where ERates_Status='Active'";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        SqlDataReader reader = cmd4.ExecuteReader();
        while (reader.Read())
        {
            exchangeRate = reader.GetString(0);



        }
        reader.Close();

        string query = "insert into Exchange_Rate ([ERates_ID],[ERates_USD],[ERates_IDR],[ERates_INR],[ERates_AUD],[ERates_EUR],[ERates_Create_Date],[ERates_Expiry_Date],[ERates_Status],[ERates_GBP]) values('" + exchangeRateID+ "','1','"+ eRatesIDR + "','"+ eRatesINR + "','"+ eRatesAUD + "','"+ eRatesEUR + "','" + time.ToString(format)+"','','Active','"+ eRatesGBP + "');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        if (exchangeRate == "")
        {

        }else
        {
            string query2 = "update Exchange_Rate set ERates_Expiry_Date='" + time.ToString(format) + "', ERates_Status='Inactive' where ERates_ID='" + exchangeRate + "'";
            SqlCommand cmd5 = new SqlCommand(query2, sqlcon);
            cmd5.ExecuteNonQuery();
            
        }

        string query5 = "update Admin_ID_gen set Exchange_Rate_ID='" + id + "';";
        SqlCommand cmd7 = new SqlCommand(query5, sqlcon);
        cmd7.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Exchange Rate";
        string details = "Exchange Rate created: ERates_IDR: " + eRatesIDR + ", ERates_INR: " + eRatesINR + ", ERates_AUD: " + eRatesAUD+ ", ERates_EUR: "+ eRatesEUR+ ",ERates_GBP:"+ eRatesGBP;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

    [WebMethod]
    public static string getAllExchangeRate()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select ERates_ID,ERates_IDR,ERates_INR,ERates_AUD,ERates_EUR,ERates_GBP,ERates_Status from Exchange_Rate ORDER BY ERates_Status asc;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string ERates_ID = reader.GetString(0);
            double ERates_IDR = reader.GetDouble(1);
            double ERates_INR = reader.GetDouble(2);
            double ERates_AUD = reader.GetDouble(3);
            double ERates_EUR = reader.GetDouble(4);
            double ERates_GBP = reader.GetDouble(5);
            string status = reader.GetString(6);
            JSON += "[\"" + ERates_ID + "\" , \"" + ERates_IDR + "\",\"" + ERates_INR + "\",\"" + ERates_AUD + "\",\"" + ERates_EUR + "\",\"" + ERates_GBP + "\",\"" + status + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static void deleteExchangeRate(string exchangeRateID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Exchange_Rate where ERates_ID='"+ exchangeRateID + "'";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();


        string pageName = "Exchange Rate";
        string details = "Exchange Rate:" + exchangeRateID + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }
    [WebMethod]
    public static void updateExchangeRate(string exchangeRateID, string eRatesIDR, string eRatesINR,string eRatesAUD, string eRatesEUR,string eRatesGBP)

    {
        
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select ERates_ID,ERates_IDR,ERates_INR,ERates_AUD,ERates_EUR,ERates_GBP,ERates_Status from Exchange_Rate where ERates_ID='"+exchangeRateID+"' ORDER BY ERates_ID DESC ";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            ERates_IDR = reader.GetDouble(1);
            ERates_INR = reader.GetDouble(2);
            ERates_AUD = reader.GetDouble(3);
            ERates_EUR = reader.GetDouble(4);
            ERates_GBP = reader.GetDouble(5);
            ERates_Status = reader.GetString(6);
        }
        if (ERates_IDR.Equals(eRatesIDR))
        { }
        else
        {
            string pageName = "Exchange Rate";
            string details = "ERates_IDR changed from: " + ERates_IDR + "To: " + eRatesIDR;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (ERates_INR.Equals(eRatesINR))
        { }
        else
        {
            string pageName = "Exchange Rate";
            string details = "ERates_INR changed from: " + ERates_INR + "To: " + eRatesINR;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (ERates_AUD.Equals(eRatesAUD))
        { }
        else
        {
            string pageName = "Exchange Rate";
            string details = "ERates_AUD changed from: " + ERates_AUD + "To: " + eRatesAUD;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (ERates_EUR.Equals(eRatesEUR))
        { }
        else
        {
            string pageName = "Exchange Rate";
            string details = "ERates_EUR changed from: " + ERates_EUR + "To: " + eRatesEUR;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (ERates_GBP.Equals(eRatesGBP))
        { }
        else
        {
            string pageName = "Exchange Rate";
            string details = "ERates_GBP changed from: " + ERates_GBP + "To: " + eRatesGBP;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();


        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "update Exchange_Rate set ERates_IDR='"+ eRatesIDR + "',ERates_INR='"+ eRatesINR + "',ERates_AUD='"+ eRatesAUD + "',ERates_EUR='"+ eRatesEUR + "',ERates_GBP='"+ eRatesGBP + "' where ERates_ID='"+ exchangeRateID + "'";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

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