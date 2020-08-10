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
        public string NavTheme { get; set; } = "light"; // light | dark
        public string Layout { get; set; } = "mix";    // side | top | mix
        public string ContentWidth { get; set; } = "Fluid"; // Fluid | Fixed
        public bool FixedHeader { get; set; }
        public bool FixSiderbar { get; set; } = true;
        public string Title { get; set; } = "Ant Design Pro";
        public string IconfontUrl { get; set; }
        public string PrimaryColor { get; set; }
        public bool ColorWeak { get; set; }
        public bool SplitMenus { get; set; }
        public bool HeaderRender { get; set; } = true;
        public bool FooterRender { get; set; } = true;
        public bool MenuRender { get; set; } = true;
        public bool MenuHeaderRender { get; set; } = true;
    }
}
