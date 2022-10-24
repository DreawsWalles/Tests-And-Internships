using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace Calculator
{
    public class Program
    {
        static string[] commands = { "-help", "-end" };
        static private void WorksWithCommands(string command)
        {
            Console.Clear();
            switch (command)
            {
                case "-help":
                    Console.WriteLine("Список команд:");
                    Console.WriteLine("\"-help\"- вывести список команд");
                    Console.WriteLine("\"-end\"- завершить работу \"Калькулятора\"");
                    break;
                case "-end":
                    Environment.Exit(0);
                    break;
            }
            HelpFunctions.Continue();
            Console.Clear();
        }
        static private int InputNumber(string message, ref double result)
        {
            Menu menu = new Menu("Выберите действие:", commands);
            menu.Add("Ввести ещё раз");
            menu.Add("Выйти в меню", true);
            while(true)
            {
                Console.Write($"{message} ");
                string s = Console.ReadLine();
                if (HelpFunctions.isCommand(s, commands))
                {
                    WorksWithCommands(s);
                    return -1;
                }
                try
                {
                    result = Convert.ToDouble(s);
                    return 0;
                }
                catch(Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Для вывода списка команд введите \"-help\"");
                    Console.WriteLine();
                    menu.Print();
                    if (menu.Choice() == 0)
                        return -2;
                    Console.Clear();
                }
            }
        }
        public static void Main()
        {
            while (true)
            {
                double x = 0, y = 0;
                int isContinue;
                do
                {
                    if ((isContinue = InputNumber("Введите первое число:", ref x)) == -2)
                        return;
                } while (isContinue != 0);
                do
                {
                    if ((isContinue = InputNumber("Введите второе число:", ref x)) == -2)
                        return;
                } while (isContinue != 0);
                Console.Write("Введите операцию: ");
                string operation = Console.ReadLine();
                try
                {
                    Console.WriteLine($"Результат операции: {ClassCalculator.Operation(operation, x, y)}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Для вывода списка команд введите \"-help\"");
                }
                HelpFunctions.Continue();
                Console.Clear();
            }
        }
    }
}
