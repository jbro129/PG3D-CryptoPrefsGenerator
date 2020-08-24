using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PG3D_CryptoPrefsGen2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Jformat(string orig)
        {
            return orig.Replace("%3a", "%3A").Replace("%2b", "%2B").Replace("%2f", "%2F").Replace("%3d", "%3D");
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            EncryptKeyOut.Text = Jformat(HttpUtility.UrlEncode(CryptoPrefsCreater.WrapKey(EncryptKeyIn.Text)));
            EncryptValueOut.Text = Jformat(HttpUtility.UrlEncode(CryptoPrefsCreater.GetValueFromKey(EncryptKeyIn.Text, EncryptValueIn.Text)));
            FullTextEnc.Text = "<string name=\"" + EncryptKeyOut.Text + "\">" + EncryptValueOut.Text + "</string>";
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            DecryptKeyOut.Text = CryptoPrefsDecryptor.UnWrapKey(HttpUtility.UrlDecode(DecryptKeyIn.Text));
            DecryptValueOut.Text = CryptoPrefsDecryptor.GetValueFromKey(HttpUtility.UrlDecode(DecryptKeyIn.Text), HttpUtility.UrlDecode(DecryptValueIn.Text));
            FullTextDec.Text = "<string name=\"" + DecryptKeyOut.Text + "\">" + DecryptValueOut.Text + "</string>";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void EncryptKeyIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EncryptValueIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void EncryptKeyOut_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EncryptValueOut_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
