using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class SelectLang
    {
        [Parameter] 
        public string[] Locales { get; set; } = { "zh-CN", "zh-TW", "en-US", "pt-BR" };

        [Parameter]
        public IDictionary<string, string> LanguageLabels { get; set; } = new Dictionary<string, string>
        {
            ["zh-CN"] = "简体中文",
            ["zh-TW"] = "繁体中文",
            ["en-US"] = "English",
            ["pt-BR"] = "Português",
        };

        [Parameter] 
        public IDictionary<string, string> LanguageIcons { get; set; } = new Dictionary<string, string>
        {
            ["zh-CN"] = "🇨🇳",
            ["zh-TW"] = "🇭🇰",
            ["en-US"] = "🇺🇸",
            ["pt-BR"] = "🇧🇷",
        };

        [Parameter] 
        public EventCallback<MenuItem> OnItemSelected { get; set; }
    }
}