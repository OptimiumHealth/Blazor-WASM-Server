using GeneralComponents.GCNavMenu;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace GeneralComponents.Shared
{
    public class NavMenuBase: ComponentBase
    {
        [Inject] NavigationManager NavigationHelper { get; set; }

        protected List<GCNavMenuItemInfo> ItemList = new List<GCNavMenuItemInfo>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            // Set up our menu item list
            if (ItemList.Count == 0)
            {
                ItemList.Add(new GCNavMenuItemInfo("patview", "PAT", true));
                ItemList.Add(new GCNavMenuItemInfo("ormanagerview", "OR Manager", true));
                ItemList.Add(new GCNavMenuItemInfo("newprocessview", "New Process", true));
                ItemList.Add(new GCNavMenuItemInfo("reportview", "Reports", true));
                ItemList.Add(new GCNavMenuItemInfo("settingsView", "Settings", true));
                ItemList.Add(new GCNavMenuItemInfo("aboutview", "About", true));
            }
        }

        bool IsLoggedIn { get; set; } = false;

        public void OnSelect(GCNavMenuSelection ev)
        {
            // Invoke a new view based on selection
            NavigationHelper.NavigateTo("/" + ev.SelectedItemId);
        }

    }
}
