using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace PROG_POE_Jake_young_ST10081936
{
    internal class SoundManager
    {

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to play custom game sounds
        /// </summary>
        /// <param name="sound"></param>
        public void PlaySound(string sound)
        {
            //defualt sound file
            var soundFile = Resources.BookClick;

            //select sound to play based on method input
            switch (sound)
            {
                case "BookClick":
                    //click is default sound
                    break;
                case "BookDrop":
                    soundFile = Resources.BookDrop;
                    break;
                case "ButtonClick":
                    soundFile = Resources.ButtonClick;
                    break;
                case "ButtonHover":
                    soundFile = Resources.ButtonHover;
                    break;
                case "GameWin":
                    soundFile = Resources.GameWin;
                    break;
                case "GameLose":
                    soundFile = Resources.GameLose;
                    break;
                case "WrongAnswer":
                    soundFile = Resources.WrongAnswer;
                    break;

            }


            try
            {
                //source - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-play-a-sound-from-a-windows-form?view=netframeworkdesktop-4.8
                //new sound player
                SoundPlayer simpleSound = new SoundPlayer(soundFile);


                //play the selected sound
                simpleSound.Play();
                
            }
            catch
            {
                var inform = MessageBox.Show("Sound effect could not be played", "Error");
            }

        }
        //------------------------------------------------------------------------------------------------------------------



    }
}
