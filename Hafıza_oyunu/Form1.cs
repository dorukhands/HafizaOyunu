using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hafıza_oyunu
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!","N","N",",",",","k","k", 
            "b","b","v","v","w","w","z","z"
        };
        Label firstClicked, secondClicked;
        public Form1()
        {
            InitializeComponent();
            atama();
           
        }

        private void label_click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;
            
            Label clickedlabel = sender as Label;
            if (clickedlabel == null)
            {
                return;
            }
            if (clickedlabel.ForeColor == Color.Black)
            {
                return;
            }
            if (firstClicked == null)
            {
                firstClicked = clickedlabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }
            secondClicked = clickedlabel;
            secondClicked.ForeColor = Color.Black;

            kazananKontrol();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
            timer1.Start();
        }
        private void kazananKontrol()
        {
            Label label;
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            MessageBox.Show("Tebrikler kazandınız");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;

        }

        private void atama()
        {
            Label label;
            int randomNumber;
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                    continue;
                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];
                icons.RemoveAt(randomNumber);
            }
        }
        
        
        }
    }

