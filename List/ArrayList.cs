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
            if(Length == _array.Length)
            {
                UpSize();
            }
            _array[Length] = value;
            Length++;
        }
        public void AddToBeginning(int value)
        {
            if(Length == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length + 1];
            for(int i = 1; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i - 1];
            }
            tmpArray[0] = value;
            _array = tmpArray;
            Length++;
        }
        public void AddByIndex(int index, int value)
        {
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
            for(i = a; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i - 1];
            }
            tmpArray[index] = value;
            _array = tmpArray;
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
