using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AcmeUI.Components
{
    /// <summary>
    /// Defines menu component with items of type <see cref="IList{TItem}"/>
    /// </summary>
    /// <typeparam name="TItem">The items type</typeparam>
    public class AcmeMenuBase<TItem> : ComponentBase
    {
        /// <summary>
        /// Gets or sets the list of menu items of <see cref="TItem"/>
        /// </summary>
        [Parameter]
        public IList<TItem> Data { get; set; }

        /// <summary>
        /// Gets or sets the name property specifying menu item title
        /// </summary>
        [Parameter]
        public string TitleProperty { get; set; }

        /// <summary>
        /// Gets or sets the name property specifying children menu items
        /// </summary>
        [Parameter]
        public string SubmenuItemsProperty { get; set; }

        /// <summary>
        /// Gets or sets the selected event callback
        /// </summary>
        [Parameter]
        public EventCallback<MenuItemEventArgs<TItem>> Selected { get; set; }

        protected void TriggerMenuItemSelected(TItem menuItem)
        {
            Selected.InvokeAsync(new MenuItemEventArgs<TItem> { MenuItem = menuItem });
        }

        protected string GetMenuItemTitle(TItem menItem)
        {
            var titleProperty = typeof(TItem).GetProperty(TitleProperty);

            if (titleProperty == null)
            {
                throw new ArgumentException($"No such property {TitleProperty}");
            }

            return titleProperty.GetValue(menItem).ToString();
        }

        protected IList<TItem> GetChildren(TItem menuItem)
        {
            var submenuItemsProperty = typeof(TItem).GetProperty(SubmenuItemsProperty);

            if (submenuItemsProperty == null)
            {
                throw new ArgumentException($"No such property {SubmenuItemsProperty}");
            }

            return (IList<TItem>)submenuItemsProperty.GetValue(menuItem) ?? new List<TItem>();
        }
    }
}
