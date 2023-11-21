using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_Jake_young_ST10081936
{
    internal class GifListManager
    {
        //total number of frames that the animation has
        private int animNumberOfFrames = 0;

        //current frame that the animation is on
        private int animCurrentFrame = 0;

        //frame dimension properties of the current animation
        private FrameDimension animDimension;

        //list to hold picture boxes where the animations are contained
        private List<PictureBox> animList = new List<PictureBox>();

        //list to hold all animations that have already been done
        private List<PictureBox> animListDone = new List<PictureBox>();

        //constructor
        public GifListManager(List<PictureBox> animList, List<PictureBox> animListDone)
        {
            this.animList = animList;
            this.animListDone = animListDone;

            //initialise values and methods of gif and containers
            InitialiseGif();
        }


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to manually end and proccess an animation
        /// </summary>
        /// <param name="currentGif"></param>
        public void ManualHandle(PictureBox currentGif)
        {
            //set the image to the last frame of the animation
            currentGif.Image.SelectActiveFrame(animDimension, animNumberOfFrames - 1); //source - https://stackoverflow.com/a/27875407
            
            //disable the picturebox to freeze the animation
            currentGif.Enabled = false;

            //add the picturebox to the list of proccessed animations
            animListDone.Add(currentGif);

            //reset the current frame counter for the gif animation progress
            animCurrentFrame = 0;
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to initialise the gif data
        /// </summary>
        private void InitialiseGif()
        {

            //loop through the given list of pictureboxes that contain gifs
            foreach (PictureBox gifContainer in animList)
            {
                //set the on paint method of the current picturebox
                gifContainer.Paint += new PaintEventHandler(anim_Paint); ;
            }

            //set the frame dimension using to first item in the list of animation containers
            animDimension = new FrameDimension(animList[0].Image.FrameDimensionsList[0]);

            //set the total number of frames that the animation has
            animNumberOfFrames = animList[0].Image.GetFrameCount(animDimension);

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to control the animation state during its paint stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //source - https://stackoverflow.com/a/53639299
        private void anim_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //get the current picturebox being altered
            PictureBox thisGifContainer = (PictureBox)sender;

            //if the animation has completed
            if (animCurrentFrame >= animNumberOfFrames - 10) //offset total animation frames by 10 to properly catch the end of it and prevent frame skipping
            {

                //set the image to the last frame of the animation
                thisGifContainer.Image.SelectActiveFrame(animDimension, animNumberOfFrames - 1); //source - https://stackoverflow.com/a/27875407

                //disable the current picture box to freeze the animation
                thisGifContainer.Enabled = false;

                //add the animation to the list of finished animations
                animListDone.Add(thisGifContainer);

                //reset the current frame counter for the gif animation progress
                animCurrentFrame = 0;
            }

            //increment the current frame counter
            animCurrentFrame++;

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// method to animate and complete an animation
        /// </summary>
        /// <param name="remainingAnimations"></param>
        /// <returns></returns>
        public int animateItem(List<PictureBox> remainingAnimations)
        {
            //enable and run the last uncomplete animation
            remainingAnimations.Last().Enabled = true;

            //get the amount of valid and undone animations left
            int leftoverAnimations = remainingAnimations.Count();

            return leftoverAnimations;

        }
        //------------------------------------------------------------------------------------------------------------------


    }
}
