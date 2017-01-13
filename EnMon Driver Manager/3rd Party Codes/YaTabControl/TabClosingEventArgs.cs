using System;

namespace GrayIris.Utilities.UI.Controls
{
    /// <summary>
    /// A class to contain the information regarding the
    /// <see cref="YaTabControl.TabClosing"/> event.
    /// </summary>
    public class TabClosingEventArgs : EventArgs
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TabClosingEventArgs.Cancel'
        public bool Cancel { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TabClosingEventArgs.Cancel'
    }
}
