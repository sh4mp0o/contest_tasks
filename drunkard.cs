using System;
using System.Collections.Generic;


/*

 Игрок, который забирает себе карты, сначала кладет под низ своей колоды карту первого игрока,
затем карту второго игрока (то есть карта второго игрока оказывается внизу колоды).

Напишите программу, которая моделирует игру в пьяницу и определяет, кто выигрывает.
В игре участвует 10 карт, имеющих значения от 0 до 9, большая карта побеждает меньшую, карта со значением 0 побеждает карту 9.


Формат ввода

Программа получает на вход две строки: первая строка содержит 5 чисел, разделенных пробелами — номера карт первого игрока,
вторая – аналогично 5 карт второго игрока. Карты перечислены сверху вниз,
то есть каждая строка начинается с той карты, которая будет открыта первой.


Формат вывода

Программа должна определить, кто выигрывает при данной раздаче, и вывести слово first или second,
после чего вывести количество ходов, сделанных до выигрыша.
Если на протяжении 10^6 ходов игра не заканчивается, программа должна вывести слово botva.


Пример

Ввод
1 3 5 7 9
2 4 6 8 0

Вывод
second 5

*/



namespace contest
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueF = new Queue<int>();
            Queue<int> queueS = new Queue<int>();
            string[] line = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < line.Length; i++)
            {
                queueF.Enqueue(int.Parse(line[i]));
            }
            line = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < line.Length; i++)
            {
                queueS.Enqueue(int.Parse(line[i]));
            }
            int count = 0;
            while(queueF.Count > 0 && queueS.Count > 0)
            {
                int F = queueF.Dequeue();
                int S = queueS.Dequeue();
                if(F == 0 && S == 9)
                {
                    queueF.Enqueue(F);
                    queueF.Enqueue(S);
                }
                else if (S == 0 && F == 9)
                {
                    queueS.Enqueue(F);
                    queueS.Enqueue(S);
                }
                else if (F > S)
                {
                    queueF.Enqueue(F);
                    queueF.Enqueue(S);
                }
                else
                {
                    queueS.Enqueue(F);
                    queueS.Enqueue(S);
                }
                count++;
            }
            if (count > 1000000) Console.WriteLine("botva");
            else
            {
                if (queueS.Count > 0) Console.WriteLine($"second {count}");
                else Console.WriteLine($"first {count}");
            }
            Console.ReadKey();
        }
    }
}
