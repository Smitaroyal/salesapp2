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
    static string pointsamt, pointstax, poinstcgst, pointssgst,mrgcode;
    string IGSTrate, Interestrate,mcwaiver;
    string Finance_No, documentationfee, IGST_Amount, No_Emi, emiamt;

    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager, ophid, ocard;
    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID, opage, oplang, opdesignation;
    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country, osage, oslang, osdesignation;
    static string oSub_Profile1_ID, oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country, osp1age;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country, osp2age;
    static string oSub_Profile3_ID, oSub_Profile3_Title, oSub_Profile3_Fname, oSub_Profile3_Lname, oSub_Profile3_DOB, oSub_Profile3_Nationality, oSub_Profile3_Country, osp3age;
    static string oSub_Profile4_ID, oSub_Profile4_Title, oSub_Profile4_Fname, oSub_Profile4_Lname, oSub_Profile4_DOB, oSub_Profile4_Nationality, oSub_Profile4_Country, osp4age;
    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate, oSubprofile3_CC, oSubprofile3_Mobile, oSubprofile3_Alt_CC, oSubprofile3_Alternate, oSubprofile4_CC, oSubprofile4_Mobile, oSubprofile4_Alt_CC, oSubprofile4_Alternate,opriOfficecc,opriOfficeno,osecOfficecc,osecOfficeno;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email, oSubprofile3_Email, oSubprofile4_Email;
    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate,priOfficeno,secOfficeno;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec, sp3mobilec, sp3alternatec, sp4mobilec, sp4alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc, sp3cc, sp3altccc, sp4cc, sp4altccc,priOfficecc,secOfficecc;
    static string pemail, semail, sp1email, sp2email, sp3email, sp4email;


    static string ocsalesrep, ocTomgr, obuttonup, odealdate, odealstatus,oadhar,opan,oloanbuofficer,ocanxcontno,ocanxdate;
    static string opts_club, opts_newpts, opts_entitlement, opts_totalpts, opts_firstyr, opts_Tenure, opts_lastyr, opts_nopersons;
    static string otip_Trade_In_Details_club_resort, otip_Trade_In_Details_No_rights, otip_Trade_In_Details_ContNo_RCINo, otip_Trade_In_Details_Points_value, otip_New_Club, otip_New_Club_Points_Rights, otip_New_MemebrshipType, otip_New_TotalPointsRights, otip_New_First_year_occupancy, otip_New_Tenure, otip_New_Last_year_occupancy,otip_nopersons;
    static string otiw_Trade_In_Weeks_resort, otiw_Trade_In_Weeks_Apt, otiw_Trade_In_Weeks_Season, otiw_Trade_In_Weeks_NoWks, otiw_Trade_In_Weeks_ContNo_RCINo, otiw_Trade_In_Weeks_Points_value, otiw_NewPointsW_Club, otiw_NewPointsW_Club_Points_Rights, otiw_NewPointsW_MemebrshipType, otiw_NewPointsW_Total_Points_rights, otiw_NewPointsW_First_year_occupancy, otiw_NewPointsW_Tenure, otiw_NewPointsW_Last_year_occupancy, otiw_nopersons;
    static string omcwv, omcfees, omcdate, omemberfee, omemebercgst, omembersgst, ocurrency, oaffiliate, ototalintax, odepamt, obalpayable, odepbal, opaymethod, onoinstallment, oinstallment, ototalbalance, ofinance, ofinancemethod, oFinanceno, ofinmonth, onoemi, oemiamt, ofindocfee, oisgtrate, oigstamt, ointerestrate, oregcollectionterm, oregcollamt, obaladepamtdate, ooldLoanAgreement;
    static string onewpoints,oconversionfee,oadminfee,ototpurchprice,ocgst, osgst, ototalpriceInTax,odeposit, obalance,obalancedue, oremarks;
    static string tifpresort, tifpnopoints, tifpcontrcino, tifpptsvalue;
    static string otifresort, otifresidence_no, otifresidence_type, otiffractional_interest, otifentitlement, otiffirstyear_Occupancy, otiftenure, otiflastyear_Occupancy, otifleaseback, otifMc_Charges, otifOldcontracttype, otifRESORT, otifAPT_TYPE, otifSEASON, otifNO_WEEKS, otifNO_POINTS, otifPOINTS_VALUE, otifoldContract_No, otifContractNo, otifProfileID, otifSales_Rep, otifTO_Manager, otifButtonUp_Officer, otifDealRegistered_Date, otifDealStatus, otifContract_CreatedDate, otifContract_UpdatedDate, otifContractType, otifMCWaiver, otifFinance_Details, otifContract_Remark, otifPan_Card, otifAdhar_Card, otifMC_Charges, otifFirst_MC_Payable_Date, otifMemberFee, otifMemberCGST, otifMembersGST;
    static string ofctAdmission_fees, ofctadministration_fees, ofctCgst, ofctSgst, ofctTotal_Purchase_Price, ofctTotal_Price_Including_Tax, ofctDeposit, ofctBalance, ofctBalance_Due_Dates, ofctRemarks, ooldloanamt;
    static string contractno, ocompanyname, ocogstin, ocompanypano;
    static string ProfileID;
    static string regTerms, oregTerms,ocomment2;
    static string ocontractno, otradeinvalue, ototalvalue;
    static string oReceipt_Date, oAmount, otaxable_value, ocgstrate, ocgstamt, osgstrate, osgstamt, ototalamt, oPayment_Mode;
    static string ocontractcomment;


	static int wkno;
    
    public void financebreakup(string noemi, string financeamt, string emiamt, string contractid, string ctype, string contno,string installmentcnt)
    {
        int emimonths = Convert.ToInt32(noemi);// (noemiTextBox.Text);
        double principalamt = Convert.ToDouble(financeamt);// balamtpayableTextBox.Text);
        double emiamt1 = Convert.ToDouble(emiamt);// emiamtTextBox.Text);
        int months = 12;
        int ik;
        string month, fmonth;

        if (ctype == "Fractional" || ctype == "Trade-In-Fractionals")
        {
            int interest = 11;
            for (ik = 1; ik <= emimonths; ik++)
            {

                //if contractdetails id doesnt exists then
                int exists = Queries.CheckIDExistsInFinance_Breakup(contno);
                if (exists == 1)
                {
                    //get min principalamt
                    int ink = ik - 1;
                    double pa = Queries.GetMinPrinicipalAmt(contno);
                    double mi = Queries.GetMinMonthlyPrincipal(contno, ink, pa);
                    double newba = pa - mi;
                    double Yearly_interest = Math.Round((newba * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);
                    fmonth = Queries.FinanceInstallmentMonthF(contno);
                    month = Queries.FinanceInstallmentMonthStartdate(contno);
                    int insert = Queries.InsertFinance_Breakup( contno, contractid, newba, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
                }
                else
                {
                    double Yearly_interest = Math.Round((principalamt * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);

                    //get max month from installment table
                    if (installmentcnt == "0" || installmentcnt == ""|| installmentcnt=="NaN")
                    {
                        fmonth = Queries.FinanceInstallmentMonthStartdateNewFZeroInstallment(contno);
                        month = Queries.FinanceInstallmentMonthStartdateNewZeroInstallment(contno);
                        int insert = Queries.InsertFinance_Breakup( contno, contractid, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);

                    }
                    else
                    {
                        fmonth = Queries.FinanceInstallmentMonthStartdateNewF(contno);
                        month = Queries.FinanceInstallmentMonthStartdateNew(contno);
                        int insert = Queries.InsertFinance_Breakup( contno, contractid, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
                    }
                }

            }
        }
        else
        {
            int interest = 19;
            for (ik = 1; ik <= emimonths; ik++)
            {

                //if contractdetails id doesnt exists then
                int exists = Queries.CheckIDExistsInFinance_Breakup(contno);
                if (exists == 1)
                {
                    //get min principalamt
                    int ink = ik - 1;
                    double pa = Queries.GetMinPrinicipalAmt(contno);
                    double mi = Queries.GetMinMonthlyPrincipal(contno, ink, pa);
                    double newba = pa - mi;
                    double Yearly_interest = Math.Round((newba * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);
                    fmonth = Queries.FinanceInstallmentMonthF(contno);
                    month = Queries.FinanceInstallmentMonthStartdate(contno);
                    int insert = Queries.InsertFinance_Breakup( contno, contractid, newba, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
                }
                else
                {
                    double Yearly_interest = Math.Round((principalamt * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);
                    //get max month from installment table
                    if (installmentcnt == "0" || installmentcnt == "" || installmentcnt == "NaN")
                    {
                        fmonth = Queries.FinanceInstallmentMonthStartdateNewFZeroInstallment(contno);
                        month = Queries.FinanceInstallmentMonthStartdateNewZeroInstallment(contno);
                        int insert = Queries.InsertFinance_Breakup( contno, contractid, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);

                    }
                    else
                    {
                        fmonth = Queries.FinanceInstallmentMonthStartdateNewF(contno);
                        month = Queries.FinanceInstallmentMonthStartdateNew(contno);
                        int insert = Queries.InsertFinance_Breakup(contno, contractid, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
                    }
                }

            }
        }
    }
    public void CheckBreakup(string financetype, string ofinancebal, string noemi, string onoemi, string financeamt, string emiamt, string contractid, string ctype, string contno,string instno)
    {
        if (financetype == "Finance")
        {
            //check if contno exists
            int exists = Queries.ContractDetails_IDFinance_Breakup(contno);
            //if YES
            if (exists == 1)
            {

                

                //check if finance amt is not same
                if ((String.Compare(ofinancebal, financeamt) != 0) && (String.Compare(onoemi, noemi) != 0))
                {
                    //delete previous entries
                    int del = Queries.DeleteContractDetailsIDFinance_Breakup(contno);
                    //insert new entries
                    financebreakup(noemi, financeamt, emiamt, contractid, ctype, contno,instno);

                }
                else if ((String.Compare(ofinancebal, financeamt) == 0) && (String.Compare(onoemi, noemi) != 0))
                {
                    //delete previous entries
                    int del = Queries.DeleteContractDetailsIDFinance_Breakup(contno);
                    //insert new entries
                    financebreakup(noemi, financeamt, emiamt, contractid, ctype, contno, instno);

                }
               else if ((String.Compare(ofinancebal, financeamt) != 0) && (String.Compare(onoemi, noemi) == 0))
                {
                    //delete previous entries
                    int del = Queries.DeleteContractDetailsIDFinance_Breakup(contno);
                    //insert new entries
                    financebreakup(noemi, financeamt, emiamt, contractid, ctype, contno, instno);

                }
                else { }
            }
            //if NO
            else
            {

                financebreakup(noemi, financeamt, emiamt, contractid, ctype, contno, instno);
            }
        }
        else if (financetype == "Non Finance")
        {
            //check if contno exists
            int exists = Queries.ContractDetails_IDFinance_Breakup(contno);
            //if YES
            if (exists == 1)
            {
                //delete previous entries
                int del = Queries.DeleteContractDetailsIDFinance_Breakup(contno);
            }
            //if NO
            else
            { }

        }

    }
    public void LoadDocuments(string ContractDetails_ID, string office, string Finance_Details, string ContractType, string aftype, string mc, string canxcontno, string companyname, string statename)
    {
        if (mc == "Yes")
        {
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
        }
        else if (mc == "No" || mc == "")
        {
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
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
            }
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
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
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
            }
        }

    }

    public void SOR_AdditionalName(string contractdetails_ID)
    {
        // string ContractdetailsID = ContractdetailsIDTextBox.Text;
        string contractno = contractnoTextBox.Text;

        int ik;
        string iname, iadd, istate, icountry, ipincode;
        string name, add, state, country, pincode;
        string user = (string)Session["username"];
        if (asornoTextBox.Text == "")
        {
        }
        else
        {
            int num = Convert.ToInt32(asornoTextBox.Text);
            if (SORDropDownList.SelectedItem.Text == "")
            {

            }
            else if (SORDropDownList.SelectedItem.Text == "SOR Name")
            {
                for (ik = 1; ik <= Convert.ToInt32(num); ik++)
                {
                    string id = Queries.GetContractNo_OthernamesID(officeTextBox.Text);
                    iname = "textBox1_" + ik + "1";
                    name = Request.Form[iname];
                    iadd = "textBox1_" + ik + "2";
                    add = Request.Form[iadd];
                    istate = "textBox1_" + ik + "3";
                    state = Request.Form[istate];
                    icountry = "textBox1_" + ik + "4";
                    country = Request.Form[icountry];
                    ipincode = "textBox1_" + ik + "5";
                    pincode = Request.Form[ipincode];

                    int insertrow = Queries.InsertContractNo_Othernames(id, contractnoTextBox.Text, contractdetails_ID, SORDropDownList.SelectedItem.Text, name.ToUpper(), add.ToUpper(), state.ToUpper(), country.ToUpper(), pincode, "Active", "", DateTime.Now.ToString());
                    string log5in = "SOR Details:" + "ContractdetailsID: " + contractdetails_ID + "," + "Contractno: " + contractnoTextBox.Text + "," + "Type:" + SORDropDownList.SelectedItem.Text + "," + "Name:" + name.ToUpper() + "," + "address:" + add.ToUpper() + "," + "state:" + state.ToUpper() + "," + "country:" + country.ToUpper() + "," + "postcode:" + pincode;
                    int insertlogin = Queries.InsertContractLogs_India(profileidTextBox.Text, contractdetails_ID, log5in, user, DateTime.Now.ToString());
                    int updatesor = Queries.UpdateContractNo_OthernamesID(officeTextBox.Text);
                }

                asornoTextBox.Text = "";
                int existssor = Queries.ContractIDINSOR_Additional(contractdetails_ID);
                if (existssor == 1)
                {
                    GridView2.Visible = true;
                    DataSet dsor = Queries.LoadContractNo_Othernames(contractdetails_ID);
                    GridView2.DataSource = dsor;
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.Visible = false;
                }

            }
            else if (SORDropDownList.SelectedItem.Text == "Additional Name")
            {
                for (ik = 1; ik <= Convert.ToInt32(num); ik++)
                {
                    string id = Queries.GetContractNo_OthernamesID(officeTextBox.Text);
                    iname = "textBox1_" + ik + "1";
                    name = Request.Form[iname];
                    iadd = "textBox1_" + ik + "2";
                    add = Request.Form[iadd];
                    istate = "textBox1_" + ik + "3";
                    state = Request.Form[istate];
                    icountry = "textBox1_" + ik + "4";
                    country = Request.Form[icountry];
                    ipincode = "textBox1_" + ik + "5";
                    pincode = Request.Form[ipincode];

                    int insertrow = Queries.InsertContractNo_Othernames(id, contractnoTextBox.Text, contractdetails_ID, SORDropDownList.SelectedItem.Text, name.ToUpper(), add.ToUpper(), state.ToUpper(), country.ToUpper(), pincode, "Active", "", DateTime.Now.ToString());
                    string log5in = "Additional Name Details:" + "ContractdetailsID: " + contractdetails_ID + "," + "Contractno: " + contractnoTextBox.Text + "," + "Type:" + SORDropDownList.SelectedItem.Text + "," + "Name:" + name.ToUpper() + "," + "address:" + add.ToUpper() + "," + "state:" + state.ToUpper() + "," + "country:" + country.ToUpper() + "," + "postcode:" + pincode;
                    int insertlogin = Queries.InsertContractLogs_India(profileidTextBox.Text, contractdetails_ID, log5in, user, DateTime.Now.ToString());
                    int updatesor = Queries.UpdateContractNo_OthernamesID(officeTextBox.Text);
                }

                asornoTextBox.Text = "";
                int existssor = Queries.ContractIDINSOR_Additional(contractdetails_ID);
                if (existssor == 1)
                {
                    GridView2.Visible = true;
                    DataSet dsor = Queries.LoadContractNo_Othernames(contractdetails_ID);
                    GridView2.DataSource = dsor;
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.Visible = false;
                }
            }

        }

        /*  int exists = Queries.ContractIDINSOR_Additional(contractdetails_ID);
          if (exists == 1)
          {
              DataSet dsor = Queries.LoadContractNo_Othernames(contractdetails_ID);
              for(int i=0;i<dsor.Tables[0].Rows.Count;i++)
              {

                  //string otherNamesID = dsor.Tables[0].Rows[i]["otherNamesID"].ToString();
                  //string ContractNo = dsor.Tables[0].Rows[i]["ContractNo"].ToString();
                  //string ContractDetails_ID = dsor.Tables[0].Rows[i]["ContractDetails_ID"].ToString();
                  //string Type = dsor.Tables[0].Rows[i]["Type"].ToString();
                  //string Name = dsor.Tables[0].Rows[i]["Name"].ToString();
                  //string Address = dsor.Tables[0].Rows[i]["Address"].ToString();
                  //string State = dsor.Tables[0].Rows[i]["State"].ToString();
                  //string Country = dsor.Tables[0].Rows[i]["Country"].ToString();
                  //string Postcode = dsor.Tables[0].Rows[i]["Postcode"].ToString();
                  //string Status = dsor.Tables[0].Rows[i]["Status"].ToString();
                  //string Document_name = dsor.Tables[0].Rows[i]["Document_name"].ToString();
                  //string Added_Date = dsor.Tables[0].Rows[i]["Added_Date"].ToString();
                  //string log5 = "SOR/ Additional Details Deleted:" + "otherNamesID: " + otherNamesID + "," + "ContractNo: " + ContractNo + "," + "ContractDetails_ID #:" + ContractDetails_ID + "," + "Type:" + Type + "," + "Name :" + Name + "," + "Address:" + Address + "," + "State:" + State + "," + "Country: " + Country + "," + "Postcode: " + Postcode + "," + "Status: " + Status + "," + "Document_name: " + Document_name + "," + "Added_Date: " + Added_Date;

                  //int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractDetails_ID, log5, user, DateTime.Now.ToString());
                  //int delrow = Queries.DeleteContractNo_Othernames(otherNamesID);
              }
          }
          else { }*/


    }
    public void visibilityPointstrue()
    {
      
        lblAdministrationFees.Visible = false;
        AdministrationFeesTextBox.Visible = false;
        lblconversionfee.Visible = false;
        conversionfeeTextBox.Visible = false;
        lblnewpoints.Visible = true;
        newpointsTextBox.Visible = true;

    }
  
    public void visibilitytradeinPointstrue()
    {
       
        lblAdministrationFees.Visible = false;
        AdministrationFeesTextBox.Visible = false;
        lblconversionfee.Visible = true ;
        conversionfeeTextBox.Visible = true ;
        lblnewpoints.Visible = true ;
        newpointsTextBox.Visible = true ;
    }
  
    public void visibilitytradeinweekstrue()
    {
       
        lbltipnopoints.Visible = false;
        tipnopointsTextBox.Visible = false;
       
        lblAdministrationFees.Visible = false;
        AdministrationFeesTextBox.Visible = false;
        lblconversionfee.Visible = true ;
        conversionfeeTextBox.Visible = true;
        lblnewpoints.Visible = true ;
        newpointsTextBox.Visible = true ;
    }
    
    public void visibilityfractionaltrue()
   {
       
        lblconversionfee.Visible = false;
        conversionfeeTextBox.Visible = false;
        lblnewpoints.Visible = false;
        newpointsTextBox.Visible = false;
    }
   
    public void visibilitytradeinfractionaltrue()
    {
        
        lblAdministrationFees.Visible = true;
        AdministrationFeesTextBox.Visible = true;
        lblconversionfee.Visible = false;
        conversionfeeTextBox.Visible = false;
        lblnewpoints.Visible = false;
        newpointsTextBox.Visible = false;
    }
   
  
       
   
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

            htmlstr += " <input id=" + ca + "" + id + " type='checkbox' class='hello' name='aamt' onClick="  + addvalue + "() value='" + amt + "'>" + name + "";


        }

        return htmlstr;
    }
    public void SORAddltionalLoadVisibility()
    {
        lblsoraname.Visible = false;
         soranameTextBox.Visible = false;
        lblsoraaddress.Visible = false;
        soraaddressTextBox.Visible = false;
        lblsorastate.Visible = false;
        sorastateTextBox.Visible = false;        
        lblsoracountry.Visible = false;
        soracountryTextBox.Visible = false;
        lblsorapincode.Visible = false;
        sorapincodeTextBox.Visible = false;
        btndelete.Visible = false;
        btnupdate.Visible = false;

    }
    public void OnlySORLoadVisibility()
    {
        lblsoraname.Visible = true;
        soranameTextBox.Visible = true;
        lblsoraaddress.Visible = true;
        soraaddressTextBox.Visible = true;
        lblsorastate.Visible = true;
        sorastateTextBox.Visible = true;
         
        lblsoracountry.Visible = true;
        soracountryTextBox.Visible = true;
        lblsorapincode.Visible = true;
        sorapincodeTextBox.Visible = true;
        btndelete.Visible = true;
        btnupdate.Visible = true;

    }
    public void OnlyAddltionalLoadVisibility()
    {
        lblsoraname.Visible = true;
        soranameTextBox.Visible = true;
        lblsoraaddress.Visible = false;
        soraaddressTextBox.Visible = false;
        lblsorastate.Visible = false;
        sorastateTextBox.Visible = false;
        
        lblsoracountry.Visible = false;
        soracountryTextBox.Visible = false;
        lblsorapincode.Visible = false;
        sorapincodeTextBox.Visible = false;
        btndelete.Visible = true;
        btnupdate.Visible = true;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string user = (string)Session["username"];

      string sContractdetailsID= (string)Session["ContractdetailsID"]  ;
       
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
       
      
        if (!IsPostBack)
        {



         /*  contractno = Convert.ToString(Request.QueryString["ContractNo"]);
           contractnoTextBox.Text = contractno;       
           ProfileID = Queries.GetProfileIDOnContractNo(contractno);
           DataSet dsct = Queries.LoadContractNoDetails(contractno);
           ContractdetailsIDTextBox.Text= dsct.Tables[0].Rows[0]["ContractDetails_ID"].ToString();
           DataSet dsfd = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);//(contractno); */

             ContractdetailsIDTextBox.Text = sContractdetailsID;
            DataSet dsct = Queries.LoadContractNoDetailsOnContractDetails_ID(sContractdetailsID);
            contractno = dsct.Tables[0].Rows[0]["Contractno"].ToString();            
          contractnoTextBox.Text = contractno;       
          ProfileID = Queries.GetProfileIDOnContractNo(contractno);
            DataSet dsfd = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text); 


            DataSet ds = Queries.LoadProfielDetailsFull(ProfileID);
           profileidTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();
           indateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"].ToString();
           createdbyTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString();
           office = ds.Tables[0].Rows[0]["Office"].ToString();
           officeTextBox.Text = ds.Tables[0].Rows[0]["Office"].ToString();
           ophid = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
           ocard = ds.Tables[0].Rows[0]["Card_Holder"].ToString();
           commentsTextBox.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
           comment2.Text = ds.Tables[0].Rows[0]["comment2"].ToString();
           companynameTextBox.Text = ds.Tables[0].Rows[0]["Company_Name"].ToString().ToUpper();
            gstinTextBox.Text  = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
            companypanoTextBox.Text  = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
            ocogstin = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
            ocompanypano = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();

            //load sor names etc
            SORAddltionalLoadVisibility();
            int existssor = Queries.ContractIDINSOR_Additional(ContractdetailsIDTextBox.Text);
           if(existssor==1)
           {
               GridView2.Visible = true;
               DataSet dsor = Queries.LoadContractNo_Othernames(ContractdetailsIDTextBox.Text);
               GridView2.DataSource = dsor;
               GridView2.DataBind();


           }
           else
           {
               GridView2.Visible = false;
           }


            DataSet dsreceiptdetails = Queries.LoadContract_Indian_Deposit_ReceiptDetails(ContractdetailsIDTextBox.Text);
            GridView3.DataSource = dsreceiptdetails;
            GridView3.DataBind();
                DataSet dsdepmethd = Queries.LoadDepositPaymentMethod(office);
                depositmethodaddDropDownList.DataSource = dsdepmethd;
                depositmethodaddDropDownList.DataTextField = "Deposit_pay_method_name";
                depositmethodaddDropDownList.DataValueField = "Deposit_pay_method_name";
                depositmethodaddDropDownList.AppendDataBoundItems = true;
                depositmethodaddDropDownList.Items.Insert(0, new ListItem("", ""));
                depositmethodaddDropDownList.DataBind();

                //DataSet dsfm = Queries.LoadFinanceMethod(office);
                //financemethodDropDownList.DataSource = dsfm;
                //financemethodDropDownList.DataTextField = "Finance_Name";
                //financemethodDropDownList.DataValueField = "Finance_Name";
                //financemethodDropDownList.AppendDataBoundItems = true;
                //financemethodDropDownList.Items.Insert(0, new ListItem("", ""));
                //financemethodDropDownList.DataBind();

                //loading venuecountry on load
                DataSet ds1 = Queries.LoadProfileVenueCountry(ProfileID);
           VenueCountryDropDownList.DataSource = ds1;
           VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
           VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
           VenueCountryDropDownList.AppendDataBoundItems = true;
           VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
           VenueCountryDropDownList.DataBind();

           //loading venue on load
           DataSet ds2 = Queries.LoadProfileVenue(ProfileID, VenueCountryDropDownList.SelectedItem.Text);
           VenueDropDownList.DataSource = ds2;
           VenueDropDownList.DataTextField = "Venue_Name";
           VenueDropDownList.DataValueField = "Venue_Name";
           VenueDropDownList.AppendDataBoundItems = true;
           VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
           VenueDropDownList.DataBind();

           // loading venuegroup on load
           DataSet ds3 = Queries.LoadProfileVenueGroup(ProfileID, VenueDropDownList.SelectedItem.Text);
           GroupVenueDropDownList.DataSource = ds3;
           GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
           GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
           GroupVenueDropDownList.AppendDataBoundItems = true;
           GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
           GroupVenueDropDownList.DataBind();

           //loading marketing program on load
           DataSet ds4 = Queries.LoadProfileMktg(ProfileID, VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
           MarketingProgramDropDownList.DataSource = ds4;
           MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
           MarketingProgramDropDownList.DataValueField = "Marketing_Program_Name";
           MarketingProgramDropDownList.AppendDataBoundItems = true;
           MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
           MarketingProgramDropDownList.DataBind();

           // loading agents on load as per venue group
           if (GroupVenueDropDownList.SelectedItem.Text == "Coldline")
           {
               //     DataSet ds5 = Queries.LoadProfileAgent(ProfileID);
               DataSet ds5 = Queries.LoadProfileAgent1(ProfileID, VenueDropDownList.SelectedItem.Text);
               AgentDropDownList.DataSource = ds5;
               AgentDropDownList.DataTextField = "agentname";
               AgentDropDownList.DataValueField = "agentname";
               AgentDropDownList.AppendDataBoundItems = true;
               AgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
               AgentDropDownList.DataBind();


           }
           else
           {
               DataSet ds5 = Queries.LoadProfileAgentNotColdline(ProfileID, VenueDropDownList.SelectedItem.Text);
               AgentDropDownList.DataSource = ds5;
               AgentDropDownList.DataTextField = "Sales_Rep_Name";
               AgentDropDownList.DataValueField = "Sales_Rep_Name";
               AgentDropDownList.AppendDataBoundItems = true;
               AgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
               AgentDropDownList.DataBind();



           }

           // loading To name on load as per venue group
           if (GroupVenueDropDownList.SelectedItem.Text == "Coldline")
           {
               // load to11
               DataSet ds5aa = Queries.LoadTOOPCOnVenue11(ProfileID, VenueDropDownList.SelectedItem.Text);
               TONameDropDownList.DataSource = ds5aa;
               TONameDropDownList.DataTextField = "to_name";
               TONameDropDownList.DataValueField = "to_name";
               TONameDropDownList.AppendDataBoundItems = true;
               TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
               TONameDropDownList.DataBind();


           }
           else
           {
               // load to12
               DataSet ds5aa = Queries.LoadTOOPCOnVenue12(ProfileID, VenueDropDownList.SelectedItem.Text);
               TONameDropDownList.DataSource = ds5aa;
               TONameDropDownList.DataTextField = "TO_Manager_Name";
               TONameDropDownList.DataValueField = "TO_Manager_Name";
               TONameDropDownList.AppendDataBoundItems = true;
               TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
               TONameDropDownList.DataBind();



           }


           DataSet dsmg = Queries.LoadProfileManager(ProfileID, VenueDropDownList.SelectedItem.Text);
           ManagerDropDownList.DataSource = dsmg;
           ManagerDropDownList.DataTextField = "Manager_Name";
           ManagerDropDownList.DataValueField = "Manager_Name";
           ManagerDropDownList.AppendDataBoundItems = true;
           ManagerDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["manager"].ToString(), ""));
           ManagerDropDownList.DataBind();



           if (MarketingProgramDropDownList.SelectedItem.Text == "Owner" || MarketingProgramDropDownList.SelectedItem.Text == "OWNER")
           {
               // loadprofilememebertype
               DataSet dsmgs = Queries.LoadProfileMemberType(ProfileID);
               MemType1DropDownList.DataSource = dsmgs;
               MemType1DropDownList.DataTextField = "Member_Type_Name";
               MemType1DropDownList.DataValueField = "Member_Type_Name";
               MemType1DropDownList.AppendDataBoundItems = true;
               MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
               MemType1DropDownList.DataBind();


               Memno1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();

               // load profiletype
               DataSet dsmgss = Queries.LoadProfileType(ProfileID);
               TypeDropDownList.DataSource = dsmgss;
               TypeDropDownList.DataTextField = "Type_Name";
               TypeDropDownList.DataValueField = "Type_Name";
               TypeDropDownList.AppendDataBoundItems = true;
               TypeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString(), ""));
               TypeDropDownList.DataBind();
           }
           else
           {


               // profilemembertype
               DataSet dsmgs = Queries.LoadProfileMemberType(ProfileID);
               MemType1DropDownList.DataSource = dsmgs;
               MemType1DropDownList.DataTextField = "Member_Type_Name";
               MemType1DropDownList.DataValueField = "Member_Type_Name";
               MemType1DropDownList.AppendDataBoundItems = true;
               MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
               MemType1DropDownList.DataBind();
               // load profiletype
               DataSet dsmgss = Queries.LoadProfileType(ProfileID);
               TypeDropDownList.DataSource = dsmgss;
               TypeDropDownList.DataTextField = "Type_Name";
               TypeDropDownList.DataValueField = "Type_Name";
               TypeDropDownList.AppendDataBoundItems = true;
               TypeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString(), ""));
               TypeDropDownList.DataBind();


           }






           DataSet dsptitle = Queries.LoadPrimarySalutation(ProfileID,office);
           PrimaryTitleDropDownList.DataSource = dsptitle;
           PrimaryTitleDropDownList.DataTextField = "Salutation";
           PrimaryTitleDropDownList.DataValueField = "Salutation";
           PrimaryTitleDropDownList.AppendDataBoundItems = true;
           PrimaryTitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
           PrimaryTitleDropDownList.DataBind();

           pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
           plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
           primarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("dd-MM-yyyy");
           primaryAge.Text = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
           pdesginationTextBox.Text = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();


           DataSet dspnationality = Queries.LoadPrimaryNationality(ProfileID);
           PrimarynationalityDropDownList.DataSource = dspnationality;
           PrimarynationalityDropDownList.DataTextField = "Nationality_Name";
           PrimarynationalityDropDownList.DataValueField = "Nationality_Name";
           PrimarynationalityDropDownList.AppendDataBoundItems = true;
           PrimarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
           PrimarynationalityDropDownList.DataBind();

           DataSet dspcountry = Queries.LoadCountryPrimary(ProfileID);
           primarycountryDropDownList.DataSource = dspcountry;
           primarycountryDropDownList.DataTextField = "country_name";
           primarycountryDropDownList.DataValueField = "country_name";
           primarycountryDropDownList.AppendDataBoundItems = true;
           primarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
           primarycountryDropDownList.DataBind();



           pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();

           DataSet dspm = Queries.LoadCountryWithCodePrimaryMobile(ProfileID);
           primarymobileDropDownList.DataSource = dspm;
           primarymobileDropDownList.DataTextField = "name";
           primarymobileDropDownList.DataValueField = "name";
           primarymobileDropDownList.AppendDataBoundItems = true;
           primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
           primarymobileDropDownList.DataBind();

           pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();

            DataSet dspalt = Queries.LoadCountryWithCodePrimaryAlt(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString());// ProfileID);
           primaryalternateDropDownList.DataSource = dspalt;
           primaryalternateDropDownList.DataTextField = "name";
           primaryalternateDropDownList.DataValueField = "name";
           primaryalternateDropDownList.AppendDataBoundItems = true;
           primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
           primaryalternateDropDownList.DataBind();
           palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();

            DataSet dspoff = Queries.LoadCountryWithCodePrimaryOffice(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString());// ProfileID);
           pofficecodeDropDownList.DataSource = dspoff;
           pofficecodeDropDownList.DataTextField = "name";
           pofficecodeDropDownList.DataValueField = "name";
           pofficecodeDropDownList.AppendDataBoundItems = true;
           pofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_office_cc"].ToString(), ""));
           pofficecodeDropDownList.DataBind();
           pofficenoTextBox.Text = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();



           //secondary details
           DataSet dsstitle = Queries.LoadSecondarySalutation(ProfileID,office);
           secondarytitleDropDownList.DataSource = dsstitle;
           secondarytitleDropDownList.DataTextField = "Salutation";
           secondarytitleDropDownList.DataValueField = "Salutation";
           secondarytitleDropDownList.AppendDataBoundItems = true;
           secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Title"].ToString(), ""));
           secondarytitleDropDownList.DataBind();

           sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Fname"].ToString();
           slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Lname"].ToString();
           secondarydobdatepicker.Text  = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_secondary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_secondary_DOB"].ToString()).ToString("dd-MM-yyyy");
           secondaryAge.Text = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
           sdesignationTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();

           DataSet dssnationality = Queries.LoadSecondaryNationality(ProfileID);
           secondarynationalityDropDownList.DataSource = dssnationality;
           secondarynationalityDropDownList.DataTextField = "Nationality_Name";
           secondarynationalityDropDownList.DataValueField = "Nationality_Name";
           secondarynationalityDropDownList.AppendDataBoundItems = true;
           secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Nationality"].ToString(), ""));
           secondarynationalityDropDownList.DataBind();

           DataSet dsscountry = Queries.LoadCountrySecondary(ProfileID);
           secondarycountryDropDownList.DataSource = dsscountry;
           secondarycountryDropDownList.DataTextField = "country_name";
           secondarycountryDropDownList.DataValueField = "country_name";
           secondarycountryDropDownList.AppendDataBoundItems = true;
           secondarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString(), ""));
           secondarycountryDropDownList.DataBind();



           semailTextBox.Text = ds.Tables[0].Rows[0]["secondary_Email"].ToString();

            DataSet dssm = Queries.LoadCountryWithCodeSecondaryMobile(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString());// ProfileID);
           secondarymobileDropDownList.DataSource = dssm;
           secondarymobileDropDownList.DataTextField = "name";
           secondarymobileDropDownList.DataValueField = "name";
           secondarymobileDropDownList.AppendDataBoundItems = true;
           secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_CC"].ToString(), ""));
           secondarymobileDropDownList.DataBind();

           smobileTextBox.Text = ds.Tables[0].Rows[0]["secondary_Mobile"].ToString();

            DataSet dssalt = Queries.LoadCountryWithCodeSecondaryAlt(ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString());// ProfileID);
           secondaryalternateDropDownList.DataSource = dssalt;
           secondaryalternateDropDownList.DataTextField = "name";
           secondaryalternateDropDownList.DataValueField = "name";
           secondaryalternateDropDownList.AppendDataBoundItems = true;
           secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_Alt_CC"].ToString(), ""));
           secondaryalternateDropDownList.DataBind();
           salternateTextBox.Text = ds.Tables[0].Rows[0]["secondary_Alternate"].ToString();


            DataSet dssoff = Queries.LoadCountryWithCodeSecondaryOffice(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString());// ProfileID);
           sofficecodeDropDownList.DataSource = dssoff;
           sofficecodeDropDownList.DataTextField = "name";
           sofficecodeDropDownList.DataValueField = "name";
           sofficecodeDropDownList.AppendDataBoundItems = true;
           sofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString(), ""));
           sofficecodeDropDownList.DataBind();
           sofficenoTextBox.Text = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();

           //address
           address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
           address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
           //stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
           cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
           pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
           livingyrsTextBox.Text = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

           DataSet ds12 = Queries.LoadCountryName();
           AddCountryDropDownList.DataSource = ds12;
           AddCountryDropDownList.DataTextField = "country_name";
           AddCountryDropDownList.DataValueField = "country_name";
           AddCountryDropDownList.AppendDataBoundItems = true;
           AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
           AddCountryDropDownList.DataBind();

           //state Name
           DataSet ds1222 = Queries.LoadStateName(ProfileID, AddCountryDropDownList.SelectedItem.Text);
           StateDropDownList.DataSource = ds1222;
           StateDropDownList.DataTextField = "State_Name";
           StateDropDownList.DataValueField = "State_Name";
           StateDropDownList.AppendDataBoundItems = true;
           StateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_State"].ToString(), ""));
           StateDropDownList.DataBind();


           DataSet dsemploy = Queries.LoadEmploymentStatusNotInProfile(ProfileID);
           employmentstatusDropDownList.DataSource = dsemploy;
           employmentstatusDropDownList.DataTextField = "Name";
           employmentstatusDropDownList.DataValueField = "Name";
           employmentstatusDropDownList.AppendDataBoundItems = true;
           employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
           employmentstatusDropDownList.DataBind();


           DataSet dsmart = Queries.LoadMaritalStatusNotInProfile(ProfileID);
           maritalstatusDropDownList.DataSource = dsmart;
           maritalstatusDropDownList.DataTextField = "MaritalStatus";
           maritalstatusDropDownList.DataValueField = "MaritalStatus";
           maritalstatusDropDownList.AppendDataBoundItems = true;
           maritalstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
           maritalstatusDropDownList.DataBind();



           DataSet dssp1title = Queries.LoadSub_Profile1Salutation(ProfileID,office);
           sp1titleDropDownList.DataSource = dssp1title;
           sp1titleDropDownList.DataTextField = "Salutation";
           sp1titleDropDownList.DataValueField = "Salutation";
           sp1titleDropDownList.AppendDataBoundItems = true;
           sp1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
           sp1titleDropDownList.DataBind();

           sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
           sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
           //   sp1dobdatepicker.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("dd-MM-yyyy");
           sp1dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);
           subProfile1Age.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

           DataSet dssp1nationality = Queries.LoadSub_Profile1Nationality(ProfileID);
           sp1nationalityDropDownList.DataSource = dssp1nationality;
           sp1nationalityDropDownList.DataTextField = "Nationality_Name";
           sp1nationalityDropDownList.DataValueField = "Nationality_Name";
           sp1nationalityDropDownList.AppendDataBoundItems = true;
           sp1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
           sp1nationalityDropDownList.DataBind();

           DataSet dssp1country = Queries.LoadCountrySP1(ProfileID);
           sp1countryDropDownList.DataSource = dssp1country;
           sp1countryDropDownList.DataTextField = "country_name";
           sp1countryDropDownList.DataValueField = "country_name";
           sp1countryDropDownList.AppendDataBoundItems = true;
           sp1countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
           sp1countryDropDownList.DataBind();



           sp1pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();

            DataSet dssp1m = Queries.LoadCountryWithCodeSP1Mobile(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());// ProfileID);
           sp1mobileDropDownList.DataSource = dssp1m;
           sp1mobileDropDownList.DataTextField = "name";
           sp1mobileDropDownList.DataValueField = "name";
           sp1mobileDropDownList.AppendDataBoundItems = true;
           sp1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
           sp1mobileDropDownList.DataBind();

           sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();

            DataSet dssp1alt = Queries.LoadCountryWithCodeSP1Alt(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());// ProfileID);
           sp1alternateDropDownList.DataSource = dssp1alt;
           sp1alternateDropDownList.DataTextField = "name";
           sp1alternateDropDownList.DataValueField = "name";
           sp1alternateDropDownList.AppendDataBoundItems = true;
           sp1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
           sp1alternateDropDownList.DataBind();
           sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();



           DataSet dssp2title = Queries.LoadSub_Profile2Salutation(ProfileID,office);
           sp2titleDropDownList.DataSource = dssp2title;
           sp2titleDropDownList.DataTextField = "Salutation";
           sp2titleDropDownList.DataValueField = "Salutation";
           sp2titleDropDownList.AppendDataBoundItems = true;
           sp2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
           sp2titleDropDownList.DataBind();

           sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
           sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
           //   sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("dd-MM-yyyy");
           sp2dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);
           subProfile2Age.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

           DataSet dssp2nationality = Queries.LoadSub_Profile2Nationality(ProfileID);
           sp2nationalityDropDownList.DataSource = dssp2nationality;
           sp2nationalityDropDownList.DataTextField = "Nationality_Name";
           sp2nationalityDropDownList.DataValueField = "Nationality_Name";
           sp2nationalityDropDownList.AppendDataBoundItems = true;
           sp2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
           sp2nationalityDropDownList.DataBind();

           DataSet dssp2country = Queries.LoadCountrySP2(ProfileID);
           sp2countryDropDownList.DataSource = dssp2country;
           sp2countryDropDownList.DataTextField = "country_name";
           sp2countryDropDownList.DataValueField = "country_name";
           sp2countryDropDownList.AppendDataBoundItems = true;
           sp2countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
           sp2countryDropDownList.DataBind();
           sp2pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

            DataSet dssp2m = Queries.LoadCountryWithCodeSP2Mobile(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());// ProfileID);
           sp2mobileDropDownList.DataSource = dssp2m;
           sp2mobileDropDownList.DataTextField = "name";
           sp2mobileDropDownList.DataValueField = "name";
           sp2mobileDropDownList.AppendDataBoundItems = true;
           sp2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
           sp2mobileDropDownList.DataBind();

           sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();

            DataSet dssp2alt = Queries.LoadCountryWithCodeSP2Alt(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());// ProfileID);
           sp2alternateDropDownList.DataSource = dssp2alt;
           sp2alternateDropDownList.DataTextField = "name";
           sp2alternateDropDownList.DataValueField = "name";
           sp2alternateDropDownList.AppendDataBoundItems = true;
           sp2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
           sp2alternateDropDownList.DataBind();
           sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();


           //sub profile 3///
           DataSet dssp3title = Queries.LoadSub_Profile3Salutation(ProfileID,office);
           sp3titleDropDownList.DataSource = dssp3title;
           sp3titleDropDownList.DataTextField = "Salutation";
           sp3titleDropDownList.DataValueField = "Salutation";
           sp3titleDropDownList.AppendDataBoundItems = true;
           sp3titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
           sp3titleDropDownList.DataBind();

           sp3fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
           sp3lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();

           //sp3dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("dd-MM-yyyy");
           sp3dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);


           subProfile3Age.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

           DataSet dssp3nationality = Queries.LoadSub_Profile3Nationality(ProfileID);
           sp3nationalityDropDownList.DataSource = dssp3nationality;
           sp3nationalityDropDownList.DataTextField = "Nationality_Name";
           sp3nationalityDropDownList.DataValueField = "Nationality_Name";
           sp3nationalityDropDownList.AppendDataBoundItems = true;
           sp3nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
           sp3nationalityDropDownList.DataBind();

           DataSet dssp3country = Queries.LoadCountrySP3(ProfileID);
           sp3countryDropDownList.DataSource = dssp3country;
           sp3countryDropDownList.DataTextField = "country_name";
           sp3countryDropDownList.DataValueField = "country_name";
           sp3countryDropDownList.AppendDataBoundItems = true;
           sp3countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
           sp3countryDropDownList.DataBind();
           sp3pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();

            DataSet dssp3m = Queries.LoadCountryWithCodeSP3Mobile(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());// ProfileID);
           sp3mobileDropDownList.DataSource = dssp3m;
           sp3mobileDropDownList.DataTextField = "name";
           sp3mobileDropDownList.DataValueField = "name";
           sp3mobileDropDownList.AppendDataBoundItems = true;
           sp3mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
           sp3mobileDropDownList.DataBind();

           sp3mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();

            DataSet dssp3alt = Queries.LoadCountryWithCodeSP3Alt(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());// ProfileID);
           sp3alternateDropDownList.DataSource = dssp3alt;
           sp3alternateDropDownList.DataTextField = "name";
           sp3alternateDropDownList.DataValueField = "name";
           sp3alternateDropDownList.AppendDataBoundItems = true;
           sp3alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
           sp3alternateDropDownList.DataBind();
           sp3alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
           // end//


           //// sub profile 4//
           DataSet dssp4title = Queries.LoadSub_Profile3Salutation(ProfileID,office);
           sp4titleDropDownList.DataSource = dssp4title;
           sp4titleDropDownList.DataTextField = "Salutation";
           sp4titleDropDownList.DataValueField = "Salutation";
           sp4titleDropDownList.AppendDataBoundItems = true;
           sp4titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
           sp4titleDropDownList.DataBind();

           sp4fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
           sp4lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();

           //  sp4dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("dd-MM-yyyy");
           sp4dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]);



           subProfile4Age.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

           DataSet dssp4nationality = Queries.LoadSub_Profile3Nationality(ProfileID);
           sp4nationalityDropDownList.DataSource = dssp4nationality;
           sp4nationalityDropDownList.DataTextField = "Nationality_Name";
           sp4nationalityDropDownList.DataValueField = "Nationality_Name";
           sp4nationalityDropDownList.AppendDataBoundItems = true;
           sp4nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
           sp4nationalityDropDownList.DataBind();

           DataSet dssp4country = Queries.LoadCountrySP3(ProfileID);
           sp4countryDropDownList.DataSource = dssp4country;
           sp4countryDropDownList.DataTextField = "country_name";
           sp4countryDropDownList.DataValueField = "country_name";
           sp4countryDropDownList.AppendDataBoundItems = true;
           sp4countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
           sp4countryDropDownList.DataBind();
           sp4pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

            DataSet dssp4m = Queries.LoadCountryWithCodeSP3Mobile(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());// ProfileID);
           sp4mobileDropDownList.DataSource = dssp4m;
           sp4mobileDropDownList.DataTextField = "name";
           sp4mobileDropDownList.DataValueField = "name";
           sp4mobileDropDownList.AppendDataBoundItems = true;
           sp4mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
           sp4mobileDropDownList.DataBind();

           sp4mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();


            DataSet dssp4alt = Queries.LoadCountryWithCodeSP3Alt(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());// ProfileID);
           sp4alternateDropDownList.DataSource = dssp4alt;
           sp4alternateDropDownList.DataTextField = "name";
           sp4alternateDropDownList.DataValueField = "name";
           sp4alternateDropDownList.AppendDataBoundItems = true;
           sp4alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
           sp4alternateDropDownList.DataBind();
           sp4alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
           ////end//


           resortTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();

           roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
           arrivaldatedatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("dd-MM-yyyy");
           departuredatedatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("dd-MM-yyyy");
           tourdatedatepicker.Text = String.Format("{0:yyyy-MM-dd}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToShortDateString();
           timeinTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
           timeoutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
           inpriceTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
           inrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
           outpriceTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
           outrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();


           DataSet dsqual = Queries.LoadGuestStatusInProfile(ProfileID);
           guestatusDropDownList.DataSource = dsqual;
           guestatusDropDownList.DataTextField = "Guest_Status_name";
           guestatusDropDownList.DataValueField = "Guest_Status_name";
           guestatusDropDownList.AppendDataBoundItems = true;
           guestatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
           guestatusDropDownList.DataBind();

           DataSet dstour = Queries.LoadSalesRepsInProfile1(office, ProfileID, VenueDropDownList.SelectedItem.Text);
           toursalesrepDropDownList.DataSource = dstour;
           toursalesrepDropDownList.DataTextField = "Sales_Rep_Name";
           toursalesrepDropDownList.DataValueField = "Sales_Rep_Name";
           toursalesrepDropDownList.AppendDataBoundItems = true;
           toursalesrepDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
           toursalesrepDropDownList.DataBind();



           //  load all sales rep based on office

         /*  DataSet ds7 = Queries.LoadSalesRepsInProfile1(office, ProfileID, VenueDropDownList.SelectedItem.Text);// LoadSalesReps(office);
           contsalesrepDropDownList.DataSource = ds7;
           contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
           contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
           contsalesrepDropDownList.AppendDataBoundItems = true;
           //contsalesrepDropDownList.Items.Insert(0, new ListItem("", ""));
           contsalesrepDropDownList.Items.Insert(0, new ListItem(dsct.Tables[0].Rows[0]["Sales_Rep"].ToString(), ""));
           contsalesrepDropDownList.DataBind();*/
            contsalesrepTextBox.Text = dsct.Tables[0].Rows[0]["Sales_Rep"].ToString();
            //   load TO based on office


            DataSet dsto = Queries.LoadTOManagerOnVenue(office, VenueDropDownList.SelectedItem.Text);
            TOManagerDropDownList.DataSource = dsto;
            TOManagerDropDownList.DataTextField = "TO_Manager_Name";
            TOManagerDropDownList.DataValueField = "TO_Manager_Name";
            TOManagerDropDownList.AppendDataBoundItems = true;
            TOManagerDropDownList.Items.Insert(0, new ListItem(dsct.Tables[0].Rows[0]["TO_Manager"].ToString(), ""));
            TOManagerDropDownList.DataBind();


            DataSet dsbu = Queries.LoadButtonUpOnVenue(office, VenueDropDownList.SelectedItem.Text);
            ButtonUpDropDownList.DataSource = dsbu;
            ButtonUpDropDownList.DataTextField = "ButtonUp_Name";
            ButtonUpDropDownList.DataValueField = "ButtonUp_Name";
            ButtonUpDropDownList.AppendDataBoundItems = true;
            ButtonUpDropDownList.Items.Insert(0, new ListItem(dsct.Tables[0].Rows[0]["ButtonUp_Officer"].ToString(), ""));
            ButtonUpDropDownList.DataBind();


            DataSet dsdstatus = Queries.contractdealstatus(ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);        
            dealstatusDropDownList.DataSource = dsdstatus;
            dealstatusDropDownList.DataTextField = "Status_Type";
            dealstatusDropDownList.DataValueField = "Status_Type";
            dealstatusDropDownList.AppendDataBoundItems = true;
            dealstatusDropDownList.Items.Insert(0, new ListItem(dsct.Tables[0].Rows[0]["DealStatus"].ToString(), ""));
            dealstatusDropDownList.DataBind();

            dealdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["DealRegistered_Date"]);

            //Contract tab
            //load contract type
            contracttypeTextBox.Text = dsct.Tables[0].Rows[0]["ContractType"].ToString();
            CanxContractNoTextBox.Text= dsct.Tables[0].Rows[0]["CanxContractNo"].ToString();
            string conttypevalue = dsct.Tables[0].Rows[0]["ContractType"].ToString();
            string Finance_Details = dsct.Tables[0].Rows[0]["Finance_Details"].ToString();
            LoanBUOfficerTextBox.Text = dsct.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
            ocontractcomment= dsct.Tables[0].Rows[0]["Contract_comment"].ToString();
            contractcommentTextBox.Text= dsct.Tables[0].Rows[0]["Contract_comment"].ToString();
            omcwv = dsct.Tables[0].Rows[0]["MCWaiver"].ToString();
            if (omcwv == "No" || omcwv == "NO")
            {
                mcRadioButtonList.Checked = false;
            }
            else if (omcwv == "Yes" || omcwv == "YES")
            {
                mcRadioButtonList.Checked = true;
            }

             if (conttypevalue == "Points")
            {

                visibilityPointstrue();
               
                DataSet dspts = Queries.LoadNewPointsDetails(ContractdetailsIDTextBox.Text);
                if (dspts.Tables[0].Rows.Count == 0)
                {
                    clubTextBox.Text = "";
                    newpointsrightTextBox.Text = "";
                    EntitlementPoinDropDownList.Text = "";
                    totalptrightsTextBox.Text = "";
                    firstyrTextBox.Text = "";
                    tenureTextBox.Text = "";
                    lastyrTextBox.Text = "";
                }
                else
                {

                    clubTextBox.Text = dspts.Tables[0].Rows[0]["club"].ToString();
                    newpointsrightTextBox.Text = dspts.Tables[0].Rows[0]["New_points_rights"].ToString();
                    DataSet dspten = Queries.pointsentitlement(contractnoTextBox.Text);
                    EntitlementPoinDropDownList.Items.Add(dspts.Tables[0].Rows[0]["Type_membership"].ToString());
                    EntitlementPoinDropDownList.Items.Add(dspten.Tables[0].Rows[0]["Entitlement_Name"].ToString());
                    totalptrightsTextBox.Text = dspts.Tables[0].Rows[0]["Total_points_rights"].ToString();
                    firstyrTextBox.Text = dspts.Tables[0].Rows[0]["First_year_occupancy"].ToString();
                    tenureTextBox.Text = dspts.Tables[0].Rows[0]["Tenure"].ToString();
                    lastyrTextBox.Text = dspts.Tables[0].Rows[0]["Last_year_occupancy"].ToString();
                    NoPersonsTextBox.Text = dspts.Tables[0].Rows[0]["NoPersons"].ToString();

                    opts_club = dspts.Tables[0].Rows[0]["club"].ToString();
                    opts_newpts = dspts.Tables[0].Rows[0]["New_points_rights"].ToString();
                    opts_entitlement = dspts.Tables[0].Rows[0]["Type_membership"].ToString();
                    opts_totalpts = dspts.Tables[0].Rows[0]["Total_points_rights"].ToString();
                    opts_firstyr = dspts.Tables[0].Rows[0]["First_year_occupancy"].ToString();
                    opts_Tenure = dspts.Tables[0].Rows[0]["Tenure"].ToString();
                    opts_lastyr = dspts.Tables[0].Rows[0]["Last_year_occupancy"].ToString();
                    opts_nopersons = dspts.Tables[0].Rows[0]["NoPersons"].ToString();


                    //load finance details

                    DataSet dsptsf = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);// contractno);
                    financeradiobuttonlist.SelectedValue = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
                    MCFeesTextBox.Text = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    MCdateTextBox.Text =  dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    memberfeeTextBox.Text = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    memcgstTextBox.Text = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    memsgstTextBox.Text = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    adharcardTextBox.Text = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                    pancardnoTextBox.Text = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                    companypanoTextBox.Text = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
                    gstinTextBox.Text = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
                

                    DataSet dscur = Queries.currencyfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);

                    currencyDropDownList.DataSource = dscur;
                    currencyDropDownList.DataTextField = "Finance_Currency_Name";
                    currencyDropDownList.DataValueField = "Finance_Currency_Name";
                    currencyDropDownList.AppendDataBoundItems = true;
                    currencyDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["currency"].ToString(), ""));
                    currencyDropDownList.DataBind();
                    totalfinpriceIntaxTextBox.Text = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    intialdeppercentTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                    balinitialdepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();

                    obalpayable = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();


                    baldepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
                    
                    regcollectiontermTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                    regcollamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                    baladepamtdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"]); //Convert.ToDateTime (dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString()).ToString("yyyy-MM-dd");
                    oldLoanAgreementTextBox.Text = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();

                    DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                   // PayMethodDropDownList.Items.Add(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString());
                     //   financemethodDropDownList.Items.Clear();
                    PayMethodDropDownList.DataSource = dspym;
                    PayMethodDropDownList.DataTextField = "pay_method_name";
                    PayMethodDropDownList.DataValueField = "pay_method_name";
                    PayMethodDropDownList.AppendDataBoundItems = true;
                    PayMethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString(), ""));
                    PayMethodDropDownList.DataBind();

                    NoinstallmentTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    installmentamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    balamtpayableTextBox.Text = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                    omcfees = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    omcdate = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    omemberfee = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    omemebercgst = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    omembersgst = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    oadhar = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                    opan = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                    ocurrency = dsptsf.Tables[0].Rows[0]["currency"].ToString();
                    oaffiliate = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                    ototalintax = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    odepamt = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();

                    odepbal = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
                    onoinstallment = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    oinstallment = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    ototalbalance = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                    oregcollectionterm = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                    oregcollamt = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                    obaladepamtdate = dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString();
                    ooldLoanAgreement = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();

                    //if (dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString() == "Finance")
                    //{
                    DataSet dsfin = Queries.financemethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                    //   financemethodDropDownList.Items.Clear();
                    financemethodDropDownList.DataSource = dsfin;
                    financemethodDropDownList.DataTextField = "Finance_Name";
                    financemethodDropDownList.DataValueField = "Finance_Name";
                    financemethodDropDownList.AppendDataBoundItems = true;
                    financemethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString(), ""));
                    financemethodDropDownList.DataBind();
                    FinancenoTextBox.Text = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                    finmonthTextBox.Text = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                    noemiTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                    emiamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                    findocfeeTextBox.Text = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                    isgtrateTextBox.Text = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                    igstamtTextBox.Text = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                    interestrateTextBox.Text = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
                    ofinancemethod = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();
                    oFinanceno = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                    ofinmonth = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                    onoemi = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                    oemiamt = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                    ofindocfee = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                    oisgtrate = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                    oigstamt = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                    ointerestrate = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
                    //}
                    //else if (dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString() == "Non Finance")
                    //{



                    //}

                    //load PA details
                    DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);

                    newpointsTextBox.Text = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
                    conversionfeeTextBox.Text = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
                    adminfeeTextBox.Text = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                    testadminfeeTextBox.Text = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                    totpurchpriceTextBox.Text = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                    cgstTextBox.Text = dspa.Tables[0].Rows[0]["Cgst"].ToString();
                    sgstTextBox.Text = dspa.Tables[0].Rows[0]["Sgst"].ToString();
                    totalpriceInTaxTextBox.Text = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    depositTextBox.Text = dspa.Tables[0].Rows[0]["Deposit"].ToString();
                    balanceTextBox.Text = dspa.Tables[0].Rows[0]["Balance"].ToString();
                    balancedueTextBox.Text = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                    remarksTextBox.Text = dspa.Tables[0].Rows[0]["Remarks"].ToString();

                    onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
                    oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
                    oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                    ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                    ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
                    osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
                    ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
                    obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
                    obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                    oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();
                    //load installments
                    DataSet dsin = Queries.contractInstallment(ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);
                    if (dsin.Tables[0].Rows.Count == 0)
                    {
                        GridView1.Visible = false;

                    }
                    else
                    {

                        GridView1.Visible = true;
                        GridView1.DataSource = dsin;
                        GridView1.DataBind();
                    }
                    //load receipt
                    DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_Receipt(ContractdetailsIDTextBox.Text);
                    if (dsreceipt.Tables[0].Rows.Count == 0)
                    {
                        DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                        depositmethodDropDownList.DataSource = dsdep;
                        depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                        depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                        depositmethodDropDownList.AppendDataBoundItems = true;
                        depositmethodDropDownList.Items.Insert(0, new ListItem("", ""));
                        depositmethodDropDownList.DataBind();
                        invoicedateTextBox.Text = "";

                    }
                    else
                    { 
                        DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                    depositmethodDropDownList.DataSource = dsdep;
                    depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                    depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                    depositmethodDropDownList.AppendDataBoundItems = true;
                    depositmethodDropDownList.Items.Insert(0, new ListItem(dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString(), ""));
                    depositmethodDropDownList.DataBind();
                    invoicedateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsreceipt.Tables[0].Rows[0]["Receipt_Date"]);// Convert.ToDateTime(dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString()).ToString("yyyy-MM-dd");
                }
                }


                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, oaffiliate, omcwv, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);


            }
            else if (conttypevalue == "Trade-In-Points")
            {
                visibilitytradeinPointstrue();
                DataSet dstip = Queries.LoadTradeinPointsDetails(ContractdetailsIDTextBox.Text);//contractno);
                if (dstip.Tables[0].Rows.Count == 0)
                {
                    tnmresortTextBox.Text = "";
                    tipnopointsTextBox.Text = "";
                    nmcontrcinoTextBox.Text = "";
                    tipptsvalueTextBox.Text = "";
                    clubTextBox.Text = "";
                    newpointsrightTextBox.Text = "";
                    EntitlementPoinDropDownList.SelectedIndex = 0;
                    totalptrightsTextBox.Text = "";
                    firstyrTextBox.Text = "";
                    tenureTextBox.Text = "";
                    lastyrTextBox.Text = "";
                }
                else
                {
                    tnmresortTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_club_resort"].ToString();
                    tipnopointsTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_No_rights"].ToString();
                    nmcontrcinoTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_ContNo_RCINo"].ToString();
                    tipptsvalueTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_Points_value"].ToString();
                    clubTextBox.Text = dstip.Tables[0].Rows[0]["New_Club"].ToString();
                    newpointsrightTextBox.Text = dstip.Tables[0].Rows[0]["New_Club_Points_Rights"].ToString();
                    NoPersonsTextBox.Text = dstip.Tables[0].Rows[0]["NoPersons"].ToString();


                    DataSet dstipen = Queries.tradeinpointsentitlement(ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);
                    EntitlementPoinDropDownList.Items.Add(dstip.Tables[0].Rows[0]["New_MemebrshipType"].ToString());
                    EntitlementPoinDropDownList.Items.Add(dstipen.Tables[0].Rows[0]["Entitlement_Name"].ToString());

                    totalptrightsTextBox.Text = dstip.Tables[0].Rows[0]["New_TotalPointsRights"].ToString();
                    firstyrTextBox.Text = dstip.Tables[0].Rows[0]["New_First_year_occupancy"].ToString();
                    tenureTextBox.Text = dstip.Tables[0].Rows[0]["New_Tenure"].ToString();
                    lastyrTextBox.Text = dstip.Tables[0].Rows[0]["New_Last_year_occupancy"].ToString();

                    otip_Trade_In_Details_club_resort = dstip.Tables[0].Rows[0]["Trade_In_Details_club_resort"].ToString();
                    otip_Trade_In_Details_No_rights = dstip.Tables[0].Rows[0]["Trade_In_Details_No_rights"].ToString();
                    otip_Trade_In_Details_ContNo_RCINo = dstip.Tables[0].Rows[0]["Trade_In_Details_ContNo_RCINo"].ToString();
                    otip_Trade_In_Details_Points_value = dstip.Tables[0].Rows[0]["Trade_In_Details_Points_value"].ToString();
                    otip_New_Club = dstip.Tables[0].Rows[0]["New_Club"].ToString();
                    otip_New_Club_Points_Rights = dstip.Tables[0].Rows[0]["New_Club_Points_Rights"].ToString();
                    otip_New_MemebrshipType = dstip.Tables[0].Rows[0]["New_MemebrshipType"].ToString();
                    otip_New_TotalPointsRights = dstip.Tables[0].Rows[0]["New_TotalPointsRights"].ToString();
                    otip_New_First_year_occupancy = dstip.Tables[0].Rows[0]["New_First_year_occupancy"].ToString();
                    otip_New_Tenure = dstip.Tables[0].Rows[0]["New_Tenure"].ToString();
                    otip_New_Last_year_occupancy = dstip.Tables[0].Rows[0]["New_Last_year_occupancy"].ToString();
                }



                //load finance details

                DataSet dsptsf = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);// contractno);
                financeradiobuttonlist.SelectedValue = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
                MCFeesTextBox.Text = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                MCdateTextBox.Text = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                memberfeeTextBox.Text = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                memcgstTextBox.Text = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                memsgstTextBox.Text = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                adharcardTextBox.Text = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                pancardnoTextBox.Text = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                companypanoTextBox.Text = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
                gstinTextBox.Text = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();

                DataSet dscur = Queries.currencyfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);//contractnoTextBox.Text
                currencyDropDownList.DataSource = dscur;
                currencyDropDownList.DataTextField = "Finance_Currency_Name";
                currencyDropDownList.DataValueField = "Finance_Currency_Name";
                currencyDropDownList.AppendDataBoundItems = true;
                currencyDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["currency"].ToString(), ""));
                currencyDropDownList.DataBind();

                totalfinpriceIntaxTextBox.Text = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                intialdeppercentTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                balinitialdepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();

                obalpayable = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();


                baldepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
                 
                regcollectiontermTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                regcollamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                baladepamtdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"]); //Convert.ToDateTime (dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString()).ToString("yyyy-MM-dd");
                oldLoanAgreementTextBox.Text = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();

               // DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                // PayMethodDropDownList.Items.Add(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString());
                DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                
                PayMethodDropDownList.DataSource = dspym;
                PayMethodDropDownList.DataTextField = "pay_method_name";
                PayMethodDropDownList.DataValueField = "pay_method_name";
                PayMethodDropDownList.AppendDataBoundItems = true;
                PayMethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString(), ""));
                PayMethodDropDownList.DataBind();
                NoinstallmentTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                installmentamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                balamtpayableTextBox.Text = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                omcfees = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                omcdate = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                omemberfee = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                omemebercgst = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                omembersgst = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                oadhar = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                opan = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                ocurrency = dsptsf.Tables[0].Rows[0]["currency"].ToString();
                oaffiliate = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                ototalintax = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                odepamt = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();

                odepbal = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
                onoinstallment = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                oinstallment = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                ototalbalance = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                oregcollectionterm = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                oregcollamt = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                obaladepamtdate = dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString();
                ooldLoanAgreement = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();

                 

                DataSet dsfin = Queries.financemethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);

                financemethodDropDownList.DataSource = dsfin;
                financemethodDropDownList.DataTextField = "Finance_Name";
                financemethodDropDownList.DataValueField = "Finance_Name";
                financemethodDropDownList.AppendDataBoundItems = true;
                financemethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString(), ""));
                financemethodDropDownList.DataBind();
                FinancenoTextBox.Text = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                finmonthTextBox.Text = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                noemiTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                emiamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                findocfeeTextBox.Text = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                isgtrateTextBox.Text = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                igstamtTextBox.Text = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                interestrateTextBox.Text = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
                ofinancemethod = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();
                oFinanceno = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                ofinmonth = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                onoemi = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                oemiamt = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                ofindocfee = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                oisgtrate = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                oigstamt = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                ointerestrate = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();


             

                //load PA details
                DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);
                newpointsTextBox.Text = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
                conversionfeeTextBox.Text = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
                adminfeeTextBox.Text = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                testadminfeeTextBox.Text = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                totpurchpriceTextBox.Text = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                cgstTextBox.Text = dspa.Tables[0].Rows[0]["Cgst"].ToString();
                sgstTextBox.Text = dspa.Tables[0].Rows[0]["Sgst"].ToString();
                totalpriceInTaxTextBox.Text = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                depositTextBox.Text = dspa.Tables[0].Rows[0]["Deposit"].ToString();
                balanceTextBox.Text = dspa.Tables[0].Rows[0]["Balance"].ToString();
                balancedueTextBox.Text = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                remarksTextBox.Text = dspa.Tables[0].Rows[0]["Remarks"].ToString();

                onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
                oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
                oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
                osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
                ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
                obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
                obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();
                //load installments
                DataSet dsin = Queries.contractInstallment(ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);
                if (dsin.Tables[0].Rows.Count == 0)
                {
                    GridView1.Visible = false;

                }
                else
                {

                    GridView1.Visible = true;
                    GridView1.DataSource = dsin;
                    GridView1.DataBind();
                }
                //load receipt
                DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_Receipt(ContractdetailsIDTextBox.Text);
                if (dsreceipt.Tables[0].Rows.Count == 0)
                {
                    DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                    depositmethodDropDownList.DataSource = dsdep;
                    depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                    depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                    depositmethodDropDownList.AppendDataBoundItems = true;
                    depositmethodDropDownList.Items.Insert(0, new ListItem("", ""));
                    depositmethodDropDownList.DataBind();
                    invoicedateTextBox.Text = "";

                }
                else
                {
                    DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                    depositmethodDropDownList.DataSource = dsdep;
                    depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                    depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                    depositmethodDropDownList.AppendDataBoundItems = true;
                    depositmethodDropDownList.Items.Insert(0, new ListItem(dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString(), ""));
                    depositmethodDropDownList.DataBind();
                    invoicedateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsreceipt.Tables[0].Rows[0]["Receipt_Date"]);// Convert.ToDateTime(dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString()).ToString("yyyy-MM-dd");
                }

                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, oaffiliate, omcwv, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);


            }
            else if (conttypevalue == "Trade-In-Weeks")
            {
                
                visibilitytradeinweekstrue();
                 
                DataSet dstiw = Queries.LoadTradeinWeeksDetails(ContractdetailsIDTextBox.Text);//  contractno);
                if (dstiw.Tables[0].Rows.Count == 0)
                {
                    tnmresortTextBox.Text = "";
                    tnmapttypeTextBox.Text = "";
                    tnmseasonDropDownList.SelectedIndex = 0;
                    nmnowksTextBox.Text = "";
                    nmcontrcinoTextBox.Text = "";
                    tipnopointsTextBox.Text = "";
                    tipptsvalueTextBox.Text = "";
                    clubTextBox.Text = "";
                    newpointsrightTextBox.Text = "";
                    EntitlementPoinDropDownList.SelectedIndex = 0;
                    totalptrightsTextBox.Text = "";
                    firstyrTextBox.Text = "";
                    tenureTextBox.Text = "";
                    lastyrTextBox.Text = "";
                }
                else
                {

                    tnmresortTextBox.Text = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_resort"].ToString();
                    tnmapttypeTextBox.Text = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Apt"].ToString();

                    DataSet dstiwk = Queries.tradeinwksseason(ContractdetailsIDTextBox.Text);
                    tnmseasonDropDownList.DataSource = dstiwk;
                    tnmseasonDropDownList.DataTextField = "Season_Name";
                    tnmseasonDropDownList.DataValueField = "Season_Name";
                    tnmseasonDropDownList.AppendDataBoundItems = true;
                    tnmseasonDropDownList.Items.Insert(0, new ListItem(dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Season"].ToString(), ""));
                    tnmseasonDropDownList.DataBind();

                    nmnowksTextBox.Text = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_NoWks"].ToString();
                    nmcontrcinoTextBox.Text = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_ContNo_RCINo"].ToString();
                    tipptsvalueTextBox.Text = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Points_value"].ToString();
                    clubTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    newpointsrightTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Club_Points_Rights"].ToString();

                    DataSet dstiwen = Queries.tradeinwksentitlement(ContractdetailsIDTextBox.Text);
                    EntitlementPoinDropDownList.Items.Add(dstiw.Tables[0].Rows[0]["NewPointsW_MemebrshipType"].ToString());
                    EntitlementPoinDropDownList.Items.Add(dstiwen.Tables[0].Rows[0]["Entitlement_Name"].ToString());

                    totalptrightsTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Total_Points_rights"].ToString();
                    firstyrTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_First_year_occupancy"].ToString();
                    tenureTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Tenure"].ToString();
                    lastyrTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Last_year_occupancy"].ToString();
                    NoPersonsTextBox.Text = dstiw.Tables[0].Rows[0]["NoPersons"].ToString();

                    otiw_Trade_In_Weeks_resort = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_resort"].ToString();
                    otiw_Trade_In_Weeks_Apt = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Apt"].ToString();
                    otiw_Trade_In_Weeks_Season = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Season"].ToString();
                    otiw_Trade_In_Weeks_NoWks = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_NoWks"].ToString();
                    otiw_Trade_In_Weeks_ContNo_RCINo = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_ContNo_RCINo"].ToString();
                    otiw_Trade_In_Weeks_Points_value = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Points_value"].ToString();
                    otiw_NewPointsW_Club = dstiw.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    otiw_NewPointsW_Club_Points_Rights = dstiw.Tables[0].Rows[0]["NewPointsW_Club_Points_Rights"].ToString();
                    otiw_NewPointsW_MemebrshipType = dstiw.Tables[0].Rows[0]["NewPointsW_MemebrshipType"].ToString();
                    otiw_NewPointsW_Total_Points_rights = dstiw.Tables[0].Rows[0]["NewPointsW_Total_Points_rights"].ToString();
                    otiw_NewPointsW_First_year_occupancy = dstiw.Tables[0].Rows[0]["NewPointsW_First_year_occupancy"].ToString();
                    otiw_NewPointsW_Tenure = dstiw.Tables[0].Rows[0]["NewPointsW_Tenure"].ToString();
                    otiw_NewPointsW_Last_year_occupancy = dstiw.Tables[0].Rows[0]["NewPointsW_Last_year_occupancy"].ToString();
                    otiw_nopersons = dstiw.Tables[0].Rows[0]["NoPersons"].ToString();
                    //load finance details

                    DataSet dsptsf = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);// contractno);
                    financeradiobuttonlist.SelectedValue = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
                    MCFeesTextBox.Text = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    MCdateTextBox.Text = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    memberfeeTextBox.Text = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    memcgstTextBox.Text = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    memsgstTextBox.Text = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    adharcardTextBox.Text = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                    pancardnoTextBox.Text = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                    companypanoTextBox.Text = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
                    gstinTextBox.Text = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();

                    DataSet dscur = Queries.currencyfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);

                    currencyDropDownList.DataSource = dscur;
                    currencyDropDownList.DataTextField = "Finance_Currency_Name";
                    currencyDropDownList.DataValueField = "Finance_Currency_Name";
                    currencyDropDownList.AppendDataBoundItems = true;
                    currencyDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["currency"].ToString(), ""));
                    currencyDropDownList.DataBind();
                    totalfinpriceIntaxTextBox.Text = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    intialdeppercentTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                    balinitialdepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();

                    obalpayable = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();


                    baldepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
                   
                    regcollectiontermTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                    regcollamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                    baladepamtdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"]); //Convert.ToDateTime (dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString()).ToString("yyyy-MM-dd");
                    oldLoanAgreementTextBox.Text = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();

                    //DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                    //PayMethodDropDownList.Items.Add(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString());
                    DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                   
                    PayMethodDropDownList.DataSource = dspym;
                    PayMethodDropDownList.DataTextField = "pay_method_name";
                    PayMethodDropDownList.DataValueField = "pay_method_name";
                    PayMethodDropDownList.AppendDataBoundItems = true;
                    PayMethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString(), ""));
                    PayMethodDropDownList.DataBind();
                    NoinstallmentTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    installmentamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    balamtpayableTextBox.Text = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                    omcfees = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    omcdate = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    omemberfee = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    omemebercgst = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    omembersgst = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    oadhar = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                    opan = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                    ocurrency = dsptsf.Tables[0].Rows[0]["currency"].ToString();
                    oaffiliate = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                    ototalintax = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    odepamt = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();

                    odepbal = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
                    onoinstallment = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    oinstallment = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    ototalbalance = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                    oregcollectionterm = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                    oregcollamt = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                    obaladepamtdate = dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString();
                    ooldLoanAgreement = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();

                    //if (dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString() == "Finance")
                    //{


                    DataSet dsfin = Queries.financemethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);

                    financemethodDropDownList.DataSource = dsfin;
                    financemethodDropDownList.DataTextField = "Finance_Name";
                    financemethodDropDownList.DataValueField = "Finance_Name";
                    financemethodDropDownList.AppendDataBoundItems = true;
                    financemethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString(), ""));
                    financemethodDropDownList.DataBind();
                    FinancenoTextBox.Text = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                    finmonthTextBox.Text = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                    noemiTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                    emiamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                    findocfeeTextBox.Text = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                    isgtrateTextBox.Text = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                    igstamtTextBox.Text = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                    interestrateTextBox.Text = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
                    ofinancemethod = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();
                    oFinanceno = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                    ofinmonth = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                    onoemi = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                    oemiamt = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                    ofindocfee = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                    oisgtrate = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                    oigstamt = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                    ointerestrate = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
                    //}
                    //else if (dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString() == "Non Finance")
                    //{



                    //}

                    //load PA details
                    DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);

                    newpointsTextBox.Text = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
                    conversionfeeTextBox.Text = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
                    adminfeeTextBox.Text = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                    testadminfeeTextBox.Text = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                    totpurchpriceTextBox.Text = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                    cgstTextBox.Text = dspa.Tables[0].Rows[0]["Cgst"].ToString();
                    sgstTextBox.Text = dspa.Tables[0].Rows[0]["Sgst"].ToString();
                    totalpriceInTaxTextBox.Text = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    depositTextBox.Text = dspa.Tables[0].Rows[0]["Deposit"].ToString();
                    balanceTextBox.Text = dspa.Tables[0].Rows[0]["Balance"].ToString();
                    balancedueTextBox.Text = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                    remarksTextBox.Text = dspa.Tables[0].Rows[0]["Remarks"].ToString();

                    onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
                    oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
                    oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
                    ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                    ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
                    osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
                    ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
                    obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
                    obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                    oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();
                    //load installments
                    DataSet dsin = Queries.contractInstallment(ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);
                    if (dsin.Tables[0].Rows.Count == 0)
                    {
                        GridView1.Visible = false;

                    }
                    else
                    {

                        GridView1.Visible = true;
                        GridView1.DataSource = dsin;
                        GridView1.DataBind();
                    }
                    //load receipt
                    DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_Receipt(ContractdetailsIDTextBox.Text);
                    if (dsreceipt.Tables[0].Rows.Count == 0)
                    {
                        DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                        depositmethodDropDownList.DataSource = dsdep;
                        depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                        depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                        depositmethodDropDownList.AppendDataBoundItems = true;
                        depositmethodDropDownList.Items.Insert(0, new ListItem("", ""));
                        depositmethodDropDownList.DataBind();
                        invoicedateTextBox.Text = "";

                    }
                    else
                    {
                        DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                        depositmethodDropDownList.DataSource = dsdep;
                        depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                        depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                        depositmethodDropDownList.AppendDataBoundItems = true;
                        depositmethodDropDownList.Items.Insert(0, new ListItem(dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString(), ""));
                        depositmethodDropDownList.DataBind();
                        invoicedateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsreceipt.Tables[0].Rows[0]["Receipt_Date"]);// Convert.ToDateTime(dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString()).ToString("yyyy-MM-dd");
                    }
                }
                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, oaffiliate, omcwv, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);

            }
            else if (conttypevalue == "Fractional")
            {

                visibilityfractionaltrue();
                //load finance details
                DataSet dstif = Queries.loadtradeinfractional(ContractdetailsIDTextBox.Text);
                if (dstif.Tables[0].Rows.Count == 0)
                {

                }
                else
                {
                    DataSet dsold = Queries.LoadOldContractType(ContractdetailsIDTextBox.Text);
                    oldcontracttypeDropDownList.DataSource = dsold;
                    oldcontracttypeDropDownList.DataTextField = "ContractType";
                    oldcontracttypeDropDownList.DataValueField = "ContractType";
                    oldcontracttypeDropDownList.AppendDataBoundItems = true;
                    oldcontracttypeDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString(), ""));
                    oldcontracttypeDropDownList.DataBind();

                    DataSet dsfres = Queries.loadtradeinfractionalResort(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                    if (dsfres.Tables[0].Rows.Count == 0)
                    {
                        fwresortDropDownList.Items.Add(dstif.Tables[0].Rows[0]["resort"].ToString());
                    }
                    else
                    {
                        fwresortDropDownList.DataSource = dsfres;
                        fwresortDropDownList.DataTextField = "Contract_Resort_Name";
                        fwresortDropDownList.DataValueField = "Contract_Resort_Name";
                        fwresortDropDownList.AppendDataBoundItems = true;
                        fwresortDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["resort"].ToString(), ""));
                        fwresortDropDownList.DataBind();
                    }

                    DataSet dsfresidenceno = Queries.loadtradeinfractionalResidence(ContractdetailsIDTextBox.Text);
                    if (dsfresidenceno.Tables[0].Rows.Count == 0)
                    {
                        fwresidencenoDropDownList.Items.Add(dstif.Tables[0].Rows[0]["residence_no"].ToString());
                    }
                    else
                    {
                        fwresidencenoDropDownList.DataSource = dsfresidenceno;
                        fwresidencenoDropDownList.DataTextField = "Contract_Residence_Name";
                        fwresidencenoDropDownList.DataValueField = "Contract_Residence_Name";
                        fwresidencenoDropDownList.AppendDataBoundItems = true;
                        fwresidencenoDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["residence_no"].ToString(), ""));
                        fwresidencenoDropDownList.DataBind();

                    }
                    DataSet dsftype = Queries.loadtradeinfractionalResidencetype(ContractdetailsIDTextBox.Text);
                    if (dsftype.Tables[0].Rows.Count == 0)
                    {
                        fwresidencetypeDropDownList.Items.Add(dstif.Tables[0].Rows[0]["residence_type"].ToString());
                    }
                    else
                    {
                        fwresidencetypeDropDownList.DataSource = dsftype;
                        fwresidencetypeDropDownList.DataTextField = "Contract_Resi_Type_Name";
                        fwresidencetypeDropDownList.DataValueField = "Contract_Resi_Type_Name";
                        fwresidencetypeDropDownList.AppendDataBoundItems = true;
                        fwresidencetypeDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["residence_type"].ToString(), ""));
                        fwresidencetypeDropDownList.DataBind();

                    }

                    DataSet dsfint = Queries.loadtradeinfractionalFractionalInt(ContractdetailsIDTextBox.Text);
                    if (dsfint.Tables[0].Rows.Count == 0)
                    {
                        fwfractIntDropDownList.Items.Add(dstif.Tables[0].Rows[0]["fractional_interest"].ToString());
                    }
                    else
                    {
                        fwfractIntDropDownList.DataSource = dsfint;
                        fwfractIntDropDownList.DataTextField = "Contract_Fractional_Int_Name";
                        fwfractIntDropDownList.DataValueField = "Contract_Fractional_Int_Name";
                        fwfractIntDropDownList.AppendDataBoundItems = true;
                        fwfractIntDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["fractional_interest"].ToString(), ""));
                        fwfractIntDropDownList.DataBind();

                    }

                    DataSet dstifen = Queries.tradeinfractionalentitlement(ContractdetailsIDTextBox.Text);
                    fwentitlementDropDownList.Items.Add(dstif.Tables[0].Rows[0]["entitlement"].ToString());
                    fwentitlementDropDownList.Items.Add(dstifen.Tables[0].Rows[0]["Entitlement_Name"].ToString());
                    fwfirstyrTextBox.Text = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
                    fwtenureTextBox.Text = dstif.Tables[0].Rows[0]["tenure"].ToString();
                    fwlastyrTextBox.Text = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();

                
                    //load details

                    DataSet dsptsf = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);
                    financeradiobuttonlist.SelectedValue = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
                    MCFeesTextBox.Text = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    MCdateTextBox.Text = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    memberfeeTextBox.Text = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    memcgstTextBox.Text = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    memsgstTextBox.Text = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    adharcardTextBox.Text = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                    pancardnoTextBox.Text = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                    companypanoTextBox.Text = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
                    gstinTextBox.Text = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();

                    oldLoanAgreementTextBox.Text = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
                    foldloanamountTextBox.Text = dsptsf.Tables[0].Rows[0]["Old_Loan_Amount"].ToString();
                    regcollectiontermTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                    regcollamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();

                    DataSet dscur = Queries.currencyfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);

                    currencyDropDownList.DataSource = dscur;
                    currencyDropDownList.DataTextField = "Finance_Currency_Name";
                    currencyDropDownList.DataValueField = "Finance_Currency_Name";
                    currencyDropDownList.AppendDataBoundItems = true;
                    currencyDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["currency"].ToString(), ""));
                    currencyDropDownList.DataBind();

                    totalfinpriceIntaxTextBox.Text = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    intialdeppercentTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                    baldepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
                    balinitialdepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();

                    

                    baladepamtdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"]); //Convert.ToDateTime (dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString()).ToString("yyyy-MM-dd");


                    //DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                    //PayMethodDropDownList.Items.Add(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString());
                    DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                    
                    PayMethodDropDownList.DataSource = dspym;
                    PayMethodDropDownList.DataTextField = "pay_method_name";
                    PayMethodDropDownList.DataValueField = "pay_method_name";
                    PayMethodDropDownList.AppendDataBoundItems = true;
                    PayMethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString(), ""));
                    PayMethodDropDownList.DataBind();
                    NoinstallmentTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    installmentamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    balamtpayableTextBox.Text = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();

                    omcfees = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    omcdate = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    omemberfee = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    omemebercgst = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    omembersgst = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    ocurrency = dsptsf.Tables[0].Rows[0]["currency"].ToString();
                    oaffiliate = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                    ototalintax = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    odepamt = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                    obalpayable = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();

                    odepbal = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
                    onoinstallment = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    oinstallment = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    ototalbalance = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                   
                    //if (dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString() == "Finance")
                    //{
                        DataSet dsfin = Queries.financemethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);

                        financemethodDropDownList.DataSource = dsfin;
                        financemethodDropDownList.DataTextField = "Finance_Name";
                        financemethodDropDownList.DataValueField = "Finance_Name";
                        financemethodDropDownList.AppendDataBoundItems = true;
                        financemethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString(), ""));
                        financemethodDropDownList.DataBind();

                        FinancenoTextBox.Text = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                        finmonthTextBox.Text = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                        noemiTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                        emiamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                        findocfeeTextBox.Text = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                        isgtrateTextBox.Text = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                        igstamtTextBox.Text = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                        interestrateTextBox.Text = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();

                        ofinancemethod = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();

                        oFinanceno = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                        ofinmonth = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                        onoemi = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                        oemiamt = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                        ofindocfee = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                        oisgtrate = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                        oigstamt = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                        ointerestrate = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();

                    //}
                    //else if (dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString() == "Non Finance")
                    //{

                    //}

                    //load fractional pa
                    DataSet dsfpa = Queries.LoadfractionalPA(ContractdetailsIDTextBox.Text);

                    ftradeinvalueTextBox.Text = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
                    tradeinamtTextBox.Text = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
                    ftotalvalueTextBox.Text = dsfpa.Tables[0].Rows[0]["Total_value"].ToString();
                    adminfeeTextBox.Text = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
                    AdministrationFeesTextBox.Text = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
                    testadminfeeTextBox.Text = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
                    totpurchpriceTextBox.Text = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                    cgstTextBox.Text = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
                    sgstTextBox.Text = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
                    totalpriceInTaxTextBox.Text = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    depositTextBox.Text = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
                    balanceTextBox.Text = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
                    balancedueTextBox.Text = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                    remarksTextBox.Text = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();


                    //load installments
                    DataSet dsin = Queries.contractInstallment(ContractdetailsIDTextBox.Text);
                    if (dsin.Tables[0].Rows.Count == 0)
                    {
                        GridView1.Visible = false;

                    }
                    else
                    {

                        GridView1.Visible = true;
                        GridView1.DataSource = dsin;
                        GridView1.DataBind();
                    }
                }
                //load receipt
                DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_Receipt(ContractdetailsIDTextBox.Text);
                if (dsreceipt.Tables[0].Rows.Count == 0)
                {
                    DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                    depositmethodDropDownList.DataSource = dsdep;
                    depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                    depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                    depositmethodDropDownList.AppendDataBoundItems = true;
                    depositmethodDropDownList.Items.Insert(0, new ListItem("", ""));
                    depositmethodDropDownList.DataBind();
                    invoicedateTextBox.Text = "";

                }
                else
                {
                    DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                    depositmethodDropDownList.DataSource = dsdep;
                    depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                    depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                    depositmethodDropDownList.AppendDataBoundItems = true;
                    depositmethodDropDownList.Items.Insert(0, new ListItem(dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString(), ""));
                    depositmethodDropDownList.DataBind();
                    invoicedateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsreceipt.Tables[0].Rows[0]["Receipt_Date"]);// Convert.ToDateTime(dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString()).ToString("yyyy-MM-dd");
                }
                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, "", omcwv, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);

            }
            else if (conttypevalue == "Trade-In-Fractionals")
            {
               
                visibilityfractionaltrue();
                //load finance details
                DataSet dstif = Queries.loadtradeinfractional(ContractdetailsIDTextBox.Text);
                if (dstif.Tables[0].Rows.Count == 0)
                {

                }
                else
                {
                    DataSet dsold=Queries.LoadOldContractType(ContractdetailsIDTextBox.Text);
                    oldcontracttypeDropDownList.DataSource = dsold;
                    oldcontracttypeDropDownList.DataTextField = "ContractType";
                    oldcontracttypeDropDownList.DataValueField = "ContractType";
                    oldcontracttypeDropDownList.AppendDataBoundItems = true;
                    oldcontracttypeDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString(), ""));
                    oldcontracttypeDropDownList.DataBind();
                   
                    DataSet dsfres = Queries.loadtradeinfractionalResort(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                    if (dsfres.Tables[0].Rows.Count == 0)
                    {
                        fwresortDropDownList.Items.Add(dstif.Tables[0].Rows[0]["resort"].ToString());
                    }
                    else
                    {
                        fwresortDropDownList.DataSource = dsfres;
                        fwresortDropDownList.DataTextField = "Contract_Resort_Name";
                        fwresortDropDownList.DataValueField = "Contract_Resort_Name";
                        fwresortDropDownList.AppendDataBoundItems = true;
                        fwresortDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["resort"].ToString(), ""));
                        fwresortDropDownList.DataBind();
                     }

                    DataSet dsfresidenceno = Queries.loadtradeinfractionalResidence(ContractdetailsIDTextBox.Text);
                    if (dsfresidenceno.Tables[0].Rows.Count == 0)
                    {
                        fwresidencenoDropDownList.Items.Add(dstif.Tables[0].Rows[0]["residence_no"].ToString());
                    }
                    else
                    {
                        fwresidencenoDropDownList.DataSource = dsfresidenceno;
                        fwresidencenoDropDownList.DataTextField = "Contract_Residence_Name";
                        fwresidencenoDropDownList.DataValueField = "Contract_Residence_Name";
                        fwresidencenoDropDownList.AppendDataBoundItems = true;
                        fwresidencenoDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["residence_no"].ToString(), ""));
                        fwresidencenoDropDownList.DataBind();

                    }
                    DataSet dsftype = Queries.loadtradeinfractionalResidencetype(ContractdetailsIDTextBox.Text);
                    if (dsftype.Tables[0].Rows.Count == 0)
                    {
                        fwresidencetypeDropDownList.Items.Add(dstif.Tables[0].Rows[0]["residence_type"].ToString());
                    }
                    else
                    {
                        fwresidencetypeDropDownList.DataSource = dsftype;
                        fwresidencetypeDropDownList.DataTextField = "Contract_Resi_Type_Name";
                        fwresidencetypeDropDownList.DataValueField = "Contract_Resi_Type_Name";
                        fwresidencetypeDropDownList.AppendDataBoundItems = true;
                        fwresidencetypeDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["residence_type"].ToString(), ""));
                        fwresidencetypeDropDownList.DataBind();
  
                    }

                    DataSet dsfint = Queries.loadtradeinfractionalFractionalInt(ContractdetailsIDTextBox.Text);
                    if (dsfint.Tables[0].Rows.Count == 0)
                    {
                        fwfractIntDropDownList.Items.Add(dstif.Tables[0].Rows[0]["fractional_interest"].ToString());
                    }
                    else
                    {
                        fwfractIntDropDownList.DataSource = dsfint;
                        fwfractIntDropDownList.DataTextField = "Contract_Fractional_Int_Name";
                        fwfractIntDropDownList.DataValueField = "Contract_Fractional_Int_Name";
                        fwfractIntDropDownList.AppendDataBoundItems = true;
                        fwfractIntDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["fractional_interest"].ToString(), ""));
                        fwfractIntDropDownList.DataBind();

                     }

                    DataSet dstifen = Queries.tradeinfractionalentitlement(ContractdetailsIDTextBox.Text);
                    fwentitlementDropDownList.Items.Add(dstif.Tables[0].Rows[0]["entitlement"].ToString());
                    fwentitlementDropDownList.Items.Add(dstifen.Tables[0].Rows[0]["Entitlement_Name"].ToString());
                    fwfirstyrTextBox.Text = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
                    fwtenureTextBox.Text = dstif.Tables[0].Rows[0]["tenure"].ToString();
                    fwlastyrTextBox.Text = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();

                    if (dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString() == "Points")
                    {
                       
                        tnmresortTextBox.Text = dstif.Tables[0].Rows[0]["tradeinresort"].ToString();
                        tipnopointsTextBox.Text = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
                        nmcontrcinoTextBox.Text = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
                        tipptsvalueTextBox.Text = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();

                        tifpresort = dstif.Tables[0].Rows[0]["RESORT"].ToString();
                        tifpnopoints = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
                        tifpcontrcino = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
                        tifpptsvalue = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();


                    }
                    else if (dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString() == "Weeks" )
                    {
                         
                        tnmresortTextBox.Text = dstif.Tables[0].Rows[0]["RESORT"].ToString();
                        tnmapttypeTextBox.Text = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString();
                        DataSet dsfseason = Queries.tradeinfractionalseason(ContractdetailsIDTextBox.Text);

                        tnmseasonDropDownList.DataSource = dsfseason;
                        tnmseasonDropDownList.DataTextField = "Season_Name";
                        tnmseasonDropDownList.DataValueField = "Season_Name";
                        tnmseasonDropDownList.AppendDataBoundItems = true;
                        tnmseasonDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["SEASON"].ToString(), ""));
                        tnmseasonDropDownList.DataBind();

                 

                        nmnowksTextBox.Text = dstif.Tables[0].Rows[0]["NO_WEEKS"].ToString();
                        tipnopointsTextBox.Text = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
                        nmcontrcinoTextBox.Text = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
                        tipptsvalueTextBox.Text = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();


                    }
                    else if (dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString() == "Fractionals")
                    {

                        tnmresortTextBox.Text = dstif.Tables[0].Rows[0]["RESORT"].ToString();
                        tnmapttypeTextBox.Text = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString(); 
                        nmcontrcinoTextBox.Text = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
                        nmnowksTextBox.Text = dstif.Tables[0].Rows[0]["NO_WEEKS"].ToString();

                    }

                    //load details

                    DataSet dsptsf = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text );
                    financeradiobuttonlist.SelectedValue = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
                    MCFeesTextBox.Text = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    MCdateTextBox.Text = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    memberfeeTextBox.Text = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    memcgstTextBox.Text = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    memsgstTextBox.Text = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    adharcardTextBox.Text = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
                    pancardnoTextBox.Text = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
                    companypanoTextBox.Text = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
                    gstinTextBox.Text = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();

                    oldLoanAgreementTextBox.Text= dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
                    foldloanamountTextBox.Text= dsptsf.Tables[0].Rows[0]["Old_Loan_Amount"].ToString();
                   regcollectiontermTextBox.Text  = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                    regcollamtTextBox.Text  = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                    DataSet dscur = Queries.currencyfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                  
                    currencyDropDownList.DataSource = dscur;
                    currencyDropDownList.DataTextField = "Finance_Currency_Name";
                    currencyDropDownList.DataValueField = "Finance_Currency_Name";
                    currencyDropDownList.AppendDataBoundItems = true;
                    currencyDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["currency"].ToString(), ""));
                    currencyDropDownList.DataBind();
               
                    totalfinpriceIntaxTextBox.Text = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    intialdeppercentTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                    baldepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
                    balinitialdepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();

                    
                    baladepamtdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"]); //Convert.ToDateTime (dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString()).ToString("yyyy-MM-dd");



                    //DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                    //PayMethodDropDownList.Items.Add(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString());
                    DataSet dspym = Queries.paymethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                     
                    PayMethodDropDownList.DataSource = dspym;
                    PayMethodDropDownList.DataTextField = "pay_method_name";
                    PayMethodDropDownList.DataValueField = "pay_method_name";
                    PayMethodDropDownList.AppendDataBoundItems = true;
                    PayMethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString(), ""));
                    PayMethodDropDownList.DataBind();

                    NoinstallmentTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    installmentamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    balamtpayableTextBox.Text = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                    omcfees = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
                    omcdate = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
                    omemberfee = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
                    omemebercgst = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
                    omembersgst = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
                    ocurrency = dsptsf.Tables[0].Rows[0]["currency"].ToString();
                    oaffiliate = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                    ototalintax = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    odepamt = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                    obalpayable = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
                   
                    odepbal = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
                    onoinstallment = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                    oinstallment = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                    ototalbalance = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                    oldLoanAgreementTextBox.Text = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
                    //if (dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString() == "Finance")
                    //{
                        DataSet dsfin = Queries.financemethodfinancedetails(ContractdetailsIDTextBox.Text, officeTextBox.Text);
                      
                        financemethodDropDownList.DataSource = dsfin;
                        financemethodDropDownList.DataTextField = "Finance_Name";
                        financemethodDropDownList.DataValueField = "Finance_Name";
                        financemethodDropDownList.AppendDataBoundItems = true;
                        financemethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString(), ""));
                        financemethodDropDownList.DataBind();
                     
                        FinancenoTextBox.Text = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                        finmonthTextBox.Text = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                        noemiTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                        emiamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                        findocfeeTextBox.Text = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                        isgtrateTextBox.Text = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                        igstamtTextBox.Text = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                        interestrateTextBox.Text = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
                        
                        ofinancemethod = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();

                        oFinanceno = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
                        ofinmonth = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
                        onoemi = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
                        oemiamt = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
                        ofindocfee = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
                        oisgtrate = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
                        oigstamt = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
                        ointerestrate = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();

                 

                    //load fractional pa
                    DataSet dsfpa = Queries.LoadfractionalPA(ContractdetailsIDTextBox.Text);

                    ftradeinvalueTextBox.Text = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
                    tradeinamtTextBox.Text  = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
                    ftotalvalueTextBox.Text = dsfpa.Tables[0].Rows[0]["Total_value"].ToString();
                    adminfeeTextBox.Text = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
                    testadminfeeTextBox.Text = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
                    AdministrationFeesTextBox.Text = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
                    totpurchpriceTextBox.Text = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
                    cgstTextBox.Text = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
                    sgstTextBox.Text = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
                    totalpriceInTaxTextBox.Text = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                    depositTextBox.Text = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
                    balanceTextBox.Text = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
                    balancedueTextBox.Text = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
                    remarksTextBox.Text = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();


                    //load installments
                    DataSet dsin = Queries.contractInstallment(ContractdetailsIDTextBox.Text);
                    if (dsin.Tables[0].Rows.Count == 0)
                    {
                        GridView1.Visible = false;
                        
                    }
                    else
                    {
                        
                        GridView1.Visible = true;
                        GridView1.DataSource = dsin;
                        GridView1.DataBind();
                    }
                }
                //load receipt
                DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_Receipt(ContractdetailsIDTextBox.Text);
                if (dsreceipt.Tables[0].Rows.Count == 0)
                {
                    DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                    depositmethodDropDownList.DataSource = dsdep;
                    depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                    depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                    depositmethodDropDownList.AppendDataBoundItems = true;
                    depositmethodDropDownList.Items.Insert(0, new ListItem("", ""));
                    depositmethodDropDownList.DataBind();
                    invoicedateTextBox.Text = "";

                }
                else
                {
                    DataSet dsdep = Queries.LoadDeposit_Pay_Method(ContractdetailsIDTextBox.Text, office);
                    depositmethodDropDownList.DataSource = dsdep;
                    depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                    depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                    depositmethodDropDownList.AppendDataBoundItems = true;
                    depositmethodDropDownList.Items.Insert(0, new ListItem(dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString(), ""));
                    depositmethodDropDownList.DataBind();
                    invoicedateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsreceipt.Tables[0].Rows[0]["Receipt_Date"]);// Convert.ToDateTime(dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString()).ToString("yyyy-MM-dd");
                }
                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, oaffiliate, omcwv, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);

            }
        }
    }
            

        




 
    //update details

public void CreateButton_Click(object sender, EventArgs e)
    {
      string user =(string)Session["username"];
        DataSet dsct = Queries.LoadContractDetails_ID(ContractdetailsIDTextBox.Text);

	ocontractno = dsct.Tables[0].Rows[0]["contractno"].ToString();
        wkno = Convert.ToInt32(dsct.Tables[0].Rows[0]["dealweekno"]);
        ocsalesrep = dsct.Tables[0].Rows[0]["Sales_Rep"].ToString();
        ocTomgr =dsct.Tables[0].Rows[0]["TO_Manager"].ToString();
        obuttonup = dsct.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
        odealdate= String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["DealRegistered_Date"]);//dsct.Tables[0].Rows[0]["DealRegistered_Date"].ToString();
        odealstatus= dsct.Tables[0].Rows[0]["DealStatus"].ToString();

        oloanbuofficer = dsct.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
        ocanxcontno = dsct.Tables[0].Rows[0]["CanxContractNo"].ToString();
        ocanxdate = dsct.Tables[0].Rows[0]["Contract_Canx_date"].ToString();
        ocogstin=dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
        ocontractcomment = dsct.Tables[0].Rows[0]["Contract_comment"].ToString();
 
        ocompanypano = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
        DataSet dspr = Queries.LoadProfielDetailsFull(ProfileID);
        ocompanyname= dspr.Tables[0].Rows[0]["Company_Name"].ToString();

        DataSet dsptsf = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);
        ofinance = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
        omcwv = dsct.Tables[0].Rows[0]["MCWaiver"].ToString();
        omcfees = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
        omcdate = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
        omemberfee = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
        omemebercgst = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
        omembersgst = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
        oadhar = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
        opan = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
        ocurrency = dsptsf.Tables[0].Rows[0]["currency"].ToString();
        oaffiliate = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
        ototalintax = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
        odepamt = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
        obalpayable = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
        odepbal = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
        onoinstallment = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
        oinstallment = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
        ototalbalance = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
        opaymethod = dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString();
        obaladepamtdate = dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString();

        ofinancemethod = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();
        oFinanceno = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
        ofinmonth = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
        onoemi = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
        oemiamt = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
        ofindocfee = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
        oisgtrate = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
        oigstamt = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
        ointerestrate = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
        oregcollectionterm = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
        oregcollamt = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
        ooldLoanAgreement = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
        ooldloanamt = dsptsf.Tables[0].Rows[0]["Old_Loan_Amount"].ToString();

        DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_Receipt(ContractdetailsIDTextBox.Text);
        if (dsreceipt.Tables[0].Rows.Count == 0)
        {

        }
        else
        {
            oReceipt_Date = dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString();
            oAmount = dsreceipt.Tables[0].Rows[0]["Amount"].ToString();
            otaxable_value = dsreceipt.Tables[0].Rows[0]["taxable_value"].ToString();
            ocgstrate = dsreceipt.Tables[0].Rows[0]["cgstrate"].ToString();
            ocgstamt = dsreceipt.Tables[0].Rows[0]["cgstamt"].ToString();
            osgstrate = dsreceipt.Tables[0].Rows[0]["sgstrate"].ToString();
            osgstamt = dsreceipt.Tables[0].Rows[0]["sgstamt"].ToString();
            ototalamt = dsreceipt.Tables[0].Rows[0]["totalamt"].ToString();
            oPayment_Mode = dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString();
        }
        string finance = financeradiobuttonlist.SelectedItem.Text;
        string mcfees = MCFeesTextBox.Text;
        string mcdate = MCdateTextBox.Text;
        string memberfee = memberfeeTextBox.Text;
        string memebercgst = memcgstTextBox.Text;
        string membersgst = memsgstTextBox.Text;
        string adhar = adharcardTextBox.Text.ToUpper();
        string pancrd = pancardnoTextBox.Text.ToUpper();
        string currency = currencyDropDownList.SelectedItem.Text;// Request.Form[currencyDropDownList.UniqueID];
        string affiliate = AffiliationvalueTextBox.Text;
        string totalintax = totalfinpriceIntaxTextBox.Text;
        string depamt = intialdeppercentTextBox.Text;
        string balpayable = baldepamtTextBox.Text;
        string depbal = balinitialdepamtTextBox.Text;
        string noinstallment = NoinstallmentTextBox.Text;
        string installment = installmentamtTextBox.Text;
        string totalbalance = balamtpayableTextBox.Text;
        string paymethod = PayMethodDropDownList.SelectedItem.Text;
        string baldepdate = baladepamtdateTextBox.Text;
        string paymentmode = depositmethodDropDownList.SelectedItem.Text;

        string regcollectionterm = regcollectiontermTextBox.Text;
        string regcollamt = regcollamtTextBox.Text;
        string oldloanagreementno = oldLoanAgreementTextBox.Text;
        string loanamt = foldloanamountTextBox.Text;

        string receiptdate = invoicedateTextBox.Text;
        string ncontractcomment = contractcommentTextBox.Text;
    

        //calculate gst on intial dep    //update receipt amt                  
        double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
        double gst = Math.Round(indeposit / 118 * 18 / 2);
        double taxableamt = Math.Round(indeposit / 118 * 100);

        // int dealwkno = Queries.GetWkNumber(Convert.ToDateTime(dealdateTextBox.Text));

        string d = dealdateTextBox.Text;
        DateTime dt = DateTime.ParseExact(d, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        // for both "1/1/2000" or "25/1/2000" formats
        string newString = dt.ToString("MM/dd/yyyy");
        int dealwkno = Queries.GetWkNumber(Convert.ToDateTime(newString));


        string financemethod, Financeno, finmonth, noemi, emiamt, findocfee, isgtrate, igstamt, interestrate;
        if (finance == "Finance")
        {
            financemethod = financemethodDropDownList.SelectedItem.Text;// Request.Form[financemethodDropDownList.UniqueID];
            Financeno = FinancenoTextBox.Text;
            finmonth = finmonthTextBox.Text;
            noemi = noemiTextBox.Text;
            emiamt = emiamtTextBox.Text;
            findocfee = findocfeeTextBox.Text;
            isgtrate = isgtrateTextBox.Text;
            igstamt = igstamtTextBox.Text;
            interestrate = interestrateTextBox.Text;

        }
        else
        {
            financemethod = "";
            Financeno = "";
            finmonth = "";
            noemi = "";
            emiamt = "";
            findocfee = "";
            isgtrate = "";
            igstamt = "";
            interestrate = "";

        }

        string contract = contracttypeTextBox.Text;
        string contractno = contractnoTextBox.Text.ToUpper();
        int i;
        string inst = "Installment No";
        string iamt, idate, ia, idt;

        string loanbuofficer = LoanBUOfficerTextBox.Text.ToUpper();
        string canxcontno = CanxContractNoTextBox.Text.ToUpper();
        string csalesrep = contsalesrepTextBox.Text.ToUpper();// contsalesrepDropDownList.SelectedItem.Text;
        string cTomgr = TOManagerDropDownList.SelectedItem.Text;
        string buttonup = ButtonUpDropDownList.SelectedItem.Text;
        string dealdate = dealdateTextBox.Text;
        string dealstatus, canxdate;

        string ncompanyname = companynameTextBox.Text.ToUpper();
        string ngstin = gstinTextBox.Text.ToUpper();
        string ncompanypanno = companypanoTextBox.Text.ToUpper();

        if (dealstatusDropDownList.SelectedItem.Text == "CANCELLED")
        {
            dealstatus = dealstatusDropDownList.SelectedItem.Text;
            canxdate = DateTime.Now.ToShortDateString();
        }
        else
        {
            dealstatus = dealstatusDropDownList.SelectedItem.Text;
            canxdate = "";
        }
        if (String.Compare(ocompanyname, ncompanyname) != 0)
        {
            int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
            string act = "company name changed from:" + ocompanyname + "To:" + ncompanyname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
        }
        if (String.Compare(ocontractcomment, ncontractcomment) != 0)
        {
            int update = Queries.UpdateContractDetails_IndianComment(ContractdetailsIDTextBox.Text, ncontractcomment.ToUpper());
            string act = "contract comment changed from:" + ocontractcomment + "To:" + ncontractcomment;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
        }
        
        if (contract=="Points")
        {
             

            DataSet dspts = Queries.LoadNewPointsDetails(ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);
           
                opts_club = dspts.Tables[0].Rows[0]["club"].ToString();
                opts_newpts = dspts.Tables[0].Rows[0]["New_points_rights"].ToString();
                opts_entitlement = dspts.Tables[0].Rows[0]["Type_membership"].ToString();
                opts_totalpts = dspts.Tables[0].Rows[0]["Total_points_rights"].ToString();
                opts_firstyr = dspts.Tables[0].Rows[0]["First_year_occupancy"].ToString();
                opts_Tenure = dspts.Tables[0].Rows[0]["Tenure"].ToString();
                opts_lastyr = dspts.Tables[0].Rows[0]["Last_year_occupancy"].ToString();
                opts_nopersons = dspts.Tables[0].Rows[0]["NoPersons"].ToString();
                ocontractno = dspts.Tables[0].Rows[0]["contractno"].ToString();
           
           

            DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);
            onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
            oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
            oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
            ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
            osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
            ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
            obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
            obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();

           
            string pts_club = clubTextBox.Text;
            string pts_newpts = newpointsrightTextBox.Text;
            string pts_entitlement = EntitlementPoinDropDownList.SelectedItem.Text;
            string pts_totalpts = totalptrightsTextBox.Text;
            string pts_firstyr = firstyrTextBox.Text;
            string pts_Tenure = tenureTextBox.Text;
            string pts_lastyr = lastyrTextBox.Text;
            string pts_nopersons = NoPersonsTextBox.Text;

           
            string newpoints = newpointsTextBox.Text;
            string conversionfee= conversionfeeTextBox.Text;
            string adminfee= adminfeeTextBox.Text;
            string totpurchprice= totpurchpriceTextBox.Text;
            string cgst =cgstTextBox.Text;
            string sgst =sgstTextBox.Text;
            string totalpriceInTax= totalpriceInTaxTextBox.Text;
            string deposit =depositTextBox.Text;
            string balance =balanceTextBox.Text;
            string balancedue =balancedueTextBox.Text;
            string remarks =remarksTextBox.Text;

           
            if (mcRadioButtonList.Checked == true)
            {
                mcwaiver = "Yes";
            }
            else
            {
                mcwaiver = "No";

            }
           
            if (String.Compare(ocogstin, ngstin) != 0)
            {
                string act = "(points)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocompanypano, ncompanypanno)!=0)
            {
                string act = "(points)company pan no changed from:" + ocompanypano + "To:" + ncompanypanno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocontractno, contractno) != 0)
            {
                //update in installment table
                int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
                if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
                {
                    int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
                }
                else { }

                string act = "(points)Contract NO changed from:" + ocontractno + "To:" + contractno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocsalesrep, csalesrep) != 0)
            {
                string act = "(points)sales rep changed from:" + ocsalesrep + "To:" + csalesrep;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocTomgr, cTomgr) != 0)
            {
                string act = "(points)TO manager changed from:" + ocTomgr + "To:" + cTomgr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(obuttonup, buttonup) != 0)
            {
                string act = "(points)button up changed from:" + obuttonup + "To:" + buttonup;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(odealdate, dealdate) != 0)
            {
                string act = "(points)deal date changed from:" + odealdate + "To:" + dealdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text , ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

	if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
            {
                string act = "(points)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odealstatus, dealstatus) != 0)
            {
                string act = "(points)deal status changed from:" + odealstatus + "To:" + dealstatus;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
            {
                string act = "(points)Loan BU Officer changed from:" + oloanbuofficer + "To:" + loanbuofficer;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocanxcontno, canxcontno) != 0)
            {
                string act = "(points)Cancelled Canx No changed from:" + ocanxcontno + "To:" + canxcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(ocanxdate, canxdate) != 0)
            {
                string act = "(points)deal cancelled date changed from:" + ocanxdate + "To:" + canxdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }



            if (String.Compare(omcwv, mcwaiver) != 0)
            {
                string act = "(points)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(oadhar , adhar ) != 0)
            {
                string act = "(points) adhar Card changed from:" + oadhar + "To:" + adhar;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opan, pancrd ) != 0)
            {
                string act = "(points)pan card changed from:" + opan + "To:" + pancrd;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(opts_club, pts_club) != 0)
            {
                string act = "(points) club name changed from:" + opts_club + "To:" + pts_club;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opts_newpts, pts_newpts) != 0)
            {
                string act = "(points)new points changed from:" + opts_newpts + "To:" + pts_newpts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(opts_entitlement, pts_entitlement) != 0)
            {
                string act = "(points)entitlement changed from:" + opts_entitlement + "To:" + pts_entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opts_totalpts, pts_totalpts) != 0)
            {
                string act = "(points) total points changed from:" + opts_totalpts + "To:" + pts_totalpts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opts_firstyr, pts_firstyr) != 0)
            {
                string act = "(points) first yr changed from:" + opts_firstyr + "To:" + pts_firstyr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opts_Tenure, pts_Tenure) != 0)
            {
                string act = "(points)tenure changed from:" + opts_Tenure + "To:" + pts_Tenure;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opts_lastyr, pts_lastyr) != 0)
            {
                string act = "(points) last yr changed from:" + opts_lastyr + "To:" + pts_lastyr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opts_nopersons, pts_nopersons) != 0)
            {
                string act = "(points) No. Of Persons changed from:" + opts_nopersons + "To:" + pts_nopersons;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(ofinance, finance) != 0)
            {
              
                string act = "(points) financemethod changed from:" + ofinance + "To:" + finance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                 CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text );
            }
            else { }
            if (String.Compare(omcfees, mcfees) != 0)
            {
                string act = "(points) MC fees changed from:" + omcfees + "To:" + mcfees;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omcdate, mcdate) != 0)
            {
                string act = "(points) MC Date changed from:" + omcdate + "To:" + mcdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omemberfee, memberfee) != 0)
            {
                string act = "(points) member fee changed from:" + omemberfee + "To:" +  memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omemebercgst, memebercgst) != 0)
            {
                string act = "(points) cgst changed from:" + omemebercgst + "To:" + memebercgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omembersgst, membersgst) != 0)
            {
                string act = "(points) sgst changed from:" + omembersgst + "To:" + membersgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocurrency, currency) != 0)
            {
                string act = "(points) Currency changed from:" + ocurrency + "To:" + currency;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oaffiliate, affiliate) != 0)
            {
                string act = "(points) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalintax, totalintax) != 0)
            {
                string act = "(points) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepamt, depamt) != 0)
            {
                string act = "(points)deposit amount changed from:" + odepamt + "To:" + depamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalpayable, balpayable) != 0)
            {
                string act = "(points)deposit amount(bal) changed from:" + obalpayable + "To:" + balpayable;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(obaladepamtdate, baldepdate) != 0)
            {
                string act = "(points)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepbal, depbal) != 0)
            {
                string act = "(points)Balance deposit changed from:" + odepbal + "To:" + depbal;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoinstallment, noinstallment) != 0)
            {
                string act = "(points) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                
            }
            else
            {

            }
            if (String.Compare(oinstallment, installment) != 0)
            {
                string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + installment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
                {
                    //check if contracttno exists in installment table if yes deleete if no  nothting
                    //check previous valu of installment
                    if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
                    {

                    }
                    else
                    {
                        //delete from installment table;
                    }
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete from table

                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }

                    }
                    else { }

                }
                else
                {
                    //delete .//previous installment
                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                    {
                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                    }
                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                }
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete .//previous installment
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date =  dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

                    }
                    else
                    {
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


                    }
                }
                else
                { }
                }
       
            
            if (String.Compare(ototalbalance, totalbalance) != 0)
            {
                string act = "(points) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opaymethod, paymethod) != 0)
            {
                string act = "(points) pay method changed from:" + opaymethod + "To:" + paymethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinancemethod, financemethod) != 0)
            {
                string act = "(points)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oFinanceno, Financeno) != 0)
            {
                string act = "(points) Finance no changed from:" + oFinanceno + "To:" + Financeno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinmonth, finmonth) != 0)
            {
                string act = "(points) finance month changed from:" + ofinmonth + "To:" + finmonth;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoemi, noemi) != 0)
            {
                string act = "(points) No of EMI changed from:" + onoemi + "To:" + noemi;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(oemiamt, emiamt) != 0)
            {
                string act = "(points)EMI Amount changed from:" + oemiamt + "To:" + emiamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofindocfee, findocfee) != 0)
            {
                string act = "(points)Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oisgtrate, isgtrate) != 0)
            {
                string act = "(points)IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oigstamt, igstamt) != 0)
            {
                string act = "(points) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ointerestrate, interestrate) != 0)
            {
                string act = "(points) Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onewpoints, newpoints) != 0)
            {
                string act = "(points)New points changed from:" + onewpoints + "To:" + newpoints;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oconversionfee, conversionfee) != 0)
            {
                string act = "(points)Conversion Fee changed from:" + oconversionfee + "To:" + conversionfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oadminfee, adminfee) != 0)
            {
                string act = "(points)Admin Fee changed from:" + oadminfee + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototpurchprice, totpurchprice) != 0)
            {
                string act = "(points)Purchase Price changed from:" + ototpurchprice + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocgst, cgst) != 0)
            {
                string act = "(points)CGST changed from:" + ocgst + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgst, sgst) != 0)
            {
                string act = "(points)SGST changed from:" + osgst + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalpriceInTax, totalpriceInTax) != 0)
            {
                string act = "(points) Total Price including Tax (PA) changed from:" + ototalpriceInTax + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odeposit, deposit) != 0)
            {
                string act = "(points)Deposit(PA) changed from:" + odeposit + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalance, balance) != 0)
            {
                string act = "(points) Balaance(PA) changed from:" + obalance + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalancedue, balancedue) != 0)
            {
                string act = "(points)balance due date(PA) changed from:" + obalancedue + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oremarks, remarks) != 0)
            {
                string act = "(points) Remarks changed from:" + oremarks + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oPayment_Mode, paymentmode) != 0)
            {
                string act = "(points)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oReceipt_Date, receiptdate) != 0)
            {
                string act = "(points)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }



            if (String.Compare(ototalamt, indeposit.ToString()) != 0)
            {
                string act = "(points)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oAmount, taxableamt.ToString()) != 0)
            {
                string act = "(points)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
            {
                string act = "(points)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocgstamt, gst.ToString()) != 0)
            {
                string act = "(points)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgstamt, gst.ToString()) != 0)
            {
                string act = "(points)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
            {
                installment = "0";
            }
            else
            {
                installment = installmentamtTextBox.Text;
            }
            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
            {
                noinstallment = "0";
            }
            else
            {
                noinstallment = NoinstallmentTextBox.Text;
            }

            int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text,canxcontno,canxdate,loanbuofficer,ContractdetailsIDTextBox.Text);

 		 int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);
            int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt,"", balpayable,"", depbal, totalbalance,paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text,"","","",baldepdate,"",ContractdetailsIDTextBox.Text);
            int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
             int updatepointscontract = Queries.UpdateContract_Points_Indian(pts_club,pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr,contractnoTextBox.Text,ContractdetailsIDTextBox.Text);
        //    int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);
            if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
            {
                int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
            }
            else
            {
                int updatefin = Queries.UpdatefinanceStartdate(contractno);
            }
            string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text ;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text , finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);

        }//end of points contract

            
        else if(contract== "Trade-In-Points")
        {
                DataSet dstip = Queries.LoadTradeinPointsDetails(ContractdetailsIDTextBox.Text);
             
                otip_Trade_In_Details_club_resort = dstip.Tables[0].Rows[0]["Trade_In_Details_club_resort"].ToString();
                otip_Trade_In_Details_No_rights = dstip.Tables[0].Rows[0]["Trade_In_Details_No_rights"].ToString();
                otip_Trade_In_Details_ContNo_RCINo = dstip.Tables[0].Rows[0]["Trade_In_Details_ContNo_RCINo"].ToString();
                otip_Trade_In_Details_Points_value = dstip.Tables[0].Rows[0]["Trade_In_Details_Points_value"].ToString();
                otip_New_Club = dstip.Tables[0].Rows[0]["New_Club"].ToString();
                otip_New_Club_Points_Rights = dstip.Tables[0].Rows[0]["New_Club_Points_Rights"].ToString();
                otip_New_MemebrshipType = dstip.Tables[0].Rows[0]["New_MemebrshipType"].ToString();
                otip_New_TotalPointsRights = dstip.Tables[0].Rows[0]["New_TotalPointsRights"].ToString();
                otip_New_First_year_occupancy = dstip.Tables[0].Rows[0]["New_First_year_occupancy"].ToString();
                otip_New_Tenure = dstip.Tables[0].Rows[0]["New_Tenure"].ToString();
                otip_New_Last_year_occupancy = dstip.Tables[0].Rows[0]["New_Last_year_occupancy"].ToString();
                otip_nopersons = dstip.Tables[0].Rows[0]["NoPersons"].ToString();

         

            DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);
            onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
            oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
            oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
            ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
            osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
            ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
            obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
            obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();
           

           

            string tpresort = tnmresortTextBox.Text;
            string tpnpts = tipnopointsTextBox.Text;
            string tpcontno = nmcontrcinoTextBox.Text;
            string tpptsval = tipptsvalueTextBox.Text;
            string  pts_club = clubTextBox.Text;
            string pts_newpts = newpointsrightTextBox.Text;
            string pts_entitlement = EntitlementPoinDropDownList.SelectedItem.Text;// Request.Form[EntitlementPoinDropDownList.UniqueID];
            string pts_totalpts = totalptrightsTextBox.Text;
            string pts_firstyr = firstyrTextBox.Text;
            string pts_Tenure = tenureTextBox.Text;
            string pts_lastyr = lastyrTextBox.Text;
            string pts_nopersons = NoPersonsTextBox.Text;

         

             
            string newpoints = newpointsTextBox.Text;
            string conversionfee = conversionfeeTextBox.Text;
            string adminfee = adminfeeTextBox.Text;
            string totpurchprice = totpurchpriceTextBox.Text;
            string cgst = cgstTextBox.Text;
            string sgst = sgstTextBox.Text;
            string totalpriceInTax = totalpriceInTaxTextBox.Text;
            string deposit = depositTextBox.Text;
            string balance = balanceTextBox.Text;
            string balancedue = balancedueTextBox.Text;
            string remarks = remarksTextBox.Text;
           
            if (mcRadioButtonList.Checked == true)
            {
                mcwaiver = "Yes";
            }
            else
            {
                mcwaiver = "No";

            }
           
            if (String.Compare(ocogstin, ngstin) != 0)
            {
                string act = "(trade in points)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocompanypano, ncompanypanno) != 0)
            {
                string act = "(trade in points)company Pan # changed from:" + ocompanypano + "To:" + ncompanypanno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocontractno, contractno) != 0)
            {
                //update in installment table
                int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
                if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
                {
                    int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
                }
                else { }
                string act = "(trade in points)Contract NO changed from:" + ocontractno + "To:" + contractno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocsalesrep, csalesrep) != 0)
            {
                string act = "(trade in points)sales rep changed from:" + ocsalesrep + "To:" + csalesrep;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocTomgr, cTomgr) != 0)
            {
                string act = "(trade in points) TO manager changed from:" + ocTomgr + "To:" + cTomgr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(obuttonup, buttonup) != 0)
            {
                string act = "(trade in points)button up changed from:" + obuttonup + "To:" + buttonup;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odealdate, dealdate) != 0)
            {
                string act = "(trade in points)deal date changed from:" + odealdate + "To:" + dealdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
	 if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
            {
                string act = "(trade in points)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(odealstatus, dealstatus) != 0)
            {
                string act = "(trade in points) deal status changed from:" + odealstatus + "To:" + dealstatus;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
            {
                string act = "(trade in points)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
          

            if (String.Compare(ocanxcontno, canxcontno) != 0)
            {
                string act = "(trade in points)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocanxdate, canxdate) != 0)
            {
                string act = "(trade in points)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }              

            if (String.Compare(omcwv, mcwaiver) != 0)
            {
                string act = "(trade in points)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(oadhar, adhar) != 0)
            {
                string act = "(trade in points) adhar Card changed from:" + oadhar + "To:" + adhar;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opan, pancrd) != 0)
            {
                string act = "(trade in points) pan card changed from:" + opan + "To:" + pancrd;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
 

            if (String.Compare(otip_Trade_In_Details_club_resort, tpresort) != 0)
            {
                string act = "(trade in points) club(trade in) changed from:" + otip_Trade_In_Details_club_resort + "To:" + tpresort;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_Trade_In_Details_No_rights, tpnpts) != 0)
            {
                string act = "(trade in points) points rights (trade in) changed from:" + otip_Trade_In_Details_No_rights + "To:" + tpnpts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otip_Trade_In_Details_ContNo_RCINo, tpcontno) != 0)
            {
                string act = "(trade in points) cont.no (trade in) changed from:" + otip_Trade_In_Details_ContNo_RCINo + "To:" + tpcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_Trade_In_Details_Points_value, tpptsval) != 0)
            {
                string act = "(trade in points)new points changed from:" + otip_Trade_In_Details_Points_value + "To:" + tpptsval;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otip_New_Club, pts_club) != 0)
            {
                string act = "(trade in points) club name changed from:" + opts_club + "To:" + pts_club;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_New_Club_Points_Rights, pts_newpts) != 0)
            {
                string act = "(trade in points)new points changed from:" + opts_newpts + "To:" + pts_newpts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otip_New_MemebrshipType, pts_entitlement) != 0)
            {
                string act = "(trade in points)entitlement changed from:" + otip_New_MemebrshipType + "To:" + pts_entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_New_TotalPointsRights, pts_totalpts) != 0)
            {
                string act = "(trade in points) total points changed from:" + otip_New_TotalPointsRights + "To:" + pts_totalpts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_New_First_year_occupancy, pts_firstyr) != 0)
            {
                string act = "(trade in points) first yr changed from:" + otip_New_First_year_occupancy + "To:" + pts_firstyr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_New_Tenure, pts_Tenure) != 0)
            {
                string act = "(trade in points)tenure changed from:" + otip_New_Tenure + "To:" + pts_Tenure;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_New_Last_year_occupancy, pts_lastyr) != 0)
            {
                string act = "(trade in points) last yr changed from:" + otip_New_Last_year_occupancy + "To:" + pts_lastyr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otip_nopersons, pts_nopersons) != 0)
            {
                string act = "(trade in points) No. Of Persons changed from:" + opts_nopersons + "To:" + pts_nopersons;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinance, finance) != 0)
            {
                string act = "(trade in points) financemethod changed from:" + ofinance + "To:" + finance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(omcfees, mcfees) != 0)
            {
                string act = "(trade in points) MC fees changed from:" + omcfees + "To:" + mcfees;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omcdate, mcdate) != 0)
            {
                string act = "(trade in points) MC Date changed from:" + omcdate + "To:" + mcdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omemberfee, memberfee) != 0)
            {
                string act = "(trade in points) member fee changed from:" + omemberfee + "To:" + memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omemebercgst, memebercgst) != 0)
            {
                string act = "(trade in points) MC cgst changed from:" + omemebercgst + "To:" + memebercgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omembersgst, membersgst) != 0)
            {
                string act = "(trade in points) MC sgst changed from:" + omembersgst + "To:" + membersgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocurrency, currency) != 0)
            {
                string act = "(trade in points) Currency changed from:" + ocurrency + "To:" + currency;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oaffiliate, affiliate) != 0)
            {
                string act = "(trade in points) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalintax, totalintax) != 0)
            {
                string act = "(trade in points) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepamt, depamt) != 0)
            {
                string act = "(trade in points)deposit amount changed from:" + odepamt + "To:" + depamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalpayable, balpayable) != 0)
            {
                string act = "(trade in points)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obaladepamtdate, baldepdate) != 0)
            {
                string act = "(trade in points)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepbal, depbal) != 0)
            {
                string act = "(trade in points)Balance deposit changed from:" + odepbal + "To:" + depbal;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoinstallment, noinstallment) != 0)
            {
                string act = "(trade in points) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oinstallment, installment) != 0)
            {
                string act = "(trade in points) Installment Amount changed from:" + oinstallment + "To:" + installment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
                {
                    //check if contracttno exists in installment table if yes deleete if no  nothting
                    //check previous valu of installment
                    if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
                    {

                    }
                    else
                    {
                        //delete from installment table;
                    }
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete from table
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }

                    }
                    else { }

                }
                else
                {
                    //delete .//previous installment
                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                    {
                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:"+ Installment_Invoice_No+","+"Deleted Datetime:"+ DateTime.Now.ToString()+","+ "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                     
                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                    }
                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate+","+"Invoice ID:"+ Queries.GetInstallmentInvoiceNo(office)+","+"Contract details ID:" +ContractdetailsIDTextBox.Text ;
                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                }
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete .//previous installment
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date =   dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

                    }
                    else
                    {
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


                    }
                }
                else
                { }
            }
            if (String.Compare(ototalbalance, totalbalance) != 0)
            {
                string act = "(trade in points) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opaymethod, paymethod) != 0)
            {
                string act = "(trade in points) pay method changed from:" + opaymethod + "To:" + paymethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinancemethod, financemethod) != 0)
            {
                string act = "(trade in points)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oFinanceno, Financeno) != 0)
            {
                string act = "(trade in points) Finance no changed from:" + oFinanceno + "To:" + Financeno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinmonth, finmonth) != 0)
            {
                string act = "(trade in points) finance month changed from:" + ofinmonth + "To:" + finmonth;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoemi, noemi) != 0)
            {
                string act = "(trade in points) No of EMI changed from:" + onoemi + "To:" + noemi;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(oemiamt, emiamt) != 0)
            {
                string act = "(trade in points) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofindocfee, findocfee) != 0)
            {
                string act = "(trade in points) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oisgtrate, isgtrate) != 0)
            {
                string act = "(trade in points) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oigstamt, igstamt) != 0)
            {
                string act = "(trade in points) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ointerestrate, interestrate) != 0)
            {
                string act = "(trade in points)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onewpoints, newpoints) != 0)
            {
                string act = "(trade in points) New points changed from:" + onewpoints + "To:" + newpoints;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oconversionfee, conversionfee) != 0)
            {
                string act = "(trade in points) Conversion Fee changed from:" + oconversionfee + "To:" + conversionfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oadminfee, adminfee) != 0)
            {
                string act = "(trade in points)Admin Fee changed from:" + oadminfee + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototpurchprice, totpurchprice) != 0)
            {
                string act = "(trade in points) Purchase Price changed from:" + ototpurchprice + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocgst, cgst) != 0)
            {
                string act = "(trade in points) CGST changed from:" + ocgst + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgst, sgst) != 0)
            {
                string act = "(trade in points)SGST changed from:" + osgst + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalpriceInTax, totalpriceInTax) != 0)
            {
                string act = "(trade in points) Total Price including Tax (PA) changed from:" + ototalpriceInTax + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odeposit, deposit) != 0)
            {
                string act = "(trade in points) Deposit(PA) changed from:" + odeposit + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalance, balance) != 0)
            {
                string act = "(trade in points) Balance(PA) changed from:" + obalance + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalancedue, balancedue) != 0)
            {
                string act = "(trade in points) balance due date(PA) changed from:" + obalancedue + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oremarks, remarks) != 0)
            {
                string act = "(trade in points) Remarks changed from:" + oremarks + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oPayment_Mode, paymentmode) != 0)
            {
                string act = "(trade in points)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oReceipt_Date, receiptdate) != 0)
            {
                string act = "(trade in points)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }



            if (String.Compare(ototalamt, indeposit.ToString()) != 0)
            {
                string act = "(trade in points)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oAmount, taxableamt.ToString()) != 0)
            {
                string act = "(trade in points)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
            {
                string act = "(trade in points)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocgstamt, gst.ToString()) != 0)
            {
                string act = "(trade in points)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgstamt, gst.ToString()) != 0)
            {
                string act = "(trade in points)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
            {
                installment = "0";
            }
            else
            {
                installment = installmentamtTextBox.Text;
            }
            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
            {
                noinstallment = "0";
            }
            else
            {
                noinstallment = NoinstallmentTextBox.Text;
            }
            int updatepointscontract = Queries.UpdateContract_Trade_In_Points_Indian( tpresort,tpnpts,tpcontno,tpptsval,pts_club, pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr, contractnoTextBox.Text,ContractdetailsIDTextBox.Text);

            int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);
           	
  int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text); 
	   int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, "", "", "", baldepdate,"", ContractdetailsIDTextBox.Text);
            int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
          //   int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);
            if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN")
            {
                int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
            }
            else
            {
                int updatefin = Queries.UpdatefinanceStartdate(contractno);
            }

            string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);
        }
        else if(contract== "Trade-In-Weeks")
        {
            DataSet dstiw = Queries.LoadTradeinWeeksDetails(ContractdetailsIDTextBox.Text);

            otiw_Trade_In_Weeks_resort = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_resort"].ToString();
                otiw_Trade_In_Weeks_Apt = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Apt"].ToString();
                otiw_Trade_In_Weeks_Season = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Season"].ToString();
                otiw_Trade_In_Weeks_NoWks = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_NoWks"].ToString();
                otiw_Trade_In_Weeks_ContNo_RCINo = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_ContNo_RCINo"].ToString();
                otiw_Trade_In_Weeks_Points_value = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Points_value"].ToString();
                otiw_NewPointsW_Club = dstiw.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                otiw_NewPointsW_Club_Points_Rights = dstiw.Tables[0].Rows[0]["NewPointsW_Club_Points_Rights"].ToString();
                otiw_NewPointsW_MemebrshipType = dstiw.Tables[0].Rows[0]["NewPointsW_MemebrshipType"].ToString();
                otiw_NewPointsW_Total_Points_rights = dstiw.Tables[0].Rows[0]["NewPointsW_Total_Points_rights"].ToString();
                otiw_NewPointsW_First_year_occupancy = dstiw.Tables[0].Rows[0]["NewPointsW_First_year_occupancy"].ToString();
                otiw_NewPointsW_Tenure = dstiw.Tables[0].Rows[0]["NewPointsW_Tenure"].ToString();
                otiw_NewPointsW_Last_year_occupancy = dstiw.Tables[0].Rows[0]["NewPointsW_Last_year_occupancy"].ToString();
                otiw_nopersons = dstiw.Tables[0].Rows[0]["NoPersons"].ToString();
            

            

            DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);
            onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
            oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
            oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
            ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
            osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
            ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
            obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
            obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();
        


            string tpresort = tnmresortTextBox.Text;
            string apt = tnmapttypeTextBox.Text;
            string season= tnmseasonDropDownList.SelectedItem.Text;
            string nowks = nmnowksTextBox.Text;
            string tpcontno = nmcontrcinoTextBox.Text;          
            string tpptsval = tipptsvalueTextBox.Text;
            string pts_club = clubTextBox.Text;
            string pts_newpts = newpointsrightTextBox.Text;
            string pts_entitlement = EntitlementPoinDropDownList.SelectedItem.Text;// Request.Form[EntitlementPoinDropDownList.UniqueID];
            string pts_totalpts = totalptrightsTextBox.Text;
            string pts_firstyr = firstyrTextBox.Text;
            string pts_Tenure = tenureTextBox.Text;
            string pts_lastyr = lastyrTextBox.Text;
            string pts_nopersons = NoPersonsTextBox.Text;

             
            //string interestrate = interestrateTextBox.Text;
            string newpoints = newpointsTextBox.Text;
            string conversionfee = conversionfeeTextBox.Text;
            string adminfee = adminfeeTextBox.Text;
            string totpurchprice = totpurchpriceTextBox.Text;
            string cgst = cgstTextBox.Text;
            string sgst = sgstTextBox.Text;
            string totalpriceInTax = totalpriceInTaxTextBox.Text;
            string deposit = depositTextBox.Text;
            string balance = balanceTextBox.Text;
            string balancedue = balancedueTextBox.Text;
            string remarks = remarksTextBox.Text;
          
            if (mcRadioButtonList.Checked == true)
            {
                mcwaiver = "Yes";
            }
            else
            {
                mcwaiver = "No";

            }
            
            if (String.Compare(ocogstin, ngstin) != 0)
            {
                string act = "(trade in weeks)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocontractno, contractno) != 0)
            {
                //update in installment table
                int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
                if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
                {
                    int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
                }
                else { }
                string act = "(trade in weeks)Contract NO changed from:" + ocontractno + "To:" + contractno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocsalesrep, csalesrep) != 0)
            {
                string act = "(trade in weeks)sales rep changed from:" + ocsalesrep + "To:" + csalesrep;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocTomgr, cTomgr) != 0)
            {
                string act = "(trade in weeks) TO manager changed from:" + ocTomgr + "To:" + cTomgr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(obuttonup, buttonup) != 0)
            {
                string act = "(trade in weeks)button up changed from:" + obuttonup + "To:" + buttonup;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(odealdate, dealdate) != 0)
            {
                string act = "(trade in weeks)deal date changed from:" + odealdate + "To:" + dealdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
	if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
            {
                string act = "(trade in weeks)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(odealstatus, dealstatus) != 0)
            {
                string act = "(trade in weeks) deal status changed from:" + odealstatus + "To:" + dealstatus;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
            {
                string act = "(trade in weeks)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocanxcontno, canxcontno) != 0)
            {
                string act = "(trade in weeks)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocanxdate, canxdate) != 0)
            {
                string act = "(trade in weeks)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
           
            if (String.Compare(omcwv, mcwaiver) != 0)
            {
                string act = "(trade in weeks)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(oadhar, adhar) != 0)
            {
                string act = "(trade in weeks) adhar Card changed from:" + oadhar + "To:" + adhar;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opan, pancrd) != 0)
            {
                string act = "(trade in weeks) pan card changed from:" + opan + "To:" + pancrd;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(otiw_Trade_In_Weeks_resort, tpresort) != 0)
            {
                string act = "(trade in weeks) club(trade in) changed from:" + otiw_Trade_In_Weeks_resort + "To:" + tpresort;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otiw_Trade_In_Weeks_Apt, apt) != 0)
            {
                string act = "(trade in weeks) Apt Type(trade in) changed from:" + otiw_Trade_In_Weeks_Apt + "To:" + apt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otiw_Trade_In_Weeks_Season, season) != 0)
            {
                string act = "(trade in weeks) Season(trade in) changed from:" + otiw_Trade_In_Weeks_Season + "To:" + season;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(otiw_Trade_In_Weeks_NoWks, nowks) != 0)
            {
                string act = "(trade in weeks) No. Wks(trade in) changed from:" + otiw_Trade_In_Weeks_NoWks + "To:" + nowks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { } 
            if (String.Compare(otiw_Trade_In_Weeks_ContNo_RCINo, tpcontno) != 0)
            {
                string act = "(trade in weeks) cont.no (trade in) changed from:" + otiw_Trade_In_Weeks_ContNo_RCINo + "To:" + tpcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiw_Trade_In_Weeks_Points_value, tpptsval) != 0)
            {
                string act = "(trade in weeks) points value changed from:" + otiw_Trade_In_Weeks_Points_value + "To:" + tpptsval;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otiw_NewPointsW_Club, pts_club) != 0)
            {
                string act = "(trade in weeks) club name changed from:" + otiw_NewPointsW_Club + "To:" + pts_club;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiw_NewPointsW_Club_Points_Rights, pts_newpts) != 0)
            {
                string act = "(trade in weeks)new points changed from:" + otiw_NewPointsW_Club_Points_Rights + "To:" + pts_newpts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otiw_NewPointsW_MemebrshipType, pts_entitlement) != 0)
            {
                string act = "(trade in weeks)entitlement changed from:" + otiw_NewPointsW_MemebrshipType + "To:" + pts_entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiw_NewPointsW_Total_Points_rights, pts_totalpts) != 0)
            {
                string act = "(trade in weeks) total points changed from:" + otiw_NewPointsW_Total_Points_rights + "To:" + pts_totalpts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiw_NewPointsW_First_year_occupancy, pts_firstyr) != 0)
            {
                string act = "(trade in weeks) first yr changed from:" + otiw_NewPointsW_First_year_occupancy + "To:" + pts_firstyr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiw_NewPointsW_Tenure, pts_Tenure) != 0)
            {
                string act = "(trade in weeks)tenure changed from:" + otiw_NewPointsW_Tenure + "To:" + pts_Tenure;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiw_NewPointsW_Last_year_occupancy, pts_lastyr) != 0)
            {
                string act = "(trade in weeks) last yr changed from:" + otiw_NewPointsW_Last_year_occupancy + "To:" + pts_lastyr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiw_nopersons, pts_nopersons) != 0)
            {
                string act = "(trade in weeks) last yr changed from:" + otiw_nopersons + "To:" + pts_nopersons;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinance, finance) != 0)
            {
                string act = "(trade in weeks) financemethod changed from:" + ofinance + "To:" + finance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(omcfees, mcfees) != 0)
            {
                string act = "(trade in weeks) MC fees changed from:" + omcfees + "To:" + mcfees;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omcdate, mcdate) != 0)
            {
                string act = "(trade in weeks) MC Date changed from:" + omcdate + "To:" + mcdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omemberfee, memberfee) != 0)
            {
                string act = "(trade in weeks) member fee changed from:" + omemberfee + "To:" + memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omemebercgst, memebercgst) != 0)
            {
                string act = "(trade in weeks) MC cgst changed from:" + omemebercgst + "To:" + memebercgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(omembersgst, membersgst) != 0)
            {
                string act = "(trade in weeks) MC sgst changed from:" + omembersgst + "To:" + membersgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocurrency, currency) != 0)
            {
                string act = "(trade in weeks) Currency changed from:" + ocurrency + "To:" + currency;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oaffiliate, affiliate) != 0)
            {
                string act = "(trade in weeks) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalintax, totalintax) != 0)
            {
                string act = "(trade in weeks) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepamt, depamt) != 0)
            {
                string act = "(trade in weeks)deposit amount changed from:" + odepamt + "To:" + depamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalpayable, balpayable) != 0)
            {
                string act = "(trade in weeks)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obaladepamtdate, baldepdate) != 0)
            {
                string act = "(points)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepbal, depbal) != 0)
            {
                string act = "(trade in weeks)Balance deposit changed from:" + odepbal + "To:" + depbal;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoinstallment, noinstallment) != 0)
            {
                string act = "(trade in weeks) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oinstallment, installment) != 0)
            {
                string act = "(trade in weeks) Installment Amount changed from:" + oinstallment + "To:" + installment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
                {
                    //check if contracttno exists in installment table if yes deleete if no  nothting
                    //check previous valu of installment
                    if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
                    {

                    }
                    else
                    {
                        //delete from installment table;
                    }
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete from table
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }

                    }
                    else { }

                }
                else
                {
                    //delete .//previous installment
                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                    {
                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                    }
                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                }
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete .//previous installment
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date =   dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

                    }
                    else
                    {
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


                    }
                }
                else
                { }
            }
            if (String.Compare(ototalbalance, totalbalance) != 0)
            {
                string act = "(trade in weeks) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opaymethod, paymethod) != 0)
            {
                string act = "(trade in weeks) pay method changed from:" + opaymethod + "To:" + paymethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinancemethod, financemethod) != 0)
            {
                string act = "(trade in weeks)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oFinanceno, Financeno) != 0)
            {
                string act = "(trade in weeks) Finance no changed from:" + oFinanceno + "To:" + Financeno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinmonth, finmonth) != 0)
            {
                string act = "(trade in weeks) finance month changed from:" + ofinmonth + "To:" + finmonth;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoemi, noemi) != 0)
            {
                string act = "(trade in weeks) No of EMI changed from:" + onoemi + "To:" + noemi;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(oemiamt, emiamt) != 0)
            {
                string act = "(trade in weeks) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofindocfee, findocfee) != 0)
            {
                string act = "(trade in weeks) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oisgtrate, isgtrate) != 0)
            {
                string act = "(trade in weeks) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oigstamt, igstamt) != 0)
            {
                string act = "(trade in weeks) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ointerestrate, interestrate) != 0)
            {
                string act = "(trade in weeks)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onewpoints, newpoints) != 0)
            {
                string act = "(trade in weeks) New points changed from:" + onewpoints + "To:" + newpoints;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oconversionfee, conversionfee) != 0)
            {
                string act = "(trade in weeks) Conversion Fee changed from:" + oconversionfee + "To:" + conversionfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oadminfee, adminfee) != 0)
            {
                string act = "(trade in weeks)Admin Fee changed from:" + oadminfee + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototpurchprice, totpurchprice) != 0)
            {
                string act = "(trade in weeks) Purchase Price changed from:" + ototpurchprice + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocgst, cgst) != 0)
            {
                string act = "(trade in weeks) CGST changed from:" + ocgst + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgst, sgst) != 0)
            {
                string act = "(trade in weeks)SGST changed from:" + osgst + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalpriceInTax, totalpriceInTax) != 0)
            {
                string act = "(trade in weeks) Total Price including Tax (PA) changed from:" + ototalpriceInTax + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odeposit, deposit) != 0)
            {
                string act = "(trade in weeks) Deposit(PA) changed from:" + odeposit + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalance, balance) != 0)
            {
                string act = "(trade in weeks) Balance(PA) changed from:" + obalance + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalancedue, balancedue) != 0)
            {
                string act = "(trade in weeks) balance due date(PA) changed from:" + obalancedue + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oremarks, remarks) != 0)
            {
                string act = "(trade in weeks) Remarks changed from:" + oremarks + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPayment_Mode, paymentmode) != 0)
            {
                string act = "(trade in weeks)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oReceipt_Date, receiptdate) != 0)
            {
                string act = "(trade in weeks)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalamt, indeposit.ToString()) != 0)
            {
                string act = "(trade in weeks)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oAmount, taxableamt.ToString()) != 0)
            {
                string act = "(trade in weeks)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
            {
                string act = "(trade in weeks)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocgstamt, gst.ToString()) != 0)
            {
                string act = "(trade in weeks)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgstamt, gst.ToString()) != 0)
            {
                string act = "(trade in weeks)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
            {
                installment = "0";
            }
            else
            {
                installment = installmentamtTextBox.Text;
            }
            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
            {
                noinstallment = "0";
            }
            else
            {
                noinstallment = NoinstallmentTextBox.Text;
            }

            int updatepointscontract = Queries.UpdateContract_Trade_In_Weeks_Indian(tpresort, apt, season, nowks, tpcontno, tpptsval, pts_club, pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr, contractnoTextBox.Text,ContractdetailsIDTextBox.Text);
             int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);
        
  	int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);    
	int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, "", "", "", baldepdate,"", ContractdetailsIDTextBox.Text);
            int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
           //  int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);

            string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);
        }
        else if (contract == "Fractional")
        {
            DataSet dstif = Queries.loadtradeinfractional(ContractdetailsIDTextBox.Text);
            otifresort = dstif.Tables[0].Rows[0]["resort"].ToString();
            otifresidence_no = dstif.Tables[0].Rows[0]["residence_no"].ToString();
            otifresidence_type = dstif.Tables[0].Rows[0]["residence_type"].ToString();
            otiffractional_interest = dstif.Tables[0].Rows[0]["fractional_interest"].ToString();
            otifentitlement = dstif.Tables[0].Rows[0]["entitlement"].ToString();
            otiffirstyear_Occupancy = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
            otiftenure = dstif.Tables[0].Rows[0]["tenure"].ToString();
            otiflastyear_Occupancy = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();
            otifleaseback = dstif.Tables[0].Rows[0]["leaseback"].ToString();
            otifMc_Charges = dstif.Tables[0].Rows[0]["Mc_Charges"].ToString();
            otifOldcontracttype = dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString();
            otifRESORT = dstif.Tables[0].Rows[0]["tradeinresort"].ToString();
            otifAPT_TYPE = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString();
            otifSEASON = dstif.Tables[0].Rows[0]["SEASON"].ToString();
            otifNO_WEEKS = dstif.Tables[0].Rows[0]["NO_WEEKS"].ToString();
            otifNO_POINTS = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
            otifPOINTS_VALUE = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();
            otifoldContract_No = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
            otifSales_Rep = dstif.Tables[0].Rows[0]["Sales_Rep"].ToString();
            otifTO_Manager = dstif.Tables[0].Rows[0]["TO_Manager"].ToString();
            otifButtonUp_Officer = dstif.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
            otifDealRegistered_Date = dstif.Tables[0].Rows[0]["DealRegistered_Date"].ToString();
            otifDealStatus = dstif.Tables[0].Rows[0]["DealStatus"].ToString();
            otifMCWaiver = dstif.Tables[0].Rows[0]["MCWaiver"].ToString();
            otifFinance_Details = dstif.Tables[0].Rows[0]["Finance_Details"].ToString();
            otifContract_Remark = dstif.Tables[0].Rows[0]["Contract_Remark"].ToString();
            otifPan_Card = dstif.Tables[0].Rows[0]["Pan_Card"].ToString();
            otifAdhar_Card = dstif.Tables[0].Rows[0]["Adhar_Card"].ToString();
            otifMC_Charges = dstif.Tables[0].Rows[0]["MC_Charges"].ToString();
            otifFirst_MC_Payable_Date = dstif.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
            otifMemberFee = dstif.Tables[0].Rows[0]["MemberFee"].ToString();
            otifMemberCGST = dstif.Tables[0].Rows[0]["MemberCGST"].ToString();
            otifMembersGST = dstif.Tables[0].Rows[0]["MembersGST"].ToString();
            oloanbuofficer= dstif.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
            ocanxcontno= dstif.Tables[0].Rows[0]["CanxContractNo"].ToString();
            ocanxdate= dstif.Tables[0].Rows[0]["Contract_Canx_date"].ToString();

           
            DataSet dsfpa = Queries.LoadfractionalPA(ContractdetailsIDTextBox.Text);
            ofctAdmission_fees = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
            ofctadministration_fees = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
            ofctCgst = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
            ofctSgst = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
            ofctTotal_Purchase_Price = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            ofctTotal_Price_Including_Tax = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            ofctDeposit = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
            ofctBalance = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
            ofctBalance_Due_Dates = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            ofctRemarks = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();

          

            string tpresort = tnmresortTextBox.Text;
            string apt = tnmapttypeTextBox.Text;
         
          //  string season = tnmseasonDropDownList.SelectedItem.Text;

 		string  season = Request.Form[tnmseasonDropDownList.UniqueID];
            if (season == null || season=="")
            {
                season = "";
            }else
            {
                season = Request.Form[tnmseasonDropDownList.UniqueID];
            }
            string nowks = nmnowksTextBox.Text;
            string tpcontno = nmcontrcinoTextBox.Text;
            string tpnopts = tipnopointsTextBox.Text;
            string tpptsval = tipptsvalueTextBox.Text;
            string resort = fwresortDropDownList.SelectedItem.Text;
            string residence_no = fwresidencenoDropDownList.SelectedItem.Text;
            string residence_type = fwresidencetypeDropDownList.SelectedItem.Text;
            string fractional_interest = fwfractIntDropDownList.SelectedItem.Text;
            string entitlement = fwentitlementDropDownList.SelectedItem.Text;
            string firstyear_Occupancy = fwfirstyrTextBox.Text;
            string tenure = fwtenureTextBox.Text;
            string lastyear_Occupancy = fwlastyrTextBox.Text;
            string ocontracttype = oldcontracttypeDropDownList.SelectedItem.Text;

          
           
            string adminfee = adminfeeTextBox.Text;
            string oAdministrationFees = AdministrationFeesTextBox.Text;
            string totpurchprice = totpurchpriceTextBox.Text;
            string cgst = cgstTextBox.Text;
            string sgst = sgstTextBox.Text;
            string totalpriceInTax = totalpriceInTaxTextBox.Text;
            string deposit = depositTextBox.Text;
            string balance = balanceTextBox.Text;
            string balancedue = balancedueTextBox.Text;
            string remarks = remarksTextBox.Text;
         
            if (mcRadioButtonList.Checked == true)
            {
                mcwaiver = "Yes";
            }
            else
            {
                mcwaiver = "No";

            }
            if (String.Compare(ocompanyname, ncompanyname) != 0)
            {
                int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
                string act = "(fractional)company name changed from:" + ocompanyname + "To:" + ncompanyname;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocogstin, ngstin) != 0)
            {
                string act = "(fractional)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocontractno, contractno) != 0)
            {
                //update in installment table
                int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
                if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
                {
                    int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
                }
                else { }
                string act = "(fractional)Contract NO changed from:" + ocontractno + "To:" + contractno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifSales_Rep, csalesrep) != 0)
            {
                string act = "(fractional)sales rep changed from:" + otifSales_Rep + "To:" + csalesrep;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifTO_Manager, cTomgr) != 0)
            {
                string act = "(fractional) TO manager changed from:" + otifTO_Manager + "To:" + cTomgr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifButtonUp_Officer, buttonup) != 0)
            {
                string act = "(fractional)button up changed from:" + otifButtonUp_Officer + "To:" + buttonup;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(otifDealRegistered_Date, dealdate) != 0)
            {
                string act = "(fractional)deal date changed from:" + otifDealRegistered_Date + "To:" + dealdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
	 if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
            {
                string act = "(fractional)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifDealStatus, dealstatus) != 0)
            {
                string act = "(fractional) deal status changed from:" + otifDealStatus + "To:" + dealstatus;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
            {
                string act = "(fractional)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocanxcontno, canxcontno) != 0)
            {
                string act = "(fractional)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocanxdate, canxdate) != 0)
            {
                string act = "(fractional)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
           

            if (String.Compare(otifMCWaiver, mcwaiver) != 0)
            {
                string act = "(fractional)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(otifAdhar_Card, adhar) != 0)
            {
                string act = "(fractional) adhar Card changed from:" + otifAdhar_Card + "To:" + adhar;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifPan_Card, pancrd) != 0)
            {
                string act = "(fractional) pan card changed from:" + otifPan_Card + "To:" + pancrd;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifOldcontracttype, ocontracttype) != 0)
            {
                string act = "(fractional) Old Contract Type changed from:" + otifOldcontracttype + "To:" + ocontracttype;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifRESORT, tpresort) != 0)
            {
                string act = "(fractional) Resort(trade in) changed from:" + otifRESORT + "To:" + tpresort;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifAPT_TYPE, apt) != 0)
            {
                string act = "(fractional) Apt Type(trade in) changed from:" + otifAPT_TYPE + "To:" + apt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifSEASON, season) != 0)
            {
                string act = "(fractional) Season(trade in) changed from:" + otifSEASON + "To:" + season;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(otifNO_WEEKS, nowks) != 0)
            {
                string act = "(fractional) No. Wks(trade in) changed from:" + otifNO_WEEKS + "To:" + nowks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifoldContract_No, tpcontno) != 0)
            {
                string act = "(fractional) cont.no (trade in) changed from:" + otifoldContract_No + "To:" + tpcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
            {
                string act = "(fractional)no.of points value changed from:" + otifNO_POINTS + "To:" + tpnopts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
            {
                string act = "(fractional) points value changed from:" + otifPOINTS_VALUE + "To:" + tpptsval;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifresort, resort) != 0)
            {
                string act = "(fractional) points value changed from:" + otifresort + "To:" + resort;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifresidence_no, residence_no) != 0)
            {
                string act = "(fractional) residence_no value changed from:" + otifresidence_no + "To:" + residence_no;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifresidence_type, residence_type) != 0)
            {
                string act = "(fractional) residence_type value changed from:" + otifresidence_type + "To:" + residence_type;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiffractional_interest, fractional_interest) != 0)
            {
                string act = "(fractional) fractional_interest value changed from:" + otiffractional_interest + "To:" + fractional_interest;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifentitlement, entitlement) != 0)
            {
                string act = "(fractional) Entitlement value changed from:" + otifentitlement + "To:" + entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiffirstyear_Occupancy, firstyear_Occupancy) != 0)
            {
                string act = "(fractional) First Yr Occupancy value changed from:" + otiffirstyear_Occupancy + "To:" + firstyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiftenure, tenure) != 0)
            {
                string act = "(fractional) Tenure changed from:" + otiftenure + "To:" + tenure;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiflastyear_Occupancy, lastyear_Occupancy) != 0)
            {
                string act = "(fractional) Last Yr Occupancy value changed from:" + otiflastyear_Occupancy + "To:" + lastyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifFinance_Details, finance) != 0)
            {
                string act = "(fractional) financemethod changed from:" + otifFinance_Details + "To:" + finance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(otifMC_Charges, mcfees) != 0)
            {
                string act = "(fractional) MC fees changed from:" + otifMC_Charges + "To:" + mcfees;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifFirst_MC_Payable_Date, mcdate) != 0)
            {
                string act = "(fractional) MC Date changed from:" + otifFirst_MC_Payable_Date + "To:" + mcdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifMemberFee, memberfee) != 0)
            {
                string act = "(fractional) member fee changed from:" + otifMemberFee + "To:" + memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifMemberCGST, memebercgst) != 0)
            {
                string act = "(fractional) MC cgst changed from:" + otifMemberCGST + "To:" + memebercgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifMembersGST, membersgst) != 0)
            {
                string act = "(fractional) MC sgst changed from:" + otifMembersGST + "To:" + membersgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocurrency, currency) != 0)
            {
                string act = "(fractional) Currency changed from:" + ocurrency + "To:" + currency;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oaffiliate, affiliate) != 0)
            {
                string act = "(fractional) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalintax, totalintax) != 0)
            {
                string act = "(fractional) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepamt, depamt) != 0)
            {
                string act = "(fractional)deposit amount changed from:" + odepamt + "To:" + depamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalpayable, balpayable) != 0)
            {
                string act = "(fractional)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obaladepamtdate, baldepdate) != 0)
            {
                string act = "(fractional)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepbal, depbal) != 0)
            {
                string act = "(fractional)Balance deposit changed from:" + odepbal + "To:" + depbal;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oregcollectionterm, regcollectionterm) != 0)
            {
                string act = "(fractional)reg collection term changed from:" + oregcollectionterm + "To:" + regcollectionterm;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oregcollamt, regcollamt) != 0)
            {
                string act = "(fractional)reg collection amt changed from:" + oregcollamt + "To:" + regcollamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ooldLoanAgreement, oldloanagreementno) != 0)
            {
                string act = "(fractional)old loan agreement no changed from:" + ooldLoanAgreement + "To:" + oldloanagreementno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ooldloanamt, loanamt) != 0)
            {
                string act = "(fractional)old loan amt changed from:" + ooldloanamt + "To:" + loanamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoinstallment, noinstallment) != 0)
            {
                string act = "(fractional) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oinstallment, installment) != 0)
            {
                string act = "(fractional) Installment Amount changed from:" + oinstallment + "To:" + installment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
                {
                    //check if contracttno exists in installment table if yes deleete if no  nothting
                    //check previous valu of installment
                    if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
                    {

                    }
                    else
                    {
                        //delete from installment table;
                    }
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete from table
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }

                    }
                    else { }

                }
                else
                {
                    //delete .//previous installment
                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                    {
                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                    }
                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                }
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete .//previous installment
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

                    }
                    else
                    {
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


                    }
                }
                else
                { }

            }
            if (String.Compare(ototalbalance, totalbalance) != 0)
            {
                string act = "(fractional) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opaymethod, paymethod) != 0)
            {
                string act = "(fractional) pay method changed from:" + opaymethod + "To:" + paymethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinancemethod, financemethod) != 0)
            {
                string act = "(fractional)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oFinanceno, Financeno) != 0)
            {
                string act = "(fractional) Finance no changed from:" + oFinanceno + "To:" + Financeno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinmonth, finmonth) != 0)
            {
                string act = "(fractional) finance month changed from:" + ofinmonth + "To:" + finmonth;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoemi, noemi) != 0)
            {
                string act = "(fractional) No of EMI changed from:" + onoemi + "To:" + noemi;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(oemiamt, emiamt) != 0)
            {
                string act = "(fractional) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofindocfee, findocfee) != 0)
            {
                string act = "(fractional) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oisgtrate, isgtrate) != 0)
            {
                string act = "(fractional) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oigstamt, igstamt) != 0)
            {
                string act = "(fractional) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ointerestrate, interestrate) != 0)
            {
                string act = "(fractional)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctAdmission_fees, adminfee) != 0)
            {
                string act = "(fractional)Admission fees changed from:" + ofctAdmission_fees + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctadministration_fees, oAdministrationFees) != 0)
            {
                string act = "(fractional)Administration Fees changed from:" + ofctadministration_fees + "To:" + oAdministrationFees;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctCgst, cgst) != 0)
            {
                string act = "(fractional)CGST amt changed from:" + ofctCgst + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctSgst, sgst) != 0)
            {
                string act = "(fractional) SGST amt changed from:" + ofctSgst + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctTotal_Purchase_Price, totpurchprice) != 0)
            {
                string act = "(fractional)Total purchase price changed from:" + ofctTotal_Purchase_Price + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctTotal_Price_Including_Tax, totalpriceInTax) != 0)
            {
                string act = "(fractional)Total price In. Tax changed from:" + ofctTotal_Price_Including_Tax + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctDeposit, deposit) != 0)
            {
                string act = "(fractional)Deposit changed from:" + ofctDeposit + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctBalance, balance) != 0)
            {
                string act = "(fractional)balance Rate changed from:" + ofctBalance + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctBalance_Due_Dates, balancedue) != 0)
            {
                string act = "(fractional)balance due changed from:" + ofctBalance_Due_Dates + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctRemarks, remarks) != 0)
            {
                string act = "(fractional)remarks changed from:" + ofctRemarks + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPayment_Mode, paymentmode) != 0)
            {
                string act = "(fractional)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oReceipt_Date, receiptdate) != 0)
            {
                string act = "(fractional)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ototalamt, indeposit.ToString()) != 0)
            {
                string act = "(fractional)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oAmount, taxableamt.ToString()) != 0)
            {
                string act = "(fractional)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
            {
                string act = "(fractional)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocgstamt, gst.ToString()) != 0)
            {
                string act = "(fractional)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgstamt, gst.ToString()) != 0)
            {
                string act = "(fractional)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
            {
                installment = "0";
            }
            else
            {
                installment = installmentamtTextBox.Text;
            }
            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
            {
                noinstallment = "0";
            }
            else
            {
                noinstallment = NoinstallmentTextBox.Text;
            }
            int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);

  		int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);
            int updatecontractPA = Queries.UpdateContract_FractionalPA_Indian(adminfee, oAdministrationFees, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text,"","", ContractdetailsIDTextBox.Text);
             int updatefractionalcontract = Queries.UpdateContract_Fractional_Indian(resort, residence_no, residence_type, fractional_interest, entitlement, firstyear_Occupancy, tenure, lastyear_Occupancy,"", mcfees, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);


            int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text,"","","",  baldepdate,"", ContractdetailsIDTextBox.Text);
            // int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);
            

            string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);

        }
        else if (contract == "Trade-In-Fractionals")
        {
            DataSet dstif = Queries.loadtradeinfractional(ContractdetailsIDTextBox.Text);
            otifresort = dstif.Tables[0].Rows[0]["resort"].ToString();
            otifresidence_no = dstif.Tables[0].Rows[0]["residence_no"].ToString();
            otifresidence_type = dstif.Tables[0].Rows[0]["residence_type"].ToString();
            otiffractional_interest = dstif.Tables[0].Rows[0]["fractional_interest"].ToString();
            otifentitlement = dstif.Tables[0].Rows[0]["entitlement"].ToString();
            otiffirstyear_Occupancy = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
            otiftenure = dstif.Tables[0].Rows[0]["tenure"].ToString();
            otiflastyear_Occupancy = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();
            otifleaseback = dstif.Tables[0].Rows[0]["leaseback"].ToString();
            otifMc_Charges = dstif.Tables[0].Rows[0]["Mc_Charges"].ToString();
            otifOldcontracttype = dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString();
            otifRESORT = dstif.Tables[0].Rows[0]["tradeinresort"].ToString();
            otifAPT_TYPE = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString();
            otifSEASON = dstif.Tables[0].Rows[0]["SEASON"].ToString();
            otifNO_WEEKS = dstif.Tables[0].Rows[0]["NO_WEEKS"].ToString();
            otifNO_POINTS = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
            otifPOINTS_VALUE = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();
            otifoldContract_No = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
            otifSales_Rep = dstif.Tables[0].Rows[0]["Sales_Rep"].ToString();
            otifTO_Manager = dstif.Tables[0].Rows[0]["TO_Manager"].ToString();
            otifButtonUp_Officer = dstif.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
            otifDealRegistered_Date = dstif.Tables[0].Rows[0]["DealRegistered_Date"].ToString();
            otifDealStatus = dstif.Tables[0].Rows[0]["DealStatus"].ToString();          
            otifMCWaiver = dstif.Tables[0].Rows[0]["MCWaiver"].ToString();
            otifFinance_Details = dstif.Tables[0].Rows[0]["Finance_Details"].ToString();
            otifContract_Remark = dstif.Tables[0].Rows[0]["Contract_Remark"].ToString();
            otifPan_Card = dstif.Tables[0].Rows[0]["Pan_Card"].ToString();
            otifAdhar_Card = dstif.Tables[0].Rows[0]["Adhar_Card"].ToString();
            otifMC_Charges = dstif.Tables[0].Rows[0]["MC_Charges"].ToString();
            otifFirst_MC_Payable_Date = dstif.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
            otifMemberFee = dstif.Tables[0].Rows[0]["MemberFee"].ToString();
            otifMemberCGST = dstif.Tables[0].Rows[0]["MemberCGST"].ToString();
            otifMembersGST = dstif.Tables[0].Rows[0]["MembersGST"].ToString();
            oloanbuofficer = dstif.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
            ocanxcontno = dstif.Tables[0].Rows[0]["CanxContractNo"].ToString();
            ocanxdate = dstif.Tables[0].Rows[0]["Contract_Canx_date"].ToString();

            DataSet dsfpa = Queries.LoadfractionalPA(ContractdetailsIDTextBox.Text);
            otradeinvalue= dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
            ototalvalue= dsfpa.Tables[0].Rows[0]["Total_value"].ToString();
            ofctAdmission_fees = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
            ofctadministration_fees = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
            ofctCgst = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
            ofctSgst = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
            ofctTotal_Purchase_Price = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            ofctTotal_Price_Including_Tax = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            ofctDeposit = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
            ofctBalance = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
            ofctBalance_Due_Dates = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            ofctRemarks = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();

          
            string tpresort = tnmresortTextBox.Text;
            string apt = tnmapttypeTextBox.Text;
            string season;         
           if(Request.Form[tnmseasonDropDownList.UniqueID]=="")
            {
                season = "";

            }
            else
            {
                season = Request.Form[tnmseasonDropDownList.UniqueID];

            }
            string tradeinresort = tnmresortTextBox.Text;
            string nowks = nmnowksTextBox.Text;
            string tpcontno = nmcontrcinoTextBox.Text;
            string tpnopts = tipnopointsTextBox.Text;
            string tpptsval = tipptsvalueTextBox.Text;            
            string resort = fwresortDropDownList.SelectedItem.Text;
           string residence_no = fwresidencenoDropDownList.SelectedItem.Text;
            string residence_type = fwresidencetypeDropDownList.SelectedItem.Text;
            string fractional_interest = fwfractIntDropDownList.SelectedItem.Text;
            string entitlement = fwentitlementDropDownList.SelectedItem.Text;
            string firstyear_Occupancy = fwfirstyrTextBox.Text;
         string tenure = fwtenureTextBox.Text;
         string lastyear_Occupancy = fwlastyrTextBox.Text;
            string ocontracttype = oldcontracttypeDropDownList.SelectedItem.Text;

        
           
            string tradeinvalue = ftradeinvalueTextBox.Text;
            string totalvalue = ftotalvalueTextBox.Text;

            string adminfee = adminfeeTextBox.Text;
            string oAdministrationFees = AdministrationFeesTextBox.Text;
            string totpurchprice = totpurchpriceTextBox.Text;
            string cgst = cgstTextBox.Text;
            string sgst = sgstTextBox.Text;
            string totalpriceInTax = totalpriceInTaxTextBox.Text;
            string deposit = depositTextBox.Text;
            string balance = balanceTextBox.Text;
            string balancedue = balancedueTextBox.Text;
            string remarks = remarksTextBox.Text;
             
            if (mcRadioButtonList.Checked == true)
            {
                mcwaiver = "Yes";
            }
            else
            {
                mcwaiver = "No";

            }
            if (String.Compare(ocompanyname, ncompanyname) != 0)
            {
                int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
                string act = "(trade in fractional)company name changed from:" + ocompanyname + "To:" + ncompanyname;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocogstin, ngstin) != 0)
            {
                string act = "(trade in fractional)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocontractno, contractno) != 0)
            {
                //update in installment table
                int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
                if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
                {
                    int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
                }
                else { }
                string act = "(trade in fractional)Contract NO changed from:" + ocontractno + "To:" + contractno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifSales_Rep, csalesrep) != 0)
            {
                string act = "(trade in fractional)sales rep changed from:" + otifSales_Rep + "To:" + csalesrep;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifTO_Manager, cTomgr) != 0)
            {
                string act = "(trade in fractional) TO manager changed from:" + otifTO_Manager + "To:" + cTomgr;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifButtonUp_Officer, buttonup) != 0)
            {
                string act = "(trade in fractional)button up changed from:" + otifButtonUp_Officer + "To:" + buttonup;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(otifDealRegistered_Date, dealdate) != 0)
            {
                string act = "(trade in fractional)deal date changed from:" + otifDealRegistered_Date + "To:" + dealdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
		if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
            {
                string act = "(trade in fractional)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifDealStatus, dealstatus) != 0)
            {
                string act = "(trade in fractional) deal status changed from:" + otifDealStatus + "To:" + dealstatus;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
            {
                string act = "(trade in fractional)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocanxcontno, canxcontno) != 0)
            {
                string act = "(trade in fractional)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocanxdate, canxdate) != 0)
            {
                string act = "(trade in fractional)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
          

            if (String.Compare(otifMCWaiver, mcwaiver) != 0)
            {
                string act = "(trade in fractional)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(otifAdhar_Card, adhar) != 0)
            {
                string act = "(trade in fractional) adhar Card changed from:" + otifAdhar_Card + "To:" + adhar;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifPan_Card, pancrd) != 0)
            {
                string act = "(trade in fractional) pan card changed from:" + otifPan_Card + "To:" + pancrd;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifOldcontracttype, ocontracttype) != 0)
            {
                string act = "(trade in fractional) Old Contract Type changed from:" + otifOldcontracttype + "To:" + ocontracttype;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifRESORT, tradeinresort) != 0)
            {
                string act = "(trade in fractional) Resort(trade in) changed from:" + otifRESORT + "To:" + tradeinresort;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifAPT_TYPE, apt) != 0)
            {
                string act = "(trade in fractional) Apt Type(trade in) changed from:" + otifAPT_TYPE + "To:" + apt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifSEASON, season) != 0)
            {
                string act = "(trade in fractional) Season(trade in) changed from:" + otifSEASON + "To:" + season;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }       
            

            if (String.Compare(otifNO_WEEKS, nowks) != 0)
            {
                string act = "(trade in fractional) No. Wks(trade in) changed from:" + otifNO_WEEKS + "To:" + nowks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifoldContract_No, tpcontno) != 0)
            {
                string act = "(trade in fractional) cont.no (trade in) changed from:" + otifoldContract_No + "To:" + tpcontno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
            {
                string act = "(trade in fractional)no.of points value changed from:" + otifNO_POINTS + "To:" + tpnopts;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
            {
                string act = "(trade in fractional) points value changed from:" + otifPOINTS_VALUE + "To:" + tpptsval;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifresort  ,resort) != 0)
            {
                string act = "(trade in fractional) points value changed from:" + otifresort + "To:" + resort;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifresidence_no, residence_no) != 0)
            {
                string act = "(trade in fractional) residence_no value changed from:" + otifresidence_no + "To:" + residence_no;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifresidence_type  ,residence_type) != 0)
            {
                string act = "(trade in fractional) residence_type value changed from:" + otifresidence_type + "To:" + residence_type;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiffractional_interest, fractional_interest) != 0)
            {
                string act = "(trade in fractional) fractional_interest value changed from:" + otiffractional_interest + "To:" + fractional_interest;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifentitlement ,entitlement) != 0)
            {
                string act = "(trade in fractional) Entitlement value changed from:" + otifentitlement + "To:" + entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiffirstyear_Occupancy, firstyear_Occupancy) != 0)
            {
                string act = "(trade in fractional) First Yr Occupancy value changed from:" + otiffirstyear_Occupancy + "To:" + firstyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiftenure  ,tenure) != 0)
            {
                string act = "(trade in fractional) Tenure changed from:" + otiftenure + "To:" + tenure;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otiflastyear_Occupancy, lastyear_Occupancy) != 0)
            {
                string act = "(trade in fractional) Last Yr Occupancy value changed from:" + otiflastyear_Occupancy + "To:" + lastyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
           
            if (String.Compare(otifFinance_Details, finance) != 0)
            {
                string act = "(trade in fractional) financemethod changed from:" + otifFinance_Details + "To:" + finance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(otifMC_Charges, mcfees) != 0)
            {
                string act = "(trade in fractional) MC fees changed from:" + otifMC_Charges + "To:" + mcfees;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifFirst_MC_Payable_Date, mcdate) != 0)
            {
                string act = "(trade in fractional) MC Date changed from:" + otifFirst_MC_Payable_Date + "To:" + mcdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifMemberFee, memberfee) != 0)
            {
                string act = "(trade in fractional) member fee changed from:" + otifMemberFee + "To:" + memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifMemberCGST, memebercgst) != 0)
            {
                string act = "(trade in fractional) MC cgst changed from:" + otifMemberCGST + "To:" + memebercgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otifMembersGST, membersgst) != 0)
            {
                string act = "(trade in fractional) MC sgst changed from:" + otifMembersGST + "To:" + membersgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ocurrency, currency) != 0)
            {
                string act = "(trade in fractional) Currency changed from:" + ocurrency + "To:" + currency;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oaffiliate, affiliate) != 0)
            {
                string act = "(trade in fractional) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalintax, totalintax) != 0)
            {
                string act = "(trade in fractional) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepamt, depamt) != 0)
            {
                string act = "(trade in fractional)deposit amount changed from:" + odepamt + "To:" + depamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obalpayable, balpayable) != 0)
            {
                string act = "(trade in fractional)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(obaladepamtdate, baldepdate) != 0)
            {
                string act = "(trade in fractional)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(odepbal, depbal) != 0)
            {
                string act = "(trade in fractional)Balance deposit changed from:" + odepbal + "To:" + depbal;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoinstallment, noinstallment) != 0)
            {
                string act = "(trade in fractional) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oinstallment, installment) != 0)
            {
                string act = "(trade in fractional) Installment Amount changed from:" + oinstallment + "To:" + installment;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
                {
                    //check if contracttno exists in installment table if yes deleete if no  nothting
                    //check previous valu of installment
                    if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
                    {

                    }
                    else
                    {
                        //delete from installment table;
                    }
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete from table
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }

                    }
                    else { }

                }
                else
                {
                    //delete .//previous installment
                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                    {
                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                    }
                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                }
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
                    if (exists == 1)
                    {
                        //delete .//previous installment
                        DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            string Installment_Date =   dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

                            int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
                        }
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

                    }
                    else
                    {
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
                            int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
                        //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
                        //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
                        //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


                    }
                }
                else
                { }
            }
            if (String.Compare(ototalbalance, totalbalance) != 0)
            {
                string act = "(trade in fractional) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(opaymethod, paymethod) != 0)
            {
                string act = "(trade in fractional) pay method changed from:" + opaymethod + "To:" + paymethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinancemethod, financemethod) != 0)
            {
                string act = "(trade in fractional)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oFinanceno, Financeno) != 0)
            {
                string act = "(trade in fractional) Finance no changed from:" + oFinanceno + "To:" + Financeno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofinmonth, finmonth) != 0)
            {
                string act = "(trade in fractional) finance month changed from:" + ofinmonth + "To:" + finmonth;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(onoemi, noemi) != 0)
            {
                string act = "(trade in fractional) No of EMI changed from:" + onoemi + "To:" + noemi;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
                CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
            }
            else { }
            if (String.Compare(oemiamt, emiamt) != 0)
            {
                string act = "(trade in fractional) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofindocfee, findocfee) != 0)
            {
                string act = "(trade in fractional) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oisgtrate, isgtrate) != 0)
            {
                string act = "(trade in fractional) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oigstamt, igstamt) != 0)
            {
                string act = "(trade in fractional) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ointerestrate, interestrate) != 0)
            {
                string act = "(trade in fractional)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otradeinvalue,  tradeinvalue) != 0)
            {
                string act = "(trade in fractional)Trade in value changed from:" + otradeinvalue  + "To:" +  tradeinvalue ;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ototalvalue, totalvalue) != 0)
            {
                string act = "(trade in fractional)total value changed from:" + ototalvalue + "To:" + totalvalue;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctAdmission_fees ,adminfee) != 0)
            {
                string act = "(trade in fractional)Admission fees changed from:" + ofctAdmission_fees + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctadministration_fees, oAdministrationFees) != 0)
            {
                string act = "(trade in fractional)Administration fees changed from:" + ofctadministration_fees + "To:" + oAdministrationFees;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctCgst,cgst) != 0)
            {
                string act = "(trade in fractional) Cgst changed from:" + ofctCgst + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctSgst, sgst) != 0)
            {
                string act = "(trade in fractional) Sgst changed from:" + ofctSgst + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctTotal_Purchase_Price,totpurchprice) != 0)
            {
                string act = "(trade in fractional)Total Purchase Price changed from:" + ofctTotal_Purchase_Price + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctTotal_Price_Including_Tax, totalpriceInTax) != 0)
            {
                string act = "(trade in fractional)Total Price Including Tax changed from:" + ofctTotal_Price_Including_Tax + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctDeposit,deposit) != 0)
            {
                string act = "(trade in fractional) Deposit changed from:" + ofctDeposit + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctBalance, balance) != 0)
            {
                string act = "(trade in fractional)ofctBalance changed from:" + ofctBalance + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctBalance_Due_Dates,balancedue) != 0)
            {
                string act = "(trade in fractional) Balance Due Dates changed from:" + ofctBalance_Due_Dates + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ofctRemarks, remarks) != 0)
            {
                string act = "(trade in fractional) Remarks changed from:" + ofctRemarks + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oregcollectionterm, regcollectionterm) != 0)
            {
                string act = "(trade in fractional)reg collection term changed from:" + oregcollectionterm + "To:" + regcollectionterm;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oregcollamt, regcollamt) != 0)
            {
                string act = "(trade in fractional)reg collection amt changed from:" + oregcollamt + "To:" + regcollamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ooldLoanAgreement, oldloanagreementno) != 0)
            {
                string act = "(trade in fractional)old loan agreement no changed from:" + ooldLoanAgreement + "To:" + oldloanagreementno;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ooldloanamt, loanamt) != 0)
            {
                string act = "(trade in fractional)old loan agreement no changed from:" + ooldloanamt + "To:" + loanamt;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPayment_Mode, paymentmode) != 0)
            {
                string act = "(trade in fractional)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oReceipt_Date, receiptdate) != 0)
            {
                string act = "(trade in fractional)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ototalamt, indeposit.ToString()) != 0)
            {
                string act = "(trade in fractional)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oAmount, taxableamt.ToString()) != 0)
            {
                string act = "(trade in fractional)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
            {
                string act = "(trade in fractional)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocgstamt, gst.ToString()) != 0)
            {
                string act = "(trade in fractional)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(osgstamt, gst.ToString()) != 0)
            {
                string act = "(trade in fractional)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
                int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
            }
            else { }

            if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
            {
                installment = "0";
            }
            else
            {
                installment = installmentamtTextBox.Text;
            }
            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
            {
                noinstallment = "0";
            }
            else
            {
                noinstallment = NoinstallmentTextBox.Text;
            }

            int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);

  		int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);           
		 int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, oldloanagreementno, regcollectionterm, regcollamt, baldepdate, loanamt, ContractdetailsIDTextBox.Text);
            int updatecontractPA = Queries.UpdateContract_FractionalPA_Indian(adminfee, oAdministrationFees, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text,tradeinvalue,totalvalue, ContractdetailsIDTextBox.Text);
            int updatepointscontract = Queries.UpdateContract_Trade_In_Fractional_Indian(ocontracttype, tpresort, apt, season, nowks, tpnopts, tpptsval, tpcontno, contractnoTextBox.Text,ContractdetailsIDTextBox.Text);
            int updatefractionalcontract = Queries.UpdateContract_Fractional_Indian(resort, residence_no, residence_type, fractional_interest, entitlement, firstyear_Occupancy, tenure, lastyear_Occupancy, "", mcfees, contractnoTextBox.Text,ContractdetailsIDTextBox.Text);

           //  int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);
            string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);
        }

    





}

protected void Button5_Click(object sender, EventArgs e)
    {
        string contractno = contractnoTextBox.Text;
        string ContractType = contracttypeTextBox.Text;
        if (ContractType == "Fractional")
        {

            string printr = PrintPdfDropDownList.SelectedItem.Text;

            if (printr.Contains("BREAKUP"))//== "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("RECEIPT"))// == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("ADDITION"))// (printr== "ADDITION OF NAME LETTER")
            {
                DataTable datatable = Queries.AdditionalName_FractionalProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("SOR"))
            {
                DataTable datatable = Queries.SOR_FractionalProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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

            else if (printr.Contains("AUTHORISED"))
            {
                DataTable datatable = Queries.CompanyLetterHead(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt"));
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            if (printr.Contains("BREAKUP"))// == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("RECEIPT"))//printr == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("ADDITION"))
            //else if (printr == "ADDITION OF NAME LETTER")
            {
                DataTable datatable = Queries.AdditionalName_NewPointsProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("SOR"))
            {


            }

            else if (printr.Contains("AUTHORISED"))
            {
                DataTable datatable = Queries.CompanyLetterHead(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                DataTable datatable = Queries.NewPoints_PA(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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

            if (printr.Contains("BREAKUP"))// == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("RECEIPT"))// == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            // else if (printr == "ADDITION OF NAME LETTER" || printr== "TRADEIN_POINTS_ADDITION OF NAME LETTER")
            else if (printr.Contains("ADDITION"))
            {
                DataTable datatable = Queries.AdditionalName_TIPProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("SOR"))
            {
                DataTable datatable = Queries.SOR_TIPProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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

            else if (printr.Contains("AUTHORISED"))
            {
                DataTable datatable = Queries.CompanyLetterHead(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            if (printr.Contains("BREAKUP"))// == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("RECEIPT"))// == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            // else if (printr == "ADDITION OF NAME LETTER" || printr == "TRADEIN_WEEKS_ADDITION OF NAME LETTER")
            else if (printr.Contains("ADDITION"))
            {
                DataTable datatable = Queries.AdditionalName_TIWProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("SOR"))
            {
                DataTable datatable = Queries.SOR_TIWProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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

            else if (printr.Contains("AUTHORISED"))
            {
                DataTable datatable = Queries.CompanyLetterHead(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            if (printr.Contains("BREAKUP"))// == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("RECEIPT"))// == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            //else if (printr == "ADDITION OF NAME LETTER")
            else if (printr.Contains("ADDITION"))
            {
                DataTable datatable = Queries.AdditionalName_FractionalProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
            else if (printr.Contains("SOR"))
            {
                DataTable datatable = Queries.SOR_FractionalProc(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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

            else if (printr.Contains("AUTHORISED"))
            {
                DataTable datatable = Queries.CompanyLetterHead(contractno);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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
                crystalReport.Load(Server.MapPath("~/ireports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/ireports/" + printr + ".rpt") + "Export";
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


    [WebMethod]
    public static string getPointsAmoountTax(string currency)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string JSON = "{\n \"names\":[";
        string query = "select amount,taxValue from PointsContract where currency='"+currency+"' and status='Active' ;";
        SqlCommand sql =new SqlCommand(query,sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            double amount = reader.GetDouble(0);
            double tax = reader.GetDouble(1);
            JSON += "[\"" + amount + "\",\"" + tax + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    //Code commented by gaurav 8-12-2017
    //[WebMethod]
    //public static string getContractnoOnClub(string venue, string venuegrp, string club,string nationality)
    //{

    //    string JSON = "{\n \"names\":[";
    //    if(nationality=="Indian")
    //    {
    //        SqlDataReader reader = Queries.GetIncrementValueofContractClubIndian(venue, venuegrp, club, nationality);
    //        while (reader.Read())
    //        {
    //            string code = reader.GetString(0);
    //            //  string src = reader.GetString(1);
    //            //  string inc = reader.GetString(2);
    //            //JSON += "[\"" + code + "\",\"" + src + "\",\"" + inc + "\"],";

    //            JSON += "[\"" + code + "\"],";
    //        }
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";

    //    }

    //    else
    //    {
    //        SqlDataReader reader = Queries.GetIncrementValueofContractClubNonIndian(venue, venuegrp, club, nationality);
    //        while (reader.Read())
    //        {
    //            string code = reader.GetString(0);
    //            //  string src = reader.GetString(1);
    //            //  string inc = reader.GetString(2);
    //            //JSON += "[\"" + code + "\",\"" + src + "\",\"" + inc + "\"],";
    //            JSON += "[\"" + code + "\"],";
    //        }
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";

    //    }


    //    return JSON;

    //}




        // new code gaurav
    [WebMethod]
        public static string getContractnoOnClub(string venue,string venuegrp,string club,string nationality)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string JSON = "{\n \"names\":[";
        if (nationality == "Indian")
        {
            string query = "SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and cc.Nationality ='Indian'";
            SqlCommand sql = new SqlCommand(query, sqlcon);

            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                string code = reader.GetString(0);
                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            string query = "SELECT Contract_Code + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + Increment_Value + vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and cc.Nationality !='Indian'";
            SqlCommand sql = new SqlCommand(query, sqlcon);

            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                string code = reader.GetString(0);
                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
           

        return JSON;
    }



    [WebMethod]
    public static string getFinanceNo(string venue, string finance,string type,string financevalue,string contractdetails_id)
    {
        


        string JSON = "{\n \"names\":[";
        int exists = Queries.CheckFinanceIndianDetailsExists(contractdetails_id, financevalue, finance);
        if (exists == 1)
        {
            SqlDataReader reader = Queries.getFinanceNoFromID(contractdetails_id, financevalue, finance);
            while (reader.Read())
            {
                string code = reader.GetString(0);

                JSON += "[\"" + code + "\"],";

            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetFinanceNoIncrementValue(venue, finance, type);
            string code;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (type == "Fractional" || type == "Trade-In-Fractionals")
                    {
                        code = reader.GetString(0) + "Z6";
                    }
                    else
                    {
                        code = reader.GetString(0) + "Z8";
                    }

                    JSON += "[\"" + code + "\"],";

                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";

            }
            else
            {
                if (type == "Fractional" || type == "Trade-In-Fractionals")
                {
                    code = reader.GetString(0) + "Z6";
                }
                else
                {
                    code = reader.GetString(0) + "Z8";
                }

                JSON += "[\"" + code + "\"],";
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
               

            }
                
        }
        return JSON;

    }
    [WebMethod]
    public static string GetfractionalResidenceType(string resort)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadfractionalResidencetype(resort);
        while (reader.Read())
        {
            string type = reader.GetString(0);

            JSON += "[\"" + type + "\"],";

        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadfractionalResidenceNo(string resort)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadfractionalResidenceNo(resort);
        while (reader.Read())
        {
            string mn = reader.GetString(0);

            JSON += "[\"" + mn + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }



    [WebMethod]
    public static string getContractnoOnResort(string venue, string club, string nationality)
    {

        string JSON = "{\n \"names\":[";
        if (nationality == "Indian")

        {
            SqlDataReader reader = Queries.GetIncrementValueofContractResortIndian(venue, club);//, nationality);
            while (reader.Read())
            {
                string code = reader.GetString(0);
                 
                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetIncrementValueofContractResortNonIndian(venue, club);//, nationality);
            while (reader.Read())
            {

                string code = reader.GetString(0);

                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        return JSON;
}


[WebMethod]
public static string LoadClubNameonContractType(string contracttype)
{

    string JSON = "{\n \"names\":[";


    SqlDataReader reader = Queries.LoadClubOnContractType(contracttype);
    while (reader.Read())
    {
        string club = reader.GetString(0);

        JSON += "[\"" + club + "\"],";
    }
    JSON = JSON.Substring(0, JSON.Length - 1);
    JSON += "] \n}";

    return JSON;
}


    [WebMethod]
    public static string getVenueOnCountry(string countryName)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = " select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_Name = '" + countryName + "')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }

    [WebMethod]
    public static string getVenueGroupOnVenue(string venue)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select vg.Venue_Group_ID,vg.Venue_Group_Name from Venue_Group vg where vg.Venue_ID in(select venue.Venue_ID from venue where venue.Venue_Name ='" + venue + "')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(1);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }


    



    protected void Button6_Click(object sender, EventArgs e)
    {
        DataSet ds = Queries.LoadProfielDetailsFull(profileidTextBox.Text);
        oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
        oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
        oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
        oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
        oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
        oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
        oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
        oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
        oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
        oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
        oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
        oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
        oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
        oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
        oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
	ocomment2 = ds.Tables[0].Rows[0]["comment2"].ToString();
        oManager = ds.Tables[0].Rows[0]["Manager"].ToString();
        ophid = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
        ocard = ds.Tables[0].Rows[0]["Card_Holder"].ToString();

        oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
        oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
        oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
        oProfile_Primary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
        oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
        opage = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
        opdesignation = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
        oplang = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

        oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
        oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
        oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
        oProfile_Secondary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);//Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
        oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
        osage = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
        osdesignation = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
        oslang = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

        oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
        oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
        oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
        oSub_Profile1_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
        oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
        oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
        osp1age = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

        oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
        oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
        oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
        oSub_Profile2_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
        oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
        oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
        osp2age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

        oSub_Profile3_Title = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
        oSub_Profile3_Fname = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
        oSub_Profile3_Lname = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
     
        oSub_Profile3_Nationality = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
        oSub_Profile3_Country = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
        oSub_Profile3_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]); 
        osp3age = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

        oSub_Profile4_Title = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
        oSub_Profile4_Fname = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
        oSub_Profile4_Lname = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
         oSub_Profile4_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
        oSub_Profile4_Nationality = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
        oSub_Profile4_Country = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
        osp4age = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

        oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
        oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
        oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
        oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
        oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
        oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
        oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();
        oProfile_Address_Country = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();

        oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
        oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
        oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
        oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
        opriOfficecc= ds.Tables[0].Rows[0]["Primary_office_cc"].ToString();
        opriOfficeno = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();
        oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
        oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
        oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
        oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
        osecOfficecc = ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString(); 
        osecOfficeno = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString(); 
        oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
        oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
        oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
        oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
        oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
        oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
        oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
        oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

        oSubprofile3_CC = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
        oSubprofile3_Mobile = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
        oSubprofile3_Alt_CC = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
        oSubprofile3_Alternate = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

        oSubprofile4_CC = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
        oSubprofile4_Mobile = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
        oSubprofile4_Alt_CC = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
        oSubprofile4_Alternate = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();

        oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
        oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
        oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
        oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
        oSubprofile3_Email = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
        oSubprofile4_Email = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

        oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
        oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
        oProfile_Stay_Arrival_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Stay_Departure_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

        oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
        oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
        oTour_Details_Tour_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
        oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
        oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
        oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
        oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
        oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
        oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
        oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
        oregTerms = ds.Tables[0].Rows[0]["RegTerms"].ToString();
        //update profile
        

        string user = (string)Session["username"];
        createdbyTextBox.Text = user;
        //get office of user
        string office = Queries.GetOffice(user);

        string profile = profileidTextBox.Text;
        string createdby = createdbyTextBox.Text;
        string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
        string venue = VenueDropDownList.SelectedItem.Text;
        string venuegroup = GroupVenueDropDownList.SelectedItem.Text;
        string mktg = Request.Form["MarketingProgramDropDownList"];//MarketingProgramDropDownList.SelectedItem.Text;
        if (mktg == "")
        {
            mktg = MarketingProgramDropDownList.Items[0].Text;

        }
        else
        {
            mktg = Request.Form["MarketingProgramDropDownList"];
        }
        string agents = Request.Form["AgentDropDownList"];// .SelectedItem.Text;
        //string agents1;
        if (agents == "")
        {
            agents = AgentDropDownList.Items[0].Text;
        }
        else
        {
            agents = Request.Form["AgentDropDownList"];
        }
        string agentcode = Request.Form["TONameDropDownList"];// .SelectedItem.Text;
        if (agentcode == "")
        {
            agentcode = TONameDropDownList.Items[0].Text;

        }
        else
        {
            agentcode = Request.Form["TONameDropDownList"];
        }

        string mgr;

        if (venuegroup == "Coldline" || venuegroup == "COLDLINE")
        {
            mgr = Request.Form["ManagerDropDownList"];// SelectedItem.Text;
            if (mgr == "")
            {
                mgr = ManagerDropDownList.Items[0].Text;

            }
            else
            {
                mgr = Request.Form["ManagerDropDownList"];
            }

        }
        else
        {

            mgr = agentcode;
        }





        string photoidentity;
        if (Request.Form["pidentity"] == null)
        {
            photoidentity = "";
        }
        else
        {
            photoidentity = Request.Form["pidentity"];
        }
        string card;
        if (Request.Form["card"] == null)
        {
            card = "";
        }
        else
        {
            card = Request.Form["card"];
        }

        //member details
        string membertype1 = MemType1DropDownList.SelectedItem.Text;// .SelectedItem.Text;
        string memno1 = Memno1TextBox.Text;
        if (mktg == "Owner" || mktg == "OWNER")
        {
            membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno = Memno1TextBox.Text;
            if (memno == null || memno == "")
            {
                memno1 = "";
            }
            else
            {
                memno1 = Memno1TextBox.Text;
            }

        }
        else
        {
            membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno = TypeDropDownList.SelectedItem.Text;
            if (memno == null || memno == "")
            {

                memno1 = "";
            }
            else
            {

                memno1 = TypeDropDownList.SelectedItem.Text;
            }


        }



        string membertype2 = Request.Form[MemType2DropDownList.UniqueID];// .SelectedItem.Text;
        string memno2 = Memno2TextBox.Text;




        //primary profile
        string primarytitle = PrimaryTitleDropDownList.SelectedItem.Text;
        string primaryfname = pfnameTextBox.Text.ToUpper();
        string primaylname = plnameTextBox.Text.ToUpper();
        string primarydob = primarydobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd");
        string primarynationality = PrimarynationalityDropDownList.SelectedItem.Text;
        string primarycountry = primarycountryDropDownList.SelectedItem.Text;
        string npage = primaryAge.Text;
        string npdesg = pdesginationTextBox.Text.ToUpper();
        string primarylanguage;


        if (Request.Form["primarylang"] == null)
        {
            primarylanguage = "";
        }
        else
        {
            primarylanguage = Request.Form["primarylang"];

        }

        //if (primarymobileDropDownList.SelectedIndex == 0)
        //{
        //    pcc = "";

        //}
        //else
        //{

        pcc = Request.Form["primarymobileDropDownList"];//primarymobileDropDownList.SelectedItem.Text;

        if (pcc == "")
        {
            pcc = primarymobileDropDownList.Items[0].Text;
        }
        else
        {
            pcc = Request.Form["primarymobileDropDownList"];

        }

        //}
        //if (primaryalternateDropDownList.SelectedIndex == 0)
        //{
        //    paltrcc = "";
        //}
        //else
        //{

        paltrcc = Request.Form["primaryalternateDropDownList"]; //primaryalternateDropDownList.SelectedItem.Text;
        if (paltrcc == "")
        {
            paltrcc = primaryalternateDropDownList.Items[0].Text;
        }
        else
        {
            paltrcc = Request.Form["primaryalternateDropDownList"];
        }

        priOfficecc = Request.Form["pofficecodeDropDownList"]; //primaryalternateDropDownList.SelectedItem.Text;
        if (priOfficecc == "")
        {
            priOfficecc = pofficecodeDropDownList.Items[0].Text;
        }
        else
        {
            priOfficecc = Request.Form["pofficecodeDropDownList"];
        }



        //}
        if (pmobileTextBox.Text == "" || pmobileTextBox.Text == null)
        {
            pmobile = "";
        }
        else
        {
            pmobile = pmobileTextBox.Text;
        }

        if (palternateTextBox.Text == "" || palternateTextBox.Text == null)
        {
            palternate = "";
        }
        else
        {
            palternate = palternateTextBox.Text;
        }


        if (pofficenoTextBox.Text == "" || pofficenoTextBox.Text == null)
        {
            priOfficeno = "";
        }
        else
        {
            priOfficeno = pofficenoTextBox.Text;
        }

        if (pemailTextBox.Text == "" || pemailTextBox.Text == null)
        {
            pemail = "";
        }
        else
        {
            pemail = pemailTextBox.Text.ToUpper();
        }

        //secondary profile

        string secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
        string secondaryfname = sfnameTextBox.Text.ToUpper();
        string secondarylname = slnameTextBox.Text.ToUpper();
        string secondarydob = secondarydobdatepicker.Text;//Convert.ToDateTime(sdobdatepicker.Text).ToString("yyyy-MM-dd"); 
        string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
        string secondarycountry = secondarycountryDropDownList.SelectedItem.Text;
        string nsage = secondaryAge.Text;
        string nsdesg = sdesignationTextBox.Text.ToUpper();

        string secondarylanguage;
        if (Request.Form["seclang"] == null)
        {
            secondarylanguage = "";
        }
        else
        {
            secondarylanguage = Request.Form["seclang"];

        }
        //if (secondarymobileDropDownList.SelectedIndex == 0)
        //{
        //    scc = "";
        //}
        //else
        //{

        scc = Request.Form["secondarymobileDropDownList"];//secondarymobileDropDownList.SelectedItem.Text;
        if (scc == "")
        {
            scc = secondarymobileDropDownList.Items[0].Text;
        }
        else
        {
            scc = Request.Form["secondarymobileDropDownList"];
        }
        //}

        //if (secondaryalternateDropDownList.SelectedIndex == 0)
        //{
        //    saltcc = "";
        //}
        //else
        //{

        saltcc = Request.Form["secondaryalternateDropDownList"];//secondaryalternateDropDownList.SelectedItem.Text;
        if (saltcc == "")
        {
            saltcc = secondaryalternateDropDownList.Items[0].Text;
        }
        else
        {

            saltcc = Request.Form["secondaryalternateDropDownList"];


        }

        secOfficecc = Request.Form["sofficecodeDropDownList"];//secondaryalternateDropDownList.SelectedItem.Text;
        if (secOfficecc == "")
        {
            secOfficecc = sofficecodeDropDownList.Items[0].Text;
        }
        else
        {

            secOfficecc = Request.Form["sofficecodeDropDownList"];
        }


        //}

        if (smobileTextBox.Text == "" || smobileTextBox.Text == null)
        {
            smobile = "";
        }
        else
        {
            smobile = smobileTextBox.Text;
        }
        if (salternateTextBox.Text == "" || salternateTextBox.Text == null)
        {
            salternate = "";
        }
        else
        {
            salternate = salternateTextBox.Text;
        }

        if (sofficenoTextBox.Text == "" || sofficenoTextBox.Text == null)
        {
            secOfficeno = "";
        }
        else
        {
            secOfficeno = sofficenoTextBox.Text;
        }

        if (semailTextBox.Text == "" || semailTextBox.Text == null)
        {
            semail = "";
        }
        else
        {
            semail = semailTextBox.Text.ToUpper();
        }
        //sub profile1


        string sp1title = sp1titleDropDownList.SelectedItem.Text;
        string sp1fname = sp1fnameTextBox.Text.ToUpper();
        string sp1lname = sp1lnameTextBox.Text.ToUpper();
        string sp1dob = sp1dobdatepicker.Text;//Convert.ToDateTime(sp1dobdatepicker.Text).ToString("yyyy-MM-dd"); 


        string sp1nationality = sp1nationalityDropDownList.SelectedItem.Text;
        string sp1country = sp1countryDropDownList.SelectedItem.Text;
        string nsp1age = subProfile1Age.Text;
        //if (sp1mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp1cc = "";
        //}
        //else
        //{

        sp1cc = Request.Form["sp1mobileDropDownList"];//sp1mobileDropDownList.SelectedItem.Text;
        if (sp1cc == "")
        {
            sp1cc = sp1mobileDropDownList.Items[0].Text;
        }
        else
        {

            sp1cc = Request.Form["sp1mobileDropDownList"];

        }
        //}

        //if (sp1alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp1altcc = "";
        //}
        //else
        //{

        sp1altcc = Request.Form["sp1alternateDropDownList"];// sp1alternateDropDownList.SelectedItem.Text;

        if (sp1altcc == "")
        {
            sp1altcc = sp1alternateDropDownList.Items[0].Text;
        }
        else
        {
            sp1altcc = Request.Form["sp1alternateDropDownList"]; ;
        }
        //}


        if (sp1mobileTextBox.Text == "" || sp1mobileTextBox.Text == null)
        {
            sp1mobile = "";
        }
        else
        {
            sp1mobile = sp1mobileTextBox.Text;
        }
        if (sp1alternateTextBox.Text == "" || sp1alternateTextBox.Text == null)
        {
            sp1alternate = "";
        }
        else
        {
            sp1alternate = sp1alternateTextBox.Text;
        }
        if (sp1pemailTextBox.Text == "" || sp1pemailTextBox.Text == null)
        {
            sp1email = "";
        }
        else
        {
            sp1email = sp1pemailTextBox.Text.ToUpper();
        }



        //sub profile 2
        string sp2title = sp2titleDropDownList.SelectedItem.Text;
        string sp2fname = sp2fnameTextBox.Text.ToUpper();
        string sp2lname = sp2lnameTextBox.Text.ToUpper();
        string sp2dob = sp2dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp2nationality = sp2nationalityDropDownList.SelectedItem.Text;
        string sp2country = sp2countryDropDownList.SelectedItem.Text;
        string nsp2age = subProfile2Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        sp2cc = Request.Form["sp2mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (sp2cc == "")
        {
            sp2cc = sp2mobileDropDownList.Items[0].Text;
        }
        else
        {

            sp2cc = Request.Form["sp2mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        sp2altccc = Request.Form["sp2alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (sp2altccc == "")
        {
            sp2altccc = sp2alternateDropDownList.Items[0].Text;
        }
        else
        {
            sp2altccc = Request.Form["sp2alternateDropDownList"];

        }
        //}


        if (sp2mobileTextBox.Text == "" || sp2mobileTextBox.Text == null)
        {
            sp2mobile = "";
        }
        else
        {
            sp2mobile = sp2mobileTextBox.Text;

        }
        if (sp2alternateTextBox.Text == "" || sp2alternateTextBox.Text == null)
        {
            sp2alternate = "";

        }
        else
        {
            sp2alternate = sp2alternateTextBox.Text;

        }
        if (sp2pemailTextBox.Text == "" || sp2pemailTextBox.Text == null)
        {
            sp2email = "";
        }
        else
        {
            sp2email = sp2pemailTextBox.Text.ToUpper();
        }

        //// sub profile 3//
        string sp3title = sp3titleDropDownList.SelectedItem.Text;
        string sp3fname = sp3fnameTextBox.Text.ToUpper();
        string sp3lname = sp3lnameTextBox.Text.ToUpper();
        string sp3dob = sp3dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp3nationality = sp3nationalityDropDownList.SelectedItem.Text;
        string sp3country = sp3countryDropDownList.SelectedItem.Text;
        string nsp3age = subProfile3Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        sp3cc = Request.Form["sp3mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (sp3cc == "")
        {
            sp3cc = sp3mobileDropDownList.Items[0].Text;
        }
        else
        {

            sp3cc = Request.Form["sp3mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        sp3altccc = Request.Form["sp3alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (sp3altccc == "")
        {
            sp3altccc = sp3alternateDropDownList.Items[0].Text;
        }
        else
        {
            sp3altccc = Request.Form["sp3alternateDropDownList"];

        }
        //}


        if (sp3mobileTextBox.Text == "" || sp3mobileTextBox.Text == null)
        {
            sp3mobile = "";
        }
        else
        {
            sp3mobile = sp3mobileTextBox.Text;

        }
        if (sp3alternateTextBox.Text == "" || sp3alternateTextBox.Text == null)
        {
            sp3alternate = "";

        }
        else
        {
            sp3alternate = sp3alternateTextBox.Text;

        }
        if (sp3pemailTextBox.Text == "" || sp3pemailTextBox.Text == null)
        {
            sp3email = "";
        }
        else
        {
            sp3email = sp3pemailTextBox.Text.ToUpper();
        }
        //end//

        // sub profile 4//
        string sp4title = sp4titleDropDownList.SelectedItem.Text;
        string sp4fname = sp4fnameTextBox.Text.ToUpper();
        string sp4lname = sp4lnameTextBox.Text.ToUpper();
        string sp4dob = sp4dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp4nationality = sp4nationalityDropDownList.SelectedItem.Text;
        string sp4country = sp4countryDropDownList.SelectedItem.Text;
        string nsp4age = subProfile4Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        sp4cc = Request.Form["sp4mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (sp4cc == "")
        {
            sp4cc = sp4mobileDropDownList.Items[0].Text;
        }
        else
        {

            sp4cc = Request.Form["sp4mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        sp4altccc = Request.Form["sp4alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (sp4altccc == "")
        {
            sp4altccc = sp4alternateDropDownList.Items[0].Text;
        }
        else
        {
            sp4altccc = Request.Form["sp4alternateDropDownList"];

        }
        //}


        if (sp4mobileTextBox.Text == "" || sp4mobileTextBox.Text == null)
        {
            sp4mobile = "";
        }
        else
        {
            sp4mobile = sp4mobileTextBox.Text;

        }
        if (sp4alternateTextBox.Text == "" || sp4alternateTextBox.Text == null)
        {
            sp4alternate = "";

        }
        else
        {
            sp4alternate = sp4alternateTextBox.Text;

        }
        if (sp4pemailTextBox.Text == "" || sp4pemailTextBox.Text == null)
        {
            sp4email = "";
        }
        else
        {
            sp4email = sp4pemailTextBox.Text.ToUpper();
        }
        // end//


        //address

        string address1 = address1TextBox.Text.ToUpper();
        string address2 = address2TextBox.Text.ToUpper();
        string state = Request.Form["StateDropDownList"];// StateDropDownList.SelectedItem.Text;
        if (state == "")
        {
            state = StateDropDownList.Items[0].Text;
        }
        else
        {
            state = Request.Form["StateDropDownList"];


        }
        string city = cityTextBox.Text.ToUpper();
        string pincode = pincodeTextBox.Text;
        string acountry = AddCountryDropDownList.SelectedItem.Text;

        //other details

        string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
        string maritalstatus = maritalstatusDropDownList.SelectedItem.Text;
        string livingyrs = livingyrsTextBox.Text;

        //stay details
        string resort = resortTextBox.Text.ToUpper();
        string roomno = roomnoTextBox.Text;
        string arrivaldate = arrivaldatedatepicker.Text;
        string departuredate = departuredatedatepicker.Text;

        //guest status

        string gueststatus = guestatusDropDownList.SelectedItem.Text;
        string salesrep = toursalesrepDropDownList.SelectedItem.Text;
        string timeIn = timeinTextBox.Text;
        string timeOut = timeoutTextBox.Text;
        string tourdate;
        int wkno;
        if (tourdatedatepicker.Text == "" || tourdatedatepicker.Text == null || tourdatedatepicker.Text == "NaN" || tourdatedatepicker.Text == "1-1-1990")
        {
            tourdate = "";
            wkno = 0;
        }
        else
        {
            tourdate = tourdatedatepicker.Text;
            wkno = Queries.GetWkNumber(Convert.ToDateTime(tourdate));
            tourdate = Convert.ToDateTime(tourdatedatepicker.Text).ToString("dd-MM-yyyy");
        }
        string taxin = inpriceTextBox.Text.ToUpper();
        string taxirefin = inrefTextBox.Text.ToUpper();
        string taxiout = outpriceTextBox.Text.ToUpper();
        string taxirefout = outrefTextBox.Text.ToUpper();
        string ProComments = commentsTextBox.Text.ToUpper();
	string Procomment2 = comment2.Text.ToUpper();
        if (CheckBox2.Checked)
        {


            regTerms = "Y";
        }
        else
        {
            regTerms = "N";

        }

        if (String.Compare(oProfile_Venue_Country, venuecountry) != 0)
        {
            string act = "venue country changed from:" + oProfile_Venue_Country + "To:" + venuecountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Venue, venue) != 0)
        {
            string act = "venue changed from:" + oProfile_Venue + "To:" + venue;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Group_Venue, venuegroup) != 0)
        {
            string act = "venue group changed from:" + oProfile_Group_Venue + "To:" + venuegroup;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Marketing_Program, mktg) != 0)
        {
            string act = "marketing prgm changed from:" + oProfile_Marketing_Program + "To:" + mktg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent, agents) != 0)
        {
            string act = "agent name changed from:" + oProfile_Agent + "To:" + agents;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent_Code, agentcode) != 0)
        {
            string act = "To Name changed from:" + oProfile_Agent_Code + "To:" + agentcode;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oManager, mgr) != 0)
        {
            string act = "manager changed from:" + oManager + "To:" + mgr;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type1, membertype1) != 0)
        {
            string act = "membertype1 changed from:" + oProfile_Member_Type1 + "To:" + membertype1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ophid, photoidentity) != 0)
        {
            string act = "Photo Identity changed from:" + ophid + "To:" + photoidentity;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ocard, card) != 0)
        {
            string act = "Card Holder value changed from:" + ocard + "To:" + card;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number1, memno1) != 0)
        {
            string act = "memno1 changed from:" + oProfile_Member_Number1 + "To:" + memno1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type2, membertype2) != 0)
        {
            string act = "membertype2 changed from:" + oProfile_Member_Type2 + "To:" + membertype2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number2, memno2) != 0)
        {
            string act = "memno2 changed from:" + oProfile_Member_Number2 + "To:" + memno2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Title, primarytitle) != 0)
        {
            string act = "primary title changed from:" + oProfile_Primary_Title + "To:" + primarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Fname, primaryfname) != 0)
        {
            string act = "primary fname changed from:" + oProfile_Primary_Fname + "To:" + primaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Lname, primaylname) != 0)
        {
            string act = "primay lname changed from:" + oProfile_Primary_Lname + "To:" + primaylname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_DOB, primarydob) != 0)
        {
            string act = "primary dob changed from:" + oProfile_Primary_DOB + "To:" + primarydob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Nationality, primarynationality) != 0)
        {
            string act = "primary nationality changed from:" + oProfile_Primary_Nationality + "To:" + primarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Country, primarycountry) != 0)
        {
            string act = "primary country changed from:" + oProfile_Primary_Country + "To:" + primarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opage, npage) != 0)
        {
            string act = "primary age changed from:" + opage + "To:" + npage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opdesignation, npdesg) != 0)
        {
            string act = "primary designation changed from:" + opdesignation + "To:" + npdesg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oplang, primarylanguage) != 0)
        {
            string act = "primary Language changed from:" + oplang + "To:" + primarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_CC, pcc) != 0)
        {
            string act = "primary mobile code changed from:" + oPrimary_CC + "To:" + pcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Mobile, pmobile) != 0)
        {
            string act = "primary mobile no changed from:" + oPrimary_Mobile + "To:" + pmobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
        {
            string act = "primary mobile changed from:" + oPrimary_Alt_CC + "To:" + paltrcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alternate, palternate) != 0)
        {
            string act = "primary alternate no changed from:" + oPrimary_Alternate + "To:" + palternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(opriOfficecc, priOfficecc) != 0)
        {
            string act = "primary office cc changed from:" + opriOfficecc + "To:" + priOfficecc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(opriOfficeno, priOfficeno) != 0)
        {
            string act = "primary office no changed from:" + opriOfficeno + "To:" + priOfficeno;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        
        if (String.Compare(oPrimary_Email, pemail) != 0)
        {
            string act = "primary email changed from:" + oPrimary_Email + "To:" + pemail;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Title, secondarytitle) != 0)
        {
            string act = "secondary title changed from:" + oProfile_Secondary_Title + "To:" + secondarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Fname, secondaryfname) != 0)
        {
            string act = "secondary fname changed from:" + oProfile_Secondary_Fname + "To:" + secondaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Lname, secondarylname) != 0)
        {
            string act = "secondary lname changed from:" + oProfile_Secondary_Lname + "To:" + secondarylname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_DOB, secondarydob) != 0)
        {
            string act = "secondary dob changed from:" + oProfile_Secondary_DOB + "To:" + secondarydob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oProfile_Secondary_Nationality, secondarynationality) != 0)
        {
            string act = "secondary nationality changed from:" + oProfile_Secondary_Nationality + "To:" + secondarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osage, nsage) != 0)
        {
            string act = "secondary age changed from:" + osage + "To:" + nsage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osdesignation, nsdesg) != 0)
        {
            string act = "secondary designation changed from:" + osdesignation + "To:" + nsdesg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oslang, secondarylanguage) != 0)
        {
            string act = "secondary Language changed from:" + oslang + "To:" + secondarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Country, secondarycountry) != 0)
        {
            string act = "secondary country changed from:" + oProfile_Secondary_Country + "To:" + secondarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSecondary_CC, scc) != 0)
        {
            string act = "secondary mobile code changed from:" + oSecondary_CC + "To:" + scc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSecondary_Mobile, smobile) != 0)
        {
            string act = "secondary mobile no changed from:" + oSecondary_Mobile + "To:" + smobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());

        }
        else { }
        if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
        {
            string act = "secondary alternaet num code changed from:" + oSecondary_Alt_CC + "To:" + saltcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSecondary_Alternate, salternate) != 0)
        {
            string act = "secondary alternate no changed from:" + oSecondary_Alternate + "To:" + salternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(osecOfficecc, secOfficecc) != 0)
        {
            string act = "secondary office cc changed from:" + osecOfficecc + "To:" + secOfficecc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(osecOfficeno, secOfficeno) != 0)
        {
            string act = "secondary office no changed from:" + osecOfficeno + "To:" + secOfficeno;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oSecondary_Email, semail) != 0)
        {
            string act = "secondary email changed from:" + oSecondary_Email + "To:" + semail;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Title, sp1title) != 0)
        {
            string act = "subprofile1 title changed from:" + oSub_Profile1_Title + "To:" + sp1title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Fname, sp1fname) != 0)
        {
            string act = "subprofile1 fname changed from:" + oSub_Profile1_Fname + "To:" + sp1fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Lname, sp1lname) != 0)
        {
            string act = "subprofile1 lname changed from:" + oSub_Profile1_Lname + "To:" + sp1lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_DOB, sp1dob) != 0)
        {
            string act = "subprofile1 dob changed from:" + oSub_Profile1_DOB + "To:" + sp1dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Nationality, sp1nationality) != 0)
        {
            string act = "subprofile1 nationality changed from:" + oSub_Profile1_Nationality + "To:" + sp1nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp1age, nsp1age) != 0)
        {
            string act = "subprofile1 age changed from:" + osp1age + "To:" + nsp1age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Country, sp1country) != 0)
        {
            string act = "subprofile1 country changed from:" + oSub_Profile1_Country + "To:" + sp1country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
        {
            string act = "subprofile1 mobile code changed from:" + oSubprofile1_CC + "To:" + sp1cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_Mobile, sp1mobile) != 0)
        {
            string act = "subprofile1 mobile no changed from:" + oSubprofile1_Mobile + "To:" + sp1mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
        {
            string act = "subprofile1 alternate no code changed from:" + oSubprofile1_Alt_CC + "To:" + sp1altcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_Alternate, sp1alternate) != 0)
        {
            string act = "subprofile1 alternate changed from:" + oSubprofile1_Alternate + "To:" + sp1alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(oSubprofile1_Email, sp1email) != 0)
        {
            string act = "subprofile1 email changed from:" + oSubprofile1_Email + "To:" + sp1email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Title, sp2title) != 0)
        {
            string act = "subprofile2 title changed from:" + oSub_Profile2_Title + "To:" + sp2title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Fname, sp2fname) != 0)
        {
            string act = "subprofile2 fname changed from:" + oSub_Profile2_Fname + "To:" + sp2fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Lname, sp2lname) != 0)
        {
            string act = "subprofile2 lname changed from:" + oSub_Profile2_Lname + "To:" + sp2lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_DOB, sp2dob) != 0)
        {
            string act = "subprofile2 dob changed from:" + oSub_Profile2_DOB + "To:" + sp2dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Nationality, sp2nationality) != 0)
        {
            string act = "subprofile2 nationality changed from:" + oSub_Profile2_Nationality + "To:" + sp2nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp2age, nsp2age) != 0)
        {
            string act = "subprofile2 age changed from:" + osp2age + "To:" + nsp2age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Country, sp2country) != 0)

        {
            string act = "subprofile2 country changed from:" + oSub_Profile2_Country + "To:" + sp2country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
        {
            string act = "subprofile2 mobile code changed from:" + oSubprofile2_CC + "To:" + sp2cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Mobile, sp2mobile) != 0)
        {
            string act = "subprofile2 mobile no changed from:" + oSubprofile2_Mobile + "To:" + sp2mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
        {
            string act = "subprofile2 alternate no code changed from:" + oSubprofile2_Alt_CC + "To:" + sp2altccc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Alternate, sp2alternate) != 0)
        {
            string act = "subprofile2 alternate no changed from:" + oSubprofile2_Alternate + "To:" + sp2alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Email, sp2email) != 0)
        {
            string act = "subprofile2 email changed from:" + oSubprofile2_Email + "To:" + sp2email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        //// sub profile 3//
        if (String.Compare(oSub_Profile3_Title, sp3title) != 0)
        {
            string act = "subprofile3 title changed from:" + oSub_Profile3_Title + "To:" + sp3title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Fname, sp3fname) != 0)
        {
            string act = "subprofile3 fname changed from:" + oSub_Profile3_Fname + "To:" + sp3fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Lname, sp3lname) != 0)
        {
            string act = "subprofile3 lname changed from:" + oSub_Profile3_Lname + "To:" + sp3lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_DOB, sp3dob) != 0)
        {
            string act = "subprofile3 dob changed from:" + oSub_Profile3_DOB + "To:" + sp3dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Nationality, sp3nationality) != 0)
        {
            string act = "subprofile3 nationality changed from:" + oSub_Profile3_Nationality + "To:" + sp3nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp3age, nsp3age) != 0)
        {
            string act = "subprofile3 age changed from:" + osp3age + "To:" + nsp3age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Country, sp3country) != 0)

        {
            string act = "subprofile3 country changed from:" + oSub_Profile3_Country + "To:" + sp3country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_CC, sp3cc) != 0)
        {
            string act = "subprofile3 mobile code changed from:" + oSubprofile3_CC + "To:" + sp3cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Mobile, sp3mobile) != 0)
        {
            string act = "subprofile3 mobile no changed from:" + oSubprofile3_Mobile + "To:" + sp3mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Alt_CC, sp3altccc) != 0)
        {
            string act = "subprofile3 alternate no code changed from:" + oSubprofile3_Alt_CC + "To:" + sp3altccc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Alternate, sp3alternate) != 0)
        {
            string act = "subprofile3 alternate no changed from:" + oSubprofile3_Alternate + "To:" + sp3alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Email, sp3email) != 0)
        {
            string act = "subprofile3 email changed from:" + oSubprofile3_Email + "To:" + sp3email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        // end//



        // sub profile 4//
        if (String.Compare(oSub_Profile4_Title, sp4title) != 0)
        {
            string act = "subprofile4 title changed from:" + oSub_Profile4_Title + "To:" + sp4title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Fname, sp4fname) != 0)
        {
            string act = "subprofile4 fname changed from:" + oSub_Profile4_Fname + "To:" + sp4fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Lname, sp4lname) != 0)
        {
            string act = "subprofile4 lname changed from:" + oSub_Profile4_Lname + "To:" + sp4lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_DOB, sp4dob) != 0)
        {
            string act = "subprofile4 dob changed from:" + oSub_Profile4_DOB + "To:" + sp4dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Nationality, sp4nationality) != 0)
        {
            string act = "subprofile4 nationality changed from:" + oSub_Profile4_Nationality + "To:" + sp4nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp4age, nsp4age) != 0)
        {
            string act = "subprofile4 age changed from:" + osp4age + "To:" + nsp4age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Country, sp4country) != 0)

        {
            string act = "subprofile4 country changed from:" + oSub_Profile4_Country + "To:" + sp4country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_CC, sp4cc) != 0)
        {
            string act = "subprofile4 mobile code changed from:" + oSubprofile4_CC + "To:" + sp4cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Mobile, sp4mobile) != 0)
        {
            string act = "subprofile4 mobile no changed from:" + oSubprofile4_Mobile + "To:" + sp4mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Alt_CC, sp4altccc) != 0)
        {
            string act = "subprofile4 alternate no code changed from:" + oSubprofile4_Alt_CC + "To:" + sp4altccc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Alternate, sp4alternate) != 0)
        {
            string act = "subprofile4 alternate no changed from:" + oSubprofile4_Alternate + "To:" + sp4alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Email, sp4email) != 0)
        {
            string act = "subprofile4 email changed from:" + oSubprofile4_Email + "To:" + sp4email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        //// end//


        if (String.Compare(oProfile_Address_Line1, address1) != 0)

        {
            string act = "address1 changed from:" + oProfile_Address_Line1 + "To:" + address1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_Line2, address2) != 0)
        {
            string act = "address2 changed from:" + oProfile_Address_Line2 + "To:" + address2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_State, state) != 0)
        {
            string act = "state changed from:" + oProfile_Address_State + "To:" + state;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_city, city) != 0)
        {
            string act = "city changed from:" + oProfile_Address_city + "To:" + city;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_Postcode, pincode) != 0)
        {
            string act = "pincode changed from:" + oProfile_Address_Postcode + "To:" + pincode;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_Country, acountry) != 0)
        {
            string act = "Address Country changed from:" + oProfile_Address_Country + "To:" + acountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Employment_status, employmentstatus) != 0)
        {
            string act = "employment status changed from:" + oProfile_Employment_status + "To:" + employmentstatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Marital_status, maritalstatus) != 0)
        {
            string act = "marital status changed from:" + oProfile_Marital_status + "To:" + maritalstatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_NOY_Living_as_couple, livingyrs) != 0)
        {
            string act = "livingyrs changed from:" + oProfile_NOY_Living_as_couple + "To:" + livingyrs;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Resort_Name, resort) != 0)
        {
            string act = "resort changed from:" + oProfile_Stay_Resort_Name + "To:" + resort;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Resort_Room_Number, roomno) != 0)
        {
            string act = "roomno changed from:" + oProfile_Stay_Resort_Room_Number + "To:" + roomno;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Arrival_Date, arrivaldate) != 0)
        {
            string act = "arrival date changed from:" + oProfile_Stay_Arrival_Date + "To:" + arrivaldate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Departure_Date, departuredate) != 0)
        {
            string act = "departure date changed from:" + oProfile_Stay_Departure_Date + "To:" + departuredate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Guest_Status, gueststatus) != 0)
        {
            string act = "guest status changed from:" + oTour_Details_Guest_Status + "To:" + gueststatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Guest_Sales_Rep, salesrep) != 0)

        {
            string act = "salesrep changed from:" + oTour_Details_Guest_Sales_Rep + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Sales_Deck_Check_In, timeIn) != 0)
        {
            string act = "time In changed from:" + oTour_Details_Sales_Deck_Check_In + "To:" + timeIn;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Sales_Deck_Check_Out, timeOut) != 0)
        {
            string act = "time Out changed from:" + oTour_Details_Sales_Deck_Check_Out + "To:" + timeOut;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Tour_Date, tourdate) != 0)
        {
            string act = "tour date changed from:" + oTour_Details_Tour_Date + "To:" + tourdate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Taxi_In_Price, taxin) != 0)
        {
            string act = "taxi in price changed from:" + oTour_Details_Taxi_In_Price + "To:" + taxin;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Taxi_In_Ref, taxirefin) != 0)
        {
            string act = "taxi reference in changed from:" + oTour_Details_Taxi_In_Ref + "To:" + taxirefin;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Taxi_Out_Price, taxiout) != 0)
        {
            string act = "taxi outprice changed from:" + oTour_Details_Taxi_Out_Price + "To:" + taxiout;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Taxi_Out_Ref, taxirefout) != 0)
        {
            string act = "taxi reference out changed from:" + oTour_Details_Taxi_Out_Ref + "To:" + taxirefout;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oComments, ProComments) != 0)
        {
            string act = "Profile Comments changed from:" + oComments + "To:" + ProComments;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oregTerms, regTerms) != 0)
        {
            string act = "Registration Terms changed from:" + oregTerms + "To:" + regTerms;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ocompanyname, companynameTextBox.Text.ToUpper()) != 0)
        {

            string log3 = "Company Name changed from:" + ocompanyname + " " + "to" + companynameTextBox.Text.ToUpper();
            int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

        }
        else { }
        if (String.Compare(ocogstin, gstinTextBox.Text.ToUpper()) != 0)
        {

            string log3 = "Company (GSTIN NO) changed from:" + ocogstin + " " + "to" + gstinTextBox.Text.ToUpper();
            int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

        }
        else { }
        if (String.Compare(ocompanypano, companypanoTextBox.Text.ToUpper()) != 0)
        {

            string log3 = "Company (PAN NO) changed from:" + ocompanypano + " " + "to" + companypanoTextBox.Text.ToUpper();
            int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

        }
        else { }

if (String.Compare(ocomment2, Procomment2) != 0)
        {

            string log3 = "comment2 changed from:" + ocomment2 + " " + "to" + Procomment2;
            int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

        }
        else { }

      

        //update profile
        int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
        int updateothers = Queries.UpdateCompnayGSTIN_PAN(gstinTextBox.Text.ToUpper(), companypanoTextBox.Text.ToUpper(), ContractdetailsIDTextBox.Text);
        int updateprofile = Queries.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, mgr, photoidentity, card, ProComments, "", "", regTerms,"",Procomment2);
        int primary = Queries.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry, npage, npdesg, primarylanguage);
        if (secondarytitle == "")
        {

        }
        else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Profile_Secondary where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, nsage, nsdesg, secondarylanguage);
            }
            else
            {
                int year = DateTime.Now.Year;
                string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                int secondary = Queries.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, profileidTextBox.Text, nsage, nsdesg, secondarylanguage);
                int updates = Queries.UpdateSecondaryValue(office, year);

                string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + profileidTextBox.Text + "Age:" + nsage + "," + "Designation:" + nsdesg + "," + "Languages spoken:" + secondarylanguage;
                int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

            }
            reader.Close();
            sqlcon.Close();

        }


        if (sp1title == "")
        {

        }
        else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile1 where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, nsp1age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile1id = Queries.GetSubProfile1ID(office);
                int subprofielid = Queries.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, ProfileID, nsp1age);
                int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


                string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + ProfileID;
                int insertlog5 = Queries.InsertContractLogs_India(ProfileID, "", log5, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();

        }


        if (sp2title == "")
        {

        }
        else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile2 where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp2 = Queries.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, nsp2age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile2id = Queries.GetSubProfile2ID(office);
                int subprofielid2 = Queries.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, ProfileID, nsp2age);
                int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

                string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + ProfileID;
                int insertlog6 = Queries.InsertContractLogs_India(ProfileID, "", log6, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
        }

        if (sp3title == "")
        {

        }
        else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile3 where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp3 = Queries.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, nsp3age);

            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile3id = Queries.GetSubProfile3ID(office);
                int subprofielid3 = Queries.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, ProfileID, nsp3age);
                int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

                string log12 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + ProfileID;
                int insertlog12 = Queries.InsertContractLogs_India(ProfileID, "", log12, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();

        }

        if (sp4title == "")
        {

        }
        else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile4 where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp4 = Queries.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, nsp4age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile4id = Queries.GetSubProfile4ID(office);
                int subprofielid4 = Queries.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, ProfileID, nsp4age);
                int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


                string log13 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + ProfileID;
                int insertlog13 = Queries.InsertContractLogs_India(ProfileID, "", log13, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
        }
        

        int address = Queries.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);
        int phone = Queries.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp4cc, sp4mobile, sp3altccc, sp3alternate, sp4altccc, sp4alternate,priOfficecc,priOfficeno,secOfficecc,secOfficeno);
        int email = Queries.UpdateEmail(profile, pemail, semail, sp1email, sp2email, "", "", "", "", sp3email, "",sp4email, "");
        int stay = Queries.UpdateProfileStay(profile, resort, roomno, arrivaldate, departuredate);
        int tour = Queries.UpdateTourDetails(profile, gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout,"",wkno);
         Response.Redirect(Request.RawUrl);
        //   string msg = "Details updated for Profile :" + " " + profile;
        //  Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);



    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
       // gvbind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //int installmentid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

        //Label lblID = (Label)row.FindControl("lblID");
        ////TextBox txtname=(TextBox)gr.cell[].control[];  
        //TextBox textName = (TextBox)row.Cells[0].Controls[0];
        //TextBox textadd = (TextBox)row.Cells[1].Controls[0];
        //TextBox textc = (TextBox)row.Cells[2].Controls[0];
        ////TextBox textadd = (TextBox)row.FindControl("txtadd");  
        ////TextBox textc = (TextBox)row.FindControl("txtc");  
        //GridView1.EditIndex = -1;
        //string stor_id = GridView1.DataKeys[e.RowIndex].Values["stor_id"].ToString();
        //TextBox   stor_name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("stor_name");
        //TextBox stor_address = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaddress");
        //TextBox city = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtcity");
        //TextBox state = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtstate");
        //TextBox zip = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtzip");
        //////SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
        ////SqlCommand cmd = new SqlCommand("update detail set name='" + textName.Text + "',address='" + textadd.Text + "',country='" + textc.Text + "'where id='" + userid + "'", conn);
        ////cmd.ExecuteNonQuery();
        ////conn.Close();
        ////gvbind();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
     //   GridView1.PageIndex = e.NewPageIndex;
        //gvbind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
       // GridView1.EditIndex = -1;
        //gvbind();
    }
    [WebMethod]
    public static string primaryl(string prid)
    {
       
        string JSON = "{\n \"names\":[";
      
        
        SqlDataReader reader = Queries.LoadPrimaryLang(prid);
      if(reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
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
        

        return JSON;
    }

    [WebMethod]
    public static string Secondarylang(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadSecLang(prid);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
            }

            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" +"" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
            return JSON;
    }


    [WebMethod]
    public static string PhotoIdentity(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadPhotoID(prid);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
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

        return JSON;
    }
    [WebMethod]
    public static string CardType(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadCardType(prid);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
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

        return JSON;
    }



    [WebMethod]
    public static string getMarketingProgram(string venue, string venueGroup, string profileID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select distinct Marketing_Program_Name from Marketing_Program join Venue_Group vg on vg.Venue_group_ID=Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID= vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='" + profileID + "' ) and vg.Venue_Group_Name='" + venueGroup + "' and v.Venue_Name= '" + venue + "'";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;
    }



    [WebMethod]
    public static string getAffiliate()
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select Affiliate_Type,currency from Finance_Details_Indian where ContractNo='"+contractno+"'";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;
    }

    [WebMethod]
    public static string LoadManagersOnVenue(string venue)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadManagersOnVenue1(venue);
        while (reader.Read())
        {
            string mn = reader.GetString(0);

            JSON += "[\"" + mn + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }

    [WebMethod]
    public static string LoadAgentsOnVenuegrp(string venue, string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetSalesRepOnlyVenue(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        return JSON;
    }



    [WebMethod]
    public static string LoadTOOnVenueNVGrp(string venue, string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenue1(venue);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;
        }
        else
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenueNGrp(venue);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;

        }
    }


    [WebMethod]
    public static string LoadCountryCode(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }
    [WebMethod]
    public static string LoadAllCountryCode(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string LoadStates(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select s.State_Name from state s join Country c on s.State_Country=c.Country_Name where c.Country_Name='" + country + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string stateName = reader.GetString(0);



                JSON += "[\"" + stateName + "\"],";


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
    public static string LoadSalesRepOnVenue(string venue, string country)
    {



        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.GetSalesRepOnVenue(venue, country);
        while (reader.Read())
        {
            string sr = reader.GetString(0);

            JSON += "[\"" + sr + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }


    [WebMethod]
    public static string loadRegTerms()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select RegTerms from profile p where Profile_ID='" + ProfileID + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string RegTerms = reader.GetString(0);



                JSON += "[\"" + RegTerms + "\"],";


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
    public static string LoadFinancemethod( string ContractDetails_ID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
      
        string query = "select distinct Finance_Name from FinanceMethod where Finance_Status = 'active' and office = '" + office + "' and Finance_Name not in(select Finance_Type from Finance_Details_Indian where ContractDetails_ID = '" + ContractDetails_ID + "') ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
       
        while (reader.Read())
        {
            string sr = reader.GetString(0);

            JSON += "[\"" + sr + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;

    }

    [WebMethod]
    public static string LoadFinancemethod1(string ContractDetails_ID,string finance_type)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        int q = Queries.CheckFinanceIndianDetailsExists1(ContractDetails_ID);//, finance_type);
        if (q == 1)
        {
            string query = "select Finance_Type,finance_method from Finance_Details_Indian where ContractDetails_ID='" + ContractDetails_ID + "' union  select distinct Finance_Name, 'Finance' from FinanceMethod where Finance_Status = 'active' and office = '" + office + "' and Finance_Name not in(select Finance_Type from Finance_Details_Indian where ContractDetails_ID = '" + ContractDetails_ID + "')  ";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string sr = reader.GetString(0);
                string sr1 = reader.GetString(1);
                JSON += "[\"" + sr + "\",\"" + sr1 + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            sqlcon.Close();

        }
        else
        {
            string query = "select Finance_Type from Finance_Details_Indian where ContractDetails_ID='" + ContractDetails_ID + "' union  select distinct Finance_Name from FinanceMethod where Finance_Status = 'active' and office = '" + office + "' and Finance_Name not in(select Finance_Type from Finance_Details_Indian where ContractDetails_ID = '" + ContractDetails_ID + "') order by Finance_Type desc";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string sr = reader.GetString(0);

                JSON += "[\"" + sr + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
            sqlcon.Close();
        }
       
        return JSON;

    }

    [WebMethod]
    public static string LoadManagementCharges(string club, string year, string curr)
    {
            
        String JSON = "{\n \"names\":[";

        SqlDataReader reader = Queries.LoadMCChartTimeshare(club, year, curr);
        while (reader.Read())
        {
            string sr1 = reader.GetString(0);
            string sr2 = reader.GetString(1);
            string sr3 = reader.GetString(2);
            string sr4 = reader.GetString(3);

            JSON += "[\"" + sr1 + "\",\"" + sr2 + "\",\"" + sr3 + "\",\"" + sr4 + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        
          
        

        return JSON;

    }

    [WebMethod]
    public static string LoadManagementChargesFract(string club, string year, string curr, string wk, string type)
    {

        String JSON = "{\n \"names\":[";

        SqlDataReader reader = Queries.LoadMCChartfractionalOnEdit(club, year, curr, wk, type);
        while (reader.Read())
        {
            string sr1 = reader.GetString(0);
            string sr2 = reader.GetString(1);
            string sr3 = reader.GetString(2);
            string sr4 = reader.GetString(3);

            JSON += "[\"" + sr1 + "\",\"" + sr2 + "\",\"" + sr3 + "\",\"" + sr4 + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }





        return JSON;

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        DataSet dsct = Queries.LoadContractNoDetails(contractnoTextBox.Text);
        SOR_AdditionalName(ContractdetailsIDTextBox.Text);
        DataSet dsfd = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);
        string Finance_Details = dsfd.Tables[0].Rows[0]["Finance_Method"].ToString();
        DataSet ds = Queries.LoadProfielDetailsFull(profileidTextBox.Text);
        string aftype = dsfd.Tables[0].Rows[0]["Affiliate_Type"].ToString();
        string mc = dsct.Tables[0].Rows[0]["MCWaiver"].ToString();

    }

    //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if(e.CommandName=="EditRow")
    //    {
    //        int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
    //        GridView2.EditIndex = rowindex;
    //        DataSet dsor = Queries.LoadContractNo_Othernames(ContractdetailsIDTextBox.Text);
    //        GridView2.DataSource = dsor;
    //        GridView2.DataBind();
    //    }
    //    else if(e.CommandName == "DeleteRow")
    //    {

    //    }
    //    else if (e.CommandName == "UpdateRow")
    //    {
    //        DataSet dsor = Queries.LoadContractNo_Othernames(ContractdetailsIDTextBox.Text);
    //        GridView2.DataSource = dsor;
    //        GridView2.DataBind();

    //    }
    //    else if (e.CommandName == "CancelUpdate")
    //    {
    //        GridView2.EditIndex = -1;
    //        DataSet dsor = Queries.LoadContractNo_Othernames(ContractdetailsIDTextBox.Text);
    //        GridView2.DataSource = dsor;
    //        GridView2.DataBind();
    //    }
    //}

    protected void Button8_Click(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
	string foreigncurrency;
        if(foreigncurrencyTextBox.Text==""|| foreigncurrencyTextBox.Text=="0"|| foreigncurrencyTextBox.Text==null|| foreigncurrencyTextBox.Text=="NaN")
        {
            foreigncurrency = "60";
        }
        else
        {
            foreigncurrency = foreigncurrencyTextBox.Text;
        }
        if (ReceiptamtTextBox.Text == "" || ReceiptamtTextBox.Text == "0" || ReceiptamtTextBox.Text == null || ReceiptamtTextBox.Text == "NaN")

        {
        }
        else
        { 

            DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            int cyr = Convert.ToInt32(CurYear) % 100;
            string cyr1 = cyr.ToString("yy");
            int tpyr = Convert.ToInt32(PreYear) % 100;
            int nxyr = Convert.ToInt32(NexYear) % 100;
            string FinYear = null;
            if (DateTime.Today.Month > 3)
            {
               
                FinYear = CurrentYear + "-" + nxyr;
            }
            else
            {
                
                FinYear = PreviousYear + "-" + cyr;

            }
            string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
            if(contracttypeTextBox.Text == "Fractional" || contracttypeTextBox.Text== "Trade-In-Fractionals")
            {
                if (currencyDropDownList.SelectedItem.Text == "INR")
                {
                    double indeposit = Convert.ToDouble(ReceiptamtTextBox.Text);
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text,"", "", "", "", "", receipttypeDropDownList.SelectedItem.Text );
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "" + "," + "Current rate:" + "0" + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + " " + "," + "contractdetailsID:" + ContractdetailsIDTextBox.Text+ "Type:"+ receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                else
                {
                    double currentrate = Convert.ToDouble(foreigncurrency);

                    double indeposit = Math.Round(Convert.ToDouble(ReceiptamtTextBox.Text) * currentrate);
                    double gst = 0;
                    double taxableamt = 0;
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "KARMA ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, "INR", currentrate.ToString(), DateTime.Now.ToShortDateString(), ReceiptamtTextBox.Text, receipttypeDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "KARMA ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "Rs." + "," + "Current rate:" + currentrate.ToString() + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + ReceiptamtTextBox.Text + "," + "contractdetailsID:" +ContractdetailsIDTextBox.Text+ "Type:"+ receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
            }
            else
            {
                if (currencyDropDownList.SelectedItem.Text == "INR")
                {
                    double indeposit = Convert.ToDouble(ReceiptamtTextBox.Text);
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text, "", "", "", "", "", receipttypeDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "" + "," + "Current rate:" + "0" + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + " " + "," + "contractdetailsID:" + ContractdetailsIDTextBox.Text+" Type:"+ receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                else
                {
                    double currentrate = Convert.ToDouble(foreigncurrency);

                    double indeposit = Math.Round(Convert.ToDouble(ReceiptamtTextBox.Text) * currentrate);
                    double gst = 0;
                    double taxableamt = 0;
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, "INR", currentrate.ToString(), DateTime.Now.ToShortDateString(), ReceiptamtTextBox.Text, receipttypeDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "Rs." + "," + "Current rate:" + currentrate.ToString() + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + ReceiptamtTextBox.Text + "," + "contractdetailsID:" + ContractdetailsIDTextBox.Text+"Type:"+receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }

            }
            ReceiptamtTextBox.Text = "";
            DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_ReceiptDetails(ContractdetailsIDTextBox.Text);
            GridView3.DataSource = dsreceipt;
            GridView3.DataBind();
        }
        
    }
    //protected void Linkbtn1Click(object sender, EventArgs e)
    //{

    //    GridViewRow gdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
    //    string profileID = gdrow.Cells[0].Text;
    //    string name1 = gdrow.Cells[1].Text;
    //    string r = gdrow.Cells[2].Text;
    //    string h = gdrow.Cells[3].Text;
    //}
    
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //LinkButton lnkView = (LinkButton)e.CommandSource;
        //string id = lnkView.CommandArgument;

        //DataSet ds = Queries.LoadContractNo_OthernamesOnID(id);

        //string type = ds.Tables[0].Rows[0]["type"].ToString();
        //if (type == "SOR Name")
        //{

        //    OnlySORLoadVisibility();
        //    DataSet ds1 = Queries.LoadContractNo_OthernamesOnID(id);

        //    soranameTextBox.Text = ds1.Tables[0].Rows[0]["Name"].ToString();
        //    soraaddressTextBox.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
        //    sorastateTextBox.Text = ds1.Tables[0].Rows[0]["State"].ToString();

        //    soracountryTextBox.Text = ds1.Tables[0].Rows[0]["Country"].ToString();
        //    sorapincodeTextBox.Text = ds1.Tables[0].Rows[0]["Postcode"].ToString();


        //}
        //else if (type == "Additional Name")
        //{


        //    OnlyAddltionalLoadVisibility();
        //    DataSet ds1 = Queries.LoadContractNo_OthernamesOnID(id);
        //    soranameTextBox.Text = ds1.Tables[0].Rows[0]["Name"].ToString();
        //}
        string  othernamesid = e.CommandArgument.ToString();
        if (e.CommandName == "Delete")
        {
            // Response.Write("test"+ othernamesid);

            // Bind_grid();
            int update = Queries.UpdateContractNo_OthernamesStatus(othernamesid);

               DataSet dsor = Queries.LoadContractNo_Othernames(ContractdetailsIDTextBox.Text);
                GridView2.DataSource = dsor;
                GridView2.DataBind();

 

           
        }
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         
        string reciptno = e.CommandArgument.ToString();
        if (e.CommandName == "Delete")
        {
        //   Response.Write("test" + reciptno);
          int update=Queries.UpdateReceiptTableStatus(reciptno);
           
            DataSet dsreceiptdetails = Queries.LoadContract_Indian_Deposit_ReceiptDetails(ContractdetailsIDTextBox.Text);
            GridView3.DataSource = dsreceiptdetails;
            GridView3.DataBind();
        }
    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }





    //protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //     string type =   GridView2.SelectedRow.Cells[2].Text;

    //    if (type == "SOR Name")
    //    {
    //        string id = GridView2.SelectedRow.Cells[8].Text;
    //        OnlySORLoadVisibility();
    //        DataSet ds1 = Queries.LoadContractNo_OthernamesOnID(id);

    //        soranameTextBox.Text = ds1.Tables[0].Rows[0]["Name"].ToString();
    //        soraaddressTextBox.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
    //        sorastateTextBox.Text = ds1.Tables[0].Rows[0]["State"].ToString();

    //        soracountryTextBox.Text = ds1.Tables[0].Rows[0]["Country"].ToString();
    //        sorapincodeTextBox.Text = ds1.Tables[0].Rows[0]["Postcode"].ToString();


    //    }
    //    else if (type == "Additional Name")
    //    {
    //        string id = GridView2.SelectedRow.Cells[8].Text;

    //        OnlyAddltionalLoadVisibility();
    //        DataSet ds1 = Queries.LoadContractNo_OthernamesOnID(id);
    //        soranameTextBox.Text = ds1.Tables[0].Rows[0]["Name"].ToString();
    //    }
    //}
}



