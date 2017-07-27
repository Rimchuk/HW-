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
        public void SerializeList(List<Person> list)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream("worker.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, list);
            }
        }

        public List<Person> DeserializeList()
        {
            if (File.Exists("worker.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Person>));
                List<Person> myWorker;
                using (FileStream fs = new FileStream("worker.xml", FileMode.OpenOrCreate))
                {
                    myWorker = (List<Person>)xs.Deserialize(fs);
                }
                return myWorker;
            }
            else
            {
                return new List<Person>();
            }
        }
    }
}
