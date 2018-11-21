using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Budget1 : System.Web.UI.Page
{


    public string getdata()
    {
        string user = (string)Session["username"];
        string office1 = (string)Session["office"];

        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct parentnode,ReportOrder from user_group_access ug where username ='" + user + "' order by ReportOrder asc";
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

       string  user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
        //Label1.Text = "HI!! " + user;
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
    public static string getsourceOnVenue(string venue)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct marketing_group from Marketing_Program2 where Venue2_ID in('v26','v21','v22','v23','v24') and MProgram2_Status = 'Active'";
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

    [WebMethod]
    public static string getdetails(string year, string country, string venue, string venueGroup, string source, string sourceGroup1)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        string query = "Select * from Months";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        int i = 0;
        while (reader.Read())
        {
          
            string month = reader.GetString(2);
            string date = year + month;
            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select * from Monthly_BudgetIndo where years='"+year+"' and Profile_Venue_Country='"+country+"' and venue='"+venue+"' and venue_group='"+venueGroup+"' and Source='"+source+"' and Budget_Month='"+date+"' and Source2='"+sourceGroup1+"'";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                i++;
                if (i == 12)
                {
                    JSON += "[\"" + "2" + "\"],";
                }
                else
                {
                    JSON += "[\"" + "1" + "\"],";
                }
               
            }
            else
            {
                SqlConnection sqlcon2 = new SqlConnection(conn);
                string query5 = "select Convert(char(3), datename(month, '"+date+"'))";
                sqlcon2.Open();
                SqlCommand cmd5 = new SqlCommand(query5, sqlcon2);
                string hell = (string)cmd5.ExecuteScalar();
                JSON += "[\"" + date + "\",\"" + hell + "\"],";
                sqlcon2.Close();
            }
            
            sqlcon1.Close();
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    //[WebMethod]
    //public static string getDuplicateBudgetDetails(string year, string country,string venue,string venueGroup,string source,string sourceGroup1)
    //{
    //    string JSON = "{\n \"names\":[";
    //    string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
    //    SqlConnection sqlcon1 = new SqlConnection(conn);
    //    DateTime dtt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    //    string date2 = dtt.ToString("yyyy-MM-dd");
    //    sqlcon1.Open();
    //    string query1 = "select * from InhouseStats where Group_Venue='" + groupvenue + "' and IDate='" + date2 + "';";
    //    SqlCommand cmd = new SqlCommand(query1, sqlcon1);
    //    SqlDataReader reader1 = cmd.ExecuteReader();
    //    if (reader1.HasRows)
    //    {
    //        JSON += "[\"" + "1" + "\"],";
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";
    //    }
    //    else
    //    {
    //        JSON += "[\"" + "2" + "\"],";
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";
    //    }

    //    return JSON;

    //}


    [WebMethod]
    public static string getBudgetDetails(string year,string country,string venue,string venueGroup,string source,string sourceGroup1)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct *,Convert(char(3),datename(month,Budget_Month)) from Monthly_BudgetIndo mb where years='" + year+"' and Profile_Venue_Country='"+country+"' and venue='"+venue+"' and venue_group='"+venueGroup+"' and Source='"+source+ "' and Source2='"+ sourceGroup1 + "' and Status='Active' order by mb.Budget_Month asc";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {


                int id = reader.GetInt32(0);
                string month = reader.GetString(18);
                string days = reader.GetString(16);
                double QT = reader.GetDouble(7);
                int close = reader.GetInt32(8);
                double sales = reader.GetDouble(9);
                int average = reader.GetInt32(11);
                double netvolume = reader.GetDouble(12);

                JSON += "[\"" + id + "\",\"" + month + "\",\"" + days + "\",\"" + QT + "\",\"" + close + "\",\"" + sales + "\",\"" + average + "\",\"" + netvolume + "\"],";


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
    public static void insertBudget(string year, string country,string venue,string venueGroup,string QT,string CLOSE,string SALES,string AVG,string NET,string group,string source,string MONTH,string DAYS,string sourceGroup)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["val"]="";
        if (venue =="Inhouse" || venue == "INHOUSE")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            string[] qt = QT.Split(',');
            string[] close = CLOSE.Split(',');
            string[] sales = SALES.Split(',');
            string[] avg = AVG.Split(',');

            string[] net = NET.Split(',');

            string[] month = MONTH.Split(',');
            string[] days = DAYS.Split(',');
            for (int i = 0; i <= qt.Length - 1; i++)
            {

                if (qt[i] == "" || close[i] == "" || sales[i] == "" || avg[i] == "" || net[i] == "")
                {

                }
                else
                {
                    if (month[i] == "undefined")
                    {

                    }
                    else
                    {

                        DateTime time = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss:sss";

                        string query = "insert into Monthly_BudgetIndo values('" + year + "','" + country + "','" + venue + "','" + venueGroup + "','" + source + "','" + month[i] + "','" + qt[i] + "','" + close[i] + "','" + sales[i] + "','$','" + avg[i] + "','" + net[i] + "','" + time.ToString(format) + "','','Active','" + days[i] + "','" + sourceGroup + "')";
                        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                        cmd1.ExecuteNonQuery();

                        string pageName = "Budget";
                        string details = "Budeget inserted : Year: " + year + ", Country: " + country + ", Venue: " + venue + ", Venue Group: " + venueGroup + ", Source: " + source + ", date: " + month[i] + ", QT: " + qt[i] + ", close:" + close[i] + ", sales:" + sales[i] + ", average: " + avg[i] + ", net:" + net[i] + ", Days:" + days[i] + ", source group:" + sourceGroup;
                        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                    }
                }



            }

            //string pageName = "Country";
            //string details = "Country Created : Country: " + countryname + ", countrycode: " + countrycode;
            //int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());


            sqlcon.Close();

        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            string[] qt = QT.Split(',');
            string[] close = CLOSE.Split(',');
            string[] sales = SALES.Split(',');
            string[] avg = AVG.Split(',');

            string[] net = NET.Split(',');

            string[] month = MONTH.Split(',');
            string[] days = DAYS.Split(',');
            for (int i = 0; i <= qt.Length - 1; i++)
            {

                if (qt[i] == "" || close[i] == "" || sales[i] == "" || avg[i] == "" || net[i] == "")
                {

                }
                else
                {
                    if (month[i]=="undefined")
                    {

                    }else
                    {
                        DateTime time = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss:sss";

                        string query = "insert into Monthly_BudgetIndo values('" + year + "','" + country + "','" + venue + "','" + venueGroup + "','" + source + "','" + month[i] + "','" + qt[i] + "','" + close[i] + "','" + sales[i] + "','$','" + avg[i] + "','" + net[i] + "','" + time.ToString(format) + "','','Active','" + days[i] + "','')";
                        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                        cmd1.ExecuteNonQuery();

                        string pageName = "Budget";
                        string details = "Budeget inserted : Year: " + year + ", Country: " + country + ", Venue: " + venue + ", Venue Group: " + venueGroup + ", Source: " + source + ", date: " + month[i] + ", QT: " + qt[i] + ", close:" + close[i] + ", sales:" + sales[i] + ", average: " + avg[i] + ", net:" + net[i] + ", Days:" + days[i] + ", source group:" + sourceGroup;
                        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                    }
                    
                   
                }
            }
            //string pageName = "Country";
            //string details = "Country Created : Country: " + countryname + ", countrycode: " + countrycode;
            //int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            sqlcon.Close();

        }


    }



    [WebMethod]
    public static void updateBudget(string id,string days,string qt, string close, string saless, string average, string netvolume)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["venue"] = "";
        HttpContext.Current.Session["Group_Venue"] = "";
        HttpContext.Current.Session["source"] = "";
        HttpContext.Current.Session["budgetMonth"] = "";
        HttpContext.Current.Session["source2"] = "";
        HttpContext.Current.Session["qtss"] = "";
        HttpContext.Current.Session["qtss"] = "";
        HttpContext.Current.Session["close"] = "";
        HttpContext.Current.Session["sales"] = "";
        HttpContext.Current.Session["averagePrice"] = "";
        HttpContext.Current.Session["netVolume"] = "";
        HttpContext.Current.Session["days"] = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
     
        string[] ids = id.Split(',');
        string[] dayss = days.Split(',');
        string[] qts = qt.Split(',');
        string[] closes = close.Split(',');
        string[] salesss = saless.Split(',');
        string[] avg = average.Split(',');
        string[] net = netvolume.Split(',');
        
        for (int i = 0; i <= ids.Length - 1; i++)
        {
            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();
            if (ids[i] == "undefined" || qts[i] == "undefined" || closes[i] == "undefined" || salesss[i] == "undefined" || avg[i] == "undefined" || net[i] == "undefined" || dayss[i] == "undefined")
            {

            }else
            {
                string query1 = "select venue,venue_group,Source,Convert(char(3),datename(month,Budget_Month)),QT,[Close], Sales, AveragePrice, NetVolume,[Days],Source2 from Monthly_BudgetIndo where SR = '" + ids[i] + "'";
                SqlCommand cmd = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())

                {
                    HttpContext.Current.Session["venue"] = reader.GetString(0);
                    HttpContext.Current.Session["Group_Venue"] = reader.GetString(1);
                    HttpContext.Current.Session["source"] = reader.GetString(2);
                    HttpContext.Current.Session["budgetMonth"] = reader.GetString(3);
                    HttpContext.Current.Session["source2"] = reader.GetString(10);

                    HttpContext.Current.Session["qtss"] = reader.GetDouble(4);
                    HttpContext.Current.Session["close"] = reader.GetInt32(5);
                    HttpContext.Current.Session["sales"] = reader.GetDouble(6);
                    HttpContext.Current.Session["averagePrice"] = reader.GetInt32(7);
                    HttpContext.Current.Session["netVolume"] = reader.GetDouble(8);
                    HttpContext.Current.Session["days"] = reader.GetString(9);
                }
                if (HttpContext.Current.Session["qtss"].ToString().Equals(qts[i]))
                {

                }
                else
                {
                    string pageName = "Budget";
                    string details = "Venue: " + HttpContext.Current.Session["venue"].ToString() + ", Group Venue: " + HttpContext.Current.Session["Group_Venue"] + ", Source: " + HttpContext.Current.Session["source"] + ", month: " + HttpContext.Current.Session["budgetMonth"] + ", QT changed from : " + HttpContext.Current.Session["qtss"] + " to: " + qts[i];
                    int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                }


                if (HttpContext.Current.Session["close"].ToString().Equals(closes[i]))
                {

                }
                else
                {
                    string pageName = "Budget";
                    string details = "Venue: " + HttpContext.Current.Session["venue"].ToString() + ", Group Venue: " + HttpContext.Current.Session["Group_Venue"] + ", Source: " + HttpContext.Current.Session["source"] + ", month: " + HttpContext.Current.Session["budgetMonth"] + ", Close changed from : " + HttpContext.Current.Session["close"] + " to: " + closes[i];
                    int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                }


                if (HttpContext.Current.Session["sales"].ToString().Equals(salesss[i]))
                {

                }
                else
                {
                    string pageName = "Budget";
                    string details = "Venue: " + HttpContext.Current.Session["venue"].ToString() + ", Group Venue: " + HttpContext.Current.Session["Group_Venue"] + ", Source: " + HttpContext.Current.Session["source"] + ", month: " + HttpContext.Current.Session["budgetMonth"] + ", sales changed from : " + HttpContext.Current.Session["sales"] + " to: " + salesss[i];
                    int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["averagePrice"].ToString().Equals(avg[i]))
                {

                }
                else
                {
                    string pageName = "Budget";
                    string details = "Venue: " + HttpContext.Current.Session["venue"].ToString() + ", Group Venue: " + HttpContext.Current.Session["Group_Venue"] + ", Source: " + HttpContext.Current.Session["source"] + ", month: " + HttpContext.Current.Session["budgetMonth"] + ", Average Price changed from : " + HttpContext.Current.Session["averagePrice"] + " to: " + avg[i];
                    int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["netVolume"].ToString().Equals(net[i]))
                {

                }
                else
                {
                    string pageName = "Budget";
                    string details = "Venue: " + HttpContext.Current.Session["venue"].ToString() + ", Group Venue: " + HttpContext.Current.Session["Group_Venue"] + ", Source: " + HttpContext.Current.Session["source"] + ", month: " + HttpContext.Current.Session["budgetMonth"] + ", Net Volume changed from : " + HttpContext.Current.Session["netVolume"] + " to: " + net[i];
                    int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                }



                if (HttpContext.Current.Session["days"].ToString().Equals(dayss[i]))
                {

                }
                else
                {
                    string pageName = "Budget";
                    string details = "Venue: " + HttpContext.Current.Session["venue"].ToString() + ", Group Venue: " + HttpContext.Current.Session["Group_Venue"] + ", Source: " + HttpContext.Current.Session["source"] + ", month: " + HttpContext.Current.Session["budgetMonth"] + ", Net Volume changed from : " + HttpContext.Current.Session["days"] + " to: " + dayss[i];
                    int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
                }

                HttpContext.Current.Session["venue"] = "";
                HttpContext.Current.Session["Group_Venue"] = "";
                HttpContext.Current.Session["source"] = "";
                HttpContext.Current.Session["budgetMonth"] = "";
                HttpContext.Current.Session["source2"] = "";
                HttpContext.Current.Session["qtss"] = "";
                HttpContext.Current.Session["qtss"] = "";
                HttpContext.Current.Session["close"] = "";
                HttpContext.Current.Session["sales"] = "";
                HttpContext.Current.Session["averagePrice"] = "";
                HttpContext.Current.Session["netVolume"] = "";
                HttpContext.Current.Session["days"] = "";

                reader.Close();
            }
            sqlcon1.Close();
            
        }

        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();

        for (int i = 0; i <= qts.Length - 1; i++)
        {
            if (ids[i] == "undefined" || qts[i] == "undefined" || closes[i] == "undefined" || salesss[i]=="undefined" || avg[i]=="undefined" || net[i]=="undefined" || dayss[i]=="undefined")
            {

            }else
            if (ids[i] == "" || qts[i] == "" || closes[i] == "" || salesss[i] == "" || avg[i] == "" || net[i] == "")
            {

               
            }
            else
            { 
                string query = "update Monthly_BudgetIndo set QT='"+qts[i]+"',[Close]='"+closes[i]+"',Sales='"+salesss[i]+"',AveragePrice='"+avg[i]+"',NetVolume='"+net[i]+"' ,Days='"+dayss[i]+"' where SR='"+ids[i]+"' ";
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
    public static string getSourceOnVenueGroup(string venueGroup)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct marketing_group from Marketing_Program2 where Venue2_ID = '"+ venueGroup + "' and MProgram2_Status = 'Active'";
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