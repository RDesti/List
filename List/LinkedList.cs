using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        private Node _root;
        private Node _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index > 0 && index < Length)
                {
                    Node current = GetNodeByIndex(index);

                    return current.Value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index > 0 && index < Length)
                {
                    Node current = GetNodeByIndex(index);

                    current.Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }
        public LinkedList(int[] values)                       //if values is null - need exception NullReference
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }
        public void Add(int value)
        {
            ++Length;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }
        public void RemoveFirst()
        {
            _root = _root.Next;
        }
        public void RemoveByIndex(int index)
        {
            Node current = _root;

            for(int i = 1; i < index; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            --Length;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index > 0 && index < Length)
            {
                Node current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }
                return s;
            }
            else
            {
                return string.Empty;
            }
        }
        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if(this.Length != list.Length)
            {
                return false;
            }
            Node currentThis = _root;
            Node currentList = list._root;

            do
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentThis = currentThis.Next;
                currentList = currentList.Next;
            }
            while (!(currentThis.Next is null));
            return true;
        }
    }
}
