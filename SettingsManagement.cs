using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace YourMouseMaster
{
    class SettingsManagement
    {
        public enum STORETYPE { XML, REGISTRY }
        public SettingsVars Vars = new SettingsVars();

        String SettingsFileName;
        String SettingsFileDirectory;
        String SettingsFilePath;

        public SettingsManagement()
        {
            SettingsFileName = "settings.xml";
            SettingsFileDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SettingsFilePath = String.Format("{0}\\{1}", SettingsFileDirectory, SettingsFileName);
        }

        public bool GetSettings(STORETYPE StoreType)
        {
            switch (StoreType)
            {
                case STORETYPE.XML:
                    return LoadSettingsFromXML();
                    break;

                case STORETYPE.REGISTRY:
                    break;
            }

            return true;
        }

        public bool SetSettings(STORETYPE StoreType)
        {

            switch (StoreType)
            {
                case STORETYPE.XML:
                    return SaveSettingsIntoXML();
                    break;

                case STORETYPE.REGISTRY:
                    break;
            }

            return true;
        }

        private bool LoadSettingsFromXML()
        {
            XmlDocument XmlDoc = new XmlDocument();
            try
            {
                if (!File.Exists(SettingsFilePath))
                {
                    // file not found
                    return false;
                }

                XmlDoc = new XmlDocument();
                XmlDoc.Load(SettingsFilePath);

                XmlNodeList rootNodeList = XmlDoc.GetElementsByTagName("YMM-Settings");
                if (rootNodeList.Count <= 0) return false;

                XmlNode rootNode = rootNodeList[0];
      
                XmlNode Item = rootNode.FirstChild;

                while (Item != null)
                {
                    if (Item.Name == "UseKeyboardSniffer")
                    {
                        foreach (XmlAttribute NodeAttribute in Item.Attributes)
                        {
                            try
                            {
                                if (NodeAttribute.Name == "Active")
                                {
                                    Vars.UseKeyboardSniffer = (bool)bool.Parse(NodeAttribute.Value);
                                }
                            }
                            catch (Exception exc)
                            {
                                // problem with parsing 
                            }
                        }
                    }
                    else if (Item.Name == "ShortKeySimulationToggle")
                    {
                        foreach (XmlAttribute NodeAttribute in Item.Attributes)
                        {
                            try
                            {
                                if (NodeAttribute.Name == "Key")
                                {
                                    Vars.ShortKeySimulationToggle = (Keys)Enum.Parse(typeof(Keys), NodeAttribute.Value);
                                }
                            }
                            catch (Exception exc)
                            {
                                // problem with parsing 
                            }
                        }
                    }
                    else if (Item.Name == "ShortKeyAddEventMouse")
                    {
                        foreach (XmlAttribute NodeAttribute in Item.Attributes)
                        {
                            try
                            {
                                if (NodeAttribute.Name == "Key")
                                {
                                    Vars.ShortKeyAddEventMouse = (Keys)Enum.Parse(typeof(Keys), NodeAttribute.Value);
                                }
                            }
                            catch (Exception exc)
                            {
                                // problem with parsing 
                            }
                        }
                    }
                    else if (Item.Name == "ShortKeyAddEventKeyboard")
                    {
                        foreach (XmlAttribute NodeAttribute in Item.Attributes)
                        {
                            try
                            {
                                if (NodeAttribute.Name == "Key")
                                {
                                    Vars.ShortKeyAddEventKeyboard = (Keys)Enum.Parse(typeof(Keys), NodeAttribute.Value);
                                }
                            }
                            catch (Exception exc)
                            {
                                // problem with parsing 
                            }
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

        private bool SaveSettingsIntoXML()
        {
            XmlDocument XmlDoc = new XmlDocument();
     
            // xml declaration
            XmlNode docNode = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlDoc.AppendChild(docNode);

            // the root node
            XmlNode rootNode = XmlDoc.CreateElement("YMM-Settings");
            XmlDoc.AppendChild(rootNode);

            // ///////////////////////////////////////////////////////////////////////////////////////
            // UseKeyboardSniffer
            XmlNode Node_UseKeyboardSniffer = XmlDoc.CreateElement("UseKeyboardSniffer");
            // Attribute 'Active'
            XmlAttribute Attribute_UseKeyboardSniffer_Active = XmlDoc.CreateAttribute("Active");
            Attribute_UseKeyboardSniffer_Active.Value = Vars.UseKeyboardSniffer.ToString();
            // add the attribute to the node
            Node_UseKeyboardSniffer.Attributes.Append(Attribute_UseKeyboardSniffer_Active);
            // now add the whole node
            rootNode.AppendChild(Node_UseKeyboardSniffer);
            // ///////////////////////////////////////////////////////////////////////////////////////

            // ///////////////////////////////////////////////////////////////////////////////////////
            // ShortKeySimulationToggle
            XmlNode Node_ShortKeySimulationToggle = XmlDoc.CreateElement("ShortKeySimulationToggle");
            // Attribute 'Key'
            XmlAttribute Attribute_ShortKeySimulationToggle_Key = XmlDoc.CreateAttribute("Key");
            Attribute_ShortKeySimulationToggle_Key.Value = Vars.ShortKeySimulationToggle.ToString();
            // add the attribute to the node
            Node_ShortKeySimulationToggle.Attributes.Append(Attribute_ShortKeySimulationToggle_Key);
            // now add the whole node
            rootNode.AppendChild(Node_ShortKeySimulationToggle);
            // ///////////////////////////////////////////////////////////////////////////////////////

            // ///////////////////////////////////////////////////////////////////////////////////////
            // ShortKeyAddEventMouse
            XmlNode Node_ShortKeyAddEventMouse = XmlDoc.CreateElement("ShortKeyAddEventMouse");
            // Attribute 'Key'
            XmlAttribute Attribute_ShortKeyAddEventMouse_Key = XmlDoc.CreateAttribute("Key");
            Attribute_ShortKeyAddEventMouse_Key.Value = Vars.ShortKeyAddEventMouse.ToString();
            // add the attribute to the node
            Node_ShortKeyAddEventMouse.Attributes.Append(Attribute_ShortKeyAddEventMouse_Key);
            // now add the whole node
            rootNode.AppendChild(Node_ShortKeyAddEventMouse);
            // ///////////////////////////////////////////////////////////////////////////////////////

            // ///////////////////////////////////////////////////////////////////////////////////////
            // ShortKeyAddEventKeyboard
            XmlNode Node_ShortKeyAddEventKeyboard = XmlDoc.CreateElement("ShortKeyAddEventKeyboard");
            // Attribute 'Key'
            XmlAttribute Attribute_ShortKeyAddEventKeyboard_Key = XmlDoc.CreateAttribute("Key");
            Attribute_ShortKeyAddEventKeyboard_Key.Value = Vars.ShortKeyAddEventKeyboard.ToString();
            // add the attribute to the node
            Node_ShortKeyAddEventKeyboard.Attributes.Append(Attribute_ShortKeyAddEventKeyboard_Key);
            // now add the whole node
            rootNode.AppendChild(Node_ShortKeyAddEventKeyboard);
            // ///////////////////////////////////////////////////////////////////////////////////////


            try
            {
                // save the xml file
                XmlDoc.Save(SettingsFilePath);
            }
            catch (Exception exc)
            {
                return false;

            }
       
            return true;
        }

    }
}
