using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class ArrayList : IEnumerable<int>, IComparable
    {
        private const int DefaultSize = 4;
        private const double Increment = 1.33;
        private int _currentCount;
        private int[] _array;

        private int DefaultNewSize => (int)(_array.Length * Increment);
        public int Count => _currentCount;
        public int Capacity => _array.Length;

        public ArrayList()
        {
            _array = new int[DefaultSize];
        }

        public ArrayList(int capacity)
        {
            _array = new int[capacity];
        }

        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * Increment)];
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _currentCount = array.Length;
        }

        public void Add(int element)
        {
            if (Count == Capacity)
            {
                Resize(DefaultNewSize);
            }

            _array[_currentCount++] = element;
        }

        public void RemoveLastItem()
        {
            --_currentCount;
        }

        public void RemoveLastNItems(int n)
        {
            for (int i = 0; i < n; i++)
            {
                --_currentCount;
            }
        }

        public void RemoveFirstItem()
        {
            for (int i = 0; i < Count; i++)
            {
                _array[i] = _array[i + 1];
            }

            --_currentCount;
        }

        public void RemoveFirstNItems(int n)
        {
            while (n != 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    _array[i] = _array[i + 1];
                }

                --_currentCount;
                --n;
            }
        }

        public void AddByIndex(int element, int index)
        {
            if (Count == Capacity)
            {
                Resize(DefaultNewSize);
            }

            for (int i = Count-1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[index] = element;
            ++_currentCount;
        }

        public void Add(int[] array)
        {
            var newSize = Count + array.Length;
            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = Count, j = 0; i < newSize; i++, j++)
            {
                _array[i] = array[j];
            }

            _currentCount = newSize;
        }

        public void AddFront(int[] array)
        {
            var newSize = Count + array.Length;
            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                _array[i+array.Length] = _array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _currentCount = newSize;
        }

        public void AddFront(int element)
        {
            if (Count == Capacity)
            {
                Resize(DefaultNewSize);
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[0] = element;
            ++_currentCount;
        }

        public int MaxValueIndex()
        {
            int maxI = 0;

            for (int i = 1; i < Count; i++)
            {
                if (_array[i].CompareTo(_array[maxI]) == 1)
                {
                    maxI = i;
                }
            }

            return maxI;
        }

        public int MinValueIndex()
        {
            int minI = 0;

            for (int i = 1; i < Count; i++)
            {
                if (_array[i].CompareTo(_array[minI]) == -1)
                {
                    minI = i;
                }
            }

            return minI;
        }

        public int MaxValue()
        {
            var maxValue = _array[MaxValueIndex()];

            return maxValue;
        }

        public int MinValue()
        {
            var minValue = _array[MinValueIndex()];

            return minValue;
        }

        private void Resize(int NewSize)
        {
            int[] arrayNew = new int[NewSize];
            for (int i = 0; i < _array.Length; i++)
            {
                arrayNew[i] = _array[i];
            }

            _array = arrayNew;
        }

        public int ReturnLength()
        {
            return Count;
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                Swap(ref _array[i], ref _array[Count - i - 1]);
            }
        }

        public void SortAscending()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == -1)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public void SortDescending()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == 1)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
