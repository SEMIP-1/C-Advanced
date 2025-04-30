using System.Runtime.CompilerServices;

namespace DataStructuresCollections
{
    public class SemList<T> where T : class
    {
        #region Propertits
        T[] Items;
        public int Count;
        int CurrentIndex;
        public int Capacity =4;
        #endregion

        #region Constructors
        public SemList()
        {
            Items= new T[Capacity];
            Count = 0;
            CurrentIndex=0;
        }
        public SemList(int Capacity)
        {
            this.Capacity=Capacity;
            this.Items= new T[Capacity];
            Count = 0;
            CurrentIndex=0;
        }
        #endregion
        
        #region Indexers
        public T this[int index]
        {
            get
            {
                if(index<0 || index> CurrentIndex)
                {
                    throw new IndexOutOfRangeException();
                }
                return Items[index];
            }
            set
            {
                if(index<0 || index> CurrentIndex)
                {
                    throw new IndexOutOfRangeException();
                }
                Items[index]=value;
            }
            
        }
        public List<T> this[string indexers]
        {
            get
            {
                if(string.IsNullOrEmpty(indexers))
                    throw new ArgumentNullException();
                
                string[] indexersArray = indexers.Split(',');
                List<T> result = new List<T>();
                foreach (var index in indexersArray)
                {
                    if(Convert.ToInt32(index) < 0 || Convert.ToInt32(index) > CurrentIndex)
                        continue;
                    
                    result.Add(Items[Convert.ToInt32(index)]);
                }
                return result;
                
            }
        }
        #endregion

        #region Methods
        void CopyArray(T[] nArrayOld,T[] nArrayNew,int Size)
        {
            for (int i = 0; i < Size; i++)
            {
                nArrayNew[i] = nArrayOld[i];
            }
        }        
        void Resize(int nSize)
        {
            T[] newItems = new T[nSize];
            CopyArray(this.Items, newItems,this.Items.Length);
            this.Items= newItems;
        }
        public void Add(T item)
        {
            if(CurrentIndex >= this.Capacity)
            {
                Capacity=Capacity*2;
                Resize(Capacity);
            }
            Items[CurrentIndex] = item;
            CurrentIndex++;
            Count++;
        }
        void Shiftleft(int index)
        {
            for(int i=index;i<CurrentIndex;i++)
           {
                if(this.Items[i]==null)
                    break;
                this.Items[index]=this.Items[index+1];
           }
        }
        public void RemoveAT(int index)
        {
            if(index<0 || index> CurrentIndex)
            {
                throw new IndexOutOfRangeException();
            }
            Shiftleft(index);
           CurrentIndex--;
           Count--;
        }
        public int IndexOf(T item)
        {
            for(int i =0; i<=CurrentIndex;i++)
            {
                if(EqualityComparer<T>.Default.Equals(this.Items[i],item))
                    return i;
            } 
            return -1;
        }
        public void Remove(T item)
        {
            //RemoveAT(IndexOf(item));
            int removedindex =IndexOf(item);
            if(removedindex<0 || removedindex> CurrentIndex)
            {
                throw new IndexOutOfRangeException();
            }
            Shiftleft(removedindex);
            CurrentIndex--;
            Count--;
        }
        #endregion
    
    }
}

