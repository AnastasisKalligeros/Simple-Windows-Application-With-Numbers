using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2atomikiergasia
{
    public partial class Form1 : Form
    {
        List<Button> buttonList = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            Color[] colorArray;
            colorArray = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.White, Color.Purple };
            Random r = new Random();
            try
            {
                num = Convert.ToInt32(this.textBox1.Text);
            }
            catch (Exception)
            {
                return;
            }
            int num2 = 100;
            int num3 = 100;
            int num4 = 60;
            int num5 = 60;
            int width = 50;
            int height = 50;
            int num8 = ((base.Width - num2) / num4) * num4;
            
            for (int i = 0; i < num; i++)
            {
                Button button = new Button
                {
                    Size = new Size(width, height)
                };
                int num10 = (((i * num4) % num8) / num4) * num4;
                int num11 = ((i * num4) / num8) * num5;
                button.Location = new Point(num2 + num10, num3 +     num11);
                int index = r.Next(0, 6);
                button.BackColor = colorArray[index];
                button.Text = (i + 1).ToString();
                button.Click += new EventHandler(myClick);
                base.Controls.Add(button);
                buttonList.Add(button);
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            if (buttonList.Count != 0)
            {
                foreach (Button button in buttonList)
                {
                    base.Controls.Remove(button);
                }
                buttonList.Clear();
            }
        }
     

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (buttonList.Count == 0)
            {
                button1.PerformClick();
            }
        }

        public void myClick(object o, EventArgs e)
        {
            MessageBox.Show(((Button)o).Text);
        }
    }
}
