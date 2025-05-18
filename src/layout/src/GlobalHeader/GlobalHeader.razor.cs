using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using OneOf;

namespace AntDesign.ProLayout
{
    internal interface IGlobalHeader : IPureSettings
    {
        bool Collapsed { get; }
        bool IsMobile { get; }
        OneOf<string, RenderFragment> Logo { get; }
        bool MenuRender { get; }
        bool HeaderRender { get; }
    }

    public partial class GlobalHeader : AntProComponentBase, IGlobalHeader
    {
        public string BaseClassName => "ant-pro-global-header";

        [Parameter]
        public string PrefixCls { get; set; } = "ant-pro";

        [Parameter]
        public EventCallback<bool> OnCollapse { get; set; }

        [Parameter]
        public RenderFragment CollapsedButtonRender { get; set; }

        [Parameter]
        public bool Collapsed { get; set; }

        [Parameter]
        public bool IsMobile { get; set; }

        [Parameter]
        public bool HasSiderMenu { get; set; }

        [Parameter]
        public int SiderWidth { get; set; }

        [Parameter]
        public OneOf<string, RenderFragment> Logo { get; set; }

        [Parameter]
        public string BaseURL { get; set; } = "";

        [CascadingParameter(Name = nameof(RightContentRender))]
        public RenderFragment RightContentRender { get; set; }

        [Parameter]
        public MenuDataItem[] MenuData { get; set; }

        [Parameter]
        public EventCallback<MenuItem> OnMenuItemClicked { get; set; }

        private async Task HandleMenuItemClick(MenuItem menuItem)
        {
            // 更新选中的菜单项
            SelectedKey = menuItem.Key;

            if (OnMenuItemClicked.HasDelegate)
            {
                await OnMenuItemClicked.InvokeAsync(menuItem);
            }
        }

        public MenuDataItem[] NoChildrenMenuData => MenuData?
            .Where(x => !x.HideInMenu)  // Only show non-hidden menu items
            .Select(x => new MenuDataItem
            {
                Path = x.Path,
                Key = x.Key,
                Icon = x.Icon,
                Children = null,  // Hide children
                Name = x.Name,
                Match = NavLinkMatch.Prefix,  // Use Prefix match for top-level items
                Locale = x.Locale,
                Authority = x.Authority,
                HideChildrenInMenu = true,  // Force hide children
                HideInMenu = x.HideInMenu,
                ParentKeys = x.ParentKeys
            })
            .ToArray() ?? [];

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
                .If($"{BaseClassName}-layout-{Layout}", () => !IsMobile);
        }
    }
}