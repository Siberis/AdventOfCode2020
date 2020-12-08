using System;

namespace Day1
{
    public static class Day1
    {
        public static int Star1(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i] + input[j] == 2020)
                    {
                        return input[i] * input[j];
                    }
                }
            }
            return input.Length;
        }
        public static int Star2(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    for (int k = 0; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            return input[i] * input[j] * input[k];
                        }
                    }
                }
            }
            return input.Length;
        }
    }
}
