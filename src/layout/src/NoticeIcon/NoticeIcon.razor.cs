using Microsoft.AspNetCore.Components;

namespace AntDesign.ProLayout
{
    public partial class NoticeIcon : AntDomComponentBase
    {
        private readonly Trigger[] _trigger = { Trigger.Click };

        [Parameter] public bool Visible { get; set; }
        [Parameter] public int Count { get; set; }
        [Parameter] public string ClearText { get; set; }
        [Parameter] public string ViewMoreText { get; set; }
        [Parameter] public EventCallback<string> OnClear { get; set; }
        [Parameter] public EventCallback<string> OnViewMore { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string IconType { get; set; } = "bell";
        [Parameter] public IconThemeType IconTheme { get; set; } = IconThemeType.Outline;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("noticeButton")
                .If("opened", () => Visible);
        }
    }
}