using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleList
{
    class Program
    {
        class CircleList
        {
            private int value;
            private CircleList prev;
            private CircleList next;

            public CircleList(int value)
            {
                Value = value;
            }

            public int Value { get => value; set => this.value = value; }
            public CircleList Prev { get => prev; set => prev = value; }
            public CircleList Next { get => next; set => next = value; }

            public static CircleList CreateHead(int value)
            {
                CircleList head = new CircleList(value);
                head.Next = head;
                head.Prev = head;
                return head;
            }

            public void Add(int value)
            {
                CircleList newElement = new CircleList(value);
                AddElement(ref newElement);
            }

            public void AddElement(ref CircleList newElement)
            {
                if (Next == null)
                {
                    Next = newElement;
                }
                else
                {
                    newElement.Next = Next;
                    newElement.Next.Prev = newElement;
                    Next = newElement;
                }
                newElement.Prev = this;
            }

            public void Delete(ref CircleList head)
            {
                // if head is alone
                if (this == this.Prev)
                {
                    head = null;
                    return;
                }

                // if head is not alone
                if (this == head)
                {
                    head = this.Prev;
                }

                // if isn
                this.Prev.Next = this.Next;
                this.Next.Prev = this.Prev;
            }
        }

        static void Main(string[] args)
        {
            CircleList head = CircleList.CreateHead(1);
            PrintList(ref head);
            head.Add(2);
            PrintList(ref head);
            head.Add(3);
            PrintList(ref head);
            CircleList element = new CircleList(20);
            head.AddElement(ref element);
            PrintList(ref head);
            head.Add(4);
            PrintList(ref head);
            head.Add(5);
            PrintList(ref head);
            element.Add(21);
            PrintList(ref head);


            element.Delete(ref head);
            PrintList(ref head);


            CircleList temp = FindByValueFromHead(ref head, 2);
            Console.Read();


        }

        static CircleList FindByValueFromHead(ref CircleList head, int value)
        {
            if (head.Value == value)
            {
                return head;
            }

            CircleList item = head.Next;
            while (item != head)
            {
                if (item.Value == value)
                {
                    return item;
                }
                item = item.Next;
            }
            return null;
        }

        static void PrintList(ref CircleList head)
        {
            CircleList item = head;
            do
            {
                Console.Write(item.Value + "\t");
                item = item.Next;
            } while (item != head);
            Console.WriteLine();
        }
    }
}
