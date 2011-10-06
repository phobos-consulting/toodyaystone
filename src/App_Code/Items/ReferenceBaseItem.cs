using N2.Details;

/// <summary>
/// This is an abstract class that we can derive from on in all 
/// situations when we want edit the item's title and name.
/// </summary>
[WithEditable("Name", typeof(N2.Web.UI.WebControls.NameEditor), "Text", 20, "Name")]
public abstract class ReferenceBaseItem : N2.ContentItem
{
    [DisplayableLiteral()]
    [EditableTextBox("Name", 10, Required = true)]
    public override string Name
    {
        get { return base.Name; }
        set { base.Name = value; }
    }

    public override string Title
    {
        get { return base.Name; }
        set { base.Name = value; }
    }

    public virtual string LargeIconUrl
    {
        get { return null; }
    }
}
