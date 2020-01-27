﻿using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorExample.Client.Services
{
    public abstract class OverlayContent
    {
        protected OverlayContent(Action<OverlayContent> closeOverlay)
        {
            CloseOverlay = closeOverlay;
        }

        public event EventHandler Closed;

        public abstract string ComponentTypeName { get; }

        public RenderFragment Content { get; protected set; }

        public bool IsClosed { get; private set; }

        private Action<OverlayContent> CloseOverlay { get; }

        public void Close()
        {
            if (IsClosed)
                return;

            IsClosed = true;
            Content = null;
            CloseOverlay(this);
            Closed?.Invoke(this, EventArgs.Empty);
        }

        public async Task CloseWhenFinished(Task task)
        {
            // TODO: Check for TaskCanceledException?
            await task;
            Close();
        }
    }
}
