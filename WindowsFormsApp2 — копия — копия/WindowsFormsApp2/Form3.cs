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
    // [ИЗМЕНЕНИЕ]: Класс называется Form3
    public partial class Form3 : Form 
    {
        // --- Константы и переменные ---
        // [ИЗМЕНЕНИЕ]: Размер сетки 8x8 (Низкая сложность)
        private const int GridSize = 8; 
        private const int ButtonSize = 40; // Стандартный размер кнопки

        private Button[,] gridButtons = new Button[GridSize, GridSize];
        private char[,] letterGrid = new char[GridSize, GridSize];

        // [ИЗМЕНЕНИЕ]: Более короткие слова для низкой сложности
        private readonly List<string> targetWords = new List<string> {
             "ПАУК", "КОД", "СЕТЬ", "ОКНО", "ПАР", "ЯБЛОКО"
        };

        private List<string> foundWords = new List<string>();
        private List<Button> currentSelection = new List<Button>();

        private Color selectionColor = Color.Yellow;
        private Color foundColor = Color.LightGreen;
        private Color defaultColor = Color.Transparent;

        public Form3()
        {
            // Убедитесь, что Form3.Designer.cs содержит wordsListBox, gameGridPanel, и ExitButton.
            InitializeComponent(); 
            this.Text = "Филворд: Низкая сложность (8x8)";
            this.Load += Form3_Load;
            

            gameGridPanel.BorderStyle = BorderStyle.FixedSingle;
            gameGridPanel.Visible = true;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // ===== Настройка GRID и ListBox (используем ту же логику позиционирования) =====
            gameGridPanel.Size = new Size(GridSize * ButtonSize, GridSize * ButtonSize);
            wordsListBox.Width = 150;
            wordsListBox.Height = gameGridPanel.Height;
            int spacing = 20; 
            int totalWidth = gameGridPanel.Width + spacing + wordsListBox.Width;
            int startX = (this.ClientSize.Width - totalWidth) / 2;

            // GRID
            gameGridPanel.Left = startX;
            gameGridPanel.Top = 50;

            // LISTBOX
            wordsListBox.Left = gameGridPanel.Right + spacing;
            wordsListBox.Top = gameGridPanel.Top;
            wordsListBox.Anchor = AnchorStyles.Top;

            

            InitializeGameGrid();
            UpdateWordsListBox();
        }

        private void InitializeGameGrid()
        {
            gameGridPanel.Controls.Clear();
            foundWords.Clear();
            currentSelection.Clear();

            LoadFixedGrid();

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button btn = new Button();
                    btn.Text = letterGrid[i, j].ToString();
                    btn.Size = new Size(ButtonSize, ButtonSize);
                    btn.Location = new Point(j * ButtonSize, i * ButtonSize);
                    btn.Tag = new Point(i, j);
                    btn.BackColor = defaultColor;
                    btn.Font = new Font(btn.Font.FontFamily, 12, FontStyle.Bold); 

                    btn.Click += GridButton_Click;

                    gameGridPanel.Controls.Add(btn);
                    gridButtons[i, j] = btn;
                }
            }
            UpdateWordsListBox();
        }

        /// <summary>
        /// Фиксированная сетка 8x8 для низкой сложности.
        /// </summary>
        private void LoadFixedGrid()
        {
            // [ИЗМЕНЕНИЕ]: Фиксированные данные сетки 8x8 
            string[] fixedGridData = new string[]
            {
                "ПОААСЕТЬ",
                "АКЦИФРТТ",
                "УОКНОЦКФ",
                "ККЛОДИОП",
                "РПАРЯФКВ",
                "АТАУКТЕВ",
                "ЯБЛОКОАЫ",
                "КОДСМТЬТ"
            };

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    letterGrid[i, j] = fixedGridData[i][j];
                }
            }
        }
        
        // --- Методы взаимодействия (аналогично Form1) ---

        private void GridButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || !clickedButton.Enabled) return;

            if (currentSelection.Count == 0)
                StartNewSelection(clickedButton);
            else if (IsAdjacent(currentSelection.Last(), clickedButton))
            {
                ExtendSelection(clickedButton);
                CheckWord();
            }
            else
            {
                ResetSelection();
                StartNewSelection(clickedButton);
            }
        }

        private void StartNewSelection(Button btn)
        {
            currentSelection.Add(btn);
            btn.BackColor = selectionColor;
        }

        private void ExtendSelection(Button btn)
        {
            if (currentSelection.Contains(btn))
            {
                ResetSelection();
                return;
            }
            currentSelection.Add(btn);
            btn.BackColor = selectionColor;
        }

        private void ResetSelection()
        {
            foreach (Button btn in currentSelection)
            {
                if (btn.Enabled)
                    btn.BackColor = defaultColor;
            }
            currentSelection.Clear();
        }

        private void CheckWord()
        {
            if (currentSelection.Count < 2) return;

            string currentWord = "";
            foreach (Button btn in currentSelection)
                currentWord += btn.Text.ToUpper();

            if (targetWords.Contains(currentWord) && !foundWords.Contains(currentWord))
            {
                foundWords.Add(currentWord);
                MarkWordAsFound();

                if (foundWords.Count == targetWords.Count)
                {
                    // [ИЗМЕНЕНИЕ]: Используем кнопку "ОК" для подтверждения победы.
                    // При нажатии "ОК" (которое действует как "Завершить игру"), мы закроем приложение.
                    DialogResult result = MessageBox.Show(
                        "Победа! Уровень завершена", // Текст о победе

                        "Поздравляем! Все слова найдены!",
                        MessageBoxButtons.OK, // Используем стандартную кнопку OK
                        MessageBoxIcon.Information);

                    // После нажатия "ОК" (которое означает, что пользователь подтвердил сообщение),
                    // немедленно завершаем игру.
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void MarkWordAsFound()
        {
            foreach (Button btn in currentSelection)
            {
                btn.BackColor = foundColor;
                btn.Enabled = false; 
            }

            currentSelection.Clear();
            UpdateWordsListBox();
            
            if (foundWords.Count == targetWords.Count)
            {
                 foreach (Button btn in gameGridPanel.Controls.OfType<Button>())
                     btn.Enabled = false;
            }
        }

        private void UpdateWordsListBox()
        {
            wordsListBox.DataSource = targetWords.Except(foundWords).ToList();
        }

        private bool IsAdjacent(Button b1, Button b2)
        {
            Point p1 = (Point)b1.Tag;
            Point p2 = (Point)b2.Tag;
            return Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (foundWords.Count == targetWords.Count)
            {
                this.Close(); // ← Возвращаемся в главное меню
                return;
            }

            DialogResult result = MessageBox.Show(
                "Вы не закончили игру. Вернуться в меню?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                this.Close(); // ← Главное меню появится снова
        }
    }
}