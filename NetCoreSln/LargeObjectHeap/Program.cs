using System;
using System.Runtime;
using System.Threading;

namespace LargeObjectHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int count = 1; count <= 5; ++count)
                AllocBigMemoryBlock2(count);
            Console.Write("\nPress any key to exit...");
            while (Console.KeyAvailable == false)
                Thread.Sleep(250);
        }

        static void AllocBigMemoryBlock(int pass)
        {
            const int MB = 1024 * 1024;
            byte[] array = null;
            long maxMem = 0;
            int arraySize = 0; 
            while (Console.KeyAvailable == false)
            {
                try
                {
                    arraySize += 10;
                    array = new byte[arraySize * MB];
                    array[arraySize * MB - 1] = 100;
                    maxMem = GC.GetTotalMemory(true);
                    Console.Write("Pass:{0}  Max Array " +
                        "Size (MB): {1:D4}  {2:D4}\r",
                        pass, arraySize,
                        Convert.ToInt32(maxMem / MB));
                }
                catch (OutOfMemoryException)
                {
                    Console.Write("\n");
                    maxMem = GC.GetTotalMemory(true);
                    if (arraySize < 20)
                        Console.Write("Pass:{0} Small " +
                            "Array Size (MB): {1:D4}" +
                            "  {2:D4} {3}\r\n\n",
                            pass, arraySize,
                            Convert.ToInt32(maxMem / MB),
                            "Insufficient Memory...");
                    else
                        Console.Write("Pass:{0} Failed " +
                            "Array Size (MB): {1:D4}" +
                            "  {2:D4} {3}\r\n\n",
                            pass, arraySize,
                            Convert.ToInt32(maxMem / MB),
                            "Out Of Memory...");
                    break;
                }
                finally
                {
                    array = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        static void AllocBigMemoryBlock2(int pass)
        {
            const int MB = 1024 * 1024;
            byte[] array = null;
            long maxMem = 0;
            int arraySize = 0;
            MemoryFailPoint memFailPoint;
            while (Console.KeyAvailable == false)
            {
                try
                {
                    arraySize += 10;
                    using (memFailPoint = new MemoryFailPoint(arraySize))
                    {
                        array = new byte[arraySize * MB];
                        array[arraySize * MB - 1] = 100;
                        maxMem = GC.GetTotalMemory(true);
                        Console.Write("Pass:{0}    " +
                            "Max Array Size (MB): {1:D4}  {2:D4}\r",
                            pass, arraySize,
                            Convert.ToInt32(maxMem / MB));
                    }
                }
                catch (InsufficientMemoryException)
                {
                    Console.Write("\n insufficient memory exception");
                    Console.Write("\n");
                    maxMem = GC.GetTotalMemory(true);
                    if (arraySize < 20)
                        Console.Write("Pass:{0}  Small Array" +
                            " Size (MB): {1:D4}  {2:D4} {3}\r\n\n",
                            pass, arraySize,
                            Convert.ToInt32(maxMem / MB),
                            "Insufficient Memory...");
                    else
                        Console.Write("Pass:{0} Failed Array Size" +
                            " (MB): {1:D4}  {2:D4} {3}\r\n\n",
                            pass, arraySize,
                            Convert.ToInt32(maxMem / MB),
                            "Out Of Memory...");
                    break;
                }
                catch (OutOfMemoryException)
                {
                    Console.Write("\n outof memory exception");

                    Console.Write("\n");
                    maxMem = GC.GetTotalMemory(true);
                    if (arraySize < 20)
                        Console.Write("Pass:{0}  Small Array" +
                            " Size (MB): {1:D4}  {2:D4} {3}\r\n\n",
                            pass, arraySize,
                            Convert.ToInt32(maxMem / MB),
                            "Insufficient Memory...");
                    else
                        Console.Write("Pass:{0} Failed Array" +
                            " Size (MB): {1:D4}  {2:D4} {3}\r\n\n",
                            pass, arraySize,
                            Convert.ToInt32(maxMem / MB),
                            "Out Of Memory...");
                    break;
                }
                finally
                {
                    array = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
} 
