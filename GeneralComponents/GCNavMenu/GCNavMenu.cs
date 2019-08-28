using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;


//
//  3028-20-28  ADR
//              Implements two different components. One is a navigation bar, and the other
//              is for the navigation links inside of it.
//
//  2018-19-27  MS
//              Added functionality to allow hiding/showing of menu items
//

namespace GeneralComponents.GCNavMenu
{
    public class GCNavMenu : ComponentBase
    {
        //
        //  We get all of this stuff as parameters from the cshtml. BrandText is optional
        //  and is displayed to the left of the menu. IsImage means that BrandText is actually
        //  an image path, else it is text.
        //
        [Parameter] public bool IsImage { get; set; } = false;
        [Parameter] public string BrandText { get; set; } = "";
        [Parameter] public List<GCNavMenuItemInfo> MenuItems { get; set; }
        [Parameter] public EventCallback<GCNavMenuSelection> OnSelect { get; set; }
        [Parameter] public string ActiveId { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            // If no initially active element provided , then select the 0th one if we have one
            if ((ActiveId == "") && (MenuItems.Count != 0))
                ActiveId = MenuItems[0].pItemId;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            int rendSeq = 1;

            builder.OpenElement(rendSeq++, "div");
            builder.AddAttribute(rendSeq++, "class", "gc-navmenu");

            // So the brand text div first if we have any
            if (BrandText.Length != 0)
            {
                if (IsImage)
                {
                    // It's an image
                    builder.OpenElement(rendSeq++, "div");
                    builder.AddAttribute(rendSeq++, "style", "margin : 8px;");
                    builder.OpenElement(rendSeq++, "img");
                    builder.AddAttribute(rendSeq++, "src", BrandText);
                    builder.CloseElement();
                    builder.CloseElement();
                }
                else
                {
                    // It's just text
                    builder.OpenElement(rendSeq++, "div");
                    builder.AddAttribute(rendSeq++, "class", "gc-navbrand");
                    builder.AddContent(rendSeq, BrandText);
                    builder.CloseElement();
                }
            }

            //
            //  Iterate our menu items and spit out content for them. Pint each one at our
            //  internal click handler.
            //
            foreach (GCNavMenuItemInfo navMenuItemInfo in MenuItems)
            {
                if (navMenuItemInfo.pItemIsVisible)
                {
                    builder.OpenComponent(rendSeq++, typeof(OptiNavMenuItem));
                    builder.AddAttribute(rendSeq++, "ItemId", navMenuItemInfo.pItemId);
                    builder.AddAttribute(rendSeq++, "ItemText", navMenuItemInfo.pItemText);
                    builder.AddAttribute
                    (
                        rendSeq++, "OnSelect", EventCallback.Factory.Create<GCNavMenuSelection>(this, e => OnClick(e))
                    );

                    // For the active one set the is active flag
                    if (navMenuItemInfo.pItemId == ActiveId)
                        builder.AddAttribute(rendSeq++, "IsActive", true);
                    else
                        builder.AddAttribute(rendSeq++, "IsActive", false);

                    builder.CloseComponent();
                }
            }

            builder.CloseElement();
        }

        public void DisableItem(string itemId)
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (MenuItems[i].pItemId == itemId)
                {
                    MenuItems[i].pItemIsVisible = false;
                }
            }
        }

        public void EnableItem(string itemId)
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (MenuItems[i].pItemId == itemId)
                {
                    MenuItems[i].pItemIsVisible = true;
                }
            }
        }

        public void SetActiveItem(string itemId)
        {
            ActiveId = itemId;
        }

        public void Refresh()
        {
            StateHasChanged();
        }


        // We just pass along our configured item name, so we don't need any parameters
        private bool OnClick(GCNavMenuSelection ev)
        {
            // Remember the active one's id and re-render
            ActiveId = ev.SelectedItemId;
            StateHasChanged();

            // And pass it on our consumers
            OnSelect.InvokeAsync(ev);
            return false;
        }
    }

    //  We need a derivative of the UI event change parameters class. We pass the
    //  assigned menu item name.
    //
    public class GCNavMenuSelection : UIEventArgs
    {
        public string SelectedItemId { get; set; }
    };


    public class GCNavMenuItemInfo
    {
        public GCNavMenuItemInfo(string id, string text, bool isVisible)
        {
            pItemId = id;
            pItemText = text;
            pItemIsVisible = isVisible;
        }

        public string pItemId { get; set; }
        public string pItemText { get; set; }
        public bool pItemIsVisible { get; set; }
    };


    public class OptiNavMenuItem : ComponentBase
    {
        // We get all of this stuff as parameters from our parent menu class when he generates us.
        [Parameter] public bool IsActive { get; set; } = false;
        [Parameter] public string ItemId { get; set; }
        [Parameter] public string ItemText { get; set; }

        // An action we invoke when our selection changes
        [Parameter] public EventCallback<GCNavMenuSelection> OnSelect { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            int rendSeq = 1;

            builder.OpenElement(rendSeq++, "div");

            if (IsActive)
                builder.AddAttribute(rendSeq++, "class", "gc-navlink-active");
            else
                builder.AddAttribute(rendSeq++, "class", "gc-navlink");

            builder.AddAttribute
            (
                rendSeq++, "onclick", EventCallback.Factory.Create < UIMouseEventArgs >(this, e => OnClick(e))
            );
            builder.AddContent(rendSeq++, ItemText);
            builder.CloseElement();
        }


        // We just pass along our configured item name, so we don't need any parameters
        private bool OnClick(UIMouseEventArgs e)
        {
            OnSelect.InvokeAsync(new GCNavMenuSelection { SelectedItemId = ItemId });
            return false;
        }
    }
}
