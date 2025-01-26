using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OneOf;

namespace AntDesign.ProLayout
{
    internal interface ISiderMenu : IBaseMenu
    {
        OneOf<string, RenderFragment> Logo { get; }
        int SiderWidth { get; }
        RenderFragment MenuExtraRender { get; }
        RenderFragment<bool> CollapsedButtonRender { get; }
        BreakpointType Breakpoint { get; }
        EventCallback<MouseEventArgs> OnMenuHeaderClick { get; }
        bool Hide { get; }
        List<RenderFragment> Links { get; }
    }

    public partial class SiderMenu : ISiderMenu
    {
        public string SiderStyle => $"overflow: hidden; padding-top: {(Layout == Layout.Mix ? HeaderHeight : 0)}px;";
        public string PrefixCls { get; } = "ant-pro";
        public string BaseClassName => $"{PrefixCls}-sider";

        [CascadingParameter(Name = nameof(Collapsed))]
        public bool Collapsed { get; set; }

        [Parameter] public EventCallback<bool> HandleOpenChange { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public MenuDataItem[] MenuData { get; set; }
        [Parameter] public MenuMode Mode { get; set; } = MenuMode.Inline;
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        [Parameter] public string[] OpenKeys { get; set; } = [];
        [Parameter] public OneOf<string, RenderFragment> Logo { get; set; }
        [Parameter] public string BaseURL { get; set; } = "";
        [Parameter] public int SiderWidth { get; set; } = 208;
        [Parameter] public BreakpointType Breakpoint { get; set; } = BreakpointType.Lg;
        [Parameter] public bool Hide { get; set; }
        [Parameter] public List<RenderFragment> Links { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnMenuHeaderClick { get; set; }
        [Parameter] public EventCallback<string[]> OpenKeysChanged { get; set; }

        [CascadingParameter(Name = nameof(MenuExtraRender))]
        public RenderFragment MenuExtraRender { get; set; }

        [Parameter]
        public bool Accordion { get; set; }

        [Parameter]
        public SiderTheme SiderTheme
        {
            get
            {
                return NavTheme switch
                {
                    MenuTheme.Light => SiderTheme.Light,
                    MenuTheme.Dark => SiderTheme.Dark,
                    _ => SiderTheme.Light
                };
            }
            set => NavTheme = value == SiderTheme.Light ? MenuTheme.Light : MenuTheme.Dark;
        }

        [Parameter]
        public string[] SelectedKeys { get; set; }

        [Parameter]
        public EventCallback<string[]> SelectedKeysChanged { get; set; }

        [Parameter]
        public EventCallback<MenuItem> OnMenuItemClicked { get; set; }

        private async Task HandleOnCollapse(bool collapsed)
        {
            if (!IsMobile && OnCollapse.HasDelegate)
            {
                await OnCollapse.InvokeAsync(collapsed);
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add(BaseClassName)
                .If($"{BaseClassName}-fixed", () => FixSiderbar)
                .If($"{BaseClassName}-layout-{Layout}", () => !IsMobile)
                .If($"{BaseClassName}-light", () => NavTheme == MenuTheme.Light);
        }
    }
}