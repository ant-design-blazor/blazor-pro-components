using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class NoticeIcon : AntDomComponentBase
    {
        private readonly TriggerType[] _trigger = { TriggerType.Click };

        [Parameter] public bool Visible { get; set; }
        [Parameter] public int Count { get; set; }
        [Parameter] public string ClearText { get; set; }
        [Parameter] public string ViewMoreText { get; set; }
        [Parameter] public EventCallback<string> OnClear { get; set; }
        [Parameter] public EventCallback<string> OnViewMore { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        private void SetVisible(bool visible)
        {
            Visible = visible;
        }

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