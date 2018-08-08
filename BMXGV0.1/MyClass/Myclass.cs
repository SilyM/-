using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using INIFILE;
using System.IO;
using System.IO.Ports;


namespace BMXGV0._1.MyClass
{
    class Myclass
    {
        #region DataGridView布局
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">采集端地址</param>
        /// <param name="b">通道号</param>
        /// <param name="c">缆号</param>
        /// <param name="d">芯片位置号</param>
        /// <param name="e">温度</param>

        #endregion

        #region 串口参数预置
        /// <summary>
        /// 串口参数
        /// </summary>
        /// <param name="Baudrate"></param>
        /// <param name="databits"></param>
        /// <param name="stop"></param>
        /// <param name="PARITY"></param>
        public void DecomSerf(ComboBox Baudrate, ComboBox databits, ComboBox stop, ComboBox PARITY)
        {
            //----------------------串口预置--------------------------//
            switch (Profile.G_BAUDRATE)
            {
                case "300":
                    Baudrate.SelectedIndex = 0;
                    break;
                case "600":
                    Baudrate.SelectedIndex = 1;
                    break;
                case "1200":
                    Baudrate.SelectedIndex = 2;
                    break;
                case "2400":
                    Baudrate.SelectedIndex = 3;
                    break;
                case "4800":
                    Baudrate.SelectedIndex = 4;
                    break;
                case "9600":
                    Baudrate.SelectedIndex = 5;
                    break;
                case "19200":
                    Baudrate.SelectedIndex = 6;
                    break;
                case "38400":
                    Baudrate.SelectedIndex = 7;
                    break;
                case "115200":
                    Baudrate.SelectedIndex = 8;
                    break;
                default:
                    {
                        MessageBox.Show("波特率参数错误！");
                        return;
                    }
            }
            switch (Profile.G_DATABITS)
            {
                case "5":
                    databits.SelectedIndex = 0;
                    break;
                case "6":
                    databits.SelectedIndex = 1;
                    break;
                case "7":
                    databits.SelectedIndex = 2;
                    break;
                case "8":
                    databits.SelectedIndex = 3;
                    break;
                default:
                    {
                        MessageBox.Show("数据位参数错误！");
                        return;
                    }

            }

            switch (Profile.G_STOP)
            {
                case "1":
                    stop.SelectedIndex = 0;
                    break;
                case "1.5":
                    stop.SelectedIndex = 1;
                    break;
                case "2":
                    stop.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("停止位参数错误！");
                        return;
                    }

            }
            switch (Profile.G_PARITY)
            {
                case "wu":
                    PARITY.SelectedIndex = 0;
                    break;
                case "ODD":
                    PARITY.SelectedIndex = 1;
                    break;
                case "EVEN":
                    PARITY.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("停止位参数错误！");
                        return;
                    }

            }
        }
        #endregion

        #region 获取串口
        public void COMCHECK(ComboBox com)
        {
            string[] strCOM = SerialPort.GetPortNames(); //check COM
            if (strCOM == null)
            {
                MessageBox.Show("本机没有串口！");
                return;
            }

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                com.Items.Add(s);
            }
        }
        #endregion

        #region 数据保存至本地
        public void Save_file(string aa, string times, string xinxi)
        {
            DateTime dt = DateTime.Now;
            Directory.CreateDirectory(@"C:\" + "LQCW");
            StreamWriter SW = new StreamWriter(@"C:\" + "LQCW" + "\\" + "_" + xinxi + ".txt", true, Encoding.UTF8);
            SW.Write(dt + " " + aa + "\r\n\r\n");
            SW.Flush();
            SW.Close();
        }
        #endregion

      

        #region CRC校验plus
        private static ushort[] crc16_table = new ushort[256]
       {
    0x0000, 0xC0C1, 0xC181, 0x0140, 0xC301, 0x03C0, 0x0280, 0xC241,
    0xC601, 0x06C0, 0x0780, 0xC741, 0x0500, 0xC5C1, 0xC481, 0x0440,
    0xCC01, 0x0CC0, 0x0D80, 0xCD41, 0x0F00, 0xCFC1, 0xCE81, 0x0E40,
    0x0A00, 0xCAC1, 0xCB81, 0x0B40, 0xC901, 0x09C0, 0x0880, 0xC841,
    0xD801, 0x18C0, 0x1980, 0xD941, 0x1B00, 0xDBC1, 0xDA81, 0x1A40,
    0x1E00, 0xDEC1, 0xDF81, 0x1F40, 0xDD01, 0x1DC0, 0x1C80, 0xDC41,
    0x1400, 0xD4C1, 0xD581, 0x1540, 0xD701, 0x17C0, 0x1680, 0xD641,
    0xD201, 0x12C0, 0x1380, 0xD341, 0x1100, 0xD1C1, 0xD081, 0x1040,
    0xF001, 0x30C0, 0x3180, 0xF141, 0x3300, 0xF3C1, 0xF281, 0x3240,
    0x3600, 0xF6C1, 0xF781, 0x3740, 0xF501, 0x35C0, 0x3480, 0xF441,
    0x3C00, 0xFCC1, 0xFD81, 0x3D40, 0xFF01, 0x3FC0, 0x3E80, 0xFE41,
    0xFA01, 0x3AC0, 0x3B80, 0xFB41, 0x3900, 0xF9C1, 0xF881, 0x3840,
    0x2800, 0xE8C1, 0xE981, 0x2940, 0xEB01, 0x2BC0, 0x2A80, 0xEA41,
    0xEE01, 0x2EC0, 0x2F80, 0xEF41, 0x2D00, 0xEDC1, 0xEC81, 0x2C40,
    0xE401, 0x24C0, 0x2580, 0xE541, 0x2700, 0xE7C1, 0xE681, 0x2640,
    0x2200, 0xE2C1, 0xE381, 0x2340, 0xE101, 0x21C0, 0x2080, 0xE041,
    0xA001, 0x60C0, 0x6180, 0xA141, 0x6300, 0xA3C1, 0xA281, 0x6240,
    0x6600, 0xA6C1, 0xA781, 0x6740, 0xA501, 0x65C0, 0x6480, 0xA441,
    0x6C00, 0xACC1, 0xAD81, 0x6D40, 0xAF01, 0x6FC0, 0x6E80, 0xAE41,
    0xAA01, 0x6AC0, 0x6B80, 0xAB41, 0x6900, 0xA9C1, 0xA881, 0x6840,
    0x7800, 0xB8C1, 0xB981, 0x7940, 0xBB01, 0x7BC0, 0x7A80, 0xBA41,
    0xBE01, 0x7EC0, 0x7F80, 0xBF41, 0x7D00, 0xBDC1, 0xBC81, 0x7C40,
    0xB401, 0x74C0, 0x7580, 0xB541, 0x7700, 0xB7C1, 0xB681, 0x7640,
    0x7200, 0xB2C1, 0xB381, 0x7340, 0xB101, 0x71C0, 0x7080, 0xB041,
    0x5000, 0x90C1, 0x9181, 0x5140, 0x9301, 0x53C0, 0x5280, 0x9241,
    0x9601, 0x56C0, 0x5780, 0x9741, 0x5500, 0x95C1, 0x9481, 0x5440,
    0x9C01, 0x5CC0, 0x5D80, 0x9D41, 0x5F00, 0x9FC1, 0x9E81, 0x5E40,
    0x5A00, 0x9AC1, 0x9B81, 0x5B40, 0x9901, 0x59C0, 0x5880, 0x9841,
    0x8801, 0x48C0, 0x4980, 0x8941, 0x4B00, 0x8BC1, 0x8A81, 0x4A40,
    0x4E00, 0x8EC1, 0x8F81, 0x4F40, 0x8D01, 0x4DC0, 0x4C80, 0x8C41,
    0x4400, 0x84C1, 0x8581, 0x4540, 0x8701, 0x47C0, 0x4680, 0x8641,
    0x8201, 0x42C0, 0x4380, 0x8341, 0x4100, 0x81C1, 0x8081, 0x4040
       };




        private static int crc16_byte(int crc, byte data)
        {
            return (crc >> 8) ^ crc16_table[(crc ^ data) & 0xff];
        }

        public byte[] CRC16(byte[] buffer, int len)
        {
            int crc = 0;
            for (int i = 0; i < len; i++)
            {
                crc = crc16_byte(crc, buffer[i]);
            }
            byte[] returnVal = new byte[2];
            returnVal = BitConverter.GetBytes(crc);
            return returnVal;
        }

        #endregion  

        #region StringToHEX
        public byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        #endregion


        #region 串口数据获取
        public void OP(List<byte> buffer,int ICNum,DataTable table)
        {
           string[] ROMID = new string[ICNum];
           string[] CobleNum = new string[ICNum];
           string[] LocalNum = new string[ICNum];
           string[] Wendu = new string[ICNum];

            int serfNum = ICNum * 14;

            byte[] IC_Information_data = new byte[serfNum];

            buffer.CopyTo(24, IC_Information_data, 0, serfNum);

            for (int i = 0, j = 0; i < IC_Information_data.Length; i += 14, j++)
            {
                ROMID[j] = Convert.ToString(IC_Information_data[i],16) + Convert.ToString(IC_Information_data[i+1], 16) + Convert.ToString(IC_Information_data[i+2], 16) + Convert.ToString(IC_Information_data[i+3], 16) + Convert.ToString(IC_Information_data[i+4], 16) + Convert.ToString(IC_Information_data[i+5], 16) + Convert.ToString(IC_Information_data[i+6], 16) + Convert.ToString(IC_Information_data[i+7], 16);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int a = 8, b = 0; a < IC_Information_data.Length; a += 14, b++)
            {
                StringBuilder IC_data = new StringBuilder();
                byte[] zz = new byte[2] { IC_Information_data[a], IC_Information_data[a + 1] };
                for (int k = 0; k < 2; k++)
                {
                    string zh = Convert.ToString(zz[k], 2);
                    string tp = zh.PadLeft(8, '0');
                    IC_data.Append(tp);
                }
                char[] clc = new char[16];
                IC_data.CopyTo(0, clc, 0, 16);
                string lanhao = null;
                string weizhihao = null;
                for (int m = 0; m < 11; m++)
                {
                    lanhao += clc[m].ToString();
                }
                CobleNum[b] = Convert.ToInt32(lanhao, 2).ToString();
                for (int q = 11; q < 16; q++)
                {
                    weizhihao += clc[q].ToString();
                }
                LocalNum[b] = Convert.ToInt32(weizhihao, 2).ToString();

            }
            for (int c = 10, d = 0; c < IC_Information_data.Length; c += 14, d++) //温度
            {
                if (IC_Information_data[c] == 0x3f && IC_Information_data[c + 1] == 0xff)
                {
                    Wendu[d] = "--";
                }
                else if (IC_Information_data[c] == 0xff && IC_Information_data[c + 1] == 0xff)
                {
                    Wendu[d] = "--";
                }
                else
                {

                    StringBuilder temperature_data = new StringBuilder();
                    byte[] zz = new byte[2] { IC_Information_data[c], IC_Information_data[c + 1] };

                    for (int k = 0; k < 2; k++)
                    {
                        string zh = Convert.ToString(zz[k], 2);
                        string tp = zh.PadLeft(8, '0');
                        temperature_data.Append(tp);
                    }
                    char[] c1c = new char[16];
                    temperature_data.CopyTo(0, c1c, 0, 16);
                    string canshutyep = null;
                    string wenduint = null;
                    string wendudouble = null;
                    string zhengfu = null;
                    for (int m = 0; m < 4; m++)
                    {
                        canshutyep += c1c[m].ToString();

                    }

                    for (int p = 5; p < 12; p++)
                    {
                        wenduint += c1c[p].ToString();

                    }
                    for (int q = 12; q < 16; q++)
                    {
                        wendudouble += c1c[q].ToString();

                    }
                    if (c1c[4].ToString() == "1")
                    {
                        zhengfu = "-";
                    }
                    else
                    {
                        zhengfu = "+";
                    }
                    Wendu[d] = zhengfu + Convert.ToInt32(wenduint, 2).ToString() + "." + Convert.ToInt32(wendudouble, 2);

                }


            }
            for (int ii = 0; ii < ICNum; ii++)
            {

                DataRow r1 = table.NewRow();

                r1["时间"] = DateTime.Now.ToString();
                r1["ROMID"] = ROMID[ii];
                r1["缆号"] = CobleNum[ii];
                r1["地址"] = LocalNum[ii];
                r1["温度（℃）"] = Wendu[ii];  
                table.Rows.Add(r1);
            }
        }
        #endregion





        #region bit to Byte 
        public byte[] bitToByteTH (TextBox EENum)
        {
            string a = EENum.Text;
            int b;
            string c;
            string d;
            string f;
            
            b = Convert.ToInt16(a);
            c = Convert.ToString(b, 2);
            d = "000000";
            c = c.PadLeft(10, '0');
            f = c + d;
            byte[] encodebyte = new byte[f.Length / 8];
            for (int i = 0; i < f.Length / 8; i++)
            {
                encodebyte[i] = Convert.ToByte(f.Substring(i * 8, 8), 2);
            }
            return encodebyte;
        }

        public byte[] bitToByteTL(TextBox EENum)
        {
            string a = EENum.Text;
            int b;
            string c;
            string d;
            string f;

            b = Convert.ToInt16(a);
            c = Convert.ToString(b, 2);
            d = c.PadLeft(6,'0');
            c = "0000000000";
            f = c + d;
            byte[] encodebyte = new byte[f.Length / 8];
            for (int i = 0; i < f.Length / 8; i++)
            {
                encodebyte[i] = Convert.ToByte(f.Substring(i * 8, 8), 2);
            }
            return encodebyte;
        }
        public byte[] bitToByteTHTL(TextBox EENum)
        {
            string a = EENum.Text;
            int b;
            string c;
            string d;
            string f;

            b = Convert.ToInt16(a);
            c = Convert.ToString(b, 2);
            d = c.PadLeft(6, '0');
            c = c.PadLeft(10, '0');
            f = c + d;
            byte[] encodebyte = new byte[f.Length / 8];
            for (int i = 0; i < f.Length / 8; i++)
            {
                encodebyte[i] = Convert.ToByte(f.Substring(i * 8, 8), 2);
            }
            return encodebyte;
        }


        #endregion





        #region 控件调整
        public void Adjust(DataGridView dataGridView1)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.AutoResizeRows();
        }
        #endregion






    }
}

