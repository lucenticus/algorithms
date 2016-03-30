using System;

class Program
{
    private static void countingsort(int[] A, int[] B, int k) {
	var C = new int [k + 1];
	for (int i = 0; i <= k; i++)
	    C[i] = 0;

	for (int j = 0; j < A.Length; j++)
	    C[A[j]] = C[A[j]] + 1;

	for (int i = 1; i < k + 1; i++) {
	    C[i] = C[i] + C[i-1];
	}

	for (int j = A.Length - 1; j >= 0; j--) {
	    B[C[A[j]] - 1] = A[j];
	    C[A[j]] = C[A[j]] - 1;
	}
    }
    private static void Main()
    {
	int [] A = {2, 5, 3, 0, 2, 3, 0, 3};
	var B = new int [A.Length];
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();
	countingsort(A, B, 5);
	for(int i = 0; i < B.Length; i++)
	    Console.Write(B[i] + " ");
	Console.WriteLine();

    }
}
