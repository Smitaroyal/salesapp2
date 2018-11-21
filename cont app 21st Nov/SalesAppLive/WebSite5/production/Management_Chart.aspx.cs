using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Management_Chart : System.Web.UI.Page
{

  
    
    public string getdata()
    {
        string office1 = (string)Session["office"];
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

      string  user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
      //  Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }

    [WebMethod]
    public static void insertManagement_Chart(string type,string Year, string Currency,string NoWeek, string roomtype, string club,string propertyFee, string MemberFee,string MemberCGST, string MemberSGST,string timeMemberCGST,string timeMemberSGST)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        if (type == "TimeShare")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "insert into ManagementCharges_Chart_India values('"+Year+"','"+Currency+"','','','"+club+"','"+propertyFee.ToUpper()+"','"+MemberFee.ToUpper()+"','Active','"+time.ToString(format)+"','','"+ timeMemberCGST.ToUpper() + "','"+ timeMemberSGST.ToUpper() + "')";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();



            string pageName = "Management Charge Chart";
            string details = "Management Charge Chart Created : Year: " + Year + ", Currency: " + Currency+", club"+club+", property fee:"+propertyFee.ToUpper()+", member fee:"+MemberFee.ToUpper()+", MemberCGST :"+ timeMemberCGST.ToUpper()+", MemberSGST :"+ timeMemberSGST.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

            sqlcon.Close();

        }
        else
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "insert into ManagementCharges_Chart_India values('" + Year + "','" + Currency + "','"+NoWeek+"','"+roomtype+"','" + club + "','" + propertyFee.ToUpper() + "','" + MemberFee.ToUpper() + "','Active','" + time.ToString(format) + "','','"+MemberCGST.ToUpper()+"','"+MemberSGST.ToUpper()+"')";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();



            string pageName = "Management Charge Chart";
            string details = "Management Charge Chart Created : Year: " + Year + ", Currency: " + Currency + ", club" + club + ", property fee:" + propertyFee.ToUpper() + ", member fee:" + MemberFee.ToUpper()+",no of weeks:"+NoWeek+", room type:"+ roomtype+", Member CGST:"+MemberCGST.ToUpper()+", Member SGST:"+MemberSGST.ToUpper();
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

            sqlcon.Close();

        }


    }


    public string currency()
    {
       
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select Finance_Currency_Name from Finance_Currency where Finance_Currency_Status='Active'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string name = reader.GetString(0);

            htmlstr += "<option value='"+name+"'>"+name+"</option>";
        }
        reader.Close();
        sqlcon.Close();

        return htmlstr;

    }



    public string NoWeeks()
    {

        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select Contract_Fractional_Int_Name from Contract_Fractional_Int where Contract_Fractional_Int_Status = 'Active'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string name = reader.GetString(0);

            htmlstr += "<option value='" + name + "'>" + name + "</option>";
        }
        reader.Close();
        sqlcon.Close();

        return htmlstr;

    }


    public string RoomType()
    {

        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select Contract_Resi_Type_Name from Contract_Residence_Type where Contract_Resi_Type_Status='Active'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string name = reader.GetString(0);

            htmlstr += "<option value='" + name + "'>" + name + "</option>";
        }
        reader.Close();
        sqlcon.Close();

        return htmlstr;

    }


    [WebMethod]
    public static string getClub(string type)
    {
        string office = HttpContext.Current.Session["office"].ToString();
        if (type=="TimeShare")
        {
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            String JSON = "{\n \"names\":[";
            string query = "select distinct Contract_Club_Name from Contract_Club where Venue_Country_ID='VC4' and Contract_Club_Status='Active'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


                string Contract_Club_Name = reader.GetString(0);



                JSON += "[\"" + Contract_Club_Name + "\"],";


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
            String JSON = "{\n \"names\":[";
            string query = "select Contract_Resort_Name from Contract_Resort where office='"+office+"' and Contract_Resort_Status='Active' ";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


                string Contract_Resort_Name = reader.GetString(0);



                JSON += "[\"" + Contract_Resort_Name + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            reader.Close();
            sqlcon.Close();
            return JSON;

        }
      



    }


    [WebMethod]
    public static string getAllManagement_Chart()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct Management_ID,(Year) as year1,Currency,weekno,Otype,club,Property_fee,Member_fee,status,isnull(Member_CGST,''),isnull(Member_SGST,'') from ManagementCharges_Chart_India where status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            int Management_ID = reader.GetInt32(0);
            int year1 = reader.GetInt32(1);
            string Currency = reader.GetString(2);
            string weekno = reader.GetString(3);
            string Otype = reader.GetString(4);
            string club = reader.GetString(5);
            string Property_fee = reader.GetString(6);
            string Member_fee = reader.GetString(7);
            string status = reader.GetString(8);
            string Member_CGST = reader.GetString(9);
            string Member_SGST = reader.GetString(10);
            

            JSON += "[\"" + Management_ID + "\" , \"" + year1 + "\",\"" + Currency + "\",\"" + weekno + "\",\"" + Otype + "\",\"" + club + "\",\"" + Property_fee + "\",\"" + Member_fee + "\",\"" + status + "\",\"" + Member_CGST + "\",\"" + Member_SGST + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static void deleteManagement_Chart(string ID, string Name)

    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from ManagementCharges_Chart_India where Management_ID='"+ID+"';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        
        string pageName = "Management charge Chart";
        string details = "Name: " + Name + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        sqlcon.Close();

    }

    [WebMethod]
    public static void EditManagement_Chart(string ID)

    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "update ManagementCharges_Chart_India set status='Inactive' where Management_ID='"+ID+"';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();

        string pageName = "Management charge Chart";
        string details = "ID: " + ID + " IN ACTIVE";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
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
        string office1 = HttpContext.Current.Session["office"].ToString();
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
        string office1 = HttpContext.Current.Session["office"].ToString();

        string JSON = "{\n \"names\":[";
        
            string val = "EditProfile1.aspx?Profile_ID=" + profileID + "";
            JSON += "[\"" + val + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        return JSON;



    }

}