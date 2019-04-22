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

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //DockPanel week2 = new DockPanel();
            //week2.Background = new SolidColorBrush(Colors.LightBlue);
            //Label label2 = new Label();
            //label2.Content = "test";
            //week2.Children.Add(label2);
            //DockPanel.SetDock(week2, Dock.Top);
            //MainDock.Children.Add(week2)

            Week week1 = new Week();
            MainDock.Children.Add(week1);

        }


    }

    public partial class Week : DockPanel
    {

        public Week()
        {
            DockPanel.SetDock(this, Dock.Top);

            Label weekLabel = new Label();
            weekLabel.Content = "Test";
            this.Children.Add(weekLabel);
        }

    }
}
