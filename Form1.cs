using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalisanYonetimSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Calisanlar().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GorevlerForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Izinler().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MaasBilgileri().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new PerformansDegerlendirmeleri().ShowDialog();
        }
    }
}
