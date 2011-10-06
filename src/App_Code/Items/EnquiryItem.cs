using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// </summary>
[N2.Definition("Enquiry page", "EnquiryItem")]
public class EnquiryItem : BaseItem
{

    [N2.Details.EditableTextBox("Email Subject", 110)]
    public virtual string EmailSubject
    {
        get { return (string)GetDetail("EmailSubject") ?? string.Empty; }
        set { SetDetail("EmailSubject", value); }
    }

    [N2.Details.EditableTextBox("Email Body", 120, TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine, Rows = 4)]
    public virtual string EmailBody
    {
        get { return (string)GetDetail("EmailBody"); }
        set { SetDetail("EmailBody", value); }
    }



    [N2.Details.EditableTextBox("Successful message", 130, TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine, Rows = 4)]
    public virtual string SuccessfulMessage
    {
        get { return (string)GetDetail("SuccessfulMessage"); }
        set { SetDetail("SuccessfulMessage", value); }
    }

    [N2.Details.EditableFreeTextArea("Error message", 140)]
    public virtual string ErrorMessage
    {
        get { return (string)GetDetail("ErrorMessage"); }
        set { SetDetail("ErrorMessage", value); }
    }

    public override string TemplateUrl
    {
        get { return "/EnquiryTemplate.aspx"; }
    }

    public override string IconUrl
    {
        get
        {
            return "/Upload/Icons/enquiry.gif";
        }
    }


  
}
