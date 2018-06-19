using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Sales_Rep_Coldline : System.Web.UI.Page
{

    static string office1;
    static string pname;
    static string Status1;
    static string Venue1;
    static string AgentName1;
    static string user;
    static string AgentName;
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

        //string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    [WebMethod]
    public static void insertSalesRep(string salesRep, string venue )
    {

        int id = 0;
      
        string value = "IND";
        string salesRepID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select Sales_Rep_Coldline_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        salesRepID = value + id;
        string query = "insert into Agent_GroupVenue ([Agent_id],[AgentName],[Status],[Created_Date],[Venue_Group_ID],[Venue]) values('"+ salesRepID + "','"+ salesRep.ToUpper() + "','Active','"+time.ToString(format)+"','Coldline','"+venue+"')";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        string query3 = "insert into agent values('"+ salesRepID + "', '"+salesRep.ToUpper()+"', 'Active', '"+time.ToString(format)+"','', '"+office1+"')";
        SqlCommand cmd3 = new SqlCommand(query3, sqlcon);
        cmd3.ExecuteNonQuery();

        string query1 = "update Admin_ID_gen set Sales_Rep_Coldline_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Agents Coldline";
        string details = "Agents Coldline created: Agent Name " + salesRep + ", Venue: " + venue;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

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
    public static string getAllSalesRep()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select * from Agent_GroupVenue";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

           string salesRepID = reader.GetString(0);
            string venueGroup = reader.GetString(1);
            string status = reader.GetString(2);
            string venueName = reader.GetString(4);
        
            string agentName = reader.GetString(5);
            JSON += "[\"" + salesRepID + "\" , \"" + agentName + "\",\"" + status + "\",\"" + venueGroup + "\",\"" + venueName + "\"],";


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

        string query1 = "select AgentName from Agent_GroupVenue where Agent_id='" + salesRepID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            AgentName = reader.GetString(0);


        }
        reader.Close();
        sqlcon1.Close();
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Agent_GroupVenue where [Agent_id]='" + salesRepID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Agents Coldline";
        string details = "Agent Coldline: " + AgentName + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

    [WebMethod]
    public static void updateSalesRep(string salesRepID, string salesRepName, string status, string venueName)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select Agent_id,Status,Venue,AgentName from Agent_GroupVenue where Agent_id='" + salesRepID + "'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Status1 = reader.GetString(1);
            Venue1 = reader.GetString(2);

            AgentName1 = reader.GetString(3);

        }

       

        if (Status1.Equals(status))
        { }
        else
        {
            string pageName = "Agents Coldline";
            string details = "Status changed from: " + Status1 + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (Venue1.Equals(venueName))
        { }
        else
        {
            string pageName = "Agents Coldline";
            string details = "Venue changed from: " + Venue1 + "To: " + venueName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (AgentName1.Equals(salesRepName))
        { }
        else
        {
            string pageName = "Agents Coldline";
            string details = "Agent Name changed from: " + AgentName1 + "To: " + salesRepName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {
            string query = "update Agent_GroupVenue set [AgentName]='" + salesRepName.ToUpper() + "',[Status]='" + status + "',[Venue]='" + venueName + "' where [Agent_id]='" + salesRepID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();

            string query2 = "  update Agent set Agent_Name='"+ salesRepName.ToUpper() + "',Agent_Status='"+status+"' where Agent_ID='"+salesRepID+"';";
            SqlCommand cmd3 = new SqlCommand(query2, sqlcon);
            cmd3.ExecuteNonQuery();
        }
        else
        {
            
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Agent_GroupVenue set [AgentName]='" + salesRepName.ToUpper() + "',[Status]='" + status + "',[Venue]='" + venueName + "' where [Agent_id]='" + salesRepID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();


            string query2 = "  update Agent set Agent_Name='"+salesRepName.ToUpper()+"',Agent_Status='"+status+"',Agent_Expiry_Date='"+time.ToString(format)+"' where Agent_ID='"+salesRepID+"';";
            SqlCommand cmd3 = new SqlCommand(query2, sqlcon);
            cmd3.ExecuteNonQuery();
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
    public static string getAllVenue1()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='VC004'); ";
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