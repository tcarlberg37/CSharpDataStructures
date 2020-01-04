using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Lecture
{
    class Node
    {
        private int data;
        public Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    class LinkedList
    {
        private Node head;

        public void append(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return;
            }
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node(data); // create a new node at the end of the linked list
        }

        public void prepend(int data)
        {
            Node oldHead = head;
            this.head = new Node(data);
            head.next = oldHead;
        }
    }

    class Program
    {
        static int[] addOne(int[] arr, int size)
        {   // assume arr is an array where each index is a digit of a large number in order, add one to the number
            if (arr[size - 1] < 9)
            {
                arr[size - 1]++;
                return arr;
            }
            else if (size == 1 && arr[0] == 9)
            {
                int[] plusOne = new int[arr.Length + 1];
                plusOne[0] = 1;
                for (int i = 1; i < size; i++)
                {
                    plusOne[i] = 0;
                }
                return plusOne;
            }
            else
            {
                arr[size - 1] = 0;
                return addOne(arr, size - 1);
            }
        }

        static int binarySearch(int[] arr, int size, int key)
        {
            int low, mid, hi;
            low = 0;
            hi = size - 1;
            while(low <= hi)
            {
                mid = (low + hi) / 2;
                if (arr[mid] == key)
                {
                    return mid;
                }
                else if (arr[mid] > key)
                {
                    hi = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
        }
    }
}
