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
            List<List<string>> np = new List<List<string>>();
            foreach (List<string> item in list)
                np.Add(new List<string> { item[0], item[1] });
            if (np.Contains(new List<string> { UserName.Text, Password.Text }))
                MessageBox.Show("Лешаgей");
            else
                MessageBox.Show("Лешаnеgей");
        }
    }
}
