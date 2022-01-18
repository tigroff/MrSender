namespace MrSender
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSend = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textMsg = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mailCount = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SmtpPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SmtpUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.smtpHost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MessageCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BotToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkTray = new System.Windows.Forms.CheckBox();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProxyPort = new System.Windows.Forms.NumericUpDown();
            this.RemotePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.ProxyHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mailCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(391, 277);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "&Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(480, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textMsg);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 91);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Дополнительное сообщение";
            // 
            // textMsg
            // 
            this.textMsg.Location = new System.Drawing.Point(6, 20);
            this.textMsg.Multiline = true;
            this.textMsg.Name = "textMsg";
            this.textMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textMsg.Size = new System.Drawing.Size(454, 65);
            this.textMsg.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 332);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxLog);
            this.tabPage1.Controls.Add(this.btnStop);
            this.tabPage1.Controls.Add(this.btnReload);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(472, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Рассылка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(9, 277);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "О&становить";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(310, 277);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "О&бновить";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LogBox);
            this.groupBox5.Location = new System.Drawing.Point(3, 103);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(466, 168);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "&Лог рассылки";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(6, 20);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(454, 142);
            this.LogBox.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(472, 306);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mailCount);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.SmtpPassword);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.SmtpUser);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.smtpHost);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(3, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(465, 123);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " e-mail ";
            // 
            // mailCount
            // 
            this.mailCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MrSender.Properties.Settings.Default, "MailCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mailCount.Location = new System.Drawing.Point(81, 96);
            this.mailCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mailCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mailCount.Name = "mailCount";
            this.mailCount.Size = new System.Drawing.Size(41, 20);
            this.mailCount.TabIndex = 13;
            this.mailCount.Value = global::MrSender.Properties.Settings.Default.MailCount;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(128, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "сообщений в секунду";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Отправлят&ь";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MrSender.Properties.Settings.Default, "SmptFrom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(97, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(164, 20);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = global::MrSender.Properties.Settings.Default.SmptFrom;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Отпра&витель:";
            // 
            // SmtpPassword
            // 
            this.SmtpPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MrSender.Properties.Settings.Default, "SmtpPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SmtpPassword.Location = new System.Drawing.Point(321, 43);
            this.SmtpPassword.Name = "SmtpPassword";
            this.SmtpPassword.PasswordChar = '*';
            this.SmtpPassword.ReadOnly = true;
            this.SmtpPassword.Size = new System.Drawing.Size(138, 20);
            this.SmtpPassword.TabIndex = 15;
            this.SmtpPassword.Text = global::MrSender.Properties.Settings.Default.SmtpPassword;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(267, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Паро&ль:";
            // 
            // SmtpUser
            // 
            this.SmtpUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MrSender.Properties.Settings.Default, "SmtpUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SmtpUser.Location = new System.Drawing.Point(97, 43);
            this.SmtpUser.Name = "SmtpUser";
            this.SmtpUser.ReadOnly = true;
            this.SmtpUser.Size = new System.Drawing.Size(164, 20);
            this.SmtpUser.TabIndex = 13;
            this.SmtpUser.Text = global::MrSender.Properties.Settings.Default.SmtpUser;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Поль&зователь:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MrSender.Properties.Settings.Default, "SmtpPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Location = new System.Drawing.Point(393, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = global::MrSender.Properties.Settings.Default.SmtpPort;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(354, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "&порт:";
            // 
            // smtpHost
            // 
            this.smtpHost.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MrSender.Properties.Settings.Default, "SmtpHost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smtpHost.Location = new System.Drawing.Point(48, 17);
            this.smtpHost.Name = "smtpHost";
            this.smtpHost.ReadOnly = true;
            this.smtpHost.Size = new System.Drawing.Size(300, 20);
            this.smtpHost.TabIndex = 1;
            this.smtpHost.Text = global::MrSender.Properties.Settings.Default.SmtpHost;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "&Хост:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MessageCount);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.BotToken);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(3, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 73);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Telegram ";
            // 
            // MessageCount
            // 
            this.MessageCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MrSender.Properties.Settings.Default, "MessageCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MessageCount.Location = new System.Drawing.Point(78, 44);
            this.MessageCount.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.MessageCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MessageCount.Name = "MessageCount";
            this.MessageCount.Size = new System.Drawing.Size(41, 20);
            this.MessageCount.TabIndex = 9;
            this.MessageCount.Value = global::MrSender.Properties.Settings.Default.MessageCount;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "сообщений в секунду";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Отпр&авлять";
            // 
            // BotToken
            // 
            this.BotToken.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MrSender.Properties.Settings.Default, "BotToken", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BotToken.Location = new System.Drawing.Point(79, 16);
            this.BotToken.Name = "BotToken";
            this.BotToken.ReadOnly = true;
            this.BotToken.Size = new System.Drawing.Size(381, 20);
            this.BotToken.TabIndex = 1;
            this.BotToken.Text = global::MrSender.Properties.Settings.Default.BotToken;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Токен бота:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkTray);
            this.groupBox2.Controls.Add(this.checkLog);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ProxyPort);
            this.groupBox2.Controls.Add(this.RemotePath);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnPath);
            this.groupBox2.Controls.Add(this.ProxyHost);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 92);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Общие ";
            // 
            // checkTray
            // 
            this.checkTray.AutoSize = true;
            this.checkTray.Checked = global::MrSender.Properties.Settings.Default.CheckTray;
            this.checkTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTray.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MrSender.Properties.Settings.Default, "CheckTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkTray.Location = new System.Drawing.Point(219, 69);
            this.checkTray.Name = "checkTray";
            this.checkTray.Size = new System.Drawing.Size(126, 17);
            this.checkTray.TabIndex = 11;
            this.checkTray.Text = "Свора&чивать в трей";
            this.checkTray.UseVisualStyleBackColor = true;
            // 
            // checkLog
            // 
            this.checkLog.AutoSize = true;
            this.checkLog.Checked = global::MrSender.Properties.Settings.Default.CheckErrorLog;
            this.checkLog.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MrSender.Properties.Settings.Default, "CheckErrorLog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkLog.Location = new System.Drawing.Point(9, 69);
            this.checkLog.Name = "checkLog";
            this.checkLog.Size = new System.Drawing.Size(184, 17);
            this.checkLog.TabIndex = 10;
            this.checkLog.Text = "В&ыводить в лог только ошибки";
            this.checkLog.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "П&уть к файлам:";
            // 
            // ProxyPort
            // 
            this.ProxyPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MrSender.Properties.Settings.Default, "ProxyPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProxyPort.Location = new System.Drawing.Point(394, 40);
            this.ProxyPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ProxyPort.Name = "ProxyPort";
            this.ProxyPort.ReadOnly = true;
            this.ProxyPort.Size = new System.Drawing.Size(66, 20);
            this.ProxyPort.TabIndex = 10;
            this.ProxyPort.Value = global::MrSender.Properties.Settings.Default.ProxyPort;
            // 
            // RemotePath
            // 
            this.RemotePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MrSender.Properties.Settings.Default, "RemotePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RemotePath.Location = new System.Drawing.Point(98, 13);
            this.RemotePath.Name = "RemotePath";
            this.RemotePath.ReadOnly = true;
            this.RemotePath.Size = new System.Drawing.Size(295, 20);
            this.RemotePath.TabIndex = 2;
            this.RemotePath.Text = global::MrSender.Properties.Settings.Default.RemotePath;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "п&орт:";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(399, 11);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(61, 23);
            this.btnPath.TabIndex = 9;
            this.btnPath.Text = "&Выбор";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // ProxyHost
            // 
            this.ProxyHost.Location = new System.Drawing.Point(60, 40);
            this.ProxyHost.Name = "ProxyHost";
            this.ProxyHost.ReadOnly = true;
            this.ProxyHost.Size = new System.Drawing.Size(289, 20);
            this.ProxyHost.TabIndex = 5;
            this.ProxyHost.Text = global::MrSender.Properties.Settings.Default.ProxyHost;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "П&рокси:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // folderBrowser
            // 
            this.folderBrowser.SelectedPath = global::MrSender.Properties.Settings.Default.RemotePath;
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Checked = true;
            this.checkBoxLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLog.Location = new System.Drawing.Point(171, 281);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(116, 17);
            this.checkBoxLog.TabIndex = 6;
            this.checkBoxLog.Text = "сле&дить за логом";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            this.checkBoxLog.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 357);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mr.Sender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mailCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textMsg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox BotToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RemotePath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ProxyHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ProxyPort;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkLog;
        private System.Windows.Forms.NumericUpDown MessageCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox smtpHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SmtpPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SmtpUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown mailCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox checkTray;
        private System.Windows.Forms.CheckBox checkBoxLog;
    }
}

