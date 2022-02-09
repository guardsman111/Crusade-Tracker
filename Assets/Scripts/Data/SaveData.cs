using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

namespace CrusadeTracker
{
    public static class SaveData
    {
        public static void SaveForceData(ForceDataClass data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ForceDataClass));
            var stream = new FileStream(Path.Combine(Application.persistentDataPath, "TestCrusadeFile.xml"), FileMode.Create);
            serializer.Serialize(stream, data);
            stream.Close();
        }

        public static ForceDataClass LoadForceData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ForceDataClass));
            var stream = new FileStream(Path.Combine(Application.persistentDataPath, "TestCrusadeFile.xml"), FileMode.Open);
            ForceDataClass container = serializer.Deserialize(stream) as ForceDataClass;
            stream.Close();

            return container;
        }
    }
}
