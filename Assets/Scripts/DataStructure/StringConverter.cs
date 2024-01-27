using System.Collections.Generic;

namespace Megumin.DataStructure
{
    public class StringConverter
    {
        public static string ListStringToString(List<string> list)
        {
            string temp = "";
            foreach(var data in list)
            {
                temp += data+'\n';
            }

            return temp;
        }
    }
}
