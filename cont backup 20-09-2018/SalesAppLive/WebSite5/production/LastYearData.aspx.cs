using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_LastYearData : System.Web.UI.Page
{
    
    public string getdata()
    {
        string user = (string)Session["username"];
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
    public static string getdetails(string year,string month)
    {
        string day="";
        int year1= Int32.Parse(year);
        int month1 = Int32.Parse(month);
        string JSON = "{\n \"names\":[";
        int days = DateTime.DaysInMonth(year1, month1);
        for (int i = 1; i <= days; i++)
        {
            if (i==1)
            {
                day = "01";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
            else if (i == 2)
            {
                day = "02";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
            else if (i == 3)
            {
                day = "03";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
             else if (i == 4)
            {
                day = "04";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
           else if (i ==5)
            {
                day = "05";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
            else if (i == 6)
            {
                day = "06";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
            else if (i == 7)
            {
                day = "07";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
            else if (i == 8)
            {
                day = "08";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
            else if (i == 9)
            {
                day = "09";
                string date = year + "-" + month + "-" + day;
                JSON += "[\"" + date + "\"],";
            }
            else
            {
                string date = year + "-" + month + "-" + i;
                JSON += "[\"" + date + "\"],";
            }
           
        }
        
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
     
       
        return JSON;



    }




    [WebMethod]
    public static void insertLastYearData(string year, string country, string venue, string venueGroup,string source, string monthVals, string qtVals, string salesVals,string vatVals,string sourceGroup)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string[] month = monthVals.Split(',');

        string[] qt = qtVals.Split(',');
       
        string[] sales = salesVals.Split(',');
 
        string[] vat = vatVals.Split(',');


      
        for (int i = 0; i <= month.Length - 1; i++)
        {

            if (month[i] == "" || qt[i] == "" || sales[i] == "" || sales[i] == "" || vat[i] == "" )
            {

            }
            else
            {
               
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";

                string query = "insert into Lastyeardata (years,Profile_Venue_Country,venue,Venue_Group,Source,Dates,QT,Sales,Volume,[Vol+Admin+Tax],DataInsertDate,Source2)  values('" + year+"','"+country+"','"+venue+"','"+venueGroup+"','"+source+"','"+month[i]+"','"+qt[i]+"','"+sales[i]+ "','','" + vat[i] + "','"+time.ToString(format)+"','"+sourceGroup+"')";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();

                string pageName = "Last Year Data";
                string details = "Last Year Data inserted : Year: " + year + ", Country: " + country + ", Venue: " + venue + ", Venue Group: " + venueGroup + ", Source: " + source+", Day: "+month[i]+", QT: "+qt[i]+", sales: "+sales[i]+", Vat: "+ vat[i];
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
        }
        
        sqlcon.Close();
    }



    [WebMethod]
    public static void updateLastYearData(string idVals1, string qtVals1, string salesVals1, string vatVals1)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["years"] = "";
        HttpContext.Current.Session["Profile_Venue_Country"] = "";
        HttpContext.Current.Session["venue"] = "";
        HttpContext.Current.Session["Venue_Group"] = "";
        HttpContext.Current.Session["Source"] = "";
        HttpContext.Current.Session["Source2"] = "";
        HttpContext.Current.Session["Dates"] = "";
        HttpContext.Current.Session["QT"] = "";
        HttpContext.Current.Session["Sales"] = "";
        HttpContext.Current.Session["vol"] = "";

        string[] id1 = idVals1.Split(',');

        string[] qt1 = qtVals1.Split(',');

        string[] sales1 = salesVals1.Split(',');

        string[] vat1 = vatVals1.Split(',');
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        for (int i = 0; i < id1.Length - 1; i++)
        {
            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();
            string query1 = "select years,Profile_Venue_Country,venue,Venue_Group,Source,Source2,Convert(char(3),datename(day,dates)),QT,Sales,[Vol+Admin+Tax] from Lastyeardata where SR1='" + id1[i] + "'";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HttpContext.Current.Session["years"] = reader.GetInt32(0);
                HttpContext.Current.Session["Profile_Venue_Country"] = reader.GetString(1);
                HttpContext.Current.Session["venue"] = reader.GetString(2);
                HttpContext.Current.Session["Venue_Group"] = reader.GetString(3);
                HttpContext.Current.Session["Source"] = reader.GetString(4);
                HttpContext.Current.Session["Source2"] = reader.GetString(5);
                HttpContext.Current.Session["Dates"] = reader.GetString(6);
                HttpContext.Current.Session["QT"] = reader.GetDouble(7);
                HttpContext.Current.Session["Sales"] = reader.GetDouble(8);
                HttpContext.Current.Session["vol"] = reader.GetDouble(9);
            }

            if (HttpContext.Current.Session["QT"].ToString().Equals(qt1[i]))
            {

            }
            else
            {
                string pageName = "Last Year Data";
                string details = "Country " + HttpContext.Current.Session["Profile_Venue_Country"] + ",Years: " + HttpContext.Current.Session["years"] + ", Venue: " + HttpContext.Current.Session["venue"]+ ", Group Venue: " + HttpContext.Current.Session["Venue_Group"] + ", Source: " + HttpContext.Current.Session["source"] + ", QT changed from : " + HttpContext.Current.Session["QT"] + " to: " + qt1[i] + ", Source 2" + HttpContext.Current.Session["Source2"]; 
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }


            if (HttpContext.Current.Session["Sales"].ToString().Equals(sales1[i]))
            {

            }
            else
            {
                string pageName = "Last Year Data";
                string details = "Country " + HttpContext.Current.Session["Profile_Venue_Country"] + ",Years: " + HttpContext.Current.Session["years"] + ", Venue: " + HttpContext.Current.Session["venue"] + ", Group Venue: " + HttpContext.Current.Session["Venue_Group"] + ", Source: " + HttpContext.Current.Session["source"] + ", Sales changed from : " + HttpContext.Current.Session["Sales"] + " to: " + sales1[i] + ", Source 2" + HttpContext.Current.Session["Source2"]; 
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }


            if (HttpContext.Current.Session["vol"].ToString().Equals(vat1[i]))
            {

            }
            else
            {
                string pageName = "Last Year Data";
                string details = "Country " + HttpContext.Current.Session["Profile_Venue_Country"] + ",Years: " + HttpContext.Current.Session["years"] + ", Venue: " + HttpContext.Current.Session["venue"] + ", Group Venue: " + HttpContext.Current.Session["Venue_Group"] + ", Source: " + HttpContext.Current.Session["source"] + ", VOL changed from : " + HttpContext.Current.Session["vol"] + " to: " + vat1[i] + ", Source 2" + HttpContext.Current.Session["Source2"]; 
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }
            sqlcon1.Close();
        }
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        


        for (int i = 0; i < id1.Length - 1; i++)
        {
            string query = "update Lastyeardata set QT='"+qt1[i]+"',Sales='"+sales1[i]+"',[Vol+Admin+Tax]='"+vat1[i]+"' where SR1='"+id1[i]+"'";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();
        }

    }


    [WebMethod]
    public static string getSourceOnVenueGroup(string venueGroup)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct marketing_group from Marketing_Program2 where Venue2_ID = '" + venueGroup + "' and MProgram2_Status = 'Active'";
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
    public static string getLastYearData(string year,string month, string country, string venue, string venueGroup, string source, string sourceGroup1)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        if (month == "null")
        {
            JSON += "[\"" + "0" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
      
        string day = "";
        string date = "";
        int year1 = Int32.Parse(year);
        int month1 = Int32.Parse(month);
        int days = DateTime.DaysInMonth(year1, month1);
        for (int i = 1; i <= days; i++)
        {
            if (i == 1)
            {
                day = "01";
                 date = year + "-" + month + "-" + day;
                
            }
            else if (i == 2)
            {
                day = "02";
                 date = year + "-" + month + "-" + day;
               
            }
            else if (i == 3)
            {
                day = "03";
                 date = year + "-" + month + "-" + day;
           
            }
            else if (i == 4)
            {
                day = "04";
                 date = year + "-" + month + "-" + day;
              
            }
            else if (i == 5)
            {
                day = "05";
                 date = year + "-" + month + "-" + day;
              
            }
            else if (i == 6)
            {
                day = "06";
                 date = year + "-" + month + "-" + day;
               
            }
            else if (i == 7)
            {
                day = "07";
                 date = year + "-" + month + "-" + day;
             
            }
            else if (i == 8)
            {
                day = "08";
                 date = year + "-" + month + "-" + day;
               
            }
            else if (i == 9)
            {
                day = "09";
                 date = year + "-" + month + "-" + day;
               
            }
            else
            {
                 date = year + "-" + month + "-" + i;
              
            }
       
            string query = "select distinct SR1,CONVERT(varchar(10), Dates, 105) as Dates,QT,Sales,[Vol+Admin+Tax] from Lastyeardata where years='" + year+"' and Profile_Venue_Country='"+country+"' and venue='"+venue+"' and Venue_Group='"+venueGroup+"' and Source='"+source+"' and Dates='"+date+"' and Source2='"+sourceGroup1+"' order by Dates asc";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    int id = reader.GetInt32(0);
                    string dates = reader.GetString(1);
                    double QT = reader.GetDouble(2);
                        double sales = reader.GetDouble(3);
                        double vat = reader.GetDouble(4);

                    JSON += "[\"" + id + "\",\"" + dates + "\",\"" + QT + "\",\"" + sales + "\",\"" + vat + "\"],";


                }
               
            }
            else
            {
                JSON += "[\"" + "" + "\"],";
             

            }

            reader.Close();
            sqlcon.Close();

        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";


      


        }
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

        if (office == "HML")
        {


            string val = "../../Contractsite/IndiaEdit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        else if (office == "IVO")
        {


            string val = "Edit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }



        return JSON;



    }

}