namespace YourMouseMaster
{
    partial class Settings
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxUseKeySniffer = new System.Windows.Forms.CheckBox();
            this.groupBoxShortcuts = new System.Windows.Forms.GroupBox();
            this.comboBoxShortKeyMouse = new System.Windows.Forms.ComboBox();
            this.labelAddEventMouse = new System.Windows.Forms.Label();
            this.labelAddEventKey = new System.Windows.Forms.Label();
            this.comboBoxShortKeyKeyboard = new System.Windows.Forms.ComboBox();
            this.labelShortkeyToggleSim = new System.Windows.Forms.Label();
            this.comboBoxShortkeyToggleSim = new System.Windows.Forms.ComboBox();
            this.groupBoxShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(330, 338);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(105, 32);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(441, 338);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 32);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxUseKeySniffer
            // 
            this.checkBoxUseKeySniffer.AutoSize = true;
            this.checkBoxUseKeySniffer.Location = new System.Drawing.Point(12, 12);
            this.checkBoxUseKeySniffer.Name = "checkBoxUseKeySniffer";
            this.checkBoxUseKeySniffer.Size = new System.Drawing.Size(126, 17);
            this.checkBoxUseKeySniffer.TabIndex = 2;
            this.checkBoxUseKeySniffer.Text = "Use Keyboard-Sniffer";
            this.checkBoxUseKeySniffer.UseVisualStyleBackColor = true;
            // 
            // groupBoxShortcuts
            // 
            this.groupBoxShortcuts.Controls.Add(this.labelShortkeyToggleSim);
            this.groupBoxShortcuts.Controls.Add(this.comboBoxShortkeyToggleSim);
            this.groupBoxShortcuts.Controls.Add(this.labelAddEventKey);
            this.groupBoxShortcuts.Controls.Add(this.comboBoxShortKeyKeyboard);
            this.groupBoxShortcuts.Controls.Add(this.labelAddEventMouse);
            this.groupBoxShortcuts.Controls.Add(this.comboBoxShortKeyMouse);
            this.groupBoxShortcuts.Location = new System.Drawing.Point(12, 56);
            this.groupBoxShortcuts.Name = "groupBoxShortcuts";
            this.groupBoxShortcuts.Size = new System.Drawing.Size(534, 123);
            this.groupBoxShortcuts.TabIndex = 3;
            this.groupBoxShortcuts.TabStop = false;
            this.groupBoxShortcuts.Text = "Shortkeys";
            // 
            // comboBoxShortKeyMouse
            // 
            this.comboBoxShortKeyMouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShortKeyMouse.FormattingEnabled = true;
            this.comboBoxShortKeyMouse.Location = new System.Drawing.Point(148, 59);
            this.comboBoxShortKeyMouse.Name = "comboBoxShortKeyMouse";
            this.comboBoxShortKeyMouse.Size = new System.Drawing.Size(121, 21);
            this.comboBoxShortKeyMouse.TabIndex = 0;
            // 
            // labelAddEventMouse
            // 
            this.labelAddEventMouse.AutoSize = true;
            this.labelAddEventMouse.Location = new System.Drawing.Point(15, 63);
            this.labelAddEventMouse.Name = "labelAddEventMouse";
            this.labelAddEventMouse.Size = new System.Drawing.Size(98, 13);
            this.labelAddEventMouse.TabIndex = 1;
            this.labelAddEventMouse.Text = "Add Event (Mouse)";
            // 
            // labelAddEventKey
            // 
            this.labelAddEventKey.AutoSize = true;
            this.labelAddEventKey.Location = new System.Drawing.Point(15, 91);
            this.labelAddEventKey.Name = "labelAddEventKey";
            this.labelAddEventKey.Size = new System.Drawing.Size(84, 13);
            this.labelAddEventKey.TabIndex = 3;
            this.labelAddEventKey.Text = "Add Event (Key)";
            // 
            // comboBoxShortKeyKeyboard
            // 
            this.comboBoxShortKeyKeyboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShortKeyKeyboard.FormattingEnabled = true;
            this.comboBoxShortKeyKeyboard.Location = new System.Drawing.Point(148, 87);
            this.comboBoxShortKeyKeyboard.Name = "comboBoxShortKeyKeyboard";
            this.comboBoxShortKeyKeyboard.Size = new System.Drawing.Size(121, 21);
            this.comboBoxShortKeyKeyboard.TabIndex = 2;
            // 
            // labelShortkeyToggleSim
            // 
            this.labelShortkeyToggleSim.AutoSize = true;
            this.labelShortkeyToggleSim.Location = new System.Drawing.Point(15, 23);
            this.labelShortkeyToggleSim.Name = "labelShortkeyToggleSim";
            this.labelShortkeyToggleSim.Size = new System.Drawing.Size(107, 13);
            this.labelShortkeyToggleSim.TabIndex = 5;
            this.labelShortkeyToggleSim.Text = "Simulation Start/Stop";
            // 
            // comboBoxShortkeyToggleSim
            // 
            this.comboBoxShortkeyToggleSim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShortkeyToggleSim.FormattingEnabled = true;
            this.comboBoxShortkeyToggleSim.Location = new System.Drawing.Point(148, 19);
            this.comboBoxShortkeyToggleSim.Name = "comboBoxShortkeyToggleSim";
            this.comboBoxShortkeyToggleSim.Size = new System.Drawing.Size(121, 21);
            this.comboBoxShortkeyToggleSim.TabIndex = 4;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 382);
            this.Controls.Add(this.groupBoxShortcuts);
            this.Controls.Add(this.checkBoxUseKeySniffer);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "Settings";
            this.Text = "Settings";
            this.groupBoxShortcuts.ResumeLayout(false);
            this.groupBoxShortcuts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxUseKeySniffer;
        private System.Windows.Forms.GroupBox groupBoxShortcuts;
        private System.Windows.Forms.Label labelAddEventMouse;
        private System.Windows.Forms.ComboBox comboBoxShortKeyMouse;
        private System.Windows.Forms.Label labelShortkeyToggleSim;
        private System.Windows.Forms.ComboBox comboBoxShortkeyToggleSim;
        private System.Windows.Forms.Label labelAddEventKey;
        private System.Windows.Forms.ComboBox comboBoxShortKeyKeyboard;
    }
}