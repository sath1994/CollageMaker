using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollageMaker
{
    public partial class CollageMakerForm : Form
    {
        #region Variables
        private ImageGrabber imageGrabber;
        private Random randomVariable = new Random();

        private string[] imagesLocation;
        private string mainImageLocation;

        private string StatusText
        { 
            set
            {
                StatusLabel.Text = value;
                StatusLabel.Refresh();
            }
        }
        #endregion

        #region Initializer

        public CollageMakerForm()
        {
            InitializeComponent();
            this.Text = "CollageMaker Application - By Sath";
            InitializeProgressBar();
        }

        public void InitializeProgressBar()
        {
            StatusProgressBar.Hide();
            StatusProgressBar.Maximum = 1;
            StatusProgressBar.Value = 0;
            StatusProgressBar.Show();
        }

        #endregion

        #region Button EventHandlers

        private void MainPictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            SetOpenFileDialogImageSettings(openFileDialog);

            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                mainImageLocation = openFileDialog.FileName;

            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            SetOpenFileDialogImagesSettings(openFileDialog);

            DialogResult dialogResult = openFileDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                imagesLocation= openFileDialog.FileNames;
               // StatusText =  "0 of " + imagesLocation.Length + " completed";
            }

        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            bool completed = false;
            //main picture grabbing

            imageGrabber = new ImageGrabber(GetImageSize(mainImageLocation));
            while (completed == false)
            {
                //Randomizes picture order cause some people take multiple pictures in a row
                imagesLocation = RandomizeStringArray(imagesLocation);
                //Adds all images onto imagegrabber class

                foreach (string imageLoc in imagesLocation)
                {
                    if (imageGrabber.AddToCollageImage(imageLoc) == false)
                    {
                        completed = true;
                        StatusProgressBar.Value = StatusProgressBar.Maximum;
                        break;
                    }
                        
                    AddValueToProgressBar(StatusProgressBar);
                }
            }

            //Finds the location of desktop
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string testPath = System.IO.Path.Combine(path, "CollageMaker Pictures");
            System.IO.Directory.CreateDirectory(testPath);
            //Saves the image to jpeg form
            if (SaveImageAsJpeg(imageGrabber.collageImage, testPath + "\\" + imageNameTextBox.Text))
                MessageBox.Show("Completed!");
            else
                MessageBox.Show("Failed!!!");
        }
   
        #endregion

        #region Helper Methods
        /// <summary>
        /// Gets an array and creates a random order in order add variablilty
        /// since some people take multiple pictures in one sitting
        /// </summary>
        /// <param name="stringToRandomize"></param>
        /// <returns></returns>
        private string[] RandomizeStringArray(string[] stringToRandomize)
        {
            int randomValue;
            int stringLength = stringToRandomize.Length;

            string temp;
            if (stringLength == 0)
                return null;
            else
            {
                for (int i = 0; i < stringLength; i++)
                {
                    randomValue = randomVariable.Next(0, i);
                    temp = stringToRandomize[i];
                    stringToRandomize[i] = stringToRandomize[randomValue];
                    stringToRandomize[randomValue] = temp;
                }
                return stringToRandomize;
            }

        }

        private bool SaveImageAsJpeg(Bitmap imageToSave, string fileName)
        {
            try {
                //Variables
                ImageCodecInfo myImageCodecInfo;
                System.Drawing.Imaging.Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;

                // Get an ImageCodecInfo object that represents the JPEG codec.
                myImageCodecInfo = GetEncoderInfo("image/jpeg");
                // for the Quality parameter category.
                myEncoder = System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object. 
                // An EncoderParameters object has an array of EncoderParameter 
                // objects. In this case, there is only one 
                // EncoderParameter object in the array.
                myEncoderParameters = new EncoderParameters(1);

                // Save the bitmap as a JPEG file with quality level 75.
                myEncoderParameter = new EncoderParameter(myEncoder, 75L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                imageToSave.Save( fileName + ".jpg", myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        /// Initializes the openfiledialog to get the images
        /// </summary>
        /// <param name="openFileDialog"></param>
        public void SetOpenFileDialogImagesSettings(OpenFileDialog openFileDialog)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "SelectImages";

        }

        /// <summary>
        /// sets the openfile dialog to get only one image
        /// </summary>
        /// <param name="openFileDialog"></param>
        public void SetOpenFileDialogImageSettings(OpenFileDialog openFileDialog)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "SelectImages";
        }

        #region Progress Bar Helpers
        public void AddValueToProgressBar(ProgressBar progressBar)
        {
            progressBar.Maximum++;
            progressBar.Value++;
        }
        #endregion

        public Size GetImageSize(string imageFileLocation)
        {
            Bitmap image = new Bitmap(imageFileLocation);
            return image.Size;
        }
        #endregion


    }
}
