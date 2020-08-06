using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;

namespace AntDesign.Pro.Layout
{
    public partial class SettingDrawer
    {
        private string PrefixCls { get; set; } = "ant-pro";
        private string BaseClassName => $"{PrefixCls}-setting";
        private bool _show = false;
        private string NavTheme { get; set; } = "dark";
        private string Layout { get; set; } = "sidemenu";
        private string PrimaryColor { get; set; } = "daybreak";
        private CheckboxItem[] ThemeList { get; set; } = 
        {
            new CheckboxItem
            {
                Key = "light",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/NQ%24zoisaD2/jpRkZQMyYRryryPNtyIC.svg",
                Title = "Light style",
            }
        };
        private CheckboxItem[] LayoutList { get; set; } =
        {
            new CheckboxItem
            {
                Key = "side",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/XwFOFbLkSM/LCkqqYNmvBEbokSDscrm.svg",
                Title = "Side Menu Layout",
            },
            new CheckboxItem
            {
                Key = "top",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/URETY8%24STp/KDNDBbriJhLwuqMoxcAr.svg",
                Title = "Top Menu Layout",
            },
            new CheckboxItem
            {
                Key = "mix",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/x8Ob%26B8cy8/LCkqqYNmvBEbokSDscrm.svg",
                Title = "Mix Menu Layout",
            }
        };
        private ColorItem[] DarkColorList { get; set; } =
        {
            new ColorItem
            {
                Key = "daybreak",
                Color = "#1890ff",
                Theme = "dark"
            }
        };
        private ColorItem[] LightColorList { get; set; } =
        {
            new ColorItem
            {
                Key = "daybreak",
                Color = "#1890ff",
                Theme = "dark"
            },
        };
        private bool HideHintAlert { get; set; }
        private bool HideCopyButton { get; set; }

        private void SetShow(MouseEventArgs args)
        {
            _show = !_show;
        }

        private void ChangeSetting()
        {

        }
    }
}