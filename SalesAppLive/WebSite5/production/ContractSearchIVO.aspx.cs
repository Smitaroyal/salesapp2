using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using Microsoft.Reporting.WebForms;
public partial class WebSite5_production_ContractSearchIVO : System.Web.UI.Page
{

    static string pname,office;
    static string user;
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
        pname = Request.QueryString["name"];
        office = (string)Session["office"];
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
    public static string searchcontract(string contractNo)
 {
        string JSON = "{\n \"names\":[";
      
        if (contractNo == "" || contractNo == null)
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select top(100) Contract_Finance_Cont_Numb as ContractNo,cf.Profile_ID,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as Name,Contract_Finance_Purchase_Price as [Total Purchase Price] ,Contract_Finance_Deal_Drawer as [Deal Status] from Contract_Finance cf join Profile_Primary pp on cf.Profile_ID = pp.Profile_ID join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID where (cf.Contract_Finance_Cont_Numb='"+ contractNo + "' or pp.Profile_ID ='"+ contractNo + "' or pp.Profile_Primary_Fname like '"+ contractNo + "%' or pp.Profile_Primary_Lname like '"+ contractNo + "%' or q.Primary_Mobile like '"+ contractNo + "%')";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    string ContractNo = reader.GetString(0);
                    string Profile_ID = reader.GetString(1);
                    string Name = reader.GetString(2);
                    int totalPurchasePrice = reader.GetInt32(3);
                    string dealStatus = reader.GetString(4);
                  

                    string ContractNo1 = ContractNo.Trim();
                    string Profile_ID1 = Profile_ID.Trim();
                    string Name1 = Name.Trim();
                    int totalPurchasePrice1 = totalPurchasePrice;
                    string dealStatus1 = dealStatus.Trim();
                

                    JSON += "[\"" + ContractNo1 + "\" , \"" + Profile_ID1 + "\",\"" + Name1 + "\" , \"" + totalPurchasePrice1 + "\", \"" + dealStatus1 + "\"],";


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
    public static string getlink(string contractNo)
    {
        string JSON = "{\n \"names\":[";
        
        if (office == "IVO")
        {
            if (pname == "EditContract")
            {

                string val = "../../Contractsite/Edit_Contract.aspx?ContractNo=" + contractNo + "";
                JSON += "[\"" + val + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }
            else if (pname == "ViewContract")
            {
                string val = "../../Contractsite/ContractView.aspx?ContractNo=" + contractNo + "";
                JSON += "[\"" + val + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }

        }
       


        return JSON;



    }
}