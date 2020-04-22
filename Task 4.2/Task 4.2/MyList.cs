﻿using System;

namespace Task_4._2
{
    public class MyList
    {
        /// <summary>
        /// Class with implementation of list element.
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ListElement"/> class.
            /// </summary>
            /// <param name="value">Element value.</param>
            /// <param name="next">Reference to next element.</param>
            public ListElement(string value, ListElement next)
            {
                Value = value;
                Next = next;
            }

            /// <summary>
            /// Gets or sets list element value.
            /// </summary>
            public string Value
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets next element reference.
            /// </summary>
            public ListElement Next
            {
                get;
                set;
            }
        }

        private ListElement currentElement;
        private int сounter;

        /// <summary>
        /// Add item to list
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="position">Number of item to add value to</param>
        public void AddElement(string value, int position)
        {
            if (position > SizeOfList() || position < 0)
            {
                throw new System.ArgumentOutOfRangeException("Error: Неверно указана позиция");
            }
            int currentPosition = 0;
            var newElement = new ListElement(value, currentElement.Next);
            newElement.Value = value;
            if (currentElement == null || position == 0)
            {
                currentElement = newElement;
                ++сounter;
                return;
            }
            if (position == 0)
            {
                newElement.Next = currentElement;
            }
            while (currentElement.Next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.Next;
                ++currentPosition;
            }
            newElement.Next = currentElement.Next;
            currentElement.Next = newElement;
            ++сounter;
        }

        /// <summary>
        /// Removing an item from a list
        /// </summary>
        /// <param name="position">Number of item to delete value</param>
        public void DeleteElement(int position)
        {
            int currentPosition = 0;
            if (currentElement == null && position == 0)
            {
                --сounter;
                throw new DeleteException("Нет начала списка");
            }
            if (position == 0)
            {
                currentElement = currentElement.Next;
                --сounter;
                return;
            }
            if (position > сounter - 1)
            {
                throw new System.ArgumentOutOfRangeException("Error: Неверно указана позиция");
            }
            while (currentElement.Next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.Next;
                ++currentPosition;
            }
            currentElement.Next = currentElement.Next.Next;
            --сounter;
        }

        /// <summary>
        /// Get the size of the list.
        /// </summary>
        /// <returns>List size</returns>
        public int SizeOfList() => сounter;

        /// <summary>
        /// Getting position value
        /// </summary>
        /// <param name="position">Number of item to add value to</param>
        /// <returns>Number of item to add value to</returns>
        public string GetItemValue(int position)
        {
            if (position > SizeOfList())
            {
                throw new System.ArgumentOutOfRangeException("Error: Неверно указана позиция");
            }
            int currentPosition = 0;
            if (currentElement == null)
            {
                throw new System.InvalidOperationException("Нет начала списка");
            }
            if (position == 0)
            {
                return currentElement.Value;
            }
            while (currentElement.Next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.Next;
                ++currentPosition;
            }
            return currentElement.Next.Value;
        }

        /// <summary>
        /// Overwriting value by position
        /// </summary>
        /// <param name="position">Number of item to add value to</param>
        /// <param name="number"> The number we want to replace</param>
        public void SetItemValue(int position, string stringOfValue)
        {
            if (position > сounter - 1)
            {
                throw new System.ArgumentOutOfRangeException("Error: Неверно указана позиция");
            }
            int currentPosition = 0;
            if (currentElement == null)
            {
                throw new System.InvalidOperationException("Нет начала списка");
            }
            if (position == 0)
            {
                currentElement.Value = stringOfValue;
                return;
            }
            while (currentElement.Next != null && currentPosition != position - 1)
            {
                currentElement = currentElement.Next;
                ++currentPosition;
            }
            currentElement.Next.Value = stringOfValue;
        }

        public bool AddUniqueElementToList(string value, int position)
        {
            if (position > SizeOfList())
            {
                throw new System.ArgumentOutOfRangeException("Error: Неверно указана позиция");
            }
            if (currentElement == null)
            {
                currentElement = new ListElement(value, currentElement);
                currentElement.Value = value;
                ++сounter;
                return true;
            }

            while (currentElement.Next != null)
            {
                if (currentElement.Value == value)
                {
                    throw new AddException("Error: Выражение не являеться уникальным");
                }
                currentElement = currentElement.Next;
            }

            if (currentElement.Value != value)
            {
                currentElement.Next = new ListElement(value, currentElement.Next);
                currentElement.Next.Value = value;
                ++сounter;
            }
            throw new AddException("Error: Выражение не являеться уникальным");
        }
    }
}