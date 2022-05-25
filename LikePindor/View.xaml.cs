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
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Window
    {
        public static char separator = '⁂';
        public static char separatorRow = '⸘';
        public List<List<string>> list = new List<List<string>>();
        public View()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
            Random random = new Random();
            int n = random.Next(0, list.Count);
            DateTime userDate = DateTime.Parse(list[n][2]);
            Name.Content = $"{list[n][0]}, {DateTime.Now.Year - userDate.Year}";
            Status.Text = $"Sex: {list[n][3]}\nInterest: {list[n][4]}";
            try
            {
                Field.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(list[n][5]))
                };
            }
            catch (Exception) { }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            Close();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Dislike_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int n = random.Next(0, list.Count);
            DateTime userDate = DateTime.Parse(list[n][2]);
            Name.Content = $"{list[n][0]}, {DateTime.Now.Year - userDate.Year}";
            Status.Text = $"Sex: {list[n][3]}\nInterest: {list[n][4]}";
            try
            {
                Field.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(list[n][5]))
                };
            }
            catch (Exception) { }
        }

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int n = random.Next(0, list.Count);
            DateTime userDate = DateTime.Parse(list[n][2]);
            Name.Content = $"{list[n][0]}, {DateTime.Now.Year - userDate.Year}";
            Status.Text = $"Sex: {list[n][3]}\nInterest: {list[n][4]}";
            try
            {
                Field.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(list[n][5]))
                };
            }
            catch (Exception)
            {
                Field.Fill = new SolidColorBrush(Colors.LightGray);
            }
        }
    }
}
