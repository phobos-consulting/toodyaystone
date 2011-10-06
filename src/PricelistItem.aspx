<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/ReferenceData.master" CodeFile="PricelistItem.aspx.cs" Inherits="PricelistItem" %>


<asp:Content ID="Fields" runat="server" ContentPlaceHolderID="cphFields">
    <div class="reference_field">
         <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Price:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Literal id="litPrice" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>

    <div class="reference_field">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Descrtiption:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Literal id="litDescription" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>