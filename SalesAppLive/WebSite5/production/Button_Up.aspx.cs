using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Button_Up : System.Web.UI.Page
{

    static string office1;
    static string pname;

    static string buttonName;
    static string buttonOffice;
    static string buttonStatus;
    static string venueName1;
    static string venueCountry1;
    static string description1;
    static string user;
    static string ButtonUp_Name;
    public string getdata()
    {
        office1 = (string)Session["office"];
         user = (string)Session["username"];
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
        office1 = (string)Session["office"];
        user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
      //  Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    [WebMethod]
    public static void insertButtonUp(string buttonUpName,string office, string venue,string venuecountry,string description)
    {
       
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string query = "insert into ButtonUp ([ButtonUp_Name],[Office],[ButtonUp_Status],[ButtonUp_CreatedDate],[Venue],[VenueCountry_ID],[Description]) values('" + buttonUpName.ToUpper() + "','" + office + "','Active','" + time.ToString(format) + "','" + venue + "','"+venuecountry+"','"+description.ToUpper()+"');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();
      

        string pageName = "Button Up";
        string details = "Button Up created: ButtonUp_Name: " + buttonUpName + ", office: " + office+", venue: "+venue +", venue country: "+venuecountry+", description: "+description;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        sqlcon.Close();

    }


    //public string getAllVenue()
    //{
    //    string htmlstr = "";
    //    string conn = "Data Source=192.168.20.7;Initial Catalog=Contractapp; User ID=sa;Password=c10h12n2o";
    //    SqlConnection sqlcon = new SqlConnection(conn);
    //    string query = "select Venue_ID ,Venue_Name from venue";
    //    sqlcon.Open();
    //    SqlCommand cmd = new SqlCommand(query, sqlcon);
    //    SqlDataReader reader = cmd.ExecuteReader();

    //    while (reader.Read())
    //    {

    //        string Venue_ID = reader.GetString(0);
    //        string Venue_Name = reader.GetString(1);
    //        htmlstr += "<option value='" + Venue_Name + "'>" + Venue_Name + "</option>";
    //    }



    //    return htmlstr;
    //}

    [WebMethod]
    public static string getAllButtonUp()
    {
        if (office1=="IVO")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            String JSON = "{\n \"names\":[";
            string query = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description from ButtonUp bu  join VenueCountry vc on bu.VenueCountry_ID = vc.Venue_Country_ID where Office = '"+office1+"'; ";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                int buttonUpID = reader.GetInt32(0);
                string buttonUpName = reader.GetString(1);
                string office = reader.GetString(2);
                string status = reader.GetString(3);
                string venueName = reader.GetString(4);
                string venuecountryID = reader.GetString(5);
                string venuecountryName = reader.GetString(6);
                string description = reader.GetString(7);
                JSON += "[\"" + buttonUpID + "\" , \"" + buttonUpName + "\",\"" + office + "\",\"" + status + "\",\"" + venuecountryID + "\",\"" + venuecountryName + "\",\"" + venueName + "\",\"" + description + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            reader.Close();
            sqlcon.Close();
            return JSON;

        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            String JSON = "{\n \"names\":[";
            string query = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description from ButtonUp bu join venue v on bu.Venue=v.Venue_Name join VenueCountry vc on bu.VenueCountry_ID=vc.Venue_Country_ID where Office='" + office1 + "';";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                int buttonUpID = reader.GetInt32(0);
                string buttonUpName = reader.GetString(1);
                string office = reader.GetString(2);
                string status = reader.GetString(3);
                string venueName = reader.GetString(4);
                string venuecountryID = reader.GetString(5);
                string venuecountryName = reader.GetString(6);
                string description = reader.GetString(7);
                JSON += "[\"" + buttonUpID + "\" , \"" + buttonUpName + "\",\"" + office + "\",\"" + status + "\",\"" + venuecountryID + "\",\"" + venuecountryName + "\",\"" + venueName + "\",\"" + description + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            reader.Close();
            sqlcon.Close();
            return JSON;

        }
       
       




    }


    [WebMethod]
    public static void deleteButtonUp(string buttonUpID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = " select ButtonUp_Name from ButtonUp where ButtonUp_ID='"+ buttonUpID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            ButtonUp_Name = reader.GetString(0);


        }
        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from ButtonUp where [ButtonUp_ID]='" + buttonUpID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Button Up";
        string details = "Button Up:" + ButtonUp_Name + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }

    [WebMethod]
    public static void updateButtonUp(string buttonUpID, string buttonUpName, string office, string status,string venueCountry, string venueName,string description)
    {

        if (office1 == "IVO")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();

            string query1 = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description from ButtonUp bu join VenueCountry vc on bu.VenueCountry_ID=vc.Venue_Country_ID where Office='IVO' and ButtonUp_ID='" + buttonUpID + "'";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buttonName = reader.GetString(1);
                buttonOffice = reader.GetString(2);

                buttonStatus = reader.GetString(3);
                venueName1 = reader.GetString(4);

                venueCountry1 = reader.GetString(5);
                description1 = reader.GetString(7);
            }
            if (buttonName.Equals(buttonUpName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Button Up changed from: " + buttonName + "To: " + buttonUpName;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (buttonOffice.Equals(office))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Office changed from: " + buttonOffice + "To: " + office;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            if (buttonStatus.Equals(status))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Status changed from: " + buttonStatus + "To: " + status;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }


            if (venueName1.Equals(venueName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue changed from: " + venueName1 + "To: " + venueName;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (venueCountry1.Equals(venueCountry))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue Country changed from: " + venueCountry1 + "To: " + venueCountry;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (description1.Equals(description))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Description changed from: " + description1 + "To: " + description;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon1.Close();

            SqlConnection sqlcon = new SqlConnection(conn);

            sqlcon.Open();


            if (status == "Active")
            {

                string query = "update ButtonUp set [ButtonUp_Name]='" + buttonUpName.ToUpper() + "',[Office]='" + office + "',[ButtonUp_Status]='" + status + "',[Venue]='" + venueName + "',[VenueCountry_ID]='" + venueCountry + "',[Description]='" + description.ToUpper() + "' where [ButtonUp_ID]='" + buttonUpID + "';";
                SqlCommand cmd2 = new SqlCommand(query, sqlcon);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string query = "update ButtonUp set [ButtonUp_Name]='" + buttonUpName.ToUpper() + "',[Office]='" + office + "',[ButtonUp_Status]='" + status + "',[ButtonUp_ExpiryDate]='" + time.ToString(format) + "',[Venue]='" + venueName + "',[VenueCountry_ID]='" + venueCountry + "',[Description]='" + description.ToUpper() + "' where [ButtonUp_ID]='" + buttonUpID + "';";
                SqlCommand cmd2 = new SqlCommand(query, sqlcon);
                cmd2.ExecuteNonQuery();
            }

            sqlcon.Close();
        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();

            string query1 = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description from ButtonUp bu join venue v on bu.Venue=v.Venue_Name join VenueCountry vc on bu.VenueCountry_ID=vc.Venue_Country_ID where Office='HML' and ButtonUp_ID='" + buttonUpID + "'";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buttonName = reader.GetString(1);
                buttonOffice = reader.GetString(2);

                buttonStatus = reader.GetString(3);
                venueName1 = reader.GetString(4);

                venueCountry1 = reader.GetString(5);
                description1 = reader.GetString(7);
            }
            if (buttonName.Equals(buttonUpName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Button Up changed from: " + buttonName + "To: " + buttonUpName;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (buttonOffice.Equals(office))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Office changed from: " + buttonOffice + "To: " + office;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            if (buttonStatus.Equals(status))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Status changed from: " + buttonStatus + "To: " + status;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }


            if (venueName1.Equals(venueName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue changed from: " + venueName1 + "To: " + venueName;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (venueCountry1.Equals(venueCountry))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue Country changed from: " + venueCountry1 + "To: " + venueCountry;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (description1.Equals(description))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Description changed from: " + description1 + "To: " + description;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon1.Close();

            SqlConnection sqlcon = new SqlConnection(conn);

            sqlcon.Open();


            if (status == "Active")
            {

                string query = "update ButtonUp set [ButtonUp_Name]='" + buttonUpName.ToUpper() + "',[Office]='" + office + "',[ButtonUp_Status]='" + status + "',[Venue]='" + venueName + "',[VenueCountry_ID]='" + venueCountry + "',[Description]='" + description.ToUpper() + "' where [ButtonUp_ID]='" + buttonUpID + "';";
                SqlCommand cmd2 = new SqlCommand(query, sqlcon);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string query = "update ButtonUp set [ButtonUp_Name]='" + buttonUpName.ToUpper() + "',[Office]='" + office + "',[ButtonUp_Status]='" + status + "',[ButtonUp_ExpiryDate]='" + time.ToString(format) + "',[Venue]='" + venueName + "',[VenueCountry_ID]='" + venueCountry + "',[Description]='" + description.ToUpper() + "' where [ButtonUp_ID]='" + buttonUpID + "';";
                SqlCommand cmd2 = new SqlCommand(query, sqlcon);
                cmd2.ExecuteNonQuery();
            }

            sqlcon.Close();
        }
       

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
    public static string getAllVenue1(string venueCountryID)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venueCountryID + "') and venue.Venue_Status='Active';";
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
    public static string getAllVenue(string venuecountryID)
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
        string JSON = "{\n \"names\":[";

        if (office1 == "HML")
        {


            string val = "../../Contractsite/IndiaEdit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        else if (office1 == "IVO")
        {


            string val = "../../Contractsite/Edit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }



        return JSON;



    }

}