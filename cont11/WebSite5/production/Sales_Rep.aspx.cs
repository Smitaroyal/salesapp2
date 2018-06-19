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
    static string pname;
    static string office1;


    static string Sales_Rep_Name;
    static string Sales_Rep_Status;
    static string Venue_Country_ID;
    static string SalesRepOffice;
    static string Venue_Name;
    static string Description1;
    static string user;
    static string Sales_Rep_Name1;
    public string getdata()
    {
         office1 = (string)Session["office"];
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
        
        
        office1 = (string)Session["office"];
      
            string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    [WebMethod]
    public static void insertSalesRep(string saleRepName, string office, string venueCountry, string venue,string description)
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

                string query = "insert into Sales_Rep ([Sales_Rep_ID],[Sales_Rep_Name],[Sales_Rep_Status],[Sales_Rep_Created_Date],[Venue_Country_ID],[Office],[Venue],[Description]) values('" + salesRepID + "','" + saleRepName.ToUpper() + "','Active','" + time.ToString(format) + "','" + venueCountry + "','" + office + "','" + venue+ "','" + description.ToUpper()+ "');";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();


                string query1 = "update Admin_ID_gen set Sales_Rep_ID='" + id + "';";
                SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
                cmd4.ExecuteNonQuery();
                sqlcon.Close();

                string pageName = "Sales Rep";
                string details = "Sales Rep Created : Sales_Rep_Name: " + saleRepName + ", office: " + office+ ", venueCountry: " +venueCountry+", venue: "+venue+", description: "+description;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());





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

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct sp.Sales_Rep_ID,sp.Sales_Rep_Name,sp.Sales_Rep_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,sp.Office,v.Venue_Name,sp.Description from Sales_Rep sp join VenueCountry vc on sp.Venue_country_ID=vc.Venue_Country_ID join venue v on sp.Venue=v.Venue_Name where Office='"+office1+"'; ";
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

            JSON += "[\"" + salesRepID + "\" , \"" + salesRepName + "\",\"" + status + "\",\"" + venueCountryID + "\",\"" + venueCountryName + "\",\"" + office + "\",\"" + venueName + "\",\"" + description + "\"],";


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
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='"+ venueCountryID + "'); ";
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
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select Sales_Rep_Name from Sales_Rep where Sales_Rep_ID='" + salesRepID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Sales_Rep_Name1 = reader.GetString(0);


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
        string details = "Sales Rep: " + Sales_Rep_Name1 + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }


    [WebMethod]
    public static void updateSalesRep(string salesRepID, string salesRepName, string status, string office,string venueCountryID,string venue,string description)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select distinct sp.Sales_Rep_ID,sp.Sales_Rep_Name,sp.Sales_Rep_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,sp.Office,v.Venue_Name,sp.Description from Sales_Rep sp join VenueCountry vc on sp.Venue_country_ID=vc.Venue_Country_ID join venue v on sp.Venue=v.Venue_Name where Office='"+office+"' and Sales_Rep_ID='"+salesRepID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Sales_Rep_Name = reader.GetString(1);
            Sales_Rep_Status = reader.GetString(2);

            Venue_Country_ID = reader.GetString(3);
            SalesRepOffice = reader.GetString(5);

            Venue_Name = reader.GetString(6);
            Description1 = reader.GetString(7);
        }

        if (Sales_Rep_Name.Equals(salesRepName))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Sales Rep changed from: " + Sales_Rep_Name + "To: " + salesRepName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (Sales_Rep_Status.Equals(status))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Status changed from: " + Sales_Rep_Status + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (Venue_Country_ID.Equals(venueCountryID))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Venue Country changed from: " + Venue_Country_ID + "To: " + venueCountryID;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (SalesRepOffice.Equals(office))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Office changed from: " + SalesRepOffice + "To: " + office;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (Venue_Name.Equals(venue))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "venue changed from: " + Venue_Name + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (Description1.Equals(description))
        { }
        else
        {
            string pageName = "Sales Rep";
            string details = "Description changed from: " + Description1 + "To: " + description;
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



}