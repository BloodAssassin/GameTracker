using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Custom Modules
using GameTracker.Modules;

namespace GameTracker
{
    public partial class GameEdit : Form
    {
        public VideoGame game;
        public string newNickname;

        public GameEdit(VideoGame game)
        {
            InitializeComponent();

            this.game = game;

            textBox1.Text = game.nickName;

            //Convert playtime to hours
            numericUpDown1.Value = (int)Math.Floor(game.playTime / 60);

            //Convert playtime to minutes
            numericUpDown2.Value = (int)Math.Round(game.playTime % 60, 0);

            this.ActiveControl = ApplyButton;
        }

        //Apply
        private void Apply_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Error: Can't put empty name!");
                return;
            }

            game.nickName = textBox1.Text;
            game.playTime = (int)numericUpDown1.Value * 60 + (int)numericUpDown2.Value;
            DialogResult = DialogResult.OK;
        }

        //Cancel
        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
