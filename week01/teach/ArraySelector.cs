public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 20, 40, 60, 80, 100 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}");
        // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        //first we need to create a list to append array 1 and array 2
        int[] result = new int[select.Length];

        //and now we need to keep track of the indices in each of the 2 lists
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)

                result[i] = list1[index1++];
            else
                result[i] = list2[index2++];

        }
        return result;
    }
}