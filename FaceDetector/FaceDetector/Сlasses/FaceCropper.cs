using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceDetector.Сlasses
{
    public static class FaceCropper
    {
        public static List<Image<Bgr, Byte>> CropFaces(Image<Bgr, Byte> image, CascadeClassifier cascade)
        {
            var grayImage = image.Convert<Gray, Byte>();
            var detectedFaces = cascade.DetectMultiScale(grayImage);
            var results = new List<Image<Bgr, Byte>>();

            foreach (var face in detectedFaces) 
                results.Add(image.Copy(new Rectangle(face.Location, face.Size)));

            return results;
        }

        public static List<Image<Bgr, Byte>> CropFacesFromMultipleImages(List<Image<Bgr, Byte>> images,
            CascadeClassifier cascade)
        {
            var results = new List<Image<Bgr, Byte>>();
            foreach (var image in images) results.AddRange(CropFaces(image, cascade));
            
            return results;
        }
    }
}