using System;

namespace OrderSearchLibrary
{
    public class OrderSearch
    {
        // 1. ORIGINAL BINARY SEARCH
        public int BinarySearch(int key, int[] elemArray)
        {
            int bottom = 0;
            int top = elemArray.Length - 1;
            int mid;
            int index = -1;
            Boolean found = false;

            while (bottom <= top && found == false)
            {
                mid = (top + bottom) / 2;
                if (elemArray[mid] == key)
                {
                    index = mid;
                    found = true;
                    return index;
                }
                else
                {
                    if (elemArray[mid] < key)
                        bottom = mid + 1;
                    else
                        top = mid - 1;
                }
            }
            return index;
        }

        // 2. ADDED ALGORITHM: LINEAR SEARCH
        public int LinearSearch(int key, int[] elemArray)
        {
            for (int i = 0; i < elemArray.Length; i++)
            {
                if (elemArray[i] == key)
                    return i;
            }
            return -1;
        }

        // 3. ADDED ALGORITHM: JUMP SEARCH
        public int JumpSearch(int key, int[] elemArray)
        {
            int n = elemArray.Length;
            int step = (int)Math.Floor(Math.Sqrt(n));
            int prev = 0;

            while (elemArray[Math.Min(step, n) - 1] < key)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            while (elemArray[prev] < key)
            {
                prev++;
                if (prev == Math.Min(step, n))
                    return -1;
            }

            if (elemArray[prev] == key)
                return prev;

            return -1;
        }
    }
}