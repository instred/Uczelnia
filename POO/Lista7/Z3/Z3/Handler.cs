namespace z3
{
    internal abstract class Handler
    {
        private Handler _nextHandler;

        protected abstract bool Request(string content);

        public void HandlerAttach( Handler handler )
        {
            if (_nextHandler != null)
                _nextHandler.HandlerAttach(handler);
            else
                _nextHandler = handler;
        }

        public void ChainOfResponsibility(string content)
        {
            var current = this;
            while (current != null && !current.Request(content))
            {
                current = current._nextHandler;
            }

            Handler handler = new Archiwum();
            handler.Request(content);
        }
    }
}