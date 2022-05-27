using System;

namespace example
{
    class Program
    {
        static public int Partition(int[] myArray, int left, int right)    //Creating partitions fo quicksort algorithm
        {
            int pivot;
            pivot = myArray[left];
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
        static public void quicksort(int[] myArray, int left, int right)      //quicksort method that will be run
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
        public static void mergesort(Span<int> myArray)     //mergesort methodd
        {
            var center = (myArray.Length / 2);
            if (myArray.Length > 1)
            {
                mergesort(myArray.Slice(0, center));
                mergesort(myArray.Slice(center));
                merge(myArray, center);
            }
        }
        public static void merge(Span<int> result, int righthalf)       //mergesort
        {
            var myArray = result.ToArray();
            var lhs = 0;
            var rhs = righthalf;
            var offset = 0;

            while (lhs < righthalf && rhs < myArray.Length)
            {

                if (myArray[lhs] <= myArray[rhs])
                {
                    result[offset] = myArray[lhs];
                    lhs++;

                }
                else
                {
                    result[offset] = myArray[rhs];
                    rhs++;

                }
                offset++;
            }
        }

        public static void Main(string[] args)
        {
            int[] myArray = new int[] { 9, 4, 5, 8, 5 };
            int temp = 0;


            Console.WriteLine("Please Select your sorting method");
            Console.WriteLine("1:Bubble sort");
            Console.WriteLine("2:Quicksort");
            Console.WriteLine("3:Mergesort");

            int option = int.Parse(Console.ReadLine());


            switch (option)
            {
                case 1:
                    for (int i = 0; i < myArray.Length - 1; i++)        //bubblesort
                    {
                        for (int j = 0; j < myArray.Length - (1 + i); j++)
                        {
                            if (myArray[j] > myArray[j + 1])
                            {
                                temp = myArray[j + 1];
                                myArray[j + 1] = myArray[j];
                                myArray[j] = temp;

                            }
                        }
                    }
                    for (int i = 0; i < myArray.Length; i++)
                    {
                        Console.Write("{0}", myArray[i]);
                    }
                    break;
                case 2:                                             //quicksort
                    quicksort(myArray, 9, 5);
                    for (int i = 0; i < myArray.Length; i++)
                    {
                        Console.Write("{0}", myArray[i]);
                    }

                    break;
                case 3:
                    
                    for (int i = 0; i < myArray.Length; i++)
                    {
                        Console.Write("{0}", myArray[i]);
                    }

                    break;
            }
            Console.WriteLine("\n Please choose a searching method");
            Console.WriteLine("1:Binary Search");
            Console.WriteLine("2:Linear Search");

            int option1 = int.Parse(Console.ReadLine());
            switch (option1)
            {
                case 1:                                                                         //binarysearch
                    Array.Sort(myArray);
                    Console.WriteLine("Please enter the number you wish to search");
                    int searchnum = int.Parse(Console.ReadLine());
                    int numtofind = searchnum;

                    if (binarysearch(myArray, 0, myArray.Length, numtofind) != -1)
                    {
                        Console.WriteLine("Item found");
                    }
                    else
                    {
                        Console.WriteLine("item not found");
                    }
                   


                    break;
                case 2:                                                                             //linear search
                    Array.Sort(myArray);
                    Console.WriteLine("Please enter the number you wish to search");
                    int sval = int.Parse(Console.ReadLine());
                    int index=  linearsearch(myArray, sval);
                    if (index < 0)
                    {
                        Console.WriteLine($"Number is not found");
                    }
                    else
                    {
                        Console.WriteLine($"Number is found at {index}th index");
                    }


                    break;
            };
        }
        public static int linearsearch(int[] myArray, int x)        //linear search method
        {
            for (int i=0;i<myArray.Length;i++)
            {
                if (myArray[i] == x)
                {
                    return i;
                }
            }
            return -1;

        }
        public static int binarysearch(int[]myArray,int left,int right,int numtofind)       //bianry search method
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;

                if (myArray[middle] == numtofind)
                {
                    return numtofind;
                }
                if (myArray[middle] > numtofind)
                {
                    return binarysearch(myArray, left, middle - 1, numtofind);
                }
                else { 
                    return binarysearch(myArray, left, middle + 1, numtofind); 
                }
            }
            return -1;

        }
    }
}