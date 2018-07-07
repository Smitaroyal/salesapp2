using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Venue_Group : System.Web.UI.Page
{
    static string pname;
    static string office1;
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

       // string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }
    [WebMethod]
    public static void insertVenueGroup(string venueGroupName, string venue,string venueGroupCode)
    {
        int id = 0;
        
        string value = "VG";
        string venueGroupID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select Venue_Group_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        venueGroupID = value + id;


        string query = "insert into Venue_Group ([Venue_Group_ID],[Venue_Group_Name],[Venue_Group_Status],[Venue_Group_Created_Date],[Venue_ID],[Venue_Group_Code]) values('" + venueGroupID + "','" + venueGroupName.ToUpper() + "','Active','" + time.ToString(format) + "','" + venue + "','"+ venueGroupCode.ToUpper() + "');";
       SqlCommand cmd1 = new SqlCommand(query, sqlcon);
      cmd1.ExecuteNonQuery();

        string query1 = "update Admin_ID_gen set Venue_Group_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();

        sqlcon.Close();


    }


    public string getAllVenue()
    {
        string countryid = "";
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        string query1 = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='"+ office1 + "';";
        sqlcon1.Open();
        SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader1 = cmd1.ExecuteReader();
        while (reader1.Read())
        {
            countryid = reader1.GetString(0);


            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select Venue_ID ,Venue_Name from venue where Venue_Country_ID='"+countryid+"'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                string Venue_ID = reader.GetString(0);
                string Venue_Name = reader.GetString(1);
                htmlstr += "<option value='" + Venue_ID + "'>" + Venue_Name + "</option>";
            }
            reader.Close();
            sqlcon.Close();

        }
        reader1.Close();
        sqlcon1.Close();
        return htmlstr;
    }

    [WebMethod]
    public static string getAllVenueGroup()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct vg.Venue_Group_ID,vg.Venue_Group_Name,vg.Venue_group_Code,vg.Venue_Group_Status,v.Venue_ID,v.Venue_Name from Venue_Group vg join venue v on vg.Venue_ID=v.Venue_ID;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string venueGroupID = reader.GetString(0);
            string venueGroupName = reader.GetString(1);
            string venueGroupCode = reader.GetString(2);
            string status = reader.GetString(3);
            string venueID = reader.GetString(4);
            string venueName = reader.GetString(5);


            JSON += "[\"" + venueGroupID + "\" , \"" + venueGroupName + "\",\"" + venueGroupCode + "\",\"" + status + "\",\"" + venueID + "\",\"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;





    }

    [WebMethod]
    public static void deleteVenueGroup(string venueGroupID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Venue_Group where [Venue_Group_ID]='" + venueGroupID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }


    [WebMethod]
    public static void updateVenueGroup(string venueGroupID, string venueGroupName,string venueGroupCode, string status, string venueID)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update Venue_Group set [Venue_Group_Name]='" + venueGroupName.ToUpper() + "',[Venue_Group_Code]='"+ venueGroupCode.ToUpper() + "',[Venue_Group_Status]='" + status + "',[Venue_ID]='" + venueID + "' where [Venue_Group_ID]='" + venueGroupID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Venue_Group set [Venue_Group_Name]='" + venueGroupName.ToUpper() + "',[Venue_Group_Code]='" + venueGroupCode.ToUpper() + "',[Venue_Group_Status]='" + status + "',[Venue_ID]='" + venueID + "',[Venue_Group_Expiry_Date]='"+time.ToString(format)+"' where [Venue_Group_ID]='" + venueGroupID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

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