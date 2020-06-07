using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AcmeUI.Components
{
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
    }
}
