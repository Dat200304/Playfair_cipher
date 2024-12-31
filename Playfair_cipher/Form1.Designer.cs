using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Playfair_cipher
{
    partial class Form1
    {
        /// <summary>
        /// Biến cần thiết cho Designer.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Dọn dẹp các tài nguyên đang được sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu các tài nguyên quản lý cần được giải phóng; ngược lại là false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Mã được tạo ra bởi Designer Form

        /// <summary>
        /// Phương thức yêu cầu hỗ trợ Designer - không sửa đổi nội dung của phương thức này trong trình soạn thảo mã.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(39, 39);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(413, 49);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlLight;
            textBox2.Font = new System.Drawing.Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(39, 129);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(286, 380);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(490, 120);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(497, 154);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.ControlLight;
            textBox4.Location = new Point(490, 313);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(497, 163);
            textBox4.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.DimGray;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(331, 193);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(121, 59);
            button1.TabIndex = 4;
            button1.Text = "Encrypt";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDarkDark;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(331, 278);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(121, 59);
            button2.TabIndex = 5;
            button2.Text = "Decrypt";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDarkDark;
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(331, 358);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(121, 59);
            button3.TabIndex = 6;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 7;
            label1.Text = "KEY";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(490, 96);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 8;
            label2.Text = "INPUT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(490, 289);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 9;
            label3.Text = "OUTPUT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 105);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 10;
            label4.Text = "KEY MATRIX";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(331, 129);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 28);
            comboBox1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 507);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Playfair Cipher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ComboBox comboBox1;
    }
}
