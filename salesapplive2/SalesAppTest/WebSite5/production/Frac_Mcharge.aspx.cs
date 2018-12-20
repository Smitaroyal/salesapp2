using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Frac_Mcharge : System.Web.UI.Page
{

 


  
    public string getdata()
    {
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

       string  user = (string)Session["username"];
     //   office = (string)Session["office"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
     //   Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();

        TextBox4.Text= DateTime.Today.ToString("yyyy");
    }

    [WebMethod]
    public static void insertMcharge(string mchargeName, string mchargeWeek,string mchargeYear)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        int id = 0;
        string value = "MC";
        string mchargeID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;              
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select Frac_Mc_ID from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        mchargeID = value + id;
        string query = "insert into Frac_MCharge ([MCharge_ID],[MCharge_Resi_Type],[MCharge_Per_Week],[MCharge_Year],[MCharge_Status],[MCharge_Created_Date]) values('" + mchargeID + "','" + mchargeName.ToUpper() + "','"+ mchargeWeek + "','"+ mchargeYear + "','Active','"+time.ToString(format)+"');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        string query1 = "update Admin_ID_gen set Frac_Mc_ID='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Frac Mcharge";
        string details = "Frac Mcharge created: Type: " + mchargeName.ToUpper() + ", Mc Charge Per Week: " + mchargeWeek + ", Mc Charge Year: " + mchargeYear ;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }

    [WebMethod]
    public static string getAllMcharge()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select * from Frac_MCharge";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string mchargeID = reader.GetString(0);
            string mchargeName = reader.GetString(1);
            int mchargeWeek = reader.GetInt32(2);
            string mchargeYear = reader.GetString(3);
            string mchargeStatus = reader.GetString(4);

            JSON += "[\"" + mchargeID + "\" , \"" + mchargeName + "\",\"" + mchargeWeek + "\",\"" + mchargeYear + "\",\"" + mchargeStatus + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static void deleteMcharge(string mchargeID,string mchargeName)

    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Frac_MCharge where [MCharge_ID]='" + mchargeID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Frac Mcharge";
        string details = "Frac Mcharge:" + mchargeName + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }


    [WebMethod]
    public static void updateMcharge(string mchargeID, string mchargeName, string mchargeWeek, string mchargeYear,string mchargeStatus)
    {
       HttpContext.Current.Session["MCharge_Resi_Type"]="";
        HttpContext.Current.Session["MCharge_Per_Week"] = "";
        HttpContext.Current.Session["MCharge_Year"] = "";
        HttpContext.Current.Session["MCharge_Status"] = "";
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "   select MCharge_Resi_Type,MCharge_Per_Week,MCharge_Year,MCharge_Status from Frac_MCharge where MCharge_ID = '" + mchargeID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["MCharge_Resi_Type"]   = reader.GetString(0);
            HttpContext.Current.Session["MCharge_Per_Week"]   = reader.GetInt32(1);

            HttpContext.Current.Session["MCharge_Year"]  = reader.GetString(2);
            HttpContext.Current.Session["MCharge_Status"]  = reader.GetString(3);

        }
        if (HttpContext.Current.Session["MCharge_Resi_Type"].ToString().Equals(mchargeName))
        { }
        else
        {
            string pageName = "Frac Mcharge";
            string details = "Frac Resi Type changed from: " + HttpContext.Current.Session["MCharge_Resi_Type"].ToString() + "To: " + mchargeName.ToString();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["MCharge_Per_Week"].ToString().Equals(mchargeWeek))
        { }
        else
        {
            string pageName = "Frac Mcharge";
            string details = "MCharge_Per_Week changed from: " + HttpContext.Current.Session["MCharge_Per_Week"].ToString() + "To: " + mchargeWeek;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["MCharge_Year"].ToString().Equals(mchargeYear))
        { }
        else
        {
            string pageName = "Frac Mcharge";
            string details = "year changed from: " + HttpContext.Current.Session["MCharge_Year"].ToString() + "To: " + mchargeYear;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["MCharge_Status"].ToString().Equals(mchargeStatus))
        { }
        else
        {
            string pageName = "Frac Mcharge";
            string details = "Status changed from: " + HttpContext.Current.Session["MCharge_Status"].ToString() + "To: " + mchargeStatus;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        reader.Close();
        sqlcon1.Close();


        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        if (mchargeStatus == "Active")
        {

            string query = "update Frac_MCharge set MCharge_Resi_Type='"+ mchargeName.ToUpper() + "',MCharge_Per_Week='"+ mchargeWeek + "',MCharge_Year='"+ mchargeYear + "',MCharge_Status='"+ mchargeStatus + "' where MCharge_ID='"+ mchargeID + "'";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Frac_MCharge set MCharge_Resi_Type='"+ mchargeName.ToUpper() + "',MCharge_Per_Week='"+ mchargeWeek + "',MCharge_Year='"+ mchargeYear + "',MCharge_Status='"+ mchargeStatus + "',MCharge_Expiry_Date='"+time.ToString(format)+"' where MCharge_ID='"+ mchargeID + "'";
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