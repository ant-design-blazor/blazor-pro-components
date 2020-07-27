using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public abstract class AntProLayoutBase: AntProComponentBase
    {
        internal const string BodyPropertyName = "Body";

        [Parameter]
        public RenderFragment Body { get; set; }
    }
}
