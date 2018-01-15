using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    [WebMethod]
    public static void insertUsers(string username, string password, string name, string email, string status, string office, string department, string group,string title)
    {
        
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
       
       
        string query = "insert into users ([username],[password],[name],[userstatus],[office],[created_date],[dept],[Group Id],[Email],[Title]) values('" + username + "','" + password + "','" + name + "','"+ status + "','"+ office + "','" + time.ToString(format) + "','" + department + "','"+ group + "','"+email+"','"+title+"');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();


        sqlcon.Close();


    }

    [WebMethod]
    public static string getAllUsers()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select u.username,u.password,u.name,u.userstatus,u.office,d.[Dept Code],d.[Dept Name],g.[Group Id],g.[Group Name],u.Email,u.Title from users u join Department d on u.Dept=d.[Dept Code] join user_Group g on u.[Group Id]=g.[Group Id]  ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string username = reader.GetString(0);
            string password = reader.GetString(1);
            string name = reader.GetString(2);
            string userstatus = reader.GetString(3);
            string office = reader.GetString(4);
            string deptCode = reader.GetString(5);
            string deptName = reader.GetString(6);
            int groupID = reader.GetInt32(7);
            string groupName = reader.GetString(8);
            string email = reader.GetString(9);
            string title = reader.GetString(10);

            JSON += "[\"" + username + "\" , \"" + password + "\",\"" + name + "\",\"" + userstatus + "\",\"" + office + "\",\"" + deptCode + "\",\"" + deptName + "\",\"" + groupID + "\",\"" + groupName + "\",\"" + email + "\",\"" + title + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }




    public string getAllGroups()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select [Group Id],[Group Name] from user_Group";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            int groupID = reader.GetInt32(0);
            string groupName = reader.GetString(1);
            htmlstr += "<option value='" + groupID + "'>" + groupName + "</option>";
        }



        return htmlstr;
    }

    public string getAllDepartments()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select [Dept Code],[Dept Name] from Department";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string deptCode = reader.GetString(0);
            string deptName = reader.GetString(1);
            htmlstr += "<option value='" + deptCode + "'>" + deptName + "</option>";
        }



        return htmlstr;
    }



    [WebMethod]
    public static void deleteUsers(string username)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from users where [username]='" + username + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }


    [WebMethod]
    public static void updateUsers(string username, string password, string name, string email,string status, string office, string department,string group,string title)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update users set [username]='"+username+ "',[password]='" + password + "',[name]='" + name + "',[userstatus]='" + status + "',[office]='" + office + "',[dept]='" + department + "',[Group Id]='" + group + "',[Email]='" + email + "',[Title]='"+title+"' where [username]='"+username+"';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update users set [username]='" + username + "',[password]='" + password + "',[name]='" + name + "',[userstatus]='" + status + "',[office]='" + office + "',[dept]='" + department + "',[Expiry_Date]='"+time.ToString(format)+"',[Group Id]='" + group + "',[Email]='" + email + "',[Title]='" + title + "'  where [username]='" + username + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }




}