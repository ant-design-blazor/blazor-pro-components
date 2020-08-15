using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class PageContainer
    {
        private const string prefixCls = "ant-pro";
        private string prefixedClassName = $"{prefixCls}-page-container";
        private RenderFragment _breadcrumb;
        private readonly RenderFragment _emptyBackIcon = builder => { };

        [Parameter]
        public RenderFragment ExtraContent { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment Breadcrumb
        {
            get => _breadcrumb ?? ((builder) => { });
            set => _breadcrumb = value;
        }
    }
}