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

        protected void TriggerMenuItemSelected(TItem menuItem)
        {
            Selected.InvokeAsync(new MenuItemEventArgs<TItem> { MenuItem = menuItem });
        }

        protected string GetMenuItemTitle(TItem menItem) =>
            ReflectionHelper.GetPropertyValue(menItem, TitlePropertyName).ToString();

        protected IList<TItem> GetChildren(TItem menuItem) =>
            (IList<TItem>)ReflectionHelper.GetPropertyValue(menuItem, SubmenuItemsPropertyName) ?? new List<TItem>();
    }
}
