﻿using System;

namespace List
{
    public class DoubleLinkedList
    {
        private DoubleLinkedNode _root;
        private DoubleLinkedNode _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                DoubleLinkedNode current;

                if (index > 0 && index < Length)
                {
                    current = GetNodeByIndex(index);

                }
                else if (index == 0)
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
                DoubleLinkedNode current = _root;

                if (index > 0 && index < Length)
                {
                    current = GetNodeByIndex(index);

                }
                else if (index == 0)
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

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleLinkedNode(value);
            _tail = _root;
        }

        public DoubleLinkedList(int[] values)                       //if values is null - need exception NullReference  in  Create method
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DoubleLinkedNode(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    DoubleLinkedNode tmp = _tail;

                    _tail.Next = new DoubleLinkedNode(values[i]);
                    _tail = _tail.Next;
                    _tail.Previous = tmp;
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
                _tail.Next = new DoubleLinkedNode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }
            else
            {
                _root = new DoubleLinkedNode(value);
                _tail = _root;
            }

            ++Length;
        }

        public void AddFirst(int value)
        {
            if (Length != 0)
            {
                DoubleLinkedNode firstNode = new DoubleLinkedNode(value);

                _root.Previous = firstNode;
                firstNode.Next = _root;
                _root = firstNode;
            }
            else
            {
                _root = new DoubleLinkedNode(value);
                _tail = _root;
            }

            ++Length;
        }

        public void AddByIndex(int index, int value)
        {
            if (index > 0 && index < Length)
            {
                DoubleLinkedNode current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                DoubleLinkedNode insertNode = new DoubleLinkedNode(value);

                insertNode.Next = current.Next;
                insertNode.Previous = current;
                current.Next = insertNode;
                ++Length;
            }
            else if (index == Length)
            {
                Add(value);
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddList(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                if (Length != 0)
                {
                    _tail.Next = list._root;
                    list._root.Previous = _tail;
                    _tail = list._tail;
                    Length += list.Length;
                }
                else
                {
                    _root = list._root;
                    _tail = list._tail;
                    Length += list.Length;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddListFirst(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                if (Length != 0)
                {
                    list._tail.Next = _root;
                    _root.Previous = list._tail;
                    _root = list._root;
                    Length += list.Length;
                }
                else
                {
                    _root = list._root;
                    _tail = list._tail;
                    Length += list.Length;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddListByIndex(DoubleLinkedList list, int index)
        {
            if (index > 0 && index < Length)
            {
                DoubleLinkedNode current = GetNodeByIndex(index - 1);

                list._tail.Next = current.Next;
                list._root.Previous = current;
                current.Next.Previous = list._tail;
                current.Next = list._root;
                Length += list.Length;
            }
            else if (index == Length)
            {
                AddList(list);
            }
            else if (index == 0)
            {
                AddListFirst(list);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove()
        {
            if (Length > 1)
            {
                DoubleLinkedNode current = _tail.Previous;

                _tail = current;
                --Length;
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
                _root.Previous = null;
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            else if (index > 0 && index < Length - 1)
            {
                DoubleLinkedNode current = GetNodeByIndex(index - 1);

                current.Next = current.Next.Next;
                current.Next.Previous = current;
                --Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(int countElements)
        {
            if (countElements >= 0)
            {
                if (Length > countElements)
                {
                    Length -= countElements;

                    DoubleLinkedNode current = GetNodeByIndex(Length - 1);

                    _tail = current;
                }
                else
                {
                    Length = 0;
                    _tail = null;
                    _root = null;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveFirst(int countElements)
        {
            if (countElements >= 0)
            {
                if (Length > countElements)
                {
                    DoubleLinkedNode current = GetNodeByIndex(countElements);

                    _root = current;
                    _root.Previous = null;
                    Length -= countElements;
                }
                else
                {
                    Length = 0;
                    _tail = null;
                    _root = null;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveByIndex(int index, int countElements)
        {
            if ((index >= 0 && index < Length) && countElements >= 0)
            {
                if (Length > countElements)
                {
                    DoubleLinkedNode tmpNode;
                    DoubleLinkedNode current = GetNodeByIndex(index - 1);

                    if (index + countElements + 1 > Length)
                    {
                        current.Next = _tail.Next;
                        _tail = current;
                    }
                    else
                    {
                        tmpNode = GetNodeByIndex(index + countElements - 1);
                        current.Next = tmpNode.Next;
                        tmpNode.Previous = current.Previous;
                    }

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
            else
            {
                throw new ArgumentException();
            }
        }

        public int RemoveFirstByValue(int value)
        {
            int indexRemoveValue = -1;
            DoubleLinkedNode current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    RemoveByIndex(i);
                    indexRemoveValue = i;
                    break;
                }

                current = current.Next;
            }

            return indexRemoveValue;
        }

        public int RemoveAllByValue(int value)
        {
            int countRemoveValues = 0;
            DoubleLinkedNode current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    RemoveByIndex(i);
                    --i;
                    ++countRemoveValues;
                }

                current = current.Next;
            }

            return countRemoveValues;
        }

        public int GetFirstIndex(int value)
        {
            int firstIndex = -1;
            DoubleLinkedNode current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    firstIndex = i;
                    break;
                }

                current = current.Next;
            }

            return firstIndex;
        }

        public void Reverse()
        {
            if (Length >= 0)
            {
                DoubleLinkedNode current = _root;

                while (!(current is null))
                {
                    DoubleLinkedNode tmp = current.Next;

                    current.Next = current.Previous;
                    current.Previous = tmp;
                    current = current.Previous;
                }

                current = _root;
                _root = _tail;
                _tail = current;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public int FindMax()
        {
            DoubleLinkedNode current = GetNodeByIndex(FindIndexMax());

            return current.Value;
        }

        public int FindMin()
        {
            DoubleLinkedNode current = GetNodeByIndex(FindIndexMin());

            return current.Value;
        }

        public int FindIndexMax()
        {
            if (Length > 0)
            {
                DoubleLinkedNode current = _root;
                int indexMax = 0;
                int max = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value > max)
                    {
                        max = current.Value;
                        indexMax = i;
                    }

                    current = current.Next;
                }

                return indexMax;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public int FindIndexMin()
        {
            if (Length > 0)
            {
                DoubleLinkedNode current = _root;
                int indexMin = 0;
                int min = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value < min)
                    {
                        min = current.Value;
                        indexMin = i;
                    }

                    current = current.Next;
                }

                return indexMin;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void SelectSortAscending()
        {
            if (Length != 0)
            {
                DoubleLinkedNode current = _root;

                while (current != null)
                {
                    DoubleLinkedNode minimum = current;
                    DoubleLinkedNode currentInner = current.Next;

                    while (currentInner != null)
                    {
                        if (currentInner.Value < minimum.Value)
                        {
                            minimum = currentInner;
                        }

                        currentInner = currentInner.Next;
                    }

                    int temp = current.Value;

                    current.Value = minimum.Value;
                    minimum.Value = temp;
                    current = current.Next;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void InsertSortDescending()
        {
            if (Length > 0)
            {
                DoubleLinkedNode current = _root;

                while (current != null)
                {
                    while (current.Previous != null && current.Previous.Value < current.Value)
                    {
                        int tmpValue = current.Value;

                        current.Value = current.Previous.Value;
                        current.Previous.Value = tmpValue;
                        current = current.Previous;
                    }

                    current = current.Next;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private DoubleLinkedNode GetNodeByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                DoubleLinkedNode current;

                if (index < Length / 2)
                {
                    current = _root;

                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }
                }
                else
                {
                    current = _tail;

                    for (int i = Length - 1; i > index; i--)
                    {
                        current = current.Previous;
                    }
                }

                return current;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override string ToString()                                      //stringBuilder     1return
        {
            if (Length != 0)
            {
                DoubleLinkedNode current = _root;
                string str = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    str += current.Value + " ";
                }

                return str;
            }
            else
            {
                return string.Empty;
            }
        }

        public override bool Equals(object obj)                         //return 1
        {
            DoubleLinkedList list = (DoubleLinkedList)obj;

            if (Length != list.Length)
            {
                return false;
            }

            DoubleLinkedNode currentThis = _root;
            DoubleLinkedNode currentList = list._root;

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
            while (!(currentThis.Next is null || currentThis.Previous is null));

            return true;
        }
    }
}
