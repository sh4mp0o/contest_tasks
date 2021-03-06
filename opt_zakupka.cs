using System.IO;

namespace contest
{

//A.Оптовая закупка

//Ограничение времени 1 секунда
//Ограничение памяти	64Mb

//Ввод    input.txt
//Вывод   output.txt


//Предприятие производит оптовую закупку некоторых изделий A и B,
//на которую выделена определённая сумма денег.
//У поставщика есть в наличии партии этих изделий различных модификаций по различной цене.
//На выделенные деньги необходимо приобрести как можно больше изделий одного из видов независимо от модификации.
//Если у поставщика закончатся изделия этого вида,
//то на оставшиеся деньги необходимо приобрести как можно больше изделий второго вида.
//Известны выделенная для закупки сумма и вид изделий, которые приобретаются в первую очередь,
//а также количество и цена различных модификаций данных изделий у поставщика.
//Необходимо определить, сколько будет закуплено изделий второго вида и какая сумма останется неиспользованной.


//Формат ввода

//Первая строка входного файла содержит два целых числа:
//N – общее количество партий изделий у поставщика
//и M – сумма выделенных на закупку денег (в рублях),
//а также символ (латинская буква A или B) вид изделий,
//покупаемых в первую очередь.Каждая из следующих N строк
//описывает одну партию и содержит два целых числа
//(цена одного изделия в рублях и количество изделий в партии)
//и один символ(латинская буква A или B), определяющий вид изделия.
//Все данные в строках входного файла отделены одним пробелом.


//Формат вывода

//В ответе запишите два целых числа:
//сначала количество закупленных изделий второго вида,
//затем оставшуюся неиспользованной сумму денег.


//Пример

//Ввод

//4 1000 A
//30 8 A
//50 12 B
//40 14 A
//30 60 B

//Вывод

//6 20


//Примечания

//В данном случае сначала нужно купить изделия A: 8 изделий по 30 рублей и 14 изделий по 40 рублей.
//На это будет потрачено 800 рублей.На оставшиеся 200 рублей можно купить 6 изделий B по 30 рублей.
//Таким образом, всего будет куплено 6 изделий B и останется 20 рублей.В ответе надо записать числа 6 и 20.




    internal class Program
    {
        struct product
        {
            public string type;
            public int price;
            public int count;
        }
        static void BubbleSort(product[] inArray)
        {
            for (int i = 0; i < inArray.Length; i++)
                for (int j = 0; j < inArray.Length - i - 1; j++)
                {
                    if (inArray[j].price > inArray[j + 1].price)
                    {
                        product temp = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = temp;
                    }
                }
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] line = sr.ReadLine().Split();
                int n = int.Parse(line[0]);
                int sum = int.Parse(line[1]);
                string type = line[2];
                product[] list = new product[n];
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine().Split();
                    list[i] = new product
                    {
                        type = line[2],
                        price = int.Parse(line[0]),
                        count = int.Parse(line[1])
                    };
                }
                BubbleSort(list);
                for (int i = 0; i < n; i++)
                {
                    if (list[i].type == type)
                    {
                        int count = 0;
                        while (sum >= list[i].price && count != list[i].count)
                        {
                            sum -= list[i].price;
                            count++;
                        }
                    }
                }
                int cnt = 0;
                for (int i = 0; i < n; i++)
                {
                    if (list[i].type != type)
                    {
                        int count = 0;
                        while (sum >= list[i].price && count != list[i].count)
                        {
                            sum -= list[i].price;
                            count++; cnt++;
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine($"{cnt} {sum}");
                }
            }
        }
    }
}
