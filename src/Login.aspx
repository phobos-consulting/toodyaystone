<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Log in</title>
    <link rel="stylesheet" href="/Edit/Css/All.css" type="text/css" />
    <style type="text/css">
        body{background:#c3c0bd url(/Edit/img/login_bg.gif) repeat-x;}
        td { text-align:left; }
        .login { background:transparent url(/Edit/img/login_panel.gif) no-repeat; padding:20px; margin:100px auto; width:262px; height:162px; }
        .login table { margin:5px auto 0 auto; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <asp:Login ID="Login1" TitleText="<h1>Log in</h1>" runat="server" meta:resourceKey="Login1"
                MembershipProvider="AspNetSqlMembershipProvider" OnAuthenticate="Login1_Authenticate" 
                />
        </div>
    </form>
</body>
</html>
