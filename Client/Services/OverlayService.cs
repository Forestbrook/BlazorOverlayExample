using BlazorExample.Client.Abstractions;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorExample.Client.Services
{
    public class OverlayService : IOverlayService
    {
        private IOverlay _overlay;

        public void Connect(IOverlay overlay)
            => _overlay = overlay;

        public void Disconnect(IOverlay overlay)
        {
            if (_overlay == overlay)
                _overlay = null;
        }

        public void Show<T>() where T : ComponentBase
        {
            if (_overlay == null)
                throw new InvalidOperationException($"No {typeof(IOverlay).FullName} connected to {typeof(OverlayService).FullName}");

            var content = new OverlayContent<T>(_overlay.Close);
            _overlay.Show(content);
        }
    }
}
