using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace YourMouseMaster
{
 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ListViewMenuItemClickedEventHandler
        public delegate void ListViewMenuItemClickedEventHandler(object source, ListViewMenuItemClickedEventArgs e);

        public class ListViewMenuItemClickedEventArgs : EventArgs
        {
            public enum ACTION { DELETE, EDIT };

            private ACTION EventAction;
            private ListViewItem EventItem;

            public ListViewMenuItemClickedEventArgs(ListViewItem Item,ACTION action)
            {
                EventItem = Item;
                EventAction = action;
            }
            public ListViewItem GetItem()
            {
                return EventItem;
            }
            public ACTION GetAction()
            {
                return EventAction;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       

}
