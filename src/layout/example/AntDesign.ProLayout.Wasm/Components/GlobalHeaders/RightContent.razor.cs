using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AntDesign.ProLayout
{
    public partial class RightContent : AntDomComponentBase
    {
        private List<AutoCompleteDataItem<string>> DefaultOptions { get; set; } = new List<AutoCompleteDataItem<string>>
        {
            new AutoCompleteDataItem<string>
            {
                Label = "umi ui",
                Value = "umi ui"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Table",
                Value = "Pro Table"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Layout",
                Value = "Pro Layout"
            }
        };

        private string[] _locales = { "zh-CN", "zh-TW", "en-US", "pt-BR" };

        private IEnumerable<AvatarMenuItem> _avatarMenuItems = new AvatarMenuItem[]
        {
            new AvatarMenuItem { Key = "center", IconType = "user", Option = "个人中心"},
            new AvatarMenuItem { Key = "setting", IconType = "setting", Option = "设置"},
            new AvatarMenuItem { IsDivider = true },
            new AvatarMenuItem { Key = "logout", IconType = "logout", Option = "退出登录"}
        };


        private IDictionary<string, string> _languageLabels = new Dictionary<string, string>
        {
            ["zh-CN"] = "简体中文",
            ["zh-TW"] = "繁体中文",
            ["en-US"] = "English",
            ["pt-BR"] = "Português",
        };
        private IDictionary<string, string> _languageIcons = new Dictionary<string, string>
        {
            ["zh-CN"] = "🇨🇳",
            ["zh-TW"] = "🇭🇰",
            ["en-US"] = "🇺🇸",
            ["pt-BR"] = "🇧🇷",
        };

        [Parameter] public EventCallback<MenuItem> OnUserItemSelected { get; set; }
        [Parameter] public EventCallback<MenuItem> OnLangItemSelected { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("right");
        }
    }
}