﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

public partial class WebSite5_production_Marketing_Source : System.Web.UI.Page
{
    static string pname;
    static string office1;
    static string user;

    static string MSource_Name1;
    static string MSource_Status1;
    static string MProgram2_ID1;



    
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
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    public string getAllVenueOnCountry()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Venue_ID,Venue_Name from venue where Venue_Country_ID in('VC001','VC1') and Venue_Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string venueID = reader.GetString(0);
            string venueName = reader.GetString(1);
            htmlstr += "<option value='" + venueID + "'>" + venueName + "</option>";
        }
        reader.Close();

        sqlcon.Close();

        return htmlstr;
    }


    [WebMethod]
    public static string getAllVenue2(string venue)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select v2.Venue2_ID,v2.Venue2_Name from venue2 v2 where v2.Venue_ID='" + venue + "' and v2.Venue2_Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string venue2_ID = reader.GetString(0);
            string venue2_Name = reader.GetString(1);


            JSON += "[\"" + venue2_ID + "\",\"" + venue2_Name + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static void insertSource(string marktSourceName, string markt)
    {
                int id = 0;
                string value = "MS";
                string marktSourceID;
                string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string sql = "select Marketing_Source_ID from Admin_ID_gen";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                string val = (string)cmd.ExecuteScalar();
                id= Convert.ToInt32(val) + 1;
                 marktSourceID = value+id;
       
        
       
                string query = "insert into Marketing_Source (MSource_ID,MSource_Name,MSource_Status,MSource_Create_Date,MProgram2_ID) values('"+ marktSourceID + "','"+ marktSourceName.ToUpper() + "','Active','"+time.ToString(format)+"','"+ markt + "');";
                SqlCommand cmd1 = new SqlCommand(query, sqlcon);
                cmd1.ExecuteNonQuery();

               string query1 = "update Admin_ID_gen set Marketing_Source_ID='" + id+"';";
              SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
           cmd4.ExecuteNonQuery();
               sqlcon.Close();

        string pageName = "Marketing Source";
        string details = "Marketing Source Created : Name: " + marktSourceName + ", Marketing ID: " + markt;
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());



    }

    


    [WebMethod]
    public static string getAllMarketing_Source()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select ms.MSource_ID,ms.MSource_Name,ms.MSource_Status,mp.MProgram2_ID,mp.MProgram2_Name,v.Venue_ID,v2.Venue2_ID from Marketing_Source ms join Marketing_Program2 mp on ms.MProgram2_ID=mp.MProgram2_ID join venue2 v2 on mp.Venue2_ID=v2.Venue2_ID join venue v on v2.Venue_ID=v.Venue_ID";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string marktSourceID = reader.GetString(0);
            string marktSourceName = reader.GetString(1);
            string status = reader.GetString(2);
            string marktID = reader.GetString(3);
            string marktName = reader.GetString(4);
            string Venue_ID = reader.GetString(5);
            string Venue2_ID = reader.GetString(6);


            JSON += "[\"" + marktSourceID + "\" , \"" + marktSourceName + "\",\"" + status + "\",\"" + marktID + "\",\"" + marktName + "\",\"" + Venue_ID + "\",\"" + Venue2_ID + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string getAllMarkt(string venue2)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select mp.MProgram2_ID,mp.MProgram2_Name from Marketing_Program2 mp where mp.Venue2_ID='"+venue2+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

          
            string markt_ID = reader.GetString(0);
            string markt_Name = reader.GetString(1);


            JSON += "[\"" + markt_ID + "\",\"" + markt_Name + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }
    [WebMethod]
    public static void deleteMarktSource(string marktSourceID,string marktSourceName)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Marketing_Source where [MSource_ID]='" + marktSourceID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();


        string pageName = "Marketing Source";
        string details = "Marketing Source: " + marktSourceName + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }


    [WebMethod]
    public static void updateMarktSource(string marktSourceID, string marktSourceName, string status, string markt)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon1 = new SqlConnection(conn);
        sqlcon1.Open();

        string query1 = "select ms.MSource_ID,ms.MSource_Name,ms.MSource_Status,mp.MProgram2_ID,mp.MProgram2_Name,v.Venue_ID,v2.Venue2_ID from Marketing_Source ms join Marketing_Program2 mp on ms.MProgram2_ID=mp.MProgram2_ID join venue2 v2 on mp.Venue2_ID=v2.Venue2_ID join venue v on v2.Venue_ID=v.Venue_ID where ms.MSource_ID='"+marktSourceID+"'";
        SqlCommand cmd = new SqlCommand(query1, sqlcon1);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            MSource_Name1 = reader.GetString(1);
            MSource_Status1 = reader.GetString(2);
            MProgram2_ID1 = reader.GetString(3);
           
        }

        if (MSource_Name1.Equals(marktSourceName))
        { }
        else
        {
            string pageName = "Marketing Source";
            string details = "Name changed from: " + MSource_Name1 + "To: " + marktSourceName;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        if (MSource_Status1.Equals(status))
        { }
        else
        {
            string pageName = "Marketing Source";
            string details = "Status changed from: " + MSource_Status1 + "To: " + status;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

        if (MProgram2_ID1.Equals(markt))
        { }
        else
        {
            string pageName = "Marketing Source";
            string details = "Marketing Program changed from: " + MProgram2_ID1 + "To: " + markt;
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }


        reader.Close();
        sqlcon1.Close();
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {
            string query = "update Marketing_Source set[MSource_Name] = '"+ marktSourceName.ToUpper() + "', [MSource_Status]='"+ status + "',[MProgram2_ID]='"+ markt + "' where[MSource_ID]='"+marktSourceID+"' ;";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Marketing_Source set [MSource_Name]='"+marktSourceName.ToUpper()+"', [MSource_Status]='"+status+"',[MSource_Expiry_Date]='"+time.ToString(format)+"',[MProgram2_ID]='"+ markt + "' where [MSource_ID]='"+ marktSourceID + "'";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

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


}