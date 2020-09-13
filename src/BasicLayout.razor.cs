using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using OneOf;

namespace AntDesign.Pro.Layout
{
    interface IBasicLayout: ISiderMenu, IGlobalHeader
    {
        bool Pure { get; }
        bool Loading { get; }
        bool DisableContentMargin { get; }
        string ContentStyle { get; }
    }

    public partial class BasicLayout: IBasicLayout
    {
        private readonly bool _isChildrenLayout = false;
        private string _genLayoutStyle;
        private string _weakModeStyle;

        public string PrefixCls { get; } = "ant-pro";
        public string BaseClassName => $"{PrefixCls}-basicLayout";
        public ClassMapper ContentClassMapper { get; set; } = new ClassMapper();

        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public EventCallback<bool> HandleOpenChange { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public MenuDataItem[] MenuData { get; set; }
        [Parameter] public MenuMode Mode { get; set; }
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        [Parameter] public string[] OpenKeys { get; set; }
        [Parameter] public MenuTheme Theme { get; set; }
        [Parameter] public OneOf<string, RenderFragment> Logo { get; set; }
        [Parameter] public int SiderWidth { get; set; } = 208;
        [Parameter] public RenderFragment MenuExtraRender { get; set; }
        [Parameter] public RenderFragment CollapsedButtonRender { get; set; }
        [Parameter] public BreakpointType Breakpoint { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnMenuHeaderClick { get; set; }
        [Parameter] public bool Hide { get; set; }
        [Parameter] public List<RenderFragment> Links { get; set; }
        [Parameter] public EventCallback<string[]> OnOpenChange { get; set; }
        [Parameter] public bool Pure { get; set; } = true;
        [Parameter] public bool Loading { get; set; }
        [Parameter] public bool DisableContentMargin { get; set; }
        [Parameter] public string ContentStyle { get; set; }
        [Parameter] public string ColSize { get; set; } = "lg";
        [Parameter] public RenderFragment RightContentRender { get; set; }
        [Inject] public ILogger<BasicLayout> Logger { get; set; }

        protected override void OnInitialized()
        {
            Logger.LogInformation("BasicLayout initialized.");
            base.OnInitialized();
            SetStyle();
            SetClassMap();
        }

        protected void SetStyle()
        {
            var hasLeftPadding = FixSiderbar && Layout != Layout.Top && !IsMobile;
            var paddingLeft = hasLeftPadding ? Collapsed ? 48 : SiderWidth : 0;
            _genLayoutStyle = MenuRender ? $"padding-left: {paddingLeft}px; position: relative;" : "";
            _weakModeStyle = ColorWeak ? "filter: invert(80%);" : "";
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("ant-design-pro")
                .Add(BaseClassName)
                .Add($"screen-{ColSize}")
                .If($"{BaseClassName}-top-menu", () => Layout == Layout.Top)
                .If($"{BaseClassName}-is-children", () => _isChildrenLayout)
                .If($"{BaseClassName}-fix-siderbar", () => FixSiderbar)
                .If($"{BaseClassName}-mobile", () => IsMobile);

            ContentClassMapper
                .Clear()
                .Add($"{BaseClassName}-content")
                .If($"{BaseClassName}-has-header", () => HeaderRender)
                .If($"{BaseClassName}-content-disable-margin", () => DisableContentMargin);
        }

        protected override void OnStateChanged()
        {
            base.OnStateChanged();
            SetStyle();
        }

        private void HandleCollapse(bool collapsed)
        {
            Collapsed = collapsed;
            SetStyle();
        }
    }
}
