using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm.Helpers
{
    public static class BitOperations
    {
        public static char[] XOR(char[] opt1, char[] opt2)
        {
            char[] xor = new char[opt1.Length];

            for(int i = 0; i < opt1.Length; i++)
            {
                if(opt1[i] == opt2[i])
                {
                    xor[i] = '0';
                } else
                {
                    xor[i] = '1';
                }
            }

            return xor;
        }
        public static List<string> DivideBy6Bits(char[] bits, int divider = 6)
        {
            List<string> res = new List<string> { };
            for(int i = 1; i < bits.Length; i++)
            {
                if(i % divider == 0 )
                {
                    char[] dest = bits.Skip(i - divider).Take(divider).ToArray();
                    res.Add(new string(dest));
                } else if(i == bits.Length - 1)
                {
                    char[] dest = bits.Skip(i - divider + 1).Take(divider).ToArray();
                    res.Add(new string(dest));
                }
            }
            return res;
        }
        //Convert string to binstr
        public static string GetBinaryFormChar(string charStr)
        {
            string binStr = string.Concat(Encoding.UTF8.GetBytes(charStr).Select(b => Convert.ToString(b, 2)));
            int countOfGap = Math.Abs(8 - binStr.Length);

            return countOfGap == 0 ? binStr : binStr.Insert(0, new string('0', countOfGap));
        }
        public static string GetBinaryFormChar(string charStr, int length)
        {
            int countOfGap = Math.Abs(length - charStr.Length);

            return countOfGap == 0 ? charStr : charStr.Insert(0, new string('0', countOfGap));
        }
        //comm
        public static string GetCharFormBinary(string binaryChar)
        {
            int output = Convert.ToInt32(binaryChar, 2);
            string binStr = new string(Encoding.UTF8.GetChars(new byte[] { (byte)output }));
            return binStr;
        }
        public static string GetStringFromBinary(string str)
        {
            List<string> chars = BitOperations.DivideBy6Bits(str.ToCharArray(), 8);
            string stringFromBits = "";
            foreach(var ch in chars)
            {
                stringFromBits = stringFromBits.Insert(
                        stringFromBits.Length,
                        BitOperations.GetCharFormBinary(ch)
                    );
            }

            return stringFromBits;
        }
    }
}
