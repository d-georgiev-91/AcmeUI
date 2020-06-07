using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeUIClientSide.Models;
using Microsoft.AspNetCore.Components;

namespace AcmeUIClientSide.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        public IList<MenuItem> MenuItems { get; set; }

        protected override Task OnInitializedAsync()
        {
            MenuItems = new List<MenuItem>
            {
                // sample URLs for SPA navigation
                new MenuItem
                {
                    Title = "Company",
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = "Overview",
                        },
                        new MenuItem
                        {
                            Title = "Events",
                        },
                        new MenuItem
                        {
                            Title = "Careers",
                        }
                    }
                },
                // sample URLs for external navigation
                new MenuItem
                {
                    Title = "Services",
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = "Consulting"
                        },
                        new MenuItem
                        {
                            Title = "Education"
                        }
                    }
                },
                new MenuItem
                {
                    Title = "Contact"
                }
            };

            return base.OnInitializedAsync();
        }
    }
}
