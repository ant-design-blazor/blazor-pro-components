using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Pro.Layout
{
    public class SettingItem
    {
        public string Title { get; set; }
        public bool Disabled { get; set; }
        public RenderFragment Action { get; set; }
    }

    public partial class LayoutSetting
    {
    }
}