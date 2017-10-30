namespace CarParkSimulator
{
    class Barrier
    {
        //Attributes 
        private bool lifted = false;

        // constructor 
        public Barrier()
        {
            lifted = false;
        }
        public bool isLifted()
        {
            return lifted;
        }
        public bool Lower() 
        {
            lifted = false;
            return lifted;   
        }
        public bool Raise()
        {
            lifted = true;
            return lifted;
        }
    }
}