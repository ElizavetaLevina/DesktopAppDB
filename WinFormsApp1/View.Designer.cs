﻿namespace WinFormsApp1
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            label1 = new Label();
            textBoxFirstLevel = new TextBox();
            label2 = new Label();
            colorDialog1 = new ColorDialog();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            buttonSave = new Button();
            buttonExit = new Button();
            label3 = new Label();
            textBoxSecondLevelFrom = new TextBox();
            label4 = new Label();
            textBoxSecondLevelBefore = new TextBox();
            label5 = new Label();
            label6 = new Label();
            textBoxThirdLevel = new TextBox();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 58);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 0;
            label1.Text = "Хранение менее";
            // 
            // textBoxFirstLevel
            // 
            textBoxFirstLevel.Location = new Point(213, 55);
            textBoxFirstLevel.Name = "textBoxFirstLevel";
            textBoxFirstLevel.Size = new Size(84, 31);
            textBoxFirstLevel.TabIndex = 1;
            textBoxFirstLevel.TextChanged += TextBoxFirstLevel_TextChanged;
            textBoxFirstLevel.KeyPress += TextBoxFirstLevel_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(302, 58);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 2;
            label2.Text = "дн.       Цвет:";
            // 
            // button1
            // 
            button1.Location = new Point(434, 50);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(547, 116);
            button2.Name = "button2";
            button2.Size = new Size(40, 40);
            button2.TabIndex = 9;
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(434, 179);
            button3.Name = "button3";
            button3.Size = new Size(40, 40);
            button3.TabIndex = 13;
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(382, 260);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(189, 43);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(599, 260);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(189, 43);
            buttonExit.TabIndex = 15;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 124);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 4;
            label3.Text = "Хранение от";
            // 
            // textBoxSecondLevelFrom
            // 
            textBoxSecondLevelFrom.Location = new Point(213, 121);
            textBoxSecondLevelFrom.Name = "textBoxSecondLevelFrom";
            textBoxSecondLevelFrom.ReadOnly = true;
            textBoxSecondLevelFrom.Size = new Size(84, 31);
            textBoxSecondLevelFrom.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 124);
            label4.Name = "label4";
            label4.Size = new Size(33, 25);
            label4.TabIndex = 6;
            label4.Text = "до";
            // 
            // textBoxSecondLevelBefore
            // 
            textBoxSecondLevelBefore.Location = new Point(338, 121);
            textBoxSecondLevelBefore.Name = "textBoxSecondLevelBefore";
            textBoxSecondLevelBefore.Size = new Size(84, 31);
            textBoxSecondLevelBefore.TabIndex = 7;
            textBoxSecondLevelBefore.TextChanged += TextBoxSecondLevelBefore_TextChanged;
            textBoxSecondLevelBefore.KeyPress += TextBoxSecondLevelBefore_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(427, 124);
            label5.Name = "label5";
            label5.Size = new Size(114, 25);
            label5.TabIndex = 8;
            label5.Text = "дн.       Цвет:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 190);
            label6.Name = "label6";
            label6.Size = new Size(144, 25);
            label6.TabIndex = 10;
            label6.Text = "Хранение более";
            // 
            // textBoxThirdLevel
            // 
            textBoxThirdLevel.Location = new Point(213, 184);
            textBoxThirdLevel.Name = "textBoxThirdLevel";
            textBoxThirdLevel.ReadOnly = true;
            textBoxThirdLevel.Size = new Size(84, 31);
            textBoxThirdLevel.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(302, 190);
            label7.Name = "label7";
            label7.Size = new Size(114, 25);
            label7.TabIndex = 12;
            label7.Text = "дн.       Цвет:";
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Location = new Point(-3, 249);
            label8.Name = "label8";
            label8.Size = new Size(807, 2);
            label8.TabIndex = 16;
            // 
            // View
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 313);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxThirdLevel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBoxSecondLevelBefore);
            Controls.Add(label4);
            Controls.Add(textBoxSecondLevelFrom);
            Controls.Add(label3);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBoxFirstLevel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "View";
            Text = "Цвета строчек";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxFirstLevel;
        private Label label2;
        private ColorDialog colorDialog1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button buttonSave;
        private Button buttonExit;
        private Label label3;
        private TextBox textBoxSecondLevelFrom;
        private Label label4;
        private TextBox textBoxSecondLevelBefore;
        private Label label5;
        private Label label6;
        private TextBox textBoxThirdLevel;
        private Label label7;
        private Label label8;
    }
}