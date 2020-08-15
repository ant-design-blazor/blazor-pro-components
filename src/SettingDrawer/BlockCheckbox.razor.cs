using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AntDesign.Pro.Layout
{
    public class CheckboxItem
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
    }

    public partial class BlockCheckbox
    {
        private string _value;
        private string BaseClassName => $"{PrefixCls}-drawer-block-checkbox";
        [Parameter] public string PrefixCls { get; set; } = "ant-pro";
        [Parameter] public CheckboxItem[] List { get; set; }
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