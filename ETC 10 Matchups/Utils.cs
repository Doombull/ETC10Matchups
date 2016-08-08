using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace ETC10Matchups
{
    public static class Utils
    {
        #region Members

        private static XmlDocument _settingsFile;
        private static string _settingsFilePath;

        #endregion

        #region Properties

        /// <summary>
        /// A static reference to the settings file, so we do not have to load the document each time we
        /// change a matchup
        /// </summary>
        public static XmlDocument SettingsFile
        {
            get
            {
                //Check if we have already loaded the settings file
                if (_settingsFile == null)
                {

                    //Make sure the file exists
                    if (!File.Exists(SettingsFilePath))
                        throw new ApplicationException("Settings file not found at " + SettingsFilePath);

                    //Load the file
                    _settingsFile = new XmlDocument();
                    _settingsFile.Load(SettingsFilePath);
                }

                return _settingsFile;
            }
        }

        /// <summary>
        /// The location of the settings file with the matchups
        /// </summary>
        public static string SettingsFilePath
        {
            get
            {
                if (String.IsNullOrEmpty(_settingsFilePath))
                    _settingsFilePath = Assembly.GetExecutingAssembly().Location.Replace(".exe", ".Settings.xml");

                return _settingsFilePath;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This inserts a node somewhere in a list in alphabetical order
        /// </summary>
        /// <param name="newNode"></param>
        /// <param name="parentNode"></param>
        /// <param name="siblingXPath"></param>
        /// <param name="sortAttribute"></param>
        public static void InsertNodeInOrder(XmlElement newNode, XmlNode parentNode, string siblingXPath, string sortAttribute)
        {
            //Loop through all the other armies and insert it in alphabetical order
            bool bfound = false;
            XmlNodeList siblings = parentNode.SelectNodes(siblingXPath);

            if (siblings != null)
            {
                foreach (XmlNode node in siblings)
                {
                    if (String.Compare(newNode.Attributes[sortAttribute].Value, node.Attributes[sortAttribute].Value) <= 0)
                    {
                        parentNode.InsertBefore(newNode, node);
                        bfound = true;
                        break;
                    }
                }
            }

            //If there was no node to insert it before, put it at the end
            if (!bfound)
                parentNode.AppendChild(newNode);
        }

        #endregion
    }
}
