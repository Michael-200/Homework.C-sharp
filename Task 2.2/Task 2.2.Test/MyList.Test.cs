﻿using System;
using NUnit.Framework;

namespace Task_2._2.Test
{
    public class ListTests
    {
        private MyList list;

        [SetUp]
        public void Setup()
        {
            list = new MyList();
        }

        [Test]
        public void AddUniqueElementToListShouldWorkTrue()
        {
            list.AddUniqueElementToList("ver");
            list.AddUniqueElementToList("car");
            list.AddUniqueElementToList("abc");

            Assert.IsTrue(list.Contains("car"));
        }

        [Test]
        public void AddUniqueElementToListShouldWorkFalse()
        {
            list.AddUniqueElementToList("abc");

            Assert.IsFalse(list.Contains("ver"));
        }

        [Test]
        public void AddUniqueElementToListAndDeleteElementShouldWork()
        {
            list.AddUniqueElementToList("abc");
            list.AddUniqueElementToList("ver");
            list.DeleteElement("abc");

            Assert.IsFalse(list.Contains("abc"));
            Assert.IsTrue(list.Contains("ver"));
        }

        [Test]
        public void AddElementAndAddUniqueElementToListShouldWork()
        {
            list.AddElement("abc");
            list.AddUniqueElementToList("abc");
            list.AddElement("abc");

            Assert.AreEqual(2, list.SizeOfList());
        }

        [Test]
        public void ListShouldWork()
        {
            list.AddUniqueElementToList("0");
            list.AddUniqueElementToList("1");
            list.AddUniqueElementToList("2");
            list.AddUniqueElementToList("3");
            list.AddUniqueElementToList("4");

            Assert.AreEqual(5, list.SizeOfList());

            list.DeleteElement("2");
            list.DeleteElement("0");
            list.DeleteElement("1");
            list.DeleteElement("4");
            list.DeleteElement("3");

            Assert.AreEqual(0, list.SizeOfList());

            list.AddUniqueElementToList("0");
            list.AddUniqueElementToList("1");

            Assert.AreEqual(2, list.SizeOfList());

            list.DeleteElement("0");
            list.DeleteElement("1");

            Assert.AreEqual(0, list.SizeOfList());
        }

        [Test]
        public void ShouldThrowExceptionWhenWeDeleteEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => list.DeleteElement("abc"));
        }
    }
}
