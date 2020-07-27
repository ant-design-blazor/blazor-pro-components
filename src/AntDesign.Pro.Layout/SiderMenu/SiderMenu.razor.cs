using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Pro.Layout
{
    interface ISiderMenu : IBaseMenu
    {
        OneOf<string, RenderFragment> Logo { get; }
        int SiderWidth { get; }
    }

    public partial class SiderMenu : ISiderMenu
    {
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public EventCallback<bool> HandleOpenChange { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public MenuDataItem[] MenuData { get; set; }
        [Parameter] public MenuMode Mode { get; set; }
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        [Parameter] public string[] OpenKeys { get; set; }
        [Parameter] public MenuTheme Theme { get; set; }
        [Parameter] public OneOf<string, RenderFragment> Logo { get; set; }
        [Parameter] public int SiderWidth { get; set; }
    }
}
