using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class NoticeList
    {
        private string _clearText;
        private string _viewMoreText;
        [Parameter] public string TabKey { get; set; }
        [Parameter] public string EmptyText { get; set; }
        [Parameter] public ICollection<NoticeIconData> Data { get; set; }
        [Parameter] public bool ShowClear { get; set; } = true;
        [Parameter] public bool ShowViewMore { get; set; }
        [Parameter] public EventCallback OnClear { get; set; }
        [Parameter] public EventCallback OnViewMore { get; set; }
        [Parameter] public string Title { get; set; }

        [CascadingParameter] public NoticeIcon NoticeIcon { get; set; }

        [Parameter]
        public string ClearText
        {
            get => _clearText ?? NoticeIcon.ClearText;
            set => _clearText = value;
        }

        [Parameter]
        public string ViewMoreText
        {
            get => _viewMoreText ?? NoticeIcon.ViewMoreText;
            set => _viewMoreText = value;
        }

        public async Task HandleClear()
        {
            if (OnClear.HasDelegate)
                await OnClear.InvokeAsync(TabKey);

            if (NoticeIcon.OnClear.HasDelegate) await NoticeIcon.OnClear.InvokeAsync(TabKey);
        }

        public async Task HandleViewMore()
        {
            if (OnViewMore.HasDelegate)
                await OnViewMore.InvokeAsync(TabKey);

            if (NoticeIcon.OnViewMore.HasDelegate) await NoticeIcon.OnViewMore.InvokeAsync(TabKey);
        }
    }
}