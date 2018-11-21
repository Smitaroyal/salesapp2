using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Globalization;

public partial class WebSite5_production_Dashboard : System.Web.UI.Page
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
        //office = (string)Session["office"];
      string  user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }
       // string user = (string)Session["username"];
      // Label1.Text = user;
        Label2.Text = user;
        string val = getdata();

   }
   

    public string getSignUps()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");

        if (format == "Saturday") 
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='HML' and convert(date,td.Tour_Details_Tour_Date) between  convert(date,'"+time.ToString(value)+ "') and convert(date,'" + time.ToString(value) + "')";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;

            }
            sqlcon.Close();


        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='HML' and convert(date,td.Tour_Details_Tour_Date) between  DATEADD(wk, DATEDIFF(wk, 0, '" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;

            }
            sqlcon.Close();
          
        }

        return htmlstr;


    }

    public string getSignUpsIVO()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='IVO' and convert(date,td.Tour_Details_Tour_Date) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();
        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='IVO' and convert(date,td.Tour_Details_Tour_Date) between  DATEADD(wk, DATEDIFF(wk, 0, '" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();


        }

            
        return htmlstr;
    }

    public string getDealsRegistered()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "select count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'REGISTERED' and p.Office = 'HML' and convert(date, DealRegistered_Date) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();
        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'REGISTERED' and p.Office = 'HML' and convert(date, DealRegistered_Date) between  DATEADD(wk, DATEDIFF(wk, 0, '" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();

        }
          
        return htmlstr;
    }


    public string getDealsRegisteredIVO()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "select count(*) from Contract_Finance cf join Profile p on cf.Profile_ID = p.Profile_ID where cf.Contract_Finance_Deal_Drawer = 'Deal' and p.Office = 'IVO' and convert(date, cf.Contract_Finance_Deal_Reg_Date) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();

        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select count(*) from Contract_Finance cf join Profile p on cf.Profile_ID = p.Profile_ID where cf.Contract_Finance_Deal_Drawer = 'Deal' and p.Office = 'IVO' and convert(date, cf.Contract_Finance_Deal_Reg_Date) between  DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();

        }

        return htmlstr;
    }


  

    public string getCancelledDeals()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "select top(1) count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'CANCELLED & REFUNDED' and p.Office = 'HML' and convert(date,DealRegistered_Date) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();

        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select top(1) count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'CANCELLED & REFUNDED' and p.Office = 'HML' and convert(date,DealRegistered_Date) between  DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();

        }
           
        return htmlstr;
    }



    public string getCancelledDealsIVO()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select top(1) count(*) from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where cf.Contract_Finance_Deal_Drawer='Cancel' and p.Office='IVO' and convert(date,cf.Contract_Finance_Deal_Reg_Date) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();
        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select top(1) count(*) from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where cf.Contract_Finance_Deal_Drawer='Cancel' and p.Office='IVO' and convert(date,cf.Contract_Finance_Deal_Reg_Date) between  DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                htmlstr += count;
            }
            sqlcon.Close();


        }
           
        return htmlstr;
    }
    public string getTopProfiles()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
           DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = " select * from(select top(2) total,name,Office,ContractType,'INR' as currency,Profile_ID from(select cast(cpa.Total_Purchase_Price as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cd.ContractType,p.Profile_ID  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_PA_Indian cpa on cpa.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date  between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "') union all select cast(Total_Purchase_Price as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cd.ContractType,p.Profile_ID  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join  Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_Fractional_PA_Indian cfp on cfp.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')) as pass order by cast(total as int) desc  union all select top(2) total,name,Office,ContractType,Contract_Finance_Currency as currency,Profile_ID from(select cf.Contract_Finance_Purchase_Price as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cf.Contract_Finance_Cont_Type as ContractType,cf.Contract_Finance_Currency,p.Profile_ID from Contract_Finance cf join profile p on p.Profile_ID=cf.Profile_ID join Profile_Primary pp on pp.Profile_ID=cf.Profile_ID where cf.Contract_Finance_Deal_Reg_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "') ) pass1 order by total desc ) as pass3 order by total  desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                int amount = reader.GetInt32(0);
                string name = reader.GetString(1);
                string office = reader.GetString(2);
                string type = reader.GetString(3);
                string currency = reader.GetString(4);
               string profileID = reader.GetString(5);
                htmlstr += "<li class='media event'> <div class='media-body'><a class='title' href='#topProfile'  id='topProfileclick" + i + "' data-toggle='modal'>" + name + " <input type='hidden' value='" + profileID + "' id='profileID" + i + "'/></a><p><strong>Office:" + office + " </strong></p></div></li>";
                i++;
            }

            sqlcon.Close();
            return htmlstr;

        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select * from(select top(2) total,name,Office,ContractType,'INR' as currency,Profile_ID from (select cast(cpa.Total_Purchase_Price as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cd.ContractType,p.Profile_ID  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_PA_Indian cpa on cpa.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4)) union all select cast(Total_Purchase_Price as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cd.ContractType,p.Profile_ID from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join 	Contract_Fractional_PA_Indian cfp on cfp.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))) as pass order by cast(total as int) desc union all select top(2) total,name,Office,ContractType,Contract_Finance_Currency as currency,Profile_ID from(select cf.Contract_Finance_Purchase_Price as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cf.Contract_Finance_Cont_Type as ContractType,cf.Contract_Finance_Currency,p.Profile_ID from Contract_Finance cf join profile p on p.Profile_ID=cf.Profile_ID join Profile_Primary pp on pp.Profile_ID=cf.Profile_ID where cf.Contract_Finance_Deal_Reg_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))) pass1 order by total desc) as pass3 order 	by total  desc";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
               
                int amount = reader.GetInt32(0);
                string name = reader.GetString(1);
                string office = reader.GetString(2);
                string type = reader.GetString(3);
                string currency = reader.GetString(4);
                string profileID = reader.GetString(5);
                htmlstr += "<li class='media event'> <div class='media-body'><a class='title' href='#topProfile'  id='topProfileclick"+i+"' data-toggle='modal'>" + name + " <input type='hidden' value='"+profileID+"' id='profileID"+i+"'/></a><p><strong>Office:" + office + " </strong></p></div></li>";
                i++;
            }
         
            sqlcon.Close();
            return htmlstr;
        }
           
    }



    public string getTopSalesRep()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";

            string query = "select top(1) count(cd.DealStatus),dbo.fnConvert_TitleCase(upper(cd.Sales_Rep)) as Sales_Rep,sum(cast(Total_Price_Including_Tax as int)) as volume,sp.Venue  from ContractDetails_Indian cd join Profile p on cd.ProfileID=p.Profile_ID join Contract_PA_Indian cpa on cd.ContractDetails_ID=cpa.ContractDetails_ID join Sales_Rep sp on sp.Sales_Rep_Name=cd.Sales_Rep where p.Office='HML'  and cd.DealStatus='REGISTERED' and cd.DealRegistered_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')  group by cd.Sales_Rep,sp.Venue order by volume desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "<li class='media event'> <div class='media-body'><a class='title' href='#salesRep' id='salesclick' data-toggle='modal'>" + name + "</a><p><strong>Office: HML</strong></p></div></li>";
            }



            sqlcon.Close();

        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select top(1) count(cd.DealStatus),dbo.fnConvert_TitleCase(upper(cd.Sales_Rep)) as Sales_Rep,sum(cast(Total_Price_Including_Tax as int)) as volume,sp.Venue  from ContractDetails_Indian cd join Profile p on cd.ProfileID=p.Profile_ID join Contract_PA_Indian cpa on cd.ContractDetails_ID=cpa.ContractDetails_ID join Sales_Rep sp on sp.Sales_Rep_Name=cd.Sales_Rep where p.Office='HML'  and cd.DealStatus='REGISTERED' and cd.DealRegistered_Date between  DATEADD(wk, DATEDIFF(wk, 0, '" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))  group by cd.Sales_Rep,sp.Venue order by volume desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "<li class='media event'> <div class='media-body'><a class='title' href='#salesRep' id='salesclick' data-toggle='modal'>" + name + "</a><p><strong>Office: HML</strong></p></div></li>";
            }
            
            sqlcon.Close();

        }
          

        return htmlstr;
    }
    public string getTopSalesRepIVO()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select top(1) count(cf.Contract_Finance_Deal_Drawer),dbo.fnConvert_TitleCase(upper(cf.Contract_Finance_Sales_Rep)) as Contract_Finance_Sales_Rep,sum(cf.Contract_Finance_Purchase_Price+ps.PS_Country_Tax) volume,sp.Venue from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID join Purchase_Service ps on cf.Contract_Finance_ID=ps.Contract_Finance_ID join Sales_Rep sp on sp.Sales_Rep_Name=cf.Contract_Finance_Sales_Rep where p.Office='IVO' and Contract_Finance_Sales_Rep !='' and Contract_Finance_Deal_Drawer='Deal' and cf.Contract_Finance_Deal_Reg_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')  GROUP BY Contract_Finance_Sales_Rep,sp.Venue order by volume desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "<li class='media event'> <div class='media-body'><a class='title' href='#salesRepIVO' id='salesclickIVO' data-toggle='modal'>" + name + "</a><p><strong>Office: IVO</strong></p></div></li>";
            }
            sqlcon.Close();

        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "select top(1) count(cf.Contract_Finance_Deal_Drawer),dbo.fnConvert_TitleCase(upper(cf.Contract_Finance_Sales_Rep)) as Contract_Finance_Sales_Rep,sum(cf.Contract_Finance_Purchase_Price+ps.PS_Country_Tax) volume,sp.Venue from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID join Purchase_Service ps on cf.Contract_Finance_ID=ps.Contract_Finance_ID join Sales_Rep sp on sp.Sales_Rep_Name=cf.Contract_Finance_Sales_Rep where p.Office='IVO' and Contract_Finance_Sales_Rep !='' and Contract_Finance_Deal_Drawer='Deal' and cf.Contract_Finance_Deal_Reg_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4)) GROUP BY Contract_Finance_Sales_Rep,sp.Venue order by volume desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "<li class='media event'> <div class='media-body'><a class='title' href='#salesRepIVO' id='salesclickIVO' data-toggle='modal'>" + name + "</a><p><strong>Office: IVO</strong></p></div></li>";
            }
            sqlcon.Close();

        }

        return htmlstr;
    }


    public string getDailySignUpsHML()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
  	          DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 9 - DATEPART(WEEKDAY, CONVERT(date,'" + time.ToString(value) + "')), CONVERT(date, '" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='HML' and convert(date,td.Tour_Details_Tour_Date)='" + date + "'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";
                }
                reader1.Close();
                sqlcon1.Close();
            }
            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();

        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date, '" + time.ToString(value) + "')), CONVERT(date, '" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='HML' and convert(date,td.Tour_Details_Tour_Date)='" + date + "'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";


                }
                reader1.Close();
                sqlcon1.Close();
            }

            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();

        }
           
        return htmlstr;



    }


    public string getDailyDealsHML()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
  	    DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 9 - DATEPART(WEEKDAY, CONVERT(date,'" + time.ToString(value) + "')), CONVERT(date, '" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from ContractDetails_Indian where DealRegistered_Date='" + date + "' and DealStatus='Registered'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";


                }
                reader1.Close();
                sqlcon1.Close();
            }

            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();
        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date,'" + time.ToString(value) + "')), CONVERT(date, '" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from ContractDetails_Indian where DealRegistered_Date='" + date + "' and DealStatus='Registered'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";


                }
                reader1.Close();
                sqlcon1.Close();
            }

            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();

        }
           
        return htmlstr;



    }
    
    [WebMethod]
    public static string getAdminRights()
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string JSON = "{\n \"names\":[";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select name,PageName from user_group_access  where Username='"+user+ "' and PageType='Admin'";
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



    public string getDailySignUpsIVO()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
	        DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 9 - DATEPART(WEEKDAY, CONVERT(date,'" + time.ToString(value) + "')), CONVERT(date,'" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='IVO' and convert(date,td.Tour_Details_Tour_Date)='" + date + "'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";


                }
                reader1.Close();
                sqlcon1.Close();
            }

            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();

        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date,'" + time.ToString(value) + "')), CONVERT(date,'" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile p join Tour_Details td on p.Profile_ID=td.Profile_ID where Office='IVO' and convert(date,td.Tour_Details_Tour_Date)='" + date + "'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";


                }
                reader1.Close();
                sqlcon1.Close();
            }

            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();

        }

        return htmlstr;



    }


    public string getDailyDealsIVO()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
	          DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 9 - DATEPART(WEEKDAY, CONVERT(date, '" + time.ToString(value) + "')), CONVERT(date,'" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Contract_Finance where Contract_Finance_Deal_Reg_Date='"+date+"' and Contract_Finance_Deal_Drawer='Deal'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";


                }
                reader1.Close();
                sqlcon1.Close();
            }

            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();
        }
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT -2 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 4)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date,'" + time.ToString(value) + "')), CONVERT(date,'" + time.ToString(value) + "'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Contract_Finance where Contract_Finance_Deal_Reg_Date='" + date + "' and Contract_Finance_Deal_Drawer='Deal'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    int count = reader1.GetInt32(0);
                    htmlstr += count + ",";


                }
                reader1.Close();
                sqlcon1.Close();
            }

            reader.Close();
            sqlcon.Close();
            htmlstr.TrimEnd();

        }

        return htmlstr;
    }


    public static int GetWkNumber()
    {
        DateTime time = DateTime.Now;
        int returnNumber = 0;
        try
        {
            CultureInfo ciGetNumber = CultureInfo.CurrentCulture;
            // returnNumber = ciGetNumber.Calendar.GetWeekOfYear(dtDate, CalendarWeekRule.FirstDay, DayOfWeek.Friday);
            returnNumber = ciGetNumber.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFullWeek, DayOfWeek.Saturday);
        }
        catch (System.FormatException fe)
        {
            // MessageBox.Show("Exception occurred in " + fe);

        }
        return returnNumber;

    }




    [WebMethod]
    public static string getTopSalesDetails()
    {

        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string JSON = "{\n \"names\":[";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select top(1) count(cd.DealStatus),dbo.fnConvert_TitleCase(upper(cd.Sales_Rep)) as Sales_Rep,sum(cast(Total_Price_Including_Tax as int)) as volume,sp.Venue  from ContractDetails_Indian cd join Profile p on cd.ProfileID=p.Profile_ID join Contract_PA_Indian cpa on cd.ContractDetails_ID=cpa.ContractDetails_ID join Sales_Rep sp on sp.Sales_Rep_Name=cd.Sales_Rep where p.Office='HML'  and cd.DealStatus='REGISTERED' and cd.DealRegistered_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')  group by cd.Sales_Rep,sp.Venue order by volume desc;";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    int count = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int volume = reader.GetInt32(2);
                    string venue = reader.GetString(3);
                    JSON += "[\"" + count + "\" , \"" + name + "\", \"" + volume + "\", \"" + venue + "\"],";


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
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string JSON = "{\n \"names\":[";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select top(1) count(cd.DealStatus),dbo.fnConvert_TitleCase(upper(cd.Sales_Rep)) as Sales_Rep,sum(cast(Total_Price_Including_Tax as int)) as volume,sp.Venue  from ContractDetails_Indian cd join Profile p on cd.ProfileID=p.Profile_ID join Contract_PA_Indian cpa on cd.ContractDetails_ID=cpa.ContractDetails_ID join Sales_Rep sp on sp.Sales_Rep_Name=cd.Sales_Rep where p.Office='HML'  and cd.DealStatus='REGISTERED' and cd.DealRegistered_Date between  DATEADD(wk, DATEDIFF(wk, 0, '" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))  group by cd.Sales_Rep,sp.Venue order by volume desc";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    int count = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int volume = reader.GetInt32(2);
                    string venue = reader.GetString(3);
                    JSON += "[\"" + count + "\" , \"" + name + "\", \"" + volume + "\", \"" + venue + "\"],";


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


    [WebMethod]
    public static string getTopSalesDetailsIVO()
    {
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string JSON = "{\n \"names\":[";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select top(1) count(cf.Contract_Finance_Deal_Drawer),dbo.fnConvert_TitleCase(upper(cf.Contract_Finance_Sales_Rep)) as Contract_Finance_Sales_Rep,sum(cf.Contract_Finance_Purchase_Price+ps.PS_Country_Tax) volume,sp.Venue from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID join Purchase_Service ps on cf.Contract_Finance_ID=ps.Contract_Finance_ID join Sales_Rep sp on sp.Sales_Rep_Name=cf.Contract_Finance_Sales_Rep where p.Office='IVO' and Contract_Finance_Sales_Rep !='' and Contract_Finance_Deal_Drawer='Deal' and cf.Contract_Finance_Deal_Reg_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')  GROUP BY Contract_Finance_Sales_Rep,sp.Venue order by volume desc;";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    int count = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int volume = reader.GetInt32(2);
                    string venue = reader.GetString(3);
                    JSON += "[\"" + count + "\" , \"" + name + "\", \"" + volume + "\", \"" + venue + "\"],";


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
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string JSON = "{\n \"names\":[";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);

            string query = "select top(1) count(cf.Contract_Finance_Deal_Drawer),dbo.fnConvert_TitleCase(upper(cf.Contract_Finance_Sales_Rep)) as Contract_Finance_Sales_Rep,sum(cf.Contract_Finance_Purchase_Price+ps.PS_Country_Tax) volume,sp.Venue from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID join Purchase_Service ps on cf.Contract_Finance_ID=ps.Contract_Finance_ID join Sales_Rep sp on sp.Sales_Rep_Name=cf.Contract_Finance_Sales_Rep where p.Office='IVO' and Contract_Finance_Sales_Rep !='' and Contract_Finance_Deal_Drawer='Deal' and cf.Contract_Finance_Deal_Reg_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4)) GROUP BY Contract_Finance_Sales_Rep,sp.Venue order by volume desc;";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    int count = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int volume = reader.GetInt32(2);
                    string venue = reader.GetString(3);
                    JSON += "[\"" + count + "\" , \"" + name + "\", \"" + volume + "\", \"" + venue + "\"],";


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



    [WebMethod]
    public static string getTopProfileInfo(string profileID)
    {
        string format = System.DateTime.Now.ToString("dddd");
        if (format == "Saturday")
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string JSON = "{\n \"names\":[";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select * from(select top(2) total,name,Office,ContractType,'INR' as currency,Profile_ID,ContractNo from (select cast(cpa.Total_Price_Including_Tax as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cd.ContractType,p.Profile_ID,cd.ContractNo  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_PA_Indian cpa on cpa.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "') and p.Profile_ID='" + profileID + "' union all select cast(Total_Price_Including_Tax as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name , p.Office,cd.ContractType,p.Profile_ID,cd.ContractNo from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_Fractional_PA_Indian cfp on cfp.ContractDetails_ID=cd.ContractDetails_ID where  p.Profile_ID='" + profileID + "' and cd.DealRegistered_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')) as pass  order by cast(total as int) desc union all select top(2) total,name,Office,ContractType,Contract_Finance_Currency as currency,Profile_ID,Contract_Finance_Cont_Numb from(select cf.Contract_Finance_Purchase_Price+ps.PS_Country_Tax as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cf.Contract_Finance_Cont_Type as ContractType,cf.Contract_Finance_Currency,p.Profile_ID,cf.Contract_Finance_Cont_Numb from Contract_Finance cf join profile p on p.Profile_ID=cf.Profile_ID  join Purchase_Service ps on cf.Contract_Finance_ID=ps.Contract_Finance_ID join Profile_Primary pp on pp.Profile_ID=cf.Profile_ID where  p.Profile_ID='" + profileID + "' and cf.Contract_Finance_Deal_Reg_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')) pass1 ) as pass3 order by total  desc";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    int amount = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string office = reader.GetString(2);
                    string type = reader.GetString(3);
                    string currency = reader.GetString(4);
                    string profileID1 = reader.GetString(5);
                    string contractNo = reader.GetString(6);
                    JSON += "[\"" + amount + "\" , \"" + name + "\", \"" + office + "\", \"" + type + "\", \"" + currency + "\", \"" + profileID1 + "\", \"" + contractNo + "\"],";
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
        else
        {
            DateTime time = DateTime.Now;
            string value = "yyyy-MM-dd HH:mm:ss:sss";
            string JSON = "{\n \"names\":[";
            string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select * from(select top(2) total,name,Office,ContractType,'INR' as currency,Profile_ID,ContractNo from (select cast(cpa.Total_Price_Including_Tax as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cd.ContractType,p.Profile_ID,cd.ContractNo  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_PA_Indian cpa on cpa.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4)) and p.Profile_ID='" + profileID + "' union all select cast(Total_Price_Including_Tax as int) as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name , p.Office,cd.ContractType,p.Profile_ID,cd.ContractNo from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_Fractional_PA_Indian cfp on cfp.ContractDetails_ID=cd.ContractDetails_ID where  p.Profile_ID='" + profileID + "' and cd.DealRegistered_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))) as pass  order by cast(total as int) desc union all select top(2) total,name,Office,ContractType,Contract_Finance_Currency as currency,Profile_ID,Contract_Finance_Cont_Numb from(select cf.Contract_Finance_Purchase_Price+ps.PS_Country_Tax as total,dbo.fnConvert_TitleCase(upper(pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname)) as name,p.Office,cf.Contract_Finance_Cont_Type as ContractType,cf.Contract_Finance_Currency,p.Profile_ID,cf.Contract_Finance_Cont_Numb from Contract_Finance cf join profile p on p.Profile_ID=cf.Profile_ID join Purchase_Service ps on cf.Contract_Finance_ID=ps.Contract_Finance_ID join Profile_Primary pp on pp.Profile_ID=cf.Profile_ID where  p.Profile_ID='" + profileID + "' and cf.Contract_Finance_Deal_Reg_Date between DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,'" + time.ToString(value) + "'), +4))) pass1 ) as pass3 order by total  desc";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    int amount = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string office = reader.GetString(2);
                    string type = reader.GetString(3);
                    string currency = reader.GetString(4);
                    string profileID1 = reader.GetString(5);
                    string contractNo = reader.GetString(6);
                    JSON += "[\"" + amount + "\" , \"" + name + "\", \"" + office + "\", \"" + type + "\", \"" + currency + "\", \"" + profileID1 + "\", \"" + contractNo + "\"],";
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