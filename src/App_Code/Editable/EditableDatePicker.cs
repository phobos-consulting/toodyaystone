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
public class EditableDatePicker : N2.Details.AbstractEditableAttribute 
{

    public EditableDatePicker(string title, int sortOrder) : base(title, sortOrder)
    {
    }
    
    protected override Control AddEditor(Control container)
    {
        Calendar datePicker = new Calendar();

        container.Controls.Add(datePicker);

        return datePicker;

    }

    public override void UpdateEditor(N2.ContentItem item,Control control)
    {
        Calendar datePicker = (Calendar)control;
        datePicker.SelectedDate = (DateTime)item[this.Name];
        datePicker.TodaysDate = (DateTime)item[this.Name];
    }

    public override bool UpdateItem(N2.ContentItem item,Control control)
    {
        try
        {
            Calendar datePicker = (Calendar)control;
            DateTime selectedDate = datePicker.SelectedDate;
            item[this.Name] = selectedDate;
            return true;
        }
        catch
        {
            return false;
        }

    }
    
	
}
