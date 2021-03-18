using System;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public void Add(int value)
        {
            Resize();
            _array[Length] = value;
            ++Length;
        }
        public void AddInFront(int value)
        {
            ++Length;
            Resize();
            MoveRightToIndex(0, 1);
            _array[0] = value;
        }
        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Sorry, but you are accessing a non-existent index");
            }
            ++Length;
            MoveRightToIndex(index, 1);
            Resize();
            _array[index] = value;
        }
        public void Remove()
        {
            --Length;
            Resize();
        }
        public void RemoveInFront()
        {
            --Length;
            MoveLeftToIndex(0, 1);
            Resize();
        }
        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Sorry, but you are accessing a non-existent index");
            }
            --Length;
            MoveLeftToIndex(index, 1);
            Resize();
        }
        public void Remove(int countElements)
        {
            Length -= countElements;
            Resize();
        }
        public void RemoveInFront(int countElements)
        {
            Length -= countElements;
            MoveLeftToIndex(0, countElements);
            Resize();
        }
        public void RemoveByIndex(int index, int countElements)
        {
            Length -= countElements;
            MoveLeftToIndex(index, countElements);
            Resize();
        }
        public void ReturnCurrentLength(int Length)
        {
            int currentListLength = _array.Length;
        }
        public void GetIndexAccess(int index)
        {
            int valueByIndex = _array[index];
        }










        private void Resize()
        {
            int newLength = (int)(Length * 1.33 + 1);
            int[] tmpArray = new int[newLength];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }
        private void MoveRightToIndex(int index, int count)
        {
            for (int i = Length-1; i >= index; i--)
            {
                _array[i + count] = _array[i];
            }
        }
        private void MoveLeftToIndex(int index, int count)
        {
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + count];
            }
        }
    }
}
