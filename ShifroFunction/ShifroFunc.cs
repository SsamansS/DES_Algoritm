using lab1_consl_DES_Algoritm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm.ShifroFunction
{
    public static class ShifroFunc
    {
        public static char[] ShifroF(char[] Rn, char[] Kn)
        {
            char[] RnExtension = new char[48];
            for (int i = 0; i < RnExtension.Length; i++)
            {
                RnExtension[i] = Rn[FuncStatics.ExtensionBitsPosition[i]];
            }

            char[] beforeSblocks = BitOperations.XOR(RnExtension, Kn);

            List<char> afterSblocks = new List<char>(32);
            List<string> Sblocks = BitOperations.DivideBy6Bits(beforeSblocks);
            for(int i = 0; i < Sblocks.Count; i++)
            {
                afterSblocks.AddRange(SblockFunc(Sblocks[i], i).ToList<char>());
            }

            char[] result = new char[32];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = afterSblocks[FuncStatics.FuncResPermutation[i]];
            } 

            return result;
        }
        public static string SblockFunc(string bits, int SblockNum)
        {
            //must have: bits.Length = 6
            int row = Convert.ToInt32($"{bits[0]}{bits[bits.Length-1]}", 2);
            int column = Convert.ToInt32($"{bits.Substring(1, 4)}", 2);

            int sblock = FuncStatics.SblocksForFunc[SblockNum][row, column];
            return BitOperations.GetBinaryFormChar(Convert.ToString(sblock, 2), 4);
        }
    }
}
