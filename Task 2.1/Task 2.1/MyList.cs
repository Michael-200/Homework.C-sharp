﻿using System;

namespace MyList
{
    public class MyList
    {
        private class ListElement
        {
            internal int value;
            internal ListElement next;
        }

        private ListElement head;
        private int counter;

        /// <summary>
        /// Add item to list
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="position">Number of item to add value to</param>
        public void AddElement(int value, int position)
        {
            if (position > counter || position < 0)
            {
                throw new ArgumentException("Error");
            }
            int currentPosition = 0;
            var newElement = new ListElement();
            newElement.value = value;
            if (head == null || position == 0)
            {
                head = newElement;
                ++counter;
                return;
            }
            ListElement currentElement = head;
            if (position == 0)
            {
                newElement.next = currentElement;
            }
            while (currentElement.next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.next;
                ++currentPosition;
            }
            newElement.next = currentElement.next;
            currentElement.next = newElement;
            ++counter;
        }

        /// <summary>
        /// Removing an item from a list
        /// </summary>
        /// <param name="position">Number of item to delete value</param>
        public void DeleteElement(int position)
        {
            int currentPosition = 0;
            ListElement currentElement = head;
            if (currentElement == null && position == 0)
            {
                --counter;
                throw new MyException("Нет начала списка");
            }
            if (position == 0)
            {
                head = currentElement.next;
                --counter;
                return;
            }
            if (position > counter - 1)
            {
                throw new ArgumentException("Error");
            }
            while (currentElement.next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.next;
                ++currentPosition;
            }
            currentElement.next = currentElement.next.next;
            --counter;
        }

        /// <summary>
        /// Get the size of the list.
        /// </summary>
        /// <returns>List size</returns>
        public int SizeOfList() => counter;

        /// <summary>
        /// Getting position value
        /// </summary>
        /// <param name="position">Number of item to add value to</param>
        /// <returns>Number of item to add value to</returns>
        public int GetItemValue(int position)
        {
            if (position > SizeOfList())
            {
                throw new ArgumentException("Error");
            }
            int currentPosition = 0;
            ListElement currentElement = head;
            if (head == null)
            {
                throw new MyException("Нет начала списка");
            }
            if (position == 0)
            {
                return currentElement.value;
            }
            while (currentElement.next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.next;
                ++currentPosition;
            }
            return currentElement.next.value;
        }

        /// <summary>
        /// Overwriting value by position
        /// </summary>
        /// <param name="position">Number of item to add value to</param>
        /// <param name="number"> The number we want to replace</param>
        public void SetItemValue(int position, int number)
        {
            if (position > counter - 1)
            {
                throw new ArgumentException("Error");
            }
            int currentPosition = 0;
            ListElement currentElement = head;
            if (head == null)
            {
                Console.WriteLine("Нет начала списка");
                return;
            }
            if (position == 0)
            {
                currentElement.value = number;
                return;
            }
            while (currentElement.next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.next;
                ++currentPosition;
            }
            currentElement.next.value = number;
        }
    }
}