<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/NonCMSContent.master" CodeFile="Default.aspx.cs" Inherits="Portal_Default" %>
<asp:Content ContentPlaceHolderID="cphNavigation" runat="server" ID="Navigation">
    <div class="nav_r_l">
        <a href="#" class="nav_r">Portal</a>
    </div>
</asp:Content>

<asp:Content ID="PricelistContent" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Literal ID="litHeader" runat="server">
        </asp:Literal>
    </h1>

    <div id="content_text">
        <asp:Literal ID="litText" runat="server"></asp:Literal>
    </div>
</asp:Content>