using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace AntDesign.Pro.Layout
{
    public abstract class AntProComponentBase : AntDomComponentBase, IPureSettings
    {
        [Parameter] 
        public MenuTheme NavTheme
        {
            get;
            set;
        }

        [Parameter] public Layout Layout { get; set; } = Layout.Mix;

        [Parameter] 
        public string ContentWidth
        {
            get => SettingState.Value.ContentWidth;
            set => SettingState.Value.ContentWidth = value;
        }

        [Parameter]
        public bool FixedHeader
        {
            get => SettingState.Value.FixedHeader; 
            set => SettingState.Value.FixedHeader = value;
        }

        [Parameter] 
        public bool FixSiderbar
        {
            get => SettingState.Value.FixSiderbar;
            set => SettingState.Value.FixSiderbar = value;
        }

        [Parameter] 
        public string Title
        {
            get => SettingState.Value.Title;
            set => SettingState.Value.Title = value;
        }

        [Parameter] 
        public string IconfontUrl
        {
            get => SettingState.Value.IconfontUrl;
            set => SettingState.Value.IconfontUrl = value;
        }

        [Parameter] 
        public string PrimaryColor
        {
            get => SettingState.Value.PrimaryColor;
            set => SettingState.Value.PrimaryColor = value;
        }

        [Parameter] 
        public bool ColorWeak
        {
            get => SettingState.Value.ColorWeak;
            set => SettingState.Value.ColorWeak = value;
        }


        [Parameter] 
        public bool SplitMenus
        {
            get => SettingState.Value.ColorWeak;
            set => SettingState.Value.ColorWeak = value;
        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Inject] private IOptions<ProSettings> SettingState { get; set; }
    }
}