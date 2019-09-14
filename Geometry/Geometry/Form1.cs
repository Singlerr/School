using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    public partial class Form1 : Form
    {
        double timePrev = 0;
        double time;
        double x, y = 0;
        bool created = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public double func(double x)
        {
            return 7*Math.Pow(x,40)+ 5*Math.Pow(x, 6) + 2*Math.Pow(x, 5) + 5*Math.Pow(x, 6) + 5*Math.Pow(x, 4) + 5;
        }
        public double f(double x,double h)
        {
            return (func(x + h) - func(x)) / h;
        }
        public double Calculate(double x)
        {
            double timePrev = Current();
            for(int i = 0; i < 1000000; i++)
            {
               
            }
           double  time = Current();
            double t = (time - timePrev) / 1000;
            return f(x, t);

        }
        protected override void OnPaint(PaintEventArgs e)
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
            progressBar1.Value = 0;
            x = -20;
            timer1.Start();
        
            /*  for (double x = -20;x<20;x += 0.1)
                {
                    
                    geo.Series["main"].Points.AddXY(x, Calculate(x));
                  
                }
            */
        }
        public double acc = Math.Pow(10, -10);
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
            if (x < 20)
            {
                double y = Calculate(x);
                if (y >= -20 && y <= 20) {
                    geo.Series["main"].Points.AddXY(x,y);
                    progressBar1.Increment(1);
                }
                x += 0.1;
                
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
