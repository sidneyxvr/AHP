using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHP.UI
{
    public partial class TutorialUI : Form
    {
        private string[] imgs;
        private int i;

        public TutorialUI()
        {
            InitializeComponent();
            imgs = new string[5];
            i = 0;
        }

        private void TutorialUI_Load(object sender, EventArgs e)
        {
            imgs[0] = @"Imagens\step1.jpg";
            imgs[1] = @"Imagens\step2.jpg";
            imgs[2] = @"Imagens\step3.jpg";
            imgs[3] = @"Imagens\step4.jpg";
            pictureBox1.Image = new Bitmap(imgs[i]);
        }

        private object GetFileName()
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            pictureBox1.Image = new Bitmap(i % 4 < 0 ? imgs[-1 * (i % 4)] : imgs[i % 4]);
            label1.Text = "Passo " + (i % 4 < 0 ? ((-1 * (i % 4)) + 1).ToString() : ((i % 4) + 1).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i--;
            pictureBox1.Image = new Bitmap(i % 4 < 0? imgs[-1*(i % 4)]: imgs[i % 4]);
            label1.Text = "Passo " + (i % 4 < 0 ? ((-1 * (i % 4)) + 1).ToString() : ((i % 4) + 1).ToString());
        }
    }
}
