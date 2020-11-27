using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OneOf;

namespace AntDesign.Pro.Layout
{
    internal interface ITopNavHeader : ISiderMenu
    {
    }

    public partial class TopNavHeader : ITopNavHeader
    {
        public string BaseClassName => "ant-pro-top-nav-header";
        public ClassMapper MainClassMapper { get; } = new ClassMapper();
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
        [Parameter] public RenderFragment MenuExtraRender { get; set; }
        [Parameter] public RenderFragment<bool> CollapsedButtonRender { get; set; }
        [Parameter] public BreakpointType Breakpoint { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnMenuHeaderClick { get; set; }
        [Parameter] public bool Hide { get; set; }
        [Parameter] public List<RenderFragment> Links { get; set; }
        [Parameter] public EventCallback<string[]> OnOpenChange { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .If(BaseClassName, () => NavTheme == MenuTheme.Light)
                .If("light", () => NavTheme == MenuTheme.Light);

            MainClassMapper
                .Clear()
                .Add($"{BaseClassName}-main")
                .If("wide", () => ContentWidth == "Fixed");

        }
    }
}