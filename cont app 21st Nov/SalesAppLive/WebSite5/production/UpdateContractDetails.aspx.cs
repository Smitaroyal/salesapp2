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
    public static string getAllCountries()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select * from Country;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string countryID = reader.GetString(0);
            string countryName = reader.GetString(1);
            string countryCode = reader.GetString(2);

            JSON += "[\"" + countryID + "\" , \"" + countryName + "\",\"" + countryCode + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }

    
    [WebMethod]
    public static string getdealStatusOnContractNo(string contractNo,string group)
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "  select '1' as orders,DealStatus from ContractDetails_Indian cd where cd.ContractNo='"+ contractNo + "' union select '',ds.Status_Type from DealStatus ds where  ds.Status='Active' and  ds.Status_Type  not in (select DealStatus from ContractDetails_Indian cd where cd.ContractNo='"+contractNo+"')  ORDER BY orders desc";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string Status_Type = reader.GetString(1);


                JSON += "[\"" + Status_Type + "\"],";


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
     
        sqlcon.Close();
        return JSON;
        

    }


    [WebMethod]
    public static string getSubvenueOnContractNo(string contractNo)
    {
        string profileID = "";
        string groupVenue = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct p.Profile_ID,p.Profile_Group_Venue from ContractDetails_Indian cd join profile p on cd.ProfileID=p.Profile_ID where ContractNo='"+ contractNo + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                 profileID = reader.GetString(0);
                 groupVenue = reader.GetString(1);
            }

            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select SubVenue,'1' orders from Profile where Profile_ID='"+profileID+"' union select distinct SVenue_India_Name,'' orders from sub_venue_india sbi join Venue_Group vg on vg.Venue_Group_ID=sbi.GroupVenue_ID where SVenue_India_Name not in (select p.SubVenue from Profile p where Profile_ID='"+profileID+"') and vg.Venue_Group_Name='"+groupVenue+"' order by orders desc";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    string subVenue = reader1.GetString(0);
                    JSON += "[\"" + subVenue + "\"],";
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

            sqlcon1.Close();

        }
        else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();

        return JSON;


    }

    [WebMethod]
    public static string getLeadOfficeOnContractNo(string contractNo)
    {
        string profileID = "";
        string groupVenue = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct p.Profile_ID,p.Profile_Group_Venue from ContractDetails_Indian cd join profile p on cd.ProfileID=p.Profile_ID where ContractNo='" + contractNo + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                profileID = reader.GetString(0);
                groupVenue = reader.GetString(1);
            }

            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select leadOffice,'1' orders from Profile where Profile_ID='"+ profileID + "' union select distinct Office,'' orders from LeadSourceOffice where Office not in (select leadOffice from profile where Profile_ID='"+ profileID + "') and status='Active' order by orders desc";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    string leadOffice = reader1.GetString(0);
                    JSON += "[\"" + leadOffice + "\"],";
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

            sqlcon1.Close();

        }
        else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        sqlcon.Close();

        return JSON;


    }


    [WebMethod]
    public static string getContractDetailsOnContractNo(string contractNo,string group)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";

        if (group=="Update Deal Status")
        {
        
            string query = "select cd.ContractDetails_ID,convert(varchar,cd.DealRegistered_Date,105) as dealdate ,cd.ProfileID from ContractDetails_Indian cd where cd.ContractNo='" + contractNo + "' ";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    string ContractDetails_ID = reader.GetString(0);
                    string DealRegistered_Date = reader.GetString(1);
                    string profileID = reader.GetString(2);


                    JSON += "[\"" + ContractDetails_ID + "\",\"" + DealRegistered_Date + "\",\"" + profileID + "\"],";


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

            sqlcon.Close(); 
        }
        else if (group== "Update Marketing Source SPI")
        {
            string query = "select distinct cd.ContractDetails_ID,convert(varchar,cd.DealRegistered_Date,105) as dealdate ,cd.ProfileID,p.Sale_Marketing_Source from ContractDetails_Indian cd join profile p on p.Profile_ID = cd.ProfileID  where cd.ContractNo='" + contractNo + "' and cd.DealStatus='REGISTERED' and p.Profile_Group_Venue='flybuy'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string ContractDetails_ID = reader.GetString(0);
                    string DealRegistered_Date = reader.GetString(1);
                    string profileID = reader.GetString(2);
                    string salesMarketing = reader.GetString(3);
                  //  string Marketing_Program_name = reader.GetString(4);
                  //  string leadOffice = reader.GetString(5);


                    JSON += "[\"" + ContractDetails_ID + "\",\"" + DealRegistered_Date + "\",\"" + profileID + "\",\"" + salesMarketing + "\"],";



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

            sqlcon.Close();
          
        } else if (group=="Update Referral Name")
        {
            string query = "select distinct cd.ContractDetails_ID,convert(varchar,cd.DealRegistered_Date,105) as dealdate ,cd.ProfileID,isnull(crm.Referred_By,'')  ,isnull(crm.comment1,'')  from ContractDetails_Indian cd left join CRM_details crm on cd.ContractDetails_ID=crm.contractdetails_id where cd.ContractNo='" + contractNo+"' and cd.DealStatus='REGISTERED'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string ContractDetails_ID = reader.GetString(0);
                    string DealRegistered_Date = reader.GetString(1);
                    string profileID = reader.GetString(2);
                    string refferedBy = reader.GetString(3);
                    string comment = reader.GetString(4);

                    JSON += "[\"" + ContractDetails_ID + "\",\"" + DealRegistered_Date + "\",\"" + profileID + "\",\"" + refferedBy + "\",\"" + comment + "\"],";



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

            sqlcon.Close();
        }
        else if (group == "Update Upgrade Details")
        {
            string contractType="";
            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query2 = "select distinct cd.ContractType from ContractDetails_Indian cd where cd.ContractNo='" + contractNo + "' and cd.DealStatus='REGISTERED'";
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand(query2, sqlcon1);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    contractType = reader1.GetString(0);

                }
                
                if (contractType== "Trade-In-Weeks") 
                {
                    string query = "select distinct cd.ContractDetails_ID,convert(varchar,cd.DealRegistered_Date,105) as dealdate ,cd.ProfileID,cd.ContractType,pa.oldVolume,pa.oldadminfee,pa.oldTotalTax,pa.oldDeposit,ctw.Trade_In_Weeks_ContNo_RCINo from ContractDetails_Indian cd  join Contract_PA_Indian pa on cd.ContractDetails_ID=pa.ContractDetails_ID join Contract_Trade_In_Weeks_Indian ctw on cd.ContractDetails_ID=ctw.ContractDetails_ID where cd.ContractNo='" + contractNo + "' and cd.DealStatus='REGISTERED'";
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ContractDetails_ID = reader.GetString(0);
                            string DealRegistered_Date = reader.GetString(1);
                            string profileID = reader.GetString(2);
                            string ContractType = reader.GetString(3);
                            string oldVolume = reader.GetString(4);
                            string oldAdminFee = reader.GetString(5);
                            string oldTotalTax = reader.GetString(6);
                            string oldDeposit = reader.GetString(7);
                            string oldContractNo = reader.GetString(8);

                            JSON += "[\"" + ContractDetails_ID + "\",\"" + DealRegistered_Date + "\",\"" + profileID + "\",\"" + ContractType + "\",\"" + oldVolume + "\",\"" + oldAdminFee + "\",\"" + oldTotalTax + "\",\"" + oldDeposit + "\",\"" + oldContractNo + "\"],";
                            


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

                    sqlcon.Close();
                }

                else if(contractType == "Trade-In-Points")
                {
                    string query = "select distinct cd.ContractDetails_ID,convert(varchar,cd.DealRegistered_Date,105) as dealdate ,cd.ProfileID,cd.ContractType,pa.oldVolume,pa.oldadminfee,pa.oldTotalTax,pa.oldDeposit,ctp.Trade_In_Details_ContNo_RCINo from ContractDetails_Indian cd  join Contract_PA_Indian pa on cd.ContractDetails_ID=pa.ContractDetails_ID join Contract_Trade_In_Points_Indian ctp on cd.ContractDetails_ID=ctp.ContractDetails_ID where cd.ContractNo='" + contractNo + "' and cd.DealStatus='REGISTERED'";
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ContractDetails_ID = reader.GetString(0);
                            string DealRegistered_Date = reader.GetString(1);
                            string profileID = reader.GetString(2);
                            string ContractType = reader.GetString(3);
                            string oldVolume = reader.GetString(4);
                            string oldAdminFee = reader.GetString(5);
                            string oldTotalTax = reader.GetString(6);
                            string oldDeposit = reader.GetString(7);
                            string oldContractNo = reader.GetString(8);
                            JSON += "[\"" + ContractDetails_ID + "\",\"" + DealRegistered_Date + "\",\"" + profileID + "\",\"" + ContractType + "\",\"" + oldVolume + "\",\"" + oldAdminFee + "\",\"" + oldTotalTax + "\",\"" + oldDeposit + "\",\"" + oldContractNo + "\"],";



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

                    sqlcon.Close();
                }
                
                else if (contractType == "Trade-In-Fractionals")
                {
                    string query = "select distinct top(1) cd.ContractDetails_ID,convert(varchar,cd.DealRegistered_Date,105) as dealdate ,cd.ProfileID,cd.ContractType,pa.FoldVolume,pa.Foldadminfee,pa.FoldTotalTax,pa.FoldDeposit,ctf.oldContract_No from ContractDetails_Indian cd  join Contract_Fractional_PA_Indian pa on cd.ContractDetails_ID=pa.ContractDetails_ID join Contract_Trade_In_Fractional_Indian ctf on cd.ContractDetails_ID=ctf.ContractDetails_ID where cd.ContractNo='" + contractNo + "' and cd.DealStatus='REGISTERED'";
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ContractDetails_ID = reader.GetString(0);
                            string DealRegistered_Date = reader.GetString(1);
                            string profileID = reader.GetString(2);
                            string ContractType = reader.GetString(3);
                            string oldVolume = reader.GetString(4);
                            string oldAdminFee = reader.GetString(5);
                            string oldTotalTax = reader.GetString(6);
                            string oldDeposit = reader.GetString(7);
                            string oldContractNo = reader.GetString(8);
                            JSON += "[\"" + ContractDetails_ID + "\",\"" + DealRegistered_Date + "\",\"" + profileID + "\",\"" + ContractType + "\",\"" + oldVolume + "\",\"" + oldAdminFee + "\",\"" + oldTotalTax + "\",\"" + oldDeposit + "\",\"" + oldContractNo + "\"],";



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

                    sqlcon.Close();
                }

            }
            else
            {
                JSON += "[\"" + "" + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }

            reader1.Close();
            sqlcon1.Close();


           
        }


        return JSON;

    }

    

   
    [WebMethod]
    public static void updatedetails(string group, string contractID, string profileID,string contractNo, string dealStatus,string marketingSource,string referralBy,string Comment,string contractType,string oldVolume,string oldAdminFee,string oldTotalTax,string oldDeposit,string oldContractNo,string subVenue,string leadOffice)
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
       
        if (group=="Update Deal Status")
        {
            HttpContext.Current.Session["dealStatus"] = "";
            SqlConnection sqlcon1 = new SqlConnection(conn);
            string querylog = "select DealStatus from ContractDetails_Indian where ContractDetails_ID='"+contractID+"'";
            sqlcon1.Open();
            SqlCommand cmd = new SqlCommand(querylog, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HttpContext.Current.Session["dealStatus"] = reader.GetString(0);
                }

                if (HttpContext.Current.Session["dealStatus"].ToString().Equals(dealStatus))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Deal Status changed from: " + HttpContext.Current.Session["dealStatus"].ToString() + "To: " + dealStatus;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }
            }
            else
            {

            }
         
            reader.Close();
            sqlcon1.Close();

            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "update ContractDetails_Indian set DealStatus='"+ dealStatus + "' where ContractDetails_ID='"+contractID+"' and ContractNo='"+ contractNo + "'";
            sqlcon.Open();
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            sqlcon.Close();
        }
        else if (group == "Update Marketing Source SPI")
        {
            HttpContext.Current.Session["Profile_Marketing_Source"] = "";
            HttpContext.Current.Session["Profile_Sub_Venue"] = "";
            HttpContext.Current.Session["Profile_lead_Office"] = "";
            SqlConnection sqlcon2 = new SqlConnection(conn);
            string querylog = "select Sale_Marketing_Source,SubVenue,leadoffice from profile where Profile_ID = '"+profileID+"'";
            sqlcon2.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlcon2);
            SqlDataReader readerlog = cmdlog.ExecuteReader();
            if (readerlog.HasRows)
            {
                while (readerlog.Read())
                {
                    HttpContext.Current.Session["Profile_Marketing_Source"] = readerlog.GetString(0);
                    HttpContext.Current.Session["Profile_Sub_Venue"] = readerlog.GetString(1);
                    HttpContext.Current.Session["Profile_lead_Office"] = readerlog.GetString(2);
                }

                if (HttpContext.Current.Session["Profile_Marketing_Source"].ToString().Equals(marketingSource))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Profile Marketing Source changed from: " + HttpContext.Current.Session["Profile_Marketing_Source"].ToString() + "To: " + marketingSource;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }


                if (HttpContext.Current.Session["Profile_Sub_Venue"].ToString().Equals(subVenue))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Profile Sub venue changed from: " + HttpContext.Current.Session["Profile_Sub_Venue"].ToString() + "To: " + subVenue;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["Profile_lead_Office"].ToString().Equals(leadOffice))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Profile lead Office changed from: " + HttpContext.Current.Session["Profile_lead_Office"].ToString() + "To: " + leadOffice;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

            }
            else
            {

            }

            readerlog.Close();
            readerlog.Close();

            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "update profile set Sale_Marketing_Source='"+ marketingSource + "',SubVenue='"+subVenue+"',leadOffice='"+leadOffice+"' where Profile_ID='"+profileID+"'";
            sqlcon.Open();
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
            sqlcon.Close();

            HttpContext.Current.Session["CRM_Marketing_Source"] = "";
            HttpContext.Current.Session["CRM_updated_user"] = "";

            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select * from CRM_details where contractdetails_id='"+contractID+"' and Profile_ID='"+profileID+"' and status='Active'";
            sqlcon1.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HttpContext.Current.Session["CRM_Marketing_Source"] = reader.GetString(3);
                    HttpContext.Current.Session["CRM_updated_user"] = reader.GetString(9);
                }

                if (HttpContext.Current.Session["CRM_Marketing_Source"].ToString().Equals(marketingSource))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "CRM Marketing Source changed from: " + HttpContext.Current.Session["CRM_Marketing_Source"].ToString() + "To: " + marketingSource;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["CRM_updated_user"].ToString().Equals(user))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "CRM User changed from: " + HttpContext.Current.Session["CRM_updated_user"].ToString() + "To: " + user;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string query3 = "update CRM_details set program_source='"+marketingSource+"',updated_date='"+time.ToString(format)+"',updatedby='"+user+"' where Profile_ID='"+profileID+"' and contractdetails_id='"+contractID+"' and status='Active'";
                sqlcon.Open();
                SqlCommand cmd4 = new SqlCommand(query3, sqlcon);
                cmd4.ExecuteNonQuery();

            }
            else
            {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string query2 = " insert into CRM_details values ('"+profileID+"','"+contractID+"','"+marketingSource+"','','','"+time.ToString(format)+"','','"+user+"','','Active')";
                sqlcon.Open();
                SqlCommand cmd3 = new SqlCommand(query2, sqlcon);
                cmd3.ExecuteNonQuery();

                string pageName = "Update Contract Details";
                string details = "CRM Details Created : profile ID: " + profileID + ", Contract ID: " + contractID + ", Marketing Source: " + marketingSource + ", Created date time: " + time.ToString(format)+" user :"+user;
                int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
            }

            sqlcon1.Close();
            sqlcon.Close();

           
        }
        else if(group== "Update Referral Name")
        {
            HttpContext.Current.Session["CRM_Referral"] = "";
            HttpContext.Current.Session["CRM_Comment"] = "";
            HttpContext.Current.Session["CRM_updated_user"] = "";
            SqlConnection sqlcon = new SqlConnection(conn);
            SqlConnection sqlcon1 = new SqlConnection(conn);
            string query1 = "select * from CRM_details where contractdetails_id='" + contractID + "' and Profile_ID='" + profileID + "' and status='Active'";
            sqlcon1.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlcon1);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HttpContext.Current.Session["CRM_Referral"] = reader.GetString(4);
                    HttpContext.Current.Session["CRM_Comment"] = reader.GetString(5);
                    HttpContext.Current.Session["CRM_updated_user"] = reader.GetString(9);
                }

                if (HttpContext.Current.Session["CRM_Referral"].ToString().Equals(referralBy))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "CRM Refferal changed from: " + HttpContext.Current.Session["CRM_Referral"].ToString() + "To: " + referralBy;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["CRM_Comment"].ToString().Equals(Comment))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "CRM Comment changed from: " + HttpContext.Current.Session["CRM_Comment"].ToString() + "To: " + Comment;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["CRM_updated_user"].ToString().Equals(user))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "CRM updated by changed from: " + HttpContext.Current.Session["CRM_updated_user"].ToString() + "To: " + user;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }


                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string query3 = "update CRM_details set Referred_By='"+referralBy+"' ,comment1='"+Comment+ "',updated_date='" + time.ToString(format) + "',updatedby='" + user + "' where Profile_ID='" + profileID + "' and contractdetails_id='" + contractID + "' and status='Active'";
                sqlcon.Open();
                SqlCommand cmd4 = new SqlCommand(query3, sqlcon);
                cmd4.ExecuteNonQuery();

            }
            else
            {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss:sss";
                string query2 = "insert into CRM_details values ('" + profileID + "','" + contractID + "','','"+referralBy+"','"+Comment+"','" + time.ToString(format) + "','','" + user + "','','Active')";
                sqlcon.Open();
                SqlCommand cmd3 = new SqlCommand(query2, sqlcon);
                cmd3.ExecuteNonQuery();

                string pageName = "Update Contract Details";
                string details = "CRM Details Created : profile ID: " + profileID + ", Contract ID: " + contractID + ", Referral by: " + referralBy + ", comment : "+Comment+", Created date time: " + time.ToString(format) + " user :" + user;
                int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
            }

            sqlcon1.Close();
            sqlcon.Close();

        } else if(group=="Update Upgrade Details")
        {
           
            if (contractType== "Trade-In-Weeks")
            {
                DataSet exrds = Queries.LoadExchange_Rate();
                string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();

                double usdOldVolume =Math.Round(double.Parse(oldVolume) / double.Parse(dollarrate));
                double usdOldAdminFee = Math.Round(double.Parse(oldAdminFee) / double.Parse(dollarrate));
                double usdOldTotalTax = Math.Round(double.Parse(oldTotalTax) / double.Parse(dollarrate));
                double usdOldDeposit = Math.Round(double.Parse(oldDeposit) / double.Parse(dollarrate));

                HttpContext.Current.Session["oldVolume"] = "";
                HttpContext.Current.Session["oldAdminFee"] = "";
                HttpContext.Current.Session["oldTotalTax"] = "";
                HttpContext.Current.Session["oldDeposit"] = "";
                HttpContext.Current.Session["oldContractNo"] = "";
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select distinct oldVolume,oldadminfee,oldTotalTax,oldDeposit,ctw.Trade_In_Weeks_ContNo_RCINo from Contract_PA_Indian cpa join ContractDetails_Indian cd on cd.ContractDetails_ID=cpa.ContractDetails_ID join Contract_Trade_In_Weeks_Indian ctw on cd.ContractDetails_ID=ctw.ContractDetails_ID where cd.ContractNo='"+contractNo+"' and cd.ContractDetails_ID='"+contractID+"'";
                sqlcon1.Open();
                SqlCommand cmd = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        HttpContext.Current.Session["oldVolume"] = reader.GetString(0);
                        HttpContext.Current.Session["oldAdminFee"]= reader.GetString(1);
                        HttpContext.Current.Session["oldTotalTax"]= reader.GetString(2);
                        HttpContext.Current.Session["oldDeposit"]= reader.GetString(3);
                        HttpContext.Current.Session["oldContractNo"]= reader.GetString(4);
                    }
                }else
                {

                }

                if (HttpContext.Current.Session["oldVolume"].ToString().Equals(oldVolume))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in weeks old Volume  changed from: " + HttpContext.Current.Session["oldVolume"].ToString() + "To: " + oldVolume;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["oldAdminFee"].ToString().Equals(oldAdminFee))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in weeks old AdminFee  changed from: " + HttpContext.Current.Session["oldAdminFee"].ToString() + "To: " + oldAdminFee;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }


                if (HttpContext.Current.Session["oldTotalTax"].ToString().Equals(oldTotalTax))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in weeks old Total Tax changed from: " + HttpContext.Current.Session["oldTotalTax"].ToString() + "To: " + oldTotalTax;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["oldDeposit"].ToString().Equals(oldDeposit))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in weeks old Deposit Tax changed from: " + HttpContext.Current.Session["oldDeposit"].ToString() + "To: " + oldDeposit;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["oldContractNo"].ToString().Equals(oldContractNo))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in weeks old ContractNo changed from: " + HttpContext.Current.Session["oldContractNo"].ToString() + "To: " + oldContractNo;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                reader.Close();
                sqlcon1.Close();


                SqlConnection sqlcon = new SqlConnection(conn);
                string query3 = "update Contract_PA_Indian set oldVolume = '" + oldVolume + "', oldadminfee = '" + oldAdminFee + "', oldTotalTax = '" + oldTotalTax + "', oldDeposit = '" + oldDeposit + "',usdoldvolume='"+usdOldVolume+"',usdoldadminfee='"+usdOldAdminFee+"',usdoldtax='"+usdOldTotalTax+"',usdolddeposit='"+usdOldDeposit+"' where ContractNo = '" + contractNo + "' and ContractDetails_ID = '" + contractID + "'";
                sqlcon.Open();
                SqlCommand cmd4 = new SqlCommand(query3, sqlcon);
                cmd4.ExecuteNonQuery();

                string query4 = "update Contract_Trade_In_Weeks_Indian set Trade_In_Weeks_ContNo_RCINo='"+oldContractNo+"' where ContractNo='"+contractNo+"' and ContractDetails_ID='"+contractID+"'";            
                SqlCommand cmd5 = new SqlCommand(query4, sqlcon);
                cmd5.ExecuteNonQuery();
                sqlcon.Close();

            }
            else if (contractType == "Trade-In-Points")
            {

                DataSet exrds = Queries.LoadExchange_Rate();
                string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();

                double usdOldVolume = Math.Round(double.Parse(oldVolume) / double.Parse(dollarrate));
                double usdOldAdminFee = Math.Round(double.Parse(oldAdminFee) / double.Parse(dollarrate));
                double usdOldTotalTax = Math.Round(double.Parse(oldTotalTax) / double.Parse(dollarrate));
                double usdOldDeposit = Math.Round(double.Parse(oldDeposit) / double.Parse(dollarrate));

                HttpContext.Current.Session["oldVolume"] = "";
                HttpContext.Current.Session["oldAdminFee"] = "";
                HttpContext.Current.Session["oldTotalTax"] = "";
                HttpContext.Current.Session["oldDeposit"] = "";
                HttpContext.Current.Session["oldContractNo"] = "";
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select distinct oldVolume,oldadminfee,oldTotalTax,oldDeposit,ctp.Trade_In_Details_ContNo_RCINo from Contract_PA_Indian cpa join ContractDetails_Indian cd on cd.ContractDetails_ID=cpa.ContractDetails_ID join Contract_Trade_In_Points_Indian ctp on cd.ContractDetails_ID=ctp.ContractDetails_ID where cd.ContractNo='" + contractNo + "' and cd.ContractDetails_ID='" + contractID + "'";
                sqlcon1.Open();
                SqlCommand cmd = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        HttpContext.Current.Session["oldVolume"] = reader.GetString(0);
                        HttpContext.Current.Session["oldAdminFee"] = reader.GetString(1);
                        HttpContext.Current.Session["oldTotalTax"] = reader.GetString(2);
                        HttpContext.Current.Session["oldDeposit"] = reader.GetString(3);
                        HttpContext.Current.Session["oldContractNo"] = reader.GetString(4);
                    }
                }
                else
                {

                }

                if (HttpContext.Current.Session["oldVolume"].ToString().Equals(oldVolume))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Points old Volume  changed from: " + HttpContext.Current.Session["oldVolume"].ToString() + "To: " + oldVolume;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["oldAdminFee"].ToString().Equals(oldAdminFee))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Points old AdminFee  changed from: " + HttpContext.Current.Session["oldAdminFee"].ToString() + "To: " + oldAdminFee;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }


                if (HttpContext.Current.Session["oldTotalTax"].ToString().Equals(oldTotalTax))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Points old Total Tax changed from: " + HttpContext.Current.Session["oldTotalTax"].ToString() + "To: " + oldTotalTax;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["oldDeposit"].ToString().Equals(oldDeposit))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Points old Deposit Tax changed from: " + HttpContext.Current.Session["oldDeposit"].ToString() + "To: " + oldDeposit;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["oldContractNo"].ToString().Equals(oldContractNo))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Points old ContractNo changed from: " + HttpContext.Current.Session["oldContractNo"].ToString() + "To: " + oldContractNo;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                reader.Close();
                sqlcon1.Close();


                SqlConnection sqlcon = new SqlConnection(conn);
                string query3 = "update Contract_PA_Indian set oldVolume = '" + oldVolume + "', oldadminfee = '" + oldAdminFee + "', oldTotalTax = '" + oldTotalTax + "', oldDeposit = '" + oldDeposit + "',usdoldvolume='" + usdOldVolume + "',usdoldadminfee='" + usdOldAdminFee + "',usdoldtax='" + usdOldTotalTax + "',usdolddeposit='" + usdOldDeposit + "' where ContractNo = '" + contractNo + "' and ContractDetails_ID = '" + contractID + "'";
                sqlcon.Open();
                SqlCommand cmd4 = new SqlCommand(query3, sqlcon);
                cmd4.ExecuteNonQuery();
                string query4 = "update Contract_Trade_In_Points_Indian set Trade_In_Details_ContNo_RCINo='"+ oldContractNo + "' where ContractNo='"+ contractNo + "' and ContractDetails_ID='"+ contractID + "'";
                SqlCommand cmd5 = new SqlCommand(query4, sqlcon);
                cmd5.ExecuteNonQuery();
                
                sqlcon.Close();
            }
            else if(contractType == "Trade-In-Fractionals")
            {
                DataSet exrds = Queries.LoadExchange_Rate();
                string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();

                double FusdOldVolume = Math.Round(double.Parse(oldVolume) / double.Parse(dollarrate));
                double FusdOldAdminFee = Math.Round(double.Parse(oldAdminFee) / double.Parse(dollarrate));
                double FusdOldTotalTax = Math.Round(double.Parse(oldTotalTax) / double.Parse(dollarrate));
                double FusdOldDeposit = Math.Round(double.Parse(oldDeposit) / double.Parse(dollarrate));

                HttpContext.Current.Session["FoldVolume"] = "";
                HttpContext.Current.Session["FoldAdminFee"] = "";
                HttpContext.Current.Session["FoldTotalTax"] = "";
                HttpContext.Current.Session["FoldDeposit"] = "";
                HttpContext.Current.Session["FoldContractNo"] = "";
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select distinct FoldVolume,Foldadminfee,FoldTotalTax,FoldDeposit,ctp.oldContract_No from Contract_Fractional_PA_Indian cpa join ContractDetails_Indian cd on cd.ContractDetails_ID=cpa.ContractDetails_ID join Contract_Trade_In_Fractional_Indian ctp on cd.ContractDetails_ID=ctp.ContractDetails_ID where cd.ContractNo='" + contractNo + "' and cd.ContractDetails_ID='" + contractID + "'";
                sqlcon1.Open();
                SqlCommand cmd = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        HttpContext.Current.Session["FoldVolume"] = reader.GetString(0);
                        HttpContext.Current.Session["FoldAdminFee"] = reader.GetString(1);
                        HttpContext.Current.Session["FoldTotalTax"] = reader.GetString(2);
                        HttpContext.Current.Session["FoldDeposit"] = reader.GetString(3);
                        HttpContext.Current.Session["FoldContractNo"] = reader.GetString(4);
                    }
                }
                else
                {

                }

                if (HttpContext.Current.Session["FoldVolume"].ToString().Equals(oldVolume))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Fractional old Volume  changed from: " + HttpContext.Current.Session["FoldVolume"].ToString() + "To: " + oldVolume;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["FoldAdminFee"].ToString().Equals(oldAdminFee))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Fractional old AdminFee  changed from: " + HttpContext.Current.Session["FoldAdminFee"].ToString() + "To: " + oldAdminFee;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }


                if (HttpContext.Current.Session["FoldTotalTax"].ToString().Equals(oldTotalTax))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Fractional old Total Tax changed from: " + HttpContext.Current.Session["FoldTotalTax"].ToString() + "To: " + oldTotalTax;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["FoldDeposit"].ToString().Equals(oldDeposit))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Fractional old Deposit Tax changed from: " + HttpContext.Current.Session["FoldDeposit"].ToString() + "To: " + oldDeposit;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                if (HttpContext.Current.Session["FoldContractNo"].ToString().Equals(oldContractNo))
                { }
                else
                {
                    string pageName = "Update Contract Details";
                    string details = "Trade in Fractional old ContractNo changed from: " + HttpContext.Current.Session["FoldContractNo"].ToString() + "To: " + oldContractNo;
                    int insertlog1 = Queries.InsertContractLogs_India(profileID, contractID, pageName + ": " + details, user, DateTime.Now.ToString());
                }

                reader.Close();
                sqlcon1.Close();



                SqlConnection sqlcon = new SqlConnection(conn);
                string query3 = "update Contract_Fractional_PA_Indian set FoldVolume='" + oldVolume + "',Foldadminfee='" + oldAdminFee + "',FoldTotalTax='" + oldTotalTax + "',FoldDeposit='" + oldDeposit + "',Fusdoldvolume='"+FusdOldVolume+"',Fusdoldadminfee='"+FusdOldAdminFee+"',Fusdoldtax='"+FusdOldTotalTax+"',Fusdolddeposit='"+FusdOldDeposit+"' where ContractNo='" + contractNo + "' and ContractDetails_ID='" + contractID + "'";
                sqlcon.Open();
                SqlCommand cmd4 = new SqlCommand(query3, sqlcon);
                cmd4.ExecuteNonQuery();

                string query4 = "update Contract_Trade_In_Fractional_Indian set oldContract_No='"+oldContractNo+"' where ContractNo='"+contractNo+"' and ContractDetails_ID='"+contractID+"'";
                SqlCommand cmd5 = new SqlCommand(query4, sqlcon);
                cmd5.ExecuteNonQuery();
                sqlcon.Close();
            }


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