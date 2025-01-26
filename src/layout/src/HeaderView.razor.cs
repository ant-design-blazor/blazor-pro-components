using System.Text;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.ProLayout
{
    internal interface IHeaderView : IGlobalHeader
    {
        bool HasSiderMenu { get; }
        int SiderWidth { get; }
        RenderFragment HeaderContentRender { get; }
    }

    public partial class HeaderView : IHeaderView
    {
        private string _headerStyle;
        private string _fixedHeaderStyle;
        private bool _needFixedHeader;
        private bool _needSettingWidth;
        private bool _isTop;
        public string PrefixCls { get; set; } = "ant-pro";
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public string BaseURL { get; set; } = "";
        [Parameter] public OneOf<string, RenderFragment> Logo { get; set; }
        [Parameter] public bool HasSiderMenu { get; set; }
        [Parameter] public int SiderWidth { get; set; }
        [Parameter] public RenderFragment HeaderContentRender { get; set; }
        [Parameter] public MenuDataItem[] MenuData { get; set; } = { };

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
            sb.Append($"height: {HeaderHeight}px;");
            sb.Append($"line-height: {HeaderHeight}px;");
            sb.Append($"width: {width};");
            sb.Append($"z-index: {zIndex};");
            if (_needFixedHeader)
            {
                sb.Append("right: 0;");
            }
            sb.Append(Style);
            _headerStyle = sb.ToString();
            _fixedHeaderStyle = $"height:{HeaderHeight}px; line-height: {HeaderHeight}px; background: transparent;";
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .If($"{PrefixCls}-fixed-header", () => _needFixedHeader)
                .If($"{PrefixCls}-top-menu", () => Layout == Layout.Top);
        }

        protected override void OnStateChanged()
        {
            SetStyle();
            SetClassMap();
            base.OnStateChanged();
        }
    }
}