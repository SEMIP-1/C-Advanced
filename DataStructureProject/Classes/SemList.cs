namespace DataStructuresCollections
{
    public class SemList<T>
    {
        #region Propertits
        T[] Items;
        public int Count {get;set;}
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
                if(index<0 || index> Items.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return Items[index];
            }
            set
            {
                if(index<0 || index> Items.Length)
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
                    if(Convert.ToInt32(index) < 0 || Convert.ToInt32(index) > Items.Length)
                        continue;
                    
                    result.Add(Items[Convert.ToInt32(index)]);
                }
                return result;
                
            }
        }
        #endregion
    }
}

