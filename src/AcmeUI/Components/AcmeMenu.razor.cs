using System.Collections.Generic;
using AcmeUI.Helpers;
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
        /// Reference to Reflection helper
        /// </summary>
        [Inject]
        protected ReflectionHelper ReflectionHelper { get; set; }

        /// <summary>
        /// Gets or sets the list of menu items of <see cref="TItem"/>
        /// </summary>
        [Parameter]
        public IList<TItem> Data { get; set; }

        /// <summary>
        /// Gets or sets the name property specifying menu item title
        /// </summary>
        [Parameter]
        public string TitlePropertyName { get; set; }

        /// <summary>
        /// Gets or sets the name property specifying children menu items
        /// </summary>
        [Parameter]
        public string SubmenuItemsPropertyName { get; set; }

        /// <summary>
        /// Gets or sets the selected event callback
        /// </summary>
        [Parameter]
        public EventCallback<MenuItemEventArgs<TItem>> Selected { get; set; }


        /// <summary>
        /// Triggers menu item selected event
        /// </summary>
        /// <param name="menuItem">The menu item that is selected</param>
        protected void TriggerMenuItemSelected(TItem menuItem)
        {
            Selected.InvokeAsync(new MenuItemEventArgs<TItem> { MenuItem = menuItem });
        }

        /// <summary>
        /// Retrieves the menu item title
        /// </summary>
        /// <param name="menuItem">The menu item</param>
        /// <returns>The title of the menu item</returns>
        protected string GetMenuItemTitle(TItem menuItem) =>
            ReflectionHelper.GetPropertyValue(menuItem, TitlePropertyName).ToString();

        /// <summary>
        /// Retrieves the children of the menu items
        /// </summary>
        /// <param name="menuItem">The menu item</param>
        /// <returns>List of menu items if such exists, otherwise an empty list ist returned</returns>
        protected IList<TItem> GetChildren(TItem menuItem) =>
            (IList<TItem>)ReflectionHelper.GetPropertyValue(menuItem, SubmenuItemsPropertyName) ?? new List<TItem>();
    }
}
