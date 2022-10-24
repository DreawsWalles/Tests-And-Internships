using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using HelpClasses;
using System.Threading;
using System.Collections.Concurrent;

namespace ThemeSix
{
    public class Program
    {         
        static void WorkWithArray()
        {
            Console.Clear();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ClassArray.InitOneThread();
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            Console.WriteLine("Время инициализации массива одним потоком: " + String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            watch.Reset();
            watch.Start();
            ClassArray.InitMultyThread();
            watch.Stop();
            ts = watch.Elapsed;
            Console.WriteLine("Время инициализации массива несколькими потоками: " + String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            watch.Reset();
            watch.Start();
            ClassArray.QuickSort();
            watch.Stop();
            ts = watch.Elapsed;
            Console.WriteLine("Время быстрой сортировки: " + String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            watch.Reset();
            ClassArray.InitMultyThread();
            watch.Start();
            ClassArray.BubbleSort();
            watch.Stop();
            ts = watch.Elapsed;
            Console.WriteLine("Время сортировки пузырьком: " + String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            HelpFunctions.Continue();
            Console.Clear();
        }
        public static void Main()
        {
            Menu menu = new Menu("Выберите блок заданий:");
            menu.Add("Работа с массивом");
            menu.Add("Запустить \"Чат-бота\"");
            menu.Add("Выйти в главное меню", true);
            int choice;
            do
            {
                menu.Print();
                choice = menu.Choice();
                switch (choice)
                {
                    case 1:
                        WorkWithArray();
                        break;
                    case 2:
                        ChatBotMultyThread.Program.Main();
                        break;
                }
            } while (choice != 0);
        }
    }
}
