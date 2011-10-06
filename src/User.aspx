<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/ReferenceData.master" CodeFile="User.aspx.cs" Inherits="User" %>

<asp:Content ID="Fields" runat="server" ContentPlaceHolderID="cphFields">
    <div class="reference_field">
         <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Username:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Literal id="litUsername" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>

    <div class="reference_field">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Password:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Literal id="litPassword" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    
    <div class="reference_field">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Header:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Literal id="litHeader" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    
     <div class="reference_field">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Text:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Literal id="litText" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
