using System;

namespace Lab10
{
    class Student
    {
        public string fName;
        public string lName;
        public double gpa;
        public int semester;
        public int studentID;

        public Student(string f, string l, double g, int sem, int sid)
        {
            fName = f;
            lName = l;
            gpa = g;
            semester = sem;
            studentID = sid;
        }
        public string toString()
        {
            return "\nStudent ID: " + studentID + "\nFirst Name: " + fName + "\nLast Name: " + lName + "\nGPA: " + gpa + "\nSemester: " + semester;
        }
    }
    class BSTNode
    {
        public Student student;
        public BSTNode left;
        public BSTNode right;
        
        public BSTNode(Student s)
        {
            student = s;
            left = null;
            right = null;
        }
    }
    class BST
    {
        public BSTNode root;
        public BST()
        {
            root = null;
        }
        public void insert(Student student)
        {
            root = insertNode(root, student);
        }
        private BSTNode insertNode(BSTNode curr, Student student)
        {
            BSTNode newNode = new BSTNode(student);
            if (curr == null)
            {
                return newNode;
            }
            else
            {
                if (student.studentID < curr.student.studentID)
                {
                    curr.left = insertNode(curr.left, student);
                }
                if (student.studentID > curr.student.studentID)
                {
                    curr.right = insertNode(curr.right, student);
                }
            }
            return curr;
        }
        public void delete(int ID)
        {
            root = deleteNode(root, ID);
        }
        public BSTNode deleteNode(BSTNode curr, int ID)
        {
            if (curr == null)
            {
                Console.WriteLine("Student with ID " + ID + " does not exist.");
                return curr;
            }
            if (ID < curr.student.studentID)
            {
                curr.left = deleteNode(curr.left, ID);
            }
            else if (ID > curr.student.studentID)
            {
                curr.right = deleteNode(curr.right, ID);
            }
            else  // if we get here we have found the node with the matching ID
            {
                if (curr.left == null)
                {
                    return curr.right;
                }
                if (curr.right == null)
                {
                    return curr.left;
                }
                else
                {
                    BSTNode successor = curr.right;
                    while (successor.left != null)
                    {
                        successor = successor.left;  // find the next in-order successor
                    }
                    curr.student = successor.student;
                    curr.right = deleteNode(curr.right, ID);
                }
            }
            return curr;
        }
        public Student search(int ID)
        {
            BSTNode curr = root;
            while(curr != null)
            {
                if (curr.student.studentID == ID)
                {
                    Console.WriteLine("Student with ID " + ID + " has been found.");
                    return curr.student;
                }
                else if (curr.student.studentID < ID)
                {
                    curr = curr.right;
                }
                else if (curr.student.studentID > ID)
                {
                    curr = curr.left;
                }
            }
            Console.WriteLine("Student with ID " + ID + " does not exist.");
            return null;
        }
        public void inOrder()
        {
            inOrderWorker(root);
        }
        public void inOrderWorker(BSTNode curr)
        {
            if (curr == null)
            {
                return;
            }
            inOrderWorker(curr.left);
            Console.WriteLine(curr.student.toString());
            inOrderWorker(curr.right);
            return;
        }
        public void preOrder()
        {
            preOrderWorker(root);
        }
        public void preOrderWorker(BSTNode curr)
        {
            if (curr == null)
            {
                return;
            }
            Console.WriteLine(curr.student.toString());
            preOrderWorker(curr.left);
            preOrderWorker(curr.right);
            return;
        }
        public void postOrder()
        {
            postOrderWorker(root);
        }
        public void postOrderWorker(BSTNode curr)
        {
            if (curr == null)
            {
                return;
            }
            postOrderWorker(curr.left);
            postOrderWorker(curr.right);
            Console.WriteLine(curr.student.toString());
            return;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Tom", "Carlberg", 4.0, 4, 1010101);
            Student s2 = new Student("Paul", "Ikhane", 3.5, 3, 123451);
            Student s3 = new Student("Enxhi", "Kondi", 3.9, 5, 9876543);
            Student s4 = new Student("Mariza", "Kondi", 3.25, 2, 653344);
            Student s5 = new Student("Amy", "Carlberg", 2.7, 8, 8759342);
            BST tree = new BST();
            tree.insert(s1);
            tree.insert(s2);
            tree.insert(s3);
            tree.insert(s4);
            tree.insert(s5);
            tree.search(1010101);
            tree.delete(1);
            tree.delete(123451);
            tree.delete(8759342);
            Console.WriteLine("~~~~~~~~~~~~~~~ PRE-ORDER ~~~~~~~~~~~~~~~");
            tree.preOrder();
            Console.WriteLine("~~~~~~~~~~~~~~~ POST-ORDER ~~~~~~~~~~~~~~");
            tree.postOrder();
            Console.WriteLine("~~~~~~~~~~~~~~~ IN-ORDER ~~~~~~~~~~~~~~~~");
            tree.inOrder();

            Console.ReadKey();
        }
    }
}
