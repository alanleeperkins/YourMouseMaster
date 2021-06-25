using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YourMouseMaster
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();


            LoadSettings();
        }

        public void LoadSettings()
        {
            // get the global settings
            checkBoxUseKeySniffer.Checked = Program.GlobalSettings.Vars.UseKeyboardSniffer;

            // fill the shortkey-lists
            comboBoxShortkeyToggleSim.Items.Clear();
            foreach (Keys single in Enum.GetValues(typeof(Keys)))
            {
                comboBoxShortkeyToggleSim.Items.Add(single);
                comboBoxShortKeyMouse.Items.Add(single);
                comboBoxShortKeyKeyboard.Items.Add(single);
            }
            comboBoxShortkeyToggleSim.Text = Program.GlobalSettings.Vars.ShortKeySimulationToggle.ToString();
            comboBoxShortKeyMouse.Text = Program.GlobalSettings.Vars.ShortKeyAddEventMouse.ToString();
            comboBoxShortKeyKeyboard.Text = Program.GlobalSettings.Vars.ShortKeyAddEventKeyboard.ToString();

        }

        public bool CheckSettings()
        {
            bool twinsettings = false;
            buttonSave.DialogResult = DialogResult.None;
            twinsettings = (comboBoxShortkeyToggleSim.SelectedItem.ToString() == comboBoxShortKeyMouse.SelectedItem.ToString()
                            || (comboBoxShortkeyToggleSim.SelectedItem.ToString() == comboBoxShortKeyKeyboard.SelectedItem.ToString())
                            || comboBoxShortKeyMouse.SelectedItem.ToString() == comboBoxShortKeyKeyboard.SelectedItem.ToString());

            return !twinsettings;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (!CheckSettings())
            {
                MessageBox.Show("The same key has been selected for at least more than one Shortkey", "Shortkey Error");
                return;
            }
         
            // update the global settings
            Program.GlobalSettings.Vars.UseKeyboardSniffer = checkBoxUseKeySniffer.Checked;

            Program.GlobalSettings.Vars.ShortKeySimulationToggle = (Keys)Enum.Parse(typeof(Keys), comboBoxShortkeyToggleSim.SelectedItem.ToString());
            Program.GlobalSettings.Vars.ShortKeyAddEventMouse = (Keys)Enum.Parse(typeof(Keys), comboBoxShortKeyMouse.SelectedItem.ToString());
            Program.GlobalSettings.Vars.ShortKeyAddEventKeyboard = (Keys)Enum.Parse(typeof(Keys), comboBoxShortKeyKeyboard.SelectedItem.ToString());

            Program.GlobalSettings.SetSettings(SettingsManagement.STORETYPE.XML);
            
            buttonSave.DialogResult = DialogResult.OK;
            
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}