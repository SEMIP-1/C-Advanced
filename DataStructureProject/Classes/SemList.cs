using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace DataStructuresCollections
{
    public class Person : IComparable<Person>
    {
        public string ID { get; set; }
        public int Age { get; set; }
        public int CompareTo(Person? other)
        {
            if (other == null) return 1;
            return this.ID.CompareTo(other.ID);
        }
    }
    public class SemList<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        #region Propertits
        T[] Items;
        public int Count;
        int CurrentIndex;
        public int Capacity = 4;

        int ICollection<T>.Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();
        #endregion

        #region Constructors
        public SemList()
        {
            Items = new T[Capacity];
            Count = 0;
            CurrentIndex = 0;
        }
        public SemList(int Capacity)
        {
            this.Capacity = Capacity;
            this.Items = new T[Capacity];
            Count = 0;
            CurrentIndex = 0;
        }
        #endregion

        #region Indexers
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > CurrentIndex)
                {
                    throw new IndexOutOfRangeException();
                }
                return Items[index];
            }
            set
            {
                if (index < 0 || index > CurrentIndex)
                {
                    throw new IndexOutOfRangeException();
                }
                Items[index] = value;
            }

        }
        public List<T> this[string indexers]
        {
            get
            {
                if (string.IsNullOrEmpty(indexers))
                    throw new ArgumentNullException();

                string[] indexersArray = indexers.Split(',');
                List<T> result = new List<T>();
                foreach (var index in indexersArray)
                {
                    if (Convert.ToInt32(index) < 0 || Convert.ToInt32(index) > CurrentIndex)
                        continue;

                    result.Add(Items[Convert.ToInt32(index)]);
                }
                return result;

            }
        }
        #endregion

        #region Methods
        #region Helping And Modifing
        void CopyArray(T[] nArrayOld, T[] nArrayNew, int Size)
        {
            for (int i = 0; i < Size; i++)
            {
                nArrayNew[i] = nArrayOld[i];
            }
        }
        void Resize(int nSize)
        {
            T[] newItems = new T[nSize];
            CopyArray(this.Items, newItems, Count);
            this.Items = newItems;
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            CopyArray(this.Items, array, Count);
            return array;
        }
        public void Reverse()
        {
            T[] NewArray = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                NewArray[i] = this.Items[Count - i - 1];
            }
            this.Items = NewArray;
            //Or use Items.Reverse();
        }
        public void Sort()
        {
            Array.Sort(this.Items);
        }
        void Shiftleft(int UserIndex, int UserCount)
        {
            for (int i = UserIndex + UserCount; i < Items.Length; i++)
            {
                this.Items[UserIndex] = this.Items[i];
                UserIndex++;
            }
            for (int i = Items.Length - 1; i >= Items.Length - UserCount; i--)
            {
                this.Items[i] = default(T);
                CurrentIndex--;
                Count--;
            }
        }
        public void ShiftRight(int UserIndex, int UserCount)
        {
            for (int i = Items.Length - 1; i > UserIndex; i--)
            {
                this.Items[i] = this.Items[i - UserCount];
            }
            for (int i = UserIndex; i < UserIndex + UserCount; i++)
            {
                this.Items[i] = default(T);
                CurrentIndex++;
                Count++;
            }
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i <= CurrentIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(this.Items[i], item))
                    return i;
            }
            return -1;
        }
        public void Print()
        {
            for (int i = 0; i < this.Items.Length; i++)
            {
                Console.WriteLine(this.Items[i]);
            }
        }
        #endregion
        #region Adding Items
        public void Add(T item)
        {
            if (CurrentIndex >= this.Capacity)
            {
                Capacity = Capacity + 4;
                Resize(Capacity);
            }
            Items[CurrentIndex] = item;
            CurrentIndex++;
            Count++;
        }
        public void AddRange(T[] UserItem)
        {
            if ((UserItem.Length + CurrentIndex) > this.Capacity)
            {
                while (this.Capacity < (UserItem.Length + CurrentIndex))
                {
                    this.Capacity += 4;
                }
                Resize(this.Capacity);
            }
            for (int i = 0; i < (UserItem.Length); i++)
            {
                Add(UserItem[i]);
            }
        }
        public void Insert(int UserIndex, T item)
        {
            if (UserIndex > this.CurrentIndex || UserIndex < 0)
                throw new IndexOutOfRangeException();
            if (CurrentIndex >= this.Capacity)
            {
                Capacity = Capacity + 4;
                Resize(Capacity);
            }
            ShiftRight(UserIndex, 1);
            this.Items[UserIndex] = item;
        }
        public void InsertRange(int UserIndex, T[] item)
        {
            if (UserIndex > this.CurrentIndex || UserIndex < 0)
                throw new IndexOutOfRangeException();
            if (CurrentIndex + item.Length >= this.Capacity)
            {
                Capacity = CurrentIndex + item.Length;
                Resize(Capacity);
            }
            ShiftRight(UserIndex, item.Length);
            for (int i = 0; i < item.Length; i++)
            {
                this.Items[UserIndex + i] = item[i];
            }
        }
        #endregion
        #region Removeing Items
        public void RemoveAt(int index)
        {
            if (index < 0 || index > CurrentIndex)
            {
                throw new IndexOutOfRangeException();
            }
            Shiftleft(index, 1);
            CurrentIndex--;
            Count--;
        }
        public bool Remove(T item)
        {
            //RemoveAT(IndexOf(item));
            int removedindex = IndexOf(item);
            if (removedindex < 0 || removedindex > CurrentIndex)
            {
                throw new IndexOutOfRangeException();
            }
            Shiftleft(removedindex, 1);
            return true;
        }
        public void RemoveRange(int UserIndex, int UserCount)
        {
            if (UserIndex > this.CurrentIndex || UserIndex < 0 || UserCount < 0 || UserIndex + UserCount > this.Items.Length)
                throw new IndexOutOfRangeException();
            Shiftleft(UserIndex, UserCount);

            if (Items.Length > Count)
                Resize(Count);
        }
        public void Clear()
        {
            this.Capacity = 4;
            this.CurrentIndex = 0;
            this.Count = 0;
            T[] NewArray = new T[Capacity];
        }
        public void RemoveAll()
        {
            for (int i = 0; i < this.Items.Length; i++)
            {
                this.Items[i] = default(T);
            }

        }
        #endregion
        #region IEnumerator Ineterface
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in Items)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region ICollection Ineterface
        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.Items, 0, array, arrayIndex, this.Count);
        }
        #endregion

        #endregion

    }
}

