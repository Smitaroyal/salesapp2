using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Admin_Fee : System.Web.UI.Page
{

    static string pname;
    static string user;
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

            htmlstr += "<option value='" + countryID + "'>" + countryName + "</option>";

        }

        sqlcon.Close();
        return htmlstr;
    }



    [WebMethod]
    public static void insertAdmin_Fee(string year, string country, string MONTH, string FEE)
    {

        string[] fee = FEE.Split(',');
        string[] month = MONTH.Split(',');
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        for (int i = 0; i <= fee.Length - 1; i++)
        {
            if (fee[i]=="")
            {

            }else
            {
                if (month[i] == "Jan" || month[i] == "JAN")
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

                string query = "insert into adminFeeBudget values('" + year + "','" + year + "-" + val + "-01','" + country + "','$','" + fee[i] + "','" + time.ToString(format) + "','','Active');";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();
            }
        }
        sqlcon.Close();
    }

   

  
    [WebMethod]
    public static void updateAdminFee(string ID, string adminFee, string status)

    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        if (status == "Active")
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            string query = "update adminFeeBudget set AdminFee='"+adminFee+"' ,Status='"+status+"' where AdminfeeID='"+ID+"'";

            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            sqlcon.Close();
        }
        else
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "update adminFeeBudget set AdminFee='"+adminFee+"' ,Status='"+status+"',Expiry_Date='"+time.ToString(format)+"' where AdminfeeID='"+ID+"'";

            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            sqlcon.Close();
        }

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
    public static string getAdminFeeOnYear(string year)
    {
        string JSON = "{\n \"names\":[";
        if (year=="" || year==null)
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select AdminfeeID, Year, convert(char(3), datename(Month, ab.Month)),country,AdminFee,Status from adminFeeBudget ab where year like '" + year + "%' and Status = 'Active'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
              
                while (reader.Read())
                {
                    int AdminfeeID = reader.GetInt32(0);
                    int Year = reader.GetInt32(1);
                    string Month = reader.GetString(2);
                    string country = reader.GetString(3);
                    int AdminFee = reader.GetInt32(4);
                    string Status = reader.GetString(5);


                    JSON += "[\"" + AdminfeeID + "\",\"" + Year + "\",\"" + Month + "\",\"" + country + "\",\"" + AdminFee + "\",\"" + Status + "\"],";
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
        }
       
        return JSON;



    }
}