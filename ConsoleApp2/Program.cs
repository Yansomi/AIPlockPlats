using System;
using System.Text.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {
            ArtikelIndex artikelIndex = new ArtikelIndex();
            int index = artikelIndex.GetArtikelIndex("Äpple röd 60+ PL");
            Console.WriteLine(index);
            AnnModel ann = new AnnModel();
            string awnser = ann.Predict(100256, index, 3, 13.75f, 48, 102, 3, 0,0);
            Console.WriteLine(awnser);
        }
    }
}