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
/// Summary description for production
/// </summary>
public class production
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

    public static SqlDataReader searchProfiles(string profileID,string office)//string venue)
    {
       
        SqlConnection cs1 = Queries.GetDBConnection();
        //   SqlCommand SqlCmd = new SqlCommand("  select distinct Manager_Name from managers where Manager_Status='Active' and  Venue=@venue order by 1", cs1);
        SqlCommand SqlCmd = new SqlCommand("select top(100) pp.Profile_ID,pp.Profile_Primary_Title as Title,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as Name,e.Primary_Email as Email,q.Primary_Mobile as Mobile, REPLACE(ISNULL(CONVERT(varchar, td.Tour_Details_Tour_Date,105), ''), '01-01-1900', '') as [Tour Date],td.Tour_Details_ID as Tour_Id   from Profile_Primary pp join Profile p on p.Profile_ID=pp.Profile_ID  join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID join Tour_Details td on p.Profile_ID = td.Profile_ID where  (pp.Profile_ID = '" + profileID + "' or pp.Profile_Primary_Fname like '" + profileID + "%' or pp.Profile_Primary_Lname like '" + profileID + "%' or q.Primary_Mobile like '" + profileID + "%' or e.Primary_Email like '" + profileID + "%')", cs1);
        SqlCmd.Parameters.Add("@profileID", SqlDbType.VarChar).Value = profileID;
        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        return dr;
    }
}