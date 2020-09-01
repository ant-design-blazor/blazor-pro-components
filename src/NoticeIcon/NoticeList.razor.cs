using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace AntDesign.Pro.Layout
{
    public partial class NoticeList
    {
        [Parameter] public string EmptyText { get; set; }
        [Parameter] public ICollection<NoticeIconData> Data { get; set; }
        [Parameter] public bool ShowClear { get; set; }
        [Parameter] public bool ShowViewMore { get; set; }
        [Parameter] public EventCallback OnClear { get; set; }
        [Parameter] public EventCallback OnViewMore { get; set; }
        [Parameter] public string ClearText { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string ViewMoreText { get; set; }
    }
}