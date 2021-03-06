﻿using System;
using System.Collections.Generic;

namespace Task_6._1
{
    public static class FoldFunction
    {
        /// <summary>
        /// Fold принимает список, начальное значение и функцию, которая берёт текущее накопленное значение и текущий элемент списка, и возвращает следующее накопленное значение.
        /// </summary>
        /// <param name="list"> Список для передачи в функцию </param>
        /// <param name="initialValue"> начальное значение </param>
        /// <param name="function"> Лямбда - выражение </param>
        /// <returns> Список полученный путём преобразования с помощью функции </returns>
        public static int Fold(List<int> list, int initialValue, Func<int, int, int> function)
        {
            int result = initialValue;
            foreach (int element in list)
            {
                result = function(result, element);
            }
            return result;
        }
    }
}
