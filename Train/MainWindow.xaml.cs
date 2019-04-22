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

            Week week1 = new Week();
            MainDock.Children.Add(week1);

        }

        private void MainCanvas_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            UIElement element = (UIElement)Mouse.DirectlyOver;

            Week week = element as Week;

            MenuItem weekItem = new MenuItem();
            weekItem.Header = "Week";
            MainContextMenu.Items.Add(weekItem);

            if (week != null)
            {

                MainContextMenu.Items.Add(weekItem);
            }
        }
    }

    public class Week : DockPanel
    {

        public Week()
        {
            DockPanel.SetDock(this, Dock.Top);

            this.Background = Brushes.Blue;

            Label weekLabel = new Label();
            weekLabel.Content = "Week";
            this.Children.Add(weekLabel);

            for (int i = 0; i < 3; i++)
            {
                Session session = new Session();
                this.Children.Add(session);
            }
            
        }

    }

    public class Session : DockPanel
    {
        public Session()
        {
            DockPanel.SetDock(this, Dock.Top);

            Label sessionLabel = new Label();
            sessionLabel.Content = "Session";
            this.Children.Add(sessionLabel);

            Random rand = new Random();
            int num = rand.Next(5);

            for (int i = 0; i < num; i++)
            {
                Slot slot = new Slot();
                this.Children.Add(slot);
            }

        }
    }

    public class Slot : DockPanel
    {
        public Slot()
        {
            DockPanel.SetDock(this, Dock.Top);

            Label slotLabel = new Label();
            slotLabel.Content = "Slot";
            this.Children.Add(slotLabel);
        }
    }
}
