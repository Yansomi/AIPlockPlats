using System;
using System.Text.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> Artiklar = new Dictionary<int,string>();

            var Parms = File.ReadAllText("C:\\Users\\Hampus\\source\\repos\\AIPlockPlats\\ConsoleApp2\\convert.txt");
            Dictionary<int, string> derp = JsonSerializer.Deserialize<Dictionary<int,string>>(Parms);
            string[] artikel = new string[derp.Count];
            //string ok = derp.TryGetValue(3, out string value) ? value : string.Empty;
            for(int i = 0; i < derp.Count; i++)
            {
                artikel[i] = derp.TryGetValue(i,out string value) ? value : string.Empty;
            }
            
            AnnModel ann = new AnnModel();
            string awnser = ann.Predict(111371, 160, 1, 6.43f, 56, 13,5,0,0);
            Console.WriteLine(awnser);
        }
    }
}