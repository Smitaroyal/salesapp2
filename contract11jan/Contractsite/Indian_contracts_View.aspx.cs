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






public partial class _Default : System.Web.UI.Page
{
    static string office;
    static string pointsamt, pointstax, poinstcgst, pointssgst, mrgcode;
    string IGSTrate, Interestrate, mcwaiver;
    string Finance_No, documentationfee, IGST_Amount, No_Emi, emiamt;

    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager, ophid, ocard;
    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID, opage, oplang, opdesignation;
    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country, osage, oslang, osdesignation;
    static string oSub_Profile1_ID, oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country, osp1age;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country, osp2age;
    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email;
    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc;

    static string pemail, semail, sp1email, sp2email;
    public string getdata()
    {
        string htmlstr = "";
        SqlDataReader dr = Queries.LoadAffiliationType(office);//,currencyDropDownList.SelectedItem.Text);
        while (dr.Read())
        {

            int id = dr.GetInt32(0);
            string name = dr.GetString(1);
            double amt = dr.GetDouble(2);
            string addvalue = "dispplayvalue";
            string ca = "ca";

            htmlstr += " <input id=" + ca + "" + id + " type='checkbox' class='hello' name='aamt' onClick=" + addvalue + "() value='" + amt + "'>" + name + "";


        }

        return htmlstr;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        if (!Page.IsPostBack)
        {

            string contractno = Convert.ToString(Request.QueryString["ContractNo"]);


            string ProfileID = Queries.GetProfileIDOnContractNo(contractno);
            DataSet ds = Queries.LoadContractNoDetails(contractno);
            DataSet ds1 = Queries.LoadProfielDetailsFull(ProfileID);
            string office = ds1.Tables[0].Rows[0]["office"].ToString();
            if (ds.Tables[0].Rows.Count == 0)
            {



            }
            else
            {
                string ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
                string Finance_Details = ds.Tables[0].Rows[0]["Finance_Details"].ToString();
                if (Finance_Details == "Finance")
                {
                    if (ContractType == "Fractionals")
                    {

                        //PrintPdfDropDownList.Items.Clear();
                        //DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, resortDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text);
                        //PrintPdfDropDownList.DataSource = ds21;
                        //PrintPdfDropDownList.DataTextField = "printname";
                        //PrintPdfDropDownList.DataValueField = "printname";
                        //PrintPdfDropDownList.AppendDataBoundItems = true;
                        //PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        //PrintPdfDropDownList.DataBind();

                    }
                    else if (ContractType == "Points")
                    {
                        DataSet dsp = Queries.LoadNewPointsDetails(contractno);
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(ContractType, office, dsp.Tables[0].Rows[0]["club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if (ContractType == "Trade-In-Points")
                    {
                        DataSet dsp = Queries.LoadTradeinPointsDetails(contractno);
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(ContractType, office, dsp.Tables[0].Rows[0]["New_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if (ContractType == "Trade-In-Weeks")
                    {
                        DataSet dsp = Queries.LoadTradeinWeeksDetails(contractno);
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(ContractType, office, dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }

                }
                else if (Finance_Details == "Non Finance")
                {

                    if (ContractType == "Fractionals")
                    {

                        //PrintPdfDropDownList.Items.Clear();
                        //DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, resortDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text);
                        //PrintPdfDropDownList.DataSource = ds21;
                        //PrintPdfDropDownList.DataTextField = "printname";
                        //PrintPdfDropDownList.DataValueField = "printname";
                        //PrintPdfDropDownList.AppendDataBoundItems = true;
                        //PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        //PrintPdfDropDownList.DataBind();

                    }
                    else if (ContractType == "Points")
                    {
                        DataSet dsp = Queries.LoadNewPointsDetails(contractno);
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(ContractType, office, dsp.Tables[0].Rows[0]["club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if (ContractType == "Trade-In-Points")
                    {
                        DataSet dsp = Queries.LoadTradeinPointsDetails(contractno);
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(ContractType, office, dsp.Tables[0].Rows[0]["New_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if (ContractType == "Trade-In-Weeks")
                    {
                        DataSet dsp = Queries.LoadTradeinWeeksDetails(contractno);
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(ContractType, office, dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                }



            }







        }
    }


    protected void Button5_Click(object sender, EventArgs e)
    {

        string contractno = Convert.ToString(Request.QueryString["ContractNo"]);


        string ProfileID = Queries.GetProfileIDOnContractNo(contractno);
        DataSet ds = Queries.LoadContractNoDetails(contractno);
        DataSet ds1 = Queries.LoadProfielDetailsFull(ProfileID);
        string office = ds1.Tables[0].Rows[0]["Office"].ToString();
        if (ds.Tables[0].Rows.Count == 0)
        {



        }
        else
        {
            string ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
            string Finance_Details = ds.Tables[0].Rows[0]["Finance_Details"].ToString();
            if (Finance_Details == "Finance")
            {
                if (ContractType == "Fractionals")
                {
                    DataTable datatable = Queries.Fractional_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument();
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt"));
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");
                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();
                }
                else if (ContractType == "Points")
                {
                    DataTable datatable = Queries.NewPoints_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    //   string fn = "test" + ".pdf";
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();




                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataTable datatable = Queries.TradeInPoints_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    //   string fn = "test" + ".pdf";
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataTable datatable = Queries.TradeInWeeks_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    //   string fn = "test" + ".pdf";
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();

                }
                else if (ContractType == "Trade-In-Fractionals")
                {



                }
            }
            else if (Finance_Details  == "Non Finance")
            {
                if (ContractType == "Fractionals")
                {
                    DataTable datatable = Queries.Fractional_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    //   string fn = "test" + ".pdf";
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();



                }
                else if (ContractType == "Points")
                {
                    DataTable datatable = Queries.NewPoints_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    //   string fn = "test" + ".pdf";
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();




                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataTable datatable = Queries.TradeInPoints_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    //   string fn = "test" + ".pdf";
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();



                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataTable datatable = Queries.TradeInWeeks_PA(contractno);
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                    crystalReport.SetDataSource(datatable);
                    System.IO.FileStream fs = null;
                    long FileSize = 0;
                    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    oDest.DiskFileName = ExportFileName;
                    crystalReport.ExportOptions.DestinationOptions = oDest;
                    crystalReport.Export();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("Content-Type", "application/pdf");
                    //   string fn = "test" + ".pdf";
                    string fn = printr + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                    FileSize = fs.Length;
                    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                    fs.Close();
                    Response.BinaryWrite(bBuffer);
                    Response.Flush();

                }
                else if (ContractType == "Trade-In-Fractionals")
                {



                }

            }

        }
    }
}



