<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="WebSite5_production_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title></title>
    <link href="../production/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body >

    <form id="form1" runat="server">

           
<div style="width:auto; margin:auto; float:none; margin-bottom:10px; text-align:center; clear:both;">

</div>

<div>
<div class="phpkida-main">
	<h2>   <img src="../production/images/Gold.png" class="img-square" alt=""   width="180" height="80" /><br /></h2>
		<asp:TextBox ID="TextBox1" class="ggg" name="Email" placeholder="USER NAME" runat="server"> </asp:TextBox>
			<asp:TextBox ID="TextBox2" class="ggg" name="Password" placeholder="PASSWORD" runat="server" TextMode="Password"></asp:TextBox>
				<div class="clearfix"></div>
				<asp:Button ID="Button1" name="login"  style="width:150px" runat="server" Text="Sign In" />
		
		<p>Sign in with Google?<a href="../../Contractsite/googlesign.aspx">click here</a></p>
</div>
</div>                  

    </form>

</body>
</html>
