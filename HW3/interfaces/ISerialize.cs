using HW3.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW3.interfaces
{
    public interface ISerialize
    {
        void SerializeList(List<IPerson> list);
         List<IPerson> DeserializeList();
    }
}
