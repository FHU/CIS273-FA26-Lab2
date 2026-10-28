namespace UnitTests;

using KthToLast;

[TestClass]
public class KthToLastTests
{
    // 1 -> 2 -> 3 -> 4 -> 5
    private static LinkedList<int> MakeList() => new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });

    // Singly-linked

    [TestMethod]
    public void SinglyLinked_ZeroIsTail()
    {
        Assert.AreEqual(5, MakeList().KthToLastSinglyLinked(0));
    }

    [TestMethod]
    public void SinglyLinked_OneIsBeforeTail()
    {
        Assert.AreEqual(4, MakeList().KthToLastSinglyLinked(1));
    }

    [TestMethod]
    public void SinglyLinked_Middle()
    {
        Assert.AreEqual(3, MakeList().KthToLastSinglyLinked(2));
    }

    [TestMethod]
    public void SinglyLinked_LastValidKIsHead()
    {
        Assert.AreEqual(1, MakeList().KthToLastSinglyLinked(4));
    }

    [TestMethod]
    public void SinglyLinked_SingleElement()
    {
        var list = new LinkedList<string>(new[] { "only" });
        Assert.AreEqual("only", list.KthToLastSinglyLinked(0));
    }

    [TestMethod]
    public void SinglyLinked_ListIsUnchanged()
    {
        var list = MakeList();
        list.KthToLastSinglyLinked(2);
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, list.ToArray());
    }

    [TestMethod]
    public void SinglyLinked_NegativeKThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => MakeList().KthToLastSinglyLinked(-1));
    }

    [TestMethod]
    public void SinglyLinked_KEqualToCountThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => MakeList().KthToLastSinglyLinked(5));
    }

    [TestMethod]
    public void SinglyLinked_KGreaterThanCountThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => MakeList().KthToLastSinglyLinked(10));
    }

    [TestMethod]
    public void SinglyLinked_EmptyListThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => new LinkedList<int>().KthToLastSinglyLinked(0));
    }

    // Doubly-linked

    [TestMethod]
    public void DoublyLinked_ZeroIsTail()
    {
        Assert.AreEqual(5, MakeList().KthToLastDoublyLinked(0));
    }

    [TestMethod]
    public void DoublyLinked_OneIsBeforeTail()
    {
        Assert.AreEqual(4, MakeList().KthToLastDoublyLinked(1));
    }

    [TestMethod]
    public void DoublyLinked_Middle()
    {
        Assert.AreEqual(3, MakeList().KthToLastDoublyLinked(2));
    }

    [TestMethod]
    public void DoublyLinked_LastValidKIsHead()
    {
        Assert.AreEqual(1, MakeList().KthToLastDoublyLinked(4));
    }

    [TestMethod]
    public void DoublyLinked_SingleElement()
    {
        var list = new LinkedList<string>(new[] { "only" });
        Assert.AreEqual("only", list.KthToLastDoublyLinked(0));
    }

    [TestMethod]
    public void DoublyLinked_ListIsUnchanged()
    {
        var list = MakeList();
        list.KthToLastDoublyLinked(2);
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, list.ToArray());
    }

    [TestMethod]
    public void DoublyLinked_NegativeKThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => MakeList().KthToLastDoublyLinked(-1));
    }

    [TestMethod]
    public void DoublyLinked_KEqualToCountThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => MakeList().KthToLastDoublyLinked(5));
    }

    [TestMethod]
    public void DoublyLinked_KGreaterThanCountThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => MakeList().KthToLastDoublyLinked(10));
    }

    [TestMethod]
    public void DoublyLinked_EmptyListThrows()
    {
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => new LinkedList<int>().KthToLastDoublyLinked(0));
    }
}
