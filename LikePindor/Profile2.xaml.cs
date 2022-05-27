﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LikePindor
{
    public partial class Profile2 : Window
    {
        public Profile2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string import = "";
            string path = $@"{Directory.GetCurrentDirectory()}\profile.txt";
            try
            {
                using (StreamReader profile = new StreamReader(path))
                {
                    import = profile.ReadToEnd();
                }
            }
            catch (Exception) { }
            char separator = '⁂';
            List<string> toImport = import.Split(separator).ToList();
            toImport.Remove("");
            DateTime userDate = DateTime.Parse(toImport[2]);
            User.Content = $"{toImport[0]}, {DateTime.Now.Year - userDate.Year}";
            Status.Content = $"Sex: {toImport[3]}\nInterest: {toImport[4]}";
            try
            {
                Photo.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(toImport[5]))
                };
            }
            catch (Exception) { }
            string importL = "";
            string pathL = $@"{Directory.GetCurrentDirectory()}\likes.txt";
            try
            {
                using (StreamReader likes = new StreamReader(pathL))
                {
                    importL = likes.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
            int likesCount = 0;
            List<string> likesImport = importL.Split(separator).ToList();
            foreach (string item in likesImport)
                if (item == toImport[0])
                    likesCount++;
            Likes.Content = $"Likes: {likesCount}";
            string importD = "";
            string pathD = $@"{Directory.GetCurrentDirectory()}\dislikes.txt";
            try
            {
                using (StreamReader likes = new StreamReader(pathD))
                {
                    importD = likes.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
            int dislikesCount = 0;
            List<string> dislikesImport = importD.Split(separator).ToList();
            foreach (string item in dislikesImport)
                if (item == toImport[0])
                    dislikesCount++;
            Dislikes.Content = $"Dislikes: {dislikesCount}";
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            View view = new View();
            view.Show();
            Close();
        }
    }
}