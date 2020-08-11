using System;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Pro.Layout
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

    public partial class GlobalHeader: IGlobalHeader
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

        [Parameter] 
        public OneOf<string, RenderFragment> Logo { get; set; }

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
                .If($"{BaseClassName}-layout-{Layout}", () => Layout != null);
        }
    }
}
