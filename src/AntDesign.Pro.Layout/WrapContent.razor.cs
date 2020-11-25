using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class WrapContent
    {
        [Parameter]
        public string PrefixCls { get; set; }

        [Parameter]
        public bool IsChildrenLayout { get; set; }

        [Parameter]
        public int ContentHeight { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
