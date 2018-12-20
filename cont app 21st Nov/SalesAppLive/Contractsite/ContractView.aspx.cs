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

public partial class Contractsite_ContractView : System.Web.UI.Page
{
    //static string officeo, GenContNumbglob,globContClub="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string user =  (string)Session["username"];
        string office = Queries.GetOffice(user);
        Session["officeo"] = "";
        Session["officeo"] = office;
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        if (!Page.IsPostBack)
        {

            //string contractno = "RGC9/271117/114";//.ToString(Request.QueryString["ContractNo"]);

            string contractno = Convert.ToString(Request.QueryString["ContractNo"]);
            Session["GenContNumbglob"] = "";
          Session["GenContNumbglob"] = contractno;

            string fracid = Queries2.getcontIDfromNo(contractno);
         
            DataSet ds4 = Queries2.LoadAllContractFractionalDetails(fracid);
            string conttype = ds4.Tables[0].Rows[0]["Contract_Finance_Cont_Type"].ToString(); //ds4.Tables[0].Rows[0][""].ToString();
            Session["globContClub"] = "";
            if (conttype == "Points")
            {
                Session["globContClub"]  = ds4.Tables[0].Rows[0]["CT_Points_Club"].ToString(); 
            }
            else if (conttype == "Trade Into Points")
            {
                Session["globContClub"] = ds4.Tables[0].Rows[0]["TP_New_CLub"].ToString();
            }
            else if (conttype == "Fractional")
            {
                Session["globContClub"] = "";
            }
            else if (conttype == "Trade Into Fractional")
            {
                Session["globContClub"] = "";
            }


            string PaymentMethod=ds4.Tables[0].Rows[0]["Contract_Finance_Payment_Method"].ToString();
            string affilice = ds4.Tables[0].Rows[0]["Contract_Finance_Affil_ICE"].ToString();
            string CrownCurr = ds4.Tables[0].Rows[0]["Contract_Finance_Crown_Curr"].ToString();

            string PaymentMethod2, affil2;
            if (PaymentMethod == "Crown Finance")
            {
                PaymentMethod2 = "Crown Finance";
            }
            else
            {
                PaymentMethod2 = "NCrown Finance";
            }

            if (affilice == "True")
            {
                affil2 = "ICE";
            }
            else
            {
                affil2 = "NICE";
            }






            Session["PConttype"] = conttype;//DropDownList40.SelectedItem.Text;
            Session["Pofficeo"] = office;
            Session["PGlobContClub"] = Session["globContClub"].ToString();
            Session["PPaymentMethod"] = PaymentMethod2;
            Session["PAffil"] = affil2;
            Session["PCrownCurr"] = CrownCurr;


            PrintPdfDropDownList.Items.Clear();
           // string ContType1 = DropDownList40.SelectedItem.Text;
            DataSet ds21 = Queries2.LoadPrintFiles2(conttype, office, (string)Session["globContClub"], PaymentMethod2, affil2, CrownCurr);
            PrintPdfDropDownList.DataSource = ds21;
            PrintPdfDropDownList.DataTextField = "Printpdf_name";
            PrintPdfDropDownList.DataValueField = "Printpdf_name";
            PrintPdfDropDownList.AppendDataBoundItems = true;
            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
            PrintPdfDropDownList.DataBind();

        }

        }

    protected void Button5_Click(object sender, EventArgs e)
    {
        var printr = PrintPdfTextBox2.Text; //PrintPdfDropDownList.SelectedItem.Text;

        //string msg = Server.MapPath("~/reports/" + printr + ".rpt");
        //MessageBox.Show("Error while creating profile " + ex.Message);
        //string msg = "Details updated for Profile :" + " " + profile;
        // Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

        DataTable datatable = Queries2.loadreport((string)Session["GenContNumbglob"] , printr, (string)Session["officeo"] );

        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report


        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
        crystalReport.SetDataSource(datatable);

        System.IO.FileStream fs = null;
        long FileSize = 0;
        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
        //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
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
        // Response.Close();
    }



    public class PrintPdfType
    {
        public string PrintPdfTypeID { get; set; }
        public string PrintPdfTypeName { get; set; }
        // public string P1Conttype { get; set; }
    }


    [WebMethod]
    public static string PrintPdfTypeDropDownList(string Lang)
    {
        //string conttype2 = globalclass.contracttype;


        string P1Conttype = HttpContext.Current.Session["PConttype"].ToString();
        string P1officeo = HttpContext.Current.Session["Pofficeo"].ToString();
        string P1GlobContClub = HttpContext.Current.Session["PGlobContClub"].ToString();
        string P1PaymentMethod = HttpContext.Current.Session["PPaymentMethod"].ToString();
        string P1Affil = HttpContext.Current.Session["PAffil"].ToString();
        string P1CrownCurr = HttpContext.Current.Session["PCrownCurr"].ToString();
        /* Session["Pofficeo"] = officeo;
         Session["PGlobContClub"] = GlobContClub;
         Session["PPaymentMethod"] = PaymentMethod2;
         Session["PAffil"] = affil2;
         Session["PCrownCurr"] = CrownCurr;*/


        DataTable dt = new DataTable();
        List<PrintPdfType> listRes = new List<PrintPdfType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active' and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "'  union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='" + P1Affil + "' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' union  select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr='' and  Printpdf_Lang='" + Lang + "' union select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = '" + P1Conttype + "' and p.Printpdf_office='" + P1officeo + "' and p.Print_pdf_Club='" + P1GlobContClub + "' and Printpdf_Status='Active'  and Printpdf_Affil='' and Printpdf_Fina='" + P1PaymentMethod + "' and Printpdf_Fina_Curr= '" + P1CrownCurr + "' and  Printpdf_Lang='" + Lang + "' ", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        PrintPdfType objst2 = new PrintPdfType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.PrintPdfTypeName = Convert.ToString(dt.Rows[i]["Printpdf_name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



}