using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shuffle
{
    public partial class Form1 : Form
    {
        private string[] _fileList;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            RemotePath.Text = folderBrowser.SelectedPath;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void ReadListOfFiles()
        {
            if (string.IsNullOrWhiteSpace(RemotePath.Text))
            {
                RemotePath.Text = @"C:\";
            }
            if (Directory.Exists(RemotePath.Text))
            {
                _fileList = Directory.GetFiles(RemotePath.Text, "*.txt");
            }
            string telegramPattern = @"\d+";
            string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

                bool isNotFour(string fileName)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName).Trim();
                    return Regex.IsMatch(fileName, telegramPattern, RegexOptions.IgnoreCase) | Regex.IsMatch(fileName, emailPattern, RegexOptions.IgnoreCase);
                }
            _fileList = Array.FindAll(_fileList, isNotFour).ToArray();

            if (_fileList.Length > 0)
            {
                btnShuffle.Enabled = true;
                toolStripStatusLabel1.Text = string.Concat(_fileList.Length, " файла(ов) для обработки.");
            }
            else
            {
                btnShuffle.Enabled = false;
                toolStripStatusLabel1.Text = "Нет файлов для обработки.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadListOfFiles();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            int count = 1;
            foreach (string element in _fileList)
            {
                string text = File.ReadAllText(element, Encoding.GetEncoding("windows-1251")).TrimEnd();
                //newtext = Regex.Replace(text, @"\d", "*");
                var newtext = Regex.Replace(text, @"\d{6},\d{2}", "   ***,**");
                newtext = Regex.Replace(newtext, @"\d{5},\d{2}", "  ***,**");
                newtext = Regex.Replace(newtext, @"\d{4},\d{2}", " ***,**");
                newtext = Regex.Replace(newtext, @"\d{3},\d{2}", "***,**");
                File.WriteAllText(element, newtext, Encoding.GetEncoding("windows-1251"));
                count++;
                toolStripStatusLabel1.Text = $"{count} файлов обработано.";
                statusStrip1.Refresh();
            }
            toolStripStatusLabel1.Text = "Все файлы обработаны.";
            ReadListOfFiles();
        }
    }
}
