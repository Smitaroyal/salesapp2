using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

public partial class WebSite5_production_Sales_Rep : System.Web.UI.Page
{
  
    public string getdata()
    {
        string office1 = (string)Session["office"];
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
      
          string   user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }
      //  Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    [WebMethod]
    public static void insertSalesRep(string saleRepName, string office, string venueCountry, string venue,string description)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        if (venue== "Jimbaran Sales Deck")
        {
            int id = 0;

            string value = "SR";
            string salesRepID;
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string sql = "select Sales_Rep_ID from Admin_ID_gen";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            string val = (string)cmd.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            salesRepID = value + id;

            string query = "insert into Sales_Rep ([Sales_Rep_ID],[Sales_Rep_Name],[Sales_Rep_Status],[Sales_Rep_Created_Date],[Venue_Country_ID],[Office],[Venue],[Description],[Group_Venue]) values('" + salesRepID + "','" + saleRepName.ToUpper() + "','Active','" + time.ToString(format) + "','" + venueCountry + "','" + office + "','" + venue + "','" + description.ToUpper() + "','Coldline');";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();


            string query1 = "update Admin_ID_gen set Sales_Rep_ID='" + id + "';";
            SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
            cmd4.ExecuteNonQuery();
            sqlcon.Close();

            string pageName = "Sales Rep";
            string details = "Sales Rep Created : Sales_Rep_Name: " + saleRepName + ", office: " + office + ", venueCountry: " + venueCountry + ", venue: " + venue + ", description: " + description;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

        }
        else
        {
            int id = 0;

            string value = "SR";
            string salesRepID;
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string sql = "select Sales_Rep_ID from Admin_ID_gen";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            string val = (string)cmd.ExecuteScalar();
            id = Convert.ToInt32(val) + 1;
            salesRepID = value + id;

            string query = "insert into Sales_Rep ([Sales_Rep_ID],[Sales_Rep_Name],[Sales_Rep_Status],[Sales_Rep_Created_Date],[Venue_Country_ID],[Office],[Venue],[Description],[Group_Venue]) values('" + salesRepID + "','" + saleRepName.ToUpper() + "','Active','" + time.ToString(format) + "','" + venueCountry + "','" + office + "','" + venue + "','" + description.ToUpper() + "','');";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();


            string query1 = "update Admin_ID_gen set Sales_Rep_ID='" + id + "';";
            SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
            cmd4.ExecuteNonQuery();
            sqlcon.Close();

            string pageName = "Sales Rep";
            string details = "Sales Rep Created : Sales_Rep_Name: " + saleRepName.ToUpper() + ", office: " + office + ", venueCountry: " + venueCountry + ", venue: " + venue + ", description: " + description.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

        }
              





    }



    public string getAllVenueCountry()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Venue_Country_ID,Venue_Country_Name from VenueCountry";
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
    public static string getAllSalesRep()
    {
        string office1 = HttpContext.Current.Session["office"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct sp.Sales_Rep_ID,sp.Sales_Rep_Name,sp.Sales_Rep_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,sp.Office,v.Venue_Name,sp.Description,sp.Group_Venue from Sales_Rep sp join VenueCountry vc on sp.Venue_country_ID=vc.Venue_Country_ID join venue v on sp.Venue=v.Venue_Name where Office='"+office1+"'; ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string salesRepID = reader.GetString(0);
            string salesRepName = reader.GetString(1);
            string status = reader.GetString(2);
            string venueCountryID = reader.GetString(3);
            string venueCountryName = reader.GetString(4);
            string office = reader.GetString(5);
            string venueName = reader.GetString(6);
            string description = reader.GetString(7);
            string Group_Venue = reader.GetString(8);

            JSON += "[\"" + salesRepID + "\" , \"" + salesRepName + "\",\"" + status + "\",\"" + venueCountryID + "\",\"" + venueCountryName + "\",\"" + office + "\",\"" + venueName + "\",\"" + description + "\",\"" + Group_Venue + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string getAllVenue(string venueCountryID)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='"+ venueCountryID + "') and venue.Venue_Status='Active';";
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
    public static void deleteSalesRep(string salesRepID)

    {
        HttpContext.Current.Session["Sales_Rep_Name1"] = "";
       
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select Sales_Rep_Name from Sales_Rep where Sales_Rep_ID='" + salesRepID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["Sales_Rep_Name1"] = reader.GetString(0);


        }
        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Sales_Rep where [Sales_Rep_ID]='" + salesRepID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Sales Rep";
        string details = "Sales Rep: " + HttpContext.Current.Session["Sales_Rep_Name1"].ToString() + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }


    [WebMethod]
    public static void updateSalesRep(string salesRepID, string salesRepName, string status, string office,string venueCountryID,string venue,string description)
    {
        HttpContext.Current.Session["Sales_Rep_Name"] = "";
        HttpContext.Current.Session["Sales_Rep_Status"] = "";
        HttpContext.Current.Session["Venue_Country_ID"] = "";
        HttpContext.Current.Session["SalesRepOffice"] = "";
        HttpContext.Current.Session["Venue_Name"] = "";
        HttpContext.Current.Session["Description1"] = "";
        
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select distinct sp.Sales_Rep_ID,sp.Sales_Rep_Name,sp.Sales_Rep_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,sp.Office,v.Venue_Name,sp.Description from Sales_Rep sp join VenueCountry vc on sp.Venue_country_ID=vc.Venue_Country_ID join venue v on sp.Venue=v.Venue_Name where Office='"+office+"' and Sales_Rep_ID='"+salesRepID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["Sales_Rep_Name"] = reader.GetString(1);
            HttpContext.Current.Session["Sales_Rep_Status"] = reader.GetString(2);

            HttpContext.Current.Session["Venue_Country_ID"] = reader.GetString(3);
            HttpContext.Current.Session["SalesRepOffice"] = reader.GetString(5);

            HttpContext.Current.Session["Venue_Name"] = reader.GetString(6);
            HttpContext.Current.Session["Description1"] = reader.GetString(7);
        }

        if (HttpContext.Current.Session["Sales_Rep_Name"].ToString().Equals(salesRepName))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Sales Rep changed from: " + HttpContext.Current.Session["Sales_Rep_Name"].ToString() + "To: " + salesRepName.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Sales_Rep_Status"].ToString().Equals(status))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Status changed from: " + HttpContext.Current.Session["Sales_Rep_Status"].ToString() + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["Venue_Country_ID"].ToString().Equals(venueCountryID))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Venue Country changed from: " + HttpContext.Current.Session["Venue_Country_ID"].ToString() + "To: " + venueCountryID;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["SalesRepOffice"].ToString().Equals(office))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Office changed from: " + HttpContext.Current.Session["SalesRepOffice"].ToString() + "To: " + office;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["Venue_Name"].ToString().Equals(venue))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "venue changed from: " + HttpContext.Current.Session["Venue_Name"].ToString() + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Description1"].ToString().Equals(description))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Description changed from: " + HttpContext.Current.Session["Description1"].ToString() + "To: " + description.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update Sales_Rep set [Sales_Rep_Name]='" + salesRepName.ToUpper() + "',[Sales_Rep_Status]='" + status + "',[Venue_Country_ID]='" + venueCountryID + "',[Office]='"+office+"',[Venue]='"+venue+"',[Description]='"+ description.ToUpper() + "' where [Sales_Rep_ID]='" + salesRepID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Sales_Rep set [Sales_Rep_Name]='" + salesRepName.ToUpper()+ "',[Sales_Rep_Status]='" + status + "',[Sales_Rep_Expiry_Date]='"+time.ToString(format)+"',[Venue_Country_ID]='" + venueCountryID + "',[Office]='" + office + "',[Venue]='" + venue+ "',[Description]='" + description.ToUpper() + "' where [Sales_Rep_ID]='" + salesRepID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

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

        if (office1 == "HML")
        {


            string val = "../../Contractsite/IndiaEdit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        else if (office1 == "IVO")
        {


            string val = "Edit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }



        return JSON;



    }


}