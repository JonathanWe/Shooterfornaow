using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    public class StatusScript
    {
        string[] Code;
        int i = 0;
        public StatusScript(string Code) 
        {
            string[] split = Code.Split('\n');
            Code = "";
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].Trim().StartsWith("//")) continue;
                else Code += split[i] + "\n";
            }
            this.Code = Code.Split(';');
        }
        /// <summary>
        /// Returns the next command
        /// </summary>
        /// <param name="Name">The variable to assign</param>
        /// <param name="Value">The value to assign the variable</param>
        /// <returns>Returns flase if there are no more commands left </returns>
        public bool NextCommand(out string Name, out string Value) 
        {
            Name = "";
            Value = "";
            while (i < Code.Length)
            {
                string[] split = Code[i].Trim().Split('=');
                if (split.Length < 2) 
                {
                    i++;
                    continue;
                }
                Name = split[0].Trim();
                Value = split[1].Trim();
                i++;
                return true;
            }
            return false;
        }
    }
}
