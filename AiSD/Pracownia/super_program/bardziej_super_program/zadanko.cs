using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace zadanie1._2._2
{
        class BinaryTreeNode<T> : IEnumerable<T>
    {
        public BinaryTreeNode<T> Left { get; init; }
        public BinaryTreeNode<T> Right { get; init; }
        public T Value { get; init; }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumeratorBFS();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumeratorBFS()
        {
            return new EnumeratorBFS(this);
        }
        public IEnumerator<T> GetEnumeratorDFS()
        {
            return new EnumeratorDFS(this);
        }
        public IEnumerator<T> GetEnumeratorBFSyield()
        {
            Queue < BinaryTreeNode < T >> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this);
            while(queue.Any())
            {
                BinaryTreeNode < T > curr = queue.Dequeue();
                if (curr.Left != null)
                    queue.Enqueue(curr.Left);
                if (curr.Right != null)
                    queue.Enqueue(curr.Right);
                yield return curr.Value;
            }

        }
        public IEnumerator<T> GetEnumeratorDFSyield()
        {
            yield return Value;

            if (Left != null)
                foreach (var elem in Left)
                    yield return elem;
            if (Right != null)
                foreach (var elem in Right)
                    yield return elem;
        }
        
        private class EnumeratorBFS : IEnumerator<T>
        {
            private Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            private BinaryTreeNode<T> root;
            private BinaryTreeNode<T> curr;

            public EnumeratorBFS(BinaryTreeNode<T> tree)
            {
                root = tree;
                Reset();    
            }

            public T Current
            {
                get
                {
                    if (curr != null)
                        return curr.Value;
                    throw new ArgumentException("Empty");
                }
            }

            object IEnumerator.Current => Current;


            public void Dispose() { }

            public bool MoveNext()
            {
                if(queue.Count > 0)
                {
                    curr = queue.Dequeue();
                    if (curr.Left != null) queue.Enqueue(curr.Left);
                    if (curr.Right != null) queue.Enqueue(curr.Right);
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                queue.Clear();
                queue.Enqueue(root);
                curr = root;
            }
        }

        private class EnumeratorDFS : IEnumerator<T>
        {
            private Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            private BinaryTreeNode<T> root;
            private BinaryTreeNode<T> curr;

            public EnumeratorDFS(BinaryTreeNode<T> tree)
            {
                root = tree;
                Reset();
            }

            public T Current
            {
                get
                {
                    if (curr != null)
                        return curr.Value;
                    throw new ArgumentException("Empty");
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (stack.Count != 0)
                {
                    curr = stack.Pop();
                    if (curr.Right != null)
                    {
                        stack.Push(curr.Right);
                    }
                    if (curr.Left != null)
                    {
                        stack.Push(curr.Left);
                    }
                    
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                stack.Clear();
                stack.Push(root);
                curr = root;
            }
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode<int> tree = new BinaryTreeNode<int>
            {
                Value = 2,
                Left = new BinaryTreeNode<int>
                {
                    Value = 1,
                    Left= new BinaryTreeNode<int> {Value= 7},
                    Right = new BinaryTreeNode<int> { Value = 17 }
                },
                Right = new BinaryTreeNode<int>
                {
                    Value = 3,
                    Left = new BinaryTreeNode<int> { Value = 10 },
                    Right = new BinaryTreeNode<int> { Value = 23}
                }
            };

            Console.WriteLine("BFS with no use of yield: ");
            foreach (var value in tree)
                Console.Write(value + " ");
            Console.WriteLine("\n");
            
            Console.WriteLine("DFS with no use of yield: ");
            var DFS = tree.GetEnumeratorDFS();
            while (DFS.MoveNext())
                Console.Write(DFS.Current + " ");
            Console.WriteLine("\n");
            
            Console.WriteLine("BFS using yield: ");
            var BFSyield = tree.GetEnumeratorBFSyield();
            while (BFSyield.MoveNext())
                Console.Write(BFSyield.Current + " ");
            Console.WriteLine("\n");
            
            Console.WriteLine("DFS using yield: ");
            var DFSyield = tree.GetEnumeratorDFSyield();
            while (DFSyield.MoveNext())
                Console.Write(DFSyield.Current + " ");
        }
    }
}