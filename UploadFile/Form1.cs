using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UploadFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UploadFileUser user = null;
        string filePath = "";
        private void FileChoose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            checkBox1.Enabled = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (filePath == "") filePath = "txt.txt";
            user = new UploadFileUser(Convert.ToInt64(textBox1.Text), checkBox1.Checked, filePath);
            groupBox2.Enabled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) Start.Enabled = true;
            else Start.Enabled = false;
        }

        private void Show_CheckedChanged(object sender, EventArgs e)
        {
            Item.Enabled = false;
            Index.Enabled = true;
        }

        private void Write_CheckedChanged(object sender, EventArgs e)
        {
            Item.Enabled = true;
            Index.Enabled = true;

        }

        private void Delete_CheckedChanged(object sender, EventArgs e)
        {
            Item.Enabled = false;
            Index.Enabled = true;
        }

        private void Do_Click(object sender, EventArgs e)
        {
            Tuple<string, int> pair;
            if (Show.Checked)
            {
                try
                {
                    pair = user.Item(Convert.ToInt64(Index.Text));
                    Item.Text = pair.Item1;
                    label4.Text = pair.Item2.ToString();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (Write.Checked)
                try
                {
                    label4.Text = user.Write(Item.Text, Convert.ToInt64(Index.Text)).ToString();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            if (Delete.Checked) try
                {
                    label4.Text = user.Delete(Convert.ToInt64(Index.Text)).ToString();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
