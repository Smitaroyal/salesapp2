using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Globalization;

public partial class WebSite5_production_InhouseStatsIndia : System.Web.UI.Page
{
    
    public string getdata()
    {
        string user = (string)Session["username"];
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

        string user = (string)Session["username"];
         // office = (string)Session["office"];
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
    public static string checkDuplicate(string venue,string groupVenue, string date)
    {
        string JSON = "{\n \"names\":[";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        DateTime dtt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        string date2 = dtt.ToString("yyyy-MM-dd");
        sqlcon1.Open();
        string query1 = "select * from Inhouse_Stats_Indian where Venue='"+venue+"' and  Group_Venue='" + groupVenue + "' and IDate='" + date2 + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader1 = cmd.ExecuteReader();
        if (reader1.HasRows)
        {
            JSON += "[\"" + "1" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "2" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        return JSON;

    }

    [WebMethod]
    public static void insertInhouseStats(string venue, string groupvenue, string date,string val,string val1,string val4)
    {
           string user = HttpContext.Current.Session["username"].ToString();
           string office = HttpContext.Current.Session["office"].ToString();
    
            HttpContext.Current.Session["log"] = "";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            string date1 = dt.ToString("yyyy-MM-dd");

            // string vals = "ODYSSEY,EXCHANGE,FLY BUYS,WD2,MEMBER MARKETING,HOTEL,OTHER,KCV1";
            string[] array = val.Split(',');
            string[] array1 = val1.Split(',');
         
            string[] array4 = val4.Split(',');



            DateTime time = DateTime.Parse(date1);
            int returnNumber = 0;
            CultureInfo ciGetNumber = CultureInfo.CurrentCulture;
            // returnNumber = ciGetNumber.Calendar.GetWeekOfYear(dtDate, CalendarWeekRule.FirstDay, DayOfWeek.Friday);
            returnNumber = ciGetNumber.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFullWeek, DayOfWeek.Saturday);

            for (int i = 0; i <= array.Length - 1; i++)
            {
                string query = "insert into Inhouse_Stats_Indian values ('"+ venue + "','" + groupvenue + "','" + array[i] + "','" + date1 + "','" + array1[i] + "','" + returnNumber + "','" + array4[i] + "')";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();

                HttpContext.Current.Session["log"] += " Venue:"+ venue + ", Group venue: " + groupvenue + " , Sub Venue: " + array[i] + " ,Date: " + date1 + " ,Occupied: " + array1[i] + ", Unique: " + array4[i] + "  ";


            }
            string pageName = "Inhouse Stats India";
            string details = "Inhouse Stats India inserted : " + HttpContext.Current.Session["log"];
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            sqlcon.Close();

        

    }




    public string getVenueOnCountry()
    {
        string office = HttpContext.Current.Session["office"].ToString();
        string countryID;
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        //String JSON = "{\n \"names\":[";
        string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='" + office + "' and Venue_Country_Status='Active';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            countryID = reader.GetString(0);
            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select Venue_Name,Venue_ID from venue where Venue_Country_ID='" + countryID + "' and Venue_Status='Active';";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                var venueName = reader1.GetString(0);
                var venueID = reader1.GetString(1);
                //JSON += "[\"" + venueName + "\" , \"" + venueID + "\"],";
                htmlstr += "<option value='" + venueID + "'>" + venueName + "</option>";
            }

            reader1.Close();
            sqlcon1.Close();
        }

        reader.Close();
        sqlcon.Close();
        return htmlstr;



    }


    [WebMethod]
    public static string getGroupVenueOnVenue(string venue)
    {
      
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        string query = "select Venue_Group_ID,Venue_Group_Name from Venue_Group where Venue_ID='"+venue+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string Venue_Group_ID = reader.GetString(0);
                string Venue_Group_Name = reader.GetString(1);
               
      

                JSON += "[\"" + Venue_Group_ID + "\",\"" + Venue_Group_Name + "\"],";

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

        sqlcon.Close();
        return JSON;

    }


    [WebMethod]
    public static string getSubVenueOnVenueGroup(string groupVenue)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        string query = "select SVenue_India_Name from sub_Venue_India where GroupVenue_ID='"+ groupVenue + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string SVenue_India_Name = reader.GetString(0);
              


                JSON += "[\"" + SVenue_India_Name + "\"],";

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

        sqlcon.Close();
        return JSON;

    }



    [WebMethod]
    public static string getAllInhouseStats(string date,string groupVenue,string venue)
    {
        DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        string date1 = dt.ToString("yyyy-MM-dd");
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        string query = "select SRN,Group_Venue,Sub_venue,convert(varchar(50),IDate,	105),Occu,Weekno,[Unique],Venue from Inhouse_Stats_Indian where IDate='" + date1 + "' and Group_Venue='"+groupVenue+"' and Venue='"+venue+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string groupvenue = reader.GetString(1);
                string subVenue = reader.GetString(2);
                string dates = reader.GetString(3);
                int occupied = reader.GetInt32(4);
                int weekno = reader.GetInt32(5);
                int uniq = reader.GetInt32(6);
                string venues = reader.GetString(7);

                JSON += "[\"" + ID + "\",\"" + groupvenue + "\",\"" + subVenue + "\",\"" + dates + "\",\"" + occupied + "\",\"" + weekno + "\",\"" + uniq + "\",\"" + venues + "\"],";
                
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
        
        sqlcon.Close();
        return JSON;
        
    }

    [WebMethod]
    public static void updateInnhouseStats(string valID, string valOccupied, string valUnique)
    {
        HttpContext.Current.Session["Group_Venue"] = ""; HttpContext.Current.Session["Sub_venue"] = "";
        HttpContext.Current.Session["IDate"] = ""; HttpContext.Current.Session["Occu"] = "";
        HttpContext.Current.Session["NTour"] = ""; HttpContext.Current.Session["NDeal"] = "";
        HttpContext.Current.Session["Uniq"] = "";
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["log"] = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();
        string[] ID = valID.Split(',');

        string[] array = valID.Split(',');
        string[] array1 = valOccupied.Split(',');
        string[] array4 = valUnique.Split(',');



        for (int i = 0; i <= ID.Length - 1; i++)
        {
            string query1 = "select Group_Venue, Sub_venue, convert(varchar,IDate) , Occu,[Unique] from Inhouse_Stats_Indian where SRN = '" + ID[i] + "'";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                HttpContext.Current.Session["Group_Venue"] = reader.GetString(0);
                HttpContext.Current.Session["Sub_venue"] = reader.GetString(1);
                HttpContext.Current.Session["IDate"] = reader.GetString(2);
                HttpContext.Current.Session["Occu"] = reader.GetInt32(3);
                HttpContext.Current.Session["Uniq"] = reader.GetInt32(4);
            }

            if (HttpContext.Current.Session["Occu"].ToString().Equals(array1[i]))
            {

            }else
            {
                string pageName = "Inhouse Stats India";
                string details = HttpContext.Current.Session["Group_Venue"] + "," + HttpContext.Current.Session["Sub_venue"] + ", " + HttpContext.Current.Session["IDate"] + ", Occupied Changed from: " + HttpContext.Current.Session["Occu"] + "  to: " + array1[i];
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            

            if (HttpContext.Current.Session["Uniq"].ToString().Equals(array4[i]))
            {
            }
            else
            {
                string pageName = "Inhouse Stats India";
                string details = HttpContext.Current.Session["Group_Venue"] + "," + HttpContext.Current.Session["Sub_venue"] + ", " + HttpContext.Current.Session["IDate"] + ",Unique Changed from: " + HttpContext.Current.Session["Uniq"] + "  to: " + array4[i];
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            reader.Close();

            HttpContext.Current.Session["Group_Venue"] = ""; HttpContext.Current.Session["Sub_venue"] = "";
            HttpContext.Current.Session["IDate"] = ""; HttpContext.Current.Session["Occu"] = "";
            HttpContext.Current.Session["NTour"] = ""; HttpContext.Current.Session["NDeal"] = "";
            HttpContext.Current.Session["Uniq"] = "";
        }
        sqlcon1.Close();
        
        
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();


        for (int i = 0; i <= array.Length - 1; i++)
        {
           
            string query = "update Inhouse_Stats_Indian set Occu='" + array1[i] + "',[Unique]='"+array4[i]+"' where SRN='" + array[i] + "';";

            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();


        }
        sqlcon.Close();

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
        string office = HttpContext.Current.Session["office"].ToString();
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
        string office = HttpContext.Current.Session["office"].ToString();
        string JSON = "{\n \"names\":[";

            string val = "EditProfile1.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

     
        return JSON;



    }
}