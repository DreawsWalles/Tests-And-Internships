using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelpClasses;

namespace ThemeOne_ThemeTwo
{
    class ThemeTwoBlockTwo
    {
        
        //метод, увеличивающий количество цифр, которые встретились в числах
        private void IncCountOFDigit(ref int[] countOfDigit, int number)
        {
            foreach (char element in number.ToString())
                countOfDigit[element - '0']++;
        }
        public void TaskOne()
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
                    if ((border = HelpFunctions.GetBorder("Введите количество чисел: ", 0, 20)) == -1)
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
                    int[] countOfDigit = new int[10];
                    int number = 0;
                    for (int i = 0; i < border;)
                    {
                        Console.WriteLine($"Количество чисел необходимо ввести: {border - i}");
                        if (HelpFunctions.InputNumber(ref number))
                        {
                            IncCountOFDigit(ref countOfDigit, number);
                            i++;
                        }
                        Console.Clear();
                    }
                    int maxCount = 0;
                    int result = 0;
                    for (int i = 0; i < 10; i++)
                        if (countOfDigit[i] >= maxCount)
                        {
                            maxCount = countOfDigit[i];
                            result = i;
                        }
                    Console.WriteLine();
                    Console.WriteLine($"Цифра {result} встречалась {maxCount} раз");
                    Console.WriteLine();
                }
                menuExit.Print();
                choice = menuExit.Choice();
                Console.Clear();
            } while (choice != 0);
        }
        public void TaskTwo()
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
                    if ((border = HelpFunctions.GetBorder("Введите длину массива; ", 0, 20)) == -1)
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
                    bool is_sorted_inc = true;
                    bool is_sorted_des = true;
                    int numberFirst = 0;
                    int numberSecond = 0;
                    Console.WriteLine($"Количество чисел необходимо ввести: {border}");
                    while (!HelpFunctions.InputNumber(ref numberFirst))
                    {
                        Console.Clear();
                        Console.WriteLine($"Количество чисел необходимо ввести: {border}");
                    }

                    for (int i = 2; i <= border && (is_sorted_inc || is_sorted_des);)
                    {
                        Console.Clear();
                        Console.WriteLine($"Количество чисел необходимо ввести: {border - i}");
                        if (HelpFunctions.InputNumber(ref numberSecond))
                        {
                            i++;
                            is_sorted_inc = is_sorted_inc && numberFirst < numberSecond;
                            is_sorted_des = is_sorted_des && numberFirst > numberSecond;
                            numberFirst = numberSecond;
                        }
                        else
                        {
                            Console.WriteLine("Для продолжения введите нажмите Enter...");
                            Console.ReadLine();
                        }
                    }
                    Console.Clear();
                    Console.Write("В данной последовательсти элементы ");
                    Console.WriteLine((!is_sorted_inc && !is_sorted_des) ? "ни как не упорядочены" : (is_sorted_inc ? "упорядочены по возрастанию" : "упорядочены по убыванию"));
                    Console.WriteLine();
                }
                menuExit.Print();
                choice = menuExit.Choice();
                Console.Clear();
            } while (choice != 0);
        }
        private void TaskThreeSearchMin()
        {
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            int size;
            int number = 0;
            int minNumber = 101;
            int choice;
            do
            {
                if ((size = HelpFunctions.GetBorder("Введите длину массива: ", 0, 20)) == -1)
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return;
                }
                Console.Clear();
            } while (size == -1);
            while (Console.Read() != 10) ;
            if (size > 0)
            {
                for (int i = 0; i < size;)
                {
                    Console.Clear();
                    Console.WriteLine($"Количество чисел необходимо ввести: {size - i}");
                    if (HelpFunctions.InputNumber(ref number) && number >= -100 && number <= 100)
                    {
                        i++;
                        if (number < minNumber)
                            minNumber = number;
                    }
                    else 
                        HelpFunctions.Continue();
                }
                Console.WriteLine($"Минимальный элемент: {minNumber}");
                HelpFunctions.Continue();
            }
        }
        private void TaskThreeSearchMax()
        {
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            int size;
            int number = 0;
            int maxNumber = -101;
            int choice;
            do
            {
                if ((size = HelpFunctions.GetBorder("Введите длину массива: ", 0, 20)) == -1)
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return;
                }
                Console.Clear();
            } while (size == -1);
            while (Console.Read() != 10) ;
            if (size > 0)
            {
                for (int i = 0; i < size;)
                {
                    Console.Clear();
                    Console.WriteLine($"Количество чисел необходимо ввести: {size - i}");
                    if (HelpFunctions.InputNumber(ref number) && number >= -100 && number <= 100)
                    {
                        i++;
                        if (number > maxNumber)
                            maxNumber = number;
                    }
                    else 
                        HelpFunctions.Continue();
                }
                Console.WriteLine($"Максимальный элемент: {maxNumber}");
                HelpFunctions.Continue();
            }
        }
        private void TaskThreeSearchMinNoOdd()
        {
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            int size;
            int number = 0;
            int minNumber = 101;
            int choice;
            do
            {
                if ((size = HelpFunctions.GetBorder("Введите длину массива: ", 0, 20)) == -1)
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return;
                }
                Console.Clear();
            } while (size == -1);
            while (Console.Read() != 10) ;
            if (size > 0)
            {
                for (int i = 0; i < size;)
                {
                    Console.Clear();
                    Console.WriteLine($"Количество чисел необходимо ввести: {size - i}");
                    if (HelpFunctions.InputNumber(ref number) && number >= -100 && number <= 100)
                    {
                        i++;
                        if (number > minNumber && number % 2 != 0)
                            minNumber = number;
                    }
                    else 
                        HelpFunctions.Continue();
                }
                Console.WriteLine($"Минимальный нечетный элемент: {minNumber}");
                HelpFunctions.Continue();
            }
        }
        private void TaskThreeSearchMinOdd()
        {
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            int size;
            int number = 0;
            int minNumber = 101;
            int choice;
            do
            {
                if ((size = HelpFunctions.GetBorder("Введите длину массива: ", 0, 20)) == -1)
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return;
                }
                Console.Clear();
            } while (size == -1);
            while (Console.Read() != 10) ;
            if (size > 0)
            {
                for (int i = 0; i < size;)
                {
                    Console.Clear();
                    Console.WriteLine($"Количество чисел необходимо ввести: {size - i}");
                    if (HelpFunctions.InputNumber(ref number) && number >= -100 && number <= 100)
                    {
                        i++;
                        if (number > minNumber && number % 2 == 0)
                            minNumber = number;
                    }
                    else
                        HelpFunctions.Continue();
                }
                Console.WriteLine($"Минимальный четный элемент: { minNumber}");
                HelpFunctions.Continue();
            }
        }
        private void TaskThreeSeachMinAndMaxAndSwap()
        {
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            int size;
            int minNumber = 101;
            int maxNumber = -101;
            int choice;
            do
            {
                if ((size = HelpFunctions.GetBorder("Введите длину массива: ", 0, 20)) == -1)
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return;
                }
                Console.Clear();
            } while (size == -1);
            while (Console.Read() != 10) ;
            if (size > 0)
            {
                int[] masNumbers = new int[size];
                for (int i = 0; i < size;)
                {
                    Console.Clear();
                    Console.WriteLine($"Количество чисел необходимо ввести: {size - i}");
                    if (HelpFunctions.InputNumber(ref masNumbers[i]) && masNumbers[i] >= -100 && masNumbers[i] <= 100)
                        i++;
                    else
                        HelpFunctions.Continue();
                }
                int posMin = 0;
                int posMax = 0;
                for (int i = 0; i < size; i++)
                {
                    if (masNumbers[i] < minNumber)
                    {
                        minNumber = masNumbers[i];
                        posMin = i;
                    }
                    else if (masNumbers[i] > maxNumber)
                    {
                        maxNumber = masNumbers[i];
                        posMax = i;
                    }
                }
                Console.Clear();
                Console.WriteLine("Введенный вами массив: ");
                foreach (int element in masNumbers)
                {
                    Console.Write(element);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine($"Минимальный элемент: {masNumbers[posMin]}");
                Console.WriteLine($"Максимальный элемент: {masNumbers[posMax]}");
                int a = masNumbers[posMin];
                masNumbers[posMin] = masNumbers[posMax];
                masNumbers[posMax] = a;
                Console.WriteLine("Массив после перестановки: ");
                foreach (int element in masNumbers)
                {
                    Console.Write(element);
                    Console.Write(" ");
                }
                Console.WriteLine();
                HelpFunctions.Continue();
            }
        }
        public void TaskThree()
        {
            int choice;
            Menu menuDoing = new Menu("Выберите действие:");
            menuDoing.Add("Найти минимальный элемент");
            menuDoing.Add("Найти максимальный элемент");
            menuDoing.Add("Найти минимальное нечетное");
            menuDoing.Add("Найти минимальное четное");
            menuDoing.Add("Найти минимальный и максимальный элементы и поменять их местами");
            menuDoing.Add("Выйти в меню", true);
            do
            {
                Console.Clear();
                menuDoing.Print();
                choice = menuDoing.Choice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        TaskThreeSearchMin();
                        break;
                    case 2:
                        TaskThreeSearchMax();
                        break;
                    case 3:
                        TaskThreeSearchMinNoOdd();
                        break;
                    case 4:
                        TaskThreeSearchMinOdd();
                        break;
                    case 5:
                        TaskThreeSeachMinAndMaxAndSwap();
                        break;
                }
                Console.Clear();
            } while (choice != 0);
        }
        private bool InitOrderedMass(ref int[] mass, ref int size, ref bool is_sorted_inc)
        {
            int choice;
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            do
            {
                if ((size = HelpFunctions.GetBorder("Введите длину массива: ", 0, 20)) == -1)
                {
                    mainMenu.Print();
                    choice = mainMenu.Choice();
                    if (choice == 0)
                        return false;
                }
                Console.Clear();
            } while (size == -1);
            while (Console.Read() != 10) ;
            if (size == 0)
            {
                Console.WriteLine("Массив является пустым");
                return false;
            }
            is_sorted_inc = true;
            bool is_sorted_des = true;
            mass = new int[size];
            Console.WriteLine($"Количество чисел необходимо ввести: {size}");
            while (!HelpFunctions.InputNumber(ref mass[0]))
            {
                Console.Clear();
                Console.WriteLine($"Количество чисел необходимо ввести: {size}");
            }
            for (int i = 1; i < size && (is_sorted_inc || is_sorted_des);)
            {
                Console.Clear();
                Console.WriteLine($"Количество чисел необходимо ввести: {size - i}");
                if (HelpFunctions.InputNumber(ref mass[i]))
                {
                    is_sorted_inc = is_sorted_inc && mass[i - 1] < mass[i];
                    is_sorted_des = is_sorted_des && mass[i - 1] > mass[i];
                    i++;
                }
                else
                    HelpFunctions.Continue();
            }
            if (!is_sorted_inc && !is_sorted_des)
            {
                Console.WriteLine("Данный массив не является упорядоченным");
                return false;
            }
            return true;

        }

        /// <summary>
        /// Функция по слиянию двух массивов
        /// </summary>
        /// <param name="firstMass"> Первый упорядоченный массив</param>
        /// <param name="secondMass">Второй упорядоченный массив</param>
        /// <param name="firstSize">Размер первого массива</param>
        /// <param name="secondSize">размер второго массива</param>
        /// <param name="stepFirst">Изменение шага прохода по первому массиву</param>
        /// <param name="stepSecond">Изменение шага прохода по второму массиву</param>
        /// <param name="borderInFirst">Значение с которого мы начинаем перебирать первый массив</param>
        /// <param name="borderInSecond">значение с которого мы начинаем перебирать второй массив</param>
        /// <param name="borderOutFirst">граница по которую мы перебираем первый массив</param>
        /// <param name="borderOutSecond">гранница по которую мы перебираем второй массив</param>
        /// <param name="CompareToFirst">функция сравнения для первого массива</param>
        /// <param name="CompareToSecond">функция сравнения для второго массива</param>
        /// <param name="CompareTo">функция сравнения двух чисел</param>
        /// <returns></returns>
        private int[] MergeHelp(int[] firstMass, int[] secondMass, int stepFirst, int stepSecond, int borderInFirst,
                                        int borderInSecond, int borderOutFirst, int borderOutSecond, Func<int, int, bool> CompareToFirst,
                                        Func<int, int, bool> CompareToSecond, Func<int, int, bool> CompareTo)
        {
            int i = borderInFirst, j = borderInSecond, k = 0;
            int[] result = new int[firstMass.Length + secondMass.Length];
            while (CompareToFirst(i, borderOutFirst) && CompareToSecond(j, borderOutSecond))
            {
                if (CompareTo(firstMass[i], secondMass[j]))
                {
                    result[k] = firstMass[i];
                    i += stepFirst;
                }
                else
                {
                    result[k] = secondMass[j];
                    j += stepSecond;
                }
                k++;
            }
            while (CompareToFirst(i, borderOutFirst))
            {
                result[k] = firstMass[i];
                i += stepFirst;
                k++;
            }
            while (CompareToSecond(j, borderOutSecond))
            {
                result[k] = secondMass[j];
                j += stepSecond;
                k++;
            }
            return result;
        }
        private bool CompareToMore(int a, int b)
        {
            return a >= b;
        }
        private bool CompareToLess(int a, int b)
        {
            return a < b;
        }
        private int[] Merge(int[] firstMass, int[] secondMass, bool is_sorted_inc_first, bool is_sorted_inc_second, Func<int, int, bool> CompareTo)
        {
            int[] result = new int[firstMass.Length + secondMass.Length];
            if (is_sorted_inc_first && is_sorted_inc_second)
                result = MergeHelp(firstMass, secondMass, 1, 1, 0, 0, firstMass.Length, secondMass.Length, CompareToLess, CompareToLess, CompareTo);
            else if (!is_sorted_inc_first && !is_sorted_inc_second)
                result = MergeHelp(firstMass, secondMass, -1, -1, firstMass.Length - 1, secondMass.Length - 1, 0, 0, CompareToMore, CompareToMore, CompareTo);
            else if (is_sorted_inc_first)
                result = MergeHelp(firstMass, secondMass, 1, -1, 0, secondMass.Length - 1, firstMass.Length, 0, CompareToLess, CompareToMore, CompareTo);
            else
                result = MergeHelp(firstMass, secondMass, -1, 1, firstMass.Length - 1, 0, 0, secondMass.Length, CompareToMore, CompareToLess, CompareTo);

            return result;
        }
        public void TaskFour()
        {
            int choice;
            int firstBorder = 0;
            int secondBorder = 0;
            int[] firstMass = null;
            int[] secondMass = null;
            bool is_sorted_inc_first = true;
            bool is_sorted_inc_second = true;
            bool isCorrectFirst;
            bool isCorrectSecond;
            bool isRepeat = false;
            Menu menuExit = new Menu("Выберите дейтсвие");
            menuExit.Add("Запустить ещё раз");
            menuExit.Add("Выйти в меню", true);
            Menu menuRepeat = new Menu("Инициализировать массив ещё раз? ");
            menuRepeat.Add("Да");
            menuRepeat.Add("Нет", true);
            Menu menuSorted = new Menu("Выберите сортировку для результирующего массива:");
            menuSorted.Add("Упорядочить по возрастанию");
            menuSorted.Add("Упорядочить по убыванию");
            do
            {
                do
                {
                    do
                    {
                        Console.WriteLine("Инициализация первого массива:");
                        if (!(isCorrectFirst = InitOrderedMass(ref firstMass, ref firstBorder, ref is_sorted_inc_first)))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Первый массив не инициализирован");
                            menuRepeat.Print();
                            choice = menuRepeat.Choice();
                            Console.Clear();
                            isRepeat = choice == 0 ? true : false;
                        }
                    } while (isRepeat);
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("Инициализация второго массива:");
                        if (!(isCorrectSecond = InitOrderedMass(ref secondMass, ref secondBorder, ref is_sorted_inc_second)))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Первый массив не инициализирован");
                            menuRepeat.Print();
                            choice = menuRepeat.Choice();
                            Console.Clear();
                            isRepeat = choice == 0 ? true : false;
                        }
                    } while (isRepeat);
                    if (!isCorrectFirst && !isCorrectSecond)
                    {
                        menuRepeat.ChangeTheme("Оба массива не инициализированны. Повторить ввод?");
                        menuRepeat.Print();
                        choice = menuRepeat.Choice();
                        if (choice == 0)
                            return;
                        Console.Clear();
                    }
                    menuRepeat.ChangeTheme("Инициализировать массив ещё раз? ");
                } while (!isCorrectFirst && !isCorrectSecond);
                int[] result = null;
                Console.Clear();
                menuSorted.Print();
                switch (menuSorted.Choice())
                {
                    case 1:
                        result = Merge(firstMass, secondMass, is_sorted_inc_first, is_sorted_inc_second, CompareToLess);
                        break;
                    case 2:
                        result = Merge(firstMass, secondMass, is_sorted_inc_first, is_sorted_inc_second, CompareToMore);
                        break;
                }
                Console.Clear();
                Console.Write("Первый введенный массив: ");
                foreach (int element in firstMass)
                {
                    Console.Write(element);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.Write("Второй введенный массив: ");
                foreach (int element in secondMass)
                {
                    Console.Write(element);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.Write("Результирующий введенный массив: ");
                foreach (int element in result)
                {
                    Console.Write(element);
                    Console.Write(" ");
                }
                Console.WriteLine();
                HelpFunctions.Continue();
                Console.Clear();
                menuExit.Print();
                choice = menuExit.Choice();
                Console.Clear();
            } while (choice != 0);
        }
        private bool CheckFileName(string fileName)
        {
            foreach (char symbol in fileName)
                if ((symbol == '/') || (symbol == '\\') || (symbol == ':') || (symbol == '*') || (symbol == '?') || (symbol == '«') || (symbol == '<') || (symbol == '>') || (symbol == '|'))
                {
                    Console.WriteLine($"Введен некорректный символ: {symbol}");
                    return false;
                }
            return true;
        }
        private string InputFileName(string message)
        {
            Menu menuRepeat = new Menu("Повторить ввод?");
            menuRepeat.Add("Да");
            menuRepeat.Add("Нет", true);
            bool isRepeat;
            string fileName;
            do
            {
                Console.Write(message);
                fileName = Console.ReadLine();
                if (!(isRepeat = CheckFileName(fileName)))
                {
                    Console.WriteLine();
                    menuRepeat.Print();
                    if (menuRepeat.Choice() == 0)
                        return null;
                    Console.Clear();
                }
            } while (!isRepeat);
            return fileName;
        }
        private int[] Resize(int[] mass)
        {
            int[] result = new int[mass.Length + 10];
            for (int i = 0; i < mass.Length; i++)
                result[i] = mass[i];
            return result;
        }
        private bool ProcessingString(ref int[] mass, string line, ref int count)
        {
            int pos = 0;
            int number = 0;
            while (pos < line.Length)
            {
                if ((count + 1) == mass.Length)
                    mass = Resize(mass);
                if (!char.IsDigit(line[pos]) && line[pos] != ' ')
                {
                    Console.WriteLine($"При считывании из файла обнаружен некорректный символ: {line[pos]}");
                    return false;
                }
                if (line[pos] == ' ')
                {
                    mass[count] = number;
                    count++;
                    number = 0;
                }
                else
                    number = number * 10 + (line[pos] - '0');
                pos++;
            }
            return true;
        }
        private void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        private int[] Sort(int[] array, int length, Func<int, int, bool> CompareTo)
        {
            int d = array.Length / 2;
            while (d >= 1)
            {
                for (int i = d; i < array.Length; i++)
                {
                    int j = i;
                    while ((j >= d) && (CompareTo(array[j - d], array[j])))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }
        public void TaskFive()
        {
            string inputFileName;
            bool isCorrect;
            int[] mass;
            Menu menuRepeat = new Menu("Повторить ввод из файла?");
            menuRepeat.Add("Да");
            menuRepeat.Add("Нет", true);
            int count = 0;
            do
            {
                isCorrect = true;
                mass = new int[10];
                if ((inputFileName = InputFileName("Введите имя файла входных данных: ")) == null)
                    return;
                if (!File.Exists(inputFileName))
                {
                    Console.WriteLine("Данного файла не существует");
                    Console.WriteLine();
                    menuRepeat.Print();
                    if (menuRepeat.Choice() == 0)
                        return;
                    Console.Clear();
                }
                try
                {
                    using (StreamReader fileIn = new StreamReader(inputFileName))
                    {
                        string line;
                        while ((line = fileIn.ReadLine()) != null && isCorrect)
                        {
                            if (!(isCorrect = ProcessingString(ref mass, line, ref count)))
                            {
                                Console.WriteLine();
                                menuRepeat.Print();
                                if (menuRepeat.Choice() == 0)
                                    return;
                            }
                        }
                    }
                }
                catch
                {
                    isCorrect = false;
                    Console.WriteLine("Неудалось открыть файл");
                    menuRepeat.Print();
                    if (menuRepeat.Choice() == 0)
                        return;
                }
            } while (!isCorrect);
            mass = Sort(mass, count, CompareToMore);
            Console.Clear();
            Menu menuOutput = new Menu("Выберите действие: ");
            menuOutput.Add("Вывести упорядоченный массив в тот же массив");
            menuOutput.Add("Вывести упорядоченный массив в другой файл");
            menuOutput.Add("Выйти в меню", true);
            int choice;
            string outputFileName = null;
            Menu menuCreate = new Menu("Данного файла не существует. Создать новый?");
            menuCreate.Add("Да");
            menuCreate.Add("Нет");
            do
            {
                menuOutput.Print();
                choice = menuOutput.Choice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        outputFileName = inputFileName;
                        break;
                    case 2:
                        outputFileName = InputFileName("Введите имя файла для вывода данных: ");
                        break;
                    case 3:
                        return;
                }
                if (!File.Exists(outputFileName))
                {
                    menuCreate.Print();
                    if (menuCreate.Choice() == 1)
                    {
                        FileStream fileOut = new FileStream(outputFileName, FileMode.Create);
                        fileOut.Close();
                    }
                }
                using (StreamWriter fileOut = new StreamWriter(outputFileName))
                {
                    for (int i = 0; i < count; i++)
                    {
                        fileOut.Write(mass[i]);
                        fileOut.Write(" ");
                    }
                }
                Console.Clear();
            } while (outputFileName == null || choice != 0);
        }
        public void TaskSix()
        {
            string inputFileName;
            bool isCorrect;
            int[] mass;
            Menu menuRepeat = new Menu("Повторить ввод из файла?");
            menuRepeat.Add("Да");
            menuRepeat.Add("Нет", true);
            int count = 0;
            do
            {
                isCorrect = true;
                mass = new int[10];
                if ((inputFileName = InputFileName("Введите имя файла входных данных: ")) == null)
                    return;
                if (!File.Exists(inputFileName))
                {
                    Console.WriteLine("Данного файла не существует");
                    Console.WriteLine();
                    menuRepeat.Print();
                    if (menuRepeat.Choice() == 0)
                        return;
                    Console.Clear();
                }
                try
                {
                    using (StreamReader fileIn = new StreamReader(inputFileName))
                    {
                        string line;
                        while ((line = fileIn.ReadLine()) != null && isCorrect)
                        {
                            if (!(isCorrect = ProcessingString(ref mass, line, ref count)))
                            {
                                Console.WriteLine();
                                menuRepeat.Print();
                                if (menuRepeat.Choice() == 0)
                                    return;
                            }
                        }
                    }
                }
                catch
                {
                    isCorrect = false;
                    Console.WriteLine("Неудалось открыть файл");
                    menuRepeat.Print();
                    if (menuRepeat.Choice() == 0)
                        return;
                }
            } while (!isCorrect);
            mass = Sort(mass, count, CompareToLess);
            Console.Clear();
            Menu menuOutput = new Menu("Выберите действие: ");
            menuOutput.Add("Вывести упорядоченный массив в тот же массив");
            menuOutput.Add("Вывести упорядоченный массив в другой файл");
            menuOutput.Add("Выйти в меню", true);
            int choice;
            string outputFileName = null;
            Menu menuCreate = new Menu("Данного файла не существует. Создать новый?");
            menuCreate.Add("Да");
            menuCreate.Add("Нет");
            do
            {
                menuOutput.Print();
                choice = menuOutput.Choice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        outputFileName = inputFileName;
                        break;
                    case 2:
                        outputFileName = InputFileName("Введите имя файла для вывода данных: ");
                        break;
                    case 3:
                        return;
                }
                if (!File.Exists(outputFileName))
                {
                    menuCreate.Print();
                    if (menuCreate.Choice() == 1)
                    {
                        FileStream fileOut = new FileStream(outputFileName, FileMode.Create);
                        fileOut.Close();
                    }
                }
                using (StreamWriter fileOut = new StreamWriter(outputFileName))
                {
                    for (int i = 0; i < count; i++)
                    {
                        fileOut.Write(mass[i]);
                        fileOut.Write(" ");
                    }
                }
                Console.Clear();
            } while (outputFileName == null || choice != 0);
        }
        private int[] KeyBoardInit(int size)
        {
            int[] result = new int[size];
            for (int i = 0; i < size;)
            {
                Console.Clear();
                Console.WriteLine($"Количество чисел необходимо ввести: {size - i}");
                if (HelpFunctions.InputNumber(ref result[i]))
                    i++;
                else
                    HelpFunctions.Continue();
            }
            return result;
        }
        private int[] RandomInit(int size)
        {
            int[] result = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
                result[i] = rand.Next(100);
            return result;

        }
        private int[] ShiftRight(int[] array, int cnt)
        {
            int elem;
            int[] result = new int[array.Length];
            array.CopyTo(result, 0);
            for(int i = 0; i < cnt; i++)
            {
                elem = result[result.Length - 1];
                for (int j = result.Length - 1; j > 0; j--)
                    result[j] = result[j - 1];
                result[0] = elem;
            }
            return result;
        }
        private int[] ShiftLeft(int[] array, int cnt)
        {
            int elem;
            int[] result = new int[array.Length];
            array.CopyTo(result, 0);
            for (int i = 0; i < cnt; i++)
            {
                elem = result[0];
                for (int j = 0; j < result.Length - 1; j++)
                    result[j] = result[j + 1];
                result[result.Length - 1] = elem;
            }
            return result;
        }
        private void PrintMass(string message, int[] array)
        {
            Console.WriteLine(message);
            foreach (int element in array)
            {
                Console.Write(element);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public void TaskSeven()
        {
            int size;
            int m;
            int choice;
            Menu mainMenu = new Menu("Повторить ввод границы?");
            mainMenu.Add("Да, ввести границу заново");
            mainMenu.Add("Нет, выйти в меню", true);
            Menu menuDoing = new Menu("Выберите: ");
            menuDoing.Add("Сдвинуть направо");
            menuDoing.Add("Сдвинуть налево");
            menuDoing.Add("Обновить данные");
            menuDoing.Add("Выйти в меню", true);
            Menu menuExit = new Menu("Запустить ещё раз?");
            menuExit.Add("Да");
            menuExit.Add("Нет", true);
            Menu menuInit = new Menu("Выберите способ задания массива: ");
            menuInit.Add("Ввести массив с клавиатуры");
            menuInit.Add("Задать данные из массива с помощью функции random");
            do
            {
                do
                {
                    if ((size = HelpFunctions.GetBorder("Введите длинну массива: ")) == -1)
                    {
                        mainMenu.Print();
                        choice = mainMenu.Choice();
                        if (choice == 0)
                            return;
                    }
                    Console.Clear();
                } while (size == -1);
                while (Console.Read() != 10) ;
                if (size > 0)
                {
                    Console.Clear();
                    menuInit.Print();
                    choice = menuInit.Choice();
                    int[] array = null;
                    switch (choice)
                    {
                        case 0:
                            array = KeyBoardInit(size);
                            break;
                        case 1:
                            Console.Clear();
                            array = RandomInit(size);
                            Console.WriteLine("Ваш массив: ");
                            foreach(int element in array)
                            {
                                Console.Write(element);
                                Console.Write(" ");
                            }
                            Console.WriteLine();
                            HelpFunctions.Continue();
                            break;
                    }
                    Console.Clear();
                    do
                    {
                        if ((m = HelpFunctions.GetBorder("Введите количество чисел, на которое нужно сдвинуть массив: ", 0, size)) == -1)
                        {
                            mainMenu.Print();
                            choice = mainMenu.Choice();
                            if (choice == 0)
                                return;
                        }
                        Console.Clear();
                    } while (m == -1);
                    int[] result = new int[size];
                    while (Console.Read() != 10) ;
                    do
                    {
                        Console.Clear();
                        menuDoing.Print();
                        choice = menuDoing.Choice();
                        Console.Clear();
                        switch (choice)
                        {
                            case 1:
                                result = ShiftRight(array, m);
                                PrintMass("Массив до сдвига: ", array);
                                PrintMass("Получившийся массив после сдвига: ", result);
                                HelpFunctions.Continue();
                                break;
                            case 2:
                                result = ShiftLeft(array, m);
                                PrintMass("Массив до сдвига: ", array);
                                PrintMass("Получившийся массив после сдвига: ", result);
                                HelpFunctions.Continue();
                                break;
                            case 0:
                                return;
                        }

                    } while (choice != 3);
                }
                else
                {
                    Console.Clear();
                    menuExit.Print();
                    choice = menuExit.Choice();
                    Console.Clear();
                }
            } while (choice != 0);
        }
    }
}
