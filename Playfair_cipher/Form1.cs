using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Playfair_cipher
{
    public partial class Form1 : Form
    {
        private char[,] keyTable;
        private int matrixSize = 5; // Mặc định là 5x5

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

            // Khởi tạo ComboBox
            comboBox1.Items.Add("5x5");
            comboBox1.Items.Add("6x6");
            comboBox1.SelectedIndex = 0; // Mặc định chọn 5x5

            comboBox1.SelectedIndexChanged += (sender, e) => UpdateMatrixSize();
        }
        private void UpdateMatrixSize()
        {
            if (comboBox1.SelectedItem.ToString() == "5x5")
            {
                matrixSize = 5;
            }
            else if (comboBox1.SelectedItem.ToString() == "6x6")
            {
                matrixSize = 6;
            }
        }

        private void GenerateKeyTable(string key)
        {
            char[] alphabet;

            if (matrixSize == 5)
            {
                alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray(); // Không bao gồm J
            }
            else // 6x6
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            }

            Regex rgx = new Regex("[^A-Z0-9]");
            key = rgx.Replace(key.ToUpper(), ""); // Xóa các ký tự không hợp lệ
            key = new string(key.Distinct().ToArray()); // Loại bỏ ký tự trùng nhưng giữ nguyên thứ tự

            // Loại bỏ các ký tự trong key ra khỏi bảng alphabet
            foreach (char c in key)
                alphabet = alphabet.Where(x => x != c).ToArray();

            // Tạo chuỗi key đầy đủ (key + các ký tự còn lại trong alphabet)
            string keyString = key + new string(alphabet);

            // Điều chỉnh kích thước keyTable
            keyTable = new char[matrixSize, matrixSize];

            // Điền vào keyTable
            for (int i = 0; i < matrixSize; i++)
                for (int j = 0; j < matrixSize; j++)
                    keyTable[i, j] = keyString[i * matrixSize + j];

            // Hiển thị bảng mã trong textBox2
            string keyMatrix = "";
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    keyMatrix += keyTable[i, j] + " ";
                }
                keyMatrix += Environment.NewLine;
            }
            textBox2.Text = keyMatrix;
        }





        private string ProcessText(string input, bool isEncrypt)
        {
            Regex rgx = new Regex("[^A-Z0-9]");
            input = rgx.Replace(input.ToUpper(), ""); // Chỉ giữ chữ cái và số nếu cần
            if (matrixSize == 5)
            {
                input = input.Replace('J', 'I'); // Thay thế J bằng I
            }

            // Nếu số ký tự lẻ, thêm 'X'
            if (input.Length % 2 != 0) input += "X";

            string result = "";
            string keyString = string.Join("", keyTable.Cast<char>());

            for (int i = 0; i < input.Length; i += 2)
            {
                int indexA = keyString.IndexOf(input[i]);
                int indexB = keyString.IndexOf(input[i + 1]);
                int rowA = indexA / matrixSize, colA = indexA % matrixSize;
                int rowB = indexB / matrixSize, colB = indexB % matrixSize;

                if (colA == colB) // Cùng cột
                {
                    result += keyTable[(rowA + (isEncrypt ? 1 : -1) + matrixSize) % matrixSize, colA];
                    result += keyTable[(rowB + (isEncrypt ? 1 : -1) + matrixSize) % matrixSize, colB];
                }
                else if (rowA == rowB) // Cùng hàng
                {
                    result += keyTable[rowA, (colA + (isEncrypt ? 1 : -1) + matrixSize) % matrixSize];
                    result += keyTable[rowB, (colB + (isEncrypt ? 1 : -1) + matrixSize) % matrixSize];
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
