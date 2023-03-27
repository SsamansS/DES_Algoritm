using lab1_consl_DES_Algoritm.DES;
using lab1_consl_DES_Algoritm.Helpers;
using lab1_consl_DES_Algoritm.KeyGenerator;
using lab1_consl_DES_Algoritm.ShifroFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1_consl_DES_Algoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgosDES des = new AlgosDES("03d", "fdgd");
            Console.WriteLine($"des.OpenText: {des.OpenText}");
            Console.WriteLine($"des.Clipher: {des.CipherText}");
            Console.WriteLine($"Decoding: {des.Decoding(des.CipherText)}");

            AlgosDES des2 = new AlgosDES(des.CipherText, des.KeyText, true);
            Console.WriteLine(des2.DecodeText);
            Console.WriteLine("Hello World!");
        }
    }
}
