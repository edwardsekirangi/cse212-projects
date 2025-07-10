public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //First we will create a list to store our multiples
        double[] multiples = new double[length];

        //Now we want to populate the list with the multiples of a given number

        for (int i = 0; i < length; i++)
        {
            //We use (i + 1) to prevent us from starting at 0
            multiples[i] = number * (i + 1);
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    

    //I modified the function to be able to return the result of the list
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //First we need to keep track of the count and store it in this variable
        int count = data.Count;

        //Create a list that is editable, A Dynamic list and declare it to not exceed the data limits
        List<int> rotated = new List<int>(new int[count]);

        //We will now populate the list using modulo operator to do the rotation
        for (int i = 0; i < count; i++)
        {
            //Ensures that if the index exceeds the list size, it wraps around to the beginning
            int newIndex = (i + amount) % count;
            
            rotated[newIndex] = data[i]; //Move element to new position
        }

        return rotated;
    }
}
