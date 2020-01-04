using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class HashTable
    {
        private string[] table;
        private int size;

        public HashTable(int s)
        {
            size = s;
            table = new string[size];
            for (int i = 0; i < size; i++)
            {
                table[i] = "EMPTY";
            }
        }

        public int hashFunction(string word)
        {
            int key = word[0] - 'a'; // get ASCII code for the first character of the string
            return key % size;
        }
        public int hashFunction2(string word)
        {
            int key = 0;
            for (int i = 0; i < word.Length; i++)
            {
                key += (int)word[i];  // get the ASCII code for each character in the string
            }
            return key % size;
        }

        public void insert(string word)
        {
            int key = hashFunction(word);
            if (table[key] == "EMPTY")
            {
                table[key] = word;
                Console.WriteLine(word + " successfully inserted into the table.");
            }
            else
            {   // LINEAR PROBING
                /*
                for (int i = key + 1; i < (size + key); i++) // size + key so that the loop will go around the end of the list if necessary
                {
                    if (table[i % size] == null)
                    {
                        table[i % size] = word;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                */

                // DOUBLE HASHING
                /*
                while (table[key] != "EMPTY")
                {
                    key = (key + hashFunction2(word)) % size;
                }
                table[key] = word;
                */

                // QUADRATIC PROBING
                int i = 1;
                while (table[key] != "EMPTY")
                {
                    key = (key + i * i) % size;
                    i++;
                }
                table[key] = word;
            }
        }

        public int search(string word)
        {
            int key = hashFunction(word);
            for (int i = key; i < (size + key); i++)  // linear probing search 
            {
                if (table[i % size] == word)
                {
                    return i % size;
                }
                else
                {
                    continue;
                }
            }
            return -1;
        }

        public bool delete(string word)
        {
            int key = search(word);
            if (key != -1)
            {
                table[key] = "EMPTY";
                Console.WriteLine(word + " successfully deleted from the table.");
                return true;
            }
            Console.WriteLine(word + " does not exist in the table.");
            return false;
        }

        public string printTable()
        {
            string output = "---------- HASH TABLE ----------\nIndex\t\tWord";
            for (int i = 0; i < size; i++)
            {
                output += "\n" + i + "\t\t" + table[i];
            }
            return output;
        }

        static void Main(string[] args)
        {
            HashTable ht = new HashTable(37); // hash tables should be of a prime number size for fewest collisions
            ht.insert("apple");
            ht.insert("cat");
            ht.insert("giraffe");
            ht.insert("gorgonzola");
            ht.insert("garbanzo");
            ht.insert("aardvark");
            ht.insert("amarillo");
            //ht.delete("gorgonzola");
            //ht.delete("cat");
            ht.insert("cat");
            ht.insert("cat");
            ht.insert("cat");
            Console.WriteLine(ht.search("garbanzo"));
            Console.WriteLine(ht.search("gorgonzola"));
            Console.WriteLine(ht.printTable());

            Console.ReadKey();
        }
    }
}
