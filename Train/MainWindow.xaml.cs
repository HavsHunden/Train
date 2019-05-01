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

        Label label;
        bool tempMenuItems;
        public bool alreadyGrabbed = false;

        public MainWindow()
        {
            InitializeComponent();

            label = new Label();
            label.Content = "test";
            MainDock.Children.Add(label);
        }

        public void ChangeLabel(String change)
        {
            Label l = MainDock.Children[0] as Label;
            l.Content = "Test:" + change;
        }

        //Method for Removing elements
        public void RemoveObject(FrameworkElement el)
        {
            if (el.Parent == null)
                return;

            var panel = el.Parent as Panel;
            if (panel != null)
            {
                panel.Children.Remove(el);
                return;
            }

            var decorator = el.Parent as Decorator;
            if (decorator != null)
            {
                decorator.Child = null;
                return;
            }

            var contentPresenter = el.Parent as ContentPresenter;
            if (contentPresenter != null)
            {
                contentPresenter.Content = null;
                return;
            }

            var contentControl = el.Parent as ContentControl;
            if (contentControl != null)
                contentControl.Content = null;

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            WeekGUI week1 = new WeekGUI();
            MainDock.Children.Add(week1);

        }

        public Canvas GetMainDock()
        {
            return MainCanvas;
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
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        Point onCanvas = new Point();
        Point onPanel = new Point();
        Vector test = new Vector();
        DockPanel parentDockPanel;
        Canvas parentCanvas;

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (mainWindow.alreadyGrabbed == true)
            {
                return;
            }

            mainWindow.alreadyGrabbed = true;

            Panel parent = this.Parent as Panel;

            onCanvas = e.GetPosition(parent);

            //onCanvas = e.GetPosition(mainWindow.MainCanvas);
            onPanel = e.GetPosition(this);

            test = Point.Subtract(onCanvas, onPanel);

            //mainWindow.ChangeLabel(test.ToString());

            if (this.Parent is DockPanel)
            {
                parentDockPanel = this.Parent as DockPanel;
            }

            if (this.Parent is Canvas)
            {
                parentCanvas = this.Parent as Canvas;
            }

            

            PlaceholderGUI placeholder = new PlaceholderGUI(this.ActualWidth, this.ActualHeight);

            parent.Children.Insert(parent.Children.IndexOf(this), placeholder);

            
            mainWindow.RemoveObject(this);



            Canvas.SetLeft(this, test.X);
            Canvas.SetLeft(this, test.Y);

            mainWindow.MainCanvas.Children.Add(this);

            //Ok, everything done, now we can start draging
            dragStart = e.GetPosition(this);
            CaptureMouse();
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            int change = 0;

            dragStart = null;
            ReleaseMouseCapture();

            //Panel parent = this.Parent as Panel;

            if (parentDockPanel != null)
            {
                mainWindow.ChangeLabel("dockpanel");

                for (int i = 0; i < parentDockPanel.Children.Count; i++)
                {
                    if (parentDockPanel.Children[i] is PlaceholderGUI)
                    {
                        //change++;
                        parentDockPanel.Children.RemoveAt(i);
                    }
                }

                parentDockPanel = null;
            }
            if (parentCanvas != null)
            {
                mainWindow.ChangeLabel("canvas");

                for (int i = 0; i < parentCanvas.Children.Count; i++)
                {
                    if (parentCanvas.Children[i] is PlaceholderGUI)
                    {
                        //change++;
                        parentCanvas.Children.RemoveAt(i);
                    }
                }
            }


            //mainWindow.ChangeLabel(change.ToString());

            mainWindow.alreadyGrabbed = false;

            //List<PlaceholderGUI> removal = parent.Children.OfType<PlaceholderGUI>().ToList<PlaceholderGUI>();

            //foreach (PlaceholderGUI obj in removal)
            //{

            //    mainWindow.RemoveObject(obj);
            //}

            //foreach (var obj in parent.Children)
            //{
            //    if (obj is PlaceholderGUI)
            //    {
            //        FrameworkElement frameworkElement = obj as FrameworkElement;

            //        mainWindow.RemoveObject(frameworkElement);
            //    }


            //}
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (dragStart != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Point p2 = e.GetPosition(mainWindow.MainCanvas);

                Canvas.SetLeft(this, p2.X - dragStart.Value.X);
                Canvas.SetTop(this, p2.Y - dragStart.Value.Y);

            }

            base.OnMouseMove(e);
        }
    }

    public class PlaceholderGUI : PanelGUI
    {
        public PlaceholderGUI(double width, double height)
        {
            Background = Brushes.Green;
            DockPanel.SetDock(this, Dock.Top);
            this.Visibility = Visibility.Visible;

            this.Width = width;
            this.Height = height;
        }
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
