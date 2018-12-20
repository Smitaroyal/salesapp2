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

  
    public string getdata()
    {
       string user = (string)Session["username"];
       string office1 = (string)Session["office"];

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
       // office1 = (string)Session["office"];
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
        //Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }

    [WebMethod]
    public static void insertToManager(string tomanagername, string tomanageroffice, string venue,string venueCountryID,string description,string venueCountryName,string manager)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        if (venueCountryName=="Indonesia")
        {
            if (venue=="Jimbaran Sales Deck")
            {
                 string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "insert into TO_Manager([TO_Manager_Name],[Office],[TO_Manager_Status],[TO_Manager_CreatedDate],[Venue],[VenueCountry_ID],[Description],[Group_Venue],Manager) values('" + tomanagername.ToUpper() + "','" + tomanageroffice + "','Active','" + time.ToString(format) + "','" + venue + "','" + venueCountryID + "','" + description.ToUpper() + "','Coldline','"+manager.ToUpper()+"');";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();

            string pageName = "TO Manager";
            string details = "TO Manager Created : TO_Manager_Name: " + tomanagername.ToUpper() + ", Office: " + tomanageroffice + ", venue: " + venue + ", venue country: " + venueCountryID + ", description: " + description.ToUpper()+", Manager: "+manager.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            sqlcon.Close();
            }else
            {
                string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(conn);
                sqlcon.Open();

                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";

                string query = "insert into TO_Manager([TO_Manager_Name],[Office],[TO_Manager_Status],[TO_Manager_CreatedDate],[Venue],[VenueCountry_ID],[Description],[Group_Venue],Manager) values('" + tomanagername.ToUpper() + "','" + tomanageroffice + "','Active','" + time.ToString(format) + "','" + venue + "','" + venueCountryID + "','" + description.ToUpper() + "','Inhouse','"+manager.ToUpper()+"');";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();

                string pageName = "TO Manager";
                string details = "TO Manager Created : TO_Manager_Name: " + tomanagername.ToUpper() + ", Office: " + tomanageroffice + ", venue: " + venue + ", venue country: " + venueCountryID + ", description: " + description.ToUpper()+", Manager:"+manager.ToUpper();
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                sqlcon.Close();
            }
           
        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "insert into TO_Manager([TO_Manager_Name],[Office],[TO_Manager_Status],[TO_Manager_CreatedDate],[Venue],[VenueCountry_ID],[Description],[Group_Venue],Manager) values('" + tomanagername.ToUpper() + "','" + tomanageroffice + "','Active','" + time.ToString(format) + "','" + venue + "','" + venueCountryID + "','" + description.ToUpper() + "','','"+manager.ToUpper()+"');";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();

            string pageName = "TO Manager";
            string details = "TO Manager Created : TO_Manager_Name: " + tomanagername + ", Office: " + tomanageroffice + ", venue: " + venue + ", venue country: " + venueCountryID + ", description: " + description+", Manager: "+manager.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            sqlcon.Close();

        }

       


    }

    [WebMethod]
    public static string getAllToManager()
    {
        string office1 = HttpContext.Current.Session["office"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct tm.TO_Manager_ID,tm.TO_Manager_Name,tm.Office,tm.TO_Manager_Status,v.Venue_Name,tm.VenueCountry_ID,vc.Venue_Country_Name,tm.Description,tm.Group_Venue,tm.Manager from TO_Manager tm join venue v on tm.Venue = v.Venue_Name join VenueCountry vc on tm.VenueCountry_ID=vc.Venue_Country_ID where Office='"+office1+"';";
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
            string group_venue = reader.GetString(8);
            string manager = reader.GetString(9);
            JSON += "[\"" + toManagerID + "\" , \"" + toManagerName + "\",\"" + office + "\",\"" + status + "\",\"" + venueCountryID + "\",\"" + venueCountryName + "\",\"" + venueName + "\",\"" + description + "\",\"" + group_venue + "\",\"" + manager + "\"],";


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
        HttpContext.Current.Session["TO_Manager_Name"] = "";
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select TO_Manager_Name from TO_Manager where TO_Manager_ID='" + toManagerID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["TO_Manager_Name"] = reader.GetString(0);


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
        string details = "To Manager: " + HttpContext.Current.Session["TO_Manager_Name"].ToString() + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }

    [WebMethod]
    public static void updateToManager(string toManagerID, string toManagername, string office, string toManagerstatus, string venue,string venuecountry,string description,string manager)

    {
        HttpContext.Current.Session["to_managerName"] = "";
        HttpContext.Current.Session["to_ManagerOffice"] = "";
        HttpContext.Current.Session["to_ManagerStatus"] = "";
        HttpContext.Current.Session["venue1"] = "";
        HttpContext.Current.Session["venuecountry1"] = "";
        HttpContext.Current.Session["description1"] = "";
        HttpContext.Current.Session["manager"] = "";
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select distinct tm.TO_Manager_ID,tm.TO_Manager_Name,tm.Office,tm.TO_Manager_Status,v.Venue_Name,tm.VenueCountry_ID,vc.Venue_Country_Name,tm.Description,tm.Manager from TO_Manager tm join venue v on tm.Venue = v.Venue_Name join VenueCountry vc on tm.VenueCountry_ID=vc.Venue_Country_ID where TO_Manager_ID='"+toManagerID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["to_managerName"] = reader.GetString(1);
            HttpContext.Current.Session["to_ManagerOffice"] = reader.GetString(2);

            HttpContext.Current.Session["to_ManagerStatus"] = reader.GetString(3);
            HttpContext.Current.Session["venue1"] = reader.GetString(4);

            HttpContext.Current.Session["venuecountry1"] = reader.GetString(5);
            HttpContext.Current.Session["description1"] = reader.GetString(7);
            HttpContext.Current.Session["manager"] = reader.GetString(8);
        }

        if (HttpContext.Current.Session["to_managerName"].ToString().Equals(toManagername))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "TO Manager changed from: " + HttpContext.Current.Session["to_managerName"].ToString() + "To: " + toManagername.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["to_ManagerOffice"].ToString().Equals(office))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Office changed from: " + HttpContext.Current.Session["to_ManagerOffice"].ToString() + "To: " + office;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["to_ManagerStatus"].ToString().Equals(toManagerstatus))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Status changed from: " + HttpContext.Current.Session["to_ManagerStatus"].ToString() + "To: " + toManagerstatus;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["venue1"].ToString().Equals(venue))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Venue changed from: " + HttpContext.Current.Session["venue1"].ToString() + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["venuecountry1"].ToString().Equals(venuecountry))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Venue Country changed from: " + HttpContext.Current.Session["venuecountry1"].ToString() + "To: " + venuecountry;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["description1"].ToString().Equals(description))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Description changed from: " + HttpContext.Current.Session["description1"].ToString() + "To: " + description.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["manager"].ToString().Equals(manager))
        { }
        else
        {
            string pageName = "TO Manager";
            string details = "Manager changed from: " + HttpContext.Current.Session["manager"].ToString() + "To: " + manager.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        reader.Close();
        sqlcon1.Close();


        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (toManagerstatus == "Active")
        {

            string query = "update TO_Manager set [TO_Manager_Name]='" + toManagername.ToUpper() + "',[Office]='" + office + "',[TO_Manager_Status]='" + toManagerstatus + "',[Venue]='" + venue + "',[VenueCountry_ID]='"+venuecountry+"',[Description]='"+description.ToUpper()+"',Manager='"+manager.ToUpper()+"' where [TO_Manager_ID]='" + toManagerID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update TO_Manager set [TO_Manager_Name]='" + toManagername.ToUpper() + "',[Office]='" + office + "',[TO_Manager_Status]='" + toManagerstatus + "',[Venue]='" + venue + "',[TO_Manager_ExpiryDate]='" + time.ToString(format) + "',[VenueCountry_ID]='" + venuecountry + "',[Description]='" + description.ToUpper() + "',Manager='" + manager.ToUpper() + "' where [TO_Manager_ID]='" + toManagerID + "';";
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
        string query = "select Venue_Country_ID ,Venue_Country_Name from VenueCountry where Venue_Country_Status='Active'";
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
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venuecountryID + "') and venue.Venue_Status='Active'; ";
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
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venuecountry + "') and venue.venue_status='Active'";
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
        string office1 = HttpContext.Current.Session["office"].ToString();
        string JSON = "{\n \"names\":[";

        if (profileID == "" || profileID == null)
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {

            SqlDataReader reader = production.searchProfiles(profileID, office1);

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
        string office1 = HttpContext.Current.Session["office"].ToString();
        string JSON = "{\n \"names\":[";

    
            string val = "EditProfile1.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

     
        return JSON;



    }
}