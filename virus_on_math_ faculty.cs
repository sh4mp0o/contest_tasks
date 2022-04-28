using System;
using System.Collections.Generic;

namespace contest
{


    //    C.Вирус в 7 корпусе(Структуры)

    //Ограничение времени 1 секунда
    //Ограничение памяти	64Mb

    //Ввод    стандартный ввод или input.txt
    //Вывод стандартный вывод или output.txt

    //В файловую систему 7 корпуса ЯрГУ проник вирус, который сломал контроль за правами доступа к файлам.
    //Для каждого файла Ni известно, с какими действиями можно к нему обращаться:

    //запись W,
    //чтение R,
    //запуск X.

    //Вам требуется восстановить контроль над правами доступа к файлам.
    //Ваша программа для каждого запроса должна будет возвращать OK если над файлом выполняется допустимая операция,
    //или же Access denied, если операция недопустима.


    //Формат ввода

    //В первой строке входного файла содержится число N (1<=N<=10000) —количество файлов содержащихся в данной файловой системе.
    //В следующих N строчках содержатся имена файлов и допустимых с ними операций, разделенные пробелами.
    //Далее указано чиcло M(1<=M<=50000) — количество запросов к файлам.
    //В последних M строках указан запрос вида Операция Файл. К одному и тому же файлу может быть применено любое колличество запросов.


    //Формат вывода

    //Для каждого из M запросов нужно вывести в отдельной строке Access denied или OK.


    //Пример

    //Ввод

    //4
    //helloworld.exe R X
    //pinglog W R
    //nya R
    //goodluck X W R
    //5
    //read nya
    //write helloworld.exe
    //execute nya
    //read pinglog
    //write pinglog


    // Вывод

    //OK
    //Access denied
    //Access denied
    //OK
    //OK


    internal class Program
    {
        struct file
        {
            public bool W;
            public bool R;
            public bool X;
            public string name;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<file> files = new List<file>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                files.Add(new file { name = line[0] });
                file temp = files[i];
                for (int j = 1; j < line.Length; j++)
                {
                    if (line[j] == "W") temp.W = true;
                    if (line[j] == "R") temp.R = true;
                    if (line[j] == "X") temp.X = true;
                }
                files[i] = temp;
            }
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string name = line[1];
                foreach (file file in files)
                {
                    if (file.name == name)
                    {
                        if (line[0] == "write")
                        {
                            if (file.W) Console.WriteLine("OK");
                            else Console.WriteLine("Access denied");
                        }
                        if (line[0] == "read")
                        {
                            if (file.R) Console.WriteLine("OK");
                            else Console.WriteLine("Access denied");
                        }
                        if (line[0] == "execute")
                        {
                            if (file.X) Console.WriteLine("OK");
                            else Console.WriteLine("Access denied");
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
