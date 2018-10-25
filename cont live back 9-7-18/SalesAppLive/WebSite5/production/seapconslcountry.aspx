<%@ Page Language="C#" AutoEventWireup="true" CodeFile="seapconslcountry.aspx.cs" Inherits="Contractsite_seapconslcountry" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>



    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DATE <br />
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; COUNTRY <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SUBMIT" runat="server" OnClick="SUBMIT_Click" Text="SUBMIT" Width="93px" />
        </p>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1112px">
        </rsweb:ReportViewer>
    </form>



    </body>
</html>
