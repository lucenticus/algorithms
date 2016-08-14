using System;

class BinarySearchTree {
    public class Node {
        public Node left;
        public Node right;
        public int data;
        public void print() {
            Console.WriteLine("Node: " + data);
        }
    }

    public Node root {get; set; }
    public void Insert(int d, ref Node n) {
        if (n == null) {
            n = new Node {left = null, right = null, data = d};
            return;
        }
        if (n.data < d) {
            Insert(d, ref n.right);
        } else {
            Insert(d, ref n.left);
        }
    }
    public BinarySearchTree () {
        root = null;
    }
    public BinarySearchTree(int [] A) {
        Node n = root;
        for (int i = 0 ; i < A.Length; i++) {
            Insert(A[i], ref n);
        }
        root = n;
    }
    public Node Search(Node n, int d) {
        if (n == null || n.data == d)
            return n;
        if (n.data > d)
            return Search(n.left, d);
        else
            return Search(n.right, d);
    }
    public void InorderWalk(Node n) {
        if (n == null)
            return;
        InorderWalk(n.left);
        Console.Write(n.data +  " ");
        InorderWalk(n.right);

    }
    public void PreorderWalk(Node n) {
        if (n == null)
            return;
        Console.Write(n.data +  " ");
        InorderWalk(n.left);
        InorderWalk(n.right);
        
    }
    public void PostOrderWalk(Node n) {
        if (n == null)
            return;
        InorderWalk(n.left);
        InorderWalk(n.right);
        Console.Write(n.data +  " ");
    }
}

class Program
{
    private static void Main()
    {
        int [] A = {20, 8, 5, 11, 0, 2, -4, 15, 14};
        BinarySearchTree bst = new BinarySearchTree(A);
        bst.InorderWalk(bst.root);
        Console.WriteLine();
        BinarySearchTree.Node n = bst.Search(bst.root, 11);
        if (n != null)
            n.print();
    }
}
