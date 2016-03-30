using System;

class Program
{
    private static int heap_size = 0;
    private static int parent(int i) {
	return i / 2;
    }

    private static int left(int i) {
	return 2 * i;
    }

    private static int right(int i) {
	return 2 * i + 1;
    }
    private static void swap(ref int a, ref int b) {
	int t = a;
	a = b;
	b = t;
    }

    private static void max_heapify(int[] A, int i) {
	int l = left(i);
	int r = right(i);
	int largest = i;
	if (l < heap_size && A[l] > A[i])
	    largest = l;

	if (r < heap_size && A[r] > A[largest])
	    largest = r;
	if (largest != i) {
	    swap(ref A[i], ref A[largest]);
	    max_heapify(A, largest);
	}
    }

    private static void build_max_heap(int[] A) {
	heap_size = A.Length;
	for (int i = A.Length / 2 - 1; i >= 0; i--)
	    max_heapify(A, i);
    }

    private static void heapsort(int[] A) {
	build_max_heap(A);
	for (int i = A.Length - 1; i >= 1; i--) {
	    swap(ref A[0], ref A[i]);
	    heap_size--;
	    max_heapify(A, 0);
	}
    }

    private static void Main()
    {
	int [] A = {2, 5, 3, 0, 2, 3, 0, 3};
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();
	heapsort(A);
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();

    }
}
