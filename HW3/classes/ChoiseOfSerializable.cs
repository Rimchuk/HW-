using HW3.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HW3.classes
{
    class ChoiseOfSerializable: IChoiseOfSerializable
    {
        public string ChoiserOfSerializable()

        {
            string choiseOfSerializable = "";
            if (!File.Exists("option.ini"))
            {
                TextWriter tw = new StreamWriter("option.ini", true);
                tw.WriteLine("XML");
                tw.Close();
                choiseOfSerializable = "XML";
                return choiseOfSerializable;
            }
            else
            {
                using (StreamReader sr = new StreamReader("option.ini", System.Text.Encoding.Default))
                {
                    choiseOfSerializable = sr.ReadLine();
                }
                return choiseOfSerializable;
            }
        }
    }
}
