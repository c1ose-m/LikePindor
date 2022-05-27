using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LikePindor
{
    public partial class SignUp : Window
    {
        public static char separator = '⁂';
        public static char separatorRow = '⸘';
        public string photo = "";
        SolidColorBrush blue = new SolidColorBrush(Color.FromArgb(64, 6, 38, 111));
        SolidColorBrush yellow = new SolidColorBrush(Color.FromArgb(64, 255, 208, 115));
        SolidColorBrush transparent = new SolidColorBrush(Colors.Transparent);
        LinearGradientBrush by = new LinearGradientBrush(Color.FromArgb(64, 6, 38, 111), Color.FromArgb(64, 255, 208, 115), 90);
        public static List<List<string>> list = new List<List<string>>();
        public SignUp()
        {
            InitializeComponent();
        }
        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Files.Users(out string import);
            List<string> listImport = import.Split(separatorRow).ToList();
            listImport.Remove("");
            List<List<string>> toImport = new List<List<string>>();
            foreach (string item in listImport)
            {
                List<string> tmp = item.Split(separator).ToList();
                tmp.Remove("");
                toImport.Add(tmp);
            }
            list = toImport;
            string export = "";
            string name = Name.Text;
            string password = Password.Text;
            string date = $"{Day.Text}.{Month.Text}.{Year.Text}";
            string sex = "";
            string interest = "";
            string savePhoto = photo;
            if (MaleB.Fill == blue)
                sex = "Male";
            else if (FemaleB.Fill == yellow)
                sex = "Female";
            if (LikeMaleB.Fill == blue)
                interest = "Male";
            else if (LikeFemaleB.Fill == yellow)
                interest = "Female";
            else if (LikeAllB.Fill == by)
                interest = "All";
            list.Add(new List<string> { name, password, date, sex, interest, savePhoto });
            foreach (List<string> item in list)
                export += string.Join(separator.ToString(), item) + separatorRow;
            Files.Users(export);
            View view = new View();
            string path = $@"{Directory.GetCurrentDirectory()}\current.txt";
            string exportC = string.Join(separator.ToString(), list[list.Count - 1]);
            using (StreamWriter current = new StreamWriter(path))
            {
                current.Write(exportC);
            }
            view.Show();
            Close();
        }
        private void Male_Click(object sender, RoutedEventArgs e)
        {
            MaleB.Fill = blue;
            FemaleB.Fill = transparent;
        }
        private void Female_Click(object sender, RoutedEventArgs e)
        {
            MaleB.Fill = transparent;
            FemaleB.Fill = yellow;
        }
        private void LikeMale_Click(object sender, RoutedEventArgs e)
        {
            LikeMaleB.Fill = blue;
            LikeFemaleB.Fill = transparent;
            LikeAllB.Fill = transparent;
        }
        private void LikeFemale_Click(object sender, RoutedEventArgs e)
        {
            LikeMaleB.Fill = transparent;
            LikeFemaleB.Fill = yellow;
            LikeAllB.Fill = transparent;
        }
        private void LikeAll_Click(object sender, RoutedEventArgs e)
        {
            LikeMaleB.Fill = transparent;
            LikeFemaleB.Fill = transparent;
            LikeAllB.Fill = by;
        }
        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openDialog.ShowDialog() == true)
            {
                photo = openDialog.FileName;
                Field.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(openDialog.FileName))
                };
            }
        }
    }
}
