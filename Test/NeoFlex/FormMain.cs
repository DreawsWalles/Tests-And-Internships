using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormMain : Form
    {
        private bool _isWork = false;
        private Random rnd = new Random();
        public FormMain()
        {
            InitializeComponent();
            textFile.Enabled = false;
            btnStartStop.Enabled = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 24, Size.Height - 43);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            panel1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            textFile.Size = new Size(panel1.Width - 70, panel1.Height - 50);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 24, Size.Height - 43);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            panel1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            textFile.Size = new Size(panel1.Width - 70, panel1.Height - 50);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Введите текст, необходимый для вставки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!_isWork)
            {
                _isWork = true;
                Thread thread = new Thread(new ThreadStart(MainTask));
                thread.Start();
            }
            else
            {
                _isWork = false;
            }
        }
        private void MainTask()
        {
            Invoke(new Action(() =>
            {
                textBox.Enabled = false;
                btnStartStop.Text = "Остановить";
                btnLoad.Enabled = false;
            }));
            while (_isWork)
            {
                Thread.Sleep(5000);
                textBox.Invoke((MethodInvoker)delegate
                {
                    textFile.Text = textFile.Text.Insert(rnd.Next(0, textFile.Text.Length - 1), textBox.Text);
                });                
            }
            Invoke(new Action(() =>
            {
                btnStartStop.Text = "Запустить";
                btnLoad.Enabled = true;
                textBox.Enabled = true;
            }));
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Text Files(*.TXT)|*.TXT";
                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader file = new StreamReader(fileDialog.FileName))
                        {
                            textFile.Text = file.ReadToEnd();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("При считывании информации из файла произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    textFile.Enabled = true;
                    btnStartStop.Enabled = true;
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isWork = false;
        }
    }
}
