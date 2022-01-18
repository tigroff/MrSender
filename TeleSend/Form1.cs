using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TeleSend
{
    public partial class Form1 : Form
    {
        private HashSet<long> _recepients;
        private string _file = "recepients.txt";
        private HttpClient _client;
        private HttpClientHandler _handler;
        private WebProxy _proxy;
        private TelegramBotClient _bot;
        private List<string> _logList = new List<string>();
        //test_bot - "1846625231:AAHEHYdFs6gFp-anJwIvUKId2tQ9Q0Bdc9E"
        //utn_bot - "683170386:AAHyiFXI8Uhkyv8NITbz6Py6V-Fp_yrr7Fs"


        public Form1()
        {
            InitializeComponent();
        }

        private void WriteLog(string text)
        {
            _logList.Add($"{DateTime.Now} - {text}{Environment.NewLine}");
        }

        private void InitializeBot()
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.ProxyHost))
            {
                _proxy = new WebProxy
                {
                    Address = new Uri($"http://{Properties.Settings.Default.ProxyHost}:{Properties.Settings.Default.ProxyPort.ToString()}"),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false,

                    // *** These creds are given to the proxy server, not the web server ***
                    Credentials = new NetworkCredential(
                        userName: Properties.Settings.Default.ProxyUser,
                        password: Properties.Settings.Default.ProxyPassword)
                };
                _handler = new HttpClientHandler { Proxy = _proxy };
                _client = new HttpClient(_handler);

                _bot = new TelegramBotClient(Properties.Settings.Default.BotToken, _client);
            }
            else
            {
                _bot = new TelegramBotClient(Properties.Settings.Default.BotToken);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBot();
            LoadFiles();
            toolStatus.Text = $"{_recepients.Count} уникальных номеров для рассылки.";
        }

        private void LoadFiles()
        {
            if (File.Exists(_file))
            {
                _recepients = new HashSet<long>(File.ReadAllLines(_file, Encoding.GetEncoding("windows-1251")).AsParallel().
                                Where(element => long.TryParse(element, out var _)).
                                Select(element => long.Parse(element)));
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllLines(_file, _recepients.Select(a => a.ToString()).ToArray());
            File.WriteAllLines($"Лог рассылки {DateTime.Now:yyyyddMM_HH_mm}.log", _logList);
        }

        private async Task SendMessage(long chatId, string text)
        {
            try
            {
                await _bot.SendTextMessageAsync(chatId, text, ParseMode.Html);
                WriteLog($"{chatId.ToString()} - сообщение успешно отправлено");
            }
            catch (Exception er)
            {
                WriteLog($"{chatId.ToString()} - {er.Message}");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;

            int count = 0;
            int total = _recepients.Count;

            foreach (long element in _recepients)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    await SendMessage(element, textBox.Text);
                }
                await Task.Delay(100);
                count++;
                    toolStatus.Text = $"{count} файлов из {total} обработано.";
                    statusStrip.Refresh();
            }
            btnSend.Enabled = true;
        }
    }
}
