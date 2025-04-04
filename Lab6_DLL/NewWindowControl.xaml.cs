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

namespace Lab6_DLL
{
	/// <summary>
	/// Interaction logic for NewWindowControl.xaml
	/// </summary>
	public partial class NewWindowControl : UserControl
	{
		public NewWindowControl()
		{
			InitializeComponent();
		}

		private void InputBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				try
				{
					double inp = Convert.ToDouble(InputBox.Text);
					double res = TestClass.func(inp);
					OutputBox.Text = Convert.ToString(res);
				}
				catch (Exception ex)
				{
                    // Вызываем диалоговое окно с сообщением об ошибке
                    MessageBoxResult result = MessageBox.Show(
                    ex.Message,
                    "Ошибка вычисления",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }

			}
		}

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
			Environment.Exit(0);
        }
    }
}
