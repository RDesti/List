using System;
using NUnit.Framework;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 777 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 777 })]
        [TestCase(new int[] { }, new int[] { 777 })]

        public void Add_WhenValuePassed_ShouldAddValueToEnd(int[] a, int[] b)
        {
            LinkedList actual = new LinkedList(a);
            LinkedList expected = new LinkedList(b);

            actual.Add(777);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 777, 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 777, 1 })]
        [TestCase(new int[] { }, new int[] { 777 })]

        public void AddFirst_WhenValuePassed_ShouldAddValueFirst(int[] a, int[] b)
        {
            LinkedList actual = new LinkedList(a);
            LinkedList expected = new LinkedList(b);

            actual.AddFirst(777);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 777, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 777 })]
        [TestCase(new int[] { 0, 12, 67, 38, 1 }, new int[] { 0, 777, 12, 67, 38, 1 })]

        public void AddByIndex_WhenIndexAndValuePassed_ShouldAddValueByIndex(int[] a, int[] b)
        {
            LinkedList actual = new LinkedList(a);
            LinkedList expected = new LinkedList(b);

            actual.AddByIndex(1, 777);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 4, 1)]

        public void AddByIndex_WhenIncorrectIndexPassed_ThenReturnIndexOutOfRange(int[] actualArray, int index, int value)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.AddByIndex(index, value);

            });
        }

        [TestCase(2, new int[] { 7, 7, 7 }, 21)]
        [TestCase(3, new int[] { 7, 7, 7 }, 22)]
        [TestCase(5, new int[] { 7, 7, 7 }, 23)]
        [TestCase(11, new int[] { 7, 7, 7 }, 20)]
        [TestCase(11, new int[] { }, 11)]

        public void AddList_WhenLinkedListPassed_ShouldAddListInEnd(int mockNumber1, int[] arraylist, int expectedMockNumber)
        {
            LinkedList list = new LinkedList(arraylist);
            LinkedList actual = new LinkedList(GetMock(mockNumber1));
            LinkedList expected = new LinkedList(GetMock(expectedMockNumber));

            actual.AddList(list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]

        public void AddList_WhenNullPassed_ThenReturnArgumentNullException(int[] actualArray)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.AddList(null);
            });
        }

        [TestCase(11, new int[] { 7, 7, 7 }, 20)]
        [TestCase(2, new int[] { 7, 7, 7 }, 24)]
        [TestCase(3, new int[] { 7, 7, 7 }, 25)]
        [TestCase(5, new int[] { 7, 7, 7 }, 26)]
        [TestCase(11, new int[] { }, 11)]

        public void AddListFirst_WhenLinkedListPassed_ShouldAddListAtFirst(int mockNumber1, int[] arraylist, int expectedMockNumber)
        {
            LinkedList list = new LinkedList(arraylist);
            LinkedList actual = new LinkedList(GetMock(mockNumber1));
            LinkedList expected = new LinkedList(GetMock(expectedMockNumber));

            actual.AddListFirst(list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]

        public void AddListFirst_WhenNullPassed_ThenReturnArgumentNullException(int[] actualArray)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.AddListFirst(null);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 7, 7, 7 }, new int[] { 1, 2, 3, 7, 7, 7 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 7, 7, 7 }, new int[] { 7, 7, 7, 1, 2, 3 })]
        [TestCase(new int[] { 1 }, 1, new int[] { 7, 7, 7 }, new int[] { 1, 7, 7, 7 })]
        [TestCase(new int[] { 0, 12, 67, 38, 1 }, 1, new int[] { 7, 7, 7 }, new int[] { 0, 7, 7, 7, 12, 67, 38, 1 })]

        public void AddListByIndex_WhenIndexAndLinkedListPassed_ShouldAddValueByIndex(int[] a, int index, int[] arraylist, int[] b)
        {
            LinkedList list = new LinkedList(arraylist);
            LinkedList actual = new LinkedList(a);
            LinkedList expected = new LinkedList(b);

            actual.AddListByIndex(list, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -1, new int[] { 13 })]
        [TestCase(2, -11, new int[] { 0 })]

        public void AddListByIndex_WhenInvalidIndexPassed_ShouldIndexOutOfRangeException(int mockNumber, int index, int[] value)
        {
            LinkedList list = new LinkedList(value);
            LinkedList actual = new LinkedList(GetMock(mockNumber));

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddListByIndex(list, index));
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 0, 12, 67, 38, 1 }, new int[] { 0, 12, 67, 38 })]
        [TestCase(new int[] { }, new int[] { })]

        public void Remove_WhenNothingPassed_ShouldRemoveOneElementFromEnd(int[] a, int[] b)
        {
            LinkedList actual = new LinkedList(a);
            LinkedList expected = new LinkedList(b);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 12, 67, 38, 1 }, new int[] { 12, 67, 38, 1 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]

        public void RemoveFirst_WhenNothingPassed_ShouldRemoveFirstOneElement(int[] a, int[] b)
        {
            LinkedList actual = new LinkedList(a);
            LinkedList expected = new LinkedList(b);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 6)]
        [TestCase(2, 7)]
        [TestCase(3, 8)]
        [TestCase(4, 9)]

        public void RemoveByIndex_WhenIndexPassed_ShouldRemoveByIndexOneElement(int mockNumber, int expectedMockNumber)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));
            LinkedList expected = new LinkedList(GetMock(expectedMockNumber));

            actual.RemoveByIndex(2);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]

        public void RemoveByIndex_WhenIncorrectIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.RemoveByIndex(index);
            });
        }

        [TestCase(1, 10)]
        [TestCase(2, 11)]
        [TestCase(3, 12)]
        [TestCase(4, 11)]
        [TestCase(5, 11)]
        [TestCase(11, 11)]

        public void Remove_WhenCountElementsPassed_ShouldRemoveCountElement(int mockNumber, int expectedMockNumber)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));
            LinkedList expected = new LinkedList(GetMock(expectedMockNumber));

            actual.Remove(5);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, -1)]

        public void Remove_WhennListIsEmptyAndElementsPassed_ThenArgumentException(int[] actualArray, int count)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.Remove(count);

            });
        }

        [TestCase(1, 13)]
        [TestCase(2, 11)]
        [TestCase(3, 14)]
        [TestCase(4, 11)]
        [TestCase(5, 11)]
        [TestCase(11, 11)]

        public void RemoveFirst_WhenCountElementsPassed_ShouldRemoveFirstCountElement(int mockNumber, int expectedMockNumber)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));
            LinkedList expected = new LinkedList(GetMock(expectedMockNumber));

            actual.RemoveFirst(5);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, -1)]

        public void RemoveFirst_WhennListIsEmptyElementsPassed_ThenArgumentException(int[] actualArray, int count)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.RemoveFirst(count);

            });
        }

        [TestCase(1, 15)]
        [TestCase(2, 16)]
        [TestCase(3, 17)]

        public void RemoveByIndex_WhenIndexPassed_ShouldRemoveCountElementByIndex(int mockNumber, int expectedMockNumber)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));
            LinkedList expected = new LinkedList(GetMock(expectedMockNumber));

            actual.RemoveByIndex(3, 4);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, 0)]
        [TestCase(new int[] { 1, 2, 3 }, -1, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 0, -1)]

        public void RemoveByIndex_WhenIndexOrcountIncorrectPassed_ThenReturnArgumentException(int[] actualArray, int index, int count)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.RemoveByIndex(index, count);
            });
        }

        [TestCase(1, 77, 6)]
        [TestCase(2, 639, 1)]
        [TestCase(9, 69, 1)]
        [TestCase(4, 70, -1)]
        [TestCase(5, 513, 0)]

        public void RemoveFirstByValue_WhenValuePassed_ShouldRemoveOneValueAndShowIndex(int mockNumber, int value, int expectedIndex)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actual = array.RemoveFirstByValue(value);

            Assert.AreEqual(expectedIndex, actual);
        }

        [TestCase(1, 77, 1)]
        [TestCase(2, 639, 2)]
        [TestCase(3, 331, 3)]
        [TestCase(4, 70, 0)]
        [TestCase(5, 0, 0)]

        public void RemoveAllByValue_WhenValuePassed_ShouldRemoveAllValueAndShowCount(int mockNumber, int value, int expected)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actual = array.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0, 744)]
        [TestCase(2, 4, 650)]
        [TestCase(3, 4, 331)]
        [TestCase(5, 0, 513)]

        public void GetByIndex_WhenIndexPassed_ShouldShowValueByIndex(int mockNumber, int index, int expected)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actual = array[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 4, 777)]
        [TestCase(3, 4, 777)]
        [TestCase(5, 0, 777)]

        public void SetByIndex_WhenIndexPassed_ShouldChangeValueByIndex(int mockNumber, int index, int expected)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));

            actual[index] = 777;

            Assert.AreEqual(expected, actual[index]);
        }

        [TestCase(11, 777, -1)]
        [TestCase(2, 639, 1)]
        [TestCase(3, 331, 2)]
        [TestCase(5, 777, -1)]

        public void GetFirstIndex_WhenValuePassed_ShouldFirstIndexByValue(int mockNumber, int value, int expectedIndex)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actualIndex = array.GetFirstIndex(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(11, 11)]
        [TestCase(2, 18)]
        [TestCase(4, 19)]
        [TestCase(5, 5)]

        public void Reverse_WhenArrayPassed_ShouldReversArray(int mockNumber, int expectedmockNumber)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));
            LinkedList expected = new LinkedList(GetMock(expectedmockNumber));

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void Reverse_WhenMethodCalled_ThenNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                LinkedList actual = null;

                actual.Reverse();
            });
        }

        [TestCase(4, 89)]
        [TestCase(1, 1000)]
        [TestCase(2, 936)]
        [TestCase(3, 962)]
        [TestCase(5, 513)]

        public void FindMax_WhenLinkedListPassed_ShouldMaxValue(int mockNumber, int expected)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actual = array.FindMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 69)]
        [TestCase(1, 77)]
        [TestCase(2, 554)]
        [TestCase(3, 331)]
        [TestCase(5, 513)]

        public void FindMin_WhenLinkedList_ShouldMinValue(int mockNumber, int expected)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actual = array.FindMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 0)]
        [TestCase(1, 3)]
        [TestCase(2, 0)]
        [TestCase(3, 3)]
        [TestCase(5, 0)]

        public void FindIndexMax_WhenLinkedList_ShouldIndexMaxValue(int mockNumber, int expected)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actual = array.FindIndexMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]

        public void FindIndexMax_WhenListIsEmptyPassed_ThenReturnArgumentNullException(int[] actualArray)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                LinkedList list = new LinkedList(actualArray);

                int actual = list.FindIndexMax();
            });
        }

        [TestCase(4, 1)]
        [TestCase(1, 6)]
        [TestCase(2, 2)]
        [TestCase(3, 2)]
        [TestCase(5, 0)]

        public void FindIndexMin_WhenLinkedList_ShouldIndexMinValue(int mockNumber, int expected)
        {
            LinkedList array = new LinkedList(GetMock(mockNumber));

            int actual = array.FindIndexMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]

        public void FindIndexMin_WhenListIsEmptyPassed_ThenReturnArgumentNullException(int[] actualArray)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                LinkedList list = new LinkedList(actualArray);

                int actual = list.FindIndexMin();
            });
        }

        [TestCase(4, new int[] { 69, 72, 89 })]
        [TestCase(1, new int[] { 77, 78, 121, 168, 295, 327, 377, 652, 744, 876, 934, 966, 984, 1000 })]
        [TestCase(2, new int[] { 554, 639, 639, 650, 936 })]
        [TestCase(3, new int[] { 331, 331, 331, 368, 392, 782, 802, 962 })]
        [TestCase(5, new int[] { 513 })]

        public void SelectSortAscending_WhenLinkedListPassed_ShouldSortAscending(int mockNumber, int[] expectedarray)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));
            LinkedList expected = new LinkedList(expectedarray);

            actual.SelectSortAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]

        public void SelectSortAscending_WhenListIsEmptyPassed_ThenReturnArgumentException(int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.SelectSortAscending();
            });
        }

        [TestCase(4, new int[] { 89, 72, 69 })]
        [TestCase(2, new int[] { 936, 650, 639, 639, 554 })]
        [TestCase(3, new int[] { 962, 802, 782, 392, 368, 331, 331, 331 })]
        [TestCase(5, new int[] { 513 })]

        public void InsertSortDescending_WhenLinkedListPassed_ShouldSortDescending(int mockNumber, int[] expectedarray)
        {
            LinkedList actual = new LinkedList(GetMock(mockNumber));
            LinkedList expected = new LinkedList(expectedarray);

            actual.InsertSortDescending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]

        public void InsertSortAscending_WhenListIsEmptyPassed_ThenReturnArgumentException(int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);

                actual.InsertSortDescending();
            });
        }

        private static int[] GetMock(int number)
        {
            int[] result = new int[0];

            switch (number)
            {
                case 1:
                    result = new int[] { 744, 377, 984, 1000, 78, 876, 77, 168, 652, 121, 327, 934, 295, 966 };
                    break;
                case 2:
                    result = new int[] { 936, 639, 554, 639, 650 };
                    break;
                case 3:
                    result = new int[] { 368, 802, 331, 962, 331, 782, 392, 331 };
                    break;
                case 4:
                    result = new int[] { 89, 69, 72 };
                    break;
                case 5:
                    result = new int[] { 513 };
                    break;

                case 6:
                    result = new int[] { 744, 377, 1000, 78, 876, 77, 168, 652, 121, 327, 934, 295, 966 };
                    break;
                case 7:
                    result = new int[] { 936, 639, 639, 650 };
                    break;
                case 8:
                    result = new int[] { 368, 802, 962, 331, 782, 392, 331 };
                    break;
                case 9:
                    result = new int[] { 89, 69 };
                    break;
                case 10:
                    result = new int[] { 744, 377, 984, 1000, 78, 876, 77, 168, 652 };
                    break;
                case 11:
                    result = new int[] { };
                    break;
                case 12:
                    result = new int[] { 368, 802, 331 };
                    break;
                case 13:
                    result = new int[] { 876, 77, 168, 652, 121, 327, 934, 295, 966 };
                    break;
                case 14:
                    result = new int[] { 782, 392, 331 };
                    break;
                case 15:
                    result = new int[] { 744, 377, 984, 168, 652, 121, 327, 934, 295, 966 };
                    break;
                case 16:
                    result = new int[] { 936, 639, 554 };
                    break;
                case 17:
                    result = new int[] { 368, 802, 331, 331 };
                    break;
                case 18:
                    result = new int[] { 650, 639, 554, 639, 936 };
                    break;
                case 19:
                    result = new int[] { 72, 69, 89 };
                    break;
                case 20:
                    result = new int[] { 7, 7, 7 };
                    break;
                case 21:
                    result = new int[] { 936, 639, 554, 639, 650, 7, 7, 7 };
                    break;
                case 22:
                    result = new int[] { 368, 802, 331, 962, 331, 782, 392, 331, 7, 7, 7 };
                    break;
                case 23:
                    result = new int[] { 513, 7, 7, 7 };
                    break;
                case 24:
                    result = new int[] { 7, 7, 7, 936, 639, 554, 639, 650 };
                    break;
                case 25:
                    result = new int[] { 7, 7, 7, 368, 802, 331, 962, 331, 782, 392, 331 };
                    break;
                case 26:
                    result = new int[] { 7, 7, 7, 513 };
                    break;
            }

            return result;
        }
    }
}
