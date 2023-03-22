using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm.Helpers
{
    public static class ExtraConverter
    {
        public static string StrToASCII(string OpenText)
        {
            string binStr = "";
            foreach(char ch in OpenText)
            {
                binStr = binStr.Insert(binStr.Length, 
                    BitOperations.GetBinaryFormChar(CharToBitsASCII(ch), 8)
                    );
            }

            if(binStr.Length > 64)
            {
                throw new Exception("Недопустимая длина ключа или текста");
            }

            return BitOperations.GetBinaryFormChar(binStr, 64);
        }
        static string CharToBitsASCII(char ch)
        {
            byte chByte = (byte)ch;
            return Convert.ToString(chByte, 2);
        }
        //расшифровка текста
        public static string BitsASCIIToString(string bits)
        {
            List<string> binBytes = BitOperations.DivideBy6Bits(bits.ToCharArray(), 8);

            string res = "";
            foreach(var chBin in binBytes)
            {
                res = res.Insert(res.Length, BitsASCIIToChar(chBin).ToString());
            }
            return res;
        }
        public static char BitsASCIIToChar(string binOfChar)
        {
            byte byteOfChar = BitsToByte(binOfChar);
            return (char)byteOfChar;
        }

        private static byte BitsToByte(string binOfChar)
        {
            double res = 0;
            binOfChar = ReverseStr(binOfChar);
            for(int i = 0; i < binOfChar.Length; i++)
            {
                if(binOfChar[i] == '1')
                {
                    res += Math.Pow(2, i);
                }
            }
            return (byte)res;
        }
        private static string ReverseStr(string str)
        {
            char[] charsFromStr = str.ToCharArray();
            Array.Reverse(charsFromStr);
            return new string(charsFromStr);
        }
    }
}
