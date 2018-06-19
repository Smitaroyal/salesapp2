using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Budget : System.Web.UI.Page
{

    static string pname;
    static string user;
    static string Country_Name1;
    static string Country_Code1;
    static string val;
    public string getdata()
    {
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


   
    public static string getAllCountries()
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

            string countryID = reader.GetString(0);
            string countryName = reader.GetString(1);

            htmlstr += "<option value='"+ countryID + "'>"+countryName+"</option>";

        }
      
        sqlcon.Close();
        return htmlstr;
    }

    public static string getGroup()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        string query = "select distinct marketing_main_group from Marketing_Program2 mp where mp.MProgram2_Status='Active' and marketing_main_group !=''";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string marketing_main_group = reader.GetString(0);
       

            htmlstr += "<option value='" + marketing_main_group + "'>" + marketing_main_group + "</option>";

        }

        sqlcon.Close();
        return htmlstr;
    }



    [WebMethod]
    public static string getVenueOnCountry(string venueCountryID)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Venue_ID,Venue_Name from venue where Venue_Country_ID='"+ venueCountryID + "' and Venue_Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            
            string venueID = reader.GetString(0);
            string venueName = reader.GetString(1);
         

            JSON += "[\"" + venueID + "\" , \"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string getVenueGroupOnVenue(string venue)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Venue2_ID,Venue2_Name from venue2 where Venue_ID='"+venue+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string Venue2_ID = reader.GetString(0);
            string Venue2_Name = reader.GetString(1);


            JSON += "[\"" + Venue2_ID + "\" , \"" + Venue2_Name + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;
    }
    
    [WebMethod]
    public static string getdetails()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "Select * from Months";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string month = reader.GetString(1);



            JSON += "[\"" + month + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string getAdminFee(string year,string month)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select adminfee from [adminFeeBudget] ad where Convert(char(3),datename(month,ad.Month))='"+month+"' and year='"+year+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {


                int adminfee = reader.GetInt32(0);



                JSON += "[\"" + adminfee + "\"],";


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
    public static void insertBudget(string year, string country,string venue,string venueGroup,string QT,string CLOSE,string SALES,string AVG,string GROSS,string PPN ,string ADMIN,string NET,string group,string source,string MONTH,string DAYS)
    {
     
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();

        string[] qt = QT.Split(',');
        string[] close = CLOSE.Split(',');
        string[] sales = SALES.Split(',');
        string[] avg = AVG.Split(',');
        string[] gross = GROSS.Split(',');
        string[] ppn = PPN.Split(',');
        string[] admin = ADMIN.Split(',');
        string[] net = NET.Split(',');

        string[] month = MONTH.Split(',');
        string[] days = DAYS.Split(',');
        for (int i = 0; i <= qt.Length-1; i++)
        {

            if (qt[i]=="" || close[i]=="" || sales[i]=="" || avg[i]=="" || gross[i]=="" || ppn[i]=="" || admin[i]=="" || net[i]=="" || days[i]=="")
            {

            }else
            {
                if (month[i]=="Jan" || month[i] == "JAN")
                {
                    val = "01";
                }
                else if (month[i] == "Feb" || month[i] == "FEB")
                {

                    val = "02";
                }
                else if (month[i] == "Mar" || month[i] == "MAR")
                {

                    val = "03";
                }
                else if (month[i] == "Apr" || month[i] == "APR")
                {

                    val = "04";
                }
                else if (month[i] == "May" || month[i] == "MAY")
                {

                    val = "05";
                }
                else if (month[i] == "Jun" || month[i] == "JUN")
                {

                    val = "06";
                }
                else if (month[i] == "Jul" || month[i] == "JUL")
                {

                    val = "07";
                }
                else if (month[i] == "Aug" || month[i] == "AUG")
                {

                    val = "08";
                }
                else if (month[i] == "Sep" || month[i] == "SEP")
                {

                    val = "09";
                }
                else if (month[i] == "Oct" || month[i] == "OCT")
                {

                    val = "10";
                }
                else if (month[i] == "Nov" || month[i] == "NOV")
                {

                    val = "11";

                }
                else if (month[i] == "Dec" || month[i] == "DEC")
                {

                    val = "12";

                }
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";

                string query = "insert into Monthly_BudgetIndo values('" + year + "','" + country + "','" + venue + "','" + venueGroup + "','"+source+"','"+year+"-"+val+"-01','" + qt[i] + "','" + close[i] + "','" + sales[i] + "','$','" + avg[i] + "','" + gross[i] + "','" + ppn[i] + "','" + admin[i] + "','" + net[i] + "','" + time.ToString(format) + "','','Active','"+days[i]+"')";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();
            }
           


        }
        
        //string pageName = "Country";
        //string details = "Country Created : Country: " + countryname + ", countrycode: " + countrycode;
        //int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());


        sqlcon.Close();


    }



    [WebMethod]
    public static string getSourceOnGroup(string group)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct marketing_group from Marketing_Program2 mp where mp.marketing_main_group='"+ group + "' and mp.MProgram2_Status='Active' and marketing_group !=''";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string marketing_group = reader.GetString(0);
       

            JSON += "[\"" + marketing_group + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

}