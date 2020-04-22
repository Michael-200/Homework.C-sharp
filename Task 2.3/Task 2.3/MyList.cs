﻿using System;

namespace Task_2._3
{
    public class MyList
    {
        class ListElement
        {
            internal int value;
            internal ListElement next;
        }

        private ListElement head;
        private int counter = 0;

        /// <summary>
        /// Add item to List
        /// </summary>
        /// <param name="value">Value to add</param>
        public void AddElement(int value)
        {
            ListElement newElement = new ListElement();
            newElement.value = value;
            if (head == null)
            {
                head = newElement;
                ++counter;
                return;
            }
            ListElement currentElement = head;
            while (currentElement.next != null)
            {
                currentElement = currentElement.next;
            }
            newElement.next = currentElement.next;
            currentElement.next = newElement;
            ++counter;
        }

        /// <summary>
        /// Remove element in the List
        /// </summary>
        /// <returns> Result of value </returns>
        public int RemoveElement()
        {
            ListElement currentElement = head;
            if (currentElement == null)
            {
                throw new MyException("The list is empty");
            }

            int value;
            if (currentElement.next == null)
            {
                value = currentElement.value;
                head = null;
                counter--;
                return value;
            }

            while (currentElement.next.next != null)
            {
                currentElement = currentElement.next;
            }
            value = currentElement.next.value;
            currentElement.next = null;
            counter--;
            return value;
        }

        /// <summary>
        /// Size of list
        /// </summary>
        /// <returns> Size of list </returns>
        public int SizeOfList()
        {
            return counter;
        }
    }
}

