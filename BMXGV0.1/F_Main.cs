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
           
        void Sp1_DataReceived(object sender , SerialDataReceivedEventArgs e)
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
                    string strrcv = null;

                    for (int i = 0; i < receivedData.Length; i++)
                    {
                        strrcv += receivedData[i].ToString("x2");
                    }
                    txtReceive.Text += strrcv + "\r\n";

                    if (txtReceive.TextLength > 500)
                    {
                        txtReceive.Clear();
                    }
                    #endregion

                    #region Communication Protocol processing
                    if(buffer[0]== 0x5F && buffer[1]==0x5F && buffer[receivedData.Length-1]==0xAA && buffer[receivedData.Length] == 0x55)
                    {
                    #region Connect Y/N
                        if (buffer[8] == 0x02)
                        {
                            if (buffer[9] == 0x00)
                            {
                                MessageBox.Show("连接成功！");
                            }
                            if (buffer[9] == 0x01)
                            {
                                MessageBox.Show("连接无效,请检查软硬件连接或重启程序及硬件");
                            }
                            if (buffer[9] == 0x02)
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

                    #region Channel Attribute
                    if (buffer[8] == 0x04)
                    {
                        if (buffer[9] == 0x00)
                        {
                             Chnum = Convert.ToString(buffer[10], 10);
                            if (buffer[15] == 0x00)
                            {
                                ushort QTNum = 0;   
                                byte b1 = buffer[11];   
                                byte b2 = buffer[12];   
                                QTNum = (ushort)(QTNum ^ b1);  
                                QTNum = (ushort)(QTNum << 8);  
                                QTNum = (ushort)(QTNum ^ b2); 
                                MessageBox.Show("通道："+Chnum+"，检查正确，共有QT传感器" + QTNum.ToString() + "颗");
                            }
                            if (buffer[15] == 0x01)
                            {
                                ushort QTNum = 0;   
                                byte b1 = buffer[11];   
                                byte b2 = buffer[12];   
                                QTNum = (ushort)(QTNum ^ b1); 
                                QTNum = (ushort)(QTNum << 8); 
                                QTNum = (ushort)(QTNum ^ b2); 
                                MessageBox.Show("通道："+Chnum+",检查正确，共有QT传感器" + QTNum.ToString() + "颗");
                                ushort NQTNum = 0;
                                byte b3 = buffer[13];
                                byte b4 = buffer[14];
                                NQTNum = (ushort)(NQTNum ^ b1);  
                                NQTNum = (ushort)(NQTNum << 8);  
                                NQTNum = (ushort)(NQTNum ^ b2);
                                MessageBox.Show("通道：" + Chnum +",有非本公司传感器,共有QT传感器" + QTNum.ToString() + "颗，" + "非QT传感器"+NQTNum.ToString()+"颗"); 
                            }
                        }
                        if (buffer[9] == 0x01)
                        {
                            MessageBox.Show("下发通道错误（超出范围）！");
                        }
                        if (buffer[9] == 0x02)
                        {
                            MessageBox.Show("接受到的CRC错误！");
                        }
                    }
                    #endregion

                    #region IC information Confrim
                    if (buffer[8] == 0x06)
                    {
                        Chnum = Convert.ToString(buffer[19], 10);

                        int ICNum = 0;
                        
                        byte b1 = buffer[11];
                        byte b2 = buffer[12];
                        ICNum = (int)(ICNum ^ b1);
                        ICNum = (int)(ICNum << 8);
                        ICNum = (int)(ICNum ^ b2);

                        if (buffer[9] == 0x00)
                        {
                            Myclass.OP(buffer, ICNum, table);
                        }
                        if (buffer[9] == 0x01)
                        {
                            MessageBox.Show("通道："+Chnum+",下发通道错误（超出范围/或与最近搜索通道不符）");
                            return;
                        }
                        if (buffer[9] == 0x02)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收的下行帧CRC错误");
                            return;
                        }
                        if (buffer[9] == 0x03)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID为非法传感器");
                            return;
                        }
                        if (buffer[9] == 0x04)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID CRC错误");
                            return;
                        }
                        if (buffer[9] == 0x05)
                        {
                            MessageBox.Show("通道：" + Chnum + ",连接有非法传感器（不能操作）");
                            return;
                        }
                        if (buffer[9] == 0x06)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收到错误读/写类型");
                            return;
                        }
                        if (buffer[9] == 0x07)
                        {
                            MessageBox.Show("通道：" + Chnum + ",未搜索就进行读/写操作");
                            return;
                        }

                    }
                    #endregion

                    #region
                    if (buffer[8] == 0x08)
                    {
                        Chnum = buffer[10].ToString();
                        if (buffer[9] == 0x00)
                        {
                           
                            MessageBox.Show("通道："+Chnum+"写入成功!");
                        }
                        if (buffer[9] == 0x01)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发通道错误（超出范围/或与最近搜索通道不符）");
                            return;
                        }
                        if (buffer[9] == 0x02)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收的下行帧CRC错误");
                            return;
                        }
                        if (buffer[9] == 0x03)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID为非法传感器");
                            return;
                        }
                        if (buffer[9] == 0x04)
                        {
                            MessageBox.Show("通道：" + Chnum + ",下发ROMID CRC错误");
                            return;
                        }
                        if (buffer[9] == 0x05)
                        {
                            MessageBox.Show("通道：" + Chnum + ",连接有非法传感器（不能操作）");
                            return;
                        }
                        if (buffer[9] == 0x06)
                        {
                            MessageBox.Show("通道：" + Chnum + ",接收到错误读/写类型");
                            return;
                        }
                        if (buffer[9] == 0x07)
                        {
                            MessageBox.Show("通道：" + Chnum + ",未搜索就进行读/写操作");
                            return;
                        }
                        if (buffer[9] == 0x08)
                        {
                            MessageBox.Show("通道：" + Chnum + ",写入失败");
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

        private void PIN1_Click(object sender, EventArgs e)
        {
            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[13];
            COM1[0] = 0x5f;COM1[1] = 0x5f;COM1[2] = 0x00;COM1[3] = 0x01;COM1[4] = 0x10;COM1[5] = 0x01;COM1[6] = 0x00;COM1[7] = 0x00;COM1[8] = 0x03;COM1[9] = 0x01;
            byte[] crc = new byte[11];
            byte[] crcreturn = new byte[2];
            for (int i = 2, j = 0; i < 10; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[10] = crcreturn[0];
            COM1[11] = crcreturn[1];
            COM1[12] = 0xAA;
            COM1[13] = 0x55;
        }

        private void PIN2_Click(object sender, EventArgs e)
        {

            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[13];
            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x01; COM1[4] = 0x10; COM1[5] = 0x01; COM1[6] = 0x00; COM1[7] = 0x00; COM1[8] = 0x03; COM1[9] = 0x02;
            byte[] crc = new byte[11];
            byte[] crcreturn = new byte[2];
            for (int i = 2, j = 0; i < 10; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[10] = crcreturn[0];
            COM1[11] = crcreturn[1];
            COM1[12] = 0xAA;
            COM1[13] = 0x55;
        }

        private void PIN3_Click(object sender, EventArgs e)
        {

            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[13];
            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x01; COM1[4] = 0x10; COM1[5] = 0x01; COM1[6] = 0x00; COM1[7] = 0x00; COM1[8] = 0x03; COM1[9] = 0x03;
            byte[] crc = new byte[11];
            byte[] crcreturn = new byte[2];
            for (int i = 2, j = 0; i < 10; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[10] = crcreturn[0];
            COM1[11] = crcreturn[1];
            COM1[12] = 0xAA;
            COM1[13] = 0x55;
        }

        private void PIN4_Click(object sender, EventArgs e)
        {

            MyClass.Myclass Myclass = new MyClass.Myclass();
            byte[] COM1 = new byte[13];
            COM1[0] = 0x5f; COM1[1] = 0x5f; COM1[2] = 0x00; COM1[3] = 0x01; COM1[4] = 0x10; COM1[5] = 0x01; COM1[6] = 0x00; COM1[7] = 0x00; COM1[8] = 0x03; COM1[9] = 0x04;
            byte[] crc = new byte[11];
            byte[] crcreturn = new byte[2];
            for (int i = 2, j = 0; i < 10; i++, j++)
            {
                crc[j] = COM1[i];
            }
            crcreturn = Myclass.CRC16(crc, crc.Length);
            COM1[10] = crcreturn[0];
            COM1[11] = crcreturn[1];
            COM1[12] = 0xAA;
            COM1[13] = 0x55;
        }
    }
}
