using System;
using System.IO;
using System.Linq;
using Emgu.CV;
using FaceDetector.Сlasses;


namespace FaceDetector
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var facade = new Facade(args);
            facade.CropAndSave();
        }
    }
}