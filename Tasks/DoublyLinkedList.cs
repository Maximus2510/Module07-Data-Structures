using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedListNode<T>
    {
        public T Data { get; private set; }
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        public DoublyLinkedListNode(T data)
        {
            Data = data;
        }
    }
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> tail;
        public int Length { get; private set;}

        
        public void Add(T e)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(e);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }

            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == Length)
            {
                Add(e);
                return;
            }

            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(e);

            if (index == 0)
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
            else
            {
                DoublyLinkedListNode<T> current = head;

                for (int i=0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                node.Next = current.Next;
                node.Prev = current;
                current.Next.Prev = node;
                current.Next = node;
            }
            Length++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            DoublyLinkedListNode<T> current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //DoublyLinkedListNode<T> current = head;

            //foreach(T item in )
            //{

            //}
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    
}
