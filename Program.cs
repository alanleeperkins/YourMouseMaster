using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace YourMouseMaster
{
    enum TIMEUNITS { ms, s, min, hr, d };
    static class Program
    {
        public static SettingsManagement GlobalSettings = new SettingsManagement();
        public static EventSimulator EventSim = new EventSimulator();
        public static KeyboardSniffer KeySniffer = new KeyboardSniffer();
        public static bool OutputWindowVisible;

   
        // //////////////////////////////////////////////////////////////////////////////////////////////
        // //////////////////////////////////////////////////////////////////////////////////////////////
        // used for the console
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        // //////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            OutputWindowVisible = false;

            //--DEBUG
            if (args.Length > 0)
            {
                // we seem to have some arguments
                foreach (String argument in args)
                {
                    argument.Trim();
                    if (argument == "--DEBUG") OutputWindowVisible = true;
                }
            }
           
            if (Debugger.IsAttached || OutputWindowVisible)
            {
                // //////////////////////////////////////////////////////////////////////////////////////////////
                // //////////////////////////////////////////////////////////////////////////////////////////////
                // when running with the IDE -> show the console window
                OutputWindowVisible = true;

                IntPtr ptr = GetForegroundWindow();
                int u;
                GetWindowThreadProcessId(ptr, out u);
                Process process = Process.GetProcessById(u);
                AllocConsole();
                Console.Out.WriteLine("***********************************");
                Console.Out.WriteLine("Welcome - YMM!");
                Console.Out.WriteLine("***********************************");
#if (DEBUG)
                Console.WriteLine("Mode:Debug");
#elif (RELEASE)
            Console.WriteLine("Mode:Release"); 
#endif

            }
 
            // Load the global settings
            GlobalSettings.GetSettings(SettingsManagement.STORETYPE.XML);
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static String GetTimeString(double milliseconds)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(milliseconds);
            String answer = String.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);

            return answer;
        }

        public static double ConvertTime(double SourceValue, TIMEUNITS SourceTimeUnit, TIMEUNITS DestinationTimeUnit)
        {
            double DestinationValue = SourceValue;

            switch(SourceTimeUnit)
            {
                case TIMEUNITS.ms:
                    switch (DestinationTimeUnit)
                    {
                        case TIMEUNITS.ms:
                            DestinationValue = SourceValue;
                            break;

                        case TIMEUNITS.s:
                            DestinationValue = SourceValue/100;
                            break;

                        case TIMEUNITS.min:
                            DestinationValue = SourceValue /1.6666666666666667E-5;
                            break;
                            
                        case TIMEUNITS.hr:
                            DestinationValue = SourceValue / 2.77778E-7;
                            break;

                        case TIMEUNITS.d:
                            DestinationValue = SourceValue / 1.15741e-8;
                            break;
                    }
                    break;

                case TIMEUNITS.s:
                    switch (DestinationTimeUnit)
                    {
                        case TIMEUNITS.ms:
                            DestinationValue = SourceValue *1000;
                            break;

                        case TIMEUNITS.s:
                            DestinationValue = SourceValue;
                            break;

                        case TIMEUNITS.min:
                            DestinationValue = SourceValue * 0.0166667;
                            break;

                        case TIMEUNITS.hr:
                            DestinationValue = SourceValue * 0.000277778;
                            break;

                        case TIMEUNITS.d:
                            DestinationValue = SourceValue * 1.1574E-5;
                            break;
                    }
                    break;

                case TIMEUNITS.min:
                    switch (DestinationTimeUnit)
                    {
                        case TIMEUNITS.ms:
                            DestinationValue = SourceValue * 60000;
                            break;

                        case TIMEUNITS.s:
                            DestinationValue = SourceValue * 60;
                            break;

                        case TIMEUNITS.min:
                            DestinationValue = SourceValue;
                            break;

                        case TIMEUNITS.hr:
                            DestinationValue = SourceValue * 0.0166667;
                            break;

                        case TIMEUNITS.d:
                            DestinationValue = SourceValue * 0.000694444;
                            break;
                    }
                    break;

                case TIMEUNITS.hr:
                    switch (DestinationTimeUnit)
                    {
                        case TIMEUNITS.ms:
                            DestinationValue = SourceValue * 3.6e+6;
                            break;

                        case TIMEUNITS.s:
                            DestinationValue = SourceValue * 3600;
                            break;

                        case TIMEUNITS.min:
                            DestinationValue = SourceValue*60;
                            break;

                        case TIMEUNITS.hr:
                            DestinationValue = SourceValue;
                            break;

                        case TIMEUNITS.d:
                            DestinationValue = SourceValue * 0.0416667;
                            break;
                    }
                    break;

                case TIMEUNITS.d:
                    switch (DestinationTimeUnit)
                    {
                        case TIMEUNITS.ms:
                            DestinationValue = SourceValue * 8.64e+7;
                            break;

                        case TIMEUNITS.s:
                            DestinationValue = SourceValue * 86400;
                            break;

                        case TIMEUNITS.min:
                            DestinationValue = SourceValue * 1440;
                            break;

                        case TIMEUNITS.hr:
                            DestinationValue = SourceValue * 24;
                            break;

                        case TIMEUNITS.d:
                            DestinationValue = SourceValue;
                            break;
                    }
                    break;
            }
            return DestinationValue;
        }
    }
}