﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW3.interfaces
{
    public interface IWorker: IPerson
    {
        
        string PhoneNumber { set; get; }
        string EMail { set; get; }
    }
}
