using Xunit;
using OrderSearchLibrary;

namespace OrderSearchLibrary.Tests
{
    public class OrderSearchTests
    {
        private readonly OrderSearch _searcher = new OrderSearch();

        // --- BINARY SEARCH TESTS (All-Paths & MC/DC) ---
        // Path 1: Array empty or key not found (bottom > top triggers immediately or after loop)
        [Fact]
        public void BinarySearch_KeyNotFound_ReturnsMinusOne()
        {
            int[] array = { 1, 2, 3 };
            int result = _searcher.BinarySearch(5, array);
            Assert.Equal(-1, result);
        }

        // Path 2: Key found at exactly the mid point
        [Fact]
        public void BinarySearch_KeyFoundAtMid_ReturnsIndex()
        {
            int[] array = { 10, 20, 30 };
            int result = _searcher.BinarySearch(20, array);
            Assert.Equal(1, result); // Index 1
        }

        // Path 3: Key is smaller than mid (goes left, top = mid - 1)
        [Fact]
        public void BinarySearch_KeySmallerThanMid_ReturnsIndex()
        {
            int[] array = { 10, 20, 30, 40, 50 };
            int result = _searcher.BinarySearch(10, array);
            Assert.Equal(0, result);
        }

        // Path 4: Key is larger than mid (goes right, bottom = mid + 1)
        [Fact]
        public void BinarySearch_KeyLargerThanMid_ReturnsIndex()
        {
            int[] array = { 10, 20, 30, 40, 50 };
            int result = _searcher.BinarySearch(50, array);
            Assert.Equal(4, result);
        }

        // MC/DC for: (bottom <= top && found == false)
        // True/True evaluated in the loops above.
        // False/True (bottom > top, found == false) -> Handled by KeyNotFound test.
        // True/False (bottom <= top, found == true) -> Handled by KeyFound tests (returns instantly).
    }
}