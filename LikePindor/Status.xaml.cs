using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LikePindor
{
    public partial class Status : Window
    {
        public Status()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            char separator = '⁂';
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
            List<string> likesImport = importL.Split(separator).ToList();
            int likesCount = likesImport.Count;
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
            List<string> dislikesImport = importD.Split(separator).ToList();
            int dislikesCount = dislikesImport.Count;
            List<Border> borders = new List<Border>();
            for (int i = 0; i < 11; i++)
            {
                borders.Add(new Border
                {
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(0, 0, 0, 5)
                });
                Grid.SetRow(borders[i], i);
                Grid.SetColumnSpan(borders[i], 6);
                Grid.Children.Add(borders[i]);
            }
            Border verticalBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0, 0, 5, 0)
            };
            Grid.SetRowSpan(verticalBorder, 12);
            Grid.Children.Add(verticalBorder);
            int max = Math.Max(likesCount, dislikesCount);
            decimal step = Math.Round((decimal)max / 10m) + 1;
            List<TextBox> textBoxes = new List<TextBox>();
            decimal likesSteps = 0, dislikesSteps = 0;
            for (int i = 0; i < 11; i++)
            {
                textBoxes.Add(new TextBox
                {
                    Text = $"{step * 10 - step * i}",
                    VerticalContentAlignment = VerticalAlignment.Bottom,
                    HorizontalContentAlignment = HorizontalAlignment.Right
                });
                Grid.SetRow(textBoxes[i], i);
                Grid.Children.Add(textBoxes[i]);
                if (step * i < likesCount)
                    likesSteps++;
                if (step * i < dislikesCount)
                    dislikesSteps++;
            }
            Rectangle rectangleL = new Rectangle
            {
                Fill = new SolidColorBrush(Color.FromRgb(6, 38, 111)),
                Stroke = new SolidColorBrush(Color.FromRgb(255, 208, 115)),
                StrokeThickness = 5
            };
            Rectangle rectangleD = new Rectangle
            {
                Fill = new SolidColorBrush(Color.FromRgb(255, 208, 115)),
                Stroke = new SolidColorBrush(Color.FromRgb(6, 38, 111)),
                StrokeThickness = 5
            };
            Grid.SetColumn(rectangleL, 2);
            Grid.SetColumn(rectangleD, 4);
            Grid.SetRow(rectangleL, 11 - (int)likesSteps);
            Grid.SetRowSpan(rectangleL, (int)likesSteps);
            Grid.SetRow(rectangleD, 11 - (int)dislikesSteps);
            Grid.SetRowSpan(rectangleD, (int)dislikesSteps);
            Grid.Children.Add(rectangleL);
            Grid.Children.Add(rectangleD);
            TextBox textBoxLikes = new TextBox
            {
                Text = "LIKES",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontSize = 72
            };
            TextBox textBoxDislikes = new TextBox
            {
                Text = "DISLIKES",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontSize = 72
            };
            Grid.SetColumn(textBoxLikes, 2);
            Grid.SetColumn(textBoxDislikes, 4);
            Grid.SetRow(textBoxLikes, 12);
            Grid.SetRow(textBoxDislikes, 12);
            Grid.Children.Add(textBoxLikes);
            Grid.Children.Add(textBoxDislikes);
        }
    }
}
