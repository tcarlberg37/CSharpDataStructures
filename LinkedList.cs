using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
    class LinkedList
    {
        public Node head;
        public LinkedList()
        {
            head = null;
        }
        public void addFront(int data)
        {
            Node newNode = new Node(data);
            newNode.next = head;
            head = newNode;
        }
        public void addLast(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node current = head;
            while(current.next != null)
            {
                current = current.next; // traverse to the end of the linked list
            }
            current.next = newNode;
        }
        public void printList()
        {
            Node current = head;
            while(current != null)
            {
                Console.WriteLine("Node Data: " + current.data);
                current = current.next;
            }
            Console.WriteLine();
        }
        public void printReverse(Node head)
        {
            Node current = head;
            if (current == null)
            {
                return;
            }
            printReverse(current.next);
            Console.WriteLine("Node Data: " + current.data);
        }
        public void addInOrder(int value)
        {
            Node newNode = new Node(value);
            if (head == null || head.data >= value)
            {
                newNode.next = head;
                head = newNode;
                return;
            }
            Node previous = head;
            Node current = head.next;
            while (current != null && current.data < value)
            {
                previous = current;
                current = current.next;
            }
            previous.next = newNode; // insert the node in between the previous and current
            newNode.next = current;
        }
        public int delete(int value)
        {
            Node current = head;
            if (head == null)
            {
                return -1;
            }
            else if (head.data == value)
            {
                head = current.next;
                return current.data;
            }
            while (current != null)
            {
                if(current.next != null && current.next.data == value)
                {
                    current.next = current.next.next; // remove the link to the next Node
                    return current.data;
                }
                current = current.next;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();
            ll.addInOrder(10);
            ll.addInOrder(3);
            ll.addInOrder(200);
            ll.addInOrder(-60);
            ll.addInOrder(37);
            ll.addInOrder(-5);
            ll.printList();
            Console.WriteLine("Reverse: ");
            ll.printReverse(ll.head);
            ll.delete(12121);
            ll.delete(-60);
            ll.delete(200);
            Console.WriteLine("\nDelete first and last: ");
            ll.printList();

            Console.ReadKey();
        }
    }
}
