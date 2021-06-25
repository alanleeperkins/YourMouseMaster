namespace YourMouseMaster
{
    partial class SingleKeyboardEventEdit
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
            this.groupBoxKeyEventSettings = new System.Windows.Forms.GroupBox();
            this.comboBoxEventTypes = new System.Windows.Forms.ComboBox();
            this.comboBoxEventNames = new System.Windows.Forms.ComboBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxKeyEventSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxKeyEventSettings
            // 
            this.groupBoxKeyEventSettings.Controls.Add(this.label2);
            this.groupBoxKeyEventSettings.Controls.Add(this.label1);
            this.groupBoxKeyEventSettings.Controls.Add(this.buttonCancel);
            this.groupBoxKeyEventSettings.Controls.Add(this.buttonAddEvent);
            this.groupBoxKeyEventSettings.Controls.Add(this.comboBoxEventNames);
            this.groupBoxKeyEventSettings.Controls.Add(this.comboBoxEventTypes);
            this.groupBoxKeyEventSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxKeyEventSettings.Name = "groupBoxKeyEventSettings";
            this.groupBoxKeyEventSettings.Size = new System.Drawing.Size(335, 163);
            this.groupBoxKeyEventSettings.TabIndex = 0;
            this.groupBoxKeyEventSettings.TabStop = false;
            this.groupBoxKeyEventSettings.Text = "Single-Event";
            // 
            // comboBoxEventTypes
            // 
            this.comboBoxEventTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventTypes.FormattingEnabled = true;
            this.comboBoxEventTypes.Location = new System.Drawing.Point(103, 22);
            this.comboBoxEventTypes.Name = "comboBoxEventTypes";
            this.comboBoxEventTypes.Size = new System.Drawing.Size(190, 21);
            this.comboBoxEventTypes.TabIndex = 0;
            // 
            // comboBoxEventNames
            // 
            this.comboBoxEventNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventNames.FormattingEnabled = true;
            this.comboBoxEventNames.Location = new System.Drawing.Point(103, 62);
            this.comboBoxEventNames.Name = "comboBoxEventNames";
            this.comboBoxEventNames.Size = new System.Drawing.Size(190, 21);
            this.comboBoxEventNames.TabIndex = 1;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(11, 127);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(126, 29);
            this.buttonAddEvent.TabIndex = 2;
            this.buttonAddEvent.Text = "Close and &Add Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(203, 127);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 29);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Key Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Key";
            // 
            // SingleKeyboardEventEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 183);
            this.Controls.Add(this.groupBoxKeyEventSettings);
            this.Name = "SingleKeyboardEventEdit";
            this.Text = "Single-Keyboard-Event Editor";
            this.groupBoxKeyEventSettings.ResumeLayout(false);
            this.groupBoxKeyEventSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxKeyEventSettings;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.ComboBox comboBoxEventNames;
        private System.Windows.Forms.ComboBox comboBoxEventTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}