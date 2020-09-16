using System.Collections.Generic;
using System.Threading.Tasks;
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

        [Parameter] public IList<TabPaneItem> TabList { get; set; }

        [Parameter] public string TabActiveKey { get; set; }

        [Parameter] public EventCallback<string> OnTabChange { get; set; }

        protected async Task HandleTabClick(string key)
        {
            // Do not use TabChange/KeyChange will cause an endless loop
            if (key != TabActiveKey && OnTabChange.HasDelegate)
            {
                await OnTabChange.InvokeAsync(key);
            }
        }
    }
}