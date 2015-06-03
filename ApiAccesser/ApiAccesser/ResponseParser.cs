using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAccesser
{
    static class ResponseParser
    {
        //Add line breaks and tabulations
        public static string SimpleParse(string response)
        {
            StringBuilder sb = new StringBuilder();
            int level = 0;
            foreach (char c in response)
            {
                if (c == '{')
                {
                    sb.AppendLine("{");
                    sb.Append(" ");
                    level++;
                }
                else if (c == '}')
                {
                    sb.AppendLine("");
                    sb.AppendLine("}");
                    level--;
                }
                else if (c == ',')
                {
                    sb.AppendLine(",");
                    for (int i = 0; i < level; i++)
                    {
                        sb.Append(" ");
                    }
                }
                else if (c == ':')
                {
                    sb.Append(": ");
                }
                else
                {
                    sb.Append(c);
                }
            }
            sb.Replace("\"", "");
            sb.Replace(",", "");
            return sb.ToString();
        }
    }
}
