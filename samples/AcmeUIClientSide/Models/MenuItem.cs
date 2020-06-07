using System.Collections.Generic;

namespace AcmeUIClientSide.Models
{
    public class MenuItem
    {
        public string Title { get; set; }

        public IList<MenuItem> MenuItems { get; set; }
    }
}