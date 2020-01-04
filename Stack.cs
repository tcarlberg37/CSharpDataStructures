using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue
{
    class Stack // LIFO = Last In, First Out
    {
        public int top;
        public int[] items;
        public int maxItems;
        public Stack(int max)
        {
            maxItems = max;
            items = new int[max];
            top = -1;
        }
        public bool push(int value) // add an item to the top of the stack
        {
            if(top < maxItems - 1)
            {
                top++;
                items[top] = value;
                return true;
            }
            else
            {
                Console.WriteLine("No more space left in the stack.");
                return false;
            }
        }
        public int pop() // delete and return the top item of the stack
        {
            if (top > -1)
            {
                top--;
                return items[top + 1];
            }
            Console.WriteLine("Stack is empty.");
            return -1;
        }
        public int peek() // look at the top item of the stack
        {
            if (top > -1)
            {
                return items[top];
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Stack s = new Stack(50);
            s.push(5);
            s.push(1);
            s.push(10);
            s.push(-4);
            Console.WriteLine(s.peek());
            Console.WriteLine(s.pop());
            Console.ReadKey();
        }
    }
}
