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

    public sealed class ContentWidth : EnumValue<ContentWidth>
    {
        public static readonly ContentWidth Fluid = new ContentWidth(nameof(Fluid), 1);
        public static readonly ContentWidth Fixed = new ContentWidth(nameof(Fixed), 2);

        private ContentWidth(string name, int value)
            : base(name, value)
        {
        }
    }

    interface IPureSettings
    {
        MenuTheme NavTheme { get; }
        Layout Layout { get; }
        ContentWidth ContentWidth { get; }
        bool FixedHeader { get; }
        bool FixSiderbar { get; }
        string Title { get; }
        string IconfontUrl { get; }
        string PrimaryColor { get; }
        bool ColorWeak { get; }
        bool SplitMenus { get; }
    }
}
