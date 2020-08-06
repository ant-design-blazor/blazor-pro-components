using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

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
        [Parameter] public string ContentWidth { get; set; } = "Fixed";
    }
}