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
using System.Xml.Linq;
using IMVUCal3DLib;

namespace LibTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "IMVU ASSET|*.xml;*.xpf;*.xaf;*.xmf;*.xsf;*.xrf" })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Material material = new Material(richTextBox1.Text);                       

            richTextBox2.Text = material.GetMapTextureName();
        }
    }
}
