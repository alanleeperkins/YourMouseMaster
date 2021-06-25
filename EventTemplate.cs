using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace YourMouseMaster
{
    class EventTemplate
    {
        public Collection<SingleEventSimulation> EventTemplateCollection = new Collection<SingleEventSimulation>();
        
        public EventTemplate()
        {
            EventTemplateCollection.Clear();
        }

        ~EventTemplate()
        {

        }

        public void AddEvent(SingleEventSimulation item)
        {
            EventTemplateCollection.Add(item);
        }

        public bool OnOpenTemplate()
        {
            OpenFileDialog OpenTemplateDlg = new OpenFileDialog();
            OpenTemplateDlg.InitialDirectory = Environment.SpecialFolder.Programs.ToString();
            OpenTemplateDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            OpenTemplateDlg.RestoreDirectory = true;

            if (OpenTemplateDlg.ShowDialog() == DialogResult.OK)
            {
                LoadTemplateFromFile(OpenTemplateDlg.FileName);

            }


            return true;
        }
  
        public bool LoadTemplateFromFile(String sSourcePath)
        {
            XmlDocument TemplateXml = new XmlDocument();
            try
            {
                if (!File.Exists(sSourcePath))
                {
                    // file not found
                    return false;
                }
                
                
                TemplateXml = new XmlDocument();
                TemplateXml.Load(sSourcePath);


                XmlNodeList rootNodeList = TemplateXml.GetElementsByTagName("YMM-Template");
                if (rootNodeList.Count <= 0) return false;
           
                XmlNode rootNode = rootNodeList[0];
           
                XmlNode Item = rootNode.FirstChild;

                while (Item != null)
                {
                    if (Item.Name == "TemplateInfo")
                    {
                        foreach (XmlAttribute NodeAttribute in Item.Attributes)
                        {
                            if (NodeAttribute.Name == "Name")
                            {

                            }                           
                        }
                    }
                    else if (Item.Name == "TemplateEvents")
                    {
                        // now load the events
                        XmlNode EventNode = Item.FirstChild;

                        while (EventNode != null)
                        {

                            SingleEventSimulation newEvent = new SingleEventSimulation();
                            foreach (XmlAttribute NodeAttribute in EventNode.Attributes)
                            {
                                if (NodeAttribute.Name == "Type")
                                {
                                    newEvent.SimulationType = (SIMTYPE)Enum.Parse(typeof(SIMTYPE), NodeAttribute.Value);
                                }
                                else if (NodeAttribute.Name == "EventDef")
                                {
                                    newEvent.Event = new object();
                                    newEvent.Event = (MOUSEVENT)Enum.Parse(typeof(MOUSEVENT), NodeAttribute.Value); 
                                }
                                else if (NodeAttribute.Name == "CursorPositionX")
                                {
                                    newEvent.PositionX = Convert.ToInt32(NodeAttribute.Value);
                                }
                                else if (NodeAttribute.Name == "CursorPositionY")
                                {
                                    newEvent.PositionY = Convert.ToInt32(NodeAttribute.Value);
                                }
                            }

                            AddEvent(newEvent);
                            
                            EventNode = EventNode.NextSibling;
                        }

                    }
                    
                    Item = Item.NextSibling;
                }
            }
            catch (Exception exc)
            {

            }

            return true;
        }

        public bool OnSaveAsTemplate()
        {
            SaveFileDialog SaveTemplateDlg = new SaveFileDialog();
            SaveTemplateDlg.InitialDirectory = Environment.SpecialFolder.Programs.ToString();
            SaveTemplateDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            SaveTemplateDlg.RestoreDirectory = true;

            if (SaveTemplateDlg.ShowDialog() == DialogResult.OK)
            {
                SaveTemplateInFile(SaveTemplateDlg.FileName);
            }

            return true;
        }

        private void SaveTemplateInFile(String sDestinationPath)
        {
            XmlDocument TemplateXml = new XmlDocument();

            // xml declaration
            XmlNode docNode = TemplateXml.CreateXmlDeclaration("1.0", "utf-8", null);
            TemplateXml.AppendChild(docNode);

            // the root node
            XmlNode rootNode = TemplateXml.CreateElement("YMM-Template");
            TemplateXml.AppendChild(rootNode);

            // Template Info
            XmlNode TempInfo = TemplateXml.CreateElement("TemplateInfo");
            // Attribute 'Name'
            XmlAttribute TempInfo_Name = TemplateXml.CreateAttribute("Name");
            TempInfo_Name.Value = "DummyName1";
            // att the attribute to the node
            TempInfo.Attributes.Append(TempInfo_Name);
            // now at the whole node
            rootNode.AppendChild(TempInfo);
            
            // Template Events
            XmlNode TempEvents = TemplateXml.CreateElement("TemplateEvents");
            foreach (SingleEventSimulation single in EventTemplateCollection)
            {
                XmlNode TempSingleEvent = TemplateXml.CreateElement("Event");
                //
                // attribute 'Type'
                XmlAttribute Event_Type = TemplateXml.CreateAttribute("Type");
                Event_Type.Value = single.SimulationType.ToString();
                TempSingleEvent.Attributes.Append(Event_Type);
                //
                // attribute 'EventDef'
                XmlAttribute Event_EventDef = TemplateXml.CreateAttribute("EventDef");
                Event_EventDef.Value = single.Event.ToString();
                TempSingleEvent.Attributes.Append(Event_EventDef);
                //
                // attribute 'CursorPositionX'
                XmlAttribute Event_CursorPositionX = TemplateXml.CreateAttribute("CursorPositionX");
                Event_CursorPositionX.Value = single.PositionX.ToString();
                TempSingleEvent.Attributes.Append(Event_CursorPositionX);
                //
                // attribute 'CursorPositionY'
                XmlAttribute Event_CursorPositionY = TemplateXml.CreateAttribute("CursorPositionY");
                Event_CursorPositionY.Value = single.PositionY.ToString();
                TempSingleEvent.Attributes.Append(Event_CursorPositionY);
                //
                //
                TempEvents.AppendChild(TempSingleEvent);
            }
            // finally add the template events to the root
            rootNode.AppendChild(TempEvents);

            try
            {
                // save the xml file
                TemplateXml.Save(sDestinationPath);
            }
            catch (Exception exc)
            {

            }
        }

    }
}

#if OLD

    public class ConfigManagement
    {
        public enum CONFIGFILETPYE { XML, TEXT };
        public enum STARTPANELTYPE { NORMAL, SELPREMSTANDARD };
        public enum PRODUCTTYPE { NONE, STANDARD, PREMIUM, ALL };
        public enum PRODUCTSELECTIONTYPE { CARROUSEL, TILE };

        public CONFIGFILETPYE sConfigFileType;
        public String sConfigFileName;
        public String sConfigFileDirectory;
        public String sConfigFilePath;
        public XmlDocument xConfigFileXml;

        // ////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////
        // settings
        // ////////////////////////////////////////////////////////////////////

        // Jump Back to MainMenu
        // ScreensaverToMenuRecessTimeInUse
        public bool screensaverToMenuRecessTimeInUse;
        public bool GetScreensaverToMenuRecessTimeInUse() { return screensaverToMenuRecessTimeInUse; }
        public void SetScreensaverToMenuRecessTimeInUse(bool newInUse) { screensaverToMenuRecessTimeInUse = newInUse; }
        // ScreensaverToMenuRecessTime
        public int screensaverToMenuRecessTime;
        public int GetScreensaverToMenuRecessTime() { return screensaverToMenuRecessTime; }
        public void SetScreensaverToMenuRecessTime(int newTime) { screensaverToMenuRecessTime = newTime; }

        // StartSettings
        // StartPanelType
        public STARTPANELTYPE startPanelType;
        public STARTPANELTYPE GetStartPanelType() { return startPanelType; }
        public void SetStartPanelType(STARTPANELTYPE newType) { startPanelType = newType; }
        // HomeWindowProdTypeStandardPreselection
        public PRODUCTTYPE homeWindowProdTypeStandardPreselection;
        public PRODUCTTYPE GetHomeWindowProdTypeStandardPreselection() { return homeWindowProdTypeStandardPreselection; }
        public void SetHomeWindowProdTypeStandardPreselection(PRODUCTTYPE newType) { homeWindowProdTypeStandardPreselection = newType; }
        // ProductSelectionWindowStyle
        public PRODUCTSELECTIONTYPE productSelectionWindowStyle;
        public PRODUCTSELECTIONTYPE GetProductSelectionWindowStyle() { return productSelectionWindowStyle; }
        public void SetProductSelectionWindowStyle(PRODUCTSELECTIONTYPE newType) { productSelectionWindowStyle = newType; }


        // BackgroundImage
        // BackgroundImageInUse
        public bool backgroundImageInUse;
        public bool GetBackgroundImageInUse() { return backgroundImageInUse; }
        public void SetBackgroundImageInUse(bool newValue) { backgroundImageInUse = newValue; }
        // BackgroundImageImageName
        public String backgroundImageImagePath;
        public String GetBackgroundImageImagePath() { return backgroundImageImagePath; }
        public void SetBackgroundImageImagePath(String newValue) { backgroundImageImagePath = newValue; }

        // startProcessOnPictureClickEnabled
        public bool startProcessOnPictureClickEnabled;
        public bool GetStartProcessOnPictureClickEnabled() { return startProcessOnPictureClickEnabled; }
        public void SetStartProcessOnPictureClickEnabled(bool newValue) { startProcessOnPictureClickEnabled = newValue; }


        // /////////////////////////////////////////////////////////////////////////////////////////
        // Advertisement Image and Video ( size and location )
        public bool UsePresel3UseSpecialCoordsEnabled;
        public bool GetUsePresel3UseSpecialCoordsEnabled() { return UsePresel3UseSpecialCoordsEnabled; }
        public void SetUsePresel3UseSpecialCoordsEnabled(bool newValue) { UsePresel3UseSpecialCoordsEnabled = newValue; }
        // coords location (one coord for image and video) only one is visible at the same time
        // X coord
        public int Presel3SpecialCoordLocationX;
        public int GetPresel3SpecialCoordLocationX() { return Presel3SpecialCoordLocationX; }
        public void SetPresel3SpecialCoordLocationX(int newValue) { Presel3SpecialCoordLocationX = newValue; }
        // Y coord
        public int Presel3SpecialCoordLocationY;
        public int GetPresel3SpecialCoordLocationY() { return Presel3SpecialCoordLocationY; }
        public void SetPresel3SpecialCoordLocationY(int newValue) { Presel3SpecialCoordLocationY = newValue; }
        // size  (one size for image and video) only one is visible at the same time
        // width
        public int Presel3SpecialCoordWidth;
        public int GetPresel3SpecialCoordWidth() { return Presel3SpecialCoordWidth; }
        public void SetPresel3SpecialCoordWidth(int newValue) { Presel3SpecialCoordWidth = newValue; }
        // height
        public int Presel3SpecialCoordHeight;
        public int GetPresel3SpecialCoordHeight() { return Presel3SpecialCoordHeight; }
        public void SetPresel3SpecialCoordHeight(int newValue) { Presel3SpecialCoordHeight = newValue; }


        public ConfigManagement()
        {
            sConfigFileType = CONFIGFILETPYE.XML;
            sConfigFileName = "touchconf.xml";
            sConfigFileDirectory = String.Format("{0}\\SesKion\\CoffeeCon\\", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            sConfigFilePath = String.Format("{0}\\SesKion\\CoffeeCon\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), sConfigFileName);
            startProcessOnPictureClickEnabled = false;

            UsePresel3UseSpecialCoordsEnabled = false;
        }

        ~ConfigManagement()
        {

        }



        private void CreateStandardConfigXml()
        {
            xConfigFileXml = new XmlDocument();

            // write the xml declaration
            XmlNode docNode = xConfigFileXml.CreateXmlDeclaration("1.0", "utf-8", null);
            xConfigFileXml.AppendChild(docNode);

            // write the 'CoffeConTouchSettingsNode'
            XmlNode CoffeConTouchSettingsNode = xConfigFileXml.CreateElement("CoffeConTouch-Settings");
            xConfigFileXml.AppendChild(CoffeConTouchSettingsNode);

            // ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // now let's add the coffeecon-touch standard settings
            try
            {

                // ////////////////////////////////////////////////////////////////////////////////////////////////////////
                // 'ScreensaverToMenuRecessTime'
                XmlNode ScreensaverToMenuRecessTimeNode = xConfigFileXml.CreateElement("ScreensaverToMenuRecessTime");
               
                
                // Attribute 'InUse' 0 or 1
                XmlAttribute ScreensaverToMenuRecessTimeInUseAttribute = xConfigFileXml.CreateAttribute("InUse");
                ScreensaverToMenuRecessTimeInUseAttribute.Value = "01";
                ScreensaverToMenuRecessTimeNode.Attributes.Append(ScreensaverToMenuRecessTimeInUseAttribute);

                // Attribute 'RecessTime' in milliseconds
                XmlAttribute ScreensaverToMenuRecessTimeRecessTimeAttribute = xConfigFileXml.CreateAttribute("RecessTime");
                ScreensaverToMenuRecessTimeRecessTimeAttribute.Value = Convert.ToString((1000 * 60 * 5));   // 300000 ms = 5 minutes
                ScreensaverToMenuRecessTimeNode.Attributes.Append(ScreensaverToMenuRecessTimeRecessTimeAttribute);

             
                // now add the whole node
                CoffeConTouchSettingsNode.AppendChild(ScreensaverToMenuRecessTimeNode);
                // ////////////////////////////////////////////////////////////////////////////////////////////////////////
                
                /*
                // comment
                XmlComment ScreensaverToMenuRecessTimeInUseComment = xConfigFileXml.CreateComment("ScreensaverToMenuRecessTimeInUseComment");
                ScreensaverToMenuRecessTimeInUseComment.Value = "Zeitspanne bis zum Automatischen Rücksprung an die Produkttypenauswahl\nRecessTime = [millisekunden]\nInUse = [0|1]";
                xConfigFileXml.InsertBefore(ScreensaverToMenuRecessTimeInUseComment, ScreensaverToMenuRecessTimeNode);
                */
            }
            catch (Exception exc)
            {

            }


            try
            {
                // ////////////////////////////////////////////////////////////////////////////////////////////////////////
                // 'StartSettings'          
                // Values: 
                XmlNode StartSettingsNode = xConfigFileXml.CreateElement("StartSettings");
                
                // Attribute 'StartPanel'  | PremStdSelection | Normal
                XmlAttribute StartPanelAttribute = xConfigFileXml.CreateAttribute("StartPanel");
                StartPanelAttribute.Value = "Normal";
                StartSettingsNode.Attributes.Append(StartPanelAttribute);
                
                // Attribute 'HomeWindowTypeProdTypeStandardPreselection'  | Premium | Standard | All
                XmlAttribute ProdTypeStandardPreselectionPanelAttribute = xConfigFileXml.CreateAttribute("HomeWindowProdTypeStandardPreselection");
                ProdTypeStandardPreselectionPanelAttribute.Value = "All";
                StartSettingsNode.Attributes.Append(ProdTypeStandardPreselectionPanelAttribute);
                
                // Attribute 'ProductSelectionWindowStyle'  | Tile | Carrousel
                XmlAttribute ProductSelectionWindowStylePanelAttribute = xConfigFileXml.CreateAttribute("ProductSelectionWindowStyle");
                ProductSelectionWindowStylePanelAttribute.Value = "Carrousel";
                StartSettingsNode.Attributes.Append(ProductSelectionWindowStylePanelAttribute);

                // now add the whole node
                CoffeConTouchSettingsNode.AppendChild(StartSettingsNode);
                // ////////////////////////////////////////////////////////////////////////////////////////////////////////
                
                /*
                // comment
                XmlComment StartSettingsComment = xConfigFileXml.CreateComment("StartSettingsComment");
                StartSettingsComment.Value = "Angabe der Starteinstellungen\nStartPanel = Normal | [PremStdSelection]\nHomeWindowProdTypeStandardPreselection = Standard | Premium | All\nProductSelectionWindowStyle = Carrousel | Tile";
                xConfigFileXml.InsertBefore(StartSettingsComment, StartSettingsNode);
                */

            }
            catch (Exception exc)
            {

            }


            try
            {
                // ////////////////////////////////////////////////////////////////////////////////////////////////////////
                // BackgroundImage

                // BackgroundImage
                XmlNode BackgroundImageNode = xConfigFileXml.CreateElement("BackgroundImage");

                // Attribute 'BackgroundImageInUse'  | 0 | 1 
                XmlAttribute BackgroundImageInUseAttribute = xConfigFileXml.CreateAttribute("BackgroundImageInUse");
                BackgroundImageInUseAttribute.Value = "0";
                BackgroundImageNode.Attributes.Append(BackgroundImageInUseAttribute);

                // Attribute 'BackgroundImageImageName'  [imagepath]
                XmlAttribute BackgroundImageImageNameAttribute = xConfigFileXml.CreateAttribute("BackgroundImageImageName");
                BackgroundImageImageNameAttribute.Value = "";
                BackgroundImageNode.Attributes.Append(BackgroundImageImageNameAttribute);

                // now add the whole node
                CoffeConTouchSettingsNode.AppendChild(BackgroundImageNode);
                // ////////////////////////////////////////////////////////////////////////////////////////////////////////


            }
            catch (Exception exc)
            {

            }


            try
            {
                // ////////////////////////////////////////////////////////////////////////////////////////////////////////
                // StartProcessOnPictureClickEnabledNode

                // BackgroundImage
                XmlNode StartProcessOnPictureClickEnabledNode = xConfigFileXml.CreateElement("StartProcessOnPictureClick");

                // Attribute 'StartProcessOnPictureClickEnabled'  | 0 | 1 
                XmlAttribute StartProcessOnPictureClickEnabledAttribute = xConfigFileXml.CreateAttribute("StartProcessOnPictureClickEnabled");
                StartProcessOnPictureClickEnabledAttribute.Value = "0";     // standard = disabled
                StartProcessOnPictureClickEnabledNode.Attributes.Append(StartProcessOnPictureClickEnabledAttribute);

                // now add the whole node
                CoffeConTouchSettingsNode.AppendChild(StartProcessOnPictureClickEnabledNode);
                // ////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
            catch (Exception exc)
            {

            }

            try
            {
                // save the xml file
                xConfigFileXml.Save(sConfigFilePath);
            }
            catch (Exception exc)
            {

            }
        }
     

        
        public bool OpenConfigFile()
        {

            try
            {
                if (!File.Exists(sConfigFilePath))
                {
                    // look for the directory, maybe we have to create that first
                    if (!File.Exists(sConfigFileDirectory))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(sConfigFileDirectory);
                        }
                        catch (Exception exc)
                        {
                            // can't create directory
                        }
                    }
                    CreateStandardConfigXml();
                }
                else
                {
                    xConfigFileXml = new XmlDocument();
                    xConfigFileXml.Load(sConfigFilePath);
                }
            }
            catch (Exception exc)
            {


            }

            
            return true;
        }

        public bool CloseConfigFile()
        {
            return true;
        }

        public void SetStandardSettings()
        {
            SetScreensaverToMenuRecessTime(600);
            SetScreensaverToMenuRecessTimeInUse(true);                  
            SetBackgroundImageInUse(false);                             // no background image / uses high system rescources
            SetStartPanelType(STARTPANELTYPE.NORMAL);                   // without preselection
            SetProductSelectionWindowStyle(PRODUCTSELECTIONTYPE.TILE);  // standard menu : tile
            SetStartProcessOnPictureClickEnabled(false);                // only start with clicking the "start" button
            SetUsePresel3UseSpecialCoordsEnabled(false);                // use the standard cords and size
        }

        public bool LoadSettings()
        {
            SetStandardSettings();
            
            if (!OpenConfigFile()) return false;
            if (xConfigFileXml == null) return false;

            XmlNodeList settingsNodeList = xConfigFileXml.GetElementsByTagName("CoffeConTouch-Settings");
            if (settingsNodeList.Count <= 0) return false;
            XmlNode CoffeConTouchSettingsNode = settingsNodeList[0];

            XmlNode Item = CoffeConTouchSettingsNode.FirstChild;

            while (Item != null)
            {
                if (Item.Name == "ScreensaverToMenuRecessTime")
                {
                    foreach (XmlAttribute NodeAttribute in Item.Attributes) {
                       
                        if (NodeAttribute.Name == "InUse")
                        {
                            try {
                                SetScreensaverToMenuRecessTimeInUse(Convert.ToBoolean(Convert.ToInt32(NodeAttribute.Value)));
                            }catch(Exception exc) {

                            }
                        }
                        else if (NodeAttribute.Name == "RecessTime")
                        {
                            int iRecessTime = 0;
                            try
                            {
                                SetScreensaverToMenuRecessTime(Convert.ToInt32(NodeAttribute.Value));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                    }

                }
                else if (Item.Name == "StartSettings")
                {
                    foreach (XmlAttribute NodeAttribute in Item.Attributes)
                    {

                        if (NodeAttribute.Name == "StartPanel")
                        {
                            if (NodeAttribute.Value == "Normal")
                            {
                                SetStartPanelType(STARTPANELTYPE.NORMAL);
                            }
                            else if (NodeAttribute.Value == "PremStdSelection")
                            {
                                SetStartPanelType(STARTPANELTYPE.SELPREMSTANDARD);
                            }
                        }
                        else if (NodeAttribute.Name == "HomeWindowProdTypeStandardPreselection")
                        {
                            if (NodeAttribute.Value == "Standard")
                            {
                                SetHomeWindowProdTypeStandardPreselection(PRODUCTTYPE.STANDARD);
                            }
                            else if (NodeAttribute.Value == "Premium")
                            {
                                SetHomeWindowProdTypeStandardPreselection(PRODUCTTYPE.PREMIUM);
                            }
                            else
                            {
                                SetHomeWindowProdTypeStandardPreselection(PRODUCTTYPE.ALL);
                            }
                        }
                        else if (NodeAttribute.Name == "ProductSelectionWindowStyle")
                        {
                            if (NodeAttribute.Value == "Tile")
                            {
                                SetProductSelectionWindowStyle(PRODUCTSELECTIONTYPE.TILE);
                            }
                            else if (NodeAttribute.Value == "Carrousel")
                            {
                                SetProductSelectionWindowStyle(PRODUCTSELECTIONTYPE.CARROUSEL);
                            }
                        }
                    }
                }
                else if (Item.Name == "BackgroundImage")
                {
                    foreach (XmlAttribute NodeAttribute in Item.Attributes)
                    {
                        if (NodeAttribute.Name == "BackgroundImageInUse")
                        {
                            try
                            {
                                SetBackgroundImageInUse(Convert.ToBoolean(Convert.ToInt32(NodeAttribute.Value)));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                        else if (NodeAttribute.Name == "BackgroundImageImageName")
                        {
                            try
                            {
                                SetBackgroundImageImagePath(NodeAttribute.Value);
                            }
                            catch (Exception exc)
                            {
                                // now legal path found -> deactivate it
                                SetBackgroundImageInUse(false);
                                SetBackgroundImageImagePath("");
                            }
                        }
                    }
                }
                else if (Item.Name == "StartProcessOnPictureClick")
                {
                    foreach (XmlAttribute NodeAttribute in Item.Attributes)
                    {
                        if (NodeAttribute.Name == "StartProcessOnPictureClickEnabled")
                        {
                            try
                            {
                                SetStartProcessOnPictureClickEnabled(Convert.ToBoolean(Convert.ToInt32(NodeAttribute.Value)));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                    }
                }
                else if (Item.Name == "Presel3UseSpecialCoords")
                {
                    foreach (XmlAttribute NodeAttribute in Item.Attributes)
                    {
                        if (NodeAttribute.Name == "UsePresel3UseSpecialCoordsEnabled")
                        {
                            try
                            {
                                SetUsePresel3UseSpecialCoordsEnabled(Convert.ToBoolean(Convert.ToInt32(NodeAttribute.Value)));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                        else if (NodeAttribute.Name == "Presel3SpecialCoordLocationX")
                        {
                            try
                            {
                                SetPresel3SpecialCoordLocationX(Convert.ToInt32(NodeAttribute.Value));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                        else if (NodeAttribute.Name == "Presel3SpecialCoordLocationY")
                        {
                            try
                            {
                                SetPresel3SpecialCoordLocationY(Convert.ToInt32(NodeAttribute.Value));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                        else if (NodeAttribute.Name == "Presel3SpecialCoordWidth")
                        {
                            try
                            {
                                SetPresel3SpecialCoordWidth(Convert.ToInt32(NodeAttribute.Value));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                        else if (NodeAttribute.Name == "Presel3SpecialCoordHeight")
                        {
                            try
                            {
                                SetPresel3SpecialCoordHeight(Convert.ToInt32(NodeAttribute.Value));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                    }


                }

                Item = Item.NextSibling;
            }


            CloseConfigFile();


            // set some special settings

            // no background if carrousel mode is active
            if (GetProductSelectionWindowStyle() == PRODUCTSELECTIONTYPE.CARROUSEL)
            {
                SetBackgroundImageInUse(false);
            }


            return true;
        }




    }
#endif
