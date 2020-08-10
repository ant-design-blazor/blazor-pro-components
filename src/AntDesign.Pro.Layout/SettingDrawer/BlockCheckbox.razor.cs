using System;
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
        private string BaseClassName => $"{PrefixCls}-drawer-block-checkbox";
        [Parameter] public string PrefixCls { get; set; } = "ant-pro";
        [Parameter] public string Value { get; set; }
        [Parameter] public CheckboxItem[] List { get; set; }
        [Parameter] public EventCallback<string> OnChange { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Console.WriteLine(Value);
        }

        private async Task HandleOnClick(MouseEventArgs args, CheckboxItem item)
        {
            Value = item.Key;
            if (OnChange.HasDelegate)
            {
                await OnChange.InvokeAsync(item.Key);
            }
        }
    }
}