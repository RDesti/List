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
        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }
        public ArrayList(int[] initialArray)
        {
            Length = 0;
            _array = new int[(int)(Length * 1.33 + 1)];
            for (int i = 0; i < initialArray.Length; i++)
            {
                Add(initialArray[i]);
            }
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
            Resize();
            MoveRightToIndex(index, 1);
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
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Sorry, but you are accessing a non-existent index");
            }
            Length -= countElements;
            MoveLeftToIndex(index, countElements);
            Resize();
        }
        public void ReturnCurrentLength(int Length)
        {
            int currentListLength = _array.Length;
        }
        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }
        public void GetFirstIndex(int value)
        {
            int firstIndex = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    firstIndex = i;
                }
            }
        }
        public void Change(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Sorry, but you are accessing a non-existent index");
            }
            _array[index] = value;
        }
        public void GetReverst(ref int[] _array)
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int revers = _array[i];
                _array[i] = _array[Length - i - 1];
                _array[Length - i - 1] = revers;
            }
        }
        public void FindMax(int[] _array)
        {
            int max = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (max < _array[i])
                {
                    max = _array[i];
                }
            }
        }
        public void FindMin(int[] _array)
        {
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                    if (min > _array[i])
                    {
                        min = _array[i];
                    }
            }
        }
        public void FindIndexMaxElement(int[] _array)
        {
            int max = _array[0];
            int maxIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                if (max < _array[i])
                {
                    max = _array[i];
                    maxIndex = i;
                }
            }
        }
        public void FindIndexMinElement(int[] _array)
        {
            int min = _array[0];
            int minIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                    minIndex = i;
                }
            }
        }
        public void SortAscending(int[] _array)
        {

        }
        public void SortDescending(int[] _array)
        {

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
              for (int i = Length - 1; i >= index; i--)
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
        public override string ToString()
        {
            string s = string.Empty;
            for(int i = 0; i < Length; i++)
            {
                s += _array[i];
            }
            return s;
        }
        public override bool Equals(object obj)
        {
            //if (obj is ArrayList)
            //{
                ArrayList arrList = (ArrayList)obj;
                if(this.Length != arrList.Length)
                {
                    return false;
                }
                for(int i = 0; i < Length; i++)
                {
                    if(this._array[i] != arrList._array[i])
                    {
                        return false;
                    }
                }
                return true;
            //}
            //else
            //{
            //    throw new Exception("");
            //}
        }
    } 
}
