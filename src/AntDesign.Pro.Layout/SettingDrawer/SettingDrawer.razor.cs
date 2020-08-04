using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;

namespace AntDesign.Pro.Layout
{
    public partial class SettingDrawer
    {
        private string PrefixCls => "ant-pro";
        private string BaseClassName => $"{PrefixCls}-setting";
        private bool _show = false;

        private void SetShow(MouseEventArgs args)
        {
            _show = !_show;
        }
    }
}