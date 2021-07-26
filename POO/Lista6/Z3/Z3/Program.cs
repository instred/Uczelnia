using System;

namespace Z3
{
    public class MainClass
    {
        public static void Main()
        {
            Tree tree = new TreeNode()
            {
                Left = new TreeNode()
                {
                    Left = new TreeLeaf() { Value = 3 },
                    Right = new TreeLeaf() { Value = 5 },
                },
                Right = new TreeLeaf() { Value = 7 }
            };

            DepthTreeVisitor depth = new DepthTreeVisitor();

            tree.Accept(depth);

            Console.WriteLine("Depth of tree is: {0}", depth.Depth);
            Console.ReadLine();
        }
    }

    public abstract class Tree
    {
        public virtual void Accept(TreeVisitor visitor)
        {

        }
    }

    public class TreeNode : Tree
    {
        public Tree Left { get; set; }
        public Tree Right { get; set; }

        public override void Accept(TreeVisitor visitor)
        {
            visitor.VisitNode(this);

            if (Left != null)
                Left.Accept(visitor);
            if (Right != null)
                Right.Accept(visitor);
        }
    }

    public class TreeLeaf : Tree
    {
        public int Value { get; set; }

        public override void Accept(TreeVisitor visitor)
        {
            visitor.VisitLeaf(this);
        }
    }

    public abstract class TreeVisitor
    {
        public abstract void VisitNode(TreeNode node);
        public abstract void VisitLeaf(TreeLeaf leaf);
    }
    public class DepthTreeVisitor : TreeVisitor
    {
        public int Depth { get; set; }

        public override void VisitNode(TreeNode node)
        {

        }
        public override void VisitLeaf(TreeLeaf leaf)
        {
            this.Depth = 1;
        }
    }
}