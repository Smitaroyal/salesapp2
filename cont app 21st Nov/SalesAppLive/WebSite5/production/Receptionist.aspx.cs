using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Receptionist : System.Web.UI.Page
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
        HttpContext.Current.Session["Name"] = ""; HttpContext.Current.Session["designation"] = "";
        HttpContext.Current.Session["fullName"] = ""; HttpContext.Current.Session["status"] = "";
        string user = (string)Session["username"];
         // office = (string)Session["office"];
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
    public static void insertReceptionist(string name, string designation,string fullName)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        int id = 0;
        string value = "R";
        string ID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;              
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        string sql = "select Receptionist from Admin_ID_gen";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        string val = (string)cmd.ExecuteScalar();
        id = Convert.ToInt32(val) + 1;
        ID = value + id;
        string query = "insert into Reception values('"+ID+"','"+name.ToUpper()+"','','"+designation.ToUpper()+"','','Active','"+time.ToString(format)+"','','"+fullName.ToUpper()+"','')";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        string query1 = "update Admin_ID_gen set Receptionist='" + id + "';";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        cmd4.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Receptionist";
        string details = " Receptionist Created :  Name: " + name.ToUpper() + ", designation: " + designation.ToUpper() + ", full Name: " + fullName.ToUpper();
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
    }

    [WebMethod]
    public static string getAllReceptionist()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select * from Reception;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string ID = reader.GetString(0);
            string recepName = reader.GetString(1);
            string recepDesig= reader.GetString(3);
            string recepStatus = reader.GetString(5);
            string fullName = reader.GetString(8);

            JSON += "[\"" + ID + "\" , \"" + recepName + "\",\"" + recepDesig + "\",\"" + fullName + "\",\"" + recepStatus + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;
        
    }

    [WebMethod]
    public static void deleteReceptionist(string ID,string recepName)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Reception where [Recep_ID]='" + ID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Receptionist";
        string details = "Receptionist: " + recepName + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }

    [WebMethod]
    public static void updateReceptionist(string ID, string name, string designation,string fullName,string status)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        HttpContext.Current.Session["Name"] = ""; HttpContext.Current.Session["designation"] = "";
        HttpContext.Current.Session["fullName"] = ""; HttpContext.Current.Session["status"] = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        string query1 = "select Recep_First_Name,Recep_Desig,Recep_Full_Name,Recep_Status from Reception where Recep_ID='"+ID+"'";
        sqlcon1.Open();
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            HttpContext.Current.Session["Name"] = reader.GetString(0);
            HttpContext.Current.Session["designation"] = reader.GetString(1);
            HttpContext.Current.Session["fullName"] = reader.GetString(2);
            HttpContext.Current.Session["status"] = reader.GetString(3);
        }
        if (HttpContext.Current.Session["Name"].ToString().Equals(name))
        { }
        else
        {
            string pageName = "Receptionist";
            string details = "Name changed from: " + HttpContext.Current.Session["Name"].ToString() + "To: " + name;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["designation"].ToString().Equals(designation))
        { }
        else
        {
            string pageName = "Receptionist";
            string details = "designation changed from: " + HttpContext.Current.Session["designation"].ToString() + "To: " + designation;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (HttpContext.Current.Session["fullName"].ToString().Equals(designation))
        { }
        else
        {
            string pageName = "Receptionist";
            string details = "fullName changed from: " + HttpContext.Current.Session["fullName"].ToString() + "To: " + fullName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (HttpContext.Current.Session["status"].ToString().Equals(status))
        { }
        else
        {
            string pageName = "Receptionist";
            string details = "status changed from: " + HttpContext.Current.Session["status"].ToString() + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        sqlcon1.Close();

        if (status=="Active")
        {
            
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "update Reception set Recep_First_Name='" + name.ToUpper() + "',Recep_Desig='" + designation.ToUpper() + "',Recep_Full_Name='" + fullName.ToUpper() + "' where Recep_ID='" + ID + "'";
            sqlcon.Open();
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            sqlcon.Close();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
         
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "update Reception set Recep_First_Name='" + name.ToUpper() + "',Recep_Desig='" + designation.ToUpper() + "',Recep_Full_Name='" + fullName.ToUpper() + "',Recep_Status='"+status+"',Recep_Expiry_Date='"+time.ToString(format)+"' where Recep_ID='" + ID + "';";
            sqlcon.Open();
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            sqlcon.Close();

        }
     

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

   
            string val = "EditProfile1.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        
        

        return JSON;



    }
}