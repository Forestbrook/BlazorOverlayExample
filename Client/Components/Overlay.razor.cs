using BlazorExample.Client.Abstractions;
using BlazorExample.Client.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorExample.Client.Components
{
    public partial class Overlay : ComponentBase, IOverlay, IDisposable
    {
        private RenderFragment Content => OverlayContent?.Content;

        private bool IsVisible { get; set; }

        private OverlayContent OverlayContent { get; set; }

        [Inject]
        private OverlayService OverlayService { get; set; }

        protected override void OnInitialized()
            => OverlayService.Connect(this);

        public void Show(OverlayContent overlayContent)
        {
            if (OverlayContent != null)
                throw new InvalidOperationException($"Show {overlayContent.ComponentTypeName} while {OverlayContent.ComponentTypeName} not yet closed.");

            OverlayContent = overlayContent;
            IsVisible = true;
            StateHasChanged();
        }

        public void Close()
            => OverlayContent?.Close();

        public void Close(OverlayContent overlayContent)
        {
            // Check for already closed:
            if (overlayContent != OverlayContent)
                return;

            OverlayContent = null;
            IsVisible = false;
            StateHasChanged();
        }

        public void Dispose()
        {
            OverlayService.Disconnect(this);
            var overlayContent = OverlayContent;
            OverlayContent = null;
            overlayContent?.Close();
        }
    }
}
