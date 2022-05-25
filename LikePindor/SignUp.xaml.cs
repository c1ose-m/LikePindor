using Microsoft.Win32;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LikePindor
{
    public partial class SignUp : Window
    {
        public static char separator = '⁂';
        public static char separatorRow = '⸘';
        public string photo = "";
        SolidColorBrush lightCyan = new SolidColorBrush(Colors.LightCyan);
        SolidColorBrush pink = new SolidColorBrush(Colors.Pink);
        SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);
        LinearGradientBrush uk = new LinearGradientBrush(Colors.Blue, Colors.Yellow, 90);
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
            if (MaleB.Fill == lightCyan)
                sex = "Male";
            else if (FemaleB.Fill == pink)
                sex = "Female";
            if (LikeMaleB.Fill == lightCyan)
                interest = "Male";
            else if (LikeFemaleB.Fill == pink)
                interest = "Female";
            else if (LikeAllB.Fill == uk)
                interest = "All";
            list.Add(new List<string> { name, password, date, sex, interest, savePhoto });
            foreach (List<string> item in list)
                export += string.Join(separator.ToString(), item) + separatorRow;
            Files.Users(export);
            View view = new View();
            view.Show();
            Close();
        }

        private void Male_Click(object sender, RoutedEventArgs e)
        {
            MaleB.Fill = lightCyan;
            FemaleB.Fill = lightGray;
        }

        private void Female_Click(object sender, RoutedEventArgs e)
        {
            MaleB.Fill = lightGray;
            FemaleB.Fill = pink;
        }

        private void LikeMale_Click(object sender, RoutedEventArgs e)
        {
            LikeMaleB.Fill = lightCyan;
            LikeFemaleB.Fill = lightGray;
            LikeAllB.Fill = lightGray;
        }

        private void LikeFemale_Click(object sender, RoutedEventArgs e)
        {
            LikeMaleB.Fill = lightGray;
            LikeFemaleB.Fill = pink;
            LikeAllB.Fill = lightGray;
        }

        private void LikeAll_Click(object sender, RoutedEventArgs e)
        {
            LikeMaleB.Fill = lightGray;
            LikeFemaleB.Fill = lightGray;
            LikeAllB.Fill = uk;
        }

        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openDialog.ShowDialog() == true)
            {
                photo = openDialog.FileName;
                Field.Fill = new ImageBrush{
                    ImageSource = new BitmapImage(new Uri(openDialog.FileName))
                };
            }
        }
    }
}
