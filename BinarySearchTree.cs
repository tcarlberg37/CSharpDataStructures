using System;

namespace BinarySearchTree
{
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
    class BST
    {
        public Node root;

        public BST()
        {
            root = null;
        }
        public void insertNode(int num)
        {
            root = insert(root, num);
        }
        private Node insert(Node curr, int num)
        {
            Node newNode = new Node(num);
            if (curr == null)
            {
                return newNode;
            }
            else
            {
                if (num < curr.data)
                {
                    curr.left = insert(curr.left, num);
                }
                if (num > curr.data)
                {
                    curr.right = insert(curr.right, num);
                }
            }
            return curr;
        }
        public int search(int num)
        {
            return searchWorker(root, num);
        }
        private int searchWorker(Node curr, int num)
        {
            if (curr == null)
            {
                return -1;
            }
            if (curr.data == num)
            {
                Console.WriteLine(num + " found.");
                return num;
            }
            if (curr.data > num)
            {
                return searchWorker(curr.left, num);
            }
            return searchWorker(curr.right, num);
        }
        public int nonRecursiveSearch(int num)
        {
            Node curr = root;
            while (curr != null)
            {
                if (curr.data == num)
                {
                    Console.WriteLine(num + " found.");
                    return num;
                }
                if (curr.data < num)
                {
                    curr = curr.right;
                }
                else
                {
                    curr = curr.left;
                }
            }
            Console.WriteLine(num + " not found.");
            return -1;

        }
        public void inOrder()
        {
            inOrderWorker(root);
        }
        private void inOrderWorker(Node curr)  // IN-ORDER TRAVERSAL = LEFT, VISIT, RIGHT
        {
            if (curr == null)
            {
                return;
            }
            inOrderWorker(curr.left);
            Console.Write("{0} ", curr.data);
            inOrderWorker(curr.right);
            return;
        }
        public void preOrder()
        {
            preOrderWorker(root);
        }
        private void preOrderWorker(Node curr)  // PRE-ORDER TRAVERSAL = VISIT, LEFT, RIGHT
        {
            if (curr == null)
            {
                return;
            }
            Console.Write("{0} ", curr.data);
            preOrderWorker(curr.left);
            preOrderWorker(curr.right);
            return;
        }
        public void postOrder()
        {
            postOrderWorker(root);
        }
        private void postOrderWorker(Node curr)  // POST-ORDER TRAVERSAL = LEFT, RIGHT, VISIT
        {
            if (curr == null)
            {
                return;
            }
            postOrderWorker(curr.left);
            postOrderWorker(curr.right);
            Console.Write("{0} ", curr.data);
            return;
        }
        public void levelOrder()
        {
            Node[] nodeList = new Node[100];
            int head = 0, tail = 1;
            nodeList[head] = root;
            while (head != tail)
            {
                Console.Write("{0} ", nodeList[head].data);
                if (nodeList[head].left != null)
                {
                    nodeList[tail] = nodeList[head].left;
                    tail++;
                }
                if (nodeList[head].right != null)
                {
                    nodeList[tail] = nodeList[head].right;
                    tail++;
                }
                head++;
            }
        }
        
        public void delete(int num)
        {
            root = deleteNode(root, num);
        }
        public Node deleteNode(Node curr, int num)
        {
            if (curr == null)
            {
                Console.WriteLine(num + " not found. No node deleted.");
                return curr;
            }
            if (num < curr.data)
            {
                curr.left = deleteNode(curr.left, num);
            }
            else if (num > curr.data)
            {
                curr.right = deleteNode(curr.right, num);
            }
            else // we have found the node to be deleted
            {
                // CASE 1: delete a leaf node (a node which has no children)
                // CASE 2: delete a node that has a single child (either left or right child)
                if (curr.left == null)
                {
                    return curr.right;
                }
                if (curr.right == null)
                {
                    return curr.left;
                }
                // CASE 3: delete a node that has 2 child nodes (Replace node by its in-order successor or predecessor)
                else
                {
                    Node successor = curr.right;
                    while (successor.left != null)
                    {
                        successor = successor.left; // in-order successor
                    }
                    curr.data = successor.data; // copy the data
                    curr.right = deleteNode(curr.right, num);
                }
            }
            return curr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.insertNode(8);
            tree.insertNode(4);
            tree.insertNode(17);
            tree.insertNode(1);
            tree.insertNode(11);
            tree.insertNode(22);
            tree.insertNode(-5);
            tree.insertNode(7);
            tree.insertNode(37);

            Console.WriteLine("\n----- IN-ORDER TRAVERSAL -----");
            tree.inOrder();
            Console.WriteLine("\n----- PRE-ORDER TRAVERSAL -----");
            tree.preOrder();
            Console.WriteLine("\n----- POST-ORDER TRAVERSAL -----");
            tree.postOrder();
            Console.WriteLine("\n----- LEVEL-ORDER TRAVERSAL -----");
            tree.levelOrder();
            Console.WriteLine("\n----- SEARCH TESTS ------");
            tree.nonRecursiveSearch(7);
            tree.nonRecursiveSearch(8);
            tree.nonRecursiveSearch(100);

            tree.delete(37);
            tree.delete(11);
            tree.delete(100);
            tree.delete(8);
            tree.inOrder();

            Console.ReadKey();
        }
    }
}
