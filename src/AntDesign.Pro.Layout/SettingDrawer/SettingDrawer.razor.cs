using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;

namespace AntDesign.Pro.Layout
{
    public partial class SettingDrawer
    {
        private bool _show;
        private string PrefixCls { get; } = "ant-pro";
        private string BaseClassName => $"{PrefixCls}-setting";

        private CheckboxItem[] ThemeList { get; set; }

        private CheckboxItem[] LayoutList { get; set; } =
        {
            new CheckboxItem
            {
                Key = "side",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/XwFOFbLkSM/LCkqqYNmvBEbokSDscrm.svg",
                Title = "Side Menu Layout"
            },
            new CheckboxItem
            {
                Key = "top",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/URETY8%24STp/KDNDBbriJhLwuqMoxcAr.svg",
                Title = "Top Menu Layout"
            },
            new CheckboxItem
            {
                Key = "mix",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/x8Ob%26B8cy8/LCkqqYNmvBEbokSDscrm.svg",
                Title = "Mix Menu Layout"
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
            }
        };

        [Parameter] public bool HideHintAlert { get; set; }
        [Parameter] public bool HideCopyButton { get; set; }
        [Inject] public MessageService Message { get; set; }
        [Inject] public IOptions<ProSettings> SettingState { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetThemeList();
        }

        private void SetThemeList()
        {
            var list = new List<CheckboxItem>
            {
                new CheckboxItem
                {
                    Key = "light",
                    Url = "https://gw.alipayobjects.com/zos/antfincdn/NQ%24zoisaD2/jpRkZQMyYRryryPNtyIC.svg",
                    Title = "Light style"
                }
            };

            if (SettingState.Value.Layout != "mix")
            {
                list.Add(new CheckboxItem
                {
                    Key = "dark",
                    Url = "https://gw.alipayobjects.com/zos/antfincdn/XwFOFbLkSM/LCkqqYNmvBEbokSDscrm.svg",
                    Title = "Dark style"
                });
            }

            ThemeList = list.ToArray();
        }

        private void SetShow(MouseEventArgs args)
        {
            _show = !_show;
        }

        private void ChangeSetting()
        {
        }

        private async Task CopySetting(MouseEventArgs args)
        {
            var json = JsonSerializer.Serialize(SettingState.Value);
            await JsInvokeAsync<object>(JSInteropConstants.copy, json);
            await Message.Success("copy success£¬please replace defaultSettings in wwwroot/appsettings.json");
        }
    }
}