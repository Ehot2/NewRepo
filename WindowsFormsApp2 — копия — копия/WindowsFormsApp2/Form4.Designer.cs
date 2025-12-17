namespace WindowsFormsApp2
{
    partial class Form4
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.wordsListBox = new System.Windows.Forms.ListBox();
            this.gameGridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.ExitButton.Location = new System.Drawing.Point(209, 623);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(164, 43);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Вернуться в меню";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // wordsListBox
            // 
            this.wordsListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.wordsListBox.FormattingEnabled = true;
            this.wordsListBox.Location = new System.Drawing.Point(439, 70);
            this.wordsListBox.Name = "wordsListBox";
            this.wordsListBox.Size = new System.Drawing.Size(120, 95);
            this.wordsListBox.TabIndex = 9;
            // 
            // gameGridPanel
            // 
            this.gameGridPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gameGridPanel.BackColor = System.Drawing.Color.Transparent;
            this.gameGridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameGridPanel.Location = new System.Drawing.Point(209, 70);
            this.gameGridPanel.Name = "gameGridPanel";
            this.gameGridPanel.Size = new System.Drawing.Size(200, 100);
            this.gameGridPanel.TabIndex = 8;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Без_названия;
            this.ClientSize = new System.Drawing.Size(784, 749);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.wordsListBox);
            this.Controls.Add(this.gameGridPanel);
            this.Name = "Form4";
            this.Text = "Филворды (высокая сложнсоть)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ListBox wordsListBox;
        private System.Windows.Forms.Panel gameGridPanel;
    }
}