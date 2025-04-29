namespace DataStructuresCollections
{
    public class SemList
    {
        #region Propertits
        T[] Item;
        public int Count {get;set:}
        int CurrentIndex;
        const int Capacity =4
        #endregion

        #region Constructors
        public semlist()
        {
            Item= new T[Capacity];
            Count = 0;
            CurrentIndex=0;
        }
        public semlist(int Capacity)
        {
            this.Capacity=Capacity;
            this.Item= new T[Capacity];
            Count = 0;
            CurrentIndex=0;
        }
        #endregion
        
        #region Indexers
        public T this[int index]
        {
            set
            {
                Item[index]=value
            }
            get
            {
                if(index>0 || index>Items.Length)
                {
                    throw new IndexOutOfRangeexception();
                }
                return Items[index]
            }
        }
        public string this[string ListName]{}
        #endregion
    }
}

