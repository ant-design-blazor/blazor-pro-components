using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Pro.Layout
{
    interface ISiderMenu : IBaseMenu
    {
        OneOf<string, RenderFragment> Logo { get; }
        int SiderWidth { get; }
        BreakpointType Breakpoint { get; }
        bool Hide { get; }
        List<RenderFragment> Links { get; }
    }

    public partial class SiderMenu : ISiderMenu
    {
        public string PrefixCls { get; } = "ant-pro";
        public string BaseClassName => $"{PrefixCls}-sider";
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public EventCallback<bool> HandleOpenChange { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public MenuDataItem[] MenuData { get; set; }
        [Parameter] public MenuMode Mode { get; set; }
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        [Parameter] public string[] OpenKeys { get; set; }
        [Parameter] public MenuTheme Theme { get; set; } = MenuTheme.Light;
        [Parameter] public OneOf<string, RenderFragment> Logo { get; set; }
        [Parameter] public int SiderWidth { get; set; } = 208;
        public BreakpointType Breakpoint { get; set; }
        [Parameter] public bool Hide { get; set; }
        [Parameter] public SiderTheme SiderTheme { get; set; } = SiderTheme.Light;
        [Parameter] public List<RenderFragment> Links { get; set; }
        [Parameter] public EventCallback OnMenuHeaderClick { get; set; }
        [Parameter] public EventCallback<string[]> OnOpenChange { get; set; }

        async Task CollapseSider(bool collapse)
        {
            if (!IsMobile)
            {
                await OnCollapse.InvokeAsync(collapse);
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            FixSiderbar = true;
            Layout = Layout.Side;
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add(Class)
                .Add(BaseClassName)
                .If($"{BaseClassName}-fixed", () => FixSiderbar)
                .If($"{BaseClassName}-layout-{Layout}", () => !IsMobile)
                .If($"{BaseClassName}-light", () => Theme == MenuTheme.Light);
        }
    }
}
