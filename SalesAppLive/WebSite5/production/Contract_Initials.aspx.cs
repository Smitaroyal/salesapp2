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
    static string office1;
    static string countryID;
    static string pname;

    static string Contract_Club_Name;
    static string Contract_Club_Status;
    static string Contract_Code;
    static string Venue_ID;
    static string Increment_Value;
    static string Nationality;

    static string Contract_Resort_Name;
    static string Contract_Resort_Status;
    static string Code;
    static string venue1;
    static string Increment_Value1;
    static string Nationality1;
    static string user;
    public string getdata()
    {

        office1 = (string)Session["office"];
        string user = (string)Session["username"];
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
        office1 = (string)Session["office"];
        user = (string)Session["username"];
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
    public static void insertContractInitials(string venue,string club,string nationality,string initial,string inc,string type,string venueName)
    {

        if (type == "TimeShare")
        {
            int id = 0;

            string value = "COC";
            string contInitID;
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='" + office1 + "' and Venue_Country_Status='Active';";

            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                countryID = reader.GetString(0);
            }
            reader.Close();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string sql = "select Contract_Initials from Admin_ID_gen";
            SqlCommand cmd1 = new SqlCommand(sql, sqlcon);

            string val = (string)cmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;
            contInitID = value + id;
            string query1 = "insert into Contract_Club (Contract_Club_ID,Contract_Club_Name,Contract_Club_Status,Contract_Club_Created_Date,Venue_Country_ID,Office,Contract_Code,Venue_ID,Increment_Value,Nationality) values('" + contInitID + "','" + club + "','Active','" + time.ToString(format) + "','" + countryID + "','" + office1 + "','" + initial.ToUpper() + "','" + venue + "','" + inc + "','" + nationality + "');";
            SqlCommand cmd2 = new SqlCommand(query1, sqlcon);
            cmd2.ExecuteNonQuery();

            string query2 = "update Admin_ID_gen set Contract_Initials='" + id + "';";
            SqlCommand cmd4 = new SqlCommand(query2, sqlcon);
            cmd4.ExecuteNonQuery();
            sqlcon.Close();

            string pageName = "Contract Initials";
            string details = "Contract Initials Created : Venue:" + venue + ", Club:" + club+ ", nationality:" + nationality+", contract code:"+initial+", Inc Val:"+inc+", type:"+type;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

        }
        else
        {
            int id = 0;

            string value = "CRG";
            string contInitID;
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            string query = "select Venue_Country_ID from VenueCountry where Venue_Country_Office='" + office1 + "' and Venue_Country_Status='Active';";

            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                countryID = reader.GetString(0);
            }
            reader.Close();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string sql = "select Fract from Admin_ID_gen";
            SqlCommand cmd1 = new SqlCommand(sql, sqlcon);

            string val = (string)cmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;
            contInitID = value + id;
            string query1 = "insert into Contract_ResortCode_Generation(Contract_Resort_ID,Contract_Resort_Name,Contract_Resort_Status,Contract_Resort_Created_Date,office,Venue,Code,Increment_Value,Nationality) values('" + contInitID + "','" + club + "','Active','" + time.ToString(format) + "','" + office1 + "','" + venueName + "','" + initial.ToUpper() + "','" + inc + "','" + nationality + "');";
            SqlCommand cmd2 = new SqlCommand(query1, sqlcon);
            cmd2.ExecuteNonQuery();

            string query2 = "update Admin_ID_gen set Fract='" + id + "';";
            SqlCommand cmd4 = new SqlCommand(query2, sqlcon);
            cmd4.ExecuteNonQuery();
            sqlcon.Close();

            string pageName = "Contract Initials";
            string details = "Contract Initials Created : Venue:" + venueName + ", Club:" + club + ", nationality:" + nationality + ", contract code:" + initial + ", Inc Val:" + inc + ", type:" + type;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

           
          
        
    }

  
    public  string getVenue()
    {
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
                htmlstr += "<option value='"+venueID+"'>"+venueName+"</option>";
            }

            reader1.Close();
            sqlcon1.Close();
        }
     
        reader.Close();
        sqlcon.Close();
        return htmlstr;



    }

    [WebMethod]
    public static string getclub(string value)

    {
      

        if (value == "TimeShare")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string JSON = "{\n \"names\":[";
            string query = "select distinct Contract_Club_Name  from Contract_Club where Office='"+ office1 + "' and Contract_Club_Status='Active';";
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
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string JSON = "{\n \"names\":[";
            string query = "select distinct Contract_Resort_Name from Contract_ResortCode_Generation  where office='"+ office1 + "' and Contract_Resort_Status='Active'";
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
      

    }


    [WebMethod]
    public static string getContractInitials(string value)

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
         
            string query = "select Contract_Resort_ID,Contract_Resort_Name,Contract_Resort_Status,v.Venue_ID,venue,Code,Increment_Value,Nationality from Contract_ResortCode_Generation cg join venue v on  cg.Venue=v.Venue_Name where office = '" + office1 + "' and cg.Venue like '" + value + "%' and cg.Contract_Resort_Status='Active' UNION  select Contract_Club_ID,Contract_Club_Name,Contract_Club_Status,cc.Venue_ID,v.Venue_Name,Contract_Code,Increment_Value,Nationality  from Contract_Club cc  join venue v on cc.Venue_ID = v.Venue_ID  where Office = '" + office1 + "' and v.Venue_Name like '" + value + "%' and Contract_Club_Status='Active';";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                var contractid = reader.GetString(0);
                var club = reader.GetString(1);
                var status = reader.GetString(2);
                var venueID = reader.GetString(3);
                var venueName = reader.GetString(4);
                var contractCode = reader.GetString(5);
                var inc = reader.GetString(6);
                var nationality = reader.GetString(7);
                JSON += "[\"" + contractid + "\",\"" + club + "\",\"" + status + "\",\"" + venueID + "\",\"" + venueName + "\",\"" + contractCode + "\",\"" + inc + "\",\"" + nationality + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            reader.Close();
            sqlcon.Close();
          

        }
        return JSON;



    }


    
    [WebMethod]
    public static void updateInitials(string contractID, string venue, string club,string nationality,string initial,string inc,string status,string type,string venueName)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        
        if (type == "TimeShare")
        {
            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();

            string query1 = "select Contract_Club_Name,Contract_Club_Status,Contract_Code,Venue_ID,Increment_Value,Nationality from Contract_Club where Office='"+ office1 + "' and Contract_Club_ID='"+contractID+"';";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Contract_Club_Name = reader.GetString(0);
                Contract_Club_Status = reader.GetString(1);

                Contract_Code = reader.GetString(2);
                Venue_ID = reader.GetString(3);

                Increment_Value = reader.GetString(4);
                Nationality = reader.GetString(5);
            }

            if (Contract_Club_Name.Equals(club)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Club Name changed from:" + Contract_Club_Name + "To:" + club;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Contract_Club_Status.Equals(status)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Status changed from:" + Contract_Club_Status + "To:" + status;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Contract_Code.Equals(initial)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Contract Code changed from:" + Contract_Code + "To:" + initial;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Venue_ID.Equals(venue)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Venue changed from:" + Venue_ID + "To:" + venue;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Increment_Value.Equals(inc)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Increment Value changed from:" + Increment_Value + "To:" + inc;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Nationality.Equals(nationality)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Nattionality changed from:" + Nationality + "To:" + nationality;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            reader.Close();
            sqlcon1.Close();
            if (status == "Active")
            {
                SqlConnection sqlcon = new SqlConnection(conn);
                sqlcon.Open();

                string query = "update Contract_Club set Contract_Club_Name = '" + club + "', Contract_Club_Status = '" + status + "', Venue_ID = '" + venue + "', Contract_Code = '" + initial.ToUpper() + "', Increment_Value = '" + inc + "', Nationality = '" + nationality + "' where Contract_Club_ID = '" + contractID + "'";

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

                string query = "update Contract_Club set Contract_Club_Name = '" + club + "', Contract_Club_Status = '" + status + "', Venue_ID = '" + venue + "', Contract_Code = '" + initial.ToUpper() + "', Increment_Value = '" + inc + "', Nationality = '" + nationality + "',Contract_Club_Expiry_Date='" + time.ToString(format) + "' where Contract_Club_ID = '" + contractID + "'";

                SqlCommand cmd2 = new SqlCommand(query, sqlcon);
                cmd2.ExecuteNonQuery();
                sqlcon.Close();
            }
        }
        else
        {
            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();

            string query1 = "select Contract_Resort_Name,Contract_Resort_Status,venue,Code,Increment_Value,Nationality from Contract_ResortCode_Generation where office='"+ office1 + "' and Contract_Resort_ID='"+contractID+"';";
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Contract_Resort_Name = reader.GetString(0);
                Contract_Resort_Status = reader.GetString(1);

                venue1 = reader.GetString(2);
                Code = reader.GetString(3);

                Increment_Value1 = reader.GetString(4);
                Nationality1 = reader.GetString(5);
            }

            if (Contract_Resort_Name.Equals(club)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Club Name changed from:" + Contract_Resort_Name + "To:" + club;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Contract_Resort_Status.Equals(status)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Status changed from:" + Contract_Resort_Status + "To:" + status;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Code.Equals(initial)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Contract Code changed from:" + Code + "To:" + initial;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (venue1.Equals(venue)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Venue changed from:" + venue1 + "To:" + venueName;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Increment_Value1.Equals(inc)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Increment Value changed from:" + Increment_Value1 + "To:" + inc;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            if (Nationality1.Equals(nationality)) { }
            else
            {
                string pageName = "Contract Initials";
                string details = "Nattionality changed from:" + Nationality1 + "To:" + nationality;
                int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
            }

            reader.Close();
            sqlcon1.Close();


            if (status == "Active")
            {
                SqlConnection sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                string query = "update Contract_ResortCode_Generation set Contract_Resort_Name='"+club+"',Contract_Resort_Status='"+status+"',Venue='"+ venueName + "',Code='"+initial.ToUpper()+"',Increment_Value='"+inc+"' ,Nationality='"+nationality+"' where Contract_Resort_ID='"+ contractID + "';";

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

                string query = "update Contract_ResortCode_Generation set Contract_Resort_Name='"+club+"',Contract_Resort_Status='"+status+"',Contract_Resort_Expiry_Date='"+time.ToString(format)+"',Venue='"+ venueName + "',Code='"+initial.ToUpper()+"',Increment_Value='"+inc+"' ,Nationality='"+nationality+"' where Contract_Resort_ID='"+ contractID + "';";

                SqlCommand cmd2 = new SqlCommand(query, sqlcon);
                cmd2.ExecuteNonQuery();
                sqlcon.Close();
            }
        }
       

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


    [WebMethod]
    public static string searchProfile(string profileID)
    {
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
        string JSON = "{\n \"names\":[";

        if (office1 == "HML")
        {


            string val = "../../Contractsite/IndiaEdit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        else if (office1 == "IVO")
        {


            string val = "../../Contractsite/Edit Profile.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }



        return JSON;



    }
}