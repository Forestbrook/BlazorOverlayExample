using Microsoft.AspNetCore.Components;

namespace BlazorExample.Client.Abstractions
{
    public interface IOverlay
    {
        void Close();
        void Show(RenderFragment content);
    }
}
