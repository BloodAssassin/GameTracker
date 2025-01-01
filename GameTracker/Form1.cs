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
        public List<VideoGame> showedPlayedGames = new List<VideoGame>();

        public string version = "v0.1.2";

        bool isloading = true;

        //OrderArrow
        Image orderArrow_default = Resources.OrderArrow_Default;
        Image orderArrow_selected = Resources.OrderArrow_Selected;

        //Sorting
        int sortIndex = 0;
        string sortOrder = "asc";

        public Form1()
        {
            //Font scale
            Font = new Font(Font.Name, 8.25f * 125f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();

            //FlowLayout scroll
            this.DoubleBuffered = true;
            flowLayoutPanel1.AutoScroll = true;

            //Apply version text
            Text = "Game Tracker " + version;

            //Make save directory
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Game Tracker") == false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Game Tracker");
            }

            //Assign values to dropDown
            LoadSorting();
            InitSortDropDown();

            //Load list
            LoadPlayTime();
            RefreshList();

            //Check if program is already running
            CheckAlreadyRunning();

            isloading = false;
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

            new List<VideoGame>(playedGames);
            SortGameList();

            int i = 0;
            foreach (VideoGame game in showedPlayedGames)
            {
                RoundedPictureBox newGameIcon = new RoundedPictureBox();
                PictureBox newGamepad = new PictureBox();
                Label newHours = new Label();
                RoundedButton newRemoveButton = new RoundedButton();
                RoundedButton newEditButton = new RoundedButton();
                RoundedPanel newPanel = new RoundedPanel();
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
                newEditButton._defaultBackColor = Color.FromArgb(68, 69, 96);
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
                newRemoveButton.BackColor = Color.FromArgb(68, 69, 96);
                newRemoveButton._defaultBackColor = Color.FromArgb(68, 69, 96);
                newRemoveButton.FlatStyle = FlatStyle.Flat;
                newRemoveButton.ForeColor = Color.White;
                newRemoveButton.Location = new Point(20, 329);
                newRemoveButton.Name = "newRemoveButton" + i;
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
                // Gamepad icon
                //
                newGamepad.Image = Properties.Resources.gamepad;
                newGamepad.Location = new Point(19, 255);
                newGamepad.Name = "newGamepad";
                newGamepad.Size = new Size(32, 25);
                newGamepad.SizeMode = PictureBoxSizeMode.Zoom;
                newGamepad.TabIndex = 10;
                newGamepad.TabStop = false;
                newGamepad.Visible = false;

                game.gamepadIcon = newGamepad;

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
                newStatusMessage.Visible = false;

                //Add as a reference
                game.statusMessage = newStatusMessage;

                // 
                // Panel
                // 
                newPanel.BackColor = Color.FromArgb(29, 38, 54);
                newPanel.Controls.Add(newGameName);
                newPanel.Controls.Add(newGameIcon);
                newPanel.Controls.Add(newGamepad);
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

                    //Currently playing
                    if (game.isRunning == true)
                    {
                        game.hoursLabel.ForeColor = Color.FromArgb(0, 255, 4);
                        game.hoursLabel.Font = new Font(game.hoursLabel.Font, FontStyle.Bold);
                        game.hoursLabel.Location = new Point(49, 257);

                        game.gamepadIcon.Visible = true;
                    }
                    //Not currently playing
                    else if (game.isRunning == false)
                    {
                        game.hoursLabel.ForeColor = Color.White;
                        game.hoursLabel.Font = new Font(game.hoursLabel.Font, FontStyle.Regular);
                        game.hoursLabel.Location = new Point(20, 257);

                        game.gamepadIcon.Visible = false;
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

        private void AddGameClick(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
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

        private void InitSortDropDown()
        {
            string[] sorts = { "Added", "Playtime", "Alphabetical" };

            //Default is set to 'asc' if it's 'desc' than flip the arrow
            if (sortOrder == "desc")
            {
                orderArrow_selected.RotateFlip(RotateFlipType.RotateNoneFlipY);
                orderArrow_default.RotateFlip(RotateFlipType.RotateNoneFlipY);

                OrderArrow.Image = orderArrow_default;
            }

            sortDropDown.DataSource = sorts;
            sortDropDown.SelectedIndex = sortIndex;
        }

        private void SaveSorting()
        {
            //Save to file
            sortIndex = sortDropDown.SelectedIndex;

            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                    @"\Game Tracker\Sorting.txt");

            writer.Write(sortIndex + " " + sortOrder);

            writer.Close();
        }

        private void LoadSorting()
        {
            //Load from file
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                    @"\Game Tracker\Sorting.txt"))
            {
                string line;
                StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                    @"\Game Tracker\Sorting.txt");

                line = reader.ReadLine();
                sortIndex = Convert.ToInt32(line.Split()[0]);
                sortOrder = line.Split()[1];

                reader.Close();
            }
        }

        private void ScrollBarMinimizeFix()
        {
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.AutoScroll = true;
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

        //Sort game list
        private void SortGameList()
        {
            //By added order
            if (sortDropDown.SelectedIndex == 0)
            {
                if (sortOrder == "asc")
                {
                    showedPlayedGames.Clear();
                    showedPlayedGames = new List<VideoGame>(playedGames);
                }
                else if (sortOrder == "desc")
                {
                    showedPlayedGames = new List<VideoGame>(playedGames);
                    showedPlayedGames.Reverse();
                }
            }
            //By play time
            else if (sortDropDown.SelectedIndex == 1)
            {
                if (sortOrder == "asc")
                {
                    showedPlayedGames = playedGames.OrderBy(x => x.playTime).ToList();
                }
                else if (sortOrder == "desc")
                {
                    showedPlayedGames = playedGames.OrderByDescending(x => x.playTime).ToList();
                }
            }
            //By alphabet
            else if (sortDropDown.SelectedIndex == 2)
            {
                if (sortOrder == "asc")
                {
                    showedPlayedGames = playedGames.OrderBy(x => x.nickName).ToList();
                }
                else if (sortOrder == "desc")
                {
                    showedPlayedGames = playedGames.OrderByDescending(x => x.nickName).ToList();
                }
            }
        }

        //Order arrow click
        private void OrderArrow_Click(object sender, EventArgs e)
        {
            orderArrow_selected.RotateFlip(RotateFlipType.RotateNoneFlipY);
            orderArrow_default.RotateFlip(RotateFlipType.RotateNoneFlipY);

            OrderArrow.Image = orderArrow_selected;

            if (sortOrder == "asc")
            {
                sortOrder = "desc";
            }
            else if (sortOrder == "desc")
            {
                sortOrder = "asc";
            }

            SaveSorting();
            RefreshList();
        }

        //Order arrow hover
        private void OrderArrow_MouseEnter(object sender, EventArgs e)
        {
            OrderArrow.Image = orderArrow_selected;
        }

        //Order arrow leave
        private void OrderArrow_MouseLeave(object sender, EventArgs e)
        {
            OrderArrow.Image = orderArrow_default;
        }

        private void sortDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isloading == false)
            {
                SaveSorting();
                RefreshList();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Scrollbar fix applied
            ScrollBarMinimizeFix();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
