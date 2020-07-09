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

        private void btnIndexDisplayNodesByName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
                return;

            richTextBox2.Clear();

            List<XElement> nodes = Utilities.GetNodesByName(richTextBox1.Text, textBox1.Text);

            foreach(XElement node in nodes)
            {
                richTextBox2.AppendText(node.ToString() + Environment.NewLine);
            }
        }

        private void btnIndexLastMeshNodeIndex_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
                return;

            richTextBox2.Clear();

            string lastIndex = Index.GetLargestMeshIndex(richTextBox1.Text);
            string lastID = Index.GetLargestMeshID(richTextBox1.Text);

            richTextBox2.Text = lastIndex + Environment.NewLine;
            richTextBox2.AppendText(lastID);
        }
    }
}
