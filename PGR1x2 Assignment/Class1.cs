using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGR1x2_Assignment
{
    class Class1
    {
        static public int Partition(int[] myArray, int left, int right)
        {
            int pivot = myArray[left];
            while (true) 
            {
                while (myArray[left] < pivot)
                {
                    left++;
                }
                while (myArray[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = myArray[right];
                    myArray[right] = myArray[left];
                    myArray[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quicksort (int[] myArray,int left,int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(myArray, left, right);
                if (pivot > 1)
                {
                    quicksort(myArray, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quicksort(myArray, pivot + 1, right);
                }
            }
        }
         }
}
