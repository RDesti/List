using System;

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
                Node current;

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
                Node current;

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

            if (values.Length != 0 && values != null)
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
            if (index > 0 && index < Length)
            {
                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                Node insertNode = new Node(value);

                insertNode.Next = current.Next;
                current.Next = insertNode;
                ++Length;
            }
            else if (index == Length)
            {
                Add(value);
            }
            else if(index == 0)
            {
                AddFirst(value);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddList(LinkedList list)
        {
            if (!(list is null))
            {
                if (Length == 0)
                {
                    AddListFirst(list);
                }
                else
                {
                    _tail.Next = list._root;
                    _tail = list._tail;
                    Length += list.Length;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddListFirst(LinkedList list)
        {
            if (!(list is null))
            {
                if (Length == 0)
                {
                    _root = list._root;
                    _tail = list._tail;
                }
                else
                {
                    list._tail.Next = _root;
                    _root = list._root;
                }

                Length += list.Length;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddListByIndex(LinkedList list, int index)
        {
            if (index >= 1 && index <= Length)
            {
                Length += list.Length;

                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                list._tail.Next = current.Next;
                current.Next = list._root;
            }
            else if (index == 0)
            {
                AddListFirst(list);
            }
            else if (index == Length)
            {
                AddList(list);
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
            if (Length > 0)
            {
                --Length;
            }

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
            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            else if(index > 0 && index < Length - 1)
            {
                Node current = GetNodeByIndex(index - 1);

                current.Next = current.Next.Next;
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

                    Node current = GetNodeByIndex(Length - 1);

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
                    Node tmpNode;
                    Node current = GetNodeByIndex(index - 1);

                    if (index + countElements + 1 > Length)
                    {
                        current.Next = _tail.Next;
                        _tail = current;
                    }
                    else
                    {
                        tmpNode = GetNodeByIndex(index + countElements - 1);
                        current.Next = tmpNode.Next;
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
            Node current = _root;

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
            Node current = _root;

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
                Node current = _root;

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
                Node current = _root;
                Node prev = null;
                Node next;

                while (!(current is null))
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                _root = prev;
                _tail = current;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public int FindMax()
        {
            Node current = GetNodeByIndex(FindIndexMax());

            return current.Value;
        }

        public int FindMin()
        {
            Node current = GetNodeByIndex(FindIndexMin());

            return current.Value;
        }

        public int FindIndexMax()
        {
            if (Length > 0)
            {
                Node current = _root;
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
                Node current = _root;
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
                Node current = _root;

                while (current != null)
                {
                    Node minimum = current;
                    Node currentInner = current.Next;

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
            if (Length != 0)
            {
                Node current = _root;
                Node tmpNode = new Node(0);
                Node prev = tmpNode;

                while (current != null)
                {
                    if (prev.Value < current.Value)
                    {
                        prev = tmpNode;
                    }
                    while (prev.Next != null && prev.Next.Value > current.Value)
                    {
                        prev = prev.Next;
                    }

                    Node nextNode = current.Next;

                    current.Next = prev.Next;
                    prev.Next = current;
                    current = nextNode;
                }

                _root = tmpNode.Next; 
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()                     //stringBuilder + 1 return
        {
            if (Length != 0)
            {
                Node current = _root;
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

        public override bool Equals(object obj)                         //1 return
        {
            LinkedList list = (LinkedList)obj;

            if (Length != list.Length)
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

        private Node GetNodeByIndex(int index)
        {
            if (index >= 0 && index < Length)
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
    }
}
