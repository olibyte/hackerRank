using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T> where T : IComparable<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }
        public bool Remove(T element) //removes
        {
            //if data contains element
            if (Contains(element))
            {
                RemoveAt(IndexOf(element));
                return true;
            }
            return false;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }
        public void Insert(int index, T element) //insert a new element at the specified index
        {
            if (index > Count || index < 0) throw new IndexOutOfRangeException();
            {
                ExtendData(DEFAULT_CAPACITY);
            }
            if (Count == Capacity)
                ExtendData(DEFAULT_CAPACITY);
            if (index == Count)
            {
                data[Count] = element;

            }
            for (int i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            while (Count != 0)
            {
                Count--;
            }
        }

        public bool Contains(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element))
                    return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            for (int j = index; j < Count - 1; j++)
            {
                data[j] = data[j + 1];
            }
            data[Count - 1] = default(T);
            Count--;
        }

        public override string ToString()
        {
            string stringData = "";
            for (int i = 0; i < Count; i++)
            {
                stringData += string.Format($", {data[i]}");
            }
            return $"[ {stringData} ]";
        }
        public T Find(Func<T, bool> searchCriteria)
        {
            if (searchCriteria == null) throw new ArgumentNullException("Search criteria is null.");
            for (int i = 0; i < Count; i++)
            {
                if (searchCriteria(data[i])) return data[i];
            }
            return default(T);
        }
        public T Max()
        {
            Comparer<T> comparer = Comparer<T>.Default; //default comparer from IComparer

            T maxValue = data[0];
            if (maxValue == null)
            {
                return default(T);
            }
            for (int i = 0; i < Count; i++)
            {

                if (comparer.Compare(data[i], maxValue) == 1)
                {
                    maxValue = data[i];
                }
            }
            return maxValue;
        }

        public T Min()
        {
            Comparer<T> comparer = Comparer<T>.Default; //default comparer from IComparer

            T minValue = data[0];
            if (minValue == null)
            {
                return default(T);
            }
            for (int i = 0; i < Count; i++)
            {

                if ((comparer.Compare(data[i], minValue) < 1))
                {
                    minValue = data[i];
                }
            }
            return minValue;
        }

        public Vector<T> FindAll(Func<T, bool> searchCriteria)
        {

            if (searchCriteria == null) throw new ArgumentNullException("Search criteria is null.");
            Vector<T> results = new Vector<T>();
            for (int i = 0; i < Count; i++)
            {
                if (searchCriteria(data[i]))
                    results.Add(data[i]);
            }
            return results;
        }

        public int RemoveAll(Func<T, bool> filterCriteria)
        {
            if (filterCriteria == null) throw new ArgumentNullException();

            int elementsRemoved = 0;
            for (int i = Count - 1; i >= 0; i--)
            {
                if (filterCriteria(data[i]))
                {
                    elementsRemoved++;
                    RemoveAt(i);
                }
            }
            return elementsRemoved;

        }

        public ISorter Sorter { set; get; } = new DefaultSorter();

        internal class DefaultSorter : ISorter
        {
            public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
            {
                if (comparer == null) comparer = Comparer<K>.Default;
                Array.Sort(sequence, comparer);
            }
        }

        public void Sort()
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            Sorter.Sort(data, null);
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            if (comparer == null) Sorter.Sort(data, null);
            else Sorter.Sort(data, comparer);
        }

        public int BinarySearch_Iterative(T element)
        {
            int bottom = 0;
            int top = Count - 1;
            int middle = (bottom + top) / 2;
            while (top >= bottom)
            {
                if (data[middle].CompareTo(element) == 0)
                {
                    return IndexOf(element);
                }
                else if (data[middle].CompareTo(element) > 0)
                {
                    top = middle - 1;
                }
                else
                {
                    bottom = middle + 1;
                }
                middle = (bottom + top) / 2;
            }
            return -1;
        }
        public int BinarySearch_Iterative(T element, IComparer<T> comparer)
        {
            int bottom = 0;
            int top = Count - 1;
            int middle = (bottom + top) / 2;
            while (top >= bottom)
            {
                if (comparer.Compare(data[middle], element) == 0)
                {
                    return IndexOf(element);
                }
                else if (comparer.Compare(data[middle], element) > 0)
                {
                    top = middle - 1;
                }
                else
                {
                    bottom = middle + 1;
                }
                middle = (bottom + top) / 2;
            }
            return -1;

        }
        public int BinarySearch(T element, int left, int right, IComparer<T> comparer)
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                int result = comparer.Compare(element, data[mid]);
                if (result == 0)
                {
                    return mid;
                }
                else if (result > 0)
                {
                    return BinarySearch(element, mid + 1, right, comparer);
                }
                return BinarySearch(element, left, mid - 1, comparer);
            }
            return -1;
        }
        public int BinarySearch(T element)
        {
            return BinarySearch(element, 0, Count, null);
        }
        public int BinarySearch(T element, IComparer<T> comparer)
        {
            return BinarySearch(element, 0, Count, comparer);
        }
                // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.

        public IEnumerator<T> GetEnumerator()
        {
            // You should replace this plug by your code.
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}