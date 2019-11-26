using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace RDVSIX
{
    public static class ProjectHelper
    {
        public static SelectedItem GetSelectedItem(this IVsHierarchy hierarchy, uint ItemID)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (hierarchy == null)
                throw new ArgumentNullException("hierarchy");
            ErrorHandler.ThrowOnFailure(hierarchy.GetProperty(
                ItemID, (int)__VSHPROPID.VSHPROPID_ExtObject, out var prjItemObject));

            SelectedItem selectedItem = prjItemObject as SelectedItem;
            return selectedItem;
        }




    }
}
