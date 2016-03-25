using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace _3DFamilyTreeFileUtility._3DFamilyTree
{
    public class AppDataStorage
    {
        public string FamilyInfoFileName;
        public string FamilySearchUserName;
        public string FamilySearchStartingId;

        public AppDataStorage()
        {
            

        }

        public static AppDataStorage Read()
        {
            AppDataStorage retAppDataStorage = new AppDataStorage();
            var appDataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "3DFT", "3DFT.xml");

            if (File.Exists(appDataFile))
            {
                
                // Construct an instance of the XmlSerializer with the type
                // of object that is being deserialized.
                XmlSerializer serializer = new XmlSerializer(typeof (AppDataStorage));
                // To read the file, create a FileStream.
                using (FileStream myFileStream = new FileStream(appDataFile, FileMode.Open))
                {
                    // Call the Deserialize method and cast to the object type.
                    return (AppDataStorage) serializer.Deserialize(myFileStream);
                }
            }
            return retAppDataStorage;

        }

        public void Save()
        {
            var appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "3DFT");
            if (!Directory.Exists(appDataFolder))
                Directory.CreateDirectory(appDataFolder);

            var appDataFile = Path.Combine(appDataFolder, "3DFT.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(AppDataStorage));

            var settings = new XmlWriterSettings { Indent = true, IndentChars = "\t", CloseOutput = true };

            using (var writer = XmlWriter.Create(File.Create(appDataFile), settings))
            {
                serializer.Serialize(writer, this);
            }
        }
    }

}
