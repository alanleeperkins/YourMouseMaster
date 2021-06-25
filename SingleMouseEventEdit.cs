using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YourMouseMaster
{   
    public partial class SingleMouseEventEdit : Form
    {
        public bool Save = false;
        public SingleEventSimulation Event;

        public SingleMouseEventEdit()
        {
            InitializeComponent();
            InitDesktop();
            
            // show the last set mouse position
            UpdateMousePosition(Program.EventSim.Mouse.MousePositionX, Program.EventSim.Mouse.MousePositionY);

            // new event
            Event = new SingleEventSimulation();
        }

        public SingleMouseEventEdit(SingleEventSimulation EditEvent)
        {
            InitializeComponent();
            InitDesktop();

            // edit an existing event

            // event type
            Event = EditEvent;
            
            // event name
            int selectedIndex = ((int)((MOUSEVENT)Event.Event)-1); 
            if (selectedIndex>=Program.EventSim.Mouse.EventNames.Length)
            {
                // problem
            }
            String selectedName = Program.EventSim.Mouse.EventNames[selectedIndex];
            comboBoxEventNames.SelectedIndex = GetComboBoxEventNameIndex(selectedName);
            
            // mouse position
            UpdateMousePosition(Event.PositionX, Event.PositionY);
        }

        public void InitDesktop()
        {
            Save = false;

            // fill the event names
            foreach (String name in Program.EventSim.Mouse.EventNames)
            {
                comboBoxEventNames.Items.Add(name);
            }
        }

        public int GetComboBoxEventNameIndex(String EventName)
        {
            for (int i = 0; i < comboBoxEventNames.Items.Count; i++)
            {
                if (comboBoxEventNames.Items[i].ToString() == EventName)
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateMousePosition()
        {
            Program.EventSim.Mouse.SetMousePosition(Cursor.Position.X, Cursor.Position.Y);
            labelEventCoordsValue.Text = String.Format("X={0:0000} Y={1:0000}", Cursor.Position.X, Cursor.Position.Y);
        }

        public void UpdateMousePosition(int posX, int posY)
        {
            Program.EventSim.Mouse.SetMousePosition(posX, posY);
            labelEventCoordsValue.Text = String.Format("X={0:0000} Y={1:0000}", posX, posY);
        }

        public void UpdateSingleEvent()
        {
            if (comboBoxEventNames.SelectedIndex < 0) return; 

            EnumStringItem FoundItem = new EnumStringItem();
            if (!Program.EventSim.Mouse.EnumStringColl.FindByName(comboBoxEventNames.SelectedItem.ToString(), ref FoundItem))
            {

            }
            Event.Event = (MOUSEVENT)FoundItem.Enumeration; 
            
            Event.SimulationType = SIMTYPE.MOUSE;
            Event.PositionX = Program.EventSim.Mouse.MousePositionX;
            Event.PositionY = Program.EventSim.Mouse.MousePositionY;
            Save = true;
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            // OK
            UpdateSingleEvent();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SingleEventEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p')
            {
                UpdateMousePosition();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Space))
            {

            }
        }    
    }
}