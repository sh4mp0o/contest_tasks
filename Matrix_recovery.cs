using System;
using System.Collections.Generic;


//Ограничение времени	1 секунда
//Ограничение памяти	256Mb
//Ввод	стандартный ввод или input.txt
//Вывод	стандартный вывод или output.txt
//Для создания сервиса бонусов была предложена следующая схема:
//Выбирается целое число n.
//В помеченные ячейки матрицы n×n записываются n различных чисел от 1 до n^2.
//Остальные n^2−n ячеек остаются пустыми. Пользователь получает бонус,
//если угадывает числа, расположенные в помеченных ячейках.
//Для получения бонуса нужно заполнить матрицу n×n таким образом, чтобы все числа от 
//1 до n^2 встречались ровно один раз, а во всех помеченных ячейках числа совпадали с выигрышным шаблоном.
//Найдите любую выигрышную матрицу.

//Формат ввода
//В первой строке входных данных записано целое число 
//n(2≤n≤100).
//Далее в n строках записаны числа в матрице-шаблоне 
//aij(0≤aij≤n^2). Если aij=0, то соответствующая ячейка матрицы не является помеченной и должна быть заполнена.
//Если aij≠0, то в соответствующую ячейку матрицы нужно вписать aij.

//Формат вывода
//Выведите n строк по n целых чисел — любую из выигрышных матриц.
//Гарантируется, что существует как минимум одна выигрышная матрица.

//Пример 1
//Ввод	
//4
//0 0 0 0
//1 2 3 4
//0 0 0 0
//0 0 0 0

//Вывод
//6 16 14 11
//1 2 3 4
//8 5 7 10
//13 12 9 15

//Пример 2
//Ввод	
//4
//1 0 0 0
//0 6 0 0
//0 0 11 0
//0 0 0 16

//Вывод
//1 2 4 3
//14 6 8 5
//7 10 11 13
//12 9 15 16

//Пример 3
//Ввод	
//3
//0 0 0
//0 0 0
//3 2 1

//Вывод
//9 5 4
//6 7 8
//3 2 1

namespace contest2ndCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            SortedSet<int> set = new SortedSet<int>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(line[j]);
                    set.Add(matrix[i, j]);
                }
            }
            int k = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        while (set.Contains(k))
                            k++;
                        matrix[i, j] = k;
                        set.Add(k);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
    }
}
