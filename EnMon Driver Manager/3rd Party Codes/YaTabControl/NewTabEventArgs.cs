using System;
using System.Collections.Generic;
using System.Text;

namespace GrayIris.Utilities.UI.Controls
{

#pragma warning disable CS1574 // XML comment has cref attribute 'NewTab' that could not be resolved
    /// <summary>
    /// A class to contain the information regarding the
    /// <see cref="YaTabControl.NewTab"/> event.
    /// </summary>
    public class NewTabEventArgs : EventArgs
#pragma warning restore CS1574 // XML comment has cref attribute 'NewTab' that could not be resolved
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NewTabEventArgs.NewTabEventArgs(YaTabPage)'
        public NewTabEventArgs(YaTabPage newTab)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NewTabEventArgs.NewTabEventArgs(YaTabPage)'
        {
            NewTab = newTab;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NewTabEventArgs.NewTab'
        public YaTabPage NewTab { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NewTabEventArgs.NewTab'
    }
}
