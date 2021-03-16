﻿using System;

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
