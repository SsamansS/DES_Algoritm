using lab1_consl_DES_Algoritm.DES;
using lab1_consl_DES_Algoritm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm
{
    public class InitializationPosition
    {
        //table 1
        public int[] _StartPosition = new int[] {
            57, 49, 41, 33, 25, 17,  9, 1, 
            59, 51, 43, 35, 27, 19, 11, 3, 
            61, 53, 45, 37, 29, 21, 13, 5, 
            63, 55, 47, 39, 31, 23, 15, 7, 
            56, 48, 40, 32, 24, 16,  8, 0,
            58, 50, 42, 34, 26, 18, 10, 2, 
            60, 52, 44, 36, 28, 20, 12, 4, 
            62, 54, 46, 38, 30, 22, 14, 6
        };
        public string ShifroText { get; set; }
        public string BinShifroText { get; set; }
        public char[] StartPermutation { get; set; }
        public char[] LastPermutation { get; set; }
        public char[] L0 = new char[32];
        public char[] R0 = new char[32];
        public char[] L16 = new char[32];
        public char[] R16 = new char[32];

        public InitializationPosition(string ShifroText)
        {
            this.ShifroText = ShifroText;
            this.BinShifroText = GetBinaryFormStr(ShifroText);

            this.StartPermutation = new char[64];
            SetStartPermutation(this.BinShifroText);
            SetL0anbR0();
        }
        public InitializationPosition(string ShifroText, bool isDecode = false)
        {
            this.ShifroText = ShifroText;
            this.BinShifroText = GetBinaryFormStr(ShifroText);

            this.LastPermutation = new char[64];
            SetLastPermutation(this.BinShifroText);
            SetL16anbR16();
        }
        public void SetLastPermutation(string BinStr)
        {
            for (int i = 0; i < this.LastPermutation.Length; i++)
            {
                this.LastPermutation[i] = BinStr[desStatics._FinishPosition[i]];
            }
        }

        void SetL16anbR16()
        {
            for (int i = 0; i < this.LastPermutation.Length; i++)
            {
                if (i >= 0 && i < 32)
                {
                    this.L16[i] = this.LastPermutation[i];
                }
                else
                {
                    this.R16[this.R16.Length + i - this.LastPermutation.Length] = this.LastPermutation[i];
                }
            }
        }

        void SetL0anbR0()
        {
            for(int i = 0; i < this.StartPermutation.Length; i++)
            {
                if(i >= 0 && i < 32)
                {
                    this.L0[i] = this.StartPermutation[i];
                } else
                {
                    this.R0[this.R0.Length + i - this.StartPermutation.Length] = this.StartPermutation[i];
                }
            }
        }

        void SetStartPermutation(string str)
        {
            for (int i = 0; i < this.StartPermutation.Length; i++)
            {
                this.StartPermutation[i] = str[_StartPosition[i]];
            }
        }

        public string GetBinaryFormStr(string str)
        {
            string binText = "";
            for(int i = 0; i < str.Length; i++)
            {
                binText = binText.Insert(binText.Length, BitOperations.GetBinaryFormChar(str[i].ToString()));
            }

            return binText;
        }
        //
    }
}
