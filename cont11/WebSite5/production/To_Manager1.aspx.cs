using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_To_Manager1 : System.Web.UI.Page
{

    static string pname;

    static string to_managerName;
    static string TO_Manager_Name;
    static string to_ManagerOffice;
    static string to_ManagerStatus;
    static string venue1;
    static string venuecountry1;
    static string description1;
    static string user;
    public string getdata()
    {
       user = (string)Session["username"];
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

    [WebMethod]
    public static void insertToManager(string tomanagername, string tomanageroffice, string venue,string venueCountryID,string description)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();

        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
       
        string query = "insert into TO_Manager([TO_Manager_Name],[Office],[TO_Manager_Status],[TO_Manager_CreatedDate],[Venue],[VenueCountry_ID],[Description]) values('" + tomanagername.ToUpper() + "','" + tomanageroffice + "','Active','" + time.ToString(format) + "','" + venue + "','"+ venueCountryID + "','"+description.ToUpper()+"');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        string pageName = "TO Manager";
        string details = "TO Manager Created : TO_Manager_Name: " + tomanagername + ", Office: " + tomanageroffice+ ", venue: " +venue+", venue country: "+venueCountryID+", description: "+description;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        sqlcon.Close();


    }

    [WebMethod]
    public static string getAllToManager()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct tm.TO_Manager_ID,tm.TO_Manager_Name,tm.Office,tm.TO_Manager_Status,v.Venue_Name,tm.VenueCountry_ID,vc.Venue_Country_Name,tm.Description from TO_Manager tm join venue v on tm.Venue = v.Venue_Name join VenueCountry vc on tm.VenueCountry_ID=vc.Venue_Country_ID; ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            int toManagerID = reader.GetInt32(0);
            string toManagerName = reader.GetString(1);
            string office = reader.GetString(2);
            string status = reader.GetString(3);
            string venueCountryID = reader.GetString(5);
            string venueCountryName = reader.GetString(6);
            string venueName = reader.GetString(4);
            string description = reader.GetString(7);
            JSON += "[\"" + toManagerID + "\" , \"" + toManagerName + "\",\"" + office + "\",\"" + status + "\",\"" + venueCountryID + "\",\"" + venueCountryName + "\",\"" + venueName + "\",\"" + description + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static void deleteToManager(string toManagerID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select TO_Manager_Name from TO_Manager where TO_Manager_ID='" + toManagerID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            TO_Manager_Name = reader.GetString(0);


        }
        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from TO_Manager where [TO_Manager_ID]='" + toManagerID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "To Manager";
        string details = "To Manager: " + TO_Manager_Name + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }

    [WebMethod]
    public static void updateToManager(string toManagerID, string toManagername, string office, string toManagerstatus, string venue,string venuecountry,string description)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select distinct tm.TO_Manager_ID,tm.TO_Manager_Name,tm.Office,tm.TO_Manager_Status,v.Venue_Name,tm.VenueCountry_ID,vc.Venue_Country_Name,tm.Description from TO_Manager tm join venue v on tm.Venue = v.Venue_Name join VenueCountry vc on tm.VenueCountry_ID=vc.Venue_Country_ID where TO_Manager_ID='"+toManagerID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            to_managerName = reader.GetString(1);
            to_ManagerOffice = reader.GetString(2);

            to_ManagerStatus = reader.GetString(3);
            venue1 = reader.GetString(4);

            venuecountry1 = reader.GetString(5);
            description1 = reader.GetString(7);
        }

        if (to_managerName.Equals(toManagername))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "TO Manager changed from: " + to_managerName + "To: " + toManagername;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (to_ManagerOffice.Equals(office))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Office changed from: " + to_ManagerOffice + "To: " + office;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (to_ManagerStatus.Equals(toManagerstatus))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Status changed from: " + to_ManagerStatus + "To: " + toManagerstatus;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (venue1.Equals(venue))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Venue changed from: " + venue1 + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (venuecountry1.Equals(venuecountry))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Venue Country changed from: " + venuecountry1 + "To: " + venuecountry;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (description1.Equals(description))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Description changed from: " + description1 + "To: " + description;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        reader.Close();
        sqlcon1.Close();


        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (toManagerstatus == "Active")
        {

            string query = "update TO_Manager set [TO_Manager_Name]='" + toManagername.ToUpper() + "',[Office]='" + office + "',[TO_Manager_Status]='" + toManagerstatus + "',[Venue]='" + venue + "',[VenueCountry_ID]='"+venuecountry+"',[Description]='"+description.ToUpper()+"' where [TO_Manager_ID]='" + toManagerID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update TO_Manager set [TO_Manager_Name]='" + toManagername.ToUpper() + "',[Office]='" + office + "',[TO_Manager_Status]='" + toManagerstatus + "',[Venue]='" + venue + "',[TO_Manager_ExpiryDate]='" + time.ToString(format) + "',[VenueCountry_ID]='" + venuecountry + "',[Description]='" + description.ToUpper() + "' where [TO_Manager_ID]='" + toManagerID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }

    

    public string getAllVenueCountry()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Venue_Country_ID ,Venue_Country_Name from VenueCountry";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string venueCountryID = reader.GetString(0);
            string venueCountryName = reader.GetString(1);
            htmlstr += "<option value='" + venueCountryID + "'>" + venueCountryName + "</option>";
        }

        reader.Close();
        sqlcon.Close();
        return htmlstr;
    }


    [WebMethod]
    public static string getAllVenue1(string venuecountryID)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venuecountryID + "'); ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string venueName = reader.GetString(0);



            JSON += "[\"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string getAllVenue(string venuecountry)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venuecountry + "'); ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string venueName = reader.GetString(0);



            JSON += "[\"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }
}