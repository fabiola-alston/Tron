using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinkedListNS
{
    public interface ILinkedList<Type>
    {
        public void AddFirst(Type value) { }

        public void AddLast(Type value) { }

        public void Clear() { }

        public void Print() { }

        public void RemoveFirst() { }

        public void RemoveLast() { }

        public void Remove(Type value) { }

        public void RemoveAt(int index) { }

    }

    internal class Node<Type>
    {
        public Type value;
        public Node<Type> next;

    }

    // singly linked list class
    public class SinglyLinkedList<Type> : ILinkedList<Type>
    {
        private Node<Type> first;
        private Node<Type> current;
        private Node<Type> previous;
        private int? counter;


        // add or change first value
        public void AddFirst(Type value)
        {
            if (value == null) throw new ArgumentNullException();

            if (first == null)
            {
                first = new Node<Type>();
                first.value = value;
            }
            else
            {
                Node<Type> new_first = new Node<Type>();
                new_first.value = value;
                new_first.next = first;

                first = new_first;
            }


        }

        // add a value to end of linked list
        public void AddLast(Type value)
        {
            if (first != null)
            {
                current = first;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = new Node<Type>();
                current.next.value = value;
            }
            else
            {
                this.AddFirst(value);
            }
        }

        // clear list (delete all elements)
        public void Clear()
        {
            first = null;
        }

        // print out list to console
        public void Print()
        {
            if (first != null)
            {
                current = first;

                while (current != null)
                {
                    Console.WriteLine(current.value);
                    current = current.next;
                }
            }
        }


        // remove first item from list (head)
        public void RemoveFirst()
        {
            if (first != null)
            {
                current = first.next;
                first = current;

            }

        }

        // remove last item from list
        public void RemoveLast()
        {
            if (first != null)
            {
                current = first;

                while (current.next != null)
                {
                    previous = current;
                    current = current.next;
                }

                previous.next = null;

            }
        }

        // removes specified data
        public void Remove(Type value)
        {
            if (first != null)
            {
                current = first;

                while (current != null)
                {
                    if (current.value.Equals(value))
                    {
                        previous.next = current.next;
                    }

                    previous = current;
                    current = current.next;
                }
            }
        }

        // removes data at specified index
        public void RemoveAt(int index)
        {
            if (first != null)
            {
                counter = 0;
                current = first;

                while (counter < index)
                {
                    previous = current;
                    current = current.next;
                    counter++;
                }

                previous.next = current.next;

            }
        }

        public Type Index(int index)
        {

            if (first == null)
            {
                throw new Exception("Tried referencing index, list is empty.");
            }
            else
            {
                current = first;

                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }
            }

            return current.value;
        }

        public int Length()
        {
            int length = 0;

            current = first;

            while (current != null)
            {
                current = current.next;
                length++;
            }

            return length;
        }

    }

    public class LinkedList : MonoBehaviour
    {
    }

}
