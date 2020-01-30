using System;
using System.Collections.Generic;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceDetector.Сlasses
{
    public class Facade
    {
        private CascadeClassifier cascade = null;
        private Image<Bgr, Byte> Image = null;
        private List<Image<Bgr, Byte>> Images = null;
        private string PathToSave = null;

        public Facade(string[] args)
        {
            Console.WriteLine();
            var cascadeParam = ParamsReader.GetHaarCascadeParam(args);
            var imgParam = ParamsReader.GetImgParam(args);
            PathToSave = ParamsReader.GetPathToSaveParam(args);

            if (imgParam == null)
            {
                Console.WriteLine("Image parameter not founded, the program will be closed.");
                Environment.Exit(0);
            }

            if (File.Exists(imgParam))
                Image = ImageLoader.LoadImage(imgParam);
            else if (Directory.Exists(imgParam)) 
                Images = ImageLoader.LoadImagesFromFolder(imgParam);
            else
            {
                Console.WriteLine("Image not founded, the program will be closed.");
                Environment.Exit(0);
            }

            if (cascadeParam == null) 
                cascade = CascadeInitializer.InitDefaultCascade();
            else
                cascade = CascadeInitializer.InitCascade(cascadeParam);

        }

        public void CropAndSave()
        {
            List<Image<Bgr, Byte>> faces = null;
            if (Image == null)
                faces = FaceCropper.CropFacesFromMultipleImages(Images, cascade);
            else
                faces = FaceCropper.CropFaces(Image, cascade);

            if (faces.Count != 0)
            {
                if (PathToSave != null && !Directory.Exists(PathToSave))
                {
                    Console.WriteLine(
                        "The directory does not exist, path to save is not valid. Will be used default path.");
                    PathToSave = null;
                }
                PathToSave = ImageSaver.Save(faces, PathToSave);
                Console.WriteLine($"The program found {faces.Count} faces.\nThey were saved at\n{PathToSave}");
                
            }
            else
                Console.WriteLine("The program didn't find any faces.");

        }
    }
}