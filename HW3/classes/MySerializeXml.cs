using HW3.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HW3.classes
{
    public class MySerializeXml : ISerialize
    {
        public void SerializeList(List<IPerson> list)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<IPerson>));
            using (FileStream fs = new FileStream("worker.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, list);
            }
        }

        public List<IPerson> DeserializeList()
        {
            if (File.Exists("worker.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<IPerson>));
                List<IPerson> myWorker;
                using (FileStream fs = new FileStream("worker.xml", FileMode.OpenOrCreate))
                {
                    myWorker = (List<IPerson>)xs.Deserialize(fs);
                }
                return myWorker;
            }
            else
            {
                return new List<IPerson>();
            }
        }
    }
}
