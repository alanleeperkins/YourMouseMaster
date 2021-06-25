using System;
using System.Collections.Generic;
using System.Text;

namespace YourMouseMaster
{
    public class SettingsVars
    {
        public bool UseKeyboardSniffer;
        public System.Windows.Forms.Keys ShortKeySimulationToggle;
        public System.Windows.Forms.Keys ShortKeyAddEventMouse;
        public System.Windows.Forms.Keys ShortKeyAddEventKeyboard;

        public SettingsVars()
        {
            UseKeyboardSniffer = true;

            ShortKeyAddEventMouse = System.Windows.Forms.Keys.F1;
            ShortKeyAddEventKeyboard = System.Windows.Forms.Keys.F2;
            ShortKeySimulationToggle = System.Windows.Forms.Keys.F5;
        }
    }
}
