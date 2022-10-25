using System;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Diagnostics;

namespace project
{
    public partial class FrmMain : Form
    {

        BookList Booklist;
        string filePath = null;
        public FrmMain()
        {
            InitializeComponent();
            //запрещаем пользователю менять размеры формы
            MaximizeBox = false;
            MinimizeBox = false;    
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //инициализируем список книг
            Booklist = new BookList();
        }
        /// <summary>
        /// функция открытия файла
        /// </summary>
        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = ".xml";
            openFile.Filter = "XML files (*.xml)|*.xml"; //устанавливаем фильтр, чтобы пользовател не открыл не нужные нам файлы
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile.FileName;//извлекаем путь файла, с которым будем работать
                Booklist.LoadXML(filePath); //загружаем из файла в наш класс данные
                Load_dataGrifView(); // загружаем данные в DataGridView
            }
        }

        private void Load_dataGrifView()
        {
            dataGridView1.Rows.Clear(); //Очищаем DaraGridView
            foreach(Book element in Booklist.list) // Проходимся по всем элементам, что у нас есть и добавляем в DataGridView
                dataGridView1.Rows.Add(element.ToArrayString());                 
        }

        /// <summary>
        /// функция сохранения файла
        /// </summary>
        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".xml";
            saveFile.Filter = "XML files (*.xml)|*.xml"; //устанавливаем фильтр
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFile.FileName; //запоминаем имя, на тот случай, если вдруг пользователь ввел другое 
                Booklist.SaveXML(filePath); //сохраняем все данные
            }
        }

        /// <summary>
        /// функция открытия html отчета
        /// </summary>
        private void button_report_Click(object sender, EventArgs e)
        {
            //проверяем открыт ли файл
            if (filePath != null)
            {
                //загружаем таблицу стилей
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load("System/transform.xsl");

                //выполняем преобразование нашего xml файла с помощью xsl файла в html файд
                xslt.Transform(filePath, "System/books.html");
                //открываем страничку в баузере
                Process.Start(@"E:\OneDrive - ВГУ\C#\project.XML_file\project\bin\Debug\System\books.html");
            }
        }

        /// <summary>
        /// функция обработчик клика по ячейке в DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //проверяем что пользователь кликнул именно по ячейке
            if (e.RowIndex != -1)
            {
                //запускаем форму, для изменения данных
                FrmWorkWithElement form = new FrmWorkWithElement(filePath, Booklist.list[e.RowIndex].ToArrayString());
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK) //если пользователь удачно все изменил то и мы меняем данные
                {
                    Booklist.list[e.RowIndex] = new Book(form.result);
                    Load_dataGrifView();
                }
            }
        }

        /// <summary>
        /// функция удаления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_node_Click(object sender, EventArgs e)
        {
            //запускаем форму для ввода записи, которую нам нужно удалить
            FrmWorkWithElement form = new FrmWorkWithElement(filePath);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK) // если пользователь все правильно ввел, то мы пытаемся удалить запись и уведомлеяем пользователя о результате
            {
                if (Booklist.Remove(form.result))
                {
                    MessageBox.Show("Запись о книге успешно удалена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_dataGrifView();
                }
                else
                    MessageBox.Show("Запись о книге не удалось удалить", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// метод добавления записи
        /// </summary>
        private void button_add_node_Click(object sender, EventArgs e)
        {
            //запускаем формочку для ввода данных о книге
            FrmWorkWithElement form = new FrmWorkWithElement(filePath);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)//если пользователь все правильно ввел, то мы добавляем данные в DataGridView
            {
                Booklist.Add(new Book(form.result));
                dataGridView1.Rows.Add(Booklist.list[Booklist.list.Count - 1].ToArrayString());
            }
        }
    }
}
