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

   

    static string pemail, semail, sp1email, sp2email;
   
    public void LoadDocuments(string ContractDetails_ID, string office, string Finance_Details, string ContractType, string aftype, string mc, string canxcontno, string companyname,string statename)
    {
        if (mc == "Yes")
        {
            //check if id exists in othernames
            int othersid = Queries.ContractNo_OthernamesExistsA(ContractDetails_ID);
            if (othersid == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {

                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
            int othersid1 = Queries.ContractNo_OthernamesExistsNone(ContractDetails_ID);
            if (othersid1 == 0)
            {
                if (ContractType == "Fractionals")
                {

                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }

                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
            int othersid2 = Queries.ContractNo_OthernamesExistsB(ContractDetails_ID);
            if (othersid2 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
            int othersid3 = Queries.ContractNo_OthernamesExistsS(ContractDetails_ID);
            if (othersid3 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
        }
        else if(mc=="No")
        {
            //check if id exists in othernames
            int othersid = Queries.ContractNo_OthernamesExistsA(ContractDetails_ID);
            if (othersid == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }

                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points1(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points2(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points3(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points1(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points2(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points3(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
            int othersid1 = Queries.ContractNo_OthernamesExistsNone(ContractDetails_ID);
            if (othersid1 == 0)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points4(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points5(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points6(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points4(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points5(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points6(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points4(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points5(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points6(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
            int othersid2 = Queries.ContractNo_OthernamesExistsB(ContractDetails_ID);
            if (othersid2 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points7(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points8(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points9(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points7(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points8(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points9(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points7(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points8(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points9(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
            int othersid3 = Queries.ContractNo_OthernamesExistsS(ContractDetails_ID);
            if (othersid3 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points10(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points11(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points12(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points10(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points11(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points12(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points10(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points11(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points12(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
        }
        
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
            string ContractDetails_ID = ds.Tables[0].Rows[0]["ContractDetails_ID"].ToString();

            string mc = ds.Tables[0].Rows[0]["MCWaiver"].ToString();
            DataSet ds1 = Queries.LoadProfielDetailsFull(ProfileID);
            string office = ds1.Tables[0].Rows[0]["Office"].ToString();
            string oldcontno= ds.Tables[0].Rows[0]["CanxContractNo"].ToString();
            string companyname= ds1.Tables[0].Rows[0]["Company_Name"].ToString();           
            string statename = ds1.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            DataSet dsfinance = Queries.LoadFinanceContractDetails(ContractDetails_ID);

            if (ds.Tables[0].Rows.Count == 0)
            {



            }
            else
            {
                string ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
                string Finance_Details = ds.Tables[0].Rows[0]["Finance_Details"].ToString();
                string aftype= dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                 
                LoadDocuments(ContractDetails_ID, office, Finance_Details, ContractType, aftype, mc, oldcontno, companyname,statename);

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
        string statename = ds1.Tables[0].Rows[0]["Profile_Address_State"].ToString();
        if (ds.Tables[0].Rows.Count == 0)
        {



        }
        else
        {
            string ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
            string Finance_Details = ds.Tables[0].Rows[0]["Finance_Details"].ToString();
            string contractdetailsID= ds.Tables[0].Rows[0]["ContractDetails_ID"].ToString();
            
                if (ContractType == "Fractionals")
                {

                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    
                    if (printr == "BREAKUP")
                    {
                        DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
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
                    else if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
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
                    else if (printr == "REP REPORT")
                    {
                        DataTable datatable = Queries.Rep_ReportProc(contractno);
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
                    else if(printr== "ADDITION OF NAME LETTER")
                    {
                        DataTable datatable = Queries.AdditionalName_FractionalProc(contractno);
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
                    else if(printr.Contains("sor"))
                    {
                        DataTable datatable = Queries.SOR_FractionalProc(contractno);
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
                    else
                    {
                        DataTable datatable = Queries.Fractional_PA(contractno);
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

                }
                else if (ContractType == "Points")
                {


                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "BREAKUP")
                    {
                        DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
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
                    else if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
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
                    else if (printr == "REP REPORT")
                    {
                        DataTable datatable = Queries.Rep_ReportProc(contractno);
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
                else if (printr == "ADDITION OF NAME LETTER")
                {
                    DataTable datatable = Queries.AdditionalName_NewPointsProc(contractno);
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
                else if (printr.Contains("sor"))
                {
                     

                }
                else
                    {
                        DataTable datatable = Queries.NewPoints_PA(contractno);
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


                }
                else if (ContractType == "Trade-In-Points")
                {


                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "BREAKUP")
                    {
                        DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
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
                    else if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
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
                    else if (printr == "REP REPORT")
                    {
                        DataTable datatable = Queries.Rep_ReportProc(contractno);
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
                else if (printr == "ADDITION OF NAME LETTER")
                {
                    DataTable datatable = Queries.AdditionalName_TIPProc(contractno);
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
                else if (printr.Contains("sor"))
                {
                    DataTable datatable = Queries.SOR_TIPProc(contractno);
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
                else
                    {
                        DataTable datatable = Queries.TradeInPoints_PA(contractno);
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

                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "BREAKUP")
                    {
                        DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
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
                    else if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
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
                    else if (printr == "REP REPORT")
                    {
                        DataTable datatable = Queries.Rep_ReportProc(contractno);
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
                else if (printr == "ADDITION OF NAME LETTER")
                {
                    DataTable datatable = Queries.AdditionalName_TIWProc(contractno);
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
                else if (printr.Contains("sor"))
                {
                    DataTable datatable = Queries.SOR_TIWProc(contractno);
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
                else
                    {
                        DataTable datatable = Queries.TradeInWeeks_PA(contractno);

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

                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "BREAKUP")
                    {
                        DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
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
                    else if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
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
                    else if (printr == "REP REPORT")
                    {
                        DataTable datatable = Queries.Rep_ReportProc(contractno);
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
                else if (printr == "ADDITION OF NAME LETTER")
                {
                    DataTable datatable = Queries.AdditionalName_FractionalProc(contractno);
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
                else if (printr.Contains("sor"))
                {
                    DataTable datatable = Queries.SOR_FractionalProc(contractno);
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
                else
                    {
                        DataTable datatable = Queries.FractionalTradeIn_PA(contractno);

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
                }
          

        }
    }
}



