using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNATranslator
{
    public partial class Form1 : Form
    {
        public Dictionary<char, int> d = new Dictionary<char, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Setup();
        }
        private void Setup()
        {
            d.Add('A', 0);
            d.Add('B', 1);
            d.Add('C', 2);
            d.Add('D',3);
            d.Add('E', 01);
            d.Add('F', 02);
            d.Add('G', 03);
            d.Add('H', 10);
            d.Add('I', 11);
            d.Add('J', 12);
            d.Add('K', 13);
            d.Add('L', 20);
            d.Add('M', 21);
            d.Add('N', 22);
            d.Add('O',23);
            d.Add('P', 30);
            d.Add('Q', 31);
            d.Add('R',32);
            d.Add('S', 33);
            d.Add('T', 100);
            d.Add('U', 101);
            d.Add('V', 102);
            d.Add('W', 103);
            d.Add('X', 110);
            d.Add('Y', 111);
            d.Add('Z',112);
        }
        private char Get(int id)
        {
            switch (id)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'G';
                case 2:
                    return 'C';
                case 3:
                    return 'T';
                
                default:
                    return ' ';
            }
        }
        private void Set(StringBuilder builder,int id)
        {
            if(id >= 100)
            {
                int first = (int)id / 100;
                int middle = (int)(id - (first * 100))/10;
                int last = id - (middle * 10);
                builder.Append(Get(first)).Append(Get(middle)).Append(Get(last));
            }
            else 
            if(id >= 10)
            {
                int first = (int)id / 10;
                int last = id - (first * 10);
                builder.Append(Get(first)).Append(Get(last));
            }
            else
            {
                builder.Append(Get(id));
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //
            String str = input.Text;
            char[] chars = str.ToUpper().ToCharArray();
            StringBuilder builder = new StringBuilder();
           for(int i = 0; i < chars.Length; i++)
            {
                if (d.ContainsKey(chars[i]))
                {
                    Set(builder, d[chars[i]]);
                }
                else
                {
                    builder.Append(' ');
                }
            }
            output.Text = builder.ToString();
        }
    }
}
