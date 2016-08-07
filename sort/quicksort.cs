using System;

internal class Program
{
    private static void swap(ref int a, ref int b) {
	int t = a;
	a = b;
	b = t;
    }
    private static int partition(int[] A, int p, int r) {
	int x = A[r];
	int i = p - 1;
	for (int j = p; j <= r - 1; j++) {
	    if (A[j] <= x) {
		i = i + 1;
		swap(ref A[i], ref A[j]);
	    }
	}
	swap(ref A[i+1], ref A[r]);
	return i + 1;
    }
    private static void quicksort(int[] A, int p, int r) {
	if (p < r) {
	    int q = partition(A, p, r);
	    quicksort(A, p, q-1);
	    quicksort(A, q+1, r);
	}
    }
    private static void Main(string[] args)
    {
	int [] A = {2, 8, 7, 1, 3, 5, 6, 4};
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();

	quicksort(A, 0, A.Length - 1);
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	    Console.WriteLine();
    }
}
