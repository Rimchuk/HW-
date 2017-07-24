using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW3.interfaces
{
    public interface IPerson
    {
       string Name { get; set; }
       string Surname { set; get; }
       int Age { get; set; }
        int ID { set; get; }
    }
}
