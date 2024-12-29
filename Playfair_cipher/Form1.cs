// File: Form1.cs
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Playfair_cipher
{
    public partial class Form1 : Form
    {
        private char[,] keyTable = new char[5, 5];

        public Form1()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // Gán sự kiện cho các nút
            button1.Click += (sender, e) => Encrypt();
            button2.Click += (sender, e) => Decrypt();
            button3.Click += (sender, e) => ClearTextBoxes();
        }

        private void GenerateKeyTable(string key)
        {
            char[] alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray(); // Không bao gồm J
            Regex rgx = new Regex("[^A-Z]");
            key = rgx.Replace(key.ToUpper(), ""); // Xóa các ký tự không hợp lệ
            key = new string(key.Distinct().ToArray()); // Loại bỏ ký tự trùng

            // Loại bỏ các ký tự trong key ra khỏi bảng alphabet
            foreach (char c in key)
                alphabet = alphabet.Where(x => x != c).ToArray();

            string keyString = key + new string(alphabet);

            // Điền vào keyTable
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    keyTable[i, j] = keyString[i * 5 + j];

            // Hiển thị bảng mã trong textBox2
            string keyMatrix = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    keyMatrix += keyTable[i, j] + " ";
                }
                keyMatrix += Environment.NewLine;
            }
            textBox2.Text = keyMatrix;
        }

        private string ProcessText(string input, bool isEncrypt)
        {
            Regex rgx = new Regex("[^A-Z]");
            input = rgx.Replace(input.ToUpper(), ""); // Chỉ giữ chữ cái
            input = input.Replace('J', 'I'); // Thay thế J bằng I

            // Nếu số ký tự lẻ, thêm 'X'
            if (input.Length % 2 != 0) input += "X";

            string result = "";
            string keyString = string.Join("", keyTable.Cast<char>());

            for (int i = 0; i < input.Length; i += 2)
            {
                int indexA = keyString.IndexOf(input[i]);
                int indexB = keyString.IndexOf(input[i + 1]);
                int rowA = indexA / 5, colA = indexA % 5;
                int rowB = indexB / 5, colB = indexB % 5;

                if (colA == colB) // Cùng cột
                {
                    result += keyTable[(rowA + (isEncrypt ? 1 : -1) + 5) % 5, colA];
                    result += keyTable[(rowB + (isEncrypt ? 1 : -1) + 5) % 5, colB];
                }
                else if (rowA == rowB) // Cùng hàng
                {
                    result += keyTable[rowA, (colA + (isEncrypt ? 1 : -1) + 5) % 5];
                    result += keyTable[rowB, (colB + (isEncrypt ? 1 : -1) + 5) % 5];
                }
                else // Thành hình chữ nhật
                {
                    result += keyTable[rowA, colB];
                    result += keyTable[rowB, colA];
                }
            }

            return result;
        }

        private void Encrypt()
        {
            string key = textBox1.Text;
            string inputText = textBox3.Text;

            GenerateKeyTable(key);
            string encryptedText = ProcessText(inputText, true);

            textBox4.Text = encryptedText;
        }

        private void Decrypt()
        {
            string key = textBox1.Text;
            string inputText = textBox3.Text;

            GenerateKeyTable(key);
            string decryptedText = ProcessText(inputText, false);

            textBox4.Text = decryptedText;
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
