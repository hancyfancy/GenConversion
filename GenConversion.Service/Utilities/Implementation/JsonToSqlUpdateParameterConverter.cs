﻿using GenConversion.Service.Enumerations;
using GenConversion.Service.Utilities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenConversion.Service.Utilities.Implementation
{
    public class JsonToSqlUpdateParameterConverter : ISqlConverter
    {
        public string ToSql(string json)
        {
            try
            {
                string output = string.Empty;

                string properties = json.Replace("{", "").Replace("}", "").Replace("\r\n", "").Trim();

                List<string> props = properties.Split(",").ToList();

                props.RemoveAll(p => string.IsNullOrWhiteSpace(p));

                for (int i = 0; i < props.Count; i++)
                {
                    string prop = props[i];

                    List<string> kv = prop.Split(":").ToList();

                    if (i > 0)
                    {
                        output += ",";
                    }

                    if (string.Equals(kv[0].Replace("\"", "").Trim(), "Type", StringComparison.InvariantCultureIgnoreCase) && (!kv[1].Replace("\"", "").Trim().All(Char.IsLetter)))
                    {
                        int enumInt = int.Parse(kv[1]);

                        kv[1] = "'" + ((ProductTypeEnum)enumInt).ToString() + "'";
                    }

                    output += kv[0].Replace("\"", "") + "=" + kv[1].Replace("\"", "'").Replace("true", "1").Replace("false", "0");
                }

                return output;
            }
            catch (Exception e)
            {
                return default;
            }
        }
    }
}
