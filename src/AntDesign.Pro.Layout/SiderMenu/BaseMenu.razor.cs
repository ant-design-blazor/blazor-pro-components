using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    internal interface IBaseMenu : IPureSettings
    {
        string Class { get; }
        bool Collapsed { get; }
        EventCallback<bool> HandleOpenChange { get; }
        bool IsMobile { get; }
        MenuDataItem[] MenuData { get; }
        MenuMode Mode { get; }
        EventCallback<bool> OnCollapse { get; }
        string[] OpenKeys { get; }
        string Style { get; }
        MenuTheme Theme { get; }
    }

    public partial class BaseMenu: IBaseMenu
    {
        public bool Collapsed { get; set; }
        public EventCallback<bool> HandleOpenChange { get; set; }
        public bool IsMobile { get; set; }
        public MenuDataItem[] MenuData { get; set; }
        public MenuMode Mode { get; set; }
        public EventCallback<bool> OnCollapse { get; set; }
        public string[] OpenKeys { get; set; }
        public MenuTheme Theme { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MenuData = new MenuDataItem[]
            {
                new MenuDataItem
                {
                    Name = "Test1",
                    Key = "Test1",
                    Path = "/Test1"
                }, 
            };
        }

        public void SetOpenKeys(string[] args)
        {

        }
    }
}