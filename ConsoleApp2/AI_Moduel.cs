using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class AnnModel
    {
        string modelPath;
        InferenceSession session;
        long[] inputShape = { 1, 9 };
        float[] inputData = new float[9];
        OrtValue inputOrtValue;
        Dictionary<string, OrtValue> inputs;
        string[] awnsers;
        public AnnModel(string modelPath = "C:\\Users\\Hampus\\source\\repos\\AIPlockPlats\\ConsoleApp2\\AnnP.onnx")
        {
            this.modelPath = modelPath;
            this.session = new InferenceSession(this.modelPath);
        }
        public string Predict(float input1, float input2,float input3,float input4, float input5 , float input6 , float input7 , float input8, float input9)
        {
            Dictionary<int,string> Parms = new Dictionary<int,string>();

            float maxScale1 = 700491.0f;
            float minScale1 = 100012.0f;
            float maxScale2 = 2134.0f;
            float minScale2 = 0.0f;
            float maxScale3 = 99.0f;
            float minScale3 = 0.0f;
            float maxScale4 = 1150.0f;
            float minScale4 = 0.05f;
            float maxScale5 = 1000.0f;
            float minScale5 = 0.0f;
            float maxScale6 = 54933.0f;
            float minScale6 = 1.0f;
            float maxScale7 = 5.0f;
            float minScale7 = 1.0f;
            float maxScale8 = 1.0f;
            float minScale8 = 0.0f;
            float maxScale9 = 1.0f;
            float minScale9 = 0.0f;


            inputData[0] = ScaleData(input1, maxScale1, minScale1);
            inputData[1] = ScaleData(input2, maxScale2, minScale2);
            inputData[2] = ScaleData(input3, maxScale3, minScale3);
            inputData[3] = ScaleData(input4, maxScale4, minScale4);
            inputData[4] = ScaleData(input5, maxScale5, minScale5);
            inputData[5] = ScaleData(input6, maxScale6, minScale6);
            inputData[6] = ScaleData(input7, maxScale7, minScale7);
            inputData[7] = ScaleData(input8, maxScale8, minScale8);
            inputData[8] = ScaleData(input9, maxScale9, minScale9);
            var inputOrtValue = OrtValue.CreateTensorValueFromMemory(inputData, inputShape);
            inputs = new Dictionary<string, OrtValue>()
            {
                {"dense_input", inputOrtValue }
            };
            var runOptions = new RunOptions();
            var outputs = session.Run(runOptions, inputs, session.OutputNames);
            var result = outputs.Last().GetTensorDataAsSpan<float>();
            float[] data = result.ToArray();

            int awnser = ArgMax(data);
            string stringAwnser = "not found";
            if (awnser == 0)
            {
                stringAwnser = "?";
            }
            else if (awnser == 1)
            {
                stringAwnser = "B31_B53";
            }
            else if (awnser == 2)
            {
                stringAwnser = "Buffert";
            }
            else if (awnser == 3)
            {
                stringAwnser = "D01-D30";
            }
            else if (awnser == 4)
            {
                stringAwnser = "D31-D54";
            }
            else if (awnser == 5)
            {
                stringAwnser = "E05-E28";
            }
            else if (awnser == 6)
            {
                stringAwnser = "E29-E58";
            }
            else if (awnser == 7)
            {
                stringAwnser = "F42-F67";
            }
            else if (awnser == 8)
            {
                stringAwnser = "GA01-GA27";
            }
            else if (awnser == 9)
            {
                stringAwnser = "GC-Jämn";
            }
            else if (awnser == 10)
            {
                stringAwnser = "GC-Ojämn";
            }
            else if (awnser == 11)
            {
                stringAwnser = "H21-H43";
            }
            else if (awnser == 12)
            {
                stringAwnser = "J01-J40";
            }
            else if (awnser == 13)
            {
                stringAwnser = "K-Gång";
            }
            else if (awnser == 14)
            {
                stringAwnser = "L21";
            }
            else if (awnser == 15)
            {
                stringAwnser = "L23-L70";
            }

            return stringAwnser;
        }
        private float ScaleData(float input, float scaleMax, float scaleMin)
        {
            MinMaxScaler scaler = new MinMaxScaler(scaleMax, scaleMin);
            return scaler.Scale(input);
        }
        private int ArgMax(float[] arr)
        {
            int max = -1;
            float biggest = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > biggest)
                {
                    max = i;
                }
            }
            return max;
        }
    }
}
