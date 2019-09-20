using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ArduinoController
{
  
    public partial class Form1 : Form
    {
        private SerialPort leftPort, rightPort;
       
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Left_TextChanged(object sender, EventArgs e)
        {

        }
        private void PerformLeftClick()
        {
            Else.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
        }
        private void PerformRightClick()
        {
            Else.mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            leftPort = new SerialPort();
            rightPort = new SerialPort();
            leftPort.PortName = left.Text;
            rightPort.PortName = right.Text;
            leftPort.BaudRate = 115200;
            rightPort.BaudRate = 115200;
            leftPort.DataReceived += DataReceivedL;
            rightPort.DataReceived += DataReceivedR;
            leftPort.Open();
            rightPort.Open();
            status.Text = "Connected";
        }
        public static int Map(t int  value, int fromSource, int toSource, int fromTarget, int toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
        private void DataReceivedR(object sender,SerialDataReceivedEventArgs e)
        {
            double angle = 0;
            bool flag = double.TryParse(rightPort.ReadExisting(), out angle);
            if (flag)
            {
                int k = 0;
                if(angle < 0)
                {
                    k = 0;
                }else
                if(angle > 180)
                {
                    k = 180;
                }
                else
                {
                    k = (int)angle;
                }

                int numclick = Map(k, 0, 180, 0, 50);
                for(int i = 0; i < numclick; i++)
                {
                    PerformRightClick();
                }
                    
            }
        }
        private void DataReceivedL(object sender,SerialDataReceivedEventArgs e)
        {
            double angle = 0;
            bool flag = double.TryParse(rightPort.ReadExisting(), out angle);
            if (flag)
            {
                int k = 0;
                if (angle < 0)
                {
                    k = 0;
                }
                else
                if (angle > 180)
                {
                    k = 180;
                }
                else
                {
                    k = (int)angle;
                }

                int numclick = Map(k, 0, 180, 0, 50);
                for (int i = 0; i < numclick; i++)
                {
                    PerformLeftClick();
                }

            }
        }
    }
}
