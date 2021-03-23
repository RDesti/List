using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        private Node _root;
        private Node _tail;

        private int _length;
        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                if(value >= 0)
                {
                    _length = value;
                }
                else if(value < 0)
                {
                    _length = 0;
                }
            }
        }

        public int this[int index]
        {
            get
            {
                Node current;
                if (index > 0 && index < Length)
                {
                    current = GetNodeByIndex(index);

                }
                else if(index == 0)
                {
                    current = _root;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                return current.Value;
            }
            set
            {
                Node current = _root;
                if (index > 0 && index < Length)
                {
                    current = GetNodeByIndex(index);

                }
                else if(index == 0)
                {
                    current = _root;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                current.Value = value;
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
            if (Length != 0)
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }
                ++Length;
        }
        public void AddFirst(int value)
        {
            ++Length;
            Node firstNode = new Node(value);
            firstNode.Next = _root;
            _root = firstNode;
        }
        public void AddByIndex(int index, int value)
        {
            if (index != 0)
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                Node insertNode = new Node(value);

                insertNode.Next = current.Next;
                current.Next = insertNode;
            }
            else
            {
                AddFirst(value);
            }
            ++Length;
        }
        public void Remove()
        {
            if (Length > 1)
            {
                --Length;
                Node current = GetNodeByIndex(Length - 1);
                _tail = current;
            }
            else
            {
                RemoveFirst();
            }
        }
        public void RemoveFirst()
        {
            --Length;
            if (Length > 1)
            {
                _root = _root.Next;
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }
        public void RemoveByIndex(int index)
        {
            Node current = GetNodeByIndex(index - 1);
            current.Next = current.Next.Next;
            --Length;
        }
        public void Remove(int countElements)
        {
            if(Length > countElements)
            {
                Length -= countElements;
                Node current = GetNodeByIndex(Length-1);
                _tail = current;
            }
            else
            {
                Length = 0;
                _tail = null;
                _root = null;
            }
        }
        public void RemoveFirst(int countElements)
        {
            if (Length > countElements)
            {
                Node current = GetNodeByIndex(countElements);
                _root = current;
                Length -= countElements;
            }
            else
            {
                Length = 0;
                _tail = null;
                _root = null;
            }
        }
        public void RemoveByIndex(int index, int countElements)
        {
            if (Length > countElements)
            {
                Node tmpNode;
                if (index + countElements + 1 > Length)
                {
                    tmpNode = GetNodeByIndex(Length - 1);
                }
                else
                {
                    tmpNode = GetNodeByIndex(index + countElements - 1);
                }
                Node current = GetNodeByIndex(index - 1);
                current.Next = tmpNode.Next;
                if (Length < index + countElements)
                {
                    Length -= index + countElements - Length;
                }
                else
                {
                    Length -= countElements;
                }
            }
            else
            {
                Length = 0;
                _tail = null;
                _root = null;
            }
        }
        public int GetFirstIndex(int value)
            {
                int firstIndex = -1;
                Node current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if(current.Value == value)
                    {
                        firstIndex = i;
                        break;
                    }
                current = current.Next;
                }
                return firstIndex;
            }
        public void GetReverst()
        {
            Node current = _root;
            Node prev = null;
            Node next;
            while(!(current is null))
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            _root = prev;
        }
        public int FindMax()
        {
            Node current = GetNodeByIndex(FindIndexMax());
            int max = current.Value;
            return max;
        }
        public int FindMin()
        {
            Node current = GetNodeByIndex(FindIndexMin());
            int min = current.Value;
            return min;
        }
        public int FindIndexMax()
        {
            Node current = _root;
            int indexMax = 0;
            int max = current.Value;
            for(int i = 0; i < Length; i++)
            {
                if(current.Value > max)
                {
                    max = current.Value;
                    indexMax = i;
                }
                current = current.Next;
            }
            return indexMax;
        }
        public int FindIndexMin()
        {
            Node current = _root;
            int indexMin = 0;
            int min = current.Value;
            for(int i = 0; i < Length; i++)
            {
                if(current.Value < min)
                {
                    min = current.Value;
                    indexMin = i;
                }
                current = current.Next;
            }
            return indexMin;
        }

        private Node GetNodeByIndex(int index)
        {
             Node current = _root;
            if (index > 0 && index < Length)
            {
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            else if(index == 0)
            {
                current = _root;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
                return current;
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
            if (currentThis is null && currentList is null)
            {
                return true;
            }
                do
                {
                    if (currentThis.Value != currentList.Value)
                    {
                        return false;
                    }
                    if (Length > 1)
                    {
                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                }
                while (!(currentThis.Next is null));
            return true;
        }
    }
}
