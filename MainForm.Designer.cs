namespace YourMouseMaster
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSimulationSettings = new System.Windows.Forms.GroupBox();
            this.comboBoxSingleEventDelaysTimeUnits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxStopByIteration = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownStopByIteration = new YourMouseMaster.NumericUpDownEx();
            this.groupBoxStopByTime = new System.Windows.Forms.GroupBox();
            this.comboBoxStopByTimeTimeUnits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownStopByTime = new YourMouseMaster.NumericUpDownEx();
            this.radioButtonStopByIteration = new System.Windows.Forms.RadioButton();
            this.radioButtonStopByTime = new System.Windows.Forms.RadioButton();
            this.numericUpDownSingleEventDelay = new YourMouseMaster.NumericUpDownEx();
            this.labelSingleEventDely = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.labelElapsedEvents = new System.Windows.Forms.Label();
            this.labelElapsedIterations = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.menuStripSingleEvents = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopToolStripMenuItemSimulationToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSingleEventList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSingleEventListClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAsTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemInsertTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMouseCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelEventEditInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButtonSelectedMouseEvent = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonKeyboardEvent = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabelKeyInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listViewSingleEvents = new YourMouseMaster.ListViewEx();
            this.columnNo = new System.Windows.Forms.ColumnHeader();
            this.columnSimType = new System.Windows.Forms.ColumnHeader();
            this.columnEvent = new System.Windows.Forms.ColumnHeader();
            this.columnCoordX = new System.Windows.Forms.ColumnHeader();
            this.columnCoordY = new System.Windows.Forms.ColumnHeader();
            this.columnKey = new System.Windows.Forms.ColumnHeader();
            this.radioButtonNonStop = new System.Windows.Forms.RadioButton();
            this.groupBoxSimulationSettings.SuspendLayout();
            this.groupBoxStopByIteration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopByIteration)).BeginInit();
            this.groupBoxStopByTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopByTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSingleEventDelay)).BeginInit();
            this.groupBoxInfo.SuspendLayout();
            this.menuStripSingleEvents.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Single Events";
            // 
            // groupBoxSimulationSettings
            // 
            this.groupBoxSimulationSettings.Controls.Add(this.radioButtonNonStop);
            this.groupBoxSimulationSettings.Controls.Add(this.comboBoxSingleEventDelaysTimeUnits);
            this.groupBoxSimulationSettings.Controls.Add(this.label7);
            this.groupBoxSimulationSettings.Controls.Add(this.groupBoxStopByIteration);
            this.groupBoxSimulationSettings.Controls.Add(this.groupBoxStopByTime);
            this.groupBoxSimulationSettings.Controls.Add(this.radioButtonStopByIteration);
            this.groupBoxSimulationSettings.Controls.Add(this.radioButtonStopByTime);
            this.groupBoxSimulationSettings.Controls.Add(this.numericUpDownSingleEventDelay);
            this.groupBoxSimulationSettings.Controls.Add(this.labelSingleEventDely);
            this.groupBoxSimulationSettings.Location = new System.Drawing.Point(12, 46);
            this.groupBoxSimulationSettings.Name = "groupBoxSimulationSettings";
            this.groupBoxSimulationSettings.Size = new System.Drawing.Size(325, 186);
            this.groupBoxSimulationSettings.TabIndex = 10;
            this.groupBoxSimulationSettings.TabStop = false;
            this.groupBoxSimulationSettings.Text = "Simulation Settings";
            // 
            // comboBoxSingleEventDelaysTimeUnits
            // 
            this.comboBoxSingleEventDelaysTimeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSingleEventDelaysTimeUnits.FormattingEnabled = true;
            this.comboBoxSingleEventDelaysTimeUnits.Location = new System.Drawing.Point(222, 19);
            this.comboBoxSingleEventDelaysTimeUnits.Name = "comboBoxSingleEventDelaysTimeUnits";
            this.comboBoxSingleEventDelaysTimeUnits.Size = new System.Drawing.Size(65, 21);
            this.comboBoxSingleEventDelaysTimeUnits.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, -99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Number of iterations";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBoxStopByIteration
            // 
            this.groupBoxStopByIteration.Controls.Add(this.label6);
            this.groupBoxStopByIteration.Controls.Add(this.numericUpDownStopByIteration);
            this.groupBoxStopByIteration.Location = new System.Drawing.Point(40, 129);
            this.groupBoxStopByIteration.Name = "groupBoxStopByIteration";
            this.groupBoxStopByIteration.Size = new System.Drawing.Size(265, 50);
            this.groupBoxStopByIteration.TabIndex = 18;
            this.groupBoxStopByIteration.TabStop = false;
            this.groupBoxStopByIteration.Text = "Stop By Iteration";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stop after";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownStopByIteration
            // 
            this.numericUpDownStopByIteration.Location = new System.Drawing.Point(66, 20);
            this.numericUpDownStopByIteration.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.numericUpDownStopByIteration.Name = "numericUpDownStopByIteration";
            this.numericUpDownStopByIteration.Size = new System.Drawing.Size(135, 20);
            this.numericUpDownStopByIteration.TabIndex = 19;
            this.numericUpDownStopByIteration.Tag = "";
            this.numericUpDownStopByIteration.ThousandsSeparator = true;
            // 
            // groupBoxStopByTime
            // 
            this.groupBoxStopByTime.Controls.Add(this.comboBoxStopByTimeTimeUnits);
            this.groupBoxStopByTime.Controls.Add(this.label8);
            this.groupBoxStopByTime.Controls.Add(this.numericUpDownStopByTime);
            this.groupBoxStopByTime.Location = new System.Drawing.Point(40, 73);
            this.groupBoxStopByTime.Name = "groupBoxStopByTime";
            this.groupBoxStopByTime.Size = new System.Drawing.Size(265, 53);
            this.groupBoxStopByTime.TabIndex = 17;
            this.groupBoxStopByTime.TabStop = false;
            this.groupBoxStopByTime.Text = "Stop By Time";
            // 
            // comboBoxStopByTimeTimeUnits
            // 
            this.comboBoxStopByTimeTimeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopByTimeTimeUnits.FormattingEnabled = true;
            this.comboBoxStopByTimeTimeUnits.Location = new System.Drawing.Point(182, 23);
            this.comboBoxStopByTimeTimeUnits.Name = "comboBoxStopByTimeTimeUnits";
            this.comboBoxStopByTimeTimeUnits.Size = new System.Drawing.Size(65, 21);
            this.comboBoxStopByTimeTimeUnits.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Stop after";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownStopByTime
            // 
            this.numericUpDownStopByTime.Location = new System.Drawing.Point(66, 23);
            this.numericUpDownStopByTime.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.numericUpDownStopByTime.Name = "numericUpDownStopByTime";
            this.numericUpDownStopByTime.Size = new System.Drawing.Size(110, 20);
            this.numericUpDownStopByTime.TabIndex = 21;
            this.numericUpDownStopByTime.Tag = "";
            this.numericUpDownStopByTime.ThousandsSeparator = true;
            // 
            // radioButtonStopByIteration
            // 
            this.radioButtonStopByIteration.AutoSize = true;
            this.radioButtonStopByIteration.Location = new System.Drawing.Point(20, 130);
            this.radioButtonStopByIteration.Name = "radioButtonStopByIteration";
            this.radioButtonStopByIteration.Size = new System.Drawing.Size(14, 13);
            this.radioButtonStopByIteration.TabIndex = 16;
            this.radioButtonStopByIteration.TabStop = true;
            this.radioButtonStopByIteration.UseVisualStyleBackColor = true;
            this.radioButtonStopByIteration.CheckedChanged += new System.EventHandler(this.radioButtonStopByIteration_CheckedChanged);
            // 
            // radioButtonStopByTime
            // 
            this.radioButtonStopByTime.AutoSize = true;
            this.radioButtonStopByTime.Location = new System.Drawing.Point(20, 74);
            this.radioButtonStopByTime.Name = "radioButtonStopByTime";
            this.radioButtonStopByTime.Size = new System.Drawing.Size(14, 13);
            this.radioButtonStopByTime.TabIndex = 15;
            this.radioButtonStopByTime.TabStop = true;
            this.radioButtonStopByTime.UseVisualStyleBackColor = true;
            this.radioButtonStopByTime.CheckedChanged += new System.EventHandler(this.radioButtonStopByTime_CheckedChanged);
            // 
            // numericUpDownSingleEventDelay
            // 
            this.numericUpDownSingleEventDelay.Location = new System.Drawing.Point(136, 19);
            this.numericUpDownSingleEventDelay.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.numericUpDownSingleEventDelay.Name = "numericUpDownSingleEventDelay";
            this.numericUpDownSingleEventDelay.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownSingleEventDelay.TabIndex = 14;
            this.numericUpDownSingleEventDelay.Tag = "";
            this.numericUpDownSingleEventDelay.ThousandsSeparator = true;
            // 
            // labelSingleEventDely
            // 
            this.labelSingleEventDely.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSingleEventDely.AutoSize = true;
            this.labelSingleEventDely.Location = new System.Drawing.Point(22, 22);
            this.labelSingleEventDely.Name = "labelSingleEventDely";
            this.labelSingleEventDely.Size = new System.Drawing.Size(97, 13);
            this.labelSingleEventDely.TabIndex = 13;
            this.labelSingleEventDely.Text = "Single Event Delay";
            this.labelSingleEventDely.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelElapsedEvents);
            this.groupBoxInfo.Controls.Add(this.labelElapsedIterations);
            this.groupBoxInfo.Controls.Add(this.labelElapsedTime);
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 238);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(325, 76);
            this.groupBoxInfo.TabIndex = 11;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // labelElapsedEvents
            // 
            this.labelElapsedEvents.AutoSize = true;
            this.labelElapsedEvents.Location = new System.Drawing.Point(43, 54);
            this.labelElapsedEvents.Name = "labelElapsedEvents";
            this.labelElapsedEvents.Size = new System.Drawing.Size(58, 13);
            this.labelElapsedEvents.TabIndex = 2;
            this.labelElapsedEvents.Text = "Events: 00";
            // 
            // labelElapsedIterations
            // 
            this.labelElapsedIterations.AutoSize = true;
            this.labelElapsedIterations.Location = new System.Drawing.Point(33, 37);
            this.labelElapsedIterations.Name = "labelElapsedIterations";
            this.labelElapsedIterations.Size = new System.Drawing.Size(68, 13);
            this.labelElapsedIterations.TabIndex = 1;
            this.labelElapsedIterations.Text = "Iterations: 00";
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.AutoSize = true;
            this.labelElapsedTime.Location = new System.Drawing.Point(12, 20);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(119, 13);
            this.labelElapsedTime.TabIndex = 0;
            this.labelElapsedTime.Text = "Elapsed Time: 00:00:00";
            // 
            // menuStripSingleEvents
            // 
            this.menuStripSingleEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.simulationToolStripMenuItem,
            this.toolStripMenuItemSingleEventList,
            this.toolStripMenuItemTemplates});
            this.menuStripSingleEvents.Location = new System.Drawing.Point(0, 0);
            this.menuStripSingleEvents.Name = "menuStripSingleEvents";
            this.menuStripSingleEvents.Size = new System.Drawing.Size(824, 24);
            this.menuStripSingleEvents.TabIndex = 12;
            this.menuStripSingleEvents.Text = "Single Events";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSettings,
            this.toolStripSeparator1,
            this.ToolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // ToolStripMenuItemSettings
            // 
            this.ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings";
            this.ToolStripMenuItemSettings.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItemSettings.Text = "Settings";
            this.ToolStripMenuItemSettings.Click += new System.EventHandler(this.settingsToolStripMenuItemSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItemExit.Text = "Exit";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStopToolStripMenuItemSimulationToggle});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // startStopToolStripMenuItemSimulationToggle
            // 
            this.startStopToolStripMenuItemSimulationToggle.Name = "startStopToolStripMenuItemSimulationToggle";
            this.startStopToolStripMenuItemSimulationToggle.Size = new System.Drawing.Size(133, 22);
            this.startStopToolStripMenuItemSimulationToggle.Text = "Start / Stop";
            this.startStopToolStripMenuItemSimulationToggle.Click += new System.EventHandler(this.startStopToolStripMenuItemSimulationToggle_Click);
            // 
            // toolStripMenuItemSingleEventList
            // 
            this.toolStripMenuItemSingleEventList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSingleEventListClear});
            this.toolStripMenuItemSingleEventList.Name = "toolStripMenuItemSingleEventList";
            this.toolStripMenuItemSingleEventList.Size = new System.Drawing.Size(104, 20);
            this.toolStripMenuItemSingleEventList.Text = "Single Event List";
            // 
            // toolStripMenuItemSingleEventListClear
            // 
            this.toolStripMenuItemSingleEventListClear.Name = "toolStripMenuItemSingleEventListClear";
            this.toolStripMenuItemSingleEventListClear.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItemSingleEventListClear.Text = "Clear List";
            this.toolStripMenuItemSingleEventListClear.Click += new System.EventHandler(this.toolStripMenuItemSingleEventListClear_Click);
            // 
            // toolStripMenuItemTemplates
            // 
            this.toolStripMenuItemTemplates.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSaveAsTemplate,
            this.toolStripMenuItemInsertTemplate});
            this.toolStripMenuItemTemplates.Name = "toolStripMenuItemTemplates";
            this.toolStripMenuItemTemplates.Size = new System.Drawing.Size(74, 20);
            this.toolStripMenuItemTemplates.Text = "Templates";
            // 
            // toolStripMenuItemSaveAsTemplate
            // 
            this.toolStripMenuItemSaveAsTemplate.Name = "toolStripMenuItemSaveAsTemplate";
            this.toolStripMenuItemSaveAsTemplate.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItemSaveAsTemplate.Text = "Save As Template...";
            this.toolStripMenuItemSaveAsTemplate.Click += new System.EventHandler(this.toolStripMenuItemSaveAsTemplate_Click);
            // 
            // toolStripMenuItemInsertTemplate
            // 
            this.toolStripMenuItemInsertTemplate.Name = "toolStripMenuItemInsertTemplate";
            this.toolStripMenuItemInsertTemplate.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItemInsertTemplate.Text = "Insert Template...";
            this.toolStripMenuItemInsertTemplate.Click += new System.EventHandler(this.toolStripMenuItemInsertTemplate_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMouseCoords,
            this.toolStripStatusLabelEventEditInfo,
            this.toolStripDropDownButtonSelectedMouseEvent,
            this.toolStripDropDownButtonKeyboardEvent,
            this.toolStripStatusLabelKeyInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(824, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMouseCoords
            // 
            this.toolStripStatusLabelMouseCoords.Name = "toolStripStatusLabelMouseCoords";
            this.toolStripStatusLabelMouseCoords.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelMouseCoords.Text = "Mouse: X=0000 Y=0000";
            // 
            // toolStripStatusLabelEventEditInfo
            // 
            this.toolStripStatusLabelEventEditInfo.Name = "toolStripStatusLabelEventEditInfo";
            this.toolStripStatusLabelEventEditInfo.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabelEventEditInfo.Text = "Selectet Event: ";
            // 
            // toolStripDropDownButtonSelectedMouseEvent
            // 
            this.toolStripDropDownButtonSelectedMouseEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonSelectedMouseEvent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonSelectedMouseEvent.Image")));
            this.toolStripDropDownButtonSelectedMouseEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSelectedMouseEvent.Name = "toolStripDropDownButtonSelectedMouseEvent";
            this.toolStripDropDownButtonSelectedMouseEvent.Size = new System.Drawing.Size(128, 20);
            this.toolStripDropDownButtonSelectedMouseEvent.Text = "<no event selected>";
            this.toolStripDropDownButtonSelectedMouseEvent.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButtonSelectedEvent_DropDownItemClicked);
            // 
            // toolStripDropDownButtonKeyboardEvent
            // 
            this.toolStripDropDownButtonKeyboardEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonKeyboardEvent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonKeyboardEvent.Image")));
            this.toolStripDropDownButtonKeyboardEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonKeyboardEvent.Name = "toolStripDropDownButtonKeyboardEvent";
            this.toolStripDropDownButtonKeyboardEvent.Size = new System.Drawing.Size(128, 20);
            this.toolStripDropDownButtonKeyboardEvent.Text = "<no event selected>";
            this.toolStripDropDownButtonKeyboardEvent.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButtonKeyboardEvent_DropDownItemClicked);
            // 
            // toolStripStatusLabelKeyInfo
            // 
            this.toolStripStatusLabelKeyInfo.Name = "toolStripStatusLabelKeyInfo";
            this.toolStripStatusLabelKeyInfo.Size = new System.Drawing.Size(162, 17);
            this.toolStripStatusLabelKeyInfo.Text = "KeyInfo: \'Add Event\' = SPACE";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // listViewSingleEvents
            // 
            this.listViewSingleEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNo,
            this.columnSimType,
            this.columnEvent,
            this.columnCoordX,
            this.columnCoordY,
            this.columnKey});
            this.listViewSingleEvents.FullRowSelect = true;
            this.listViewSingleEvents.GridLines = true;
            this.listViewSingleEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSingleEvents.HideSelection = false;
            this.listViewSingleEvents.Location = new System.Drawing.Point(346, 47);
            this.listViewSingleEvents.MultiSelect = false;
            this.listViewSingleEvents.Name = "listViewSingleEvents";
            this.listViewSingleEvents.Size = new System.Drawing.Size(466, 265);
            this.listViewSingleEvents.TabIndex = 1;
            this.listViewSingleEvents.UseCompatibleStateImageBehavior = false;
            this.listViewSingleEvents.View = System.Windows.Forms.View.Details;
            this.listViewSingleEvents.DoubleClick += new System.EventHandler(this.listViewSingleEvents_DoubleClick);
            // 
            // columnNo
            // 
            this.columnNo.Text = "No.";
            this.columnNo.Width = 40;
            // 
            // columnSimType
            // 
            this.columnSimType.Text = "Type";
            this.columnSimType.Width = 85;
            // 
            // columnEvent
            // 
            this.columnEvent.Text = "Event";
            this.columnEvent.Width = 130;
            // 
            // columnCoordX
            // 
            this.columnCoordX.Text = "X";
            this.columnCoordX.Width = 50;
            // 
            // columnCoordY
            // 
            this.columnCoordY.Text = "Y";
            this.columnCoordY.Width = 50;
            // 
            // columnKey
            // 
            this.columnKey.Text = "Key";
            this.columnKey.Width = 80;
            // 
            // radioButtonNonStop
            // 
            this.radioButtonNonStop.AutoSize = true;
            this.radioButtonNonStop.Location = new System.Drawing.Point(20, 47);
            this.radioButtonNonStop.Name = "radioButtonNonStop";
            this.radioButtonNonStop.Size = new System.Drawing.Size(218, 17);
            this.radioButtonNonStop.TabIndex = 24;
            this.radioButtonNonStop.TabStop = true;
            this.radioButtonNonStop.Text = "Non-stop (Toggle with Start/Stop Button)";
            this.radioButtonNonStop.UseVisualStyleBackColor = true;
            this.radioButtonNonStop.CheckedChanged += new System.EventHandler(this.radioButtonNonStop_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 342);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.groupBoxSimulationSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewSingleEvents);
            this.Controls.Add(this.menuStripSingleEvents);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripSingleEvents;
            this.MinimumSize = new System.Drawing.Size(840, 380);
            this.Name = "Form1";
            this.Text = "Mouse Master Editor";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBoxSimulationSettings.ResumeLayout(false);
            this.groupBoxSimulationSettings.PerformLayout();
            this.groupBoxStopByIteration.ResumeLayout(false);
            this.groupBoxStopByIteration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopByIteration)).EndInit();
            this.groupBoxStopByTime.ResumeLayout(false);
            this.groupBoxStopByTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopByTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSingleEventDelay)).EndInit();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.menuStripSingleEvents.ResumeLayout(false);
            this.menuStripSingleEvents.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewEx listViewSingleEvents;
        private System.Windows.Forms.ColumnHeader columnNo;
        private System.Windows.Forms.ColumnHeader columnEvent;
        private System.Windows.Forms.ColumnHeader columnCoordX;
        private System.Windows.Forms.ColumnHeader columnCoordY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSimulationSettings;
        private NumericUpDownEx numericUpDownSingleEventDelay;
        private System.Windows.Forms.Label labelSingleEventDely;
        private System.Windows.Forms.GroupBox groupBoxStopByIteration;
        private System.Windows.Forms.GroupBox groupBoxStopByTime;
        private System.Windows.Forms.RadioButton radioButtonStopByIteration;
        private System.Windows.Forms.RadioButton radioButtonStopByTime;
        private System.Windows.Forms.Label label7;
        private NumericUpDownEx numericUpDownStopByIteration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private NumericUpDownEx numericUpDownStopByTime;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelElapsedTime;
        private System.Windows.Forms.Label labelElapsedIterations;
        private System.Windows.Forms.MenuStrip menuStripSingleEvents;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStopToolStripMenuItemSimulationToggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMouseCoords;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelKeyInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEventEditInfo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSelectedMouseEvent;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSingleEventList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSingleEventListClear;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTemplates;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAsTemplate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInsertTemplate;
        private System.Windows.Forms.ComboBox comboBoxStopByTimeTimeUnits;
        private System.Windows.Forms.Label labelElapsedEvents;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox comboBoxSingleEventDelaysTimeUnits;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonKeyboardEvent;
        private System.Windows.Forms.ColumnHeader columnKey;
        private System.Windows.Forms.ColumnHeader columnSimType;
        private System.Windows.Forms.RadioButton radioButtonNonStop;
    }
}

