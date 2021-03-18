using NUnit.Framework;

namespace List.Tests
{
    public class ArrayListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 4 })]
        [TestCase(new int[] { }, new int[] { 4 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]

        public void Test1(int[] a, int[] b)
        {
            ArrayList actual = new ArrayList(a);
            ArrayList expected = new ArrayList(b);
            actual.Add(4);

            Assert.AreEqual(expected, actual); 
        }
    }
}