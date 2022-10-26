using System;

namespace contest2ndCourse
{

//    В этой задаче вас просят вычислить сумму двух многочленов
//P(x)=a(n)*x^n+…+a(1)*x+a(0) и Q(x)=b(m)*x^m+…+b(1)*x+b(0).
//Формат ввода
//В первой строке входных данных записано одно целое число
//n(0≤n≤10). Во второй строке записаны числа
//a(n),a(n−1), …, a(0)(−100≤a(i)≤100,a(n)≠0).
//В третьей строке записано одно целое число
//m(0≤m≤10). В четвертой строке записаны числа
//b(m),b(m−1),…,b(0)(−100≤b(i)≤100,b(m)≠0).
//Гарантируется, что a(n)+b(m)≠0.

//Формат вывода

//В первой строке выведите число k — степени многочлена
//P(x)+Q(x).
//Во второй строке выведите коэффициенты этого многочлена
//c(k),c(k−1),…,c(1),c(0).

//Пример 1
//Ввод Вывод

//3
//1 2 3 4
//2
//1 0 0
//3
//1 3 3 4 

//Пример 2
//Ввод Вывод

//0
//1
//9
//1 2 3 4 5 6 7 8 9 0
//9
//1 2 3 4 5 6 7 8 9 1 

//Пример 3
//Ввод Вывод

//1
//1 1
//1
//1 1
//1
//2 2 

//Примечания
//Обязательно описать класс многочлен и переопределить операцию сложения и вычитания.
//В конструктор должен передаваться массив коэффициентов.

    public class Polynomial
    {
        public int[] coeffs;
        public Polynomial(int[] coeffs)
        {
            this.coeffs = new int[coeffs.Length];
            for (int i = 0; i < coeffs.Length; i++)
            {
                this.coeffs[i] = coeffs[i];
            }
        }
        public static Polynomial operator +(Polynomial n1, Polynomial n2)
        {
            if (n1.coeffs.Length > n2.coeffs.Length)
            {
                for (int i = n1.coeffs.Length - 1; i > n1.coeffs.Length - n2.coeffs.Length - 1; i--)
                {
                    n1.coeffs[i] += n2.coeffs[i - (n1.coeffs.Length - n2.coeffs.Length)];
                }
                return n1;
            }
            else
            {
                for (int i = n2.coeffs.Length - 1; i > n2.coeffs.Length - n1.coeffs.Length - 1; i--)
                {
                    n2.coeffs[i] += n1.coeffs[i - (n2.coeffs.Length - n1.coeffs.Length)];
                }
                return n2;
            }
        }
        public static Polynomial operator -(Polynomial n1, Polynomial n2)
        {
            if (n1.coeffs.Length > n2.coeffs.Length)
            {
                for (int i = n1.coeffs.Length - 1; i > n1.coeffs.Length - n2.coeffs.Length - 1; i--)
                {
                    n1.coeffs[i] -= n2.coeffs[i - (n1.coeffs.Length - n2.coeffs.Length)];
                }
                return n1;
            }
            else
            {
                for (int i = n2.coeffs.Length - 1; i > n2.coeffs.Length - n1.coeffs.Length - 1; i--)
                {
                    n2.coeffs[i] -= n1.coeffs[i - (n2.coeffs.Length - n1.coeffs.Length)];
                }
                return n2;
            }
        }
        public override string ToString()
        {
            string str ="";
            for (int i = 0; i < this.coeffs.Length; i++)
            {
                str += " " + Convert.ToString(this.coeffs[i]);
            }
            str = str.Substring(1);
            return str;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split(' ');
            int[] buff = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                buff[i] = int.Parse(line[i]);
            }
            Polynomial first = new Polynomial(buff);
            n = int.Parse(Console.ReadLine());
            line = Console.ReadLine().Split(' ');
            buff = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                buff[i] = int.Parse(line[i]);
            }
            Polynomial second = new Polynomial(buff);
            Console.WriteLine(Math.Max(first.coeffs.Length - 1, second.coeffs.Length - 1));
            first += second;
            Console.WriteLine(first.ToString());
            Console.ReadLine();
        }
    }
}
