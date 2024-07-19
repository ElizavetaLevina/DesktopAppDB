namespace WinFormsApp1
{
    partial class MessageToClient
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageToClient));
            label1 = new Label();
            textBoxPhone = new TextBox();
            contextMenu = new ContextMenuStrip(components);
            item1 = new ToolStripMenuItem();
            item2 = new ToolStripMenuItem();
            buttonChangeNumber = new Button();
            label2 = new Label();
            textBoxPort = new TextBox();
            label3 = new Label();
            textBoxMessage = new TextBox();
            label4 = new Label();
            label5 = new Label();
            buttonExit = new Button();
            buttonSend = new Button();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(154, 25);
            label1.TabIndex = 2;
            label1.Text = "Номер телефона:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(172, 40);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.ReadOnly = true;
            textBoxPhone.Size = new Size(230, 31);
            textBoxPhone.TabIndex = 1;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(24, 24);
            contextMenu.Items.AddRange(new ToolStripItem[] { item1, item2 });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(297, 68);
            // 
            // item1
            // 
            item1.Name = "item1";
            item1.Size = new Size(296, 32);
            item1.Text = "ID клиента";
            item1.Click += Item1_Click;
            // 
            // item2
            // 
            item2.Name = "item2";
            item2.Size = new Size(296, 32);
            item2.Text = "Дополнительный телефон";
            item2.Click += Item2_Click;
            // 
            // buttonChangeNumber
            // 
            buttonChangeNumber.Location = new Point(410, 43);
            buttonChangeNumber.Name = "buttonChangeNumber";
            buttonChangeNumber.Size = new Size(20, 25);
            buttonChangeNumber.TabIndex = 0;
            buttonChangeNumber.UseVisualStyleBackColor = true;
            buttonChangeNumber.Click += ButtonChangeNumber_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(108, 85);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 3;
            label2.Text = "Порт:";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(172, 82);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(150, 31);
            textBoxPort.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 144);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 5;
            label3.Text = "Сообщение:";
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(172, 141);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(586, 272);
            textBoxMessage.TabIndex = 6;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(-1, 428);
            label4.Name = "label4";
            label4.Size = new Size(807, 2);
            label4.TabIndex = 7;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(-1, 429);
            label5.Name = "label5";
            label5.Size = new Size(807, 2);
            label5.TabIndex = 8;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(615, 436);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(169, 43);
            buttonExit.TabIndex = 9;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(415, 436);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(169, 43);
            buttonSend.TabIndex = 10;
            buttonSend.Text = "Отправить";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += ButtonSend_Click;
            // 
            // MessageToClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 485);
            Controls.Add(buttonSend);
            Controls.Add(buttonExit);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxMessage);
            Controls.Add(label3);
            Controls.Add(textBoxPort);
            Controls.Add(label2);
            Controls.Add(buttonChangeNumber);
            Controls.Add(textBoxPhone);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MessageToClient";
            Text = "Отправка сообщения";
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxPhone;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem item1;
        private ToolStripMenuItem item2;
        private Button buttonChangeNumber;
        private Label label2;
        private TextBox textBoxPort;
        private Label label3;
        private TextBox textBoxMessage;
        private Label label4;
        private Label label5;
        private Button buttonExit;
        private Button buttonSend;
    }
}