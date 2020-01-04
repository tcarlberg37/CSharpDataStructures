using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnorderedArray
{
    class UnorderedArray
    {
        private int[] itemArray;
        private int numElements;
        private int maxElements;

        public UnorderedArray(int max)
        {
            maxElements = max;
            numElements = 0;
            itemArray = new int[max];
        }

        public bool addLast(int item)
        {
            if (numElements < maxElements)
            {
                itemArray[numElements] = item;
                numElements++;
                Console.WriteLine("Item added to end of the list.");
                return true;
            }
            else
            {
                Console.WriteLine("Not enough space in the list.");
                return false;
            }
        }

        public bool efficientDelete(int item)
        {
            // delete the first occurance of the item
            for (int i = 0; i < numElements; i++)
            {
                if (itemArray[i] == item)
                {
                    itemArray[i] = itemArray[numElements];
                    numElements--;
                    Console.WriteLine("Item successfully deleted.");
                    return true;
                }
            }
            Console.WriteLine("Item not found.");
            return false;
        }

        public string printList()
        {
            string output = "";
            for (int i = 0; i < numElements; i++)
            {
                output += "Item " + i + ": " + itemArray[i] + "\n";
            }
            return output;
        }

        public void selectionSortAsc()
        {
            // selection sort goes through the list numElements times and swaps items to their correct position
            for (int i = 0; i < numElements; i++)
            { 
                int minIndex = i;
                for (int j = i; j < numElements; j++)
                {
                    if (itemArray[j] < itemArray[minIndex])
                    {
                        minIndex = j;
                    }
                    int temp = itemArray[minIndex];
                    itemArray[minIndex] = itemArray[i];
                    itemArray[i] = temp;
                }
            }
        }
        public void selectionSortDesc()
        {
            // selection sort goes through the list numElements times and swaps items to their correct position
            for (int i = 0; i < numElements; i++)
            {
                int maxIndex = i;
                for (int j = i; j < numElements; j++)
                {
                    if (itemArray[j] > itemArray[maxIndex])
                    {
                        maxIndex = j;
                    }
                    int temp = itemArray[maxIndex];
                    itemArray[maxIndex] = itemArray[i];
                    itemArray[i] = temp;
                }
            }
        }

        public void insertionSortAsc()
        {
            // insertion sort checks each item to the one next to it and swaps until it reaches the correctly sorted position.
            for (int i = 0; i < numElements; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (itemArray[j] < itemArray[j - 1])
                    {
                        int temp = itemArray[j];
                        itemArray[j] = itemArray[j - 1];
                        itemArray[j - 1] = temp;
                    }
                    j--;
                }
            }
        }
        public void insertionSortDesc()
        {
            // insertion sort checks each item to the one next to it and swaps until it reaches the correctly sorted position.
            for (int i = 0; i < numElements; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (itemArray[j] > itemArray[j - 1])
                    {
                        int temp = itemArray[j];
                        itemArray[j] = itemArray[j - 1];
                        itemArray[j - 1] = temp;
                    }
                    j--;
                }
            }
        }

        public int binarySearch(int item)
        {
            // binary search requires the list to be sorted in ascending order
            int low = 0;
            int high = numElements - 1;
            int middle;
            while (low <= high)
            {
                middle = (low + high) / 2;
                if (itemArray[middle] == item)
                {
                    return middle;
                }
                if (itemArray[middle] < item)
                {
                    low = middle + 1;
                }
                else if (itemArray[middle] > item)
                {
                    high = middle - 1;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            UnorderedArray a = new UnorderedArray(20);
            a.addLast(4);
            a.addLast(7);
            a.addLast(2);
            a.addLast(121);
            a.addLast(21);
            a.addLast(12);
            a.addLast(9);
            a.addLast(-1);
            a.addLast(35);
            a.addLast(4);
            a.addLast(7);
            a.addLast(-12);
            Console.WriteLine(a.printList());
            Console.WriteLine("Ascending Insertion Sort:");
            a.insertionSortAsc();
            Console.WriteLine(a.printList());
            Console.WriteLine("Descending Insertion Sort:");
            a.insertionSortDesc();
            Console.WriteLine(a.printList());
            Console.WriteLine("Ascending Selection Sort:");
            a.selectionSortAsc();
            Console.WriteLine(a.printList());
            int search = a.binarySearch(21);
            Console.WriteLine("Binary Search for 21: " + search);
            search = a.binarySearch(-12);
            Console.WriteLine("Binary Search for -12: " + search);
            search = a.binarySearch(121);
            Console.WriteLine("Binary Search for 121: " + search);
            search = a.binarySearch(7);
            Console.WriteLine("Binary Search for 7: " + search);
            Console.ReadKey();
        }
    }
}
