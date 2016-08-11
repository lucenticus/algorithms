using System;
using System.Collections.Generic;

class HashTable {
    private const int size = 101;
    private List<Pair> []tab;
    public HashTable() {
        tab = new List<Pair>[size];
    }
    private int hash(int key) {
        return key % size;
    }
    public void add(int key, String s) {
        List <Pair> l = tab[hash(key)];
        if (l == null)
            tab[hash(key)] = new List<Pair>();
        tab[hash(key)].Add(new Pair (key, s));
    }
    public String search(int key) {
        List <Pair> h = tab[hash(key)];
        if (h == null)
            return null;
        foreach (Pair p in h) {
            if (p.key == key)
                return p.val;
        }
        return null;
    }
    public bool remove(int key) {
        List <Pair> h = tab[hash(key)];
        foreach (Pair p in h) {
            if (p.key == key) {
                h.Remove(p);
                return true;
            }
        }
        return false;
    }
    class Pair {
        public int key;
        public String val;
        public Pair(int k, String s) {
            key = k;
            val = s;
        }
    }
}
class Program
{
    private static void Main()
    {
        HashTable tab = new HashTable();
        tab.add(1, "qwe");
        tab.add(3, "qwew");
        tab.add(102, "q");
        tab.add(11, "qwwwe");

        for (int k = 0; k < 102; k++) {
            String s = tab.search(k);
            if (s != null)
                Console.WriteLine("Value for key '" + k + "': " + s);
            else
                Console.WriteLine("Can't find val for key '" + k + "'");
        }
    }
}
