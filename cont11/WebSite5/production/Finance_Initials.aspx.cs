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
    static string office;
    static string countryID;
    static string pname;
    static string financeMethod1;
    static string financeStatus1;
    static string venuename1;
    static string FinanceCode1;
    static string FinanceIncrval1;
    static string user;
    public string getdata()
    {
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
                 office = Queries.GetOffice(user);
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
    public static void insertFinanceInitials(string venue,string fianceMethod,  string financeCode, string inc,string type)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();

        if (type == "TimeShare")
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string query1 = " insert into FinanceMethod_Venue (FinanceMethod_Name,FinanceMethod_Status,Created_Date,Office,Venue,FinanceCode,FinanceIncrval,ContractType,ContractTypeCode) values('" + fianceMethod + "','Active','" + time.ToString(format) + "','" + office + "','" + venue + "','" + financeCode.ToUpper() + "','" + inc + "','Fractional','Z8')";
            SqlCommand cmd2 = new SqlCommand(query1, sqlcon);
            cmd2.ExecuteNonQuery();

            string pageName = "Finance Initials";
            string details = "Finance Initials created : Finance Method:" + fianceMethod + ", Finance Code:" + financeCode+",venue:"+venue+",Incremantal value:"+inc+",Type:"+type;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string query1 = "  insert into FinanceMethod_Venue (FinanceMethod_Name,FinanceMethod_Status,Created_Date,Office,Venue,FinanceCode,FinanceIncrval,ContractType,ContractTypeCode) values('" + fianceMethod + "','Active','" + time.ToString(format) + "','" + office + "','" + venue + "','" + financeCode.ToUpper() + "','" + inc + "','Non Fractional','Z6')";
            SqlCommand cmd2 = new SqlCommand(query1, sqlcon);
            cmd2.ExecuteNonQuery();

            string pageName = "Finance Initials";
            string details = "Finance Initials created : Finance Method: " + fianceMethod + ", Finance Code: " + financeCode + ",venue: " + venue + ",Incremantal value: " + inc + ",Type: " + type;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

        }



        sqlcon.Close();
    }

  
    public  string getVenue()
    {
        string countryID;
        string htmlstr="";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        //String JSON = "{\n \"names\":[";
        string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='"+office+ "' and Venue_Country_Status='Active';";
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
     
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string JSON = "{\n \"names\":[";
            string query = "select Finance_Name from FinanceMethod where Office='"+office+ "' and Finance_Status='Active'";
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
         
            string query = "select FMV_Id,FinanceMethod_Name,FinanceMethod_Status,Venue,FinanceCode,FinanceIncrval from FinanceMethod_Venue where Office='"+office+"' and Venue like '" + value + "%' and FinanceMethod_Status='Active'";
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
      
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select FMV_Id,FinanceMethod_Name,FinanceMethod_Status,Venue,FinanceCode,FinanceIncrval from FinanceMethod_Venue where Office='"+office+"' and FMV_Id='"+financeID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
             financeMethod1 = reader.GetString(1);
             financeStatus1 = reader.GetString(2);

             venuename1 = reader.GetString(3);
             FinanceCode1 = reader.GetString(4);

             FinanceIncrval1 = reader.GetString(5);
            
        }

        if (financeMethod1.Equals(fianceMethod))
        { }else
        {
            string pageName = "Finance Initials";
            string details = "Finance Method changed from: " + financeMethod1 + "To: " + fianceMethod;
            int insertlog1 = Queries.admin_Log(pageName, details,user ,DateTime.Now.ToString());
        }
        if (financeStatus1.Equals(status))
        { }else
        {
            string pageName = "Finance Initials";
            string details = "Status changed from: " + financeStatus1 + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (venuename1.Equals(venue)) { }
        else
        {
            string pageName = "Finance Initials";
            string details = "Venue changed from: " + venuename1 + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (FinanceCode1.Equals(financeCode)){}
        else
        {
            string pageName = "Finance Initials";
            string details = "Start Code changed from: " + FinanceCode1 + "To: " + financeCode;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (FinanceIncrval1.Equals(inc)) { }
        else
        {
            string pageName = "Finance Initials";
            string details = "Incremental value changed from: " + FinanceIncrval1 + "To: " + inc;
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
}