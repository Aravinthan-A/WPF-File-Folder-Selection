using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Folder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String Filepath = Rootpath();
            String mainpath = System.IO.Path.Combine(Filepath, "Country");
            DirectoryInfo directory = new DirectoryInfo(mainpath);
            DirectoryInfo[] listd = directory.GetDirectories();
            cbbname.ItemsSource = listd;
            cbbname.DisplayMemberPath = "Name";
        }
        private String Rootpath()
        {
            String Filepath = System.Environment.CurrentDirectory;
            int indexc = Filepath.IndexOf("bin");
            string removebin=Filepath.Remove(indexc);
            return removebin;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DirectoryInfo directoryInfo=(DirectoryInfo)cbbname.SelectedItem;
            DirectoryInfo[] listd = directoryInfo.GetDirectories();
            cmbcoun.ItemsSource=listd;
            cmbcoun.DisplayMemberPath = "Name";
        }
        private void cmbcoun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DirectoryInfo directoryInf = (DirectoryInfo)cmbcoun.SelectedItem;
            FileInfo[] filelist = directoryInf.GetFiles();
            cmdstate.ItemsSource = filelist;
            cmdstate.DisplayMemberPath = "Name";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Register sucessfully","Register",MessageBoxButton.OK,MessageBoxImage.Information);
        }
       
    }
}
