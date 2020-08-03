using System.Text;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Pro.Layout
{
    internal interface IHeaderView: IGlobalHeader
    {
        bool HasSiderMenu { get; }
        int SiderWidth { get; }
        RenderFragment HeaderContentRender { get; }
    }

    public partial class HeaderView: IHeaderView
    {
        private string _headerStyle;
        private bool _needFixedHeader;
        private bool _needSettingWidth;
        private bool _isTop;
        public string PrefixCls { get; set; } = "ant-pro";
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public OneOf<string, RenderFragment> Logo { get; set; }
        [Parameter] public bool MenuRender { get; set; }
        [Parameter] public bool HeaderRender { get; set; }
        [Parameter] public bool HasSiderMenu { get; set; }
        [Parameter] public int SiderWidth { get; set; } = 208;
        [Parameter] public RenderFragment HeaderContentRender { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetStyle();
            SetClassMap();
        }

        protected void SetStyle()
        {
            _isTop = Layout == Layout.Top;
            _needFixedHeader = FixedHeader || Layout == Layout.Mix;
            _needSettingWidth = _needFixedHeader && HasSiderMenu && !_isTop && !IsMobile;
            var width = Layout == Layout.Mix && _needSettingWidth ? $"calc(100% - {(Collapsed ? "48" : SiderWidth.ToString())}px)" : "100%";
            var zIndex = Layout == Layout.Mix ? 100 : 9;
            var sb = new StringBuilder();
            sb.Append("padding: 0;");
            sb.Append("height: 48px;");
            sb.Append("ine-height: 48px;");
            sb.Append($"width: {width};");
            sb.Append($"z-index: {zIndex};");
            if (_needFixedHeader)
            {
                sb.Append("right: 0;");
            }
            sb.Append(Style);
            _headerStyle = sb.ToString();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .If($"{PrefixCls}-fixed-header", () => _needFixedHeader)
                .If($"{PrefixCls}-top-menu", () => Layout == Layout.Top);
        }
    }
}