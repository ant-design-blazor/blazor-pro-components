using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign.JsInterop;
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
        [Parameter] public RenderFragment<bool> CollapsedButtonRender { get; set; }
        [Parameter] public BreakpointType Breakpoint { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnMenuHeaderClick { get; set; }
        [Parameter] public bool Hide { get; set; }
        [Parameter] public List<RenderFragment> Links { get; set; }
        [Parameter] public EventCallback<string[]> OnOpenChange { get; set; }
        [Parameter] public bool Pure { get; set; } = true;
        [Parameter] public bool Loading { get; set; }
        [Parameter] public bool DisableContentMargin { get; set; }
        [Parameter] public string ContentStyle { get; set; }
        [Parameter] public string ColSize { get; set; } = nameof(BreakpointEnum.lg);
        [Parameter] public RenderFragment RightContentRender { get; set; }
        [Inject] public ILogger<BasicLayout> Logger { get; set; }
        [Inject] public DomEventService DomEventService { get; set; }

        private static readonly Hashtable ResponsiveMap = new Hashtable()
        {
            [nameof(BreakpointEnum.xs)] = "(max-width: 575px)",
            [nameof(BreakpointEnum.sm)] = "(max-width: 576px)",
            [nameof(BreakpointEnum.md)] = "(max-width: 768px)",
            [nameof(BreakpointEnum.lg)] = "(max-width: 992px)",
            [nameof(BreakpointEnum.xl)] = "(max-width: 1200px)",
            [nameof(BreakpointEnum.xxl)] = "(max-width: 1600px)",
        };

        protected override void OnInitialized()
        {
            Logger.LogInformation("BasicLayout initialized.");
            base.OnInitialized();
            SetStyle();
            SetClassMap();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                DomEventService.AddEventListener<object>("window", "resize", OnResize, false);
            }

            base.OnAfterRender(firstRender);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            DomEventService.RemoveEventListerner<object>("window", "resize", OnResize);
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
                .If("screen-xs", () => ColSize == nameof(BreakpointEnum.xs))
                .If("screen-sm", () => ColSize == nameof(BreakpointEnum.sm))
                .If("screen-md", () => ColSize == nameof(BreakpointEnum.md))
                .If("screen-lg", () => ColSize == nameof(BreakpointEnum.lg))
                .If("screen-xl", () => ColSize == nameof(BreakpointEnum.xl))
                .If("screen-xxl", () => ColSize == nameof(BreakpointEnum.xxl))
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

        private async void OnResize(object o)
        {
            ColSize = await GetScreenClassName();
            Logger.LogInformation($"Screen: {ColSize}");

            switch (ColSize)
            {
                case nameof(BreakpointEnum.xs):
                case nameof(BreakpointEnum.sm):
                    IsMobile = true;
                    break;
                case nameof(BreakpointEnum.md):
                    Collapsed = true;
                    break;
                default:
                    Collapsed = false;
                    IsMobile = false;
                    break;
            }

            OnStateChanged();
        }

        private async Task<string> GetScreenClassName()
        {
            string breakPoint = null;

            await typeof(BreakpointEnum).GetEnumNames().ForEachAsync(async bp =>
            {
                if (await JsInvokeAsync<bool>(JSInteropConstants.MatchMedia, ResponsiveMap[bp]))
                {
                    breakPoint = bp;
                }
            });

            return breakPoint;
        }
    }
}
