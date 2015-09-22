using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace CollageMaker
{
    class ImageGrabber
    {
        #region Variables

        public Bitmap collageImage;
        public Point LocationToPlacePicture
        {
            get { return locationToPlacePicuture; }
            set
            {
                locationToPlacePicuture = value;
                if (locationToPlacePicuture.X > defaultCollagePictureWidth)
                    locationToPlacePicuture.X = 0;
                if (locationToPlacePicuture.Y > defaultCollagePictureHeight)
                    locationToPlacePicuture.Y = 0;
            }
        }

        private bool noMoreEmptyPixel;

        private const int defaultCollagePictureHeight = 3000;
        private const int defaultCollagePictureWidth = 2400;

        private int compressionFactor;

        private Point locationToPlacePicuture;
        private Point memoryLocationPoint = new Point(0,0);
        #endregion

        #region Initialization

        /// <summary>
        /// Default size for null is 3000x 2400
        /// </summary>
        /// <param name="imageSize"></param>
        public ImageGrabber(Size imageSize)
        {
            //Sets the collage image
            InitializeCollageImage(imageSize);
            //Sets the boolean to false;
            noMoreEmptyPixel = false;
            LocationToPlacePicture = new Point(0, 0);
            //compressionFactor = Convert.ToInt32(Math.Sqrt(amountOfPics*0.77));
        }

        /// <summary>
        /// Initializes The collage Bitmap
        /// </summary>
        private void InitializeCollageImage(Size imageSize)
        {
            if (imageSize == null)
                collageImage = new Bitmap(defaultCollagePictureWidth, defaultCollagePictureHeight);
            else
                collageImage = new Bitmap(imageSize.Width, imageSize.Height);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the Image from its filename and adds it to bit map
        /// </summary>
        /// <param name="filename"></param>
        public bool AddToCollageImage(string filename)
        {
            //Gets the OriginalImage
            Bitmap OriginalImage = new Bitmap(filename);
            Size OriginalImageSize = OriginalImage.Size;
            //Gets the Compressed Image
            Size CompressedImageSize = new Size();
            //CompressedImageSize.Height = OriginalImageSize.Height / compressionFactor;
            //CompressedImageSize.Width = OriginalImageSize.Width / compressionFactor;
            //Conditional sizing
            if (OriginalImageSize.Width > OriginalImageSize.Height)
            {
                CompressedImageSize.Height = defaultCollagePictureWidth / this.compressionFactor; 
                CompressedImageSize.Width = defaultCollagePictureHeight / this.compressionFactor;
            }
            else if (OriginalImageSize.Width<OriginalImageSize.Height)
            {
                CompressedImageSize.Height = defaultCollagePictureHeight / this.compressionFactor;
                CompressedImageSize.Width = defaultCollagePictureWidth / this.compressionFactor;
            }
            else
            {
                CompressedImageSize.Height = defaultCollagePictureWidth / this.compressionFactor;
                CompressedImageSize.Width = defaultCollagePictureWidth / this.compressionFactor;
            }

            //Bitmap CompressedImage =  CompressImage(OriginalImage, CompressedImageSize);
            Bitmap CompressedImage = new Bitmap(OriginalImage, CompressedImageSize);
            SetPictureToBitmapLocationVMode(collageImage, CompressedImage, LocationToPlacePicture);

            //Finds and Sets NextLocationTo place pictures
            LocationToPlacePicture = FindNextEmptyPoint(collageImage, LocationToPlacePicture);

            //deallocates memory
            OriginalImage.Dispose();
            CompressedImage.Dispose();

            if (noMoreEmptyPixel)
                return false;
            else
                return true;

        }

        /// <summary>
        /// Sets the compressfactor
        /// Default : Convert.ToInt32(Math.Sqrt(amountOfPics*0.77))
        /// </summary>
        /// <param name="compressionFactorValue"></param>
        public void SetCompressionFactor(int compressionFactorValue)
        {
            compressionFactor = compressionFactorValue;
        }

        /// <summary>
        /// Allows addition of image to create a pic from many pics
        /// </summary>
        /// <param name="imageToCombine"></param>
        public void AddOverallImageToBitMap(string imageLocation)
        {
            Bitmap image = new Bitmap(imageLocation);
            //collageImage.//TODO add the code for collage image
        }
        #endregion

        #region HelperMethod
        //========================Finding empty points====================================
        /// <summary>
        /// Finds the Next Nearest white space goes row by row
        /// Left To Right
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="currentLocation"></param>
        /// <returns></returns>
        private Point FindNextEmptyPoint(Bitmap picture, Point currentLocation)
        {
            int currentXPosition = currentLocation.X;
            int currentYPosition = currentLocation.Y;

            int firstEmptyXPositon = -1;
            int firstEmptyYPostion = -1;

            Color pixelColor;
            for (int y = currentYPosition; y<defaultCollagePictureHeight; y++)
            {
                for (int x=currentXPosition; x<defaultCollagePictureWidth; x++)
                {
                    pixelColor = picture.GetPixel(x, y);
                    if (pixelColor.Name == "0")
                    {
                        //loads the x position of empty space
                        firstEmptyXPositon = x;

                        //finds the next x position going up from current 
                        for(int i = y; i>0; i--)
                        {
                            pixelColor = picture.GetPixel(firstEmptyXPositon, i-1);
                            if (pixelColor.Name!= "0")
                            {
                                firstEmptyYPostion = i;
                                break;
                            }
                        }
                        if (firstEmptyYPostion == -1)
                            firstEmptyYPostion=0;
                        return new Point(firstEmptyXPositon, firstEmptyYPostion);
                    }

                    //Resets X position for when it reaches the end
                    if (currentXPosition == defaultCollagePictureWidth)
                        currentXPosition = 0;
                }
            }
            return new Point(defaultCollagePictureWidth, defaultCollagePictureHeight);
        }
        
        /// <summary>
        /// Goes through entire bitmap and find the first location with 0 space
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        private Point FindFirstEmptyPoint(Bitmap picture)
        {
            Color pixelColor;
            for(int y=memoryLocationPoint.Y; y<defaultCollagePictureHeight;y++)
            {
                for (int x = memoryLocationPoint.X; x < defaultCollagePictureWidth; x++)
                {
                    pixelColor = picture.GetPixel(x, y);
                    if (pixelColor.Name == "0")
                    {
                        memoryLocationPoint = new Point(0, y);
                        return memoryLocationPoint;
                    }
                }
            }
            //if it reaches this point it means no more empty pixels
            noMoreEmptyPixel = true;

            return new Point(defaultCollagePictureWidth, defaultCollagePictureHeight);
        }

        //===================Seting Bitmap pixels ===============================================================
        /// <summary>
        /// Sets all the pixels to original picture 
        /// goes horizantly pixel by pixel
        /// </summary>
        /// <param name="pictureToSet"></param>
        /// <param name="originalBitmap"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private Bitmap SetPictureToBitmapLocationHMode(Bitmap pictureToSet, Bitmap originalBitmap, Point position)
        {
            for (int y = 0; y < originalBitmap.Height; y++)
            {
                //Checks for out of bounds Y and corrects
                if (y + position.Y >= defaultCollagePictureHeight)
                {
                    return pictureToSet;
                }

                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    if (x + position.X >= defaultCollagePictureWidth)
                    {
                        return pictureToSet;
                    }

                    Color colorToSet = originalBitmap.GetPixel(x, y);
                    pictureToSet.SetPixel(x + position.X, y + position.Y, colorToSet);
                }
            }

            return pictureToSet;
        }

        /// <summary>
        /// Sets all the pixels of a picture onto the original picture
        /// the point location is the corner point and goes vertically 
        /// and returns the picture
        /// </summary>
        /// <param name="pictureToSet"></param>
        /// <param name="originalBitmap"></param>
        /// <param name="pointLocation"></param>
        private Bitmap SetPictureToBitmapLocationVMode(Bitmap pictureToSet, Bitmap originalBitmap, Point pointLocation)
        {
            Point pointValue = pointLocation;
            try
            {
                //Goes through each point and sets it to the location
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    //checks for outof bounds x and corrects
                    if (pointValue.X + x >= defaultCollagePictureWidth)
                    {
                        //LocationToPlacePicture = new Point(0, pointValue.Y);
                        LocationToPlacePicture = FindFirstEmptyPoint(pictureToSet);
                        return pictureToSet;
                    }

                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        //Checks for out of bounds Y and corrects
                        if (pointValue.Y + y >= defaultCollagePictureHeight)
                        {
                            //LocationToPlacePicture = new Point(pointValue.X, 0);
                            LocationToPlacePicture = FindFirstEmptyPoint(pictureToSet);
                            //Goes Xaxis the yaxis
                            return SetPictureToBitmapLocationHMode(pictureToSet, originalBitmap, pointLocation);
                        }

                        Color colorToSet = originalBitmap.GetPixel(x, y);
                        pictureToSet.SetPixel(pointValue.X + x, pointValue.Y + y, colorToSet);

                    }
                }
                //Sets the next position to add the picture
                return pictureToSet;
            }
            catch
            {
                return pictureToSet;
            }
        }

        #endregion
    }
}
