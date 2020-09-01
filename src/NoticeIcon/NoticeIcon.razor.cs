using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class NoticeIcon
    {
        private TriggerType[] Trigger { get; set; } = {TriggerType.Click};

        [Parameter] public bool Visible { get; set; }
        [Parameter] public int Count { get; set; }

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