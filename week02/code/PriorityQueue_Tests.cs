using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue Low with priority 1, High with priority 3, Medium with priority 2. Dequeue one time.
    // Expected Result: High is returned, because it has the highest priority, even though it was not added first.
    // Defect(s) Found: The original implementation did not correctly identify the highest-priority item in all queue positions. This test verifies that the highest-priority item is selected. Test result after the fix: Passed.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue First with priority 2, Second with priority 2, Third with priority 1. Dequeue two times.
    // Expected Result: First is returned first, then Second, because when two items have the same highest priority, the first one added is removed first.
    // Defect(s) Found: Before the fix, Second was returned first instead of First, because the code used greater than or equal to when it compared priorities, so the later item replaced the earlier item. After the fix, the code uses greater than only. Test result after the fix: Passed.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A with priority 1, B with priority 1, C with priority 5 as the last item. Dequeue one time.
    // Expected Result: C is returned, because it has the highest priority, even though it is the last item in the queue.
    // Defect(s) Found: Before the fix, B was returned instead of C, because the loop stopped one item early and never checked the last item. After the fix, the loop checks all items. Test result after the fix: Passed.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Enqueue X with priority 1, Y with priority 3, Z with priority 2. Dequeue three times until the queue is empty.
    // Expected Result: Y is returned first, then Z, then X, in order of highest priority to lowest priority.
    // Defect(s) Found: Before the fix, Y was returned every time, because the code returned the value but never removed the item from the queue. After the fix, each item is removed after it is returned. Test result after the fix: Passed.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 1);
        priorityQueue.Enqueue("Y", 3);
        priorityQueue.Enqueue("Z", 2);

        Assert.AreEqual("Y", priorityQueue.Dequeue());
        Assert.AreEqual("Z", priorityQueue.Dequeue());
        Assert.AreEqual("X", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: No defect found. The empty queue check was already correct. Test result: Passed.
    public void TestPriorityQueue_5()
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
