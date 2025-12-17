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
    public partial class Form1: Form
    {
        // --- Константы и переменные ---
        private const int GridSize = 12; // Размер сетки 12x12
        private const int ButtonSize = 40; // Размер кнопки в пикселях

        // Двумерный массив кнопок, представляющих игровое поле
        private Button[,] gridButtons = new Button[GridSize, GridSize];
        private char[,] letterGrid = new char[GridSize, GridSize];

        // Список всех слов, которые нужно найти
        private readonly List<string> targetWords = new List<string> {
            "КИСТЬ", "КРОССВОРД", "ОБЛАКО", "АРКА",
            "ПОИСК", "ПОБЕДА", "МАЯК", "ЦИФРА", "КОНТРОЛЬ", "ПРОЕКТ"
        };

        // Список найденных слов
        private List<string> foundWords = new List<string>();

        // Список для отслеживания выбранных в данный момент кнопок
        private List<Button> currentSelection = new List<Button>();

        // Палитра цветов
        private Color selectionColor = Color.Yellow;
        private Color foundColor = Color.LightGreen;
        private Color defaultColor = SystemColors.Control;

        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            
            

            gameGridPanel.BorderStyle = BorderStyle.FixedSingle;
            gameGridPanel.Visible = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // =====  Настройка GRID  =====
            gameGridPanel.Size = new Size(GridSize * ButtonSize, GridSize * ButtonSize);

            // =====  Настройка ListBox  =====
            wordsListBox.Width = 150;
            wordsListBox.Height = gameGridPanel.Height;
            int spacing = 20; // расстояние между Grid и ListBox

            // Общая ширина игрового блока (Grid + ListBox)
            int totalWidth = gameGridPanel.Width + spacing + wordsListBox.Width;

            // Смещаем ближе к центру формы (не растягиваем вправо)
            int startX = (this.ClientSize.Width - totalWidth) / 2;

            // GRID
            gameGridPanel.Left = startX;
            gameGridPanel.Top = 50;

            // LISTBOX
            wordsListBox.Left = gameGridPanel.Right + spacing;
            wordsListBox.Top = gameGridPanel.Top;

            // =====  Кнопка выхода =====
            // Центрируем по форме 
            
            InitializeGameGrid();
            // Начинаем игру при загрузке
            UpdateWordsListBox();
        }

        

        /// <summary>
        /// Создает игровое поле, размещает заглушки (буквы) и обновляет список слов.
        /// В реальной игре здесь должен быть алгоритм генерации слов.
        /// </summary>
        private void InitializeGameGrid()
        {
            gameGridPanel.Controls.Clear();
            foundWords.Clear();
            currentSelection.Clear();

            LoadFixedGrid();

            // Создание сетки кнопок
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button btn = new Button();

                    // Используем букву из фиксированного поля
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

            // Обновление списка слов
            UpdateWordsListBox();
        }

        /// <summary>
        /// Вспомогательная функция для получения случайной русской буквы.
        /// </summary>
        private void LoadFixedGrid()
        {
            // Фиксированные данные сетки 12x12
            string[] fixedGridData = new string[]
            {
                "КИСТЬАЫЧИРЕЬ",
                "КПВЫЕИОБЛАКО",
                "РПОИСКВМЕОЦС",
                "ООМТЬПОБЕДАК",
                "СЬААРФИЦРОЛЫ",
                "СРЯКОНТРОЛЬА",
                "ВЕКОКУАПЛИРЕ",
                "ОЕЛЬНОКРНОКТ",
                "РОПАРЧРОЛРРЬ",
                "ДРКОЗЬАЕЬЬАЯ",
                "АРКАРПККЕТКЯ",
                "КЦИФРАЬТДЬЬА"
            };

            // Загружаем данные в letterGrid
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    // Используем символ из загруженных данных, переводя его в верхний регистр
                    letterGrid[i, j] = fixedGridData[i][j];
                }
            }
        }
        private void GridButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || !clickedButton.Enabled) return;

            if (currentSelection.Count == 0)
            {
                // Начало нового выбора
                StartNewSelection(clickedButton);
            }
            else if (IsAdjacent(currentSelection.Last(), clickedButton))
            {
                // Расширение выбора
                ExtendSelection(clickedButton);
                CheckWord();
            }
            else
            {
                // Несоседняя кнопка, начинаем новый выбор
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
            // Проверка, чтобы избежать повторного выбора одной и той же кнопки
            if (currentSelection.Contains(btn))
            {
                // Пользователь кликнул на уже выбранную кнопку, сброс выбора
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
                // Сброс цвета только если кнопка не найдена (не зеленая)
                if (btn.Enabled)
                {
                    btn.BackColor = defaultColor;
                }
            }
            currentSelection.Clear();
        }

        // --- Проверка Слова ---

        private void CheckWord()
        {
            if (currentSelection.Count < 2) return;

            // Составляем текущее выбранное слово (в верхнем регистре)
            string currentWord = "";
            foreach (Button btn in currentSelection)
            {
                currentWord += btn.Text.ToUpper();
            }

            // Проверка: слово должно быть целевым и еще не найденным
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

        private string GetCurrentWord()
        {
            string currentWord = "";
            foreach (Button btn in currentSelection)
            {
                currentWord += btn.Text.ToUpper();
            }
            return currentWord;
        }

        private void MarkWordAsFound()
        {
            foreach (Button btn in currentSelection)
            {
                btn.BackColor = foundColor;
                btn.Enabled = false; // Отключаем кнопки, чтобы нельзя было использовать их повторно
            }

            // Очищаем текущий выбор, чтобы начать новый
            currentSelection.Clear();
            UpdateWordsListBox();
        }

        private void UpdateWordsListBox()
        {
            // Обновление ListBox: отображаем только те слова, которые еще не найдены
            wordsListBox.DataSource = targetWords.Except(foundWords).ToList();
        }

        // --- Вспомогательные функции ---

        /// <summary>
        /// Проверяет, является ли b2 соседней по отношению к b1 (горизонтально, вертикально, диагонально).
        /// </summary>
        private bool IsAdjacent(Button b1, Button b2)
        {
            Point p1 = (Point)b1.Tag;
            Point p2 = (Point)b2.Tag;

            // Проверяем, что разница в координатах X и Y не более 1
            return Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1;
        }

        private void gameGridPanel_Paint(object sender, PaintEventArgs e)
        {

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

