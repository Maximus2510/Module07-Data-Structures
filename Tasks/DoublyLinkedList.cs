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
            return new DoublyLinkedListEnumerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(T item)
        {
            DoublyLinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current == head)
                    {
                        head = current.Next;
                        if (head != null)
                        {
                            head.Prev = null;
                        }
                    }
                    else if (current == tail)
                    {
                        tail = current.Prev;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    Length--;
                    return;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
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

            if (current == head)
            {
                head = current.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            else if (current == tail)
            {
                tail = current.Prev;
                tail.Next = null;
            }
            else
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }

            Length--;

            return current.Data;
        }
    }

    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> current;

        public DoublyLinkedListEnumerator(DoublyLinkedListNode<T> head)
        {
            this.head = head;
            current = null;
        }

        public T Current
        {
            get { return current.Data; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (current == null)
            {
                current = head;
            }
            else
            {
                current = current.Next;
            }

            return (current != null);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

}
