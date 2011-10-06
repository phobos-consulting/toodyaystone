using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

public partial class EnquiryTemplate : N2.Web.UI.Page<EnquiryItem>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SuccessfulLiteral.Text = CurrentItem.SuccessfulMessage;
        ErrorLiteral.Text = CurrentItem.ErrorMessage;
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        bool emailToEnquirerSuccessful = true;

        if (PreferredMethodList.SelectedValue == "Email")
        {
            emailToEnquirerSuccessful = SendEmailToEnquirer();
        }
        bool emailToContactSuccessful = SendEmailToWebsiteContact();

        EnquiryPanel.Visible = false;

        if (emailToEnquirerSuccessful
            && emailToContactSuccessful)
        {

            SuccessfulPanel.Visible = true;
        }
        else
        {
            ErrorPanel.Visible = true;
        }

    }

    private bool SendEmailToEnquirer()
    {
        try
        {
            MailMessage message = new MailMessage(MailSettings.SenderEmail, EmailTextBox.Text);

            message.Subject = CurrentItem.EmailSubject;
            message.Body = CurrentItem.EmailBody;
            message.IsBodyHtml = true;

            SendEmail(message);
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }

    private bool SendEmailToWebsiteContact()
    {
        try
        {

            MailMessage message = new MailMessage(MailSettings.SenderEmail, MailSettings.ContactEmail);

            message.Subject = "Website Enquiry";

            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.AppendLine(string.Format("Name : {0}", NameTextBox.Text));
            builder.AppendLine(string.Format("Email : {0}", EmailTextBox.Text));
            builder.AppendLine(string.Format("Phone : {0}", PhoneTextBox.Text));
            builder.AppendLine(string.Format("Address : {0}", AddressTextBox.Text));
            builder.AppendLine(string.Format("Enquiry Details : {0}", DetailsTextBox.Text));
            builder.AppendLine(string.Format("Preferred Method of Correspondence : {0}", PreferredMethodList.SelectedValue));
            builder.AppendLine(string.Format("Timestamp : {0}", DateTime.Now.ToString()));
            message.Body = builder.ToString();
            message.IsBodyHtml = false;

            SendEmail(message);
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }

    private void SendEmail(MailMessage message)
    {
        SmtpClient client = new SmtpClient(MailSettings.MailServer);
        if (MailSettings.RequiresCredentials)
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(MailSettings.Username, MailSettings.Password);
        }
        else
        {
            client.UseDefaultCredentials = true;
        }
        client.Send(message);
    }
}
