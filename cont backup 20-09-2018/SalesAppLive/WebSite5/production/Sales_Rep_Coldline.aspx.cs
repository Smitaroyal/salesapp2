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

    
    public string getdata()
    {
       string  office1 = (string)Session["office"];
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
     string office1 = (string)Session["office"];
        string  user = (string)Session["username"];
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
    public static void insertSalesRep(string salesRep, string venue )
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string office1 = HttpContext.Current.Session["office"].ToString();
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
        string details = "Agents Coldline created: Agent Name " + salesRep.ToUpper() + ", Venue: " + venue;
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
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["AgentName"] = "";
       
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select AgentName from Agent_GroupVenue where Agent_id='" + salesRepID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["AgentName"] = reader.GetString(0);


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
        string details = "Agent Coldline: " + HttpContext.Current.Session["AgentName"].ToString()+ " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

    [WebMethod]
    public static void updateSalesRep(string salesRepID, string salesRepName, string status, string venueName)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["Status1"] = "";
        HttpContext.Current.Session["Venue1"] = "";
        HttpContext.Current.Session["AgentName1"] = "";

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select Agent_id,Status,Venue,AgentName from Agent_GroupVenue where Agent_id='" + salesRepID + "'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["Status1"] = reader.GetString(1);
            HttpContext.Current.Session["Venue1"] = reader.GetString(2);

            HttpContext.Current.Session["AgentName1"] = reader.GetString(3);

        }

       

        if (HttpContext.Current.Session["Status1"].ToString().Equals(status))
        { }
        else
        {
            string pageName = "Agents Coldline";
            string details = "Status changed from: " + HttpContext.Current.Session["Status1"].ToString() + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["Venue1"].ToString().Equals(venueName))
        { }
        else
        {
            string pageName = "Agents Coldline";
            string details = "Venue changed from: " + HttpContext.Current.Session["Venue1"].ToString() + "To: " + venueName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["AgentName1"].ToString().Equals(salesRepName))
        { }
        else
        {
            string pageName = "Agents Coldline";
            string details = "Agent Name changed from: " + HttpContext.Current.Session["AgentName1"].ToString() + "To: " + salesRepName.ToUpper();
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
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='VC4'); ";
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