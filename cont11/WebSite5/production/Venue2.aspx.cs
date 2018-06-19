using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

public partial class WebSite5_production_Venue2 : System.Web.UI.Page
{
    static string pname;
    static string office1;
   
    public string getdata()
    {
         office1 = (string)Session["office"];
        string user = (string)Session["username"];

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
    public static void insertVenue2(string venue2Name, string venueCountry, string venue,string cgsCode,string cglCode,string fgsCode, string fglCode, string fiVal)
    {
                int id = 0;
               
                string value = "V2";
                string venue2ID;
                string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select Venue2_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        venue2ID = value + id;

        string query = "insert into venue2 (Venue2_ID,Venue2_Name,Venue2_Status,Venue2_Created_Date,Venue_ID,Cont_Gen_SCode,Cont_Gen_LCode,ContF_Gen_SCode,ContF_Gen_LCode,ContF_Inc_Val) values('"+ venue2ID + "','"+ venue2Name.ToUpper() + "','Active','"+time.ToString(format)+"','"+venue+"','"+cgsCode+"','"+cglCode+"','"+fgsCode+"','"+fglCode+"','"+fiVal+"');";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();
        string query1 = "update Admin_ID_gen set Venue2_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();





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
    public static string getAllVenue2()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select v2.Venue2_ID,v2.Venue2_Name,v2.Venue2_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,v.Venue_ID,v.Venue_Name,v2.Cont_Gen_SCode,v2.Cont_Gen_LCode,v2.ContF_Gen_SCode,v2.ContF_Gen_LCode,v2.ContF_Inc_Val from venue v join venue2 v2 on v.Venue_ID=v2.Venue_ID join VenueCountry vc on v.Venue_Country_ID = vc.Venue_Country_ID ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string venue2ID = reader.GetString(0);
            string venue2Name = reader.GetString(1);
            string status = reader.GetString(2);
            string venueCountryID = reader.GetString(3);
            string venueCountryName = reader.GetString(4);
            string venueID = reader.GetString(5);
            string venueName = reader.GetString(6);
            string cgsCode = reader.GetString(7);
            string cglCode = reader.GetString(8);
            string fgsCode = reader.GetString(9);
            string fglCode = reader.GetString(10);
            int fiVal = reader.GetInt32(11);


            JSON += "[\"" + venue2ID + "\" , \"" + venue2Name + "\",\"" + status + "\",\"" + venueCountryID + "\",\"" + venueCountryName + "\",\"" + venueID + "\",\"" + venueName + "\",\"" + cgsCode + "\",\"" + cglCode + "\",\"" + fgsCode + "\",\"" + fglCode + "\",\"" + fiVal + "\"],";


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
            string venueID = reader.GetString(1);



            JSON += "[\"" + venueName + "\",\"" + venueID + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        reader.Close();
        sqlcon.Close();
        return JSON;



    }
    [WebMethod]
    public static void deleteVenue2(string venue2ID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from venue2 where Venue2_ID='"+ venue2ID + "'";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }


    [WebMethod]
    public static void updateVenue2(string venue2ID, string venue2Name, string status,string venueCountry, string venue, string cgsCode, string cglCode, string fgsCode, string fglCode, string fiVal)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update venue2 set [Venue2_Name]='" + venue2Name.ToUpper() +"',[Venue2_Status]='" +status +"',[Venue_ID]='"+ venue + "',[Cont_Gen_SCode]='" +cgsCode +"',[Cont_Gen_LCode]='"+cglCode+"',[ContF_Gen_SCode]='"+fgsCode+"',[ContF_Gen_LCode]='"+fglCode+"',[ContF_Inc_Val]='"+fiVal+"' where [Venue2_ID]='"+venue2ID+ "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update venue2 set [Venue2_Name]='" + venue2Name.ToUpper() + "',[Venue2_Status]='" + status + "',[Venue2_Expiry_Date]='"+time.ToString(format)+"',[Venue_ID]='" + venue + "',[Cont_Gen_SCode]='" + cgsCode + "',[Cont_Gen_LCode]='" + cglCode + "',[ContF_Gen_SCode]='" + fgsCode + "',[ContF_Gen_LCode]='" + fglCode + "',[ContF_Inc_Val]='" + fiVal + "' where [Venue2_ID]='" + venue2ID + "';";
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
            string venueID = reader.GetString(1);


            JSON += "[\"" + venueName + "\",\"" + venueID + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }



}