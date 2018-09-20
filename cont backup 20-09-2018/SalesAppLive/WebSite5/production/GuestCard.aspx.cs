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

public partial class WebSite5_production_GuestCard : System.Web.UI.Page
{
    static string profileID;
    static string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        profileID = Request.QueryString["name"];
       string office = (string)Session["office"];
        user = (string)Session["username"];

        if (office == "IVO")
        {

            DataTable datatable = Queries2.loadregcard(profileID);
            var printr = "Guest Reg Form";
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
            string fn = "Guest Reg Form" + ".pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

            fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
            FileSize = fs.Length;
            byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
            fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            fs.Close();
            Response.BinaryWrite(bBuffer);
            Response.Flush();
        }
        else if (office == "HML")
        {

            DataTable datatable = Queries2.loadregcard1(profileID);
            var printr = "Guest Reg form india";
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
            string fn = "Guest Reg Form" + ".pdf";
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
    