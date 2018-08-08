using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Flybuy_PreArrival : System.Web.UI.Page
{

    static string pname,office;
    static string user;
    static string Pre_Arrival_Name;
    static string Pre_Arrival_Status;
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
       // Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }

    [WebMethod]
    public static void insertFlybuy_PreArrival(string fly_PreArrival)
    {
        int id = 0;
       
        string value = "FPA";
        string flyPreArrivalID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;              
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select Fly_PreArrival from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        flyPreArrivalID = value + id;
        string query = "insert into Flybuy_Pre_Arrival(Pre_Arrival_ID, Pre_Arrival_Name, Pre_Arrival_Status, Pre_Arrival_Create_Date) values('"+flyPreArrivalID+"', '"+fly_PreArrival.ToUpper()+"', 'Active', '"+time.ToString(format)+"') ";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        string query1 = "update Admin_ID_gen set Fly_PreArrival='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Pre Arrival";
        string details = "Pre Arrival created: Name: " + fly_PreArrival;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

    [WebMethod]
    public static string getAllFlybuy_PreArrival()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select * from Flybuy_Pre_Arrival;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string flyPreArrivalID = reader.GetString(0);
            string flyPreArrival = reader.GetString(1);
            string status = reader.GetString(2);

            JSON += "[\"" + flyPreArrivalID + "\" , \"" + flyPreArrival + "\",\"" + status + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static void deleteFlybuy_PreArrival(string flyPreArrivalID,string flyPreArrival)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Flybuy_Pre_Arrival where [Pre_Arrival_ID]='" + flyPreArrivalID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Pre Arrival";
        string details = "Pre Arrival:" + flyPreArrival + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }
    [WebMethod]
    public static void updateFlybuy_PreArrival(string fly_PreArrival_ID, string fly_PreArrival, string status)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select  ss.Pre_Arrival_Name,ss.Pre_Arrival_Status from Flybuy_Pre_Arrival ss where Pre_Arrival_ID ='"+fly_PreArrival_ID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Pre_Arrival_Name = reader.GetString(0);
            Pre_Arrival_Status = reader.GetString(1);
        }
        if (Pre_Arrival_Name.Equals(fly_PreArrival))
        { }
        else
        {
            string pageName = "Pre Arrival";
            string details = "Name changed from: " + Pre_Arrival_Name + "To: " + fly_PreArrival;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (Pre_Arrival_Status.Equals(status))
        { }
        else
        {
            string pageName = "Pre Arrival";
            string details = "status changed from: " + Pre_Arrival_Status + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update Flybuy_Pre_Arrival set Pre_Arrival_Name='" + fly_PreArrival.ToUpper() + "',Pre_Arrival_Status='" + status+ "' where Pre_Arrival_ID='" + fly_PreArrival_ID + "'";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Flybuy_Pre_Arrival set Pre_Arrival_Name='" + fly_PreArrival.ToUpper() + "',Pre_Arrival_Status='" + status + "',Pre_Arrival_Expiry_Date='" + time.ToString(format)+ "' where Pre_Arrival_ID='" + fly_PreArrival_ID + "'";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

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