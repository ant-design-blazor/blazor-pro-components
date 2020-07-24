using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class GridContent
    {
        private string _prefixCls = "ant-pro";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string ContentWidth { get; set; }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add($"{_prefixCls}-grid-content")
                .If("wide", () => ContentWidth == "Fixed");
        }
        
        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }
    }
}