using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm.KeyGenerator
{
    public class Keys
    {
        char[] KeyPermutation { get; set; }
        public List<char[]> AllKeys { get; set; }
        public Keys(char[] keyPermutation)
        {
            this.KeyPermutation = keyPermutation;
            this.AllKeys = new List<char[]> { };
            this.GenericKeys();
        }
        public void GenericKeys()
        {
            KeyIP keyIP = new KeyIP(this.KeyPermutation);
            char[] permutationB = keyIP.PermutationB;
            for(int i = 0; i < 16; i++)
            {
                char[] Cn = MoveLeft(keyIP.C0, KeyStatics.CountOfRoundShift[i]);
                char[] Dn = MoveLeft(keyIP.D0, KeyStatics.CountOfRoundShift[i]);

                AllKeys.Add(LastGenericKeyPermutation(Cn, Dn));

                keyIP.C0 = Cn;
                keyIP.D0 = Dn;
            }
        }
        public char[] MoveLeft(char[] bits, int moveCount)
        {
            char[] bitsBefore = new char[bits.Length];
            bits.CopyTo(bitsBefore, 0);
            for(int i = 0; i < bits.Length; i++)
            {
                if(i >= bits.Length - moveCount)
                {
                    bits[i] = bitsBefore[ i + moveCount - bits.Length];
                } else
                {
                    bits[i] = bitsBefore[i + moveCount];
                }
            }
            return bits;
        }
        public char[] LastGenericKeyPermutation(char[] Cn, char[] Dn)
        {
            char[] BeforePermutation = new char[Cn.Length + Dn.Length];
            Cn.CopyTo(BeforePermutation, 0);
            Dn.CopyTo(BeforePermutation, Cn.Length);

            char[] KeyN = new char[48];
            for (int i = 0; i < KeyN.Length; i++)
            {
                KeyN[i] = BeforePermutation[KeyStatics.GenericKeyPermutation[i]];
            }

            return KeyN;
        }
    }
}
