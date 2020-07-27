namespace AntDesign.Pro.Layout
{
    internal interface ITopNavHeader : ISiderMenu
    {
    }

    public abstract class TopNavHeaderBase : SiderMenuBase, ITopNavHeader
    {

    }

    public partial class TopNavHeader : TopNavHeaderBase
    {
        private readonly string _baseClassName;
    }
}