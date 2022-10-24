using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace ThemeOne_ThemeTwo
{
    public class ThemeTwo
    {
        public void FirstBlock()
        {
            Menu menu = new Menu("Выберите задачу: ");
            menu.Add("Ввести трехзначное число. Посчитать сумму цифр, вывести на экран.");
            menu.Add("Вводить числа, пока не будет введен ноль. Вывести число с максимальной суммой цифр в нем.");
            menu.Add("Ввести n чисел (n задается пользователем). Посчитать сумму трех первых нечетных.");
            menu.Add("Ввести n чисел (n задается пользователем). Посчитать сумму трех последних нечетных.");
            menu.Add("Ввести m и n, где m и n - два целых числа не больше 20. Нарисовать звездочками на кране.");
            menu.Add("Посчитать сумму ряда.");
            menu.Add("Посчитать сумму  6 + 10 + 14 + ................... + 46. Сколько слагаемых?");
            menu.Add("Посчитать сумму  6 + 10 + 14 + ...................   , всего 10 слагаемых.");
            menu.Add("Посчитать сумму 1+2+4+8+16+....., всего 11 слагаемых.");
            menu.Add("Посчитать сумму  6 + 10 + 14 + ..................., Остановиться, когда сумма превысит 100. Сколько слагаемых?");
            menu.Add("Посчитать сумму  6 + 10 + 14 + ..................., последнюю, которая еще не превышает 100. Сколько слагаемых?");
            menu.Add("Посчитать сумму первых n чисел Фиббоначи: 1 + 1 + 2 + 3 + 5 + 8 +  13 + … n задается пользователем");
            menu.Add("Вернуться назад", true);
            int choice;
            ThemeTwoBlockOne BlockOne = null;
            do
            {
                Console.Clear();
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
                if (choice != 0 && BlockOne == null)
                    BlockOne = new ThemeTwoBlockOne();
                switch (choice)
                {
                    case 1:
                        BlockOne.TaskOne();
                        break;
                    case 2:
                        BlockOne.TaskTwo();
                        break;
                    case 3:
                        BlockOne.TaskThree();
                        break;
                    case 4:
                        BlockOne.TaskFour();
                        break;
                    case 5:
                        BlockOne.TaskFive();
                        break;
                    case 6:
                        BlockOne.TaskSix();
                        break;
                    case 7:
                        BlockOne.TaskSeven();
                        break;
                    case 8:
                        BlockOne.TaskEight();
                        break;
                    case 9:
                        BlockOne.TaskNine();
                        break;
                    case 10:
                        BlockOne.TaskTen();
                        break;
                    case 11:
                        BlockOne.TaskEleven();
                        break;
                    case 12:
                        BlockOne.TaskTwelve();
                        break;

                }
            } while (choice != 0);
        }
        private void SecondBlock()
        {
            Menu menu = new Menu("Выберите задачу: ");
            menu.Add("Вернуться назад", true);
            menu.Add("Ввести n целых чисел (n задается пользователем). Какая цифра встречается чаще других? Если таких цифр несколько – вывести ту из них, которая обозначает наибольшее число, а " +
                "также сколько раз она встретилась.");
            menu.Add("Ввести массив целых чисел. Длина массива задается пользователем. Определить, упорядочен ли он по возрастанию. По убыванию?");
            menu.Add("Ввести массив целых чисел в диапазоне [-100,100]. Длина массива задается пользователем. Выполнить поиск определнныъ элементов.");
            menu.Add("Ввести два упорядоченных массива (контроль за корректностью ввода). Слить их в один упорядоченный массив без использования сортировки.");
            menu.Add("Считать из файла массив целых чисел. Упорядочить по возрастанию. Вывести обратно в файл.");
            menu.Add("Считать из файла массив целых чисел. Упорядочить по убыванию. Вывести обратно в файл.");
            menu.Add("Сдвинуть массив [1..n] циклически влево (вправо) на m позиций. «Падающие» элементы должны уходить в хвост (в голову).");
            int choice;
            ThemeTwoBlockTwo BlockTwo = null;
            do
            {
                Console.Clear();
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
                if (choice != 0 && BlockTwo == null)
                    BlockTwo = new ThemeTwoBlockTwo();
                switch(choice)
                {
                    case 1:
                        BlockTwo.TaskOne();
                        break;
                    case 2:
                        BlockTwo.TaskTwo();
                        break;
                    case 3:
                        BlockTwo.TaskThree();
                        break;
                    case 4:
                        BlockTwo.TaskFour();
                        break;
                    case 5:
                        BlockTwo.TaskFive();
                        break;
                    case 6:
                        BlockTwo.TaskSix();
                        break;
                    case 7:
                        BlockTwo.TaskSeven();
                        break;
                }
            } while (choice != 0);

        }
        private void ThirdBlock()
        {
            Menu menu = new Menu("Выберите задачу: ");
            menu.Add("Даны переменные \r\n" +
                     "\thello = \"Привет!\"\r\n" +
                     "\tname = \"Меня зовут...\"\r\n" +
                     "\tage = \"Мне... лет\"\r\n" +
                     "Оперируя переменными составить полноценное предложение всеми возможными способами (форматирование, интерполяция)");
            menu.Add("Дан массив строк [\"apple\", \"banana\", \"orange\", \"kiwi\", \"mango\"] \r\n" +
                     "\t- Вывести все значения через запятую" +
                     "\t- Вывести все значения построчно");
            menu.Add("Сравнить две строки и вывести результат сравнения\r\n" +
                "\t- \"привет\" и \"здравствуйте\"\r\n" +
                "\t- \"двацдать\" и \"двенадцать\"\r\n" +
                "\t- \"синус\" и \"синусоида\"\r\n" +
                "\t- \"14\" и \"81\"");
            menu.Add("Найти в строке индекс первого вхождения буквы: \"о\"\r\n" +
                "\t- \"Хорошо в лесу...\"\r\n" +
                "\t- \"Эх, дороги, пыль да туман\"\r\n" +
                "\t- \"Семнадцать вариантов решения\"");
            menu.Add("Найти в строке индекс последнего вхождения буквы: \"у\"\r\n" +
                "\t- \"Где такое интересное место ?\"\r\n" +
                "\t- \"У меня дома есть ноутбук.\"\r\n" +
                "\t- \"Винтажный стул\"\r\n");
            menu.Add("Вставить в строку другую строку\r\n" +
                "\t- \"Какой... день\"\r\n" +
                "\t- \"замечательный\"");
            menu.Add("Заменить в строке слово \"магазин\" на \"парк\"\r\n" +
                "\t- \"Привет, я иду в магазин\"");
            menu.Add("Удалить из строки слово \"большого\"\r\n" +
                "\t- \"Сегодня в зоопарке я видел большого жирафа\"");
            menu.Add("Привести предложение: \"ПрыгаЮщие БуквЫ к нижнему\", а затем к верхнему регистру");
            menu.Add("Разделить строку на элементы массива\r\n" +
                "\t- \"Первый рабочий день прошел на ура\"");
            menu.Add("Выйти в главное меню", true);
            int choice;
            ThemeTwoBlockThree BlockThree = null;
            do
            {
                Console.Clear();
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
                if (choice != 0 && BlockThree == null)
                    BlockThree = new ThemeTwoBlockThree();
                switch (choice)
                {
                    case 1:
                        BlockThree.TaskOne();
                        break;
                    case 2:
                        BlockThree.TaskTwo();
                        break;
                    case 3:
                        BlockThree.TaskThree();
                        break;
                    case 4:
                        BlockThree.TaskFour();
                        break;
                    case 5:
                        BlockThree.TaskFive();
                        break;
                    case 6:
                        BlockThree.TaskSix();
                        break;
                    case 7:
                        BlockThree.TaskSeven();
                        break;
                    case 8:
                        BlockThree.TaskEight();
                        break;
                    case 9:
                        BlockThree.TaskNine();
                        break;
                    case 10:
                        BlockThree.TaskTen();
                        break;
                }
            } while (choice != 0);
        }
        private void FourthBlock()
        {
            Console.WriteLine("Вопросы по данной теме:");
            Console.WriteLine();
            Console.WriteLine("1. Как чем являются все переменные в .net?");
            Console.WriteLine("2. Чем является имя переменной? В какой момент под переменную выделяется памяться?");
            Console.WriteLine("3. В чем различие между массивами на платформе Win32 и .net?");
            Console.WriteLine("4. В чем основной плюс при работе с массивами в .net?");
            Console.WriteLine("5. Работа с enum. Как можно обратиться к элементу в перечислениях?");
            Console.WriteLine("6. Работа с оператором switch. В каких случаях стоит использовать данный оператор?");
            Console.WriteLine("7. Напишите тернарный опреатор для вывода в консоль");
            Console.WriteLine("8. Работа с break и continue.");
            Console.WriteLine("9. Напишите алгоритм нахождения среднего арифметического последовательности чисел");
            Console.WriteLine();
            HelpFunctions.Continue();
        }
        public ThemeTwo()
        {
            Menu menu = new Menu("Выберите блок заданий: ");
            menu.Add("Основы C#");
            menu.Add("Массивы");
            menu.Add("Строки");
            menu.Add("Вопросы по данной теме");
            menu.Add("Вернуться в главное меню", true);
            int choice;
            do
            {
                Console.Clear();
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        FirstBlock();
                        break;
                    case 2:
                        SecondBlock();
                        break;
                    case 3:
                        ThirdBlock();
                        break;
                    case 4:
                        FourthBlock();
                        break;
                }
            } while (choice != 0);
        }
    }
}
