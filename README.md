# AcmeUI
A Blazor library for UI compoment(s)

## Usage

### Prerequisites
1. Add a reference to AcmeUI.
2. Register AcmeUI services at Program.cs 
```csharp
    using System.Threading.Tasks;
    using AcmeUI;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    
    namespace AcmeUIClientSide
    {
        public class Program
        {
            public static async Task Main(string[] args)
            {
                var builder = WebAssemblyHostBuilder.CreateDefault(args);
                builder.RootComponents.Add<App>("app");
    
                builder.Services.AddAcmeUI();
    
                await builder.Build().RunAsync();
            }
        }
    }
```
3. Add reference to _Imports.razor or relatively to your compoment.
```razor
@using AcmeUI.Components
```
4. Add reference to www/index.html
```html
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>AcmeUIClientSide</title>
    <base href="/" />
    <link href="_content/AcmeUI/acme-menu.css" rel="stylesheet" />
</head>

<body>
    <app></app>
    <script src="_framework/blazor.webassembly.js"></script>
</body>

</html>
```

### Components usage
#### AcmeMenu

1. Create hierarchical data source
```csharp
public class MenuItem
{
	public string Title { get; set; }
	
	public IList<MenuItem> MenuItems { get; set; }
}
```

```csharp
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
```
2. Reference the AcmeMenu in the desired compoment and bind to the properties

```blazor
<AcmeMenu TItem="MenuItem"
          Data="@MenuItems"
          TitlePropertyName="@nameof(MenuItem.Title)"
          SubmenuItemsPropertyName="@nameof(MenuItem.MenuItems)"
          Selected="@OnItemClick">
</AcmeMenu>
```