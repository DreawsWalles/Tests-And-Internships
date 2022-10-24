using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace ThemeOne_ThemeTwo
{
     class ThemeTwoBlockThree
    {

        private void FormattingStrings(string hello, string name, string age)
        {
            Console.WriteLine("Формирование предложения с использованием форматирования строк: ");
            Console.WriteLine("{0} {1}. {2}", hello, name.Remove(name.Length - 3).Insert(name.Length - 3, "Андрей"), age.Remove(4, 3).Insert(4, "20"));
        }
        private void InterpolationStrings(string hello, string name, string age)
        {
            Console.WriteLine("Формирование предложения с использованием интерполяции строк: ");
            Console.WriteLine("Первый вариант:");
            string result = $"{hello} {name.Remove(name.Length - 3).Insert(name.Length - 3, "Андрей")}. {age.Remove(4, 3).Insert(4, "20")}";
            Console.WriteLine(result);
            Console.WriteLine("Второй вариант:");
            Console.WriteLine($"{hello} {name.Remove(name.Length - 3).Insert(name.Length - 3, "Андрей")}. {age.Remove(4, 3).Insert(4, "20")}");
        }
        public void TaskOne()
        {
            string hello = "Привет!";
            string name = "Меня зовут ...";
            string age = "Мне ... лет";
            FormattingStrings(hello, name, age);
            InterpolationStrings(hello, name, age);
            HelpFunctions.Continue();
        }
        public void TaskTwo()
        {
            string[] array = {"apple", "banana", "orange", "kiwi", "mango"};
            Console.WriteLine("Вывод текста через запятую: ");
            for (int i = 0; i < array.Length - 1; i++)
                Console.Write($"{array[i]}, ");
            Console.WriteLine(array[array.Length - 1]);
            Console.WriteLine("Вывод текста построчно:");
            foreach (string element in array)
                Console.WriteLine(element);
            HelpFunctions.Continue();
        }
        private void CompareStrings(string a, string b)
        {
            Console.WriteLine($"Сравнение строк \"{a}\" и \"{b}\":");
            switch (a.CompareTo(b))
            {
                case 0:
                    Console.WriteLine("Строчки равны");
                    break;
                case 1:
                    Console.WriteLine($"Слово \"{a}\" больше, чем слово \"{b}\"");
                    break;
                case -1:
                    Console.WriteLine($"Слово \"{b}\" больше, чем слово \"{a}\"");
                    break;
            }
            Console.WriteLine();
        }
        public void TaskThree()
        {
            string[] arrayOne = { "привет", "двацдать", "синус", "14" };
            string[] arrayTwo = { "здравствуйте", "двенадцать", "синусоида", "81" };
            for (int i = 0; i < arrayOne.Length; i++)
                CompareStrings(arrayOne[i],arrayTwo[i]);
            HelpFunctions.Continue();
        }

        private void SearchIndexFirstSymbol(string s, char symbol)
        {
            int pos = s.IndexOf(symbol);
            Console.WriteLine(pos == -1 ? $"В предложении \"{s}\" нет символа \"{symbol}\"" : $"Индекс первого вхождения буквы: \"о\" в предложении \"{s}\": {pos}");
        }
        public void TaskFour()
        {
            string[] array = { "Хорошо в лесу...", "Эх, дороги, пыль да туман", "Семнадцать вариантов решения" };
            foreach(string element in array)
                SearchIndexFirstSymbol(element, 'о');
            HelpFunctions.Continue();
        }
        private void SearchIndexLastSymbol(string s, char symbol)
        {
            int pos = s.LastIndexOf(symbol);
            Console.WriteLine(pos == -1 ? $"В предложении \"{s}\" нет символа \"{symbol}\"" : $"Индекс последнего вхождения буквы: \"у\" в предложении \"{s}\": {pos}");
        }
        public void TaskFive()
        {
            string[] array = { "Где такое интересное место?", "У меня дома есть ноутбук.", "Винтажный стул" };
            foreach(string element in array)
                SearchIndexLastSymbol(element, 'у');
            HelpFunctions.Continue();
        }
        public void TaskSix()
        {
            string sentenceOne = "Какой ... день";
            string sentenceTwo = "замечательный";
            Console.WriteLine($"Изначально имеем две строки \r\n Первая строка: \"{sentenceOne}\" \r\n Вторая строка: \"{sentenceTwo}\"");
            Console.WriteLine($"Вставляем эти две строки и получаем: \"{sentenceOne.Remove(sentenceOne.IndexOf('.'), 3).Insert(sentenceOne.IndexOf('.'), sentenceTwo)}\"");
        }
        public void TaskSeven()
        {
            string sentence = "Привет, я иду в магазин";
            Console.WriteLine($"Изначально имеем предложение: {sentence}");
            Console.WriteLine($"Теперь заменяем в нем слово \"магазин\" на слово \"парк\" и получаем: {sentence.Replace("магазин", "парк")}");
            HelpFunctions.Continue();
        }
        public void TaskEight()
        {
            string sentence = "Сегодня в зоопарке я видел большого жирафа";
            Console.WriteLine($"Изначально имеем предложение: {sentence}");
            Console.WriteLine($"Теперь удаляем слово \"большого\"и получаем: {sentence.Remove(sentence.IndexOf("большого"),"большого".Length + 1)}");
            HelpFunctions.Continue();
        }
        public void TaskNine()
        {
            string sentence = "ПрыгаЮщие БуквЫ";
            Console.WriteLine($"Изначально имеем предложение: {sentence}");
            Console.WriteLine($"Теперь приводим это предлоение к вернехму регистру: {sentence.ToUpper()}");
            Console.WriteLine($"Теперь приводим это предложение к нижнему регистру: {sentence.ToLower()}");
            HelpFunctions.Continue();
        }
        public void TaskTen()
        {
            string sentence = "Первый рабочий день прошел на ура";
            string[] array = sentence.Split(' ');
            Console.WriteLine($"Изначально имеем предложение: \"{sentence}\"");
            Console.WriteLine("Теперь разбиваем это предложение на слова и выводим их построчно:");
            foreach (string element in array)
                Console.WriteLine(element);
        }
    }
}
