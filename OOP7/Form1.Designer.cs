﻿namespace OOP7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBrush = new System.Windows.Forms.Button();
            this.listColor = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.listGroup = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(556, 475);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreateObj);
            // 
            // btnBrush
            // 
            this.btnBrush.Enabled = false;
            this.btnBrush.Location = new System.Drawing.Point(574, 12);
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new System.Drawing.Size(47, 40);
            this.btnBrush.TabIndex = 1;
            this.btnBrush.TabStop = false;
            this.btnBrush.Text = "brush";
            this.btnBrush.UseVisualStyleBackColor = true;
            this.btnBrush.Click += new System.EventHandler(this.btnChangeColor);
            this.btnBrush.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dontTouchKeyboard);
            // 
            // listColor
            // 
            this.listColor.FormattingEnabled = true;
            this.listColor.Items.AddRange(new object[] {
            "Blue",
            "Brown",
            "Yellow",
            "Green",
            "Purple",
            "Red",
            "White"});
            this.listColor.Location = new System.Drawing.Point(574, 58);
            this.listColor.Name = "listColor";
            this.listColor.Size = new System.Drawing.Size(47, 108);
            this.listColor.TabIndex = 2;
            this.listColor.SelectedIndexChanged += new System.EventHandler(this.listColor_SelectedIndexChanged);
            this.listColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dontTouchKeyboard);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Circle",
            "Rectangle",
            "Square",
            "Triangle"});
            this.listBox1.Location = new System.Drawing.Point(574, 392);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(85, 95);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dontTouchKeyboard);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(653, 12);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(78, 40);
            this.btnCreateGroup.TabIndex = 4;
            this.btnCreateGroup.Text = "Create Group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            this.btnCreateGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dontTouchKeyboard);
            // 
            // listGroup
            // 
            this.listGroup.FormattingEnabled = true;
            this.listGroup.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.listGroup.Items.AddRange(new object[] {
            "No one"});
            this.listGroup.Location = new System.Drawing.Point(653, 58);
            this.listGroup.Name = "listGroup";
            this.listGroup.Size = new System.Drawing.Size(78, 108);
            this.listGroup.TabIndex = 5;
            this.listGroup.TabStop = false;
            this.listGroup.UseTabStops = false;
            this.listGroup.SelectedIndexChanged += new System.EventHandler(this.button_ApplyGroup_Click);
            this.listGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dontTouchKeyboard);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 214);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dontTouchKeyboard);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 519);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listGroup);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listColor);
            this.Controls.Add(this.btnBrush);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBrush;
        private System.Windows.Forms.ListBox listColor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.ListBox listGroup;
        private System.Windows.Forms.Button button1;
    }
}

