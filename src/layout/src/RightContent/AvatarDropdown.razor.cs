using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace AntDesign.ProLayout
{
    public partial class AvatarDropdown
    {
        [Parameter] public string Avatar { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public EventCallback<MenuItem> OnItemSelected { get; set; }

        [Parameter]
        public IEnumerable<AvatarMenuItem> MenuItems { get; set; } = 
        new AvatarMenuItem[]
        {
            new AvatarMenuItem { Key = "center", IconType = "user", Option = "个人中心"},
            new AvatarMenuItem { Key = "setting", IconType = "setting", Option = "个人中心"},
            new AvatarMenuItem { IsDivider = true },
            new AvatarMenuItem { Key = "logout", IconType = "logout", Option = "个人中心"}
        };
    }

    public class AvatarMenuItem
    {
        public string Key { get; set; }
        public string IconType { get; set; }
        public IconThemeType IconTheme { get; set; } = IconThemeType.Outline;
        public string Option { get; set; }
        public bool IsDivider { get; set; }
    }

}