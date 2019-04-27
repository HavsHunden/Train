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
        bool tempMenuItems;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            WeekGUI week1 = new WeekGUI();
            MainDock.Children.Add(week1);

        }

        private void MainCanvas_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (tempMenuItems)
            {
                int num = MainContextMenu.Items.Count;
                MainContextMenu.Items.RemoveAt(num - 1);
                tempMenuItems = false;
            }

            List<PanelGUI> WeekList = MainDock.Children.OfType<PanelGUI>().ToList<PanelGUI>();

            foreach (PanelGUI element in WeekList)
            {
                if (element.IsMouseOver)
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.Header = "japp";
                    MainContextMenu.Items.Add(menuItem);

                    tempMenuItems = true;
                }
            }
 
        }

        private void MainCanvas_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            if (tempMenuItems)
            {
                int num = MainContextMenu.Items.Count;
                MainContextMenu.Items.RemoveAt(num - 1);
                tempMenuItems = false;
            }
        }
    }

    public abstract class PanelGUI : DockPanel
    {
        protected Label panelGUIlabel;
        protected Nullable<Point> dragStart = null;

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            this.Background = Brushes.Aqua;
            dragStart = e.GetPosition(this);
            this.CaptureMouse();

        }

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    if(dragStart != null && e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        Point p2 = e.GetPosition();
        //    }

        //    base.OnMouseMove(e);
        //}
    }

    public class WeekGUI : PanelGUI
    {

        public WeekGUI()
        {
            DockPanel.SetDock(this, Dock.Top);

            this.Background = Brushes.Blue;

            panelGUIlabel = new Label();
            panelGUIlabel.Content = "Week";
            this.Children.Add(panelGUIlabel);

            for (int i = 0; i < 3; i++)
            {
                SessionGUI session = new SessionGUI();
                this.Children.Add(session);
            }
            
        }

    }

    public class SessionGUI : PanelGUI
    {
        public SessionGUI()
        {
            DockPanel.SetDock(this, Dock.Top);

            panelGUIlabel = new Label();
            panelGUIlabel.Content = "Session";
            this.Children.Add(panelGUIlabel);

            Random rand = new Random();
            int num = rand.Next(5);

            for (int i = 0; i < num; i++)
            {
                SlotGUI slot = new SlotGUI();
                this.Children.Add(slot);
            }

        }
    }

    public class SlotGUI : PanelGUI
    {
        public SlotGUI()
        {
            DockPanel.SetDock(this, Dock.Top);

            panelGUIlabel = new Label();
            panelGUIlabel.Content = "Slot";
            this.Children.Add(panelGUIlabel);
        }
    }
}
