using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace YourMouseMaster
{    
    class NumericUpDownEx : NumericUpDown
    {
        String Unit;
        String UnitExt;
       
        public NumericUpDownEx()
        {
            Unit = "";
            UnitExt = "";
        }

        public void SetUnit(String value)
        {
            Unit = value;
            UnitExt = value;
        }

        public void SetUnit(String value,String value2)
        {
            Unit = value;
            UnitExt = value2;
        }

        public String GetUnit()
        {
            return Unit;
        }

        protected override void UpdateEditText()
        {
            // Append the units to the end of the numeric value
            if (Unit == null) return;
            if (UnitExt == null) return;

            if (this.Value > 1)
            {
                this.Text = String.Format("{0} {1}", this.Value, UnitExt);
            }
            else
            {
                this.Text = String.Format("{0} {1}", this.Value, Unit);
            }

        }
    }
}
