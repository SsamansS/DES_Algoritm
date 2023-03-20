using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm.KeyGenerator
{
    public class KeyIP
    {
        int[] _PermutationPositionB = new int[]
        {
            56, 48, 40, 32, 24, 16, 8,
            0,  57, 49, 41, 33, 25, 17, 
            9,   1, 58, 50, 42, 34, 26, 
            18, 10,  2, 59, 51, 43, 35, 
            62, 54, 46, 38, 30, 22, 14, 
            6,  61, 53, 45, 37, 29, 21, 
            13,  5, 60, 52, 44, 36, 28, 
            20, 12,  4, 27, 19, 11,  3
        };

        public char[] PermutationB { get; set; }
        public char[] C0 = new char[28];
        public char[] D0 = new char[28];

        public KeyIP(char[] KeyPermutation)
        {
            this.PermutationB = new char[56];
            SetPermutationB(KeyPermutation);
            SetC0anbD0();
        }

        private void SetPermutationB(char[] KeyPermutation)
        {
            for (int i = 0; i < this.PermutationB.Length; i++)
            {
                this.PermutationB[i] = KeyPermutation[_PermutationPositionB[i]];
            }
        }
        public void SetC0anbD0()
        {
            for (int i = 0; i < this.PermutationB.Length; i++)
            {
                if (i >= 0 && i < 28)
                {
                    this.C0[i] = this.PermutationB[i];
                }
                else
                {
                    this.D0[this.D0.Length + i - this.PermutationB.Length] = this.PermutationB[i];
                }
            }
        }
    }
}
