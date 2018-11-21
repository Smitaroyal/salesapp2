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
using Microsoft.Reporting.WebForms;

public partial class Contractsite_DSR_INDIA_ACC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void show_report()
    {
        ReportViewer1.Reset();
        DataTable dt1 = Queries.dsr_india_acc1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text);
        DataTable dt2 = Queries.dsr_india_acc2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text);
        DataTable dt3 = Queries.dsr_india_acc3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text);
        DataTable dt4 = Queries.dsr_india_acc4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text);

        ReportDataSource rds1 = new ReportDataSource("DataSet1", dt1);
        ReportDataSource rds2 = new ReportDataSource("DataSet2", dt2);
        ReportDataSource rds3 = new ReportDataSource("DataSet3", dt3);
        ReportDataSource rds4 = new ReportDataSource("DataSet4", dt4);

        ReportViewer1.LocalReport.DataSources.Add(rds1);
        ReportViewer1.LocalReport.DataSources.Add(rds2);
        ReportViewer1.LocalReport.DataSources.Add(rds3);
        ReportViewer1.LocalReport.DataSources.Add(rds4);


        ReportViewer1.LocalReport.ReportPath = "reports/DSR_INDIA_ACC.rdlc";
        ReportParameter[] rptParam = new ReportParameter[]
        {
            new ReportParameter("DATE",TextBox1.Text),
            new ReportParameter("COUNTRY",TextBox2.Text),
            new ReportParameter("CURR",TextBox3.Text),
            new ReportParameter("VENUE",TextBox4.Text),
            new ReportParameter("CLUB",TextBox5.Text),
            new ReportParameter("VENUEGROUP",TextBox6.Text)
        };
        ReportViewer1.LocalReport.SetParameters(rptParam);
        ReportViewer1.LocalReport.Refresh();
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        show_report();
    }
}