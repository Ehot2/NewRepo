namespace WindowsFormsApp2
{
    partial class Form2
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
            this.Startbutton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.easyRadio = new System.Windows.Forms.RadioButton();
            this.mediumRadio = new System.Windows.Forms.RadioButton();
            this.hardRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Startbutton
            // 
            this.Startbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Startbutton.BackColor = System.Drawing.Color.Transparent;
            this.Startbutton.FlatAppearance.BorderSize = 0;
            this.Startbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Startbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Startbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Startbutton.Font = new System.Drawing.Font("Arial", 23.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Startbutton.ForeColor = System.Drawing.Color.Lime;
            this.Startbutton.Location = new System.Drawing.Point(229, 521);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(141, 66);
            this.Startbutton.TabIndex = 0;
            this.Startbutton.Text = "Старт";
            this.Startbutton.UseVisualStyleBackColor = false;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Arial", 23.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.Red;
            this.ExitButton.Location = new System.Drawing.Point(410, 521);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(134, 66);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 50.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(113, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 76);
            this.label1.TabIndex = 2;
            this.label1.Text = "Игра Филворды";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(207, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(395, 46);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выбор сложности";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // easyRadio
            // 
            this.easyRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.easyRadio.AutoSize = true;
            this.easyRadio.BackColor = System.Drawing.Color.Transparent;
            this.easyRadio.Checked = true;
            this.easyRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic);
            this.easyRadio.Location = new System.Drawing.Point(311, 342);
            this.easyRadio.Name = "easyRadio";
            this.easyRadio.Size = new System.Drawing.Size(125, 35);
            this.easyRadio.TabIndex = 4;
            this.easyRadio.TabStop = true;
            this.easyRadio.Text = "Низкая";
            this.easyRadio.UseVisualStyleBackColor = false;
            // 
            // mediumRadio
            // 
            this.mediumRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mediumRadio.AutoSize = true;
            this.mediumRadio.BackColor = System.Drawing.Color.Transparent;
            this.mediumRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic);
            this.mediumRadio.Location = new System.Drawing.Point(310, 392);
            this.mediumRadio.Name = "mediumRadio";
            this.mediumRadio.Size = new System.Drawing.Size(143, 35);
            this.mediumRadio.TabIndex = 5;
            this.mediumRadio.Text = "Средняя";
            this.mediumRadio.UseVisualStyleBackColor = false;
            // 
            // hardRadio
            // 
            this.hardRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hardRadio.AutoSize = true;
            this.hardRadio.BackColor = System.Drawing.Color.Transparent;
            this.hardRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic);
            this.hardRadio.Location = new System.Drawing.Point(311, 444);
            this.hardRadio.Name = "hardRadio";
            this.hardRadio.Size = new System.Drawing.Size(142, 35);
            this.hardRadio.TabIndex = 6;
            this.hardRadio.Text = "Высокая";
            this.hardRadio.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Без_названия;
            this.ClientSize = new System.Drawing.Size(800, 735);
            this.Controls.Add(this.hardRadio);
            this.Controls.Add(this.mediumRadio);
            this.Controls.Add(this.easyRadio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Startbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Филворды";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton easyRadio;
        private System.Windows.Forms.RadioButton mediumRadio;
        private System.Windows.Forms.RadioButton hardRadio;
    }
}