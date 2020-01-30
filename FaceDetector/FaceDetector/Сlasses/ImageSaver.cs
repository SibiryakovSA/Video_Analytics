using System;
using System.Collections.Generic;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceDetector.Сlasses
{
    public static class ImageSaver
    {
        public static string Save(List<Image<Bgr, Byte>> images, string path = null)
        {
            if (path == null) path = AppDomain.CurrentDomain.BaseDirectory;
            var savePath = path + @"\FaceDetector result " + DateTime.Now.ToShortDateString();
            
            if (Directory.Exists(savePath)) Directory.Delete(savePath, true);
                Directory.CreateDirectory(savePath);

            int counter = 0;
            foreach (var image in images)
            {
                image.Save(savePath + @"\" + $"{++counter}.jpg");
            }
            

            return savePath;
        }
    }
}
