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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LikePindor
{
    public partial class SignIn : Window
    {
        public static char separator = '⁂';
        public static char separatorRow = '⸘';
        List<List<string>> list = new List<List<string>>();
        public SignIn()
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
            foreach (List<string> item in list)
                if (item[0] == UserName.Text & item[1] == Password.Text)
                {
                    View view = new View();
                    string path = $@"{Directory.GetCurrentDirectory()}\current.txt";
                    string export = string.Join(separator.ToString(), item);
                    using (StreamWriter current = new StreamWriter(path))
                    {
                        current.Write(export);
                    }
                    view.Show();
                    Close();
                    break;
                }
        }
    }
}
