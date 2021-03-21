using NUnit.Framework;

namespace List.Tests
{
    public class ArrayListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 777 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 777 })]
        [TestCase(new int[] { }, new int[] { 777 })]

        public void Add_WhenValuePassed_ShouldAddValueToEnd(int[] a, int[] b)
        {
            ArrayList actual = new ArrayList(a);
            ArrayList expected = new ArrayList(b);

            actual.Add(777);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 777, 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 777, 1 })]
        [TestCase(new int[] { }, new int[] { 777 })]

        public void AddFirst_WhenValuePassed_ShouldAddValueFirst(int[] a, int[] b)
        {
            ArrayList actual = new ArrayList(a);
            ArrayList expected = new ArrayList(b);

            actual.AddFirst(777);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 777, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 777 })]
        [TestCase(new int[] { 0, 12, 67, 38, 1 }, new int[] { 0, 777, 12, 67, 38, 1 })]

        public void AddByIndex_WhenIndexAndValuePassed_ShouldAddValueByIndex(int[] a, int[] b)
        {
            ArrayList actual = new ArrayList(a);
            ArrayList expected = new ArrayList(b);

            actual.AddByIndex(1, 777);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 0, 12, 67, 38, 1 }, new int[] { 0, 12, 67, 38 })]

        public void Remove_WhenNothingPassed_ShouldRemoveOneElementFromEnd(int[] a, int[] b)
        {
            ArrayList actual = new ArrayList(a);
            ArrayList expected = new ArrayList(b);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 12, 67, 38, 1 }, new int[] { 12, 67, 38, 1 })]
        [TestCase(new int[] { 1 }, new int[] { })]

        public void RemoveFirst_WhenNothingPassed_ShouldRemoveFirstOneElement(int[] a, int[] b)
        {
            ArrayList actual = new ArrayList(a);
            ArrayList expected = new ArrayList(b);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 6)]
        [TestCase(2, 7)]
        [TestCase(3, 8)]
        [TestCase(4, 9)]

        public void RemoveByIndex_WhenIndexPassed_ShouldRemoveByIndexOneElement(int mockNumber, int expectedMockNumber)
        {
            ArrayList actual = new ArrayList(GetMock(mockNumber));
            ArrayList expected = new ArrayList(GetMock(expectedMockNumber));

            actual.RemoveByIndex(2);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 10)]
        [TestCase(2, 11)]
        [TestCase(3, 12)]
        [TestCase(4, 11)]
        [TestCase(5, 11)]

        public void Remove_WhenCountElementsPassed_ShouldRemoveCountElement(int mockNumber, int expectedMockNumber)
        {
            ArrayList actual = new ArrayList(GetMock(mockNumber));
            ArrayList expected = new ArrayList(GetMock(expectedMockNumber));

            actual.Remove(5);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 13)]
        [TestCase(2, 11)]
        [TestCase(3, 14)]
        [TestCase(4, 11)]
        [TestCase(5, 11)]

        public void RemoveFirst_WhenCountElementsPassed_ShouldRemoveFirstCountElement(int mockNumber, int expectedMockNumber)
        {
            ArrayList actual = new ArrayList(GetMock(mockNumber));
            ArrayList expected = new ArrayList(GetMock(expectedMockNumber));

            actual.RemoveFirst(5);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 15)]
        [TestCase(2, 16)]
        [TestCase(3, 17)]

        public void RemoveByIndex_WhenIndexPassed_ShouldRemoveCountElementByIndex(int mockNumber, int expectedMockNumber)
        {
            ArrayList actual = new ArrayList(GetMock(mockNumber));
            ArrayList expected = new ArrayList(GetMock(expectedMockNumber));

            actual.RemoveByIndex(3, 4);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 0, 744)]
        [TestCase(2, 4, 650)]
        [TestCase(3, 4, 962)]
        [TestCase(5, 0, 513)]

        public void GetByIndex_WhenIndexPassed_ShouldShowValueByIndex(int mockNumber, int index, int expected)
        {
            ArrayList array = new ArrayList(GetMock(mockNumber));
            int actual = array[index];

            Assert.AreEqual(expected, actual);
        }


        [TestCase(11, 0, 777)]
        [TestCase(2, 4, 777)]
        [TestCase(3, 4, 777)]
        [TestCase(5, 0, 777)]

        public void SetByIndex_WhenIndexPassed_ShouldChangeValueByIndex(int mockNumber, int index, int expected)
        {
            ArrayList actual = new ArrayList(GetMock(mockNumber));
            actual[index] = 777;

            Assert.AreEqual(expected, actual[index]);
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
            }
            return result;
        }
    }
}