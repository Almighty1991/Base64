using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aufgabe_Base64
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabe_text = "";
            int zahl_ascii = 0;
            string binär = "";
            string binärlang = "";
            string binärshort = "";
            int zähler = 5;
            int base_zahl = 0;
            int binärzähler = 0;
            int auffüllen = 0;
            string gleichzeichen = "";
            string baseausgabe = "";
            string based64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

            Console.WriteLine("Geben Sie einen Text ein: ");
            eingabe_text = Console.ReadLine();
            Console.Clear();

            Console.WriteLine();
            for (int i = 0; i < eingabe_text.Length; i++)
            {
                zahl_ascii = (int)eingabe_text[i];

                while (zahl_ascii > 0)
                {
                    binär = (zahl_ascii % 2) + binär;
                    zahl_ascii /= 2;
                }
                for (int u = binär.Length; u < 8; u++)
                {
                    if (u < 8)
                    {
                        binär = "0" + binär;
                    }
                }
                binärlang += binär;
                binär = "";

            }

            if (eingabe_text.Length % 3 == 1)
            {
                gleichzeichen = "=" + "=";
            }

            if (eingabe_text.Length % 3 == 2)
            {
                gleichzeichen = "=";
            }

            auffüllen = binärlang.Length % 6;
            while (auffüllen > 0)
            {
                binärlang += "0";
                auffüllen--;
            }

            for (int i = 0; i <27; i++)
            {
                for (int b = 0; b < 6; b++)
                {
                    binärshort += binärlang[binärzähler];
                    binärzähler++;
                }

                for (int c = 0; c < 6; c++)
                {
                    if (binärshort[c] == 49)
                    {
                        base_zahl += (int)Math.Pow(2, zähler);
                    }
                    zähler--;
                }

                baseausgabe += based64[base_zahl];
                zähler = 5;
                binärshort = "";       
                base_zahl = 0;
                
            }

            baseausgabe += gleichzeichen;
            Console.WriteLine(eingabe_text);
            Console.WriteLine(baseausgabe);
            byte[] bytes = Encoding.UTF8.GetBytes(eingabe_text);
            string base64 = Convert.ToBase64String(bytes);
            Console.WriteLine("Base64-Ausgabe: " + base64);
        }
    }
}
