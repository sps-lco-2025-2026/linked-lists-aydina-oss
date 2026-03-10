using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListExample.Lib;

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{
    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestPrepend()
    {
        var ill = new IntegerLinkedList(5);
        ill.Prepend(3);
        Assert.AreEqual("{3, 5}", ill.ToString());
    }

    [TestMethod]
    public void TestDelete()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        bool success = ill.Delete(7);
        Assert.IsTrue(success);
        Assert.AreEqual("{5, 9}", ill.ToString());
        Assert.IsFalse(ill.Delete(99));
    }

    [TestMethod]
    public void TestInsert()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(9);
        ill.Insert(7, 1);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestJoin()
    {
        var list1 = new IntegerLinkedList(1);
        var list2 = new IntegerLinkedList(2);
        list1.Join(list2);
        Assert.AreEqual("{1, 2}", list1.ToString());
    }

    [TestMethod]
    public void TestContains()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        Assert.IsTrue(ill.Contains(7));
        Assert.IsFalse(ill.Contains(10));
    }

    [TestMethod]
    public void TestRemoveDuplicates()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(5);
        ill.Append(9);
        ill.RemoveDuplicates();
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestMerge()
    {
        var list1 = new IntegerLinkedList(1);
        list1.Append(3);
        var list2 = new IntegerLinkedList(2);
        list2.Append(4);
        list1.Merge(list2);
        Assert.AreEqual("{1, 2, 3, 4}", list1.ToString());
    }

    [TestMethod]
    public void TestReverse()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(2);
        ill.Append(3);
        var reversed = ill.Reverse();
        Assert.AreEqual("{3, 2, 1}", reversed.ToString());
    }

    [TestMethod]
    public void TestSorted()
    {
        var sorted = new SortedIntegerLinkedList(5);
        sorted.Append(3);
        sorted.Append(7);
        sorted.Append(4);
        Assert.AreEqual("{3, 4, 5, 7}", sorted.ToString());
    }
}   