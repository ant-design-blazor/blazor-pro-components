using System;

namespace AntDesign.Pro.Layout
{
    public sealed class Layout : EnumValue<Layout>
    {
        public static readonly Layout Side = new Layout(nameof(Side).ToLowerInvariant(), 1);
        public static readonly Layout Top = new Layout(nameof(Top).ToLowerInvariant(), 2);
        public static readonly Layout Mix = new Layout(nameof(Mix).ToLowerInvariant(), 3);

        private Layout(string name, int value)
            : base(name, value)
        {
        }
    }

    interface IPureSettings
    {
        MenuTheme NavTheme { get; }
        Layout Layout { get; }
        string ContentWidth { get; }
        bool FixedHeader { get; }
        bool FixSiderbar { get; }
        string Title { get; }
        string IconfontUrl { get; }
        string PrimaryColor { get; }
        bool ColorWeak { get; }
        bool SplitMenus { get; }
    }

    interface IRenderSetting
    {
        bool HeaderRender { get; }
        bool FooterRender { get; }
        bool MenuRender { get; }
        bool MenuHeaderRender { get; }
    }

    public class ProSettings
    {
        private string _navTheme = "light";     // light | dark
        private string _layout = "mix";         // side | top | mix
        private string _contentWidth = "Fluid"; // Fluid | Fixed
        private bool _fixedHeader;
        private bool _fixSiderbar = true;
        private string _title = "Ant Design Pro";
        private string _iconfontUrl;
        private string _primaryColor;
        private bool _colorWeak;
        private bool _splitMenus;
        private bool _headerRender = true;
        private bool _footerRender = true;
        private bool _menuRender = true;
        private bool _menuHeaderRender = true;
        private int _headerHeight = 48;
        public event Action OnStateChange; // todo: replace with service for updating state.

        public string NavTheme
        {
            get => _navTheme;
            set
            {
                if (_navTheme == value) return;
                _navTheme = value;
                OnStateChange?.Invoke();
            }
        }

        public int HeaderHeight
        {
            get => _headerHeight;
            set
            {
                if (_headerHeight == value) return;
                _headerHeight = value;
                OnStateChange?.Invoke();
            }
        }

        public string Layout
        {
            get => _layout;
            set
            {
                if (_layout == value) return;
                _layout = value;
                OnStateChange?.Invoke();
            }
        } 

        public string ContentWidth
        {
            get => _contentWidth;
            set
            {
                if (_contentWidth == value) return;
                _contentWidth = value;
                OnStateChange?.Invoke();
            }
        }

        public bool FixedHeader
        {
            get => _fixedHeader;
            set
            {
                if (_fixedHeader == value) return;
                _fixedHeader = value;
                OnStateChange?.Invoke();
            }
        }

        public bool FixSiderbar
        {
            get => _fixSiderbar;
            set
            {
                if (_fixSiderbar == value) return;
                _fixSiderbar = value;
                OnStateChange?.Invoke();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnStateChange?.Invoke();
            }
        }

        public string IconfontUrl
        {
            get => _iconfontUrl;
            set
            {
                if (_iconfontUrl == value) return;
                _iconfontUrl = value;
                OnStateChange?.Invoke();
            }
        }

        public string PrimaryColor
        {
            get => _primaryColor;
            set
            {
                if (_primaryColor == value) return;
                _primaryColor = value;
                OnStateChange?.Invoke();
            }
        }

        public bool ColorWeak
        {
            get => _colorWeak;
            set
            {
                if (_colorWeak == value) return;
                _colorWeak = value;
                OnStateChange?.Invoke();
            }
        }

        public bool SplitMenus
        {
            get => _splitMenus;
            set
            {
                if (_splitMenus == value) return;
                _splitMenus = value;
                OnStateChange?.Invoke();
            }
        }

        public bool HeaderRender
        {
            get => _headerRender;
            set
            {
                if (_headerRender == value) return;
                _headerRender = value;
                OnStateChange?.Invoke();
            }
        }

        public bool FooterRender
        {
            get => _footerRender;
            set
            {
                if (_footerRender == value) return;
                _footerRender = value;
                OnStateChange?.Invoke();
            }
        }

        public bool MenuRender
        {
            get => _menuRender;
            set
            {
                if (_menuRender == value) return;
                _menuRender = value;
                OnStateChange?.Invoke();
            }
        }

        public bool MenuHeaderRender
        {
            get => _menuHeaderRender;
            set
            {
                if (_menuHeaderRender == value) return;
                _menuHeaderRender = value;
                OnStateChange?.Invoke();
            }
        }
    }
}
