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


    public string getdata()
    {
       // office1 = (string)Session["office"];
       string  user = (string)Session["username"];
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
      //  Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    [WebMethod]
    public static void insertButtonUp(string buttonUpName,string office, string venue,string venuecountry,string description,string buttonUpManager)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string query = "insert into ButtonUp ([ButtonUp_Name],[Office],[ButtonUp_Status],[ButtonUp_CreatedDate],[Venue],[VenueCountry_ID],[Description],Manager) values('" + buttonUpName.ToUpper() + "','" + office + "','Active','" + time.ToString(format) + "','" + venue + "','"+venuecountry+"','"+description.ToUpper()+"','"+ buttonUpManager.ToUpper() + "');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();
      

        string pageName = "Button Up";
        string details = "Button Up created: ButtonUp_Name: " + buttonUpName.ToUpper() + ", office: " + office+", venue: "+venue +", venue country: "+venuecountry+", description: "+description.ToUpper()+", Manager: "+ buttonUpManager.ToUpper();
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
        string office1 = HttpContext.Current.Session["office"].ToString();
        if (office1=="IVO")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            String JSON = "{\n \"names\":[";
            string query = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description,bu.Manager from ButtonUp bu  join VenueCountry vc on bu.VenueCountry_ID = vc.Venue_Country_ID where Office = '"+office1+"'; ";
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
                string buttonUpManager = reader.GetString(8);
                JSON += "[\"" + buttonUpID + "\" , \"" + buttonUpName + "\",\"" + office + "\",\"" + status + "\",\"" + venuecountryID + "\",\"" + venuecountryName + "\",\"" + venueName + "\",\"" + description + "\",\"" + buttonUpManager + "\"],";


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
            string query = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description,bu.Manager from ButtonUp bu join venue v on bu.Venue=v.Venue_Name join VenueCountry vc on bu.VenueCountry_ID=vc.Venue_Country_ID where Office='" + office1 + "';";
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
                string buttonUpManager = reader.GetString(8);
                JSON += "[\"" + buttonUpID + "\" , \"" + buttonUpName + "\",\"" + office + "\",\"" + status + "\",\"" + venuecountryID + "\",\"" + venuecountryName + "\",\"" + venueName + "\",\"" + description + "\",\"" + buttonUpManager + "\"],";


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
      
        HttpContext.Current.Session["ButtonUp_Name"] = "";
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = " select ButtonUp_Name from ButtonUp where ButtonUp_ID='"+ buttonUpID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["ButtonUp_Name"] = reader.GetString(0);


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
        string details = "Button Up:" + HttpContext.Current.Session["ButtonUp_Name"].ToString() + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }

    [WebMethod]
    public static void updateButtonUp(string buttonUpID, string buttonUpName, string office, string status,string venueCountry, string venueName,string description,string buttonUpManager)
    {
        HttpContext.Current.Session["buttonName"] = "";
        HttpContext.Current.Session["buttonOffice"] = "";
        HttpContext.Current.Session["buttonStatus"] = "";
        HttpContext.Current.Session["venueName1"] = "";
        HttpContext.Current.Session["venueCountry1"] = "";
        HttpContext.Current.Session["description1"] = "";
        HttpContext.Current.Session["Manager"] = "";



        string user = HttpContext.Current.Session["username"].ToString();
        string office1 = HttpContext.Current.Session["office"].ToString();
        if (office1 == "IVO")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();

            string query1 = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description,bu.Manager from ButtonUp bu join VenueCountry vc on bu.VenueCountry_ID=vc.Venue_Country_ID where Office='IVO' and ButtonUp_ID='" + buttonUpID + "'";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HttpContext.Current.Session["buttonName"]   = reader.GetString(1);
                HttpContext.Current.Session["buttonOffice"]  = reader.GetString(2);

                HttpContext.Current.Session["buttonStatus"]  = reader.GetString(3);
                HttpContext.Current.Session["venueName1"]  = reader.GetString(4);

                HttpContext.Current.Session["venueCountry1"]  = reader.GetString(5);
                HttpContext.Current.Session["description1"]  = reader.GetString(7);
                HttpContext.Current.Session["Manager"] = reader.GetString(8);
            }
            if (HttpContext.Current.Session["buttonName"].ToString().Equals(buttonUpName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Button Up changed from: " + HttpContext.Current.Session["buttonName"].ToString() + "To: " + buttonUpName.ToUpper();
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["buttonOffice"].ToString().Equals(office))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Office changed from: " + HttpContext.Current.Session["buttonOffice"].ToString() + "To: " + office;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            if (HttpContext.Current.Session["buttonStatus"].ToString().Equals(status))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Status changed from: " + HttpContext.Current.Session["buttonStatus"].ToString() + "To: " + status;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }


            if (HttpContext.Current.Session["venueName1"].ToString().Equals(venueName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue changed from: " + HttpContext.Current.Session["venueName1"] .ToString()+ "To: " + venueName;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["venueCountry1"].ToString().Equals(venueCountry))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue Country changed from: " + HttpContext.Current.Session["venueCountry1"].ToString() + "To: " + venueCountry;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["description1"].ToString().Equals(description))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Description changed from: " + HttpContext.Current.Session["description1"].ToString() + "To: " + description.ToUpper();
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["Manager"].ToString().Equals(buttonUpManager))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Manager changed from: " + HttpContext.Current.Session["Manager"].ToString() + "To: " + buttonUpManager.ToUpper();
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
            HttpContext.Current.Session["buttonName"] = "";
            HttpContext.Current.Session["buttonOffice"] = "";
            HttpContext.Current.Session["buttonStatus"] = "";
            HttpContext.Current.Session["venueName1"] = "";
            HttpContext.Current.Session["venueCountry1"] = "";
            HttpContext.Current.Session["description1"] = "";
            HttpContext.Current.Session["Manager"] = "";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();

            string query1 = "select distinct bu.ButtonUp_ID,bu.ButtonUp_Name,bu.Office,bu.ButtonUp_Status,bu.Venue,bu.VenueCountry_ID,vc.Venue_Country_Name,bu.Description,bu.Manager from ButtonUp bu join venue v on bu.Venue=v.Venue_Name join VenueCountry vc on bu.VenueCountry_ID=vc.Venue_Country_ID where Office='HML' and ButtonUp_ID='" + buttonUpID + "'";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HttpContext.Current.Session["buttonName"]   = reader.GetString(1);
                HttpContext.Current.Session["buttonOffice"]     = reader.GetString(2);

                HttpContext.Current.Session["buttonStatus"]    = reader.GetString(3);
                HttpContext.Current.Session["venueName1"]   = reader.GetString(4);

                HttpContext.Current.Session["venueCountry1"]   = reader.GetString(5);
                HttpContext.Current.Session["description1"]   = reader.GetString(7);
                HttpContext.Current.Session["Manager"] = reader.GetString(8);
            }
            if (HttpContext.Current.Session["buttonName"].ToString().Equals(buttonUpName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Button Up changed from: " + HttpContext.Current.Session["buttonName"].ToString() + "To: " + buttonUpName.ToUpper();
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["buttonOffice"].ToString().Equals(office))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Office changed from: " + HttpContext.Current.Session["buttonOffice"].ToString() + "To: " + office;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            if (HttpContext.Current.Session["buttonStatus"].ToString().Equals(status))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Status changed from: " + HttpContext.Current.Session["buttonStatus"].ToString() + "To: " + status;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }


            if (HttpContext.Current.Session["venueName1"].ToString().Equals(venueName))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue changed from: " + HttpContext.Current.Session["venueName1"].ToString() + "To: " + venueName;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["venueCountry1"].ToString().Equals(venueCountry))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Venue Country changed from: " + HttpContext.Current.Session["venueCountry1"].ToString() + "To: " + venueCountry;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["description1"].ToString().Equals(description))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Description changed from: " + HttpContext.Current.Session["description1"].ToString() + "To: " + description.ToUpper();
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (HttpContext.Current.Session["Manager"].ToString().Equals(buttonUpManager))
            { }
            else
            {
                string pageName = "Button Up";
                string details = "Manager changed from: " + HttpContext.Current.Session["Manager"].ToString() + "To: " + buttonUpManager.ToUpper();
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon1.Close();

            SqlConnection sqlcon = new SqlConnection(conn);

            sqlcon.Open();


            if (status == "Active")
            {

                string query = "update ButtonUp set [ButtonUp_Name]='" + buttonUpName.ToUpper() + "',[Office]='" + office + "',[ButtonUp_Status]='" + status + "',[Venue]='" + venueName + "',[VenueCountry_ID]='" + venueCountry + "',[Description]='" + description.ToUpper() + "',Manager='"+buttonUpManager.ToUpper()+"' where [ButtonUp_ID]='" + buttonUpID + "';";
                SqlCommand cmd2 = new SqlCommand(query, sqlcon);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string query = "update ButtonUp set [ButtonUp_Name]='" + buttonUpName.ToUpper() + "',[Office]='" + office + "',[ButtonUp_Status]='" + status + "',[ButtonUp_ExpiryDate]='" + time.ToString(format) + "',[Venue]='" + venueName + "',[VenueCountry_ID]='" + venueCountry + "',[Description]='" + description.ToUpper() + "',Manager='" + buttonUpManager.ToUpper() + "' where [ButtonUp_ID]='" + buttonUpID + "';";
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