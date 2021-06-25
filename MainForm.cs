using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace YourMouseMaster
{
    internal delegate void SafeUpdateDelegate();

    public partial class MainForm : Form
    {
        Collection<SingleEventSimulation> TempSingleEvent = new Collection<SingleEventSimulation>();

        public enum SingleEventListColumn : int
        {
            NUMBER = 0,
            SIMTYPE = 1,
            EVENTTYPE = 2,
            MOUSECOORDX = 3,
            MOUSECOORDY = 4,
            KEYCODE     = 5
        }

        int StandardSingleEventDelay;       
        int StandartStopByTime;             
        int StandartStopByIteration;

        private SafeUpdateDelegate EventKeyboardSnifferTimerHandler;
        private System.Timers.Timer KeyboardSnifferTimer;

        private SafeUpdateDelegate EventCursorPositionTimerHandler;
        private System.Timers.Timer CursorPositionTimer;
     
        private SafeUpdateDelegate EventSimTimerEventHandler;
        private System.Timers.Timer EventSimTimer;

        private SimulationInfo SimInfo = new SimulationInfo();

        int currentEventPointer = 0;

        bool IsRunning = false;

        int SingleEventListMinWidth = 0;
        int SingleEventListMinHeight = 0;
        int MainWindowMinWidth = 0;
        int MainWindowMinHeight = 0;

        public MainForm()
        {
            InitializeComponent();

            // standard settings
            GetStandardSettings();
            GetUserSettings();

            PrepareForm();

            Text = String.Format("{0} ({1})","YMM", Application.ProductVersion);
        }

        /// <summary>
        /// prepares the form1 window
        /// </summary>
        private void PrepareForm()
        {
            SingleEventListMinHeight = listViewSingleEvents.Height;
            SingleEventListMinWidth = listViewSingleEvents.Width;

            MainWindowMinWidth = Width;
            MainWindowMinHeight = Height;
            Rectangle ScreenSol = Screen.FromControl(this).Bounds;

            MaximumSize = new Size(MainWindowMinWidth, ScreenSol.Height);

            listViewSingleEvents.OnListViewMenuItemClicked += new ListViewMenuItemClickedEventHandler(listViewSingleEvents_OnListViewMenuItemClicked);

            EventSimTimerEventHandler = new SafeUpdateDelegate(EventSimTimerEvent);
            EventSimTimer = new System.Timers.Timer();
            EventSimTimer.Elapsed += new ElapsedEventHandler(OnEventSimTimerEvent);

            EventCursorPositionTimerHandler = new SafeUpdateDelegate(EventCursorPositionTimer);
            CursorPositionTimer = new System.Timers.Timer(200);
            CursorPositionTimer.Elapsed += new ElapsedEventHandler(OnEventCursorPositionTimer);
            CursorPositionTimer.Start();

            EventKeyboardSnifferTimerHandler = new SafeUpdateDelegate(EventKeyboardSnifferTimer);
            KeyboardSnifferTimer = new System.Timers.Timer(100);
            KeyboardSnifferTimer.Elapsed += new ElapsedEventHandler(OnKeyboardSnifferTimer);
            KeyboardSnifferTimer.Start();

            // Single Event Dalay (ms)
            numericUpDownSingleEventDelay.Value = StandardSingleEventDelay;

            // stop after time
            //numericUpDownStopByTime.SetUnit("ms");
            numericUpDownStopByTime.Value = StandartStopByTime;

            // stop after iteration
            numericUpDownStopByIteration.SetUnit("iteration", "iterations");
            numericUpDownStopByIteration.Value = StandartStopByIteration;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // fill the mouse event names
            foreach (String name in Program.EventSim.Mouse.EventNames)
            {
                toolStripDropDownButtonSelectedMouseEvent.DropDown.Items.Add(name);
            }

            if (toolStripDropDownButtonSelectedMouseEvent.DropDown.Items.Count > 0)
            {
                toolStripDropDownButtonSelectedMouseEvent.Text = toolStripDropDownButtonSelectedMouseEvent.DropDown.Items[0].ToString();
                UpdateSelectedEditEvent();
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // fill the keyboard event names
            foreach (String name in Program.EventSim.Keyboard.EventNames)
            {
                toolStripDropDownButtonKeyboardEvent.DropDown.Items.Add(name);
            }
            if (toolStripDropDownButtonKeyboardEvent.DropDown.Items.Count > 0)
            {
                toolStripDropDownButtonKeyboardEvent.Text = toolStripDropDownButtonKeyboardEvent.DropDown.Items[0].ToString();
                UpdateSelectedEditEvent();
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            comboBoxStopByTimeTimeUnits.Items.Clear();
            comboBoxSingleEventDelaysTimeUnits.Items.Clear();
            foreach (TIMEUNITS foo in Enum.GetValues(typeof(TIMEUNITS)))
            {
                comboBoxStopByTimeTimeUnits.Items.Add(foo.ToString());
                comboBoxSingleEventDelaysTimeUnits.Items.Add(foo.ToString());

            }
            comboBoxStopByTimeTimeUnits.SelectedIndex = 0;
            comboBoxSingleEventDelaysTimeUnits.SelectedIndex = 0;

            UpdateSimulationInfo(false);
        }

        /// <summary>
        /// the event of the menustrip located in the SingleEventsListView
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        void listViewSingleEvents_OnListViewMenuItemClicked(object source, ListViewMenuItemClickedEventArgs e)
        {
            ListViewItem selectedItem = e.GetItem();
            ListViewMenuItemClickedEventArgs.ACTION ItemAction = e.GetAction();
        
            switch (ItemAction)
            {
                case ListViewMenuItemClickedEventArgs.ACTION.EDIT:
                    SingleEventSimulation SelectedEvent = ConvertListViewItemToEvent(selectedItem);
                    EditEvent(selectedItem.Index, SelectedEvent);
                    break;

                case ListViewMenuItemClickedEventArgs.ACTION.DELETE:
                    DeleteEvent(selectedItem.Index);
                    break;
            }
        }

        /// <summary>
        /// Loads the Standard Settings
        /// </summary>
        private void GetStandardSettings()
        {
            StandardSingleEventDelay = 2000;        // delay in ms
            StandartStopByTime = 10000;             // stop after 10 seconds
            StandartStopByIteration = 1;             // stop after 1 iteration

            radioButtonStopByIteration.Checked = true;
            radioButtonStopByTime.Checked = false;

        }

        /// <summary>
        /// Loads the user-specified settings
        /// </summary>
        private void GetUserSettings()
        {
            Program.EventSim.EditorAddMouseEventKey = Program.GlobalSettings.Vars.ShortKeyAddEventMouse;
            Program.EventSim.EditorAddKeyboardEventKey = Program.GlobalSettings.Vars.ShortKeyAddEventKeyboard;
            Program.EventSim.ToggleSimulationKey = Program.GlobalSettings.Vars.ShortKeySimulationToggle;
            toolStripStatusLabelKeyInfo.Text = String.Format("KeyInfo: 'Add Mouse' = {0} | 'Add Key' = {1} | 'Toggle Sim' = {2}", Program.EventSim.EditorAddMouseEventKey.ToString(), Program.EventSim.EditorAddKeyboardEventKey.ToString(), Program.EventSim.ToggleSimulationKey.ToString());
        }

        /// <summary>
        /// goes to the next events
        /// </summary>
        private void DoNextEvent()
        {
            listViewSingleEvents.MarkLine(currentEventPointer);
    
            //Program.EventSim.Mouse.SetMousePosition(Program.EventSim.EventCollection[currentEventPointer].PositionX, Program.EventSim.EventCollection[currentEventPointer].PositionY);
            //Program.EventSim.Mouse.DoEvent((MOUSEVENT)Program.EventSim.EventCollection[currentEventPointer].Event, 0, 0);
            Program.EventSim.DoSimulation(Program.EventSim.EventCollection[currentEventPointer]);
            SimInfo.StepsCounter++;
            currentEventPointer++;
            if (currentEventPointer >= Program.EventSim.EventCollection.Count)
            {
                // All events to -> one iteration completed
                //StopSimulation();
                //return;
                //Console.WriteLine("new iteration");
                
                currentEventPointer = 0;
                SimInfo.IterationCounter++;
            }

            if (Program.EventSim.CounterType == COUNTERTYPE.ITERATIONS)
            {
                // stop after max iterations arrived
                if (SimInfo.IterationCounter >= SimInfo.MaxIterations)
                {
                    StopSimulation();
                    return;
                }
            }
            else if (Program.EventSim.CounterType == COUNTERTYPE.STEPS)
            {
                // stop after max steps arrived
                /*
                if(SimInfo.StepsCounter >= SimInfo.MaxSteps ) 
                {
                    StopSimulation();
                    return;
                }
                */
            }
            else if (Program.EventSim.CounterType == COUNTERTYPE.TOGGLEBUTTON) 
            {

            }
        }

        /// <summary>
        /// gets called after one key has been pressed (normal/system/function)
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // listen to only one : the global key sniffer or the local form keypress 
            if (!Program.GlobalSettings.Vars.UseKeyboardSniffer)
            {
                if (keyData == Program.EventSim.EditorAddMouseEventKey)
                {
                    Console.WriteLine("Form1_KeyPress: AddNewEvent (Mouse)");
                    AddNewEvent(SIMTYPE.MOUSE);
                }
                else if (keyData == Program.EventSim.EditorAddKeyboardEventKey)
                {
                    Console.WriteLine("Form1_KeyPress: AddNewEvent (Keyboard)");
                    AddNewEvent(SIMTYPE.KEYBOARD);
                }
                else if (keyData == Program.EventSim.ToggleSimulationKey)
                {
                    Console.WriteLine("Form1_KeyPress: ToogleSimulation");
                    ToogleSimulation();
                }
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Function called by the Event for the KeyboardSniffer Timer
        /// </summary>
        private void EventKeyboardSnifferTimer()
        {
            if (Program.GlobalSettings.Vars.UseKeyboardSniffer)
            {
                if (Program.KeySniffer.IsKeyPressed((KeyboardSniffer.VirtualKeyStates)Program.EventSim.ToggleSimulationKey))
                {
                    if (Program.KeySniffer.PressedSniffedKey == Keys.None)
                    {
                        Program.KeySniffer.PressedSniffedKey = Program.EventSim.ToggleSimulationKey;
                        Console.WriteLine("EventKeyboardSnifferTimer: Toggle");
                        ToogleSimulation();
                    }
                }
                else if (Program.KeySniffer.IsKeyPressed((KeyboardSniffer.VirtualKeyStates)Program.EventSim.EditorAddMouseEventKey))
                {
                    if (Program.KeySniffer.PressedSniffedKey == Keys.None)
                    {
                        Console.WriteLine("EventKeyboardSnifferTimer: EditorAddMouseEventKey");
                        Program.KeySniffer.PressedSniffedKey = Program.EventSim.EditorAddMouseEventKey;
                        AddNewEvent(SIMTYPE.MOUSE);
                    }
                }
                else if (Program.KeySniffer.IsKeyPressed((KeyboardSniffer.VirtualKeyStates)Program.EventSim.EditorAddKeyboardEventKey))
                {
                    if (Program.KeySniffer.PressedSniffedKey == Keys.None)
                    {
                        Console.WriteLine("EventKeyboardSnifferTimer: EditorAddKeyboardEventKey");
                        Program.KeySniffer.PressedSniffedKey = Program.EventSim.EditorAddKeyboardEventKey;
                        AddNewEvent(SIMTYPE.KEYBOARD);
                    }
                }
                else
                {
                    // no user-specified key pressed
                    Program.KeySniffer.PressedSniffedKey = Keys.None;
                }
            }
            else
            {
                // wait for the Form Key_Down event
            }
        }
        /// <summary>
        /// Event for the KeyboardSniffer Timer, which calles the EventKeyboardSnifferTimer Function
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnKeyboardSnifferTimer(object source, ElapsedEventArgs e)
        {
            try
            {
                this.Invoke(this.EventKeyboardSnifferTimerHandler);
            }
            catch (Exception exc)
            {

            }
        }
        
        /// <summary>
        /// Function called by the Event for the EventCursorPosition-Timer
        /// </summary>
        private void EventCursorPositionTimer()
        {          
            // update mouse position info
            toolStripStatusLabelMouseCoords.Text = String.Format("X={0:0000} Y={1:0000}", Cursor.Position.X, Cursor.Position.Y);
            Program.EventSim.EditorSelectedEvent.PositionX = Cursor.Position.X;
            Program.EventSim.EditorSelectedEvent.PositionY = Cursor.Position.Y;

        }

        /// <summary>
        /// Event for the EventCursorPosition Timer, which calles the EventCursorPositionTimer Function
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnEventCursorPositionTimer(object source, ElapsedEventArgs e)
        {
            try
            {
                this.Invoke(this.EventCursorPositionTimerHandler);
            }
            catch (Exception exc)
            {

            }
        }

        /// <summary>
        /// Function called by the Event for the EventSimTimer
        /// </summary>
        private void EventSimTimerEvent()
        {
            if (Program.EventSim.CounterType == COUNTERTYPE.TIME)
            {
                if (SimInfo.SimStopWatch.IsRunning && (SimInfo.SimStopWatch.ElapsedMilliseconds >= SimInfo.MaxMilliseconds))
                {
                    UpdateSimulationInfo(true);
                    StopSimulation();
                    return;
                }
            }
            DoNextEvent();
            UpdateSimulationInfo(true);
        }

        /// <summary>
        /// Event for the EventSimTimer, which calles the EventSimTimerEvent Function
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnEventSimTimerEvent(object source, ElapsedEventArgs e)
        {
            this.Invoke(this.EventSimTimerEventHandler);
        }

        /// <summary>
        /// Prepares the Event Collection, fills the EventList with all Items found in the SingleEvents-ListView
        /// </summary>
        /// <returns></returns>
        public bool PrepareEventCollection()
        {
            // no events
            if (listViewSingleEvents.Items.Count <= 0) return false;
         
            // remove the old events
            Program.EventSim.ClearEvents();
           
            foreach (ListViewItem item in listViewSingleEvents.Items)
            {
                SingleEventSimulation newEvent = ConvertListViewItemToEvent(item);
                Program.EventSim.AddEvent(newEvent);
            }

            return true;
        }

        /// <summary>
        /// Toggles the Simulation
        /// </summary>
        public void ToogleSimulation()
        {
            if (IsRunning)
            {
                // stop it
                StopSimulation();
            }
            else
            {
                // start it
                StartSimulation();
            }
        }

        /// <summary>
        /// Stops the Simulation
        /// </summary>
        /// <returns></returns>
        private bool StopSimulation()
        {
            IsRunning = false;
            EventSimTimer.Stop();
            SimInfo.SimStopWatch.Stop();
            Console.WriteLine("Simulation Stop");
            
            FreezeInput(false);

            // unselectd all items
            listViewSingleEvents.MarkLine(-1);
            
            /*
            // TEST START
            SingleEventSimulation Bla = new SingleEventSimulation();
            Bla.SimulationType = SIMTYPE.KEYBOARD;
            Bla.KeyboardOutput = "What a fuck is that?";
            Program.EventSim.DoSimulation(Bla);
            // TEST END
            */

            try
            {
                NotifyIcon SimulationNotifier = new NotifyIcon();
                SimulationNotifier.BalloonTipText = "Simulation finished!";
                SimulationNotifier.BalloonTipTitle = "Your Mouse Master";
                String IconPath = String.Format("{0}\\images.ico", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                SimulationNotifier.Icon = new Icon(IconPath);
                SimulationNotifier.Visible = true;
                SimulationNotifier.ShowBalloonTip(5000); 
            }catch (Exception exc) {

            }

            return true;
        }

        /// <summary>
        /// Starts the Simulation
        /// </summary>
        /// <returns></returns>
        private bool StartSimulation()
        {
            if (!PrepareEventCollection()) return false;

            listViewSingleEvents.SelectedItems.Clear();
            groupBoxInfo.Focus(); // get the focus out of the listview 

            FreezeInput(true);

            UpdateSimulationInfo(false); // reset
            Console.WriteLine("Simulation Start");

            double Interval = (int)Program.ConvertTime(Convert.ToDouble(numericUpDownSingleEventDelay.Value),
                                     (TIMEUNITS)Enum.Parse(typeof(TIMEUNITS),
                                     comboBoxSingleEventDelaysTimeUnits.SelectedItem.ToString()),
                                     TIMEUNITS.ms);// user spec. single event delay
                
            EventSimTimer.Interval = Interval;   // single event delay in ms
            EventSimTimer.Start();

            currentEventPointer = 0;
            IsRunning = true;

            // reset the simulation info values
            SimInfo.Reset();

            // set the max values
            SimInfo.MaxIterations = Decimal.ToInt32( numericUpDownStopByIteration.Value );
            SimInfo.MaxMilliseconds = (int)Program.ConvertTime(Convert.ToDouble(numericUpDownStopByTime.Value),
                                     (TIMEUNITS)Enum.Parse(typeof(TIMEUNITS),
                                     comboBoxStopByTimeTimeUnits.SelectedItem.ToString()),
                                     TIMEUNITS.ms);

            SimInfo.MaxSteps = -1;//Decimal.ToInt32( numericUpDownStopByStep.Value );

            //////////////////////////////////////////////////////////////////////////////////
            // start
            SimInfo.SimStopWatch.Start();

            // start with the first event
            DoNextEvent();

            return true;
        }

        /// <summary>
        /// disables the input fields during a running simulation
        /// </summary>
        /// <param name="freeze"></param>
        public void FreezeInput(bool freeze)
        {
            groupBoxSimulationSettings.Enabled = !freeze;
            listViewSingleEvents.WriteProtection = freeze;

            toolStripMenuItemFile.Enabled = !freeze;
            toolStripMenuItemSingleEventList.Enabled = !freeze;
            toolStripMenuItemTemplates.Enabled = !freeze;
        }

        /// <summary>
        /// Updates or clears the current simulation info fields
        /// </summary>
        /// <param name="Update">true= shows the current values / false=clears all simulation info fields</param>
        public void UpdateSimulationInfo(bool Update)
        {
            if (Update)
            {
                labelElapsedTime.Text = String.Format("Elapsed Time: {0}", Program.GetTimeString(SimInfo.SimStopWatch.ElapsedMilliseconds));
                SimInfo.MillisecondsCounter += SimInfo.SimStopWatch.ElapsedMilliseconds;
                labelElapsedIterations.Text = String.Format("Iterations: {0}", (SimInfo.IterationCounter));
                labelElapsedEvents.Text = String.Format("Events: {0}", (SimInfo.StepsCounter));                
                
            }
            else
            {
                labelElapsedTime.Text = "Elapsed Time: --:--:--";
                labelElapsedIterations.Text = "Iterations: -";
                labelElapsedEvents.Text = "Events: -";
            }
        }

        /// <summary>
        /// Clears the List of Single events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearSingleEvents_Click(object sender, EventArgs e)
        {
            listViewSingleEvents.Items.Clear();
        }

        /// <summary>
        /// Converts an SingleEventSimulation Event to an ListViewItem
        /// </summary>
        /// <param name="SingleEvent"></param>
        /// <returns></returns>
        public ListViewItem ConvertEventToListViewItem(SingleEventSimulation SingleEvent)
        {
            ListViewItem item = new ListViewItem();
            int eventID = -1;
            try
            {
                switch (SingleEvent.SimulationType)
                {
                    case SIMTYPE.MOUSE:
                        // ID
                        item.Text = ((int)(listViewSingleEvents.Items.Count + 1)).ToString();
                        // Type
                        item.SubItems.Add(SingleEvent.SimulationType.ToString());
                        // Event
                        eventID = ((int)((MOUSEVENT)SingleEvent.Event) - 1);
                        item.SubItems.Add(Program.EventSim.Mouse.EventNames[eventID]);
                        // XPos
                        item.SubItems.Add(SingleEvent.PositionX.ToString());
                        // YPos
                        item.SubItems.Add(SingleEvent.PositionY.ToString());
                        // Key
                        item.SubItems.Add("");
                        break;

                    case SIMTYPE.KEYBOARD:
                        // ID
                        item.Text = ((int)(listViewSingleEvents.Items.Count + 1)).ToString();
                        // Type
                        item.SubItems.Add(SingleEvent.SimulationType.ToString());
                        // Event
                        eventID = ((int)((KEYBOARDEVENT)SingleEvent.Event) - 1);
                        item.SubItems.Add(Program.EventSim.Keyboard.EventNames[eventID]);
                        // XPos
                        item.SubItems.Add(Program.EventSim.Mouse.MousePositionX.ToString());
                        // YPos
                        item.SubItems.Add(Program.EventSim.Mouse.MousePositionY.ToString());
                        // Key
                        item.SubItems.Add(SingleEvent.EventKey.ToString());
                        break;
                }

            }catch (Exception exc) {

            }
 
            return item;
        }

        /// <summary>
        /// Converts a ListViewItem to an SingleEventSimulation Event
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public SingleEventSimulation ConvertListViewItemToEvent(ListViewItem item)
        {
            EnumStringItem FoundItem = new EnumStringItem();
            SingleEventSimulation newEvent = new SingleEventSimulation();
            String SimType = item.SubItems[(int)SingleEventListColumn.SIMTYPE].Text.ToString();

            try
            {
                newEvent.SimulationType = (SIMTYPE)Enum.Parse(typeof(SIMTYPE), SimType);
                switch (newEvent.SimulationType)
                {
                    case SIMTYPE.MOUSE:
                        if (!Program.EventSim.Mouse.EnumStringColl.FindByName(item.SubItems[(int)SingleEventListColumn.EVENTTYPE].Text, ref FoundItem))
                        {

                        }

                        newEvent.Event = (MOUSEVENT)FoundItem.Enumeration;
                        break;
                    case SIMTYPE.KEYBOARD:
                        if (!Program.EventSim.Keyboard.EnumStringColl.FindByName(item.SubItems[(int)SingleEventListColumn.EVENTTYPE].Text, ref FoundItem))
                        {

                        }

                        newEvent.Event = (KEYBOARDEVENT)FoundItem.Enumeration;
                        break;
                    case SIMTYPE.GESTURE:
                        /*
                        if (!Program.EventSim.Mouse.EnumStringColl.FindByName(item.SubItems[(int)SingleEventListColumn.KEYCODE].Text, ref FoundItem))
                        {

                        }

                        newEvent.Event = (MOUSEVENT)FoundItem.Enumeration;
                        */
                        break;
                }
            }
            catch (Exception exc)
            {

            }

            try
            {
                newEvent.PositionX = int.Parse(item.SubItems[(int)SingleEventListColumn.MOUSECOORDX].Text);
            }
            catch (Exception exc)
            {
                return null;
            }

            try
            {
                newEvent.PositionY = int.Parse(item.SubItems[(int)SingleEventListColumn.MOUSECOORDY].Text);
            }
            catch (Exception exc)
            {
                return null;
            }

            try
            {
                
                String Key = item.SubItems[(int)SingleEventListColumn.KEYCODE].Text;

                newEvent.EventKey = (Keys)Enum.Parse(typeof(Keys), Key);
            }
            catch (Exception exc)
            {
            }

            return newEvent;
        }

        /// <summary>
        /// Opens the Edit-Window for the Item at the given position
        /// </summary>
        /// <param name="ItemPosition"></param>
        /// <param name="selectedEvent"></param>
        public void EditEvent(int ItemPosition,SingleEventSimulation selectedEvent)
        {
            bool saveChangedEvent = false;

            switch (selectedEvent.SimulationType)
            {
                case SIMTYPE.MOUSE:
                    SingleMouseEventEdit MouseEditor = null;
                    MouseEditor = new SingleMouseEventEdit(selectedEvent);
                    if (MouseEditor.ShowDialog() == DialogResult.OK)
                    {
                        saveChangedEvent = true;
                    }
                    break;

                case SIMTYPE.KEYBOARD:
                    SingleKeyboardEventEdit KeyEditor = null;
                    KeyEditor = new SingleKeyboardEventEdit(selectedEvent);
                    if (KeyEditor.ShowDialog() == DialogResult.OK)
                    {
                        saveChangedEvent = true;
                    }
                    break;
            }

            if (saveChangedEvent)
            {
                UpdateSingleEventInList(ItemPosition, selectedEvent);
            }
         
            
        }

        /// <summary>
        /// Removes the Item at the given positon
        /// </summary>
        /// <param name="ItemPosition"></param>
        public void DeleteEvent(int ItemPosition)
        {
            listViewSingleEvents.Items.RemoveAt(ItemPosition);
        }

        /// <summary>
        /// Updates and Item at the given position
        /// </summary>
        /// <param name="ItemPosition"></param>
        /// <param name="SingleEvent"></param>
        public void UpdateSingleEventInList(int ItemPosition, SingleEventSimulation SingleEvent)
        {
            ListViewItem item = ConvertEventToListViewItem(SingleEvent);
            item.Text = ((int)(ItemPosition+1)).ToString();
            listViewSingleEvents.Items[ItemPosition] = item;
        }

        /// <summary>
        /// Insert an Item at the End of the list
        /// </summary>
        /// <param name="SingleEvent"></param>
        public void InsertSingleEventToList(SingleEventSimulation SingleEvent)
        {
            ListViewItem item = ConvertEventToListViewItem(SingleEvent);
            listViewSingleEvents.Items.Add(item);
            listViewSingleEvents.Items[listViewSingleEvents.Items.Count - 1].EnsureVisible();
        }

        /// <summary>
        /// Open an Item for Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewSingleEvents_DoubleClick(object sender, EventArgs e)
        {
            SingleEventSimulation SelectedEvent = ConvertListViewItemToEvent(listViewSingleEvents.SelectedItems[0]);          
            EditEvent(listViewSingleEvents.SelectedItems[0].Index,SelectedEvent);
        }

        /// <summary>
        /// stop/start toggle with the toggle button or the specified toggle key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonNonStop_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStopByTime.Enabled = !radioButtonNonStop.Checked;
            groupBoxStopByIteration.Enabled = !radioButtonNonStop.Checked;
            if (radioButtonNonStop.Enabled)
            {
                Program.EventSim.CounterType = COUNTERTYPE.TOGGLEBUTTON;
            }
        }

        /// <summary>
        /// stop criteria is the time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonStopByTime_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStopByTime.Enabled = !radioButtonStopByIteration.Checked;
            groupBoxStopByIteration.Enabled = radioButtonStopByIteration.Checked;
            if (groupBoxStopByTime.Enabled)
            {
                Program.EventSim.CounterType = COUNTERTYPE.TIME;
            }
        }

        /// <summary>
        /// stop criteria is the number of iterations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonStopByIteration_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxStopByTime.Enabled = !radioButtonStopByIteration.Checked;
            groupBoxStopByIteration.Enabled = radioButtonStopByIteration.Checked;
            if (groupBoxStopByIteration.Enabled)
            {
                Program.EventSim.CounterType = COUNTERTYPE.ITERATIONS;
            }
        }

        private void startStopToolStripMenuItemSimulationToggle_Click(object sender, EventArgs e)
        {
            ToogleSimulation();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Opens the settings window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            Settings Dialog = new Settings();
            if (Dialog.ShowDialog() != DialogResult.OK)
            {
                GetUserSettings();
            }       
        }


        /// <summary>
        /// a new mouse-event has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripDropDownButtonSelectedEvent_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButtonSelectedMouseEvent.Text = e.ClickedItem.Text;
            UpdateSelectedEditEvent();
        }

        /// <summary>
        /// a new keyboard-event has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripDropDownButtonKeyboardEvent_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButtonKeyboardEvent.Text = e.ClickedItem.Text;
        }    


        /// <summary>
        /// 
        /// </summary>
        public void UpdateSelectedEditEvent()
        {
            return;

            /////////////////////////////////////////////////////////////////////////////////////////////
            // find the mouse event
            EnumStringItem FoundItem = new EnumStringItem();
            if (!Program.EventSim.Mouse.EnumStringColl.FindByName(toolStripDropDownButtonSelectedMouseEvent.Text, ref FoundItem))
            {

            }

            // definition of the simulation type now makes the ADD function
            Program.EventSim.EditorSelectedEvent.SimulationType = SIMTYPE.MOUSE;
            Program.EventSim.EditorSelectedEvent.Event = (MOUSEVENT)FoundItem.Enumeration;

        }

        /// <summary>
        /// Adds a new Event to the EventList
        /// </summary>
        /// <param name="EventSimType">the simulation type (mouse/key)</param>
        public void AddNewEvent(SIMTYPE EventSimType)
        {
            SingleEventSimulation newEvent = null;

            switch (EventSimType)
            {
                case SIMTYPE.MOUSE:
                    Console.WriteLine("add new mouse event...");
                    /////////////////////////////////////////////////////////////////////////////////////////////
                    // find the mouse event
                    EnumStringItem FoundMouseEventItem = new EnumStringItem();
                    if (!Program.EventSim.Mouse.EnumStringColl.FindByName(toolStripDropDownButtonSelectedMouseEvent.Text, ref FoundMouseEventItem))
                    {
                        Console.WriteLine("Error: AddNewEvent Mouse");
                        return;
                    }
                 
                    newEvent = new SingleEventSimulation();
                    newEvent.SimulationType = SIMTYPE.MOUSE;
                    newEvent.Event = (MOUSEVENT)FoundMouseEventItem.Enumeration;
                    newEvent.PositionX = Program.EventSim.EditorSelectedEvent.PositionX;
                    newEvent.PositionY = Program.EventSim.EditorSelectedEvent.PositionY;
                    break;

                case SIMTYPE.KEYBOARD:
                    Console.WriteLine("add new keyboard event...");

                    SingleKeyboardEventEdit KeyEventEdit = new SingleKeyboardEventEdit();
                   
                    DialogResult dialogResult = KeyEventEdit.ShowDialog();
                    if (dialogResult != DialogResult.OK)
                    {
                        // problem, no key seleced
                        Console.WriteLine("Error: KeyEventEdit No Key selected");
                        return;
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////
                    // find the keyboard event
                    EnumStringItem FoundKeyboardEventItem = new EnumStringItem();
                    if (!Program.EventSim.Keyboard.EnumStringColl.FindByName(toolStripDropDownButtonKeyboardEvent.Text, ref FoundKeyboardEventItem))
                    {
                        Console.WriteLine("Error: AddNewEvent Mouse");
                        return;
                    }
                    
                    newEvent = new SingleEventSimulation();
                    newEvent.SimulationType = SIMTYPE.KEYBOARD;
                    newEvent.Event = (KEYBOARDEVENT)FoundKeyboardEventItem.Enumeration;
                    newEvent.EventKey = KeyEventEdit.Event.EventKey;
                    break;

                case SIMTYPE.GESTURE:
                    break;
            }

            if (newEvent != null)
            {
                InsertSingleEventToList(newEvent);
            }
        }

        /// <summary>
        /// Clears the SingleEvent List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSingleEventListClear_Click(object sender, EventArgs e)
        {
            listViewSingleEvents.Items.Clear();
        }

        /// <summary>
        /// saves the content of the singleevent list as a xml-template file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSaveAsTemplate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            EventTemplate tmp = new EventTemplate();

            // fill the event collection for the save process
            PrepareEventCollection();

            foreach (SingleEventSimulation single in Program.EventSim.EventCollection)
            {
                tmp.AddEvent(single);
            }

            // now clear the event collection
            Program.EventSim.ClearEvents();

            tmp.OnSaveAsTemplate();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// loads the content of an xml-template file into the singlevent lists (adds them to the end of the list)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemInsertTemplate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            EventTemplate tmp = new EventTemplate();

            tmp.OnOpenTemplate();
            foreach (SingleEventSimulation single in tmp.EventTemplateCollection)
            {
                InsertSingleEventToList(single);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// resizes the SingleEventsTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            listViewSingleEvents.Height = SingleEventListMinHeight + (control.Size.Height - MainWindowMinHeight);
        }

       
     
    }
}