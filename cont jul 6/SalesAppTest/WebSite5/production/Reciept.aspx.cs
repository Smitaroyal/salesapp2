using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_Reciept : System.Web.UI.Page
{
    static string office;
    static string countryID;
    static string pname;


    static string venue1;
    static string receiptStart1;
    static string ReceiptGen_Code1;
    static string Status1;
    static string user;
    public string getdata()
    {
         user = (string)Session["username"];
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
    public static void insertReceiptDetails(string venue,string receiptStart,  string receiptCode)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
       
            string query1 = "insert into Indian_ReceiptGeneration(Venue, StateCode, ReceiptStart, ReceiptGen_Code, SupplyPlace, Status) values('"+venue+"','30','"+ receiptStart.ToUpper() + "','"+ receiptCode + "','GOA','Active')";
            SqlCommand cmd2 = new SqlCommand(query1, sqlcon);
            cmd2.ExecuteNonQuery();


        string pageName = "Receipt Details";
        string details = "Receipt Details created : Venue: " + venue + ", receipt start: " + receiptStart+", receipt code: "+receiptCode;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

        sqlcon.Close();
    }

  [WebMethod]
    public static string ReceiptInitials(string value)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";

        if (value == "" || value == null)
        {
            JSON += "[\"" + ""+"\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            string query1 = "select * from Indian_ReceiptGeneration where Status='Active'  and Venue like '" + value + "%'";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                int ID = reader1.GetInt32(0);
                var Venue = reader1.GetString(1);
                var stateCode = reader1.GetString(2);
                var receiptStart = reader1.GetString(3);
                var receiptCode = reader1.GetString(4);
                var supplyCode = reader1.GetString(5);
                var status = reader1.GetString(6);
                JSON += "[\"" + ID + "\" , \"" + Venue + "\", \"" + stateCode + "\", \"" + receiptStart + "\", \"" + receiptCode + "\", \"" + supplyCode + "\", \"" + status + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        sqlcon1.Close();
            return JSON ;



    }

  
   
    [WebMethod]
    public static void updateReceiptInitials(string receiptID, string venue, string receiptStart, string receiptCode,string status)

   {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select venue,ReceiptStart,ReceiptGen_Code,Status from Indian_ReceiptGeneration where Status='Active' and Indian_ReceiptGeneration_ID='"+ receiptID + "'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            venue1 = reader.GetString(0);
            receiptStart1 = reader.GetString(1);

            ReceiptGen_Code1 = reader.GetString(2);
            Status1 = reader.GetString(3);

          
        }
      

        if (venue1.Equals(venue)) { }
        else
        {
            string pageName = "Receipt Details";
            string details = "Receipt Venue changed from: " + venue1 + "To: " + venue;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (receiptStart1.Equals(receiptStart)) { }
        else
        {
            string pageName = "Receipt Details";
            string details = "Receipt Start changed from: " + receiptStart1 + "To: " + receiptStart;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        if (ReceiptGen_Code1.Equals(receiptCode)) { }
        else
        {
            string pageName = "Receipt Details";
            string details = "Receipt Code changed from: " + ReceiptGen_Code1 + "To: " + receiptCode;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (Status1.Equals(status)) { }
        else
        {
            string pageName = "Receipt Details";
            string details = "Receipt Status changed from: " + Status1 + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        reader.Close();
        sqlcon1.Close();

        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
      
           
            string query = "update Indian_ReceiptGeneration set Venue='"+ venue + "', ReceiptStart='"+ receiptStart.ToUpper() + "',ReceiptGen_Code='"+receiptCode+"',Status='"+ status + "' where Indian_ReceiptGeneration_ID='"+ receiptID + "' ";
          
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }


    public string getVenue()
    {
        string countryID;
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        //String JSON = "{\n \"names\":[";
        string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='" + office + "' and Venue_Country_Status='Active';";
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
                htmlstr += "<option value='" + venueName + "'>" + venueName + "</option>";
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