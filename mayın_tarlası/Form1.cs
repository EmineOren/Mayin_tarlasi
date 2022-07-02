using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mayın_tarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            butonüret();

        }

        private void butonüret()
        {
            flowLayoutPanel1.Controls.Clear();
            Random rnd = new Random();
            List<int> mayinlar = new List<int>();
            for (int i = 1;mayinlar.Count <15; i++)
            {
                int sayi = rnd.Next(1, 61);
                if (!mayinlar.Contains(sayi))
                {
                    mayinlar.Add(sayi);
                }

            }


            for (int i =1; i < 61; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(35, 35);
                btn.Text = i.ToString();
                if (mayinlar.Contains(i))
                {
                    btn.Tag = true;
                }
                else
                {
                    btn.Tag = false;       
                }
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);

            }
        }
        int secilen = 0;
        int bulunan = 0;

        private void Btn_Click(object sender, EventArgs e)
        {
            Button basilanButon = (Button)sender;
            bool mayin = (bool)basilanButon.Tag;
            secilen++;
            if (mayin)
            {
                basilanButon.BackColor = Color.Red;
                basilanButon.Enabled = false;
                MessageBox.Show("Bravo! Mayını Buldun", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bulunan++;
                secilen--;
            }
            else
            {
                basilanButon.BackColor = Color.Blue;
            }
            textBox1.Text = secilen.ToString();
            textBox2.Text = bulunan.ToString();
            if (bulunan>=15)
            {
       DialogResult dialogResult = MessageBox.Show("Tüm mayınları buldun. devam etmek istermisin?", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (dialogResult==DialogResult.OK)
                {
                    butonüret();
                    bulunan = 0;
                    secilen = 0;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
