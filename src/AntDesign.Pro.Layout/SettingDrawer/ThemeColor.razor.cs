using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public class ColorItem
    {
        public string Key { get; set; }
        public string Color { get; set; }
        public string Theme { get; set; }
    }

    public partial class ThemeColor
    {
        [Parameter] public ColorItem[] Colors { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public EventCallback<string> OnChange { get; set; }

    }
}