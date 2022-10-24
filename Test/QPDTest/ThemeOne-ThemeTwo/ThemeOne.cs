using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace ThemeOne_ThemeTwo
{
    public class ThemeOne
    {
        public ThemeOne()
        {
            Console.WriteLine("Вопросы по теме:");
            Console.WriteLine();
            Console.WriteLine("1. Основные ппреимущества .net");
            Console.WriteLine("2. Как происходит выполнение кода в среде CLR?");
            Console.WriteLine("3. Что такое сборка?");
            Console.WriteLine("4. Как выглядит объединение управляемых модулей в сборку?");
            Console.WriteLine("5. Что в .net отвечает за создание машинного кода и в какой момет сборки это происходит?");
            Console.WriteLine("6. Что такое NGen?");
            Console.WriteLine("7. Что такое методанные?");
            Console.WriteLine("8. Как происходит объединение модулей при создании сборки?");
            Console.WriteLine("9. Расскажите о сборках. На какие два типа их можно негласно поделить?");
            Console.WriteLine("10. Расскажите про приватное развертывание");
            Console.WriteLine("11. Расскажите про сборку со строгим именем");
            Console.WriteLine("12. Зачем нужно отложенное подписание и как оно работает?");
            Console.WriteLine("13. Расскажите про политику издателя. Зачем она нужна и что из себя представляет");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            HelpFunctions.Continue();
        }
    }
}
