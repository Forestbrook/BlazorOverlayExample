using Microsoft.AspNetCore.Components;

namespace BlazorExample.Client.Abstractions
{
    public interface IOverlayService
    {
        void Show<T>() where T : ComponentBase;
    }
}
