using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Sql;
using System.Net;
using System.IO;
using System.Web.UI.WebControls.Adapters;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Globalization;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using System.Collections.Generic;


public partial class Contractsite_ProfileDetailsView : System.Web.UI.Page
{
    static string srep;
    protected void Page_Load(object sender, EventArgs e)
    {
        string profile = Convert.ToString(Request.QueryString["Profile_ID"]);

        DataSet ds2 = Queries.LoadProfileOnCreationOnLoad(profile);

        lblprofileid.Text = ds2.Tables[0].Rows[0]["Profile_ID"].ToString();
        lbltourdate.Text = ds2.Tables[0].Rows[0]["tourdate"].ToString();
        lblopcagent.Text = ds2.Tables[0].Rows[0]["Profile_Agent"].ToString();
        lblteamcapt.Text = ds2.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
        lblarrival.Text = ds2.Tables[0].Rows[0]["arrival"].ToString();
        lblmale.Text = ds2.Tables[0].Rows[0]["primaryFullName"].ToString();
        lblfemale.Text = ds2.Tables[0].Rows[0]["secondaryFullName"].ToString();
        lblresort.Text = ds2.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        lblnon.Text = ds2.Tables[0].Rows[0]["memeberNonmember"].ToString();
        lblmdesg.Text = ds2.Tables[0].Rows[0]["Primary_Designation"].ToString();
        lblmaritalstatus.Text = ds2.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
        lblphotoidentitiy.Text = ds2.Tables[0].Rows[0]["Photo_identity"].ToString();
        lblcard.Text = ds2.Tables[0].Rows[0]["Card_Holder"].ToString();
        lblcomments.Text = ds2.Tables[0].Rows[0]["comments"].ToString();//+" "+ds2.Tables[0].Rows[0]["comment2"].ToString();
        lblplang.Text = ds2.Tables[0].Rows[0]["Primary_Language"].ToString();
        lblplang0.Text = ds2.Tables[0].Rows[0]["Secondary_Language"].ToString();
        lblempstatus.Text = ds2.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
        lbldepdate.Text = ds2.Tables[0].Rows[0]["Departure"].ToString();
        lblmale0.Text = String.Format("{0:dd-MM-yyyy}", ds2.Tables[0].Rows[0]["Profile_Primary_DOB"]);
        lblfemale0.Text = String.Format("{0:dd-MM-yyyy}", ds2.Tables[0].Rows[0]["Profile_Secondary_DOB"]);//.ToString();
        lblfdesg.Text = ds2.Tables[0].Rows[0]["Secondary_Designation"].ToString();

        DataSet dsvenue = Queries.LoadProfileOnCreation(profile);
        string venue = dsvenue.Tables[0].Rows[0]["Profile_Venue"].ToString();
        string grpvenue = dsvenue.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
        DataSet dsrep = Queries.GetSalesRepOnlyVenueViewPage(venue);
        salesrepDropDownList.DataSource = dsrep;
        salesrepDropDownList.DataTextField = "sales_rep_name";
        salesrepDropDownList.DataValueField = "sales_rep_name";
        salesrepDropDownList.AppendDataBoundItems = true;
        salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
        salesrepDropDownList.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dsprofile = Queries.LoadProfileOnCreation(lblprofileid.Text);
        srep = dsprofile.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
        string salesrep = salesrepDropDownList.SelectedItem.Text;
        if (String.Compare(srep, salesrep) != 0)
        {
            string act = "Sales Rep changed from:" + srep + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(lblprofileid.Text, "", act, "", DateTime.Now.ToString());
        }
        else { }
        int tour = Queries.UpdateSalesRepDetails(lblprofileid.Text, salesrep);
        string msg = "Assigned Sales Rep";
        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
    }
}