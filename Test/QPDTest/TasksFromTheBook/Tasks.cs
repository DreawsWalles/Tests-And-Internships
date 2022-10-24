using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace TasksFromTheBook
{
    static public class Tasks
    {
        //Работа с Enum

        enum WeekDays
        {
            Monday, Tuesday, Wednesday,
            Thursday, Friday, Saturday, Sunday
        }
        static private void WorkWhithEnum()
        {
            string[] WeekDaysRussianNames = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
            WeekDays day = WeekDays.Thursday;

            Console.WriteLine("Сегодня " + day);
            Console.WriteLine("Сегодня " + WeekDaysRussianNames[(int)day]);
            int dayIndex = (int)day + 1;
            Console.WriteLine("Номер дня " + dayIndex);

            if (day == WeekDays.Friday)
                Console.WriteLine("Скоро выходной");
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            
        }
    }
}
