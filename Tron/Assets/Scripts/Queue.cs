using StackNS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QueueNS
{
    internal class DoubleNode<T>
    {
        public T value;
        public DoubleNode<T> next;
        public DoubleNode<T> previous;
    }

    public class Queue<T>
    {
        private DoubleNode<T> first;

        public void Enqueue(T value)
        {
            DoubleNode<T> newNode = new DoubleNode<T>();
            newNode.value = value;

            if (first == null)
            {
                first = newNode;
            }

            else
            {
                DoubleNode<T> current = first;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = newNode;
                newNode.previous = current;

            }
        }

        public void Dequeue()
        {
            if (first == null)
            {
                throw new Exception("Queue is empty.");

            }
            else
            {
                DoubleNode<T> nextFirst = first.next;

                nextFirst.previous = null;
                first = nextFirst;

            }
        }

        public int Count()
        {
            int counter = 0;

            if (first != null)
            {
                DoubleNode<T> current = first;

                while (current != null)
                {
                    counter++;
                    current = current.next;
                }
            }

            return counter;
        }

        public void Print()
        {
            if (first != null)
            {
                DoubleNode<T> current = first;

                while (current != null)
                {
                    Console.WriteLine(current.value);
                    current = current.next;
                }

                Console.WriteLine("-------");

            }
        }

    }
    }




