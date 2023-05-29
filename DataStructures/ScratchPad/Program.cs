using System;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckBracketsIfBalanced("(([([(())])]))");
        }

        public static void CheckBracketsIfBalanced(string text)
        {
            var stack = new StackLinkedList();

            foreach(var character in text)
            {
                if(character == '(' || character == '[')
                {
                    stack.Push(character);
                }
                else
                {
                    var returnedChar = stack.Pop();

                    if(!((returnedChar=='(' && character == ')') || (returnedChar=='[' && character == ']')))
                    {
                        System.Console.WriteLine("NOT BALANCED");
                        break;
                    }
                }
            }

            if(!stack.IsEmpty())
            {
                System.Console.WriteLine("NOT BALANCED");
            }
            else
            {
                System.Console.WriteLine("BALANCED");
            }
        }
    }

    public class StackLinkedList
    {
        Node head = null;

        public void Push(char c)
        {
            if(head == null)
            {
                head = new Node{ key = c};
            }
            else
            {
                var temp = head;
                head = new Node{ key = c};
                head.next = temp;
                temp = null;
            }
        }

        public char Pop()
        {
            if(head == null)
            {
                throw new Exception("NO ELEMENTS!");
            }
            else
            {
                var temp =  head.key;
                head = head.next;
                return temp;
            }
        }

        public bool IsEmpty()
        {
            return head == null ? true : false;
        }
    }

    class Node
    {
        public char key { get; set; }
        public Node next { get; set; }
    }
}
