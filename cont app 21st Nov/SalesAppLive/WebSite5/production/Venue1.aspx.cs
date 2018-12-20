using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Venue1 : System.Web.UI.Page
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
        //office = (string)Session["office"];
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
    public static void insertVenue(string venuename,string venuecountry ,string gstin,string Address,string phone)
    {
        int id = 0;
        string user = HttpContext.Current.Session["username"].ToString();
        string value = "V";
        string venueID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
     
        string sql = "select Venue_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        venueID = value + id;

        string query = "insert into venue ([Venue_ID],[Venue_Name],[Venue_Status],[Venue_Created_Date],[Venue_Country_ID]) values('" + venueID + "','" + venuename.ToUpper() + "','Active','" + time.ToString(format) + "','" + venuecountry + "');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        string query1 = "update Admin_ID_gen set Venue_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();


        string query2 = "insert into Venue_GSTIN_Nos values('"+ venuename + "','"+ gstin + "','Active','"+ time.ToString(format) + "','','"+Address+"','"+phone+"')";
        SqlCommand cmd2 = new SqlCommand(query2, sqlcon);
        cmd2.ExecuteNonQuery();

        string pageName = "Venue";
        string details = "Venue Created : Venue Name: " + venuename.ToUpper() + ", venueCountry: " + venuecountry + ", gstin: " + gstin+", Address:"+Address+", Phone:"+phone;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

        sqlcon.Close();


    }

    [WebMethod]
    public static string getAllVenue()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct v.Venue_ID,v.Venue_Name,v.Venue_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,gs.GSTIN,gs.Id,gs.Venue_Address,gs.Venue_PhoneNo from venue v join VenueCountry vc on v.Venue_Country_ID = vc.Venue_Country_ID join Venue_GSTIN_Nos gs on v.Venue_Name = gs.venue; ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string venueID = reader.GetString(0);
            string venueName = reader.GetString(1);
            string venueCountryID = reader.GetString(3);
            string status = reader.GetString(2);
            string venueCountryName = reader.GetString(4);
            string gstin = reader.GetString(5);
            int id = reader.GetInt32(6);
            string address = reader.GetString(7);
            string phone = reader.GetString(8);
            
            JSON += "[\"" + venueID + "\" , \"" + venueName + "\",\"" + gstin + "\",\"" + address + "\",\"" + phone + "\",\"" + status + "\",\"" + venueCountryName + "\",\"" + venueCountryID + "\",\"" + id + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    public string getAllVenueCountry()
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Venue_Country_ID ,Venue_Country_Name from VenueCountry where Venue_Country_Status='Active'";
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
    public static void updateVenue(string venueID, string venueName, string status,string venueCountryID ,string gstin,string g_ID,string Address, string phone)
    {
        HttpContext.Current.Session["Venue_Name1"] = "";
        HttpContext.Current.Session["Venue_Status1"] = "";
        HttpContext.Current.Session["Venue_Country_ID1"] = "";
        HttpContext.Current.Session["GSTIN1"] = "";
        HttpContext.Current.Session["Venue_Address"] = "";
        HttpContext.Current.Session["Venue_PhoneNo"] = "";

        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query3 = "select distinct v.Venue_Name,v.Venue_Status,v.Venue_Country_ID,GSTIN,Venue_Address,Venue_PhoneNo from venue v join Venue_GSTIN_Nos gs on v.Venue_Name = gs.venue where v.Venue_ID='" + venueID + "'";
        SqlCommand cmd = new SqlCommand(query3, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["Venue_Name1"] = reader.GetString(0);
            HttpContext.Current.Session["Venue_Status1"] = reader.GetString(1);

            HttpContext.Current.Session["Venue_Country_ID1"] = reader.GetString(2);
            HttpContext.Current.Session["GSTIN1"] = reader.GetString(3);

            HttpContext.Current.Session["Venue_Address"] = reader.GetString(4);
            HttpContext.Current.Session["Venue_PhoneNo"] = reader.GetString(5);
        }

        if (HttpContext.Current.Session["Venue_Name1"].ToString().Equals(venueName))
        { }
        else
        {
            string pageName = "Venue";
            string details = "venue Name changed from: " + HttpContext.Current.Session["Venue_Name1"].ToString() + "To: " + venueName.ToUpper() ;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Venue_Status1"].ToString().Equals(status))
        { }
        else
        {
            string pageName = "Venue";
            string details = "Status changed from: " + HttpContext.Current.Session["Venue_Status1"].ToString() + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["Venue_Country_ID1"].ToString().Equals(venueCountryID))
        { }
        else
        {
            string pageName = "Venue";
            string details = "Venue Country changed from: " + HttpContext.Current.Session["Venue_Country_ID1"].ToString() + "To: " + venueCountryID;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["GSTIN1"].ToString().Equals(gstin))
        { }
        else
        {
            string pageName = "Venue";
            string details = "gstin changed from: " + HttpContext.Current.Session["GSTIN1"].ToString() + "To: " + gstin;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Venue_Address"].ToString().Equals(Address))
        { }
        else
        {
            string pageName = "Venue";
            string details = "Address changed from: " + HttpContext.Current.Session["Venue_Address"].ToString() + "To: " + Address;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Venue_PhoneNo"].ToString().Equals(phone))
        { }
        else
        {
            string pageName = "Venue";
            string details = "Phone No changed from: " + HttpContext.Current.Session["Venue_PhoneNo"].ToString() + "To: " + phone;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();


        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update venue set [Venue_Name]='"+venueName.ToUpper()+"',[Venue_Status]='"+status+"',[Venue_Country_ID]='"+venueCountryID+"' where [Venue_ID]='"+venueID+"';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();

            string query1 = "update Venue_GSTIN_Nos set venue='"+ venueName.ToUpper() + "', GSTIN='" + gstin + "',Status='"+status+ "',Venue_Address='"+ Address + "',Venue_PhoneNo='"+phone+"' where Id='" + g_ID + "'";
            SqlCommand cmd3 = new SqlCommand(query1, sqlcon);
            cmd3.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update venue set [Venue_Name]='" + venueName.ToUpper() + "',[Venue_Status]='" + status + "',[Venue_Expiry_Date]='"+time.ToString(format)+"',[Venue_Country_ID]='" + venueCountryID + "' where [Venue_ID]='" + venueID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();

            string query1 = "update Venue_GSTIN_Nos set venue='"+ venueName.ToUpper() + "', GSTIN='" + gstin + "',Status='" + status + "',ExpiryDate='"+ time.ToString(format) + "',Venue_Address='" + Address + "',Venue_PhoneNo='" + phone + "' where Id='" + g_ID + "'";
            SqlCommand cmd3 = new SqlCommand(query1, sqlcon);
            cmd3.ExecuteNonQuery();
        }

        sqlcon.Close();

    }



    [WebMethod]
    public static void deleteVenue(string venueID,string venueName)

    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from venue where [Venue_ID]='" + venueID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();


        string query1 = "delete from Venue_GSTIN_Nos where venue='"+ venueName + "'";
       
        SqlCommand cmd3 = new SqlCommand(query1, sqlcon);
        cmd3.ExecuteNonQuery();


        string pageName = "Venue";
        string details = "Venue: " + venueName + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
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