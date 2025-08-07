public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        //If value equals current node's data, return and not add it to the tree
        if (value == Data)
        {
            return; // Value already exists in the tree, do not insert duplicates
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        //For our first case, we will check to see if the current is the data and then return true
        if (value == Data)
        {
            return true;
        }

        //If value is less, search the left subtree
        if (value < Data)
        {
            //So, I was gonna use an if statement and found this simpler way of checking for
            // the left subtree if it is null
            return Left?.Contains(value) ?? false; // If Left is null, return false
        }

        //If the value is greater, search the right subtree
        else
        {
            //So, I was gonna use an if statement and found this simpler way of checking for
            // the right subtree if it is null
            return Right?.Contains(value) ?? false; // If Right is null, return false

        }
        
    }

    public int GetHeight()
    {
        // TODO Start Problem 4\

        //Initialize heights for the left and right subtrees
        int leftHeight = 0;
        int rightHeight = 0;

        //Recursively get height of left subtree if it exists
        if (Left != null)
        {
            leftHeight = Left.GetHeight();
        }

        //Recursively get the height of right subtree if it exists
        if (Right != null)
        {
            rightHeight = Right.GetHeight();
        }

        //Return 1(for current node) plus the maximum of left and right heights
        if (leftHeight > rightHeight)
        {
            return 1 + leftHeight;
        }
        else
        {
            return 1 + rightHeight;
        }
        // return 0; Replace this line with the correct return statement(s)
    }
}