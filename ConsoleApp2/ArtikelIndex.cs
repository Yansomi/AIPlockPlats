using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp2
{
    public class ArtikelIndex
    {
        string[] Artikels;
        public ArtikelIndex(string fileLocation = "C:\\Users\\Hampus\\source\\repos\\AIPlockPlats\\ConsoleApp2\\convert.txt")
        {
            var Parms = File.ReadAllText(fileLocation);

            Dictionary<int, string> Serializing = JsonSerializer.Deserialize<Dictionary<int, string>>(Parms);
            this.Artikels = new string[Serializing.Count];

            for(int i = 0; i < Serializing.Count; i++)
            {
                this.Artikels[i] = Serializing.TryGetValue(i, out string value) ? value : string.Empty;
            }
        }
        public int GetArtikelIndex(string ArtikelName)
        {
            bool Found = false;
            int index = -1;
            for(int i = 0;i < this.Artikels.Length && Found == false;i++)
            {
                if(ArtikelName == this.Artikels[i])
                {
                    index = i;
                    Found = true;
                }
            }
            return index;
        }
    }
        
}




