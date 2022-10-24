using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpClasses
{
    static public class HelpFunctions
    {
        static public int InputAndCheckBorder()
        {
            int number = 0;
            char symbol = Convert.ToChar(Console.Read());
            if (symbol == '\r')
            {
                Console.WriteLine("Введена пустая строка");
                return -1;
            }
            if (symbol == '-')
            {
                Console.WriteLine("Данное число не может быть отрицательным");
                return -1;
            }
            int digit;
            int count = 0;
            do
            {
                digit = IsOnDigit(symbol, count);
                if (digit == -1)
                {
                    number = -1;
                    return -1;
                }
                number = number * 10 + digit;
                count++;
                symbol = Convert.ToChar(Console.Read());
            } while (symbol != '\r' && digit != -1);
            return number;
        }
        static public int InputAndCheckNumber()
        {
            Console.Write("->");
            int number = 0;
            char symbol = Convert.ToChar(Console.Read());
            if (symbol == '\r')
            {
                Console.WriteLine("Введена пустая строка");
                return -1;
            }
            if (symbol == '-')
                symbol = Convert.ToChar(Console.Read());
            int digit;
            int count = 0;
            do
            {
                digit = IsOnDigit(symbol, count);
                if (digit == -1)
                {
                    number = -1;
                    return -1;
                }
                number = number * 10 + digit;
                count++;
                symbol = Convert.ToChar(Console.Read());
            } while (symbol != '\r' && digit != -1);
            return number;
        }
        static public int GetBorder(string message)
        {
            Menu menu = new Menu("Выберите действие: ");
            menu.Add("Повторить");
            menu.Add("Выйти", true);
            int choice = 0;
            int border;
            do
            {
                Console.WriteLine(message);
                Console.Write("->");
                if ((border = InputAndCheckBorder()) == -1)
                {
                    while (Console.Read() != 10) ;
                    Console.WriteLine();
                    menu.Print();
                    choice = menu.Choice();
                    Console.Clear();
                    if (choice == 0)
                        return -1;
                }
            } while (border == -1);
            return border;
        }
        static public int GetBorder(string message, int borderBeg, int borderEnd)
        {
            Menu menu = new Menu("Выберите действие: ");
            menu.Add("Повторить");
            menu.Add("Выйти", true);
            int choice = 0;
            int border;
            do
            {
                Console.WriteLine(message);
                Console.Write("->");
                if ((border = InputAndCheckBorder()) == -1)
                {
                    while (Console.Read() != 10) ;
                    Console.WriteLine();
                    menu.Print();
                    choice = menu.Choice();
                    Console.Clear();
                    if (choice == 0)
                        return -1;
                }
            } while (border == -1);
            if (border < borderBeg || border > borderEnd)
            {
                Console.WriteLine($"Введенное значение должно быть в диапазоне от {borderBeg} до {borderEnd}");
                return -1;
            }
            return border;
        }
        static public int IsOnDigit(char symbol, int count)
        {
            if (count > 0 && symbol == '.')
            {
                Console.WriteLine("Введено не целое число");
                return -1;
            }
            if (char.IsDigit(symbol))
                return symbol - '0';
            Console.WriteLine($"При считывании обнаружен некорректный символ {symbol}");
            return -1;
        }
        static public int IsOnDigit(char symbol)
        {
            if (char.IsDigit(symbol))
                return symbol - '0';
            Console.WriteLine($"При считывании обнаружен некорректный символ {symbol}");
            return -1;
        }
        static public void Continue()
        {
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
        }
        static public bool InputNumber(ref int result)
        {
            result = 0;
            Console.Write("->");
            char symbol = Convert.ToChar(Console.Read());
            if (symbol == '\r')
            {
                Console.WriteLine("Введена пустая строка");
                while (Console.Read() != 10) ;
                return false;
            }
            if (symbol == '-')
                symbol = Convert.ToChar(Console.Read());
            int digit;
            do
            {
                if ((digit = HelpFunctions.IsOnDigit(symbol)) == -1)
                {
                    while (Console.Read() != 10) ;
                    return false;
                }
                result = result * 10 + digit;
                symbol = Convert.ToChar(Console.Read());
            } while (symbol != '\r' && digit != -1);
            while (Console.Read() != 10) ;
            return true;
        }
        /// <summary>
        /// Функция проверяет строку s на корректный ввод номера. Если встречен некорретный символ- он отображается в параметре unCorrectSymbol
        /// Если функция нашла ошибку в строке- она вернет отрицательное значение
        /// </summary>
        /// <param name="s"></param>
        /// <param name="unCorrectSymbol"></param>
        /// <param name="borders"></param>
        /// <returns></returns>
        static public int ChechNumber(string s, ref char unCorrectSymbol, params int[] borders)
        {
            if (borders.Length > 2)
                throw new Exception("Передано много параметров, максимальное количество параметров: 4");
            if (s.Length == 0)
                return -1;
            int result = 0;
            foreach(char symbol in s)
            {
                if (char.IsDigit(symbol))
                    result = result * 10 + (symbol - '0');
                else
                {
                    unCorrectSymbol = symbol;
                    return -2;
                }
            }
            switch(borders.Length)
            {
                case 1:
                    if (result < borders[0])
                        return - 3;
                    break;
                case 2:
                    if ((result < borders[0]) || (result > borders[1]))
                        return -3;
                    break;
            }
            return result;
        }
        static public bool isCommand(string command, string[] commands)
        {
            foreach (string element in commands)
                if (element == command)
                    return true;
            return false;
        }
    }
}
