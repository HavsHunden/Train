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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace Train
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DockPanel week = new DockPanel();

            week.Background = new SolidColorBrush(Colors.LightBlue);

            Label label = new Label();

            label.Content = "testtesttest";

            DockPanel.SetDock(week, Dock.Top);

            week.Children.Add(label);

            MainDock.Children.Add(week);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DockPanel week2 = new DockPanel();
            week2.Background = new SolidColorBrush(Colors.LightBlue);
            Label label2 = new Label();
            label2.Content = "test";
            week2.Children.Add(label2);
            DockPanel.SetDock(week2, Dock.Top);
            MainDock.Children.Add(week2);

        }


    }
}
