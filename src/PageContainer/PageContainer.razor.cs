using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class PageContainer
    {
        private const string PrefixCls = "ant-pro";
        private readonly string _prefixedClassName = $"{PrefixCls}-page-container";

        [Parameter] public RenderFragment ExtraContent { get; set; }

        [Parameter] public RenderFragment Content { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string Title { get; set; }

        [Parameter] public RenderFragment Breadcrumb { get; set; }
    }
}