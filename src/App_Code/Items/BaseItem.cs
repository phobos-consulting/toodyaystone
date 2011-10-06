using N2.Details;

/// <summary>
/// This is an abstract class that we can derive from on in all 
/// situations when we want edit the item's title and name.
/// </summary>
[WithEditable("Name", typeof(N2.Web.UI.WebControls.NameEditor), "Text", 20, "Name")]
public abstract class BaseItem : N2.ContentItem
{
	[DisplayableLiteral()]
	[EditableTextBox("Title", 10,Required=true)]
	public override string Title
	{
		get { return base.Title; }
		set { base.Title = value; }
    }

    [N2.Details.EditableCheckBox("Show child image galleries", 45)]
    public virtual bool ShowImageGalleries
    {
        get
        {
            object oShowImageGalleries = GetDetail("ShowImageGalleries");
            if (oShowImageGalleries == null)
            {
                return false;
            }
            else return (bool)oShowImageGalleries;
        }
        set { SetDetail("ShowImageGalleries", value); }
    }

    [N2.Details.EditableCheckBox("Is Visible", 40)]
    public virtual bool IsVisible
    {
        get
        {
            object show = GetDetail("IsVisible");
            if (show == null)
            {
                return true;
            }
            else return (bool)show;
        }
        set { SetDetail("IsVisible", value); }
    }


    [N2.Details.EditableFreeTextArea("Text", 300)]
    public virtual string Text
    {
        get { return (string)GetDetail("Text"); }
        set { SetDetail("Text", value); }
    }

    



}
