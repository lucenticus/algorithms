using System;
using System.Collections.Generic;

class Graph {
    private Node[] nodes;
    public Graph(int size) {
        nodes = new Node[size];
    }
    public Node setNode(Node n) {
        return nodes[n.val] = n;
    }
    public Node getNode(int i) {
        if (nodes[i] == null)
            nodes[i] = new Node(i);
        return nodes[i];
    }

    public void reset() {
        foreach (Node n in nodes) {
            n.marked = false;
        }
    }
    public void print() {
        for(int i = 0; i < nodes.Length; i++) {
            nodes[i].print();
	    Console.WriteLine("");
        }
    }
    public void visit(Node r) {
        Console.Write(r.val + ", ");
    }
    public void searchDFS(int r) {
        visit(nodes[r]);
        nodes[r].marked = true;
        foreach (int n in nodes[r].adj) {
            if (nodes[n].marked == false) {
                nodes[n].marked = true;
                searchDFS(n);
            }
        }
    }
    public Graph reverse() {
        Graph R = new Graph(nodes.Length);
        for (int i = 0; i < nodes.Length; i++) {
            var n = getNode(i);
            foreach (var a in n.adj) {
                R.getNode(a).addAdj(i);
            }
        }
        return R;
    }
}
class Node {
    public int val { get; set; }
    public List <int> adj;
    public bool marked;
    public Node() {
        marked = false;
    }
    public Node(int i) {
        marked = false;
        val = i;
        adj = new List<int>();
    }

    public void addAdj(int a) {
        adj.Add(a);
    }
    public void print() {
        Console.Write(val + ": ");
        foreach (int a in adj)
            Console.Write(a + ", ");
    }

}
class Program
{
    private static void Main()
    {
        Graph G = new Graph(6);
        G.setNode(new Node {val = 0, adj = new List<int> {1, 3}});
        G.setNode(new Node {val = 1, adj = new List<int> {0, 4}});
        G.setNode(new Node {val = 2, adj = new List<int> {5, 4}});
        G.setNode(new Node {val = 3, adj = new List<int> {0, 1, 4}});
        G.setNode(new Node {val = 4, adj = new List<int> {2, 3}});
        G.setNode(new Node {val = 5, adj = new List<int> {2, 5}});
        G.print();

        Console.WriteLine();
        Graph R = G.reverse();
        R.print();

    }
}
