<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/Content.master" CodeFile="EnquiryTemplate.aspx.cs" Inherits="EnquiryTemplate" %>

<asp:Content ContentPlaceHolderID="cphAdditionalContent" ID="contentSupportingContent" runat="server">
    <asp:Panel ID="EnquiryPanel" runat="server" Visible="True">
        <h2>Make an enquiry</h2>
        <div class="field_label">
            Name
        </div>
        <div class="field">
            <asp:TextBox ID="NameTextBox" runat="server" Width="200"></asp:TextBox>*
              <asp:RequiredFieldValidator ID="NameRequiredField"
             runat="server" ControlToValidate="NameTextBox">Required field
            </asp:RequiredFieldValidator>
        </div>
        <div class="field_label">
            Email
        </div>
        <div class="field">
            <asp:TextBox ID="EmailTextBox" runat="server" Width="250"></asp:TextBox>*
            <asp:RequiredFieldValidator ID="EmailRequiredField"
             runat="server" ControlToValidate="EmailTextBox">Required field
            </asp:RequiredFieldValidator>
        </div>
       <div class="field_label">
            Phone
        </div>
        <div class="field">
            <asp:TextBox ID="PhoneTextBox" runat="server" Width="150"></asp:TextBox>
        </div>
        <div class="field_label">
            Address
        </div>
        <div class="field">
            <asp:TextBox ID="AddressTextBox" runat="server" Width="300"></asp:TextBox>
        </div>
        <div class="field_label">
            Enquiry Details
        </div>
        <div class="field">
            <asp:TextBox ID="DetailsTextBox" TextMode="MultiLine" Height="50px" runat="server" Width="400"></asp:TextBox>
        </div>
         <div class="field_label">
            Preferred method of correspondence
        </div>
        <div class="field">
            <asp:RadioButtonList ID="PreferredMethodList" RepeatDirection="Horizontal"  runat="server">
                <asp:ListItem Selected="True" Text="Email" />
                 <asp:ListItem Text="Phone" />
                 <asp:ListItem Text="Post" />
            </asp:RadioButtonList>
        </div>
        
        * Mandatory field
        
        <div style="padding-top: 20px; text-align: right; width:420px">
            <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="SubmitButton_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="ErrorPanel" runat="server" Visible="False">
        <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal>
    </asp:Panel>
     <asp:Panel ID="SuccessfulPanel" runat="server" Visible="False">
        <b><asp:Literal ID="SuccessfulLiteral" runat="server"></asp:Literal></b>
    </asp:Panel>
</asp:Content>