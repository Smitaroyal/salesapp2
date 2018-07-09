using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Rights : System.Web.UI.Page
{

    static string pname;
    static string user;
    static string Country_Name1;
    static string Country_Code1;
    static string office1;
    public string getdata()
    {
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
        office1 = (string)Session["office"];
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
    public static void insertUsers(string username, string password, string name, string email, string office, string group,string title)
    {
        
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
       
       
        string query = "insert into users ([username],[password],[name],[userstatus],[office],[created_date],[dept],[Group Id],[Email],[Title]) values('" + username + "','" + password + "','" + name + "','Active','"+ office + "','" + time.ToString(format) + "','','"+ group + "','"+email+"','"+title+"');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();
            sqlcon.Close();
        
    }





    [WebMethod]
    public static string getAllUsers(string search)
    {
        string JSON = "{\n \"names\":[";
        if (search == "" || search == null)
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {

            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select u.username,u.password,u.name,u.office,g.[Group Id],g.[Group Name],u.Email,u.Title,u.userstatus from users u join user_Group g on u.[Group Id]=g.[Group Id] where Office='" + office1 + "' and u.username like '" + search + "%'  ;";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    string username = reader.GetString(0);
                    string password = reader.GetString(1);
                    string name = reader.GetString(2);
                    string office = reader.GetString(3);
                    int groupID = reader.GetInt32(4);
                    string groupName = reader.GetString(5);
                    string email = reader.GetString(6);
                    string title = reader.GetString(7);
                    string userstatus = reader.GetString(8);
                    JSON += "[\"" + username + "\" , \"" + password + "\",\"" + name + "\",\"" + office + "\",\"" + groupID + "\",\"" + email + "\",\"" + title + "\",\"" + groupName + "\",\"" + userstatus + "\"],";


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


    [WebMethod]
    public static string getRights()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select PageUrl,PageName,ParentNode,AccessNode,Office from PageUrl where Office='" + office1+"' and pagetype='Main'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string PageUrl = reader.GetString(0);
            string PageName = reader.GetString(1);
            string ParentNode = reader.GetString(2);
            string AccessNode = reader.GetString(3);
            string office = reader.GetString(4);

            JSON += "[\"" + PageUrl + "\" , \"" + PageName + "\",\"" + ParentNode + "\",\"" + AccessNode + "\",\"" + office + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string getActiveRights(string group, string username)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select uga.Name from user_group_access uga where uga.[Group Id]='"+group+"' and uga.Username='"+username+"' and uga.pagetype='Main'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string Name = reader.GetString(0);


                JSON += "[\"" + Name + "\"],";


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
    public static string getAdmin()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select PageUrl,PageName,ParentNode,AccessNode,Office from PageUrl where Office='" + office1 + "' and pagetype='Admin'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string PageUrl = reader.GetString(0);
            string PageName = reader.GetString(1);
            string ParentNode = reader.GetString(2);
            string AccessNode = reader.GetString(3);
            string office = reader.GetString(4);


            JSON += "[\"" + PageUrl + "\" , \"" + PageName + "\",\"" + ParentNode + "\",\"" + AccessNode + "\",\"" + office + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string getActiveAdmin(string group, string username)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select uga.Name from user_group_access uga where uga.[Group Id]='" + group + "' and uga.Username='" + username + "' and uga.pagetype='Admin'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string Name = reader.GetString(0);


                JSON += "[\"" + Name + "\"],";


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
    public static string getReports()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select PageUrl,PageName,ParentNode,AccessNode,Office from PageUrl where Office='" + office1 + "' and pagetype='Reports'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string PageUrl = reader.GetString(0);
            string PageName = reader.GetString(1);
            string ParentNode = reader.GetString(2);
            string AccessNode = reader.GetString(3);
            string office = reader.GetString(4);


            JSON += "[\"" + PageUrl + "\" , \"" + PageName + "\",\"" + ParentNode + "\",\"" + AccessNode + "\",\"" + office + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string getActiveReports(string group, string username)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select uga.Name from user_group_access uga where uga.[Group Id]='" + group + "' and uga.Username='" + username + "' and uga.pagetype='Reports'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string Name = reader.GetString(0);


                JSON += "[\"" + Name + "\"],";


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


    public string getAllGroups()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
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

        reader.Close();
        sqlcon.Close();
        return htmlstr;
    }



    [WebMethod]
    public static void updateUsers(string username, string password, string name, string email, string office, string group, string title,string val,string vals,string vals1,string rVal,string rVal1,string aVal,string aVal1)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (val == "Active")
        {

            string query = "update users set [password]='" + password + "',[name]='" + name + "',[userstatus]='" + val + "',[office]='" + office + "',[dept]='',[Group Id]='" + group + "',[Email]='" + email + "',[Title]='" + title + "' where [username]='" + username + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update users set [password]='" + password + "',[name]='" + name + "',[userstatus]='" + val + "',[office]='" + office + "',[dept]='',[Expiry_Date]='" + time.ToString(format) + "',[Group Id]='" + group + "',[Email]='" + email + "',[Title]='" + title + "'  where [username]='" + username + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        string[] array = vals.Split(',');
        string[] array1 = vals1.Split(',');

        for (int i = 0; i <= array1.Length - 1; i++)
        {
            string query = "delete from user_group_access where [Group Id]='" + group + "' and Name='" + array1[i] + "' and Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.ExecuteNonQuery();
        }

        for (int i = 0; i <= array.Length - 1; i++)
        {
            string query = "delete from user_group_access where [Group Id]='"+ group + "' and Name='"+array[i]+ "' and Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.ExecuteNonQuery();


            string query1 = "select * from PageUrl where PageName='"+array[i]+"' and Office='"+office1+ "' ";
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {

                string pageurl = reader.GetString(1);
                string pagename = reader.GetString(2);
                string parentNode = reader.GetString(4);
                string AcessNode = reader.GetString(5);
                string type = reader.GetString(6);

                string query2 = "insert into user_group_access ([Group Id],Name,Title,PageName,office,ParentNode,AccessName,PageType,Username) values('"+group+"','"+pagename+"','"+ title + "','"+pageurl+"','"+office1+"','"+parentNode+"','"+AcessNode+"','"+type+"','"+username+"')";
                SqlCommand cmd3 = new SqlCommand(query2, sqlcon);
                cmd3.ExecuteNonQuery();

            }
           // reader.Close();


        }

        string[] aarray = aVal.Split(',');
        string[] aarray1 = aVal1.Split(',');

        for (int i = 0; i <= aarray1.Length - 1; i++)
        {
            string query = "delete from user_group_access where [Group Id]='" + group + "' and Name='" + aarray1[i] + "' and Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.ExecuteNonQuery();
        }

        for (int i = 0; i <= aarray.Length - 1; i++)
        {
            string query = "delete from user_group_access where [Group Id]='" + group + "' and Name='" + aarray[i] + "' and Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.ExecuteNonQuery();


            string query1 = "select * from PageUrl where PageName='" + aarray[i] + "' and Office='" + office1 + "' ";
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {

                string pageurl = reader.GetString(1);
                string pagename = reader.GetString(2);
                string parentNode = reader.GetString(4);
                string AcessNode = reader.GetString(5);
                string type = reader.GetString(6);

                string query2 = "insert into user_group_access ([Group Id],Name,Title,PageName,office,ParentNode,AccessName,PageType,Username) values('" + group + "','" + pagename + "','" + title + "','" + pageurl + "','" + office1 + "','" + parentNode + "','" + AcessNode + "','" + type + "','" + username + "')";
                SqlCommand cmd3 = new SqlCommand(query2, sqlcon);
                cmd3.ExecuteNonQuery();

            }
            // reader.Close();


        }




        string[] rarray = rVal.Split(',');
        string[] rarray1 = rVal1.Split(',');

        for (int i = 0; i <= rarray1.Length - 1; i++)
        {
            string query = "delete from user_group_access where [Group Id]='" + group + "' and Name='" + rarray1[i] + "' and Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.ExecuteNonQuery();
        }

        for (int i = 0; i <= rarray.Length - 1; i++)
        {
            string query = "delete from user_group_access where [Group Id]='" + group + "' and Name='" + rarray[i] + "' and Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.ExecuteNonQuery();


            string query1 = "select * from PageUrl where PageName='" + rarray[i] + "' and Office='" + office1 + "' ";
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {

                string pageurl = reader.GetString(1);
                string pagename = reader.GetString(2);
                string parentNode = reader.GetString(4);
                string AcessNode = reader.GetString(5);
                string type = reader.GetString(6);

                string query2 = "insert into user_group_access ([Group Id],Name,Title,PageName,office,ParentNode,AccessName,PageType,Username) values('" + group + "','" + pagename + "','" + title + "','" + pageurl + "','" + office1 + "','" + parentNode + "','" + AcessNode + "','" + type + "','" + username + "')";
                SqlCommand cmd3 = new SqlCommand(query2, sqlcon);
                cmd3.ExecuteNonQuery();

            }
            // reader.Close();


        }

        sqlcon.Close();

    }
}