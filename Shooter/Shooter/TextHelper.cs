using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    public static class TextHelper
    {
        public static string[] Between(string Text, string Start, string End) { return Between(Text, Start, End, null); }
        
        /// <summary>
        /// Returns the text between start and end text
        /// </summary>
        /// <param name="Text">The source string</param>
        /// <param name="Start">How the between starts. Eks: (return this) Start = (</param>
        /// <param name="End">How the between ends. Eks: (return this) End = )</param>
        /// <param name="Exseptions">Exseptions. Eks: "he sad \hi\" " the exseption = \"</param>
        /// <returns></returns>
        public static string[] Between(string Text, string Start, string End, string[] Exceptions) 
        {
            if (Exceptions == null) Exceptions = new string[0];
            List<string> result = new List<string>();
            string tmp = "";
            bool ok = true;
            int i = 0;
            while (Text != "")
            {
                i = FindFirst(Text, Start);
                if (i == -1) break;
                for (int j = 0; j < Exceptions.Length; j++)
                {
                    if (ContainsAt(Text, Exceptions[j], i)) ok = false;
                }
                Text = Text.Substring(i, Text.Length - i);
                i = 0;
                if (ok)
                {
                    ok = false;
                    while (!ok)
                    {
                        ok = true;
                        i = FindFirst(Text.Substring(1), End);
                        if (i == -1) break;
                        for (int j = 0; j < Exceptions.Length; j++)
                        {
                            if (ContainsAt(Text, Exceptions[j], i)) ok = false;
                        }
                        if (ok)
                        {
                            result.Add(Text.Substring(Start.Length, i));
                        }
                        else i++;
                    }
                }
                Text = Text.Substring(1);
            }
            return result.ToArray();
        }

        public static int FindFirst(string Text, string Value) 
        {
            return FindFirst(Text, Value, 0);
        }

        public static int FindFirst(string Text, string Value, int Offset) 
        {
            string tmp = "";
            for (int i = Offset; i < Text.Length; i++)
            {
                tmp += Text[i];
                if (tmp.EndsWith(Value))
                {
                    return i - (Value.Length - 1);
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns true if Value goes trougth Index 
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Value"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static bool ContainsAt(string Text, string Value, int Index) 
        {
            int small = Index - Value.Length;
            if (small < 0) small = 0;
            int big = Value.Length * 2;
            if (big > Text.Length) big = Text.Length;
            Text = Text.Substring(small, big);
            if (Text.Contains(Value)) return true;
            return false;
        }

        public static string BytesToString(byte[] Bytes) 
        {
            return BitConverter.ToString(Bytes);
        }

        public static string BytesToStringAndSplit(byte[] Bytes, string Split)
        {
            int i = 0;
            return BytesToStringAndSplit(Bytes, Split, out i);
        }

        public static string BytesToStringAndSplit(byte[] Bytes, string Split, out int SplitIndex)
        {
            string text = "";
            SplitIndex = -1;
            for (int i = 0; i < Bytes.Length; i++)
            {
                text += BitConverter.ToString(new byte[] { Bytes[i] });
                if (text.EndsWith(Split))
                {
                    SplitIndex = i;
                    break;
                }
            }
            return text;
        }

        public static int LetterCount(string Text, char Letter) 
        {
            int count = 0;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] == Letter) count++;
            }
            return count;
        }

        public static string RemoveDoubble(string Text, char Letter) 
        {
            string tmp = "";
            char lastChar = new char();
            for (int i = 0; i < Text.Length; i++)
            {
                if (!(lastChar == Letter && Text[i] == Letter)) tmp += Text[i];
                lastChar = Text[i];
            }
            return tmp;
        }
    }
}
