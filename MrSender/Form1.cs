using MrSender.Properties;
using NLog;
using NLog.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;



namespace MrSender
{

    public partial class Form1 : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string _defaultPath = Path.Combine(@"C:\","Soft","Koresh");
        private TelegramBotClient _bot;
        private string[] _fileList;
        private Dictionary<string, string> _passwords = new Dictionary<string, string>();
        private string _passwordFile = Path.Combine(Settings.Default.RemotePath,"passwords.cfg");
        private bool _emergencyStop, _imWorking, _canWriteToPath = false;
        bool minimizedToTray;
        private HttpClient _client;
        private HttpClientHandler handler;
        private WebProxy proxy;
        //private string _logFile = Path.Combine(Settings.Default.RemotePath, $"Лог рассылки {DateTime.Now:yyyyddMM_HH_mm}.log");
        private Encoding _defaultEnc = Encoding.GetEncoding("windows-1251");


        protected override void WndProc(ref Message message)
        {
            if (message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                ShowWindow();
            }
            base.WndProc(ref message);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeBot()
        {
            if (!string.IsNullOrWhiteSpace(Settings.Default.ProxyHost))
            {
                proxy = new WebProxy
                {
                    Address = new Uri($"http://{Settings.Default.ProxyHost}:{Settings.Default.ProxyPort.ToString()}"),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false,

                    // *** These creds are given to the proxy server, not the web server ***
                    Credentials = new NetworkCredential(
                        userName: Settings.Default.ProxyUser,
                        password: Settings.Default.ProxyPassword)
                };
                handler = new HttpClientHandler {Proxy = proxy};
                _client = new HttpClient(handler);

                //_bot = new TelegramBotClient(Settings.Default.BotToken);
                _bot = new TelegramBotClient(Settings.Default.BotToken, _client);
            }
            else
            {
                _bot = new TelegramBotClient(Settings.Default.BotToken);
            }
        }

        private async Task SendMessage(string pernr, long chatId, string text)
        {
            try
            {
                await _bot.SendTextMessageAsync(chatId, text, ParseMode.Html);
                if (!checkLog.Checked) Logger.Info($"{PernrName(pernr)} - {chatId.ToString()} - сообщение успешно отправлено");
            }
            catch (Exception er)
            {
                Logger.Error($"{PernrName(pernr)} - {chatId.ToString()} - {er.Message}");
            }
        }

        private async Task SendFile(string pernr, long chatId, string filePath)
        {
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                    await _bot.SendPhotoAsync(
                        chatId: chatId,
                        photo: new InputOnlineFile(fileStream, fileName)
                    //caption: "Nice Picture"
                    );
                }
                if (!checkLog.Checked) Logger.Info($"{PernrName(pernr)} - {chatId.ToString()} - файл успешно отправлен"); 
            }
            catch (Exception er)
            {
                Logger.Error($"{PernrName(pernr)} - {chatId.ToString()} - {er.Message}");
            }
        }

        private async Task SendPhoto(string pernr, long chatId, Bitmap bmp)
        {
            try
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    bmp.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    memStream.Position = 0;
                    await _bot.SendPhotoAsync(
                        chatId: chatId,
                        photo: memStream
                    );
                }
                if (!checkLog.Checked) Logger.Info($"{PernrName(pernr)} - {chatId.ToString()} - изображение успешно отправлено");
            }
            catch (Exception er)
            {
                Logger.Error($"{PernrName(pernr)} - {chatId.ToString()} - {er.Message} {er.InnerException?.InnerException?.Message}");
            }
        }

        private async Task SendMail(string element)
        {
            string body = "Доброго дня!<br><br>" +
            "Цей лист сформовано автоматично, не відповідайте на нього. <br><br>" +
            "Ваш розрахунковий листок знаходиться у прикріпленому до цього листа файлі. <br><br>" +
            "Якщо Ви ще не отримували пароль, то спробуйте '123qaz' (без лапок).<br>" +
            "Отримати новий чи відновити втрачений пароль можна кожного дня у Вашого бухгалтера. <br>" +
            "Будь-ласка з 8:00 до 17:00 (п'ятниця до 15:45), окрім вихідних та свят.<br><br>" +
            "Набридло вводити щоразу пароль? Встановіть собі месенджер <a href=\"https://telegram.org/\">Telegram</a> та під'єднайтеся <br>" +
            "до офіційного <a href=\"https://t.me/ukrtatnafta_bot\">чат-бота</a>. Обов'язково повідомте про це Вашого бухгалтера!<br><br>" +
            "Гарного дня!";

            if (!string.IsNullOrWhiteSpace(textMsg.Text)) body += $"<br><br>P.S. {textMsg.Text}";

            //string subj = PernrName(element);
            string subj = AttachmentName(element); 

            var client = new SmtpClient();
            var message = new MailMessage();
            Attachment data = new Attachment(ConvertToPdf(element), AttachmentName(element)+".pdf", MediaTypeNames.Application.Pdf);

            client.Host = Settings.Default.SmtpHost;
            client.Port = Convert.ToInt16(Settings.Default.SmtpPort);
            client.Credentials = new NetworkCredential(Settings.Default.SmtpUser, Settings.Default.SmtpPassword);
            client.Timeout = 10000;

            message.From = new MailAddress(Settings.Default.SmptFrom, "ПАТ 'Укртатнафта'", Encoding.Default);

            //message.To.Add(new MailAddress("koreshock@ukrtatnafta.com"));
            message.To.Add(new MailAddress(Path.GetFileNameWithoutExtension(element).Trim()));


            message.Subject = subj;
            message.IsBodyHtml = true;
            message.Body = body;
            message.Attachments.Add(data);
            message.Priority = MailPriority.High;

            try
            {
                await client.SendMailAsync(message);
                if (!checkLog.Checked) Logger.Info($"{PernrName(element)} - {message.To} - письмо успешно отправлено");
                await Task.Delay(Convert.ToInt16(1000 / mailCount.Value));
            }
            catch (Exception ex)
            {
                Logger.Error($"{PernrName(element)} - {ex.Message}");
            }
            finally
            {
                message.Attachments.Dispose();
                DeleteFile(element);
            }
        }

        private void DeleteFile(string element)
        {
            try
            {
                File.Delete(element);
            }
            catch
            {
                Logger.Error($"Невозможно удалить файл {element}");
            }
        }

        private async Task TelegramSend(string element)
        {
            try
            {
                string text = File.ReadAllText(element, _defaultEnc).TrimEnd();
                long chatId = Convert.ToInt64(Path.GetFileNameWithoutExtension(element).Trim());
                Bitmap bmp = new Bitmap(1, 1);
                Graphics graphics = Graphics.FromImage(bmp);
                Font font = new Font(Settings.Default.FontName, Settings.Default.FontSize);
                SizeF stringSize = graphics.MeasureString(text, font);
                bmp = new Bitmap(bmp, (int)stringSize.Width, (int)stringSize.Height);
                graphics = Graphics.FromImage(bmp);
                graphics.Clear(Color.White);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                //graphics.DrawString(txt, font, new SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0);
                graphics.DrawString(text, font, Brushes.Black, 0, 0);
                font.Dispose();
                graphics.Flush();
                graphics.Dispose();

                if (!string.IsNullOrWhiteSpace(textMsg.Text))
                {
                    await SendMessage(element,chatId, textMsg.Text);
                }
                await SendPhoto(element,chatId, bmp);

                await Task.Delay(Convert.ToInt16(1000 / MessageCount.Value));
            }
            catch (Exception er)
            {
                Logger.Error($"{PernrName(element)} - {er.Message}");
            }
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            BtnSend.Enabled = false;
            btnStop.Enabled = true;
            btnReload.Enabled = false;
            _imWorking = true;
            int count = 0;
            int total = _fileList.Length;
            FillPasswords();
                       
            try
            {
                foreach (string element in _fileList)
                {
                    if (!File.Exists(element))
                    {
                        Logger.Error($"{element} не найден.");
                        continue;
                    }

                    if (!_emergencyStop)
                    {
                        if (element.Contains("@"))
                        {
                            await SendMail(element);
                        }
                        else
                        {
                            await TelegramSend(element);
                            DeleteFile(element);
                        }
                        count++;
                        toolStripStatusLabel1.Text = $"{count} файлов из {total} обработано.";
                        statusStrip1.Refresh();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception er)
            {
                Logger.Error(er.Message);
            }


            if (!_emergencyStop)
            {
                Logger.Info("<Конец рассылки>");
                DeleteFile(_passwordFile);
            }
            else
            {
                Array.Clear(_fileList, 0, total);
                Logger.Warn("<Рассылка прервана пользователем>");
            }
            _passwords.Clear();
            _emergencyStop = false;
            btnReload.Enabled = true;
            btnStop.Enabled = false;
            _imWorking = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(_defaultPath))
            {
                try
                {
                    Directory.CreateDirectory(_defaultPath);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }

            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile")
                {
                    FileName = Path.Combine(Settings.Default.RemotePath,$"Лог рассылки {DateTime.Now:yyyyddMM_HH_mm}.log"),
                    Layout = "${date:format=MM-dd-yyyy HH\\:MM\\:ss} - ${level} - ${message}",
                    AutoFlush = true
                };

            RichTextBoxTarget target = new RichTextBoxTarget()
            {
                FormName = "Form1", // your winform class name
                ControlName = "rtbLog", // your RichTextBox control/variable name
                AutoScroll = true,
                Layout = "${date:format=MM-dd-yyyy HH\\:MM\\:ss} - ${message}",
                UseDefaultRowColoringRules = false,
            };

            target.RowColoringRules.Add
                (new RichTextBoxRowColoringRule
                    (
                        "level >= LogLevel.Warning", // condition
                        "Red", // font color
                        "InactiveBorder" // back color
                    )
                );

            config.AddTarget("richTextBox", target);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, target);
            LogManager.Configuration = config;

            if (NoSettingsError(Settings.Default.BotToken, "Токен telegram бота не заполнен!")
                & NoSettingsError(Settings.Default.SmtpHost, "SMTP хост не заполнен!")
                & NoSettingsError(Settings.Default.SmtpUser, "SMTP user не указан!")
                & NoSettingsError(Settings.Default.SmtpPort.ToString(), "SMTP порт не заполнен!"))
            {
                InitializeBot();
                LoadFiles();
                _canWriteToPath = DirectoryHasPermission(RemotePath.Text, FileSystemRights.Write);
                if (!_canWriteToPath) 
                    Logger.Error($"Нет прав записи в каталог {RemotePath.Text}!"); 
            }
            else
            {
                btnReload.Enabled = false;
                btnReload.Enabled = false;
                BtnSend.Enabled = false;
            }
        }

        private bool NoSettingsError(string element, string message)
        {
            if (string.IsNullOrWhiteSpace(element))
            {
                Logger.Error($"{message} Рассылка невозможна.");
                return false;
            }
            return true;
        }

        private void LoadFiles()
        {
            if (string.IsNullOrWhiteSpace(RemotePath.Text))
                RemotePath.Text = _defaultPath;
            
            if (!Directory.Exists(RemotePath.Text))
            {
                try
                {
                    Directory.CreateDirectory(RemotePath.Text);
                }
                catch
                {
                    Logger.Error($"Невозможно создать каталог {RemotePath.Text}. Обратитесь к системному администратору.");
                    RemotePath.Text = "C:";
                };
            }
            
            _fileList = Directory.GetFiles(RemotePath.Text, "*.txt");

            string telegramPattern = @"\d+";
            //string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            _fileList = _fileList.Where(fileName =>
            {
                fileName = Path.GetFileNameWithoutExtension(fileName).Trim();
                return Regex.IsMatch(fileName, telegramPattern, RegexOptions.IgnoreCase) | Regex.IsMatch(fileName, emailPattern, RegexOptions.IgnoreCase);
            }).ToArray();

            if (_fileList.Length > 0)
            {
                BtnSend.Enabled = true;
                toolStripStatusLabel1.Text = string.Concat(_fileList.Length, " файла(ов) для рассылки.");
            }
            else
            {
                BtnSend.Enabled = false;
                toolStripStatusLabel1.Text = "Нет файлов для рассылки.";
            }
        }

        public static bool DirectoryHasPermission(string DirectoryPath, FileSystemRights AccessRight)
        {
            if (string.IsNullOrEmpty(DirectoryPath)) return false;

            try
            {
                AuthorizationRuleCollection rules = Directory.GetAccessControl(DirectoryPath).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                WindowsIdentity identity = WindowsIdentity.GetCurrent();

                foreach (FileSystemAccessRule rule in rules)
                {
                    if (identity.Groups.Contains(rule.IdentityReference))
                    {
                        if ((AccessRight & rule.FileSystemRights) == AccessRight)
                        {
                            if (rule.AccessControlType == AccessControlType.Allow)
                                return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
            }
            return false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogManager.Shutdown();
            Settings.Default.Save();
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            RemotePath.Text = folderBrowser.SelectedPath;
            LoadFiles();
        }

        private MemoryStream ConvertToPdf(string element)
        {
            int FontSize = 8;
            string FontName = "Courier New";
            //string filename;
            var stream = new MemoryStream();

            var logFile = File.ReadAllLines(element, _defaultEnc);

            using (PdfDocument document = new PdfDocument())
            {
                LayoutHelper helper = new LayoutHelper(document, XUnit.FromCentimeter(1), XUnit.FromCentimeter(21 - 1));
                XUnit left = XUnit.FromCentimeter(1);
                document.Info.Title = AttachmentName(element);
                document.Info.Author = "ПАТ 'Укртатнафта'";

                XFont font = new XFont(FontName, FontSize);

                foreach (string line in logFile)
                {
                    XUnit top = helper.GetLinePosition(FontSize, FontSize + 5);
                    helper.Gfx.DrawString(line, font, XBrushes.Black, left, top, XStringFormats.TopLeft);
                }

                helper.Gfx.Dispose();
                string watermark = "конфіденційно";
                XFont font1 = new XFont("Verdana", 80);
                var gfx = XGraphics.FromPdfPage(helper.Page, XGraphicsPdfPageOptions.Prepend);
                var size = gfx.MeasureString(watermark, font1);

                gfx.TranslateTransform(helper.Page.Width / 2, helper.Page.Height / 2);
                gfx.RotateTransform(-Math.Atan(helper.Page.Height / helper.Page.Width) * 180 / Math.PI);
                gfx.TranslateTransform(-helper.Page.Width / 2, -helper.Page.Height / 2);

                var format = new XStringFormat
                {
                    Alignment = XStringAlignment.Near,
                    LineAlignment = XLineAlignment.Near
                };

                XBrush brush = new XSolidBrush(XColor.FromArgb(40, 255, 0, 0));

                gfx.DrawString(watermark, font1, brush, new XPoint((helper.Page.Width - size.Width) / 2, (helper.Page.Height - size.Height) / 2), format);

                PdfSecuritySettings securitySettings = document.SecuritySettings;

                securitySettings.UserPassword = GetPassword(element);
                securitySettings.OwnerPassword = "b[8sr}$TyC";

                securitySettings.PermitAccessibilityExtractContent = false;
                securitySettings.PermitAnnotations = false;
                securitySettings.PermitAssembleDocument = false;
                securitySettings.PermitExtractContent = false;
                securitySettings.PermitFormsFill = false;
                securitySettings.PermitFullQualityPrint = true;
                securitySettings.PermitModifyDocument = false;
                securitySettings.PermitPrint = true;

                document.Save(stream);
            }
            //return filename;
            return stream;
        }

        public string AttachmentName(string s)
        {
            try
            {
                File.ReadAllLines(s, _defaultEnc).AsParallel()
                .ForAll(pair =>
                {
                    pair.Trim();
                    int a = pair.IndexOf("р.");
                    if ((a > 0) && (pair.Length > 0) && (pair.StartsWith("РОЗРАХУНКОВИЙ")))
                        s = pair.Substring(0, a).ToLower().Trim();
                });
            }
            catch (Exception er)
            {
                Logger.Error(er.Message);
            }
          
            if (s.Length > 0) return (char.ToUpper(s[0]) + s.Substring(1));
            else return "Розрахунковий листок";
        }

        public string PernrName(string s)
        {
            File.ReadAllLines(s, _defaultEnc).AsParallel()
                .ForAll(pair =>
                {
                    pair.Trim();
                    if ((pair.Length > 0) && (pair.StartsWith("Табельний")))
                       s = pair.Substring(16, 24).Trim();
                });
          
            if (s.Length > 0) return "т.н."+s;
            else return "XXXX";
        }

        private string GetPassword(string element)
        {
            //string key = Path.GetFileNameWithoutExtension(element);
            //if (_passwords.ContainsKey(key))
            //    return _passwords[key];
            //WriteLog($"Пароль для {key} не обнаружен, использован пароль по умолчанию.");
            //return "123qaz";

            string pass = string.Empty;
            string key = Path.GetFileNameWithoutExtension(element);
            if (_passwords.ContainsKey(key))
                pass = _passwords[key];
            if (string.IsNullOrEmpty(pass))
            {
                Logger.Warn($"Пароль для {key} не обнаружен, использован пароль по умолчанию.");
                pass = "123qaz";
            }
            return pass;
        }

        private void FillPasswords()
        {
            if (File.Exists(_passwordFile))
            {
                _passwords = File.ReadAllLines(_passwordFile, _defaultEnc)
                        .Select(pair => pair.Trim())
                        .Where(p => (p.Length >= 9))
                        .Select(p => new { key = p.Substring(0, p.Length - 9), val = p.Substring(p.Length - 8) })
                        .Where(p => (Regex.IsMatch(p.val, @"\d+", RegexOptions.IgnoreCase)))
                        .GroupBy(p => p.key)                            
                        .ToDictionary(p => p.Key, p => p.Select(i => i.val).FirstOrDefault());
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _emergencyStop = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_imWorking)
            {
                if (MessageBox.Show("Прервать рассылку?", "Процесс не завершен", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _emergencyStop = true;
                e.Cancel = true;
            }
        }

        void MinimizeToTray()
        {
            notifyIcon.Text = ProgramInfo.AssemblyTitle;
            notifyIcon.Visible = true;
            this.Hide();
            minimizedToTray = true;
        }

        public void ShowWindow()
        {
            if (minimizedToTray)
            {
                notifyIcon.Visible = false;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                minimizedToTray = false;
            }
            else
            {
                WinApi.ShowToFront(this.Handle);
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if ((checkTray.Checked)&&(this.WindowState == FormWindowState.Minimized))
               MinimizeToTray(); 
        }
    }
    
}