using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AcmeUI.Components
{
    public class AcmeMenuBase<TItem> : ComponentBase
    {
        [Parameter]
        public IList<TItem> Data { get; set; }
    }
}
