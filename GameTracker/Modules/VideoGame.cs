using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Modules
{
    public class VideoGame
    {
        public string name;
        public string nickName;
        public string path;
        public double playTime;
        public bool isRunning;

        //Hours Label Reference
        public Label hoursLabel;

        //Gamepad Reference
        public PictureBox gamepadIcon;

        //Remove Button Reference
        public Button editButton;

        //Remove Button Reference
        public Button removeButton;

        //Status Message Reference
        public Label statusMessage;

        public VideoGame(string name, string path, double playTime)
        {
            this.name = name;
            this.path = path;
            this.playTime = playTime;
            this.nickName = name;
        }

        public VideoGame(string name, string path, double playTime, string nickName)
        {
            this.name = name;
            this.path = path;
            this.playTime = playTime;
            this.nickName = nickName;
        }

        public VideoGame()
        {

        }
    }
}
