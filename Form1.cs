using GameTracker.Properties;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Runtime.InteropServices;

//Custom Modules
using GameTracker.Modules;

namespace GameTracker
{
    public partial class Form1 : Form
    {
        //Played games list
        public List<VideoGame> playedGames = new List<VideoGame>();

        public string version = "v0.1.8";

        int i = 0;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            flowLayoutPanel1.AutoScroll = true;

            //Apply version text
            Text = "Game Tracker " + version;

            //Make save directory
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Game Tracker") == false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Game Tracker");
            }

            LoadPlayTime();
            RefreshList();

            CheckAlreadyRunning();
        }

        //Close if already running
        private void CheckAlreadyRunning()
        {
            int n = 0;

            Process[] pname = Process.GetProcesses();

            foreach (Process p in pname)
            {
                if (p.ProcessName == "GameTracker")
                {
                    n++;
                }
            }

            if (n == 2)
            {
                this.Hide();
                MessageBox.Show("An instance of the app is already running!");
                Environment.Exit(0);
            }
        }

        private void RefreshList()
        {
            flowLayoutPanel1.Controls.Clear();

            int i = 0;
            foreach (VideoGame game in playedGames)
            {
                PictureBox newGameIcon = new PictureBox();
                Label newHours = new Label();
                Button newEditButton = new Button();
                Button newRemoveButton = new Button();
                Panel newPanel = new Panel();
                Label newGameName = new Label();
                Label newPlayTime = new Label();
                Label newStatusMessage = new Label();

                //
                // gameIcon
                //
                string iconDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Game Tracker\Game Icons";

                newGameIcon.BackColor = Color.FromArgb(68, 69, 96);
                newGameIcon.Location = new Point(20, 43);
                newGameIcon.Name = "gameIcon" + i;
                newGameIcon.Size = new Size(162, 167);
                newGameIcon.SizeMode = PictureBoxSizeMode.CenterImage;
                newGameIcon.TabIndex = 4;
                newGameIcon.TabStop = false;
                newGameIcon.Click += gameIcon_Click;

                try
                {
                    Bitmap bitmapImage;
                    Image icon;

                    using (Image image = Image.FromFile(iconDirectory + @"\" + game.name + ".png"))
                    {
                        bitmapImage = new Bitmap(image);
                    }

                    icon = bitmapImage;
                    newGameIcon.Image = icon;
                }
                catch
                {
                    MessageBox.Show("Error: Could not find " + game.nickName + "'s icon.");
                }
                // 
                // Edit Button
                // 
                newEditButton.BackColor = Color.FromArgb(68, 69, 96);
                newEditButton.FlatAppearance.BorderSize = 0;
                newEditButton.FlatStyle = FlatStyle.Flat;
                newEditButton.ForeColor = Color.White;
                newEditButton.Location = new Point(20, 294);
                newEditButton.Name = "newEditButton" + i;
                newEditButton.Size = new Size(94, 29);
                newEditButton.TabIndex = 6;
                newEditButton.Text = "Edit";
                newEditButton.UseVisualStyleBackColor = false;
                newEditButton.Cursor = Cursors.Hand;

                //Add click function
                newEditButton.Click += EditClicked;

                //Add as a reference
                game.editButton = newEditButton;

                // 
                // Remove Button
                // 
                newRemoveButton.BackColor = Color.FromArgb(68, 69, 96);
                newRemoveButton.FlatAppearance.BorderSize = 0;
                newRemoveButton.FlatStyle = FlatStyle.Flat;
                newRemoveButton.ForeColor = Color.White;
                newRemoveButton.Location = new Point(20, 329);
                newRemoveButton.Name = "newRemoveButton";
                newRemoveButton.Size = new Size(94, 29);
                newRemoveButton.TabIndex = 10;
                newRemoveButton.Text = "Remove";
                newRemoveButton.UseVisualStyleBackColor = false;
                newRemoveButton.Cursor = Cursors.Hand;

                //Add click function
                newRemoveButton.Click += RemoveClicked;

                //Add as a reference
                game.removeButton = newRemoveButton;

                // 
                // Game Label
                // 
                newGameName.ForeColor = Color.FromArgb(224, 224, 224);
                newGameName.Location = new Point(19, 13);
                newGameName.Name = "newGameName" + i;
                newGameName.Size = new Size(162, 20);
                newGameName.TabIndex = 9;
                newGameName.Text = game.nickName;
                newGameName.TextAlign = ContentAlignment.MiddleCenter;
                // 
                // Play Time
                // 
                newPlayTime.AutoSize = true;
                newPlayTime.ForeColor = Color.White;
                newPlayTime.Location = new Point(20, 225);
                newPlayTime.Margin = new Padding(0);
                newPlayTime.Name = "newPlayTime" + i;
                newPlayTime.Size = new Size(78, 20);
                newPlayTime.TabIndex = 0;
                newPlayTime.Text = "PLAY TIME";
                newPlayTime.TextAlign = ContentAlignment.MiddleLeft;
                // 
                // Hours Label
                // 

                //Convert to hours from minutes
                double hours = Math.Floor(game.playTime / 60);
                double minutes = Math.Round(game.playTime % 60, 0);

                newHours.ForeColor = Color.FromArgb(224, 224, 224);
                newHours.Location = new Point(20, 257);
                newHours.Name = "newHours" + i;
                newHours.Size = new Size(162, 20);
                newHours.TabIndex = 5;
                newHours.Text = hours + "h " + minutes + "m";
                newHours.TextAlign = ContentAlignment.MiddleLeft;

                //Add as a reference
                game.hoursLabel = newHours;

                // 
                // statusMessage
                // 
                newStatusMessage.ForeColor = Color.FromArgb(224, 224, 224);
                newStatusMessage.Location = new Point(20, 371);
                newStatusMessage.Name = "statusMessage";
                newStatusMessage.Size = new Size(162, 20);
                newStatusMessage.TabIndex = 11;
                newStatusMessage.Text = "";
                newStatusMessage.TextAlign = ContentAlignment.MiddleCenter;

                //Add as a reference
                game.statusMessage = newStatusMessage;

                // 
                // Panel
                // 
                newPanel.BackColor = Color.FromArgb(29, 38, 54);
                newPanel.Controls.Add(newGameName);
                newPanel.Controls.Add(newGameIcon);
                newPanel.Controls.Add(newHours);
                newPanel.Controls.Add(newEditButton);
                newPanel.Controls.Add(newRemoveButton);
                newPanel.Controls.Add(newPlayTime);
                newPanel.Controls.Add(newStatusMessage);
                newPanel.Location = new Point(3, 3);
                newPanel.Name = "panel1";
                newPanel.Size = new Size(209, 401);
                newPanel.Margin = new System.Windows.Forms.Padding(2);
                newPanel.TabIndex = 9;

                flowLayoutPanel1.Controls.Add(newPanel);

                i++;

                //Path changed status message
                try
                {
                    Bitmap.FromHicon(new Icon(Icon.ExtractAssociatedIcon(game.path), new Size(48, 48)).Handle);
                }
                catch
                {
                    game.statusMessage.Text = "(path changed)";
                }
            }
        }

        private void SavePlayTime()
        {
            //Save to file
            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                @"\Game Tracker\PlayTime.txt");

            foreach (VideoGame game in playedGames)
            {
                writer.WriteLine("---");
                writer.WriteLine(game.name);
                writer.WriteLine(game.nickName);
                writer.WriteLine(game.path);
                writer.WriteLine(game.playTime);
            }

            writer.Close();
        }

        private void SaveIcon(string iconPath, string gameName)
        {
            string iconDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Game Tracker\Game Icons";
            Bitmap gameIcon = Bitmap.FromHicon(new Icon(Icon.ExtractAssociatedIcon(iconPath), new Size(48, 48)).Handle);

            //Create a directory if it doesn't exist
            if (Directory.Exists(iconDirectory) == false)
            {
                Directory.CreateDirectory(iconDirectory);
                MessageBox.Show(iconDirectory);
            }

            gameIcon.Save(iconDirectory + @"\" + gameName + ".png", ImageFormat.Png);
        }

        private void LoadPlayTime()
        {
            try
            {
                //Load from file to list
                StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                    @"\Game Tracker\PlayTime.txt", false);

                int nameLine = 1;
                int nickNameLine = 2;
                int pathLine = 3;
                int playTimeLine = 4;

                int currentLine = 0;
                string line;

                VideoGame loadedGame = new VideoGame();

                while ((line = reader.ReadLine()) != null)
                {
                    //Name
                    if (currentLine == nameLine)
                    {
                        loadedGame.name = line;
                    }
                    //NickName
                    else if (currentLine == nickNameLine)
                    {
                        loadedGame.nickName = line;
                    }
                    //Path
                    else if (currentLine == pathLine)
                    {
                        loadedGame.path = line;
                    }
                    //PlayTime (last line)
                    else if (currentLine == playTimeLine)
                    {
                        loadedGame.playTime = Convert.ToDouble(line);

                        playedGames.Add(loadedGame);

                        //Reset current line
                        currentLine = 0;

                        //Reset values for loadedGame
                        loadedGame = new VideoGame();

                        //Skip the increment
                        continue;
                    }

                    currentLine++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private bool CheckPlayed(string playedName)
        {
            foreach (VideoGame game in playedGames)
            {
                if (game.name == playedName)
                {
                    return true;
                }
            }

            return false;
        }

        private int GameIndex(string playedName)
        {
            int index = 0;
            foreach (VideoGame game in playedGames)
            {
                if (game.name == playedName)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Process[] pname = Process.GetProcesses();

                foreach (VideoGame game in playedGames)
                {
                    game.isRunning = false;

                    foreach (Process p in pname)
                    {
                        if (p.ProcessName == game.name)
                        {
                            game.isRunning = true;
                            break;
                        }
                    }

                    //Currently playing status message
                    if (game.isRunning)
                    {
                        game.statusMessage.Text = "(currently playing)";
                    }
                    else if (game.statusMessage.Text == "(currently playing)")
                    {
                        game.statusMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (VideoGame game in playedGames)
            {
                if (game.isRunning == true)
                {
                    game.playTime++;

                    //Convert to hours
                    double hours = Math.Floor(game.playTime / 60);
                    //Convert to minutes
                    double minutes = Math.Round(game.playTime % 60, 0);

                    game.hoursLabel.Text = hours + "h " + minutes + "m";
                }
            }
            SavePlayTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                {
                    dialog.Title = "Game Select";
                    dialog.Filter = "All files (*.*)|*.*|Executable (*.exe)|*.exe";
                    dialog.FilterIndex = 2;
                    dialog.ShowDialog();

                    //If a proper file selected
                    if (dialog.FileName != "" && dialog.FileName.Contains(".exe"))
                    {
                        string addedGamePath = dialog.FileName;
                        string addedGameName = Path.GetFileName(dialog.FileName);
                        addedGameName = addedGameName.Substring(0, addedGameName.Length - 4);

                        //Add to list (if new)
                        if (CheckPlayed(addedGameName) == false)
                        {
                            i = 0;
                            VideoGame newGame = new VideoGame(addedGameName, addedGamePath, 0);
                            playedGames.Add(newGame);
                        }
                        //Update path (if changed)
                        else if (CheckPlayed(addedGameName) == true && playedGames[GameIndex(addedGameName)].path != addedGamePath)
                        {
                            playedGames[GameIndex(addedGameName)].path = addedGamePath;
                        }

                        SaveIcon(addedGamePath, addedGameName);
                        SavePlayTime();
                        RefreshList();
                    }
                }

                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void EditClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            VideoGame editGame = null;

            foreach (VideoGame game in playedGames)
            {
                if (button == game.editButton)
                {
                    editGame = game;
                }
            }

            GameEdit editWindow = new GameEdit(editGame);

            if (editWindow.ShowDialog() == DialogResult.OK)
            {
                SavePlayTime();
                RefreshList();
            }
        }

        private void RemoveClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            VideoGame gameToBeRemoved = null;

            //Game icon
            string iconDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Game Tracker\Game Icons";

            foreach (VideoGame game in playedGames)
            {
                if (game.removeButton == button)
                {
                    gameToBeRemoved = game;
                }
            }

            //Delete data from .txt
            playedGames.Remove(gameToBeRemoved);

            RefreshList();
            SavePlayTime();

            //Delete game icon
            File.Delete(iconDirectory + @"\" + gameToBeRemoved.name + ".png");            
        }

        private void gameIcon_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
