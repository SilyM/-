namespace BMXGV0._1
{
    partial class F_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSpNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBaudRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDataBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStopBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsParity = new System.Windows.Forms.ToolStripStatusLabel();
            this.Connect = new System.Windows.Forms.Button();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStop = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PIN1 = new System.Windows.Forms.Button();
            this.PIN2 = new System.Windows.Forms.Button();
            this.PIN3 = new System.Windows.Forms.Button();
            this.PIN4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ReadPIN2 = new System.Windows.Forms.Button();
            this.ReadPIN4 = new System.Windows.Forms.Button();
            this.ReadPIN1 = new System.Windows.Forms.Button();
            this.ReadPIN3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EENum2 = new System.Windows.Forms.TextBox();
            this.DownMode = new System.Windows.Forms.ComboBox();
            this.EENum = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.WritePIN2 = new System.Windows.Forms.Button();
            this.WritePIN4 = new System.Windows.Forms.Button();
            this.WritePIN1 = new System.Windows.Forms.Button();
            this.WritePIN3 = new System.Windows.Forms.Button();
            this.tmSend = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.Connect);
            this.groupBox1.Controls.Add(this.cbSerial);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnSwitch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 173);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSpNum,
            this.tsBaudRate,
            this.tsDataBits,
            this.tsStopBits,
            this.tsParity});
            this.statusStrip1.Location = new System.Drawing.Point(3, 148);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(467, 22);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsSpNum
            // 
            this.tsSpNum.Name = "tsSpNum";
            this.tsSpNum.Size = new System.Drawing.Size(95, 17);
            this.tsSpNum.Text = "串口号：未指定|";
            // 
            // tsBaudRate
            // 
            this.tsBaudRate.Name = "tsBaudRate";
            this.tsBaudRate.Size = new System.Drawing.Size(86, 17);
            this.tsBaudRate.Text = "波特率:未指定|";
            // 
            // tsDataBits
            // 
            this.tsDataBits.Name = "tsDataBits";
            this.tsDataBits.Size = new System.Drawing.Size(86, 17);
            this.tsDataBits.Text = "数据位:未指定|";
            // 
            // tsStopBits
            // 
            this.tsStopBits.Name = "tsStopBits";
            this.tsStopBits.Size = new System.Drawing.Size(86, 17);
            this.tsStopBits.Text = "停止位:未指定|";
            // 
            // tsParity
            // 
            this.tsParity.Name = "tsParity";
            this.tsParity.Size = new System.Drawing.Size(86, 17);
            this.tsParity.Text = "停止位:未指定|";
            // 
            // Connect
            // 
            this.Connect.Font = new System.Drawing.Font("宋体", 12F);
            this.Connect.Location = new System.Drawing.Point(352, 30);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(99, 23);
            this.Connect.TabIndex = 22;
            this.Connect.Text = "连接";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // cbSerial
            // 
            this.cbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(85, 29);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(121, 24);
            this.cbSerial.TabIndex = 38;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbParity);
            this.groupBox3.Controls.Add(this.cbStop);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbDataBits);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbBaudRate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(26, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "串口设置";
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cbParity.Location = new System.Drawing.Point(275, 51);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(97, 24);
            this.cbParity.TabIndex = 37;
            // 
            // cbStop
            // 
            this.cbStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStop.Location = new System.Drawing.Point(97, 51);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(83, 24);
            this.cbStop.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(211, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 34;
            this.label8.Text = "校验位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(35, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 35;
            this.label7.Text = "停止位：";
            // 
            // cbDataBits
            // 
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(275, 25);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(97, 24);
            this.cbDataBits.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(212, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "数据位：";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(97, 25);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(83, 24);
            this.cbBaudRate.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(35, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "波特率:";
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(234, 30);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(99, 23);
            this.btnSwitch.TabIndex = 2;
            this.btnSwitch.Text = "打开串口";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口：";
            // 
            // PIN1
            // 
            this.PIN1.Font = new System.Drawing.Font("宋体", 9F);
            this.PIN1.Location = new System.Drawing.Point(6, 52);
            this.PIN1.Name = "PIN1";
            this.PIN1.Size = new System.Drawing.Size(113, 38);
            this.PIN1.TabIndex = 17;
            this.PIN1.Text = "通道1";
            this.PIN1.UseVisualStyleBackColor = true;
            this.PIN1.Click += new System.EventHandler(this.PIN1_Click);
            // 
            // PIN2
            // 
            this.PIN2.Font = new System.Drawing.Font("宋体", 9F);
            this.PIN2.Location = new System.Drawing.Point(122, 52);
            this.PIN2.Name = "PIN2";
            this.PIN2.Size = new System.Drawing.Size(113, 38);
            this.PIN2.TabIndex = 18;
            this.PIN2.Text = "通道2";
            this.PIN2.UseVisualStyleBackColor = true;
            this.PIN2.Click += new System.EventHandler(this.PIN2_Click);
            // 
            // PIN3
            // 
            this.PIN3.Font = new System.Drawing.Font("宋体", 9F);
            this.PIN3.Location = new System.Drawing.Point(236, 52);
            this.PIN3.Name = "PIN3";
            this.PIN3.Size = new System.Drawing.Size(113, 38);
            this.PIN3.TabIndex = 19;
            this.PIN3.Text = "通道3";
            this.PIN3.UseVisualStyleBackColor = true;
            this.PIN3.Click += new System.EventHandler(this.PIN3_Click);
            // 
            // PIN4
            // 
            this.PIN4.Font = new System.Drawing.Font("宋体", 9F);
            this.PIN4.Location = new System.Drawing.Point(353, 52);
            this.PIN4.Name = "PIN4";
            this.PIN4.Size = new System.Drawing.Size(113, 38);
            this.PIN4.TabIndex = 20;
            this.PIN4.Text = "通道4";
            this.PIN4.UseVisualStyleBackColor = true;
            this.PIN4.Click += new System.EventHandler(this.PIN4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PIN2);
            this.groupBox2.Controls.Add(this.PIN4);
            this.groupBox2.Controls.Add(this.PIN1);
            this.groupBox2.Controls.Add(this.PIN3);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 13F);
            this.groupBox2.Location = new System.Drawing.Point(12, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 116);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1、搜索";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(492, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(778, 619);
            this.dataGridView1.TabIndex = 23;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ReadPIN2);
            this.groupBox4.Controls.Add(this.ReadPIN4);
            this.groupBox4.Controls.Add(this.ReadPIN1);
            this.groupBox4.Controls.Add(this.ReadPIN3);
            this.groupBox4.Enabled = false;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 13F);
            this.groupBox4.Location = new System.Drawing.Point(13, 331);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(473, 116);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2、读取";
            // 
            // ReadPIN2
            // 
            this.ReadPIN2.Font = new System.Drawing.Font("宋体", 9F);
            this.ReadPIN2.Location = new System.Drawing.Point(122, 39);
            this.ReadPIN2.Name = "ReadPIN2";
            this.ReadPIN2.Size = new System.Drawing.Size(113, 38);
            this.ReadPIN2.TabIndex = 22;
            this.ReadPIN2.Text = "通道2";
            this.ReadPIN2.UseVisualStyleBackColor = true;
            this.ReadPIN2.Click += new System.EventHandler(this.ReadPIN2_Click);
            // 
            // ReadPIN4
            // 
            this.ReadPIN4.Font = new System.Drawing.Font("宋体", 9F);
            this.ReadPIN4.Location = new System.Drawing.Point(353, 39);
            this.ReadPIN4.Name = "ReadPIN4";
            this.ReadPIN4.Size = new System.Drawing.Size(113, 38);
            this.ReadPIN4.TabIndex = 24;
            this.ReadPIN4.Text = "通道4";
            this.ReadPIN4.UseVisualStyleBackColor = true;
            this.ReadPIN4.Click += new System.EventHandler(this.ReadPIN4_Click);
            // 
            // ReadPIN1
            // 
            this.ReadPIN1.Font = new System.Drawing.Font("宋体", 9F);
            this.ReadPIN1.Location = new System.Drawing.Point(6, 39);
            this.ReadPIN1.Name = "ReadPIN1";
            this.ReadPIN1.Size = new System.Drawing.Size(113, 38);
            this.ReadPIN1.TabIndex = 21;
            this.ReadPIN1.Text = "通道1";
            this.ReadPIN1.UseVisualStyleBackColor = true;
            this.ReadPIN1.Click += new System.EventHandler(this.ReadPIN1_Click);
            // 
            // ReadPIN3
            // 
            this.ReadPIN3.Font = new System.Drawing.Font("宋体", 9F);
            this.ReadPIN3.Location = new System.Drawing.Point(236, 39);
            this.ReadPIN3.Name = "ReadPIN3";
            this.ReadPIN3.Size = new System.Drawing.Size(113, 38);
            this.ReadPIN3.TabIndex = 23;
            this.ReadPIN3.Text = "通道3";
            this.ReadPIN3.UseVisualStyleBackColor = true;
            this.ReadPIN3.Click += new System.EventHandler(this.ReadPIN3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.EENum2);
            this.groupBox5.Controls.Add(this.DownMode);
            this.groupBox5.Controls.Add(this.EENum);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.WritePIN2);
            this.groupBox5.Controls.Add(this.WritePIN4);
            this.groupBox5.Controls.Add(this.WritePIN1);
            this.groupBox5.Controls.Add(this.WritePIN3);
            this.groupBox5.Enabled = false;
            this.groupBox5.Font = new System.Drawing.Font("宋体", 13F);
            this.groupBox5.Location = new System.Drawing.Point(12, 464);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(473, 200);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "3、传感器编码选项";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(361, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 81;
            this.label3.Text = "位置号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(265, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 80;
            this.label2.Text = "电缆号：";
            // 
            // EENum2
            // 
            this.EENum2.Enabled = false;
            this.EENum2.Location = new System.Drawing.Point(387, 45);
            this.EENum2.Name = "EENum2";
            this.EENum2.Size = new System.Drawing.Size(63, 27);
            this.EENum2.TabIndex = 79;
            this.EENum2.Text = "01";
            this.EENum2.TextChanged += new System.EventHandler(this.EENum2_TextChanged);
            // 
            // DownMode
            // 
            this.DownMode.AutoCompleteCustomSource.AddRange(new string[] {
            "TH",
            "TL",
            "TH及TL"});
            this.DownMode.FormattingEnabled = true;
            this.DownMode.Items.AddRange(new object[] {
            "电缆号",
            "位置号",
            "电缆号及位置号"});
            this.DownMode.Location = new System.Drawing.Point(39, 46);
            this.DownMode.Name = "DownMode";
            this.DownMode.Size = new System.Drawing.Size(196, 25);
            this.DownMode.TabIndex = 78;
            this.DownMode.Text = "选择要写入的编码选项";
            this.DownMode.SelectedIndexChanged += new System.EventHandler(this.DownMode_SelectedIndexChanged);
            // 
            // EENum
            // 
            this.EENum.Enabled = false;
            this.EENum.Location = new System.Drawing.Point(286, 45);
            this.EENum.Name = "EENum";
            this.EENum.Size = new System.Drawing.Size(63, 27);
            this.EENum.TabIndex = 77;
            this.EENum.Text = "01";
            this.EENum.TextChanged += new System.EventHandler(this.EENum_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 18);
            this.label14.TabIndex = 76;
            this.label14.Text = "编码：";
            // 
            // WritePIN2
            // 
            this.WritePIN2.Font = new System.Drawing.Font("宋体", 9F);
            this.WritePIN2.Location = new System.Drawing.Point(122, 127);
            this.WritePIN2.Name = "WritePIN2";
            this.WritePIN2.Size = new System.Drawing.Size(113, 38);
            this.WritePIN2.TabIndex = 22;
            this.WritePIN2.Text = "通道2";
            this.WritePIN2.UseVisualStyleBackColor = true;
            this.WritePIN2.Click += new System.EventHandler(this.WritePIN2_Click);
            // 
            // WritePIN4
            // 
            this.WritePIN4.Font = new System.Drawing.Font("宋体", 9F);
            this.WritePIN4.Location = new System.Drawing.Point(353, 127);
            this.WritePIN4.Name = "WritePIN4";
            this.WritePIN4.Size = new System.Drawing.Size(113, 38);
            this.WritePIN4.TabIndex = 24;
            this.WritePIN4.Text = "通道4";
            this.WritePIN4.UseVisualStyleBackColor = true;
            this.WritePIN4.Click += new System.EventHandler(this.WritePIN4_Click);
            // 
            // WritePIN1
            // 
            this.WritePIN1.Font = new System.Drawing.Font("宋体", 9F);
            this.WritePIN1.Location = new System.Drawing.Point(6, 127);
            this.WritePIN1.Name = "WritePIN1";
            this.WritePIN1.Size = new System.Drawing.Size(113, 38);
            this.WritePIN1.TabIndex = 21;
            this.WritePIN1.Text = "通道1";
            this.WritePIN1.UseVisualStyleBackColor = true;
            this.WritePIN1.Click += new System.EventHandler(this.WritePIN1_Click);
            // 
            // WritePIN3
            // 
            this.WritePIN3.Font = new System.Drawing.Font("宋体", 9F);
            this.WritePIN3.Location = new System.Drawing.Point(236, 127);
            this.WritePIN3.Name = "WritePIN3";
            this.WritePIN3.Size = new System.Drawing.Size(113, 38);
            this.WritePIN3.TabIndex = 23;
            this.WritePIN3.Text = "通道3";
            this.WritePIN3.UseVisualStyleBackColor = true;
            this.WritePIN3.Click += new System.EventHandler(this.WritePIN3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "传感器数量：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(566, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "           ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 8F);
            this.button1.Location = new System.Drawing.Point(21, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 82;
            this.button1.Text = "检验";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 679);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_Main";
            this.Text = "北京七芯中创科技有限公司";
            this.Load += new System.EventHandler(this.F_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbStop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PIN1;
        private System.Windows.Forms.Button PIN2;
        private System.Windows.Forms.Button PIN3;
        private System.Windows.Forms.Button PIN4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ReadPIN2;
        private System.Windows.Forms.Button ReadPIN4;
        private System.Windows.Forms.Button ReadPIN1;
        private System.Windows.Forms.Button ReadPIN3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox DownMode;
        private System.Windows.Forms.TextBox EENum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button WritePIN2;
        private System.Windows.Forms.Button WritePIN4;
        private System.Windows.Forms.Button WritePIN1;
        private System.Windows.Forms.Button WritePIN3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsSpNum;
        private System.Windows.Forms.ToolStripStatusLabel tsBaudRate;
        private System.Windows.Forms.ToolStripStatusLabel tsDataBits;
        private System.Windows.Forms.ToolStripStatusLabel tsStopBits;
        private System.Windows.Forms.ToolStripStatusLabel tsParity;
        private System.Windows.Forms.Timer tmSend;
        private System.Windows.Forms.TextBox EENum2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}

