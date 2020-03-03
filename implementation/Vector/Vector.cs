using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T>
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

        public T this[int index]
        {
            // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
            // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...

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

        private void ExtendData(int extraCapacity)
        {
            // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
            // The new capacity is equal to the existing one plus 'extraCapacity'.
            // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.

            T[] newData = new T[Capacity + extraCapacity];
            
            for (int i = 0; i < Count; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }

        
        public void Add(T element)
        {
            // This method adds a new element to the existing array.
            // If the internal array is out of capacity, its capacity is first extended to fit the new element.
            if (Count == Capacity)
                ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element; //add to end of array
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

        public int IndexOf(T element)
        {
            // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
            // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
            // If occurrence is not found, then the method returns –1.
            // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.

            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1; //not found
        }//returns zero based index of element in collection

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
            for(int i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            while(Count != 0)
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
            if(index < 0 || index > Count)
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
            for(int i = 0; i < Count; i++)
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
            if(maxValue == null)
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

                if((comparer.Compare(data[i], minValue) < 1))
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
            for (int i = Count-1; i >= 0; i--)
            {
                if (filterCriteria(data[i]))
                {
                    elementsRemoved++;
                    RemoveAt(i);
                }
            }
            return elementsRemoved;

        }
        public void Sort()
        {
            Array.Sort(data, 0, Count);
        }
        public void Sort(IComparer<T> comparer)
        {           
            Array.Sort(data, 0, Count, comparer);
        }
        
    }
}
