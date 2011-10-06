<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Products.ascx.cs" Inherits="Controls_Products" %>

<asp:Repeater ID="ProductsRepeater" runat="server">
        <ItemTemplate>
        
        <div class="product">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="product_content">
                         <h2>
                            <a class="product_link" href="<%# DataBinder.Eval(Container.DataItem, "Url") %>">
                                    <%# DataBinder.Eval(Container.DataItem, "Title") %>
                             </a>
                         </h2>
                         <div class="product_teaser">
                            <%# StripHtml(DataBinder.Eval(Container.DataItem, "Teaser")) %>
                             <a class="more_link" href="<%# DataBinder.Eval(Container.DataItem, "Url") %>">
                               ...more
                            </a>
                         </div>
                    </td>
                    <td>
                         <a href="<%# DataBinder.Eval(Container.DataItem, "Url") %>">
                            <img src="<%# DataBinder.Eval(Container.DataItem, "ProductImage") %>" 
                                alt="<%# DataBinder.Eval(Container.DataItem, "Title") %>" 
                                class="product_image"
                                border="0"/>
                        </a>
                    </td>
                </tr>
            </table>
           
          
        </div>
      </ItemTemplate>
      <FooterTemplate>
        <div id="product_footer"></div>
      </FooterTemplate>
</asp:Repeater>
