using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Создаем и показываем основную игру
            Form gameForm;

            // Проверяем какая сложность выбрана
            if (easyRadio.Checked)
            {
                gameForm = new Form3(); // 8x8
            }
            else if (mediumRadio.Checked)
            {
                gameForm = new Form1();    // 12x12 (твоя текущая форма)
            }
            else // radioHard.Checked
            {
                gameForm = new Form4(); // 16x16
            }

            // При закрытии основной формы, закрываем все приложение
            gameForm.FormClosed += (s, args) => this.Show();
            gameForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
