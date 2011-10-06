using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using N2;



/// <summary>
/// Summary description for NavigationHelper
/// </summary>
public class NavigationHelper
{
    
    //public static RadTreeView PopulateTreeView(RadTreeView treeView, ContentItem rootItem, ContentItem currentItem)
    //{
    //    int level = 0;
        
    //    RadTreeNode rootNode = new RadTreeNode();
    //    SetNode(rootNode, rootItem, rootItem.ID == currentItem.ID, level, true);
    //    treeView.Nodes.Add(rootNode);

    //    foreach (N2.ContentItem childItem in GetChildren(rootItem))
    //    {
    //        if (childItem.GetType() != typeof(ImageGalleryItem)
    //            || (childItem.GetType() == typeof(ImageGalleryItem)
    //                    && childItem.GetDetail<bool>("ShowOnNavigation", true)))
    //        {
    //            RadTreeNode childNode = new RadTreeNode();

    //            bool isCurrentNode = AddNode(childNode, childItem, currentItem, level);

    //            treeView.Nodes.Add(childNode);
    //        }

    //    }

    //    treeView.ShowLineImages = false;
    //    treeView.SkinsPath = "/Skins";
    //    treeView.Skin = "NavTreeView";
    //    return treeView;
    //}

    #region GetChildren

    private static N2.Collections.ItemList GetChildren(ContentItem parentItem)
    {
        N2.Collections.ItemFilter trashFilter = new N2.Collections.TypeFilter(true, typeof(N2.Edit.Trash.TrashContainerItem));
        N2.Collections.ItemFilter folderFilter = new N2.Collections.TypeFilter(true, typeof(FolderItem));
        N2.Collections.ItemFilter imageFilter = new N2.Collections.TypeFilter(true, typeof(ImageItem));
        
        return parentItem.GetChildren(trashFilter, folderFilter, imageFilter);
    }

    #endregion

    #region AddNode

    private static bool AddNode(RadTreeNode parentNode, ContentItem parentItem, ContentItem currentItem, int level)
    {
        ++level;
        bool descendantIsCurrentNode = false;
        bool isCurrentNode = (parentItem.ID == currentItem.ID);
        
        foreach (N2.ContentItem childItem in GetChildren(parentItem))
        {
            if (childItem.GetType() != typeof(ImageGalleryItem)
                 || (childItem.GetType() == typeof(ImageGalleryItem)
                         && childItem.GetDetail<bool>("ShowOnNavigation", true)))
            {
                RadTreeNode childNode = new RadTreeNode();

                bool b = AddNode(childNode, childItem, currentItem, level);

                descendantIsCurrentNode = descendantIsCurrentNode || b;

                parentNode.Nodes.Add(childNode);
            }
        }

        SetNode(parentNode, parentItem, isCurrentNode, level, false, descendantIsCurrentNode);

        return isCurrentNode || descendantIsCurrentNode;
    }

    #endregion

    #region SetNode
    private static void SetNode(RadTreeNode treeNode, ContentItem contentItem, bool isCurrentNode, int level, bool isRootNode)
    {

        SetNode(treeNode, contentItem, isCurrentNode, level, isRootNode, false);
    }

    private static void SetNode(RadTreeNode treeNode, ContentItem contentItem, bool isCurrentNode, int level, bool isRootNode, bool descendantIsCurrentNode)
    {
         string result = string.Empty;
         string divFormat = "<div class=\"{0}\"><div style=\"white-space:normal\">{1}</div></div>"; 
        // set layout
        if (level <= 1)
        {
            result += string.Format(divFormat, "nav_r_l", contentItem.Title);
        }
        else if (level <= 2)
        {
            result += string.Format(divFormat, "nav_c_l", contentItem.Title);
        }
        else if (level <= 3)
        {
            result += string.Format(divFormat, "nav_gc_l", contentItem.Title);
        }
        else
        {
            result += string.Format(divFormat, "nav_ggc_l", contentItem.Title);
        }
       
        treeNode.Text = result;
        treeNode.NavigateUrl = contentItem.Url;
      
        SetStyle(treeNode, contentItem, isCurrentNode, descendantIsCurrentNode, level);
    }

    #endregion

    #region SetStyle
   
    private static void SetStyle(RadTreeNode treeNode, ContentItem contentItem, bool isCurrentNode, bool descendantIsCurrentNode, int level)
    {
        if (isCurrentNode || descendantIsCurrentNode)
        {
            if (level <= 1)
            {
                treeNode.CssClass = "nav_r_sel";
                treeNode.HoveredCssClass = "nav_r_sel_ho";
                treeNode.SelectedCssClass = "nav_r_sel_ho";
            }
            else if (level <= 2)
            {
                treeNode.CssClass = "nav_c_sel";
                treeNode.HoveredCssClass = "nav_c_sel_ho";
                treeNode.SelectedCssClass = "nav_c_sel_ho";
            }
            else if (level <= 3)
            {
                treeNode.CssClass = "nav_gc_sel";
                treeNode.HoveredCssClass = "nav_gc_sel_ho";
                treeNode.SelectedCssClass = "nav_gc_sel_ho";
            }
            else
            {
                treeNode.CssClass = "nav_ggc_sel";
                treeNode.HoveredCssClass = "nav_ggc_sel_ho";
                treeNode.SelectedCssClass = "nav_ggc_sel_ho";
            }
            treeNode.Expanded = true;

        }
        else
        {
            if (level <= 1)
            {
                treeNode.CssClass = "nav_r";
                treeNode.HoveredCssClass = "nav_r_ho";
                treeNode.SelectedCssClass = "nav_r_ho";
            }
            else if (level <= 2)
            {
                treeNode.CssClass = "nav_c";
                treeNode.HoveredCssClass = "nav_c_ho";
                treeNode.SelectedCssClass = "nav_c_ho";
            }
            else if (level <= 3)
            {
                treeNode.CssClass = "nav_gc";
                treeNode.HoveredCssClass = "nav_gc_ho";
                treeNode.SelectedCssClass = "nav_gc_ho";
            }
            else
            {
                treeNode.CssClass = "nav_ggc";
                treeNode.HoveredCssClass = "nav_ggc_ho";
                treeNode.SelectedCssClass = "nav_ggc_ho";
            }
        }

    }
    #endregion

}
