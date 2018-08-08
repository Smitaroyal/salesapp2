using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_To_Opc : System.Web.UI.Page
{

    static string pname,office;
    static string user;

    static string TO_Name1;
    static string TO_Status1;
    static string venue1;
    static string TO_Name;
    public string getdata()
    {
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
         user = (string)Session["username"];
        office = (string)Session["office"];
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
    public static void insertToOpc(string toOpcName, string venue,string venueGroup)
    {

        int id = 0;

        string value = "TO";
        string opcID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select To_Opc from Admin_ID_gen";
        SqlCommand cmd1 = new SqlCommand(sql, sqlcon);
        string val = (string)cmd1.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        opcID = value + id;
        string query = "insert into OPC_TOs(TO_ID, TO_Name, TO_Status, Office, Created_Date, Venue, VenueGroup) values('"+opcID+"', '"+toOpcName.ToUpper()+"', 'Active', 'HML', '"+time.ToString(format)+"', '"+venue+"', 'Coldline')";
        SqlCommand cmd5 = new SqlCommand(query, sqlcon);
        cmd5.ExecuteNonQuery();
       

        string query1 = "update Admin_ID_gen set To_Opc='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();


        string pageName = "TO OPC";
        string details = "TO OPC Created : Name:" + toOpcName + ", Venue:" + venue;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());


    }

    [WebMethod]
    public static string getAllOpc()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select TO_ID,TO_Name,TO_Status,venue,VenueGroup from OPC_TOs where TO_Status='Active' ; ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string TO_ID = reader.GetString(0);
            string TO_Name = reader.GetString(1);
            string TO_Status = reader.GetString(2);
          ;
            string venue = reader.GetString(3);
            string VenueGroup = reader.GetString(4);
            JSON += "[\"" + TO_ID + "\" , \"" + TO_Name + "\",\"" + TO_Status + "\",\"" + venue + "\",\"" + VenueGroup + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static void deleteTo_Opc(string to_opc_ID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select TO_Name from OPC_TOs where TO_ID='" + to_opc_ID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            TO_Name = reader.GetString(0);


        }
        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from OPC_TOs where [TO_ID]='" + to_opc_ID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "TO OPC";
        string details = "TO OPC : " + TO_Name + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

    [WebMethod]
    public static void updateTo_Opc(string toOpcID, string toOpcName, string venue, string toOpcStatus)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select TO_ID,TO_Name,TO_Status,venue from OPC_TOs where TO_Status='Active' and TO_ID='"+toOpcID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            TO_Name1 = reader.GetString(1);
            TO_Status1 = reader.GetString(2);

            venue1 = reader.GetString(3);
           
        }

        if (TO_Name1.Equals(toOpcName))
        { }
        else
        {
            string pageName = "TO OPC";
            string details = "TO OPC changed from: " + TO_Name1 + " To: " + toOpcName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (TO_Status1.Equals(toOpcStatus))
        { }
        else
        {
            string pageName = "TO OPC";
            string details = "Status changed from: " + TO_Status1 + " To: " + toOpcStatus;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (venue1.Equals(venue))
        { }
        else
        {
            string pageName = "TO OPC";
            string details = "Venue changed from: " + venue1 + " To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();


        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (toOpcStatus == "Active")
        {

            string query = "update OPC_TOs set TO_Name='"+ toOpcName.ToUpper() + "',TO_Status='"+ toOpcStatus + "',Venue='"+venue+"' where TO_ID='"+ toOpcID + "'";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update OPC_TOs set TO_Name='" + toOpcName.ToUpper() + "',TO_Status='" + toOpcStatus + "',Venue='" + venue + "',Expiry_Date='"+time.ToString(format)+"' where TO_ID='"+toOpcID+"';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
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
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='VC4') and Venue.Venue_Status='Active'; ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string venueName = reader.GetString(0);
            string venueID = reader.GetString(1);


            JSON += "[\"" + venueName + "\",\"" + venueName + "\"],";


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
        string JSON = "{\n \"names\":[";

        if (office == "HML")
        {


            string val = "../../Contractsite/IndiaEdit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        else if (office == "IVO")
        {


            string val = "../../Contractsite/Edit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }



        return JSON;



    }
}