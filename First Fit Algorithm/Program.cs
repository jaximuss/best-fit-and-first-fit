using System;

namespace First_Fit_Algorithm
{
    class Program
    {
        static void firstFitAlgorithm(int[] blocks, int[] processes, int blockLength, int processlength)
        {
            //lets allocate every process into an array

            int[] allocate = new int[processlength];
            //since all blocks are empty
            for (int i = 0; i < allocate.Length; i++)
            {
                allocate[i] = -1;
            }
            //pick each process and find out if the first block is suitable for the process
            for (int i = 0; i < processlength; i++)
            {
                //find the first fit block for each process
                for (int j = 0; j < blockLength; j++)
                {
                    if (blocks[j] >= processes[i])
                    {
                        //if true then allocate the first block immediately
                        allocate[i] = j;

                        //then we reduce the amount of blocks we are working with so the process can immediately go to the next block
                        blocks[j] -= processes[i];
                        break;
                    }
                }
            }
            Console.WriteLine("\nProcess No.\tProcess Size\tBlock no.");
            for (int i = 0; i < processlength; i++)
            {
                Console.Write(" " + (i + 1) + "\t\t" +
                              processes[i] + "\t\t");
                if (allocate[i] != -1)
                    Console.Write(allocate[i] + 1);
                else
                    Console.Write("Not Allocated");
                Console.WriteLine();

            }


        }
        public static void Main(string[]args)
        {
             int[] blocks = { 300, 320, 100, 200, 600 };
             int[] processes = { 213, 413, 512, 222 };
             int blockslength = blocks.Length;
             int processlength = processes.Length;

             firstFitAlgorithm(blocks, processes, blockslength, processlength);

        }
    }
}
