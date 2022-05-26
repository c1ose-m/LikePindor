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
    public partial class View : Window
    {
        public int n = 0;
        public static char separator = '⁂';
        public static char separatorRow = '⸘';
        public List<List<string>> list = new List<List<string>>();
        static string directory = Directory.GetCurrentDirectory();
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
            n = random.Next(0, list.Count);
            DateTime userDate = DateTime.Parse(list[n][2]);
            Name.Text = $"{list[n][0]}, {DateTime.Now.Year - userDate.Year}";
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
            string import = "";
            string path = $@"{directory}\dislikes.txt";
            try
            {
                using (StreamReader dislikes = new StreamReader(path))
                {
                    import = dislikes.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
            List<string> listImport = import.Split(separator).ToList();
            listImport.Add(list[n][0]);
            string export = string.Join(separator.ToString(), listImport);
            using (StreamWriter dislikes = new StreamWriter(path))
            {
                dislikes.Write(export);
            }
            Random random = new Random();
            n = random.Next(0, list.Count);
            DateTime userDate = DateTime.Parse(list[n][2]);
            Name.Text = $"{list[n][0]}, {DateTime.Now.Year - userDate.Year}";
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
            string import = "";
            string path = $@"{directory}\likes.txt";
            try
            {
                using (StreamReader likes = new StreamReader(path))
                {
                    import = likes.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
            List<string> listImport = import.Split(separator).ToList();
            listImport.Add(list[n][0]);
            string export = string.Join(separator.ToString(), listImport);
            using (StreamWriter likes = new StreamWriter(path))
            {
                likes.Write(export);
            }
            Random random = new Random();
            n = random.Next(0, list.Count);
            DateTime userDate = DateTime.Parse(list[n][2]);
            Name.Text = $"{list[n][0]}, {DateTime.Now.Year - userDate.Year}";
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

        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            Profile2 profile2 = new Profile2();
            string path = $@"{Directory.GetCurrentDirectory()}\profile.txt";
            string export = string.Join(separator.ToString(), list[n]);
            using (StreamWriter profile = new StreamWriter(path))
            {
                profile.Write(export);
            }
            profile2.Show();
            Close();
        }
    }
}
