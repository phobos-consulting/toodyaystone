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
/// Summary description for EditableDatePicker
/// </summary>
public class EditableOneToTenPicker : N2.Details.AbstractEditableAttribute 
{

    public EditableOneToTenPicker(string title, int sortOrder)
        : base(title, sortOrder)
    {
    }
    protected override Control AddEditor(Control container)
    {
        DropDownList ddl = new DropDownList();
        ddl.Width = Unit.Pixel(100);
        AddNumbers(ddl);

        container.Controls.Add(ddl);

        return ddl;
        
    }

    private void AddNumbers(DropDownList ddl)
    {
        for (int i = 1; i <= 10; ++i)
        {
            ListItem item = new ListItem();
            item.Value = i.ToString();
            item.Text = i.ToString();

            ddl.Items.Add(item);
        }
    }


    public override void UpdateEditor(N2.ContentItem item, Control control)
    {
        DropDownList ddl = (DropDownList)control;
        ddl.SelectedValue = item[this.Name].ToString();
       
    }

    public override bool UpdateItem(N2.ContentItem item,Control control)
    {
        try
        {
            DropDownList ddl = (DropDownList)control;
           
            item[this.Name] = ddl.SelectedValue;
            return true;
        }
        catch
        {
            return false;
        }

    }
    
	
}
