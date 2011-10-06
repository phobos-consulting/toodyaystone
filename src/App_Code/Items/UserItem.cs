using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using N2;

/// <summary>
/// This is my custom content data container class. Since this class derives 
/// from <see cref="N2.ContentItem"/> N2 will pick up this class and make it 
/// available when we create pages in edit mode. 
/// 
/// Another thing to notice is that in addition to Text defined to be editable 
/// in this class it's Title and Name are also editable. This is because of the 
/// abstract base class <see cref="MyItemBase"/> it derives from.
/// </summary>
[N2.Definition("User", "UserItem")]

public class UserItem : ReferenceBaseItem
{
    [N2.Details.EditableTextBox("Username", 20)]
    public virtual string Username
    {
        get { return (string)GetDetail("Username") ?? string.Empty; }
        set { SetDetail("Username", value); }
    }

    [N2.Details.EditableTextBox("Password", 30)]
    public virtual string Password
    {
        get { return (string)GetDetail("Password") ?? string.Empty; }
        set { SetDetail("Password", value); }
    }

    [N2.Details.EditableTextBox("Header", 40, Required = true)]
    public virtual string Header
    {
        get { return (string)GetDetail("Header") ?? string.Empty; }
        set { SetDetail("Header", value); }
    }


    [N2.Details.EditableFreeTextArea("Text", 50)]
    public virtual string Text
    {
        get { return (string)GetDetail("Text"); }
        set { SetDetail("Text", value); }
    }

    public override string TemplateUrl
    {
        get { return "/User.aspx"; }
    }

    public override string IconUrl
    {
        get { return "/Upload/Icons/user.gif"; }
    }

    public override string LargeIconUrl
    {
        get { return "/Upload/Icons/user_large.gif"; }
    }
}
