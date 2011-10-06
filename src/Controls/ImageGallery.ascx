<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageGallery.ascx.cs" Inherits="Controls_ImageGallery" %>
<asp:Panel ID="GalleryPanel" runat="server">
    <asp:Panel ID="GalleryTitlePanel" runat="server" Visible="False">
          <div class="gallery_title">
            <asp:Literal ID="GalleryTitleLiteral" runat="server"></asp:Literal>
          </div>
            <div class="gallery_teaser">
                <asp:Literal ID="GalleryTeaserLiteral" runat="server"></asp:Literal>
            </div>
    </asp:Panel>
    <div class="gallery">
        <asp:Table ID="GalleryTable" runat="server"></asp:Table>
    </div>
</asp:Panel>