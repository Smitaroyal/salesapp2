using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Country : System.Web.UI.Page
{
    
    public string getdata()
    {
        string office1 = (string)Session["office"];
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
       // Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }

    [WebMethod]
    public static void insertFinanceInitials(string venue,string fianceMethod,  string financeCode, string inc)
    {
        string office1 = HttpContext.Current.Session["office"].ToString();
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();

      
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string query1 = " insert into FinanceMethod_Venue (FinanceMethod_Name,FinanceMethod_Status,Created_Date,Office,Venue,FinanceCode,FinanceIncrval,ContractType,ContractTypeCode) values('" + fianceMethod + "','Active','" + time.ToString(format) + "','" + office1 + "','" + venue + "','" + financeCode.ToUpper() + "','" + inc + "','','')";
            SqlCommand cmd2 = new SqlCommand(query1, sqlcon);
            cmd2.ExecuteNonQuery();

            string pageName = "Finance Initials";
            string details = "Finance Initials created : Finance Method:" + fianceMethod + ", Finance Code:" + financeCode.ToUpper()+",venue:"+venue+",Incremantal value:"+inc;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
       
         
        sqlcon.Close();
    }

  
    public  string getVenue()
    {
        string office1 = HttpContext.Current.Session["office"].ToString();
        string countryID;
        string htmlstr="";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        //String JSON = "{\n \"names\":[";
        string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='"+ office1 + "' and Venue_Country_Status='Active';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

             countryID = reader.GetString(0);
            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select Venue_Name,Venue_ID from venue where Venue_Country_ID='"+ countryID + "' and Venue_Status='Active';";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                var venueName = reader1.GetString(0);
                var venueID = reader1.GetString(1);
                //JSON += "[\"" + venueName + "\" , \"" + venueID + "\"],";
                htmlstr += "<option value='"+ venueName + "'>"+venueName+"</option>";
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
    public static string getFinanceMethod()

    {
        string office1 = HttpContext.Current.Session["office"].ToString();

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string JSON = "{\n \"names\":[";
            string query = "select Finance_Name from FinanceMethod where Office='"+ office1 + "' and Finance_Status='Active'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                var name = reader.GetString(0);

                JSON += "[\"" + name + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            reader.Close();
            sqlcon.Close();
            return JSON;
       
      

    }


    [WebMethod]
    public static string getFinanceInitials(string value)

    {
        string office1 = HttpContext.Current.Session["office"].ToString();
        string JSON = "{\n \"names\":[";
        if (value == "" || value==null)
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
         
            string query = "select FMV_Id,FinanceMethod_Name,FinanceMethod_Status,Venue,FinanceCode,FinanceIncrval from FinanceMethod_Venue where Office='" + office1 + "' and Venue like '" + value + "%' and FinanceMethod_Status='Active'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int FMV_Id = reader.GetInt32(0);
                var FinanceMethod_Name = reader.GetString(1);
                var FinanceMethod_Status = reader.GetString(2);
                var Venue = reader.GetString(3);
                var FinanceCode = reader.GetString(4);
                var FinanceIncrval = reader.GetString(5);
                

                JSON += "[\"" + FMV_Id + "\",\"" + FinanceMethod_Name + "\",\"" + FinanceMethod_Status + "\",\"" + Venue + "\",\"" + FinanceCode + "\",\"" + FinanceIncrval + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            reader.Close();
            sqlcon.Close();
          

        }
        return JSON;
        
    }
    

    [WebMethod]
    public static void updateFinanceInitials(string financeID, string venue, string fianceMethod,string financeCode, string inc,string status)
   {


        HttpContext.Current.Session["financeMethod1"] = "";
        HttpContext.Current.Session["financeStatus1"] = "";
        HttpContext.Current.Session["venuename1"] = "";
        HttpContext.Current.Session["FinanceCode1"] = "";
        HttpContext.Current.Session["FinanceIncrval1"] = "";

        string user = HttpContext.Current.Session["username"].ToString();
        string office1 = HttpContext.Current.Session["office"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select FMV_Id,FinanceMethod_Name,FinanceMethod_Status,Venue,FinanceCode,FinanceIncrval from FinanceMethod_Venue where Office='"+ office1 + "' and FMV_Id='"+financeID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["financeMethod1"] = reader.GetString(1);
            HttpContext.Current.Session["financeStatus1"] = reader.GetString(2);

            HttpContext.Current.Session["venuename1"] = reader.GetString(3);
            HttpContext.Current.Session["FinanceCode1"] = reader.GetString(4);

            HttpContext.Current.Session["FinanceIncrval1"] = reader.GetString(5);
            
        }

        if (HttpContext.Current.Session["financeMethod1"].ToString().Equals(fianceMethod))
        { }else
        {
            string pageName = "Finance Initials";
            string details = "Finance Method changed from: " + HttpContext.Current.Session["financeMethod1"].ToString() + "To: " + fianceMethod;
            int insertlog1 = Queries.admin_Log(pageName, details,user ,DateTime.Now.ToString());
        }
        if (HttpContext.Current.Session["financeStatus1"].ToString().Equals(status))
        { }else
        {
            string pageName = "Finance Initials";
            string details = "Status changed from: " + HttpContext.Current.Session["financeStatus1"].ToString() + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (HttpContext.Current.Session["venuename1"].ToString().Equals(venue)) { }
        else
        {
            string pageName = "Finance Initials";
            string details = "Venue changed from: " + HttpContext.Current.Session["venuename1"].ToString() + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (HttpContext.Current.Session["FinanceCode1"].ToString().Equals(financeCode)){}
        else
        {
            string pageName = "Finance Initials";
            string details = "Start Code changed from: " + HttpContext.Current.Session["FinanceCode1"].ToString() + "To: " + financeCode.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (HttpContext.Current.Session["FinanceIncrval1"].ToString().Equals(inc)) { }
        else
        {
            string pageName = "Finance Initials";
            string details = "Incremental value changed from: " + HttpContext.Current.Session["FinanceIncrval1"].ToString() + "To: " + inc;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        reader.Close();
        sqlcon1.Close();
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        if (status=="Active")
        {
           
            string query = " update FinanceMethod_Venue set FinanceMethod_Name='"+ fianceMethod + "',FinanceMethod_Status='"+ status + "',Venue='"+ venue + "',FinanceCode='"+ financeCode.ToUpper() + "',FinanceIncrval='"+ inc + "' where FMV_Id='"+ financeID + "';";
          
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
           
            string query = "  update FinanceMethod_Venue set FinanceMethod_Name='"+ fianceMethod + "',FinanceMethod_Status='"+ status + "',Venue='"+ venue + "',FinanceCode='"+ financeCode.ToUpper() + "',FinanceIncrval='"+ inc + "',Expiry_Date='"+time.ToString(format)+"' where FMV_Id='"+ financeID + "'";
           
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            
        }
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