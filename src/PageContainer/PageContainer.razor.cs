using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class PageContainer
    {
        private const string PrefixCls = "ant-pro";
        private readonly string _prefixedClassName = $"{PrefixCls}-page-container";
        private RenderFragment _breadcrumb;
        private RenderFragment _extra;

        [Parameter]
        public RenderFragment Extra
        {
            get => _extra ?? (builder => { });
            set => _extra = value;
        }

        [Parameter] public RenderFragment ExtraContent { get; set; }

        [Parameter] public RenderFragment Content { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string Title { get; set; }

        [Parameter]
        public RenderFragment Breadcrumb
        {
            get => _breadcrumb ?? (builder => { });
            set => _breadcrumb = value;
        }
    }
}