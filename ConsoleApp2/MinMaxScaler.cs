using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class MinMaxScaler
    {
        float max;
        float min;

        public MinMaxScaler(float max, float min)
        {
            this.max = max;
            this.min = min;
        }
        public float Scale(float value)
        {
            float y = (value - this.min) / (this.max - this.min);
            return y;
        }
    }
}
