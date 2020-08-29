using System;
using System.Collections.Generic;

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