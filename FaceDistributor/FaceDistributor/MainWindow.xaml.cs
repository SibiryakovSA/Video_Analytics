using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace FaceDistributor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<string> allImages = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImagesButtonBaseOnClick(object sender, RoutedEventArgs e)
        {
            List<string> temp = new List<string>();
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image(*.img;*.jpg;)|*.jpg;*.img;";
            fileDialog.Multiselect = true;

            if (fileDialog.ShowDialog() != true)
                return;

            temp.AddRange(fileDialog.FileNames);

            if (allImages.Count != 0)
            {
                var saveChoiseResult =
                    MessageBox.Show("do you want to add to verified images?", "", MessageBoxButton.YesNoCancel);
                if (saveChoiseResult == MessageBoxResult.Yes)
                {
                    foreach (var t in temp)
                        if (!allImages.Contains(t))
                            allImages.Add(t);
                }
                else if (saveChoiseResult == MessageBoxResult.No)
                {
                    allImages = temp;
                    DisplayedImage.Source = new BitmapImage(new Uri(temp[0]));
                }
            }
            else
            {
                allImages = temp;
                DisplayedImage.Source = new BitmapImage(new Uri(temp[0]));
            }
        }

        private void PosButtonOnClick(object sender, RoutedEventArgs e) => DistrImagePosNeg(true);

        private void NegButtonOnClick(object sender, RoutedEventArgs e) => DistrImagePosNeg(false);

        private void DistrImagePosNeg(bool posNeg)
        {
            //true if  pos, false if neg

            string savePath = posNeg
                ? AppDomain.CurrentDomain.BaseDirectory + "Pos"
                : AppDomain.CurrentDomain.BaseDirectory + "Neg";
            if (allImages.Count != 0)
            {
                Directory.CreateDirectory(savePath);
                File.Copy(allImages[0],
                    savePath + "\\" + Path.GetFileName(allImages[0]), true);

                allImages.Remove(allImages[0]);
                if (allImages.Count != 0)
                {
                    DisplayedImage.Source = new BitmapImage(new Uri(allImages[0]));
                }
                else
                    DisplayedImage.Source = null;
            }
        }
    }
}