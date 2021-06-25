using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace YourMouseMaster
{
    public enum KEYBOARDEVENT { KEYDOWN = 1, KEYUP = 2, KEYTOGGLE = 3 };

    class KeyboardSimulator
    {
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
  
        public String[] EventNames = { "Key Down", "Key Up","Key Toggle" };
        public EnumStringList EnumStringColl = new EnumStringList();
      
        [DllImport("user32.dll")]
        static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);    
     
        
        public KeyboardSimulator()
        {
            Prepare();
        }

        private void Prepare()
        {
            // make sure the count of the enum is identical with the count of the string names ;-)
            int i = 0;
            foreach (KEYBOARDEVENT singleevent in Enum.GetValues(typeof(KEYBOARDEVENT)))
            {
                EnumStringItem item = new EnumStringItem();
                item.Enumeration = (KEYBOARDEVENT)singleevent;
                item.Name = EventNames[i];

                if (!EnumStringColl.Add(item))
                {
                    // failed
                }
                i++;
            }
        }
        public void WriteString(String Output)
        {
            foreach (char sign in Output)
            {
                bool IsUpperSign = false;
                IsUpperSign = char.IsUpper(sign);
                if (IsUpperSign)
                {
                    // push down the left control key for an upper sign
                    DoEvent(KEYBOARDEVENT.KEYDOWN, (System.Windows.Forms.Keys.ShiftKey));
                }
                
                 DoEvent(KEYBOARDEVENT.KEYTOGGLE, (System.Windows.Forms.Keys)char.ToUpper(sign));
                
                if (IsUpperSign)
                {
                    // lift up the left control key to go back to lower sign
                    DoEvent(KEYBOARDEVENT.KEYUP, (System.Windows.Forms.Keys.ShiftKey));
                }
            }
        }


        public void DoEvent(KEYBOARDEVENT DoEvent, System.Windows.Forms.Keys key)
        {
            switch (DoEvent)
            {
                case KEYBOARDEVENT.KEYDOWN:
                    keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    break;

                case KEYBOARDEVENT.KEYUP:
                    keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;

                case KEYBOARDEVENT.KEYTOGGLE:
                    Console.WriteLine("keytoggle");
                    keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
            }
        }
    }
}
