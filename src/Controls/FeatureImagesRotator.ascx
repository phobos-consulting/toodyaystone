<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeatureImagesRotator.ascx.cs" Inherits="Controls_FeatureImagesRotator" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

 <rad:RadRotator TransitionEffect="Fade" FrameDuration="10000" width="270px" height="280px" runat="server" id="FeatureImagesRotator">
    <ItemTemplate>
        <img src="<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>" alt="<%# DataBinder.Eval(Container.DataItem, "Caption") %>" style="border:0px;"/>
    </ItemTemplate>
</rad:RadRotator>
