using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ThemeSix
{
    static class ClassArray
    {
        static public int[] Array { get; private set; }
        static int Size;
        static ClassArray()
        {
            Size = 1000000;
            Array = new int[Size];   
        }
        static public void InitOneThread()
        {
            Random rnd = new Random();
            for (int i = 0; i < Size; i++)
                Array[i] = rnd.Next(0, 900);
        }
        static public void InitMultyThread()
        {
            Parallel.Invoke(
                () =>
                {
                    Random rand1 = new Random();
                    for (int i = 0; i < Size / 2; i++)
                        Array[i] = rand1.Next(0, 900);
                },
                () =>
                {
                    Random rand2 = new Random();
                    for (int i = Size / 2; i < Size; i++)
                        Array[i] = rand2.Next(0, 900);
                });
        }
        static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }

        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static void QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return;
            int pivotIndex = Partition(array, minIndex, maxIndex);
            Parallel.Invoke(
                        () => QuickSort(array, minIndex, pivotIndex - 1),
                        () => QuickSort(array, pivotIndex + 1, maxIndex));

            return;
        }
        static public void QuickSort()
        {
            QuickSort(Array, 0, Array.Length - 1);
        }
        static void BubbleSort(int[] array, int indexBeg, int indexEnd, bool swapFlag)
        {
            if (indexBeg == indexEnd || !swapFlag)
                return;
            Parallel.Invoke(
                () =>
                {
                    swapFlag = false;
                    for (int i = indexBeg; i < indexEnd - 1; i++)
                        if (array[i] > array[i + 1])
                        {
                            Swap(ref array[i], ref array[i + 1]);
                            swapFlag = true;
                        }
                    BubbleSort(array, indexBeg + 1, indexEnd - 1, swapFlag);
                },
                () =>
                {
                    swapFlag = false;
                    for (int i = indexEnd - 2; i > indexBeg; i--)
                        if (array[i - 1] > array[i])
                        {
                            Swap(ref array[i - 1], ref array[i]);
                            swapFlag = true;
                        }
                    BubbleSort(array, indexBeg + 1, indexEnd - 1, swapFlag);
                });
        }
        static public void BubbleSort()
        {
            BubbleSort(Array, 0, Size, true);
        }
    }
}
