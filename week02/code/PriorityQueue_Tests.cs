using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and then dequeue it.
    // Expected Result: Item is dequeued after being enqueued.
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        var Result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", Result);

    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and then dequeue them.
    // Expected Result: Items are dequeued in order of priority (highest to lowest).
    // Defect(s) Found: Not handling priorities correctly. It failed to dequeue the highest priority item first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        // Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("Low Priority Task", 1);
        priorityQueue.Enqueue("High Priority Task", 5);
        priorityQueue.Enqueue("Medium Priority Task", 3);

        Assert.AreEqual("High Priority Task", priorityQueue.Dequeue());
        Assert.AreEqual("Medium Priority Task", priorityQueue.Dequeue());
        Assert.AreEqual("Low Priority Task", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and then dequeue them.
    // Expected Result: Items are dequeued in the order they were enqueued (FIFO) when priorities are the same.
    // Defect(s) Found: Incorrectly handled same priority items. It failed to maintain FIFO order.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 2);
        priorityQueue.Enqueue("Task2", 2);
        priorityQueue.Enqueue("Task3", 2);

        Assert.AreEqual("Task1", priorityQueue.Dequeue());
        Assert.AreEqual("Task2", priorityQueue.Dequeue());
        Assert.AreEqual("Task3", priorityQueue.Dequeue());
    }


    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: No defects found.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario: Enqueue items with negative and zero priorities.
    // Expected Result: Items are dequeued in order of priority (highest to lowest), treating negative priorities as lower than zero.
    // Defect(s) Found: It fails to handle negative and zero priorities correctly.
    public void TestPriorityQueue_NegativeAndZeroPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Negative Priority Task", -1);
        priorityQueue.Enqueue("Zero Priority Task", 0);
        priorityQueue.Enqueue("Positive Priority Task", 1);

        Assert.AreEqual("Positive Priority Task", priorityQueue.Dequeue());
        Assert.AreEqual("Zero Priority Task", priorityQueue.Dequeue());
        Assert.AreEqual("Negative Priority Task", priorityQueue.Dequeue());
    }
}