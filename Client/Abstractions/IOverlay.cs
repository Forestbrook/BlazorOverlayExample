using BlazorExample.Client.Services;

namespace BlazorExample.Client.Abstractions
{
    public interface IOverlay
    {
        void Close(OverlayContent overlayContent);
        void Show(OverlayContent overlayContent);
    }
}
