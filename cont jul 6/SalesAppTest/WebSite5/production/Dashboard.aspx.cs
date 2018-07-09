using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Dashboard : System.Web.UI.Page
{
    static string pname;
    static string user;
    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct parentnode from user_group_access ug where username ='"+user+"'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            if (name=="")
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


              

                 htmlstr += "<li><a href="+ pageurl +"?name="+ AccessName + ">"+ pagename + " </a></li>";
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

         user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }
       // string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
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

            string query = "select count(*) from Profile where Office='HML' and convert(date,Profile_Date_Of_Insertion) between  convert(date,'"+time.ToString(value)+ "') and convert(date,'" + time.ToString(value) + "')";
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
            string query = "select count(*) from Profile where Office='HML' and convert(date,Profile_Date_Of_Insertion) between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))";
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
            string query = "select count(*) from Profile where Office='IVO' and convert(date,Profile_Date_Of_Insertion) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
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
            string query = "select count(*) from Profile where Office='IVO' and convert(date,Profile_Date_Of_Insertion) between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))";
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

            string query = "select count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'REGISTERED' and p.Office = 'HML' and convert(date, Profile_Date_Of_Insertion) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
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
            string query = "select count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'REGISTERED' and p.Office = 'HML' and convert(date, Profile_Date_Of_Insertion) between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))";
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

            string query = "select count(*) from Contract_Finance cf join Profile p on cf.Profile_ID = p.Profile_ID where cf.Contract_Finance_Deal_Drawer = 'Deal' and p.Office = 'IVO' and convert(date, Profile_Date_Of_Insertion) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
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
            string query = "select count(*) from Contract_Finance cf join Profile p on cf.Profile_ID = p.Profile_ID where cf.Contract_Finance_Deal_Drawer = 'Deal' and p.Office = 'IVO' and convert(date, Profile_Date_Of_Insertion) between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))";
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

            string query = "select top(1) count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'CANCELLED & REFUNDED' and p.Office = 'HML' and convert(date, Profile_Date_Of_Insertion) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
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
            string query = "select top(1) count(*) from ContractDetails_Indian cd join Profile p on cd.ProfileID = p.Profile_ID where DealStatus = 'CANCELLED & REFUNDED' and p.Office = 'HML' and convert(date, Profile_Date_Of_Insertion) between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))";
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
            string query = "select top(1) count(*) from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where cf.Contract_Finance_Deal_Drawer='Cancel' and p.Office='IVO' and convert(date,Profile_Date_Of_Insertion) between  convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')";
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
            string query = "select top(1) count(*) from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where cf.Contract_Finance_Deal_Drawer='Cancel' and p.Office='IVO' and convert(date,Profile_Date_Of_Insertion) between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))";
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
   	string query = "select * from(select top(2) total,name,Office,ContractType,'INR' as currency from(select cast(cpa.Total_Purchase_Price as int) as total,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as name,p.Office,cd.ContractType  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_PA_Indian cpa on cpa.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between '"+ time.ToString(value) + "' and '"+ time.ToString(value) + "' union all select cast(Total_Purchase_Price as int) as total,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as name,p.Office,cd.ContractType  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_Fractional_PA_Indian cfp on cfp.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between '"+ time.ToString(value) + "' and '"+ time.ToString(value) + "') as pass order by cast(total as int) desc union all select top(2) total,name,Office,ContractType,Contract_Finance_Currency as currency from(select cf.Contract_Finance_Purchase_Price as total,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as name,p.Office,cf.Contract_Finance_Cont_Type as ContractType,cf.Contract_Finance_Currency from Contract_Finance cf join profile p on p.Profile_ID=cf.Profile_ID join Profile_Primary pp on pp.Profile_ID=cf.Profile_ID where cf.Contract_Finance_Deal_Reg_Date between '"+ time.ToString(value) + "' and '"+ time.ToString(value) + "') pass1 ) as pass3 order by total  desc";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int amount = reader.GetInt32(0);
            string name = reader.GetString(1);
            string office = reader.GetString(2);
            string type = reader.GetString(3);
            string currency = reader.GetString(4);
            htmlstr += "<li class='media event'> <a class='pull-left border-aero profile_thumb'><i class='fa fa-user aero'></i></a><div class='media-body'><a class='title' href='#'>" + name + "</a> <p><strong>"+currency+": " + amount + " </strong></p><p><strong>Office:"+office+" </strong></p><p><strong>Contract Type: " + type+"</strong></p> </div></li>";
        }
        
        sqlcon.Close();
        return htmlstr;
}else{
   string query = "select * from(select top(2) total,name,Office,ContractType,'INR' as currency from(select cast(cpa.Total_Purchase_Price as int) as total,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as name,p.Office,cd.ContractType  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_PA_Indian cpa on cpa.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4)) union all select cast(Total_Purchase_Price as int) as total,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as name,p.Office,cd.ContractType  from ContractDetails_Indian cd join profile p on p.Profile_ID=cd.ProfileID join Profile_Primary pp on pp.Profile_ID=cd.ProfileID join Contract_Fractional_PA_Indian cfp on cfp.ContractDetails_ID=cd.ContractDetails_ID where cd.DealRegistered_Date between DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))) as pass order by cast(total as int) desc union all select top(2) total,name,Office,ContractType,Contract_Finance_Currency as currency from(select cf.Contract_Finance_Purchase_Price as total,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as name,p.Office,cf.Contract_Finance_Cont_Type as ContractType,cf.Contract_Finance_Currency from Contract_Finance cf join profile p on p.Profile_ID=cf.Profile_ID join Profile_Primary pp on pp.Profile_ID=cf.Profile_ID where cf.Contract_Finance_Deal_Reg_Date between DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))) pass1 ) as pass3 order by total  desc";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int amount = reader.GetInt32(0);
            string name = reader.GetString(1);
            string office = reader.GetString(2);
            string type = reader.GetString(3);
            string currency = reader.GetString(4);
            htmlstr += "<li class='media event'> <a class='pull-left border-aero profile_thumb'><i class='fa fa-user aero'></i></a><div class='media-body'><a class='title' href='#'>" + name + "</a> <p><strong>"+currency+": " + amount + " </strong></p><p><strong>Office:"+office+" </strong></p><p><strong>Contract Type: " + type+"</strong></p> </div></li>";
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

            string query = "select top(1) count(cd.DealStatus),cd.Sales_Rep from ContractDetails_Indian cd join Profile p on cd.ProfileID=p.Profile_ID where p.Office='HML'  and cd.DealStatus='REGISTERED' and cd.DealRegistered_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')  group by cd.Sales_Rep order by count(cd.DealStatus) desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "  <div class='count'>" + count + "<h6 style='margin-top:auto'>" + name + "</h6></div>";
            }



            sqlcon.Close();

        }
        else
        {

            string query = "select top(1) count(cd.DealStatus),cd.Sales_Rep from ContractDetails_Indian cd join Profile p on cd.ProfileID=p.Profile_ID where p.Office='HML'  and cd.DealStatus='REGISTERED' and cd.DealRegistered_Date between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4))  group by cd.Sales_Rep order by count(cd.DealStatus) desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "  <div class='count'>" + count + "<h6 style='margin-top:auto'>" + name + "</h6></div>";
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
            string query = "select top(1) count(cf.Contract_Finance_Deal_Drawer),cf.Contract_Finance_Sales_Rep from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where Office='IVO' and Contract_Finance_Sales_Rep !='' and Contract_Finance_Deal_Drawer='Deal' and cf.Contract_Finance_Deal_Reg_Date between convert(date,'" + time.ToString(value) + "') and convert(date,'" + time.ToString(value) + "')  GROUP BY Contract_Finance_Sales_Rep order by count(Contract_Finance_Deal_Drawer) desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "  <div class='count'>" + count + "<h6 style='margin-top:auto'>" + name + "</h6></div>";
            }
            sqlcon.Close();

        }
        else
        {

            string query = "select top(1) count(cf.Contract_Finance_Deal_Drawer),cf.Contract_Finance_Sales_Rep from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where Office='IVO' and Contract_Finance_Sales_Rep !='' and Contract_Finance_Deal_Drawer='Deal' and cf.Contract_Finance_Deal_Reg_Date between  DATEADD(wk, DATEDIFF(wk, 0, getdate()), -2) and DATEADD(wk, 0, DATEADD(wk, DATEDIFF(wk, 0,getdate()), +4)) GROUP BY Contract_Finance_Sales_Rep order by count(Contract_Finance_Deal_Drawer) desc;";
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                string name = reader.GetString(1);
                htmlstr += "  <div class='count'>" + count + "<h6 style='margin-top:auto'>" + name + "</h6></div>";
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
        if (format == "Sunday")
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS (SELECT -7 day UNION ALL  SELECT day +1 FROM weekdays WHERE day < -1)SELECT DATEADD(DAY, day, DATEADD(DAY, 2-DATEPART(WEEKDAY, CONVERT (date, '2018-04-16 00:00:00.000')), CONVERT (date,  '2018-04-16 00:00:00.000'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile where Office='HML' and convert(date,Profile_Date_Of_Insertion)='" + date + "'";
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
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT 0 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 6)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date, '2018-04-16 00:00:00.000')), CONVERT(date, '2018-04-16 00:00:00.000'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile where Office='HML' and convert(date,Profile_Date_Of_Insertion)='" + date + "'";
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
        if (format == "Sunday")
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS (SELECT -7 day UNION ALL  SELECT day +1 FROM weekdays WHERE day < -1)SELECT DATEADD(DAY, day, DATEADD(DAY, 2-DATEPART(WEEKDAY, CONVERT (date, '2018-04-16 00:00:00.000')), CONVERT (date,  '2018-04-16 00:00:00.000'))) date FROM weekdays";
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
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT 0 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 6)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date, '2018-04-16 00:00:00.000')), CONVERT(date, '2018-04-16 00:00:00.000'))) date FROM weekdays";
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
        if (format == "Sunday")
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS (SELECT -7 day UNION ALL  SELECT day +1 FROM weekdays WHERE day < -1)SELECT DATEADD(DAY, day, DATEADD(DAY, 2-DATEPART(WEEKDAY, CONVERT (date, '2018-04-16 00:00:00.000')), CONVERT (date,  '2018-04-16 00:00:00.000'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile where Office='IVO' and convert(date,Profile_Date_Of_Insertion)='" + date + "'";
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
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT 0 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 6)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date, '2018-04-16 00:00:00.000')), CONVERT(date, '2018-04-16 00:00:00.000'))) date FROM weekdays";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select count(*) from Profile where Office='IVO' and convert(date,Profile_Date_Of_Insertion)='" + date + "'";
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
        if (format == "Sunday")
        {
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS (SELECT -7 day UNION ALL  SELECT day +1 FROM weekdays WHERE day < -1)SELECT DATEADD(DAY, day, DATEADD(DAY, 2-DATEPART(WEEKDAY, CONVERT (date, '2018-04-16 00:00:00.000')), CONVERT (date,  '2018-04-16 00:00:00.000'))) date FROM weekdays";
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
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "WITH weekdays AS(SELECT 0 day UNION ALL  SELECT day + 1 FROM weekdays WHERE day < 6)SELECT DATEADD(DAY, day, DATEADD(DAY, 2 - DATEPART(WEEKDAY, CONVERT(date, '2018-04-16 00:00:00.000')), CONVERT(date, '2018-04-16 00:00:00.000'))) date FROM weekdays";
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

}