using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_todo
{
    public partial class MainWindow : Window
    {
        private Context db = new();

        public MainWindow()
        {
            InitializeComponent();
            db.Tasks.Load();

            Tasks.ItemsSource = db.Tasks.Local.ToObservableCollection();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskContent.Text.Trim()))
                return;
            db.Tasks.Add(new Task(TaskContent.Text, false));
            db.SaveChanges();
            TaskContent.Text = string.Empty;
        }

        private void TaskContentChanged(object sender, TextChangedEventArgs e) => db.SaveChanges();

        private void Delete(object sender, RoutedEventArgs e)
        {
            db.Tasks.Remove((Task)((Button)sender).DataContext);
            db.SaveChanges();
        }

        private void IsDoneChanged(object sender, RoutedEventArgs e) => db.SaveChanges();
    }
}