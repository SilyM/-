using System;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;


namespace BMXGV0._1
{
    public partial class F_Main : Form
    {

        SerialPort Sp1 = new SerialPort();//实例化串口
        MyClass.Myclass Myclass = new BMXGV0._1.MyClass.Myclass();

        public F_Main()
        {
            InitializeComponent();
            
         
        }



        private void F_Main_Load(object sender, EventArgs e)
        {
            EENum.Enabled = false;
            EENum.Enabled = false;
            INIFILE.Profile.LoadProfile(); //加载本地Config文件
            Myclass.DecomSerf(cbBaudRate, cbDataBits, cbStop, cbParity); //GUI COM serf set
            Myclass.COMCHECK(cbSerial); //Get COM

            Sp1.BaudRate = 115200;
            Control.CheckForIllegalCrossThreadCalls = false; //Allow Access UI Thread
            Sp1.DataReceived += new SerialDataReceivedEventHandler(Sp1_DataReceived);
            Sp1.DtrEnable = true;
            Sp1.RtsEnable = true;
            Sp1.ReadTimeout = 100000;
            Sp1.Close();
         
        }

        void Sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(300);

            DataTable table = new DataTable();

            DataColumn c0 = new DataColumn("时间", typeof(string));
            DataColumn c1 = new DataColumn("ROMID", typeof(string));
            DataColumn c2 = new DataColumn("缆号", typeof(string));
            DataColumn c3 = new DataColumn("地址", typeof(string));
            DataColumn c4 = new DataColumn("温度（℃）", typeof(string));


            table.Columns.Add(c0);
            table.Columns.Add(c1);
            table.Columns.Add(c2);
            table.Columns.Add(c3);
            table.Columns.Add(c4);


            if (Sp1.IsOpen)
            {

                List<byte> buffer = new List<byte>(4096);
                try
                {
                    string Chnum; //chnnel number
                    #region Save Data To Static
                    Byte[] receivedData = new Byte[Sp1.BytesToRead];
                    Sp1.Read(receivedData, 0, receivedData.Length);
                    buffer.AddRange(receivedData); //buffer those to list
                    Sp1.DiscardInBuffer();
                    //string strrcv = null;

                    //for (int i = 0; i < receivedData.Length; i++)
                    //{
                    //    strrcv += receivedData[i].ToString("x2");
                    //}
                    //txtReceive.Text += strrcv + "\r\n";

                    //if (txtReceive.TextLength > 500)
                    //{
                    //    txtReceive.Clear();
                    //}
                    #endregion
                    int n = buffer.Count;
                    #region Communication Protocol processing
                    if (buffer[0] == 0x5F && buffer[1] == 0x5F && buffer[n - 1] == 0xAA && buffer[n-2] == 0x55)
                    {
                        
                        #region Connect Y/N 02
                        if (buffer[10] == 0x02)
                        {
                            if (buffer[11] == 0x00)
                            {
                                MessageBox.Show("连接成功！");
                            }
                            if (buffer[11] == 0x01)
                            {
                                MessageBox.Show("连接无效,请检查软硬件连接或重启程序及硬件");
                            }
                            if (buffer[11] == 0x02)
                            {
                                MessageBox.Show("接收到的CRC校验错误！");
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                    #endregion

                        #region Channel Attribute 04
                    if (buffer[10] == 0x04)
                    {
                        if (buffer[11] == 0x00)
                        {
                            Chnum = Convert.ToString(buffer[12], 10);
                            if (buffer[17] == 0x00)
                            {
                                ushort QTNum = 0;
                                byte b1 = buffer[13];
                                byte b2 = buffer[14];
                                QTNum = (ushort)(QTNum ^ b1);
                                QTNum = (ushort)(QTNum << 8);
                                QTNum = (ushort)(QTNum ^ b2);
                                MessageBox.Show("通道：" + Chnum + "，检查正确，共有QT传感器" + QTNum.ToString() + "颗");
                                groupBox4.Enabled = true;
                            }
                            if (buffer[17] == 0x01)
                            {
                                ushort QTNum = 0;
                                byte b1 = buffer[13];
                                byte b2 = buffer[14];
                                QTNum = (ushort)(QTNum ^ b1);
                                QTNum = (ushort)(QTNum << 8);
                                QTNum = (ushort)(QTNum ^ b2);
                                ushort NQTNum = 0;
                                byte b3 = buffer[15];
                                byte b4 = buffer[16];
                                NQTNum = (ushort)(NQTNum ^ b3);
                                NQTNum = (ushort)(NQTNum << 8);
                                NQTNum = (ushort)(NQTNum ^ b4);
                                MessageBox.Show("通道：" + Chnum + ",有非本公司传感器,共有QT传感器" + QTNum.ToString() + "颗，" + "非QT传感器" + NQTNum.ToString() + "颗");
                            }
                        }
                        if (buffer[11] == 0x01)
                        {
                            MessageBox.Show("下发通道错误（超出范围）！");
                        }
                        if (buffer[11] == 0x02)
                        {
                            MessageBox.Show("接受到的CRC错误！");
                        }
                    }
                    #endregion

                        #region IC information Confrim 06
                    if (buffer[10] == 0x06)
                    {
                        
                        Chnum = Convert.ToString(buffer[21], 10);

                        int ICNum = 0;

                        byte b1 = buffer[22];
                        byte b2 = buffer[23];
                        ICNum = (int)(ICNum ^ b1);
                        ICNum = (int)(ICNum << 8);
                        ICNum = ICNum ^ b2;

                        if (buffer[11] == 0x00)
                        {
                            Myclass.OP(buffer, ICNum, table);
                            this.Invoke(new MethodInvoker(() =>
                            {
                                this.dataGridView1.DataSource = table;
                            }));
                            groupBox5.Enabled = true;
                        }
                        if (buffer[11] == 0x01)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发通道错误（超出范围/或与最近搜索通道不符）");
                            return;
                        }
                        if (buffer[11] == 0x02)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收的下行帧CRC错误");
                            return;
                        }
                        if (buffer[11] == 0x03)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID为非法传感器");
                            return;
                        }
                        if (buffer[11] == 0x04)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID CRC错误");
                            return;
                        }
                        if (buffer[11] == 0x05)
                        {
                            MessageBox.Show("通道：" + Chnum + ",连接有非法传感器（不能操作）");
                            return;
                        }
                        if (buffer[11] == 0x06)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收到错误读/写类型");
                            return;
                        }
                        if (buffer[11] == 0x07)
                        {
                            MessageBox.Show("通道：" + Chnum + ",未搜索就进行读/写操作");
                            return;
                        }

                    }
                    #endregion

                        #region Write IC EE Confrim 08
                    if (buffer[10] == 0x08)
                    {
                        Chnum = buffer[12].ToString();
                        if (buffer[11] == 0x00)
                        {

                            MessageBox.Show("通道：" + Chnum + "写入成功!");
                        }
                        if (buffer[11] == 0x01)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发通道错误（超出范围/或与最近搜索通道不符）");
                            return;
                        }
                        if (buffer[11] == 0x02)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收的下行帧CRC错误");
                            return;
                        }
                        if (buffer[11] == 0x03)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID为非法传感器");
                            return;
                        }
                        if (buffer[11] == 0x04)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID CRC错误");
                            return;
                        }
                        if (buffer[11] == 0x05)
                        {
                            MessageBox.Show("通道：" + Chnum + ",连接有非法传感器（不能操作）");
                            return;
                        }
                        if (buffer[11] == 0x06)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收到错误读/写类型");
                            return;
                        }
                        if (buffer[11] == 0x07)
                        {
                            MessageBox.Show("通道：" + Chnum + ",未搜索就进行读/写操作");
                            return;
                        }
                        if (buffer[11] == 0x08)
                        {
                            MessageBox.Show("通道：" + Chnum + ",写入失败");
                            return;
                        }
                        if (buffer[11] == 0x09)
                        {
                            MessageBox.Show("通道：" + Chnum + ",未经读取就写入");
                            return;
                        }
                    }

                    #endregion
                }
                catch
                {

                }
                #endregion
            }
        }

                      #region 0x0003
        private void PIN1_Click(object sender, EventArgs e) //0x0003
        {
            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[16];

            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x0A; COM1[4] = 0x00; COM1[5] = 0x01; COM1[6] = 0x10; COM1[7] = 0x01; COM1[8] = 0x00; COM1[9] = 0x00;
            COM1[10] = 0x03; COM1[11] = 0x01;
            byte[] crc = new byte[8];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 12; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[12] = crcreturn[1];
            COM1[13] = crcreturn[0];
            COM1[14] = 0x55;
            COM1[15] = 0xAA;
            Sp1.Write(COM1, 0, COM1.Length);
        }

        private void PIN2_Click(object sender, EventArgs e)
        {

            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[16];

            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x0A; COM1[4] = 0x00; COM1[5] = 0x01; COM1[6] = 0x10; COM1[7] = 0x01; COM1[8] = 0x00; COM1[9] = 0x00;
            COM1[10] = 0x03; COM1[11] = 0x02;
            byte[] crc = new byte[8];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 12; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[12] = crcreturn[1];
            COM1[13] = crcreturn[0];
            COM1[14] = 0x55;
            COM1[15] = 0xAA;
            Sp1.Write(COM1, 0, COM1.Length);
        }

        private void PIN3_Click(object sender, EventArgs e)
        {

            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[16];

            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x0A; COM1[4] = 0x00; COM1[5] = 0x01; COM1[6] = 0x10; COM1[7] = 0x01; COM1[8] = 0x00; COM1[9] = 0x00;
            COM1[10] = 0x03; COM1[11] = 0x03;
            byte[] crc = new byte[8];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 12; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[12] = crcreturn[1];
            COM1[13] = crcreturn[0];
            COM1[14] = 0x55;
            COM1[15] = 0xAA;
            Sp1.Write(COM1, 0, COM1.Length);
        }

        private void PIN4_Click(object sender, EventArgs e)
        {

            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[16];

            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x0A; COM1[4] = 0x00; COM1[5] = 0x01; COM1[6] = 0x10; COM1[7] = 0x01; COM1[8] = 0x00; COM1[9] = 0x00;
            COM1[10] = 0x03; COM1[11] = 0x04;
            byte[] crc = new byte[8];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 12; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[12] = crcreturn[1];
            COM1[13] = crcreturn[0];
            COM1[14] = 0x55;
            COM1[15] = 0xAA;
            Sp1.Write(COM1, 0, COM1.Length);
        }
        #endregion

                      #region 0x0005
        private void ReadPIN1_Click(object sender, EventArgs e) //0x0005
        {
            byte[] COM2 = new byte[25];
            COM2[0] = 0x5f; COM2[1] = 0x5f; COM2[2] = 0x00; COM2[3] = 0x13; COM2[4] = 0x00; COM2[5] = 0x01; COM2[6] = 0x10; COM2[7] = 0x01; COM2[8] = 0x00; COM2[9] = 0x00; COM2[10] = 0x05; COM2[11] = 0x01;
            COM2[12] = 0x01;
            for (int i = 13; i < 13 + 8; i++)
            {
                COM2[i] = 0x00;
            }
            byte[] crc = new byte[17];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 13+8; i++, j++)
            {
                crc[j] = COM2[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM2[21] = crcreturn[1];
            COM2[22] = crcreturn[0];
            COM2[23] = 0x55;
            COM2[24] = 0xAA;
            Sp1.Write(COM2, 0, COM2.Length);
            

        }

        private void ReadPIN2_Click(object sender, EventArgs e)
        {
            byte[] COM2 = new byte[25];
            COM2[0] = 0x5f; COM2[1] = 0x5f; COM2[2] = 0x00; COM2[3] = 0x13; COM2[4] = 0x00; COM2[5] = 0x01; COM2[6] = 0x10; COM2[7] = 0x01; COM2[8] = 0x00; COM2[9] = 0x00; COM2[10] = 0x05; COM2[11] = 0x02;
            COM2[12] = 0x01;
            for (int i = 13; i < 13 + 8; i++)
            {
                COM2[i] = 0x00;
            }
            byte[] crc = new byte[17];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 13+8; i++, j++)
            {
                crc[j] = COM2[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM2[21] = crcreturn[1];
            COM2[22] = crcreturn[0];
            COM2[23] = 0x55;
            COM2[24] = 0xAA;
            Sp1.Write(COM2, 0, COM2.Length);
        }

        private void ReadPIN3_Click(object sender, EventArgs e)
        {
            byte[] COM2 = new byte[25];
            COM2[0] = 0x5f; COM2[1] = 0x5f; COM2[2] = 0x00; COM2[3] = 0x13; COM2[4] = 0x00; COM2[5] = 0x01; COM2[6] = 0x10; COM2[7] = 0x01; COM2[8] = 0x00; COM2[9] = 0x00; COM2[10] = 0x05; COM2[11] = 0x03;
            COM2[12] = 0x01;
            for (int i = 13; i < 13 + 8; i++)
            {
                COM2[i] = 0x00;
            }
            byte[] crc = new byte[17];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 13+8; i++, j++)
            {
                crc[j] = COM2[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM2[21] = crcreturn[1];
            COM2[22] = crcreturn[0];
            COM2[23] = 0x55;
            COM2[24] = 0xAA;
            Sp1.Write(COM2, 0, COM2.Length);
        }

        private void ReadPIN4_Click(object sender, EventArgs e)
        {
            byte[] COM2 = new byte[25];
            COM2[0] = 0x5f; COM2[1] = 0x5f; COM2[2] = 0x00; COM2[3] = 0x13; COM2[4] = 0x00; COM2[5] = 0x01; COM2[6] = 0x10; COM2[7] = 0x01; COM2[8] = 0x00; COM2[9] = 0x00; COM2[10] = 0x05; COM2[11] = 0x04;
            COM2[12] = 0x01;
            for (int i = 13; i < 13 + 8; i++)
            {
                COM2[i] = 0x00;
            }
            byte[] crc = new byte[17];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 13+8; i++, j++)
            {
                crc[j] = COM2[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM2[21] = crcreturn[1];
            COM2[22] = crcreturn[0];
            COM2[23] = 0x55;
            COM2[24] = 0xAA;
            Sp1.Write(COM2, 0, COM2.Length);
        }

        #endregion

                      #region 0x0007
        private void WritePIN1_Click(object sender, EventArgs e)
        {
            byte[] COM3 = new byte[27];
            byte[] btoB = new byte[2];
            COM3[0] = 0x5f; COM3[1] = 0x5f; COM3[2] = 0x00; COM3[3] = 0x15; COM3[4] = 0x00; COM3[5] = 0x01; COM3[6] = 0x10; COM3[7] = 0x01; COM3[8] = 0x00; COM3[9] = 0x00; COM3[10] = 0x07; COM3[11] = 0x01;
            if (DownMode.Text == "电缆号")
            {
                COM3[12] = 0x01;

                btoB = Myclass.bitToByteTH(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];


            }
            if (DownMode.Text == "位置号")
            {
                COM3[12] = 0x02;
                btoB = Myclass.bitToByteTL(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            if (DownMode.Text == "电缆号及位置号")
            {
               
                COM3[12] = 0x03;
                btoB = Myclass.bitToByteTHTL(EENum,EENum2);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            for (int i = 13; i < 13 + 8; i++)
            {
                COM3[i] = 0x00;
            }
            byte[] crc = new byte[19];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 23; i++, j++)
            {
                crc[j] = COM3[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM3[23] = crcreturn[1];
            COM3[24] = crcreturn[0];
            COM3[25] = 0x55;
            COM3[26] = 0xAA;
            Sp1.Write(COM3, 0, COM3.Length);



        }



        private void WritePIN2_Click(object sender, EventArgs e)
        {
            byte[] COM3 = new byte[27];
            byte[] btoB = new byte[2];
            COM3[0] = 0x5f; COM3[1] = 0x5f; COM3[2] = 0x00; COM3[3] = 0x15; COM3[4] = 0x00; COM3[5] = 0x01; COM3[6] = 0x10; COM3[7] = 0x01; COM3[8] = 0x00; COM3[9] = 0x00; COM3[10] = 0x07; COM3[11] = 0x02;
            if (DownMode.Text == "电缆号")
            {
                COM3[12] = 0x01;

                btoB = Myclass.bitToByteTH(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];


            }
            if (DownMode.Text == "位置号")
            {
                COM3[12] = 0x02;
                btoB = Myclass.bitToByteTL(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            if (DownMode.Text == "电缆号及位置号")
            {
                COM3[12] = 0x03;
                btoB = Myclass.bitToByteTHTL(EENum,EENum2);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            for (int i = 13; i < 13 + 8; i++)
            {
                COM3[i] = 0x00;
            }
            byte[] crc = new byte[19];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 23; i++, j++)
            {
                crc[j] = COM3[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM3[23] = crcreturn[1];
            COM3[24] = crcreturn[0];
            COM3[25] = 0x55;
            COM3[26] = 0xAA;
            Sp1.Write(COM3, 0, COM3.Length);
        }



        private void WritePIN3_Click(object sender, EventArgs e)
        {
            byte[] COM3 = new byte[27];
            byte[] btoB = new byte[2];
            COM3[0] = 0x5f; COM3[1] = 0x5f; COM3[2] = 0x00; COM3[3] = 0x15; COM3[4] = 0x00; COM3[5] = 0x01; COM3[6] = 0x10; COM3[7] = 0x01; COM3[8] = 0x00; COM3[9] = 0x00; COM3[10] = 0x07; COM3[11] = 0x03;
            if (DownMode.Text == "电缆号")
            {
                COM3[12] = 0x01;

                btoB = Myclass.bitToByteTH(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];


            }
            if (DownMode.Text == "位置号")
            {
                COM3[12] = 0x02;
                btoB = Myclass.bitToByteTL(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            if (DownMode.Text == "电缆号及位置号")
            {
                COM3[12] = 0x03;
                btoB = Myclass.bitToByteTHTL(EENum,EENum2);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            for (int i = 13; i < 13 + 8; i++)
            {
                COM3[i] = 0x00;
            }
            byte[] crc = new byte[19];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 23; i++, j++)
            {
                crc[j] = COM3[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM3[23] = crcreturn[1];
            COM3[24] = crcreturn[0];
            COM3[25] = 0x55;
            COM3[26] = 0xAA;
            Sp1.Write(COM3, 0, COM3.Length);
        }

        private void WritePIN4_Click(object sender, EventArgs e)
        {
            byte[] COM3 = new byte[27];
            byte[] btoB = new byte[2];
            COM3[0] = 0x5f; COM3[1] = 0x5f; COM3[2] = 0x00; COM3[3] = 0x15; COM3[4] = 0x00; COM3[5] = 0x01; COM3[6] = 0x10; COM3[7] = 0x01; COM3[8] = 0x00; COM3[9] = 0x00; COM3[10] = 0x07; COM3[11] = 0x04;
            if (DownMode.Text == "TH")
            {
                COM3[12] = 0x01;

                btoB = Myclass.bitToByteTH(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];


            }
            if (DownMode.Text == "TL")
            {
                COM3[12] = 0x02;
                btoB = Myclass.bitToByteTL(EENum);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            if (DownMode.Text == "TH及TL")
            {
                COM3[12] = 0x03;
                btoB = Myclass.bitToByteTHTL(EENum,EENum2);
                COM3[21] = btoB[0];
                COM3[22] = btoB[1];
            }
            for (int i = 13; i < 13 + 8; i++)
            {
                COM3[i] = 0x00;
            }
            byte[] crc = new byte[19];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 23; i++, j++)
            {
                crc[j] = COM3[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM3[23] = crcreturn[1];
            COM3[24] = crcreturn[0];
            COM3[25] = 0x55;
            COM3[26] = 0xAA;
            Sp1.Write(COM3, 0, COM3.Length);
        }
        #endregion
        private void Connect_Click(object sender, EventArgs e) //0x0001
        {
            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[19];

            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x0d; COM1[4] = 0x00; COM1[5] = 0x01; COM1[6] = 0x10; COM1[7] = 0x01; COM1[8] = 0x00; COM1[9] = 0x00;
            COM1[10] = 0x01; COM1[11] = 0x07; COM1[12] = 0x51; COM1[13] = 0x70; COM1[14] = 0x05;
            byte[] crc = new byte[11];
            byte[] crcreturn = new byte[2];
            for (int i = 4, j = 0; i < 15; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[15] = crcreturn[1];
            COM1[16] = crcreturn[0];
            COM1[17] = 0x55;
            COM1[18] = 0xAA;
            Sp1.Write(COM1, 0, COM1.Length);
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (!Sp1.IsOpen)
            {
                try
                {
                    string serialName = cbSerial.SelectedItem.ToString();
                    Sp1.PortName = serialName;
                    //串口设置
                    string strBaudRate = cbBaudRate.Text;
                    string strDateBits = cbDataBits.Text;
                    string strStopBits = cbStop.Text;
                    Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    Int32 idateBits = Convert.ToInt32(strDateBits);

                    Sp1.BaudRate = iBaudRate;
                    Sp1.DataBits = idateBits;
                    Sp1.StopBits = StopBits.One;
                    Sp1.Parity = Parity.None;

                    if (Sp1.IsOpen == true)
                    {
                        Sp1.Close();
                    }
                    tsSpNum.Text = "串口号：" + Sp1.PortName + "|";
                    tsBaudRate.Text = "波特率：" + Sp1.BaudRate + "|";
                    tsDataBits.Text = "数据位：" + Sp1.DataBits + "|";
                    tsStopBits.Text = "停止位：" + Sp1.StopBits + "|";
                    tsParity.Text = "校验位:" + Sp1.Parity + "|";

                    cbSerial.Enabled = false;
                    cbBaudRate.Enabled = false;
                    cbStop.Enabled = false;
                    cbDataBits.Enabled = false;
                    cbParity.Enabled = false;

                    Sp1.Open();

                    btnSwitch.Text = "关闭串口";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    tmSend.Enabled = false;
                }
            }
            else
            {
                //状态栏设置
                tsSpNum.Text = "串口号：未指定|";
                tsBaudRate.Text = "波特率：未指定|";
                tsDataBits.Text = "数据位：未指定|";
                tsStopBits.Text = "停止位：未指定|";
                tsParity.Text = "校验位：未指定|";
                //恢复控件功能
                //设置必要控件不可用
                cbSerial.Enabled = true;
                cbBaudRate.Enabled = true;
                cbDataBits.Enabled = true;
                cbStop.Enabled = true;
                cbParity.Enabled = true;

                Sp1.Close();                    //关闭串口
                btnSwitch.Text = "打开串口";
                tmSend.Enabled = false;         //关闭计时器
            }
        }

        private void EENum_TextChanged(object sender, EventArgs e)
        {

        }

        private void EENum2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DownMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DownMode.SelectedIndex == 0)
            {
                EENum.Enabled = true;
                EENum2.Enabled = false;
            }
            if (DownMode.SelectedIndex == 1)
            {
                EENum.Enabled = false;
                EENum2.Enabled = true;
            }
            if (DownMode.SelectedIndex == 2)
            {
                EENum2.Enabled = true;
                EENum.Enabled = true;
            }
        }
    }
}
