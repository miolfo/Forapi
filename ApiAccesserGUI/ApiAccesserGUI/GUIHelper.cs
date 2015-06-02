using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAccesserGUI
{
    static class GUIHelper
    {
        public static void WriteToFile(string path, string content)
        {
            System.IO.File.WriteAllText(path, content);
        }

        public static string ReadFromFile(string path)
        {
            try
            {
                string result = "";
                result = System.IO.File.ReadAllText(path);
                return result;
            }

            catch (Exception ex)
            {
                if (ex.InnerException is System.IO.FileNotFoundException)
                    WriteToFile(@".\previousCall.txt", "");
                else
                    WriteToFile(@".\err.txt", ex.GetType() + ", " + ex.Message);
                return "";
            }
        }
    }
}
