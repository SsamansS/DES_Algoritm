using lab1_consl_DES_Algoritm.Helpers;
using lab1_consl_DES_Algoritm.KeyGenerator;
using lab1_consl_DES_Algoritm.ShifroFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_consl_DES_Algoritm.DES
{
    public class AlgosDES
    {
        public string KeyText { get; set; }
        public string OpenText { get; set; }
        public string CipherText { get; set; }
        public string DecodeText { get; set; }

        public AlgosDES(string Text, string Key)
        {
            this.OpenText = Text;
            this.KeyText = Key;
            this.Encryp();
        }
        public AlgosDES(string Text, string Key, bool isDecode)
        {
            this.OpenText = Text;
            this.KeyText = Key;
            this.DecodeText = this.Decoding(OpenText);
        }

        public void Encryp()
        {
            InitializationPosition initializationKey = new InitializationPosition(KeyText);
            Keys keys = new Keys(ExtraConverter.StrToASCII(KeyText).ToCharArray());

            InitializationPosition initializationText = new InitializationPosition(OpenText);

            //Item1 - L
            //Item2 - R
            (string, string) Operands = (
                    new string(initializationText.L0),
                    new string(initializationText.R0)
                );

            for(int i = 0; i < 16; i++)
            {
                Operands = RoundFeistel(
                        new string(Operands.Item1),
                        new string(Operands.Item2),
                        keys.AllKeys[i]
                    );
            }

            this.CipherText = ExtraConverter.BitsASCIIToString(
                    LastPermutation(
                            Operands.Item2.ToCharArray(), Operands.Item1.ToCharArray()
                        ));
        }
        public string Decoding(string shifroText)
        {
            InitializationPosition initializationKey = new InitializationPosition(KeyText);
            Keys keys = new Keys(initializationKey.BinShifroText.ToCharArray());

            InitializationPosition initializationText = new InitializationPosition(shifroText);

            //Item1 - L
            //Item2 - R
            (string, string) Operands = (
                    new string(initializationText.L0),
                    new string(initializationText.R0)
                );

            for (int i = 15; i >= 0; i--)
            {
                Operands = RoundFeistel(
                        new string(Operands.Item1),
                        new string(Operands.Item2),
                        keys.AllKeys[i]
                    );
            }
            this.DecodeText = ExtraConverter.BitsASCIIToString(
                    LastPermutation(
                            Operands.Item2.ToCharArray(), Operands.Item1.ToCharArray()
                        ));
            return this.DecodeText;
        }
        public (string, string) RoundFeistel(string Ln, string Rn, char[] Kn)
        {
            string Rn1 = new string(
                    BitOperations.XOR(
                        Ln.ToCharArray(),
                        ShifroFunc.ShifroF(Rn.ToCharArray(), Kn)
                    )
                );

            return (Rn, Rn1);
        }
        public string StartPermutation(char[] Ln, char[] Bn, int[] StartPermutation)
        {
            char[] BeforePermutation = new char[Ln.Length + Bn.Length];
            Ln.CopyTo(BeforePermutation, 0);
            Bn.CopyTo(BeforePermutation, Ln.Length);

            char[] ClipherN = new char[BeforePermutation.Length];
            for (int i = 0; i < ClipherN.Length; i++)
            {
                ClipherN[i] = BeforePermutation[StartPermutation[i]];
            }

            return new string(ClipherN);
        }
        public string LastPermutation(char[] Ln, char[] Bn)
        {
            char[] BeforePermutation = new char[Ln.Length + Bn.Length];
            Ln.CopyTo(BeforePermutation, 0);
            Bn.CopyTo(BeforePermutation, Ln.Length);

            char[] ClipherN = new char[BeforePermutation.Length];
            for (int i = 0; i < ClipherN.Length; i++)
            {
                ClipherN[i] = BeforePermutation[desStatics._FinishPosition[i]];
            }

            return new string(ClipherN);
        }
        public string LastPermutation(char[] BinStr)
        {
            char[] ClipherN = new char[BinStr.Length];
            for (int i = 0; i < ClipherN.Length; i++)
            {
                ClipherN[i] = BinStr[desStatics._FinishPosition[i]];
            }

            return new string(ClipherN);
        }
    }
}
