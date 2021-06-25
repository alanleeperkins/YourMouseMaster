namespace YourMouseMaster
{
    partial class SingleMouseEventEdit
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
            this.groupBoxSingleEvent = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelEventCoordsValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEventNames = new System.Windows.Forms.ComboBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.groupBoxSingleEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSingleEvent
            // 
            this.groupBoxSingleEvent.Controls.Add(this.buttonCancel);
            this.groupBoxSingleEvent.Controls.Add(this.label5);
            this.groupBoxSingleEvent.Controls.Add(this.labelEventCoordsValue);
            this.groupBoxSingleEvent.Controls.Add(this.label4);
            this.groupBoxSingleEvent.Controls.Add(this.label3);
            this.groupBoxSingleEvent.Controls.Add(this.comboBoxEventNames);
            this.groupBoxSingleEvent.Controls.Add(this.buttonAddEvent);
            this.groupBoxSingleEvent.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSingleEvent.Name = "groupBoxSingleEvent";
            this.groupBoxSingleEvent.Size = new System.Drawing.Size(335, 163);
            this.groupBoxSingleEvent.TabIndex = 10;
            this.groupBoxSingleEvent.TabStop = false;
            this.groupBoxSingleEvent.Text = "Single-Event";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(203, 127);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 29);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(116, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 48);
            this.label5.TabIndex = 12;
            this.label5.Text = "Press \'p\' to get the current mouse position, and use it for the current event!";
            // 
            // labelEventCoordsValue
            // 
            this.labelEventCoordsValue.Location = new System.Drawing.Point(116, 54);
            this.labelEventCoordsValue.Name = "labelEventCoordsValue";
            this.labelEventCoordsValue.Size = new System.Drawing.Size(180, 13);
            this.labelEventCoordsValue.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Event-Coords";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(43, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Event";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxEventNames
            // 
            this.comboBoxEventNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventNames.FormattingEnabled = true;
            this.comboBoxEventNames.Location = new System.Drawing.Point(116, 20);
            this.comboBoxEventNames.Name = "comboBoxEventNames";
            this.comboBoxEventNames.Size = new System.Drawing.Size(190, 21);
            this.comboBoxEventNames.TabIndex = 7;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(11, 127);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(126, 29);
            this.buttonAddEvent.TabIndex = 6;
            this.buttonAddEvent.Text = "Close and &Add Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // SingleMouseEventEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 183);
            this.Controls.Add(this.groupBoxSingleEvent);
            this.KeyPreview = true;
            this.Name = "SingleMouseEventEdit";
            this.Text = "Single-Mouse-Event Editor";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SingleEventEdit_KeyPress);
            this.groupBoxSingleEvent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSingleEvent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelEventCoordsValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEventNames;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Button buttonCancel;
    }
}