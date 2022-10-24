using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace ThemeOne_ThemeTwo
{
    class ThemeTwoBlockOne
    {

        private bool InputAndCheckTaskOne(ref int sum)
        {
            char symbol = Convert.ToChar(Console.Read());
            if (symbol == '\r')
            {
                Console.WriteLine("Введена пустая строка");
                return false;
            }
            if (symbol == '-')
                symbol = Convert.ToChar(Console.Read());
            int count = 0;
            int digit;
            do
            {
                digit = HelpFunctions.IsOnDigit(symbol, count);
                if (digit == -1)
                    return false;
                sum += digit;
                count++;
                symbol = Convert.ToChar(Console.Read());
            } while (symbol != '\r' && digit != -1);
            if (count < 3)
            {
                Console.WriteLine("Введенное число не является трехначным");
                return false;
            }
            return true;
        }
        public void TaskOne()
        {
            Menu menu = new Menu("Выберите действие: ");
            menu.Add("Повторить");
            menu.Add("Выйти", true);
            int choice;
            int sum;
            do
            {
                Console.WriteLine("Введите трехзначное целое число");
                Console.Write("->");
                sum = 0;
                if (InputAndCheckTaskOne(ref sum))
                    Console.WriteLine($"Сумма цифр в числе: {sum}");
                while (Console.Read() != 10) ;
                Console.WriteLine();
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
            } while (choice != 0);
        }
        private int InputAndCheckTaskTwo(ref int number)
        {
            Console.Write("->");
            int sum = 0;
            number = 0;
            char symbol = Convert.ToChar(Console.Read());
            if (symbol == '\r')
            {
                Console.WriteLine("Введена пустая строка");
                return -1;
            }
            if (symbol == '-'){
                symbol = Convert.ToChar(Console.Read());}
            int digit;
            int count = 0;
            do
            {
                digit = HelpFunctions.IsOnDigit(symbol, count);
                if (digit == -1)
                {
                    number = -1;
                    return -1;
                }
                sum += digit;
                number = number * 10 + digit;
                count++;
                symbol = Convert.ToChar(Console.Read());
            } while (symbol != '\r' && digit != -1);
            return sum;
        }
        public void TaskTwo()
        {
            Menu menu = new Menu("Выберите действие: ");
            menu.Add("Повторить");
            menu.Add("Выйти", true);
            int choice;
            int number;
            int sum;
            int max;
            do
            {
                number = 0;
                max = 0;
                Console.WriteLine("Введите последовательность чисел");
                Console.WriteLine("*** Признак конца последовательности- 0 ***");
                do
                {
                    if ((sum = InputAndCheckTaskTwo(ref number)) != -1)
                        max = sum > max ? sum : max;
                    while (Console.Read() != 10) ;

                } while (number != 0);
                Console.WriteLine();
                Console.WriteLine($"Число с максимальной суммой цифр: {number}");
                Console.WriteLine();
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
            } while (choice != 0);
        }
        public void TaskThree()
        {
            int border;
            int choice;
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да");
            mainMenu.Add("Нет", true);
            Menu menuExit = new Menu("Выберите дейтсвие");
            menuExit.Add("Запустить ещё раз");
            menuExit.Add("Выйти в меню", true);
            int? numberOne, numberTwo, numberThree;
            int count;
            int number;
            int sum;
            do
            {
                numberOne = null;
                numberTwo = null;
                numberThree = null;
                count = 0;
                sum = 0;
                do
                {
                    if ((border = HelpFunctions.GetBorder("Введите длину массива: ")) == -1)
                    {
                        mainMenu.Print();
                        choice = mainMenu.Choice();
                        if (choice == 0)
                            return;
                    }
                    Console.Clear();
                } while (border == -1);
                while (Console.Read() != 10) ;
                if (border > 0)
                {
                    while (count < border)
                    {
                        Console.Write("Количество чисел необходимо ввести: ");
                        Console.WriteLine(border - count); 
                        if ((number = HelpFunctions.InputAndCheckNumber()) != -1)
                        {
                            if (number % 2 != 0)
                                if (numberOne == null)
                                {
                                    numberOne = number;
                                    sum += number;
                                }
                                else if (numberTwo == null)
                                {
                                    numberTwo = number;
                                    sum += number;
                                }
                                else if (numberThree == null)
                                {
                                    numberThree = number;
                                    sum += number;
                                }
                            count++;
                            while (Console.Read() != 10) ;
                        }
                        else
                            HelpFunctions.Continue();
                        Console.Clear();
                    }
                    Console.WriteLine();
                    if (numberOne == null && numberTwo == null && numberThree == null)
                        Console.WriteLine("Вы не ввели ни одного нечетного числа");
                    else
                    {
                        Console.WriteLine($"Сумма трех первых нечетных чисел равна: {sum}");
                        Console.WriteLine($"Первое число: {numberOne}");
                        Console.Write("Второе число: ");
                        if (numberTwo == null)
                            Console.WriteLine("Второго числа не было введено");
                        else
                            Console.WriteLine(numberTwo);
                        Console.Write("Третье число: ");
                        if (numberThree == null)
                            Console.WriteLine("Тертьего числа не было введно");
                        Console.WriteLine(numberThree);
                    }
                    Console.WriteLine();
                }
                menuExit.Print();
                choice = menuExit.Choice();
                Console.Clear();
            } while (choice != 0);
        }
        private int GetSum(int? numberOne, int? numberTwo, int? numberThree)
        {
            int result = 0;
            if (numberOne == null)
                return -1;
            result += (int)numberOne;
            if (numberTwo == null)
                return result;
            result += (int)numberTwo;
            if (numberThree == null)
                return result;
            result += (int)numberThree;
            return result;

        }
        public void TaskFour()
        {
            int border;
            int choice;
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            Menu menuExit = new Menu("Выберите дейтсвие");
            menuExit.Add("Запустить ещё раз");
            menuExit.Add("Выйти в меню", true);
            int? numberOne, numberTwo, numberThree;
            int count;
            int number;
            int sum;
            do
            {
                numberOne = null;
                numberTwo = null;
                numberThree = null;
                count = 0;
                do
                {
                    if ((border = HelpFunctions.GetBorder("Введите длину массива: ")) == -1)
                    {
                        mainMenu.Print();
                        choice = mainMenu.Choice();
                        if (choice == 0)
                            return;
                    }
                    Console.Clear();
                } while (border == -1);
                while (Console.Read() != 10) ;
                if (border > 0)
                {
                    while (count < border)
                    {
                        Console.Write("Количество чисел необходимо ввести: ");
                        Console.WriteLine(border - count);
                        if ((number = HelpFunctions.InputAndCheckNumber()) != -1)
                        {
                            if (number % 2 != 0)
                                if (numberOne == null)
                                    numberOne = number;
                                else if (numberTwo == null)
                                    numberTwo = number;
                                else if (numberThree == null)
                                    numberThree = number;
                                else
                                {
                                    numberOne = numberTwo;
                                    numberTwo = numberThree;
                                    numberThree = number;
                                }
                            count++;
                            while (Console.Read() != 10) ;
                        }
                        else 
                            HelpFunctions.Continue();
                        Console.Clear();
                    }
                    Console.WriteLine();
                    if ((sum = GetSum(numberOne, numberTwo, numberThree)) == -1)
                        Console.WriteLine("Вы не ввели ни одного нечетного числа");
                    else
                    {
                        Console.WriteLine($"Сумма трех первых нечетных чисел равна: {sum}");
                        Console.WriteLine($"Первое число: {numberOne}");
                        Console.Write("Второе число: ");
                        if (numberTwo == null)
                            Console.WriteLine("Второго числа не было введено");
                        else
                            Console.WriteLine(numberTwo);
                        Console.Write("Третье число: ");
                        if (numberThree == null)
                            Console.WriteLine("Тертьего числа не было введно");
                        Console.WriteLine(numberThree);
                    }
                    Console.WriteLine();
                }
                menuExit.Print();
                choice = menuExit.Choice();
                Console.Clear();
            } while (choice != 0);
        }
        public void GraphicsModuleA(int n, int m)
        {
            Console.WriteLine("1. Прмоугольник");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        private void GraphicsModuleBOne(int m)
        {
            Console.WriteLine("2.1");
            Console.WriteLine();
            for (int i = 1; i <= m; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        private void GraphicsModuleBTwo(int m)
        {
            Console.WriteLine();
            Console.WriteLine("2.2");
            Console.WriteLine();
            for (int i = 1; i <= m; i++)
            {
                for (int j = 0; j < m - i; j++)
                    Console.Write(" ");
                for (int j = m - i; j < m; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        private void GraphicsModuleBThree(int m)
        {
            Console.WriteLine();
            Console.WriteLine("2.3");
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m - i; j++)
                    Console.Write("*");
                for (int j = m - i; j < m; j++)
                    Console.Write(" ");
                Console.WriteLine();
            }
        }
        private void GraphicsModuleBFour(int m)
        {
            Console.WriteLine();
            Console.WriteLine("2.4");
            Console.WriteLine();
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j < i; j++)
                    Console.Write(" ");
                for (int j = i; j <= m; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        private void GraphicsModuleB(int m)
        {
            Console.WriteLine("2. Треугольник");
            GraphicsModuleBOne(m);
            GraphicsModuleBTwo(m);
            GraphicsModuleBThree(m);
            GraphicsModuleBFour(m);     
        }
        private void GraphicsModuleC(int n)
        {
            Console.WriteLine("3. Ромб");
            Console.WriteLine();
            for(int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n - i; j++)
                    Console.Write(" ");
                for (int j = n - i; j < n; j++)
                    Console.Write("*");
                for (int j = 0; j < i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            for (int i = n; i > 0; i--)
            {
                for (int j = 0; j < n - i; j++)
                    Console.Write(" ");
                for (int j = n - i; j < n; j++)
                    Console.Write("*");
                for (int j = 0; j < i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        public void TaskFive()
        {
            int borderN, borderM;
            int choice;
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            do
            {
                if ((borderN = HelpFunctions.GetBorder("Введите границу n: ", 1, 20)) == -1 )
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return;
                }
                Console.Clear();
            } while (borderN == -1);
            while (Console.Read() != 10) ;
            do
            {
                if ((borderM = HelpFunctions.GetBorder("Введите границу m: ", 1, 20)) == -1)
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return;
                }
                Console.Clear();
            } while (borderM == -1);
            while (Console.Read() != 10) ;
            GraphicsModuleA(borderN, borderM);
            Console.WriteLine();
            GraphicsModuleB(borderM);
            Console.WriteLine();
            GraphicsModuleC(borderN);
            HelpFunctions.Continue();
        }
        private int AriphProgModeleA()
        {
            int result = 0;
            for (int i = 1; i <= 50; i++)
                result += i;
            return result;
        }
        private int AtiphProgModuleB()
        {
            int result = 0;
            for (int i = 2; i <= 50;)
            {
                result += i;
                i += 2;
            }
            return result;
        }
        private int AriphProgModuleC()
        {
            int result = 0;
            for (int i = 1; i <= 51;)
            {
                result += i;
                i += 2;
            }
            return result;
        }
        public void TaskSix()
        {
            Console.WriteLine("Посчитать сумму ряда:");
            Console.WriteLine();
            Console.WriteLine($"а) 1 + 2 + 3 + .................. + 50 = {AriphProgModeleA()}");
            Console.WriteLine($"б) 2 + 4 + 6 + 8 + 10 + .....  + 50 = {AtiphProgModuleB()}");
            Console.WriteLine($"в) 1 + 3 + 5  +7 + 9.... + 51 = {AriphProgModuleC()}");
            Console.WriteLine();
            HelpFunctions.Continue();
        }
        public void TaskSeven()
        {
            int result = 0;
            int count = 0;
            for (int i = 6; i <= 46;)
            {
                result += i;
                i += 4;
                count++;
            }
            Console.WriteLine($"Сумма ряда 6 + 10 + 14 + ................... + 46 = {result}");
            Console.WriteLine($"Количество слагаемых: {count}");
            Console.WriteLine();
            HelpFunctions.Continue();
        }
        public void TaskEight()
        {
            int result = 0;
            for (int i = 0; i < 10; i++)
                result += 4;
            Console.WriteLine($"Сумма ряда при 10 слагаемых 6 + 10 + 14 + ...................  = {result}");
            Console.WriteLine();
            HelpFunctions.Continue();
        }
        public void TaskNine()
        {
            int result = 0;
            int delta = 1;
            for (int i = 0; i < 11; i++)
            {
                result += i;
                delta *= 2;
            }
            Console.WriteLine($"Сумма 11 слагаемых 1+2+4+8+16+.... = {result}");
            Console.WriteLine();
            HelpFunctions.Continue();
        }
        public void TaskTen()
        {
            int result;
            int count = 0;
            for (result = 6; result <= 100;)
            {
                result += 4;
                count++;
            }
            Console.WriteLine($"Сумма 6 + 10 + 14 + ....... = {result} при условии, что сумма должна превысить 100 количество слагаемых равно {count}");
            Console.WriteLine();
            HelpFunctions.Continue();
        }
        public void TaskEleven()
        {
            int result;
            int count = 0;
            for (result = 6; (result + 4) <= 100;)
            {
                result += 4;
                count++;
            }
            Console.WriteLine($"Сумма, которая не привышает 100, 6 + 10 + 14 + ....... = {result} имеет {count} слагаемых");
            Console.WriteLine();
            HelpFunctions.Continue();
        }
        private int Fibonachi(int number)
        {
            if (number <= 1)
                return number;
            return Fibonachi(number - 1) + Fibonachi(number - 2);
        }
        public void TaskTwelve()
        {
            int border;
            int choice;
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            Menu menuExit = new Menu("Выберите дейтсвие");
            menuExit.Add("Запустить ещё раз");
            menuExit.Add("Выйти в меню", true);
            do
            {
                do
                {
                    if ((border = HelpFunctions.GetBorder("Введите количество чисел, сумму которых необходимо посчитать: ", 0, 20)) == -1)
                    {
                        mainMenu.Print();
                        choice = mainMenu.Choice();
                        if (choice == 0)
                            return;
                    }
                    Console.Clear();
                } while (border == -1);
                while (Console.Read() != 10) ;
                int result = 0;
                for (int i = 0; i < border; i++)
                    result += Fibonachi(i);
                Console.WriteLine($"Сумма первых {border} чисел Фибоначчи равна {result}");
                Console.WriteLine();
                menuExit.Print();
                choice = menuExit.Choice();
                Console.Clear();
            } while (choice != 0);
        }
    }
}
