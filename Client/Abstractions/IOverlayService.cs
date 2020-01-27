using System;

namespace BlazorExample.Client.Abstractions
{
    public interface IOverlayService
    {
        void Close();
        void Show(Type contentType);
    }
}
