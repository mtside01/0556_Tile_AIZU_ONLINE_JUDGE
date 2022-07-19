using System;
using System.Collections.Generic;

namespace _0556_Tile_AIZU_ONLINE_JUDGE
{
    class Inputs
    {
        public int N;
        public int K;
        public List<int> a = new List<int>();
        public List<int> b = new List<int>(); 
    }

    enum TILE_COLOR
    {
        RED = 0,
        BLUE,
        YELLOW,
        TILE_NUM
    }


    class Program
    {
        static void Main(string[] args)
        {

            Inputs inputs = getInputs();
            outputResults(inputs.K, calculatePeeledTile(inputs));

        }

        static Inputs getInputs()
        {
            Inputs inputs = new Inputs();

            inputs.N = int.Parse(Console.ReadLine());
            inputs.K = int.Parse(Console.ReadLine());

            for(var i = 0; i < inputs.K; i++)
            {
                string inputString = Console.ReadLine();
                string[] stringArray = inputString.Split(" ");
                inputs.a.Add(int.Parse(stringArray[0]));
                inputs.b.Add(int.Parse(stringArray[1]));
            }

            return inputs;
        }

        static List<TILE_COLOR> calculatePeeledTile(Inputs inputs)
        {
            List<TILE_COLOR> calculatedResults = new List<TILE_COLOR>();

            for(var i = 0; i < inputs.K; i++)
            {
                inputs.a[i] = convertToMinUnit(inputs.N, inputs.a[i]);
                inputs.b[i] = convertToMinUnit(inputs.N, inputs.b[i]);

                calculatedResults.Add(calculateTileColor(Math.Min(inputs.a[i], inputs.b[i])));
            }

            return calculatedResults;
        }

        static int convertToMinUnit(int N, int abi)
        {
            if (abi > (Math.Round((double)N/2)))
            {
                abi = N + 1 - abi;
            }

            return abi;
        }

        static TILE_COLOR calculateTileColor(int tileNum)
        {
            TILE_COLOR retVal;

            switch (tileNum % (int)TILE_COLOR.TILE_NUM)
            {
                case 1:
                    retVal = TILE_COLOR.RED;
                    break;
                case 2:
                    retVal = TILE_COLOR.BLUE;
                    break;
                default:
                    retVal = TILE_COLOR.YELLOW;
                    break;
            }

            return retVal;
        }

        static void outputResults(int K, List<TILE_COLOR> calculatedResults)
        {
            for(var i = 0; i < K; i++)
            {
                Console.WriteLine((int)calculatedResults[i] + 1);
            }
        }
    }
}
