using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGraph
{
    public partial class Form1 : Form
    {
        double anglePrev = 0;
        double time, timePrev = 0;
        public static Form1 instance;
        double x,y= 0;
        static SerialPort port;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            geo.ChartAreas.Clear();
            geo.Series.Clear();
            geo.ChartAreas.Add("Draw");
            geo.ChartAreas["Draw"].BackColor = Color.White;
            geo.ChartAreas["Draw"].BackColor = Color.White;
            geo.ChartAreas["Draw"].AxisX.Maximum = 300;
            geo.ChartAreas["Draw"].AxisX.Minimum = -100;
            geo.ChartAreas["Draw"].AxisX.Interval = 1;
            geo.ChartAreas["Draw"].AxisX.MajorGrid.LineColor = Color.Black;
            geo.ChartAreas["Draw"].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            geo.ChartAreas["Draw"].AxisY.Maximum = 300;
            geo.ChartAreas["Draw"].AxisY.Minimum = -100;
            geo.ChartAreas["Draw"].AxisY.Interval = 1;
            geo.ChartAreas["Draw"].AxisY.MajorGrid.LineColor = Color.Black;
            geo.ChartAreas["Draw"].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            geo.Series.Add("main");
            geo.Series["main"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            geo.Series["main"].Color = Color.Blue;
            geo.Series["main"].BorderWidth = 2;
            geo.Series["main"].LegendText = "x";
        }
        public double func(double x)
        {
            return 7 * Math.Pow(x, 40) + 5 * Math.Pow(x, 6) + 2 * Math.Pow(x, 5) + 5 * Math.Pow(x, 6) + 5 * Math.Pow(x, 4) + 5;
        }
        public double f(double x,double xPrev, double h)
        {
            return (x - xPrev) / h;
        }
        public double Calculate(double x,double xPrev)
        {

            for (int i = 0; i < 1000000; i++)
            {

            }
            
            double t = (time - timePrev) / 1000;
            return f(x, xPrev,t);

        }
     /*   protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            geo.ChartAreas.Clear();
            geo.Series.Clear();
            geo.ChartAreas.Add("Draw");
            geo.ChartAreas["Draw"].BackColor = Color.White;
            geo.ChartAreas["Draw"].BackColor = Color.White;
            geo.ChartAreas["Draw"].AxisX.Maximum = 20;
            geo.ChartAreas["Draw"].AxisX.Minimum = -20;
            geo.ChartAreas["Draw"].AxisX.Interval = 2;
            geo.ChartAreas["Draw"].AxisX.MajorGrid.LineColor = Color.Black;
            geo.ChartAreas["Draw"].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            geo.ChartAreas["Draw"].AxisY.Maximum = 20;
            geo.ChartAreas["Draw"].AxisY.Minimum = -20;
            geo.ChartAreas["Draw"].AxisY.Interval = 2;
            geo.ChartAreas["Draw"].AxisY.MajorGrid.LineColor = Color.Black;
            geo.ChartAreas["Draw"].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            geo.Series.Add("main");
            geo.Series["main"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            geo.Series["main"].Color = Color.Blue;
            geo.Series["main"].BorderWidth = 2;
            geo.Series["main"].LegendText = "x";
         
            x = -20;
            timer1.Start();

              for (double x = -20;x<20;x += 0.1)
                {
                    
                    geo.Series["main"].Points.AddXY(x, Calculate(x));
                  
                }
           
            
        }*/
        public void Draw(double y)
        {
            // geo.ChartAreas.Clear();
            //  geo.Series.Clear();
            //  geo.ChartAreas.Add("Draw");
           
                geo.ChartAreas["Draw"].AxisX.Maximum = 20+x;
                geo.ChartAreas["Draw"].AxisX.Minimum = -20+x;
                geo.Series["main"].Points.AddXY(x, y);
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            x = -20;
            timer1.Start();
        }
        public static double Current()
        {
            DateTime Jan1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan javaSpan = DateTime.UtcNow - Jan1970;
            return javaSpan.TotalMilliseconds;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
           
        }
        public void Set(String s)
        {
            label1.Text = s;
        }
        private void DataReceived(object sender,SerialDataReceivedEventArgs e)
        {
          
            double angle = 0;
            bool b = double.TryParse(port.ReadExisting(), out angle);
            if (b)
            {
                time = Current();
                y = Calculate(angle, anglePrev) / 10;
                instance.BeginInvoke(new Action(delegate ()
                {
                    Set(y.ToString());
                }));
                if (y >= -20 && y <= 20)
                {
                    instance.BeginInvoke(new Action(delegate ()
                    {
                        Draw(y);
                    }));
                }
                anglePrev = angle;
                x += 0.1;
                timePrev = Current();
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            String[] strs = lines.Lines;
            int y;
           
            foreach(String str in strs)
            {
                bool b = int.TryParse(str, out y);
                if (b)
                {
                    Draw(y);
                    x += 0.1;
                }
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            port = new SerialPort();
            port.PortName = textBox1.Text;
            port.BaudRate = 115200;
            port.Open();
            /* System.Threading.Thread t = new System.Threading.Thread(delegate ()
             {
                 while (true)
                 {

                     double angle = 0;
                     instance.BeginInvoke(new Action(delegate()
                     {
                         Draw(Calculate(angle, anglePrev));
                     }));

                     anglePrev = angle;
                     x += 0.1;
                 }
             });
             t.Start();*/
            timer2.Interval = 10;
            port.DataReceived += DataReceived;
            timePrev = Current();

        //    timer2.Start();
        }
       
        private void Timer2_Tick(object sender, EventArgs e)
        {
            double angle = 0;
            bool b = double.TryParse(port.ReadExisting(), out angle);
            if (b)
            {
                y = Calculate(angle, anglePrev);
                if (y >= -20 && y <= 20)
                {
                    Draw(y);
                }
                anglePrev = angle;
                x += 0.1;
            }
        }
    }
}
