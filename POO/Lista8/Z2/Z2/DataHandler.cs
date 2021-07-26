namespace Z2
{
    public abstract class DataHandler
    {
        protected abstract void Connection();
        protected abstract void GetData();
        protected abstract void Processing();
        protected abstract void Close();

        public void Execute() {
            Connection();
            GetData();
            Processing();
            Close();
        }
    }
}