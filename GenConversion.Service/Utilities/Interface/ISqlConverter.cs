﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenConversion.Service.Utilities.Interface
{
    public interface ISqlConverter
    {
        string ToSql(string json);
    }
}
