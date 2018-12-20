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
    //    static string pointsamt, pointstax, poinstcgst, pointssgst, mrgcode;
    //    string IGSTrate, Interestrate, mcwaiver;
    //    string Finance_No, documentationfee, IGST_Amount, No_Emi, emiamt;

    //    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager, ophid, ocard;
    //    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID, opage, oplang, opdesignation;
    //    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country, osage, oslang, osdesignation;
    //    static string oSub_Profile1_ID, oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country, osp1age;
    //    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country, osp2age;
    //    static string oSub_Profile3_ID, oSub_Profile3_Title, oSub_Profile3_Fname, oSub_Profile3_Lname, oSub_Profile3_DOB, oSub_Profile3_Nationality, oSub_Profile3_Country, osp3age;
    //    static string oSub_Profile4_ID, oSub_Profile4_Title, oSub_Profile4_Fname, oSub_Profile4_Lname, oSub_Profile4_DOB, oSub_Profile4_Nationality, oSub_Profile4_Country, osp4age;
    //    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    //    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate, oSubprofile3_CC, oSubprofile3_Mobile, oSubprofile3_Alt_CC, oSubprofile3_Alternate, oSubprofile4_CC, oSubprofile4_Mobile, oSubprofile4_Alt_CC, oSubprofile4_Alternate, opriOfficecc, opriOfficeno, osecOfficecc, osecOfficeno;
    //    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email, oSubprofile3_Email, oSubprofile4_Email;
    //    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    //    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;
    //    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate, priOfficeno, secOfficeno;
    //    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec, sp3mobilec, sp3alternatec, sp4mobilec, sp4alternatec;
    //    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc, sp3cc, sp3altccc, sp4cc, sp4altccc, priOfficecc, secOfficecc;
    //    static string pemail, semail, sp1email, sp2email, sp3email, sp4email;


    //    static string ocontractno, ocsalesrep, ocTomgr, obuttonup, odealdate, odealstatus, oContractUpdatedDate, omcwv, ofinancedetails, ocontract_Remark, opan, oadhar, omcfees, omcdate, omemberfee,
    //              omemebercgst, omembersgst, ocanxcontno, ocanxdate, oloanbuofficer, ocogstin, ocompanypano, odealweekno, odeckdetails, odeckremark, ocontractcomment, obu6, oupdowngrade;
    //    static string ocurrency, oaffiliate, ototalintax, odepamt, obalpayable, odepbal, ototalbalance, opaymethod, onoinstallment, oinstallment, ofinance,
    //  ofinancemethod, oFinanceno, oisgtrate, ointerestrate, ofindocfee, oigstamt, onoemi, oemiamt, ofinmonth, ooldLoanAgreement, oregcollectionterm, oregcollamt, obaladepamtdate, ooldloanamt;

    //    static string onewpoints, oconversionfee, oadminfee, ototpurchprice, ocgst, osgst, ototalpriceInTax, odeposit, obalance, obalancedue, oremarks,
    //ooldVolume, ooldadminfee, ooldTotalTax, ooldDeposit, ousdoldvolume, ousdoldadminfee, ousdoldtax, ousdolddeposit, oUSDConvertedVolume, oUSDConvertedAdminfee, oUSDConvertedTax, oUSDConverteddeposit;

    //    static string ofctAdmission_fees, ofctadministration_fees, ofctCgst, ofctSgst, ofctTotal_Purchase_Price, ofctTotal_Price_Including_Tax, ofctDeposit, ofctBalance, ofctBalance_Due_Dates, ofctRemarks,
    //  otradeinvalue, ototalvalue, oFoldVolume, oFoldadminfee, oFoldTotalTax, oFoldDeposit, oFusdoldvolume, oFusdoldadminfee, oFusdoldtax, oFusdolddeposit, oUSDConvertedFVolume, oUSDConvertedFAdminfee, oUSDConvertedFTax, oUSDConvertedFdeposit;

    //    static string oReceipt_Date, oAmount, otaxable_value, ocgstrate, ocgstamt, osgstrate, osgstamt, ototalamt, oPayment_Mode, oactual_currency, oconverted_currency, oConverted_rate, oExchangedValue_date, oActual_Amt;
    //    static string opts_club, opts_newpts, opts_entitlement, opts_totalpts, opts_firstyr, opts_Tenure, opts_lastyr, opts_nopersons;
    //    static string otip_Trade_In_Details_club_resort, otip_Trade_In_Details_No_rights, otip_Trade_In_Details_ContNo_RCINo, otip_Trade_In_Details_Points_value, otip_New_Club, otip_New_Club_Points_Rights, otip_New_MemebrshipType, otip_New_TotalPointsRights, otip_New_First_year_occupancy, otip_New_Tenure, otip_New_Last_year_occupancy, otip_nopersons;
    //    static string otiw_Trade_In_Weeks_resort, otiw_Trade_In_Weeks_Apt, otiw_Trade_In_Weeks_Season, otiw_Trade_In_Weeks_NoWks, otiw_Trade_In_Weeks_ContNo_RCINo, otiw_Trade_In_Weeks_Points_value, otiw_NewPointsW_Club, otiw_NewPointsW_Club_Points_Rights, otiw_NewPointsW_MemebrshipType, otiw_NewPointsW_Total_Points_rights, otiw_NewPointsW_First_year_occupancy, otiw_NewPointsW_Tenure, otiw_NewPointsW_Last_year_occupancy, otiw_nopersons;
    //    static string tifpresort, tifpnopoints, tifpcontrcino, tifpptsvalue;
    //    static string otiresort, otifresidence_no, otifresidence_type, otiffractional_interest, otifentitlement, otiffirstyear_Occupancy, otiftenure, otiflastyear_Occupancy, otifleaseback, otifMc_Charges, otifOldcontracttype, otifRESORT, otifAPT_TYPE, otifSEASON, otifNO_WEEKS, otifNO_POINTS, otifPOINTS_VALUE, otifoldContract_No, otifContractNo, otifProfileID, otifSales_Rep, otifTO_Manager, otifButtonUp_Officer, otifDealRegistered_Date, otifDealStatus, otifContract_CreatedDate, otifContract_UpdatedDate, otifContractType, otifMCWaiver, otifFinance_Details, otifContract_Remark, otifPan_Card, otifAdhar_Card, otifMC_Charges, otifFirst_MC_Payable_Date, otifMemberFee, otifMemberCGST, otifMembersGST;
    //static string ProfileID;
    //static string regTerms, oregTerms, ocomment2, ocompanyname, contractno;
    //static int wkno;

        //old global variables

    // static string ocsalesrep, ocTomgr, obuttonup, odealdate, odealstatus,oadhar,opan,oloanbuofficer,ocanxcontno,ocanxdate;
    // static string opts_club, opts_newpts, opts_entitlement, opts_totalpts, opts_firstyr, opts_Tenure, opts_lastyr, opts_nopersons;
    //static string otip_Trade_In_Details_club_resort, otip_Trade_In_Details_No_rights, otip_Trade_In_Details_ContNo_RCINo, otip_Trade_In_Details_Points_value, otip_New_Club, otip_New_Club_Points_Rights, otip_New_MemebrshipType, otip_New_TotalPointsRights, otip_New_First_year_occupancy, otip_New_Tenure, otip_New_Last_year_occupancy,otip_nopersons;
    //static string otiw_Trade_In_Weeks_resort, otiw_Trade_In_Weeks_Apt, otiw_Trade_In_Weeks_Season, otiw_Trade_In_Weeks_NoWks, otiw_Trade_In_Weeks_ContNo_RCINo, otiw_Trade_In_Weeks_Points_value, otiw_NewPointsW_Club, otiw_NewPointsW_Club_Points_Rights, otiw_NewPointsW_MemebrshipType, otiw_NewPointsW_Total_Points_rights, otiw_NewPointsW_First_year_occupancy, otiw_NewPointsW_Tenure, otiw_NewPointsW_Last_year_occupancy, otiw_nopersons;
    //  static string omcwv, omcfees, omcdate, omemberfee, omemebercgst, omembersgst,
    //  static string ocurrency, oaffiliate, ototalintax, odepamt, obalpayable, odepbal, opaymethod, onoinstallment, oinstallment, ototalbalance, ofinance, ofinancemethod, oFinanceno, ofinmonth, onoemi, oemiamt, ofindocfee, oisgtrate, oigstamt, ointerestrate, oregcollectionterm, oregcollamt, obaladepamtdate, ooldLoanAgreement;
    // static string onewpoints,oconversionfee,oadminfee,ototpurchprice,ocgst, osgst, ototalpriceInTax,odeposit, obalance,obalancedue, oremarks;
    //static string tifpresort, tifpnopoints, tifpcontrcino, tifpptsvalue;
    //static string otifresort, otifresidence_no, otifresidence_type, otiffractional_interest, otifentitlement, otiffirstyear_Occupancy, otiftenure, otiflastyear_Occupancy, otifleaseback, otifMc_Charges, otifOldcontracttype, otifRESORT, otifAPT_TYPE, otifSEASON, otifNO_WEEKS, otifNO_POINTS, otifPOINTS_VALUE, otifoldContract_No, otifContractNo, otifProfileID, otifSales_Rep, otifTO_Manager, otifButtonUp_Officer, otifDealRegistered_Date, otifDealStatus, otifContract_CreatedDate, otifContract_UpdatedDate, otifContractType, otifMCWaiver, otifFinance_Details, otifContract_Remark, otifPan_Card, otifAdhar_Card, otifMC_Charges, otifFirst_MC_Payable_Date, otifMemberFee, otifMemberCGST, otifMembersGST;
    //  static string ofctAdmission_fees, ofctadministration_fees, ofctCgst, ofctSgst, ofctTotal_Purchase_Price, ofctTotal_Price_Including_Tax, ofctDeposit, ofctBalance, ofctBalance_Due_Dates, ofctRemarks, ooldloanamt;
    //  static string contractno;
    //  static string ocompanyname, ocogstin, ocompanypano;

    //  static string ocontractno, otradeinvalue, ototalvalue;
    //  static string oReceipt_Date, oAmount, otaxable_value, ocgstrate, ocgstamt, osgstrate, osgstamt, ototalamt, oPayment_Mode;
    // static string ocontractcomment,obu6,oupdowngrade;





    public void financebreakup(string noemi, string financeamt, string emiamt, string contractid, string ctype, string contno, string installmentcnt)
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
                    int insert = Queries.InsertFinance_Breakup(contno, contractid, newba, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
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
                        int insert = Queries.InsertFinance_Breakup(contno, contractid, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);

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
                    int insert = Queries.InsertFinance_Breakup(contno, contractid, newba, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
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
                        int insert = Queries.InsertFinance_Breakup(contno, contractid, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);

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
    public void CheckBreakup(string financetype, string ofinancebal, string noemi, string onoemi, string financeamt, string emiamt, string contractid, string ctype, string contno, string instno)
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
                    financebreakup(noemi, financeamt, emiamt, contractid, ctype, contno, instno);

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
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
            }
            //check if id exists in othernames
            int othersid = Queries.ContractNo_OthernamesExistsA(ContractDetails_ID);
            if (othersid == 1)
            {
                if (ContractType == "Fractional")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
            }


            int othersid3 = Queries.ContractNo_OthernamesExistsS(ContractDetails_ID);
            if (othersid3 == 1)
            {
                if (ContractType == "Fractional")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
            int othersid2 = Queries.ContractNo_OthernamesExistsB(ContractDetails_ID);
            if (othersid2 == 1)
            {
                if (ContractType == "Fractional")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
        }
        else if (mc == "No" || mc == "")
        {
            int othersid1 = Queries.ContractNo_OthernamesExistsNone(ContractDetails_ID);
            if (othersid1 == 0)
            {
                if (ContractType == "Fractional")
                {
                    PrintPdfDropDownList.Items.Clear();

                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
                        PrintPdfDropDownList.Items.Clear();
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
            }
            //check if id exists in othernames
            int othersid = Queries.ContractNo_OthernamesExistsA(ContractDetails_ID);
            if (othersid == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
                        string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                        string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
            }


            int othersid3 = Queries.ContractNo_OthernamesExistsS(ContractDetails_ID);
            if (othersid3 == 1)
            {
                if (ContractType == "Fractional")
                {
                    PrintPdfDropDownList.Items.Clear();

                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
            }
            int othersid2 = Queries.ContractNo_OthernamesExistsB(ContractDetails_ID);
            if (othersid2 == 1)
            {
                if (ContractType == "Fractional")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    PrintPdfDropDownList.Items.Clear();
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);
                    PrintPdfDropDownList.Items.Clear();
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);
                    if (dsp.Tables[0].Rows.Count == 0) { }
                    else
                    {
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
                    //GridView2.Visible = true;
                    //DataSet dsor = Queries.LoadContractNo_Othernames(contractdetails_ID);
                    //GridView2.DataSource = dsor;
                    //GridView2.DataBind();

                }
                else
                {
                    //GridView2.Visible = false;
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
                    //GridView2.Visible = true;
                    //DataSet dsor = Queries.LoadContractNo_Othernames(contractdetails_ID);
                    //GridView2.DataSource = dsor;
                    //GridView2.DataBind();

                }
                else
                {
                    //GridView2.Visible = false;
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
        lblconversionfee.Visible = true;
        conversionfeeTextBox.Visible = true;
        lblnewpoints.Visible = true;
        newpointsTextBox.Visible = true;
    }

    public void visibilitytradeinweekstrue()
    {

        lbltipnopoints.Visible = false;
        tipnopointsTextBox.Visible = false;

        lblAdministrationFees.Visible = false;
        AdministrationFeesTextBox.Visible = false;
        lblconversionfee.Visible = true;
        conversionfeeTextBox.Visible = true;
        lblnewpoints.Visible = true;
        newpointsTextBox.Visible = true;
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

            htmlstr += " <input id=" + ca + "" + id + " type='checkbox' class='hello' name='aamt' onClick=" + addvalue + "() value='" + amt + "'>" + name + "";


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

        string sContractdetailsID = (string)Session["ContractdetailsID"];

        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }


        if (!IsPostBack)
        {

            Session["oProfile_Venue_Country"] = ""; Session["oProfile_Venue"] = ""; Session["oProfile_Group_Venue"] = ""; Session["oProfile_Marketing_Program"] = "";
            Session["oProfile_Agent"] = ""; Session["oProfile_Agent_Code"] = ""; Session["oProfile_Member_Type1"] = ""; Session["oProfile_Member_Number1"] = "";
            Session["oProfile_Member_Type2"] = ""; Session["oProfile_Member_Number2"] = ""; Session["oProfile_Employment_status"] = ""; Session["oProfile_Marital_status"] = "";
            Session["oProfile_NOY_Living_as_couple"] = ""; Session["oOffice"] = ""; Session["oComments"] = ""; Session["oManager"] = "";
            Session["ophid"] = ""; Session["ocard"] = "";

            Session["oProfile_Primary_Title"] = ""; Session["oProfile_Primary_Fname"] = ""; Session["oProfile_Primary_Lname"] = "";
            Session["oProfile_Primary_DOB"] = ""; Session["oProfile_Primary_Nationality"] = ""; Session["oProfile_Primary_Country"] = "";
            Session["opage"] = ""; Session["opdesignation"] = ""; Session["oplang"] = "";

            Session["oProfile_Secondary_Title"] = ""; Session["oProfile_Secondary_Fname"] = ""; Session["oProfile_Secondary_Lname"] = "";
            Session["oProfile_Secondary_DOB"] = ""; Session["oProfile_Secondary_Nationality"] = ""; Session["oProfile_Secondary_Country"] = "";
            Session["osage"] = ""; Session["osdesignation"] = ""; Session["oslang"] = "";

            Session["oSub_Profile1_Title"] = ""; Session["oSub_Profile1_Fname"] = ""; Session["oSub_Profile1_Lname"] = "";
            Session["oSub_Profile1_DOB"] = ""; Session["  oSub_Profile1_Nationality"] = ""; Session["oSub_Profile1_Country"] = "";
            Session["osp1age"] = "";

            Session["oSub_Profile2_Title"] = ""; Session["oSub_Profile2_Fname"] = ""; Session["oSub_Profile2_Lname"] = "";
            Session["oSub_Profile2_DOB"] = ""; Session["  oSub_Profile2_Nationality"] = ""; Session["oSub_Profile2_Country"] = "";
            Session["osp2age"] = "";

            Session["oSub_Profile3_Title"] = ""; Session["oSub_Profile3_Fname"] = ""; Session["oSub_Profile3_Lname"] = "";
            Session["oSub_Profile3_DOB"] = ""; Session["  oSub_Profile3_Nationality"] = ""; Session["oSub_Profile3_Country"] = "";
            Session["osp3age"] = "";

            Session["oSub_Profile4_Title"] = ""; Session["oSub_Profile4_Fname"] = ""; Session["oSub_Profile4_Lname"] = "";
            Session["oSub_Profile4_DOB"] = ""; Session["  oSub_Profile4_Nationality"] = ""; Session["oSub_Profile4_Country"] = "";
            Session["osp4age"] = "";

            Session["oProfile_Address_Line1"] = ""; Session["oProfile_Address_Line2"] = ""; Session["oProfile_Address_State"] = "";
            Session["oProfile_Address_city"] = ""; Session["oProfile_Address_Postcode"] = ""; Session["oProfile_Address_Created_Date"] = "";
            Session["oProfile_Address_Expiry_Date"] = ""; Session["oProfile_Address_Country"] = "";

            Session["oProfile_CorAddress_Line1"] = ""; Session["oProfile_CorAddress_Line2"] = ""; Session["oProfile_CorAddress_State"] = "";
            Session["oProfile_CorAddress_city"] = ""; Session["oProfile_CorAddress_Postcode"] = ""; Session["oProfile_CorAddress_Created_Date"] = "";
            Session["oProfile_Address_Expiry_Date"] = ""; Session["oProfile_CorAddress_Country"] = "";


            Session["oPrimary_CC"] = ""; Session["oPrimary_Mobile"] = ""; Session["oPrimary_Alt_CC"] = "";
            Session["oPrimary_Alternate"] = ""; Session["opriOfficecc"] = ""; Session["opriOfficeno"] = "";

            Session["osecOfficecc"] = ""; Session["osecofficeno"] = ""; Session["oSecondary_CC"] = "";
            Session["oSecondary_Mobile"] = ""; Session["oSecondary_Alt_CC"] = ""; Session["oSecondary_Alternate"] = "";

            Session["oSubprofile1_CC"] = ""; Session["oSubprofile1_Mobile"] = ""; Session["oSubprofile1_Alt_CC"] = ""; Session["oSubprofile1_Alternate"] = "";
            Session["oSubprofile2_CC"] = ""; Session["oSubprofile2_Mobile"] = ""; Session["oSubprofile2_Alt_CC"] = ""; Session["oSubprofile2_Alternate"] = "";

            Session["oSubprofile3_CC"] = ""; Session["oSubprofile3_Mobile"] = ""; Session["oSubprofile3_Alt_CC"] = ""; Session["oSubprofile3_Alternate"] = "";
            Session["oSubprofile4_CC"] = ""; Session["oSubprofile4_Mobile"] = ""; Session["oSubprofile4_Alt_CC"] = ""; Session["oSubprofile4_Alternate"] = "";

            Session["oPrimary_Email"] = ""; Session["oSecondary_Email"] = ""; Session["oSubprofile1_Email"] = "";
            Session["oSubprofile2_Email"] = ""; Session["oSubprofile3_Email"] = ""; Session["oSubprofile4_Email"] = "";

            Session["oPrimary_Email2"] = ""; Session["oSecondary_Email2"] = ""; Session["oSubprofile1_Email2"] = "";
            Session["oSubprofile2_Email2"] = ""; Session["oSubprofile3_Email2"] = ""; Session["oSubprofile4_Email2"] = "";


            Session["oProfile_Stay_ID"] = ""; Session["oProfile_Stay_Resort_Name"] = ""; Session["oProfile_Stay_Resort_Room_Number"] = "";
            Session["oProfile_Stay_Arrival_Date"] = ""; Session["oProfile_Stay_Departure_Date"] = "";

            Session["oTour_Details_Guest_Status"] = ""; Session["oTour_Details_Guest_Sales_Rep"] = ""; Session["oTour_Details_Tour_Date"] = "";
            Session["tourweekno"] = ""; Session["oTour_Details_Sales_Deck_Check_In"] = ""; Session["oTour_Details_Sales_Deck_Check_Out"] = "";
            Session["oTour_Details_Taxi_In_Price"] = ""; Session["oTour_Details_Taxi_In_Ref"] = ""; Session["oTour_Details_Taxi_Out_Price"] = "";
            Session["oTour_Details_Taxi_Out_Ref"] = ""; Session["oComments"] = ""; Session["oregTerms"] = ""; Session["ocomment2"] = "";

            Session["ProfileID"] = ""; Session["ophid"] = ""; Session["ocard"] = ""; Session["oTour_Details_Tour_Date"] = "";


            //load blank values of session
            Session["contractdetails_id"] = "";
            Session["contractno"] = ""; Session["ocsalesrep"] = ""; Session["ocTomgr"] = ""; Session["obuttonup"] = ""; Session["odealdate"] = ""; Session["odealstatus"] = "";
            Session["oContractUpdatedDate"] = ""; Session["omcwv"] = ""; Session["ofinancedetails"] = ""; Session["ocontract_Remark"] = ""; Session["opan"] = ""; Session["oadhar"] = "";
            Session["omcfees"] = ""; Session["omcdate"] = ""; Session["omemberfee"] = ""; Session["omemebercgst"] = ""; Session["omembersgst"] = "";
            Session["ocanxcontno"] = ""; Session["ocanxdate"] = ""; Session["oloanbuofficer"] = ""; Session["ocogstin"] = ""; Session["ocompanypano"] = "";
            Session["odealweekno"] = ""; Session["odeckdetails"] = ""; Session["odeckremark"] = ""; Session["ocontractcomment"] = ""; Session["obu6"] = ""; Session["oupdowngrade"] = "";

            Session["ocurrency"] = ""; Session["oaffiliate"] = ""; Session["ototalintax"] = ""; Session["odepamt"] = ""; Session["obalpayable"] = ""; Session["odepbal"] = "";
            Session["ototalbalance"] = ""; Session["opaymethod"] = ""; Session["onoinstallment"] = ""; Session["oinstallment"] = ""; Session["ofinance"] = ""; Session["ofinancemethod"] = "";
            Session["oFinanceno"] = ""; Session["oisgtrate"] = ""; Session["ointerestrate"] = ""; Session["ofindocfee"] = ""; Session["oigstamt"] = ""; Session["onoemi"] = "";
            Session["oemiamt"] = ""; Session["ofinmonth"] = ""; Session["ooldLoanAgreement"] = ""; Session["oregcollectionterm"] = ""; Session["oregcollamt"] = ""; Session["obaladepamtdate"] = ""; Session["ooldloanamt"] = "";


            Session["onewpoints"] = ""; Session["oconversionfee"] = ""; Session["oadminfee"] = ""; Session["ototpurchprice"] = ""; Session["ocgst"] = ""; Session["osgst"] = ""; Session["ototalpriceInTax"] = ""; Session["odeposit"] = ""; Session["obalance"] = ""; Session["obalancedue"] = ""; Session["oremarks"] = "";
            Session["ooldVolume"] = ""; Session["ooldadminfee"] = ""; Session["ooldTotalTax"] = ""; Session["ooldDeposit"] = ""; Session["ousdoldvolume"] = ""; Session["ousdoldadminfee"] = ""; Session["ousdoldtax"] = ""; Session["ousdolddeposit"] = "";
            Session["oUSDConvertedVolume"] = ""; Session["oUSDConvertedAdminfee"] = ""; Session["oUSDConvertedTax"] = ""; Session["oUSDConverteddeposit"] = "";

            Session["ofctAdmission_fees"] = ""; Session["ofctadministration_fees"] = ""; Session["ofctCgst"] = ""; Session["ofctSgst"] = ""; Session["ofctTotal_Purchase_Price"] = ""; Session["ofctTotal_Price_Including_Tax"] = "";
            Session["ofctDeposit"] = ""; Session["ofctBalance"] = ""; Session["ofctBalance_Due_Dates"] = ""; Session["ofctRemarks"] = ""; Session["otradeinvalue"] = ""; Session["ototalvalue"] = "";
            Session["oFoldVolume"] = ""; Session["oFoldadminfee"] = ""; Session["oFoldTotalTax"] = ""; Session["oFoldDeposit"] = ""; Session["oFusdoldvolume"] = ""; Session["oFusdoldadminfee"] = ""; Session["oFusdoldtax"] = ""; Session["oFusdolddeposit"] = "";
            Session["oUSDConvertedFVolume"] = ""; Session["oUSDConvertedFAdminfee"] = ""; Session["oUSDConvertedFTax"] = ""; Session["oUSDConvertedFdeposit"] = "";

            Session["oReceipt_Date"] = ""; Session["oReceipt_No"] = ""; Session["oAmount"] = ""; Session["otaxable_value"] = ""; Session["ocgstrate"] = ""; Session["ocgstamt"] = ""; Session["osgstrate"] = ""; Session["osgstamt"] = ""; Session["ototalamt"] = ""; Session["oPayment_Mode"] = "";
            Session["oactual_currency"] = ""; Session["oconverted_currency"] = ""; Session["oConverted_rate"] = ""; Session["oExchangedValue_date"] = ""; Session["oActual_Amt"] = "";
            Session["opts_club"] = ""; Session["opts_newpts"] = ""; Session["opts_entitlement"] = ""; Session["opts_totalpts"] = ""; Session["opts_firstyr"] = ""; Session["opts_Tenure"] = ""; Session["opts_lastyr"] = ""; Session["opts_nopersons"] = "";



            Session["otip_Trade_In_Details_club_resort"] = ""; Session["otip_Trade_In_Details_No_rights"] = ""; Session["otip_Trade_In_Details_ContNo_RCINo"] = ""; Session["otip_Trade_In_Details_Points_value"] = ""; Session["Actualpoints_value"] = ""; Session["otip_New_Club"] = ""; Session["otip_New_Club_Points_Rights"] = ""; Session["otip_New_MemebrshipType"] = "";
            Session["otip_New_TotalPointsRights"] = ""; Session["otip_New_First_year_occupancy"] = ""; Session["otip_New_Tenure"] = ""; Session["otip_New_Last_year_occupancy"] = ""; Session["otip_nopersons"] = "";



            Session["otiw_Trade_In_Weeks_resort"] = ""; Session["otiw_Trade_In_Weeks_Apt"] = ""; Session["otiw_Trade_In_Weeks_Season"] = ""; Session["otiw_Trade_In_Weeks_NoWks"] = ""; Session["otiw_Trade_In_Weeks_ContNo_RCINo"] = ""; Session["otiw_Trade_In_Weeks_Points_value"] = ""; Session["otiw_NewPointsW_Club"] = "";
            Session["otiw_NewPointsW_Club_Points_Rights"] = ""; Session["otiw_NewPointsW_MemebrshipType"] = ""; Session["otiw_NewPointsW_Total_Points_rights"] = ""; Session["otiw_NewPointsW_First_year_occupancy"] = ""; Session["otiw_NewPointsW_Tenure"] = ""; Session["otiw_NewPointsW_Last_year_occupancy"] = ""; Session["otiw_nopersons"] = "";


            Session["otiresort"] = ""; Session["otifresidence_no"] = ""; Session["otifresidence_type"] = ""; Session["otiffractional_interest"] = ""; Session["otifentitlement"] = ""; Session["otiffirstyear_Occupancy"] = ""; Session["otiftenure"] = ""; Session["otiflastyear_Occupancy"] = ""; Session["otifleaseback"] = ""; Session["otifMc_Charges"] = "";
            Session["otifOldcontracttype"] = ""; Session["otifRESORT"] = ""; Session["otifAPT_TYPE"] = ""; Session["otifSEASON"] = ""; Session["otifNO_WEEKS"] = ""; Session["otifNO_POINTS"] = ""; Session["otifPOINTS_VALUE"] = ""; Session["otifoldContract_No"] = "";


            Session["Installment_ID"] = ""; Session["iProfileID"] = ""; Session["ContractNo"] = ""; Session["Installment_no"] = ""; Session["Installment_Amount"] = ""; Session["Installment_Date"] = ""; Session["Installment_Invoice_No"] = "";

            Session["program_source"] = ""; Session["Referred_By"] = ""; Session["comment1"] = ""; Session["updated_date"] = ""; Session["updatedby"] = "";



            /*  contractno = Convert.ToString(Request.QueryString["ContractNo"]);
              contractnoTextBox.Text = contractno;       
              ProfileID = Queries.GetProfileIDOnContractNo(contractno);
              DataSet dsct = Queries.LoadContractNoDetails(contractno);
              ContractdetailsIDTextBox.Text= dsct.Tables[0].Rows[0]["ContractDetails_ID"].ToString();
              DataSet dsfd = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);//(contractno); */

            ContractdetailsIDTextBox.Text = sContractdetailsID;
            DataSet dsct = Queries.LoadContractNoDetailsOnContractDetails_ID(sContractdetailsID);

            Session["contractno"] = dsct.Tables[0].Rows[0]["Contractno"].ToString();
            contractnoTextBox.Text = dsct.Tables[0].Rows[0]["Contractno"].ToString();
          Session["ProfileID"] = Queries.GetProfileIDOnContractNo(Session["contractno"].ToString());
            DataSet dsfd = Queries.LoadFinanceContractDetails(sContractdetailsID);


          
            DataSet ds = Queries.LoadProfielDetailsFull(Session["ProfileID"].ToString());
            profileidTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();
            indateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"].ToString();
            createdbyTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString();
            office = ds.Tables[0].Rows[0]["Office"].ToString();
            officeTextBox.Text = ds.Tables[0].Rows[0]["Office"].ToString();
            
            commentsTextBox.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            comment2.Text = ds.Tables[0].Rows[0]["comment2"].ToString();
            companynameTextBox.Text = ds.Tables[0].Rows[0]["Company_Name"].ToString().ToUpper();
            gstinTextBox.Text = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
            companypanoTextBox.Text = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
    

            //load sor names etc
            SORAddltionalLoadVisibility();
            int existssor = Queries.ContractIDINSOR_Additional(ContractdetailsIDTextBox.Text);
            if (existssor == 1)
            {
              


            }
            else
            {
                //GridView2.Visible = false;
            }


            //---  DataSet dsreceiptdetails = Queries.LoadContract_Indian_Deposit_ReceiptDetails(ContractdetailsIDTextBox.Text);
            //---   GridView3.DataSource = dsreceiptdetails;
            //---  GridView3.DataBind();


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
            DataSet ds1 = Queries.LoadProfileVenueCountry(Session["ProfileID"].ToString());
            VenueCountryDropDownList.DataSource = ds1;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            //loading venue on load
            DataSet ds2 = Queries.LoadProfileVenue(Session["ProfileID"].ToString(), VenueCountryDropDownList.SelectedItem.Text);
            VenueDropDownList.DataSource = ds2;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            // loading venuegroup on load
            DataSet ds3 = Queries.LoadProfileVenueGroup(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
            GroupVenueDropDownList.DataSource = ds3;
            GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            GroupVenueDropDownList.AppendDataBoundItems = true;
            GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            GroupVenueDropDownList.DataBind();

            ////loading marketing program on load
            //DataSet ds4 = Queries.LoadProfileMktg(ProfileID, VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
            //MarketingProgramDropDownList.DataSource = ds4;
            //MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingProgramDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingProgramDropDownList.AppendDataBoundItems = true;
            //MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingProgramDropDownList.DataBind();

            if (GroupVenueDropDownList.SelectedItem.Text == "Coldline" || GroupVenueDropDownList.SelectedItem.Text == "COLDLINE")
            {

                DataSet ds4 = Queries.LoadProfileMktg(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
                MarketingProgramDropDownList.DataSource = ds4;
                MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
                MarketingProgramDropDownList.DataValueField = "Marketing_Program_Name";
                MarketingProgramDropDownList.AppendDataBoundItems = true;
                MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
                MarketingProgramDropDownList.DataBind();
            }
            else
            {
                if (ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString() == "")
                {
                    DataSet ds4445 = Queries.LoadMarktOnCode(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
                    MarketingProgramDropDownList.DataSource = ds4445;
                    MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
                    MarketingProgramDropDownList.DataValueField = "Marketing_Program_abbrv";
                    MarketingProgramDropDownList.AppendDataBoundItems = true;
                    MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
                    MarketingProgramDropDownList.DataBind();

                }
                else
                {
                    DataSet ds444 = Queries.LoadMarktOnCode(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
                    DataSet ds4 = Queries.LoadProfileMktg1(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
                    MarketingProgramDropDownList.DataSource = ds4;
                    MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
                    MarketingProgramDropDownList.DataValueField = "Marketing_Program_abbrv";
                    MarketingProgramDropDownList.AppendDataBoundItems = true;
                    MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds444.Tables[0].Rows[0]["Marketing_Program_Name"].ToString(), ""));
                    MarketingProgramDropDownList.DataBind();
                }

            }
            // loading agents on load as per venue group
            if (GroupVenueDropDownList.SelectedItem.Text == "Coldline")
            {
                //     DataSet ds5 = Queries.LoadProfileAgent(ProfileID);
                DataSet ds5 = Queries.LoadProfileAgent1(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
                AgentDropDownList.DataSource = ds5;
                AgentDropDownList.DataTextField = "agentname";
                AgentDropDownList.DataValueField = "agentname";
                AgentDropDownList.AppendDataBoundItems = true;
                AgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                AgentDropDownList.DataBind();


            }
            else
            {
                DataSet ds5 = Queries.LoadProfileAgentNotColdline(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
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
                DataSet ds5aa = Queries.LoadTOOPCOnVenue11(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
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
                DataSet ds5aa = Queries.LoadTOOPCOnVenue12(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
                TONameDropDownList.DataSource = ds5aa;
                TONameDropDownList.DataTextField = "TO_Manager_Name";
                TONameDropDownList.DataValueField = "TO_Manager_Name";
                TONameDropDownList.AppendDataBoundItems = true;
                TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
                TONameDropDownList.DataBind();



            }


            DataSet dsmg = Queries.LoadProfileManager(Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
            ManagerDropDownList.DataSource = dsmg;
            ManagerDropDownList.DataTextField = "Manager_Name";
            ManagerDropDownList.DataValueField = "Manager_Name";
            ManagerDropDownList.AppendDataBoundItems = true;
            ManagerDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["manager"].ToString(), ""));
            ManagerDropDownList.DataBind();



            if (MarketingProgramDropDownList.SelectedItem.Text == "T/S MEMBER" || MarketingProgramDropDownList.SelectedItem.Text == "T/S MEMBER RCI" || MarketingProgramDropDownList.SelectedItem.Text == "FRACTIONAL OWNER" || MarketingProgramDropDownList.SelectedItem.Text == "FRACTIONAL OWNER RCI" || MarketingProgramDropDownList.SelectedItem.Text == "Owner" || MarketingProgramDropDownList.SelectedItem.Text == "OWNER" || MarketingProgramDropDownList.SelectedItem.Text == "Member" || MarketingProgramDropDownList.SelectedItem.Text == "MEMBER")
            {
                // loadprofilememebertype
                DataSet dsmgs = Queries.LoadProfileMemberType(Session["ProfileID"].ToString());
                MemType1DropDownList.DataSource = dsmgs;
                MemType1DropDownList.DataTextField = "Member_Type_Name";
                MemType1DropDownList.DataValueField = "Member_Type_Name";
                MemType1DropDownList.AppendDataBoundItems = true;
                MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
                MemType1DropDownList.DataBind();


                Memno1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();

                // load profiletype
                DataSet dsmgss = Queries.LoadProfileType(Session["ProfileID"].ToString());
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
                DataSet dsmgs = Queries.LoadProfileMemberType(Session["ProfileID"].ToString());
                MemType1DropDownList.DataSource = dsmgs;
                MemType1DropDownList.DataTextField = "Member_Type_Name";
                MemType1DropDownList.DataValueField = "Member_Type_Name";
                MemType1DropDownList.AppendDataBoundItems = true;
                MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
                MemType1DropDownList.DataBind();
                // load profiletype
                DataSet dsmgss = Queries.LoadProfileType(Session["ProfileID"].ToString());
                TypeDropDownList.DataSource = dsmgss;
                TypeDropDownList.DataTextField = "Type_Name";
                TypeDropDownList.DataValueField = "Type_Name";
                TypeDropDownList.AppendDataBoundItems = true;
                TypeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString(), ""));
                TypeDropDownList.DataBind();


            }

            // new code added by gaurav //
            DataSet dsLead = Queries.onLoadLeadOffice(Session["ProfileID"].ToString());
            LeadOfficeDropDownList.DataSource = dsLead;
            LeadOfficeDropDownList.DataTextField = "Office";
            LeadOfficeDropDownList.DataValueField = "Office";
            LeadOfficeDropDownList.AppendDataBoundItems = true;

            LeadOfficeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["leadOffice"].ToString(), ""));
            LeadOfficeDropDownList.DataBind();
            //--//


            // new code added by gaurav //
            DataSet dsSubVenue = Queries.onLoadSubVenue(VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text, Session["ProfileID"].ToString());
            SubVenueDropDownList.DataSource = dsSubVenue;
            SubVenueDropDownList.DataTextField = "SVenue_India_Name";
            SubVenueDropDownList.DataValueField = "SVenue_India_Name";
            SubVenueDropDownList.AppendDataBoundItems = true;
            SubVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["SubVenue"].ToString(), ""));
            SubVenueDropDownList.DataBind();






            DataSet dsptitle = Queries.LoadPrimarySalutation(Session["ProfileID"].ToString(), office);
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


            DataSet dspnationality = Queries.LoadPrimaryNationality(Session["ProfileID"].ToString());
            PrimarynationalityDropDownList.DataSource = dspnationality;
            PrimarynationalityDropDownList.DataTextField = "Nationality_Name";
            PrimarynationalityDropDownList.DataValueField = "Nationality_Name";
            PrimarynationalityDropDownList.AppendDataBoundItems = true;
            PrimarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            PrimarynationalityDropDownList.DataBind();

            DataSet dspcountry = Queries.LoadCountryPrimary(Session["ProfileID"].ToString());
            primarycountryDropDownList.DataSource = dspcountry;
            primarycountryDropDownList.DataTextField = "country_name";
            primarycountryDropDownList.DataValueField = "country_name";
            primarycountryDropDownList.AppendDataBoundItems = true;
            primarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            primarycountryDropDownList.DataBind();



            pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            pemail2TextBox.Text = ds.Tables[0].Rows[0]["Primary_Email2"].ToString();

            DataSet dspm = Queries.LoadCountryWithCodePrimaryMobile(Session["ProfileID"].ToString());
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
            DataSet dsstitle = Queries.LoadSecondarySalutation(Session["ProfileID"].ToString(), office);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();

            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Lname"].ToString();
            secondarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_secondary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_secondary_DOB"].ToString()).ToString("dd-MM-yyyy");
            secondaryAge.Text = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            sdesignationTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();

            DataSet dssnationality = Queries.LoadSecondaryNationality(Session["ProfileID"].ToString());
            secondarynationalityDropDownList.DataSource = dssnationality;
            secondarynationalityDropDownList.DataTextField = "Nationality_Name";
            secondarynationalityDropDownList.DataValueField = "Nationality_Name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();

            DataSet dsscountry = Queries.LoadCountrySecondary(Session["ProfileID"].ToString());
            secondarycountryDropDownList.DataSource = dsscountry;
            secondarycountryDropDownList.DataTextField = "country_name";
            secondarycountryDropDownList.DataValueField = "country_name";
            secondarycountryDropDownList.AppendDataBoundItems = true;
            secondarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString(), ""));
            secondarycountryDropDownList.DataBind();



            semailTextBox.Text = ds.Tables[0].Rows[0]["secondary_Email"].ToString();
            semail2TextBox.Text = ds.Tables[0].Rows[0]["secondary_Email2"].ToString();

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
            DataSet ds1222 = Queries.LoadStateName(Session["ProfileID"].ToString(), AddCountryDropDownList.SelectedItem.Text);
            StateDropDownList.DataSource = ds1222;
            StateDropDownList.DataTextField = "State_Name";
            StateDropDownList.DataValueField = "State_Name";
            StateDropDownList.AppendDataBoundItems = true;
            StateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_State"].ToString(), ""));
            StateDropDownList.DataBind();


            DataSet dsemploy = Queries.LoadEmploymentStatusNotInProfile(Session["ProfileID"].ToString());
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();


            DataSet dsmart = Queries.LoadMaritalStatusNotInProfile(Session["ProfileID"].ToString());
            maritalstatusDropDownList.DataSource = dsmart;
            maritalstatusDropDownList.DataTextField = "MaritalStatus";
            maritalstatusDropDownList.DataValueField = "MaritalStatus";
            maritalstatusDropDownList.AppendDataBoundItems = true;
            maritalstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            maritalstatusDropDownList.DataBind();



            DataSet dssp1title = Queries.LoadSub_Profile1Salutation(Session["ProfileID"].ToString(), office);
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

            DataSet dssp1nationality = Queries.LoadSub_Profile1Nationality(Session["ProfileID"].ToString());
            sp1nationalityDropDownList.DataSource = dssp1nationality;
            sp1nationalityDropDownList.DataTextField = "Nationality_Name";
            sp1nationalityDropDownList.DataValueField = "Nationality_Name";
            sp1nationalityDropDownList.AppendDataBoundItems = true;
            sp1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            sp1nationalityDropDownList.DataBind();

            DataSet dssp1country = Queries.LoadCountrySP1(Session["ProfileID"].ToString());
            sp1countryDropDownList.DataSource = dssp1country;
            sp1countryDropDownList.DataTextField = "country_name";
            sp1countryDropDownList.DataValueField = "country_name";
            sp1countryDropDownList.AppendDataBoundItems = true;
            sp1countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            sp1countryDropDownList.DataBind();



            sp1pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            sp1pemail2TextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

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



            DataSet dssp2title = Queries.LoadSub_Profile2Salutation(Session["ProfileID"].ToString(), office);
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

            DataSet dssp2nationality = Queries.LoadSub_Profile2Nationality(Session["ProfileID"].ToString());
            sp2nationalityDropDownList.DataSource = dssp2nationality;
            sp2nationalityDropDownList.DataTextField = "Nationality_Name";
            sp2nationalityDropDownList.DataValueField = "Nationality_Name";
            sp2nationalityDropDownList.AppendDataBoundItems = true;
            sp2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            sp2nationalityDropDownList.DataBind();

            DataSet dssp2country = Queries.LoadCountrySP2(Session["ProfileID"].ToString());
            sp2countryDropDownList.DataSource = dssp2country;
            sp2countryDropDownList.DataTextField = "country_name";
            sp2countryDropDownList.DataValueField = "country_name";
            sp2countryDropDownList.AppendDataBoundItems = true;
            sp2countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            sp2countryDropDownList.DataBind();
            sp2pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            sp2pemail2TextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();

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
            DataSet dssp3title = Queries.LoadSub_Profile3Salutation(Session["ProfileID"].ToString(), office);
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

            DataSet dssp3nationality = Queries.LoadSub_Profile3Nationality(Session["ProfileID"].ToString());
            sp3nationalityDropDownList.DataSource = dssp3nationality;
            sp3nationalityDropDownList.DataTextField = "Nationality_Name";
            sp3nationalityDropDownList.DataValueField = "Nationality_Name";
            sp3nationalityDropDownList.AppendDataBoundItems = true;
            sp3nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
            sp3nationalityDropDownList.DataBind();

            DataSet dssp3country = Queries.LoadCountrySP3(Session["ProfileID"].ToString());
            sp3countryDropDownList.DataSource = dssp3country;
            sp3countryDropDownList.DataTextField = "country_name";
            sp3countryDropDownList.DataValueField = "country_name";
            sp3countryDropDownList.AppendDataBoundItems = true;
            sp3countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            sp3countryDropDownList.DataBind();
            sp3pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
            sp3pemail2TextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();

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
            DataSet dssp4title = Queries.LoadSub_Profile3Salutation(Session["ProfileID"].ToString(), office);
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

            DataSet dssp4nationality = Queries.LoadSub_Profile3Nationality(Session["ProfileID"].ToString());
            sp4nationalityDropDownList.DataSource = dssp4nationality;
            sp4nationalityDropDownList.DataTextField = "Nationality_Name";
            sp4nationalityDropDownList.DataValueField = "Nationality_Name";
            sp4nationalityDropDownList.AppendDataBoundItems = true;
            sp4nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
            sp4nationalityDropDownList.DataBind();

            DataSet dssp4country = Queries.LoadCountrySP3(Session["ProfileID"].ToString());
            sp4countryDropDownList.DataSource = dssp4country;
            sp4countryDropDownList.DataTextField = "country_name";
            sp4countryDropDownList.DataValueField = "country_name";
            sp4countryDropDownList.AppendDataBoundItems = true;
            sp4countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            sp4countryDropDownList.DataBind();
            sp4pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
            sp4pemail2TextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

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


            DataSet dsqual = Queries.LoadGuestStatusInProfile(Session["ProfileID"].ToString());
            guestatusDropDownList.DataSource = dsqual;
            guestatusDropDownList.DataTextField = "Guest_Status_name";
            guestatusDropDownList.DataValueField = "Guest_Status_name";
            guestatusDropDownList.AppendDataBoundItems = true;
            guestatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            guestatusDropDownList.DataBind();

            DataSet dstour = Queries.LoadSalesRepsInProfile1(office, Session["ProfileID"].ToString(), VenueDropDownList.SelectedItem.Text);
            toursalesrepDropDownList.DataSource = dstour;
            toursalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            toursalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            toursalesrepDropDownList.AppendDataBoundItems = true;
            toursalesrepDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            toursalesrepDropDownList.DataBind();

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
            // ButtonUpDropDownList.Items.Insert(0, new ListItem("", ""));
            ButtonUpDropDownList.DataBind();


            DataSet dsdstatus = Queries.contractdealstatus(sContractdetailsID);// ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);        
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
            CanxContractNoTextBox.Text = dsct.Tables[0].Rows[0]["CanxContractNo"].ToString();
            string conttypevalue = dsct.Tables[0].Rows[0]["ContractType"].ToString();
            string Finance_Details = dsct.Tables[0].Rows[0]["Finance_Details"].ToString();
            LoanBUOfficerTextBox.Text = dsct.Tables[0].Rows[0]["Loan_BU_officer"].ToString();

            contractcommentTextBox.Text = dsct.Tables[0].Rows[0]["Contract_comment"].ToString();


            if (dsct.Tables[0].Rows[0]["MCWaiver"].ToString() == "No" || dsct.Tables[0].Rows[0]["MCWaiver"].ToString() == "NO")
            {
                mcRadioButtonList.Checked = false;
            }
            else if (dsct.Tables[0].Rows[0]["MCWaiver"].ToString() == "Yes" || dsct.Tables[0].Rows[0]["MCWaiver"].ToString() == "YES")

            {
                mcRadioButtonList.Checked = true;
            }
            MCFeesTextBox.Text = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
            MCdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["First_MC_Payable_Date"]);//.ToString();
            memberfeeTextBox.Text = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
            memcgstTextBox.Text = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
            memsgstTextBox.Text = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
            adharcardTextBox.Text = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
            pancardnoTextBox.Text = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
            companypanoTextBox.Text = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
            gstinTextBox.Text = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
            contractremarkTextBox.Text = dsct.Tables[0].Rows[0]["Contract_Remark"].ToString();

            string actbu = dsct.Tables[0].Rows[0]["bu_A6"].ToString();

            if (actbu == "" || actbu == null)
            {
                BUCheckBox.Checked = false;

            }
            else if (actbu == "Yes")
            {
                BUCheckBox.Checked = true;

            }

            else if (actbu == "No")
            {
                BUCheckBox.Checked = false;

            }
            string actup = dsct.Tables[0].Rows[0]["Updowngrade"].ToString();
            if (actup == "" || actup == null)
            {
                upCheckBox.Checked = false;
                downCheckBox.Checked = false;
            }
            else if (actup == "Upgrade")
            {
                upCheckBox.Checked = true;
                downCheckBox.Checked = false;
            }
            else if (actup == "Downgrade")
            {
                upCheckBox.Checked = false;
                downCheckBox.Checked = true;
            }

            //load finance details

            DataSet dsptsf = Queries.LoadFinanceContractDetails(sContractdetailsID);// ContractdetailsIDTextBox.Text);// contractno);
            if (dsptsf.Tables[0].Rows.Count == 0)
            {
                financeradiobuttonlist.SelectedIndex = -1;
                DataSet dscur = Queries.LoadFinanceOffice(office);// officeTextBox.Text);
                currencyDropDownList.DataSource = dscur;
                currencyDropDownList.DataTextField = "Finance_Currency_Name";
                currencyDropDownList.DataValueField = "Finance_Currency_Name";
                currencyDropDownList.AppendDataBoundItems = true;
                currencyDropDownList.Items.Insert(0, new ListItem("", ""));
                currencyDropDownList.DataBind();
                totalfinpriceIntaxTextBox.Text = "";
                intialdeppercentTextBox.Text = "";
                balinitialdepamtTextBox.Text = "";
                baldepamtTextBox.Text = "";
                regcollectiontermTextBox.Text = "";
                regcollamtTextBox.Text = "";
                baladepamtdateTextBox.Text = "";
                oldLoanAgreementTextBox.Text = "";
                PayMethodDropDownList.SelectedIndex = 0;
                AffiliationvalueTextBox.Text = "";
                NoinstallmentTextBox.Text = "";
                installmentamtTextBox.Text = "";
                balamtpayableTextBox.Text = "";
                financemethodDropDownList.SelectedIndex = 0;
                FinancenoTextBox.Text = "";
                finmonthTextBox.Text = "";
                noemiTextBox.Text = "";
                emiamtTextBox.Text = "";
                findocfeeTextBox.Text = "";
                isgtrateTextBox.Text = "";
                igstamtTextBox.Text = "";
                interestrateTextBox.Text = "";

            }
            else
            {
                financeradiobuttonlist.SelectedValue = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
                DataSet dscur = Queries.currencyfinancedetails(sContractdetailsID, office);// ContractdetailsIDTextBox.Text, officeTextBox.Text);
                currencyDropDownList.DataSource = dscur;
                currencyDropDownList.DataTextField = "Finance_Currency_Name";
                currencyDropDownList.DataValueField = "Finance_Currency_Name";
                currencyDropDownList.AppendDataBoundItems = true;
                currencyDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["currency"].ToString(), ""));
                currencyDropDownList.DataBind();
                totalfinpriceIntaxTextBox.Text = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
                intialdeppercentTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
                balinitialdepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
                baldepamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
                regcollectiontermTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
                regcollamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
                baladepamtdateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"]); //Convert.ToDateTime (dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString()).ToString("yyyy-MM-dd");
                oldLoanAgreementTextBox.Text = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
                DataSet dspym = Queries.paymethodfinancedetails(sContractdetailsID, office);// ContractdetailsIDTextBox.Text, officeTextBox.Text);
                PayMethodDropDownList.DataSource = dspym;
                PayMethodDropDownList.DataTextField = "pay_method_name";
                PayMethodDropDownList.DataValueField = "pay_method_name";
                PayMethodDropDownList.AppendDataBoundItems = true;
                PayMethodDropDownList.Items.Insert(0, new ListItem(dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString(), ""));
                PayMethodDropDownList.DataBind();
                AffiliationvalueTextBox.Text = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                NoinstallmentTextBox.Text = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
                installmentamtTextBox.Text = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
                balamtpayableTextBox.Text = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
                DataSet dsfin = Queries.financemethodfinancedetails(sContractdetailsID, office);// ContractdetailsIDTextBox.Text, officeTextBox.Text);

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

            }


            //load installments
            DataSet dsin = Queries.contractInstallment(sContractdetailsID);// ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);
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
            DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_ReceiptActiveOnlyDeposit(ContractdetailsIDTextBox.Text);// LoadContract_Indian_Deposit_Receipt(ContractdetailsIDTextBox.Text);
            if (dsreceipt.Tables[0].Rows.Count == 0)
            {
                DataSet dsdep = Queries.LoadDeposit_Pay_Method(sContractdetailsID,office);// ContractdetailsIDTextBox.Text, office);
                depositmethodDropDownList.DataSource = dsdep;
                depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                depositmethodDropDownList.AppendDataBoundItems = true;
                depositmethodDropDownList.Items.Insert(0, new ListItem("", ""));
                depositmethodDropDownList.DataBind();
                invoicedateTextBox.Text = "";
             //   depositmethodTextBox.Text = "";

            }
            else
            {
                DataSet dsdep = Queries.LoadDeposit_Pay_Method(sContractdetailsID, office);// ContractdetailsIDTextBox.Text, office);
                depositmethodDropDownList.DataSource = dsdep;
                depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
                depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
                depositmethodDropDownList.AppendDataBoundItems = true;
                depositmethodDropDownList.Items.Insert(0, new ListItem(dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString(), ""));
                depositmethodDropDownList.DataBind();
               // depositmethodTextBox.Text = dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString();
                invoicedateTextBox.Text = String.Format("{0:dd-MM-yyyy}", dsreceipt.Tables[0].Rows[0]["Receipt_Date"]);// Convert.ToDateTime(dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString()).ToString("yyyy-MM-dd");
                invoicenoTextBox.Text = dsreceipt.Tables[0].Rows[0]["Receipt_No"].ToString();
            }
            DataSet dscrm = Queries.LoadCRM_details(sContractdetailsID);// ContractdetailsIDTextBox.Text);
            if (dscrm.Tables[0].Rows.Count == 0)
            {
                PrgmsrcTextBox.Text = "";
                RefByTextBox.Text = "";
            }
            else
            {
                PrgmsrcTextBox.Text = dscrm.Tables[0].Rows[0]["program_source"].ToString();
                RefByTextBox.Text = dscrm.Tables[0].Rows[0]["Referred_By"].ToString();


            }


            if (dsct.Tables[0].Rows[0]["ContractType"].ToString() == "Points") // (conttypevalue == "Points")
            {

                visibilityPointstrue();

                DataSet dspts = Queries.LoadNewPointsDetails(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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
                    DataSet dspten = Queries.pointsentitlement(sContractdetailsID);// contractnoTextBox.Text);
                    EntitlementPoinDropDownList.Items.Add(dspts.Tables[0].Rows[0]["Type_membership"].ToString());
                    EntitlementPoinDropDownList.Items.Add(dspten.Tables[0].Rows[0]["Entitlement_Name"].ToString());
                    totalptrightsTextBox.Text = dspts.Tables[0].Rows[0]["Total_points_rights"].ToString();
                    firstyrTextBox.Text = dspts.Tables[0].Rows[0]["First_year_occupancy"].ToString();
                    tenureTextBox.Text = dspts.Tables[0].Rows[0]["Tenure"].ToString();
                    lastyrTextBox.Text = dspts.Tables[0].Rows[0]["Last_year_occupancy"].ToString();
                    NoPersonsTextBox.Text = dspts.Tables[0].Rows[0]["NoPersons"].ToString();



                }
                //load PA details
                DataSet dspa = Queries.contractPA(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                if (dspa.Tables[0].Rows.Count == 0)
                {
                    newpointsTextBox.Text = "";
                    conversionfeeTextBox.Text = "";
                    adminfeeTextBox.Text = "";
                    testadminfeeTextBox.Text = "";
                    totpurchpriceTextBox.Text = "";
                    cgstTextBox.Text = "";
                    sgstTextBox.Text = "";
                    totalpriceInTaxTextBox.Text = "";
                    depositTextBox.Text = "";
                    balanceTextBox.Text = "";
                    balancedueTextBox.Text = "";
                    remarksTextBox.Text = "";
                }
                else
                {

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


                }


                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, AffiliationvalueTextBox.Text, dsct.Tables[0].Rows[0]["MCWaiver"].ToString(), CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);


            }
            else if (dsct.Tables[0].Rows[0]["ContractType"].ToString() == "Trade-In-Points")//(conttypevalue == "Trade-In-Points")
            {
                visibilitytradeinPointstrue();
                DataSet dstip = Queries.LoadTradeinPointsDetails(sContractdetailsID);// ContractdetailsIDTextBox.Text);//contractno);
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
                    tipactualptsvalueTextBox.Text = "";
                }
                else
                {
                    tnmresortTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_club_resort"].ToString();
                    tipnopointsTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_No_rights"].ToString();
                    nmcontrcinoTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_ContNo_RCINo"].ToString();
                    tipptsvalueTextBox.Text = dstip.Tables[0].Rows[0]["Trade_In_Details_Points_value"].ToString();
                    tipactualptsvalueTextBox.Text = dstip.Tables[0].Rows[0]["Actualpoints_value"].ToString();

                    clubTextBox.Text = dstip.Tables[0].Rows[0]["New_Club"].ToString();
                    newpointsrightTextBox.Text = dstip.Tables[0].Rows[0]["New_Club_Points_Rights"].ToString();
                    NoPersonsTextBox.Text = dstip.Tables[0].Rows[0]["NoPersons"].ToString();


                    DataSet dstipen = Queries.tradeinpointsentitlement(sContractdetailsID);// ContractdetailsIDTextBox.Text);// contractnoTextBox.Text);
                    EntitlementPoinDropDownList.Items.Add(dstip.Tables[0].Rows[0]["New_MemebrshipType"].ToString());
                    EntitlementPoinDropDownList.Items.Add(dstipen.Tables[0].Rows[0]["Entitlement_Name"].ToString());

                    totalptrightsTextBox.Text = dstip.Tables[0].Rows[0]["New_TotalPointsRights"].ToString();
                    firstyrTextBox.Text = dstip.Tables[0].Rows[0]["New_First_year_occupancy"].ToString();
                    tenureTextBox.Text = dstip.Tables[0].Rows[0]["New_Tenure"].ToString();
                    lastyrTextBox.Text = dstip.Tables[0].Rows[0]["New_Last_year_occupancy"].ToString();



                }
                //load PA details
                DataSet dspa = Queries.contractPA(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                if (dspa.Tables[0].Rows.Count == 0)
                {
                    newpointsTextBox.Text = "";
                    conversionfeeTextBox.Text = "";
                    adminfeeTextBox.Text = "";
                    testadminfeeTextBox.Text = "";
                    totpurchpriceTextBox.Text = "";
                    cgstTextBox.Text = "";
                    sgstTextBox.Text = "";
                    totalpriceInTaxTextBox.Text = "";
                    depositTextBox.Text = "";
                    balanceTextBox.Text = "";
                    balancedueTextBox.Text = "";
                    remarksTextBox.Text = "";
                }
                else
                {
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


                }


                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, AffiliationvalueTextBox.Text, dsct.Tables[0].Rows[0]["MCWaiver"].ToString(), CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);


            }
            else if (dsct.Tables[0].Rows[0]["ContractType"].ToString() == "Trade-In-Weeks")//(conttypevalue == "Trade-In-Weeks")
            {

                visibilitytradeinweekstrue();

                DataSet dstiw = Queries.LoadTradeinWeeksDetails(sContractdetailsID);// ContractdetailsIDTextBox.Text);//  contractno);
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

                    DataSet dstiwk = Queries.tradeinwksseason(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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

                    DataSet dstiwen = Queries.tradeinwksentitlement(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                    EntitlementPoinDropDownList.Items.Add(dstiw.Tables[0].Rows[0]["NewPointsW_MemebrshipType"].ToString());
                    EntitlementPoinDropDownList.Items.Add(dstiwen.Tables[0].Rows[0]["Entitlement_Name"].ToString());

                    totalptrightsTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Total_Points_rights"].ToString();
                    firstyrTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_First_year_occupancy"].ToString();
                    tenureTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Tenure"].ToString();
                    lastyrTextBox.Text = dstiw.Tables[0].Rows[0]["NewPointsW_Last_year_occupancy"].ToString();
                    NoPersonsTextBox.Text = dstiw.Tables[0].Rows[0]["NoPersons"].ToString();


                }

                //load PA details
                DataSet dspa = Queries.contractPA(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                if (dspa.Tables[0].Rows.Count == 0)
                {
                    newpointsTextBox.Text = "";
                    conversionfeeTextBox.Text = "";
                    adminfeeTextBox.Text = "";
                    testadminfeeTextBox.Text = "";
                    totpurchpriceTextBox.Text = "";
                    cgstTextBox.Text = "";
                    sgstTextBox.Text = "";
                    totalpriceInTaxTextBox.Text = "";
                    depositTextBox.Text = "";
                    balanceTextBox.Text = "";
                    balancedueTextBox.Text = "";
                    remarksTextBox.Text = "";
                }
                else
                {
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


                }


                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, AffiliationvalueTextBox.Text, dsct.Tables[0].Rows[0]["MCWaiver"].ToString(), CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);

            }//           Trade - In - Weeks
            else if (dsct.Tables[0].Rows[0]["ContractType"].ToString() == "Fractional")//(conttypevalue == "Fractional")
            {

                visibilityfractionaltrue();
                //load finance details
                DataSet dstif = Queries.loadtradeinfractional(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                if (dstif.Tables[0].Rows.Count == 0)
                {

                }
                else
                {
                    DataSet dsold = Queries.LoadOldContractType(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                    oldcontracttypeDropDownList.DataSource = dsold;
                    oldcontracttypeDropDownList.DataTextField = "ContractType";
                    oldcontracttypeDropDownList.DataValueField = "ContractType";
                    oldcontracttypeDropDownList.AppendDataBoundItems = true;
                    oldcontracttypeDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString(), ""));
                    oldcontracttypeDropDownList.DataBind();

                    DataSet dsfres = Queries.loadtradeinfractionalResort(sContractdetailsID, office);// ContractdetailsIDTextBox.Text, officeTextBox.Text);
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

                    DataSet dsfresidenceno = Queries.loadtradeinfractionalResidence(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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
                    DataSet dsftype = Queries.loadtradeinfractionalResidencetype(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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

                    DataSet dsfint = Queries.loadtradeinfractionalFractionalInt(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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

                    DataSet dstifen = Queries.tradeinfractionalentitlement(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                    fwentitlementDropDownList.Items.Add(dstif.Tables[0].Rows[0]["entitlement"].ToString());
                    fwentitlementDropDownList.Items.Add(dstifen.Tables[0].Rows[0]["Entitlement_Name"].ToString());
                    fwfirstyrTextBox.Text = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
                    fwtenureTextBox.Text = dstif.Tables[0].Rows[0]["tenure"].ToString();
                    fwlastyrTextBox.Text = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();

                }

                //load fractional pa
                DataSet dsfpa = Queries.LoadfractionalPA(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                if (dsfpa.Tables[0].Rows.Count == 0)
                {
                    ftradeinvalueTextBox.Text = "";
                    tradeinamtTextBox.Text = "";
                    ftotalvalueTextBox.Text = "";
                    adminfeeTextBox.Text = "";
                    AdministrationFeesTextBox.Text = "";
                    testadminfeeTextBox.Text = "";
                    totpurchpriceTextBox.Text = "";
                    cgstTextBox.Text = "";
                    sgstTextBox.Text = "";
                    totalpriceInTaxTextBox.Text = "";
                    depositTextBox.Text = "";
                    balanceTextBox.Text = "";
                    balancedueTextBox.Text = "";
                    remarksTextBox.Text = "";
                }
                else
                {

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
                }



                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, "", dsct.Tables[0].Rows[0]["MCWaiver"].ToString(), CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);

            }//Fractionals
            else if (dsct.Tables[0].Rows[0]["ContractType"].ToString() == "Trade-In-Fractionals") //(conttypevalue == "Trade -In-Fractionals")
            {

                visibilityfractionaltrue();
                //load finance details
                DataSet dstif = Queries.loadtradeinfractional(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                if (dstif.Tables[0].Rows.Count == 0)
                {

                }
                else
                {
                    DataSet dsold = Queries.LoadOldContractType(sContractdetailsID);// ContractdetailsIDTextBox.Text);
                    oldcontracttypeDropDownList.DataSource = dsold;
                    oldcontracttypeDropDownList.DataTextField = "ContractType";
                    oldcontracttypeDropDownList.DataValueField = "ContractType";
                    oldcontracttypeDropDownList.AppendDataBoundItems = true;
                    oldcontracttypeDropDownList.Items.Insert(0, new ListItem(dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString(), ""));
                    oldcontracttypeDropDownList.DataBind();

                    DataSet dsfres = Queries.loadtradeinfractionalResort(sContractdetailsID, office);// ContractdetailsIDTextBox.Text, officeTextBox.Text);
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

                    DataSet dsfresidenceno = Queries.loadtradeinfractionalResidence(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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
                    DataSet dsftype = Queries.loadtradeinfractionalResidencetype(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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

                    DataSet dsfint = Queries.loadtradeinfractionalFractionalInt(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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

                    DataSet dstifen = Queries.tradeinfractionalentitlement(sContractdetailsID);// ContractdetailsIDTextBox.Text);
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

                         

                    }
                    else if (dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString() == "Weeks")
                    {

                        tnmresortTextBox.Text = dstif.Tables[0].Rows[0]["RESORT"].ToString();
                        tnmapttypeTextBox.Text = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString();
                        DataSet dsfseason = Queries.tradeinfractionalseason(sContractdetailsID);// ContractdetailsIDTextBox.Text);

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

                }

                //load fractional pa
                DataSet dsfpa = Queries.LoadfractionalPA(sContractdetailsID);// ContractdetailsIDTextBox.Text);

                if (dsfpa.Tables[0].Rows.Count == 0)
                {
                    ftradeinvalueTextBox.Text = "";
                    tradeinamtTextBox.Text = "";
                    ftotalvalueTextBox.Text = "";
                    adminfeeTextBox.Text = "";
                    AdministrationFeesTextBox.Text = "";
                    testadminfeeTextBox.Text = "";
                    totpurchpriceTextBox.Text = "";
                    cgstTextBox.Text = "";
                    sgstTextBox.Text = "";
                    totalpriceInTaxTextBox.Text = "";
                    depositTextBox.Text = "";
                    balanceTextBox.Text = "";
                    balancedueTextBox.Text = "";
                    remarksTextBox.Text = "";
                }
                else
                {

                    ftradeinvalueTextBox.Text = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
                    tradeinamtTextBox.Text = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
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
                }




                LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeTextBox.Text, AffiliationvalueTextBox.Text, dsct.Tables[0].Rows[0]["MCWaiver"].ToString(), CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);

            }//Trade-In-Fractionals
        }
    }








    //update details

    public void CreateButton_Click(object sender, EventArgs e)
    {

        string sContractdetailsID = (string)Session["ContractdetailsID"];
        string user = (string)Session["username"];
        DataSet dsct = Queries.LoadContractDetails_ID(sContractdetailsID);// (ContractdetailsIDTextBox.Text);

        Session["contractno"] = dsct.Tables[0].Rows[0]["contractno"].ToString();
        Session["ocsalesrep"] = dsct.Tables[0].Rows[0]["Sales_Rep"].ToString();
        Session["ocTomgr"] = dsct.Tables[0].Rows[0]["TO_Manager"].ToString();
        Session["obuttonup"] = dsct.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
        Session["odealdate"] = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["DealRegistered_Date"]);
        Session["odealstatus"] = dsct.Tables[0].Rows[0]["DealStatus"].ToString();
        Session["oContractUpdatedDate"] = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["Contract_UpdatedDate"]);// dsct.Tables[0].Rows[0]["Contract_UpdatedDate"].ToString();
        Session["omcwv"] = dsct.Tables[0].Rows[0]["MCWaiver"].ToString();
        Session["ofinancedetails"] = dsct.Tables[0].Rows[0]["Finance_Details"].ToString();
        Session["ocontract_Remark"] = dsct.Tables[0].Rows[0]["Contract_Remark"].ToString();
        Session["opan"] = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
        Session["oadhar"] = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
        Session["omcfees"] = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
        Session["omcdate"] = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["First_MC_Payable_Date"]);// dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
        Session["omemberfee"] = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
        Session["omemebercgst"] = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
        Session["omembersgst"] = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
        Session["ocanxcontno"] = dsct.Tables[0].Rows[0]["CanxContractNo"].ToString();
        Session["ocanxdate"] = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["Contract_Canx_date"]);// dsct.Tables[0].Rows[0]["Contract_Canx_date"].ToString()
        Session["oloanbuofficer"] = dsct.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
        Session["ocogstin"] = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
        Session["ocompanypano"] = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
        Session["odealweekno"] = Convert.ToInt32(dsct.Tables[0].Rows[0]["dealweekno"]);
        Session["odeckdetails"] = dsct.Tables[0].Rows[0]["deckdetails"].ToString();
        Session["odeckremark"] = dsct.Tables[0].Rows[0]["deckremark"].ToString();
        Session["ocontractcomment"] = dsct.Tables[0].Rows[0]["Contract_comment"].ToString();
        Session["obu6"] = dsct.Tables[0].Rows[0]["BU_A6"].ToString();
        Session["oupdowngrade"] = dsct.Tables[0].Rows[0]["Updowngrade"].ToString();

        DataSet dsptsf = Queries.LoadFinanceContractDetails(sContractdetailsID);// (ContractdetailsIDTextBox.Text);
        Session["ocurrency"] = dsptsf.Tables[0].Rows[0]["currency"].ToString();
        Session["oaffiliate"] = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
        Session["ototalintax"] = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
        Session["odepamt"] = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
        Session["obalpayable"] = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
        Session["odepbal"] = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
        Session["ototalbalance"] = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
        Session["opaymethod"] = dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString();
        Session["onoinstallment"] = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
        Session["oinstallment"] = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
        Session["ofinancemethod"] = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();
        Session["oFinanceno"] = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
        Session["oisgtrate"] = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
        Session["ointerestrate"] = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
        Session["ofindocfee"] = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
        Session["oigstamt"] = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
        Session["onoemi"] = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
        Session["oemiamt"] = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
        Session["ofinmonth"] = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
        Session["ooldLoanAgreement"] = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
        Session["oregcollectionterm"] = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
        Session["oregcollamt"] = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
        Session["obaladepamtdate"] = String.Format("{0:dd-MM-yyyy}", dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"]);// dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString();
        Session["ooldloanamt "] = dsptsf.Tables[0].Rows[0]["Old_Loan_Amount"].ToString();








        DataSet dspr = Queries.LoadProfielDetailsFull(Session["ProfileID"].ToString());
        Session["ocompanyname"] = dspr.Tables[0].Rows[0]["Company_Name"].ToString();



        DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_ReceiptActiveOnlyDeposit(sContractdetailsID);// LoadContract_Indian_Deposit_Receipt(sContractdetailsID);// ContractdetailsIDTextBox.Text);
        if (dsreceipt.Tables[0].Rows.Count == 0)
        {

        }
        else
        {

            Session["oReceipt_Date"] = String.Format("{0:dd-MM-yyyy}", dsreceipt.Tables[0].Rows[0]["Receipt_Date"]);// dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString();
            Session["oReceipt_No"] = dsreceipt.Tables[0].Rows[0]["Receipt_No"].ToString();
            Session["oAmount"] = dsreceipt.Tables[0].Rows[0]["Amount"].ToString();
            Session["otaxable_value"] = dsreceipt.Tables[0].Rows[0]["taxable_value"].ToString();
            Session["ocgstrate"] = dsreceipt.Tables[0].Rows[0]["cgstrate"].ToString();
            Session["ocgstamt"] = dsreceipt.Tables[0].Rows[0]["cgstamt"].ToString();
            Session["osgstrate"] = dsreceipt.Tables[0].Rows[0]["sgstrate"].ToString();
            Session["osgstamt"] = dsreceipt.Tables[0].Rows[0]["sgstamt"].ToString();
            Session["ototalamt"] = dsreceipt.Tables[0].Rows[0]["totalamt"].ToString();
            Session["oPayment_Mode"] = dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString();
            Session["oactual_currency"] = dsreceipt.Tables[0].Rows[0]["actual_currency"].ToString();
            Session["oconverted_currency"] = dsreceipt.Tables[0].Rows[0]["converted_currency"].ToString();
            Session["oConverted_rate"] = dsreceipt.Tables[0].Rows[0]["Converted_rate"].ToString();
            Session["oExchangedValue_date"] = dsreceipt.Tables[0].Rows[0]["ExchangedValue_date"].ToString();
            Session["oActual_Amt"] = dsreceipt.Tables[0].Rows[0]["Actual_Amt"].ToString();
        }

        DataSet dscrm = Queries.LoadCRM_details(sContractdetailsID);// ContractdetailsIDTextBox.Text);
        if (dscrm.Tables[0].Rows.Count == 0)
        {
            Session["program_source"] = ""; Session["Referred_By"] = "";
            Session["updated_date"] = ""; Session["updatedby"] = "";
        }
        else
        {
            Session["program_source"] = dscrm.Tables[0].Rows[0]["program_source"].ToString();
            Session["Referred_By"] = dscrm.Tables[0].Rows[0]["Referred_By"].ToString();
            Session["updated_date"] = dscrm.Tables[0].Rows[0]["updated_date"].ToString();
            Session["updatedby"] = dscrm.Tables[0].Rows[0]["updatedby"].ToString();


        }


        string finance = financeradiobuttonlist.SelectedItem.Text;
        string mcfees = MCFeesTextBox.Text;
        string mcdate = String.Format("{0:dd-MM-yyyy}", MCdateTextBox.Text);
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
        string baldepdate = String.Format("{0:dd-MM-yyyy}", baladepamtdateTextBox.Text);
        string paymentmode = depositmethodDropDownList.SelectedItem.Text;// depositmethodTextBox.Text;//

        string regcollectionterm = regcollectiontermTextBox.Text;
        string regcollamt = regcollamtTextBox.Text;
        string oldloanagreementno = oldLoanAgreementTextBox.Text;
        string loanamt = foldloanamountTextBox.Text;

        string receiptdate = invoicedateTextBox.Text;
        string ncontractcomment = contractcommentTextBox.Text;
        string receiptno = invoicenoTextBox.Text;
        string contractremark = contractremarkTextBox.Text;
        string prgmsrc = PrgmsrcTextBox.Text;
        string refby = RefByTextBox.Text;


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
        string bu6;
        if (BUCheckBox.Checked)
        {
            bu6 = "Yes";
        }
        else
        {
            bu6 = "No";
        }
        string updown = null;

        if (upCheckBox.Checked)
        {
            updown = "Upgrade";
        }
        else
        {
            updown = "";
        }
        if (downCheckBox.Checked)
        {
            updown = "Downgrade";
        }
        else
        {
            updown = "";
        }

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
            Financeno = "0";
            finmonth = "";
            noemi = "0";
            emiamt = "0";
            findocfee = "0";
            isgtrate = "0";
            igstamt = "0";
            interestrate = "0";

        }
        string mcwaiver;
        if (mcRadioButtonList.Checked == true)
        {
            mcwaiver = "Yes";
        }
        else
        {
            mcwaiver = "No";

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

        if (dealstatusDropDownList.SelectedItem.Text == "CANCELLED" || dealstatusDropDownList.SelectedItem.Text == "CANCELLED & REFUNDED")
        {
            dealstatus = dealstatusDropDownList.SelectedItem.Text;
            canxdate = DateTime.Now.ToString();
        }
         
        else
        {
            dealstatus = dealstatusDropDownList.SelectedItem.Text;
            canxdate = "";
        }
        if (String.Compare(Session["ocompanyname"].ToString(), ncompanyname) != 0)
        {
            int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, ncompanyname);
            string act = "company name changed from:" + Session["ocompanypano"].ToString() + "To:" + ncompanyname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocontractcomment"].ToString(), ncontractcomment) != 0)
        {
            int update = Queries.UpdateContractDetails_IndianComment(ContractdetailsIDTextBox.Text, ncontractcomment.ToUpper());
            string act = "contract comment(for DSR) changed from:" + Session["ocontractcomment"].ToString() + "To:" + ncontractcomment;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocogstin"].ToString(), ngstin) != 0)
        {
            string act = "company GSTIN changed from:" + Session["ocogstin"].ToString() + "To:" + ngstin;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocompanypano"].ToString(), ncompanypanno) != 0)
        {
            string act = "company pan no changed from:" + Session["ocompanypano"].ToString() + "To:" + ncompanypanno;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oContractUpdatedDate"].ToString(), DateTime.Now.ToString()) != 0)
        {
            string act = "contract updated date changed from:" + Session["oContractUpdatedDate"].ToString() + "To:" + DateTime.Now.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocontract_Remark"].ToString(), contractremark) != 0)
        {
            int update = Queries.UpdateContractDetails_IndianContract_Remark(ContractdetailsIDTextBox.Text, contractremark.ToUpper());
            string act = "contract remark changed from:" + Session["ocontract_Remark"].ToString() + "To:" + contractremark;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["contractno"].ToString(), contractno) != 0)
        {
            //update in installment table
            if (Queries.CheckContract_Installments_Indian_ContractNoExists(sContractdetailsID) == 1)
            {
                int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, sContractdetailsID);
            }
            else { }
            if (Queries.CheckFinanceBreakup_ContractNoExists(sContractdetailsID) == 1)
            {
                int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, sContractdetailsID);
            }
            else { }
            if (Queries.CheckContractNo_Othernames_ContractNoExists(sContractdetailsID) == 1)
            {
                int updatebkrup = Queries.UpdateContractNo_Othernames_ContractNo(contractno, sContractdetailsID);
            }
            else { }
            if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(sContractdetailsID) == 1)
            {
                int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, sContractdetailsID);
            }
            else { }

            //if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(sContractdetailsID) == 1)
            //{
            //    int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, sContractdetailsID);
            //}
            //else { }
            string act = "Contract NO changed from:" + Session["contractno"].ToString() + "To:" + contractno;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["ocsalesrep"].ToString(), csalesrep) != 0)
        {
            string act = "sales rep changed from:" + Session["ocsalesrep"].ToString() + "To:" + csalesrep;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["ocTomgr"].ToString(), cTomgr) != 0)
        {
            string act = "TO manager changed from:" + Session["ocTomgr"].ToString() + "To:" + cTomgr;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["obuttonup"].ToString(), buttonup) != 0)
        {
            string act = "button up changed from:" + Session["obuttonup"].ToString() + "To:" + buttonup;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["odealdate"].ToString(), dealdate) != 0)
        {
            string act = "deal date changed from:" + Session["odealdate"].ToString() + "To:" + dealdate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["odealweekno"].ToString(), dealwkno.ToString()) != 0)
        {
            string act = "deal wk no changed from:" + Session["odealweekno"].ToString() + "To:" + dealwkno.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["odealstatus"].ToString(), dealstatus) != 0)
        {
            string act = "deal status changed from:" + Session["odealstatus"].ToString() + "To:" + dealstatus;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oloanbuofficer"].ToString(), loanbuofficer) != 0)
        {
            string act = "Loan BU Officer changed from:" + Session["oloanbuofficer"].ToString() + "To:" + loanbuofficer;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocanxcontno"].ToString(), canxcontno) != 0)
        {
            string act = "Cancelled Canx No changed from:" + Session["ocanxcontno"].ToString() + "To:" + canxcontno;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["ocanxdate"].ToString(), canxdate) != 0)
        {
            string act = "deal cancelled date changed from:" + Session["ocanxdate"].ToString() + "To:" + canxdate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }



        if (String.Compare(Session["omcwv"].ToString(), mcwaiver) != 0)
        {
            string act = "MC waiver changed from:" + Session["omcwv"].ToString() + "To:" + mcwaiver;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["oadhar"].ToString(), adhar) != 0)
        {
            string act = "Adhar Card changed from:" + Session["oadhar"].ToString() + "To:" + adhar;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["opan"].ToString(), pancrd) != 0)
        {
            string act = "pan card changed from:" + Session["opan"].ToString() + "To:" + pancrd;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ofinancedetails"].ToString(), finance) != 0)
        {

            string act = "Financemethod changed from:" + Session["ofinancedetails"].ToString() + "To:" + finance;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            CheckBreakup(finance,Session["ototalbalance"].ToString(), noemiTextBox.Text, Session["onoemi"].ToString(), totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, sContractdetailsID, NoinstallmentTextBox.Text);
        }
        else { }
        if (String.Compare(Session["omcfees"].ToString(), mcfees) != 0)
        {
            string act = "MC fees changed from:" + Session["omcfees"].ToString() + "To:" + mcfees;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["omcdate"].ToString(), mcdate) != 0)
        {
            string act = "MC Date changed from:" + Session["omcdate"].ToString() + "To:" + mcdate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["omemberfee"].ToString(), memberfee) != 0)
        {
            string act = "Member fee changed from:" + Session["omemberfee"].ToString() + "To:" + memberfee;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["omemebercgst"].ToString(), memebercgst) != 0)
        {
            string act = "Member cgst changed from:" + Session["omemebercgst"].ToString() + "To:" + memebercgst;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["omembersgst"].ToString(), membersgst) != 0)
        {
            string act = "Member sgst changed from:" + Session["omembersgst"].ToString() + "To:" + membersgst;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["obu6"].ToString(), bu6) != 0)
        {
            string act = "Button up after 6pm changed from:" + Session["obu6"].ToString() + "To:" + bu6;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oupdowngrade"].ToString(), updown) != 0)
        {
            string act = "Upgrade/Downgrade changed from:" + Session["oupdowngrade"].ToString() + "To:" + updown;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocurrency"].ToString(), currency) != 0)
        {
            string act = "Currency changed from:" + Session["ocurrency"].ToString() + "To:" + currency;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oaffiliate"].ToString(), affiliate) != 0)
        {
            string act = "Affiliation changed from:" + Session["oaffiliate"].ToString() + "To:" + affiliate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ototalintax"].ToString(), totalintax) != 0)
        {
            string act = "Total price including tax changed from:" + Session["ototalintax"].ToString() + "To:" + totalintax;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["odepamt"].ToString(), depamt) != 0)
        {
            string act = "Deposit amount changed from:" + Session["odepamt"].ToString() + "To:" + depamt;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["obalpayable"].ToString(), balpayable) != 0)
        {
            string act = "Deposit amount(bal) changed from:" + Session["obalpayable"].ToString() + "To:" + balpayable;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["obaladepamtdate"].ToString(), baldepdate) != 0)
        {
            string act = "Deposit amount(bal) Date changed from:" + Session["obaladepamtdate"].ToString() + "To:" + baldepdate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["odepbal"].ToString(), depbal) != 0)
        {
            string act = "Balance deposit changed from:" + Session["odepbal"].ToString() + "To:" + depbal;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["onoinstallment"].ToString(), noinstallment) != 0)
        {
            string act = "No of installment changed from:" + Session["onoinstallment"].ToString() + "To:" + noinstallment;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());

        }
        else
        {

        }
        if (String.Compare(Session["oinstallment"].ToString(), installment) != 0)
        {
            string act = "Installment Amount changed from:" + Session["oinstallment"].ToString() + "To:" + installment;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            if (Queries.CheckContract_Installments_Indian_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
            {
                if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
                {
                    //check if contracttno exists in installment table if yes deleete if no  nothting
                    //check previous valu of installment
                    if (Session["onoinstallment"].ToString() == "" || Session["onoinstallment"].ToString() == "0" || Session["onoinstallment"].ToString() == "NaN")
                    {

                    }
                    else
                    {
                        //delete from installment table;
                    }
                    int exists = Queries.ContractNoInInstallmentTable(sContractdetailsID);
                    if (exists == 1)
                    {
                        //delete from table

                        DataSet dsin = Queries.LoadcontractInstallment(sContractdetailsID);//.Text);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            Session["Installment_ID"] = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();

                            Session["iProfileID"] = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            Session["ContractNo"] = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            Session["Installment_no"] = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            Session["Installment_Amount"] = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            Session["Installment_Date"] = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            Session["Installment_Invoice_No"] = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Session["Installment_ID"].ToString(), Session["iProfileID"].ToString(), Session["ContractNo"].ToString(), Session["Installment_no"].ToString(), Session["Installment_Amount"].ToString(), Session["Installment_Date"].ToString(), Session["Installment_Invoice_No"].ToString(), DateTime.Now.ToString(), sContractdetailsID);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + Session["iProfileID"].ToString() + "," + "ContractNo: " + Session["ContractNo"].ToString() + "," + "Installment #:" + Session["Installment_no"].ToString() + "," + "Installment Amt:" + Session["Installment_Amount"].ToString() + "," + "Installment Date:" + Session["Installment_Date"].ToString() + "," + "Installment_Invoice_No:" + Session["Installment_Invoice_No"].ToString() + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + sContractdetailsID;
                            int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, log5, user, DateTime.Now.ToString());
                            int delrow = Queries.DeleteContract_Installments_Indian(Session["Installment_ID"].ToString());
                        }

                    }
                    else { }

                }
                else
                {
                    //delete .//previous installment
                    DataSet dsin = Queries.LoadcontractInstallment(sContractdetailsID);
                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                    {
                        Session["Installment_ID"] = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();

                        Session["iProfileID"] = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                        Session["ContractNo"] = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                        Session["Installment_no"] = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                        Session["Installment_Amount"] = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                        Session["Installment_Date"] = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                        Session["Installment_Invoice_No"] = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Session["Installment_ID"].ToString(), Session["iProfileID"].ToString(), Session["ContractNo"].ToString(), Session["Installment_no"].ToString(), Session["Installment_Amount"].ToString(), Session["Installment_Date"].ToString(), Session["Installment_Invoice_No"].ToString(), DateTime.Now.ToString(), sContractdetailsID);
                        string log5 = "Installment Details Deleted:" + "Profile id: " + Session["iProfileID"].ToString() + "," + "ContractNo: " + Session["ContractNo"].ToString() + "," + "Installment #:" + Session["Installment_no"].ToString() + "," + "Installment Amt:" + Session["Installment_Amount"].ToString() + "," + "Installment Date:" + Session["Installment_Date"].ToString() + "," + "Installment_Invoice_No:" + Session["Installment_Invoice_No"].ToString() + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + sContractdetailsID;
                        int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, log5, user, DateTime.Now.ToString());
                        int delrow = Queries.DeleteContract_Installments_Indian(Session["Installment_ID"].ToString());
                    }
                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(Session["ProfileID"].ToString(), Session["contractno"].ToString(), installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office),  sContractdetailsID);
                        string log5 = "Installment Details:" + "Profile id: " + Session["ProfileID"].ToString() + "," + "Contractno: " +Session["contractno"].ToString() + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" +  sContractdetailsID;
                        int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                }
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    int exists = Queries.ContractNoInInstallmentTable(sContractdetailsID);
                    if (exists == 1)
                    {
                        //delete .//previous installment
                        DataSet dsin = Queries.LoadcontractInstallment(sContractdetailsID);
                        for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
                        {
                            Session["Installment_ID"] = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
                            Session["iProfileID"] = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
                            Session["ContractNo"] = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
                            Session["Installment_no"] = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
                            Session["Installment_Amount"] = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
                            Session["Installment_Date"] = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
                            Session["Installment_Invoice_No"] = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
                            int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Session["Installment_ID"].ToString(), Session["iProfileID"].ToString(), Session["ContractNo"].ToString(), Session["Installment_no"].ToString(), Session["Installment_Amount"].ToString(), Session["Installment_Date"].ToString(), Session["Installment_Invoice_No"].ToString(), DateTime.Now.ToString(), sContractdetailsID);
                            string log5 = "Installment Details Deleted:" + "Profile id: " + Session["iProfileID"].ToString() + "," + "ContractNo: " + Session["ContractNo"].ToString() + "," + "Installment #:" + Session["Installment_no"].ToString() + "," + "Installment Amt:" + Session["Installment_Amount"].ToString() + "," + "Installment Date:" + Session["Installment_Date"].ToString() + "," + "Installment_Invoice_No:" + Session["Installment_Invoice_No"].ToString() + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + sContractdetailsID;
                            int insertlog5 = Queries.InsertContractLogs_India(Session["iProfileID"].ToString(), sContractdetailsID, log5, user, DateTime.Now.ToString());
                            int delrow = Queries.DeleteContract_Installments_Indian(Session["Installment_ID"].ToString());
                        }
                        for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(Session["ProfileID"].ToString(), Session["contractno"].ToString(), installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), sContractdetailsID);
                            string log5 = "Installment Details:" + "Profile id: " + Session["ProfileID"].ToString() + "," + "Contractno: " +Session["contractno"].ToString() + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + sContractdetailsID;
                            int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(sContractdetailsID);

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

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(Session["ProfileID"].ToString(), sContractdetailsID, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office),sContractdetailsID);
                            string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + sContractdetailsID;
                            int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(sContractdetailsID);


                    }
                }
                else
                { }

            }
        }
        else { }


        if (String.Compare(Session["ototalbalance"].ToString(), totalbalance) != 0)
        {
            string act = "Balance Amount changed from:" + Session["ototalbalance"].ToString() + "To:" + totalbalance;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["opaymethod"].ToString(), paymethod) != 0)
        {
            string act = "Pay method changed from:" + Session["opaymethod"].ToString() + "To:" + paymethod;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ofinancemethod"].ToString(), financemethod) != 0)
        {
            string act = "Finance type changed from:" + Session["ofinancemethod"].ToString() + "To:" + financemethod;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oFinanceno"].ToString(), Financeno) != 0)
        {
            string act = "Finance no changed from:" + Session["oFinanceno"].ToString() + "To:" + Financeno;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ofinmonth"].ToString(), finmonth) != 0)
        {
            string act = "Finance month changed from:" + Session["ofinmonth"].ToString() + "To:" + finmonth;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["onoemi"].ToString(), noemi) != 0)
        {
            string act = "No of EMI changed from:" + Session["onoemi"].ToString() + "To:" + noemi;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            CheckBreakup(finance, Session["ototalbalance"].ToString(), noemiTextBox.Text, Session["onoemi"].ToString(),totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, sContractdetailsID, NoinstallmentTextBox.Text);
        }
        else { }
        if (String.Compare(Session["oemiamt"].ToString(), emiamt) != 0)
        {
            string act = "EMI Amount changed from:" + Session["oemiamt"].ToString() + "To:" + emiamt;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ofindocfee"].ToString(), findocfee) != 0)
        {
            string act = "Documentation Fee changed from:" + Session["ofindocfee"].ToString() + "To:" + findocfee;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oisgtrate"].ToString(), isgtrate) != 0)
        {
            string act = "IGST Rate changed from:" + Session["oisgtrate"].ToString() + "To:" + isgtrate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oigstamt"].ToString(), igstamt) != 0)
        {
            string act = "ISGT Amt changed from:" + Session["oigstamt"].ToString() + "To:" + igstamt;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ointerestrate"].ToString(), interestrate) != 0)
        {
            string act = "Interest Rate changed from:" + Session["ointerestrate"].ToString() + "To:" + interestrate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPayment_Mode"].ToString(), paymentmode) != 0)
        {
            string act = "Payment Mode changed from:" + Session["oPayment_Mode"].ToString() + "To:" + paymentmode;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oReceipt_Date"].ToString(), receiptdate) != 0)
        {
            string act = "Receipt Date changed from:" + Session["oReceipt_Date"].ToString() + "To:" + receiptdate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oReceipt_No"].ToString(), receiptno) != 0)
        {
            string act = "Receipt No changed from:" + Session["oReceipt_No"].ToString() + "To:" + receiptno;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ototalamt"].ToString(), indeposit.ToString()) != 0)
        {
            string act = "Total amount changed from:" + Session["ototalamt"].ToString() + "To:" + indeposit.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["otaxable_value"].ToString(), taxableamt.ToString()) != 0)
        {
            string act = "Amount changed from:" + Session["otaxable_value"].ToString() + "To:" + taxableamt.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["otaxable_value"].ToString(), taxableamt.ToString()) != 0)
        {
            string act = "Taxable amt changed from:" + Session["otaxable_value"].ToString() + "To:" + taxableamt.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["ocgstamt"].ToString(), gst.ToString()) != 0)
        {
            string act = "CGST Amt changed from:" + Session["ocgstamt"].ToString() + "To:" + gst.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osgstamt"].ToString(), gst.ToString()) != 0)
        {
            string act = "SGST Amt changed from:" + Session["osgstamt"].ToString() + "To:" + gst.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["Referred_By"].ToString(), refby) != 0)
        {
            string act = "Referred By(CRM Details) changed from:" + Session["Referred_By"].ToString() + "To:" + refby;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["program_source"].ToString(), prgmsrc) != 0)
        {
            string act = "Program Src(CRM Details) changed from:" + Session["program_source"].ToString() + "To:" + prgmsrc;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["updated_date"].ToString(), DateTime.Now.ToString()) != 0)
        {
            string act = "updated_date(CRM Details) changed from:" + Session["updated_date"].ToString() + "To:" + DateTime.Now.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["updatedby"].ToString(), user) != 0)
        {
            string act = "Updated By(CRM Details) changed from:" + Session["updatedby"].ToString() + "To:" + user;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
        }
        else { }

  
        int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractno, canxcontno, canxdate, loanbuofficer, sContractdetailsID);

        int updatecontractdetailsIndianothers = Queries.UpdateContractDetails_IndianBuUpdown(bu6, updown, sContractdetailsID);

        int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), sContractdetailsID);
        int updatecrm = Queries.UpdateCRM_details(sContractdetailsID, prgmsrc, refby, DateTime.Now.ToString(), user);
        int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractno, "", "", "", baldepdate, "", sContractdetailsID);
        int updatereceipt = Queries.UpdateReceiptNoIndian(contractno, receiptno, paymentmode,  sContractdetailsID);


        if (contract=="Points")
        {


            DataSet dspts = Queries.LoadNewPointsDetails(sContractdetailsID); 
            Session["opts_club"] = dspts.Tables[0].Rows[0]["club"].ToString();
            Session["opts_newpts"] = dspts.Tables[0].Rows[0]["New_points_rights"].ToString();
            Session["opts_entitlement"] = dspts.Tables[0].Rows[0]["Type_membership"].ToString();
            Session["opts_totalpts"] = dspts.Tables[0].Rows[0]["Total_points_rights"].ToString();
            Session["opts_firstyr"] = dspts.Tables[0].Rows[0]["First_year_occupancy"].ToString();
            Session["opts_Tenure"] = dspts.Tables[0].Rows[0]["Tenure"].ToString();
            Session["opts_lastyr"] = dspts.Tables[0].Rows[0]["Last_year_occupancy"].ToString();
            Session["opts_nopersons"] = dspts.Tables[0].Rows[0]["NoPersons"].ToString(); 
                    
            DataSet dspa = Queries.contractPA(sContractdetailsID);
            Session["onewpoints"] = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
            Session["oconversionfee"] = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
            Session["oadminfee"] = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
            Session["ototpurchprice"] = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            Session["ocgst"] = dspa.Tables[0].Rows[0]["Cgst"].ToString();
            Session["osgst"] = dspa.Tables[0].Rows[0]["Sgst"].ToString();
            Session["ototalpriceInTax"] = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            Session["odeposit"] = dspa.Tables[0].Rows[0]["Deposit"].ToString();
            Session["obalance"] = dspa.Tables[0].Rows[0]["Balance"].ToString();
            Session["obalancedue"] = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            Session["oremarks"] = dspa.Tables[0].Rows[0]["Remarks"].ToString();
            Session["ooldVolume"] = dspa.Tables[0].Rows[0]["oldVolume"].ToString();
            Session["ooldadminfee"] = dspa.Tables[0].Rows[0]["oldadminfee"].ToString();
            Session["ooldTotalTax"] = dspa.Tables[0].Rows[0]["oldTotalTax"].ToString();
            Session["ooldDeposit"] = dspa.Tables[0].Rows[0]["oldDeposit"].ToString();
            Session["ousdoldvolume"] = dspa.Tables[0].Rows[0]["usdoldvolume"].ToString();
            Session["ousdoldadminfee"] = dspa.Tables[0].Rows[0]["usdoldadminfee"].ToString();
            Session["ousdoldtax"] = dspa.Tables[0].Rows[0]["usdoldtax"].ToString();
            Session["ousdolddeposit"] = dspa.Tables[0].Rows[0]["usdolddeposit"].ToString();
            Session["oUSDConvertedVolume"] = dspa.Tables[0].Rows[0]["USDConvertedVolume"].ToString();
            Session["oUSDConvertedAdminfee"] = dspa.Tables[0].Rows[0]["USDConvertedAdminfee"].ToString();
            Session["oUSDConvertedTax"] = dspa.Tables[0].Rows[0]["USDConvertedTax"].ToString();
            Session["oUSDConverteddeposit"] = dspa.Tables[0].Rows[0]["USDConverteddeposit"].ToString();


         

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

            string USDConvertedVolume, USDConvertedTax, USDConvertedAdminfee, USDConverteddeposit;
            DataSet exrds = Queries.LoadExchange_Rate();
            string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();
            if (currencyDropDownList.SelectedItem.Text == "INR")
            {
                if (newpointsTextBox.Text == "" || newpointsTextBox.Text == null || newpointsTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(newpointsTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConverteddeposit = valueamt.ToString();
                }
            }
            else
            {
                if (totpurchpriceTextBox.Text == "" || totpurchpriceTextBox.Text == null || totpurchpriceTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(totpurchpriceTextBox.Text), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text), 0);
                    USDConverteddeposit = valueamt.ToString();
                }

            }


        

            if (String.Compare(Session["opts_club"].ToString(), pts_club) != 0)
            {
                string act = "(points) club name changed from:" + Session["opts_club"].ToString() + "To:" + pts_club;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["opts_newpts"].ToString(), pts_newpts) != 0)
            {
                string act = "(points)new points changed from:" + Session["opts_newpts"].ToString() + "To:" + pts_newpts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["opts_entitlement"].ToString(), pts_entitlement) != 0)
            {
                string act = "(points)entitlement changed from:" + Session["opts_entitlement"].ToString() + "To:" + pts_entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["opts_totalpts"].ToString(), pts_totalpts) != 0)
            {
                string act = "(points) total points changed from:" + Session["opts_totalpts"] .ToString()+ "To:" + pts_totalpts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["opts_firstyr"].ToString(), pts_firstyr) != 0)
            {
                string act = "(points) first yr changed from:" + Session["opts_firstyr"].ToString() + "To:" + pts_firstyr;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["opts_Tenure"].ToString(), pts_Tenure) != 0)
            {
                string act = "(points)tenure changed from:" + Session["opts_Tenure"].ToString() + "To:" + pts_Tenure;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["opts_lastyr"].ToString(), pts_lastyr) != 0)
            {
                string act = "(points) last yr changed from:" + Session["opts_lastyr"].ToString() + "To:" + pts_lastyr;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["opts_nopersons"].ToString(), pts_nopersons) != 0)
            {
                string act = "(points) No. Of Persons changed from:" + Session["opts_nopersons"].ToString() + "To:" + pts_nopersons;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["onewpoints"].ToString(), newpoints) != 0)
            {
                string act = "(points)New points changed from:" + Session["onewpoints"].ToString() + "To:" + newpoints;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oconversionfee"].ToString(), conversionfee) != 0)
            {
                string act = "(points)Conversion Fee changed from:" + Session["oconversionfee"].ToString() + "To:" + conversionfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oadminfee"].ToString(), adminfee) != 0)
            {
                string act = "(points)Admin Fee changed from:" + Session["oadminfee"].ToString() + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ototpurchprice"].ToString(), totpurchprice) != 0)
            {
                string act = "(points)Purchase Price changed from:" + Session["ototpurchprice"].ToString() + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ocgst"].ToString(), cgst) != 0)
            {
                string act = "(points)CGST changed from:" + Session["ocgst"].ToString()+ "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["osgst"].ToString(), sgst) != 0)
            {
                string act = "(points)SGST changed from:" + Session["osgst"].ToString() + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["ototalpriceInTax"].ToString(), totalpriceInTax) != 0)
            {
                string act = "(points) Total Price including Tax (PA) changed from:" + Session["ototalpriceInTax"].ToString() + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["odeposit"].ToString(), deposit) != 0)
            {
                string act = "(points)Deposit(PA) changed from:" + Session["odeposit"].ToString() + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["obalance"].ToString(), balance) != 0)
            {
                string act = "(points) Balaance(PA) changed from:" + Session["obalance"].ToString() + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["obalancedue"].ToString(), balancedue) != 0)
            {
                string act = "(points)balance due date(PA) changed from:" + Session["obalancedue"].ToString() + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oremarks"].ToString(), remarks) != 0)
            {
                string act = "(points) Remarks changed from:" + Session["oremarks"].ToString() + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedVolume"].ToString(), USDConvertedVolume) != 0)
            {
                string act = "(points) Total Vol(USD) changed from:" + Session["oUSDConvertedVolume"].ToString() + "To:" + USDConvertedVolume;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedAdminfee"].ToString(), USDConvertedAdminfee) != 0)
            {
                string act = "(points) Total Admin fee(USD) changed from:" + Session["oUSDConvertedAdminfee"].ToString() + "To:" + USDConvertedAdminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedTax"].ToString(), USDConvertedTax) != 0)
            {
                string act = "(points) Total Tax(USD) changed from:" + Session["oUSDConvertedTax"].ToString() + "To:" + USDConvertedTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConverteddeposit"].ToString(), USDConverteddeposit) != 0)
            {
                string act = "(points) Total Deposit(USD) changed from:" + Session["oUSDConverteddeposit"].ToString() + "To:" + USDConverteddeposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
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

            int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text,   sContractdetailsID);
            int updatecontractpaUSD = Queries.UpdateContract_PA_IndianUSDConversion(USDConvertedVolume, USDConvertedAdminfee, USDConvertedTax,USDConverteddeposit, contractnoTextBox.Text, sContractdetailsID);
             int updatepointscontract = Queries.UpdateContract_Points_Indian(pts_club,pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr,contractnoTextBox.Text,sContractdetailsID);
            
            if (Queries.CheckContract_Installments_Indian_ContractNoExists(sContractdetailsID) == 1)
            {
                if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
                {
                    int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
                }
                else
                {

                    if (String.Compare(Session["ofinmonth"].ToString(), finmonth) != 0)
                    {
                        int updatefinmonth = Queries.UpdateFinanceMonth_Indian(finmonth, sContractdetailsID);
                    }
                    else
                    {
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    }

                }
            }
            else { }
            if (dealstatus == "DELETED" || dealstatus == "Deleted")
            {

                string act = "Contract No:" + contractno + "with contract details ID:" + sContractdetailsID + "Deleted from system";
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());

                int rows2 = Queries.DeleteFinance_Details_Indian(sContractdetailsID);
                int rows3 = Queries.DeleteContract_PA_Indian(sContractdetailsID);
                int rows4 = Queries.DeleteContract_Points_Indian(sContractdetailsID);
                int rows5 = Queries.DeleteContract_Trade_In_Points_Indian(sContractdetailsID);
                int rows6 = Queries.DeleteContract_Trade_In_Weeks_Indian(sContractdetailsID);
                int rows7 = Queries.DeleteContract_Indian_Deposit_Receipt(sContractdetailsID);
                int rows8 = Queries.DeleteContract_Fractional_Indian(sContractdetailsID);
                int rows9 = Queries.DeleteContract_Trade_In_Fractional_Indian(sContractdetailsID);
                int rows10 = Queries.DeleteContract_Fractional_PA_Indian(sContractdetailsID);
                int rows12 = Queries.DeleteContract_Installments_IndianRows(sContractdetailsID);
                int rows13 = Queries.DeleteContractNo_Othernamestablerows(sContractdetailsID);
                int rows14 = Queries.DeleteContract_Installments_Indian_Deleted(sContractdetailsID);
                int rows15 = Queries.DeleteContract_Logs_India(sContractdetailsID);
                int rows16 = Queries.DeleteContractTeamDetails(sContractdetailsID);
                int rows17 = Queries.DeleteCRM_details(sContractdetailsID);
                int rows18 = Queries.DeleteFinance_Breakup(sContractdetailsID);
                int rows1 = Queries.DeleteContractDetails_Indian(sContractdetailsID);
                Response.Redirect("~/Contractsite/ContractSearch.aspx");
            }
            else { }
            string msg = "Details updated for Contract :" + " " + contractno;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            LoadDocuments(sContractdetailsID, officeTextBox.Text , finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);

        }//end of points contract

            
        else if(contract== "Trade-In-Points")
        {
                DataSet dstip = Queries.LoadTradeinPointsDetails(sContractdetailsID);
 
            Session["otip_Trade_In_Details_club_resort"] = dstip.Tables[0].Rows[0]["Trade_In_Details_club_resort"].ToString();
            Session["otip_Trade_In_Details_No_rights"] = dstip.Tables[0].Rows[0]["Trade_In_Details_No_rights"].ToString();
            Session["otip_Trade_In_Details_ContNo_RCINo"] = dstip.Tables[0].Rows[0]["Trade_In_Details_ContNo_RCINo"].ToString();
            Session["otip_Trade_In_Details_Points_value"] = dstip.Tables[0].Rows[0]["Trade_In_Details_Points_value"].ToString();
            Session["otip_New_Club"] = dstip.Tables[0].Rows[0]["New_Club"].ToString();
            Session["otip_New_Club_Points_Rights"] = dstip.Tables[0].Rows[0]["New_Club_Points_Rights"].ToString();
            Session["otip_New_MemebrshipType"] = dstip.Tables[0].Rows[0]["New_MemebrshipType"].ToString();
            Session["otip_New_TotalPointsRights"] = dstip.Tables[0].Rows[0]["New_TotalPointsRights"].ToString();
            Session["otip_New_First_year_occupancy"] = dstip.Tables[0].Rows[0]["New_First_year_occupancy"].ToString();
            Session["otip_New_Tenure"] = dstip.Tables[0].Rows[0]["New_Tenure"].ToString();
            Session["otip_New_Last_year_occupancy"] = dstip.Tables[0].Rows[0]["New_Last_year_occupancy"].ToString();
            Session["otip_nopersons"] = dstip.Tables[0].Rows[0]["NoPersons"].ToString();
            Session["Actualpoints_value"] = dstip.Tables[0].Rows[0]["Actualpoints_value"].ToString();
            



            DataSet dspa = Queries.contractPA(sContractdetailsID);

            Session["onewpoints"] = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
            Session["oconversionfee"] = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
            Session["oadminfee"] = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
            Session["ototpurchprice"] = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            Session["ocgst"] = dspa.Tables[0].Rows[0]["Cgst"].ToString();
            Session["osgst"] = dspa.Tables[0].Rows[0]["Sgst"].ToString();
            Session["ototalpriceInTax"] = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            Session["odeposit"] = dspa.Tables[0].Rows[0]["Deposit"].ToString();
            Session["obalance"] = dspa.Tables[0].Rows[0]["Balance"].ToString();
            Session["obalancedue"] = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            Session["oremarks"] = dspa.Tables[0].Rows[0]["Remarks"].ToString();            
            Session["oUSDConvertedVolume"] = dspa.Tables[0].Rows[0]["USDConvertedVolume"].ToString();
            Session["oUSDConvertedAdminfee"] = dspa.Tables[0].Rows[0]["USDConvertedAdminfee"].ToString();
            Session["oUSDConvertedTax"] = dspa.Tables[0].Rows[0]["USDConvertedTax"].ToString();
            Session["oUSDConverteddeposit"] = dspa.Tables[0].Rows[0]["USDConverteddeposit"].ToString();

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
            string Actualpoints_value = tipactualptsvalueTextBox.Text;
          
                


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

            string USDConvertedVolume, USDConvertedTax, USDConvertedAdminfee, USDConverteddeposit;
            DataSet exrds = Queries.LoadExchange_Rate();
            string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();
            if (currencyDropDownList.SelectedItem.Text == "INR")
            {
                if (conversionfeeTextBox .Text == "" || conversionfeeTextBox.Text == null || conversionfeeTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(conversionfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConverteddeposit = valueamt.ToString();
                }
            }
            else
            {
                if (totpurchpriceTextBox.Text == "" || totpurchpriceTextBox.Text == null || totpurchpriceTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(totpurchpriceTextBox.Text), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text), 0);
                    USDConverteddeposit = valueamt.ToString();
                }

            }

           

               



            if (String.Compare(Session["otip_Trade_In_Details_club_resort"].ToString(), tpresort) != 0)
            {
                string act = "(trade in points) club(trade in) changed from:" + Session["otip_Trade_In_Details_club_resort"].ToString()+ "To:" + tpresort;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otip_Trade_In_Details_No_rights"].ToString(), tpnpts) != 0)
            {
                string act = "(trade in points) points rights (trade in) changed from:" + Session["otip_Trade_In_Details_No_rights"].ToString() + "To:" + tpnpts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otip_Trade_In_Details_ContNo_RCINo"].ToString(), tpcontno) != 0)
            {
                string act = "(trade in points) cont.no (trade in) changed from:" + Session["otip_Trade_In_Details_ContNo_RCINo"].ToString() + "To:" + tpcontno;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otip_Trade_In_Details_Points_value"].ToString(), tpptsval) != 0)
            {
                string act = "(trade in points)new points changed from:" + Session["otip_Trade_In_Details_Points_value"].ToString() + "To:" + tpptsval;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["Actualpoints_value"].ToString(), Actualpoints_value) != 0)
            {
                string act = "(trade in points)Actual Points changed from:" + Session["Actualpoints_value"].ToString() + "To:" + Actualpoints_value;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            
            if (String.Compare(Session["otip_New_Club"].ToString(), pts_club) != 0)
            {
                string act = "(trade in points) club name changed from:" + Session["otip_New_Club"].ToString() + "To:" + pts_club;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otip_New_Club_Points_Rights"].ToString(), pts_newpts) != 0)
            {
                string act = "(trade in points)new points changed from:" + Session["otip_New_Club_Points_Rights"].ToString() + "To:" + pts_newpts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otip_New_MemebrshipType"].ToString(), pts_entitlement) != 0)
            {
                string act = "(trade in points)entitlement changed from:" + Session["otip_New_MemebrshipType"].ToString() + "To:" + pts_entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
          

            if (String.Compare(Session["otip_New_TotalPointsRights"].ToString(), pts_totalpts) != 0)
            {
                string act = "(trade in points) total points changed from:" + Session["otip_New_TotalPointsRights"].ToString() + "To:" + pts_totalpts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otip_New_First_year_occupancy"].ToString(), pts_firstyr) != 0)
            {
                string act = "(trade in points) first yr changed from:" + Session["otip_New_First_year_occupancy"].ToString() + "To:" + pts_firstyr;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otip_New_Tenure"].ToString(), pts_Tenure) != 0)
            {
                string act = "(trade in points)tenure changed from:" + Session["otip_New_Tenure"].ToString() + "To:" + pts_Tenure;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otip_New_Last_year_occupancy"].ToString(), pts_lastyr) != 0)
            {
                string act = "(trade in points) last yr changed from:" + Session["otip_New_Last_year_occupancy"].ToString() + "To:" + pts_lastyr;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otip_nopersons"].ToString(), pts_nopersons) != 0)
            {
                string act = "(trade in points) No. Of Persons changed from:" + Session["otip_nopersons"].ToString() + "To:" + pts_nopersons;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["onewpoints"].ToString(), newpoints) != 0)
            {
                string act = "(trade in points)New points changed from:" + Session["onewpoints"].ToString() + "To:" + newpoints;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oconversionfee"].ToString(), conversionfee) != 0)
            {
                string act = "(trade in points)Conversion Fee changed from:" + Session["oconversionfee"].ToString() + "To:" + conversionfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oadminfee"].ToString(), adminfee) != 0)
            {
                string act = "(trade in points)Admin Fee changed from:" + Session["oadminfee"].ToString() + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ototpurchprice"].ToString(), totpurchprice) != 0)
            {
                string act = "(trade in points)Purchase Price changed from:" + Session["ototpurchprice"].ToString() + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ocgst"].ToString(), cgst) != 0)
            {
                string act = "(trade in points)CGST changed from:" + Session["ocgst"].ToString() + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["osgst"].ToString(), sgst) != 0)
            {
                string act = "(trade in points)SGST changed from:" + Session["osgst"].ToString() + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["ototalpriceInTax"].ToString(), totalpriceInTax) != 0)
            {
                string act = "(trade in points) Total Price including Tax (PA) changed from:" + Session["ototalpriceInTax"].ToString() + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["odeposit"].ToString(), deposit) != 0)
            {
                string act = "(trade in points)Deposit(PA) changed from:" + Session["odeposit"].ToString() + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["obalance"].ToString(), balance) != 0)
            {
                string act = "(trade in points) Balaance(PA) changed from:" + Session["obalance"].ToString() + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["obalancedue"].ToString(), balancedue) != 0)
            {
                string act = "(trade in points)balance due date(PA) changed from:" + Session["obalancedue"].ToString() + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oremarks"].ToString(), remarks) != 0)
            {
                string act = "(trade in points) Remarks changed from:" + Session["oremarks"].ToString() + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedVolume"].ToString(), USDConvertedVolume) != 0)
            {
                string act = "(trade in points) Total Vol(USD) changed from:" + Session["oUSDConvertedVolume"].ToString() + "To:" + USDConvertedVolume;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedAdminfee"].ToString(), USDConvertedAdminfee) != 0)
            {
                string act = "(trade in points) Total Admin fee(USD) changed from:" + Session["oUSDConvertedAdminfee"].ToString() + "To:" + USDConvertedAdminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedTax"].ToString(), USDConvertedTax) != 0)
            {
                string act = "(trade in points) Total Tax(USD) changed from:" + Session["oUSDConvertedTax"].ToString() + "To:" + USDConvertedTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConverteddeposit"].ToString(), USDConverteddeposit) != 0)
            {
                string act = "(trade in points) Total Deposit(USD) changed from:" + Session["oUSDConverteddeposit"].ToString() + "To:" + USDConverteddeposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
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
            int updatepointscontract = Queries.UpdateContract_Trade_In_Points_Indian( tpresort,tpnpts,tpcontno,tpptsval,pts_club, pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr, contractno,sContractdetailsID,Actualpoints_value);          
            int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractno, sContractdetailsID);
             int updatecontractpaUSD = Queries.UpdateContract_PA_IndianUSDConversion(USDConvertedVolume, USDConvertedAdminfee, USDConvertedTax, USDConverteddeposit, contractno, sContractdetailsID);
            if (Queries.CheckContract_Installments_Indian_ContractNoExists(sContractdetailsID) == 1)
            {
                if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN")
                {
                    int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
                }
                else
                {
                    // int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    if (String.Compare(Session["ofinmonth"].ToString(), finmonth) != 0)
                    {
                        int updatefinmonth = Queries.UpdateFinanceMonth_Indian(finmonth, sContractdetailsID);
                    }
                    else
                    {
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    }
                }
            }
            else { }
            if (dealstatus == "DELETED" || dealstatus == "Deleted")
            {

                string act = "Contract No:" + contractno + "with contract details ID:" + sContractdetailsID + "Deleted from system";
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());

                int rows2 = Queries.DeleteFinance_Details_Indian(sContractdetailsID);
                int rows3 = Queries.DeleteContract_PA_Indian(sContractdetailsID);
                int rows4 = Queries.DeleteContract_Points_Indian(sContractdetailsID);
                int rows5 = Queries.DeleteContract_Trade_In_Points_Indian(sContractdetailsID);
                int rows6 = Queries.DeleteContract_Trade_In_Weeks_Indian(sContractdetailsID);
                int rows7 = Queries.DeleteContract_Indian_Deposit_Receipt(sContractdetailsID);
                int rows8 = Queries.DeleteContract_Fractional_Indian(sContractdetailsID);
                int rows9 = Queries.DeleteContract_Trade_In_Fractional_Indian(sContractdetailsID);
                int rows10 = Queries.DeleteContract_Fractional_PA_Indian(sContractdetailsID);
                int rows12 = Queries.DeleteContract_Installments_IndianRows(sContractdetailsID);
                int rows13 = Queries.DeleteContractNo_Othernamestablerows(sContractdetailsID);
                int rows14 = Queries.DeleteContract_Installments_Indian_Deleted(sContractdetailsID);
                int rows15 = Queries.DeleteContract_Logs_India(sContractdetailsID);
                int rows16 = Queries.DeleteContractTeamDetails(sContractdetailsID);
                int rows17 = Queries.DeleteCRM_details(sContractdetailsID);
                int rows18 = Queries.DeleteFinance_Breakup(sContractdetailsID);
                int rows1 = Queries.DeleteContractDetails_Indian(sContractdetailsID);
                Response.Redirect("~/Contractsite/ContractSearch.aspx");
            }
            else { }
            string msg = "Details updated for Contract :" + " " + contractno;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);
        }
         else if(contract== "Trade-In-Weeks")
        {
            DataSet dstiw = Queries.LoadTradeinWeeksDetails(sContractdetailsID);
              
            Session["otiw_Trade_In_Weeks_resort"] = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_resort"].ToString();
            Session["otiw_Trade_In_Weeks_Apt"] = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Apt"].ToString();
            Session["otiw_Trade_In_Weeks_Season"] = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Season"].ToString();
            Session["otiw_Trade_In_Weeks_NoWks"] = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_NoWks"].ToString();
            Session["otiw_Trade_In_Weeks_ContNo_RCINo"] = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_ContNo_RCINo"].ToString();
            Session["otiw_Trade_In_Weeks_Points_value"] = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Points_value"].ToString();
            Session["otiw_NewPointsW_Club"] = dstiw.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
            Session["otiw_NewPointsW_Club_Points_Rights"] = dstiw.Tables[0].Rows[0]["NewPointsW_Club_Points_Rights"].ToString();
            Session["otiw_NewPointsW_MemebrshipType"] = dstiw.Tables[0].Rows[0]["NewPointsW_MemebrshipType"].ToString();
            Session["otiw_NewPointsW_Total_Points_rights"] = dstiw.Tables[0].Rows[0]["NewPointsW_Total_Points_rights"].ToString();
            Session["otiw_NewPointsW_First_year_occupancy"] = dstiw.Tables[0].Rows[0]["NewPointsW_First_year_occupancy"].ToString();
            Session["otiw_NewPointsW_Tenure"] = dstiw.Tables[0].Rows[0]["NewPointsW_Tenure"].ToString();
            Session["otiw_NewPointsW_Last_year_occupancy"] = dstiw.Tables[0].Rows[0]["NewPointsW_Last_year_occupancy"].ToString();
            Session["otiw_nopersons"] = dstiw.Tables[0].Rows[0]["NoPersons"].ToString();


            DataSet dspa = Queries.contractPA(sContractdetailsID);        

            Session["onewpoints"] = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
            Session["oconversionfee"] = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
            Session["oadminfee"] = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
            Session["ototpurchprice"] = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            Session["ocgst"] = dspa.Tables[0].Rows[0]["Cgst"].ToString();
            Session["osgst"] = dspa.Tables[0].Rows[0]["Sgst"].ToString();
            Session["ototalpriceInTax"] = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            Session["odeposit"] = dspa.Tables[0].Rows[0]["Deposit"].ToString();
            Session["obalance"] = dspa.Tables[0].Rows[0]["Balance"].ToString();
            Session["obalancedue"] = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            Session["oremarks"] = dspa.Tables[0].Rows[0]["Remarks"].ToString();
            Session["oUSDConvertedVolume"] = dspa.Tables[0].Rows[0]["USDConvertedVolume"].ToString();
            Session["oUSDConvertedAdminfee"] = dspa.Tables[0].Rows[0]["USDConvertedAdminfee"].ToString();
            Session["oUSDConvertedTax"] = dspa.Tables[0].Rows[0]["USDConvertedTax"].ToString();
            Session["oUSDConverteddeposit"] = dspa.Tables[0].Rows[0]["USDConverteddeposit"].ToString();


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
          
            string USDConvertedVolume, USDConvertedTax, USDConvertedAdminfee, USDConverteddeposit;
            DataSet exrds = Queries.LoadExchange_Rate();
            string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();
            if (currencyDropDownList.SelectedItem.Text == "INR")
            {
                if (conversionfeeTextBox.Text  == "" || conversionfeeTextBox.Text == null || conversionfeeTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(conversionfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConverteddeposit = valueamt.ToString();
                }
            }
            else
            {
                if (totpurchpriceTextBox.Text == "" || totpurchpriceTextBox.Text == null || totpurchpriceTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(totpurchpriceTextBox.Text), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text), 0);
                    USDConverteddeposit = valueamt.ToString();
                }

            }
     
        


            if (String.Compare(Session["otiw_Trade_In_Weeks_resort"].ToString(), tpresort) != 0)
            {
                string act = "(trade in weeks) club(trade in) changed from:" + Session["otiw_Trade_In_Weeks_resort"].ToString() + "To:" + tpresort;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otiw_Trade_In_Weeks_Apt"].ToString(), apt) != 0)
            {
                string act = "(trade in weeks) Apt Type(trade in) changed from:" + Session["otiw_Trade_In_Weeks_Apt"].ToString() + "To:" + apt;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otiw_Trade_In_Weeks_Season"].ToString(), season) != 0)
            {
                string act = "(trade in weeks) Season(trade in) changed from:" + Session["otiw_Trade_In_Weeks_Season"].ToString() + "To:" + season;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otiw_Trade_In_Weeks_NoWks"].ToString(), nowks) != 0)
            {
                string act = "(trade in weeks) No. Wks(trade in) changed from:" + Session["otiw_Trade_In_Weeks_NoWks"].ToString() + "To:" + nowks;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { } 
            if (String.Compare(Session["otiw_Trade_In_Weeks_ContNo_RCINo"].ToString(), tpcontno) != 0)
            {
                string act = "(trade in weeks) cont.no (trade in) changed from:" + Session["otiw_Trade_In_Weeks_ContNo_RCINo"].ToString() + "To:" + tpcontno;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiw_Trade_In_Weeks_Points_value"].ToString(), tpptsval) != 0)
            {
                string act = "(trade in weeks) points value changed from:" + Session["otiw_Trade_In_Weeks_Points_value"].ToString() + "To:" + tpptsval;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otiw_NewPointsW_Club"].ToString(), pts_club) != 0)
            {
                string act = "(trade in weeks) club name changed from:" + Session["otiw_NewPointsW_Club"].ToString() + "To:" + pts_club;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

 
            if (String.Compare(Session["otiw_NewPointsW_Club_Points_Rights"].ToString(), pts_newpts) != 0)
            {
                string act = "(trade in weeks)new points changed from:" + Session["otiw_NewPointsW_Club_Points_Rights"].ToString() + "To:" + pts_newpts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otiw_NewPointsW_MemebrshipType"].ToString(), pts_entitlement) != 0)
            {
                string act = "(trade in weeks)entitlement changed from:" + Session["otiw_NewPointsW_MemebrshipType"].ToString() + "To:" + pts_entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiw_NewPointsW_Total_Points_rights"].ToString(), pts_totalpts) != 0)
            {
                string act = "(trade in weeks) total points changed from:" + Session["otiw_NewPointsW_Total_Points_rights"].ToString() + "To:" + pts_totalpts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiw_NewPointsW_First_year_occupancy"].ToString(), pts_firstyr) != 0)
            {
                string act = "(trade in weeks) first yr changed from:" + Session["otiw_NewPointsW_First_year_occupancy"].ToString() + "To:" + pts_firstyr;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiw_NewPointsW_Tenure"].ToString(), pts_Tenure) != 0)
            {
                string act = "(trade in weeks)tenure changed from:" + Session["otiw_NewPointsW_Tenure"].ToString() + "To:" + pts_Tenure;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiw_NewPointsW_Last_year_occupancy"].ToString(), pts_lastyr) != 0)
            {
                string act = "(trade in weeks) last yr changed from:" + Session["otiw_NewPointsW_Last_year_occupancy"].ToString() + "To:" + pts_lastyr;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiw_nopersons"].ToString(), pts_nopersons) != 0)
            {
                string act = "(trade in weeks) last yr changed from:" + Session["otiw_nopersons"].ToString() + "To:" + pts_nopersons;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["onewpoints"].ToString(), newpoints) != 0)
            {
                string act = "(trade in weeks)New points changed from:" + Session["onewpoints"].ToString() + "To:" + newpoints;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oconversionfee"].ToString(), conversionfee) != 0)
            {
                string act = "(trade in weeks)Conversion Fee changed from:" + Session["oconversionfee"].ToString() + "To:" + conversionfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oadminfee"].ToString(), adminfee) != 0)
            {
                string act = "(trade in weeks)Admin Fee changed from:" + Session["oadminfee"].ToString() + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ototpurchprice"].ToString(), totpurchprice) != 0)
            {
                string act = "(trade in weeks)Purchase Price changed from:" + Session["ototpurchprice"].ToString() + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ocgst"].ToString(), cgst) != 0)
            {
                string act = "(trade in weeks)CGST changed from:" + Session["ocgst"].ToString() + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["osgst"].ToString(), sgst) != 0)
            {
                string act = "(trade in weeks)SGST changed from:" + Session["osgst"].ToString() + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["ototalpriceInTax"].ToString(), totalpriceInTax) != 0)
            {
                string act = "(trade in weeks) Total Price including Tax (PA) changed from:" + Session["ototalpriceInTax"].ToString() + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["odeposit"].ToString(), deposit) != 0)
            {
                string act = "(trade in weeks)Deposit(PA) changed from:" + Session["odeposit"].ToString() + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["obalance"].ToString(), balance) != 0)
            {
                string act = "(trade in weeks) Balaance(PA) changed from:" + Session["obalance"].ToString() + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["obalancedue"].ToString(), balancedue) != 0)
            {
                string act = "(trade in weeks)balance due date(PA) changed from:" + Session["obalancedue"].ToString() + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oremarks"].ToString(), remarks) != 0)
            {
                string act = "(trade in weeks) Remarks changed from:" + Session["oremarks"].ToString() + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedVolume"].ToString(), USDConvertedVolume) != 0)
            {
                string act = "(trade in weeks) Total Vol(USD) changed from:" + Session["oUSDConvertedVolume"].ToString() + "To:" + USDConvertedVolume;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedAdminfee"].ToString(), USDConvertedAdminfee) != 0)
            {
                string act = "(trade in weeks) Total Admin fee(USD) changed from:" + Session["oUSDConvertedAdminfee"].ToString() + "To:" + USDConvertedAdminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedTax"].ToString(), USDConvertedTax) != 0)
            {
                string act = "(trade in weeks) Total Tax(USD) changed from:" + Session["oUSDConvertedTax"].ToString() + "To:" + USDConvertedTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConverteddeposit"].ToString(), USDConverteddeposit) != 0)
            {
                string act = "(trade in weeks) Total Deposit(USD) changed from:" + Session["oUSDConverteddeposit"].ToString() + "To:" + USDConverteddeposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
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

         

            int updatepointscontract = Queries.UpdateContract_Trade_In_Weeks_Indian(tpresort, apt, season, nowks, tpcontno, tpptsval, pts_club, pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr, contractnoTextBox.Text,sContractdetailsID);
             int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractno, sContractdetailsID);
            int updatecontractpaUSD = Queries.UpdateContract_PA_IndianUSDConversion(USDConvertedVolume, USDConvertedAdminfee, USDConvertedTax, USDConverteddeposit, contractno, sContractdetailsID);
            if (Queries.CheckContract_Installments_Indian_ContractNoExists(sContractdetailsID) == 1)
            {
                if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
                {
                    int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
                }
                else
                {

                    if (String.Compare(Session["ofinmonth"].ToString(), finmonth) != 0)
                    {
                        int updatefinmonth = Queries.UpdateFinanceMonth_Indian(finmonth, sContractdetailsID);
                    }
                    else
                    {
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    }

                }
            }
            else { }
            if (dealstatus == "DELETED" || dealstatus == "Deleted")
            {

                string act = "Contract No:" + contractno + "with contract details ID:" + sContractdetailsID+ "Deleted from system";
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());

                int rows2 = Queries.DeleteFinance_Details_Indian(sContractdetailsID);
                int rows3 = Queries.DeleteContract_PA_Indian(sContractdetailsID);
                int rows4 = Queries.DeleteContract_Points_Indian(sContractdetailsID);
                int rows5 = Queries.DeleteContract_Trade_In_Points_Indian(sContractdetailsID);
                int rows6 = Queries.DeleteContract_Trade_In_Weeks_Indian(sContractdetailsID);
                int rows7 = Queries.DeleteContract_Indian_Deposit_Receipt(sContractdetailsID);
                int rows8 = Queries.DeleteContract_Fractional_Indian(sContractdetailsID);
                int rows9 = Queries.DeleteContract_Trade_In_Fractional_Indian(sContractdetailsID);
                int rows10 = Queries.DeleteContract_Fractional_PA_Indian(sContractdetailsID);
                int rows12 = Queries.DeleteContract_Installments_IndianRows(sContractdetailsID);
                int rows13 = Queries.DeleteContractNo_Othernamestablerows(sContractdetailsID);
                int rows14 = Queries.DeleteContract_Installments_Indian_Deleted(sContractdetailsID);
                int rows15 = Queries.DeleteContract_Logs_India(sContractdetailsID);
                int rows16 = Queries.DeleteContractTeamDetails(sContractdetailsID);
                int rows17 = Queries.DeleteCRM_details(sContractdetailsID);
                int rows18 = Queries.DeleteFinance_Breakup(sContractdetailsID);
                int rows1 = Queries.DeleteContractDetails_Indian(sContractdetailsID);
                Response.Redirect("~/Contractsite/ContractSearch.aspx");
            }
            else { }
            string msg = "Details updated for Contract :" + " " + contractno;
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);
        }
        else if (contract == "Fractional")
        {
            DataSet dstif = Queries.loadtradeinfractional(sContractdetailsID);

            Session["otiresort"] = dstif.Tables[0].Rows[0]["resort"].ToString();
            Session["otifresidence_no"] = dstif.Tables[0].Rows[0]["residence_no"].ToString();
            Session["otifresidence_type"] = dstif.Tables[0].Rows[0]["residence_type"].ToString();
            Session["otiffractional_interest"] = dstif.Tables[0].Rows[0]["fractional_interest"].ToString();
            Session["otifentitlement"] = dstif.Tables[0].Rows[0]["entitlement"].ToString();
            Session["otiffirstyear_Occupancy"] = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
            Session["otiftenure"] = dstif.Tables[0].Rows[0]["tenure"].ToString();
            Session["otiflastyear_Occupancy"] = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();
            Session["otifleaseback"] = dstif.Tables[0].Rows[0]["leaseback"].ToString();
            Session["otifMc_Charges"] = dstif.Tables[0].Rows[0]["Mc_Charges"].ToString();

            
         


                         

            DataSet dsfpa = Queries.LoadfractionalPA(sContractdetailsID);     
            Session["ofctAdmission_fees"] = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
            Session["ofctadministration_fees"] = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
            Session["ofctCgst"] = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
            Session["ofctSgst"] = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
            Session["ofctTotal_Purchase_Price"] = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            Session["ofctTotal_Price_Including_Tax"] = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            Session["ofctDeposit"] = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
            Session["ofctBalance"] = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
            Session["ofctBalance_Due_Dates"] = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            Session["ofctRemarks"] = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();
            Session["otradeinvalue"] = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
            Session["ototalvalue"] = dsfpa.Tables[0].Rows[0]["Total_value"].ToString();
            Session["oFoldVolume"] = dsfpa.Tables[0].Rows[0]["FoldVolume"].ToString();
            Session["oFoldadminfee"] = dsfpa.Tables[0].Rows[0]["Foldadminfee"].ToString();
            Session["oFoldTotalTax"] = dsfpa.Tables[0].Rows[0]["FoldTotalTax"].ToString();
            Session["oFoldDeposit"] = dsfpa.Tables[0].Rows[0]["FoldDeposit"].ToString();
            Session["oFusdoldvolume"] = dsfpa.Tables[0].Rows[0]["Fusdoldvolume"].ToString();
            Session["oFusdoldadminfee"] = dsfpa.Tables[0].Rows[0]["Fusdoldadminfee"].ToString();
            Session["oFusdoldtax"] = dsfpa.Tables[0].Rows[0]["Fusdoldtax"].ToString();
            Session["oFusdolddeposit"] = dsfpa.Tables[0].Rows[0]["Fusdolddeposit"].ToString();
            Session["oUSDConvertedFVolume"] = dsfpa.Tables[0].Rows[0]["USDConvertedFVolume"].ToString();
            Session["oUSDConvertedFAdminfee"] = dsfpa.Tables[0].Rows[0]["USDConvertedFAdminfee"].ToString();
            Session["oUSDConvertedFTax"] = dsfpa.Tables[0].Rows[0]["USDConvertedFTax"].ToString();
            Session["oUSDConvertedFdeposit"] = dsfpa.Tables[0].Rows[0]["USDConvertedFdeposit"].ToString();


 
            string resort = fwresortDropDownList.SelectedItem.Text;
            string residence_no = fwresidencenoDropDownList.SelectedItem.Text;
            string residence_type = fwresidencetypeDropDownList.SelectedItem.Text;
            string fractional_interest = fwfractIntDropDownList.SelectedItem.Text;
            string entitlement = fwentitlementDropDownList.SelectedItem.Text;
            string firstyear_Occupancy = fwfirstyrTextBox.Text;
            string tenure = fwtenureTextBox.Text;
            string lastyear_Occupancy = fwlastyrTextBox.Text;
        
           
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

            string USDConvertedVolume, USDConvertedTax, USDConvertedAdminfee, USDConverteddeposit;
            DataSet exrds = Queries.LoadExchange_Rate();
            string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();
            if (currencyDropDownList.SelectedItem.Text == "INR")
            {
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (AdministrationFeesTextBox.Text == "" || AdministrationFeesTextBox.Text == null || AdministrationFeesTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(AdministrationFeesTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConverteddeposit = valueamt.ToString();
                }
            }
            else
            {
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (AdministrationFeesTextBox.Text == "" || AdministrationFeesTextBox.Text == null || AdministrationFeesTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(AdministrationFeesTextBox.Text), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text), 0);
                    USDConverteddeposit = valueamt.ToString();
                }
            }

          

             
           

            
            if (String.Compare(Session["otiRESORT"].ToString(), resort) != 0)
            {
                string act = "(fractional) points value changed from:" + Session["otiRESORT"].ToString() + "To:" + resort;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
     
            if (String.Compare(Session["otifresidence_no"].ToString(), residence_no) != 0)
            {
                string act = "(fractional) residence_no value changed from:" + Session["otifresidence_no"].ToString() + "To:" + residence_no;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otifresidence_type"].ToString(), residence_type) != 0)
            {
                string act = "(fractional) residence_type value changed from:" + Session["otifresidence_type"].ToString() + "To:" + residence_type;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiffractional_interest"].ToString(), fractional_interest) != 0)
            {
                string act = "(fractional) fractional_interest value changed from:" + Session["otiffractional_interest"].ToString() + "To:" + fractional_interest;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otifentitlement"].ToString(), entitlement) != 0)
            {
                string act = "(fractional) Entitlement value changed from:" + Session["otifentitlement"].ToString() + "To:" + entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiffirstyear_Occupancy"].ToString(), firstyear_Occupancy) != 0)
            {
                string act = "(fractional) First Yr Occupancy value changed from:" + Session["otiffirstyear_Occupancy"].ToString() + "To:" + firstyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiftenure"].ToString(), tenure) != 0)
            {
                string act = "(fractional) Tenure changed from:" + Session["otiftenure"].ToString() + "To:" + tenure;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiflastyear_Occupancy"].ToString(), lastyear_Occupancy) != 0)
            {
                string act = "(fractional) Last Yr Occupancy value changed from:" + Session["otiflastyear_Occupancy"].ToString() + "To:" + lastyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctAdmission_fees"].ToString(), adminfee) != 0)
            {
                string act = "(fractional)Admission fees changed from:" + Session["ofctAdmission_fees"].ToString() + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctadministration_fees"].ToString(), oAdministrationFees) != 0)
            {
                string act = "(fractional)Administration Fees changed from:" + Session["ofctadministration_fees"].ToString() + "To:" + oAdministrationFees;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctCgst"].ToString(), cgst) != 0)
            {
                string act = "(fractional)CGST amt changed from:" + Session["ofctCgst"].ToString() + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctSgst"].ToString(), sgst) != 0)
            {
                string act = "(fractional) SGST amt changed from:" + Session["ofctSgst"].ToString() + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctTotal_Purchase_Price"].ToString(), totpurchprice) != 0)
            {
                string act = "(fractional)Total purchase price changed from:" + Session["ofctTotal_Purchase_Price"].ToString() + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctTotal_Price_Including_Tax"].ToString(), totalpriceInTax) != 0)
            {
                string act = "(fractional)Total price In. Tax changed from:" + Session["ofctTotal_Price_Including_Tax"].ToString() + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctDeposit"].ToString(), deposit) != 0)
            {
                string act = "(fractional)Deposit changed from:" + Session["ofctDeposit"].ToString() + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctBalance"].ToString(), balance) != 0)
            {
                string act = "(fractional)balance Rate changed from:" + Session["ofctBalance"].ToString() + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctBalance_Due_Dates"].ToString(), balancedue) != 0)
            {
                string act = "(fractional)balance due changed from:" + Session["ofctBalance_Due_Dates"].ToString() + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctRemarks"].ToString(), remarks) != 0)
            {
                string act = "(fractional)remarks changed from:" + Session["ofctRemarks"].ToString() + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

          
            if (String.Compare(Session["oUSDConvertedFVolume"].ToString(), USDConvertedVolume) != 0)
            {
                string act = "(fractional)remarks changed from:" + Session["oUSDConvertedFVolume"].ToString() + "To:" + USDConvertedVolume;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedFAdminfee"].ToString(), USDConvertedAdminfee) != 0)
            {
                string act = "(fractional)remarks changed from:" + Session["oUSDConvertedFAdminfee"].ToString() + "To:" + USDConvertedAdminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedFTax"].ToString(), USDConvertedTax) != 0)
            {
                string act = "(fractional)remarks changed from:" + Session["oUSDConvertedFTax"].ToString() + "To:" + USDConvertedTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedFdeposit"].ToString(), USDConverteddeposit) != 0)
            {
                string act = "(fractional)remarks changed from:" + Session["oUSDConvertedFdeposit"].ToString() + "To:" + USDConverteddeposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
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

 
             int updatecontractPA = Queries.UpdateContract_FractionalPA_Indian(adminfee, oAdministrationFees, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractno,"","", sContractdetailsID);
             int updatefractionalcontract = Queries.UpdateContract_Fractional_Indian(resort, residence_no, residence_type, fractional_interest, entitlement, firstyear_Occupancy, tenure, lastyear_Occupancy,"", mcfees, contractno, sContractdetailsID);
            int updatecontractpaUSD = Queries.UpdateContract_Fractional_PA_IndianUSDConversion(USDConvertedVolume, USDConvertedAdminfee, USDConvertedTax, USDConverteddeposit, contractno, sContractdetailsID);
            if (Queries.CheckContract_Installments_Indian_ContractNoExists(sContractdetailsID) == 1)
            {
                if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
                {
                    int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
                }
                else
                {

                    if (String.Compare(Session["ofinmonth"].ToString(), finmonth) != 0)
                    {
                        int updatefinmonth = Queries.UpdateFinanceMonth_Indian(finmonth, sContractdetailsID);
                    }
                    else
                    {
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    }

                }
            }
            if (dealstatus == "DELETED" || dealstatus == "Deleted")
            {

                string act = "Contract No:" + contractno + "with contract details ID:" + sContractdetailsID + "Deleted from system";
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());

                int rows2 = Queries.DeleteFinance_Details_Indian(sContractdetailsID);
                int rows3 = Queries.DeleteContract_PA_Indian(sContractdetailsID);
                int rows4 = Queries.DeleteContract_Points_Indian(sContractdetailsID);
                int rows5 = Queries.DeleteContract_Trade_In_Points_Indian(sContractdetailsID);
                int rows6 = Queries.DeleteContract_Trade_In_Weeks_Indian(sContractdetailsID);
                int rows7 = Queries.DeleteContract_Indian_Deposit_Receipt(sContractdetailsID);
                int rows8 = Queries.DeleteContract_Fractional_Indian(sContractdetailsID);
                int rows9 = Queries.DeleteContract_Trade_In_Fractional_Indian(sContractdetailsID);
                int rows10 = Queries.DeleteContract_Fractional_PA_Indian(sContractdetailsID);
                int rows12 = Queries.DeleteContract_Installments_IndianRows(sContractdetailsID);
                int rows13 = Queries.DeleteContractNo_Othernamestablerows(sContractdetailsID);
                int rows14 = Queries.DeleteContract_Installments_Indian_Deleted(sContractdetailsID);
                int rows15 = Queries.DeleteContract_Logs_India(sContractdetailsID);
                int rows16 = Queries.DeleteContractTeamDetails(sContractdetailsID);
                int rows17 = Queries.DeleteCRM_details(sContractdetailsID);
                int rows18 = Queries.DeleteFinance_Breakup(sContractdetailsID);
                int rows1 = Queries.DeleteContractDetails_Indian(sContractdetailsID);
                Response.Redirect("~/Contractsite/ContractSearch.aspx");
            }
            else { }
            string msg = "Details updated for Contract :" + " " + contractno;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);

        }

        else if (contract == "Trade-In-Fractionals")
        {
            DataSet dstif = Queries.loadtradeinfractional(sContractdetailsID);

            Session["otiresort"] = dstif.Tables[0].Rows[0]["resort"].ToString();
            Session["otifresidence_no"] = dstif.Tables[0].Rows[0]["residence_no"].ToString();
            Session["otifresidence_type"] = dstif.Tables[0].Rows[0]["residence_type"].ToString();
            Session["otiffractional_interest"] = dstif.Tables[0].Rows[0]["fractional_interest"].ToString();
            Session["otifentitlement"] = dstif.Tables[0].Rows[0]["entitlement"].ToString();
            Session["otiffirstyear_Occupancy"] = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
            Session["otiftenure"] = dstif.Tables[0].Rows[0]["tenure"].ToString();
            Session["otiflastyear_Occupancy"] = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();
            Session["otifleaseback"] = dstif.Tables[0].Rows[0]["leaseback"].ToString();
            Session["otifMc_Charges"] = dstif.Tables[0].Rows[0]["Mc_Charges"].ToString();

            Session["otifOldcontracttype"] = dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString();
            Session["otifRESORT"] = dstif.Tables[0].Rows[0]["tradeinresort"].ToString();
            Session["otifAPT_TYPE"] = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString();
            Session["otifSEASON"] = dstif.Tables[0].Rows[0]["SEASON"].ToString();
            Session["otifNO_WEEKS"] = dstif.Tables[0].Rows[0]["NO_WEEKS"].ToString();
            Session["otifNO_POINTS"] = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
            Session["otifPOINTS_VALUE"] = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();
            Session["otifoldContract_No"] = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();




            DataSet dsfpa = Queries.LoadfractionalPA(ContractdetailsIDTextBox.Text);
            Session["ofctAdmission_fees"] = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
            Session["ofctadministration_fees"] = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
            Session["ofctCgst"] = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
            Session["ofctSgst"] = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
            Session["ofctTotal_Purchase_Price"] = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
            Session["ofctTotal_Price_Including_Tax"] = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
            Session["ofctDeposit"] = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
            Session["ofctBalance"] = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
            Session["ofctBalance_Due_Dates"] = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
            Session["ofctRemarks"] = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();
            Session["otradeinvalue"] = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
            Session["ototalvalue"] = dsfpa.Tables[0].Rows[0]["Total_value"].ToString();
            Session["oFoldVolume"] = dsfpa.Tables[0].Rows[0]["FoldVolume"].ToString();
            Session["oFoldadminfee"] = dsfpa.Tables[0].Rows[0]["Foldadminfee"].ToString();
            Session["oFoldTotalTax"] = dsfpa.Tables[0].Rows[0]["FoldTotalTax"].ToString();
            Session["oFoldDeposit"] = dsfpa.Tables[0].Rows[0]["FoldDeposit"].ToString();
            Session["oFusdoldvolume"] = dsfpa.Tables[0].Rows[0]["Fusdoldvolume"].ToString();
            Session["oFusdoldadminfee"] = dsfpa.Tables[0].Rows[0]["Fusdoldadminfee"].ToString();
            Session["oFusdoldtax"] = dsfpa.Tables[0].Rows[0]["Fusdoldtax"].ToString();
            Session["oFusdolddeposit"] = dsfpa.Tables[0].Rows[0]["Fusdolddeposit"].ToString();
            Session["oUSDConvertedFVolume"] = dsfpa.Tables[0].Rows[0]["USDConvertedFVolume"].ToString();
            Session["oUSDConvertedFAdminfee"] = dsfpa.Tables[0].Rows[0]["USDConvertedFAdminfee"].ToString();
            Session["oUSDConvertedFTax"] = dsfpa.Tables[0].Rows[0]["USDConvertedFTax"].ToString();
            Session["oUSDConvertedFdeposit"] = dsfpa.Tables[0].Rows[0]["USDConvertedFdeposit"].ToString();



            string tpresort = tnmresortTextBox.Text;
            string apt = tnmapttypeTextBox.Text;
            
            string season = Request.Form[tnmseasonDropDownList.UniqueID];
            if (season == null || season == "")
            {
                season = "";
            }
            else
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

            string USDConvertedVolume, USDConvertedTax, USDConvertedAdminfee, USDConverteddeposit;
            DataSet exrds = Queries.LoadExchange_Rate();
            string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();
            if (currencyDropDownList.SelectedItem.Text == "INR")
            {
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (AdministrationFeesTextBox.Text == "" || AdministrationFeesTextBox.Text == null || AdministrationFeesTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(AdministrationFeesTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)) / Convert.ToDouble(dollarrate), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text) / Convert.ToDouble(dollarrate), 0);
                    USDConverteddeposit = valueamt.ToString();
                }
            }
            else
            {
                if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
                {
                    USDConvertedVolume = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text), 0);
                    USDConvertedVolume = valueamt.ToString();
                }
                if (AdministrationFeesTextBox.Text == "" || AdministrationFeesTextBox.Text == null || AdministrationFeesTextBox.Text == "NaN")
                {
                    USDConvertedAdminfee = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(AdministrationFeesTextBox.Text), 0);
                    USDConvertedAdminfee = valueamt.ToString();
                }
                if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
                {
                    USDConvertedTax = "0";
                }
                else
                {
                    double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)), 0);
                    USDConvertedTax = valueamt.ToString();
                }
                if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
                {
                    USDConverteddeposit = "0";
                }
                else
                {
                    double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text), 0);
                    USDConverteddeposit = valueamt.ToString();
                }
            }






            if (String.Compare(Session["otifOldcontracttype"].ToString(), ocontracttype) != 0)
            {
                string act = "(trade in fractional) Old Contract Type changed from:" + Session["otifOldcontracttype"].ToString() + "To:" + ocontracttype;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otifRESORT"].ToString(), tpresort) != 0)
            {
                string act = "(trade in fractional) Resort(trade in) changed from:" + Session["otifRESORT"].ToString() + "To:" + tpresort;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otifAPT_TYPE"].ToString(), apt) != 0)
            {
                string act = "(trade in fractional) Apt Type(trade in) changed from:" + Session["otifAPT_TYPE"].ToString() + "To:" + apt;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otifSEASON"].ToString(), season) != 0)
            {
                string act = "(trade in fractional) Season(trade in) changed from:" + Session["otifSEASON"].ToString() + "To:" + season;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(Session["otifNO_WEEKS"].ToString(), nowks) != 0)
            {
                string act = "(trade in fractional) No. Wks(trade in) changed from:" + Session["otifNO_WEEKS"].ToString() + "To:" + nowks;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otifoldContract_No"].ToString(), tpcontno) != 0)
            {
                string act = "(trade in fractional) cont.no (trade in) changed from:" + Session["otifoldContract_No"].ToString() + "To:" + tpcontno;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otifNO_POINTS"].ToString(), tpptsval) != 0)
            {
                string act = "(trade in fractional)no.of points value changed from:" + Session["otifNO_POINTS"].ToString() + "To:" + tpnopts;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otifPOINTS_VALUE"].ToString(), tpptsval) != 0)
            {
                string act = "(trade in fractional) points value changed from:" + Session["otifPOINTS_VALUE"].ToString() + "To:" + tpptsval;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiRESORT"].ToString(), resort) != 0)
            {
                string act = "(trade in fractional) points value changed from:" + Session["otiRESORT"].ToString() + "To:" + resort;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(Session["otifresidence_no"].ToString(), residence_no) != 0)
            {
                string act = "(trade in fractional) residence_no value changed from:" + Session["otifresidence_no"].ToString() + "To:" + residence_no;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otifresidence_type"].ToString(), residence_type) != 0)
            {
                string act = "(trade in fractional) residence_type value changed from:" + Session["otifresidence_type"].ToString() + "To:" + residence_type;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiffractional_interest"].ToString(), fractional_interest) != 0)
            {
                string act = "(trade in fractional) fractional_interest value changed from:" + Session["otiffractional_interest"].ToString() + "To:" + fractional_interest;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otifentitlement"].ToString(), entitlement) != 0)
            {
                string act = "(trade in fractional) Entitlement value changed from:" + Session["otifentitlement"].ToString() + "To:" + entitlement;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiffirstyear_Occupancy"].ToString(), firstyear_Occupancy) != 0)
            {
                string act = "(trade in fractional) First Yr Occupancy value changed from:" + Session["otiffirstyear_Occupancy"].ToString() + "To:" + firstyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiftenure"].ToString(), tenure) != 0)
            {
                string act = "(trade in fractional) Tenure changed from:" + Session["otiftenure"].ToString() + "To:" + tenure;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["otiflastyear_Occupancy"].ToString(), lastyear_Occupancy) != 0)
            {
                string act = "(trade in fractional) Last Yr Occupancy value changed from:" + Session["otiflastyear_Occupancy"].ToString() + "To:" + lastyear_Occupancy;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctAdmission_fees"].ToString(), adminfee) != 0)
            {
                string act = "(trade in fractional)Admission fees changed from:" + Session["ofctAdmission_fees"].ToString() + "To:" + adminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctadministration_fees"].ToString(), oAdministrationFees) != 0)
            {
                string act = "(trade in fractional)Administration Fees changed from:" + Session["ofctadministration_fees"].ToString() + "To:" + oAdministrationFees;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctCgst"].ToString(), cgst) != 0)
            {
                string act = "(trade in fractional)CGST amt changed from:" + Session["ofctCgst"].ToString() + "To:" + cgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctSgst"].ToString(), sgst) != 0)
            {
                string act = "(trade in fractional) SGST amt changed from:" + Session["ofctSgst"].ToString() + "To:" + sgst;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctTotal_Purchase_Price"].ToString(), totpurchprice) != 0)
            {
                string act = "(trade in fractional)Total purchase price changed from:" + Session["ofctTotal_Purchase_Price"].ToString() + "To:" + totpurchprice;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctTotal_Price_Including_Tax"].ToString(), totalpriceInTax) != 0)
            {
                string act = "(trade in fractional)Total price In. Tax changed from:" + Session["ofctTotal_Price_Including_Tax"].ToString() + "To:" + totalpriceInTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctDeposit"].ToString(), deposit) != 0)
            {
                string act = "(trade in fractional)Deposit changed from:" + Session["ofctDeposit"].ToString() + "To:" + deposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctBalance"].ToString(), balance) != 0)
            {
                string act = "(trade in fractional)balance Rate changed from:" + Session["ofctBalance"].ToString() + "To:" + balance;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctBalance_Due_Dates"].ToString(), balancedue) != 0)
            {
                string act = "(trade in fractional)balance due changed from:" + Session["ofctBalance_Due_Dates"].ToString() + "To:" + balancedue;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["ofctRemarks"].ToString(), remarks) != 0)
            {
                string act = "(trade in fractional)remarks changed from:" + Session["ofctRemarks"].ToString() + "To:" + remarks;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(Session["oUSDConvertedFVolume"].ToString(), USDConvertedVolume) != 0)
            {
                string act = "(trade in fractional)remarks changed from:" + Session["oUSDConvertedFVolume"].ToString() + "To:" + USDConvertedVolume;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedFAdminfee"].ToString(), USDConvertedAdminfee) != 0)
            {
                string act = "(trade in fractional)remarks changed from:" + Session["oUSDConvertedFAdminfee"].ToString() + "To:" + USDConvertedAdminfee;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedFTax"].ToString(), USDConvertedTax) != 0)
            {
                string act = "(trade in fractional)remarks changed from:" + Session["oUSDConvertedFTax"].ToString() + "To:" + USDConvertedTax;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(Session["oUSDConvertedFdeposit"].ToString(), USDConverteddeposit) != 0)
            {
                string act = "(trade in fractional)remarks changed from:" + Session["oUSDConvertedFdeposit"].ToString() + "To:" + USDConverteddeposit;
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());
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


            int updatecontractPA = Queries.UpdateContract_FractionalPA_Indian(adminfee, oAdministrationFees, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractno, "", "", sContractdetailsID);
            int updatefractionalcontract = Queries.UpdateContract_Fractional_Indian(resort, residence_no, residence_type, fractional_interest, entitlement, firstyear_Occupancy, tenure, lastyear_Occupancy, "", mcfees, contractno, sContractdetailsID);
            int updatepointscontract = Queries.UpdateContract_Trade_In_Fractional_Indian(ocontracttype, tpresort, apt, season, nowks, tpnopts, tpptsval, tpcontno, contractno, sContractdetailsID);
            int updatecontractpaUSD = Queries.UpdateContract_Fractional_PA_IndianUSDConversion(USDConvertedVolume, USDConvertedAdminfee, USDConvertedTax, USDConverteddeposit, contractno, sContractdetailsID);
            if (Queries.CheckContract_Installments_Indian_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
            {
                if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
                {
                    int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
                }
                else
                {

                    if (String.Compare(Session["ofinmonth"].ToString(), finmonth) != 0)
                    {
                        int updatefinmonth = Queries.UpdateFinanceMonth_Indian(finmonth, sContractdetailsID);
                    }
                    else
                    {
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    }

                }
            }
            if (dealstatus == "DELETED" || dealstatus == "Deleted")
            {

                string act = "Contract No:" + contractnoTextBox.Text + "with contract details ID:" + sContractdetailsID+ "Deleted from system";
                int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), sContractdetailsID, act, user, DateTime.Now.ToString());

                int rows2 = Queries.DeleteFinance_Details_Indian(sContractdetailsID);
                int rows3 = Queries.DeleteContract_PA_Indian(sContractdetailsID);
                int rows4 = Queries.DeleteContract_Points_Indian(sContractdetailsID);
                int rows5 = Queries.DeleteContract_Trade_In_Points_Indian(sContractdetailsID);
                int rows6 = Queries.DeleteContract_Trade_In_Weeks_Indian(sContractdetailsID);
                int rows7 = Queries.DeleteContract_Indian_Deposit_Receipt(sContractdetailsID);
                int rows8 = Queries.DeleteContract_Fractional_Indian(sContractdetailsID);
                int rows9 = Queries.DeleteContract_Trade_In_Fractional_Indian(sContractdetailsID);
                int rows10 = Queries.DeleteContract_Fractional_PA_Indian(sContractdetailsID);
                int rows12 = Queries.DeleteContract_Installments_IndianRows(sContractdetailsID);
                int rows13 = Queries.DeleteContractNo_Othernamestablerows(sContractdetailsID);
                int rows14 = Queries.DeleteContract_Installments_Indian_Deleted(sContractdetailsID);
                int rows15 = Queries.DeleteContract_Logs_India(sContractdetailsID);
                int rows16 = Queries.DeleteContractTeamDetails(sContractdetailsID);
                int rows17 = Queries.DeleteCRM_details(sContractdetailsID);
                int rows18 = Queries.DeleteFinance_Breakup(sContractdetailsID);
                int rows1 = Queries.DeleteContractDetails_Indian(sContractdetailsID);
                Response.Redirect("~/Contractsite/ContractSearch.aspx");
            }
            else { }
            string msg = "Details updated for Contract :" + " " + contractno;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
            Response.Redirect(Request.RawUrl);

        }






    }

    //public void CreateButton1_Click(object sender, EventArgs e)
    //{

    //    string sContractdetailsID = (string)Session["ContractdetailsID"];
    //    string user = (string)Session["username"];
    //    DataSet dsct = Queries.LoadContractDetails_ID(sContractdetailsID);// (ContractdetailsIDTextBox.Text);

    //    Session["contractno"] = dsct.Tables[0].Rows[0]["contractno"].ToString();
    //    Session["ocsalesrep"] = dsct.Tables[0].Rows[0]["Sales_Rep"].ToString();
    //    Session["ocTomgr"] = dsct.Tables[0].Rows[0]["TO_Manager"].ToString();
    //    Session["obuttonup"] = dsct.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
    //    Session["odealdate"] = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["DealRegistered_Date"]);
    //    Session["odealstatus"] = dsct.Tables[0].Rows[0]["DealStatus"].ToString();
    //    Session["oContractUpdatedDate"] = dsct.Tables[0].Rows[0]["Contract_UpdatedDate"].ToString();
    //    Session["omcwv"] = dsct.Tables[0].Rows[0]["MCWaiver"].ToString();
    //    Session["ofinancedetails"] = dsct.Tables[0].Rows[0]["Finance_Details"].ToString();
    //    Session["ocontract_Remark"] = dsct.Tables[0].Rows[0]["Contract_Remark"].ToString();
    //    Session["opan"] = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
    //    Session["oadhar"] = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
    //    Session["omcfees"] = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
    //    Session["omcdate"] = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
    //    Session["omemberfee"] = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
    //    Session["omemebercgst"] = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
    //    Session["omembersgst"] = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
    //    Session["ocanxcontno"] = dsct.Tables[0].Rows[0]["CanxContractNo"].ToString();
    //    Session["ocanxdate"] = dsct.Tables[0].Rows[0]["Contract_Canx_date"].ToString();
    //    Session["oloanbuofficer"] = dsct.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
    //    Session["ocogstin"] = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
    //    Session["ocompanypano"] = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
    //    Session["odealweekno"] = Convert.ToInt32(dsct.Tables[0].Rows[0]["dealweekno"]);
    //    Session["odeckdetails"] = dsct.Tables[0].Rows[0]["deckdetails"].ToString();
    //    Session["odeckremark"] = dsct.Tables[0].Rows[0]["deckremark"].ToString();
    //    Session["ocontractcomment"] = dsct.Tables[0].Rows[0]["Contract_comment"].ToString();
    //    Session["obu6"] = dsct.Tables[0].Rows[0]["BU_A6"].ToString();
    //    Session["oupdowngrade"] = dsct.Tables[0].Rows[0]["Updowngrade"].ToString();

    //    DataSet dsptsf = Queries.LoadFinanceContractDetails(sContractdetailsID);// (ContractdetailsIDTextBox.Text);
    //    Session["ocurrency"] = dsptsf.Tables[0].Rows[0]["currency"].ToString();
    //    Session["oaffiliate"] = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
    //    Session["ototalintax"] = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
    //    Session["odepamt"] = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
    //    Session["obalpayable"] = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
    //    Session["odepbal"] = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
    //    Session["ototalbalance"] = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
    //    Session["opaymethod"] = dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString();
    //    Session["onoinstallment"] = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
    //    Session["oinstallment"] = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
    //    Session["ofinancemethod"] = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();
    //    Session["oFinanceno"] = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
    //    Session["oisgtrate"] = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
    //    Session["ointerestrate"] = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
    //    Session["ofindocfee"] = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
    //    Session["oigstamt"] = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
    //    Session["onoemi"] = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
    //    Session["oemiamt"] = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
    //    Session["ofinmonth"] = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
    //    Session["ooldLoanAgreement"] = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
    //    Session["oregcollectionterm"] = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
    //    Session["oregcollamt"] = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
    //    Session["obaladepamtdate"] = dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString();
    //    Session["ooldloanamt "] = dsptsf.Tables[0].Rows[0]["Old_Loan_Amount"].ToString();


       




    //    ocompanypano = dsct.Tables[0].Rows[0]["Company_PanNo"].ToString();
    //    DataSet dspr = Queries.LoadProfielDetailsFull(ProfileID);
    //    ocompanyname = dspr.Tables[0].Rows[0]["Company_Name"].ToString();

    //    /*   ocontractno = dsct.Tables[0].Rows[0]["contractno"].ToString();
    //       wkno = Convert.ToInt32(dsct.Tables[0].Rows[0]["dealweekno"]);
    //       ocsalesrep = dsct.Tables[0].Rows[0]["Sales_Rep"].ToString();
    //       ocTomgr = dsct.Tables[0].Rows[0]["TO_Manager"].ToString();
    //       obuttonup = dsct.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
    //       odealdate = String.Format("{0:dd-MM-yyyy}", dsct.Tables[0].Rows[0]["DealRegistered_Date"]);//dsct.Tables[0].Rows[0]["DealRegistered_Date"].ToString();
    //       odealstatus = dsct.Tables[0].Rows[0]["DealStatus"].ToString();

    //       oloanbuofficer = dsct.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
    //       ocanxcontno = dsct.Tables[0].Rows[0]["CanxContractNo"].ToString();
    //       ocanxdate = dsct.Tables[0].Rows[0]["Contract_Canx_date"].ToString();
    //       ocogstin = dsct.Tables[0].Rows[0]["Client_GSTIN"].ToString();
    //       ocontractcomment = dsct.Tables[0].Rows[0]["Contract_comment"].ToString();

    //       DataSet dsptsf = Queries.LoadFinanceContractDetails(ContractdetailsIDTextBox.Text);
    //       ofinance = dsptsf.Tables[0].Rows[0]["Finance_Method"].ToString();
    //       omcwv = dsct.Tables[0].Rows[0]["MCWaiver"].ToString();
    //       omcfees = dsct.Tables[0].Rows[0]["MC_Charges"].ToString();
    //       omcdate = dsct.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
    //       omemberfee = dsct.Tables[0].Rows[0]["MemberFee"].ToString();
    //       omemebercgst = dsct.Tables[0].Rows[0]["MemberCGST"].ToString();
    //       omembersgst = dsct.Tables[0].Rows[0]["MembersGST"].ToString();
    //       oadhar = dsct.Tables[0].Rows[0]["Adhar_Card"].ToString();
    //       opan = dsct.Tables[0].Rows[0]["Pan_Card"].ToString();
    //       ocurrency = dsptsf.Tables[0].Rows[0]["currency"].ToString();
    //       oaffiliate = dsptsf.Tables[0].Rows[0]["Affiliate_Type"].ToString();
    //       ototalintax = dsptsf.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
    //       odepamt = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Percent"].ToString();
    //       obalpayable = dsptsf.Tables[0].Rows[0]["Balance_Payable"].ToString();
    //       odepbal = dsptsf.Tables[0].Rows[0]["Initial_Deposit_Balance"].ToString();
    //       onoinstallment = dsptsf.Tables[0].Rows[0]["No_Installments"].ToString();
    //       oinstallment = dsptsf.Tables[0].Rows[0]["Installment_Amount"].ToString();
    //       ototalbalance = dsptsf.Tables[0].Rows[0]["Bal_Amount_Payable"].ToString();
    //       opaymethod = dsptsf.Tables[0].Rows[0]["Payment_Method"].ToString();
    //       obaladepamtdate = dsptsf.Tables[0].Rows[0]["BalanceDeposit_Date"].ToString();

    //       ofinancemethod = dsptsf.Tables[0].Rows[0]["Finance_Type"].ToString();
    //       oFinanceno = dsptsf.Tables[0].Rows[0]["Finance_No"].ToString();
    //       ofinmonth = dsptsf.Tables[0].Rows[0]["financeMonth"].ToString();
    //       onoemi = dsptsf.Tables[0].Rows[0]["No_Emi"].ToString();
    //       oemiamt = dsptsf.Tables[0].Rows[0]["Emi_Installment"].ToString();
    //       ofindocfee = dsptsf.Tables[0].Rows[0]["documentationfee"].ToString();
    //       oisgtrate = dsptsf.Tables[0].Rows[0]["IGSTrate"].ToString();
    //       oigstamt = dsptsf.Tables[0].Rows[0]["IGST_Amount"].ToString();
    //       ointerestrate = dsptsf.Tables[0].Rows[0]["Interestrate"].ToString();
    //       oregcollectionterm = dsptsf.Tables[0].Rows[0]["Registry_Collection_Term"].ToString();
    //       oregcollamt = dsptsf.Tables[0].Rows[0]["Registry_Collection_Amt"].ToString();
    //       ooldLoanAgreement = dsptsf.Tables[0].Rows[0]["Old_Loan_AgreementNo"].ToString();
    //       ooldloanamt = dsptsf.Tables[0].Rows[0]["Old_Loan_Amount"].ToString();*/

    //    DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_ReceiptActiveOnlyDeposit(sContractdetailsID); //LoadContract_Indian_Deposit_Receipt(sContractdetailsID);// ContractdetailsIDTextBox.Text);
    //    if (dsreceipt.Tables[0].Rows.Count == 0)
    //    {

    //    }
    //    else
    //    {

    //        Session["oReceipt_Date"] = dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString();
    //        Session["oAmount"] = dsreceipt.Tables[0].Rows[0]["Amount"].ToString();
    //        Session["otaxable_value"] = dsreceipt.Tables[0].Rows[0]["taxable_value"].ToString();
    //        Session["ocgstrate"] = dsreceipt.Tables[0].Rows[0]["cgstrate"].ToString();
    //        Session["ocgstamt"] = dsreceipt.Tables[0].Rows[0]["cgstamt"].ToString();
    //        Session["osgstrate"] = dsreceipt.Tables[0].Rows[0]["sgstrate"].ToString();
    //        Session["osgstamt"] = dsreceipt.Tables[0].Rows[0]["sgstamt"].ToString();
    //        Session["ototalamt"] = dsreceipt.Tables[0].Rows[0]["totalamt"].ToString();
    //        Session["oPayment_Mode"] = dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString();
    //        Session["oactual_currency"] = dsreceipt.Tables[0].Rows[0]["actual_currency"].ToString();
    //        Session["oconverted_currency"] = dsreceipt.Tables[0].Rows[0]["converted_currency"].ToString();
    //        Session["oConverted_rate"] = dsreceipt.Tables[0].Rows[0]["Converted_rate"].ToString();
    //        Session["oExchangedValue_date"] = dsreceipt.Tables[0].Rows[0]["ExchangedValue_date"].ToString();
    //        Session["oActual_Amt"] = dsreceipt.Tables[0].Rows[0]["Actual_Amt"].ToString();

    //        //oReceipt_Date = dsreceipt.Tables[0].Rows[0]["Receipt_Date"].ToString();
    //        //oAmount = dsreceipt.Tables[0].Rows[0]["Amount"].ToString();
    //        //otaxable_value = dsreceipt.Tables[0].Rows[0]["taxable_value"].ToString();
    //        //ocgstrate = dsreceipt.Tables[0].Rows[0]["cgstrate"].ToString();
    //        //ocgstamt = dsreceipt.Tables[0].Rows[0]["cgstamt"].ToString();
    //        //osgstrate = dsreceipt.Tables[0].Rows[0]["sgstrate"].ToString();
    //        //osgstamt = dsreceipt.Tables[0].Rows[0]["sgstamt"].ToString();
    //        //ototalamt = dsreceipt.Tables[0].Rows[0]["totalamt"].ToString();
    //        //oPayment_Mode = dsreceipt.Tables[0].Rows[0]["Payment_Mode"].ToString();


    //    }
    //    string finance = financeradiobuttonlist.SelectedItem.Text;
    //    string mcfees = MCFeesTextBox.Text;
    //    string mcdate = MCdateTextBox.Text;
    //    string memberfee = memberfeeTextBox.Text;
    //    string memebercgst = memcgstTextBox.Text;
    //    string membersgst = memsgstTextBox.Text;
    //    string adhar = adharcardTextBox.Text.ToUpper();
    //    string pancrd = pancardnoTextBox.Text.ToUpper();
    //    string currency = currencyDropDownList.SelectedItem.Text;// Request.Form[currencyDropDownList.UniqueID];
    //    string affiliate = AffiliationvalueTextBox.Text;
    //    string totalintax = totalfinpriceIntaxTextBox.Text;
    //    string depamt = intialdeppercentTextBox.Text;
    //    string balpayable = baldepamtTextBox.Text;
    //    string depbal = balinitialdepamtTextBox.Text;
    //    string noinstallment = NoinstallmentTextBox.Text;
    //    string installment = installmentamtTextBox.Text;
    //    string totalbalance = balamtpayableTextBox.Text;
    //    string paymethod = PayMethodDropDownList.SelectedItem.Text;
    //    string baldepdate = baladepamtdateTextBox.Text;
    //    string paymentmode = depositmethodDropDownList.SelectedItem.Text;

    //    string regcollectionterm = regcollectiontermTextBox.Text;
    //    string regcollamt = regcollamtTextBox.Text;
    //    string oldloanagreementno = oldLoanAgreementTextBox.Text;
    //    string loanamt = foldloanamountTextBox.Text;

    //    string receiptdate = invoicedateTextBox.Text;
    //    string ncontractcomment = contractcommentTextBox.Text;


    //    //calculate gst on intial dep    //update receipt amt                  
    //    double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
    //    double gst = Math.Round(indeposit / 118 * 18 / 2);
    //    double taxableamt = Math.Round(indeposit / 118 * 100);

    //    // int dealwkno = Queries.GetWkNumber(Convert.ToDateTime(dealdateTextBox.Text));

    //    string d = dealdateTextBox.Text;
    //    DateTime dt = DateTime.ParseExact(d, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    //    // for both "1/1/2000" or "25/1/2000" formats
    //    string newString = dt.ToString("MM/dd/yyyy");
    //    int dealwkno = Queries.GetWkNumber(Convert.ToDateTime(newString));


    //    string financemethod, Financeno, finmonth, noemi, emiamt, findocfee, isgtrate, igstamt, interestrate;
    //    if (finance == "Finance")
    //    {
    //        financemethod = financemethodDropDownList.SelectedItem.Text;// Request.Form[financemethodDropDownList.UniqueID];
    //        Financeno = FinancenoTextBox.Text;
    //        finmonth = finmonthTextBox.Text;
    //        noemi = noemiTextBox.Text;
    //        emiamt = emiamtTextBox.Text;
    //        findocfee = findocfeeTextBox.Text;
    //        isgtrate = isgtrateTextBox.Text;
    //        igstamt = igstamtTextBox.Text;
    //        interestrate = interestrateTextBox.Text;

    //    }
    //    else
    //    {
    //        financemethod = "";
    //        Financeno = "";
    //        finmonth = "";
    //        noemi = "";
    //        emiamt = "";
    //        findocfee = "";
    //        isgtrate = "";
    //        igstamt = "";
    //        interestrate = "";

    //    }

    //    string contract = contracttypeTextBox.Text;
    //    string contractno = contractnoTextBox.Text.ToUpper();
    //    int i;
    //    string inst = "Installment No";
    //    string iamt, idate, ia, idt;

    //    string loanbuofficer = LoanBUOfficerTextBox.Text.ToUpper();
    //    string canxcontno = CanxContractNoTextBox.Text.ToUpper();
    //    string csalesrep = contsalesrepTextBox.Text.ToUpper();// contsalesrepDropDownList.SelectedItem.Text;
    //    string cTomgr = TOManagerDropDownList.SelectedItem.Text;
    //    string buttonup = ButtonUpDropDownList.SelectedItem.Text;
    //    string dealdate = dealdateTextBox.Text;
    //    string dealstatus, canxdate;

    //    string ncompanyname = companynameTextBox.Text.ToUpper();
    //    string ngstin = gstinTextBox.Text.ToUpper();
    //    string ncompanypanno = companypanoTextBox.Text.ToUpper();

    //    if (dealstatusDropDownList.SelectedItem.Text == "CANCELLED")
    //    {
    //        dealstatus = dealstatusDropDownList.SelectedItem.Text;
    //        canxdate = DateTime.Now.ToShortDateString();
    //    }
    //    else
    //    {
    //        dealstatus = dealstatusDropDownList.SelectedItem.Text;
    //        canxdate = "";
    //    }
    //    if (String.Compare(ocompanyname, ncompanyname) != 0)
    //    {
    //        int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, ncompanyname);
    //        string act = "company name changed from:" + ocompanyname + "To:" + ncompanyname;
    //        int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //    }
    //    if (String.Compare(ocontractcomment, ncontractcomment) != 0)
    //    {
    //        int update = Queries.UpdateContractDetails_IndianComment(ContractdetailsIDTextBox.Text, ncontractcomment.ToUpper());
    //        string act = "contract comment changed from:" + ocontractcomment + "To:" + ncontractcomment;
    //        int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //    }

    //    if (contract == "Points")
    //    {


    //        DataSet dspts = Queries.LoadNewPointsDetails(sContractdetailsID);// (ContractdetailsIDTextBox.Text);



    //        Session["opts_club"] = dspts.Tables[0].Rows[0]["club"].ToString();
    //        Session["opts_newpts"] = dspts.Tables[0].Rows[0]["New_points_rights"].ToString();
    //        Session["opts_entitlement"] = dspts.Tables[0].Rows[0]["Type_membership"].ToString();
    //        Session["opts_totalpts"] = dspts.Tables[0].Rows[0]["Total_points_rights"].ToString();
    //        Session["opts_firstyr"] = dspts.Tables[0].Rows[0]["First_year_occupancy"].ToString();
    //        Session["opts_Tenure"] = dspts.Tables[0].Rows[0]["Tenure"].ToString();
    //        Session["opts_lastyr"] = dspts.Tables[0].Rows[0]["Last_year_occupancy"].ToString();
    //        Session["opts_nopersons"] = dspts.Tables[0].Rows[0]["NoPersons"].ToString();


    //        //opts_club = dspts.Tables[0].Rows[0]["club"].ToString();
    //        //opts_newpts = dspts.Tables[0].Rows[0]["New_points_rights"].ToString();
    //        //opts_entitlement = dspts.Tables[0].Rows[0]["Type_membership"].ToString();
    //        //opts_totalpts = dspts.Tables[0].Rows[0]["Total_points_rights"].ToString();
    //        //opts_firstyr = dspts.Tables[0].Rows[0]["First_year_occupancy"].ToString();
    //        //opts_Tenure = dspts.Tables[0].Rows[0]["Tenure"].ToString();
    //        //opts_lastyr = dspts.Tables[0].Rows[0]["Last_year_occupancy"].ToString();
    //        //opts_nopersons = dspts.Tables[0].Rows[0]["NoPersons"].ToString();
    //        //ocontractno = dspts.Tables[0].Rows[0]["contractno"].ToString();



    //        DataSet dspa = Queries.contractPA(sContractdetailsID);// ContractdetailsIDTextBox.Text);



    //        Session["onewpoints"] = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
    //        Session["oconversionfee"] = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
    //        Session["oadminfee"] = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
    //        Session["ototpurchprice"] = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
    //        Session["ocgst"] = dspa.Tables[0].Rows[0]["Cgst"].ToString();
    //        Session["osgst"] = dspa.Tables[0].Rows[0]["Sgst"].ToString();
    //        Session["ototalpriceInTax"] = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
    //        Session["odeposit"] = dspa.Tables[0].Rows[0]["Deposit"].ToString();
    //        Session["obalance"] = dspa.Tables[0].Rows[0]["Balance"].ToString();
    //        Session["obalancedue"] = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
    //        Session["oremarks"] = dspa.Tables[0].Rows[0]["Remarks"].ToString();
    //        Session["ooldVolume"] = dspa.Tables[0].Rows[0]["oldVolume"].ToString();
    //        Session["ooldadminfee"] = dspa.Tables[0].Rows[0]["oldadminfee"].ToString();
    //        Session["ooldTotalTax"] = dspa.Tables[0].Rows[0]["oldTotalTax"].ToString();
    //        Session["ooldDeposit"] = dspa.Tables[0].Rows[0]["oldDeposit"].ToString();
    //        Session["ousdoldvolume"] = dspa.Tables[0].Rows[0]["usdoldvolume"].ToString();
    //        Session["ousdoldadminfee"] = dspa.Tables[0].Rows[0]["usdoldadminfee"].ToString();
    //        Session["ousdoldtax"] = dspa.Tables[0].Rows[0]["usdoldtax"].ToString();
    //        Session["ousdolddeposit"] = dspa.Tables[0].Rows[0]["usdolddeposit"].ToString();
    //        Session["oUSDConvertedVolume"] = dspa.Tables[0].Rows[0]["USDConvertedVolume"].ToString();
    //        Session["oUSDConvertedAdminfee"] = dspa.Tables[0].Rows[0]["USDConvertedAdminfee"].ToString();
    //        Session["oUSDConvertedTax"] = dspa.Tables[0].Rows[0]["USDConvertedTax"].ToString();
    //        Session["oUSDConverteddeposit"] = dspa.Tables[0].Rows[0]["USDConverteddeposit"].ToString();


           


    //        string pts_club = clubTextBox.Text;
    //        string pts_newpts = newpointsrightTextBox.Text;
    //        string pts_entitlement = EntitlementPoinDropDownList.SelectedItem.Text;
    //        string pts_totalpts = totalptrightsTextBox.Text;
    //        string pts_firstyr = firstyrTextBox.Text;
    //        string pts_Tenure = tenureTextBox.Text;
    //        string pts_lastyr = lastyrTextBox.Text;
    //        string pts_nopersons = NoPersonsTextBox.Text;


    //        string newpoints = newpointsTextBox.Text;
    //        string conversionfee = conversionfeeTextBox.Text;
    //        string adminfee = adminfeeTextBox.Text;
    //        string totpurchprice = totpurchpriceTextBox.Text;
    //        string cgst = cgstTextBox.Text;
    //        string sgst = sgstTextBox.Text;
    //        string totalpriceInTax = totalpriceInTaxTextBox.Text;
    //        string deposit = depositTextBox.Text;
    //        string balance = balanceTextBox.Text;
    //        string balancedue = balancedueTextBox.Text;
    //        string remarks = remarksTextBox.Text;

    //        string USDConvertedVolume, USDConvertedTax, USDConvertedAdminfee, USDConverteddeposit;
    //        DataSet exrds = Queries.LoadExchange_Rate();
    //        string dollarrate = exrds.Tables[0].Rows[0]["ERates_USD"].ToString();
    //        if (currencyDropDownList.SelectedItem.Text == "INR")
    //        {
    //            if (newpointsTextBox.Text == "" || newpointsTextBox.Text == null || newpointsTextBox.Text == "NaN")
    //            {
    //                USDConvertedVolume = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round(Convert.ToDouble(newpointsTextBox.Text) / Convert.ToDouble(dollarrate), 0);
    //                USDConvertedVolume = valueamt.ToString();
    //            }
    //            if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
    //            {
    //                USDConvertedAdminfee = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text) / Convert.ToDouble(dollarrate), 0);
    //                USDConvertedAdminfee = valueamt.ToString();
    //            }
    //            if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
    //            {
    //                USDConvertedTax = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)) / Convert.ToDouble(dollarrate), 0);
    //                USDConvertedTax = valueamt.ToString();
    //            }
    //            if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
    //            {
    //                USDConverteddeposit = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text) / Convert.ToDouble(dollarrate), 0);
    //                USDConverteddeposit = valueamt.ToString();
    //            }
    //        }
    //        else
    //        {
    //            if (totpurchpriceTextBox.Text == "" || totpurchpriceTextBox.Text == null || totpurchpriceTextBox.Text == "NaN")
    //            {
    //                USDConvertedVolume = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round(Convert.ToDouble(totpurchpriceTextBox.Text), 0);
    //                USDConvertedVolume = valueamt.ToString();
    //            }
    //            if (adminfeeTextBox.Text == "" || adminfeeTextBox.Text == null || adminfeeTextBox.Text == "NaN")
    //            {
    //                USDConvertedAdminfee = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round(Convert.ToDouble(adminfeeTextBox.Text), 0);
    //                USDConvertedAdminfee = valueamt.ToString();
    //            }
    //            if (cgstTextBox.Text == "" || cgstTextBox.Text == null || cgstTextBox.Text == "NaN" || sgstTextBox.Text == "" || sgstTextBox.Text == null || sgstTextBox.Text == "NaN")
    //            {
    //                USDConvertedTax = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round((Convert.ToDouble(cgstTextBox.Text) + Convert.ToDouble(sgstTextBox.Text)), 0);
    //                USDConvertedTax = valueamt.ToString();
    //            }
    //            if (depositTextBox.Text == "" || depositTextBox.Text == null || depositTextBox.Text == "NaN")
    //            {
    //                USDConverteddeposit = "0";
    //            }
    //            else
    //            {
    //                double valueamt = Math.Round(Convert.ToDouble(depositTextBox.Text), 0);
    //                USDConverteddeposit = valueamt.ToString();
    //            }

    //        }



    //        if (mcRadioButtonList.Checked == true)
    //        {
    //            mcwaiver = "Yes";
    //        }
    //        else
    //        {
    //            mcwaiver = "No";

    //        }

    //        if (String.Compare(ocogstin, ngstin) != 0)
    //        {
    //            string act = "(points)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocompanypano, ncompanypanno) != 0)
    //        {
    //            string act = "(points)company pan no changed from:" + ocompanypano + "To:" + ncompanypanno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocontractno, contractno) != 0)
    //        {
    //            //update in installment table
    //            int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
    //            if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContractNo_Othernames_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContractNo_Othernames_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }

    //            if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }


    //            string act = "(points)Contract NO changed from:" + ocontractno + "To:" + contractno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocsalesrep, csalesrep) != 0)
    //        {
    //            string act = "(points)sales rep changed from:" + ocsalesrep + "To:" + csalesrep;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocTomgr, cTomgr) != 0)
    //        {
    //            string act = "(points)TO manager changed from:" + ocTomgr + "To:" + cTomgr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(obuttonup, buttonup) != 0)
    //        {
    //            string act = "(points)button up changed from:" + obuttonup + "To:" + buttonup;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(odealdate, dealdate) != 0)
    //        {
    //            string act = "(points)deal date changed from:" + odealdate + "To:" + dealdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
    //        {
    //            string act = "(points)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odealstatus, dealstatus) != 0)
    //        {
    //            string act = "(points)deal status changed from:" + odealstatus + "To:" + dealstatus;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
    //        {
    //            string act = "(points)Loan BU Officer changed from:" + oloanbuofficer + "To:" + loanbuofficer;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocanxcontno, canxcontno) != 0)
    //        {
    //            string act = "(points)Cancelled Canx No changed from:" + ocanxcontno + "To:" + canxcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(ocanxdate, canxdate) != 0)
    //        {
    //            string act = "(points)deal cancelled date changed from:" + ocanxdate + "To:" + canxdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }



    //        if (String.Compare(omcwv, mcwaiver) != 0)
    //        {
    //            string act = "(points)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(oadhar, adhar) != 0)
    //        {
    //            string act = "(points) adhar Card changed from:" + oadhar + "To:" + adhar;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opan, pancrd) != 0)
    //        {
    //            string act = "(points)pan card changed from:" + opan + "To:" + pancrd;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(opts_club, pts_club) != 0)
    //        {
    //            string act = "(points) club name changed from:" + opts_club + "To:" + pts_club;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opts_newpts, pts_newpts) != 0)
    //        {
    //            string act = "(points)new points changed from:" + opts_newpts + "To:" + pts_newpts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(opts_entitlement, pts_entitlement) != 0)
    //        {
    //            string act = "(points)entitlement changed from:" + opts_entitlement + "To:" + pts_entitlement;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opts_totalpts, pts_totalpts) != 0)
    //        {
    //            string act = "(points) total points changed from:" + opts_totalpts + "To:" + pts_totalpts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opts_firstyr, pts_firstyr) != 0)
    //        {
    //            string act = "(points) first yr changed from:" + opts_firstyr + "To:" + pts_firstyr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opts_Tenure, pts_Tenure) != 0)
    //        {
    //            string act = "(points)tenure changed from:" + opts_Tenure + "To:" + pts_Tenure;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opts_lastyr, pts_lastyr) != 0)
    //        {
    //            string act = "(points) last yr changed from:" + opts_lastyr + "To:" + pts_lastyr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opts_nopersons, pts_nopersons) != 0)
    //        {
    //            string act = "(points) No. Of Persons changed from:" + opts_nopersons + "To:" + pts_nopersons;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(ofinance, finance) != 0)
    //        {

    //            string act = "(points) financemethod changed from:" + ofinance + "To:" + finance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(omcfees, mcfees) != 0)
    //        {
    //            string act = "(points) MC fees changed from:" + omcfees + "To:" + mcfees;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omcdate, mcdate) != 0)
    //        {
    //            string act = "(points) MC Date changed from:" + omcdate + "To:" + mcdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omemberfee, memberfee) != 0)
    //        {
    //            string act = "(points) member fee changed from:" + omemberfee + "To:" + memberfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omemebercgst, memebercgst) != 0)
    //        {
    //            string act = "(points) cgst changed from:" + omemebercgst + "To:" + memebercgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omembersgst, membersgst) != 0)
    //        {
    //            string act = "(points) sgst changed from:" + omembersgst + "To:" + membersgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocurrency, currency) != 0)
    //        {
    //            string act = "(points) Currency changed from:" + ocurrency + "To:" + currency;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oaffiliate, affiliate) != 0)
    //        {
    //            string act = "(points) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalintax, totalintax) != 0)
    //        {
    //            string act = "(points) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepamt, depamt) != 0)
    //        {
    //            string act = "(points)deposit amount changed from:" + odepamt + "To:" + depamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalpayable, balpayable) != 0)
    //        {
    //            string act = "(points)deposit amount(bal) changed from:" + obalpayable + "To:" + balpayable;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(obaladepamtdate, baldepdate) != 0)
    //        {
    //            string act = "(points)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepbal, depbal) != 0)
    //        {
    //            string act = "(points)Balance deposit changed from:" + odepbal + "To:" + depbal;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoinstallment, noinstallment) != 0)
    //        {
    //            string act = "(points) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

    //        }
    //        else
    //        {

    //        }
    //        if (String.Compare(oinstallment, installment) != 0)
    //        {
    //            string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + installment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
    //            {
    //                //check if contracttno exists in installment table if yes deleete if no  nothting
    //                //check previous valu of installment
    //                if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
    //                {

    //                }
    //                else
    //                {
    //                    //delete from installment table;
    //                }
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete from table

    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }

    //                }
    //                else { }

    //            }
    //            else
    //            {
    //                //delete .//previous installment
    //                DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                {
    //                    string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                    string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                    string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                    string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                    string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                    string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                    string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                    int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                    int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                }
    //                for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                {
    //                    string installemnt_No = inst + " " + i;
    //                    ia = "textBox_" + i + "1";
    //                    iamt = Request.Form[ia];
    //                    idt = "textBox_" + i + "2";
    //                    idate = Request.Form[idt];

    //                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                    //update instalmentno
    //                    int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (CheckBox1.Checked == true)
    //            {
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete .//previous installment
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

    //                }
    //                else
    //                {
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


    //                }
    //            }
    //            else
    //            { }
    //        }


    //        if (String.Compare(ototalbalance, totalbalance) != 0)
    //        {
    //            string act = "(points) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opaymethod, paymethod) != 0)
    //        {
    //            string act = "(points) pay method changed from:" + opaymethod + "To:" + paymethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinancemethod, financemethod) != 0)
    //        {
    //            string act = "(points)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oFinanceno, Financeno) != 0)
    //        {
    //            string act = "(points) Finance no changed from:" + oFinanceno + "To:" + Financeno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinmonth, finmonth) != 0)
    //        {
    //            string act = "(points) finance month changed from:" + ofinmonth + "To:" + finmonth;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoemi, noemi) != 0)
    //        {
    //            string act = "(points) No of EMI changed from:" + onoemi + "To:" + noemi;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(oemiamt, emiamt) != 0)
    //        {
    //            string act = "(points)EMI Amount changed from:" + oemiamt + "To:" + emiamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofindocfee, findocfee) != 0)
    //        {
    //            string act = "(points)Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oisgtrate, isgtrate) != 0)
    //        {
    //            string act = "(points)IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oigstamt, igstamt) != 0)
    //        {
    //            string act = "(points) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ointerestrate, interestrate) != 0)
    //        {
    //            string act = "(points) Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onewpoints, newpoints) != 0)
    //        {
    //            string act = "(points)New points changed from:" + onewpoints + "To:" + newpoints;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oconversionfee, conversionfee) != 0)
    //        {
    //            string act = "(points)Conversion Fee changed from:" + oconversionfee + "To:" + conversionfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oadminfee, adminfee) != 0)
    //        {
    //            string act = "(points)Admin Fee changed from:" + oadminfee + "To:" + adminfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototpurchprice, totpurchprice) != 0)
    //        {
    //            string act = "(points)Purchase Price changed from:" + ototpurchprice + "To:" + totpurchprice;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocgst, cgst) != 0)
    //        {
    //            string act = "(points)CGST changed from:" + ocgst + "To:" + cgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgst, sgst) != 0)
    //        {
    //            string act = "(points)SGST changed from:" + osgst + "To:" + sgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalpriceInTax, totalpriceInTax) != 0)
    //        {
    //            string act = "(points) Total Price including Tax (PA) changed from:" + ototalpriceInTax + "To:" + totalpriceInTax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odeposit, deposit) != 0)
    //        {
    //            string act = "(points)Deposit(PA) changed from:" + odeposit + "To:" + deposit;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalance, balance) != 0)
    //        {
    //            string act = "(points) Balaance(PA) changed from:" + obalance + "To:" + balance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalancedue, balancedue) != 0)
    //        {
    //            string act = "(points)balance due date(PA) changed from:" + obalancedue + "To:" + balancedue;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oremarks, remarks) != 0)
    //        {
    //            string act = "(points) Remarks changed from:" + oremarks + "To:" + remarks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(oPayment_Mode, paymentmode) != 0)
    //        {
    //            string act = "(points)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oReceipt_Date, receiptdate) != 0)
    //        {
    //            string act = "(points)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }



    //        if (String.Compare(ototalamt, indeposit.ToString()) != 0)
    //        {
    //            string act = "(points)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oAmount, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(points)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(points)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(points)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(points)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
    //        {
    //            installment = "0";
    //        }
    //        else
    //        {
    //            installment = installmentamtTextBox.Text;
    //        }
    //        if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
    //        {
    //            noinstallment = "0";
    //        }
    //        else
    //        {
    //            noinstallment = NoinstallmentTextBox.Text;
    //        }

    //        int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);

    //        int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);
    //        int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, "", "", "", baldepdate, "", ContractdetailsIDTextBox.Text);
    //        int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
    //        int updatepointscontract = Queries.UpdateContract_Points_Indian(pts_club, pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
    //        //    int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);
    //        if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
    //        {
    //            int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
    //        }
    //        else
    //        {
    //            int updatefin = Queries.UpdatefinanceStartdate(contractno);
    //        }
    //        string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
    //        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
    //        LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
    //        Response.Redirect(Request.RawUrl);

    //    }//end of points contract


    //    else if (contract == "Trade-In-Points")
    //    {
    //        DataSet dstip = Queries.LoadTradeinPointsDetails(ContractdetailsIDTextBox.Text);

    //        otip_Trade_In_Details_club_resort = dstip.Tables[0].Rows[0]["Trade_In_Details_club_resort"].ToString();
    //        otip_Trade_In_Details_No_rights = dstip.Tables[0].Rows[0]["Trade_In_Details_No_rights"].ToString();
    //        otip_Trade_In_Details_ContNo_RCINo = dstip.Tables[0].Rows[0]["Trade_In_Details_ContNo_RCINo"].ToString();
    //        otip_Trade_In_Details_Points_value = dstip.Tables[0].Rows[0]["Trade_In_Details_Points_value"].ToString();
    //        otip_New_Club = dstip.Tables[0].Rows[0]["New_Club"].ToString();
    //        otip_New_Club_Points_Rights = dstip.Tables[0].Rows[0]["New_Club_Points_Rights"].ToString();
    //        otip_New_MemebrshipType = dstip.Tables[0].Rows[0]["New_MemebrshipType"].ToString();
    //        otip_New_TotalPointsRights = dstip.Tables[0].Rows[0]["New_TotalPointsRights"].ToString();
    //        otip_New_First_year_occupancy = dstip.Tables[0].Rows[0]["New_First_year_occupancy"].ToString();
    //        otip_New_Tenure = dstip.Tables[0].Rows[0]["New_Tenure"].ToString();
    //        otip_New_Last_year_occupancy = dstip.Tables[0].Rows[0]["New_Last_year_occupancy"].ToString();
    //        otip_nopersons = dstip.Tables[0].Rows[0]["NoPersons"].ToString();



    //        DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);
    //        onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
    //        oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
    //        oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
    //        ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
    //        ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
    //        osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
    //        ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
    //        odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
    //        obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
    //        obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
    //        oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();




    //        string tpresort = tnmresortTextBox.Text;
    //        string tpnpts = tipnopointsTextBox.Text;
    //        string tpcontno = nmcontrcinoTextBox.Text;
    //        string tpptsval = tipptsvalueTextBox.Text;
    //        string pts_club = clubTextBox.Text;
    //        string pts_newpts = newpointsrightTextBox.Text;
    //        string pts_entitlement = EntitlementPoinDropDownList.SelectedItem.Text;// Request.Form[EntitlementPoinDropDownList.UniqueID];
    //        string pts_totalpts = totalptrightsTextBox.Text;
    //        string pts_firstyr = firstyrTextBox.Text;
    //        string pts_Tenure = tenureTextBox.Text;
    //        string pts_lastyr = lastyrTextBox.Text;
    //        string pts_nopersons = NoPersonsTextBox.Text;




    //        string newpoints = newpointsTextBox.Text;
    //        string conversionfee = conversionfeeTextBox.Text;
    //        string adminfee = adminfeeTextBox.Text;
    //        string totpurchprice = totpurchpriceTextBox.Text;
    //        string cgst = cgstTextBox.Text;
    //        string sgst = sgstTextBox.Text;
    //        string totalpriceInTax = totalpriceInTaxTextBox.Text;
    //        string deposit = depositTextBox.Text;
    //        string balance = balanceTextBox.Text;
    //        string balancedue = balancedueTextBox.Text;
    //        string remarks = remarksTextBox.Text;

    //        if (mcRadioButtonList.Checked == true)
    //        {
    //            mcwaiver = "Yes";
    //        }
    //        else
    //        {
    //            mcwaiver = "No";

    //        }

    //        if (String.Compare(ocogstin, ngstin) != 0)
    //        {
    //            string act = "(trade in points)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocompanypano, ncompanypanno) != 0)
    //        {
    //            string act = "(trade in points)company Pan # changed from:" + ocompanypano + "To:" + ncompanypanno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocontractno, contractno) != 0)
    //        {
    //            //update in installment table
    //            int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
    //            if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContractNo_Othernames_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContractNo_Othernames_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }

    //            string act = "(trade in points)Contract NO changed from:" + ocontractno + "To:" + contractno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocsalesrep, csalesrep) != 0)
    //        {
    //            string act = "(trade in points)sales rep changed from:" + ocsalesrep + "To:" + csalesrep;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocTomgr, cTomgr) != 0)
    //        {
    //            string act = "(trade in points) TO manager changed from:" + ocTomgr + "To:" + cTomgr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(obuttonup, buttonup) != 0)
    //        {
    //            string act = "(trade in points)button up changed from:" + obuttonup + "To:" + buttonup;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odealdate, dealdate) != 0)
    //        {
    //            string act = "(trade in points)deal date changed from:" + odealdate + "To:" + dealdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
    //        {
    //            string act = "(trade in points)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(odealstatus, dealstatus) != 0)
    //        {
    //            string act = "(trade in points) deal status changed from:" + odealstatus + "To:" + dealstatus;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
    //        {
    //            string act = "(trade in points)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(ocanxcontno, canxcontno) != 0)
    //        {
    //            string act = "(trade in points)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocanxdate, canxdate) != 0)
    //        {
    //            string act = "(trade in points)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(omcwv, mcwaiver) != 0)
    //        {
    //            string act = "(trade in points)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(oadhar, adhar) != 0)
    //        {
    //            string act = "(trade in points) adhar Card changed from:" + oadhar + "To:" + adhar;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opan, pancrd) != 0)
    //        {
    //            string act = "(trade in points) pan card changed from:" + opan + "To:" + pancrd;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otip_Trade_In_Details_club_resort, tpresort) != 0)
    //        {
    //            string act = "(trade in points) club(trade in) changed from:" + otip_Trade_In_Details_club_resort + "To:" + tpresort;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_Trade_In_Details_No_rights, tpnpts) != 0)
    //        {
    //            string act = "(trade in points) points rights (trade in) changed from:" + otip_Trade_In_Details_No_rights + "To:" + tpnpts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otip_Trade_In_Details_ContNo_RCINo, tpcontno) != 0)
    //        {
    //            string act = "(trade in points) cont.no (trade in) changed from:" + otip_Trade_In_Details_ContNo_RCINo + "To:" + tpcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_Trade_In_Details_Points_value, tpptsval) != 0)
    //        {
    //            string act = "(trade in points)new points changed from:" + otip_Trade_In_Details_Points_value + "To:" + tpptsval;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otip_New_Club, pts_club) != 0)
    //        {
    //            string act = "(trade in points) club name changed from:" + opts_club + "To:" + pts_club;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_New_Club_Points_Rights, pts_newpts) != 0)
    //        {
    //            string act = "(trade in points)new points changed from:" + opts_newpts + "To:" + pts_newpts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otip_New_MemebrshipType, pts_entitlement) != 0)
    //        {
    //            string act = "(trade in points)entitlement changed from:" + otip_New_MemebrshipType + "To:" + pts_entitlement;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_New_TotalPointsRights, pts_totalpts) != 0)
    //        {
    //            string act = "(trade in points) total points changed from:" + otip_New_TotalPointsRights + "To:" + pts_totalpts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_New_First_year_occupancy, pts_firstyr) != 0)
    //        {
    //            string act = "(trade in points) first yr changed from:" + otip_New_First_year_occupancy + "To:" + pts_firstyr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_New_Tenure, pts_Tenure) != 0)
    //        {
    //            string act = "(trade in points)tenure changed from:" + otip_New_Tenure + "To:" + pts_Tenure;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_New_Last_year_occupancy, pts_lastyr) != 0)
    //        {
    //            string act = "(trade in points) last yr changed from:" + otip_New_Last_year_occupancy + "To:" + pts_lastyr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otip_nopersons, pts_nopersons) != 0)
    //        {
    //            string act = "(trade in points) No. Of Persons changed from:" + opts_nopersons + "To:" + pts_nopersons;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinance, finance) != 0)
    //        {
    //            string act = "(trade in points) financemethod changed from:" + ofinance + "To:" + finance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(omcfees, mcfees) != 0)
    //        {
    //            string act = "(trade in points) MC fees changed from:" + omcfees + "To:" + mcfees;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omcdate, mcdate) != 0)
    //        {
    //            string act = "(trade in points) MC Date changed from:" + omcdate + "To:" + mcdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omemberfee, memberfee) != 0)
    //        {
    //            string act = "(trade in points) member fee changed from:" + omemberfee + "To:" + memberfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omemebercgst, memebercgst) != 0)
    //        {
    //            string act = "(trade in points) MC cgst changed from:" + omemebercgst + "To:" + memebercgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omembersgst, membersgst) != 0)
    //        {
    //            string act = "(trade in points) MC sgst changed from:" + omembersgst + "To:" + membersgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocurrency, currency) != 0)
    //        {
    //            string act = "(trade in points) Currency changed from:" + ocurrency + "To:" + currency;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oaffiliate, affiliate) != 0)
    //        {
    //            string act = "(trade in points) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalintax, totalintax) != 0)
    //        {
    //            string act = "(trade in points) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepamt, depamt) != 0)
    //        {
    //            string act = "(trade in points)deposit amount changed from:" + odepamt + "To:" + depamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalpayable, balpayable) != 0)
    //        {
    //            string act = "(trade in points)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obaladepamtdate, baldepdate) != 0)
    //        {
    //            string act = "(trade in points)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepbal, depbal) != 0)
    //        {
    //            string act = "(trade in points)Balance deposit changed from:" + odepbal + "To:" + depbal;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoinstallment, noinstallment) != 0)
    //        {
    //            string act = "(trade in points) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oinstallment, installment) != 0)
    //        {
    //            string act = "(trade in points) Installment Amount changed from:" + oinstallment + "To:" + installment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
    //            {
    //                //check if contracttno exists in installment table if yes deleete if no  nothting
    //                //check previous valu of installment
    //                if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
    //                {

    //                }
    //                else
    //                {
    //                    //delete from installment table;
    //                }
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete from table
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }

    //                }
    //                else { }

    //            }
    //            else
    //            {
    //                //delete .//previous installment
    //                DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                {
    //                    string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                    string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                    string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                    string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                    string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                    string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                    string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                    int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                    int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                }
    //                for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                {
    //                    string installemnt_No = inst + " " + i;
    //                    ia = "textBox_" + i + "1";
    //                    iamt = Request.Form[ia];
    //                    idt = "textBox_" + i + "2";
    //                    idate = Request.Form[idt];

    //                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                    //update instalmentno
    //                    int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (CheckBox1.Checked == true)
    //            {
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete .//previous installment
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

    //                }
    //                else
    //                {
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


    //                }
    //            }
    //            else
    //            { }
    //        }
    //        if (String.Compare(ototalbalance, totalbalance) != 0)
    //        {
    //            string act = "(trade in points) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opaymethod, paymethod) != 0)
    //        {
    //            string act = "(trade in points) pay method changed from:" + opaymethod + "To:" + paymethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinancemethod, financemethod) != 0)
    //        {
    //            string act = "(trade in points)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oFinanceno, Financeno) != 0)
    //        {
    //            string act = "(trade in points) Finance no changed from:" + oFinanceno + "To:" + Financeno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinmonth, finmonth) != 0)
    //        {
    //            string act = "(trade in points) finance month changed from:" + ofinmonth + "To:" + finmonth;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoemi, noemi) != 0)
    //        {
    //            string act = "(trade in points) No of EMI changed from:" + onoemi + "To:" + noemi;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(oemiamt, emiamt) != 0)
    //        {
    //            string act = "(trade in points) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofindocfee, findocfee) != 0)
    //        {
    //            string act = "(trade in points) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oisgtrate, isgtrate) != 0)
    //        {
    //            string act = "(trade in points) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oigstamt, igstamt) != 0)
    //        {
    //            string act = "(trade in points) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ointerestrate, interestrate) != 0)
    //        {
    //            string act = "(trade in points)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onewpoints, newpoints) != 0)
    //        {
    //            string act = "(trade in points) New points changed from:" + onewpoints + "To:" + newpoints;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oconversionfee, conversionfee) != 0)
    //        {
    //            string act = "(trade in points) Conversion Fee changed from:" + oconversionfee + "To:" + conversionfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oadminfee, adminfee) != 0)
    //        {
    //            string act = "(trade in points)Admin Fee changed from:" + oadminfee + "To:" + adminfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototpurchprice, totpurchprice) != 0)
    //        {
    //            string act = "(trade in points) Purchase Price changed from:" + ototpurchprice + "To:" + totpurchprice;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocgst, cgst) != 0)
    //        {
    //            string act = "(trade in points) CGST changed from:" + ocgst + "To:" + cgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgst, sgst) != 0)
    //        {
    //            string act = "(trade in points)SGST changed from:" + osgst + "To:" + sgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalpriceInTax, totalpriceInTax) != 0)
    //        {
    //            string act = "(trade in points) Total Price including Tax (PA) changed from:" + ototalpriceInTax + "To:" + totalpriceInTax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odeposit, deposit) != 0)
    //        {
    //            string act = "(trade in points) Deposit(PA) changed from:" + odeposit + "To:" + deposit;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalance, balance) != 0)
    //        {
    //            string act = "(trade in points) Balance(PA) changed from:" + obalance + "To:" + balance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalancedue, balancedue) != 0)
    //        {
    //            string act = "(trade in points) balance due date(PA) changed from:" + obalancedue + "To:" + balancedue;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oremarks, remarks) != 0)
    //        {
    //            string act = "(trade in points) Remarks changed from:" + oremarks + "To:" + remarks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(oPayment_Mode, paymentmode) != 0)
    //        {
    //            string act = "(trade in points)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oReceipt_Date, receiptdate) != 0)
    //        {
    //            string act = "(trade in points)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }



    //        if (String.Compare(ototalamt, indeposit.ToString()) != 0)
    //        {
    //            string act = "(trade in points)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oAmount, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(trade in points)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(trade in points)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(trade in points)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(trade in points)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
    //        {
    //            installment = "0";
    //        }
    //        else
    //        {
    //            installment = installmentamtTextBox.Text;
    //        }
    //        if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
    //        {
    //            noinstallment = "0";
    //        }
    //        else
    //        {
    //            noinstallment = NoinstallmentTextBox.Text;
    //        }
    //        int updatepointscontract = Queries.UpdateContract_Trade_In_Points_Indian(tpresort, tpnpts, tpcontno, tpptsval, pts_club, pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);

    //        int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);

    //        int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);
    //        int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, "", "", "", baldepdate, "", ContractdetailsIDTextBox.Text);
    //        int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
    //        //   int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);
    //        if (NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "NaN")
    //        {
    //            int updatefin1 = Queries.UpdatefinanceStartdateIFZeroInstallment(contractno);
    //        }
    //        else
    //        {
    //            int updatefin = Queries.UpdatefinanceStartdate(contractno);
    //        }

    //        string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
    //        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
    //        LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
    //        Response.Redirect(Request.RawUrl);
    //    }
    //    else if (contract == "Trade-In-Weeks")
    //    {
    //        DataSet dstiw = Queries.LoadTradeinWeeksDetails(ContractdetailsIDTextBox.Text);

    //        otiw_Trade_In_Weeks_resort = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_resort"].ToString();
    //        otiw_Trade_In_Weeks_Apt = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Apt"].ToString();
    //        otiw_Trade_In_Weeks_Season = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Season"].ToString();
    //        otiw_Trade_In_Weeks_NoWks = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_NoWks"].ToString();
    //        otiw_Trade_In_Weeks_ContNo_RCINo = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_ContNo_RCINo"].ToString();
    //        otiw_Trade_In_Weeks_Points_value = dstiw.Tables[0].Rows[0]["Trade_In_Weeks_Points_value"].ToString();
    //        otiw_NewPointsW_Club = dstiw.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
    //        otiw_NewPointsW_Club_Points_Rights = dstiw.Tables[0].Rows[0]["NewPointsW_Club_Points_Rights"].ToString();
    //        otiw_NewPointsW_MemebrshipType = dstiw.Tables[0].Rows[0]["NewPointsW_MemebrshipType"].ToString();
    //        otiw_NewPointsW_Total_Points_rights = dstiw.Tables[0].Rows[0]["NewPointsW_Total_Points_rights"].ToString();
    //        otiw_NewPointsW_First_year_occupancy = dstiw.Tables[0].Rows[0]["NewPointsW_First_year_occupancy"].ToString();
    //        otiw_NewPointsW_Tenure = dstiw.Tables[0].Rows[0]["NewPointsW_Tenure"].ToString();
    //        otiw_NewPointsW_Last_year_occupancy = dstiw.Tables[0].Rows[0]["NewPointsW_Last_year_occupancy"].ToString();
    //        otiw_nopersons = dstiw.Tables[0].Rows[0]["NoPersons"].ToString();




    //        DataSet dspa = Queries.contractPA(ContractdetailsIDTextBox.Text);
    //        onewpoints = dspa.Tables[0].Rows[0]["New_Points_Price"].ToString();
    //        oconversionfee = dspa.Tables[0].Rows[0]["Conversion_Fee"].ToString();
    //        oadminfee = dspa.Tables[0].Rows[0]["Admin_Fee"].ToString();
    //        ototpurchprice = dspa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
    //        ocgst = dspa.Tables[0].Rows[0]["Cgst"].ToString();
    //        osgst = dspa.Tables[0].Rows[0]["Sgst"].ToString();
    //        ototalpriceInTax = dspa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
    //        odeposit = dspa.Tables[0].Rows[0]["Deposit"].ToString();
    //        obalance = dspa.Tables[0].Rows[0]["Balance"].ToString();
    //        obalancedue = dspa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
    //        oremarks = dspa.Tables[0].Rows[0]["Remarks"].ToString();



    //        string tpresort = tnmresortTextBox.Text;
    //        string apt = tnmapttypeTextBox.Text;
    //        string season = tnmseasonDropDownList.SelectedItem.Text;
    //        string nowks = nmnowksTextBox.Text;
    //        string tpcontno = nmcontrcinoTextBox.Text;
    //        string tpptsval = tipptsvalueTextBox.Text;
    //        string pts_club = clubTextBox.Text;
    //        string pts_newpts = newpointsrightTextBox.Text;
    //        string pts_entitlement = EntitlementPoinDropDownList.SelectedItem.Text;// Request.Form[EntitlementPoinDropDownList.UniqueID];
    //        string pts_totalpts = totalptrightsTextBox.Text;
    //        string pts_firstyr = firstyrTextBox.Text;
    //        string pts_Tenure = tenureTextBox.Text;
    //        string pts_lastyr = lastyrTextBox.Text;
    //        string pts_nopersons = NoPersonsTextBox.Text;


    //        //string interestrate = interestrateTextBox.Text;
    //        string newpoints = newpointsTextBox.Text;
    //        string conversionfee = conversionfeeTextBox.Text;
    //        string adminfee = adminfeeTextBox.Text;
    //        string totpurchprice = totpurchpriceTextBox.Text;
    //        string cgst = cgstTextBox.Text;
    //        string sgst = sgstTextBox.Text;
    //        string totalpriceInTax = totalpriceInTaxTextBox.Text;
    //        string deposit = depositTextBox.Text;
    //        string balance = balanceTextBox.Text;
    //        string balancedue = balancedueTextBox.Text;
    //        string remarks = remarksTextBox.Text;

    //        if (mcRadioButtonList.Checked == true)
    //        {
    //            mcwaiver = "Yes";
    //        }
    //        else
    //        {
    //            mcwaiver = "No";

    //        }

    //        if (String.Compare(ocogstin, ngstin) != 0)
    //        {
    //            string act = "(trade in weeks)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocontractno, contractno) != 0)
    //        {
    //            //update in installment table
    //            int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
    //            if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContractNo_Othernames_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContractNo_Othernames_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }

    //            string act = "(trade in weeks)Contract NO changed from:" + ocontractno + "To:" + contractno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocsalesrep, csalesrep) != 0)
    //        {
    //            string act = "(trade in weeks)sales rep changed from:" + ocsalesrep + "To:" + csalesrep;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocTomgr, cTomgr) != 0)
    //        {
    //            string act = "(trade in weeks) TO manager changed from:" + ocTomgr + "To:" + cTomgr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(obuttonup, buttonup) != 0)
    //        {
    //            string act = "(trade in weeks)button up changed from:" + obuttonup + "To:" + buttonup;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(odealdate, dealdate) != 0)
    //        {
    //            string act = "(trade in weeks)deal date changed from:" + odealdate + "To:" + dealdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
    //        {
    //            string act = "(trade in weeks)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(odealstatus, dealstatus) != 0)
    //        {
    //            string act = "(trade in weeks) deal status changed from:" + odealstatus + "To:" + dealstatus;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
    //        {
    //            string act = "(trade in weeks)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocanxcontno, canxcontno) != 0)
    //        {
    //            string act = "(trade in weeks)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocanxdate, canxdate) != 0)
    //        {
    //            string act = "(trade in weeks)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(omcwv, mcwaiver) != 0)
    //        {
    //            string act = "(trade in weeks)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(oadhar, adhar) != 0)
    //        {
    //            string act = "(trade in weeks) adhar Card changed from:" + oadhar + "To:" + adhar;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opan, pancrd) != 0)
    //        {
    //            string act = "(trade in weeks) pan card changed from:" + opan + "To:" + pancrd;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otiw_Trade_In_Weeks_resort, tpresort) != 0)
    //        {
    //            string act = "(trade in weeks) club(trade in) changed from:" + otiw_Trade_In_Weeks_resort + "To:" + tpresort;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otiw_Trade_In_Weeks_Apt, apt) != 0)
    //        {
    //            string act = "(trade in weeks) Apt Type(trade in) changed from:" + otiw_Trade_In_Weeks_Apt + "To:" + apt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otiw_Trade_In_Weeks_Season, season) != 0)
    //        {
    //            string act = "(trade in weeks) Season(trade in) changed from:" + otiw_Trade_In_Weeks_Season + "To:" + season;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otiw_Trade_In_Weeks_NoWks, nowks) != 0)
    //        {
    //            string act = "(trade in weeks) No. Wks(trade in) changed from:" + otiw_Trade_In_Weeks_NoWks + "To:" + nowks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_Trade_In_Weeks_ContNo_RCINo, tpcontno) != 0)
    //        {
    //            string act = "(trade in weeks) cont.no (trade in) changed from:" + otiw_Trade_In_Weeks_ContNo_RCINo + "To:" + tpcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_Trade_In_Weeks_Points_value, tpptsval) != 0)
    //        {
    //            string act = "(trade in weeks) points value changed from:" + otiw_Trade_In_Weeks_Points_value + "To:" + tpptsval;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otiw_NewPointsW_Club, pts_club) != 0)
    //        {
    //            string act = "(trade in weeks) club name changed from:" + otiw_NewPointsW_Club + "To:" + pts_club;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_NewPointsW_Club_Points_Rights, pts_newpts) != 0)
    //        {
    //            string act = "(trade in weeks)new points changed from:" + otiw_NewPointsW_Club_Points_Rights + "To:" + pts_newpts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otiw_NewPointsW_MemebrshipType, pts_entitlement) != 0)
    //        {
    //            string act = "(trade in weeks)entitlement changed from:" + otiw_NewPointsW_MemebrshipType + "To:" + pts_entitlement;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_NewPointsW_Total_Points_rights, pts_totalpts) != 0)
    //        {
    //            string act = "(trade in weeks) total points changed from:" + otiw_NewPointsW_Total_Points_rights + "To:" + pts_totalpts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_NewPointsW_First_year_occupancy, pts_firstyr) != 0)
    //        {
    //            string act = "(trade in weeks) first yr changed from:" + otiw_NewPointsW_First_year_occupancy + "To:" + pts_firstyr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_NewPointsW_Tenure, pts_Tenure) != 0)
    //        {
    //            string act = "(trade in weeks)tenure changed from:" + otiw_NewPointsW_Tenure + "To:" + pts_Tenure;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_NewPointsW_Last_year_occupancy, pts_lastyr) != 0)
    //        {
    //            string act = "(trade in weeks) last yr changed from:" + otiw_NewPointsW_Last_year_occupancy + "To:" + pts_lastyr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiw_nopersons, pts_nopersons) != 0)
    //        {
    //            string act = "(trade in weeks) last yr changed from:" + otiw_nopersons + "To:" + pts_nopersons;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinance, finance) != 0)
    //        {
    //            string act = "(trade in weeks) financemethod changed from:" + ofinance + "To:" + finance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(omcfees, mcfees) != 0)
    //        {
    //            string act = "(trade in weeks) MC fees changed from:" + omcfees + "To:" + mcfees;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omcdate, mcdate) != 0)
    //        {
    //            string act = "(trade in weeks) MC Date changed from:" + omcdate + "To:" + mcdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omemberfee, memberfee) != 0)
    //        {
    //            string act = "(trade in weeks) member fee changed from:" + omemberfee + "To:" + memberfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omemebercgst, memebercgst) != 0)
    //        {
    //            string act = "(trade in weeks) MC cgst changed from:" + omemebercgst + "To:" + memebercgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(omembersgst, membersgst) != 0)
    //        {
    //            string act = "(trade in weeks) MC sgst changed from:" + omembersgst + "To:" + membersgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocurrency, currency) != 0)
    //        {
    //            string act = "(trade in weeks) Currency changed from:" + ocurrency + "To:" + currency;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oaffiliate, affiliate) != 0)
    //        {
    //            string act = "(trade in weeks) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalintax, totalintax) != 0)
    //        {
    //            string act = "(trade in weeks) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepamt, depamt) != 0)
    //        {
    //            string act = "(trade in weeks)deposit amount changed from:" + odepamt + "To:" + depamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalpayable, balpayable) != 0)
    //        {
    //            string act = "(trade in weeks)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obaladepamtdate, baldepdate) != 0)
    //        {
    //            string act = "(points)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepbal, depbal) != 0)
    //        {
    //            string act = "(trade in weeks)Balance deposit changed from:" + odepbal + "To:" + depbal;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoinstallment, noinstallment) != 0)
    //        {
    //            string act = "(trade in weeks) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oinstallment, installment) != 0)
    //        {
    //            string act = "(trade in weeks) Installment Amount changed from:" + oinstallment + "To:" + installment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
    //            {
    //                //check if contracttno exists in installment table if yes deleete if no  nothting
    //                //check previous valu of installment
    //                if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
    //                {

    //                }
    //                else
    //                {
    //                    //delete from installment table;
    //                }
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete from table
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }

    //                }
    //                else { }

    //            }
    //            else
    //            {
    //                //delete .//previous installment
    //                DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                {
    //                    string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                    string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                    string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                    string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                    string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                    string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                    string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                    int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                    int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                }
    //                for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                {
    //                    string installemnt_No = inst + " " + i;
    //                    ia = "textBox_" + i + "1";
    //                    iamt = Request.Form[ia];
    //                    idt = "textBox_" + i + "2";
    //                    idate = Request.Form[idt];

    //                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                    //update instalmentno
    //                    int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (CheckBox1.Checked == true)
    //            {
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete .//previous installment
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

    //                }
    //                else
    //                {
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


    //                }
    //            }
    //            else
    //            { }
    //        }
    //        if (String.Compare(ototalbalance, totalbalance) != 0)
    //        {
    //            string act = "(trade in weeks) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opaymethod, paymethod) != 0)
    //        {
    //            string act = "(trade in weeks) pay method changed from:" + opaymethod + "To:" + paymethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinancemethod, financemethod) != 0)
    //        {
    //            string act = "(trade in weeks)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oFinanceno, Financeno) != 0)
    //        {
    //            string act = "(trade in weeks) Finance no changed from:" + oFinanceno + "To:" + Financeno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinmonth, finmonth) != 0)
    //        {
    //            string act = "(trade in weeks) finance month changed from:" + ofinmonth + "To:" + finmonth;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoemi, noemi) != 0)
    //        {
    //            string act = "(trade in weeks) No of EMI changed from:" + onoemi + "To:" + noemi;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(oemiamt, emiamt) != 0)
    //        {
    //            string act = "(trade in weeks) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofindocfee, findocfee) != 0)
    //        {
    //            string act = "(trade in weeks) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oisgtrate, isgtrate) != 0)
    //        {
    //            string act = "(trade in weeks) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oigstamt, igstamt) != 0)
    //        {
    //            string act = "(trade in weeks) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ointerestrate, interestrate) != 0)
    //        {
    //            string act = "(trade in weeks)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onewpoints, newpoints) != 0)
    //        {
    //            string act = "(trade in weeks) New points changed from:" + onewpoints + "To:" + newpoints;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oconversionfee, conversionfee) != 0)
    //        {
    //            string act = "(trade in weeks) Conversion Fee changed from:" + oconversionfee + "To:" + conversionfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oadminfee, adminfee) != 0)
    //        {
    //            string act = "(trade in weeks)Admin Fee changed from:" + oadminfee + "To:" + adminfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototpurchprice, totpurchprice) != 0)
    //        {
    //            string act = "(trade in weeks) Purchase Price changed from:" + ototpurchprice + "To:" + totpurchprice;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocgst, cgst) != 0)
    //        {
    //            string act = "(trade in weeks) CGST changed from:" + ocgst + "To:" + cgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgst, sgst) != 0)
    //        {
    //            string act = "(trade in weeks)SGST changed from:" + osgst + "To:" + sgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalpriceInTax, totalpriceInTax) != 0)
    //        {
    //            string act = "(trade in weeks) Total Price including Tax (PA) changed from:" + ototalpriceInTax + "To:" + totalpriceInTax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odeposit, deposit) != 0)
    //        {
    //            string act = "(trade in weeks) Deposit(PA) changed from:" + odeposit + "To:" + deposit;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalance, balance) != 0)
    //        {
    //            string act = "(trade in weeks) Balance(PA) changed from:" + obalance + "To:" + balance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalancedue, balancedue) != 0)
    //        {
    //            string act = "(trade in weeks) balance due date(PA) changed from:" + obalancedue + "To:" + balancedue;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oremarks, remarks) != 0)
    //        {
    //            string act = "(trade in weeks) Remarks changed from:" + oremarks + "To:" + remarks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oPayment_Mode, paymentmode) != 0)
    //        {
    //            string act = "(trade in weeks)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oReceipt_Date, receiptdate) != 0)
    //        {
    //            string act = "(trade in weeks)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalamt, indeposit.ToString()) != 0)
    //        {
    //            string act = "(trade in weeks)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oAmount, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(trade in weeks)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(trade in weeks)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(trade in weeks)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(trade in weeks)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
    //        {
    //            installment = "0";
    //        }
    //        else
    //        {
    //            installment = installmentamtTextBox.Text;
    //        }
    //        if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
    //        {
    //            noinstallment = "0";
    //        }
    //        else
    //        {
    //            noinstallment = NoinstallmentTextBox.Text;
    //        }

    //        int updatepointscontract = Queries.UpdateContract_Trade_In_Weeks_Indian(tpresort, apt, season, nowks, tpcontno, tpptsval, pts_club, pts_newpts, pts_entitlement, pts_totalpts, pts_firstyr, pts_Tenure, pts_lastyr, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
    //        int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);

    //        int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);
    //        int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, "", "", "", baldepdate, "", ContractdetailsIDTextBox.Text);
    //        int updatecontractPA = Queries.UpdateContract_PA_Indian(newpoints, conversionfee, adminfee, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
    //        //  int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);

    //        string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
    //        LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
    //        Response.Redirect(Request.RawUrl);
    //    }
    //    else if (contract == "Fractional")
    //    {
    //        DataSet dstif = Queries.loadtradeinfractional(ContractdetailsIDTextBox.Text);
    //        otifresort = dstif.Tables[0].Rows[0]["resort"].ToString();
    //        otifresidence_no = dstif.Tables[0].Rows[0]["residence_no"].ToString();
    //        otifresidence_type = dstif.Tables[0].Rows[0]["residence_type"].ToString();
    //        otiffractional_interest = dstif.Tables[0].Rows[0]["fractional_interest"].ToString();
    //        otifentitlement = dstif.Tables[0].Rows[0]["entitlement"].ToString();
    //        otiffirstyear_Occupancy = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
    //        otiftenure = dstif.Tables[0].Rows[0]["tenure"].ToString();
    //        otiflastyear_Occupancy = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();
    //        otifleaseback = dstif.Tables[0].Rows[0]["leaseback"].ToString();
    //        otifMc_Charges = dstif.Tables[0].Rows[0]["Mc_Charges"].ToString();
    //        otifOldcontracttype = dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString();
    //        otifRESORT = dstif.Tables[0].Rows[0]["tradeinresort"].ToString();
    //        otifAPT_TYPE = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString();
    //        otifSEASON = dstif.Tables[0].Rows[0]["SEASON"].ToString();
    //        otifNO_WEEKS = dstif.Tables[0].Rows[0]["NO_WEEKS"].ToString();
    //        otifNO_POINTS = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
    //        otifPOINTS_VALUE = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();
    //        otifoldContract_No = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
    //        otifSales_Rep = dstif.Tables[0].Rows[0]["Sales_Rep"].ToString();
    //        otifTO_Manager = dstif.Tables[0].Rows[0]["TO_Manager"].ToString();
    //        otifButtonUp_Officer = dstif.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
    //        otifDealRegistered_Date = dstif.Tables[0].Rows[0]["DealRegistered_Date"].ToString();
    //        otifDealStatus = dstif.Tables[0].Rows[0]["DealStatus"].ToString();
    //        otifMCWaiver = dstif.Tables[0].Rows[0]["MCWaiver"].ToString();
    //        otifFinance_Details = dstif.Tables[0].Rows[0]["Finance_Details"].ToString();
    //        otifContract_Remark = dstif.Tables[0].Rows[0]["Contract_Remark"].ToString();
    //        otifPan_Card = dstif.Tables[0].Rows[0]["Pan_Card"].ToString();
    //        otifAdhar_Card = dstif.Tables[0].Rows[0]["Adhar_Card"].ToString();
    //        otifMC_Charges = dstif.Tables[0].Rows[0]["MC_Charges"].ToString();
    //        otifFirst_MC_Payable_Date = dstif.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
    //        otifMemberFee = dstif.Tables[0].Rows[0]["MemberFee"].ToString();
    //        otifMemberCGST = dstif.Tables[0].Rows[0]["MemberCGST"].ToString();
    //        otifMembersGST = dstif.Tables[0].Rows[0]["MembersGST"].ToString();
    //        oloanbuofficer = dstif.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
    //        ocanxcontno = dstif.Tables[0].Rows[0]["CanxContractNo"].ToString();
    //        ocanxdate = dstif.Tables[0].Rows[0]["Contract_Canx_date"].ToString();


    //        DataSet dsfpa = Queries.LoadfractionalPA(ContractdetailsIDTextBox.Text);
    //        ofctAdmission_fees = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
    //        ofctadministration_fees = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
    //        ofctCgst = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
    //        ofctSgst = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
    //        ofctTotal_Purchase_Price = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
    //        ofctTotal_Price_Including_Tax = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
    //        ofctDeposit = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
    //        ofctBalance = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
    //        ofctBalance_Due_Dates = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
    //        ofctRemarks = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();



    //        string tpresort = tnmresortTextBox.Text;
    //        string apt = tnmapttypeTextBox.Text;

    //        //  string season = tnmseasonDropDownList.SelectedItem.Text;

    //        string season = Request.Form[tnmseasonDropDownList.UniqueID];
    //        if (season == null || season == "")
    //        {
    //            season = "";
    //        }
    //        else
    //        {
    //            season = Request.Form[tnmseasonDropDownList.UniqueID];
    //        }
    //        string nowks = nmnowksTextBox.Text;
    //        string tpcontno = nmcontrcinoTextBox.Text;
    //        string tpnopts = tipnopointsTextBox.Text;
    //        string tpptsval = tipptsvalueTextBox.Text;
    //        string resort = fwresortDropDownList.SelectedItem.Text;
    //        string residence_no = fwresidencenoDropDownList.SelectedItem.Text;
    //        string residence_type = fwresidencetypeDropDownList.SelectedItem.Text;
    //        string fractional_interest = fwfractIntDropDownList.SelectedItem.Text;
    //        string entitlement = fwentitlementDropDownList.SelectedItem.Text;
    //        string firstyear_Occupancy = fwfirstyrTextBox.Text;
    //        string tenure = fwtenureTextBox.Text;
    //        string lastyear_Occupancy = fwlastyrTextBox.Text;
    //        string ocontracttype = oldcontracttypeDropDownList.SelectedItem.Text;



    //        string adminfee = adminfeeTextBox.Text;
    //        string oAdministrationFees = AdministrationFeesTextBox.Text;
    //        string totpurchprice = totpurchpriceTextBox.Text;
    //        string cgst = cgstTextBox.Text;
    //        string sgst = sgstTextBox.Text;
    //        string totalpriceInTax = totalpriceInTaxTextBox.Text;
    //        string deposit = depositTextBox.Text;
    //        string balance = balanceTextBox.Text;
    //        string balancedue = balancedueTextBox.Text;
    //        string remarks = remarksTextBox.Text;

    //        if (mcRadioButtonList.Checked == true)
    //        {
    //            mcwaiver = "Yes";
    //        }
    //        else
    //        {
    //            mcwaiver = "No";

    //        }
    //        if (String.Compare(ocompanyname, ncompanyname) != 0)
    //        {
    //            int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
    //            string act = "(fractional)company name changed from:" + ocompanyname + "To:" + ncompanyname;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocogstin, ngstin) != 0)
    //        {
    //            string act = "(fractional)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocontractno, contractno) != 0)
    //        {
    //            //update in installment table
    //            int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
    //            if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContractNo_Othernames_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContractNo_Othernames_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }

    //            string act = "(fractional)Contract NO changed from:" + ocontractno + "To:" + contractno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifSales_Rep, csalesrep) != 0)
    //        {
    //            string act = "(fractional)sales rep changed from:" + otifSales_Rep + "To:" + csalesrep;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifTO_Manager, cTomgr) != 0)
    //        {
    //            string act = "(fractional) TO manager changed from:" + otifTO_Manager + "To:" + cTomgr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifButtonUp_Officer, buttonup) != 0)
    //        {
    //            string act = "(fractional)button up changed from:" + otifButtonUp_Officer + "To:" + buttonup;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifDealRegistered_Date, dealdate) != 0)
    //        {
    //            string act = "(fractional)deal date changed from:" + otifDealRegistered_Date + "To:" + dealdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
    //        {
    //            string act = "(fractional)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifDealStatus, dealstatus) != 0)
    //        {
    //            string act = "(fractional) deal status changed from:" + otifDealStatus + "To:" + dealstatus;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
    //        {
    //            string act = "(fractional)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocanxcontno, canxcontno) != 0)
    //        {
    //            string act = "(fractional)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocanxdate, canxdate) != 0)
    //        {
    //            string act = "(fractional)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifMCWaiver, mcwaiver) != 0)
    //        {
    //            string act = "(fractional)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifAdhar_Card, adhar) != 0)
    //        {
    //            string act = "(fractional) adhar Card changed from:" + otifAdhar_Card + "To:" + adhar;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifPan_Card, pancrd) != 0)
    //        {
    //            string act = "(fractional) pan card changed from:" + otifPan_Card + "To:" + pancrd;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifOldcontracttype, ocontracttype) != 0)
    //        {
    //            string act = "(fractional) Old Contract Type changed from:" + otifOldcontracttype + "To:" + ocontracttype;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifRESORT, tpresort) != 0)
    //        {
    //            string act = "(fractional) Resort(trade in) changed from:" + otifRESORT + "To:" + tpresort;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifAPT_TYPE, apt) != 0)
    //        {
    //            string act = "(fractional) Apt Type(trade in) changed from:" + otifAPT_TYPE + "To:" + apt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifSEASON, season) != 0)
    //        {
    //            string act = "(fractional) Season(trade in) changed from:" + otifSEASON + "To:" + season;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifNO_WEEKS, nowks) != 0)
    //        {
    //            string act = "(fractional) No. Wks(trade in) changed from:" + otifNO_WEEKS + "To:" + nowks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifoldContract_No, tpcontno) != 0)
    //        {
    //            string act = "(fractional) cont.no (trade in) changed from:" + otifoldContract_No + "To:" + tpcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
    //        {
    //            string act = "(fractional)no.of points value changed from:" + otifNO_POINTS + "To:" + tpnopts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
    //        {
    //            string act = "(fractional) points value changed from:" + otifPOINTS_VALUE + "To:" + tpptsval;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifresort, resort) != 0)
    //        {
    //            string act = "(fractional) points value changed from:" + otifresort + "To:" + resort;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifresidence_no, residence_no) != 0)
    //        {
    //            string act = "(fractional) residence_no value changed from:" + otifresidence_no + "To:" + residence_no;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifresidence_type, residence_type) != 0)
    //        {
    //            string act = "(fractional) residence_type value changed from:" + otifresidence_type + "To:" + residence_type;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiffractional_interest, fractional_interest) != 0)
    //        {
    //            string act = "(fractional) fractional_interest value changed from:" + otiffractional_interest + "To:" + fractional_interest;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifentitlement, entitlement) != 0)
    //        {
    //            string act = "(fractional) Entitlement value changed from:" + otifentitlement + "To:" + entitlement;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiffirstyear_Occupancy, firstyear_Occupancy) != 0)
    //        {
    //            string act = "(fractional) First Yr Occupancy value changed from:" + otiffirstyear_Occupancy + "To:" + firstyear_Occupancy;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiftenure, tenure) != 0)
    //        {
    //            string act = "(fractional) Tenure changed from:" + otiftenure + "To:" + tenure;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiflastyear_Occupancy, lastyear_Occupancy) != 0)
    //        {
    //            string act = "(fractional) Last Yr Occupancy value changed from:" + otiflastyear_Occupancy + "To:" + lastyear_Occupancy;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifFinance_Details, finance) != 0)
    //        {
    //            string act = "(fractional) financemethod changed from:" + otifFinance_Details + "To:" + finance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(otifMC_Charges, mcfees) != 0)
    //        {
    //            string act = "(fractional) MC fees changed from:" + otifMC_Charges + "To:" + mcfees;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifFirst_MC_Payable_Date, mcdate) != 0)
    //        {
    //            string act = "(fractional) MC Date changed from:" + otifFirst_MC_Payable_Date + "To:" + mcdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifMemberFee, memberfee) != 0)
    //        {
    //            string act = "(fractional) member fee changed from:" + otifMemberFee + "To:" + memberfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifMemberCGST, memebercgst) != 0)
    //        {
    //            string act = "(fractional) MC cgst changed from:" + otifMemberCGST + "To:" + memebercgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifMembersGST, membersgst) != 0)
    //        {
    //            string act = "(fractional) MC sgst changed from:" + otifMembersGST + "To:" + membersgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocurrency, currency) != 0)
    //        {
    //            string act = "(fractional) Currency changed from:" + ocurrency + "To:" + currency;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oaffiliate, affiliate) != 0)
    //        {
    //            string act = "(fractional) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalintax, totalintax) != 0)
    //        {
    //            string act = "(fractional) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepamt, depamt) != 0)
    //        {
    //            string act = "(fractional)deposit amount changed from:" + odepamt + "To:" + depamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalpayable, balpayable) != 0)
    //        {
    //            string act = "(fractional)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obaladepamtdate, baldepdate) != 0)
    //        {
    //            string act = "(fractional)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepbal, depbal) != 0)
    //        {
    //            string act = "(fractional)Balance deposit changed from:" + odepbal + "To:" + depbal;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oregcollectionterm, regcollectionterm) != 0)
    //        {
    //            string act = "(fractional)reg collection term changed from:" + oregcollectionterm + "To:" + regcollectionterm;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oregcollamt, regcollamt) != 0)
    //        {
    //            string act = "(fractional)reg collection amt changed from:" + oregcollamt + "To:" + regcollamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ooldLoanAgreement, oldloanagreementno) != 0)
    //        {
    //            string act = "(fractional)old loan agreement no changed from:" + ooldLoanAgreement + "To:" + oldloanagreementno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ooldloanamt, loanamt) != 0)
    //        {
    //            string act = "(fractional)old loan amt changed from:" + ooldloanamt + "To:" + loanamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoinstallment, noinstallment) != 0)
    //        {
    //            string act = "(fractional) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oinstallment, installment) != 0)
    //        {
    //            string act = "(fractional) Installment Amount changed from:" + oinstallment + "To:" + installment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
    //            {
    //                //check if contracttno exists in installment table if yes deleete if no  nothting
    //                //check previous valu of installment
    //                if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
    //                {

    //                }
    //                else
    //                {
    //                    //delete from installment table;
    //                }
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete from table
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }

    //                }
    //                else { }

    //            }
    //            else
    //            {
    //                //delete .//previous installment
    //                DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                {
    //                    string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                    string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                    string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                    string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                    string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                    string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                    string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                    int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                    int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                }
    //                for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                {
    //                    string installemnt_No = inst + " " + i;
    //                    ia = "textBox_" + i + "1";
    //                    iamt = Request.Form[ia];
    //                    idt = "textBox_" + i + "2";
    //                    idate = Request.Form[idt];

    //                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                    //update instalmentno
    //                    int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (CheckBox1.Checked == true)
    //            {
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete .//previous installment
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

    //                }
    //                else
    //                {
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


    //                }
    //            }
    //            else
    //            { }

    //        }
    //        if (String.Compare(ototalbalance, totalbalance) != 0)
    //        {
    //            string act = "(fractional) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opaymethod, paymethod) != 0)
    //        {
    //            string act = "(fractional) pay method changed from:" + opaymethod + "To:" + paymethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinancemethod, financemethod) != 0)
    //        {
    //            string act = "(fractional)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oFinanceno, Financeno) != 0)
    //        {
    //            string act = "(fractional) Finance no changed from:" + oFinanceno + "To:" + Financeno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinmonth, finmonth) != 0)
    //        {
    //            string act = "(fractional) finance month changed from:" + ofinmonth + "To:" + finmonth;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoemi, noemi) != 0)
    //        {
    //            string act = "(fractional) No of EMI changed from:" + onoemi + "To:" + noemi;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(oemiamt, emiamt) != 0)
    //        {
    //            string act = "(fractional) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofindocfee, findocfee) != 0)
    //        {
    //            string act = "(fractional) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oisgtrate, isgtrate) != 0)
    //        {
    //            string act = "(fractional) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oigstamt, igstamt) != 0)
    //        {
    //            string act = "(fractional) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ointerestrate, interestrate) != 0)
    //        {
    //            string act = "(fractional)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctAdmission_fees, adminfee) != 0)
    //        {
    //            string act = "(fractional)Admission fees changed from:" + ofctAdmission_fees + "To:" + adminfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctadministration_fees, oAdministrationFees) != 0)
    //        {
    //            string act = "(fractional)Administration Fees changed from:" + ofctadministration_fees + "To:" + oAdministrationFees;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctCgst, cgst) != 0)
    //        {
    //            string act = "(fractional)CGST amt changed from:" + ofctCgst + "To:" + cgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctSgst, sgst) != 0)
    //        {
    //            string act = "(fractional) SGST amt changed from:" + ofctSgst + "To:" + sgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctTotal_Purchase_Price, totpurchprice) != 0)
    //        {
    //            string act = "(fractional)Total purchase price changed from:" + ofctTotal_Purchase_Price + "To:" + totpurchprice;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctTotal_Price_Including_Tax, totalpriceInTax) != 0)
    //        {
    //            string act = "(fractional)Total price In. Tax changed from:" + ofctTotal_Price_Including_Tax + "To:" + totalpriceInTax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctDeposit, deposit) != 0)
    //        {
    //            string act = "(fractional)Deposit changed from:" + ofctDeposit + "To:" + deposit;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctBalance, balance) != 0)
    //        {
    //            string act = "(fractional)balance Rate changed from:" + ofctBalance + "To:" + balance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctBalance_Due_Dates, balancedue) != 0)
    //        {
    //            string act = "(fractional)balance due changed from:" + ofctBalance_Due_Dates + "To:" + balancedue;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctRemarks, remarks) != 0)
    //        {
    //            string act = "(fractional)remarks changed from:" + ofctRemarks + "To:" + remarks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oPayment_Mode, paymentmode) != 0)
    //        {
    //            string act = "(fractional)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oReceipt_Date, receiptdate) != 0)
    //        {
    //            string act = "(fractional)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ototalamt, indeposit.ToString()) != 0)
    //        {
    //            string act = "(fractional)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oAmount, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(fractional)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(fractional)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(fractional)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(fractional)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
    //        {
    //            installment = "0";
    //        }
    //        else
    //        {
    //            installment = installmentamtTextBox.Text;
    //        }
    //        if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
    //        {
    //            noinstallment = "0";
    //        }
    //        else
    //        {
    //            noinstallment = NoinstallmentTextBox.Text;
    //        }
    //        int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);

    //        int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);
    //        int updatecontractPA = Queries.UpdateContract_FractionalPA_Indian(adminfee, oAdministrationFees, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, "", "", ContractdetailsIDTextBox.Text);
    //        int updatefractionalcontract = Queries.UpdateContract_Fractional_Indian(resort, residence_no, residence_type, fractional_interest, entitlement, firstyear_Occupancy, tenure, lastyear_Occupancy, "", mcfees, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);


    //        int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, "", "", "", baldepdate, "", ContractdetailsIDTextBox.Text);
    //        // int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);


    //        string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
    //        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
    //        LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
    //        Response.Redirect(Request.RawUrl);

    //    }
    //    else if (contract == "Trade-In-Fractionals")
    //    {
    //        DataSet dstif = Queries.loadtradeinfractional(ContractdetailsIDTextBox.Text);
    //        otifresort = dstif.Tables[0].Rows[0]["resort"].ToString();
    //        otifresidence_no = dstif.Tables[0].Rows[0]["residence_no"].ToString();
    //        otifresidence_type = dstif.Tables[0].Rows[0]["residence_type"].ToString();
    //        otiffractional_interest = dstif.Tables[0].Rows[0]["fractional_interest"].ToString();
    //        otifentitlement = dstif.Tables[0].Rows[0]["entitlement"].ToString();
    //        otiffirstyear_Occupancy = dstif.Tables[0].Rows[0]["firstyear_Occupancy"].ToString();
    //        otiftenure = dstif.Tables[0].Rows[0]["tenure"].ToString();
    //        otiflastyear_Occupancy = dstif.Tables[0].Rows[0]["lastyear_Occupancy"].ToString();
    //        otifleaseback = dstif.Tables[0].Rows[0]["leaseback"].ToString();
    //        otifMc_Charges = dstif.Tables[0].Rows[0]["Mc_Charges"].ToString();
    //        otifOldcontracttype = dstif.Tables[0].Rows[0]["Oldcontracttype"].ToString();
    //        otifRESORT = dstif.Tables[0].Rows[0]["tradeinresort"].ToString();
    //        otifAPT_TYPE = dstif.Tables[0].Rows[0]["APT_TYPE"].ToString();
    //        otifSEASON = dstif.Tables[0].Rows[0]["SEASON"].ToString();
    //        otifNO_WEEKS = dstif.Tables[0].Rows[0]["NO_WEEKS"].ToString();
    //        otifNO_POINTS = dstif.Tables[0].Rows[0]["NO_POINTS"].ToString();
    //        otifPOINTS_VALUE = dstif.Tables[0].Rows[0]["POINTS_VALUE"].ToString();
    //        otifoldContract_No = dstif.Tables[0].Rows[0]["oldContract_No"].ToString();
    //        otifSales_Rep = dstif.Tables[0].Rows[0]["Sales_Rep"].ToString();
    //        otifTO_Manager = dstif.Tables[0].Rows[0]["TO_Manager"].ToString();
    //        otifButtonUp_Officer = dstif.Tables[0].Rows[0]["ButtonUp_Officer"].ToString();
    //        otifDealRegistered_Date = dstif.Tables[0].Rows[0]["DealRegistered_Date"].ToString();
    //        otifDealStatus = dstif.Tables[0].Rows[0]["DealStatus"].ToString();
    //        otifMCWaiver = dstif.Tables[0].Rows[0]["MCWaiver"].ToString();
    //        otifFinance_Details = dstif.Tables[0].Rows[0]["Finance_Details"].ToString();
    //        otifContract_Remark = dstif.Tables[0].Rows[0]["Contract_Remark"].ToString();
    //        otifPan_Card = dstif.Tables[0].Rows[0]["Pan_Card"].ToString();
    //        otifAdhar_Card = dstif.Tables[0].Rows[0]["Adhar_Card"].ToString();
    //        otifMC_Charges = dstif.Tables[0].Rows[0]["MC_Charges"].ToString();
    //        otifFirst_MC_Payable_Date = dstif.Tables[0].Rows[0]["First_MC_Payable_Date"].ToString();
    //        otifMemberFee = dstif.Tables[0].Rows[0]["MemberFee"].ToString();
    //        otifMemberCGST = dstif.Tables[0].Rows[0]["MemberCGST"].ToString();
    //        otifMembersGST = dstif.Tables[0].Rows[0]["MembersGST"].ToString();
    //        oloanbuofficer = dstif.Tables[0].Rows[0]["Loan_BU_officer"].ToString();
    //        ocanxcontno = dstif.Tables[0].Rows[0]["CanxContractNo"].ToString();
    //        ocanxdate = dstif.Tables[0].Rows[0]["Contract_Canx_date"].ToString();

    //        DataSet dsfpa = Queries.LoadfractionalPA(ContractdetailsIDTextBox.Text);
    //        otradeinvalue = dsfpa.Tables[0].Rows[0]["TradeIn_value"].ToString();
    //        ototalvalue = dsfpa.Tables[0].Rows[0]["Total_value"].ToString();
    //        ofctAdmission_fees = dsfpa.Tables[0].Rows[0]["Admission_fees"].ToString();
    //        ofctadministration_fees = dsfpa.Tables[0].Rows[0]["administration_fees"].ToString();
    //        ofctCgst = dsfpa.Tables[0].Rows[0]["Cgst"].ToString();
    //        ofctSgst = dsfpa.Tables[0].Rows[0]["Sgst"].ToString();
    //        ofctTotal_Purchase_Price = dsfpa.Tables[0].Rows[0]["Total_Purchase_Price"].ToString();
    //        ofctTotal_Price_Including_Tax = dsfpa.Tables[0].Rows[0]["Total_Price_Including_Tax"].ToString();
    //        ofctDeposit = dsfpa.Tables[0].Rows[0]["Deposit"].ToString();
    //        ofctBalance = dsfpa.Tables[0].Rows[0]["Balance"].ToString();
    //        ofctBalance_Due_Dates = dsfpa.Tables[0].Rows[0]["Balance_Due_Dates"].ToString();
    //        ofctRemarks = dsfpa.Tables[0].Rows[0]["Remarks"].ToString();


    //        string tpresort = tnmresortTextBox.Text;
    //        string apt = tnmapttypeTextBox.Text;
    //        string season;
    //        if (Request.Form[tnmseasonDropDownList.UniqueID] == "")
    //        {
    //            season = "";

    //        }
    //        else
    //        {
    //            season = Request.Form[tnmseasonDropDownList.UniqueID];

    //        }
    //        string tradeinresort = tnmresortTextBox.Text;
    //        string nowks = nmnowksTextBox.Text;
    //        string tpcontno = nmcontrcinoTextBox.Text;
    //        string tpnopts = tipnopointsTextBox.Text;
    //        string tpptsval = tipptsvalueTextBox.Text;
    //        string resort = fwresortDropDownList.SelectedItem.Text;
    //        string residence_no = fwresidencenoDropDownList.SelectedItem.Text;
    //        string residence_type = fwresidencetypeDropDownList.SelectedItem.Text;
    //        string fractional_interest = fwfractIntDropDownList.SelectedItem.Text;
    //        string entitlement = fwentitlementDropDownList.SelectedItem.Text;
    //        string firstyear_Occupancy = fwfirstyrTextBox.Text;
    //        string tenure = fwtenureTextBox.Text;
    //        string lastyear_Occupancy = fwlastyrTextBox.Text;
    //        string ocontracttype = oldcontracttypeDropDownList.SelectedItem.Text;



    //        string tradeinvalue = ftradeinvalueTextBox.Text;
    //        string totalvalue = ftotalvalueTextBox.Text;

    //        string adminfee = adminfeeTextBox.Text;
    //        string oAdministrationFees = AdministrationFeesTextBox.Text;
    //        string totpurchprice = totpurchpriceTextBox.Text;
    //        string cgst = cgstTextBox.Text;
    //        string sgst = sgstTextBox.Text;
    //        string totalpriceInTax = totalpriceInTaxTextBox.Text;
    //        string deposit = depositTextBox.Text;
    //        string balance = balanceTextBox.Text;
    //        string balancedue = balancedueTextBox.Text;
    //        string remarks = remarksTextBox.Text;

    //        if (mcRadioButtonList.Checked == true)
    //        {
    //            mcwaiver = "Yes";
    //        }
    //        else
    //        {
    //            mcwaiver = "No";

    //        }
    //        if (String.Compare(ocompanyname, ncompanyname) != 0)
    //        {
    //            int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
    //            string act = "(trade in fractional)company name changed from:" + ocompanyname + "To:" + ncompanyname;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocogstin, ngstin) != 0)
    //        {
    //            string act = "(trade in fractional)company GSTIN changed from:" + ocogstin + "To:" + ngstin;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocontractno, contractno) != 0)
    //        {
    //            //update in installment table
    //            int updaterow = Queries.UpdateInstallmentdetails_Indian(contractno, ContractdetailsIDTextBox.Text);
    //            if (Queries.CheckFinanceBreakup_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateFinanceBreakup_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContractNo_Othernames_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContractNo_Othernames_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }
    //            if (Queries.CheckContract_Indian_Deposit_Receipt_ContractNoExists(ContractdetailsIDTextBox.Text) == 1)
    //            {
    //                int updatebkrup = Queries.UpdateContract_Indian_Deposit_Receipt_ContractNo(contractno, ContractdetailsIDTextBox.Text);
    //            }
    //            else { }

    //            string act = "(trade in fractional)Contract NO changed from:" + ocontractno + "To:" + contractno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifSales_Rep, csalesrep) != 0)
    //        {
    //            string act = "(trade in fractional)sales rep changed from:" + otifSales_Rep + "To:" + csalesrep;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifTO_Manager, cTomgr) != 0)
    //        {
    //            string act = "(trade in fractional) TO manager changed from:" + otifTO_Manager + "To:" + cTomgr;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifButtonUp_Officer, buttonup) != 0)
    //        {
    //            string act = "(trade in fractional)button up changed from:" + otifButtonUp_Officer + "To:" + buttonup;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifDealRegistered_Date, dealdate) != 0)
    //        {
    //            string act = "(trade in fractional)deal date changed from:" + otifDealRegistered_Date + "To:" + dealdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(wkno.ToString(), dealwkno.ToString()) != 0)
    //        {
    //            string act = "(trade in fractional)deal wk no changed from:" + wkno.ToString() + "To:" + dealwkno.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifDealStatus, dealstatus) != 0)
    //        {
    //            string act = "(trade in fractional) deal status changed from:" + otifDealStatus + "To:" + dealstatus;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oloanbuofficer, loanbuofficer) != 0)
    //        {
    //            string act = "(trade in fractional)Contract NO changed from:" + oloanbuofficer + "To:" + loanbuofficer;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocanxcontno, canxcontno) != 0)
    //        {
    //            string act = "(trade in fractional)Canx Contract NO changed from:" + ocanxcontno + "To:" + canxcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocanxdate, canxdate) != 0)
    //        {
    //            string act = "(trade in fractional)Contract Canx date changed from:" + ocanxdate + "To:" + canxdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifMCWaiver, mcwaiver) != 0)
    //        {
    //            string act = "(trade in fractional)mc waiver changed from:" + omcwv + "To:" + mcwaiver;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifAdhar_Card, adhar) != 0)
    //        {
    //            string act = "(trade in fractional) adhar Card changed from:" + otifAdhar_Card + "To:" + adhar;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifPan_Card, pancrd) != 0)
    //        {
    //            string act = "(trade in fractional) pan card changed from:" + otifPan_Card + "To:" + pancrd;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifOldcontracttype, ocontracttype) != 0)
    //        {
    //            string act = "(trade in fractional) Old Contract Type changed from:" + otifOldcontracttype + "To:" + ocontracttype;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifRESORT, tradeinresort) != 0)
    //        {
    //            string act = "(trade in fractional) Resort(trade in) changed from:" + otifRESORT + "To:" + tradeinresort;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifAPT_TYPE, apt) != 0)
    //        {
    //            string act = "(trade in fractional) Apt Type(trade in) changed from:" + otifAPT_TYPE + "To:" + apt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifSEASON, season) != 0)
    //        {
    //            string act = "(trade in fractional) Season(trade in) changed from:" + otifSEASON + "To:" + season;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }


    //        if (String.Compare(otifNO_WEEKS, nowks) != 0)
    //        {
    //            string act = "(trade in fractional) No. Wks(trade in) changed from:" + otifNO_WEEKS + "To:" + nowks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifoldContract_No, tpcontno) != 0)
    //        {
    //            string act = "(trade in fractional) cont.no (trade in) changed from:" + otifoldContract_No + "To:" + tpcontno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
    //        {
    //            string act = "(trade in fractional)no.of points value changed from:" + otifNO_POINTS + "To:" + tpnopts;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifPOINTS_VALUE, tpptsval) != 0)
    //        {
    //            string act = "(trade in fractional) points value changed from:" + otifPOINTS_VALUE + "To:" + tpptsval;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifresort, resort) != 0)
    //        {
    //            string act = "(trade in fractional) points value changed from:" + otifresort + "To:" + resort;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifresidence_no, residence_no) != 0)
    //        {
    //            string act = "(trade in fractional) residence_no value changed from:" + otifresidence_no + "To:" + residence_no;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifresidence_type, residence_type) != 0)
    //        {
    //            string act = "(trade in fractional) residence_type value changed from:" + otifresidence_type + "To:" + residence_type;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiffractional_interest, fractional_interest) != 0)
    //        {
    //            string act = "(trade in fractional) fractional_interest value changed from:" + otiffractional_interest + "To:" + fractional_interest;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifentitlement, entitlement) != 0)
    //        {
    //            string act = "(trade in fractional) Entitlement value changed from:" + otifentitlement + "To:" + entitlement;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiffirstyear_Occupancy, firstyear_Occupancy) != 0)
    //        {
    //            string act = "(trade in fractional) First Yr Occupancy value changed from:" + otiffirstyear_Occupancy + "To:" + firstyear_Occupancy;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiftenure, tenure) != 0)
    //        {
    //            string act = "(trade in fractional) Tenure changed from:" + otiftenure + "To:" + tenure;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otiflastyear_Occupancy, lastyear_Occupancy) != 0)
    //        {
    //            string act = "(trade in fractional) Last Yr Occupancy value changed from:" + otiflastyear_Occupancy + "To:" + lastyear_Occupancy;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(otifFinance_Details, finance) != 0)
    //        {
    //            string act = "(trade in fractional) financemethod changed from:" + otifFinance_Details + "To:" + finance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(otifMC_Charges, mcfees) != 0)
    //        {
    //            string act = "(trade in fractional) MC fees changed from:" + otifMC_Charges + "To:" + mcfees;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifFirst_MC_Payable_Date, mcdate) != 0)
    //        {
    //            string act = "(trade in fractional) MC Date changed from:" + otifFirst_MC_Payable_Date + "To:" + mcdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifMemberFee, memberfee) != 0)
    //        {
    //            string act = "(trade in fractional) member fee changed from:" + otifMemberFee + "To:" + memberfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifMemberCGST, memebercgst) != 0)
    //        {
    //            string act = "(trade in fractional) MC cgst changed from:" + otifMemberCGST + "To:" + memebercgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otifMembersGST, membersgst) != 0)
    //        {
    //            string act = "(trade in fractional) MC sgst changed from:" + otifMembersGST + "To:" + membersgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ocurrency, currency) != 0)
    //        {
    //            string act = "(trade in fractional) Currency changed from:" + ocurrency + "To:" + currency;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oaffiliate, affiliate) != 0)
    //        {
    //            string act = "(trade in fractional) Affiliation changed from:" + oaffiliate + "To:" + affiliate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalintax, totalintax) != 0)
    //        {
    //            string act = "(trade in fractional) Total price including tax changed from:" + ototalintax + "To:" + totalintax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepamt, depamt) != 0)
    //        {
    //            string act = "(trade in fractional)deposit amount changed from:" + odepamt + "To:" + depamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obalpayable, balpayable) != 0)
    //        {
    //            string act = "(trade in fractional)deposit mount(bal) changed from:" + obalpayable + "To:" + balpayable;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(obaladepamtdate, baldepdate) != 0)
    //        {
    //            string act = "(trade in fractional)deposit amount(bal) Date changed from:" + obaladepamtdate + "To:" + baldepdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(odepbal, depbal) != 0)
    //        {
    //            string act = "(trade in fractional)Balance deposit changed from:" + odepbal + "To:" + depbal;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoinstallment, noinstallment) != 0)
    //        {
    //            string act = "(trade in fractional) No of installment changed from:" + onoinstallment + "To:" + noinstallment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oinstallment, installment) != 0)
    //        {
    //            string act = "(trade in fractional) Installment Amount changed from:" + oinstallment + "To:" + installment;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN")
    //            {
    //                //check if contracttno exists in installment table if yes deleete if no  nothting
    //                //check previous valu of installment
    //                if (onoinstallment == "" || onoinstallment == "0" || onoinstallment == "NaN")
    //                {

    //                }
    //                else
    //                {
    //                    //delete from installment table;
    //                }
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete from table
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);//.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }

    //                }
    //                else { }

    //            }
    //            else
    //            {
    //                //delete .//previous installment
    //                DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                {
    //                    string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                    string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                    string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                    string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                    string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                    string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                    string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                    int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(ProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                    int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                }
    //                for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                {
    //                    string installemnt_No = inst + " " + i;
    //                    ia = "textBox_" + i + "1";
    //                    iamt = Request.Form[ia];
    //                    idt = "textBox_" + i + "2";
    //                    idate = Request.Form[idt];

    //                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                    string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                    int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                    //update instalmentno
    //                    int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (CheckBox1.Checked == true)
    //            {
    //                int exists = Queries.ContractNoInInstallmentTable(ContractdetailsIDTextBox.Text);
    //                if (exists == 1)
    //                {
    //                    //delete .//previous installment
    //                    DataSet dsin = Queries.LoadcontractInstallment(ContractdetailsIDTextBox.Text);
    //                    for (int j = 0; j < dsin.Tables[0].Rows.Count; j++)
    //                    {
    //                        string Installment_ID = dsin.Tables[0].Rows[j]["Installment_ID"].ToString();
    //                        string iProfileID = dsin.Tables[0].Rows[j]["ProfileID"].ToString();
    //                        string ContractNo = dsin.Tables[0].Rows[j]["ContractNo"].ToString();
    //                        string Installment_no = dsin.Tables[0].Rows[j]["Installment_no"].ToString();
    //                        string Installment_Amount = dsin.Tables[0].Rows[j]["Installment_Amount"].ToString();
    //                        string Installment_Date = dsin.Tables[0].Rows[j]["Installment_Date"].ToString();
    //                        string Installment_Invoice_No = dsin.Tables[0].Rows[j]["Installment_Invoice_No"].ToString();
    //                        int insertdel = Queries.InsertContract_Installments_Indian_Deleted(Installment_ID, iProfileID, ContractNo, Installment_no, Installment_Amount, Installment_Date, Installment_Invoice_No, DateTime.Now.ToString(), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details Deleted:" + "Profile id: " + iProfileID + "," + "ContractNo: " + ContractNo + "," + "Installment #:" + Installment_no + "," + "Installment Amt:" + Installment_Amount + "," + "Installment Date:" + Installment_Date + "," + "Installment_Invoice_No:" + Installment_Invoice_No + "," + "Deleted Datetime:" + DateTime.Now.ToString() + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(iProfileID, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());

    //                        int delrow = Queries.DeleteContract_Installments_Indian(Installment_ID);
    //                    }
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat, ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());

    //                }
    //                else
    //                {
    //                    for (i = 1; i <= Convert.ToInt32(noinstallment); i++)
    //                    {
    //                        string installemnt_No = inst + " " + i;
    //                        ia = "textBox_" + i + "1";
    //                        iamt = Request.Form[ia];
    //                        idt = "textBox_" + i + "2";
    //                        idate = Request.Form[idt];

    //                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileidTextBox.Text, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), ContractdetailsIDTextBox.Text);
    //                        string log5 = "Installment Details:" + "Profile id: " + profileidTextBox.Text + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "Invoice ID:" + Queries.GetInstallmentInvoiceNo(office) + "," + "Contract details ID:" + ContractdetailsIDTextBox.Text;
    //                        int insertlog5 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, log5, user, DateTime.Now.ToString());
    //                        //update instalmentno
    //                        int update = Queries.UpdateInstallmentInvoiceNo(office);
    //                    }
    //                    string lastmat = Queries.GetMinFinance_Details_IndianInsAmt(ContractdetailsIDTextBox.Text);
    //                    //int updateinsamt = Queries.UpdateFinance_Details_IndianInsAmt(lastmat,ContractdetailsIDTextBox.Text);
    //                    //string act = "(points) Installment Amount changed from:" + oinstallment + "To:" + lastmat;
    //                    //int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());


    //                }
    //            }
    //            else
    //            { }
    //        }
    //        if (String.Compare(ototalbalance, totalbalance) != 0)
    //        {
    //            string act = "(trade in fractional) Balance Amount changed from:" + ototalbalance + "To:" + totalbalance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(opaymethod, paymethod) != 0)
    //        {
    //            string act = "(trade in fractional) pay method changed from:" + opaymethod + "To:" + paymethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinancemethod, financemethod) != 0)
    //        {
    //            string act = "(trade in fractional)Finance type changed from:" + ofinancemethod + "To:" + financemethod;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oFinanceno, Financeno) != 0)
    //        {
    //            string act = "(trade in fractional) Finance no changed from:" + oFinanceno + "To:" + Financeno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofinmonth, finmonth) != 0)
    //        {
    //            string act = "(trade in fractional) finance month changed from:" + ofinmonth + "To:" + finmonth;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(onoemi, noemi) != 0)
    //        {
    //            string act = "(trade in fractional) No of EMI changed from:" + onoemi + "To:" + noemi;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //            CheckBreakup(finance, ototalbalance, noemiTextBox.Text, onoemi, totalbalance, emiamtTextBox.Text, contractno, contracttypeTextBox.Text, ContractdetailsIDTextBox.Text, NoinstallmentTextBox.Text);
    //        }
    //        else { }
    //        if (String.Compare(oemiamt, emiamt) != 0)
    //        {
    //            string act = "(trade in fractional) EMI Amount changed from:" + oemiamt + "To:" + emiamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofindocfee, findocfee) != 0)
    //        {
    //            string act = "(trade in fractional) Documentation Fee changed from:" + ofindocfee + "To:" + findocfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oisgtrate, isgtrate) != 0)
    //        {
    //            string act = "(trade in fractional) IGST Rate changed from:" + oisgtrate + "To:" + isgtrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oigstamt, igstamt) != 0)
    //        {
    //            string act = "(trade in fractional) ISGT Amt changed from:" + oigstamt + "To:" + igstamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ointerestrate, interestrate) != 0)
    //        {
    //            string act = "(trade in fractional)Interest Rate changed from:" + ointerestrate + "To:" + interestrate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otradeinvalue, tradeinvalue) != 0)
    //        {
    //            string act = "(trade in fractional)Trade in value changed from:" + otradeinvalue + "To:" + tradeinvalue;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ototalvalue, totalvalue) != 0)
    //        {
    //            string act = "(trade in fractional)total value changed from:" + ototalvalue + "To:" + totalvalue;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctAdmission_fees, adminfee) != 0)
    //        {
    //            string act = "(trade in fractional)Admission fees changed from:" + ofctAdmission_fees + "To:" + adminfee;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctadministration_fees, oAdministrationFees) != 0)
    //        {
    //            string act = "(trade in fractional)Administration fees changed from:" + ofctadministration_fees + "To:" + oAdministrationFees;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctCgst, cgst) != 0)
    //        {
    //            string act = "(trade in fractional) Cgst changed from:" + ofctCgst + "To:" + cgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctSgst, sgst) != 0)
    //        {
    //            string act = "(trade in fractional) Sgst changed from:" + ofctSgst + "To:" + sgst;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctTotal_Purchase_Price, totpurchprice) != 0)
    //        {
    //            string act = "(trade in fractional)Total Purchase Price changed from:" + ofctTotal_Purchase_Price + "To:" + totpurchprice;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctTotal_Price_Including_Tax, totalpriceInTax) != 0)
    //        {
    //            string act = "(trade in fractional)Total Price Including Tax changed from:" + ofctTotal_Price_Including_Tax + "To:" + totalpriceInTax;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctDeposit, deposit) != 0)
    //        {
    //            string act = "(trade in fractional) Deposit changed from:" + ofctDeposit + "To:" + deposit;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctBalance, balance) != 0)
    //        {
    //            string act = "(trade in fractional)ofctBalance changed from:" + ofctBalance + "To:" + balance;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctBalance_Due_Dates, balancedue) != 0)
    //        {
    //            string act = "(trade in fractional) Balance Due Dates changed from:" + ofctBalance_Due_Dates + "To:" + balancedue;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ofctRemarks, remarks) != 0)
    //        {
    //            string act = "(trade in fractional) Remarks changed from:" + ofctRemarks + "To:" + remarks;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oregcollectionterm, regcollectionterm) != 0)
    //        {
    //            string act = "(trade in fractional)reg collection term changed from:" + oregcollectionterm + "To:" + regcollectionterm;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oregcollamt, regcollamt) != 0)
    //        {
    //            string act = "(trade in fractional)reg collection amt changed from:" + oregcollamt + "To:" + regcollamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ooldLoanAgreement, oldloanagreementno) != 0)
    //        {
    //            string act = "(trade in fractional)old loan agreement no changed from:" + ooldLoanAgreement + "To:" + oldloanagreementno;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ooldloanamt, loanamt) != 0)
    //        {
    //            string act = "(trade in fractional)old loan agreement no changed from:" + ooldloanamt + "To:" + loanamt;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oPayment_Mode, paymentmode) != 0)
    //        {
    //            string act = "(trade in fractional)payment Mode changed from:" + oPayment_Mode + "To:" + paymentmode;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oReceipt_Date, receiptdate) != 0)
    //        {
    //            string act = "(trade in fractional)Receipt Date changed from:" + oReceipt_Date + "To:" + receiptdate;
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(ototalamt, indeposit.ToString()) != 0)
    //        {
    //            string act = "(trade in fractional)total amount changed from:" + ototalamt + "To:" + indeposit.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(oAmount, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(trade in fractional)Amount changed from:" + oAmount + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(otaxable_value, taxableamt.ToString()) != 0)
    //        {
    //            string act = "(trade in fractional)Taxable amt changed from:" + otaxable_value + "To:" + taxableamt.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (String.Compare(ocgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(trade in fractional)CGST Amt changed from:" + ocgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }
    //        if (String.Compare(osgstamt, gst.ToString()) != 0)
    //        {
    //            string act = "(trade in fractional)SGST Amt changed from:" + osgstamt + "To:" + gst.ToString();
    //            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, act, user, DateTime.Now.ToString());
    //        }
    //        else { }

    //        if (installmentamtTextBox.Text == "" || installmentamtTextBox.Text == "0" || installmentamtTextBox.Text == "NaN" || installmentamtTextBox.Text == "Infinity")
    //        {
    //            installment = "0";
    //        }
    //        else
    //        {
    //            installment = installmentamtTextBox.Text;
    //        }
    //        if (NoinstallmentTextBox.Text == "" || NoinstallmentTextBox.Text == "0" || NoinstallmentTextBox.Text == "NaN" || NoinstallmentTextBox.Text == "Infinity")
    //        {
    //            noinstallment = "0";
    //        }
    //        else
    //        {
    //            noinstallment = NoinstallmentTextBox.Text;
    //        }

    //        int updatecontractdetailsIndian = Queries.UpdateContractDetails_Indian(csalesrep, cTomgr, buttonup, dealdate, dealstatus, mcwaiver, finance, pancrd, adhar, mcfees, mcdate, memberfee, memebercgst, membersgst, contractnoTextBox.Text, canxcontno, canxdate, loanbuofficer, ContractdetailsIDTextBox.Text);

    //        int updatedealwkno = Queries.UpdateDealdateWeekno(dealwkno.ToString(), ContractdetailsIDTextBox.Text);
    //        int updatefinancedetails = Queries.UpdateFinanceDetails_Indian(finance, currency, affiliate, totalintax, depamt, "", balpayable, "", depbal, totalbalance, paymethod, noinstallment, installment, financemethod, Financeno, isgtrate, interestrate, findocfee, igstamt, noemi, emiamt, finmonth, contractnoTextBox.Text, oldloanagreementno, regcollectionterm, regcollamt, baldepdate, loanamt, ContractdetailsIDTextBox.Text);
    //        int updatecontractPA = Queries.UpdateContract_FractionalPA_Indian(adminfee, oAdministrationFees, totpurchprice, cgst, sgst, totalpriceInTax, deposit, balance, balancedue, remarks, contractnoTextBox.Text, tradeinvalue, totalvalue, ContractdetailsIDTextBox.Text);
    //        int updatepointscontract = Queries.UpdateContract_Trade_In_Fractional_Indian(ocontracttype, tpresort, apt, season, nowks, tpnopts, tpptsval, tpcontno, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);
    //        int updatefractionalcontract = Queries.UpdateContract_Fractional_Indian(resort, residence_no, residence_type, fractional_interest, entitlement, firstyear_Occupancy, tenure, lastyear_Occupancy, "", mcfees, contractnoTextBox.Text, ContractdetailsIDTextBox.Text);

    //        //  int updatereceipt = Queries.UpdateReceiptIndian(contractno, receiptdate, taxableamt.ToString(), taxableamt.ToString(), gst.ToString(), gst.ToString(), indeposit.ToString(), paymentmode, ContractdetailsIDTextBox.Text);
    //        string msg = "Details updated for Contract :" + " " + contractnoTextBox.Text;
    //        LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, finance, contracttypeTextBox.Text, affiliate, mcwaiver, canxcontno, ncompanyname, StateDropDownList.SelectedItem.Text);
    //        Response.Redirect(Request.RawUrl);
    //    }







    //}

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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
                crystalReport.Close();
                crystalReport.Dispose();
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
        Session["oProfile_Venue_Country"] = ""; Session["oProfile_Venue"] = ""; Session["oProfile_Group_Venue"] = ""; Session["oProfile_Marketing_Program"] = "";
        Session["oProfile_Agent"] = ""; Session["oProfile_Agent_Code"] = ""; Session["oProfile_Member_Type1"] = ""; Session["oProfile_Member_Number1"] = "";
        Session["oProfile_Member_Type2"] = ""; Session["oProfile_Member_Number2"] = ""; Session["oProfile_Employment_status"] = ""; Session["oProfile_Marital_status"] = "";
        Session["oProfile_NOY_Living_as_couple"] = ""; Session["oOffice"] = ""; Session["oComments"] = ""; Session["oManager"] = "";
        Session["ophid"] = ""; Session["ocard"] = "";

        Session["oProfile_Primary_Title"] = ""; Session["oProfile_Primary_Fname"] = ""; Session["oProfile_Primary_Lname"] = "";
        Session["oProfile_Primary_DOB"] = ""; Session["oProfile_Primary_Nationality"] = ""; Session["oProfile_Primary_Country"] = "";
        Session["opage"] = ""; Session["opdesignation"] = ""; Session["oplang"] = "";

        Session["oProfile_Secondary_Title"] = ""; Session["oProfile_Secondary_Fname"] = ""; Session["oProfile_Secondary_Lname"] = "";
        Session["oProfile_Secondary_DOB"] = ""; Session["oProfile_Secondary_Nationality"] = ""; Session["oProfile_Secondary_Country"] = "";
        Session["osage"] = ""; Session["osdesignation"] = ""; Session["oslang"] = "";

        Session["oSub_Profile1_Title"] = ""; Session["oSub_Profile1_Fname"] = ""; Session["oSub_Profile1_Lname"] = "";
        Session["oSub_Profile1_DOB"] = ""; Session["  oSub_Profile1_Nationality"] = ""; Session["oSub_Profile1_Country"] = "";
        Session["osp1age"] = "";

        Session["oSub_Profile2_Title"] = ""; Session["oSub_Profile2_Fname"] = ""; Session["oSub_Profile2_Lname"] = "";
        Session["oSub_Profile2_DOB"] = ""; Session["  oSub_Profile2_Nationality"] = ""; Session["oSub_Profile2_Country"] = "";
        Session["osp2age"] = "";

        Session["oSub_Profile3_Title"] = ""; Session["oSub_Profile3_Fname"] = ""; Session["oSub_Profile3_Lname"] = "";
        Session["oSub_Profile3_DOB"] = ""; Session["  oSub_Profile3_Nationality"] = ""; Session["oSub_Profile3_Country"] = "";
        Session["osp3age"] = "";

        Session["oSub_Profile4_Title"] = ""; Session["oSub_Profile4_Fname"] = ""; Session["oSub_Profile4_Lname"] = "";
        Session["oSub_Profile4_DOB"] = ""; Session["  oSub_Profile4_Nationality"] = ""; Session["oSub_Profile4_Country"] = "";
        Session["osp4age"] = "";

        Session["oProfile_Address_Line1"] = ""; Session["oProfile_Address_Line2"] = ""; Session["oProfile_Address_State"] = "";
        Session["oProfile_Address_city"] = ""; Session["oProfile_Address_Postcode"] = ""; Session["oProfile_Address_Created_Date"] = "";
        Session["oProfile_Address_Expiry_Date"] = ""; Session["oProfile_Address_Country"] = "";

        Session["oProfile_CorAddress_Line1"] = ""; Session["oProfile_CorAddress_Line2"] = ""; Session["oProfile_CorAddress_State"] = "";
        Session["oProfile_CorAddress_city"] = ""; Session["oProfile_CorAddress_Postcode"] = ""; Session["oProfile_CorAddress_Created_Date"] = "";
        Session["oProfile_Address_Expiry_Date"] = ""; Session["oProfile_CorAddress_Country"] = "";

        Session["oPrimary_CC"] = ""; Session["oPrimary_Mobile"] = ""; Session["oPrimary_Alt_CC"] = "";
        Session["oPrimary_Alternate"] = ""; Session["opriOfficecc"] = ""; Session["opriOfficeno"] = "";

        Session["osecOfficecc"] = ""; Session["osecofficeno"] = ""; Session["oSecondary_CC"] = "";
        Session["oSecondary_Mobile"] = ""; Session["oSecondary_Alt_CC"] = ""; Session["oSecondary_Alternate"] = "";

        Session["oSubprofile1_CC"] = ""; Session["oSubprofile1_Mobile"] = ""; Session["oSubprofile1_Alt_CC"] = ""; Session["oSubprofile1_Alternate"] = "";
        Session["oSubprofile2_CC"] = ""; Session["oSubprofile2_Mobile"] = ""; Session["oSubprofile2_Alt_CC"] = ""; Session["oSubprofile2_Alternate"] = "";

        Session["oSubprofile3_CC"] = ""; Session["oSubprofile3_Mobile"] = ""; Session["oSubprofile3_Alt_CC"] = ""; Session["oSubprofile3_Alternate"] = "";
        Session["oSubprofile4_CC"] = ""; Session["oSubprofile4_Mobile"] = ""; Session["oSubprofile4_Alt_CC"] = ""; Session["oSubprofile4_Alternate"] = "";

        Session["oPrimary_Email"] = ""; Session["oSecondary_Email"] = ""; Session["oSubprofile1_Email"] = "";
        Session["oSubprofile2_Email"] = ""; Session["oSubprofile3_Email"] = ""; Session["oSubprofile4_Email"] = "";

        Session["oPrimary_Email2"] = ""; Session["oSecondary_Email2"] = ""; Session["oSubprofile1_Email2"] = "";
        Session["oSubprofile2_Email2"] = ""; Session["oSubprofile3_Email2"] = ""; Session["oSubprofile4_Email2"] = "";


        Session["oProfile_Stay_ID"] = ""; Session["oProfile_Stay_Resort_Name"] = ""; Session["oProfile_Stay_Resort_Room_Number"] = "";
        Session["oProfile_Stay_Arrival_Date"] = ""; Session["oProfile_Stay_Departure_Date"] = "";

        Session["oTour_Details_Guest_Status"] = ""; Session["oTour_Details_Guest_Sales_Rep"] = ""; Session["oTour_Details_Tour_Date"] = "";
        Session["tourweekno"] = ""; Session["oTour_Details_Sales_Deck_Check_In"] = ""; Session["oTour_Details_Sales_Deck_Check_Out"] = "";
        Session["oTour_Details_Taxi_In_Price"] = ""; Session["oTour_Details_Taxi_In_Ref"] = ""; Session["oTour_Details_Taxi_Out_Price"] = "";
        Session["oTour_Details_Taxi_Out_Ref"] = ""; Session["oComments"] = ""; Session["oregTerms"] = ""; Session["ocomment2"] = "";

        Session["pmobile"] = ""; Session["palternate"] = ""; Session["smobile"] = ""; Session["salternate"] = ""; Session["priOfficeno"] = "";
        Session["sp1mobile"] = ""; Session["sp1alternate"] = ""; Session["sp2mobile"] = ""; Session["sp2alternate"] = ""; Session["secOfficeno"] = "";
        Session["sp3mobile"] = ""; Session["sp3alternate"] = ""; Session["sp4mobile"] = ""; Session["sp4alternate"] = "";

        Session["pmobilec"] = ""; Session["palternatec"] = ""; Session["smobilec"] = ""; Session["salternatec"] = ""; Session["sp1mobilec"] = ""; Session["sp1alternatec"] = "";
        Session["sp2mobilec"] = ""; Session["sp2alternatec"] = ""; Session["sp3mobilec"] = ""; Session["sp3alternatec"] = ""; Session["sp4mobilec"] = ""; Session["sp4alternatec"] = "";

        Session["pcc"] = ""; Session["paltrcc"] = ""; Session["scc"] = ""; Session["saltcc"] = ""; Session["sp1cc"] = ""; Session["sp1altcc"] = ""; Session["priOfficecc"] = "";
        Session["sp2cc"] = ""; Session["sp2altccc"] = ""; Session["sp3cc"] = ""; Session["sp3altccc"] = ""; Session["sp4cc"] = ""; Session["sp4altccc"] = ""; Session["secOfficecc"] = "";

        Session["ocompanyname"] = ""; Session["pemail"] = ""; Session["semail"] = ""; Session["sp1email"] = ""; Session["sp2email"] = ""; Session["sp3email"] = ""; Session["sp4email"] = "";
        Session["pemail2"] = ""; Session["semail2"] = ""; Session["sp1email2"] = ""; Session["sp2email2"] = ""; Session["sp3email2"] = ""; Session["sp4email2"] = "";

        Session["regTerms"] = ""; Session["tourweekno"] = "";

        DataSet ds = Queries.LoadProfielDetailsFull(Session["ProfileID"].ToString());// profileidTextBox.Text);

       

        Session["oProfile_Venue_Country"] = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
        Session["oProfile_Venue"] = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
        Session["oProfile_Group_Venue"] = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
        Session["oProfile_Marketing_Program"] = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
        Session["oProfile_Agent"] = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
        Session["oProfile_Agent_Code"] = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
        Session["oProfile_Member_Type1"] = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
        Session["oProfile_Member_Number1"] = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
        Session["oProfile_Member_Type2"] = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
        Session["oProfile_Member_Number2"] = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
        Session["oProfile_Employment_status"] = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
        Session["oProfile_Marital_status"] = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
        Session["oProfile_NOY_Living_as_couple"] = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
        Session["oOffice"] = ds.Tables[0].Rows[0]["Office"].ToString();
        Session["oComments"] = ds.Tables[0].Rows[0]["Comments"].ToString();
        Session["oManager"] = ds.Tables[0].Rows[0]["Manager"].ToString();
        Session["ophid"] = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
        Session["ocard"] = ds.Tables[0].Rows[0]["Card_Holder"].ToString();
        Session["ocomment2"] = ds.Tables[0].Rows[0]["comment2"].ToString();


        Session["oProfile_Primary_Title"] = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
        Session["oProfile_Primary_Fname"] = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
        Session["oProfile_Primary_Lname"] = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
        Session["oProfile_Primary_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oProfile_Primary_Nationality"] = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
        Session["oProfile_Primary_Country"] = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
        Session["opage"] = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
        Session["opdesignation"] = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
        Session["oplang"] = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

        Session["oProfile_Secondary_Title"] = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
        Session["oProfile_Secondary_Fname"] = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
        Session["oProfile_Secondary_Lname"] = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
        Session["oProfile_Secondary_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oProfile_Secondary_Nationality"] = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
        Session["oProfile_Secondary_Country"] = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
        Session["osage"] = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
        Session["osdesignation"] = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
        Session["oslang"] = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

        Session["oSub_Profile1_Title"] = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
        Session["oSub_Profile1_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
        Session["oSub_Profile1_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
        Session["oSub_Profile1_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);//Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile1_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
        Session["oSub_Profile1_Country"] = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
        Session["osp1age"] = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

        Session["oSub_Profile2_Title"] = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
        Session["oSub_Profile2_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
        Session["oSub_Profile2_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
        Session["oSub_Profile2_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile2_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
        Session["oSub_Profile2_Country"] = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
        Session["osp2age"] = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

        Session["oSub_Profile3_Title"] = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
        Session["oSub_Profile3_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
        Session["oSub_Profile3_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
        Session["oSub_Profile3_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile3_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
        Session["oSub_Profile3_Country"] = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
        Session["osp3age"] = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

        Session["oSub_Profile4_Title"] = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
        Session["oSub_Profile4_Fname"] = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
        Session["oSub_Profile4_Lname"] = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
        Session["oSub_Profile4_DOB"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
        Session["oSub_Profile4_Nationality"] = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
        Session["oSub_Profile4_Country"] = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
        Session["osp4age"] = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

        Session["oProfile_Address_Line1"] = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
        Session["oProfile_Address_Line2"] = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
        Session["oProfile_Address_State"] = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
        Session["oProfile_Address_city"] = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
        Session["oProfile_Address_Postcode"] = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
        Session["oProfile_Address_Created_Date"] = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
        Session["oProfile_Address_Expiry_Date"] = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();
        Session["oProfile_Address_Country"] = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();


        Session["oProfile_CorAddress_Line1"] = ds.Tables[0].Rows[0]["Address_Line1"].ToString();
        Session["oProfile_CorAddress_Line2"] = ds.Tables[0].Rows[0]["Address_Line2"].ToString();
        Session["oProfile_CorAddress_State"] = ds.Tables[0].Rows[0]["Address_State"].ToString();
        Session["oProfile_CorAddress_city"] = ds.Tables[0].Rows[0]["Address_city"].ToString();
        Session["oProfile_CorAddress_Postcode"] = ds.Tables[0].Rows[0]["Address_Postcode"].ToString();
        Session["oProfile_CorAddress_Created_Date"] = ds.Tables[0].Rows[0]["Address_Created_Date"].ToString();
        Session["oProfile_CorAddress_Expiry_Date"] = ds.Tables[0].Rows[0]["Expiry_Date"].ToString();
        Session["oProfile_CorAddress_Country"] = ds.Tables[0].Rows[0]["Address_Country"].ToString();

        Session["oPrimary_CC"] = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
        Session["oPrimary_Mobile"] = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
        Session["oPrimary_Alt_CC"] = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
        Session["oPrimary_Alternate"] = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
        Session["opriOfficecc"] = ds.Tables[0].Rows[0]["Primary_office_cc"].ToString();
        Session["opriOfficeno"] = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();

        Session["osecOfficecc"] = ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString();
        Session["osecofficeno"] = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();
        Session["oSecondary_CC"] = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
        Session["oSecondary_Mobile"] = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
        Session["oSecondary_Alt_CC"] = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
        Session["oSecondary_Alternate"] = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();

        Session["oSubprofile1_CC"] = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
        Session["oSubprofile1_Mobile"] = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
        Session["oSubprofile1_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
        Session["oSubprofile1_Alternate"] = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();

        Session["oSubprofile2_CC"] = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
        Session["oSubprofile2_Mobile"] = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
        Session["oSubprofile2_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
        Session["oSubprofile2_Alternate"] = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

        Session["oSubprofile3_CC"] = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
        Session["oSubprofile3_Mobile"] = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
        Session["oSubprofile3_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
        Session["oSubprofile3_Alternate"] = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

        Session["oSubprofile4_CC"] = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
        Session["oSubprofile4_Mobile"] = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
        Session["oSubprofile4_Alt_CC"] = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
        Session["oSubprofile4_Alternate"] = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();

        Session["oPrimary_Email"] = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
      
        Session["oSecondary_Email"] = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
        Session["oSubprofile1_Email"] = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
        Session["oSubprofile2_Email"] = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
        Session["oSubprofile3_Email"] = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
        Session["oSubprofile4_Email"] = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

        Session["oPrimary_Email2"] = ds.Tables[0].Rows[0]["Primary_Email2"].ToString();
        Session["oSecondary_Email2"] = ds.Tables[0].Rows[0]["Secondary_Email2"].ToString();
        Session["oSubprofile1_Email2"] = ds.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();
        Session["oSubprofile2_Email2"] = ds.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();
        Session["oSubprofile3_Email2"] = ds.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();
        Session["oSubprofile4_Email2"] = ds.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

        Session["oProfile_Stay_ID"] = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
        Session["oProfile_Stay_Resort_Name"] = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        Session["oProfile_Stay_Resort_Room_Number"] = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
        Session["oProfile_Stay_Arrival_Date"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
        Session["oProfile_Stay_Departure_Date"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

        Session["oTour_Details_Guest_Status"] = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
        Session["oTour_Details_Guest_Sales_Rep"] = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
        Session["oTour_Details_Tour_Date"] = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
        Session["tourweekno"] = ds.Tables[0].Rows[0]["Week_number"].ToString();
        Session["oTour_Details_Sales_Deck_Check_In"] = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
        Session["oTour_Details_Sales_Deck_Check_Out"] = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
        Session["oTour_Details_Taxi_In_Price"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
        Session["oTour_Details_Taxi_In_Ref"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
        Session["oTour_Details_Taxi_Out_Price"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
        Session["oTour_Details_Taxi_Out_Ref"] = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
        Session["oComments"] = ds.Tables[0].Rows[0]["Comments"].ToString();
        Session["oregTerms"] = ds.Tables[0].Rows[0]["RegTerms"].ToString();
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
        //string mktg = Request.Form["MarketingProgramDropDownList"];//MarketingProgramDropDownList.SelectedItem.Text;
        //if (mktg == "")
        //{
        //    mktg = MarketingProgramDropDownList.Items[0].Text;

        //}
        //else
        //{
        //    mktg = Request.Form["MarketingProgramDropDownList"];
        //}
        string mktg = Request.Form["MarketingProgramDropDownList"];// MarketingProgramDropDownList.SelectedItem.Text; ////
        if (venuegroup == "Coldline" || venuegroup == "COLDLINE")
        {
            if (mktg == "")
            {
                mktg = MarketingProgramDropDownList.Items[0].Text;

                // mktg = Queries.getMarketingAbbOnMarketingProgram(venue, venuegroup, mktg);

            }
            else
            {
                mktg = Request.Form["MarketingProgramDropDownList"];
            }
        }
        else
        {
            if (mktg == "")
            {
                mktg = MarketingProgramDropDownList.Items[0].Text;

                mktg = Queries.getMarketingAbbOnMarketingProgram(venue, venuegroup, mktg);

            }
            else
            {
                mktg = Request.Form["MarketingProgramDropDownList"];
            }
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
        if (mktg == "T/S MEMBER" || mktg == "T/S MEMBER RCI" || mktg == "FRACTIONAL OWNER" || mktg == "FRACTIONAL OWNER RCI" || mktg == "Owner" || mktg == "OWNER" || mktg == "Member" || mktg == "MEMBER")
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


        string subVenue = Request.Form["SubVenueDropDownList"];
        if (subVenue == "" || subVenue == null)
        {
            subVenue = SubVenueDropDownList.Items[0].Text;
        }
        else
        {
            subVenue = Request.Form["SubVenueDropDownList"];
        }


        string subVenueGroup = Request.Form["SubVenueGroupDropDownList"];
        if (subVenueGroup == "" || subVenueGroup == null)
        {
            subVenueGroup = SubVenueGroupDropDownList.Items[0].Value;
        }
        else
        {
            subVenueGroup = Request.Form["SubVenueGroupDropDownList"];
        }


        string leadOffice = "";
        if (venuegroup == "Inhouse" || venuegroup == "INHOUSE")
        {
            leadOffice = "";
        }
        else if (venuegroup == "FlyBuy" || venuegroup == "FLYBUY" || venuegroup == "CallCenter")
        {
            leadOffice = Request.Form["LeadOfficeDropDownList"];
            if (leadOffice == "" || leadOffice == null)
            {
                leadOffice = LeadOfficeDropDownList.Items[0].Text;
            }
            else
            {
                leadOffice = Request.Form["LeadOfficeDropDownList"];
            }
        }



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


        Session["pcc"] = Request.Form["primarymobileDropDownList"];//primarymobileDropDownList.SelectedItem.Text;

        if (Session["pcc"].ToString() == "")
        {
            Session["pcc"] = primarymobileDropDownList.Items[0].Text;
        }
        else
        {
            Session["pcc"] = Request.Form["primarymobileDropDownList"];

        }





        Session["paltrcc"] = Request.Form["primaryalternateDropDownList"]; //primaryalternateDropDownList.SelectedItem.Text;
        if (Session["paltrcc"].ToString() == "")
        {
            Session["paltrcc"] = primaryalternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["paltrcc"] = Request.Form["primaryalternateDropDownList"];
        }
        //}
        if (pmobileTextBox.Text == "" || pmobileTextBox.Text == null)
        {
            Session["pmobile"] = "";
        }
        else
        {
            Session["pmobile"] = pmobileTextBox.Text;
        }

        if (palternateTextBox.Text == "" || palternateTextBox.Text == null)
        {
            Session["palternate"] = "";
        }
        else
        {
            Session["palternate"] = palternateTextBox.Text;
        }

        if (pemailTextBox.Text == "" || pemailTextBox.Text == null)
        {
            Session["pemail"] = "";
        }
        else
        {
            Session["pemail"] = pemailTextBox.Text.ToUpper();
        }

        if (pemail2TextBox.Text == "" || pemail2TextBox.Text == null)
        {
            Session["pemail2"] = "";
        }
        else
        {
            Session["pemail2"] = pemail2TextBox.Text.ToUpper();
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
        Session["scc"] = Request.Form["secondarymobileDropDownList"];//secondarymobileDropDownList.SelectedItem.Text;
        if (Session["scc"].ToString() == "")
        {
            Session["scc"] = secondarymobileDropDownList.Items[0].Text;
        }
        else
        {
            Session["scc"] = Request.Form["secondarymobileDropDownList"];
        }


        Session["saltcc"] = Request.Form["secondaryalternateDropDownList"];//secondaryalternateDropDownList.SelectedItem.Text;
        if (Session["saltcc"].ToString() == "")
        {
            Session["saltcc"] = secondaryalternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["saltcc"] = Request.Form["secondaryalternateDropDownList"];

        }

        Session["priOfficecc"] = Request.Form["pofficecodeDropDownList"];
        if (Session["priOfficecc"].ToString() == "")
        {
            Session["priOfficecc"] = pofficecodeDropDownList.Items[0].Text;
        }
        else
        {
            Session["priOfficecc"] = Request.Form["pofficecodeDropDownList"];
        }


        Session["secOfficecc"] = Request.Form["sofficecodeDropDownList"];
        if (Session["secOfficecc"].ToString() == "")
        {
            Session["secOfficecc"] = sofficecodeDropDownList.Items[0].Text;
        }
        else
        {
            Session["secOfficecc"] = Request.Form["sofficecodeDropDownList"];
        }


        if (smobileTextBox.Text == "" || smobileTextBox.Text == null)
        {
            Session["smobile"] = "";
        }
        else
        {
            Session["smobile"] = smobileTextBox.Text;
        }
        if (salternateTextBox.Text == "" || salternateTextBox.Text == null)
        {
            Session["salternate"] = "";
        }
        else
        {
            Session["salternate"] = salternateTextBox.Text;
        }

        if (pofficenoTextBox.Text == "" || pofficenoTextBox.Text == null)
        {
            Session["priOfficeno"] = "";
        }
        else
        {
            Session["priOfficeno"] = pofficenoTextBox.Text;
        }

        if (sofficenoTextBox.Text == "" || sofficenoTextBox.Text == null)
        {
            Session["secOfficeno"] = "";
        }
        else
        {
            Session["secOfficeno"] = sofficenoTextBox.Text;
        }


        if (semailTextBox.Text == "" || semailTextBox.Text == null)
        {
            Session["semail"] = "";
        }
        else
        {
            Session["semail"] = semailTextBox.Text.ToUpper();
        }
        if (semail2TextBox.Text == "" || semail2TextBox.Text == null)
        {
            Session["semail2"] = "";
        }
        else
        {
            Session["semail2"] = semail2TextBox.Text.ToUpper();
        }
        
        //sub profile1


        string sp1title = sp1titleDropDownList.SelectedItem.Text;
        string sp1fname = sp1fnameTextBox.Text.ToUpper();
        string sp1lname = sp1lnameTextBox.Text.ToUpper();
        string sp1dob = sp1dobdatepicker.Text;


        string sp1nationality = sp1nationalityDropDownList.SelectedItem.Text;
        string sp1country = sp1countryDropDownList.SelectedItem.Text;
        string nsp1age = subProfile1Age.Text;


        Session["sp1cc"] = Request.Form["sp1mobileDropDownList"];//sp1mobileDropDownList.SelectedItem.Text;
        if (Session["sp1cc"].ToString() == "")
        {
            Session["sp1cc"] = sp1mobileDropDownList.Items[0].Text;
        }
        else
        {

            Session["sp1cc"] = Request.Form["sp1mobileDropDownList"];

        }


        Session["sp1altcc"] = Request.Form["sp1alternateDropDownList"];// sp1alternateDropDownList.SelectedItem.Text;

        if (Session["sp1altcc"].ToString() == "")
        {
            Session["sp1altcc"] = sp1alternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["sp1altcc"] = Request.Form["sp1alternateDropDownList"]; ;
        }
        //}


        if (sp1mobileTextBox.Text == "" || sp1mobileTextBox.Text == null)
        {
            Session["sp1mobile"] = "";
        }
        else
        {
            Session["sp1mobile"] = sp1mobileTextBox.Text;
        }
        if (sp1alternateTextBox.Text == "" || sp1alternateTextBox.Text == null)
        {
            Session["sp1alternate"] = "";
        }
        else
        {
            Session["sp1alternate"] = sp1alternateTextBox.Text;
        }
        if (sp1pemailTextBox.Text == "" || sp1pemailTextBox.Text == null)
        {
            Session["sp1email"] = "";
        }
        else
        {
            Session["sp1email"] = sp1pemailTextBox.Text.ToUpper();
        }

        if (sp1pemail2TextBox.Text == "" || sp1pemail2TextBox.Text == null)
        {
            Session["sp1email2"] = "";
        }
        else
        {
            Session["sp1email2"] = sp1pemail2TextBox.Text.ToUpper();
        }

        //sub profile 2
        string sp2title = sp2titleDropDownList.SelectedItem.Text;
        string sp2fname = sp2fnameTextBox.Text.ToUpper();
        string sp2lname = sp2lnameTextBox.Text.ToUpper();
        string sp2dob = sp2dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp2nationality = sp2nationalityDropDownList.SelectedItem.Text;
        string sp2country = sp2countryDropDownList.SelectedItem.Text;
        string nsp2age = subProfile2Age.Text;
        Session["sp2cc"] = Request.Form["sp2mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (Session["sp2cc"].ToString() == "")
        {
            Session["sp2cc"] = sp2mobileDropDownList.Items[0].Text;
        }
        else
        {

            Session["sp2cc"] = Request.Form["sp2mobileDropDownList"];

        }


        Session["sp2altccc"] = Request.Form["sp2alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (Session["sp2altccc"].ToString() == "")
        {
            Session["sp2altccc"] = sp2alternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["sp2altccc"] = Request.Form["sp2alternateDropDownList"];

        }



        if (sp2mobileTextBox.Text == "" || sp2mobileTextBox.Text == null)
        {
            Session["sp2mobile"] = "";
        }
        else
        {
            Session["sp2mobile"] = sp2mobileTextBox.Text;

        }
        if (sp2alternateTextBox.Text == "" || sp2alternateTextBox.Text == null)
        {
            Session["sp2alternate"] = "";

        }
        else
        {
            Session["sp2alternate"] = sp2alternateTextBox.Text;

        }
        if (sp2pemailTextBox.Text == "" || sp2pemailTextBox.Text == null)
        {
            Session["sp2email"] = "";
        }
        else
        {
            Session["sp2email"] = sp2pemailTextBox.Text.ToUpper();
        }
        if (sp2pemail2TextBox.Text == "" || sp2pemail2TextBox.Text == null)
        {
            Session["sp2email2"] = "";
        }
        else
        {
            Session["sp2email2"] = sp2pemail2TextBox.Text.ToUpper();
        }


        // sub profile 3//
        string sp3title = sp3titleDropDownList.SelectedItem.Text;
        string sp3fname = sp3fnameTextBox.Text.ToUpper();
        string sp3lname = sp3lnameTextBox.Text.ToUpper();
        string sp3dob = sp3dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp3nationality = sp3nationalityDropDownList.SelectedItem.Text;
        string sp3country = sp3countryDropDownList.SelectedItem.Text;
        string nsp3age = subProfile3Age.Text;
        Session["sp3cc"] = Request.Form["sp3mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (Session["sp3cc"].ToString() == "")
        {
            Session["sp3cc"] = sp3mobileDropDownList.Items[0].Text;
        }
        else
        {

            Session["sp3cc"] = Request.Form["sp3mobileDropDownList"];

        }

        Session["sp3altccc"] = Request.Form["sp3alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (Session["sp3altccc"].ToString() == "")
        {
            Session["sp3altccc"] = sp3alternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["sp3altccc"] = Request.Form["sp3alternateDropDownList"];

        }
        //}


        if (sp3mobileTextBox.Text == "" || sp3mobileTextBox.Text == null)
        {
            Session["sp3mobile"] = "";
        }
        else
        {
            Session["sp3mobile"] = sp3mobileTextBox.Text;

        }
        if (sp3alternateTextBox.Text == "" || sp3alternateTextBox.Text == null)
        {
            Session["sp3alternate"] = "";

        }
        else
        {
            Session["sp3alternate"] = sp3alternateTextBox.Text;

        }
        if (sp3pemailTextBox.Text == "" || sp3pemailTextBox.Text == null)
        {
            Session["sp3email"] = "";
        }
        else
        {
            Session["sp3email"] = sp3pemailTextBox.Text.ToUpper();
        }
        if (sp3pemail2TextBox.Text == "" || sp3pemail2TextBox.Text == null)
        {
            Session["sp3email2"] = "";
        }
        else
        {
            Session["sp3email2"] = sp3pemail2TextBox.Text.ToUpper();
        }


        // sub profile 4//
        string sp4title = sp4titleDropDownList.SelectedItem.Text;
        string sp4fname = sp4fnameTextBox.Text.ToUpper();
        string sp4lname = sp4lnameTextBox.Text.ToUpper();
        string sp4dob = sp4dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp4nationality = sp4nationalityDropDownList.SelectedItem.Text;
        string sp4country = sp4countryDropDownList.SelectedItem.Text;
        string nsp4age = subProfile4Age.Text;

        Session["sp4cc"] = Request.Form["sp4mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (Session["sp4cc"].ToString() == "")
        {
            Session["sp4cc"] = sp4mobileDropDownList.Items[0].Text;
        }
        else
        {

            Session["sp4cc"] = Request.Form["sp4mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        Session["sp4altccc"] = Request.Form["sp4alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (Session["sp4altccc"].ToString() == "")
        {
            Session["sp4altccc"] = sp4alternateDropDownList.Items[0].Text;
        }
        else
        {
            Session["sp4altccc"] = Request.Form["sp4alternateDropDownList"];

        }
        //}


        if (sp4mobileTextBox.Text == "" || sp4mobileTextBox.Text == null)
        {
            Session["sp4mobile"] = "";
        }
        else
        {
            Session["sp4mobile"] = sp4mobileTextBox.Text;

        }
        if (sp4alternateTextBox.Text == "" || sp4alternateTextBox.Text == null)
        {
            Session["sp4alternate"] = "";

        }
        else
        {
            Session["sp4alternate"] = sp4alternateTextBox.Text;

        }
        if (sp4pemailTextBox.Text == "" || sp4pemailTextBox.Text == null)
        {
            Session["sp4email"] = "";
        }
        else
        {
            Session["sp4email"] = sp4pemailTextBox.Text.ToUpper();
        }
        if (sp4pemail2TextBox.Text == "" || sp4pemail2TextBox.Text == null)
        {
            Session["sp4email2"] = "";
        }
        else
        {
            Session["sp4email2"] = sp4pemail2TextBox.Text.ToUpper();
        }


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
        string roomno = roomnoTextBox.Text.ToUpper();
        string arrivaldate = arrivaldatedatepicker.Text;
        string departuredate = departuredatedatepicker.Text;

        //guest status

        string gueststatus = guestatusDropDownList.SelectedItem.Text;
        string salesrep = toursalesrepDropDownList.SelectedItem.Text;
        string timeIn = timeinTextBox.Text;
        string timeOut = timeoutTextBox.Text;
        // string tourdate = tourdatedatepicker.Text;
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

        if (CheckBox1.Checked)
        {


            Session["regTerms"] = "Y";
        }
        else
        {
            Session["regTerms"] = "N";

        }

        //update
        if (String.Compare(Session["ocompanyname"].ToString(), companynameTextBox.Text) != 0)
        {
            int update = Queries.UpdateProfileCompanyName(Session["ProfileID"].ToString(), companynameTextBox.Text.ToUpper());
            string log3 = "Company Name changed from:" +Session["ocompanyname"].ToString() + " " + "to" + companynameTextBox.Text;
            int insertlog3 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log3, user, DateTime.Now.ToString());

        }
        else
        {
        }



       

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string valg = Request.Form["giftoptionDropDownList"];
        //if (valg == "" || valg == null)
        //{

        //}
        //else
        //{

        SqlConnection sqlcon4 = new SqlConnection(conn);

        string query4 = "select Gift_ID_Option+'-'+GiftItem from gift where Profile_ID='" + Session["ProfileID"].ToString() + "'";//Session["ProfileID"].ToString()
        sqlcon4.Open();
        SqlCommand cmd4 = new SqlCommand(query4, sqlcon4);
        SqlDataReader reader4 = cmd4.ExecuteReader();
        while (reader4.Read())
        {
            string name = reader4.GetString(0);
            string act1 = "Deleted:" + name;
            int insertlog2 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act1, user, DateTime.Now.ToString());
        }

        reader4.Close();
        sqlcon4.Close();

        SqlConnection sqlcon2 = new SqlConnection(conn);
        string query2 = "delete from gift where Profile_ID='" + Session["ProfileID"].ToString() + "'";//Session["ProfileID"].ToString()
        sqlcon2.Open();
        SqlCommand cmd2 = new SqlCommand(query2, sqlcon2);
        cmd2.ExecuteNonQuery();
        sqlcon2.Close();

        // }



        string val = Request.Form["giftoptionDropDownList"];
        if (val == "" || val == null)
        {

        }
        else
        {


            string[] value = val.Split(new Char[] { ',', '-' },
                                       StringSplitOptions.RemoveEmptyEntries);




            for (int i = 0; i < value.Length; i = i + 2)
            {
                conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(conn);
                string query = "select Gift_Option_Name,Item from Gift_Option where Gift_Option_Name='" + value[i] + "' and Item='" + value[i + 1] + "'";
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string giftname = reader.GetString(0);
                    string item = reader.GetString(1);


                    SqlConnection sqlcon1 = new SqlConnection(conn);
                    string query1 = "select distinct Profile_ID from Gift where Profile_ID='" + Session["ProfileID"].ToString() + "'";
                    sqlcon1.Open();
                    SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {



                            int year = DateTime.Now.Year;
                            string giftid = Queries.GetProfileGift(office);
                            int insert = Queries.InsertGiftOption(giftid, giftname.Trim(), TextBox13.Text, TextBox22.Text, Session["ProfileID"].ToString(), item.Trim(), "");
                            int updategift = Queries.UpdateGiftValue(office, year);
                            string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftname + "," + "Voucherno:" + TextBox13.Text + "," + "Comments:" + TextBox22.Text + "," + "Profile id:" + Session["ProfileID"].ToString() + "," + "Item:" + item;
                            int insertlog11 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log11, user, DateTime.Now.ToString());



                        }
                    }
                    else
                    {


                        int year = DateTime.Now.Year;
                        string giftid = Queries.GetProfileGift(office);
                        int insert = Queries.InsertGiftOption(giftid, giftname.Trim(), TextBox13.Text, TextBox22.Text, Session["ProfileID"].ToString(), item.Trim(), "");
                        int updategift = Queries.UpdateGiftValue(office, year);
                        string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftname + "," + "Voucherno:" + TextBox13.Text + "," + "Comments:" + TextBox22.Text + "," + "Profile id:" + Session["ProfileID"].ToString() + "," + "Item:" + item;
                        int insertlog11 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log11, user, DateTime.Now.ToString());

                    }

                    reader1.Close();
                    sqlcon1.Close();


                }
                reader.Close();
                sqlcon.Close();

            }
        }

        if (String.Compare(Session["oProfile_Venue_Country"].ToString(), venuecountry) != 0)
        {
            string act = "venue country changed from:" + Session["oProfile_Venue_Country"].ToString() + "To:" + venuecountry;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Venue"].ToString(), venue) != 0)
        {
            string act = "venue changed from:" + Session["oProfile_Venue"].ToString() + "To:" + venue;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Group_Venue"].ToString(), venuegroup) != 0)
        {
            string act = "venue group changed from:" + Session["oProfile_Group_Venue"].ToString() + "To:" + venuegroup;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Marketing_Program"].ToString(), mktg) != 0)
        {
            string act = "marketing prgm changed from:" + Session["oProfile_Marketing_Program"].ToString() + "To:" + mktg;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Agent"].ToString(), agents) != 0)
        {
            string act = "agent name changed from:" + Session["oProfile_Agent"].ToString() + "To:" + agents;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Agent_Code"].ToString(), agentcode) != 0)
        {
            string act = "To Name changed from:" + Session["oProfile_Agent_Code"].ToString() + "To:" + agentcode;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oManager"].ToString(), mgr) != 0)
        {
            string act = "manager changed from:" + Session["oManager"].ToString() + "To:" + mgr;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Type1"].ToString(), membertype1) != 0)
        {
            string act = "membertype1 changed from:" + Session["oProfile_Member_Type1"].ToString() + "To:" + membertype1;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ophid"].ToString(), photoidentity) != 0)
        {
            string act = "Photo Identity changed from:" + Session["ophid"].ToString() + "To:" + photoidentity;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["ocard"].ToString(), card) != 0)
        {
            string act = "Card Holder value changed from:" + Session["ocard"].ToString() + "To:" + card;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Number1"].ToString(), memno1) != 0)
        {
            string act = "memno1 changed from:" + Session["oProfile_Member_Number1"].ToString() + "To:" + memno1;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Type2"].ToString(), membertype2) != 0)
        {
            string act = "membertype2 changed from:" + Session["oProfile_Member_Type2"].ToString() + "To:" + membertype2;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Member_Number2"].ToString(), memno2) != 0)
        {
            string act = "memno2 changed from:" + Session["oProfile_Member_Number2"].ToString() + "To:" + memno2;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Title"].ToString(), primarytitle) != 0)
        {
            string act = "primary title changed from:" + Session["oProfile_Primary_Title"].ToString() + "To:" + primarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Fname"].ToString(), primaryfname) != 0)
        {
            string act = "primary fname changed from:" + Session["oProfile_Primary_Fname"].ToString() + "To:" + primaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Lname"].ToString(), primaylname) != 0)
        {
            string act = "primay lname changed from:" + Session["oProfile_Primary_Lname"].ToString() + "To:" + primaylname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_DOB"].ToString(), primarydob) != 0)
        {
            string act = "primary dob changed from:" + Session["oProfile_Primary_DOB"].ToString() + "To:" + primarydob;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Nationality"].ToString(), primarynationality) != 0)
        {
            string act = "primary nationality changed from:" + Session["oProfile_Primary_Nationality"].ToString() + "To:" + primarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Primary_Country"].ToString(), primarycountry) != 0)
        {
            string act = "primary country changed from:" + Session["oProfile_Primary_Country"].ToString() + "To:" + primarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["opage"].ToString(), npage) != 0)
        {
            string act = "primary age changed from:" + Session["opage"].ToString() + "To:" + npage;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["opdesignation"].ToString(), npdesg) != 0)
        {
            string act = "primary designation changed from:" + Session["opdesignation"].ToString() + "To:" + npdesg;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oplang"].ToString(), primarylanguage) != 0)
        {
            string act = "primary Language changed from:" + Session["oplang"].ToString() + "To:" + primarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_CC"].ToString(), Session["pcc"].ToString()) != 0)
        {
            string act = "primary mobile code changed from:" + Session["oPrimary_CC"].ToString() + "To:" + Session["pcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_Mobile"].ToString(), Session["pmobile"].ToString()) != 0)
        {
            string act = "primary mobile no changed from:" + Session["oPrimary_Mobile"].ToString() + "To:" + Session["pmobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_Alt_CC"].ToString(), Session["paltrcc"].ToString()) != 0)
        {
            string act = "primary mobile changed from:" + Session["oPrimary_Alt_CC"].ToString() + "To:" + Session["paltrcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oPrimary_Alternate"].ToString(), Session["palternate"].ToString()) != 0)
        {
            string act = "primary alternate no changed from:" + Session["oPrimary_Alternate"].ToString() + "To:" + Session["palternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["opriOfficecc"].ToString(), Session["priOfficecc"].ToString()) != 0)
        {
            string act = "primary office cc changed from:" + Session["opriOfficecc"].ToString() + "To:" + Session["priOfficecc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["opriOfficeno"].ToString(), Session["priOfficeno"].ToString()) != 0)
        {
            string act = "primary office no changed from:" + Session["opriOfficeno"].ToString() + "To:" + Session["priOfficeno"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["oPrimary_Email"].ToString(), Session["pemail"].ToString()) != 0)
        {
            string act = "primary email changed from:" + Session["oPrimary_Email"].ToString() + "To:" + Session["pemail"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oPrimary_Email2"].ToString(), Session["pemail2"].ToString()) != 0)
        {
            string act = "primary email2 changed from:" + Session["oPrimary_Email2"].ToString() + "To:" + Session["pemail2"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Title"].ToString(), secondarytitle) != 0)
        {
            string act = "secondary title changed from:" + Session["oProfile_Secondary_Title"].ToString() + "To:" + secondarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Fname"].ToString(), secondaryfname) != 0)
        {
            string act = "secondary fname changed from:" + Session["oProfile_Secondary_Fname"].ToString() + "To:" + secondaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Lname"].ToString(), secondarylname) != 0)
        {
            string act = "secondary lname changed from:" + Session["oProfile_Secondary_Lname"].ToString() + "To:" + secondarylname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_DOB"].ToString(), secondarydob) != 0)
        {
            string act = "secondary dob changed from:" + Session["oProfile_Secondary_DOB"].ToString() + "To:" + secondarydob;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oProfile_Secondary_Nationality"].ToString(), secondarynationality) != 0)
        {
            string act = "secondary nationality changed from:" + Session["oProfile_Secondary_Nationality"].ToString() + "To:" + secondarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osage"].ToString(), nsage) != 0)
        {
            string act = "secondary age changed from:" + Session["osage"].ToString() + "To:" + nsage;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osdesignation"].ToString(), nsdesg) != 0)
        {
            string act = "secondary designation changed from:" + Session["osdesignation"].ToString() + "To:" + nsdesg;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oslang"].ToString(), secondarylanguage) != 0)
        {
            string act = "secondary Language changed from:" + Session["oslang"].ToString() + "To:" + secondarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Secondary_Country"].ToString(), secondarycountry) != 0)
        {
            string act = "secondary country changed from:" + Session["oProfile_Secondary_Country"].ToString() + "To:" + secondarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSecondary_CC"].ToString(), Session["scc"].ToString()) != 0)
        {
            string act = "secondary mobile code changed from:" + Session["oSecondary_CC"].ToString() + "To:" + Session["scc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSecondary_Mobile"].ToString(), Session["smobile"].ToString()) != 0)
        {
            string act = "secondary mobile no changed from:" + Session["oSecondary_Mobile"].ToString() + "To:" + Session["smobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());

        }
        else { }
        if (String.Compare(Session["oSecondary_Alt_CC"].ToString(), Session["saltcc"].ToString()) != 0)
        {
            string act = "secondary alternaet num code changed from:" + Session["oSecondary_Alt_CC"].ToString() + "To:" + Session["saltcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSecondary_Alternate"].ToString(), Session["salternate"].ToString()) != 0)
        {
            string act = "secondary alternate no changed from:" + Session["oSecondary_Alternate"].ToString() + "To:" + Session["salternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["osecOfficecc"].ToString(), Session["secOfficecc"].ToString()) != 0)
        {
            string act = "secondary office cc changed from:" + Session["osecOfficecc"].ToString() + "To:" + Session["secOfficecc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["osecofficeno"].ToString(), Session["secOfficeno"].ToString()) != 0)
        {
            string act = "secondary office no changed from:" + Session["osecofficeno"].ToString() + "To:" + Session["secOfficeno"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oSecondary_Email"].ToString(), Session["semail"].ToString()) != 0)
        {
            string act = "secondary email changed from:" + Session["oSecondary_Email"].ToString() + "To:" + Session["semail"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSecondary_Email2"].ToString(), Session["semail2"].ToString()) != 0)
        {
            string act = "secondary email2 changed from:" + Session["oSecondary_Email2"].ToString() + "To:" + Session["semail2"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Title"].ToString(), sp1title) != 0)
        {
            string act = "subprofile1 title changed from:" + Session["oSub_Profile1_Title"].ToString() + "To:" + sp1title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Fname"].ToString(), sp1fname) != 0)
        {
            string act = "subprofile1 fname changed from:" + Session["oSub_Profile1_Fname"].ToString() + "To:" + sp1fname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Lname"].ToString(), sp1lname) != 0)
        {
            string act = "subprofile1 lname changed from:" + Session["oSub_Profile1_Lname"].ToString() + "To:" + sp1lname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_DOB"].ToString(), sp1dob) != 0)
        {
            string act = "subprofile1 dob changed from:" + Session["oSub_Profile1_DOB"].ToString() + "To:" + sp1dob;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Nationality"].ToString(), sp1nationality) != 0)
        {
            string act = "subprofile1 nationality changed from:" + Session["oSub_Profile1_Nationality"].ToString() + "To:" + sp1nationality;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp1age"].ToString(), nsp1age) != 0)
        {
            string act = "subprofile1 age changed from:" + Session["osp1age"].ToString() + "To:" + nsp1age;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile1_Country"].ToString(), sp1country) != 0)
        {
            string act = "subprofile1 country changed from:" + Session["oSub_Profile1_Country"].ToString() + "To:" + sp1country;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_CC"].ToString(), Session["sp1cc"].ToString()) != 0)
        {
            string act = "subprofile1 mobile code changed from:" + Session["oSubprofile1_CC"].ToString() + "To:" + Session["sp1cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_Mobile"].ToString(), Session["sp1mobile"].ToString()) != 0)
        {
            string act = "subprofile1 mobile no changed from:" + Session["oSubprofile1_Mobile"].ToString() + "To:" + Session["sp1mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_Alt_CC"].ToString(), Session["sp1altcc"].ToString()) != 0)
        {
            string act = "subprofile1 alternate no code changed from:" + Session["oSubprofile1_Alt_CC"].ToString() + "To:" + Session["sp1altcc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_Alternate"].ToString(), Session["sp1alternate"].ToString()) != 0)
        {
            string act = "subprofile1 alternate changed from:" + Session["oSubprofile1_Alternate"].ToString() + "To:" + Session["sp1alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["oSubprofile1_Email"].ToString(), Session["sp1email"].ToString()) != 0)
        {
            string act = "subprofile1 email changed from:" + Session["oSubprofile1_Email"].ToString() + "To:" + Session["sp1email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile1_Email2"].ToString(), Session["sp1email2"].ToString()) != 0)
        {
            string act = "subprofile1 email2 changed from:" + Session["ooSubprofile1_Email2"].ToString() + "To:" + Session["sp1email2"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Title"].ToString(), sp2title) != 0)
        {
            string act = "subprofile2 title changed from:" + Session["oSub_Profile2_Title"].ToString() + "To:" + sp2title;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Fname"].ToString(), sp2fname) != 0)
        {
            string act = "subprofile2 fname changed from:" + Session["oSub_Profile2_Fname"].ToString() + "To:" + sp2fname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Lname"].ToString(), sp2lname) != 0)
        {
            string act = "subprofile2 lname changed from:" + Session["oSub_Profile2_Lname"].ToString() + "To:" + sp2lname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_DOB"].ToString(), sp2dob) != 0)
        {
            string act = "subprofile2 dob changed from:" + Session["oSub_Profile2_DOB"].ToString() + "To:" + sp2dob;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Nationality"].ToString(), sp2nationality) != 0)
        {
            string act = "subprofile2 nationality changed from:" + Session["oSub_Profile2_Nationality"].ToString() + "To:" + sp2nationality;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp2age"].ToString(), nsp2age) != 0)
        {
            string act = "subprofile2 age changed from:" + Session["osp2age"].ToString() + "To:" + nsp2age;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile2_Country"].ToString(), sp2country) != 0)

        {
            string act = "subprofile2 country changed from:" + Session["oSub_Profile2_Country"].ToString() + "To:" + sp2country;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_CC"].ToString(), Session["sp2cc"].ToString()) != 0)
        {
            string act = "subprofile2 mobile code changed from:" + Session["oSubprofile2_CC"].ToString() + "To:" + Session["sp2cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Mobile"].ToString(), Session["sp2mobile"].ToString()) != 0)
        {
            string act = "subprofile2 mobile no changed from:" + Session["oSubprofile2_Mobile"].ToString() + "To:" + Session["sp2mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Alt_CC"].ToString(), Session["sp2altccc"].ToString()) != 0)
        {
            string act = "subprofile2 alternate no code changed from:" + Session["oSubprofile2_Alt_CC"].ToString() + "To:" + Session["sp2altccc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Alternate"].ToString(), Session["sp2alternate"].ToString()) != 0)
        {
            string act = "subprofile2 alternate no changed from:" + Session["oSubprofile2_Alternate"].ToString() + "To:" + Session["sp2alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Email"].ToString(), Session["sp2email"].ToString()) != 0)
        {
            string act = "subprofile2 email changed from:" + Session["oSubprofile2_Email"].ToString() + "To:" + Session["sp2email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile2_Email2"].ToString(), Session["sp2email2"].ToString()) != 0)
        {
            string act = "subprofile2 email2 changed from:" + Session["ooSubprofile2_Email2"].ToString() + "To:" + Session["sp2email2"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        // sub profile 3//
        if (String.Compare(Session["oSub_Profile3_Title"].ToString(), sp3title) != 0)
        {
            string act = "subprofile3 title changed from:" + Session["oSub_Profile3_Title"].ToString() + "To:" + sp3title;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Fname"].ToString(), sp3fname) != 0)
        {
            string act = "subprofile3 fname changed from:" + Session["oSub_Profile3_Fname"].ToString() + "To:" + sp3fname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Lname"].ToString(), sp3lname) != 0)
        {
            string act = "subprofile3 lname changed from:" + Session["oSub_Profile3_Lname"].ToString() + "To:" + sp3lname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_DOB"].ToString(), sp3dob) != 0)
        {
            string act = "subprofile3 dob changed from:" + Session["oSub_Profile3_DOB"].ToString() + "To:" + sp3dob;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Nationality"].ToString(), sp3nationality) != 0)
        {
            string act = "subprofile3 nationality changed from:" + Session["oSub_Profile3_Nationality"].ToString() + "To:" + sp3nationality;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp3age"].ToString(), nsp3age) != 0)
        {
            string act = "subprofile3 age changed from:" + Session["osp3age"].ToString() + "To:" + nsp3age;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile3_Country"].ToString(), sp3country) != 0)

        {
            string act = "subprofile3 country changed from:" + Session["oSub_Profile3_Country"].ToString() + "To:" + sp3country;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_CC"].ToString(), Session["sp3cc"].ToString()) != 0)
        {
            string act = "subprofile3 mobile code changed from:" + Session["oSubprofile3_CC"].ToString() + "To:" + Session["sp3cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Mobile"].ToString(), Session["sp3mobile"].ToString()) != 0)
        {
            string act = "subprofile3 mobile no changed from:" + Session["oSubprofile3_Mobile"].ToString() + "To:" + Session["sp3mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Alt_CC"].ToString(), Session["sp3altccc"].ToString()) != 0)
        {
            string act = "subprofile3 alternate no code changed from:" + Session["oSubprofile3_Alt_CC"].ToString() + "To:" + Session["sp3altccc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Alternate"].ToString(), Session["sp3alternate"].ToString()) != 0)
        {
            string act = "subprofile3 alternate no changed from:" + Session["oSubprofile3_Alternate"].ToString() + "To:" + Session["sp3alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile3_Email"].ToString(), Session["sp3email"].ToString()) != 0)
        {
            string act = "subprofile3 email changed from:" + Session["oSubprofile3_Email"].ToString() + "To:" + Session["sp3email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        // end//
        if (String.Compare(Session["oSubprofile3_Email2"].ToString(), Session["sp3email2"].ToString()) != 0)
        {
            string act = "subprofile3 email2 changed from:" + Session["ooSubprofile3_Email2"].ToString() + "To:" + Session["sp3email2"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }


        // sub profile 4//
        if (String.Compare(Session["oSub_Profile4_Title"].ToString(), sp4title) != 0)
        {
            string act = "subprofile4 title changed from:" + Session["oSub_Profile4_Title"].ToString() + "To:" + sp4title;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Fname"].ToString(), sp4fname) != 0)
        {
            string act = "subprofile4 fname changed from:" + Session["oSub_Profile4_Fname"].ToString() + "To:" + sp4fname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Lname"].ToString(), sp4lname) != 0)
        {
            string act = "subprofile4 lname changed from:" + Session["oSub_Profile4_Lname"].ToString() + "To:" + sp4lname;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_DOB"].ToString(), sp4dob) != 0)
        {
            string act = "subprofile4 dob changed from:" + Session["oSub_Profile4_DOB"].ToString() + "To:" + sp4dob;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Nationality"].ToString(), sp4nationality) != 0)
        {
            string act = "subprofile4 nationality changed from:" + Session["oSub_Profile4_Nationality"].ToString() + "To:" + sp4nationality;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["osp4age"].ToString(), nsp4age) != 0)
        {
            string act = "subprofile4 age changed from:" + Session["osp4age"].ToString() + "To:" + nsp4age;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSub_Profile4_Country"].ToString(), sp4country) != 0)

        {
            string act = "subprofile4 country changed from:" + Session["oSub_Profile4_Country"].ToString() + "To:" + sp4country;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_CC"].ToString(), Session["sp4cc"].ToString()) != 0)
        {
            string act = "subprofile4 mobile code changed from:" + Session["oSubprofile4_CC"].ToString() + "To:" + Session["sp4cc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Mobile"].ToString(), Session["sp4mobile"].ToString()) != 0)
        {
            string act = "subprofile4 mobile no changed from:" + Session["oSubprofile4_Mobile"].ToString() + "To:" + Session["sp4mobile"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Alt_CC"].ToString(), Session["sp4altccc"].ToString()) != 0)
        {
            string act = "subprofile4 alternate no code changed from:" + Session["oSubprofile4_Alt_CC"].ToString() + "To:" + Session["sp4altccc"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Alternate"].ToString(), Session["sp4alternate"].ToString()) != 0)
        {
            string act = "subprofile4 alternate no changed from:" + Session["oSubprofile4_Alternate"].ToString() + "To:" + Session["sp4alternate"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oSubprofile4_Email"].ToString(), Session["sp4email"].ToString()) != 0)
        {
            string act = "subprofile4 email changed from:" + Session["oSubprofile4_Email"].ToString() + "To:" + Session["sp4email"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        // end//
        if (String.Compare(Session["oSubprofile4_Email2"].ToString(), Session["sp4email2"].ToString()) != 0)
        {
            string act = "subprofile4 email2 changed from:" + Session["ooSubprofile4_Email2"].ToString() + "To:" + Session["sp4email2"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["oProfile_Address_Line1"].ToString(), address1) != 0)

        {
            string act = "address1 changed from:" + Session["oProfile_Address_Line1"].ToString() + "To:" + address1;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_Line2"].ToString(), address2) != 0)
        {
            string act = "address2 changed from:" + Session["oProfile_Address_Line2"].ToString() + "To:" + address2;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_State"].ToString(), state) != 0)
        {
            string act = "state changed from:" + Session["oProfile_Address_State"].ToString() + "To:" + state;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_city"].ToString(), city) != 0)
        {
            string act = "city changed from:" + Session["oProfile_Address_city"].ToString() + "To:" + city;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_Postcode"].ToString(), pincode) != 0)
        {
            string act = "pincode changed from:" + Session["oProfile_Address_Postcode"].ToString() + "To:" + pincode;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Address_Country"].ToString(), acountry) != 0)
        {
            string act = "Address Country changed from:" + Session["oProfile_Address_Country"].ToString() + "To:" + acountry;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Employment_status"].ToString(), employmentstatus) != 0)
        {
            string act = "employment status changed from:" + Session["oProfile_Employment_status"].ToString() + "To:" + employmentstatus;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Marital_status"].ToString(), maritalstatus) != 0)
        {
            string act = "marital status changed from:" + Session["oProfile_Marital_status"].ToString() + "To:" + maritalstatus;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_NOY_Living_as_couple"].ToString(), livingyrs) != 0)
        {
            string act = "livingyrs changed from:" + Session["oProfile_NOY_Living_as_couple"].ToString() + "To:" + livingyrs;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Resort_Name"].ToString(), resort) != 0)
        {
            string act = "resort changed from:" + Session["oProfile_Stay_Resort_Name"].ToString() + "To:" + resort;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Resort_Room_Number"].ToString(), roomno) != 0)
        {
            string act = "roomno changed from:" + Session["oProfile_Stay_Resort_Room_Number"].ToString() + "To:" + roomno;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Arrival_Date"].ToString(), arrivaldate) != 0)
        {
            string act = "arrival date changed from:" + Session["oProfile_Stay_Arrival_Date"].ToString() + "To:" + arrivaldate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oProfile_Stay_Departure_Date"].ToString(), departuredate) != 0)
        {
            string act = "departure date changed from:" + Session["oProfile_Stay_Departure_Date"].ToString() + "To:" + departuredate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Guest_Status"].ToString(), gueststatus) != 0)
        {
            string act = "guest status changed from:" + Session["oTour_Details_Guest_Status"].ToString() + "To:" + gueststatus;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Guest_Sales_Rep"].ToString(), salesrep) != 0)

        {
            string act = "salesrep changed from:" + Session["oTour_Details_Guest_Sales_Rep"].ToString() + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Sales_Deck_Check_In"].ToString(), timeIn) != 0)
        {
            string act = "time In changed from:" + Session["oTour_Details_Sales_Deck_Check_In"].ToString() + "To:" + timeIn;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oTour_Details_Sales_Deck_Check_Out"].ToString(), timeOut) != 0)
        {
            string act = "time Out changed from:" + Session["oTour_Details_Sales_Deck_Check_Out"].ToString() + "To:" + timeOut;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Tour_Date"].ToString(), tourdate) != 0)
        {
            string act = "tour date changed from:" + Session["oTour_Details_Tour_Date"].ToString() + "To:" + tourdate;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["tourweekno"].ToString(), wkno.ToString()) != 0)
        {
            string act = "week num changed from:" + Session["tourweekno"].ToString() + "To:" + wkno.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Taxi_In_Price"].ToString(), taxin) != 0)
        {
            string act = "taxi in price changed from:" + Session["oTour_Details_Taxi_In_Price"].ToString() + "To:" + taxin;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Taxi_In_Ref"].ToString(), taxirefin) != 0)
        {
            string act = "taxi reference in changed from:" + Session["oTour_Details_Taxi_In_Ref"].ToString() + "To:" + taxirefin;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(Session["oTour_Details_Taxi_Out_Price"].ToString(), taxiout) != 0)
        {
            string act = "taxi outprice changed from:" + Session["oTour_Details_Taxi_Out_Price"].ToString() + "To:" + taxiout;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oTour_Details_Taxi_Out_Ref"].ToString(), taxirefout) != 0)
        {
            string act = "taxi reference out changed from:" + Session["oTour_Details_Taxi_Out_Ref"].ToString() + "To:" + taxirefout;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oComments"].ToString(), ProComments) != 0)
        {
            string act = "Profile Comments changed from:" + Session["oComments"].ToString() + "To:" + ProComments;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(Session["ocomment2"].ToString(), Procomment2) != 0)
        {
            string act = "Profile Comment2 changed from:" + Session["ocomment2"].ToString() + "To:" + Procomment2;
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(Session["oregTerms"].ToString(), Session["regTerms"].ToString()) != 0)
        {
            string act = "Registration Terms changed from:" + Session["oregTerms"].ToString() + "To:" + Session["regTerms"].ToString();
            int insertlog1 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", act, user, DateTime.Now.ToString());
        }
        else { }





        //update profile
        int updateprofile = Queries.UpdateProfile(Session["ProfileID"].ToString(), venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, mgr, photoidentity, card, ProComments, "", subVenue, Session["regTerms"].ToString(), "", Procomment2,subVenueGroup, leadOffice);
        int primary = Queries.UpdateProfilePrimary(Session["ProfileID"].ToString(), primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry, npage, npdesg, primarylanguage);
        if (secondarytitle == "")
        {

        }
        else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Profile_Secondary where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int secondary = Queries.UpdateProfileSecondary(Session["ProfileID"].ToString(), secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, nsage, nsdesg, secondarylanguage);
            }
            else
            {
                int year = DateTime.Now.Year;
                string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                int secondary = Queries.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, Session["ProfileID"].ToString(), nsage, nsdesg, secondarylanguage);
                int updates = Queries.UpdateSecondaryValue(office, year);

                string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + profileidTextBox.Text + "Age:" + nsage + "," + "Designation:" + nsdesg + "," + "Languages spoken:" + secondarylanguage;
                int insertlog3 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log3, user, DateTime.Now.ToString());

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

            string query = "select * from Sub_Profile1 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp1 = Queries.UpdateSubProfile1(profileidTextBox.Text, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, nsp1age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile1id = Queries.GetSubProfile1ID(office);
                int subprofielid = Queries.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, Session["ProfileID"].ToString(), nsp1age);
                int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


                string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog5 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log5, user, DateTime.Now.ToString());
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

            string query = "select * from Sub_Profile2 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp2 = Queries.UpdateSubProfile2(Session["ProfileID"].ToString(), sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, nsp2age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile2id = Queries.GetSubProfile2ID(office);
                int subprofielid2 = Queries.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, Session["ProfileID"].ToString(), nsp2age);
                int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

                string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog6 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log6, user, DateTime.Now.ToString());
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

            string query = "select * from Sub_Profile3 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp3 = Queries.UpdateSubProfile3(Session["ProfileID"].ToString(), sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, nsp3age);

            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile3id = Queries.GetSubProfile3ID(office);
                int subprofielid3 = Queries.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, Session["ProfileID"].ToString(), nsp3age);
                int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

                string log12 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog12 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log12, user, DateTime.Now.ToString());
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

            string query = "select * from Sub_Profile4 where Profile_ID = '" + Session["ProfileID"].ToString() + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp4 = Queries.UpdateSubProfile4(profileidTextBox.Text, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, nsp4age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile4id = Queries.GetSubProfile4ID(office);
                int subprofielid4 = Queries.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, Session["ProfileID"].ToString(), nsp4age);
                int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


                string log13 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + Session["ProfileID"].ToString();
                int insertlog13 = Queries.InsertContractLogs_India(Session["ProfileID"].ToString(), "", log13, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
        }
           

            int address = Queries.UpdateProfileAddress(Session["ProfileID"].ToString(), address1, address2, state, city, pincode, acountry);
        int phone = Queries.UpdatePhone(Session["ProfileID"].ToString(), Session["pcc"].ToString(), Session["pmobile"].ToString(), Session["paltrcc"].ToString(), Session["palternate"].ToString(), Session["scc"].ToString(), Session["smobile"].ToString(), Session["saltcc"].ToString(), Session["salternate"].ToString(), Session["sp1cc"].ToString(), Session["sp1mobile"].ToString(), Session["sp1altcc"].ToString(), Session["sp1alternate"].ToString(), Session["sp2cc"].ToString(), Session["sp2mobile"].ToString(), Session["sp2altccc"].ToString(), Session["sp2alternate"].ToString(), Session["sp3cc"].ToString(), Session["sp3mobile"].ToString(), Session["sp4cc"].ToString(), Session["sp4mobile"].ToString(), Session["sp3altccc"].ToString(), Session["sp3alternate"].ToString(), Session["sp4altccc"].ToString(), Session["sp4alternate"].ToString(), Session["priOfficecc"].ToString(), Session["priOfficeno"].ToString(), Session["secOfficecc"].ToString(), Session["secOfficeno"].ToString(),"","","","");
        int email = Queries.UpdateEmail(Session["ProfileID"].ToString(), Session["pemail"].ToString(), Session["semail"].ToString(), Session["sp1email"].ToString(), Session["sp2email"].ToString(), Session["pemail2"].ToString(), Session["semail2"].ToString(), Session["sp1email2"].ToString(), Session["sp2email2"].ToString(), Session["sp3email"].ToString(), Session["sp3email2"].ToString(), Session["sp4email"].ToString(), Session["sp4email2"].ToString());
        int stay = Queries.UpdateProfileStay(Session["ProfileID"].ToString(), resort, roomno, arrivaldate, departuredate);
        int tour = Queries.UpdateTourDetails(Session["ProfileID"].ToString(), gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout, "", wkno);



       


        Response.Redirect(Request.RawUrl);



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
        if (venueGroup == "Coldline" || venueGroup == "COLDLINE")
        {
            String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string JSON = "{\n \"names\":[";
            sqlcon.Open();

            string query = "select distinct Marketing_Program_Name from Marketing_Program join Venue_Group vg on vg.Venue_group_ID=Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID= vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='" + profileID + "' ) and vg.Venue_Group_Name='" + venueGroup + "' and v.Venue_Name= '" + venue + "'";
            SqlCommand sql = new SqlCommand(query, sqlcon);

            SqlDataReader reader = sql.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    JSON += "[\"" + name + "\",\"" + name + "\"],";
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
        else
        {


            String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string JSON = "{\n \"names\":[";
            sqlcon.Open();

            string query = "select distinct Marketing_Program_Name,Marketing_Program_abbrv from Marketing_Program join Venue_Group vg on vg.Venue_group_ID=Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID= vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='" + profileID + "' ) and vg.Venue_Group_Name='" + venueGroup + "' and v.Venue_Name= '" + venue + "'";
            SqlCommand sql = new SqlCommand(query, sqlcon);

            SqlDataReader reader = sql.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string Marketing_Program_abbrv = reader.GetString(1);
                    JSON += "[\"" + name + "\",\"" + Marketing_Program_abbrv + "\"],";
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
    }

    [WebMethod]
    public static string getSubVenue(string venue, string venueGroup)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select svi.SVenue_India_Name from sub_venue_india svi join Venue_Group vg on vg.Venue_Group_ID = svi.GroupVenue_ID join venue v on v.Venue_ID = vg.Venue_ID where vg.Venue_Group_Name = '" + venueGroup + "' and v.Venue_Name = '" + venue + "' and svi.SVenue_India_Status = 'Active' order by 1; ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string SVenue_India_Name = reader.GetString(0);
                JSON += "[\"" + SVenue_India_Name + "\"],";


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
    public static string getAffiliate()
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select Affiliate_Type,currency from Finance_Details_Indian where ContractNo='"+HttpContext.Current.Session["contractno"].ToString()+ "'";
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


        SqlDataReader reader = Queries.LoadManagersOnVenue1(venue,office);
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
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue,office);
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
            SqlDataReader reader = Queries.LoadTOOPCOnVenue1(venue,office);
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
        string query = "select RegTerms from profile p where Profile_ID='" +HttpContext.Current.Session["ProfileID"].ToString() + "';";
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
        string companyname = ds.Tables[0].Rows[0]["Company_Name"].ToString().ToUpper();
        string statename = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
        LoadDocuments(ContractdetailsIDTextBox.Text, officeTextBox.Text, Finance_Details,contracttypeTextBox.Text , aftype, mc, CanxContractNoTextBox.Text, companyname, statename);
        string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
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
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["State"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodaddDropDownList.SelectedItem.Text,"", "", "", "", "", receipttypeDropDownList.SelectedItem.Text );
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "State:" + dsrecp.Tables[0].Rows[0]["State"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodaddDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "" + "," + "Current rate:" + "0" + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + " " + "," + "contractdetailsID:" + ContractdetailsIDTextBox.Text+ "Type:"+ receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    int updaterecno1 = Queries.UpdateIndian_ReceiptGenerationFinancialYear(VenueDropDownList.SelectedItem.Text);
                }
                else
                {
                    double currentrate = Convert.ToDouble(foreigncurrency);

                    double indeposit = Math.Round(Convert.ToDouble(ReceiptamtTextBox.Text) * currentrate);
                    double gst = 0;
                    double taxableamt = 0;
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["State"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "KARMA ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodaddDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, "INR", currentrate.ToString(), DateTime.Now.ToShortDateString(), ReceiptamtTextBox.Text, receipttypeDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "State:" + dsrecp.Tables[0].Rows[0]["State"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "KARMA ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodaddDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "Rs." + "," + "Current rate:" + currentrate.ToString() + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + ReceiptamtTextBox.Text + "," + "contractdetailsID:" +ContractdetailsIDTextBox.Text+ "Type:"+ receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    int updaterecno1 = Queries.UpdateIndian_ReceiptGenerationFinancialYear(VenueDropDownList.SelectedItem.Text);
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
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["State"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodaddDropDownList.SelectedItem.Text, "", "", "", "", "", receipttypeDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "State:" + dsrecp.Tables[0].Rows[0]["State"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodaddDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "" + "," + "Current rate:" + "0" + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + " " + "," + "contractdetailsID:" + ContractdetailsIDTextBox.Text+" Type:"+ receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    int updaterecno1 = Queries.UpdateIndian_ReceiptGenerationFinancialYear(VenueDropDownList.SelectedItem.Text);
                }
                else
                {
                    double currentrate = Convert.ToDouble(foreigncurrency);

                    double indeposit = Math.Round(Convert.ToDouble(ReceiptamtTextBox.Text) * currentrate);
                    double gst = 0;
                    double taxableamt = 0;
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, ContractdetailsIDTextBox.Text, contractnoTextBox.Text, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["State"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodaddDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, "INR", currentrate.ToString(), DateTime.Now.ToShortDateString(), ReceiptamtTextBox.Text, receipttypeDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + ContractdetailsIDTextBox.Text + "," + "Contractno:" + contractnoTextBox.Text + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "State:" + dsrecp.Tables[0].Rows[0]["State"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Total Amount:" + indeposit.ToString() + "," + "Deposit Payment mode:" + depositmethodaddDropDownList.SelectedItem.Text + "," + "Actual currency:" + currencyDropDownList.SelectedItem.Text + "," + "Converted Currency:" + "Rs." + "," + "Current rate:" + currentrate.ToString() + "," + "Exchanged date:" + DateTime.Now.ToShortDateString() + "," + "Actual Amt:" + ReceiptamtTextBox.Text + "," + "contractdetailsID:" + ContractdetailsIDTextBox.Text+"Type:"+receipttypeDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileidTextBox.Text, ContractdetailsIDTextBox.Text, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    int updaterecno1 = Queries.UpdateIndian_ReceiptGenerationFinancialYear(VenueDropDownList.SelectedItem.Text);
                }

            }

          
        }
        // commented by gaurav //
     //---   ReceiptamtTextBox.Text = "";
      //---  DataSet dsreceipt = Queries.LoadContract_Indian_Deposit_ReceiptDetails(ContractdetailsIDTextBox.Text);
     //---   GridView3.DataSource = dsreceipt;
      //---  GridView3.DataBind();

        // -- end --//
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

            //-- commented by gaurav --//
              //-- DataSet dsor = Queries.LoadContractNo_Othernames(ContractdetailsIDTextBox.Text);
              //--  GridView2.DataSource = dsor;
              //--  GridView2.DataBind();
              // ---- end  -----//
 

           
        }
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    // commented by gaurav //
    //protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
         
    //    string reciptno = e.CommandArgument.ToString();
    //    if (e.CommandName == "Delete")
    //    {
    //    //   Response.Write("test" + reciptno);
    //      int update=Queries.UpdateReceiptTableStatus(reciptno);
           
    //        DataSet dsreceiptdetails = Queries.LoadContract_Indian_Deposit_ReceiptDetails(ContractdetailsIDTextBox.Text);
    //        GridView3.DataSource = dsreceiptdetails;
    //        GridView3.DataBind();
    //    }
    //}

        // ------------------ commented by gaurav------------------//
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
    public string getReceiptDetails()
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Deposit_Receipt_Id,ContractNo,Receipt_No,convert(varchar(50),Receipt_Date,105),taxable_value,totalamt,Payment_Mode,actual_currency,converted_currency,Converted_rate,Actual_Amt,ContractDetails_ID from Contract_Indian_Deposit_Receipt where  ContractDetails_ID='" + ContractdetailsIDTextBox.Text + "' and Receipt_Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string Deposit_Receipt_Id = reader.GetString(0);
                string ContractNo = reader.GetString(1);
                string receiptNo = reader.GetString(2);
                string date = reader.GetString(3);
                string taxableAmt = reader.GetString(4);
                double totalAmt = reader.GetDouble(5);
                string paymentMode = reader.GetString(6);
                string actualCurrency = reader.GetString(7);
                string convertedCurrency = reader.GetString(8);
                string convertedRate = reader.GetString(9);
                string actualAmt = reader.GetString(10);

                htmlstr += "<tr><td>"+ Deposit_Receipt_Id + "</td><td>" + ContractNo + "</td><td>" + receiptNo + "</td><td>" + date + "</td><td>" + taxableAmt + "</td><td>" + totalAmt + "</td><td>" + paymentMode + "</td><td>" + actualCurrency + "</td><td>" + convertedCurrency + "</td><td>" + convertedRate + "</td><td>" + actualAmt + "</td><td><button id='btn-delete' type='button'>Delete</button></td></tr>";
            }
        }
        else
        {
          
        }
        reader.Close();
        sqlcon.Close();
        return htmlstr;
    }


    [WebMethod]
    public static void deleteReceipts(string receiptID,string contractNO,string receiptNO)

    {
        HttpContext.Current.Session["receiptID"] = "";
        HttpContext.Current.Session["receiptNO"] = "";
        HttpContext.Current.Session["receiptID"] = receiptID;
        HttpContext.Current.Session["receiptNO"] = receiptNO;
        string user = HttpContext.Current.Session["username"].ToString();
        DataSet dsrecdel = Queries.LoadContract_Indian_Deposit_ReceiptOnDeposit_Receipt_Id(HttpContext.Current.Session["receiptID"].ToString());
        string Deposit_Receipt_Id = dsrecdel.Tables[0].Rows[0]["Deposit_Receipt_Id"].ToString();
        string ContractDetails_ID = dsrecdel.Tables[0].Rows[0]["ContractDetails_ID"].ToString();
        string ContractNo = dsrecdel.Tables[0].Rows[0]["ContractNo"].ToString();
        string Receipt_No = dsrecdel.Tables[0].Rows[0]["Receipt_No"].ToString();
        string Receipt_Date = dsrecdel.Tables[0].Rows[0]["Receipt_Date"].ToString();
        string place_supply = dsrecdel.Tables[0].Rows[0]["place_supply"].ToString();
        string state = dsrecdel.Tables[0].Rows[0]["state"].ToString();
        string state_code = dsrecdel.Tables[0].Rows[0]["state_code"].ToString();
        string Product_Name = dsrecdel.Tables[0].Rows[0]["Product_Name"].ToString();
        string SAC = dsrecdel.Tables[0].Rows[0]["SAC"].ToString();
        string Amount = dsrecdel.Tables[0].Rows[0]["Amount"].ToString();
        string taxable_value = dsrecdel.Tables[0].Rows[0]["taxable_value"].ToString();
        string cgstrate = dsrecdel.Tables[0].Rows[0]["cgstrate"].ToString();
        string cgstamt = dsrecdel.Tables[0].Rows[0]["cgstamt"].ToString();
        string sgstrate = dsrecdel.Tables[0].Rows[0]["sgstrate"].ToString();
        string sgstamt = dsrecdel.Tables[0].Rows[0]["sgstamt"].ToString();
        string totalamt = dsrecdel.Tables[0].Rows[0]["totalamt"].ToString();
        string Payment_Mode = dsrecdel.Tables[0].Rows[0]["Payment_Mode"].ToString();
        string actual_currency = dsrecdel.Tables[0].Rows[0]["actual_currency"].ToString();
        string converted_currency = dsrecdel.Tables[0].Rows[0]["converted_currency"].ToString();
        string Converted_rate = dsrecdel.Tables[0].Rows[0]["Converted_rate"].ToString();
        string ExchangedValue_date = dsrecdel.Tables[0].Rows[0]["ExchangedValue_date"].ToString();
        string Actual_Amt = dsrecdel.Tables[0].Rows[0]["Actual_Amt"].ToString();
        string Receipt_Status = dsrecdel.Tables[0].Rows[0]["Receipt_Status"].ToString();
        string receipttype = dsrecdel.Tables[0].Rows[0]["receipttype"].ToString();
        string payment_date = dsrecdel.Tables[0].Rows[0]["payment_date"].ToString();
        int exists =Queries.CheckDeposit_Receipt_IdExists(HttpContext.Current.Session["receiptID"].ToString());
        if (exists == 1)
        {
            int delrecp = Queries.DeleteContract_Indian_Deposit_ReceiptOnDeposit(HttpContext.Current.Session["receiptID"].ToString());
            string pageName = "Indian Contract Edit";
            string details = "Receipt ID:" + HttpContext.Current.Session["receiptID"].ToString() + " Receipt No: " + HttpContext.Current.Session["receiptNO"].ToString() + " deleted";
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }
        else
        {


            int receiptdelete = Queries.InsertContract_Indian_Deposit_Receipt_Deleted(Deposit_Receipt_Id, ContractDetails_ID, ContractNo, Receipt_No, Receipt_Date,
                  place_supply, state, state_code, Product_Name, SAC, Amount, taxable_value, cgstrate, cgstamt, sgstrate, sgstamt,
                totalamt, Payment_Mode, actual_currency, converted_currency, Converted_rate, ExchangedValue_date, Actual_Amt, Receipt_Status, receipttype, payment_date);

            int delrecp = Queries.DeleteContract_Indian_Deposit_ReceiptOnDeposit(HttpContext.Current.Session["receiptID"].ToString());

            //string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            //       SqlConnection sqlcon = new SqlConnection(conn);
            //string query = "update Contract_Indian_Deposit_Receipt set Receipt_Status='Inactive' where Deposit_Receipt_Id='" + HttpContext.Current.Session["receiptID"].ToString() + "'";
            //sqlcon.Open();
            //SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            //cmd2.ExecuteNonQuery();
            //sqlcon.Close();

            string pageName = "Indian Contract Edit";
            string details = "Receipt ID:" + HttpContext.Current.Session["receiptID"].ToString() + " Receipt No: " + HttpContext.Current.Session["receiptNO"].ToString() + " deleted";
            int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());
        }

    }

    

    public string getsorAdditionalDetails()
    {
        string user = HttpContext.Current.Session["username"].ToString();
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select otherNamesID,ContractNo,Type,Name,Address,State,Country,Postcode from ContractNo_Othernames where ContractDetails_ID='"+ ContractdetailsIDTextBox.Text + "' and status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string otherNamesID = reader.GetString(0);
                string ContractNo = reader.GetString(1);
                string Type = reader.GetString(2);
                string Name = reader.GetString(3);
                string Address = reader.GetString(4);
                string State = reader.GetString(5);
                string Country = reader.GetString(6);
                string Postcode = reader.GetString(7);
          
                htmlstr += "<tr><td>" + otherNamesID + "</td><td>" + ContractNo + "</td><td>" + Type + "</td><td>" + Name + "</td><td>" + Address + "</td><td>" + State + "</td><td>" + Country + "</td><td>" + Postcode + "</td><td><button id='btn-delete1' type='button'>Delete</button></td></tr>";
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "Func()", true);
        }
        reader.Close();
        sqlcon.Close();
        return htmlstr;
    }


    [WebMethod]
    public static void deleteSorAdd(string sorID, string contractNO, string type)
    {
        HttpContext.Current.Session["sorID"] = "";
        HttpContext.Current.Session["type"] = "";
        HttpContext.Current.Session["sorID"] = sorID;
        HttpContext.Current.Session["type"] = type;
        string user = HttpContext.Current.Session["username"].ToString();
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "update ContractNo_Othernames set Status='Inactive' where otherNamesID='"+ HttpContext.Current.Session["sorID"].ToString() + "'";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

        string pageName = "Indian Contract Edit";
        string details = "ID:" + HttpContext.Current.Session["sorID"].ToString() + " type: " + HttpContext.Current.Session["type"].ToString() + " deleted";
        int insertlog1 = Queries.admin_Log(pageName, details, user, DateTime.Now.ToString());

    }

    [WebMethod]
    public static string ContractnoExists(string contractno)
    {

        String JSON = "{\n \"names\":[";

        SqlDataReader reader = Queries.CheckContractNo(contractno);
        if (reader.HasRows)
        {
            
            JSON += "[\"" + "1" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "0" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        return JSON;

    }
}



