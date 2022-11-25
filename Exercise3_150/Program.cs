using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }

        public void addNote() 
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the Student : ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            
            if (LAST == null || nim <= LAST.rollNumber)
            {
                if ((LAST == null) && (nim == LAST.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;

                }
                newnode.next = LAST;
                LAST = newnode;
                return;
            }

            
            Node previous, current;
            previous = LAST;
            current = LAST;

            while ((current != null) && (nim >= current.rollNumber)) ;
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll number not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }


            newnode.next = current;
            previous.next = newnode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous =
                current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*if the node is present at the end*/
                return true;
            else
                return (false);/*returns false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()/*Travers all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "    " +
                        currentNode.name + "\n");
                }
                Console.Write(LAST.rollNumber + "    " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" +
                    LAST.next.rollNumber + "    " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("List is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("Record found");
                                    Console.WriteLine("Roll number: " +
                                        curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }

}