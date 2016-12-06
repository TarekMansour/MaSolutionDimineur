using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDimineur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button bt = new Button();
                    bt.Width = 30; bt.Height = 30;
                    bt.Top = i*30;
                    bt.Left = j*30;
                    bt.BackColor = Color.DarkSlateBlue;

                    this.panel1.Controls.Add(bt);
                }
            }
          
        }
    }
}
