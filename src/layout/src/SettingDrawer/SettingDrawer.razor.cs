using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;

namespace AntDesign.ProLayout
{
    public partial class SettingDrawer : AntDomComponentBase
    {
        private bool _show;
        private ElementReference _linkRef;
        private string _url;
        private string PrefixCls { get; } = "ant-pro";
        private string BaseClassName => $"{PrefixCls}-setting";

        private CheckboxItem[] ThemeList { get; set; }

        private CheckboxItem[] LayoutList { get; set; } =
        {
            new CheckboxItem
            {
                Key = "side",
                Url = "_content/AntDesign.ProLayout/icons/layout-side.svg",
                Title = "Side Menu Layout"
            },
            new CheckboxItem
            {
                Key = "top",
                Url = "_content/AntDesign.ProLayout/icons/layout-top.svg",
                Title = "Top Menu Layout"
            },
            new CheckboxItem
            {
                Key = "mix",
                Url = "_content/AntDesign.ProLayout/icons/layout-mix.svg",
                Title = "Mix Menu Layout"
            }
        };

        private ColorItem[] DarkColorList { get; set; } = Utils.ThemeColors.Select(x => new ColorItem
        {
            Key = x.Value,
            Color = x.Key,
            Theme = "dark"
        }).ToArray();

        private ColorItem[] LightColorList { get; set; } = Utils.ThemeColors.Select(x => new ColorItem
        {
            Key = x.Value,
            Color = x.Key,
            Theme = "light"
        }).ToArray();

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
                    Url = "_content/AntDesign.ProLayout/icons/theme-light.svg",
                    Title = "Light style"
                }
            };

            if (SettingState.Value.Layout != "mix")
            {
                list.Add(new CheckboxItem
                {
                    Key = "dark",
                    Url = "_content/AntDesign.ProLayout/icons/layout-side.svg",
                    Title = "Dark style"
                });
            }
            else if (SettingState.Value.NavTheme == "dark")
            {
                SettingState.Value.NavTheme = "light";
            }

            list.Add(new CheckboxItem
            {
                Key = "realDark",
                Url = "_content/AntDesign.ProLayout/icons/theme-real-dark.svg",
                Title = "Dark style"
            });

            ThemeList = list.ToArray();
        }

        private async Task UpdateTheme(string theme)
        {
            SettingState.Value.NavTheme = theme;
            await UpdateStyle();
        }

        private async Task UpdateColor(string color)
        {
            SettingState.Value.PrimaryColor = color;
            await UpdateStyle();
        }

        private async Task UpdateStyle()
        {
            Message.Loading(new MessageConfig
            {
                Content = "Loading theme",
                Duration = 1
            });

            var color = SettingState.Value.PrimaryColor;
            var theme = SettingState.Value.NavTheme;

            string fileName;
            if (theme == "realDark")
            {
                fileName = color == "daybreak" ? "dark" : $"dark-{color}";
            }
            else
            {
                fileName = color == "daybreak" ? null : color;
            }

            Console.WriteLine(new { color, theme });


            _url = fileName == null ? "" : $"/_content/AntDesign.ProLayout/theme/{fileName}.css";
            await JsInvokeAsync(JSInteropConstants.AddElementToBody, _linkRef);
        }

        private void SetShow(MouseEventArgs args)
        {
            _show = !_show;
        }

        private async Task CopySetting(MouseEventArgs args)
        {
            var json = JsonSerializer.Serialize(SettingState.Value);
            await JsInvokeAsync<object>(JSInteropConstants.Copy, json);
            Message.Success("copy success, please replace defaultSettings in wwwroot/appsettings.json");
        }
    }
}