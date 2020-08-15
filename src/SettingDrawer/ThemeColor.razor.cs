using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public class ColorItem
    {
        public string Key { get; set; }
        public string Color { get; set; }
        public string Theme { get; set; }
    }

    public partial class ThemeColor
    {
        private string _value;
        [Parameter] public ColorItem[] Colors { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public EventCallback<string> OnChange { get; set; }
        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                ValueChanged.InvokeAsync(value);
                
            }
        }


        private async Task HandleClickAsync(string value)
        {
            Value = value;
            if (OnChange.HasDelegate)
            {
                await OnChange.InvokeAsync(value);
            }
        }
    }
}