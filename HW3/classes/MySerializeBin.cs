﻿using HW3.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HW3.classes
{
    public class MySerializeBin : ISerialize
    {
        public void SerializeList(List<Person> list)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("worker.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, list);
            }
        }

        public List<Person> DeserializeList()
        {
            if (File.Exists("worker.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<Person> myWorker;
                using (FileStream fs = new FileStream("worker.dat", FileMode.OpenOrCreate))
                {
                    myWorker = (List<Person>)bf.Deserialize(fs);
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
