<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageAlbumPreview.ascx.cs" Inherits="Controls_ImageAlbumPreview" %>

<div class="album">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:HyperLink ID="AlbumImageLink" CssClass="album_link" runat="server" BorderStyle="None"></asp:HyperLink>
                    </td>
                    <td class="album_content">
                         <h2>
                            <asp:HyperLink ID="AlbumLink" runat="server" CssClass="album_link"></asp:HyperLink>
                         </h2>
                         <div class="album_teaser">
                            <asp:Literal ID="TeaserLiteral" runat="server"></asp:Literal>
                            <asp:HyperLink ID="MoreLink" runat="server" CssClass="more_link" Text="...view album"></asp:HyperLink>
                         </div>
                    </td>
                </tr>
            </table>
     </div>
