

using HW3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW3.classes
{
    [XmlInclude(typeof(Worker))]

    public abstract class Person: IPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { set; get; }
        public int Age { get; set; }
        

        public Person()
        {
        }

        public Person(int id ,string name, string surname, int age )
        {
            ID = id;
            Name = name;
            Surname = surname;
            Age = age;
            
            
        }
        public override string ToString()
        {
            return string.Format("ID: {0}\nИмя: {1}\nФамилия: {2}\nВозраст: {3}\n", ID, Name, Surname, Age);
        }

    }
}
