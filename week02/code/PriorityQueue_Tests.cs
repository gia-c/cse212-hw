using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A (priority 1), B (priority 2), C (priority 5). Dequeue once.
    // Expected Result: C (the highest priority is at the back of the queue).
    // Defect(s) Found: The loop in Dequeue stopped one item too early (Count - 1), so the last
    // item was never checked and B was returned instead of C. Fixed the loop condition.
    public void TestPriorityQueue_HighestPriorityAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (priority 1), B (priority 5), C (priority 2). Dequeue once.
    // Expected Result: B (the highest priority is in the middle of the queue).
    // Defect(s) Found: None. This case passed with the original code.
    public void TestPriorityQueue_HighestPriorityInMiddle()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (priority 5) and B (priority 1). Dequeue twice.
    // Expected Result: A first, then B (each item is removed once it is dequeued).
    // Defect(s) Found: Dequeue never removed the item from the list, so A was returned
    // both times. Fixed by adding RemoveAt after finding the highest priority index.
    public void TestPriorityQueue_ItemIsRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (priority 3), B (priority 3), C (priority 1). Dequeue three times.
    // Expected Result: A, B, C (with equal priority, the item closest to the front goes first).
    // Defect(s) Found: The comparison used >= so the later item won ties and B was returned
    // before A. Fixed by changing >= to >.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None. This case passed with the original code.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}