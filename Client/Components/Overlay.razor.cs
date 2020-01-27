using BlazorExample.Client.Abstractions;
using BlazorExample.Client.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorExample.Client.Components
{
    public partial class Overlay : ComponentBase, IOverlay, IDisposable
    {
        private RenderFragment Content { get; set; }

        private bool IsVisible { get; set; }

        [Inject]
        private OverlayService OverlayService { get; set; }

        protected override void OnInitialized()
            => OverlayService.Connect(this);

        public void Show(RenderFragment content)
        {
            Content = content;
            IsVisible = true;
            StateHasChanged();
        }

        public void Close()
        {
            IsVisible = false;
            Content = null;
            StateHasChanged();
        }

        public void Dispose()
            => OverlayService.Disconnect(this);
    }
}
