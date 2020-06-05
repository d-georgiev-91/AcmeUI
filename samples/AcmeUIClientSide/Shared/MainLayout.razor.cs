using System.Collections.Generic;
using AcmeUIClientSide.Models;
using Microsoft.AspNetCore.Components;

namespace AcmeUIClientSide.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        public IList<MenuItem> MenuItems { get; set; }
    }
}
