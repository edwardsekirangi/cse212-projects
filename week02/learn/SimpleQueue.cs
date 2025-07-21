using System.Diagnostics;
using System.Xml.XPath;
public class SimpleQueue {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display 100
        Console.WriteLine("Test 1");
        var queue = new Queue<int>();
        queue.Enqueue(100);
        
        var value = queue.Dequeue();
        Trace.Assert(value == 100);
        Console.WriteLine(value);
        // Defect(s) Found: This had an unhandled exception error, it was trying to access or use an index value that did not exist

        Console.WriteLine("------------");

        // Test 2
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        Console.WriteLine("Test 2");
        queue = new Queue<int>();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: This works perfectly

        Console.WriteLine("------------");

        // Test 3
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        //SINCE I am using system.Collections.Generic (Queue<int>) it throws another error
        Console.WriteLine("Test 3");
        queue = new Queue<int>();
        try {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (InvalidOperationException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found: 
    }

    private readonly List<int> _queue = new();

    /// <summary>
    /// Enqueue the value provided into the queue
    /// </summary>
    /// <param name="value">Integer value to add to the queue</param>
    private void Enqueue(int value) {
        _queue.Insert(0, value);
    }

    /// <summary>
    /// Dequeue the next value and return it
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">If queue is empty</exception>
    /// <returns>First integer in the queue</returns>
    private int Dequeue() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();

        var value = _queue[1];
        _queue.RemoveAt(1);
        return value;
    }
}