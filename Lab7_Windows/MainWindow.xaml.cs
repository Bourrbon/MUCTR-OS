using System.Runtime.InteropServices;
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

namespace Lab7
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

      
        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем список перед использованием
            Wins.handleList.Clear();
            WinTree.Items.Clear();

            if (Wins.SearchOnlyVisibleWindows)
            {
                Wins.EnumWindows(new Wins.EnumWindowsProc(Wins.EnumWindowsOnlyVisibleCallback), IntPtr.Zero);
            }
            else
            {
                Wins.EnumWindows(new Wins.EnumWindowsProc(Wins.EnumWindowsAllCallback), IntPtr.Zero);
            }

            
            OutputBox.Text = $"Количество окон в системе: {Wins.handleList.Count}";

            string[] winTitles = new string[Wins.handleList.Count];

            // Получаем имена окон
            for (int i = 0; i < winTitles.Length; i++)
            {
                StringBuilder sb = new StringBuilder((int)Wins.MaxTitleLength);

                Wins.GetWindowTextA(Wins.handleList[i], sb, Wins.MaxTitleLength);

                string currentTitle = sb.ToString();
                
                if ( string.IsNullOrEmpty(currentTitle.Trim()) )
                {
                    winTitles[i] = "---Empty---";
                }
                else
                {
                    winTitles[i] = currentTitle;
                }

                

                TreeViewItem item = new TreeViewItem { Header = winTitles[i] };
                item.IsExpanded = true;
                // Добавляем хотя бы один подэлемент, чтобы появился маркер
                TreeViewItem childItem = new TreeViewItem { Header = Convert.ToString(Wins.handleList[i]) };
                item.Items.Add(childItem);
                WinTree.Items.Add(item);
            }
        }

        public void SearchVisibleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Wins.SearchOnlyVisibleWindows = true;
        }

        public void SearchVisibleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Wins.SearchOnlyVisibleWindows = false;
        }

        private void SetPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                (HeightControl.Value > 0) && 
                (WidthControl.Value  > 0) && 
                (XCoordControl.Value > 0) &&
                (YCoordControl.Value > 0) &&
                (Wins.SelectedWindowHandle != IntPtr.Zero)
                )
            {
                Wins.MoveWindow(
                    Wins.SelectedWindowHandle,
                    (int)XCoordControl.Value,
                    (int)YCoordControl.Value,
                    (int)WidthControl.Value,
                    (int)HeightControl.Value,
                    false);
            }
        }

        private void SetTitleButton_Click(object sender, RoutedEventArgs e)
        {
            if ( (Wins.SelectedWindowHandle != IntPtr.Zero) && (!string.IsNullOrEmpty(WindowTitleBox.Text.Trim())) )
            {
                Wins.SetWindowText(Wins.SelectedWindowHandle, WindowTitleBox.Text);
            }

        }

        private void WinTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem selectedItem = (TreeViewItem)WinTree.SelectedItem;

            if (selectedItem != null)
            {
                if (selectedItem is TreeViewItem treeViewItem)
                {
                    string value = treeViewItem.Header.ToString();

                    if (IntPtr.TryParse(value, out Wins.SelectedWindowHandle) )
                    {
                        /// ... 
                    }
                    else
                    {
                        Wins.SelectedWindowHandle = IntPtr.Zero;
                    }
                }
            }
        }
    }
}