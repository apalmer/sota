﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Domain
{
    public class Subject : ISubject
    {
        public int Get(int input)
        {
            return input;
        }
    }
}
