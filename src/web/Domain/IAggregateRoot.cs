﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Domain
{
    public interface IAggregateRoot
    {
        String GetResponse(IDictionary<String, Object> values);
    }
}
