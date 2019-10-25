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
namespace ArduinoCon
{

    public partial class Form1 : Form
    {
        public static Form1 instance;
        double anglePrev = 0;
        double time, timePrev = 0;
        private SerialPort leftPort, rightPort;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);



      
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Left_TextChanged(object sender, EventArgs e)
        {

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
        public static int Map(int value, int fromSource, int toSource, int fromTarget, int toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
      
        private void DataReceivedL(object sender, SerialDataReceivedEventArgs e)
        {
  
            String target = leftPort.ReadExisting();
            instance.BeginInvoke(new Action(delegate () {
                ChangeText("Left: " + target);
            }));
            if (target.Equals("U"))
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
            }else if (target.Equals("N"))
            {
                mouse_event(MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
            }
            else
            {
                double angle = 0;
                bool flag = double.TryParse(target, out angle);
                if (flag)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                    int interval = Map((int)(angle * 10), 0, 45, 1, 100);
                    RunDelayedTask(interval);
                }
            }

          
        }
  
        private void button1_Click_1(object sender, EventArgs e)
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
   
        private void leftTimer_Tick(object sender, EventArgs e)
        {
       
        }
        async Task RunDelayedTask(int period)
        {
            await Task.Delay(period);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
        }
        async Task RunDelayedTaskR(int period)
        {
            await Task.Delay(period);
            mouse_event(MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += testTimer_tick;
            t.Start();
        }
        private void testTimer_tick(object sender,EventArgs e)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
            RunDelayedTask(200);

        }
        private void rightTimer_Tick(object sender, EventArgs e)
        {
  
        }
        private void ChangeText(String text)
        {
            lstat.Text = text;
        }
        private void ChangeTextR(String text)
        {
            rstat.Text = text;
        }
        private void DataReceivedR(object sender, SerialDataReceivedEventArgs e)
        {

            String target = rightPort.ReadExisting();
            instance.BeginInvoke(new Action(delegate () {
                ChangeText("Right: " + target);
            }));
            if (target.Equals("U"))
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
            }
            else if (target.Equals("N"))
            {
                mouse_event(MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
            }
            else
            {
                double angle = 0;
                bool flag = double.TryParse(target, out angle);
                if (flag)
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                    int interval = Map((int)(angle * 10), 0, 45, 1, 100);
                    RunDelayedTaskR(interval);
                }
            }

        }
    }
}