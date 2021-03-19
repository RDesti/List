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
        public static int[] GetMock(int number)
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
            }
            return result;
        }
    }
}