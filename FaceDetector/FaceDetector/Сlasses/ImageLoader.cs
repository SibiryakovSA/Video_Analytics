using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;


namespace FaceDetector.Сlasses
{
    public static class ImageLoader
    {
        public static Image<Bgr, Byte> LoadImage(string path)
        {
            Image<Bgr, Byte> res = null;

            try
            {
                res = new Image<Bgr, byte>(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"image not found.\n{path}");
                throw;
            }
            
            return res;
        }

        public static List<Image<Bgr, Byte>> LoadImagesFromFolder(string folderPath)
        {
            var imagesPaths = Directory.GetFiles(folderPath, "*.jpg").ToList();
            imagesPaths.AddRange(Directory.GetFiles(folderPath, "*.png"));
            var res = new List<Image<Bgr, Byte>>();

            foreach (var imagePath in imagesPaths)
            {
                var img = LoadImage(imagePath);
                if (img != null) res.Add(img);
            }

            return res;
        }
    }
}