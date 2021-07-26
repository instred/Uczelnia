namespace Z3
{
    public interface IDataStrategy {
        void Connection();
        void GetData();
        void Processing();
        void Close();
    }

    public class DataHandler {
        private readonly IDataStrategy _strategy;

        public DataHandler(IDataStrategy strategy) {
            _strategy = strategy;
        }

        public void Execute() {
            _strategy.Connection();
            _strategy.GetData();
            _strategy.Processing();
            _strategy.Close();
        }
    }
}