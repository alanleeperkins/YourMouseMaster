using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace YourMouseMaster
{
    public enum SIMTYPE {MOUSE, KEYBOARD,GESTURE};
    public enum COUNTERTYPE { TIME, STEPS,ITERATIONS,TOGGLEBUTTON };

    public class SingleEventSimulation
    {
        public SIMTYPE SimulationType;
        public object Event;
        public int PositionX;
        public int PositionY;
        public Keys EventKey;
        public String KeyboardOutput;
        
        public SingleEventSimulation()
        {

        }
       
    }

    class EventSimulator
    {
        public MouseSimulator Mouse = new MouseSimulator();
        public KeyboardSimulator Keyboard = new KeyboardSimulator();

        public Collection<SingleEventSimulation> EventCollection = new Collection<SingleEventSimulation>();

        public Keys EditorAddMouseEventKey;
        public Keys EditorAddKeyboardEventKey;
        public Keys ToggleSimulationKey;
        public SingleEventSimulation EditorSelectedEvent = new SingleEventSimulation();   

        public COUNTERTYPE CounterType;
        public bool UseKeySniffer;

        public EventSimulator()
        {
            CounterType = COUNTERTYPE.TIME;     // standard -> time counter
            ClearEvents();

            // standard key settings
            EditorAddMouseEventKey = Keys.F1;
            EditorAddKeyboardEventKey = Keys.F2;
            ToggleSimulationKey = Keys.F5;        // toggles the simulation
            UseKeySniffer = true;          
        }

        public void ClearEvents()
        {
            EventCollection.Clear();
        }

        public void AddEvent(SingleEventSimulation item)
        {
            EventCollection.Add(item);
        }


        public void DoSimulation(SingleEventSimulation simulation)
        {
            switch (simulation.SimulationType)
            {
                case SIMTYPE.MOUSE:
                    Mouse.SetMousePosition(simulation.PositionX, simulation.PositionY);
                    Mouse.DoEvent((MOUSEVENT)simulation.Event, 0, 0);
                    break;

                case SIMTYPE.KEYBOARD:
                    Keyboard.WriteString(simulation.KeyboardOutput);
                    break;

                case SIMTYPE.GESTURE:
                    break;
            }
        }
    }
}
