using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class RightContent
    {
        private List<AutoCompleteDataItem> DefaultOptions { get; set; } = new List<AutoCompleteDataItem>
        {
            new AutoCompleteDataItem
            {
                Label = "umi ui",
                Value = "umi ui"
            },
            new AutoCompleteDataItem
            {
                Label = "Pro Table",
                Value = "Pro Table"
            },
            new AutoCompleteDataItem
            {
                Label = "Pro Layout",
                Value = "Pro Layout"
            }
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