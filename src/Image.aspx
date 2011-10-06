<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/ReferenceData.master" CodeFile="Image.aspx.cs" Inherits="Image" %>

<asp:Content ID="Fields" runat="server" ContentPlaceHolderID="cphFields">
    <div class="reference_field">
         <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Caption:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Literal id="litCaption" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>

     <div class="reference_field">
         <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="reference_fieldname">
                    Image:
                </td>
                <td class="reference_fieldvalue">
                    <asp:Image ID="Image1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    

</asp:Content>
