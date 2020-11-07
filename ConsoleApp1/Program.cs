using System;
using System.Dynamic;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Net.WebSockets;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int x = 1;
            char a = 'A', b = '\x5A';
            string hello = "Hello";
            short s1 = 1;
            ulong u = 10;
            Console.WriteLine(x);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(hello);
            Console.WriteLine(s1);
            Console.WriteLine(u);
            Console.WriteLine($"{x},{a},{b},{hello},{s1},{u}");
            short y;
            y = short.Parse(Console.ReadLine());
            Console.WriteLine($"{y}");
            string str;
            int q;
            str = Console.ReadLine();
            q = Convert.ToInt32(str);
            Console.WriteLine(q);
            ulong u2 = 11;
            u2 = ulong.Parse(Console.ReadLine());
            Console.WriteLine(u2);
            Console.ReadKey();
            //------------------------------------------- неявные
            byte a1 = 4;
            ushort a2 = a1;
            sbyte a3 = 4;
            short a4 = a3;
            sbyte a5 = -4;
            short a6 = a5;
            byte a7 = 99;
            short a8 = a7;
            byte a9 = 5;
            long a10 = a9;
            /// явные
            int a11 = 4;
            int a12 = 6;
            byte a13 = (byte)(a11 + a12);
            Console.WriteLine(a13);
            long a14 = 50;
            long a15 = 33;
            byte a16 = (byte)(a14 + a15);
            Console.WriteLine(a16);
            long a17 = 50;
            long a18 = 33;
            int a19 = (int)(a17 + a18);
            Console.WriteLine(a19);
            ////////// boxing and unboxing
            int i = 123; // "i" is a value type     
            object o = i; // boxing "i" into "o"
            int j = (int)o; // unboxing "o" into "j"
            //////// Неявно типизированные локальные  переменные.Ключевое слово "var"           
            var mas = 4.0;
            Console.Write(mas.GetType()); Console.WriteLine();
            var mas1 = 2;
            Console.Write(mas1.GetType()); Console.WriteLine();
            var mas2 = 2.7183F;
            Console.Write(mas2.GetType()); Console.WriteLine();
            ///// nullable
            int? aa = 1;
            int? bb = null;
            Console.WriteLine(bb ?? aa);
            int? p = null;
            if (p.HasValue)
                Console.WriteLine(p.Value);
            else
                Console.WriteLine("p is equal to null");
            ////////////// строки
            string string1 = "Hello Nikita"; ///a
            string string2 = "Hello";
            Console.WriteLine(String.Compare(string1,string2));
            int MyInt = string1.CompareTo(string2);
            Console.WriteLine(MyInt);
            Console.WriteLine(String.CompareOrdinal(string1, string2));
            /// b
            
            string string3 = "Nikita";
            string string4 = "Zaitsev";
            string string5 = "Vitalievich";
            string string6 = "NikitaZaitsevVitalievich";
            Console.WriteLine(String.Concat(string3,string4,string5)); //сцепление

            string stringcopy1 = string3;
            string stringcopy2 = string4;
            string stringcopy3 = string5;
            Console.WriteLine($"{stringcopy1},{stringcopy2},{stringcopy3}"); //копирование

            string6 = string6.Substring(2);
            Console.WriteLine(string6);
            string6 = string6.Substring(2);
            Console.WriteLine(string6);
            string6 = string6.Substring(0,string6.Length -2);
            Console.WriteLine(string6);
            string6 = string6.Substring(3, 6);
            Console.WriteLine(string6);// выделение подстроки     начало и длина 3 6

            string text = "Всем привет дорогие подписчики ";
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // параметр говорит, что надо удалить все пустые подстроки
            foreach (string s in words)
            {
                Console.WriteLine(s);
            } //// разделение строки на слова

            string text1 = " и самые любимые";
            text = text.Insert(19, text1);
            Console.WriteLine(text);//// вставки подстроки в заданную позицию

            string string7 = "Люблю С# и тебя!";
            string7 = string7.Remove(9, 7);
            Console.WriteLine(string7); /// удаление заданной подстроки

            /////c
            int x8 = 8;
            int y7 = 7;
            string result = $"{x8} + {y7} = {x8 + y7}";
            Console.WriteLine(result); // 8 + 7 = 15

            long number = 19876543210;
            Console.WriteLine($"{number:+# ### ### ## ##}"); // +1 987 654 32 10
                                                             ///////////////////ИНТЕРПОЛЯЦИЯ СТРОК БЫЛА ВЫШЕ


            ///////////////////////// С
            string string0 = "";
            string stringnull = null;
            Console.WriteLine(String.IsNullOrEmpty(string0));
            Console.WriteLine(String.IsNullOrEmpty(stringnull));
            Console.WriteLine(String.Concat(string0,stringnull)); // сцепление
            Console.WriteLine("CompareTo: " + string0.CompareTo(stringnull)); // сравнил

            //////  D
            StringBuilder sb = new StringBuilder("ABC", 50); // инициализируем строкой "ABC" и макс на 50 символов
            sb.Append(new char[] { 'D', 'E', 'F' }); // вставляем 3 символа в конец
            Console.WriteLine(sb);
            sb.Insert(0, "YA");// вставляем строку в начало
            Console.WriteLine(sb);
            sb.AppendFormat("GHI{0},{1}", 'J', 'K');
            Console.WriteLine(sb); // добавляем форматную строку в конец
            sb.Remove(5, 5);
            Console.WriteLine(sb); // удалил

            ///////// массивы
            //а
            int[,] myArray = new int[,]
            {
                {1,3,5,7,8 },
                {2,4,6,8,4 },
                {3,3,5,7,1 },
                { 2,2,1,1,4}
            };

            int height = myArray.GetLength(0);
            int width = myArray.GetLength(1);
            for (int ii = 0; ii < height; ii++) //y
            {
                for (int jj = 0; jj < width; jj++) //x
                {
                    Console.Write(myArray[ii, jj] + "\t");    
                }
                Console.WriteLine( );
            }

            /// a random
            int[,] MyArray = new int[7, 6];
                Random random = new Random();

                for (int iii = 0; iii < MyArray.GetLength(0); iii++) //y
            {
                for (int jjj = 0; jjj < MyArray.GetLength(1); jjj++) //x
                {
                    MyArray[iii, jjj] = random.Next();
                }
                
            }

            for (int iiii = 0; iiii < MyArray.GetLength(0); iiii++) //y
            {
                for (int jjjj = 0; jjjj < MyArray.GetLength(1); jjjj++) //x
                {
                    Console.Write(MyArray[iiii, jjjj] + "\t");
                }
                Console.WriteLine();
            }

            ////////////////b

            // одномерные массивы
            int[] nums2 = new int[4] { 1, 2, 3, 5 };

            int[] nums3 = new int[] { 1, 2, 3, 5 };

            int[] nums4 = new[] { 1, 2, 3, 5 };

            int[] nums5 = { 1, 2, 3, 5 };

            foreach (int g in nums5)
            {
                Console.Write(g + " ");
                
            }
            Console.WriteLine(nums5.Length);

            ////////////////c
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 1, 2 };
            numbers[1] = new int[] { 1, 2, 3 };
            numbers[2] = new int[] { 1, 2, 3, 4, 5 };
            foreach (int[] row in numbers)
            {
                foreach (int number1 in row)
                {
                    Console.Write($"{number1} \t");
                }
                Console.WriteLine();
            }

            // перебор с помощью цикла for
            for (int i1 = 0; i1 < numbers.Length; i1++)
            {
                for (int j1 = 0; j1 < numbers[i1].Length; j1++)
                {
                    Console.Write($"{numbers[i1][j1]} \t");
                }
                Console.WriteLine();
            }
            ///////////// d
            var A = new[] { 1, 10, 100, 1000 }; // int[]
            var B = new[] { "hello", null, "world" }; // string[]

            // одномерный зубчатый массив
            var c = new[]
            {
            new[]{1,2,3,4},
            new[]{5,6,7,8}
        };

            // зубчатый массив строк
            var d = new[]
            {
            new[]{"Luca", "Mads", "Luke", "Dinesh"},
            new[]{"Karen", "Suma", "Frances"}
        };
            ///////////// Кортежи
            ///а
            (int, string, char, string, ulong) student = (19, "Nikita", 'm', "Minsk", 100 );
            Console.WriteLine(student);

            //////b
            var population = new Tuple<string, int, int, int, int, int, int>(
                           "New York", 7891957, 7781984,
                           7894862, 7071639, 7322564, 8008278);
            // Display the first and last elements.
            Console.WriteLine("Population of {0} in 2000: {1:N0}",
                              population.Item1, population.Item7);

            (var a22, var b2) = ("123", 456);
            Console.WriteLine($"{a22} {b2}");
            //////////////c


            ///// d
            (int, string, char, string, ulong) student2 = (18, "Liza", 'f', "Mozyr", 80);          
            Console.WriteLine(student2.CompareTo(student));

            /// 5

            Func<int[], string, Tuple<int, int, int, char>> fun = (arr, str) => arr.Aggregate(Tuple.Create(Int32.MinValue, Int32.MaxValue, 0, str[0]), (y, x) => Tuple.Create(Math.Max(y.Item1, x), Math.Min(y.Item2, x), y.Item3 + x, y.Item4));
            Console.WriteLine(fun(new int[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, 0 }, "Abracadabra"));
            /// 6
            void Check()
            {
                unchecked
                {
                    Console.WriteLine(2147483647 + 10);
                }

            }
            Check();

            int _ = 7;

            Console.WriteLine(_);


























        }
    }
}
