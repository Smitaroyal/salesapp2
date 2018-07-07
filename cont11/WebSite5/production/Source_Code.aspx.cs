﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

public partial class WebSite5_production_Source_Code : System.Web.UI.Page
{
    static string pname;
    static string office1;
   
    public string getdata()
    {
         office1 = (string)Session["office"];
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
        
        
        office1 = (string)Session["office"];
      
            string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    [WebMethod]
    public static void insertSourceCode(string sourceCodeName, string marktSource,string agentName)
    {
                int id = 0;
                string value = "SC";
                string SourceCodeID;
                string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string sql = "select Source_Code_ID from Admin_ID_gen";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                string val = (string)cmd.ExecuteScalar();
                id= Convert.ToInt32(val) + 1;
                SourceCodeID = value+id;
       
        
       
                string query = "insert into Source_code(SCode_ID,SCode_Name,SCode_Status,SCode_Create_Date,MSource_ID,agent_name) values('"+ SourceCodeID + "','"+ sourceCodeName.ToUpper() + "','Active','"+time.ToString(format)+"','"+ marktSource + "','"+agentName.ToUpper()+"');";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();

               string query1 = "update Admin_ID_gen set Source_Code_ID='" + id+"';";
              SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
            cmd4.ExecuteNonQuery();
                sqlcon.Close();
            

        
        

    }

    


    [WebMethod]
    public static string getAllSourceCode()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select sc.SCode_ID,sc.SCode_Name,sc.SCode_Status,ms.MSource_ID,ms.MSource_Name,sc.agent_name from Source_code sc join Marketing_Source ms on sc.MSource_ID=ms.MSource_ID;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string SourceCodeID = reader.GetString(0);
            string SourceCodeName = reader.GetString(1);
            string status = reader.GetString(2);
            string marktSourceID = reader.GetString(3);
            string marktSourceName = reader.GetString(4);
            string agent = reader.GetString(5);

            JSON += "[\"" + SourceCodeID + "\" , \"" + SourceCodeName + "\",\"" + status + "\",\"" + marktSourceID + "\",\"" + marktSourceName + "\",\"" + agent + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string getAllMarketingSource()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select ms.MSource_ID,ms.MSource_Name from Marketing_Source ms";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

          
            string marktSource_ID = reader.GetString(0);
            string marktSource_Name = reader.GetString(1);


            JSON += "[\"" + marktSource_ID + "\",\"" + marktSource_Name + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }
    [WebMethod]
    public static void deleteSourceCode(string SourceCodeID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Source_Code where [SCode_ID]='" + SourceCodeID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }


    [WebMethod]
    public static void updateSourceCode(string sourceCodeID, string sourceCodeName, string status, string marktSource,string agentName)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {
            string query = "update Source_code set SCode_Name='"+ sourceCodeName.ToUpper() + "',SCode_Status='"+ status + "',MSource_ID='"+ marktSource + "',agent_name='"+agentName.ToUpper()+"' where SCode_ID='"+ sourceCodeID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Source_code set SCode_Name='"+ sourceCodeName.ToUpper() + "',SCode_Status='"+ status + "',SCode_Expiry_Date='"+ time.ToString(format) + "',MSource_ID='"+ marktSource + "',agent_name='" + agentName.ToUpper() + "' where SCode_ID='" + sourceCodeID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }
    

}