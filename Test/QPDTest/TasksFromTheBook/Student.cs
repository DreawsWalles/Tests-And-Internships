using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFromTheBook
{
    public struct subject
    {
        public string name;
        public int mark;
        public subject(string name, int mark)
        {
            this.name = name;
            this.mark = mark;
        }
        public int CompareTo(subject obj)
        {
            return name.CompareTo(obj);
        }
    };
    class Student
    {
        static int StudentsCount;
        public string Name { get; set; }
        public string Sername { get; set; }
        private int group;
        private int course;
        private subject[] subjects;
        static Student()
        {
            StudentsCount = 0;
        }

        public Student(string name, string sername, int group, int course, params subject[] marks)
        {
            StudentsCount++;
            Init(name, sername, group, course, marks);
        }
        public Student():this("", "", 1, 1, new subject("Математика", 5), new subject("Алгоритмы и структуры данных", 5), new subject("Базы данных", 5))
        {

        }
        public double AverageOfMarks()
        {
            double result = 0;
            foreach (subject element in subjects)
                result += element.mark;
            return result / subjects.Length;
        }
        public void AverageOfMarks(out double result)
        {
            result = 0;
            foreach (subject element in subjects)
                result += element.mark;
            result /= subjects.Length;
        }
        private void Init(string name, string sername, int group, int course, params subject[] marks)
        {
            this.subjects = marks;
            Name = name;
            Sername = sername;
            this.group = group;
            this.course = course;
        }
        public void Update(string name, string sername, int group, int course, params subject[] marks)
        {
            Init(name, sername, group, course, marks);
        }
        public override string ToString()
        {
            string result;
            result = $"Имая: {Name}\r\nФамилия: {Sername}";
            result += $"Группа: {group}\r\nКурс: {course}";
            result += "Успеваемость: ";
            foreach (subject element in subjects)
                result += $"Предмет: {element.name}, Оценка: {element.mark}";
            return result;
        }
        public new bool Equals(Object obj)
        {
            Student student = (Student)obj;
            if (Name.CompareTo(student.Name) == 0 && Sername.CompareTo(student.Sername) == 0 && group == student.group && course == student.course && subjects.Length == student.subjects.Length)
                for (int i = 0; i < subjects.Length; i++)
                    if (subjects[i].CompareTo(student.subjects[i]) != 0)
                        return false;
            return true;
        }
    }
}
