using System;

namespace best_fit_algorithm
{
    class Program
    {
     // create a function that will collect the blocks and processes
        static void bestFitAlgorithm(int[] memoryBlocks, int numberofblocks,
                          int[] processSize, int numberofprocesses)
        {

            // Stores the number of processes in an array
            int[] allocation = new int[numberofprocesses];

            //all blocks are empty
            for (int i = 0; i < allocation.Length; i++)
                allocation[i] = -1;

            // pick each process and find suitable
            // blocks according to its size ad
            // assign to it
            for (int i = 0; i < numberofprocesses; i++)
            {

                // Find the best fit block for
                // current process
                int bestIdx = -1;
                for (int j = 0; j < numberofblocks; j++)
                {
                    if (memoryBlocks[j] >= processSize[i])
                    {
                        if (bestIdx == -1)
                            bestIdx = j;
                        else if (memoryBlocks[bestIdx]
                                       > memoryBlocks[j])
                            bestIdx = j;
                    }
                }

                // If we could find a block for
                // current process
                if (bestIdx != -1)
                {

                    // allocate block j to p[i] 
                    // process
                    allocation[i] = bestIdx;

                    // Reduce available memory in
                    // this block.
                    memoryBlocks[bestIdx] -= processSize[i];
                }
            }

            Console.WriteLine("\nProcess No.\tProcess"
                                + " Size\tBlock no.");
            for (int i = 0; i < numberofprocesses; i++)
            {
                Console.Write(" " + (i + 1) + "\t\t"
                            + processSize[i] + "\t\t");

                if (allocation[i] != -1)
                    Console.Write(allocation[i] + 1);
                else
                    Console.Write("Not Allocated");

                Console.WriteLine();
            }
        }

        
        public static void Main()
        {
            //intialise the sizes of all elements in the block
            int[] memoryBlocks = { 400, 350, 700, 150, 600 };
            //do the same with the processes
            int[] processSize = { 122, 490, 311, 230 };
            //collect both lengths of the arrays
            int numberOfBlocks = memoryBlocks.Length;
            int numberOfProcesses = processSize.Length;

            bestFitAlgorithm(memoryBlocks, numberOfBlocks, processSize, numberOfProcesses);
        }
    }
}

