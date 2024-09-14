using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LinkedListNS;

namespace StackNS
{
    internal class DoubleNode<T>
    {
        public T value;
        public DoubleNode<T> next;
        public DoubleNode<T> previous;
    }

    public class  Stack<T>
    {
        private DoubleNode<T> first;
        private DoubleNode<T> top;

        public void Push(T value)
        {
            DoubleNode<T> newItem = new DoubleNode<T>();
            newItem.value = value;

            if (first == null)
            {
                first = newItem;
                top = newItem;
            }
            else
            {
                DoubleNode<T> current = first;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = newItem;
                newItem.previous = current;
                top = newItem;
            }
        }

        public void Pop()
        {
            if (first == null)
            {
                throw new System.Exception("Stack is empty");
            }
            else if (top == first)
            {
                first = top = null;
            }
            else
            {
                top = top.previous;
                top.next = null;
            }
            
        }

        public T Top()
        {
            return top.value;
        }
    }
}
