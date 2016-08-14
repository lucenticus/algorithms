using System;

class Program
{
    private static int binarysearch(int []A, int elem) {
        if (A.Length == 0)
            return -1;
        if (A.Length == 1 && A[0] == elem)
            return 0;
        return binarysearchhelper(A, elem, 0, A.Length - 1);

    }
    private static int binarysearchhelper(int[] A, int elem, int beg, int end) {

        int mid = (end + beg) / 2;
        if (beg > end)
            return -1;
        if (beg == end)
            return -1;
        if (A[mid] == elem)
            return mid;
        if (A[mid] < elem)
            return binarysearchhelper(A, elem, mid + 1, end);
        else
            return binarysearchhelper(A, elem, beg, mid - 1);
    }

    private static void Main()
    {
        int [] A = {-1, 0, 0, 2, 3, 9, 11, 12, 3};
	for(int i = 0; i < A.Length; i++)
            Console.Write(A[i] + " ");
        for (int i = -10; i < 20; i++) {
            int idx = binarysearch(A, i);
            if (idx >= 0)
                Console.WriteLine("Found elem " + i + " at A["+idx+"]");
            else
                Console.WriteLine("Element " + i + " isn't found");
        }
    }
}
