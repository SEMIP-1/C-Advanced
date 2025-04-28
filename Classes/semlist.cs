namespace DataStructureProject
{
    public class semlist<T>
    {
        T[] Item;
        public int Count {get;set:}
        int CurrentIndex;
        const int Capacity =4;


        public semlist()
        {
            
        }
        public semlist(int Capacity)
        {
            this.Capacity=Capacity;
            T[] nNewArray= new t [Capacity];
        }

        
    }
}