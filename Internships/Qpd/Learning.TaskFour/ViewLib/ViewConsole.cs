using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLib
{
    public class ViewConsole : IView
    {
        public void View(string question, string answer)
        {
            Console.WriteLine($"\n\nОтвет на запрос \"{question}\": {answer}");
            Console.Write("You->");
        }
    }
}
