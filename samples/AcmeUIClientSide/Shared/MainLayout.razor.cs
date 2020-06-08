using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeUI.Components;
using AcmeUIClientSide.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AcmeUIClientSide.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        public IList<MenuItem> MenuItems { get; set; }

        protected override Task OnInitializedAsync()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = "Item 1",
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = "Item 1.1"
                        },
                        new MenuItem
                        {
                            Title = "Item 1.2",
                            MenuItems = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Title = "Item 1.2.1"
                                },
                                new MenuItem
                                {
                                    Title = "Item 1.2.2"
                                }
                            }
                        }
                    }
                },
                new MenuItem
                {
                    Title = "Item 2",
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = "Item 2.1",
                            MenuItems = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Title = "Item 2.1.1"
                                },
                                new MenuItem
                                {
                                    Title = "Item 2.1.2"
                                },
                                new MenuItem
                                {
                                    Title = "Item 2.1.3"
                                }
                            }
                        },
                        new MenuItem
                        {
                            Title = "Item 2.2",
                            MenuItems = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Title = "Item 2.2.1"
                                },
                                new MenuItem
                                {
                                    Title = "Item 2.2.2"
                                }
                            }
                        },
                        new MenuItem
                        {
                            Title = "Item 2.3",
                            MenuItems = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Title = "Item 2.3.1",
                                    MenuItems = new List<MenuItem>
                                    {
                                        new MenuItem
                                        {
                                            Title = "Item 2.3.1.1"
                                        },
                                        new MenuItem
                                        {
                                            Title = "Item 2.3.1.2"
                                        }
                                    }
                                },
                                new MenuItem
                                {
                                    Title = "Item 2.3.2"
                                }
                            }
                        }
                    }
                },
                new MenuItem
                {
                    Title = "Item 3"
                }
            };

            return base.OnInitializedAsync();
        }

        public async void OnItemClick(MenuItemEventArgs<MenuItem> eventArgs)
        {
            await JsRuntime.InvokeVoidAsync("alert", eventArgs.MenuItem.Title);
        }
    }
}
