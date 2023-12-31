using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace AntDesign.ProLayout
{
    internal interface IBaseMenu : IPureSettings
    {
        bool Collapsed { get; }
        bool IsMobile { get; }
        MenuDataItem[] MenuData { get; }
        MenuMode Mode { get; }
        EventCallback<bool> OnCollapse { get; }
        string[] OpenKeys { get; }
        EventCallback<string[]> OpenKeysChanged { get; set; }
    }

    public partial class BaseMenu : IBaseMenu
    {
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public MenuDataItem[] MenuData { get; set; } = { };
        [Parameter] public MenuMode Mode { get; set; }
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        [Parameter] public string[] OpenKeys { get; set; } = [];
        [Parameter] public EventCallback<string[]> OpenKeysChanged { get; set; }

        [Parameter] public bool Accordion { get; set; }

        [Inject] public ILogger<BaseMenu> Logger { get; set; }

        protected override void OnInitialized()
        {
            Logger.LogInformation("BaseMenu initialized.");
        }
    }
}