using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Pro.Layout
{
    internal interface IHeaderView: IGlobalHeader
    {

    }

    public partial class HeaderView: IHeaderView
    {
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public OneOf<string, RenderFragment> Logo { get; set; }
        [Parameter] public bool MenuRender { get; set; }
        [Parameter] public bool HeaderRender { get; set; }
    }
}