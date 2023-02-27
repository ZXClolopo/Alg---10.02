using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg___10._02
{
    class Bib
    {
        string fio;
        string name;
        string num;
        string alt_book;
        string name_coom;
        string janr;
        List<string> list = new List<string>();
        public Bib(string fio, string name, string num, string alt_book, string name_coom, string janr, string vid, string sda)
        {
            this.fio = fio;
            this.name = name;
            this.num = num;
            this.alt_book = alt_book;
            this.name_coom = name_coom;
            this.janr = janr;
            list.Add(vid);
            list.Add(sda);
        }
        public string Pol()
        {
            if (list[1] == "")
            {
                return "На руках";
            }
            else
            {
                return "На месте";
            }
        }

        public int Opr(string a, string name)
        {
            if (a == name)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string Interval(string time1, string time2)
        {
            if (list[1] == "")
            {
                DateTime date1 = DateTime.Parse(list[0]);
                DateTime date2 = DateTime.Parse(time1);
                DateTime date3 = DateTime.Parse(time2);

                if (date3.Subtract(date1).Days < 0)
                {
                    return "0";
                }
                else
                {
                    return "1";
                }

            }
            else
            {
                DateTime date1 = DateTime.Parse(list[0]);
                DateTime date2 = DateTime.Parse(list[1]);
                DateTime date3 = DateTime.Parse(time1);
                DateTime date4 = DateTime.Parse(time2);
                if (date3.Subtract(date1).Days < 0 && date4.Subtract(date1).Days < 0)
                {
                    return "0";
                }
                else if (date2.Subtract(date3).Days < 0 && date2.Subtract(date4).Days < 0)
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag1 = true;
            bool flag2 = true;
            while (flag1)
            {
                Console.Clear();
                string path = "C:\\Users\\Lolopo\\Desktop\\Book.txt";
                StreamReader biblia = new StreamReader(path);
                Console.Write("Меню выборки\nИздательство\nЖанр\nАвтор\nКниги на руках\nКниги на интервале\nВыход");
                Console.SetCursorPosition(20, 1);
                int k = 1;
                while (flag2)
                {
                    ConsoleKeyInfo kl = Console.ReadKey();
                    if (k == 1 && kl.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите имя издательства");
                        string name = Console.ReadLine();
                        int count = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            string[] list = biblia.ReadLine().Split(' ');
                            Bib book = new Bib(list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7]);
                            if (book.Opr(list[4], name) == 1)
                            {
                                Console.WriteLine(list[0] + " " + list[1]);
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Таких нет в списке");
                        }
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    }
                    if (k == 2 && kl.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите жанр");
                        string name = Console.ReadLine();
                        int count = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            string[] list = biblia.ReadLine().Split(' ');
                            Bib book = new Bib(list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7]);
                            if (book.Opr((list[5]), name) == 1)
                            {
                                Console.WriteLine(list[0] + " " + list[1]);
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Таких нет в списке");
                        }
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    }
                    if (k == 3 && kl.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите имя автора");
                        string name = Console.ReadLine();
                        int count = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            string[] list = biblia.ReadLine().Split(' ');
                            Bib book = new Bib(list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7]);
                            if (book.Opr((list[0]), name) == 1)
                            {
                                Console.WriteLine(list[0] + " " + list[1]);
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Таких нет в списке");
                        }
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    }
                    if (k == 4 && kl.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("Книги, которые находятся на руках:");
                        int count = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            string[] list = biblia.ReadLine().Split(' ');
                            Bib book = new Bib(list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7]);
                            if (book.Pol() == "На руках")
                            {
                                Console.WriteLine(list[0] + " " + list[1]);
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            Console.WriteLine("Количество таких книг: {0}", count);
                        }
                        else
                        {
                            Console.WriteLine("Все книги на месте");
                        }
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    }
                    if (k == 5 && kl.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("С какого числа?");
                        string time1 = Console.ReadLine();
                        Console.WriteLine("До какого числа?");
                        string time2 = Console.ReadLine();
                        int count = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            string[] list = biblia.ReadLine().Split(' ');
                            Bib book = new Bib(list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7]);
                            if (book.Interval(time1, time2) == "1")
                            {
                                Console.WriteLine(list[0] + " " + list[1]);
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Таких нет в списке");
                        }
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    }
                    if (k == 6 && kl.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        flag2 = false;
                    }

                    if ((kl.Key == ConsoleKey.DownArrow && k == 6) || (kl.Key == ConsoleKey.UpArrow && k == 2))
                    {
                        k = 1;
                        Console.SetCursorPosition(20, 1);
                    }
                    else if ((kl.Key == ConsoleKey.DownArrow && k == 1) || (kl.Key == ConsoleKey.UpArrow && k == 3))
                    {
                        k = 2;
                        Console.SetCursorPosition(20, 2);
                    }
                    else if ((kl.Key == ConsoleKey.DownArrow && k == 2) || (kl.Key == ConsoleKey.UpArrow && k == 4))
                    {
                        k = 3;
                        Console.SetCursorPosition(20, 3);
                    }
                    else if ((kl.Key == ConsoleKey.DownArrow && k == 3) || (kl.Key == ConsoleKey.UpArrow && k == 5))
                    {
                        k = 4;
                        Console.SetCursorPosition(20, 4);
                    }
                    else if ((kl.Key == ConsoleKey.DownArrow && k == 4) || (kl.Key == ConsoleKey.UpArrow && k == 6))
                    {
                        k = 5;
                        Console.SetCursorPosition(20, 5);
                    }
                    else if ((kl.Key == ConsoleKey.DownArrow && k == 5) || (kl.Key == ConsoleKey.UpArrow && k == 1))
                    {
                        k = 6;
                        Console.SetCursorPosition(20, 6);
                    }

                }
                if (flag2 == false)
                {
                    flag1 = false;
                }
            }
        }
    }
}
// описать классс и методы, которые позволяют с данными структуры (библиографический список)
// (ФИО автора, название произведения, номер, год издания, наименование издательства, жанр)
// Для каждой книги дата выдаты - дата сдача - это поле список
// Заполнение, все выборки после заполнения(отслудить база незаполнена)
// Выборки по издательству, жанра, автору, книги, которые ещё не сданы, выдать книги, которые в определённый интервал(с клавиатуры вводить) были на руках
// Меню и выход
// Выдать сообщение о пустой выборке

