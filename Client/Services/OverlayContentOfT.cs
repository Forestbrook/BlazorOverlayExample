using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace BlazorExample.Client.Services
{
    public sealed class OverlayContent<T> : OverlayContent where T : ComponentBase
    {
        public OverlayContent(Action<OverlayContent> closeOverlay)
            : base(closeOverlay)
        {
            Content = CreateContent;
        }

        public override string ComponentTypeName => typeof(T).FullName;

        private void CreateContent(RenderTreeBuilder builder)
        {
            builder.OpenComponent(0, typeof(T));
            builder.AddAttribute(1, nameof(OverlayContent), this);
            builder.CloseComponent();
        }
    }
}
