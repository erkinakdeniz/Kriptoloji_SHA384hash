using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Kriptoloji_SHA384
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            //Şifrelemek istediğimiz metin seçilir.
            string sifrelenecekMetin = textBox1.Text;
            //SHA384 Class kullandık.
            using(SHA384 sHA384Hash=SHA384.Create())
            {
                //Metni bitlere çevirdik
                byte[] sifrelenecekMetinBytes = Encoding.ASCII.GetBytes(sifrelenecekMetin);
                //çevirdiğimiz bitleri SHA384'e çevirdik
                byte[] hashBytes = sHA384Hash.ComputeHash(sifrelenecekMetinBytes);
                //Çevrilen SHA384 bitlerini string karaktere çevirdik. Çevirme esnasında Aralarda yer alan - işareti aradan kaldırdık.
                string sifrelihash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                //richtextbox içine şifrelenen metni attık.
                richTextBox1.Text = sifrelihash;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
