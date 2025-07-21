using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: enqueue three items with different priorities
    // Expected Result: highest‐priority item is dequeued first 
    // Defect(s) Found: Empty test function
public void TestPriorityQueue_1() {

    var pq = new PriorityQueue();
    pq.Enqueue("low", 1);
    pq.Enqueue("medium", 5);
    pq.Enqueue("high", 10);

    Assert.AreEqual("high", pq.Dequeue(), "Expected 'high' because it had the largest priority.");
}


    [TestMethod]
    // Scenario: enqueue then peek without removing
    // Expected Result: Peek returns the same as Dequeue, but does not remove it
    // Defect(s) Found: Empty test function
public void TestPriorityQueue_2() {

    var pq = new PriorityQueue();
    pq.Enqueue("A", 2);
    pq.Enqueue("B", 3);

    var firstPeek = pq.Peek();
    Assert.AreEqual("B", firstPeek, "Peek should see 'B' first.");
    Assert.AreEqual("B", pq.Dequeue(), "Dequeue should still return 'B' after Peek.");
}


    // Add more test cases as needed below.
}