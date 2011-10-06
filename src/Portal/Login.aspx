<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/NonCMSContent.master" CodeFile="Login.aspx.cs" Inherits="Portal_Login" %>

<asp:Content ContentPlaceHolderID="cphNavigation" runat="server">
    <div class="nav_r_l">
        <a href="#" class="nav_r">Login</a>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphContentTop" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="cphContent" runat="server">
    <div style="width: 100%; height: 100%; vertical-align: middle; text-align: center;">
    <table cellspacing="0" cellpadding="0">
			<tr>
				<td height="10"></td>
			</tr>
			<tr>
				<td width="30"></td>
				<td align="right">Username:&nbsp;&nbsp;<asp:textbox id="txtUsername" Runat="server"></asp:textbox></td>
				<td width="30"></td>
			</tr>
			<tr>
				<td></td>
				<td align="right">Password:&nbsp;&nbsp;<asp:textbox id="txtPassword" TextMode="Password" Runat="server"></asp:textbox></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td align="right"><asp:Button Text="Login" runat="server" id="btnLogin" OnClick="btnLogin_Click" /></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td align="center"><asp:label id="lblWrongPassword" Runat="server"></asp:label></td>
				<td></td>
			</tr>
			<tr>
				<td height="10"></td>
			</tr>
		</table>
    </div>
</asp:Content>



