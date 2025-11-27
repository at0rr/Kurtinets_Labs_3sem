using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_4
{
    public partial class Form1 : Form
    {

        private List<string> words = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Text File";
            openFileDialog.Filter = "TXT files|*.txt"; 
            openFileDialog.InitialDirectory = @"C:\Users\romak\OneDrive\Рабочий стол\Lab_4\Lab_4";

            if (openFileDialog.ShowDialog() == DialogResult.OK)  
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    
                    string content = File.ReadAllText(filePath, Encoding.Default);
                    string[] wordArray = content.Split(new char[] { ' ', '\t', '\r', '\n' });

                    foreach (string word in wordArray)
                    {
                        if (!words.Contains(word))
                        {
                            words.Add(word);
                        }
                    }
                    MessageBox.Show(string.Join(" ", words), "Список слов");
                    
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;

                    string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                        ts.Minutes, ts.Seconds, ts.Milliseconds);
                    textBox1.Text = $"Время выполнения: {elapsedTime}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (words.Count == 0)
            {
                MessageBox.Show("Сначала загрузите файл с помощью первой кнопки!");
                return;
            }


            string searchWord = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(searchWord))
            {
                MessageBox.Show("Введите слово для поиска!");
                return;
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            listBox1.BeginUpdate();
            try
            {

                listBox1.Items.Clear();

                bool foundAny = false;
                foreach (string word in words)
                {
                    if (word.Contains(searchWord))
                    {
                        listBox1.Items.Add(word);
                        foundAny = true;
                    }
                }

                if (!foundAny)
                {
                    listBox1.Items.Add("Такого слова нет в файле");
                }
                else
                {
                    MessageBox.Show("Слово присутствует в файле!");
                    this.Text = $"Найдено совпадений: {listBox1.Items.Count}";
                }
            }
            finally
            {
                listBox1.EndUpdate();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                    ts.Minutes, ts.Seconds, ts.Milliseconds);
            textBox3.Text = $"Время выполнения: {elapsedTime}";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
