using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenConversion.Service.Utilities.Interface
{
    public interface IJsonConverter
    {
        string ToJson(string sql);
    }
}
