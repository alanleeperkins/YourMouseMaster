using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;


namespace YourMouseMaster
{
    public enum MOUSEVENT { LEFTBDOWN = 1, LEFTBUP = 2, RIGHTBDOWN = 3, RIGHTBUP = 4, LEFTBCLICK = 5, RIGHTBCLICK = 6, LEFTBDBLCLICK = 7, RIGHTBDBLCLICK = 8, MIDDLEBCLICK = 9, MIDDLEBDBLCLICK = 10 }; 
  
    public class MouseSimulator
    {
        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public String[] EventNames = { "Mouse-L Down", "Mouse-L Up", "Mouse-R Down", "Mouse-R Up", "Mouse-L Click", "Mouse-R Click", "Mouse-L DoubleClick", "Mouse-R DoubleClick", "Mouse-M Click", "Mouse-M DoubleClick"};

        public EnumStringList EnumStringColl = new EnumStringList();


        private const int MOUSEEVENTF_LEFTDOWN      = 0x0002;
        private const int MOUSEEVENTF_LEFTUP        = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN     = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP       = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN    = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP      = 0x0040;
        private const int MOUSEEVENTF_WHEELMOVE     = 0x0800;
        private const int MOUSEEVENTF_WHEELTILTED   = 0x01000;

        public int MousePositionX;
        public int MousePositionY;

        // constructor
        public MouseSimulator()
        {
            Prepare();
        }

        private void Prepare()
        {
            // make sure the count of the enum is identical with the count of the string names ;-)
            int i = 0;
            foreach (MOUSEVENT singleevent in Enum.GetValues(typeof(MOUSEVENT)))
            {
                EnumStringItem item = new EnumStringItem();
                item.Enumeration = (MOUSEVENT)singleevent;
                item.Name = EventNames[i];

                if (!EnumStringColl.Add(item))
                {
                    // failed
                }
                i++;
            }
        }

        public void SetMousePosition(int X, int Y)
        {
            SetCursorPos(X, Y);
            MousePositionX = X;
            MousePositionY = Y;
        }

        public void DoEvent(MOUSEVENT DoEvent,  int posX,  int posY)
        {
           MouseEventArgs click;
           Cursor.Position = new Point(MousePositionX, MousePositionY);
 
           switch (DoEvent)
           {
               case MOUSEVENT.LEFTBDOWN:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0);
                   mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.RIGHTBDOWN:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Right, 1, Cursor.Position.X, Cursor.Position.Y, 0);
                   mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.LEFTBUP:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.RIGHTBUP:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.LEFTBCLICK:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0);
                   mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.RIGHTBCLICK:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Right, 1, Cursor.Position.X, Cursor.Position.Y, 0);
                   mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.MIDDLEBCLICK:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Middle, 1, Cursor.Position.X, Cursor.Position.Y, 0);
                   mouse_event(MOUSEEVENTF_MIDDLEDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_MIDDLEUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.MIDDLEBDBLCLICK:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Middle, 2, Cursor.Position.X, Cursor.Position.Y, 0);
                   mouse_event(MOUSEEVENTF_MIDDLEDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_MIDDLEUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   // and once again (double)
                   mouse_event(MOUSEEVENTF_MIDDLEDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_MIDDLEUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.LEFTBDBLCLICK:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Left, 2, Cursor.Position.X, Cursor.Position.Y, 0);
                   mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    // and once again (double)
                   mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;

               case MOUSEVENT.RIGHTBDBLCLICK:
                   SetCursorPos(Cursor.Position.X, Cursor.Position.Y);
                   click = new MouseEventArgs(MouseButtons.Right, 2, MousePositionX, MousePositionY, 0);
                   mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   // and once again (double)
                   mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                   break;
           }
        }
    }
}
