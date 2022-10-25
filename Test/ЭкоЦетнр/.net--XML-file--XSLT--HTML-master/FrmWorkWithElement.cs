using System;
using System.Windows.Forms;

namespace project
{
    public partial class FrmWorkWithElement : Form
    {
        //данные о книге, которые мы передаем, в случае, если нам нужно изменить данные
        string[] Info;

        //жанные о книге, которые пользователь ввел в данной форме
        public string[] result { get; private set; }

        //список всех книг для того чтобы заполнить comboBox. Это нужно для того чтобы пользователю можно было выбрать автора и категорию из уже ранне введенных
        BookList Booklist;

        public FrmWorkWithElement(string filePath, string[] info = null)
        {
            InitializeComponent();
            result = new string[5];

            //убираем возможность пользователю изменять как либо размеры формы
            MaximizeBox = false;
            MinimizeBox = false;
            MaximumSize = Size;
            MinimumSize = Size;
            Info = info;
            //заполняем comboBox из уже ранне введных данных
            //если файл не был открыт, то ничего не делаем
            if (filePath != null)
            {
                Booklist = new BookList();
                Booklist.LoadXML(filePath);
                foreach (Book element in Booklist.list)
                {
                    foreach (string Author in element.Author)
                        comboBox1.Items.Add(Author);
                    comboBox2.Items.Add(element.Category);
                }
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
        }

        //обработка события нажатия на кнопку отмены
        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //функция проверки данных, которые ввел пользователь на корректность
        private bool Check()
        {
            bool ok;
            //попытка преобразовать введеные данные, в случае неудачи выскакивает MessageBox
            try
            {
                float price = float.Parse(textBox4.Text);
                ok = true;
            }
            catch
            {
                MessageBox.Show("Некорректно введенная цена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //попытка преобразовать введеные данные, в случае неудачи выскакивает MessageBox
            try
            {
                int year = Convert.ToInt32(textBox5.Text);
                ok = true;
            }
            catch
            {
                MessageBox.Show("Некорректно введенный год", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //проверяем ввел ли что то пользователь, или оставил textBox пустым
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Введите название книги", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //проверяем выбрал ли что то пользователь, или оставил textBox пустым
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите автора", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //проверяем выбрал ли что то пользователь, или оставил textBox пустым
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите категорию", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return ok;
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            //запускаем проверку данных, которые ввел пользователь
            // если все хорошо, то запоминаем данные и закрываем форму
            if (Check())
            {
                result[0] = textBox1.Text;
                result[1] = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                result[2] = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                result[3] = textBox5.Text;
                result[4] = textBox4.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FrmWorkWithElement_Load(object sender, EventArgs e)
        {
            if (Info != null)
            {
                textBox1.Text = Info[0];
                textBox5.Text = Info[3];
                textBox4.Text = Info[4];
            }

        }
    }
}
