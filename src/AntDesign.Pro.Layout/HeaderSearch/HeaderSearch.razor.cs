using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class HeaderSearch
    {
        private bool _searchMode = false;
        protected ClassMapper AutoCompleteClassMapper { get; } = new ClassMapper();
        [Parameter] public string DefaultValue { get; set; }
        [Parameter] public string Placeholder { get; set; }
        [Parameter] public EventCallback<bool> OnVisibleChange { get; set; }
        [Parameter] public List<AutoCompleteDataItem<string>> Options { get; set; } = new List<AutoCompleteDataItem<string>>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper.Clear()
                .Add(Class)
                .Add("headerSearch");

            AutoCompleteClassMapper
                .Clear()
                .Add("input")
                .If("show", () => _searchMode);
        }

        private async Task SetSearchMode(bool searchMode)
        {
            _searchMode = searchMode;
            if (OnVisibleChange.HasDelegate)
            {
                await OnVisibleChange.InvokeAsync(_searchMode);
            }
        }
    }
}