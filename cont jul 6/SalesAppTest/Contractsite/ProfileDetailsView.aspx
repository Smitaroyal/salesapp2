<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileDetailsView.aspx.cs" Inherits="Contractsite_ProfileDetailsView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
                    <asp:Label ID="Label1" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Profile ID"></asp:Label>
                &nbsp;&nbsp;
                    <asp:Label ID="lblprofileid" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Tour Date"></asp:Label>
                &nbsp;
                    <asp:Label ID="lbltourdate" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
                    <asp:Label ID="Label2" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="OPC Agent"></asp:Label>
                &nbsp;<asp:Label ID="lblopcagent" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label19" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Team Capt"></asp:Label>
                &nbsp;<asp:Label ID="lblteamcapt" runat="server" Font-Names="Times New Roman" Font-Size="Small"></asp:Label>
                <br />
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Client Name (Male)"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblmale" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Height="18px" Width="302px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label37" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="DOB"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblmale0" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Width="302px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Client Name (Female)"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblfemale" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Height="18px" Width="343px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label36" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="DOB"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblfemale0" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Resort Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblresort" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Width="332px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Arrival Date"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblarrival" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label34" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Dep.Date :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbldepdate" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label9" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Member/ Non Member" BorderStyle="None" Width="106px"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblnon" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label38" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Employment Status"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblempstatus" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Height="17px" Width="270px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Professional / Designation" BorderStyle="None" Width="99px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblpmale" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Male" BorderStyle="None" Height="36px" Width="43px"></asp:Label>
                    <asp:Label ID="lblmdesg" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Height="38px" Width="370px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label33" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Female" BorderStyle="None" Height="45px" Width="60px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblfdesg" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Height="48px" Width="246px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Marital Status"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblmaritalstatus" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Photo Identity"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblphotoidentitiy" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Type of Card"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblcard" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Comments"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblcomments" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Height="83px" Width="424px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Preferred Lang"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblpmale0" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Male" BorderStyle="None" Height="16px" Width="43px"></asp:Label>
                    <asp:Label ID="lblplang" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Width="242px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label35" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Female" BorderStyle="None" Height="20px" Width="42px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblplang0" runat="server" Font-Names="Times New Roman" Font-Size="Small" BorderStyle="None" Width="242px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label39" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="Select Rep" BorderStyle="None" Width="79px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="salesrepDropDownList" runat="server" Font-Names="Times New Roman" Font-Size="Small" Height="21px" Width="235px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Assign" Font-Names="Times New Roman" Font-Size="Small" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
