using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.ProLayout
{
    internal interface IGlobalHeader : IPureSettings
    {
        bool Collapsed { get; }
        bool IsMobile { get; }
        OneOf<string, RenderFragment> Logo { get; }

        // todo:oneof
        bool MenuRender { get; }

        bool HeaderRender { get; }
    }

    public partial class GlobalHeader : AntProComponentBase, IGlobalHeader
    {
        public string BaseClassName => $"{PrefixCls}-global-header";

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

        [Parameter] public int SiderWidth { get; set; }

        [Parameter]
        public OneOf<string, RenderFragment> Logo { get; set; }

        [Parameter] public string BaseURL { get; set; } = "";

        [CascadingParameter(Name = nameof(RightContentRender))]
        public RenderFragment RightContentRender { get; set; }

        public MenuDataItem[] NoChildrenMenuData { get; set; }

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
                .If($"{BaseClassName}-layout-mix", () => Layout == Layout.Mix)
                .If($"{BaseClassName}-layout-side", () => Layout == Layout.Side)
                .If($"{BaseClassName}-layout-top", () => Layout == Layout.Top);
        }
    }
}