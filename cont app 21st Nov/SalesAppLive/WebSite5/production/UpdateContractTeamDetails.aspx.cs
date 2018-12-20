using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Data;

public partial class WebSite5_production_UpdateContractDetails : System.Web.UI.Page
{

    static string pname;
    
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
    public static void updatedetails(string contractID, string contractNo,string repReport, string toReport, string sms,string Comment)
    {
        string user = HttpContext.Current.Session["username"].ToString();
      
       
        HttpContext.Current.Session["Approval_Comments"] = "";
        HttpContext.Current.Session["Rep_report"] = "";
        HttpContext.Current.Session["To_report"] = "";
        HttpContext.Current.Session["SMS_Update"] = "";
        HttpContext.Current.Session["Updated_Date"] = "";
        HttpContext.Current.Session["UpdatedBy"] = "";
        DataSet ds = Queries.LoadContractTeamDetails(contractID);
        if (ds.Tables[0].Rows.Count == 0)
        { }
        else
        {
            HttpContext.Current.Session["Approval_Comments"] = ds.Tables[0].Rows[0]["Approval_Comments"].ToString();
            HttpContext.Current.Session["Rep_report"] = ds.Tables[0].Rows[0]["Rep_report"].ToString();
            HttpContext.Current.Session["To_report"] = ds.Tables[0].Rows[0]["To_report"].ToString();
            HttpContext.Current.Session["SMS_Update"] = ds.Tables[0].Rows[0]["SMS_Update"].ToString();
            HttpContext.Current.Session["Updated_Date"] = ds.Tables[0].Rows[0]["Updated_Date"].ToString();
            HttpContext.Current.Session["UpdatedBy"] = ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
        }

        SqlDataReader reader1 = Queries.getcontractTeamDetailsOnContractID(contractID);
        if(reader1.HasRows)
        {
            if (String.Compare(HttpContext.Current.Session["Approval_Comments"].ToString(), Comment) != 0)
            {
                string act = "Approval_Comments changed from:" + HttpContext.Current.Session["Approval_Comments"].ToString() + "To:" + Comment;
                int insertlog1 = Queries.InsertContractLogs_India("", contractID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(HttpContext.Current.Session["Rep_report"].ToString(), repReport) != 0)
            {
                string act = "Approval_Comments changed from:" + HttpContext.Current.Session["Rep_report"].ToString() + "To:" + repReport;
                int insertlog1 = Queries.InsertContractLogs_India("", contractID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(HttpContext.Current.Session["To_report"].ToString(), toReport) != 0)
            {
                string act = "Approval_Comments changed from:" + HttpContext.Current.Session["To_report"].ToString() + "To:" + toReport;
                int insertlog1 = Queries.InsertContractLogs_India("", contractID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(HttpContext.Current.Session["SMS_Update"].ToString(), sms) != 0)
            {
                string act = "Approval_Comments changed from:" + HttpContext.Current.Session["SMS_Update"].ToString() + "To:" + sms;
                int insertlog1 = Queries.InsertContractLogs_India("", contractID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(HttpContext.Current.Session["Updated_Date"].ToString(), DateTime.Now.ToString()) != 0)
            {
                string act = "Approval_Comments changed from:" + HttpContext.Current.Session["Updated_Date"].ToString() + "To:" + DateTime.Now.ToString();
                int insertlog1 = Queries.InsertContractLogs_India("", contractID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(HttpContext.Current.Session["UpdatedBy"].ToString(), user) != 0)
            {
                string act = "Approval_Comments changed from:" + HttpContext.Current.Session["UpdatedBy"].ToString() + "To:" + user ;
                int insertlog1 = Queries.InsertContractLogs_India("", contractID, act, user, DateTime.Now.ToString());
            }
            else { }
            //update
            int updaterow = Queries.UpdateContractTeamDetails(Comment, repReport, toReport, sms, DateTime.Now.ToString(), user, contractID);


        }
        else
        {
            //else insert
            int insertrow = Queries.InsertContractTeamDetails(contractID,Comment, repReport, toReport, sms, DateTime.Now.ToString(), user,"","");

        }



    }


    [WebMethod]
    public static string getContractIDOnContractNo(string contractNo)
    {
        
      
        String JSON = "{\n \"names\":[";

        SqlDataReader reader = Queries.getContractIDOnContractNo(contractNo);

        if (reader.HasRows)
        {
            while (reader.Read())
            {

              string  contractID = reader.GetString(0);
                JSON += "[\"" + contractID + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        return JSON;
    }


    [WebMethod]
    public static string getContractTeamDetails(string contractNo)
    {
        string contractID = "";
       
        String JSON = "{\n \"names\":[";

        SqlDataReader reader = Queries.getContractIDOnContractNo(contractNo);
     
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                contractID = reader.GetString(0);
            }

            SqlDataReader reader1 = Queries.getcontractTeamDetailsOnContractID(contractID);
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    string repReport = reader1.GetString(0);
                    string toReport = reader1.GetString(1);
                    string smsReport = reader1.GetString(2);
                    string comments = reader1.GetString(3);

                    JSON += "[\"" + contractID + "\",\"" + repReport + "\",\"" + toReport + "\",\"" + smsReport + "\",\"" + comments + "\"],";
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

        }
        else
        {
            JSON += "[\"" + "" + "\"],";
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