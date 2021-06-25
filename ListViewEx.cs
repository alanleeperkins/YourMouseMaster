using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace YourMouseMaster
{
    class ListViewEx : ListView
    {
        int LastMarkedRow;
        public bool WriteProtection = false;

        ContextMenuStrip ListViewMenu = new ContextMenuStrip();
        public event ListViewMenuItemClickedEventHandler OnListViewMenuItemClicked;

        public ListViewEx()
        {
            LastMarkedRow = -1;
            WriteProtection = false;
            BuildContextMenu();
            ListViewMenu.ItemClicked += new ToolStripItemClickedEventHandler(ListViewMenu_ItemClicked);
        }

        private void BuildContextMenu()
        {
            ListViewMenu.Items.Add("Add before...");
            ListViewMenu.Items.Add("Add after...");
            ListViewMenu.Items.Add("Edit...");
            ListViewMenu.Items.Add("Delete");
        }

        void ListViewMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (SelectedItems.Count <= 0) return;
            if (SelectedItems.Count > 1) return; 


            if (item.Text == "Delete")
            {
                if (OnListViewMenuItemClicked != null)
                {
                    OnListViewMenuItemClicked(this, new ListViewMenuItemClickedEventArgs(SelectedItems[0], ListViewMenuItemClickedEventArgs.ACTION.DELETE));
                }
            }
            else if (item.Text == "Edit...")
            {
                if (OnListViewMenuItemClicked != null)
                {
                    OnListViewMenuItemClicked(this, new ListViewMenuItemClickedEventArgs(SelectedItems[0], ListViewMenuItemClickedEventArgs.ACTION.EDIT));
                }
            }
        }


        protected override void OnItemChecked(ItemCheckedEventArgs e)
        {
            if (WriteProtection) return;
            base.OnItemChecked(e);
        }

        protected override void OnItemMouseHover(ListViewItemMouseHoverEventArgs e)
        {
            if (WriteProtection) return;
            
            base.OnItemMouseHover(e);
        }
 

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (WriteProtection) return;
          
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            if (WriteProtection) return;
                
            base.OnItemCheck(ice);
        }

        protected override void OnClick(EventArgs e)
        {
            if (WriteProtection) return;
                
            base.OnClick(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (WriteProtection) return;

            if (e.Button == MouseButtons.Right)
            {
                if (FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ListViewMenu.Show(Cursor.Position);
                }
            } 
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (WriteProtection) return;
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (WriteProtection) return;
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (WriteProtection) return;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            if (WriteProtection) return;
            base.OnMouseHover(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (WriteProtection) return;
            base.OnMouseUp(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {          
            if (SelectedItems == null) return;
            if (SelectedItems.Count <= 0) return;

            if (WriteProtection) return;

            base.OnDoubleClick(e);
        }

        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            if (WriteProtection){
                if (e.IsSelected)
                {
                    e.Item.Selected = false;
                }
            }
            base.OnItemSelectionChanged(e);
        }

        public void MarkLine(int RowNumber)
        {
            if (Items.Count <= 0) return;
            if ((Items.Count - 1) < RowNumber) return;
            




            if (RowNumber == -1)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Items[i].BackColor = Color.White;
                    Items[i].Selected = false;
                }
                return;
            }
            if (LastMarkedRow >= 0 && ((LastMarkedRow < Items.Count))) Items[LastMarkedRow].BackColor = Color.White;

            LastMarkedRow = RowNumber;
            Items[RowNumber].BackColor = Color.LightSteelBlue;
        }
    }
}
