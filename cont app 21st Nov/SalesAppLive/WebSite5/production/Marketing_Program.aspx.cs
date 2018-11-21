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
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
      //  Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }

    [WebMethod]
    public static void insertMarketingProgram(string marktName, string venueGroup,string code)
    {
        string user = HttpContext.Current.Session["username"].ToString();
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

        string query = "insert into Marketing_Program (Marketing_Program_ID,Marketing_Program_Name,Marketing_Program_Status,Marketing_Program_Created_Date,Venue_Group_ID,Marketing_Program_abbrv) values('" + marktID + "','"+marktName.ToUpper()+"','Active','"+time.ToString(format)+"','"+venueGroup+"','"+code+"')";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

       


        string query1 = "update Admin_ID_gen set Marketing_Program_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Marketing Program";
        string details = " Makerting Program Created : Marketing_Program_Name: " + marktName.ToUpper()+", Venue Group: "+venueGroup+", Code :"+code;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

  [WebMethod]
    public static string getmarketingProgram()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";

     
            string query1 = "select mp.Marketing_Program_ID,mp.Marketing_Program_Name,mp.Marketing_Program_Status,mp.Venue_Group_ID,vg.Venue_Group_Name,vg.Venue_ID,v.Venue_Name,mp.Marketing_Program_abbrv from Marketing_Program mp join Venue_Group vg on mp.Venue_Group_ID = vg.Venue_Group_ID join venue v on vg.Venue_ID = v.Venue_ID where mp.Marketing_Program_Status = 'Active'  and v.Venue_Country_ID in('VC004','VC4');";
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
                var code = reader1.GetString(7);
            JSON += "[\"" + Marketing_Program_ID + "\" , \"" + Marketing_Program_Name + "\", \"" + Marketing_Program_Status + "\", \"" + Venue_Group_ID + "\", \"" + Venue_Group_Name + "\", \"" + Venue_ID + "\", \"" + Venue_Name + "\", \"" + code + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        

        sqlcon1.Close();
            return JSON ;
        
    }

  
   
    [WebMethod]
    public static void updateMarketingProgram(string marktID, string marktName, string venueGroup,string status,string code)

   { HttpContext.Current.Session["marktName1"] = "";
        HttpContext.Current.Session["marktStatus"] = "";
        HttpContext.Current.Session["venueGroup1"] = "";
        HttpContext.Current.Session["code1"] = "";
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select mp.Marketing_Program_ID,mp.Marketing_Program_Name,mp.Marketing_Program_Status,mp.Venue_Group_ID,vg.Venue_Group_Name,vg.Venue_ID,v.Venue_Name,mp.Marketing_Program_abbrv from Marketing_Program mp join Venue_Group vg on mp.Venue_Group_ID = vg.Venue_Group_ID join venue v on vg.Venue_ID = v.Venue_ID where mp.Marketing_Program_Status = 'Active' and Marketing_Program_ID='" + marktID + "'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["marktName1"] = reader.GetString(1);
            HttpContext.Current.Session["marktStatus"] = reader.GetString(2);

            HttpContext.Current.Session["venueGroup1"] = reader.GetString(3);
            HttpContext.Current.Session["code1"] = reader.GetString(7);

        }
     

        if (HttpContext.Current.Session["marktName1"].ToString().Equals(marktName))
        { }
        else
        {
            string pageName = "Marketing Program";
            string details = " Makerting Program changed from: " + HttpContext.Current.Session["marktName1"].ToString() + "To:" + marktName.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["marktStatus"].ToString().Equals(status))
        { }
        else
        {
            string pageName = "Marketing Program";
            string details = "Status changed from: " + HttpContext.Current.Session["marktStatus"].ToString() + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (HttpContext.Current.Session["venueGroup1"].ToString().Equals(venueGroup))
        { }
        else
        {
            string pageName = "Marketing Program";
            string details = "Venue Group from: " + HttpContext.Current.Session["venueGroup1"].ToString() + "To: " + venueGroup;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["code1"].ToString().Equals(code))
        { }
        else
        {
            string pageName = "Marketing Program";
            string details = "code from: " + HttpContext.Current.Session["code1"].ToString() + "To: " + code;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        if (status=="Active")
        {
            string query = "update Marketing_Program set Marketing_Program_Name='" + marktName.ToUpper() + "',Marketing_Program_Status='" + status + "',Venue_Group_ID='" + venueGroup + "',Marketing_Program_abbrv='"+code+"' where Marketing_Program_ID='" + marktID + "'";

            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Marketing_Program set Marketing_Program_Name='"+marktName.ToUpper()+"',Marketing_Program_Status='"+status+"',Marketing_Program_Expiry_Date='"+time.ToString(format)+"',Venue_Group_ID='"+venueGroup+ "',Marketing_Program_abbrv='" + code + "' where Marketing_Program_ID='" + marktID+"'; ";
            
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
      
           
           
        sqlcon.Close();

    }


    public string getVenue()
    {
        string office1 = HttpContext.Current.Session["office"].ToString();
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
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["Marketing_Program_Name"]="";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select Marketing_Program_Name from Marketing_Program where Marketing_Program_ID='" + marktID + "';";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["Marketing_Program_Name"] = reader.GetString(0);


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
        string details = "Marketing Program: " + HttpContext.Current.Session["Marketing_Program_Name"].ToString() + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
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