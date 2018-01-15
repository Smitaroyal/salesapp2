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

/// <summary>
/// Summary description for Queries
/// </summary>
public class Queries
{
    
    public static SqlConnection GetDBConnection()
    {
        // Get the connection string from the configuration file
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        // Create a new connection object
        SqlConnection connection = new SqlConnection(connectionString);

        // Open the connection, and return it
        connection.Open();
        return connection;
    }
    public static DataSet LoadVenueCountry()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Country_Name  from VenueCountry where Venue_Country_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadVenue()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from Venue where Venue_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadVenuebasedOnCountryID(string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from venue where Venue_Country_ID =@venuecountry", cs1);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadSubVenue(string venue1)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue_ID in (select Venue_ID from venue where Venue_Name=@venue)", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue1;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }



    public static DataSet LoadVenuebasedOnCountryName(string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select Venue_Name  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID  where vc.Venue_Country_Name =@venuecountry", cs1);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static String GetVenueCountryCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select Venue_Country_ID  from VenueCountry where Venue_Country_Name =@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
           
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    /*  public static DataSet LoadVenueGroup()
      {
          SqlDataAdapter da;
          DataSet ds = new DataSet();
          using (SqlConnection cs1 = Queries.GetDBConnection())
          {
              SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group where Venue_Group_Status='Active' order by 1", cs1);
              da = new SqlDataAdapter(SqlCmd);
              ds = new DataSet();
              da.Fill(ds);
          }
          return (ds);

      }*/
    public static String GetVenueCode(string name,string country)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_ID from venue where Venue_Name=@name and Venue_Country_ID =@country", cs1);
 
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            scd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static String GetVenueCode1(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_ID from venue where Venue_Name=@name ", cs1);

            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
         //   scd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static DataSet LoadVenueGroup(string vcode)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group where Venue_Group_Status='Active' order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select  Venue_Group_Name  from Venue_Group where Venue_ID =@vcode and Venue_Group_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@vcode", SqlDbType.VarChar).Value = vcode;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static String GetVenueGroupCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_Group_ID from Venue_Group where Venue_Group_Name=@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;  
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static DataSet LoadMarketingProgram(string vgcode)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand SqlCmd = new SqlCommand("select Marketing_Program_Name  from Marketing_Program where  Marketing_Program_Status='Active' order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Marketing_Program_Name  from Marketing_Program where  Venue_Group_ID=@vgcode", cs1);
            SqlCmd.Parameters.Add("@vgcode", SqlDbType.VarChar).Value = vgcode;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadMarketingProgramOnVenueNVGroup(string venuename,string vgname)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand SqlCmd = new SqlCommand("   select m.Marketing_Program_Name  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name =@venuename and vg.Venue_Group_Name =@vgname and m.Marketing_Program_Status = 'Active'", cs1);
            SqlCmd.Parameters.Add("@venuename", SqlDbType.VarChar).Value = venuename;
            SqlCmd.Parameters.Add("@vgname", SqlDbType.VarChar).Value = vgname;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


  
    public static DataSet LoadAgents()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Agent_Name  from Agent where Agent_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadAgents(string mktg)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select a.Agent_Name  from Agent a join Agent_marketing sm on a.Agent_ID = sm.Agent_ID join Marketing_Program mp on mp.Marketing_Program_ID = sm.marketing_program_id where a.Agent_Status = 'Active' and mp.Marketing_Program_Name =@mktg order by 1", cs1);
            SqlCmd.Parameters.Add("@mktg", SqlDbType.VarChar).Value = mktg;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

   /* public static DataSet LoadAgentsOnVenue(string venue,string venuegroup)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select a.Agent_Name from Agent_GroupVenue ag join agent a on a.Agent_ID = ag.Agent_id where   a.Agent_Status = 'Active'and ag.venue =@venue and ag.Venue_Group_ID =@venuegroup", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@venuegroup", SqlDbType.VarChar).Value = venuegroup;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }*/
    public static DataSet LoadAgentsOnVenue(string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select a.Agent_Name from Agent_GroupVenue ag join agent a on a.Agent_ID = ag.Agent_id where   a.Agent_Status = 'Active'and ag.venue =@venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
           
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    /*  public static DataSet LoadManagersOnVenue(string venue, string venuegroup)
      {
          SqlDataAdapter da;
          DataSet ds = new DataSet();
          using (SqlConnection cs1 = Queries.GetDBConnection())
          {
              SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue and 	VenueGroup=@venuegroup", cs1);
              SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
              SqlCmd.Parameters.Add("@venuegroup", SqlDbType.VarChar).Value = venuegroup;
              da = new SqlDataAdapter(SqlCmd);
              ds = new DataSet();
              da.Fill(ds);
          }
          return (ds);

      }*/
    public static DataSet LoadManagersOnVenue(string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    /* public static DataSet LoadTOOPCOnVenue(string venue, string venuegroup)
     {
         SqlDataAdapter da;
         DataSet ds = new DataSet();
         using (SqlConnection cs1 = Queries.GetDBConnection())
         {
             SqlCommand SqlCmd = new SqlCommand("  select distinct to_name from OPC_TOs where TO_Status='Active' and  Venue=@venue and 	VenueGroup=@venuegroup", cs1);
             SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
             SqlCmd.Parameters.Add("@venuegroup", SqlDbType.VarChar).Value = venuegroup;
             da = new SqlDataAdapter(SqlCmd);
             ds = new DataSet();
             da.Fill(ds);
         }
         return (ds);

     }*/
    public static DataSet LoadTOOPCOnVenue(string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct to_name from OPC_TOs where TO_Status='Active' and  Venue=@venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
  
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadAgentCode()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Agent_Code_Name  from Agent_Code where Agent_Code_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadMemberType()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Member_Type_name   from Member_Type where Member_Type_status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCode()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryName()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct country_name   from country order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadNationality()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct  nationality_name from nationality order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadGuestStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Guest_Status_name  from Guest_Status where Guest_Status_Status ='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSalesRep()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select sales_rep_name from Sales_Rep  where sales_rep_status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadGiftOption()
    {
        SqlDataAdapter da;
        DataSet dt = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Gift_Option_Name + ' -' + ' ' + item as item from Gift_Option where Gift_Option_Status = 'Active'", cs1);
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataSet();
            da.Fill(dt);
        }
        return (dt);

    }
   

    public static DataSet LoadSalesReponVenue(string venue,string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select sales_rep_name from Sales_Rep  where sales_rep_status = 'Active'  and venue =@venue and Venue_country_ID =@venuecountry", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }



    //public static String  GetProfileID(string off)
    //{ 
    //    string ProfileID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    int chek = 0;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            /* SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile where Profile_Venue_Country=@off", cs1);
    //             //  SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile", cs1);
    //             scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //             SqlDataReader dr = scd.ExecuteReader();
    //             if (dr.Read() == true)
    //             {
    //                 string len = string.Format("{0}", dr[0]);
    //                 if (len.Length != 0)
    //                 {
    //                     id = Convert.ToInt32(len);
    //                     id = id + 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //                 else
    //                 {
    //                     id = 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //             }*/

    //            //check if record exists with hmc
    //            //SqlCommand scd1 = new SqlCommand("select distinct profile_id from profile where profile_id like 'hmc%'", cs1);
    //            //SqlDataReader dr = scd1.ExecuteReader();
    //            //if(dr.Read()==true)
    //            //{
    //            //    chek = 1;
    //                //get last code of profile n increment by 1
    //                SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                string val = (string)scd.ExecuteScalar();
    //                id = Convert.ToInt32(val) + 1;
    //                ProfileID = startvalue + id;
    //                 id = id + 1;
    //                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue", cs1);
    //                     sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                   int rows = sqlcmd.ExecuteNonQuery();
    //            //}
    //            //else
    //            //{
    //            //    chek = 0;
    //            //    //else insert int
    //            //    SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //            //    scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //            //    string val = (string)scd.ExecuteScalar();
    //            //    id = Convert.ToInt32(val) + 1;
    //            //    ProfileID = startvalue + id;
    //            //}
    //        }
    //        else 
    //        {
    //            /* string sel = off;
    //             startvalue = "IVO";
    //             SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile where Profile_Venue_Country=@sel", cs1);
    //             //  SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile", cs1);
    //             scd.Parameters.Add("@sel", SqlDbType.VarChar).Value = sel;
    //             SqlDataReader dr = scd.ExecuteReader();
    //             if (dr.Read() == true)
    //             {
    //                 string len = string.Format("{0}", dr[0]);
    //                 if (len.Length != 0)
    //                 {
    //                     id = Convert.ToInt32(len);
    //                     id = id + 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //                 else
    //                 {
    //                     id = 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //             }*/

    //            SqlCommand scd1 = new SqlCommand("select distinct profile_id from profile where profile_id like 'IVO%'", cs1);
    //            SqlDataReader dr = scd1.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                chek = 1;
    //                //get last code of profile n increment by 1
    //                SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                string val = (string)scd.ExecuteScalar();
    //                id = Convert.ToInt32(val) + 1;
    //                ProfileID = startvalue + id;
    //            }
    //            else
    //            {
    //                chek = 0;
    //                //else insert int
    //                SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                string val = (string)scd.ExecuteScalar();
    //                id = Convert.ToInt32(val) + 1;
    //                ProfileID = startvalue + id;
    //            }
    //        }

    //    }

    //    return  ProfileID;
    //}
    public static int InsertIDGeneration(string venue,int year)
    {
        int rowsAffected = 0;

        int Profile_Start_Val = 0;
        int Primary_Start_Val = 0;
        int Secondary_Start_Val = 0;
        int SubProfile1_Start_Val = 0;
        int SubProfile2_Start_Val = 0;
        int Address_Start_Val = 0;
        int Phone_Start_Val = 0;
        int Email_Start_Val = 0;
        int Profile_Stay_Start_Val = 0;
        int Tour_Details_Start_Val = 0;
        int Gift_Start_Val = 0;
        int SubProfile3_Start_Val = 0;
        int SubProfile4_Start_Val = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into ID_Generation values(@VenueCode,	@Year,	@Profile_Start_Val,	@Primary_Start_Val,	@Secondary_Start_Val,	@SubProfile1_Start_Val,	@SubProfile2_Start_Val,	@Address_Start_Val,	@Phone_Start_Val,	@Email_Start_Val,	@Profile_Stay_Start_Val,	@Tour_Details_Start_Val,@Gift_Start_Val,@SubProfile3_Start_Val,@SubProfile4_Start_Val)", cs1);
                da.InsertCommand.Parameters.Add("@VenueCode", SqlDbType.VarChar).Value = venue;
                da.InsertCommand.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                da.InsertCommand.Parameters.Add("@Profile_Start_Val", SqlDbType.VarChar).Value = Profile_Start_Val;
                da.InsertCommand.Parameters.Add("@Primary_Start_Val", SqlDbType.VarChar).Value = Primary_Start_Val;
                da.InsertCommand.Parameters.Add("@Secondary_Start_Val", SqlDbType.VarChar).Value = Secondary_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile1_Start_Val", SqlDbType.VarChar).Value = SubProfile1_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile2_Start_Val", SqlDbType.VarChar).Value = SubProfile2_Start_Val;
                da.InsertCommand.Parameters.Add("@Address_Start_Val", SqlDbType.VarChar).Value = Address_Start_Val;
                da.InsertCommand.Parameters.Add("@Phone_Start_Val", SqlDbType.VarChar).Value = Phone_Start_Val;
                da.InsertCommand.Parameters.Add("@Email_Start_Val", SqlDbType.VarChar).Value = Email_Start_Val;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Start_Val", SqlDbType.VarChar).Value = Profile_Stay_Start_Val;
                da.InsertCommand.Parameters.Add("@Tour_Details_Start_Val", SqlDbType.VarChar).Value = Tour_Details_Start_Val;
                da.InsertCommand.Parameters.Add("@Gift_Start_Val", SqlDbType.VarChar).Value = Gift_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile3_Start_Val", SqlDbType.VarChar).Value = SubProfile3_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile4_Start_Val", SqlDbType.VarChar).Value = SubProfile4_Start_Val;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

              //  MessageBox.Show("Error in ID Generation Query " + ex.Message);

                string msg = "Error in ID Generation Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static String GetProfileID(string startvalue )//(string off)
    {
        string ProfileID = null;
       // string startvalue = "";
        int id = 0;
        int chek = 0;
        int year =   DateTime.Now.Year;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            /*if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/
                
                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year ", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                { 

                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                   string val =(string)scd1.ExecuteScalar();
                    id =Convert.ToInt32(val)+ 1;
                    ProfileID = startvalue+year+ id;
                
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                 }
                else if(cnt==0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    ProfileID = startvalue + year + id;
                    
                   /* SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();*/

                }
               
          /*  }
            else
            {
                startvalue = "IVO";
                
                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    ProfileID = startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    ProfileID = startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }


                
            }*/

        }

        return ProfileID;
    }
    public static int UpdateProfileValue(string startvalue,int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Profile_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdatePrimaryValue(string startvalue,int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Primary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Primary_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Primary_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Primary_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateSecondaryValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Secondary_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Secondary_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateSubprofile1Value(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val SubProfile1_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val SubProfile1_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdateSubprofile2Value(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val SubProfile2_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val SubProfile2_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdateAddressValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Address_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Address_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdatePhoneValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Phone_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Phone_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateEmailValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val Profile_Stay_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val Profile_Stay_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateStayValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Tour_Details_Start_Val Profile_Stay_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Tour_Details_Start_Val Profile_Stay_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }
    public static int UpdateTourValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Tour_Details_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Tour_Details_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateGiftValue(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Gift_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Gift_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE ID_Generation Query Gift_Start_Val " + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Gift_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int InsertProfile(string Profile_ID, DateTime Profile_Date_Of_Insertion, string Profile_Created_By,string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple,string Office,string Comments,string Manager, string Photo_identity, string Card_Holder,string Reception,string SubVenue,string regTerms)//,string vpid)
    {
       
            int rowsAffected = 0;
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection cs1 = Queries.GetDBConnection())
            {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile values(@Profile_ID,	@Profile_Date_Of_Insertion,	@Profile_Created_By,	@Profile_Venue_Country,	@Profile_Venue,	@Profile_Group_Venue,	@Profile_Marketing_Program,	@Profile_Agent,	@Profile_Agent_Code,	@Profile_Member_Type1,	@Profile_Member_Number1,	@Profile_Member_Type2,	@Profile_Member_Number2,	@Profile_Employment_status,	@Profile_Marital_status,	@Profile_NOY_Living_as_couple,@Office,@Comments,@Manager,@Photo_identity,@Card_Holder,@Reception,@SubVenue,@regTerms)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Profile_Date_Of_Insertion", SqlDbType.DateTime).Value = Profile_Date_Of_Insertion;
                da.InsertCommand.Parameters.Add("@Profile_Created_By", SqlDbType.VarChar).Value = Profile_Created_By;
                da.InsertCommand.Parameters.Add("@Profile_Venue_Country", SqlDbType.VarChar).Value = Profile_Venue_Country;
                da.InsertCommand.Parameters.Add("@Profile_Venue", SqlDbType.VarChar).Value = Profile_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Group_Venue", SqlDbType.VarChar).Value = Profile_Group_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Marketing_Program", SqlDbType.VarChar).Value = Profile_Marketing_Program;
                da.InsertCommand.Parameters.Add("@Profile_Agent", SqlDbType.VarChar).Value = Profile_Agent;
                da.InsertCommand.Parameters.Add("@Profile_Agent_Code", SqlDbType.VarChar).Value = Profile_Agent_Code;
                da.InsertCommand.Parameters.Add("@Profile_Member_Type1", SqlDbType.VarChar).Value = Profile_Member_Type1;
                da.InsertCommand.Parameters.Add("@Profile_Member_Number1", SqlDbType.VarChar).Value = Profile_Member_Number1;
                da.InsertCommand.Parameters.Add("@Profile_Member_Type2", SqlDbType.VarChar).Value = Profile_Member_Type2;
                da.InsertCommand.Parameters.Add("@Profile_Member_Number2", SqlDbType.VarChar).Value = Profile_Member_Number2;
                da.InsertCommand.Parameters.Add("@Profile_Employment_status", SqlDbType.VarChar).Value = Profile_Employment_status;
                da.InsertCommand.Parameters.Add("@Profile_Marital_status", SqlDbType.VarChar).Value = Profile_Marital_status;
                da.InsertCommand.Parameters.Add("@Profile_NOY_Living_as_couple", SqlDbType.VarChar).Value = Profile_NOY_Living_as_couple;
                da.InsertCommand.Parameters.Add("@Office", SqlDbType.VarChar).Value = Office;
                da.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                da.InsertCommand.Parameters.Add("@Manager", SqlDbType.VarChar).Value = Manager;
                da.InsertCommand.Parameters.Add("@Photo_identity", SqlDbType.VarChar).Value = Photo_identity;
                da.InsertCommand.Parameters.Add("@Card_Holder", SqlDbType.VarChar).Value = Card_Holder;
                da.InsertCommand.Parameters.Add("@Reception", SqlDbType.VarChar).Value = Reception;
                da.InsertCommand.Parameters.Add("@SubVenue", SqlDbType.VarChar).Value = SubVenue;
                da.InsertCommand.Parameters.Add("@regTerms", SqlDbType.VarChar).Value = regTerms;
                //da.InsertCommand.Parameters.Add("@vpid", SqlDbType.VarChar).Value = vpid;
                //vpid
                rowsAffected = da.InsertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                
                //MessageBox.Show("Error in Insert Profile Query " + ex.Message);

                string msg = "Error in Insert Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
            return (rowsAffected);
        
    }
    //public static String GetPrimaryProfileID(string off)
    //{
    //    string PProfileID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    /*if (off == "INDIA")
    //    {
    //        startvalue = "HMC";
    //    }
    //    else //if (off == "BALI")
    //    {
    //        startvalue = "IVO";
    //    }*/
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        //  SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Primary_ID ,6,len(Profile_Primary_ID)))from Profile_Primary", cs1);
    //        //    SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp join profile p on p.Profile_ID = pp.Profile_ID where p.Profile_Venue_Country= @off and  pp.Profile_Primary_ID like 'P_HMC%'", cs1);
    //        if (off == "INDIA"||off=="India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp where  pp.Profile_Primary_ID like 'P_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else 
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp where  pp.Profile_Primary_ID like 'P_IVO%'", cs1);
    //           // scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //            }
    //        }


    //    }

    //    return PProfileID;
    //}
    public static String GetPrimaryProfileID(string startvalue )//(string off)
    {
        string PProfileID = null;
        //string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "P";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
          
          /*  if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Primary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PProfileID = initial+ startvalue + year + id;
                   
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Primary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PProfileID = initial + startvalue + year + id;
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
         

        }

        return PProfileID;
    }
    public static int InsertPrimaryProfile(string Profile_Primary_ID, string Profile_Primary_Title, string Profile_Primary_Fname, string Profile_Primary_Lname, string Profile_Primary_DOB, string Profile_Primary_Nationality, string Profile_Primary_Country, string Profile_ID, string Primary_Age, string Primary_Designation, string Primary_Language)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries .GetDBConnection())
        {
            try
            { 
            da.InsertCommand = new SqlCommand("insert into Profile_Primary values(@Profile_Primary_ID,	@Profile_Primary_Title,	@Profile_Primary_Fname,	@Profile_Primary_Lname,	@Profile_Primary_DOB,@Profile_Primary_Nationality,@Profile_Primary_Country,@Profile_ID,@Primary_Age,@Primary_Designation,@Primary_Language)", cs1);
            da.InsertCommand.Parameters.Add("@Profile_Primary_ID", SqlDbType.VarChar).Value = Profile_Primary_ID;
            da.InsertCommand.Parameters.Add("@Profile_Primary_Title", SqlDbType.VarChar).Value = Profile_Primary_Title;
            da.InsertCommand.Parameters.Add("@Profile_Primary_Fname", SqlDbType.VarChar).Value = Profile_Primary_Fname;
            da.InsertCommand.Parameters.Add("@Profile_Primary_Lname", SqlDbType.VarChar).Value = Profile_Primary_Lname;
            da.InsertCommand.Parameters.Add("@Profile_Primary_DOB", SqlDbType.VarChar).Value = Profile_Primary_DOB;
            da.InsertCommand.Parameters.Add("@Profile_Primary_Nationality", SqlDbType.VarChar).Value = Profile_Primary_Nationality;
            da.InsertCommand.Parameters.Add("@Profile_Primary_Country", SqlDbType.VarChar).Value = Profile_Primary_Country;
            da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Primary_Age", SqlDbType.VarChar).Value = Primary_Age;
                da.InsertCommand.Parameters.Add("@Primary_Designation", SqlDbType.VarChar).Value = Primary_Designation;
                da.InsertCommand.Parameters.Add("@Primary_Language", SqlDbType.VarChar).Value = Primary_Language;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Primary Profile Query " + ex.Message);

                string msg = "Error in Insert Primary Profile Query" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    //public static String GetSecondaryProfileID(string off)
    //{
    //    string SProfileID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Secondary_ID ,6,len(Profile_Secondary_ID)))from Profile_Secondary  where  Profile_Secondary_ID like 'S_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else

    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Secondary_ID ,6,len(Profile_Secondary_ID)))from Profile_Secondary  where  Profile_Secondary_ID like 'S_IVO%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //            }

    //        }
    //    }

    //    return SProfileID;
    //}

    public static String GetSecondaryProfileID(string startvalue )//(string off)
    {
        string SProfileID = null;
        //string startvalue = "";
        int id = 0;
        
        int year = DateTime.Now.Year;
        string initial = "S";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

          /*  if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SProfileID = initial + startvalue + year + id;
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SProfileID = initial + startvalue + year + id;
                     
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
        

        }
       
        return SProfileID;
    }
    public static int InsertSecondaryProfile(string Profile_Secondary_ID, string Profile_Secondary_Title, string Profile_Secondary_Fname, string Profile_Secondary_Lname, string Profile_Secondary_DOB, string Profile_Secondary_Nationality, string Profile_Secondary_Country, string Profile_ID, string Secondary_Age, string Secondary_Designation, string Secondary_Language)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Profile_Secondary values(@Profile_Secondary_ID, 	@Profile_Secondary_Title,@Profile_Secondary_Fname,@Profile_Secondary_Lname,@Profile_Secondary_DOB,@Profile_Secondary_Nationality,@Profile_Secondary_Country,@Profile_ID,@Secondary_Age,@Secondary_Designation,@Secondary_Language)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Secondary_ID ", SqlDbType.VarChar).Value = Profile_Secondary_ID;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Title ", SqlDbType.VarChar).Value = Profile_Secondary_Title;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Fname ", SqlDbType.VarChar).Value = Profile_Secondary_Fname;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Lname ", SqlDbType.VarChar).Value = Profile_Secondary_Lname;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_DOB ", SqlDbType.VarChar).Value = Profile_Secondary_DOB;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Nationality ", SqlDbType.VarChar).Value = Profile_Secondary_Nationality;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Country ", SqlDbType.VarChar).Value = Profile_Secondary_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Secondary_Age", SqlDbType.VarChar).Value = Secondary_Age;
                da.InsertCommand.Parameters.Add("@Secondary_Designation", SqlDbType.VarChar).Value = Secondary_Designation;
                da.InsertCommand.Parameters.Add("@Secondary_Language", SqlDbType.VarChar).Value = Secondary_Language;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Secondary Profile Query " + ex.Message);

                string msg = "Error in Insert Secondary Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    //public static String GetAddressProfileID(string off)
    //{
    //    string AProfileID = null;
    //    string startvalue = "";
    //    int id = 0;

    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Address_ID ,6,len(Profile_Address_ID)))from Profile_Address where Profile_Address_ID like 'A_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Address_ID ,6,len(Profile_Address_ID)))from Profile_Address where Profile_Address_ID like 'A_IVO%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return AProfileID;
    //}
    public static String GetAddressProfileID(string startvalue)//(string off)
    {
        string AProfileID = null;
        //string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "A";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

          /*  if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    AProfileID = initial + startvalue + year + id;
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    AProfileID = initial + startvalue + year + id;
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
            

        }

        return AProfileID;
    }
    public static int InsertProfileAddress(string Profile_Address_ID, string Profile_Address_Line1, string Profile_Address_Line2, string Profile_Address_State, string Profile_Address_city, string Profile_Address_Postcode, DateTime Profile_Address_Created_Date, string Profile_Address_Expiry_Date, string Profile_ID,string acountry)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile_Address values(@Profile_Address_ID ,	@Profile_Address_Line1,	@Profile_Address_Line2 ,@Profile_Address_State,	@Profile_Address_city, 	@Profile_Address_Postcode ,	@Profile_Address_Created_Date, 	@Profile_Address_Expiry_Date ,@Profile_ID,@acountry)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Address_ID ", SqlDbType.VarChar).Value = Profile_Address_ID;
                da.InsertCommand.Parameters.Add("@Profile_Address_Line1 ", SqlDbType.VarChar).Value = Profile_Address_Line1;
                da.InsertCommand.Parameters.Add("@Profile_Address_Line2 ", SqlDbType.VarChar).Value = Profile_Address_Line2;
                da.InsertCommand.Parameters.Add("@Profile_Address_State ", SqlDbType.VarChar).Value = Profile_Address_State;
                da.InsertCommand.Parameters.Add("@Profile_Address_city ", SqlDbType.VarChar).Value = Profile_Address_city;
                da.InsertCommand.Parameters.Add("@Profile_Address_Postcode ", SqlDbType.VarChar).Value = Profile_Address_Postcode;
                da.InsertCommand.Parameters.Add("@Profile_Address_Created_Date ", SqlDbType.DateTime).Value = Profile_Address_Created_Date;
                da.InsertCommand.Parameters.Add("@Profile_Address_Expiry_Date ", SqlDbType.VarChar).Value = Profile_Address_Expiry_Date;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@acountry ", SqlDbType.VarChar).Value = acountry;
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Address Query " + ex.Message);
                string msg = "Error in Insert Profile Address Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
            rowsAffected = da.InsertCommand.ExecuteNonQuery();
        }
        return (rowsAffected);
    }



    //public static String GetSubProfile1ID(string off)
    //{
    //    string SubProfile1ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile1_ID  ,8,len(Sub_Profile1_ID)))from Sub_Profile1 where Sub_Profile1_ID like 'SP1_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile1_ID ,8,len(Sub_Profile1_ID)))from Sub_Profile1 where Sub_Profile1_ID like 'SP1_IVO%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //            }

    //        }
    //    }

    //    return SubProfile1ID;
    //}
    public static String GetSubProfile1ID(string startvalue)//(string off)
    {
        string SubProfile1ID = null;
       // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP1";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

           /* if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile1ID = initial + startvalue + year + id;
                  
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile1ID = initial + startvalue + year + id;
                     
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
        

        }

        return SubProfile1ID;
    }





    public static int InsertSub_Profile1(string Sub_Profile1_ID, string Sub_Profile1_Title, string Sub_Profile1_Fname, string Sub_Profile1_Lname, string Sub_Profile1_DOB, string Sub_Profile1_Nationality, string Sub_Profile1_Country, string Profile_ID,string Sub_Profile1_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            { 

            da.InsertCommand = new SqlCommand("insert into Sub_Profile1 values(@Sub_Profile1_ID,@Sub_Profile1_Title ,	@Sub_Profile1_Fname ,	@Sub_Profile1_Lname ,	@Sub_Profile1_DOB ,	@Sub_Profile1_Nationality ,	@Sub_Profile1_Country,	@Profile_ID,@Sub_Profile1_Age)", cs1);
            da.InsertCommand.Parameters.Add("@Sub_Profile1_ID", SqlDbType.VarChar).Value = Sub_Profile1_ID;
            da.InsertCommand.Parameters.Add("@Sub_Profile1_Title", SqlDbType.VarChar).Value = Sub_Profile1_Title;
            da.InsertCommand.Parameters.Add("@Sub_Profile1_Fname", SqlDbType.VarChar).Value = Sub_Profile1_Fname;
            da.InsertCommand.Parameters.Add("@Sub_Profile1_Lname", SqlDbType.VarChar).Value = Sub_Profile1_Lname;
            da.InsertCommand.Parameters.Add("@Sub_Profile1_DOB", SqlDbType.VarChar).Value = Sub_Profile1_DOB;
            da.InsertCommand.Parameters.Add("@Sub_Profile1_Nationality", SqlDbType.VarChar).Value = Sub_Profile1_Nationality;
            da.InsertCommand.Parameters.Add("@Sub_Profile1_Country", SqlDbType.VarChar).Value = Sub_Profile1_Country;
            da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Age", SqlDbType.VarChar).Value = Sub_Profile1_Age;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in Insert Sub Profile1 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile1 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    //public static String GetSubProfile2ID(string off)
    //{
    //    string SubProfile2ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile2_ID  ,8,len(Sub_Profile2_ID)))from Sub_Profile2  where Sub_Profile2_ID like 'SP2_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile2_ID  ,8,len(Sub_Profile2_ID)))from Sub_Profile2  where Sub_Profile2_ID like 'SP2_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //            }

    //        }
    //    }

    //    return SubProfile2ID;
    //}

    public static String GetSubProfile2ID(string startvalue)//(string off)
    {
        string SubProfile2ID = null;
      //  string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP2";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

           /* if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile2ID = initial + startvalue + year + id;
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile2ID = initial + startvalue + year + id;
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
        

        }

        return SubProfile2ID;
    }
    public static int InsertSub_Profile2( string Sub_Profile2_ID, string Sub_Profile2_Title, string Sub_Profile2_Fname, string Sub_Profile2_Lname, string Sub_Profile2_DOB, string Sub_Profile2_Nationality, string Sub_Profile2_Country, string Profile_ID,string Sub_Profile2_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile2 values(@Sub_Profile2_ID,@Sub_Profile2_Title ,	@Sub_Profile2_Fname ,	@Sub_Profile2_Lname ,	@Sub_Profile2_DOB ,	@Sub_Profile2_Nationality ,	@Sub_Profile2_Country,	@Profile_ID,@Sub_Profile2_Age)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile2_ID", SqlDbType.VarChar).Value = Sub_Profile2_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Title", SqlDbType.VarChar).Value = Sub_Profile2_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Fname", SqlDbType.VarChar).Value = Sub_Profile2_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Lname", SqlDbType.VarChar).Value = Sub_Profile2_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_DOB", SqlDbType.VarChar).Value = Sub_Profile2_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Nationality", SqlDbType.VarChar).Value = Sub_Profile2_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Country", SqlDbType.VarChar).Value = Sub_Profile2_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Age", SqlDbType.VarChar).Value = Sub_Profile2_Age;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile2 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static String GetSubProfile3ID(string startvalue)//(string off)
    {
        string SubProfile3ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP3";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile3_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile3ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile3_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile3ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile3ID;
    }


    public static int InsertSub_Profile3(string Sub_Profile3_ID, string Sub_Profile3_Title, string Sub_Profile3_Fname, string Sub_Profile3_Lname, string Sub_Profile3_DOB, string Sub_Profile3_Nationality, string Sub_Profile3_Country, string Profile_ID, string Sub_Profile3_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile3 values(@Sub_Profile3_ID,@Sub_Profile3_Title ,	@Sub_Profile3_Fname ,	@Sub_Profile3_Lname ,	@Sub_Profile3_DOB ,	@Sub_Profile3_Nationality ,	@Sub_Profile3_Country,@Sub_Profile3_Age,@Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile3_ID", SqlDbType.VarChar).Value = Sub_Profile3_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Title", SqlDbType.VarChar).Value = Sub_Profile3_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Fname", SqlDbType.VarChar).Value = Sub_Profile3_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Lname", SqlDbType.VarChar).Value = Sub_Profile3_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_DOB", SqlDbType.VarChar).Value = Sub_Profile3_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Nationality", SqlDbType.VarChar).Value = Sub_Profile3_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Country", SqlDbType.VarChar).Value = Sub_Profile3_Country;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Age", SqlDbType.VarChar).Value = Sub_Profile3_Age;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile3 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static String GetSubProfile4ID(string startvalue)//(string off)
    {
        string SubProfile4ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP4";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile4_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile4ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile4_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile4ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile4ID;
    }


    public static int InsertSub_Profile4(string Sub_Profile4_ID, string Sub_Profile4_Title, string Sub_Profile4_Fname, string Sub_Profile4_Lname, string Sub_Profile4_DOB, string Sub_Profile4_Nationality, string Sub_Profile4_Country, string Profile_ID, string Sub_Profile4_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile4 values(@Sub_Profile4_ID,@Sub_Profile4_Title ,	@Sub_Profile4_Fname ,	@Sub_Profile4_Lname ,	@Sub_Profile4_DOB ,	@Sub_Profile4_Nationality ,	@Sub_Profile4_Country,@Sub_Profile4_Age,@Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile4_ID", SqlDbType.VarChar).Value = Sub_Profile4_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Title", SqlDbType.VarChar).Value = Sub_Profile4_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Fname", SqlDbType.VarChar).Value = Sub_Profile4_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Lname", SqlDbType.VarChar).Value = Sub_Profile4_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_DOB", SqlDbType.VarChar).Value = Sub_Profile4_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Nationality", SqlDbType.VarChar).Value = Sub_Profile4_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Country", SqlDbType.VarChar).Value = Sub_Profile4_Country;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Age", SqlDbType.VarChar).Value = Sub_Profile4_Age;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile4 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    //public static String GetPhoneID(string off)
    //{
    //    string PhoneID = null;
    //    string startvalue = "";
    //    int id = 0;

    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Phone_ID,7,len(Phone_ID)))from Phone where Phone_ID like 'PH_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Phone_ID,7,len(Phone_ID)))from Phone where Phone_ID like 'PH_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //            }

    //        }

    //    }

    //    return PhoneID;
    //}

    public static String GetPhoneID(string startvalue)//(string off)
    {
        string PhoneID = null;
       // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "PH";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

           /* if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PhoneID = initial + startvalue + year + id;
                  
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PhoneID = initial + startvalue + year + id;
                   
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
         
        }

        return PhoneID;
    }




    public static int InsertPhone(string Phone_ID, string Profile_ID, string Primary_CC, string Primary_Mobile, string Primary_Alt_CC, string Primary_Alternate, string Secondary_CC, string Secondary_Mobile, string Secondary_Alt_CC, string Secondary_Alternate, string Subprofile1_CC, string Subprofile1_Mobile, string Subprofile1_Alt_CC, string Subprofile1_Alternate, string Subprofile2_CC, string Subprofile2_Mobile, string Subprofile2_Alt_CC, string Subprofile2_Alternate, string Subprofile3_CC, string Subprofile3_Mobile, string Subprofile4_CC, string Subprofile4_Mobile, string Subprofile3_Alt_CC, string Subprofile3_Alternate, string Subprofile4_Alt_CC, string Subprofile4_Alternate)
    {
        int rowsAffected = 0;
        SqlDataAdapter da1 = new SqlDataAdapter();


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da1.InsertCommand = new SqlCommand("insert into Phone values(@Phone_ID,@Profile_ID,@Primary_CC,@Primary_Mobile,@Primary_Alt_CC,@Primary_Alternate,@Secondary_CC, @Secondary_Mobile,@Secondary_Alt_CC,@Secondary_Alternate,@Subprofile1_CC,@Subprofile1_Mobile,@Subprofile1_Alt_CC,@Subprofile1_Alternate,@Subprofile2_CC,@Subprofile2_Mobile,@Subprofile2_Alt_CC,@Subprofile2_Alternate,@Subprofile3_CC,@Subprofile3_Mobile,@Subprofile4_CC,@Subprofile4_Mobile,@Subprofile3_Alt_CC,@Subprofile3_Alternate,@Subprofile4_Alt_CC,@Subprofile4_Alternate)", cs1);
                da1.InsertCommand.Parameters.Add("@Phone_ID", SqlDbType.VarChar).Value = Phone_ID;
                da1.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da1.InsertCommand.Parameters.Add("@Primary_CC", SqlDbType.VarChar).Value = Primary_CC;
                da1.InsertCommand.Parameters.Add("@Primary_Mobile", SqlDbType.VarChar).Value = Primary_Mobile;
                da1.InsertCommand.Parameters.Add("@Primary_Alt_CC", SqlDbType.VarChar).Value = Primary_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Primary_Alternate", SqlDbType.VarChar).Value = Primary_Alternate;
                da1.InsertCommand.Parameters.Add("@Secondary_CC", SqlDbType.VarChar).Value = Secondary_CC;
                da1.InsertCommand.Parameters.Add("@Secondary_Mobile", SqlDbType.VarChar).Value = Secondary_Mobile;
                da1.InsertCommand.Parameters.Add("@Secondary_Alt_CC", SqlDbType.VarChar).Value = Secondary_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Secondary_Alternate", SqlDbType.VarChar).Value = Secondary_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile1_CC", SqlDbType.VarChar).Value = Subprofile1_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Mobile", SqlDbType.VarChar).Value = Subprofile1_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Alt_CC", SqlDbType.VarChar).Value = Subprofile1_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Alternate", SqlDbType.VarChar).Value = Subprofile1_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile2_CC", SqlDbType.VarChar).Value = Subprofile2_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Mobile", SqlDbType.VarChar).Value = Subprofile2_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Alt_CC", SqlDbType.VarChar).Value = Subprofile2_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Alternate", SqlDbType.VarChar).Value = Subprofile2_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile3_CC", SqlDbType.VarChar).Value = Subprofile3_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Mobile", SqlDbType.VarChar).Value = Subprofile3_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile4_CC", SqlDbType.VarChar).Value = Subprofile4_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Mobile", SqlDbType.VarChar).Value = Subprofile4_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Alt_CC", SqlDbType.VarChar).Value = Subprofile3_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Alternate", SqlDbType.VarChar).Value = Subprofile3_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Alt_CC", SqlDbType.VarChar).Value = Subprofile4_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Alternate", SqlDbType.VarChar).Value = Subprofile4_Alternate;
                rowsAffected = da1.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in Insert Phone Query " + ex.Message);
                string msg = "Error in Insert Phone Query   " + " " + ex.Message;

                throw new Exception(msg, ex);
                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }   


        return (rowsAffected);
    }
    //public static String GetEmailID(string off)
    //{
    //    string EmailID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Email_ID ,7,len(Email_ID )))from Email where Email_ID like 'EM_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Email_ID ,7,len(Email_ID )))from Email where Email_ID like 'EM_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //            }
    //        }

    //    }

    //    return EmailID;
    //}
    public static String GetEmailID(string startvalue)//(string off)
    {
        string EmailID = null;
       // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "EM";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

           /* if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    EmailID = initial + startvalue + year + id;
                   
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    EmailID = initial + startvalue + year + id;
                  
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
      

        }


        return EmailID;
    }
    public static int InsertEmail(string Email_ID, string Profile_ID, string Primary_Email, string Secondary_Email, string Subprofile1_Email, string Subprofile2_Email, string Primary_Email2, string Secondary_Email2, string Subprofile1_Email2, string Subprofile2_Email2, string Subprofile3_Email, string Subprofile3_Email2, string Subprofile4_Email, string Subprofile4_Email2)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Email values(@Email_ID,@Profile_ID,@Primary_Email,@Secondary_Email,@Subprofile1_Email,@Subprofile2_Email,@Primary_Email2,@Secondary_Email2,@Subprofile1_Email2,@Subprofile2_Email2,@Subprofile3_Email,@Subprofile3_Email2,@Subprofile4_Email,@Subprofile4_Email2)", cs2);
                da.InsertCommand.Parameters.Add("@Email_ID ", SqlDbType.VarChar).Value = Email_ID;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Primary_Email ", SqlDbType.VarChar).Value = Primary_Email;
                da.InsertCommand.Parameters.Add("@Secondary_Email ", SqlDbType.VarChar).Value = Secondary_Email;
                da.InsertCommand.Parameters.Add("@Subprofile1_Email ", SqlDbType.VarChar).Value = Subprofile1_Email;
                da.InsertCommand.Parameters.Add("@Subprofile2_Email ", SqlDbType.VarChar).Value = Subprofile2_Email;
                da.InsertCommand.Parameters.Add("@Primary_Email2 ", SqlDbType.VarChar).Value = Primary_Email2;
                da.InsertCommand.Parameters.Add("@Secondary_Email2 ", SqlDbType.VarChar).Value = Secondary_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile1_Email2 ", SqlDbType.VarChar).Value = Subprofile1_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile2_Email2 ", SqlDbType.VarChar).Value = Subprofile2_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile3_Email ", SqlDbType.VarChar).Value = Subprofile3_Email;
                da.InsertCommand.Parameters.Add("@Subprofile3_Email2 ", SqlDbType.VarChar).Value = Subprofile3_Email2;
                da.InsertCommand.Parameters.Add("@Subprofile4_Email ", SqlDbType.VarChar).Value = Subprofile4_Email;
                da.InsertCommand.Parameters.Add("@Subprofile4_Email2 ", SqlDbType.VarChar).Value = Subprofile4_Email2;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            
            }
            catch (Exception ex)
             {

           // MessageBox.Show("Error in Insert Email Query " + ex.Message);

                string msg = "Error in Insert Email Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
    }
        return (rowsAffected);
    }

    //public static String GetStayDetailsID(string off)
    //{
    //    string Profile_Stay_ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Stay_ID ,7,len(Profile_Stay_ID)))from Profile_Stay where Profile_Stay_ID like 'SD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else

    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Stay_ID  ,7,len(Profile_Stay_ID)))from Profile_Stay where Profile_Stay_ID like 'SD_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return Profile_Stay_ID;
    //}
    public static String GetStayDetailsID(string startvalue)//(string off)
    {
        string Profile_Stay_ID = null;
       // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SD";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

          /*  if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    Profile_Stay_ID = initial + startvalue + year + id;
                   
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    Profile_Stay_ID = initial + startvalue + year + id;
                     
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
          

        }

        return Profile_Stay_ID;
    }
    public static int InsertProfileStay(string Profile_Stay_ID, string Profile_Stay_Resort_Name, string Profile_Stay_Resort_Room_Number, string Profile_Stay_Arrival_Date, string Profile_Stay_Departure_Date, string Profile_ID)//,string tourid)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            { 
            da.InsertCommand = new SqlCommand("insert into Profile_Stay values(@Profile_Stay_ID ,	@Profile_Stay_Resort_Name ,	@Profile_Stay_Resort_Room_Number ,	@Profile_Stay_Arrival_Date ,	@Profile_Stay_Departure_Date ,	@Profile_ID)", cs2);
            da.InsertCommand.Parameters.Add("@Profile_Stay_ID ", SqlDbType.VarChar).Value = Profile_Stay_ID;
            da.InsertCommand.Parameters.Add("@Profile_Stay_Resort_Name ", SqlDbType.VarChar).Value = Profile_Stay_Resort_Name;
            da.InsertCommand.Parameters.Add("@Profile_Stay_Resort_Room_Number ", SqlDbType.VarChar).Value = Profile_Stay_Resort_Room_Number;
            da.InsertCommand.Parameters.Add("@Profile_Stay_Arrival_Date ", SqlDbType.VarChar).Value = Profile_Stay_Arrival_Date;
            da.InsertCommand.Parameters.Add("@Profile_Stay_Departure_Date ", SqlDbType.VarChar).Value = Profile_Stay_Departure_Date;
            da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
            //da.InsertCommand.Parameters.Add("@tourid ", SqlDbType.VarChar).Value = tourid;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Stay Query " + ex.Message);

                string msg = "Error in Insert Profile Stay Query  " + " " + ex.Message;

                throw new Exception(msg, ex);

                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    //public static String GetTourDetailsID(string off)
    //{
    //    string TourID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Tour_Details_ID,7,len(Tour_Details_ID )))from Tour_Details where Tour_Details_ID like 'TD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Tour_Details_ID,7,len(Tour_Details_ID )))from Tour_Details where Tour_Details_ID like 'TD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return TourID;
    //}
    public static String GetTourDetailsID(string startvalue)//(string off)
    {
        string TourID = null;
      //  string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "TD";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

           /* if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";*/

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    TourID = initial + startvalue + year + id;
                    
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    TourID = initial + startvalue + year + id;
                   
                    //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    //int rows = sqlcmd.ExecuteNonQuery();

                }
         

        }


        return TourID;
    }

    public static int InsertTourDetails(string Tour_Details_ID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref, string Profile_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Tour_Details values(@Tour_Details_ID,@Tour_Details_Guest_Status,@Tour_Details_Guest_Sales_Rep,@Tour_Details_Tour_Date,@Tour_Details_Sales_Deck_Check_In,	@Tour_Details_Sales_Deck_Check_Out,@Tour_Details_Taxi_In_Price,@Tour_Details_Taxi_In_Ref ,@Tour_Details_Taxi_Out_Price ,@Tour_Details_Taxi_Out_Ref,@Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Tour_Details_ID ", SqlDbType.VarChar).Value = Tour_Details_ID;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Status ", SqlDbType.VarChar).Value = Tour_Details_Guest_Status;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Sales_Rep ", SqlDbType.VarChar).Value = Tour_Details_Guest_Sales_Rep;
                da.InsertCommand.Parameters.Add("@Tour_Details_Tour_Date ", SqlDbType.VarChar).Value = Tour_Details_Tour_Date;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_In ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_In;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_Out ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_Out;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Price ", SqlDbType.VarChar).Value = Tour_Details_Taxi_In_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_In_Ref;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Price ", SqlDbType.VarChar).Value = Tour_Details_Taxi_Out_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_Out_Ref;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Tour Details Query " + ex.Message);

                string msg = "Error in Insert Tour Details Query" + " " + ex.Message;
                
                throw new Exception("transction: " + msg, ex);

               
            }
        }
        return (rowsAffected);
    }

    public static String GetCountryCodeValue(string name, string code)
        {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
          //  SqlCommand scd = new SqlCommand(" select country_id from country where country_name =@name and country_code =@code", cs1);
            SqlCommand scd = new SqlCommand(" select country_code from country where country_name =@name and country_code =@code", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            scd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
            val = (string)scd.ExecuteScalar();
        }
        return val;
        }
    public static void ProfileView(string ID)
    {
        System.Web.HttpContext.Current.Response.Write("<script>window.open('Guest REg form india.rpt?value=" + ID + " ', 'newwindow','location=no,menubar=no,width=800,height=1000,resizable=yes,scrollbars=yes,top=250,left=200')</script>");

    }

    public static DataSet LoadProfileOnCreation(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select p.*, pp.Profile_Primary_Title, pp.Profile_Primary_Fname, pp.Profile_Primary_Lname, CONVERT (date, pp.Profile_Primary_DOB)dob, pp.Profile_Primary_Nationality, pp.Profile_Primary_Country, pa.Profile_Address_city, pa.Profile_Address_State, ph.Primary_Mobile, em.Primary_Email, s.Profile_Stay_Resort_Name, CONVERT (date,s.Profile_Stay_Arrival_Date)arrivaldate, CONVERT (date,s.Profile_Stay_Departure_Date) DepartureDate, ps.Profile_Secondary_Title, ps.Profile_Secondary_Fname, ps.Profile_Secondary_Lname, ps.Profile_Secondary_Nationality from Profile p left outer join Profile_Primary pp on pp.Profile_ID = p.Profile_ID left outer join Profile_Secondary ps on ps.Profile_ID = pp.Profile_ID  left outer join Phone ph on ph.Profile_ID = p.Profile_ID left outer join Email em on em.Profile_ID = p.Profile_ID left outer join Profile_Address pa on pa.Profile_ID = p.Profile_ID left outer join Profile_Stay s on s.Profile_ID = p.Profile_ID where p.Profile_ID =@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadEntitlement()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Entitlement_Name  from Entitlement where Entitlement_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadSearchProfile(string profileid,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
            //SqlCommand SqlCmd = new SqlCommand("	 select pp.Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where pp.Profile_ID=@profileid  and p.office=@office", cs1);
            // SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%"+ profileid + "%')", cs1);
           // SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,Profile_Primary_Title as Title,Profile_Primary_Fname+' '+Profile_Primary_Lname as Name,e.Primary_Email as Email,q.Primary_Mobile as Mobile,td.Tour_Details_Tour_Date as [Tour Date],td.Tour_Details_ID as Tour_Id  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID join Tour_Details_VP td on p.Profile_ID = td.Profile_ID where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%" + profileid + "%' or pp.Profile_Primary_Lname like '%" + profileid + "%' or e.Primary_Email like '%" + profileid + "%' or q.Primary_Mobile like '%" + profileid + "%')", cs1);

            SqlCommand SqlCmd = new SqlCommand("select pp.Profile_ID,Profile_Primary_Title as Title,Profile_Primary_Fname+' '+Profile_Primary_Lname as Name,e.Primary_Email as Email,q.Primary_Mobile as Mobile,td.Tour_Details_Tour_Date as [Tour Date],td.Tour_Details_ID as Tour_Id  from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID join Tour_Details td on p.Profile_ID = td.Profile_ID where p.office=@office and(pp.Profile_ID = @profileid or pp.Profile_Primary_Fname like '%" + profileid + "%' or pp.Profile_Primary_Lname like '%" + profileid + "%' or e.Primary_Email like '%" + profileid + "%' or q.Primary_Mobile like '%" + profileid + "%')", cs1);


            //p.office = 'ivo' and(pp.Profile_ID = '' or pp.Profile_Primary_Fname like '%anket%')
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadPayMethod()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select pay_method_name from pay_method", cs1);

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSalesReps(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID=@venuecountry", cs1);//("select * from Sales_Rep where Venue_country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuec)", cs1);
            SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where office=@office and Sales_Rep_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadVenueCountry1(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Country_Name from VenueCountry where Venue_Country_Name not in(select Profile_Venue_Country  from Profile where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadVenue1(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from Venue where Venue_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static int ProfileExists(string profile)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select Profile_ID  from Profile  where Profile_ID =@profile", cs1);
            scd.Parameters.Add("@profile", SqlDbType.VarChar).Value = profile;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;
           
    }

    public static int UserExists (string uname)
    {
        int user,ch;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqcmd = new SqlCommand("select count(*) from users where username=@uname and userstatus='Active'", cs1);
            sqcmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            ch = (int)sqcmd.ExecuteScalar();
            if (ch == 1)
            {
                user = 1;
            }
            else
            {
                user = 0;
            }
        }
        return user;
    }
    public static string PswdCheck(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select password from users where username=@uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static string GetGroupID(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select[Group Id] from users where username= @uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static string GetTitle(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Title from users where username= @uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static DataSet LoadUserGroupAccess(string id,string title)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand(" select* from user_group_access where[Group Id]=@id   and title=@title", cs1);
            SqlCmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            SqlCmd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static String GetCountryCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand scd = new SqlCommand(" select country_id from country where country_name =@name and country_code =@code", cs1);
            SqlCommand scd = new SqlCommand(" select country_code from country where country_name =@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
        
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static string GetOffice(string uname)
    {
        string val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select office from users where username= @uname", cs1);
            scd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            val = (string)scd.ExecuteScalar();

        }
        return val;
    }
    public static int GetAccessValue(string id,string title,string name)
    {
        int val;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select PageName  from user_group_access where[Group Id] =@id   and title =@title and Name =@name  and([read] = 1 or[modify] = 1 or[delete] = 1 or[write] = 1 or[report] = 1)", cs1);
            scd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            scd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            val = (int)scd.ExecuteScalar();

        }
        return val;
    }

    public static DataSet LoadSearchProfileName(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadSearchProfilePhone(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadTOManager(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

             SqlCommand SqlCmd = new SqlCommand("select TO_Manager_Name  from TO_Manager where office=@office and TO_Manager_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadTOManagerOnVenue(string office,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select TO_Manager_Name  from TO_Manager where office=@office and TO_Manager_Status='Active' and venue=@venue", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadButtonUp(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

             SqlCommand SqlCmd = new SqlCommand("select ButtonUp_Name  from ButtonUp  where office=@office and ButtonUp_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadButtonUpOnVenue(string office,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select ButtonUp_Name  from ButtonUp  where office=@office and ButtonUp_Status='Active' and venue=@venue", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadFinanceOffice(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Finance_Currency_Name  from Finance_Office  where office=@office and Status='Active'", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadProfielDetailsFull(string profile)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select* from Profile p left join Profile_Primary pp on pp.Profile_ID = p.Profile_ID left join Profile_Secondary ps on ps.Profile_ID = p.Profile_ID left join Sub_Profile1 sp1 on sp1.Profile_ID = p.Profile_ID left join Sub_Profile2   sp2 on sp2.Profile_ID = p.Profile_ID left join Sub_Profile3 sp3 on sp3.Profile_ID = p.Profile_ID left join Sub_Profile4   sp4 on sp4.Profile_ID = p.Profile_ID left join Profile_Stay  sp on sp.Profile_ID = p.Profile_ID left join Tour_Details  td on td.Profile_ID = p.Profile_ID left join Phone ph on ph.Profile_ID=p.Profile_ID left join Email em on em.Profile_ID =p.Profile_ID left join Profile_Address pa on pa.Profile_ID =p.Profile_ID  where p.Profile_ID =@profile  ", cs1);
            SqlCmd.Parameters.Add("@profile", SqlDbType.VarChar).Value = profile;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadProfileVenueCountry(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Country_Name from VenueCountry where Venue_Country_Status='active' and  Venue_Country_Name not in(select Profile_Venue_Country  from Profile where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    //public static DataSet LoadProfileVenue (string ProfileID)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        SqlCommand SqlCmd = new SqlCommand(" select distinct Venue_Name from Venue where Venue_Status='active' and Venue_Name  not in(select Profile_Venue   from Profile where Profile_ID=@ProfileID) ", cs1);
    //        SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}

    public static DataSet LoadProfileVenue(string ProfileID, string country)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //SqlCommand SqlCmd = new SqlCommand(" select distinct Venue_Name from Venue where Venue_Status='active' and Venue_Name  not in(select Profile_Venue   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("  select distinct Venue_Name from Venue join VenueCountry vc on vc.Venue_Country_ID = venue.Venue_Country_ID where Venue_Status = 'active' and Venue_Name    not in(select Profile_Venue   from Profile where Profile_ID = @ProfileID)and vc.Venue_Country_Name =@country ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    //public static DataSet LoadProfileVenueGroup(string ProfileID)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Group_Name  from Venue_Group  where Venue_Group_Status='active' and Venue_Group_Name  not in(select Profile_Group_Venue    from Profile where Profile_ID=@ProfileID) ", cs1);
    //        SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}

    public static DataSet LoadProfileVenueGroup(string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Group_Name  from Venue_Group  where Venue_Group_Status='active' and Venue_Group_Name  not in(select Profile_Group_Venue    from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Group_Name  from Venue_Group vg join venue v on v.Venue_ID = vg.Venue_ID where vg.Venue_Group_Status = 'active' and vg.Venue_Group_Name  not in(select Profile_Group_Venue    from Profile where Profile_ID =@ProfileID) and v.Venue_Name =@venue ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    //public static DataSet LoadProfileMktg(string ProfileID)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        SqlCommand SqlCmd = new SqlCommand(" select distinct Marketing_Program_Name   from Marketing_Program   where Marketing_Program_Status ='active' and Marketing_Program_Name  not in(select Profile_Marketing_Program   from Profile where Profile_ID=@ProfileID) ", cs1);
    //        SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}


    public static DataSet LoadProfileMktg(string ProfileID, string venue, string venuegrp)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // SqlCommand SqlCmd = new SqlCommand(" select distinct Marketing_Program_Name   from Marketing_Program   where Marketing_Program_Status ='active' and Marketing_Program_Name  not in(select Profile_Marketing_Program   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select distinct Marketing_Program_Name   from Marketing_Program join Venue_Group vg on vg.Venue_group_ID = Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID = @ProfileID) and vg.Venue_Group_Name = @venuegrp and v.Venue_Name =@venue ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadProfileAgent(string ProfileID)//,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct Agent_Name    from Agent    where Agent_Status  ='active' and Agent_Name  not in(select Profile_Agent   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
         //   SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadProfileAgent1(string ProfileID,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select agentname  from Agent_GroupVenue where  status='Active' and AgentName not in (select Profile_Agent  from Profile where Profile_ID=@ProfileID) and venue=@venue", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
         SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadProfileAgentNotColdline(string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select Sales_Rep_Name from Sales_Rep where Sales_Rep_Status = 'Active' and venue =@venue and Sales_Rep_Name not in (select Profile_Agent  from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadProfileManager(string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct Manager_Name from Managers where Manager_Status = 'Active' and venue =@venue and Manager_Name not in(select manager  from Profile where Profile_ID =@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count==0)
            {
                SqlCommand SqlCmd1 = new SqlCommand(" select distinct Manager_Name from Managers where Manager_Status = 'Active' and venue =@venue  ", cs1);
                SqlCmd1.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                SqlCmd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                da = new SqlDataAdapter(SqlCmd1);
                ds = new DataSet();
                da.Fill(ds);

            }
            
            return (ds);
        }
       
    }
    public static DataSet LoadProfileEmployment(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("   select Name from EmploymentStatus where status = 'Active' and name not in (select Profile_Employment_status from profile where Profile_ID = @ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;          
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
 




    public static DataSet LoadProfileAgentCode(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand(" select distinct Agent_Code_Name    from Agent_Code     where Agent_Code_Status  ='active' and Agent_Code_Name  not in(select Profile_Agent_Code   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadProfileTOName(string ProfileID,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct TO_Manager_Name from TO_Manager where TO_Manager_Status  ='active' and TO_Manager_Name  not in(select Profile_Agent_Code from Profile where Profile_ID =@ProfileID) and venue =@venue ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    
    public static DataSet LoadCountryPrimary(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("	 select distinct country_name   from country where country_name not in(select Profile_Primary_Country  from Profile_Primary where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountrySecondary(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("	 select distinct country_name   from country where country_name not in(select Profile_Secondary_Country  from Profile_Secondary where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountrySP1(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("	 select distinct country_name   from country where country_name not in(select Sub_Profile1_Country  from Sub_Profile1 where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountrySP2(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("	 select distinct country_name   from country where country_name not in(select Sub_Profile2_Country  from Sub_Profile2 where Profile_ID =@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodePrimaryMobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Primary_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    
    public static DataSet LoadCountryWithCodePrimaryAlt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Primary_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSecondaryMobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Secondary_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSecondaryAlt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Secondary_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    

    public static DataSet LoadCountryWithCodeSP1Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile1_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSP1Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile1_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSP2Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile2_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSP2Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Subprofile2_Alt_CC from phone where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
  

    //public static int UpdateProfile(string ProfileID, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple,string manager)
    //{
    //    int rowsaffected = 0;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        try
    //        {
    //            SqlCommand scd = new SqlCommand("update Profile  SET Profile_Venue_Country= '" + Profile_Venue_Country + "',	Profile_Venue= '" + Profile_Venue + "',	Profile_Group_Venue= '" + Profile_Group_Venue + "',	Profile_Marketing_Program= '" + Profile_Marketing_Program + "',	Profile_Agent= '" + Profile_Agent + "',	Profile_Agent_Code= '" + Profile_Agent_Code + "',	Profile_Member_Type1= '" + Profile_Member_Type1 + "',	Profile_Member_Number1= '" + Profile_Member_Number1 + "',	Profile_Member_Type2= '" + Profile_Member_Type2 + "',	Profile_Member_Number2= '" + Profile_Member_Number2 + "',	Profile_Employment_status= '" + Profile_Employment_status + "',	Profile_Marital_status= '" + Profile_Marital_status + "',	Profile_NOY_Living_as_couple= '" + Profile_NOY_Living_as_couple + "',	manager= '" + manager + "' where Profile_ID ='" + ProfileID + "'", cs1);
    //            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //            rowsaffected = scd.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {

    //            MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

    //            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
    //        }
    //    }
    //    return (rowsaffected);
    //}

    public static int UpdateProfile(string ProfileID, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple, string manager, string Photo_identity, string Card_Holder, string Comments, string reception,string SubVenue,string regTerms)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Profile  SET Profile_Venue_Country= '" + Profile_Venue_Country + "',	Profile_Venue= '" + Profile_Venue + "',	Profile_Group_Venue= '" + Profile_Group_Venue + "',	Profile_Marketing_Program= '" + Profile_Marketing_Program + "',	Profile_Agent= '" + Profile_Agent + "',	Profile_Agent_Code= '" + Profile_Agent_Code + "',	Profile_Member_Type1= '" + Profile_Member_Type1 + "',	Profile_Member_Number1= '" + Profile_Member_Number1 + "',	Profile_Member_Type2= '" + Profile_Member_Type2 + "',	Profile_Member_Number2= '" + Profile_Member_Number2 + "',	Profile_Employment_status= '" + Profile_Employment_status + "',	Profile_Marital_status= '" + Profile_Marital_status + "',	Profile_NOY_Living_as_couple= '" + Profile_NOY_Living_as_couple + "',	manager= '" + manager + "',	Photo_identity= '" + Photo_identity + "',	Card_Holder= '" + Card_Holder + "',Comments='"+Comments+"',Reception='"+ reception + "', SubVenue='" + SubVenue + "',RegTerms='"+regTerms+"' where Profile_ID ='" + ProfileID + "'", cs1);
            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }




    //public static int  UpdateProfilePrimary(string ProfileID, string Profile_Primary_Title, string Profile_Primary_Fname, string Profile_Primary_Lname, string Profile_Primary_DOB, string Profile_Primary_Nationality, string Profile_Primary_Country)
    //{
    //    int rowsaffected = 0;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        try
    //        {
    //            SqlCommand scd = new SqlCommand("update Profile_Primary SET  Profile_Primary_Title='" + Profile_Primary_Title + "',Profile_Primary_Fname='" + Profile_Primary_Fname + "',Profile_Primary_Lname='" + Profile_Primary_Lname + "',Profile_Primary_DOB='" + Profile_Primary_DOB + "',Profile_Primary_Nationality='" + Profile_Primary_Nationality + "',Profile_Primary_Country='" + Profile_Primary_Country + "'where Profile_ID='" + ProfileID + "'", cs1);
    //            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //            rowsaffected = scd.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {

    //            MessageBox.Show("Error in UPDATE Profile_Primary Query " + ex.Message);

    //            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
    //        }
    //    }
    //    return (rowsaffected);
    //}


    public static int UpdateProfilePrimary(string ProfileID, string Profile_Primary_Title, string Profile_Primary_Fname, string Profile_Primary_Lname, string Profile_Primary_DOB, string Profile_Primary_Nationality, string Profile_Primary_Country, string Primary_Age, string Primary_Designation, string Primary_Language)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Primary SET  Profile_Primary_Title='" + Profile_Primary_Title + "',Profile_Primary_Fname='" + Profile_Primary_Fname + "',Profile_Primary_Lname='" + Profile_Primary_Lname + "',Profile_Primary_DOB='" + Profile_Primary_DOB + "',Profile_Primary_Nationality='" + Profile_Primary_Nationality + "',Profile_Primary_Country='" + Profile_Primary_Country + "',Primary_Age='" + Primary_Age + "',Primary_Designation='" + Primary_Designation + "',Primary_Language='" + Primary_Language + "'where Profile_ID='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Profile_Primary Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Primary Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    //public static int UpdateProfileSecondary(string ProfileID, string Profile_Secondary_Title, string Profile_Secondary_Fname, string Profile_Secondary_Lname, string Profile_Secondary_DOB, string Profile_Secondary_Nationality, string Profile_Secondary_Country)
    //{
    //    int rowsaffected = 0;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        try
    //        {
    //            SqlCommand scd = new SqlCommand("update Profile_Secondary SET  Profile_Secondary_Title='" + Profile_Secondary_Title + "',Profile_Secondary_Fname='" + Profile_Secondary_Fname + "',Profile_Secondary_Lname='" + Profile_Secondary_Lname + "',Profile_Secondary_DOB='" + Profile_Secondary_DOB + "',Profile_Secondary_Nationality='" + Profile_Secondary_Nationality + "',Profile_Secondary_Country='" + Profile_Secondary_Country + "'where Profile_ID='" + ProfileID + "'", cs1);
    //            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //            rowsaffected = scd.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {

    //            MessageBox.Show("Error in UPDATE Profile_Secondary Query " + ex.Message);

    //            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
    //        }
    //    }
    //    return (rowsaffected);
    //}


    public static int UpdateProfileSecondary(string ProfileID, string Profile_Secondary_Title, string Profile_Secondary_Fname, string Profile_Secondary_Lname, string Profile_Secondary_DOB, string Profile_Secondary_Nationality, string Profile_Secondary_Country, string Secondary_Age, string Secondary_Designation, string Secondary_Language)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try { 
            SqlCommand scd = new SqlCommand("update Profile_Secondary SET  Profile_Secondary_Title='" + Profile_Secondary_Title + "',Profile_Secondary_Fname='" + Profile_Secondary_Fname + "',Profile_Secondary_Lname='" + Profile_Secondary_Lname + "',Profile_Secondary_DOB='" + Profile_Secondary_DOB + "',Profile_Secondary_Nationality='" + Profile_Secondary_Nationality + "',Profile_Secondary_Country='" + Profile_Secondary_Country + "',Secondary_Age='" + Secondary_Age + "',Secondary_Designation='" + Secondary_Designation + "',Secondary_Language='" + Secondary_Language + "'where Profile_ID='" + ProfileID + "'", cs1);
            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Profile_Secondary Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Secondary Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    //public static int UpdateSubProfile1(string ProfileID, string Sub_Profile1_Title, string Sub_Profile1_Fname, string Sub_Profile1_Lname, string Sub_Profile1_DOB, string Sub_Profile1_Nationality, string Sub_Profile1_Country)
    //{
    //    int rowsaffected = 0;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        try
    //        {
    //            SqlCommand scd = new SqlCommand("update Sub_Profile1 SET  Sub_Profile1_Title='" + Sub_Profile1_Title + "',Sub_Profile1_Fname='" + Sub_Profile1_Fname + "',Sub_Profile1_Lname='" + Sub_Profile1_Lname + "',Sub_Profile1_DOB='" + Sub_Profile1_DOB + "',Sub_Profile1_Nationality='" + Sub_Profile1_Nationality + "',Sub_Profile1_Country='" + Sub_Profile1_Country + "'where Profile_ID='" + ProfileID + "'", cs1);
    //            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //            rowsaffected = scd.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {

    //            MessageBox.Show("Error in UPDATE Sub_Profile1 Query " + ex.Message);

    //            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
    //        }
    //    }
    //    return (rowsaffected);
    //}

    public static int UpdateSubProfile1(string ProfileID, string Sub_Profile1_Title, string Sub_Profile1_Fname, string Sub_Profile1_Lname, string Sub_Profile1_DOB, string Sub_Profile1_Nationality, string Sub_Profile1_Country, string Sub_Profile1_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try { 

            SqlCommand scd = new SqlCommand("update Sub_Profile1 SET  Sub_Profile1_Title='" + Sub_Profile1_Title + "',Sub_Profile1_Fname='" + Sub_Profile1_Fname + "',Sub_Profile1_Lname='" + Sub_Profile1_Lname + "',Sub_Profile1_DOB='" + Sub_Profile1_DOB + "',Sub_Profile1_Nationality='" + Sub_Profile1_Nationality + "',Sub_Profile1_Country='" + Sub_Profile1_Country + "',Sub_Profile1_Age='" + Sub_Profile1_Age + "'where Profile_ID='" + ProfileID + "'", cs1);
            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile1 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile1 Query  " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    //public static int UpdateSubProfile2(string ProfileID, string Sub_Profile2_Title, string Sub_Profile2_Fname, string Sub_Profile2_Lname, string Sub_Profile2_DOB, string Sub_Profile2_Nationality, string Sub_Profile2_Country)
    //{
    //    int rowsaffected = 0;
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        try
    //        {
    //            SqlCommand scd = new SqlCommand("update Sub_Profile2 SET  Sub_Profile2_Title='" + Sub_Profile2_Title + "',Sub_Profile2_Fname='" + Sub_Profile2_Fname + "',Sub_Profile2_Lname='" + Sub_Profile2_Lname + "',Sub_Profile2_DOB='" + Sub_Profile2_DOB + "',Sub_Profile2_Nationality='" + Sub_Profile2_Nationality + "',Sub_Profile2_Country='" + Sub_Profile2_Country + "'where Profile_ID='" + ProfileID + "'", cs2);
    //            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //            rowsaffected = scd.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {

    //            MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

    //            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
    //        }
    //    }
    //    return (rowsaffected);
    //}

    public static int UpdateSubProfile2(string ProfileID, string Sub_Profile2_Title, string Sub_Profile2_Fname, string Sub_Profile2_Lname, string Sub_Profile2_DOB, string Sub_Profile2_Nationality, string Sub_Profile2_Country, string Sub_Profile2_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try { 
            SqlCommand scd = new SqlCommand("update Sub_Profile2 SET  Sub_Profile2_Title='" + Sub_Profile2_Title + "',Sub_Profile2_Fname='" + Sub_Profile2_Fname + "',Sub_Profile2_Lname='" + Sub_Profile2_Lname + "',Sub_Profile2_DOB='" + Sub_Profile2_DOB + "',Sub_Profile2_Nationality='" + Sub_Profile2_Nationality + "',Sub_Profile2_Country='" + Sub_Profile2_Country + "',Sub_Profile2_Age='" + Sub_Profile2_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile2 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateSubProfile3(string ProfileID, string Sub_Profile3_Title, string Sub_Profile3_Fname, string Sub_Profile3_Lname, string Sub_Profile3_DOB, string Sub_Profile3_Nationality, string Sub_Profile3_Country, string Sub_Profile3_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile3 SET  Sub_Profile3_Title='" + Sub_Profile3_Title + "',Sub_Profile3_Fname='" + Sub_Profile3_Fname + "',Sub_Profile3_Lname='" + Sub_Profile3_Lname + "',Sub_Profile3_DOB='" + Sub_Profile3_DOB + "',Sub_Profile3_Nationality='" + Sub_Profile3_Nationality + "',Sub_Profile3_Country='" + Sub_Profile3_Country + "',Sub_Profile3_Age='" + Sub_Profile3_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile3 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateSubProfile4(string ProfileID, string Sub_Profile4_Title, string Sub_Profile4_Fname, string Sub_Profile4_Lname, string Sub_Profile4_DOB, string Sub_Profile4_Nationality, string Sub_Profile4_Country, string Sub_Profile4_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile4 SET  Sub_Profile4_Title='" + Sub_Profile4_Title + "',Sub_Profile4_Fname='" + Sub_Profile4_Fname + "',Sub_Profile4_Lname='" + Sub_Profile4_Lname + "',Sub_Profile4_DOB='" + Sub_Profile4_DOB + "',Sub_Profile4_Nationality='" + Sub_Profile4_Nationality + "',Sub_Profile4_Country='" + Sub_Profile4_Country + "',Sub_Profile4_Age='" + Sub_Profile4_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile4 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateProfileAddress(string ProfileID, string Profile_Address_Line1, string Profile_Address_Line2, string Profile_Address_State, string Profile_Address_city, string Profile_Address_Postcode,string acountry)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Address SET  Profile_Address_Line1='" + Profile_Address_Line1 + "',Profile_Address_Line2='" + Profile_Address_Line2 + "',Profile_Address_State='" + Profile_Address_State + "',Profile_Address_city='" + Profile_Address_city + "',Profile_Address_Postcode='" + Profile_Address_Postcode + "',Profile_Address_Country='" + acountry + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE Profile_Address Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Address Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }
    
 

    public static int UpdatePhone(string ProfileID, string Primary_CC, string Primary_Mobile, string Primary_Alt_CC, string Primary_Alternate, string Secondary_CC, string Secondary_Mobile, string Secondary_Alt_CC, string Secondary_Alternate, string Subprofile1_CC, string Subprofile1_Mobile, string Subprofile1_Alt_CC, string Subprofile1_Alternate, string Subprofile2_CC, string Subprofile2_Mobile, string Subprofile2_Alt_CC, string Subprofile2_Alternate, string Subprofile3_CC, string Subprofile3_Mobile, string Subprofile4_CC, string Subprofile4_Mobile, string Subprofile3_Alt_CC, string Subprofile3_Alternate, string Subprofile4_Alt_CC, string Subprofile4_Alternate)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())                       

        {
            try
            {

                SqlCommand scd = new SqlCommand("update Phone SET Primary_CC= '" + Primary_CC + "',Primary_Mobile='" + Primary_Mobile + "',	Primary_Alt_CC='" + Primary_Alt_CC + "',	Primary_Alternate='" + Primary_Alternate + "',	Secondary_CC='" + Secondary_CC + "',	Secondary_Mobile='" + Secondary_Mobile + "',	Secondary_Alt_CC='" + Secondary_Alt_CC + "',	Secondary_Alternate='" + Secondary_Alternate + "',	Subprofile1_CC='" + Subprofile1_CC + "',	Subprofile1_Mobile='" + Subprofile1_Mobile + "',	Subprofile1_Alt_CC='" + Subprofile1_Alt_CC + "',	Subprofile1_Alternate='" + Subprofile1_Alternate + "',	Subprofile2_CC='" + Subprofile2_CC + "',	Subprofile2_Mobile='" + Subprofile2_Mobile + "',	Subprofile2_Alt_CC='" + Subprofile2_Alt_CC + "',	Subprofile2_Alternate='" + Subprofile2_Alternate + "',	Subprofile3_CC='" + Subprofile3_CC + "',	Subprofile3_Mobile='" + Subprofile3_Mobile + "',	Subprofile3_Alt_CC='" + Subprofile3_Alt_CC + "',	Subprofile3_Alternate='" + Subprofile3_Alternate + "',	Subprofile4_CC='" + Subprofile4_CC + "',	Subprofile4_Mobile='" + Subprofile4_Mobile + "',	Subprofile4_Alt_CC='" + Subprofile4_Alt_CC + "',	Subprofile4_Alternate='" + Subprofile4_Alternate + "'  where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE Phone Query " + ex.Message);
                string msg = "Error in UPDATE Phone Query" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    


    public static int UpdateEmail(string ProfileID, string Primary_Email, string Secondary_Email, string Subprofile1_Email, string Subprofile2_Email, string Primary_Email2, string Secondary_Email2, string Subprofile1_Email2, string Subprofile2_Email2, string Subprofile3_Email, string Subprofile3_Email2, string Subprofile4_Email, string Subprofile4_Email2)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {
                SqlCommand scd = new SqlCommand("update Email SET Primary_Email= '" + Primary_Email + "',	Secondary_Email= '" + Secondary_Email + "',	Subprofile1_Email= '" + Subprofile1_Email + "',	Subprofile2_Email= '" + Subprofile2_Email + "', Primary_Email2= '" + Primary_Email2 + "',	Secondary_Email2= '" + Secondary_Email2 + "',	Subprofile1_Email2= '" + Subprofile1_Email2 + "',	Subprofile2_Email2= '" + Subprofile2_Email2 +  "',	Subprofile3_Email= '" + Subprofile3_Email + "',	Subprofile3_Email2= '" + Subprofile3_Email2+ "',	Subprofile4_Email= '" + Subprofile4_Email + "',	Subprofile4_Email2= '" + Subprofile4_Email2 +  "' where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Email Query " + ex.Message);

                string msg = "Error in UPDATE Email Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateProfileStay(string ProfileID, string Profile_Stay_Resort_Name, string Profile_Stay_Resort_Room_Number, string Profile_Stay_Arrival_Date, string Profile_Stay_Departure_Date)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Stay SET  Profile_Stay_Resort_Name= '" + Profile_Stay_Resort_Name + "',Profile_Stay_Resort_Room_Number = '" + Profile_Stay_Resort_Room_Number + "',Profile_Stay_Arrival_Date = '" + Profile_Stay_Arrival_Date + "',Profile_Stay_Departure_Date = '" + Profile_Stay_Departure_Date + "' where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE Profile_Stay Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                string msg = "Error in UPDATE Profile_Stay Query " + " " + ex.Message;

                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateTourDetails(string ProfileID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {

                SqlCommand scd = new SqlCommand("update Tour_Details SET  Tour_Details_Guest_Status= '" + Tour_Details_Guest_Status + "',	Tour_Details_Guest_Sales_Rep= '" + Tour_Details_Guest_Sales_Rep + "',	Tour_Details_Tour_Date= '" + Tour_Details_Tour_Date + "',	Tour_Details_Sales_Deck_Check_In= '" + Tour_Details_Sales_Deck_Check_In + "',	Tour_Details_Sales_Deck_Check_Out= '" + Tour_Details_Sales_Deck_Check_Out + "',	Tour_Details_Taxi_In_Price= '" + Tour_Details_Taxi_In_Price + "',	Tour_Details_Taxi_In_Ref= '" + Tour_Details_Taxi_In_Ref + "',	Tour_Details_Taxi_Out_Price= '" + Tour_Details_Taxi_Out_Price + "',	Tour_Details_Taxi_Out_Ref= '" + Tour_Details_Taxi_Out_Ref + "'where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in UPDATE Tour_Details Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static SqlDataReader GetUserData(string user)
    {
        SqlDataReader dr;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            SqlCommand scd = new SqlCommand ("select * from user_group_access ug join users u on u.[Group Id] = ug.[Group Id]where u.username =@user ", cs2);
            scd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            dr = scd.ExecuteReader();

        }
        return dr;
    }
    public static DataSet LoadSalutations()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
             SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active' order by 1", cs1);
         
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadPrimarySalutation(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active'  and Salutation not in(select Profile_Primary_Title  from Profile_Primary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSecondarySalutation(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active'  and Salutation not in(select Profile_Secondary_Title  from Profile_Secondary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile1Salutation(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active'  and Salutation not in(select Sub_Profile1_Title  from Sub_Profile1 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile2Salutation(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active'  and Salutation not in(select Sub_Profile2_Title  from Sub_Profile2 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadContractType(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select ContractType_name  from  ContractType  where ContractType_Status='Active' and office=@office", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadPrimaryNationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Nationality_Name from  Nationality    where Nationality_Name  not in(select Profile_Primary_Nationality  from Profile_Primary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSecondaryNationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Nationality_Name from  Nationality    where Nationality_Name not in(select Profile_Secondary_Nationality  from Profile_Secondary where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile1Nationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Nationality_Name from  Nationality    where Nationality_Name not in(select Sub_Profile1_Nationality  from Sub_Profile1 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSub_Profile2Nationality(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Nationality_Name from  Nationality    where Nationality_Name not in(select Sub_Profile2_Nationality  from Sub_Profile2 where Profile_ID=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    
    //public static DataSet LoadAffiliationType(string office)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        SqlCommand SqlCmd = new SqlCommand("select Affiliation_Type_name  from AffiliationType where Affiliation_Type_Status='Active' and office=@office", cs1);
    //        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}
    public static SqlDataReader LoadAffiliationType(string office)//,string curr)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select AffiliationType_ID, Affiliation_Type_name,Affiliation_Type_Amt  from AffiliationType where Affiliation_Type_Status='Active' and office=@office", cs1);// and Affiliation_Type_Currency=@curr", cs1);
        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
     //   SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
        SqlDataReader dr = SqlCmd.ExecuteReader();
        return dr;
    }
    public static DataSet LoadPointsClub(string office,string venueid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct Contract_Club_Name from contract_club where Contract_Club_Status = 'Active' and office =@office and  Venue_ID=@venueid order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@venueid", SqlDbType.VarChar).Value = venueid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadPaymentMethod(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  pay_method_name from pay_method where pay_method_status='Active' and office=@office order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadDepositPaymentMethod(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Deposit_pay_method_name from Deposit_Pay_Method where Deposit_pay_method_status='Active' and office=@office order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static String GetdeptID(string off)
    {
        string dept = null;
        string startvalue = "D00";
        int id = 0;
        int chek = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            SqlCommand scd = new SqlCommand("select count(*) from department", cs1);
            chek = (int)scd.ExecuteScalar();
            if (chek == 0)
            {
                id = 1;
                dept = startvalue + id;
            }
            else
            {
                id = chek + 1;
                dept = startvalue + id;
            }

        }
        return dept;
    }

    public static string GetLastYr(string firstyr, string tenure)
    {
        string last;
        using (SqlConnection cs = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select LastYear  from Occupancy where StartYear=@firstyr and tenure=@tenure and status='active',cs1 ");
            scd.Parameters.Add("@firstyr", SqlDbType.VarChar).Value = firstyr;
            scd.Parameters.Add("@tenure", SqlDbType.VarChar).Value = tenure;
            last = (string)scd.ExecuteScalar();
        }
        return last;
    }
    public static DataSet LoadMembershipEntitlement()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Entitlement_Name from Entitlement where  Entitlement_Status='active' order by 1", cs1);
           
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
   /* public static DataSet LoadPointsContract(string Currency)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
              SqlCommand SqlCmd = new SqlCommand("select * from PointsContract where Currency=@Currency and status='active'", cs1);
        //    SqlCommand SqlCmd = new SqlCommand("select Amount from PointsContract where Currency=@Te  status='active'", cs1);
         SqlCmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }*/

    public static SqlDataReader LoadPointsContract(string Currency)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select amount,taxValue from PointsContract where Currency=@Currency and status='active'", cs1);
        SqlCmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
        SqlDataReader dr = SqlCmd.ExecuteReader();
        return dr;
    }

    public static DataSet LoadEmploymentStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Name  from EmploymentStatus  where  Status='Active'", cs1); 
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadMaritalStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select MaritalStatus  from MaritalStatus  where  Status='Active'", cs1);
            
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadEmploymentStatusNotInProfile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select Name  from EmploymentStatus  where  Status='Active' and Name not in(select Profile_Employment_status from profile where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadMaritalStatusNotInProfile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select MaritalStatus  from MaritalStatus  where  Status='Active' and MaritalStatus not in(select Profile_Marital_status from profile where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadGuestStatusInProfile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Guest_Status_name  from Guest_Status where Guest_Status_Status ='Active'  and Guest_Status_name not in(select Tour_Details_Guest_Status from Tour_Details  where profile_id=@ProfileID) ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSalesRepsInProfile(string office, string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

             SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where office=@office   and Sales_Rep_Status='Active' and Sales_Rep_Name not in (select Tour_Details_Guest_Sales_Rep from Tour_Details  where profile_id=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
             
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSalesRepsInProfile1(string office, string ProfileID, string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where office=@office and venue=@venue and Sales_Rep_Status='Active' and Sales_Rep_Name not in (select Tour_Details_Guest_Sales_Rep from Tour_Details  where profile_id=@ProfileID)", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static int InsertGiftOption(string Gift_ID,  string Gift_ID_Option, string Gift_Voucher_numb, string Gift_Comment, string Profile_ID, string GiftItem)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Gift values(@Gift_ID,	@Gift_ID_Option,@Gift_Voucher_numb,	@Gift_Comment,@Profile_ID,@GiftItem)", cs1);
                da.InsertCommand.Parameters.Add("@Gift_ID", SqlDbType.VarChar).Value = Gift_ID;
                da.InsertCommand.Parameters.Add("@Gift_ID_Option", SqlDbType.VarChar).Value = Gift_ID_Option;
                da.InsertCommand.Parameters.Add("@Gift_Voucher_numb", SqlDbType.VarChar).Value = Gift_Voucher_numb;
                da.InsertCommand.Parameters.Add("@Gift_Comment", SqlDbType.VarChar).Value = Gift_Comment;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@GiftItem", SqlDbType.VarChar).Value = GiftItem;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Gift Query " + ex.Message);

                string msg = "Error in Insert Gift Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static String GetProfileGift(string startvalue)//(string off)
    {
        string PProfileID = null;
        //string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "G";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /*  if (off == "INDIA" || off == "India")
              {
                  startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Gift_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PProfileID = initial + startvalue + year + id;
                
                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Gift_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select Gift_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                PProfileID = initial + startvalue + year + id;
              
                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Gift_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }
            


        }

        return PProfileID;
    }
    public static DataSet LoadFinanceMethod(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Finance_Name  from FinanceMethod where office=@office and Finance_Status='Active' ", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
  
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSeason()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select season_name from Seasons where season_status='Active' order by 1 ", cs1);          
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static SqlDataReader ContractNoGeneration(string venue,string grpname,string contractname)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct Contract_Club_Name,vg.Venue_group_Code from contract_club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID=vg.Venue_ID  where  v.Venue_Name = '" + venue + "' and vg.Venue_Group_Name = '" + grpname + "' and cc.Contract_Club_Name = '" + contractname + "' and cc.Contract_Club_Status = 'Active'", cs1);
      //  SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@grpname", SqlDbType.VarChar).Value = grpname;
        SqlCmd.Parameters.Add("@contractname", SqlDbType.VarChar).Value = contractname;
        SqlDataReader dr = SqlCmd.ExecuteReader();
    
        return dr;
    }
    public static SqlDataReader LoadVenueonVCountry(string venuecountry)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select Venue_Name  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID   where vc.Venue_Country_Name = @venuecountry", cs1);
        SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
        //   SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
   
        return dr;
    }
    public static SqlDataReader GetIncrementValueofContractClubIndian(string venue,string venuegrp,string club,string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        //  SqlCommand SqlCmd = new SqlCommand(" select distinct cc.Contract_Code,vg.Venue_group_Code,cc.increment_value from contract_club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where cc.Contract_Club_Status = 'Active' and v.Venue_Name = @venue and vg.Venue_Group_Name = @venuegrp and Contract_Club_Name = @club and    cc.nationality=@nationality", cs1);
        SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name = @venue and cc.Contract_Club_Name = @club and vg.Venue_Group_Name = @venuegrp and cc.Nationality = 'Indian'", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
       SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
        SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
        
        SqlDataReader dr = SqlCmd.ExecuteReader();
     
        return dr;
    }
    public static SqlDataReader GetIncrementValueofContractClubNonIndian(string venue, string venuegrp, string club,string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        //   SqlCommand SqlCmd = new SqlCommand(" select distinct cc.Contract_Code,vg.Venue_group_Code,cc.increment_value from contract_club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where cc.Contract_Club_Status = 'Active' and v.Venue_Name = @venue and vg.Venue_Group_Name = @venuegrp and Contract_Club_Name = @club and    cc.nationality=@nationality", cs1);
        SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name = @venue and cc.Contract_Club_Name = @club and vg.Venue_Group_Name = @venuegrp and cc.Nationality != 'Indian'", cs1);

        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@venuegrp", SqlDbType.VarChar).Value = venuegrp;
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
        SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;

        SqlDataReader dr = SqlCmd.ExecuteReader();
      
        return dr;
    }
    //public static int InsertContractDetails_Indian(string ContractNo, string ProfileID, string Sales_Rep, string TO_Manager, string ButtonUp_Officer, string DealRegistered_Date, string DealStatus, string Contract_CreatedDate, string Contract_UpdatedDate, string ContractType, string MCWaiver, string Finance_Details, string Contract_Remark, string Pan_Card, string Adhar_Card,string MC_Charges,string First_MC_Payable_Date,string MemberFee)
    //{
    //    int rowsAffected = 0;
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        try
    //        {
    //            da.InsertCommand = new SqlCommand("insert into ContractDetails_Indian values(@ContractNo,	@ProfileID ,@Sales_Rep ,	@TO_Manager ,	@ButtonUp_Officer ,	@DealRegistered_Date,	@DealStatus ,	@Contract_CreatedDate,	@Contract_UpdatedDate,	@ContractType ,	@MCWaiver,	@Finance_Details ,	@Contract_Remark ,	@Pan_Card ,	@Adhar_Card,@MC_Charges, @First_MC_Payable_Date,@MemberFee)", cs1);
    //            da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
    //            da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
    //            da.InsertCommand.Parameters.Add("@Sales_Rep ", SqlDbType.VarChar).Value = Sales_Rep;
    //            da.InsertCommand.Parameters.Add("@TO_Manager ", SqlDbType.VarChar).Value = TO_Manager;
    //            da.InsertCommand.Parameters.Add("@ButtonUp_Officer ", SqlDbType.VarChar).Value = ButtonUp_Officer;
    //            da.InsertCommand.Parameters.Add("@DealRegistered_Date", SqlDbType.VarChar).Value = DealRegistered_Date;
    //            da.InsertCommand.Parameters.Add("@DealStatus ", SqlDbType.VarChar).Value = DealStatus;
    //            da.InsertCommand.Parameters.Add("@Contract_CreatedDate", SqlDbType.VarChar).Value = Contract_CreatedDate;
    //            da.InsertCommand.Parameters.Add("@Contract_UpdatedDate", SqlDbType.VarChar).Value = Contract_UpdatedDate;
    //            da.InsertCommand.Parameters.Add("@ContractType ", SqlDbType.VarChar).Value = ContractType;
    //            da.InsertCommand.Parameters.Add("@MCWaiver", SqlDbType.VarChar).Value = MCWaiver;
    //            da.InsertCommand.Parameters.Add("@Finance_Details", SqlDbType.VarChar).Value = Finance_Details;
    //            da.InsertCommand.Parameters.Add("@Contract_Remark", SqlDbType.VarChar).Value = Contract_Remark;
    //            da.InsertCommand.Parameters.Add("@Pan_Card", SqlDbType.VarChar).Value = Pan_Card;
    //            da.InsertCommand.Parameters.Add("@Adhar_Card", SqlDbType.VarChar).Value = Adhar_Card;
    //            da.InsertCommand.Parameters.Add("@MC_Charges", SqlDbType.VarChar).Value = MC_Charges;
    //            da.InsertCommand.Parameters.Add("@First_MC_Payable_Date", SqlDbType.VarChar).Value = First_MC_Payable_Date;
    //            da.InsertCommand.Parameters.Add("@MemberFee", SqlDbType.VarChar).Value = MemberFee;

    //            rowsAffected = da.InsertCommand.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {

    //            //MessageBox.Show("Error in Insert ContractDetails_Indian Query " + ex.Message);

    //            string msg = "Error in Insert ContractDetails_Indian Query " + " " + ex.Message;

    //            throw new Exception(msg, ex);

    //            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
    //        }
    //    }
    //    return (rowsAffected);
    //}
    public static int InsertContract_Points_Indian(string ContractPoints_ID, string ProfileID, string ContractNo, string club, string New_points_rights, string Type_membership, string Total_points_rights, string First_year_occupancy, string Tenure, string Last_year_occupancy)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Points_Indian values(@ContractPoints_ID ,	@ProfileID ,	@ContractNo ,	@club,	@New_points_rights,	@Type_membership,	@Total_points_rights,	@First_year_occupancy,	@Tenure,	@Last_year_occupancy )", cs1);
                da.InsertCommand.Parameters.Add("@ContractPoints_ID ", SqlDbType.VarChar).Value = ContractPoints_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                da.InsertCommand.Parameters.Add("@New_points_rights", SqlDbType.VarChar).Value = New_points_rights;
                da.InsertCommand.Parameters.Add("@Type_membership", SqlDbType.VarChar).Value = Type_membership;
                da.InsertCommand.Parameters.Add("@Total_points_rights", SqlDbType.VarChar).Value = Total_points_rights;
                da.InsertCommand.Parameters.Add("@First_year_occupancy", SqlDbType.VarChar).Value = First_year_occupancy;
                da.InsertCommand.Parameters.Add("@Tenure", SqlDbType.VarChar).Value = Tenure;
                da.InsertCommand.Parameters.Add("@Last_year_occupancy ", SqlDbType.VarChar).Value = Last_year_occupancy;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Points_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static int InsertFinance_Details_Indian(string Finance_Details_Id, string ProfileID, string ContractNo, string Finance_Method, string Currency, string Affiliate_Type, string Total_Price_Including_Tax, string Initial_Deposit_Percent, string Initial_Deposit_Amount, string Balance_Payable, string Total_Inital_Deposit, string Initial_Deposit_Balance, string Bal_Amount_Payable, string Payment_Method, string No_Installments, string Installment_Amount, string Finance_Type, string Finance_No, string IGSTrate, string Interestrate, string documentationfee, string IGST_Amount, string No_Emi, string Emi_Installment,string financeMonth)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Finance_Details_Indian values(@Finance_Details_Id,@ProfileID,@ContractNo,@Finance_Method,@Currency,	@Affiliate_Type ,	@Total_Price_Including_Tax ,	@Initial_Deposit_Percent  ,	@Initial_Deposit_Amount  ,	@Balance_Payable  ,	@Total_Inital_Deposit  ,	@Initial_Deposit_Balance,	@Bal_Amount_Payable,@Payment_Method,@No_Installments,@Installment_Amount,@Finance_Type,@Finance_No,	@IGSTrate ,	@Interestrate ,	@documentationfee ,	@IGST_Amount,@No_Emi,@Emi_Installment,@financeMonth)", cs1);
                da.InsertCommand.Parameters.Add("@Finance_Details_Id ", SqlDbType.VarChar).Value = Finance_Details_Id;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Finance_Method ", SqlDbType.VarChar).Value = Finance_Method;
                da.InsertCommand.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;
                da.InsertCommand.Parameters.Add("@Affiliate_Type", SqlDbType.VarChar).Value = Affiliate_Type;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Percent", SqlDbType.VarChar).Value = Initial_Deposit_Percent;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Amount", SqlDbType.VarChar).Value = Initial_Deposit_Amount;
                da.InsertCommand.Parameters.Add("@Balance_Payable", SqlDbType.VarChar).Value = Balance_Payable;
                da.InsertCommand.Parameters.Add("@Total_Inital_Deposit", SqlDbType.VarChar).Value = Total_Inital_Deposit;
                da.InsertCommand.Parameters.Add("@Initial_Deposit_Balance", SqlDbType.VarChar).Value = Initial_Deposit_Balance;
                da.InsertCommand.Parameters.Add("@Bal_Amount_Payable", SqlDbType.VarChar).Value = Bal_Amount_Payable;
                da.InsertCommand.Parameters.Add("@Payment_Method", SqlDbType.VarChar).Value = Payment_Method;
                da.InsertCommand.Parameters.Add("@No_Installments", SqlDbType.VarChar).Value = No_Installments;
                da.InsertCommand.Parameters.Add("@Installment_Amount", SqlDbType.VarChar).Value = Installment_Amount;
                da.InsertCommand.Parameters.Add("@Finance_Type", SqlDbType.VarChar).Value = Finance_Type;
                da.InsertCommand.Parameters.Add("@Finance_No", SqlDbType.VarChar).Value = Finance_No;
                da.InsertCommand.Parameters.Add("@IGSTrate", SqlDbType.VarChar).Value = IGSTrate;
                da.InsertCommand.Parameters.Add("@Interestrate", SqlDbType.VarChar).Value = Interestrate;
                da.InsertCommand.Parameters.Add("@documentationfee", SqlDbType.VarChar).Value = documentationfee;
                da.InsertCommand.Parameters.Add("@IGST_Amount", SqlDbType.VarChar).Value = IGST_Amount;
                da.InsertCommand.Parameters.Add("@No_Emi", SqlDbType.VarChar).Value = No_Emi;
                da.InsertCommand.Parameters.Add("@Emi_Installment", SqlDbType.VarChar).Value = Emi_Installment;
                da.InsertCommand.Parameters.Add("@financeMonth", SqlDbType.VarChar).Value = financeMonth;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Finance_Details_Indian Query " + ex.Message);

                string msg = "Error in Insert Finance_Details_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static int InsertContract_PA_Indian(string Contract_PA_Id, string ProfileID, string ContractNo, string New_Points_Price, string Conversion_Fee, string Admin_Fee, string Total_Purchase_Price, string Cgst, string Sgst, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_PA_Indian values(@Contract_PA_Id,@ProfileID,@ContractNo ,@New_Points_Price,@Conversion_Fee,	@Admin_Fee ,@Total_Purchase_Price ,	@Cgst ,	@Sgst ,	@Total_Price_Including_Tax ,@Deposit ,	@Balance,	@Balance_Due_Dates,	@Remarks)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_PA_Id ", SqlDbType.VarChar).Value = Contract_PA_Id;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@New_Points_Price ", SqlDbType.VarChar).Value = New_Points_Price;
                da.InsertCommand.Parameters.Add("@Conversion_Fee", SqlDbType.VarChar).Value = Conversion_Fee;
                da.InsertCommand.Parameters.Add("@Admin_Fee", SqlDbType.VarChar).Value = Admin_Fee;
                da.InsertCommand.Parameters.Add("@Total_Purchase_Price", SqlDbType.VarChar).Value = Total_Purchase_Price;
                da.InsertCommand.Parameters.Add("@Cgst", SqlDbType.VarChar).Value = Cgst;
                da.InsertCommand.Parameters.Add("@Sgst", SqlDbType.VarChar).Value = Sgst;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Deposit ", SqlDbType.VarChar).Value = Deposit;
                da.InsertCommand.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
                da.InsertCommand.Parameters.Add("@Balance_Due_Dates", SqlDbType.VarChar).Value = Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in Insert Contract_PA_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static string GetInstallmentInvoiceNo(string office)
    {
        string InvoiceNo;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select startval+midval+smidval+ cast (endval as varchar(50)) from Finance_install_ID where office=@office", cs1);
            scd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            InvoiceNo = (string)scd.ExecuteScalar();
        }
        return InvoiceNo;

    }
    public static int UpdateInstallmentInvoiceNo(string office)
    {
        int rows = 0;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand(" update Finance_install_ID set endval = endval + 1 where office =@office", cs1);
                sqlcmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE Finance_install_ID Query " + ex.Message);

                string msg = "Error in UPDATE Finance_install_ID Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }


    public static int InsertContract_Installments_Indian(string ProfileID, string ContractNo, string Installment_no, string Installment_Amount, string Installment_Date,string Installment_Invoice_No)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Installments_Indian values(@ProfileID,	@ContractNo,@Installment_no,@Installment_Amount,@Installment_Date,@Installment_Invoice_No)", cs1);
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Installment_no", SqlDbType.VarChar).Value = Installment_no;
                da.InsertCommand.Parameters.Add("@Installment_Amount", SqlDbType.VarChar).Value = Installment_Amount;
                da.InsertCommand.Parameters.Add("@Installment_Date", SqlDbType.VarChar).Value = Installment_Date;
                da.InsertCommand.Parameters.Add("@Installment_Invoice_No", SqlDbType.VarChar).Value = Installment_Invoice_No;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Trade_In_Points_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Trade_In_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static string GetContract_Points_Indian()
    {
        string Contract_Points_Indian = "";
        string startvalue = "CPI";
        int id = 0;      
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractPoints_ID, 4, len(ContractPoints_ID)))from Contract_Points_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Contract_Points_Indian = startvalue + id;
                }
                else
                {
                    id = 1;
                    Contract_Points_Indian = startvalue + id;

                }

            }
        }
        return Contract_Points_Indian;


    }

    public static string GetFinance_Details_Indian()
    {
        string Finance_Details_Id = "";
        string startvalue = "FD_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Finance_Details_Id, 6, len(Finance_Details_Id)))from Finance_Details_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Finance_Details_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    Finance_Details_Id = startvalue + id;

                }

            }
        }
        return Finance_Details_Id;


    }
    public static string GetContract_PA_Indian()
    {
        string Contract_PA_Id = "";
        string startvalue = "PA_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Contract_PA_Id, 6, len(Contract_PA_Id)))from Contract_PA_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Contract_PA_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    Contract_PA_Id = startvalue + id;

                }

            }
        }
        return Contract_PA_Id;


    }
    
    public static int UpdateContractNo(string venue, string club, string nationality)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select cc.increment_value from contract_club  cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name =@venue and Contract_Club_Name = @club and    cc.nationality = @nationality", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from contract_club cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name = @venue  and Contract_Club_Name = @club and    cc.nationality = @nationality", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE contract_club Query " + ex.Message);

                string msg = "Error in UPDATE contract_club Query " + " " + ex.Message;

                throw new Exception(msg, ex);


                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
  
    public static int UpdateContractNoInd(string venue, string club)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select cc.increment_value from contract_club  cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name =@venue and Contract_Club_Name = @club and    cc.nationality ='Indian'", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from contract_club cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name = @venue  and Contract_Club_Name = @club and    cc.nationality = 'Indian'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //  sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE contract_club Query " + ex.Message);

                string msg = "Error in UPDATE contract_club Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateContractNoNInd(string venue, string club)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select cc.increment_value from contract_club  cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name =@venue and Contract_Club_Name = @club and    cc.nationality != 'Indian'", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //  scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from contract_club cc join venue v on v.Venue_ID = cc.Venue_ID where  Contract_Club_Status = 'Active' and v.Venue_Name = @venue  and Contract_Club_Name = @club and    cc.nationality  != 'Indian'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE contract_club Query " + ex.Message);

                string msg = "Error in UPDATE contract_club Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateResortNoInd(string venue, string club)//, string nationality)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Increment_Value from Contract_ResortCode_Generation   where    Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue =@venue and Nationality ='Indian'", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from Contract_ResortCode_Generation cc  where    cc.Contract_Resort_Name=@club and cc.Contract_Resort_Status = 'active' and cc.venue =@venue and cc.Nationality ='Indian'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //   sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Contract_ResortCode_Generation Query " + ex.Message);

                string msg = "Error in UPDATE Contract_ResortCode_Generation Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static int UpdateResortNoNonInd(string venue, string club)//, string nationality)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select Increment_Value from Contract_ResortCode_Generation   where    Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue =@venue and Nationality !='Indian'", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                // scd1.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.Increment_Value=@id from Contract_ResortCode_Generation cc  where    cc.Contract_Resort_Name=@club and cc.Contract_Resort_Status = 'active' and cc.venue =@venue and cc.Nationality !='Indian'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
                //   sqlcmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE Contract_ResortCode_Generation Query " + ex.Message);

                string msg = "Error in UPDATE Contract_ResortCode_Generation Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static string GetContract_Trade_In_Points_Indian()
    {
        string ContractTradeInPoint_ID = "";
        string startvalue = "CTIP";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractTradeInPoint_ID, 5, len(ContractTradeInPoint_ID)))from Contract_Trade_In_Points_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractTradeInPoint_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractTradeInPoint_ID = startvalue + id;

                }

            }
        }
        return ContractTradeInPoint_ID;


    }

    public static int InsertContract_Trade_In_Points_Indian(string ContractTradeInPoint_ID, string ProfileID, string ContractNo, string Trade_In_Details_club_resort, string Trade_In_Details_No_rights, string Trade_In_Details_ContNo_RCINo, string Trade_In_Details_Points_value, string New_Club, string New_Club_Points_Rights, string New_MemebrshipType, string New_TotalPointsRights, string New_First_year_occupancy, string New_Tenure, string New_Last_year_occupancy)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Trade_In_Points_Indian values(@ContractTradeInPoint_ID,	@ProfileID,	@ContractNo,	@Trade_In_Details_club_resort,	@Trade_In_Details_No_rights,	@Trade_In_Details_ContNo_RCINo,	@Trade_In_Details_Points_value,	@New_Club,	@New_Club_Points_Rights,	@New_MemebrshipType,	@New_TotalPointsRights,	@New_First_year_occupancy,	@New_Tenure,	@New_Last_year_occupancy)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTradeInPoint_ID", SqlDbType.VarChar).Value = ContractTradeInPoint_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_club_resort", SqlDbType.VarChar).Value = Trade_In_Details_club_resort;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_No_rights", SqlDbType.VarChar).Value = Trade_In_Details_No_rights;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_ContNo_RCINo", SqlDbType.VarChar).Value = Trade_In_Details_ContNo_RCINo;
                da.InsertCommand.Parameters.Add("@Trade_In_Details_Points_value", SqlDbType.VarChar).Value = Trade_In_Details_Points_value;
                da.InsertCommand.Parameters.Add("@New_Club", SqlDbType.VarChar).Value = New_Club;
                da.InsertCommand.Parameters.Add("@New_Club_Points_Rights", SqlDbType.VarChar).Value = New_Club_Points_Rights;
                da.InsertCommand.Parameters.Add("@New_MemebrshipType", SqlDbType.VarChar).Value = New_MemebrshipType;
                da.InsertCommand.Parameters.Add("@New_TotalPointsRights", SqlDbType.VarChar).Value = New_TotalPointsRights;
                da.InsertCommand.Parameters.Add("@New_First_year_occupancy", SqlDbType.VarChar).Value = New_First_year_occupancy;
                da.InsertCommand.Parameters.Add("@New_Tenure", SqlDbType.VarChar).Value = New_Tenure;
                da.InsertCommand.Parameters.Add("@New_Last_year_occupancy", SqlDbType.VarChar).Value = New_Last_year_occupancy;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in Insert Contract_Trade_In_Points_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Trade_In_Points_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static string GetContract_Trade_In_Weeks_Indian()
    {
        string ContractTradeInWeeks_ID = "";
        string startvalue = "CTIW";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractTradeInWeeks_ID, 5, len(ContractTradeInWeeks_ID)))from Contract_Trade_In_Weeks_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractTradeInWeeks_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractTradeInWeeks_ID = startvalue + id;

                }

            }
        }
        return ContractTradeInWeeks_ID;


    }

    public static int InsertContract_Trade_In_Weeks_Indian(String ContractTradeInWeeks_ID, String ProfileID, String ContractNo, String Trade_In_Weeks_resort, String Trade_In_Weeks_Apt, string Trade_In_Weeks_Season,String Trade_In_Weeks_NoWks, String Trade_In_Weeks_ContNo_RCINo, String Trade_In_Weeks_Points_value, String NewPointsW_Club, String NewPointsW_Club_Points_Rights, String NewPointsW_MemebrshipType, String NewPointsW_Total_Points_rights, String NewPointsW_First_year_occupancy, String NewPointsW_Tenure, String NewPointsW_Last_year_occupancy)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Trade_In_Weeks_Indian values(@ContractTradeInWeeks_ID,	@ProfileID,	@ContractNo,	@Trade_In_Weeks_resort,	@Trade_In_Weeks_Apt ,@Trade_In_Weeks_Season,	@Trade_In_Weeks_NoWks,	@Trade_In_Weeks_ContNo_RCINo,	@Trade_In_Weeks_Points_value,	@NewPointsW_Club ,	@NewPointsW_Club_Points_Rights ,	@NewPointsW_MemebrshipType ,	@NewPointsW_Total_Points_rights ,	@NewPointsW_First_year_occupancy,	@NewPointsW_Tenure,	@NewPointsW_Last_year_occupancy)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTradeInWeeks_ID ", SqlDbType.VarChar).Value = ContractTradeInWeeks_ID;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_resort", SqlDbType.VarChar).Value = Trade_In_Weeks_resort;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Apt ", SqlDbType.VarChar).Value = Trade_In_Weeks_Apt;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Season", SqlDbType.VarChar).Value = Trade_In_Weeks_Season;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_NoWks ", SqlDbType.VarChar).Value = Trade_In_Weeks_NoWks;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_ContNo_RCINo", SqlDbType.VarChar).Value = Trade_In_Weeks_ContNo_RCINo;
                da.InsertCommand.Parameters.Add("@Trade_In_Weeks_Points_value", SqlDbType.VarChar).Value = Trade_In_Weeks_Points_value;
                da.InsertCommand.Parameters.Add("@NewPointsW_Club ", SqlDbType.VarChar).Value = NewPointsW_Club;
                da.InsertCommand.Parameters.Add("@NewPointsW_Club_Points_Rights ", SqlDbType.VarChar).Value = NewPointsW_Club_Points_Rights;
                da.InsertCommand.Parameters.Add("@NewPointsW_MemebrshipType ", SqlDbType.VarChar).Value = NewPointsW_MemebrshipType;
                da.InsertCommand.Parameters.Add("@NewPointsW_Total_Points_rights ", SqlDbType.VarChar).Value = NewPointsW_Total_Points_rights;
                da.InsertCommand.Parameters.Add("@NewPointsW_First_year_occupancy", SqlDbType.VarChar).Value = NewPointsW_First_year_occupancy;
                da.InsertCommand.Parameters.Add("@NewPointsW_Tenure", SqlDbType.VarChar).Value = NewPointsW_Tenure;
                da.InsertCommand.Parameters.Add("@NewPointsW_Last_year_occupancy", SqlDbType.VarChar).Value = NewPointsW_Last_year_occupancy;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Trade_In_Weeks_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Trade_In_Weeks_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    public static SqlDataReader GetFinanceNoIncrementValue(string venue,string finance,string type)
    {
       
        if (type=="Fractional"||type== "Trade-In-Fractionals")
        {
            SqlConnection cs1 = Queries.GetDBConnection();
            SqlCommand SqlCmd = new SqlCommand(" select financecode+FinanceIncrval+contracttypecode  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType='Fractional'", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;        
            SqlDataReader  dr =SqlCmd.ExecuteReader();
         
            return dr;
        }
        else
        {
            SqlConnection cs1 = Queries.GetDBConnection();
            SqlCommand SqlCmd = new SqlCommand(" select financecode+FinanceIncrval+contracttypecode  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType='Non Fractional'", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            SqlDataReader dr = SqlCmd.ExecuteReader();
          
            return dr;
        }
       





    }

    public static SqlDataReader GetVgroupOnVenue(string venue)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group vg join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name =@venue and Venue_Group_Status = 'Active'", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
       
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
      
        return dr;
    }
    public static SqlDataReader GetSalesRepOnVenue(string venue,string country)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select sales_rep_name from Sales_Rep  sr    join VenueCountry vc on vc.Venue_Country_ID = sr.Venue_country_ID    where    sales_rep_status = 'Active'   and sr.venue =@venue and vc.Venue_Country_Name = @country", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
       
        return dr;
    }
    public static SqlDataReader GetSalesRepOnlyVenue(string venue)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select sales_rep_name from Sales_Rep  sr    join VenueCountry vc on vc.Venue_Country_ID = sr.Venue_country_ID    where    sales_rep_status = 'Active'   and sr.venue =@venue", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
      //  cs1.Close();
        return dr;
    }

    public static int UpdateFinanceNo(string venue, string finance)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select FinanceIncrval  from FinanceMethod_Venue where venue=@venue and FinanceMethod_Name=@finance and ContractType='Non Fractional'", cs1);
                scd1.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                scd1.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SqlCommand sqlcmd = new SqlCommand("update cc set cc.FinanceIncrval=@id from FinanceMethod_Venue cc  where  venue=@venue and FinanceMethod_Name=@finance and ContractType='Non Fractional'", cs1);
                sqlcmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                sqlcmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE FinanceMethod_Venue Query " + ex.Message);

                string msg = "Error in UPDATE FinanceMethod_Venue Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }
    public static DataSet LoadPrintPDFFiles_Indian(string ctype, string office, string club,string curr,string finance)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("   select printname from PrintPDF_Indian where Printpdf_Status='Active' and  clubname=@club and contracttype=@ctype and currency=@curr and Printpdf_Office = @office and finance=@finance", cs1);
            SqlCmd.Parameters.Add("@ctype", SqlDbType.VarChar).Value = ctype;
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
             SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@finance", SqlDbType.VarChar).Value = finance;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataTable NewPoints_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_Points_India", con);
          
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable TradeInPoints_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_TradeInPoints_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable TradeInWeeks_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_TradeInWeeks_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    public static DataTable Fractional_PA(string contractid)
    {

        using (SqlConnection con = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("PA_Fractional_India", con);

            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contractid", contractid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }
    
    public static SqlDataReader LoadAgentsOnVenue1(string venue)
    {
      
            SqlConnection cs1 = Queries.GetDBConnection();
            SqlCommand SqlCmd = new SqlCommand("select a.Agent_Name from Agent_GroupVenue ag join agent a on a.Agent_ID = ag.Agent_id where   a.Agent_Status = 'Active'and ag.venue =@venue", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
     
        return dr;

     }


  
    public static SqlDataReader LoadManagersOnVenue1(string venue)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
    
        return dr;
    }

    public static SqlDataReader LoadTOOPCOnVenue1(string venue)
    {

        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select distinct to_name from OPC_TOs where TO_Status='Active' and  Venue=@venue", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
     
        return dr;
    }
    public static SqlDataReader LoadTOOPCOnVenueNGrp(string venue)
    {

        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct TO_Manager_Name from TO_Manager where TO_Manager_Status = 'Active' and   Venue =@venue", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
    
        return dr;
    }
    public static SqlDataReader LoadMarketingProgramOnVenueNVGroup1(string venuename, string vgname)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand(" select m.Marketing_Program_Name  from Marketing_Program  m join Venue_Group vg on vg.Venue_Group_ID = m.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name =@venuename and vg.Venue_Group_Name =@vgname and m.Marketing_Program_Status = 'Active'", cs1);
            SqlCmd.Parameters.Add("@venuename", SqlDbType.VarChar).Value = venuename;
            SqlCmd.Parameters.Add("@vgname", SqlDbType.VarChar).Value = vgname;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
     
        return dr;

    }

    public static DataSet LoadFractionalResortIndia()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Contract_Resort_Name  from [Contract_Resort] where office='hml' and Contract_Resort_Status='Active'", cs1);
           // SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadFractionalResortNonIndia()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select Contract_Resort_Name  from [Contract_Resort] where office!='hml' and Contract_Resort_Status='Active'", cs1);
            // SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static SqlDataReader LoadfractionalResidencetype(string resort)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select crt.Contract_Resi_Type_Name from Contract_Residence_No crn join Contract_Resort cr on cr.Contract_Resort_ID = crn.Contract_Resort_ID join Contract_Residence_Type crt on crt.Contract_Residence_ID = crn.Contract_Residence_ID where cr.Contract_Resort_Name = @resort and crt.Contract_Resi_Type_Status = 'Active'", cs1);
        SqlCmd.Parameters.Add("@resort", SqlDbType.VarChar).Value = resort;        
        SqlDataReader dr = SqlCmd.ExecuteReader();
      
        return dr;

    }

    public static SqlDataReader LoadfractionalResidenceNo(string resort)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select crn.Contract_Residence_Name from Contract_Residence_No crn join Contract_Resort cr on cr.Contract_Resort_ID = crn.Contract_Resort_ID where cr.Contract_Resort_Name =@resort and crn.Contract_Residence_Status = 'Active'", cs1);
        SqlCmd.Parameters.Add("@resort", SqlDbType.VarChar).Value = resort;
        SqlDataReader dr = SqlCmd.ExecuteReader();
    
        return dr;

    }
    public static DataSet LoadFractionalInterest()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("SELECT Contract_Fractional_Int_Name FROM  Contract_Fractional_Int  where [Contract_Fractional_Int_Status]='Active'", cs1);
            
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadMCChart(string club, string year,string curr)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select * from ManagementCharges_Chart_India where club =@club and year =@year and status='Active' and  Currency=@curr", cs1);
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadMCChartfractional(string club, string year, string curr,string wk,string type)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select * from ManagementCharges_Chart_India where club =@club and year =@year and status='Active' and  Currency=@curr and weekno=@wk and Otype =@type", cs1);
            SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
            SqlCmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            SqlCmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = curr;
            SqlCmd.Parameters.Add("@wk", SqlDbType.VarChar).Value = wk;
            SqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type ;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static string GetContract_Fractional_PA_Indian()
    {
        string Contract_Fractional_PA_Id = "";
        string startvalue = "PAF_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Contract_Fractional_PA_Id, 7, len(Contract_Fractional_PA_Id)))from Contract_Fractional_PA_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    Contract_Fractional_PA_Id = startvalue + id;
                }
                else
                {
                    id = 1;
                    Contract_Fractional_PA_Id = startvalue + id;

                }

            }
        }
        return Contract_Fractional_PA_Id;


    }

    public static int InsertContract_Fractional_PA_Indian(string Contract_Fractional_PA_Id, string ProfileID, string ContractNo, string Admission_fees, string administration_fees, string Cgst, string Sgst, string Total_Purchase_Price, string Total_Price_Including_Tax, string Deposit, string Balance, string Balance_Due_Dates, string Remarks)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Fractional_PA_Indian values(@Contract_Fractional_PA_Id,	@ProfileID,	@ContractNo,	@Admission_fees,	@administration_fees ,	@Cgst,	@Sgst,	@Total_Purchase_Price ,	@Total_Price_Including_Tax,@Deposit,@Balance,@Balance_Due_Dates,@Remarks)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_Fractional_PA_Id ", SqlDbType.VarChar).Value = Contract_Fractional_PA_Id;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Admission_fees", SqlDbType.VarChar).Value = Admission_fees;
                da.InsertCommand.Parameters.Add("@administration_fees", SqlDbType.VarChar).Value = administration_fees;
                da.InsertCommand.Parameters.Add("@Cgst", SqlDbType.VarChar).Value = Cgst;
                da.InsertCommand.Parameters.Add("@Sgst", SqlDbType.VarChar).Value = Sgst;
                da.InsertCommand.Parameters.Add("@Total_Purchase_Price", SqlDbType.VarChar).Value = Total_Purchase_Price;
                da.InsertCommand.Parameters.Add("@Total_Price_Including_Tax", SqlDbType.VarChar).Value = Total_Price_Including_Tax;
                da.InsertCommand.Parameters.Add("@Deposit", SqlDbType.VarChar).Value = Deposit;
                da.InsertCommand.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
                da.InsertCommand.Parameters.Add("@Balance_Due_Dates", SqlDbType.VarChar).Value = Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in Insert Contract_Fractional_PA_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Fractional_PA_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static string GetContract_Fractional_Indian()
    {
        string ContractFractionalIndian_ID = "";
        string startvalue = "F_IN";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractFractionalIndian_ID, 5, len(ContractFractionalIndian_ID)))from Contract_Fractional_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractFractionalIndian_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractFractionalIndian_ID = startvalue + id;

                }

            }
        }
        return ContractFractionalIndian_ID;


    }
    public static int InsertContract_Fractional_Indian(string ContractFractionalIndian_ID, string ProfileID, string ContractNo, string resort, string residence_no, string residence_type, string fractional_interest, string entitlement, string firstyear_Occupancy, string tenure, string lastyear_Occupancy, string leaseback, string Mc_Charges)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into  Contract_Fractional_Indian values(@ContractFractionalIndian_ID,@ProfileID,@ContractNo,@resort,@residence_no,	@residence_type,@fractional_interest,	@entitlement,	@firstyear_Occupancy,	@tenure,	@lastyear_Occupancy,	@leaseback,	@Mc_Charges)", cs1);
                da.InsertCommand.Parameters.Add("@ContractFractionalIndian_ID", SqlDbType.VarChar).Value = ContractFractionalIndian_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@resort", SqlDbType.VarChar).Value = resort;
                da.InsertCommand.Parameters.Add("@residence_no", SqlDbType.VarChar).Value = residence_no;
                da.InsertCommand.Parameters.Add("@residence_type", SqlDbType.VarChar).Value = residence_type;
                da.InsertCommand.Parameters.Add("@fractional_interest", SqlDbType.VarChar).Value = fractional_interest;
                da.InsertCommand.Parameters.Add("@entitlement", SqlDbType.VarChar).Value = entitlement;
                da.InsertCommand.Parameters.Add("@firstyear_Occupancy", SqlDbType.VarChar).Value = firstyear_Occupancy;
                da.InsertCommand.Parameters.Add("@tenure", SqlDbType.VarChar).Value = tenure;
                da.InsertCommand.Parameters.Add("@lastyear_Occupancy", SqlDbType.VarChar).Value = lastyear_Occupancy;
                da.InsertCommand.Parameters.Add("@leaseback", SqlDbType.VarChar).Value = leaseback;
                da.InsertCommand.Parameters.Add("@Mc_Charges", SqlDbType.VarChar).Value = Mc_Charges;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in Insert Contract_Fractional_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    public static SqlDataReader GetIncrementValueofContractResortIndian(string venue, string club)//, string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        // SqlCommand SqlCmd = new SqlCommand("select Increment_Value from  Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality = @nationality", cs1);
        SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when Contract_Resort_Name ='Karma Hathi Mahal' then 'HM' else '' end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality = 'Indian'", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;        
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
       // SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
        SqlDataReader dr = SqlCmd.ExecuteReader();
        return dr;
    }
    public static SqlDataReader GetIncrementValueofContractResortNonIndian(string venue, string club)//, string nationality)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        //        SqlCommand SqlCmd = new SqlCommand("select Increment_Value from  Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality != @nationality", cs1);
        SqlCommand SqlCmd = new SqlCommand(" select  Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+case when Contract_Resort_Name ='Karma Hathi Mahal' then 'HM' else '' end as t  from Contract_ResortCode_Generation where Contract_Resort_Name=@club and Contract_Resort_Status = 'active' and venue = @venue and Nationality != 'Indian'", cs1);
        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        SqlCmd.Parameters.Add("@club", SqlDbType.VarChar).Value = club;
        //SqlCmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
        SqlDataReader dr = SqlCmd.ExecuteReader();
     
        return dr;
    }
    public static string  GetFinanceMonth(string contractno)
    {
        string mn;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd=new SqlCommand("select financemonth from Finance_Details_Indian where contractNo =@contractno",cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;
            mn=(string) scd.ExecuteScalar();
        }
        return mn;
    }

   
    public static int UpdatefinanceStartdate(string contractno)
    {
        int rows = 0;
      
        int mon,yr;
        string financemonth;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd1 = new SqlCommand("select max(Installment_Date) from Contract_Installments_Indian where ContractNo=@contractno", cs1);
                scd1.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;

                DateTime val = (DateTime)scd1.ExecuteScalar();
                DateTime fdat = Convert.ToDateTime(val);
                int month = fdat.Month;
                int year = fdat.Year;
                if (month == 12)
                {
                    mon = 1;
                    yr = year + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon); //CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName()
                                                                                                            // DateTime.Now.ToString("MMM", CultureInfo.CurrentCulture);
                                                                                                            //   int mno = DateTime.ParseExact(value, "MMMM", CultureInfo.CurrentCulture).Month;
                    financemonth = month1 + " " + yr;

                }
                else
                {
                    mon = month + 1;
                    string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mon);
                    financemonth = month1 + " " + year;
                }


                SqlCommand sqlcmd = new SqlCommand("UPDATE Finance_Details_Indian SET financeMonth=@financemonth where ContractNo=@contractno", cs1);
                sqlcmd.Parameters.Add("@financemonth", SqlDbType.VarChar).Value = financemonth;
                sqlcmd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = @contractno;

                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

               // MessageBox.Show("Error in UPDATE Finance_Details_Indian Query " + ex.Message);

                string msg = "Error in UPDATE Finance_Details_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }


        }
        return rows;
    }

    public static string GetContract_Trade_In_Fractional_Indian()
    {
        string ContractTrade_InFractional_ID = "";
        string startvalue = "CTIF";
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select max(SUBSTRING(ContractTrade_InFractional_ID, 5, len(ContractTrade_InFractional_ID)))from Contract_Trade_In_Fractional_Indian", cs1);
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                string len = string.Format("{0}", dr[0]);
                if (len.Length != 0)
                {
                    id = Convert.ToInt32(len);
                    id = id + 1;
                    ContractTrade_InFractional_ID = startvalue + id;
                }
                else
                {
                    id = 1;
                    ContractTrade_InFractional_ID = startvalue + id;

                }

            }
        }
        return ContractTrade_InFractional_ID;


    }

    public static int InsertContract_Trade_In_Fractional_Indian(string ContractTrade_InFractional_ID, string ProfileID, string ContractNo, string Oldcontracttype, string RESORT, string APT_TYPE, string NO_WEEKS, string SEASON, string NO_POINTS, string POINTS_VALUE, string oldContract_No)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Trade_In_Fractional_Indian values(@ContractTrade_InFractional_ID ,	@ProfileID ,	@ContractNo ,	@Oldcontracttype ,	@RESORT ,	@APT_TYPE ,	@NO_WEEKS ,	@SEASON ,	@NO_POINTS,	@POINTS_VALUE ,	@oldContract_No)", cs1);
                da.InsertCommand.Parameters.Add("@ContractTrade_InFractional_ID  ", SqlDbType.VarChar).Value = ContractTrade_InFractional_ID;
                da.InsertCommand.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@Oldcontracttype", SqlDbType.VarChar).Value = Oldcontracttype;
                da.InsertCommand.Parameters.Add("@RESORT", SqlDbType.VarChar).Value = RESORT;
                da.InsertCommand.Parameters.Add("@APT_TYPE", SqlDbType.VarChar).Value = APT_TYPE;
                da.InsertCommand.Parameters.Add("@NO_WEEKS", SqlDbType.VarChar).Value = NO_WEEKS;
                da.InsertCommand.Parameters.Add("@SEASON", SqlDbType.VarChar).Value = SEASON;
                da.InsertCommand.Parameters.Add("@NO_POINTS", SqlDbType.VarChar).Value = NO_POINTS;
                da.InsertCommand.Parameters.Add("@POINTS_VALUE", SqlDbType.VarChar).Value = POINTS_VALUE;
                da.InsertCommand.Parameters.Add("@oldContract_No", SqlDbType.VarChar).Value = oldContract_No;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract_Trade_In_Fractional_Indian Query " + ex.Message);

                string msg = "Error in Insert Contract_Trade_In_Fractional_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static int InsertContractLogs_India(string ProfileID,String ContractNo, String UpdatedField,string Username,   String Log_Entry)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Logs_India values(@ProfileID,@ContractNo,@UpdatedField,@Username,@Log_Entry)", cs1);
                da.InsertCommand.Parameters.Add("@ProfileID  ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@UpdatedField", SqlDbType.VarChar).Value = UpdatedField;
                da.InsertCommand.Parameters.Add("@Username ", SqlDbType.VarChar).Value = Username;
                da.InsertCommand.Parameters.Add("@Log_Entry", SqlDbType.VarChar).Value = Log_Entry;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Contract Logs Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

                string msg = "Error in Insert Contract Logs Query" + " " + ex.Message;

                throw new Exception(msg, ex);

            }
        }
        return (rowsAffected);
    }
    public static SqlDataReader LoadCodeOnCountry(string country) 
    {
        SqlConnection cs1 = Queries.GetDBConnection();
         SqlCommand SqlCmd = new SqlCommand("select Country_Code from Country  where country_name = @country", cs1);
        SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
      
        return dr;
    }
    public static SqlDataReader LoadAllCodeOnCountry(string country)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Country_Code from Country  where country_name =@country union all select Country_Code from Country  where country_name !=@country", cs1);
        SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
    
        return dr;
    }

   
    public static SqlDataReader LoadClubOnContractType(string conttype)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select distinct Club_name from Contract_type_Club where Status='Active' and Contract_Type=@conttype", cs1);
        SqlCmd.Parameters.Add("@conttype", SqlDbType.VarChar).Value = conttype;
        SqlDataReader dr = SqlCmd.ExecuteReader();
    
        return dr;

    }

    public static SqlDataReader LoadPrimaryLang(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("SELECT Primary_Language FROM Profile_Primary WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
   
        return dr;

    }
    public static SqlDataReader LoadSecLang(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("SELECT Secondary_Language FROM Profile_Secondary WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
     
        return dr;

    }
    public static SqlDataReader LoadPhotoID(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Photo_identity	from profile WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
    
        return dr;

    }
    public static SqlDataReader LoadCardType(string Profileid)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select  Card_Holder from profile  WHERE Profile_ID = @Profileid", cs1);
        SqlCmd.Parameters.Add("@Profileid", SqlDbType.VarChar).Value = Profileid;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
     
        return dr;

    }


    //new changes by muriel

    public static DataSet LoadContractProfile(string contractno, string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select pp.ContractNo, prp.Profile_Primary_Title+' '+prp.Profile_Primary_Fname+' '+prp.Profile_Primary_Lname Name,pp.DealRegistered_Date 'Deal Date',pp.DealStatus 'Deal Status', pp.Finance_Details 'Mode',fd.Total_Price_Including_Tax 'Total price'  from ContractDetails_Indian  pp join Profile_Primary prp on prp.Profile_ID = pp.ProfileID join Finance_Details_Indian fd on fd.ContractNo = pp.ContractNo join Profile p on p.Profile_ID = pp.ProfileID  where p.office = @office and(pp.ContractNo = @contractno or prp.Profile_Primary_Fname like '%" + contractno + "%') order by 3", cs1);
            SqlCmd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static String GetProfileIDOnContractNo(string contractno)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select ProfileID  from ContractDetails_Indian where ContractNo =@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }

    public static DataSet LoadContractNoDetails(string contractno)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select *  from ContractDetails_Indian where ContractNo =@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static DataSet LoadNewPointsDetails(string contractno)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from Contract_Points_Indian cp join Finance_Details_Indian f on f.ContractNo=cp.ContractNo   where  cp.ContractNo=@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadTradeinWeeksDetails(string contractno)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from Contract_Trade_In_Weeks_Indian cp join Finance_Details_Indian f on f.ContractNo=cp.ContractNo   where  cp.ContractNo=@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }
    public static DataSet LoadTradeinPointsDetails(string contractno)
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select * from Contract_Trade_In_Points_Indian cp join Finance_Details_Indian f on f.ContractNo=cp.ContractNo   where  cp.ContractNo=@contractno", cs1);
            scd.Parameters.Add("@contractno", SqlDbType.VarChar).Value = contractno;
            da = new SqlDataAdapter(scd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    public static int UpdateProfile(string ProfileID, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple, string manager, string Photo_identity, string Card_Holder, string Comments)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Profile  SET Profile_Venue_Country= '" + Profile_Venue_Country + "', Profile_Venue= '" + Profile_Venue + "', Profile_Group_Venue= '" + Profile_Group_Venue + "', Profile_Marketing_Program= '" + Profile_Marketing_Program + "', Profile_Agent= '" + Profile_Agent + "', Profile_Agent_Code= '" + Profile_Agent_Code + "', Profile_Member_Type1= '" + Profile_Member_Type1 + "', Profile_Member_Number1= '" + Profile_Member_Number1 + "', Profile_Member_Type2= '" + Profile_Member_Type2 + "', Profile_Member_Number2= '" + Profile_Member_Number2 + "', Profile_Employment_status= '" + Profile_Employment_status + "', Profile_Marital_status= '" + Profile_Marital_status + "', Profile_NOY_Living_as_couple= '" + Profile_NOY_Living_as_couple + "', manager= '" + manager + "', Photo_identity= '" + Photo_identity + "', Card_Holder= '" + Card_Holder + "' , Comments= '" + Comments + "' where Profile_ID ='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    public static int InsertContractDetails_Indian(string ContractNo, string ProfileID, string Sales_Rep, string TO_Manager, string ButtonUp_Officer, string DealRegistered_Date, string DealStatus, string Contract_CreatedDate, string Contract_UpdatedDate, string ContractType, string MCWaiver, string Finance_Details, string Contract_Remark, string Pan_Card, string Adhar_Card, string MC_Charges, string First_MC_Payable_Date, string MemberFee, string MemberCGST, string MembersGST)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into ContractDetails_Indian values(@ContractNo,	@ProfileID ,@Sales_Rep ,	@TO_Manager ,	@ButtonUp_Officer ,	@DealRegistered_Date,	@DealStatus ,	@Contract_CreatedDate,	@Contract_UpdatedDate,	@ContractType ,	@MCWaiver,	@Finance_Details ,	@Contract_Remark ,	@Pan_Card ,	@Adhar_Card,@MC_Charges, @First_MC_Payable_Date,@MemberFee,@MemberCGST,@MembersGST)", cs1);
                da.InsertCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@ProfileID ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@Sales_Rep ", SqlDbType.VarChar).Value = Sales_Rep;
                da.InsertCommand.Parameters.Add("@TO_Manager ", SqlDbType.VarChar).Value = TO_Manager;
                da.InsertCommand.Parameters.Add("@ButtonUp_Officer ", SqlDbType.VarChar).Value = ButtonUp_Officer;
                da.InsertCommand.Parameters.Add("@DealRegistered_Date", SqlDbType.VarChar).Value = DealRegistered_Date;
                da.InsertCommand.Parameters.Add("@DealStatus ", SqlDbType.VarChar).Value = DealStatus;
                da.InsertCommand.Parameters.Add("@Contract_CreatedDate", SqlDbType.VarChar).Value = Contract_CreatedDate;
                da.InsertCommand.Parameters.Add("@Contract_UpdatedDate", SqlDbType.VarChar).Value = Contract_UpdatedDate;
                da.InsertCommand.Parameters.Add("@ContractType ", SqlDbType.VarChar).Value = ContractType;
                da.InsertCommand.Parameters.Add("@MCWaiver", SqlDbType.VarChar).Value = MCWaiver;
                da.InsertCommand.Parameters.Add("@Finance_Details", SqlDbType.VarChar).Value = Finance_Details;
                da.InsertCommand.Parameters.Add("@Contract_Remark", SqlDbType.VarChar).Value = Contract_Remark;
                da.InsertCommand.Parameters.Add("@Pan_Card", SqlDbType.VarChar).Value = Pan_Card;
                da.InsertCommand.Parameters.Add("@Adhar_Card", SqlDbType.VarChar).Value = Adhar_Card;
                da.InsertCommand.Parameters.Add("@MC_Charges", SqlDbType.VarChar).Value = MC_Charges;
                da.InsertCommand.Parameters.Add("@First_MC_Payable_Date", SqlDbType.VarChar).Value = First_MC_Payable_Date;
                da.InsertCommand.Parameters.Add("@MemberFee", SqlDbType.VarChar).Value = MemberFee;
                da.InsertCommand.Parameters.Add("@MemberCGST", SqlDbType.VarChar).Value = MemberCGST;
                da.InsertCommand.Parameters.Add("@MembersGST", SqlDbType.VarChar).Value = MembersGST;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert ContractDetails_Indian Query " + ex.Message);

                string msg = "Error in Insert ContractDetails_Indian Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


}