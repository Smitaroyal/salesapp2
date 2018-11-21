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
   
    public string getdata()
    {
        string  office1 = (string)Session["office"];
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
       Session["Venue2_Name1"]="";
       Session["Venue2_Status1"]="";
       Session["Cont_Gen_SCode1"]="";
       Session["Cont_Gen_LCode1"]="";
       Session["Venue_ID1"]="";
       Session["ContF_Gen_SCode1"]="";
       Session["ContF_Gen_LCode1"]="";
       Session["ContF_Inc_Val1"]="";
       Session["Cont_Suffix_Code1"]="";
        Session["ContP_Inc_val1"] = ""; 


        //  office1 = (string)Session["office"];

        string   user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }
       // Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    [WebMethod]
    public static void insertVenue2(string venue2Name, string venueCountry, string venue,string cgsCode,string cglCode,string fgsCode, string fglCode, string fiVal,string suffCode,string contPVal)
    {
        string user = HttpContext.Current.Session["username"].ToString();
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

        string query = "insert into venue2 (Venue2_ID,Venue2_Name,Venue2_Status,Venue2_Created_Date,Venue_ID,Cont_Gen_SCode,Cont_Gen_LCode,ContF_Gen_SCode,ContF_Gen_LCode,ContF_Inc_Val,Cont_Suffix_Code,ContP_Inc_val) values('" + venue2ID + "','"+ venue2Name.ToUpper() + "','Active','"+time.ToString(format)+"','"+venue+"','"+cgsCode+"','"+cglCode+"','"+fgsCode+"','"+fglCode+"','"+fiVal+"','"+ suffCode + "','"+ contPVal + "');";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();
        string query1 = "update Admin_ID_gen set Venue2_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();


        string pageName = "Venue2";
        string details = "Venue2 Created : Venue2_Name: " + venue2Name + ", Venue_ID: " + venue + ", Cont_Gen_SCode: " + cgsCode + ", Cont_Gen_LCode: " + cglCode + ", ContF_Gen_SCode: " + fgsCode+ ",ContF_Gen_LCode :"+ fglCode+ ",ContF_Inc_Val : "+ fiVal+ ",Cont_Suffix_Code :"+ suffCode+ ",ContP_Inc_val " + contPVal;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());


    }



    public string getAllVenueCountry()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Venue_Country_ID,Venue_Country_Name from VenueCountry where Venue_Country_Status='Active'";
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
        string query = "select v2.Venue2_ID,v2.Venue2_Name,v2.Venue2_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,v.Venue_ID,v.Venue_Name,v2.Cont_Gen_SCode,v2.Cont_Gen_LCode,v2.ContF_Gen_SCode,v2.ContF_Gen_LCode,v2.ContF_Inc_Val,v2.Cont_Suffix_Code,v2.ContP_Inc_val from venue v join venue2 v2 on v.Venue_ID=v2.Venue_ID join VenueCountry vc on v.Venue_Country_ID = vc.Venue_Country_ID ;";
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
            string suffixCode = reader.GetString(12);
            string contPointsVal = reader.GetString(13);

            JSON += "[\"" + venue2ID + "\" , \"" + venue2Name + "\",\"" + status + "\",\"" + venueCountryID + "\",\"" + venueCountryName + "\",\"" + venueID + "\",\"" + venueName + "\",\"" + cgsCode + "\",\"" + cglCode + "\",\"" + fgsCode + "\",\"" + fglCode + "\",\"" + fiVal + "\",\"" + suffixCode + "\",\"" + contPointsVal + "\"],";


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
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='"+ venueCountryID + "') and venue.Venue_Status='Active'; ";
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
    public static void deleteVenue2(string venue2ID,string venue2Name)

    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from venue2 where Venue2_ID='"+ venue2ID + "'";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Venue2";
        string details = "Venue2: " + venue2Name + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }


    [WebMethod]
    public static void updateVenue2(string venue2ID, string venue2Name, string status,string venueCountry, string venue, string cgsCode, string cglCode, string fgsCode, string fglCode, string fiVal,string suffixCode,string contPVal)
    {
        HttpContext.Current.Session["Venue2_Name1"] = "";
        HttpContext.Current.Session["Venue2_Status1"] = "";
        HttpContext.Current.Session["Cont_Gen_SCode1"] = "";
        HttpContext.Current.Session["Cont_Gen_LCode1"] = "";
        HttpContext.Current.Session["Venue_ID1"] = "";
        HttpContext.Current.Session["ContF_Gen_SCode1"] = "";
        HttpContext.Current.Session["ContF_Gen_LCode1"] = "";
        HttpContext.Current.Session["ContF_Inc_Val1"] = "";
        HttpContext.Current.Session["Cont_Suffix_Code1"] = "";
        HttpContext.Current.Session["ContP_Inc_val1"] = "";
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select v2.Venue2_ID,v2.Venue2_Name,v2.Venue2_Status,vc.Venue_Country_ID,vc.Venue_Country_Name,v.Venue_ID,v.Venue_Name,v2.Cont_Gen_SCode,v2.Cont_Gen_LCode,v2.ContF_Gen_SCode,v2.ContF_Gen_LCode,v2.ContF_Inc_Val,v2.Cont_Suffix_Code,v2.ContP_Inc_val from venue v join venue2 v2 on v.Venue_ID=v2.Venue_ID join VenueCountry vc on v.Venue_Country_ID = vc.Venue_Country_ID  where v2.Venue2_ID='" + venue2ID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["Venue2_Name1"] = reader.GetString(1);
            HttpContext.Current.Session["Venue2_Status1"]  = reader.GetString(2);
            HttpContext.Current.Session["Venue_ID1"]    = reader.GetString(5);
            HttpContext.Current.Session["Cont_Gen_SCode1"]  = reader.GetString(7);
            HttpContext.Current.Session["Cont_Gen_LCode1"] = reader.GetString(8);
            HttpContext.Current.Session["ContF_Gen_SCode1"]  = reader.GetString(9);
            HttpContext.Current.Session["ContF_Gen_LCode1"]  = reader.GetString(10);
            HttpContext.Current.Session["ContF_Inc_Val1"]  = reader.GetInt32(11);
            HttpContext.Current.Session["Cont_Suffix_Code1"]  = reader.GetString(12);
            HttpContext.Current.Session["ContP_Inc_val1"] = reader.GetString(12);
        }

        if (HttpContext.Current.Session["Venue2_Name1"].ToString().Equals(venue2Name))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "Venue 2 Name changed from: " + HttpContext.Current.Session["Venue2_Name1"].ToString() + "To: " + venue2Name;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Venue2_Status1"].ToString().Equals(status))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "Status changed from: " + HttpContext.Current.Session["Venue2_Status1"].ToString()  + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["Venue_ID1"].ToString().Equals(venue))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "Venue changed from: " + HttpContext.Current.Session["Venue_ID1"].ToString() + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Cont_Gen_SCode1"].ToString().Equals(cgsCode))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "Cont_Gen_SCode changed from: " + HttpContext.Current.Session["Cont_Gen_SCode1"].ToString() + "To: " + cgsCode;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["Cont_Gen_LCode1"].ToString().Equals(cglCode))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "Cont_Gen_LCode changed from: " + HttpContext.Current.Session["Cont_Gen_LCode1"].ToString() + "To: " + cglCode;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["ContF_Gen_SCode1"].ToString().Equals(fgsCode))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "ContF_Gen_SCode changed from: " + HttpContext.Current.Session["ContF_Gen_SCode1"].ToString() + "To: " + fgsCode;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["ContF_Gen_LCode1"].ToString().Equals(fglCode))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "ContF_Gen_LCode changed from: " + HttpContext.Current.Session["ContF_Gen_LCode1"].ToString() + "To: " + fglCode;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["ContF_Inc_Val1"].ToString().Equals(fiVal))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "ContF_Inc_Val changed from: " + HttpContext.Current.Session["ContF_Inc_Val1"].ToString() + "To: " + fiVal;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["Cont_Suffix_Code1"].ToString().Equals(suffixCode))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "Cont_Suffix_Code changed from: " + HttpContext.Current.Session["Cont_Suffix_Code1"].ToString() + "To: " + suffixCode;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["ContP_Inc_val1"].ToString().Equals(contPVal))
        { }
        else
        {
            string pageName = "Venue 2";
            string details = "ContP_Inc_val1 changed from: " + HttpContext.Current.Session["ContP_Inc_val1"].ToString() + "To: " + contPVal;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update venue2 set [Venue2_Name]='" + venue2Name.ToUpper() +"',[Venue2_Status]='" +status +"',[Venue_ID]='"+ venue + "',[Cont_Gen_SCode]='" +cgsCode +"',[Cont_Gen_LCode]='"+cglCode+"',[ContF_Gen_SCode]='"+fgsCode+"',[ContF_Gen_LCode]='"+fglCode+"',[ContF_Inc_Val]='"+fiVal+"',Cont_Suffix_Code='"+ suffixCode + "',ContP_Inc_val='"+ contPVal + "' where [Venue2_ID]='" + venue2ID+ "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update venue2 set [Venue2_Name]='" + venue2Name.ToUpper() + "',[Venue2_Status]='" + status + "',[Venue2_Expiry_Date]='"+time.ToString(format)+"',[Venue_ID]='" + venue + "',[Cont_Gen_SCode]='" + cgsCode + "',[Cont_Gen_LCode]='" + cglCode + "',[ContF_Gen_SCode]='" + fgsCode + "',[ContF_Gen_LCode]='" + fglCode + "',[ContF_Inc_Val]='" + fiVal + "',Cont_Suffix_Code='"+ suffixCode + "',ContP_Inc_val='" + contPVal + "'  where [Venue2_ID]='" + venue2ID + "';";
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
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venuecountryID + "') and venue.Venue_Status='Active'; ";
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

            string val = "EditProfile1.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        return JSON;



    }

}