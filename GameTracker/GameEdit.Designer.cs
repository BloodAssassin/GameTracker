﻿namespace GameTracker
{
    partial class GameEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameEdit));
            statusMessage = new Label();
            textBox1 = new TextBox();
            applyButton = new RoundedButton();
            cancelButton = new RoundedButton();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // statusMessage
            // 
            statusMessage.ForeColor = Color.FromArgb(224, 224, 224);
            statusMessage.Location = new Point(78, 46);
            statusMessage.Margin = new Padding(2, 0, 2, 0);
            statusMessage.Name = "statusMessage";
            statusMessage.Size = new Size(94, 20);
            statusMessage.TabIndex = 12;
            statusMessage.Text = "Game name:";
            statusMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(18, 23, 33);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(192, 42);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(206, 30);
            textBox1.TabIndex = 13;
            // 
            // ApplyButton
            // 
            applyButton.BackColor = Color.FromArgb(68, 69, 96);
            applyButton._defaultBackColor = Color.FromArgb(68, 69, 96);
            applyButton.Cursor = Cursors.Hand;
            applyButton.FlatAppearance.BorderSize = 0;
            applyButton.FlatStyle = FlatStyle.Flat;
            applyButton.ForeColor = Color.FromArgb(224, 224, 224);
            applyButton.Location = new Point(414, 185);
            applyButton.Margin = new Padding(2);
            applyButton.Name = "ApplyButton";
            applyButton.Size = new Size(90, 32);
            applyButton.TabIndex = 14;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = false;
            applyButton.Click += Apply_Click;
            // 
            // button2
            // 
            cancelButton.BackColor = Color.FromArgb(68, 69, 96);
            cancelButton._defaultBackColor = Color.FromArgb(68, 69, 96);
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.FromArgb(224, 224, 224);
            cancelButton.Location = new Point(312, 185);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "button2";
            cancelButton.Size = new Size(90, 32);
            cancelButton.TabIndex = 15;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += Cancel_Click;
            // 
            // label1
            // 
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(78, 105);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 18;
            label1.Text = "Play time:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(18, 23, 33);
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.Location = new Point(192, 104);
            numericUpDown1.Margin = new Padding(2);
            numericUpDown1.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(76, 27);
            numericUpDown1.TabIndex = 19;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(18, 23, 33);
            numericUpDown2.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown2.ForeColor = Color.White;
            numericUpDown2.Location = new Point(299, 104);
            numericUpDown2.Margin = new Padding(2);
            numericUpDown2.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(76, 27);
            numericUpDown2.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(224, 224, 224);
            label2.Location = new Point(278, 106);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 21;
            label2.Text = "h";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(224, 224, 224);
            label3.Location = new Point(380, 106);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(22, 20);
            label3.TabIndex = 22;
            label3.Text = "m";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GameEdit
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(29, 38, 54);
            ClientSize = new Size(515, 228);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(applyButton);
            Controls.Add(textBox1);
            Controls.Add(statusMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GameEdit";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit";
            Load += GameEdit_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusMessage;
        private TextBox textBox1;
        private RoundedButton applyButton;
        private RoundedButton cancelButton;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private Label label3;
    }
}