<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSR_INDIA_ACC.aspx.cs" Inherits="Contractsite_DSR_INDIA_ACC" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        DATE<br />
        <asp:TextBox ID="TextBox1" runat="server">2018-09-24</asp:TextBox>
        <br />
        <br />
        COUNTRY<br />
        <asp:TextBox ID="TextBox2" runat="server">INDIA</asp:TextBox>
        <br />
        <br />
        CURRENCY<br />
        <asp:TextBox ID="TextBox3" runat="server">INR</asp:TextBox>
        <br />
        <br />
        VENUE<br />
        <asp:TextBox ID="TextBox4" runat="server">SOUTH GOA</asp:TextBox>
        <br />
        <br />
        CLUB<br />
        <asp:TextBox ID="TextBox5" runat="server">ROYAL INDIA HOLIDAY CLUB</asp:TextBox>
        <br />
        <br />
        VENUEGROUP<br />
        <asp:TextBox ID="TextBox6" runat="server">COLDLINE</asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1210px">
        </rsweb:ReportViewer>
    </form>
    
</body>
</html>
