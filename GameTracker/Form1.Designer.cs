//Custom Modules
using GameTracker.Modules;

namespace GameTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            AddGameButton = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            OrderArrow = new PictureBox();
            sortDropDown = new ComboBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            gamepad = new PictureBox();
            button4 = new Button();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            label5 = new Label();
            button5 = new Button();
            label6 = new Label();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderArrow).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gamepad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            // 
            // AddGameButton
            // 
            AddGameButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AddGameButton.BackColor = Color.FromArgb(68, 69, 96);
            AddGameButton.Cursor = Cursors.Hand;
            AddGameButton.Dock = DockStyle.Right;
            AddGameButton.FlatAppearance.BorderSize = 0;
            AddGameButton.FlatStyle = FlatStyle.Flat;
            AddGameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddGameButton.ForeColor = Color.FromArgb(224, 224, 224);
            AddGameButton.Location = new Point(734, 0);
            AddGameButton.Margin = new Padding(0);
            AddGameButton.Name = "AddGameButton";
            AddGameButton.Padding = new Padding(0, 0, 0, 2);
            AddGameButton.Size = new Size(148, 54);
            AddGameButton.TabIndex = 2;
            AddGameButton.Text = "Add Game";
            AddGameButton.UseVisualStyleBackColor = false;
            AddGameButton.Click += AddGameClick;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 60000;
            timer2.Tick += timer2_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Hello";
            notifyIcon1.BalloonTipTitle = "Game Checker";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Game Tracker";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.BackColor = Color.FromArgb(30, 30, 30);
            contextMenuStrip1.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { quitToolStripMenuItem });
            contextMenuStrip1.Margin = new Padding(0, 4, 0, 4);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.System;
            contextMenuStrip1.Size = new Size(108, 30);
            contextMenuStrip1.TabStop = true;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.BackColor = Color.Transparent;
            quitToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            quitToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            quitToolStripMenuItem.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quitToolStripMenuItem.ForeColor = Color.FromArgb(224, 224, 224);
            quitToolStripMenuItem.ImageTransparentColor = Color.Black;
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Padding = new Padding(0, 2, 0, 2);
            quitToolStripMenuItem.Size = new Size(107, 26);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(29, 38, 54);
            panel1.Controls.Add(OrderArrow);
            panel1.Controls.Add(sortDropDown);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(AddGameButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 498);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 54);
            panel1.TabIndex = 12;
            // 
            // OrderArrow
            // 
            OrderArrow.Cursor = Cursors.Hand;
            OrderArrow.Image = Properties.Resources.OrderArrow_Default;
            OrderArrow.Location = new Point(218, 11);
            OrderArrow.Margin = new Padding(2);
            OrderArrow.Name = "OrderArrow";
            OrderArrow.Size = new Size(34, 32);
            OrderArrow.SizeMode = PictureBoxSizeMode.Zoom;
            OrderArrow.TabIndex = 6;
            OrderArrow.TabStop = false;
            OrderArrow.Click += OrderArrow_Click;
            OrderArrow.MouseEnter += OrderArrow_MouseEnter;
            OrderArrow.MouseLeave += OrderArrow_MouseLeave;
            // 
            // sortDropDown
            // 
            sortDropDown.BackColor = Color.FromArgb(68, 69, 96);
            sortDropDown.Cursor = Cursors.Hand;
            sortDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            sortDropDown.FlatStyle = FlatStyle.Flat;
            sortDropDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            sortDropDown.ForeColor = Color.FromArgb(224, 224, 224);
            sortDropDown.FormattingEnabled = true;
            sortDropDown.Location = new Point(78, 15);
            sortDropDown.Margin = new Padding(2);
            sortDropDown.Name = "sortDropDown";
            sortDropDown.RightToLeft = RightToLeft.No;
            sortDropDown.Size = new Size(134, 28);
            sortDropDown.TabIndex = 5;
            sortDropDown.SelectedIndexChanged += sortDropDown_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(8, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 4;
            label1.Text = "Sort by:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.FromArgb(24, 32, 46);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(2, 2, 20, 2);
            flowLayoutPanel1.Size = new Size(882, 498);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(29, 38, 54);
            panel2.Controls.Add(gamepad);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(4, 4);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(209, 394);
            panel2.TabIndex = 9;
            // 
            // gamepad
            // 
            gamepad.Image = Properties.Resources.gamepad;
            gamepad.Location = new Point(19, 255);
            gamepad.Margin = new Padding(2);
            gamepad.Name = "gamepad";
            gamepad.Size = new Size(32, 25);
            gamepad.SizeMode = PictureBoxSizeMode.Zoom;
            gamepad.TabIndex = 10;
            gamepad.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(68, 69, 96);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.ForeColor = Color.FromArgb(217, 230, 230);
            button4.Location = new Point(20, 329);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 10;
            button4.Text = "Remove";
            button4.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(199, 213, 214);
            label4.Location = new Point(20, 12);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(162, 20);
            label4.TabIndex = 9;
            label4.Text = "[NONE]";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(68, 69, 96);
            pictureBox3.Location = new Point(20, 42);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(162, 168);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(232, 237, 238);
            label5.Location = new Point(49, 258);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(146, 20);
            label5.TabIndex = 5;
            label5.Text = "0h 0m";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(68, 69, 96);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button5.ForeColor = Color.FromArgb(217, 230, 230);
            button5.Location = new Point(20, 294);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 6;
            button5.Text = "Edit";
            button5.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(199, 213, 214);
            label6.Location = new Point(20, 225);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 0;
            label6.Text = "PLAY TIME";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(24, 32, 46);
            ClientSize = new Size(882, 552);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(798, 495);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game Tracker";
            FormClosing += Form1_FormClosing;
            Resize += Form1_Resize;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)OrderArrow).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gamepad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Button AddGameButton;
        private System.Windows.Forms.Timer timer2;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button button4;
        private Label label4;
        private PictureBox pictureBox3;
        private Label label5;
        private Button button5;
        private Label label6;
        private Label label1;
        private ComboBox sortDropDown;
        private PictureBox OrderArrow;
        private PictureBox gamepad;
    }
}
