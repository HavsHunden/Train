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

            DockPanel week1 = new DockPanel();

            week1.Background = Brushes.Blue;

            week1.Height = 50;

            week1.Width = 50;

            Label label = new Label();

            label.Content = "test1";

            week1.Children.Add(label);

            DockPanel.SetDock(week1, Dock.Top);

            //this.SizeToContent = SizeToContent.WidthAndHeight;

            MainDocker.Children.Add(week1);

            DockPanel week2 = new DockPanel();

            week2.Background = Brushes.Blue;

            week2.Height = 50;

            week2.Width = 50;

            Label label2 = new Label();

            label2.Content = "test2";

            week2.Children.Add(label2);

            DockPanel.SetDock(week2, Dock.Bottom);

            MainDocker.Children.Add(week2);
        }
    }
}
