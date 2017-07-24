using HW3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.classes
{
    [Serializable]
   public class Worker : Person, IWorker 
    { 
        public Worker()
    {
    }

    public Worker(int id, string name, string surname, int age,   string phoneNumber, string eMail) : base(id, name, surname, age)
        {
                     
        PhoneNumber = phoneNumber;
        EMail = eMail;
    }

           
    public string PhoneNumber { set; get; }
    public string EMail { set; get; }

    public override string ToString()
    {
        return string.Format("ID: {0}\nИмя: {1}\nФамилия: {2}\nВозраст: {3}\nНомер телефона: {4}\nE-Mail: {5}\n\n", ID, Name, Surname, Age,   PhoneNumber, EMail);
    }
}
}
