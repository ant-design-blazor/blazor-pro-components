using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Pro.Layout
{
    public class MenuDataItem
    {
        public string[] Authority { get; set; }
        public MenuDataItem[] Children { get; set; }
        public bool HideChildrenInMenu { get; set; }
        public bool HideInMenu { get; set; }
        public string Icon { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Path { get; set; }
        public string[] ParentKeys { get; set; }
    }
}
