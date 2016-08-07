using System;

class Program
{

    private static void mergesort(int [] A) {
        var helper = new int [A.Length];
        mergesort(A, helper, 0, A.Length - 1);
    }
    private static void mergesort(int[] A, int[] helper, int low, int high) {
        if (low < high) {
            int middle = (low + high) / 2;
            mergesort(A, helper, low, middle);
            mergesort(A, helper, middle + 1, high);
            mergesort(A, helper, low, middle, high);
        }
    }
    private static void mergesort(int[] A, int[] helper, int low, int middle, int high) {
        for (int i = low; i <= high; i++) {
            helper[i] = A[i];
        }
        int helperLeft = low;
        int helperRight = middle + 1;
        int current = low;
        while (helperLeft <= middle && helperRight <= high) {
            if (helper[helperLeft] <= helper[helperRight]) {
                A[current] = helper[helperLeft];
                helperLeft++;
            } else {
                A[current] = helper[helperRight];
                helperRight++;
            }
            current++;
        }
        int remaining = middle - helperLeft;
        for (int i = 0; i <= remaining; i++) {
            A[current + i] = helper[helperLeft + i];
        }
    }
    private static void Main()
    {
        int [] A = {2, 5, 3, 0, 2, 3, 0, 3};
        for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();
        mergesort(A);
	for(int i = 0; i < A.Length; i++)
	    Console.Write(A[i] + " ");
	Console.WriteLine();

    }
}
