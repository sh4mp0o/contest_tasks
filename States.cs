using System;
using System.IO;
using System.Collections.Generic;

namespace contest2ndCourse
{

//В файле data.csv в рабочей директории находится информация о городах.
//LatD, LatM, LatS, NS, LonD, LonM, LonS, EW, City, State
//41,5,59, N,80,39,0, W, Youngstown, OH
//42,52,48, N,97,23,23, W, Yankton, SD
//46,35,59, N,120,30,36, W, Yakima, WA
//42,16,12, N,71,48,0, W, Worcester, MA
//43,37,48, N,89,46,11, W, WisconsinDells, WI
//36,5,59, N,80,15,0, W, Winston-Salem, NC
//49,52,48, N,97,9,0, W, Winnipeg, MB
//39,11,23, N,78,9,36, W, Winchester, VA
//34,14,24, N,77,55,11, W, Wilmington, NC
//39,45,0, N,75,33,0, W, Wilmington, DE
//Определите все штаты, про которые есть данные хотя бы о двух городах.

//Формат вывода
//Выведите список требуемых штатов в лексикографическом порядке.
//Пример 1
//Ввод Вывод
//LatD, LatM, LatS, NS, LonD, LonM, LonS, EW, City, State
//41,5,59, N,80,39,0, W, Youngstown, OH
//42,52,48, N,97,23,23, W, Yankton, SD
//46,35,59, N,120,30,36, W, Yakima, WA
//42,16,12, N,71,48,0, W, Worcester, MA
//43,37,48, N,89,46,11, W, WisconsinDells, WI
//36,5,59, N,80,15,0, W, Winston-Salem, NC
//49,52,48, N,97,9,0, W, Winnipeg, MB
//39,11,23, N,78,9,36, W, Winchester, VA
//34,14,24, N,77,55,11, W, Wilmington, NC
//39,45,0, N,75,33,0, W, Wilmington, DE
//NC
//Пример 2
//Ввод Вывод
//LatD, LatM, LatS, NS, LonD, LonM, LonS, EW, City, State
//41,5,59, N,80,39,0, W, Youngstown, OH
//42,52,48, N,97,23,23, W, Yankton, SD
//46,35,59, N,120,30,36, W, Yakima, WA
//42,16,12, N,71,48,0, W, Worcester, MA
//43,37,48, N,89,46,11, W, WisconsinDells, WI
//36,5,59, N,80,15,0, W, Winston-Salem, NC
//39,11,23, N,78,9,36, W, Winchester, VA
//34,14,24, N,77,55,11, W, Wilmington, NC
//47,25,11, N,120,19,11, W, Wenatchee, WA
//44,57,35, N,89,38,23, W, Wausau, WI
//NC WA WI

    internal class Program
    {
        static void Main(string[] args)
        {
            string line;
            using (StreamReader sr = new StreamReader("data.csv"))
            {
                HashSet<string> set = new HashSet<string>();
                List<string> list = new List<string>();
                line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null && !string.IsNullOrWhiteSpace(line))
                {
                    line = line.Substring(line.Length - 2, 2);
                    if (set.Contains(line))
                        list.Add(line);
                    set.Add(line);
                }
                list.Sort();
                set.Clear();
                for (int i = 0; i < list.Count; i++)
                    set.Add(list[i]);
                foreach (string item in set)
                    Console.Write("{0} ", item);
            }
        }
    }
}
