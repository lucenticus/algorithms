using System;

class Program
{
    private static int get_max(int [] A) {
	int max = A[0];
	for (int i = 1; i < A.Length; i++)
	    if (max < A[i])
		max = A[i];
	return max;
    }

    private static void radixsort(int[] A, int digit) {
	var count = new int [10];
	var helperA = new int [A.Length];
	
	for (int i = 0; i < A.Length; i++) {
	    count[(A[i] / digit) % 10]++;	    
	}
	for (int i = 1; i < count.Length; i++) {
	    count[i] += count[i - 1];
	}
	for (int i = A.Length - 1; i >= 0; i--) {
	    helperA[count[(A[i] / digit) % 10] - 1] = A[i];
	    count[(A[i] / digit) % 10]--;
	}
	for (int i = 0; i < A.Length; i++)
	    A[i] = helperA[i];
	    	
    }
    private static void radixsort(int[] A) {
	int max = get_max(A);
	for (int i = 1; max/i > 0; i *= 10)
	    radixsort(A, i);
    }
    private static void Main()
    {
	int [] A = {329, 457, 657, 839, 436, 720, 355};
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();
	radixsort(A);
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();

    }
}
