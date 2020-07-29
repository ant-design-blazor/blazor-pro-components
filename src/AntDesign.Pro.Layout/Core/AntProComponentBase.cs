using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public abstract class AntProComponentBase : AntDomComponentBase, IPureSettings
    {
        [Parameter] public MenuTheme NavTheme { get; set; }

        [Parameter] public Layout Layout { get; set; }

        [Parameter] public ContentWidth ContentWidth { get; set; }

        [Parameter] public bool FixedHeader { get; set; }

        [Parameter] public bool FixSiderbar { get; set; }

        [Parameter] public string Title { get; set; }

        [Parameter] public string IconfontUrl { get; set; }

        [Parameter] public string PrimaryColor { get; set; }

        [Parameter] public bool ColorWeak { get; set; }

        [Parameter] public bool SplitMenus { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}