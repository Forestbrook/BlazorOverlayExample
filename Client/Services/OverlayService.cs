using BlazorExample.Client.Abstractions;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorExample.Client.Services
{
    public class OverlayService : IOverlayService
    {
        private IOverlay _overlay;

        public void Close()
            => _overlay?.Close();

        public void Connect(IOverlay overlay)
            => _overlay = overlay;

        public void Disconnect(IOverlay overlay)
        {
            if (_overlay == overlay)
                _overlay = null;
        }

        public void Show(Type contentType)
        {
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));

            if (_overlay == null)
                throw new InvalidOperationException($"No {typeof(IOverlay).FullName} connected to {typeof(OverlayService).FullName}");

            if (!contentType.IsDerivedFrom(typeof(ComponentBase)))
                throw new ArgumentException($"{contentType.FullName} must have base type {typeof(ComponentBase).FullName}");

            var content = new RenderFragment(t => { t.OpenComponent(1, contentType); t.CloseComponent(); });
            _overlay.Show(content);
        }
    }
}
