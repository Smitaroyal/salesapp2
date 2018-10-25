using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_Marketing_Program : System.Web.UI.Page
{
    static string office;
    static string office1;
    static string countryID;
    static string pname;
    static string Manager_Name1;
    static string Manager_Status1;
    static string VenueGroup1;
    static string Venue1;
    static string user;

    static string Manager_Name;
    public string getdata()
    {
        office1 = (string)Session["office"];
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
        office1 = (string)Session["office"];
        user = (string)Session["username"];
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
    public static void insertManagers(string managerName,string venue, string venueGroup)
    {

        int id = 0;

        string value = "M";
        string managerID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";

        string sql = "select Manager_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        managerID = value + id;

        string query = "  insert into Managers (Manager_Id,Manager_Name,Manager_Status,Office,Created_Date,Venue,VenueGroup) values('"+ managerID + "','"+managerName.ToUpper()+"','Active','"+office+"','"+time.ToString(format)+"','"+venue+"','"+venueGroup+"')";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

       

        string query1 = "update Admin_ID_gen set Manager_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Manager";
        string details = " Manager Created : Manager Name: " + managerName + ", Venue: "+venue+", Venue Group: "+venueGroup;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

  [WebMethod]
    public static string getManagers()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";

      
            string query1 = "select m.Manager_Id,m.Manager_Name,m.Manager_Status,v.Venue_ID,m.Venue,m.VenueGroup from Managers m join venue v on v.Venue_Name = m.Venue where m.Manager_Status = 'Active' ";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                string Manager_Id = reader1.GetString(0);
                var Manager_Name = reader1.GetString(1);
                var Manager_Status = reader1.GetString(2);
               
                var Venue_ID = reader1.GetString(3);
                var Venue_Name = reader1.GetString(4);
                var Venue_Group_Name = reader1.GetString(5);
                JSON += "[\"" + Manager_Id + "\" , \"" + Manager_Name + "\", \"" + Manager_Status + "\", \"" + Venue_ID + "\", \"" + Venue_Name + "\", \"" + Venue_Group_Name + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
           JSON += "] \n}";
        

        sqlcon1.Close();
            return JSON ;
        
    }

  
   
    [WebMethod]
    public static void updateManagers(string managerID, string managerName, string venue, string venueGroup,string status)

   {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select m.Manager_Id,m.Manager_Name,m.Manager_Status,m.Venue,m.VenueGroup from Managers m join venue v on v.Venue_Name = m.Venue where m.Manager_Status = 'Active' and Manager_Id='"+managerID+"';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Manager_Name1 = reader.GetString(1);
            Manager_Status1 = reader.GetString(2);

            Venue1 = reader.GetString(3);
            VenueGroup1 = reader.GetString(4);

        }

        if (Manager_Name1.Equals(managerName))
        { }
        else
        {
            string pageName = "Manager";
            string details = " Manager Name changed from: " + Manager_Name1 + "To: " + managerName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (Manager_Status1.Equals(status))
        { }
        else
        {
            string pageName = "Manager";
            string details = "Status changed from: " + Manager_Status1 + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (Venue1.Equals(venue))
        { }
        else
        {
            string pageName = "Manager";
            string details = "Venue from: " + Venue1 + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (VenueGroup1.Equals(venueGroup))
        { }
        else
        {
            string pageName = "Manager";
            string details = "Venue Group from: " + VenueGroup1 + "To: " + venueGroup;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        if (status=="Active")
        {
            string query = "update managers set Manager_Name = '"+managerName.ToUpper()+"', Manager_Status = '"+status+"', Venue = '"+venue+"', VenueGroup = '"+venueGroup+"' where Manager_Id = '"+managerID+"'";

            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update managers set Manager_Name = '"+managerName.ToUpper()+"', Manager_Status = '"+status+"', Expiry_Date = '"+time.ToString(format)+"', Venue = '"+venue+"', VenueGroup = '"+venueGroup+"' where Manager_Id = '"+managerID+"'";
            
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
      
           
           
        sqlcon.Close();

    }


    public string getVenue()
    {
        string countryID;
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        //String JSON = "{\n \"names\":[";
        string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='" + office1 + "' and Venue_Country_Status='Active';";
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
        //JSON = JSON.Substring(0, JSON.Length - 1);
        //JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return htmlstr;



    }

    [WebMethod]
     public static string getVenueGroup(string venue)
    {
      
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        String JSON = "{\n \"names\":[";

        SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select Venue_Group_ID, Venue_Group_Name from Venue_Group where Venue_ID ='"+venue+"' ";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                var venueGroupID = reader1.GetString(0);
                var venueGroupName = reader1.GetString(1);
            JSON += "[\"" + venueGroupName + "\" , \"" + venueGroupName + "\"],";

        }
            
         JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
      
        sqlcon1.Close();
        return JSON;



    }


    [WebMethod]
    public static void deleteManager(string managerID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select Manager_Name from Managers where Manager_Id='"+managerID+"';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Manager_Name = reader.GetString(0);
           

        }
        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Managers where [Manager_Id]='" + managerID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Manager";
        string details = "Manager: "+Manager_Name + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

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