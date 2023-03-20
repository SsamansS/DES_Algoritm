using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm.KeyGenerator
{
    public static class KeyStatics
    {
        public static int[] CountOfRoundShift = new int[]
        {
            1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1
        };
        public static int[] GenericKeyPermutation = new int[]
        {
            13, 16, 10, 23,  0,  4,
            2,  27, 14,  5, 20,  9,
            22, 18, 11,  3, 25,  7,
            15,  6, 26, 19, 12,  1,
            40, 51, 30, 36, 46, 54,
            29, 39, 50, 44, 32, 47,
            43, 48, 38, 55, 33, 52,
            45, 41, 49, 35, 28, 31
        };
    }
}
