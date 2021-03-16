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

        public void AddElement(int value)
        {
            if(Length == _array.Length)
            {
                UpSize();
            }
            _array[Length] = value;
            ++Length;
        }
        public void AddElementToBeginning(int value)
        {
            if(Length == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length + 1];
            for(int i = 1; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i - 1];
            }
            tmpArray[0] = value;
            _array = tmpArray;
            ++Length;
        }
        public void AddElementByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Sorry, but you are accessing a non-existent index");
            }
            if(Length == _array.Length)
            {
                UpSize();
            }
            int i;
            int[] tmpArray = new int[_array.Length + 1];
            for(i = 0; i < index; i++)
            {
                tmpArray[i] = _array[i];
            }
            int a = index + 1;
            for(i = a; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i - 1];
            }
            tmpArray[index] = value;
            _array = tmpArray;
            ++Length;
        }
        public void RemoveElement(int value)
        {
            int[] tmpArray = new int[_array.Length - 1];
            for(int i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
            --Length;
        }
        public void RemoveElementToBeginning(int value)
        {
            int[] tmpArray = new int[_array.Length - 1];
            for(int i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i + 1];
            }
            _array = tmpArray;
            --Length;
        }
        public void RemoveElementByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Sorry, but you are accessing a non-existent index");
            }
            int[] tmpArray = new int[_array.Length - 1];
            int i;
            for(i = 0; i < index; i++)
            {
                tmpArray[i] = _array[i];
            }
            for(i = index; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i + 1];
            }
            _array = tmpArray;
            --Length;
        }

        private void UpSize()
        {
             int newLength = (int)(_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];
            for(int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }
    }
}
