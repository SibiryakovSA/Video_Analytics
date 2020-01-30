using System;
using System.IO;
using System.Linq;
using Emgu.CV;

namespace FaceDetector.Сlasses
{
    public static class CascadeInitializer
    {
        public static CascadeClassifier InitCascade(string cascadeName)
        {
            CascadeClassifier cascade = null;
            
            if (cascadeName.LastIndexOf(".xml") == -1) cascadeName += ".xml";
            
            try
            {
                cascade = new CascadeClassifier(AppDomain.CurrentDomain.BaseDirectory + @"HaarCascades\" + cascadeName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Cascade not founded.\nWill be used default cascade.");
                cascade = InitDefaultCascade();
            }

            return cascade;
        }

        public static CascadeClassifier InitDefaultCascade() => InitCascade("haarcascade_frontalface_default.xml");
    }
}