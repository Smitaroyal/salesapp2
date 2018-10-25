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
    static string marktName1;
    static string marktStatus;
    static string Marketing_Program_Name;
    static string venueGroup1;
    static string user;
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

                htmlstr += "<li><a><i class='fa fa-home'></i>" + name + " <span class='fa fa-chevron - down'></span> </a><ul class='nav child_menu'>";
                SqlConnection sqlcon1 = new SqlConnection(conn);
                sqlcon1.Open();
                string query1 = "select * from user_group_access ug where ug.ParentNode='" + name + "' and username ='" + user + "'";
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
        reader.Close();
        sqlcon.Close();
        return htmlstr;



    }

    protected void Page_Load(object sender, EventArgs e)
    {

         user = (string)Session["username"];
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
    public static void insertMarketingProgram(string marktName, string venueGroup)
    {

        int id = 0;

        string value = "MP";
        string marktID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";

        string sql = "select Marketing_Program_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        marktID = value + id;

        string query = "insert into Marketing_Program (Marketing_Program_ID,Marketing_Program_Name,Marketing_Program_Status,Marketing_Program_Created_Date,Venue_Group_ID) values('"+ marktID + "','"+marktName.ToUpper()+"','Active','"+time.ToString(format)+"','"+venueGroup+"')";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

       


        string query1 = "update Admin_ID_gen set Marketing_Program_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Marketing Program";
        string details = " Makerting Program Created : Marketing_Program_Name: " + marktName+", Venue Group: "+venueGroup;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

  [WebMethod]
    public static string getmarketingProgram()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";

     
            string query1 = "select mp.Marketing_Program_ID,mp.Marketing_Program_Name,mp.Marketing_Program_Status,mp.Venue_Group_ID,vg.Venue_Group_Name,vg.Venue_ID,v.Venue_Name from Marketing_Program mp join Venue_Group vg on mp.Venue_Group_ID = vg.Venue_Group_ID join venue v on vg.Venue_ID = v.Venue_ID where mp.Marketing_Program_Status = 'Active'  and v.Venue_Country_ID in('VC004','VC4');";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                string Marketing_Program_ID = reader1.GetString(0);
                var Marketing_Program_Name = reader1.GetString(1);
                var Marketing_Program_Status = reader1.GetString(2);
                var Venue_Group_ID = reader1.GetString(3);
                var Venue_Group_Name = reader1.GetString(4);
                var Venue_ID = reader1.GetString(5);
                var Venue_Name = reader1.GetString(6);

                JSON += "[\"" + Marketing_Program_ID + "\" , \"" + Marketing_Program_Name + "\", \"" + Marketing_Program_Status + "\", \"" + Venue_Group_ID + "\", \"" + Venue_Group_Name + "\", \"" + Venue_ID + "\", \"" + Venue_Name + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        

        sqlcon1.Close();
            return JSON ;
        
    }

  
   
    [WebMethod]
    public static void updateMarketingProgram(string marktID, string marktName, string venueGroup,string status)

   {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select mp.Marketing_Program_ID,mp.Marketing_Program_Name,mp.Marketing_Program_Status,mp.Venue_Group_ID,vg.Venue_Group_Name,vg.Venue_ID,v.Venue_Name from Marketing_Program mp join Venue_Group vg on mp.Venue_Group_ID = vg.Venue_Group_ID join venue v on vg.Venue_ID = v.Venue_ID where mp.Marketing_Program_Status = 'Active' and Marketing_Program_ID='"+ marktID + "'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            marktName1 = reader.GetString(1);
            marktStatus = reader.GetString(2);

            venueGroup1 = reader.GetString(3);
         

        }
     

        if (marktName1.Equals(marktName))
        { }
        else
        {
            string pageName = "Marketing Program";
            string details = " Makerting Program changed from: " + marktName1 + "To:" + marktName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (marktStatus.Equals(status))
        { }
        else
        {
            string pageName = "Marketing Program";
            string details = "Status changed from: " + marktStatus + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (venueGroup1.Equals(venueGroup))
        { }
        else
        {
            string pageName = "Marketing Program";
            string details = "Venue Group from: " + venueGroup1 + "To: " + venueGroup;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        if (status=="Active")
        {
            string query = "update Marketing_Program set Marketing_Program_Name='" + marktName.ToUpper() + "',Marketing_Program_Status='" + status + "',Venue_Group_ID='" + venueGroup + "' where Marketing_Program_ID='" + marktID + "'";

            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Marketing_Program set Marketing_Program_Name='"+marktName.ToUpper()+"',Marketing_Program_Status='"+status+"',Marketing_Program_Expiry_Date='"+time.ToString(format)+"',Venue_Group_ID='"+venueGroup+"' where Marketing_Program_ID='"+marktID+"'; ";
            
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
            JSON += "[\"" + venueGroupID + "\" , \"" + venueGroupName + "\"],";

        }
            
         JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
      
        sqlcon1.Close();
        return JSON;



    }


    [WebMethod]
    public static void deleteMarkt(string marktID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select Marketing_Program_Name from Marketing_Program where Marketing_Program_ID='" + marktID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Marketing_Program_Name = reader.GetString(0);


        }
        reader.Close();
        sqlcon1.Close();


        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Marketing_Program where [Marketing_Program_ID]='" + marktID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();


        string pageName = "Marketing Program";
        string details = "Marketing Program: " + Marketing_Program_Name + " deleted";
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
}