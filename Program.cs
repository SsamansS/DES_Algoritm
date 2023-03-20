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
            Console.WriteLine("Hello World!");

            AlgosDES des = new AlgosDES("0123456789ABCDEF", "133457799BBCDFF1");
            Console.WriteLine(des.OpenText);
            Console.WriteLine(des.CipherText);
            Console.WriteLine($"des.Clipher: ");

            AlgosDES des2 = new AlgosDES(des.CipherText, des.KeyText);
            Console.WriteLine($"des2.Clipher: {des2.CipherText}");

            Console.WriteLine(des.Decoding(des.CipherText));

            Console.WriteLine(des.CipherText);
            Console.WriteLine("Hello World!");
        }
    }
}
