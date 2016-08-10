using System;
using System.Collections.Generic;

class Graph {
    private Node[] nodes;
    public Graph(int size) {
        nodes = new Node[size];
    }
    public Node setNode(int i, Node n) {
        return nodes[i] = n;
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
    public void searchBFS(int start) {
        Queue <Node>  q = new Queue <Node>();
        nodes[start].marked = true;
        q.Enqueue(nodes[start]);
        while (q.ToArray().Length > 0) {
            Node r = q.Dequeue();
            visit(r);
            foreach (int n in r.adj) {
                if (nodes[n].marked == false) {
                    nodes[n].marked = true;
                    q.Enqueue(nodes[n]);
                }
            }
        }
        Console.WriteLine("");
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
}
class Node {
    public int val { get; set; }
    public List <int> adj;
    public bool marked;
    public Node() {
        marked = false;
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
        G.setNode(0, new Node {val = 0, adj = new List<int> {1, 3}});
        G.setNode(1, new Node {val = 1, adj = new List<int> {0, 4}});
        G.setNode(2, new Node {val = 2, adj = new List<int> {5, 4}});
        G.setNode(3, new Node {val = 3, adj = new List<int> {0, 1, 4}});
        G.setNode(4, new Node {val = 4, adj = new List<int> {2, 3}});
        G.setNode(5, new Node {val = 5, adj = new List<int> {2, 5}});
        G.print();
        Console.WriteLine(" -- BFS --");
        G.searchBFS(0);
        Console.WriteLine();
        G.reset();

        Console.WriteLine(" -- DFS --");
        G.searchDFS(0);
        Console.WriteLine();

    }
}
