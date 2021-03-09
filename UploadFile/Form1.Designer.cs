
namespace UploadFile
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.FileChoose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.RadioButton();
            this.Write = new System.Windows.Forms.RadioButton();
            this.Show = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Index = new System.Windows.Forms.TextBox();
            this.Item = new System.Windows.Forms.TextBox();
            this.Do = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.FileChoose);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(6, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Rewrite";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Item Count";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Start
            // 
            this.Start.Enabled = false;
            this.Start.Location = new System.Drawing.Point(2, 122);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "START";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // FileChoose
            // 
            this.FileChoose.Location = new System.Drawing.Point(6, 19);
            this.FileChoose.Name = "FileChoose";
            this.FileChoose.Size = new System.Drawing.Size(100, 35);
            this.FileChoose.TabIndex = 0;
            this.FileChoose.Text = "Choose upload file";
            this.FileChoose.UseVisualStyleBackColor = true;
            this.FileChoose.Click += new System.EventHandler(this.FileChoose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Delete);
            this.groupBox2.Controls.Add(this.Write);
            this.groupBox2.Controls.Add(this.Show);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Index);
            this.groupBox2.Controls.Add(this.Item);
            this.groupBox2.Controls.Add(this.Do);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(18, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 166);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 10;
            // 
            // Delete
            // 
            this.Delete.AutoSize = true;
            this.Delete.Location = new System.Drawing.Point(111, 116);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(56, 17);
            this.Delete.TabIndex = 8;
            this.Delete.TabStop = true;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.CheckedChanged += new System.EventHandler(this.Delete_CheckedChanged);
            // 
            // Write
            // 
            this.Write.AutoSize = true;
            this.Write.Location = new System.Drawing.Point(111, 93);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(50, 17);
            this.Write.TabIndex = 7;
            this.Write.TabStop = true;
            this.Write.Text = "Write";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.CheckedChanged += new System.EventHandler(this.Write_CheckedChanged);
            // 
            // Show
            // 
            this.Show.AutoSize = true;
            this.Show.Location = new System.Drawing.Point(111, 70);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(52, 17);
            this.Show.TabIndex = 6;
            this.Show.TabStop = true;
            this.Show.Text = "Show";
            this.Show.UseVisualStyleBackColor = true;
            this.Show.CheckedChanged += new System.EventHandler(this.Show_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Index";
            // 
            // Index
            // 
            this.Index.Location = new System.Drawing.Point(6, 37);
            this.Index.Name = "Index";
            this.Index.Size = new System.Drawing.Size(100, 20);
            this.Index.TabIndex = 3;
            // 
            // Item
            // 
            this.Item.Location = new System.Drawing.Point(6, 103);
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(100, 20);
            this.Item.TabIndex = 2;
            // 
            // Do
            // 
            this.Do.Location = new System.Drawing.Point(6, 129);
            this.Do.Name = "Do";
            this.Do.Size = new System.Drawing.Size(75, 23);
            this.Do.TabIndex = 1;
            this.Do.Text = "Do";
            this.Do.UseVisualStyleBackColor = true;
            this.Do.Click += new System.EventHandler(this.Do_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 346);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button FileChoose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Index;
        private System.Windows.Forms.TextBox Item;
        private System.Windows.Forms.Button Do;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Delete;
        private System.Windows.Forms.RadioButton Write;
        private System.Windows.Forms.RadioButton Show;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
    }
}

