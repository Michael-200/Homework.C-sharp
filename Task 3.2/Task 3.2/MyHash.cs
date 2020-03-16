﻿using System;

namespace Task_3._2
{
    public class HashTable
    {
        public HashTable(IMyHash myHash)
        {
            Hash = myHash;
            for (int i = 0; i != capacity; ++i)
            {
                hashTable[i] = new MyList();
            }
        }

        IMyHash Hash;

        const int capacity = 100;
        MyList[] hashTable = new MyList[capacity];
        int count = 0;


        public void ChangeHash(IMyHash myHash)
        {
            MyList list = new MyList();
            for (int i = 0; i < capacity; i++)
            {
                while (hashTable[i].SizeOfList() != 0)
                {
                    string value = hashTable[i].PopElement();
                    list.AddElement(value);
                }
            }
            Hash = myHash;
            while (list.SizeOfList() != 0)
            {
                string value = list.PopElement();
                AddElementToHashTable(value);
            }
        }

        // что нужно. нужен какой-то контейнеер, в котором будем хранить
        // выкинутые элементы. нужен цикл, в котором будем идти по всей
        // хеш таблице и вытаскивать элементы оттуда в контейнер
        // после этого цикла сменить хэш функцию и наверное новым циклом
        // пока наш контейнер не окажется пуст, вытаскивать из него
        // элементы и засовывать в хеш таблицу

        /// <summary>
        /// Add value to hash table and checks value for uniqueness in hash table
        /// </summary>
        /// <param name="value">Value to add</param>
        public void AddElementToHashTable(string value)
        {
            int index = Hash.HashFunction(value);
            hashTable[index].AddUniqueElementToList(value);
        }

        /// <summary>
        /// Checks the existence of a value in a hash table
        /// </summary>
        /// <param name="value">Value entered</param>
        /// <returns>Returns index position</returns>
        public bool IsContainInHashTable(string value)
        {
            int index = Hash.HashFunction(value);
            return hashTable[index].IsContain(value);
        }

        public string PopElement()
        {
            int index = Hash.HashFunction(hashTable[count].PopElement());
            if (count < capacity)
            {
                count++;
            }
            return hashTable[index].PopElement();
        }


        public void AddElementToHashTabl()
        {
            int index = Hash.HashFunction(PopElement());
            hashTable[index].AddUniqueElementToList(PopElement());
        }


        /// <summary>
        /// Delete the value in the hash table
        /// </summary>
        /// <param name="value">Value to be deleted</param>
        public void DeleteElementOfHashTable(string value)
        {
            int index = Hash.HashFunction(value);
            if (IsContainInHashTable(value) == true)
            {
                hashTable[index].DeleteElement(value);
                Console.WriteLine($"\"{value}\" было удалено" + "\n");
            }
            else
            {
                Console.WriteLine("Такого элемента здесь нет");
                return;
            }
        }
    }
}