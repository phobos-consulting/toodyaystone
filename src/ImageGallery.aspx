<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/Content.master" CodeFile="ImageGallery.aspx.cs" Inherits="ImageGallery" %>
<%@ Register TagPrefix="pho" TagName="ImageGallery" Src="~/Controls/ImageGallery.ascx" %>
<%@ Register TagPrefix="pho" TagName="ImageAlbum" Src="~/Controls/ImageAlbum.ascx" %>

<asp:Content ContentPlaceHolderID="cphAdditionalContent" id="AdditionalContent" runat="server">
    <div style="height: 20px;"></div>
    <pho:ImageGallery id="ImageGallery1" runat="server" ShowTitle="False"></pho:ImageGallery>
    
     <pho:ImageAlbum id="ImageAlbum1" runat="server"></pho:ImageAlbum>
</asp:Content>