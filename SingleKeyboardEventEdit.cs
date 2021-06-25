using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YourMouseMaster
{
    public partial class SingleKeyboardEventEdit : Form
    {
        public bool Save = false;
        public SingleEventSimulation Event;
        
        
        public SingleKeyboardEventEdit()
        {
            InitializeComponent();
            InitDesktop();

            if (comboBoxEventTypes.Items.Count > 0)
            {
                comboBoxEventTypes.Text = comboBoxEventTypes.Items[0].ToString();
            }

            if (comboBoxEventNames.Items.Count > 0)
            {
                comboBoxEventNames.Text = comboBoxEventNames.Items[0].ToString();
            }
          
            // new event
            Event = new SingleEventSimulation();
        }

        public SingleKeyboardEventEdit(SingleEventSimulation EditEvent)
        {
            InitializeComponent();
            InitDesktop();

            // edit an existing event

            // event type
            Event = EditEvent;
            
            // event name
            int selectedIndex = ((int)((KEYBOARDEVENT)Event.Event)-1); 
            if (selectedIndex>=Program.EventSim.Keyboard.EventNames.Length)
            {
                // problem
            }
            String selectedName = Program.EventSim.Keyboard.EventNames[selectedIndex];
            comboBoxEventTypes.Text = selectedName;
           
            comboBoxEventNames.Text = Event.EventKey.ToString();
        }

        public void InitDesktop()
        {
            Save = false;

            // fill the key event types
            comboBoxEventTypes.Items.Clear();
            foreach (String single in Program.EventSim.Keyboard.EventNames)
            {
                comboBoxEventTypes.Items.Add(single);
            }


            // fill the key names with all buttons of a keyboard
            comboBoxEventNames.Items.Clear();
            foreach (Keys single in Enum.GetValues(typeof(Keys)))
            {
                comboBoxEventNames.Items.Add(single);
            }
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Event.EventKey = (Keys)Enum.Parse(typeof(Keys), comboBoxEventNames.SelectedItem.ToString());
            }
            catch (Exception exc)
            {
                return;
            }

            try
            {
                Event.Event = (KEYBOARDEVENT)(comboBoxEventTypes.SelectedIndex+1);
               // Event.Event = (KEYBOARDEVENT)Enum.Parse(typeof(KEYBOARDEVENT), comboBoxEventTypes.SelectedItem.ToString());
            }
            catch (Exception exc)
            {
                return;
            }
            


            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}