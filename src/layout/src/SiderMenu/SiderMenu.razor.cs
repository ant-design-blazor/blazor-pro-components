using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
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
        [Parameter] public string SelectedTopMenuKey { get; set; }

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

        private MenuDataItem[] FilteredMenuData
        {
            get
            {
                if (!SplitMenus || Layout != Layout.Mix || IsMobile)
                {
                    return MenuData;
                }

                if (string.IsNullOrEmpty(SelectedTopMenuKey))
                {
                    return Array.Empty<MenuDataItem>();
                }

                var parentItem = FindParentMenuItemByKey(MenuData, SelectedTopMenuKey);
                if (parentItem?.Children == null)
                {
                    return Array.Empty<MenuDataItem>();
                }

                // 设置子菜单项的 Match 为 All
                return parentItem.Children.Select(x => new MenuDataItem
                {
                    Authority = x.Authority,
                    Children = x.Children,
                    HideChildrenInMenu = x.HideChildrenInMenu,
                    HideInMenu = x.HideInMenu,
                    Icon = x.Icon,
                    IconFont = x.IconFont,
                    Key = x.Key,
                    Locale = x.Locale,
                    Name = x.Name,
                    Path = x.Path,
                    ParentKeys = x.ParentKeys,
                    Match = NavLinkMatch.All,
                    TitleTemplate = x.TitleTemplate
                }).ToArray();
            }
        }

        private MenuDataItem FindParentMenuItemByKey(MenuDataItem[] items, string key)
        {
            if (items == null) return null;

            // First check if the key belongs to a top-level item
            var topLevelItem = items.FirstOrDefault(x => x.Key == key);
            if (topLevelItem != null)
            {
                return topLevelItem;
            }

            // If not found in top level, search in children
            foreach (var item in items)
            {
                if (item.Children != null)
                {
                    var hasChild = item.Children.Any(x => x.Key == key ||
                        (x.Children != null && x.Children.Any(c => c.Key == key)));
                    if (hasChild)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

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