using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using N2;

public partial class Controls_Navigation : N2.Web.UI.UserControl<BaseItem>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindNavigation();
    }

    private void BindNavigation()
    {
        int level = 0;
        ContentItem rootItem = N2.Find.RootItem;

        AddNavigationItem(rootItem, level);

    }

    private List<int> _currentItemList;

    private List<int> CurrentItemList
    {
        get
        {
            if (_currentItemList == null)
            {
                _currentItemList = BuildCurrentItemList();
            }
            return _currentItemList;
        }
    }

    private List<int> BuildCurrentItemList()
    {
        List<int> currentItemList = new List<int>();

        currentItemList.Add(CurrentItem.ID);

        AddItemTree(CurrentItem.Parent, currentItemList);

        return currentItemList;
    }

    private void AddItemTree(ContentItem item, List<int> itemList)
    {
        if(item != null 
            && item.GetType() != typeof(HomeItem))
        {
            itemList.Add(item.ID);

            if (item.Parent != null)
            {
                AddItemTree(item.Parent, itemList);
            }
        }
    }

    
    
    #region GetChildren

    private static N2.Collections.ItemList GetChildren(ContentItem parentItem)
    {
        N2.Collections.ItemFilter trashFilter = new N2.Collections.TypeFilter(true, typeof(N2.Edit.Trash.TrashContainerItem));
        N2.Collections.ItemFilter folderFilter = new N2.Collections.TypeFilter(true, typeof(FolderItem));
        N2.Collections.ItemFilter imageFilter = new N2.Collections.TypeFilter(true, typeof(ImageItem));
        N2.Collections.ItemFilter wizardFilter = new N2.Collections.TypeFilter(true, typeof(N2.Edit.Wizard.Items.Wonderland));

        return parentItem.GetChildren(trashFilter, folderFilter, imageFilter, wizardFilter);
    }

    #endregion


    #region AddNode

    private void AddNavigationItem(ContentItem item,  int level)
    {
        
        bool isCurrentNode = (item.ID == CurrentItem.ID);

        AddNavigationLink(item, isCurrentNode, level);

        
        if (CurrentItemList.Contains(item.ID)
            || level == 0)
        {
            ++level;
            foreach (N2.ContentItem childItem in GetChildren(item))
            {
                bool isVisible = childItem.GetDetail<bool>("IsVisible", true);

                if ((childItem.GetType() != typeof(ImageGalleryItem) 
                        && isVisible)
                         || (childItem.GetType() == typeof(ImageGalleryItem)
                                 && childItem.GetDetail<bool>("ShowOnNavigation", true)
                                    && isVisible))
                {
                   
                    AddNavigationItem(childItem, level);
                }
            }
        }

    }

    #endregion

    #region AddNavigationLink

    private void AddNavigationLink(ContentItem contentItem, bool isCurrentNode, int level)
    {
        TableRow tableRow = new TableRow();
        TableCell tableCell = new TableCell();
        tableRow.Cells.Add(tableCell);
        NavigationTable.Rows.Add(tableRow);

        string cssClassPrefix = GetCssClassPrefix(level);

        tableCell.CssClass = string.Format("{0}{1}", cssClassPrefix, "_l");

        string linkCssClass = cssClassPrefix;
        if(isCurrentNode)
        {
            linkCssClass = string.Format("{0}{1}", cssClassPrefix, "_sel");
        }

        string linkFormat = "<a href=\"{0}\" class=\"{1}\">{2}</a>";
        tableCell.Text = string.Format(linkFormat, contentItem.Url, linkCssClass, contentItem.Title);
 
    }

    private string GetCssClassPrefix(int level)
    {

        if (level <= 1)
        {
            return "nav_r";
        }
        else if (level <= 2)
        {
            return "nav_c";
        }
        else if (level <= 3)
        {
            return "nav_gc";
        }
        else
        {
            return "nav_ggc";
        }
    }
    #endregion
}
